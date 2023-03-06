Option Explicit On

Imports System
Imports System.Data
Imports System.IO
Imports System.Threading.Thread
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Common



Public Class PDosifica

 
    Public Shared TOPB As ArrayControles(Of Label)
    Public Shared TCodFor As ArrayControles(Of Label)
    Public Shared TNomFor As ArrayControles(Of Label)
    Public Shared TTolva As ArrayControles(Of Label)
    Public Shared TNomMat As ArrayControles(Of Label)
    Public Shared BRecAlarma As ArrayControles(Of Button)
    Public Shared TBacheNo As ArrayControles(Of Label)
    Public Shared TNeto As ArrayControles(Of Label)
    Public Shared TBruto As ArrayControles(Of Label)
    Public Shared TMeta As ArrayControles(Of Label)
    Public Shared TFalta As ArrayControles(Of Label)
    Public Shared BarraNeto As ArrayControles(Of ProgressBar)
    Public Shared BarraBruto As ArrayControles(Of ProgressBar)
    Public Shared TStatB As ArrayControles(Of Label)
    Public Shared ShB As ArrayControles(Of PictureBox)
    Public Shared ShRunB As ArrayControles(Of PictureBox)
    Public Shared TOutB As ArrayControles(Of Label)

    Public Shared TCodMat As ArrayControles(Of Label)

    Public Shared BReIni As ArrayControles(Of Button)
    Public Shared TNomTv As ArrayControles(Of Label)

    Public DProcEnLinea As AdoNet
    Public DArt As AdoNet
    Private DUsuarios As AdoNet
    Private DVarios As AdoNet
    Private DVarios2 As AdoNet
    Private DBasculas As AdoNet
    Private DProcPend As AdoNet
    Private DProc As AdoNet
    Private DProcPend0002 As AdoNet
    Private DOPs As AdoNet
    Private DTolvas As AdoNet
    Private DDatosFor As AdoNet
    Private DConsumos As AdoNet
    Private DFor As AdoNet

    Private Seccion As String
    Private NoBache As Int16
    Private CodFor As String
    Private LP As String
    Private Paso As Int16
    Private Msg As String
    Private Palabra As String
    Private Baches As Integer
   


    Public Sub PDosifica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
       
            TOPB = New ArrayControles(Of Label)("TOPB", Me)
            TCodFor = New ArrayControles(Of Label)("TCodFor", Me)
            TNomFor = New ArrayControles(Of Label)("TNomFor", Me)
            TTolva = New ArrayControles(Of Label)("TTolva", Me)
            TNomMat = New ArrayControles(Of Label)("TNomMat", Me)
            BRecAlarma = New ArrayControles(Of Button)("BRecAlarma", Me)
            TBacheNo = New ArrayControles(Of Label)("TBacheNo", Me)
            TNeto = New ArrayControles(Of Label)("TNeto", Me)
            TBruto = New ArrayControles(Of Label)("TBruto", Me)
            TMeta = New ArrayControles(Of Label)("TMeta", Me)
            TFalta = New ArrayControles(Of Label)("TFalta", Me)
            TOutB = New ArrayControles(Of Label)("TOutB", Me)
            BarraNeto = New ArrayControles(Of ProgressBar)("BarraNeto", Me)
            BarraBruto = New ArrayControles(Of ProgressBar)("BarraBruto", Me)
            TStatB = New ArrayControles(Of Label)("TStatB", Me)
            ShB = New ArrayControles(Of PictureBox)("ShB", Me)
            ShRunB = New ArrayControles(Of PictureBox)("ShB", Me)
            TCodMat = New ArrayControles(Of Label)("TCodMat", Me)
            BReIni = New ArrayControles(Of Button)("BReIni", Me)
            TNomTv = New ArrayControles(Of Label)("TNomTv", Me)

            DOPs = New AdoNet("OPS", CONN, DbProvedor)
            DTolvas = New AdoNet("Tolvas", CONN, DbProvedor)
            DDatosFor = New AdoNet("DatosFor", CONN, DbProvedor)
            DProcEnLinea = New AdoNet("ProcesoEnLinea", CONN, DbProvedor)
            DArt = New AdoNet("ARTICULOS", CONN, DbProvedor)
            DVarios = New AdoNet("VARIOS", CONN, DbProvedor)
            DVarios2 = New AdoNet("VARIOS", CONN, DbProvedor)
            DConsumos = New AdoNet("CONSUMOS", CONN, DbProvedor)
            DBasculas = New AdoNet("-", CONN, DbProvedor)
            DProcPend = New AdoNet("-", CONN, DbProvedor)
            DProc = New AdoNet("-", CONN, DbProvedor)
            DProcPend0002 = New AdoNet("-", CONN, DbProvedor)
            DFor = New AdoNet("-", CONN, DbProvedor)

            'Lee los límites de tara e inclusiones mínimas
            DBasculas.Open("select * from BASCULAS where bascula<15 order by bascula")
            Dim K As Int16 = 0
            For Each RegBasc As DataRow In DBasculas.Rows
                K = RegBasc("BASCULA")
                'InclusionMin(K) = RegBasc("INCLUSIONMIN")
                'Limtara(K) = RegBasc("INCLUSIONMIN")
            Next

            Seccion = "AUTO"

            For K = 1 To 4
                APlanoPLC(K, "ENTRA A CHRDOSIFICA " + NombrePC + "  " + UsuarioDosificacion)
            Next K
            FLeeProc_Click(0, Nothing)

            ServPLC.ServPLC_Load(0, Nothing)

            ServEscan.ServEscan_Load(0, Nothing)
            'ServEscan.Show()

            TimScan.Enabled = True
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TimScan_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimScan.Tick
        Try
            'Application.DoEvents()
            THora.Text = Now.ToString("HH:mm:ss")
            TSeg.Text = Val(TSeg.Text) + 1
            If Val(TSeg.Text) > 100000 Then TSeg.Text = 0


            If Val(TSeg.Text) Mod 5 = 0 Then
                ServPLC.ServPLC_Load(0, Nothing)
                ServEscan.ServEscan_Load(0, Nothing)
            End If


            If Val(TSeg.Text) Mod 30 = 0 Then
                FLeeProc_Click(0, Nothing)
            End If

            'Calculo de baches realizados. No se deben tener en cuenta los que se hacen manuales por otro lado.
            If Val(TSeg.Text) Mod 60 = 0 Or TSeg.Text = "1" Then
                Dim FechaA As String
                Dim FechaB As String
                Dim FechaDate As Date

                'El día se maneja en espta planta de 5am a 5am

                FechaB = FechaC()
                If Now.Hour > 5 Then
                    FechaA = Format(Now.Date, "yyyy/MM/dd") + " 05:00"
                Else
                    FechaA = Format(DateAdd(DateInterval.Day, -1, Now), "yyyy/MM/dd") + " 05:00"
                End If

                DVarios.Open("Select CONT from BACHES where ESTADO>0 and FECHA>='" + FechaA + "' and FECHA<='" + FechaB + "'")
                TBachesHechos.Text = 0
                If DVarios.RecordCount > 0 Then
                    TBachesHechos.Text = DVarios.RecordCount
                End If

                TTonHechas.Text = 0
                DVarios2.Open("Select sum(PESOREAL) as PESOREAL from BACHES where ESTADO>0 and FECHA>='" + FechaA + "' and FECHA<='" + FechaB + "'")
                If Not IsDBNull(DVarios2.RecordSet("PESOREAL")) Then
                    TTonHechas.Text = Math.Round(DVarios2.RecordSet("PESOREAL") / 1000, 1)
                End If

                'Calcula las toneladas hora de las ultimas dos horas
                FechaDate = DateAdd(DateInterval.Hour, -2, Now)

                DVarios2.Open("Select sum(PESOREAL) as PESOREAL from BACHES where ESTADO>0 and FECHA>='" + Format(FechaDate, "yyyy/MM/dd HH:mm:ss") + "' and FECHA<'" + FechaB + "'")
                If Not IsDBNull(DVarios2.RecordSet("PESOREAL")) Then
                    TTnH.Text = Math.Round(DVarios2.RecordSet("PESOREAL") / 1000 / 2, 1)
                End If

                'Alarma del PLC activada desde el ejecutable Engrase2 avisando que el real superó el Meta.
                RespInput = ReadConfigVar("AlarmaEngrase2")
                If RespInput = "1" Then
                    Resp = ServPLC.Esc1Reg("Chr_Alarma", 1)
                    TProc.Text += "Alarma PLC Engrase 2" + vbCrLf
                    BAlEngrase2.Visible = True
                    WriteConfigVar("AlarmaEngrase2", 0)
                End If

            End If
                If File.Exists(Ruta + "b") = True Then
                    Evento(" Se cierra ChrComunicaciones por archivo b " + Me.Name)
                End
            End If

        Catch ex As Exception
            TMsgGen.Text = (ex.ToString)
        End Try

    End Sub



    Private Sub BStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStart.Click
        Try
            Dim BascG As Integer
           
            If TStatB1.Text.Trim <> "LIBRE" Then
                If TStatB1.Text.Trim <> "FIN BACHE" Then
                    RespInput = MsgBox("La báscula 1 debe estar libre, desea iniciar el proceso de todas formas?", vbInformation + vbYesNo)
                    If RespInput = vbNo Then Return
                End If
            End If

            'Revisa si ya el proceso anterior está finalizado
            DProcPend.Open("select * from PROCDOSIFPEND where PROCESO='" + Seccion + "'")
            If DProcPend.RecordCount Then
                MsgBox("No puede iniciar porque aún hay procesos pendientes", vbInformation)
                Return
            End If

            DOPs.Open("select * from OPS where OP='" + TOPSig.Text + "'")
            If DOPs.RecordCount = 0 Then
                MsgBox("OP no encontrada", vbInformation)
                Return
            End If

            CodFor = DOPs.RecordSet("CODFOR")
            LP = DOPs.RecordSet("LP")

            'Verifica el total de la formula contra el que deberia ser
            DVarios.Open("select sum(PESOMETA) as TotFor from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and TIPON<>6")

            Dim TotalFor As Int16 = 0
            If Not IsDBNull(DVarios.RecordSet("TOTFOR")) Then
                TotalFor = DVarios.RecordSet("TOTFOR")
                DFor.Open("select * from FORMULAS where CODFOR='" + CodFor + "' and LP='" + LP + "'")
                If DFor.RecordCount Then
                    If Math.Abs(DFor.RecordSet("PESOMETA") - TotalFor) > 0.5 Then
                        RespInput = MsgBox("ATENCION la suma de ingredientes no coincide con el total que debería tener el bache (PesoMetaBache)" + vbCrLf +
                                           "Deberia ser " + DFor.RecordSet("PESOMETABACHE").ToString + " Desea Continuar?", vbYesNo + vbInformation)
                        If RespInput = vbNo Then Return
                        Evento("PesoMetaBache distinto al total de ingredientes. Usuario decide continuar. Igreds: " + TotalFor.ToString + " PMBache: " + DFor.RecordSet("PESOMETA").ToString)
                    End If
                    If DFor.RecordSet("PESOMETA") > 3001 Then
                        RespInput = MsgBox("Peso meta Bache Mayor a 3000 kg. Desea Continuar?", vbYesNo + vbInformation)
                        If RespInput = vbNo Then Return
                        Evento("Peso Meta Bache mayor a 3000 : " + DFor.RecordSet("PESOMETA").ToString)
                    End If

                    If DFor.RecordSet("PESOMETA") < 3000 Then
                        RespInput = MsgBox("Peso meta Bache menor a 3000 kg. Desea Continuar?", vbYesNo + vbInformation)
                        If RespInput = vbNo Then Return
                        Evento("Peso Meta Bache menor a 3000 : " + DFor.RecordSet("PESOMETA").ToString)
                    End If

                    If TotalFor < 3000 Then
                        MsgBox("Peso meta en ingredientes de fórmula menor a 3000 kg, favor revisar", vbCritical)
                        Return
                    End If

                End If
            End If

            'Revisa la contaminación cruzada
            'ServPLCDosif.TContCruzada.Text = TOPSig.Text
            'ServPLCDosif.BContCruzada_Click(0, Nothing)
            'If ServPLCDosif.TContCruzada.Text <> "S" Then
            '    MsgBox("Contaminación cruzada", vbInformation)
            '    Return
            'End If

            'Verificaciones de toda la fórmula  ----------------------------------------------------------------

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and TIPON=1")
            For Each RDatosFor As DataRow In DDatosFor.Rows
                If RDatosFor("A") = "-" Then
                    MsgBox("Ingrediente sin TIPO asignado (AUTO, MANUAL, etc): " + RDatosFor("NOMMAT").ToString)
                    Exit Sub
                End If

                'If RDatosFor("TOLSUP") = 0 Or RDatosFor("TOLINF") = 0 Then
                '    MsgBox("Ingrediente con tolerancias en cero " + RDatosFor("NOMMAT").ToString)
                '    Exit Sub
                'End If

                'Automáticos
                If InStr(RDatosFor("A"), "A") Then
                    BascG = RDatosFor("BASCULA")
                    If BascG = 0 Then
                        MsgBox("Ingrediente con báscula 0: " + RDatosFor("NOMMAT").ToString, vbInformation)
                        Exit Sub
                    End If

                    DTolvas.Open("select * from TOLVAS where PROCESO='DOSIFICACION' and BASCULA=" + RDatosFor("BASCULA").ToString + " and CODINT='" + RDatosFor("CODMAT").ToString + "' and ACTIVA='X'")
                    If DTolvas.RecordCount = 0 Then
                        MsgBox("No se econtró Tolva para " + RDatosFor("NOMMAT").ToString, vbInformation)
                        Exit Sub
                    End If

                    'If RDatosFor("PESOMETA") < InclusionMin(BascG) Then
                    '    MsgBox(RDatosFor("NOMMAT").ToString + " La cantidad es muy pequeña. Debe ser al menos " + InclusionMin(BascG).ToString + " kg", vbInformation)
                    '    Exit Sub
                    'End If
                    RDatosFor("TOLVA") = DTolvas.RecordSet("TOLVA")
                    DDatosFor.Update("DatosFor")

                End If

            Next

            For K = 1 To 4
                APlanoPLC(K, vbCrLf + vbCrLf + "----------------------------    INICIA OP   " + TOPSig.Text)
            Next

            'OPs de limpieza
            Baches = DOPs.RecordSet("META")
            If DOPs.RecordSet("OP") = 998 Or DOPs.RecordSet("OP") = 999 Then
                Baches = DOPs.RecordSet("REAL") + 1
            End If

            'Inicia la copia de registros a la tabla de ProcDosifPend ------------------------------------------------------
            DProcPend.Open("select * from PROCDOSIFPEND where PROCESO='" + Seccion + "'")
            For Me.NoBache = DOPs.RecordSet("REAL") + 1 To Baches
                Paso = 0
                DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and TIPON=1 order by BASCULA,PASO")
                If DDatosFor.RecordCount = 0 Then
                    MsgBox("OP siningredientes por Báscula Automática", vbInformation)
                    Return
                End If
                For Each RDatosFor As DataRow In DDatosFor.Rows
                    Paso += 1
                    DProcPend.AddNew()

                    DProcPend.RecordSet("PROCESO") = "AUTO"

                    'DProcPend.RecordSet("SECCMICROS") = Seccion
                    DProcPend.RecordSet("PASO") = Paso
                    DProcPend.RecordSet("OP") = TOPSig.Text
                    DProcPend.RecordSet("BACHE") = NoBache
                    DProcPend.RecordSet("CODMAT") = RDatosFor("CODMAT")
                    DProcPend.RecordSet("CODMATB") = RDatosFor("CODMATB")
                    DProcPend.RecordSet("NOMMAT") = RDatosFor("NOMMAT")
                    DProcPend.RecordSet("METAT") = Math.Round(RDatosFor("VALOR") * DOPs.RecordSet("PORC") / 100, 3)
                    'La báscula ya viene desde la fórmula
                    DProcPend.RecordSet("BASCULA") = RDatosFor("BASCULA")
                    DProcPend.RecordSet("TOLVA") = RDatosFor("TOLVA")

                    'If RDatosFor("BASCULA") <= 2 Then
                    'Es el ingrediente es automático, prevalece la tolerancia indicada en la tolva
                    'DTolvas.Open("select * from TOLVASDOSIF where TOLVA=0" + DProcPend.RecordSet("TOLVA").ToString)
                    'If DTolvas.RecordCount Then
                    '    DProcPend.RecordSet("METAMIN") = DProcPend.RecordSet("METAT") - DTolvas.RecordSet("TOLINF")
                    '    DProcPend.RecordSet("METAMAX") = DProcPend.RecordSet("METAT") + DTolvas.RecordSet("TOLSUP")
                    'End If
                    'Else
                    '    'Es el ingrediente es Menores, prevalece la tolerancia indicada en la Bascula
                    '    DBasculas.Open("select * from BASCULAS where BASCULA=0" + RDatosFor("BASCULA").ToString)
                    '    If DBasculas.RecordCount Then
                    '        DProcPend.RecordSet("METAMIN") = DProcPend.RecordSet("METAT") - DBasculas.RecordSet("TOLINF")
                    '        DProcPend.RecordSet("METAMAX") = DProcPend.RecordSet("METAT") + DBasculas.RecordSet("TOLSUP")
                    '    End If

                    'End If

                    'Se revisa si son Automáticos que la bacula haya quedado bien
                    'default 0 el recordset no lo toma
                    'If DProcPend.RecordSet("PROCESO") = "AUTO" Then
                    If IsDBNull(DProcPend.RecordSet("BASCULA")) Then
                        MsgBox("Ingred.sin Básc.cant.Cód." + RDatosFor("CODMATB").ToString, vbInformation)
                        DProcPend.Open("delete from PROCDOSIFPEND where PROCESO='AUTO'")
                        Return
                    End If
                    'Revisa que el ingrediente haya quedado con báscula
                    If DProcPend.RecordSet("BASCULA") = 0 Then
                        MsgBox("Ingred.sin Básc.cant.Cód." + RDatosFor("CODMATB").ToString, vbInformation)
                        DProcPend.Open("delete from PROCDOSIFPEND where PROCESO='AUTO'")
                        Return
                    End If

                    'If DProcPend.RecordSet("METAMIN") < 0.001 Then
                    '    MsgBox("Ingred.Tol.Cant.Cód." + RDatosFor("CODMATB").ToString, vbInformation)
                    '    DProcPend.Open("delete from PROCDOSIFPEND where PROCESO='AUTO'")
                    '    Return
                    'End If
                    'End If
                    DProcPend.Update("DProcPend")
                Next        'DatosFor

                'Revisa si debe pedir Degussa
                DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and TIPON=10")
                If DDatosFor.RecordCount Then
                    DProcPend.AddNew()
                    DProcPend.RecordSet("PROCESO") = "DEGUSSA"
                    DProcPend.RecordSet("OP") = TOPSig.Text
                    DProcPend.RecordSet("BACHE") = NoBache
                    DProcPend.Update("ProcPend")
                End If
                'Revisa si debe pedir Manuales
                DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and TIPON=8")
                If DDatosFor.RecordCount Then
                    DProcPend.AddNew()
                    DProcPend.RecordSet("PROCESO") = "MANUALES"
                    DProcPend.RecordSet("OP") = TOPSig.Text
                    DProcPend.RecordSet("BACHE") = NoBache
                    DProcPend.Update("ProcPend")
                End If
            Next        'NumBache

            'Se deja archivo plano de lo que se generó par aproducir la OP ------------------------------------------------
            DProcPend.Open("select TOP 1 * from PROCDOSIFPEND where PROCESO='" + Seccion + "' order by ID")
            If DProcPend.RecordCount Then
                Dim BacheStart As String
                BacheStart = DProcPend.RecordSet("BACHE")
                For J = 1 To 4
                    Msg = Now.ToString("HH:mm:ss") + vbCrLf + "Inicia OP " + DOPs.RecordSet("OP").ToString + " Cód. " + CodFor.ToString + " " + DOPs.RecordSet("NOMFORB") + vbCrLf
                    DProcPend.Open("select * from PROCDOSIFPEND where PROCESO='" + Seccion + "' and BACHE=" + BacheStart + " and BASCULA=" + J.ToString)
                    For Each RPend As DataRow In DProcPend.Rows
                        Msg = "Bch." + RPend("BACHE").ToString + vbTab + " "
                        Msg += "B" + RPend("BASCULA").ToString + vbTab + " "
                        Msg += "Cod." + RPend("CODMAT") + vbTab + " "
                        Msg += RPend("NOMMAT") + vbTab + " "
                        Msg += "MT." + RPend("METAT").ToString + vbTab + " "
                        Msg += "Mín." + RPend("METAMIN").ToString + vbTab + " "
                        Msg += "M-ax." + RPend("METAMAX").ToString + vbTab + " "
                        Msg += vbCrLf
                        APlanoPLC(J, Msg)
                    Next
                Next J
            End If

            ServPLC.FNuevaOP_Click(Val(TOPSig.Text), Nothing)
            If ServPLC.DatosOKPLC(0) Then
                ServPLC.FNuevoBache_Click(0, Nothing)
            Else
                MsgBox("Error en el envío del encabezado de la OP al PLC", vbInformation)
                Return
            End If

        Catch ex As Exception
            MsgError(ex.ToString)
            EvError(ex.ToString)
        End Try
    End Sub

    Private Sub BSostCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSostCiclo.Click
        Try

            DProc.Open("select * from PROCDOSIF where PROCESO='" + Seccion + "' and BASCULA=1")
            If DProc.RecordCount Then
                If DProc.RecordSet("CICLOSOSTENIDO") = 1 Then
                    DProc.RecordSet("CICLOSOSTENIDO") = 0
                Else
                    DProc.RecordSet("CICLOSOSTENIDO") = 1
                End If
                For K = 0 To 4
                    APlanoPLC(K, "Ciclo Sostenido= " + DProc.RecordSet("CICLOSOSTENIDO").ToString)
                Next
                DProc.Update("Proc")
            End If
            FLeeProc_Click(0, Nothing)
            ServPLC.FProceso_Click(0, Nothing)
        Catch ex As Exception
            MsgError(ex.ToString)
            EvError(ex.ToString)
        End Try
    End Sub

    Private Sub BAbortar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAbortar.Click
        Try
            Dim BascAb As Integer
            'TStpOFF.Text = 250
            'BStpOFF_Click(Nothing, Nothing)
            RespInput = MsgBox("Seguro desea Abortar el proceso?......!!!!!!!", vbCritical + vbYesNo)
            If RespInput = vbNo Then Return

            Evento("Usuario Aborta proceso dosificación")

            For BascAb = 1 To 4
                'Se reinician todos los datos de la tabla 
                DVarios.Open("delete from PROCDOSIFPEND")

                DProc.Open("Select * from PROCDOSIF where PROCESO='" + Seccion + "' and BASCULA=" + BascAb.ToString)
                If DProc.RecordCount = 0 Then MsgBox("No se encontró en PROCDOSIF ")
                DProc.RecordSet("OP") = 0
                DProc.RecordSet("BACHE") = 0
                DProc.RecordSet("CODFOR") = 0
                DProc.RecordSet("NOMFOR") = "-"
                DProc.RecordSet("LP") = "-"
                DProc.RecordSet("OUTPUT") = 0
                DProc.RecordSet("NOMTOLVA") = "-"     '
                DProc.RecordSet("PASO") = 0
                DProc.RecordSet("CODMAT") = 0
                DProc.RecordSet("NOMMAT") = "-"
                DProc.RecordSet("METAT") = 0
                DProc.RecordSet("TOLSUP") = 0
                DProc.RecordSet("TOLINF") = 0
                DProc.RecordSet("ESTADO") = "LIBRE"
                Estado(1) = "LIBRE"
                DProc.Update("Proc")
            Next
            DProc.Open("select  * from PROCDOSIF where PROCESO = 'MANUALES'")
            If DProc.RecordCount Then
                DProc.RecordSet("OP") = 0
                DProc.RecordSet("BACHE") = 0
                DProc.Update("Proc")
            End If
            DProc.Open("select  * from PROCDOSIF where PROCESO = 'DEGUSSA'")
            If DProc.RecordCount Then
                DProc.RecordSet("OP") = 0
                DProc.RecordSet("BACHE") = 0
                DProc.Update("Proc")
            End If

            ServPLC.BAbortarPLC_Click(0, Nothing)
            APlanoPLC(2, "Aborta Proceso")

            FLeeProc_Click(0, Nothing)

        Catch ex As Exception
            MsgError(ex.ToString)
            EvError(ex.ToString)
        End Try

    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub



    Private Sub BRecAlarma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRecAlarma1.Click, BRecAlarma2.Click, BRecAlarma3.Click, BRecAlarma4.Click
        Try
            Dim Index As Int32 = BRecAlarma.Index(CType(sender, Button))

            'If BRecAlarma(Index).Text = "-" Then Return 'Evita doble ejecución. Cuando se da click está entrando dos veces..
            'BRecAlarma(Index).Text = "-"
            'BRecAlarma(Index).Visible = False
            ServPLC.FRecAlarma_Click(Index, Nothing)

            APlanoPLC(2, "REC.ALARMA B" + Index.ToString + "  " + TStatB(Index).Text)
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub


    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Evento("Sale de ChrDosifica")

        'APlanoGSE(1, "SALE DE CHR COMM " + NombrePC + "  " + UsuarioDosificacion)


        Me.Close()
        Me.Dispose()
        End
    End Sub



    Private Sub PDosifica_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub




    Private Sub mnUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnUsuario.Click
        Try
            Acceso.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        'AcercaD.ShowDialog()
    End Sub



    Private Sub BModBusSlavePLC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'ModBusSlavePLC.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BVaceo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'ServidorHornerVaceo.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ServidorMen.Show()
    End Sub



    Private Sub ServidorPantMenoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServidorPantMenoresToolStripMenuItem.Click
        Try
            'ServidorMen.Show()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub



    Private Sub ServidorMímicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ServidorMimico.Show()
    End Sub



    Private Sub BSubeBach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSubeBach.Click
        Try
            DOPs.Open("Select * from OPS where OP='" + Val(TOPB1.Text).ToString + "'")

            If DOPs.RecordCount AndAlso DOPs.RecordSet("BAHORA") + 1 <= DOPs.RecordSet("META") AndAlso _
                DOPs.RecordSet("REAL") + 1 <= DOPs.RecordSet("META") Then
                DOPs.RecordSet("BAHORA") += 1
                DOPs.Update("OPs")
            End If


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BBajaBach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBajaBach.Click
        Try
            DOPs.Open("Select * from OPS where OP='" + Val(TOPB1.Text).ToString + "'")

            If DOPs.RecordCount AndAlso DOPs.RecordSet("BAHORA") - 1 > 0 Then
                DOPs.RecordSet("BAHORA") -= 1
                DOPs.Update("OPs")
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BVerOPs_Click(sender As System.Object, e As System.EventArgs) Handles BVerOPs.Click
        Try
            TOPSig.Items.Clear()
            TNomForSig.Text = ""
            DOPs.Open("select * from OPs where  FINALIZADO<>'S' and MAQUILA='00' order by OP desc")
            LLenaComboBox(TOPSig, DOPs.DataTable, "OP")

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TOPSig_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TOPSig.SelectedIndexChanged
        Try
            DVarios.Open("select * from OPs where  OP='" + TOPSig.Text + "'")
            If DVarios.RecordCount Then
                TNomForSig.Text = DVarios.RecordSet("NOMFORB")
                'TDestino.Text = DVarios.RecordSet("DESTINO")

            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Public Sub FLeeProc_Click(sender As System.Object, e As System.EventArgs) Handles FLeeProc.Click
        Try
            Dim Basc As Int32

            For Basc = 1 To 4
                DProc.Open("select * from PROCDOSIF where PROCESO='" + Seccion + "' and BASCULA=" + Basc.ToString)
                If DProc.RecordCount Then
                    If Basc = 1 Then
                        TOPB(Basc).Text = DProc.RecordSet("OP")
                        TBacheNo(Basc).Text = DProc.RecordSet("BACHE")
                        TBaches.Text = DProc.RecordSet("BACHES")
                        TPorc.Text = DProc.RecordSet("PORC")
                        TTolva(Basc).Text = DProc.RecordSet("TOLVA")
                        TLP.Text = DProc.RecordSet("LP")
                        TCodFor(Basc).Text = DProc.RecordSet("CODFOR")
                        TNomFor(Basc).Text = DProc.RecordSet("NOMFOR")
                        'TDestino.Text = DProc.RecordSet("DESTINO")
                    End If
                    TStatB(Basc).Text = DProc.RecordSet("ESTADO")
                    TCodMat(Basc).Text = DProc.RecordSet("CODMAT")
                    TNomMat(Basc).Text = DProc.RecordSet("NOMMAT")
                    TMeta(Basc).Text = Math.Round(DProc.RecordSet("METAT"), 0)
                    TNomTv(Basc).Text = DProc.RecordSet("NOMTOLVA")
                    TTolva(Basc).Text = DProc.RecordSet("TOLVA")

                    Estado(Basc) = TStatB(Basc).Text



                    If Basc = 1 Then
                        If DProc.RecordSet("CICLOSOSTENIDO") = 1 Then
                            BSostCiclo.BackColor = Color.Green
                            CicloSostenido = True
                        Else
                            BSostCiclo.BackColor = Color.LightGray
                            CicloSostenido = False
                        End If
                    End If
                End If
            Next

            'Visualiza la solicitud de Micros
            DProc.Open("select * from PROCDOSIF where PROCESO='MANUALES' ")
            If DProc.RecordCount Then
                If DProc.RecordSet("OP") > 0 Then
                    shConMicros.Visible = True
                 Else
                    shConMicros.Visible = False
                End If
            End If

            'Visualiza la solicitud de Degussa
            DProc.Open("select * from PROCDOSIF where PROCESO='DEGUSSA' ")
            If DProc.RecordCount Then
                If DProc.RecordSet("OP") > 0 Then
                    shConDeg.Visible = True
                 Else
                    shConDeg.Visible = False
                End If
            End If

        Catch ex As Exception
            TMsgGen.Text = Format(Now, "HH:mm:ss") + ":   " + (ex.ToString)
            EvError(ex.ToString)
        End Try

    End Sub

    Private Sub mnServPLCDosif_Click(sender As System.Object, e As System.EventArgs) Handles mnServPLCDosif.Click
        ServPLC.Show()
    End Sub



    Private Sub mnIniDosMac_Click(sender As System.Object, e As System.EventArgs) Handles mnIniDosMac.Click
        'APlanoPLC(2, "Usuario Forza Sig.Mat B1")
        'ServPLC.FSigMat_Click(1, Nothing)
    End Sub

    Private Sub mnCambiarTolva_Click(sender As System.Object, e As System.EventArgs) Handles mnCambiarTolva.Click
        Try

            Dim Basc As Integer


            Basc = InputBox("Entre el número de la báscula (1 a 4)", "ChronoSoft", "0")
            If Basc < 1 Or Basc > 4 Then
                MsgBox("Dato no válido. Debe ser de 1 a 4", vbInformation)
                Return
            End If

            If (EstadoNum(Basc) < 2 Or EstadoNum(Basc) > 25) And EstadoNum(Basc) <> 45 Then
                MsgBox("La báscula debe estar en proceso de alimentación y está en Estado " + EstadoNum(Basc).ToString + " " + Estado(Basc), vbInformation)
                Return
            End If


            CambioTolva.CambioTolva_Load(Nothing, Nothing)
            CambioTolva.TTolvaAct.Text = TTolva(Basc).Text
            CambioTolva.TBascActual.Text = Basc
            Sleep(20)
            CambioTolva.ShowDialog()

            If Val(NuevaTolva) = 0 Then
                MsgBox("Operación inválida o cancelada por el usuario", vbCritical)
                Return
            End If

  
            'Primero hacemos el cambio para todos los baches que hacen falta
            DProcPend.Open("select * from PROCDOSIFPEND where CODMAT=" + TCodMat(Basc).Text + " and BASCULA=" + Basc.ToString)
            For Each RProcP As DataRow In DProcPend.Rows
                RProcP("TOLVA") = NuevaTolva
                RProcP("BASCULA") = NuevaBascula
                DProcPend.Update("ProcPend x en mnCambiaTolva")    'No se ha montado en Abril 12 de 2019
            Next

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + TCodFor(1).Text + "' and CODMAT='" + TCodMat(Basc).Text + "'")
            If DDatosFor.RecordCount = 0 Then
                MsgBox("Error en tabla DatosFor. No se encuentra Cod.Mat " + TCodMat(Basc).Text)
            End If
            'Inicia la copia de registros a la tabla de ProcDosifPend ------------------------------------------------------
            DProcPend.Open("select * from PROCDOSIFPEND where PROCESO='" + Seccion + "' and BASCULA=" + NuevaBascula)
            DProcPend.AddNew()
            DProcPend.RecordSet("PROCESO") = "AUTO"
            DProcPend.RecordSet("OP") = TOPB(1).Text
            DProcPend.RecordSet("BACHE") = TBacheNo(1).Text
            DProcPend.RecordSet("PASO") = 0
            DProcPend.RecordSet("CODMAT") = DDatosFor.RecordSet("CODMAT")
            DProcPend.RecordSet("CODMATB") = DDatosFor.RecordSet("CODMATB")
            DProcPend.RecordSet("NOMMAT") = DDatosFor.RecordSet("NOMMAT")
            DProcPend.RecordSet("METAT") = Math.Round(Eval(TMeta(Basc).Text) - Neto(Basc), 3)

            DProcPend.RecordSet("BASCULA") = NuevaBascula
            DProcPend.RecordSet("TOLVA") = NuevaTolva

            'DTolvas.Open("select * from TOLVASDOSIF where TOLVA=0" + DProcPend.RecordSet("TOLVA").ToString)
            'If DTolvas.RecordCount Then
            '    DProcPend.RecordSet("METAMIN") = DProcPend.RecordSet("METAT") - DTolvas.RecordSet("TOLINF")
            '    DProcPend.RecordSet("METAMAX") = DProcPend.RecordSet("METAT") + DTolvas.RecordSet("TOLSUP")
            'End If

            DProcPend.Update("ProcPend")
            APlanoPLC(Basc, "Cambio de Tolva")

            PesoParcial(Basc) = True
            RespInput = ServPLC.Esc1Reg("Chr_Fin_Alimentador_B" + Basc.ToString, 1)
            APlanoPLC(Resp, "Usuario finaliza en báscula " + Resp.ToString)

            Evento("Operario finaliza Ingrediente B1")


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub


    Private Sub mnFinalizarIngB1_Click(sender As System.Object, e As System.EventArgs) Handles mnFinalizarIng.Click
        Try
            Resp = InputBox("Entre el número de la báscula (1 a 4)", "ChronoSoft", "0")
            If Resp < 1 Or Resp > 4 Then
                MsgBox("Dato no válido. Debe ser de 1 a 4")
                Return
            End If

            If (EstadoNum(Resp) < 2 Or EstadoNum(Resp) > 25) Or EstadoNum(Resp) = 45 Then
                MsgBox("La báscula debe estar en proceso de alimentación y está en Estado " + EstadoNum(Resp).ToString + " " + Estado(Resp))
                Return
            End If

            RespInput = ServPLC.Esc1Reg("Chr_Fin_Alimentador_B" + Resp.ToString, 1)
            APlanoPLC(Resp, "Usuario finaliza en báscula " + Resp.ToString)

            Evento("Operario finaliza Ingrediente B1")


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub mnHabDescB1FueraRango_Click(sender As System.Object, e As System.EventArgs) Handles mnHabDescB1FueraRango.Click
        Try

            If Estado(1) <> "FIN BASC." Or Estado(2) <> "FIN BASC." Or Estado(3) <> "FIN BASC." Or Estado(4) <> "FIN BASC." Then

                MsgBox("Todas las básculas deben estar en FIN BASC. No puede habilitar la descarga aún.", vbInformation)
                Return
            End If
            Resp = ServPLC.Esc1Reg("Chr_OK_Descarga_Basc", 1)
            TProc.Text = TProc.Text + "Hab. Descarga" + vbCrLf

            Evento("Usuario Habilita descarga de Básculas Pesos Brutos: " + Bruto(1).ToString + vbTab + Bruto(3).ToString + vbTab + Bruto(3).ToString + vbTab + Bruto(4).ToString)
            For K = 1 To 4
                APlanoPLC(K, "Usuario Habilita descarga de B1 Peso Bruto:" + Bruto(K).ToString)
            Next K
            TMsgGen.Text = "-"
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
        Me.Dispose()
        End
    End Sub

    Private Sub mnTolvas_Click(sender As System.Object, e As System.EventArgs) Handles mnTolvas.Click
        TolvasDosif.Show()
    End Sub

    Private Sub TNeto1_Click(sender As System.Object, e As System.EventArgs) Handles TNeto1.Click

    End Sub

    Private Sub TProc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TProc.TextChanged
        Try
        Dim Num As Int32
            If Len(TProc.Text) > 160 Then
                Num = InStr(140, TProc.Text, Chr(10))
                If Num Then TProc.Text = Mid(TProc.Text, Num + 1)
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BEnviarDestino_Click(sender As System.Object, e As System.EventArgs)
        'Resp = ServPLC.Esc1Reg("Chr_Destino", Val(TDestino.Text))
        'Evento("Usuario cambia destino a " + TDestino.Text)
    End Sub

    
    Private Sub mnForzarEscaner_Click(sender As System.Object, e As System.EventArgs) Handles mnForzarEscaner.Click
        Try

            If Estado(1) <> "FIN BASC." Or Estado(2) <> "FIN BASC." Or Estado(3) <> "FIN BASC." Or Estado(4) <> "FIN BASC." Then

                MsgBox("Todas las básculas deben estar en FIN BASC. No puede forzar los Micros", vbInformation)
                Return
            End If
            ServPLC.FRecMicros_Click(0, Nothing)
      
            Evento("Usuario Habilita Escáner de Micros")
            APlanoPLC(0, "Usuario Habilita Escáner de Micros")

            TMsgGen.Text = "-"
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub mnServPLC_Click(sender As System.Object, e As System.EventArgs) Handles mnServPLC.Click
        ServPLC.Show()
    End Sub

    Private Sub mnServEscan_Click(sender As System.Object, e As System.EventArgs) Handles mnServEscan.Click
        ServEscan.Show()
    End Sub

  
    Private Sub BBorrarMsg_Click(sender As System.Object, e As System.EventArgs)
        TMsgGen.Text = ""
    End Sub

    Private Sub BAlEngrase2_Click(sender As System.Object, e As System.EventArgs) Handles BAlEngrase2.Click
        Try
            'Alarma del PLC activada desde el ejecutable Engrase2 avisando que el real superó el Meta.
            Resp = ServPLC.Esc1Reg("Chr_Alarma", 0)
            BAlEngrase2.Visible = False
            WriteConfigVar("AlarmaEngrase2", 0)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub ReconocerAlarmaEngrase2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReconocerAlarmaEngrase2ToolStripMenuItem.Click
        Try
            'Alarma del PLC activada desde el ejecutable Engrase2 avisando que el real superó el Meta.
            Resp = ServPLC.Esc1Reg("Chr_Alarma", 0)
            BAlEngrase2.Visible = False
            WriteConfigVar("AlarmaEngrase2", 0)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TMsgGen_Click(sender As Object, e As System.EventArgs) Handles TMsgGen.Click
        TMsgGen.Text = ""
    End Sub

    Private Sub TMsgGen_TextChanged(sender As System.Object, e As System.EventArgs) Handles TMsgGen.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)
        MsgError("ggg")

    End Sub
End Class