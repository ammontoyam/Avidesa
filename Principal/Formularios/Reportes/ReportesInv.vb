Option Explicit On
Imports System
Imports System.Windows.Forms


Public Class ReportesInv

    Private Rep1 As CrystalRep
    Private OKBCDate As Boolean
    Private FechaIni As String
    Private FechaFin As String
    Private DConsultas As AdoSQL
    Private OKFecha As Boolean = True
    Private DVarios As AdoSQL
    Private DMovInv As AdoSQL
    Private DUbic As AdoSQL
    Private DArt As AdoSQL
    Private DTipo As AdoSQL
    Private CodNombre As String
    Private Consulta As String
    Private CUbicacion As ArrayControles(Of ComboBox)
    Private TCodInt As ArrayControles(Of TextBox)
    Private TLote As ArrayControles(Of TextBox)
    Private CTipo As ArrayControles(Of ComboBox)
    Private DMovUser As AdoSQL
    Private DLineaProd As AdoSQL

    Private Sub BCDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCDate.Click
        Dim RepSap As CrystalRep
        Try
            OKFecha = True
            FechaIni = Format(TFechaIni.Value, "yyyy/MM/dd ") + Format(THoraIni.Value, "HH:mm")
            FechaFin = Format(TFechaFin.Value, "yyyy/MM/dd ") + Format(THoraFin.Value, "HH:mm")

            If CDate(FechaFin) <= CDate(FechaIni) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FECHA))
                OKFecha = False
                Exit Sub
            End If
            DConsultas.Refresh()

            DConsultas.RecordSet("F1") = FechaIni
            DConsultas.RecordSet("F2") = FechaFin
            DConsultas.Update()

            RepSap = New CrystalRep
            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .Formulas(2) = "DESDE='" + FechaIni + "'"
                .Formulas(3) = "HASTA='" + FechaFin + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With
            Rep1 = RepSap


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub ReportesInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DConsultas = New AdoSQL("CONSULTAS")
            DVarios = New AdoSQL("VARIOS")
            DArt = New AdoSQL("ARTICULOS")
            DMovInv = New AdoSQL("MOVINV")
            DConsultas.Open("Select * from CONSULTAS")
            DUbic = New AdoSQL("UBICACIONES")
            DTipo = New AdoSQL("TIPOSMAT")
            DMovUser = New AdoSQL("MOVPOR USUARIOS")
            DLineaProd = New AdoSQL("LINEASPROD")

            DArt.Open("select * from ARTICULOS order by CODINT")
            DUbic.Open("Select * from UBICACIONES order by CODUBI")
            DTipo.Open("select * from TIPOSMAT")
            DMovUser.Open("select DISTINCT Usuario FROM MovInv order by USUARIO")
            DLineaProd.Open("select * from LINEASPROD where TIPO='MP' order by LINEA")

            CUbicacion = New ArrayControles(Of ComboBox)("CUbicacion", Me)
            TCodInt = New ArrayControles(Of TextBox)("TCodInt", Me)
            CTipo = New ArrayControles(Of ComboBox)("CTipo", Me)
            TLote = New ArrayControles(Of TextBox)("TLote", Me)

            LLenaComboBox(CUsuario1, DMovUser.DataTable, "Usuario")
            LLenaComboBox(CUsuario2, DMovUser.DataTable, "Usuario")
            LLenaComboBox(CLinea, DLineaProd.DataTable, "LINEA")


            DLineaProd.Open("select * from LINEASPROD where TIPO='PT' OR TIPO='MP' order by LINEA")
            LLenaComboBox(CLinea1, DLineaProd.DataTable, "LINEA")
            LLenaComboBox(CLinea2, DLineaProd.DataTable, "LINEA")


            For Each C As ComboBox In CUbicacion.Values
                LLenaComboBox(C, DUbic.DataTable, "CODUBI")
            Next

            For Each C As ComboBox In CTipo.Values
                'If C Is CTipo3 Then Continue For 'Es inventario físico, por lo tanto solo deben haber MP
                LLenaComboBox(C, DTipo.DataTable, "DESCRIPCION")
            Next

            'LLenaComboBox(CTipo2, DTipo.DataTable, "DESCRIPCION")
            'LLenaComboBox(CTipo3, DTipo.DataTable, "DESCRIPCION")

            BIniFechas_Click(Nothing, Nothing)



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDetPorArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDetPorArt.Click
        Try

            If OPChronoSoft.Checked Then
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If TCodInt(1).Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.CODINT}='" + TCodInt(1).Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' "
                End If
            Else
                BIniFechas_Click(Nothing, Nothing)
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If TCodInt1.Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.CODINT}='" + TCodInt1.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO'"
                End If
            End If

            Rep1.ReportFileName = RutaRep + "rpinvarticulo.rpt"

            Rep1.PrintReport()


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDetPorLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDetPorLote.Click
        Try

            If OPChronoSoft.Checked Then
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If TLote(1).Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.LOTE}='" + TLote(1).Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' "
                End If
            Else
                BIniFechas_Click(Nothing, Nothing)
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If TLote1.Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.LOTE}='" + TLote1.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO'"
                End If
            End If
            Rep1.ReportFileName = RutaRep + "rpinvLote.rpt"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDetPorUbic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDetPorUbic.Click
        Try

            If OPChronoSoft.Checked Then
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If CUbicacion(1).Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.CODUBI}='" + CUbicacion(1).Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' "
                End If
            Else
                BIniFechas_Click(Nothing, Nothing)
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If CUbicacion1.Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.CODUBI}='" + CUbicacion1.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO'"
                End If
            End If

            Rep1.ReportFileName = RutaRep + "rpinvUbic.rpt"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub RpDetPorTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDetPorTipo.Click
        Try

            If OPChronoSoft.Checked Then
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If CTipo(1).Text.Length > 0 Then
                    DTipo.Find("DESCRIPCION='" + CTipo(1).Text + "'")
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.TIPO}='" + DTipo.RecordSet("TIPO") + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' "
                End If
            Else
                BIniFechas_Click(Nothing, Nothing)
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If CTipo(1).Text.Length > 0 Then
                    DTipo.Find("DESCRIPCION='" + CTipo(1).Text + "'")
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.TIPO}='" + DTipo.RecordSet("TIPO") + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO'"
                End If
            End If

            Rep1.ReportFileName = RutaRep + "rpinvTipo.rpt"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BExistencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExistencias.Click
        Try
            Dim Filtro As String = ""
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return

            Filtro += " {ARTICULOS.INVCHRONOS}<>0 and "
            If TCodInt(2).Text.Length > 0 Then
                Filtro += "{ARTICULOS.CODINT}='" + TCodInt(2).Text + "' and "
            End If
            If CTipo(2).Text.Length > 0 Then
                DTipo.Find("DESCRIPCION='" + CTipo(2).Text + "'")
                Filtro += " {ARTICULOS.TIPO}='" + DTipo.RecordSet("TIPO").ToString + "' and"
            End If

            If CLinea1.Text.Length > 0 Then
                Filtro += " {ARTICULOS.LINEA}='" + CLinea1.Text + "' and"
            End If

            Dim Pos As Int16
            Pos = InStrRev(Filtro, "and")
            If Pos > 0 Then Filtro = CLeft(Filtro, Pos - 1)


            Rep1.SelectionFormula = Filtro
            Rep1.ReportFileName = RutaRep + "rpExistencias.rpt"

            Rep1.PrintReport()


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BIniFechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BIniFechas.Click
        Try
            TFechaIni.Value = Now
            TFechaFin.Value = DateAdd(DateInterval.Day, 1, Now)
            THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))
            THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCompFisUno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BComparativo.Click
        Try
            Dim Filtro As String = ""
            Dim NomConsulta As String = "CCOMPARATIVO"
            'BIniFechas_Click(Nothing, Nothing)
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return

            

            If TCodInt(3).Text.Length > 0 Then

                DArt.Open("Select * from ARTICULOS where CODINT='" + TCodInt(3).Text + "'")

                If DArt.Count = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "Codigo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'MsgBox("Código no registrado en tabla articulos")
                    Return
                End If

                If DArt.RecordSet("TIPO") = "MP" Then
                    NomConsulta = "CCOMPARATIVO"
                Else
                    NomConsulta = "CCOMPARATIVOPT"
                End If

                Filtro += "{" + NomConsulta + ".CODINT}='" + TCodInt(3).Text + "' and "
            End If

            If CTipo(3).Text.Length > 0 Then
                DTipo.Find("DESCRIPCION='" + CTipo(3).Text + "'")

                If Eval(TCodInt(3).Text) > 0 AndAlso DTipo.RecordSet("TIPO").ToString <> DArt.RecordSet("TIPO") Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el código de artículo no corresponde al tipo seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'MsgBox("Hay una inconsistencia en la generación del reporte, el código de artículo no corresponde al tipo seleccionado")
                    Return
                End If

                Select Case DTipo.RecordSet("TIPO").ToString
                    Case "MP", "LQ", "AD", "PR"
                        NomConsulta = "CCOMPARATIVO"
                    Case "PT", "EM", "ET"
                        NomConsulta = "CCOMPARATIVOPT"
                End Select

                Filtro += "{" + NomConsulta + ".TIPO}='" + DTipo.RecordSet("TIPO").ToString + "' and "
            End If


            Dim Pos As Int16
            Pos = InStrRev(Filtro, "and")
            If Pos > 0 Then Filtro = CLeft(Filtro, Pos - 1)
            'Filtro += " {CMOVINV.INVCHRONOS}<>0"

            Rep1.SelectionFormula = Filtro

            Select Case DTipo.RecordSet("TIPO").ToString
                Case "MP", "LQ", "AD", "PR"
                    Rep1.ReportFileName = RutaRep + "rpComparativo.rpt"

                Case "PT", "EM", "ET"
                    Rep1.ReportFileName = RutaRep + "rpComparativoPT.rpt"
            End Select


            Rep1.PrintReport()


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BDespArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespArt.Click
        Try
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return
            If TCodInt(4).Text.Length > 0 Then
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10 and {CFACTURAS.CODPROD}='" + TCodInt(4).Text + "'"
            Else
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10"
            End If

            Rep1.ReportFileName = RutaRep + "rpDespArticulo.rpt"

            Rep1.PrintReport()


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDespOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespOP.Click
        Try
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return
            If TOPs.Text.Length > 0 Then
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10 and {CFACTURAS.OP}='" + TOPs.Text + "'"
            Else
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10"
            End If

            Rep1.ReportFileName = RutaRep + "rpDespOP.rpt"

            Rep1.PrintReport()



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDespUbic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespUbic.Click
        Try
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return
            If CUbicacion(2).Text.Length > 0 Then
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10 and {CFACTURAS.CODUBI}='" + CUbicacion(2).Text + "'"
            Else
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10"
            End If

            Rep1.ReportFileName = RutaRep + "rpDespUbic.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BDespFra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespFra.Click
        Try
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return
            If TNumFra.Text.Length > 0 Then
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10 and {CFACTURAS.FACTURANRO}='" + TNumFra.Text + "'"
            Else
                Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10"
            End If
            Rep1.Formulas(4) = "TITULO='DESPACHOS REALIZADOS'"
            Rep1.ReportFileName = RutaRep + "rpDespFra.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BDespPend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespPend.Click
        Try
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return
            'If TNumFra.Text.Length > 0 Then
            'Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}=10 and {CFACTURAS.FACTURANRO}='" + TNumFra.Text + "'"
            'Else

            Rep1.Formulas(4) = "TITULO='DESPACHOS PENDIENTES'"
            Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}<10"
            'End If

            Rep1.ReportFileName = RutaRep + "rpDespFra.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BResumen.Click
        Dim Filtro As String = ""
        BCDate_Click(Nothing, Nothing)
        If OKFecha = False Then Return

        If TCodInt(3).Text.Length > 0 Then
            Filtro += "{CINVDIARIO.CODINT}='" + TCodInt(3).Text + "' and "
        End If
        If CTipo(3).Text.Length > 0 Then
            DTipo.Find("DESCRIPCION='" + CTipo(3).Text + "'")
            Filtro += " {CINVDIARIO.TIPO}='" + DTipo.RecordSet("TIPO").ToString + "' and"
        End If

        If CLinea2.Text.Length > 0 Then
            Filtro += " {CINVDIARIO.LINEA}='" + CLinea2.Text + "' and"
        End If

        Dim Pos As Int16
        Pos = InStrRev(Filtro, "and")
        If Pos > 0 Then Filtro = CLeft(Filtro, Pos - 1)

        Rep1.SelectionFormula = Filtro
        Rep1.ReportFileName = RutaRep + "rpInvDiario.rpt"

        Rep1.PrintReport()

    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub BLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLimpiar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            For Each CB As ComboBox In CUbicacion.Values
                CB.Text = ""
            Next

            For Each CB As ComboBox In CTipo.Values
                CB.Text = ""
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDespPendArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespPendArt.Click
        Try
            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return

            Rep1.Formulas(4) = "TITULO='DESPACHOS PENDIENTES'"
            Rep1.SelectionFormula = "{CFACTURAS.DESPACHADA}<10"

            Rep1.ReportFileName = RutaRep + "rpDespPendArt.rpt"

            Rep1.PrintReport()


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDetPorUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDetPorUsuario.Click
        Try

            If OPChronoSoft.Checked Then
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If CUsuario1.Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.USUARIO}='" + CUsuario1.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' "
                End If
            Else
                BIniFechas_Click(Nothing, Nothing)
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If CUsuario1.Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.USUARIO}='" + CUsuario1.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO'"
                End If
            End If

            Rep1.ReportFileName = RutaRep + "rpinvUsuario.rpt"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BComparativoUsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BComparativoUsu.Click
        Try
            Dim Filtro As String = ""


            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return

            If CUsuario2.Text.Length > 0 Then
                Filtro = "{CCOMPARATIVO.USUARIO}='" + CUsuario2.Text + "'"
            End If
            Rep1.SelectionFormula = Filtro
            Rep1.ReportFileName = RutaRep + "rpComparativoUsuario.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    
    Private Sub BComparativoLin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BComparativoLin.Click
        Try
            Dim Filtro1 As String = ""

            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Return

            If CLinea.Text.Length > 0 Then
                Filtro1 = " {CCOMPARATIVO.LINEA}='" + CLinea.Text.ToString + "'"
            End If

            Rep1.SelectionFormula = Filtro1
            Rep1.ReportFileName = RutaRep + "rpComparativoLineaMP.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAjustesPorArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAjustesPorArt.Click
        Try

            If OpAjusteChr.Checked Then
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If TCodInt(6).Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.DETALLE}='AJUSTEINVENTARIO' and {CMOVINV.CODINT}='" + TCodInt6.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='CHRONOS' and {CMOVINV.DETALLE}='AJUSTEINVENTARIO' "
                End If
            Else
                BIniFechas_Click(Nothing, Nothing)
                BCDate_Click(Nothing, Nothing)
                If OKFecha = False Then Return
                If TCodInt(6).Text.Length > 0 Then
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.DETALLE}='AJUSTEINVENTARIO' and {CMOVINV.CODINT}='" + TCodInt6.Text + "'"
                Else
                    Rep1.SelectionFormula = "{CMOVINV.TIPOMOV}='FISICO' and {CMOVINV.DETALLE}='AJUSTEINVENTARIO'"
                End If
            End If

            Rep1.ReportFileName = RutaRep + "rpInvAjusteArt.rpt"

            Rep1.PrintReport()


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

   
End Class