Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO



Public Class DatosEngrasadores

    Dim DPelets As AdoSQL
    Dim DOps As AdoSQL
    Dim DArticulos As AdoSQL
    Private DProcLinea As AdoSQL
    Private DControlDiario As AdoSQL
    Private DLineasProd As AdoSQL
    Dim DArt As AdoSQL
    Dim DDatosEng As AdoSQL
    Dim DRepEng As AdoSQL
    Dim DVariosEng As AdoSQL
    Dim DConsEng As AdoSQL
    Dim DVarios As AdoSQL
    Dim OPEng(4) As String
    Dim OPEngRep(4) As String
    Dim CodForEng(4) As String
    Dim CodForEngRep(4) As String
    Dim LPEng(4) As String
    Dim LPEngRep(4) As String
    Dim CodMatEng(4, 3) As String 'Aca se maneja una matriz de 2x2 porque para la máquina 4 se deben enviar 2 codigos
    Dim CodMatEngRep(4) As String
    Dim NomMatEng(4, 3) As String
    Dim NomMatEngRep(4, 3) As String
    Dim PesoMetaEng(4, 3) As String
    Dim BachesMetaEng(4) As Int16
    Dim PesoMetaForEng(4) As Double
    Dim TotalOPEng(4, 3) As Double
    Dim NomProdEng(4) As String
    Dim IdMaq(4) As String
    Dim IdReg(4) As Int64
    Dim FormLoad As Boolean
    Dim UltimaOPEng(5) As String


    Public Sub DatosEngrasadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then Return

            DPelets = New AdoSQL("DATOSPELETS")
            DArt = New AdoSQL("ARTICULOS")
            DOps = New AdoSQL("OPS")
            DArticulos = New AdoSQL("ARTICULOS")
            DProcLinea = New AdoSQL("PROCESOENLINEA")
            DControlDiario = New AdoSQL("CONTROLDIARIO")
            DLineasProd = New AdoSQL("LINEASPROD")
            DVarios = New AdoSQL("Varios")
            DConsEng = New AdoSQL("ConsumosEng")

            'Estos objetos se conectan directamente a la base de datos de sigcopro
            DDatosEng = New AdoSQL("SigcoproChronos", RutaDB_SigCoPro_Engrasadores)
            DRepEng = New AdoSQL("Vistas PLC", RutaDB_SigCoPro_Engrasadores)
            DVariosEng = New AdoSQL("Vistas PLC", RutaDB_SigCoPro_Engrasadores)



            If IsNothing(UltimaOPEng(2)) Then UltimaOPEng(2) = 0
            If IsNothing(UltimaOPEng(3)) Then UltimaOPEng(3) = 0
            If IsNothing(UltimaOPEng(4)) Then UltimaOPEng(4) = 0

            TimSeg_Tick(Nothing, Nothing)

            FormLoad = True

        Catch ex As Exception
            'MsgError(ex.ToString)
            Evento(ex.StackTrace.ToString)
        End Try

    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try

            TSeg.Text = (Eval(TSeg.Text) + 1).ToString
            If Eval(TSeg.Text) > 100000 Then TSeg.Text = 0

            If Eval(TSeg.Text) Mod 3 = 0 Then
                FEnviaDatosEng_Click(Nothing, Nothing)
                FCaptDatosEng_Click(Nothing, Nothing)
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub FEnviaDatosEng_Click(sender As System.Object, e As System.EventArgs) Handles FEnviaDatosEng.Click
        Try
            DDatosEng.Open("select * from CHRONOS where PLC='ENG1'")

            DGEng.AutoGenerateColumns = False
            DGEng.DataSource = DDatosEng.DataTable

            If DDatosEng.Count Then

                For i = 1 To 1
                    DDatosEng.Find("ITEM='OP" + i.ToString + "'")

                    If DDatosEng.EOF = False AndAlso Val(DDatosEng.RecordSet("DATO")) >= 0 Then

                        'Se buscan todos los datos correspondientes de la OP y se escriben en la tabla

                        OPEng(i) = Val(DDatosEng.RecordSet("DATO"))

                        If OPEng(i) = 0 Then
                            UltimaOPEng(i) = OPEng(i)
                            GoTo ResetValoresPelets
                        End If

                        If OPEng(i) = UltimaOPEng(i) Then Continue For

                        DVarios.Open("Select * from OPS where OP='" + OPEng(i) + "'")

                        If DVarios.Count = 0 Then
                            DDatosEng.RecordSet("DATO") = 0
                            DDatosEng.Open("Update CHRONOS set DATO='OP NO EXISTE' where ITEM='NOMPROD" + i.ToString + "'")
                            DDatosEng.Update()
                            GoTo ResetValoresPelets
                        Else
                            CodForEng(i) = DVarios.RecordSet("CODFOR")
                            LPEng(i) = DVarios.RecordSet("LP")
                            BachesMetaEng(i) = DVarios.RecordSet("REAL")
                            NomProdEng(i) = DVarios.RecordSet("NOMPROD")
                        End If

                        'Sacamos el pesototal de la formula

                        DVarios.Open("Select * from FORMULAS where CODFOR='" + CodForEng(i) + "' and LP='" + LPEng(i) + "'")

                        If DVarios.Count > 0 Then
                            PesoMetaForEng(i) = Eval(DVarios.RecordSet("TOTALFOR"))
                        End If


                        'Seleccionamos el material que va como post engrase
                        DVarios.Open("Select * from DATOSFOR where A='PE' and CODFOR='" + CodForEng(i) + "' and LP='" + LPEng(i) + "'")

                        If DVarios.Count = 0 Then
                            DDatosEng.Open("Update CHRONOS set DATO='FORM SIN MAT. PE' where ITEM='NOMPROD" + i.ToString + "'")
                            GoTo ResetValoresPelets
                        End If

                        CodMatEng(i, 0) = DVarios.RecordSet("CODMAT")
                        PesoMetaEng(i, 0) = DVarios.RecordSet("PESOMETA")
                        NomMatEng(i, 0) = DVarios.RecordSet("NOMMAT")
                        TotalOPEng(i, 0) = PesoMetaEng(i, 0) * BachesMetaEng(i)


                        'Escribimos los valores en la tabla
                        'Nombre del producto
                        DDatosEng.Find("ITEM='NOMPROD" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso DDatosEng.RecordSet("DATO") <> NomProdEng(i) Then
                            DDatosEng.RecordSet("DATO") = NomProdEng(i)
                            DDatosEng.Update()
                        End If

                        'Nombre de Orden
                        DDatosEng.Find("ITEM='ORDEN" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso DDatosEng.RecordSet("DATO") <> LPEng(i) Then
                            DDatosEng.RecordSet("DATO") = LPEng(i)
                            DDatosEng.Update()
                        End If

                        'Peso total Form
                        DDatosEng.Find("ITEM='TOTALFOR" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso Eval(DDatosEng.RecordSet("DATO")) <> PesoMetaForEng(i) Then
                            DDatosEng.RecordSet("DATO") = PesoMetaForEng(i)
                            DDatosEng.Update()
                        End If

                        'CodMat Aceite
                        DDatosEng.Find("ITEM='CODMAT" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso DDatosEng.RecordSet("DATO") <> CodMatEng(i, 0) Then
                            DDatosEng.RecordSet("DATO") = CodMatEng(i, 0)
                            DDatosEng.Update()
                        End If

                        'NomMat Aceite
                        DDatosEng.Find("ITEM='NOMMAT" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso DDatosEng.RecordSet("DATO") <> NomMatEng(i, 0) Then
                            DDatosEng.RecordSet("DATO") = NomMatEng(i, 0)
                            DDatosEng.Update()
                        End If

                        'PesoMeta Aceite
                        DDatosEng.Find("ITEM='PESOMETA" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso Val(DDatosEng.RecordSet("DATO")) <> PesoMetaEng(i, 0).ToString Then
                            DDatosEng.RecordSet("DATO") = PesoMetaEng(i, 0)
                            DDatosEng.Update()
                        End If

                        'Baches Meta
                        DDatosEng.Find("ITEM='BACHESMETA" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso Val(DDatosEng.RecordSet("DATO")) <> BachesMetaEng(i).ToString Then
                            DDatosEng.RecordSet("DATO") = BachesMetaEng(i)
                            DDatosEng.Update()
                        End If

                        'Peso Meta OP
                        DDatosEng.Find("ITEM='TOTALMETAOP" + i.ToString + "'")
                        If Not DDatosEng.EOF AndAlso DDatosEng.RecordSet("DATO") <> TotalOPEng(i, 0).ToString Then
                            DDatosEng.RecordSet("DATO") = TotalOPEng(i, 0)
                            DDatosEng.Update()
                        End If

                        UltimaOPEng(i) = OPEng(i)

                    End If

                    Continue For

ResetValoresPelets:
                    'Actualizamos todos los valores a cero en la tabla CHRONOS


                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='ORDEN" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='TOTALFOR" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='' where ITEM='NOMPROD" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='CODMAT" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='NOMMAT" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='PESOMETA" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='BACHESMETA" + i.ToString + "'")
                    DVariosEng.Open("Update CHRONOS set DATO='0' where ITEM='TOTALMETAOP" + i.ToString + "'")
                Next

            End If

        Catch ex As Exception
            'MsgError(ex.ToString)
            Evento(ex.StackTrace.ToString)
        End Try
    End Sub

    Private Sub FCaptDatosEng_Click(sender As System.Object, e As System.EventArgs) Handles FCaptDatosEng.Click
        Try

            'Se realiza un ciclo para capturar los datos de los 3 engrasadores

            Dim j As Int16 = 0


            For j = 1 To 1

                DRepEng.Open("Select top 30 * from vEngrasadorPelet" + j.ToString + " order BY FECHAINI DESC")

                For Each DRRepPLC As DataRow In DRepEng.Rows

                    OPEngRep(j) = DRRepPLC("OP").ToString

                    DVarios.Open("Select * from OPS where OP='" + OPEngRep(j) + "'")
                    If DVarios.Count = 0 Then Continue For

                    CodForEngRep(j) = DVarios.RecordSet("CODFOR")
                    LPEngRep(j) = DVarios.RecordSet("LP")
                    If j = 1 Then
                        DVarios.Open("Select * from DATOSFOR where A='PE' and CODFOR='" + CodForEngRep(j) + "' and LP='" + LPEngRep(j) + "'")
                        If DVarios.Count = 0 Then Continue For
                        CodMatEngRep(j) = DVarios.RecordSet("CODMAT")
                    Else
                        CodMatEngRep(j) = DRRepPLC("CODMAT").ToString
                    End If



                    'If i = 2 Or i = 3 Then
                    'IdMaq(i) = DRRepPLC("IDMAQUINA")
                    IdReg(j) = Format(CDate(DRRepPLC("FECHAINI")), "MMdd") * 100000 + DRRepPLC("ID")

                    DConsEng.Open("select * from CONSUMOSENG where OP='" + OPEngRep(j) +
                              "' and FECHA='" + Format(CDate(DRRepPLC("FECHAINI")), "yyyy/MM/dd HH:mm") +
                             "' AND CONT=" + IdReg(j).ToString + " AND CODMAT='" + CodMatEngRep(j) + "'")
                    'Else

                    'End If


                    If DConsEng.Count = 0 Then
                        DConsEng.AddNew()
                        DConsEng.RecordSet("OP") = OPEngRep(j)
                        DConsEng.RecordSet("CONT") = IdReg(j)
                        DConsEng.RecordSet("MAQUINA") = j.ToString
                        DConsEng.RecordSet("FECHA") = Format(CDate(DRRepPLC("FECHAINI")), "yyyy/MM/dd HH:mm")
                        DConsEng.RecordSet("CODMAT") = CodMatEngRep(j)
                        If j = 4 Then
                            DVarios.Open("Select * from DATOSFOR where A='EX' and CODFOR='" + CodForEngRep(j) + "' and LP='" + LPEngRep(j) + "' and CODMAT='" + CodMatEngRep(j) + "'")
                            If DVarios.Count Then
                                'La tolva es 71 o 72, restamos 70 para que nos quede el número de tanque
                                DConsEng.RecordSet("TOLVA") = DVarios.RecordSet("TOLVA") - 70
                            End If
                        Else
                            DConsEng.RecordSet("TOLVA") = 1
                        End If
                        'Seleccionamos el material que va como post engrase
                        DVarios.Open("Select * from DATOSFOR where A='PE' and CODFOR='" + CodForEngRep(j) + "' and LP='" + LPEngRep(j) + "'")

                        If DVarios.Count > 0 Then
                            DConsEng.RecordSet("PESOMETA") = DVarios.RecordSet("PESOMETA")
                        Else
                            DConsEng.RecordSet("PESOMETA") = DRRepPLC("PESOMETA")
                        End If
                        DConsEng.RecordSet("PESOREAL") = DRRepPLC("PESOREAL")
                        DArt.Open("select * from ARTICULOS where CODINT='" + CodMatEngRep(j) + "'")
                        If DArt.Count Then
                            DConsEng.RecordSet("CODMATB") = DArt.RecordSet("CODEXT")
                            DConsEng.RecordSet("NOMMAT") = DArt.RecordSet("NOMBRE")
                        Else
                            DConsEng.RecordSet("CODMATB") = 0
                        End If

                        DOps.Open("select * from OPS where OP='" + DRRepPLC("OP").ToString + "'")
                        If DOps.Count Then
                            DConsEng.RecordSet("CODPROD") = DOps.RecordSet("CODPROD")
                            DConsEng.RecordSet("NOMPROD") = DOps.RecordSet("NOMPROD")
                        End If
                        DConsEng.Update()
                        APlanoEng("Máq: " + j.ToString + vbTab + " CodMat:" + CodMatEngRep(j) + vbTab + " Real:" + DRRepPLC("PESOREAL").ToString)
                    Else
                        DConsEng.RecordSet("PESOREAL") = DRRepPLC("PESOREAL")
                        DConsEng.Update()
                    End If

                Next 'DRRepPLC

            Next 'j


            'Se realiza un ciclo para capturar los datos de la extruder




        Catch ex As Exception
            'MsgError(ex.ToString)
            Evento(ex.StackTrace.ToString)
        End Try
    End Sub
End Class