Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class Materiales

    Private DArt As AdoSQL
    Private Fila As Integer
    Private DFil() As DataRow
    Private DR As DataRow
    Private Campos() As String
    Private DGrpMat As AdoSQL
    Private DLineasProd As AdoSQL
    Private DVarios As AdoSQL
    Private TolMinKg As Single
    Private TolMaxKg As Single
    Private TolMinPorc As Single
    Private TolMaxPorc As Single
    Private TablaGrpMat As Dictionary(Of String, String)
    Private FormLoad As Boolean

    Public Sub InicializacionTablasContCruzada()
        Try
            TablaGrpMat = New Dictionary(Of String, String)
            DVarios.Open("select * from GRPMATERIALES ORDER BY NOMGRPMAT")

            'Llenamos la tabla de grupos de materiales
            For Each FilaEsp As DataRow In DVarios.Rows
                TablaGrpMat.Add(FilaEsp("NOMGRPMAT"), FilaEsp("CODGRPMAT"))
                CBNomGrpMat.Items.Add(FilaEsp("NOMGRPMAT"))
            Next
            'Adicionamos el código 0 para indicar que no tiene asignación
            TablaGrpMat.Add("SIN ASIGNAR", "0")
            CBNomGrpMat.Items.Add("SIN ASIGNAR")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Function Devuelve_CodigoGrpMat(ByVal NombreGrpMat As String)
        Try
            Devuelve_CodigoGrpMat = ""

            If NombreGrpMat = "" Then Return Devuelve_CodigoGrpMat
            Devuelve_CodigoGrpMat = TablaGrpMat(NombreGrpMat).ToString
            Return Devuelve_CodigoGrpMat
        Catch ex As Exception
            MsgError(ex)
            Devuelve_CodigoGrpMat = ""
        End Try
    End Function

    Private Sub Materiales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            If FormLoad Then Return

            BCancelar_Click(Nothing, Nothing)

            DVarios = New AdoSQL("VARIOS")
            DArt = New AdoSQL("ARTICULOS")
            DArt.Open("Select * from ARTICULOS where TIPO='MP' order by NOMBRE")

            DGrpMat = New AdoSQL("GRPMATERIALES")
            DGrpMat.Open("Select * from GRPMATERIALES order by CODGRPMAT")

            DLineasProd = New AdoSQL("LINEASPROD")
            DLineasProd.Open("Select * from LINEASPROD where TIPO='MP'")

            LLenaComboBox(CBNomGrpMat, DGrpMat.DataTable, "NOMGRPMAT")
            LLenaComboBox(CLinea, DLineasProd.DataTable, "LINEA")
            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGArticulos, DArt.DataTable)

            If DGArticulos.Rows.Count > 0 Then DGArticulos_CellClick(Nothing, Nothing)


            Campos = {"CodInt@Cód.Int.", "CodExt@Cód.Ext.", "Nombre@Nombre"}


            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DArt.DataTable)
            CBBuscar.Text = "Nombre"

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)

            TolMinKg = Eval(ConfigParametros("TolMinKgMP"))
            TolMaxKg = Eval(ConfigParametros("TolMaxKgMP"))
            TolMinPorc = Eval(ConfigParametros("TolMinPorcMP"))
            TolMaxPorc = Eval(ConfigParametros("TolMaxPorcMP"))

            If Funcion_ManejaVehiculo Then ChVehiculo.Enabled = True
            If Funcion_GeneraAlarmaCorteSinAbrir Then ChAlarmaCorteSinAbrir.Enabled = True

            InicializacionTablasContCruzada()

            'If Funcion_FuncionesPlantaPremezclas Then ChVehiculo.Enabled = False


            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try



    End Sub

    Private Sub DGArticulos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGArticulos.CellClick
        Try
            If DGArticulos.Rows.Count = 0 Then Exit Sub

            DArt.Find("CodInt='" + DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("CodInt").Value.ToString.Trim + "'")

            If DArt.EOF Then Exit Sub

            TCodInt.Text = DArt.RecordSet("CodInt").ToString
            TNombre.Text = DArt.RecordSet("NOMBRE").ToString
            TCodExt.Text = DArt.RecordSet("CodExt").ToString
            TTolMinKg.Text = DArt.RecordSet("TOLMINKG").ToString
            TTolInfPorc.Text = DArt.RecordSet("TOLINFPORC").ToString
            TTolMaxKg.Text = DArt.RecordSet("TOLMAXKG").ToString
            TTolSupPorc.Text = DArt.RecordSet("TOLSUPPORC").ToString
            TTaraEmp.Text = DArt.RecordSet("TARAEMP").ToString
            TPresKg.Text = DArt.RecordSet("PRESKG").ToString
            TCodGrpMat.Text = DArt.RecordSet("CODGRPMAT").ToString
            ChManejaCorteLote.Checked = DArt.RecordSet("MANEJACORTELOTE")
            ChActivo.Checked = DArt.RecordSet("ACTIVO")
            ChLiquidoExt.Checked = DArt.RecordSet("LIQUIDOEXT")

            If Funcion_GeneraAlarmaCorteSinAbrir Then ChAlarmaCorteSinAbrir.Checked = DArt.RecordSet("ALARMACORTESINABRIR")
            If Funcion_ManejaVehiculo Then ChVehiculo.Checked = DArt.RecordSet("TIPOVEHICULO")

            If TCodGrpMat.Text = "0" Then
                CBNomGrpMat.Text = "SIN ASIGNAR"
            Else

                If TCodGrpMat.Text <> "" And TCodGrpMat.Text <> "-" Then
                    DVarios.Open("Select * from GRPMATERIALES where CODGRPMAT=" + TCodGrpMat.Text)
                    If DVarios.Count Then CBNomGrpMat.Text = DVarios.RecordSet("NOMGRPMAT")
                End If
            End If

            CLinea.Text = DArt.RecordSet("LINEA").ToString
            mnLCuenta.Text = DGArticulos.Rows.Count.ToString

            Fila = DGArticulos.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString()


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub



    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGArticulos.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGArticulos.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGArticulos.Rows(Fila).Selected = True
            DGArticulos.FirstDisplayedScrollingRowIndex = Fila
            DGArticulos.CurrentCell = DGArticulos(0, Fila)
            DGArticulos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp, CBBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                ''MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                ''TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                BActualizar_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGArticulos, DArt.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGArticulos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub





    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGArticulos.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGArticulos.Rows(Fila).Selected = True
            DGArticulos.FirstDisplayedScrollingRowIndex = Fila
            DGArticulos.CurrentCell = DGArticulos(0, Fila)
            DGArticulos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGArticulos.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGArticulos.Rows(Fila).Selected = True
            DGArticulos.FirstDisplayedScrollingRowIndex = Fila
            DGArticulos.CurrentCell = DGArticulos(0, Fila)
            DGArticulos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGArticulos.Rows.Count = 0 Then Exit Sub
            Fila = DGArticulos.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGArticulos.Rows(Fila).Selected = True
            DGArticulos.FirstDisplayedScrollingRowIndex = Fila
            DGArticulos.CurrentCell = DGArticulos(0, Fila)
            DGArticulos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try

            'If DRUsuario("MatPMod") Then
            If ValidaPermiso("Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If


            BCancelar_Click(Nothing, Nothing)
            BAceptar.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            TCodInt.Focus()
            DGArticulos.Enabled = False
            CLinea.Enabled = True
            CBNomGrpMat.Enabled = True
            ''CBNomGrpMat.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            BAceptar.Enabled = False
            CLinea.Text = ""
            CLinea.Enabled = False
            CLinea.DropDownStyle = ComboBoxStyle.DropDown
            CBNomGrpMat.Enabled = False
            CBNomGrpMat.Text = ""
            CBNomGrpMat.DropDownStyle = ComboBoxStyle.DropDown
            DGArticulos.Enabled = True
            ChManejaCorteLote.Checked = False
            ChVehiculo.Checked = False
            ChActivo.Checked = False
            ChLiquidoExt.Checked = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try

            'If DRUsuario("MatPMod") Then
            If ValidaPermiso("Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            BAceptar.Enabled = True
            CLinea.Enabled = True
            CBNomGrpMat.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            TCodInt.Focus()
            DGArticulos.Enabled = False
            CBNomGrpMat.DropDownStyle = ComboBoxStyle.DropDownList
            CLinea.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            If Val(TCodInt.Text) = 99999999 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_OPERACIONNOPERMITIDA) + DevuelveEvento(CodEvento.SISTEMA_CODIGORESERVADO), MsgBoxStyle.Critical)
                Exit Sub
            End If


            If TCodInt.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código interno del material"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TCodExt.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código externo del material"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TNombre.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre del material"), MsgBoxStyle.Critical)
                Exit Sub
            End If


            If Funcion_ManejaToleranciasPorcentaje Then
                If Eval(TTolSupPorc.Text) > TolMaxPorc Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " la tolerancia superior en porcentaje no debe ser mayor a " + TolMaxPorc.ToString + "%"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Eval(TTolInfPorc.Text) < TolMinPorc Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " la tolerancia inferior en porcentaje no debe ser menor a " + TolMinPorc.ToString + "%"), MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If


            If Eval(TTolMaxKg.Text) < TolMinKg Or Eval(TTolMaxKg.Text) > TolMaxKg Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " la tolerancia superior en kilogramos no debe ser mayor a " + TolMaxKg.ToString + " ni menor a " + TolMinKg.ToString), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Eval(TTolMinKg.Text) < TolMinKg Or Eval(TTolMinKg.Text) > TolMaxKg Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " la tolerancia inferior en kilogramos no debe ser mayor a " + TolMaxKg.ToString + " ni menor a " + TolMinKg.ToString), MsgBoxStyle.Critical)
                Exit Sub
            End If

            ''Se no maneja PLANTAS EXTERNAS se revisa si el código existe como PT, no se debe tener el mismo codigo para PT y MP (excepto Girardota Premezclas)
            'If Funcion_PlantasExternas Then
            'Else
            '    DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodInt.Text + "'")
            '    If DVarios.Count Then
            '        MsgBox(DevuelveEvento(CodEvento.BD_REGYAEXISTE, " como producto terminado"), vbCritical)
            '        MsgBox(DevuelveEvento(CodEvento.SISTEMA_OPERACIONNOPERMITIDA), vbCritical)
            '        Return
            '    End If
            'End If

            DArt.Open("select * from ARTICULOS WHERE TIPO='MP' and CodInt='" + TCodInt.Text.Trim + "'")

            If DArt.Count Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DArt.AddNew()
            End If

            DArt.RecordSet("CodInt") = TCodInt.Text
            DArt.RecordSet("CodExt") = TCodExt.Text
            DArt.RecordSet("NOMBRE") = CLeft(TNombre.Text, 30)
            DArt.RecordSet("TOLMINKG") = Eval(TTolMinKg.Text)
            DArt.RecordSet("TOLINFPORC") = Eval(TTolInfPorc.Text)
            DArt.RecordSet("TOLMAXKG") = Eval(TTolMaxKg.Text)
            DArt.RecordSet("TOLSUPPORC") = Eval(TTolSupPorc.Text)
            DArt.RecordSet("CODGRPMAT") = CLeft(TCodGrpMat.Text, 15)
            DArt.RecordSet("TIPO") = "MP"
            DArt.RecordSet("LINEA") = CLinea.Text
            DArt.RecordSet("TARAEMP") = Eval(TTaraEmp.Text)
            DArt.RecordSet("PRESKG") = Eval(TPresKg.Text)
            DArt.RecordSet("MANEJACORTELOTE") = ChManejaCorteLote.Checked
            DArt.RecordSet("ACTIVO") = ChActivo.Checked
            DArt.RecordSet("LIQUIDOEXT") = ChLiquidoExt.Checked
            If Funcion_GeneraAlarmaCorteSinAbrir Then
                DArt.RecordSet("ALARMACORTESINABRIR") = ChAlarmaCorteSinAbrir.Checked
            End If


            If Funcion_ManejaVehiculo Then DArt.RecordSet("TIPOVEHICULO") = ChVehiculo.Checked


            DArt.Update(Me)

            BCancelar_Click(Nothing, Nothing)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try

            'If DRUsuario("MatPMod") Then
            If ValidaPermiso("Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If TCodInt.Text.Trim = "" Then Exit Sub

            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            DArt.Delete("delete from ARTICULOS where CodInt='" + TCodInt.Text + "' and TIPO='MP'", Me)

            BCancelar_Click(Nothing, Nothing)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            'Refresca el DataGrid de materias primas
            DArt.Open("Select * from ARTICULOS where TIPO='MP' order by NOMBRE")
            AsignaDataGrid(DGArticulos, DArt.DataTable)
            If DGArticulos.RowCount > 0 Then DGArticulos_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodInt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyUp
        If e.KeyCode = Keys.Enter Then TCodExt.Focus()
    End Sub

    Private Sub TCodExt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodExt.KeyUp
        If e.KeyCode = Keys.Enter Then TNombre.Focus()
    End Sub

    Private Sub TNOMBRE_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TNombre.KeyUp
        If e.KeyCode = Keys.Enter Then BAceptar.Focus()
    End Sub

    Private Sub BImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimir.Click
        Dim RepSap As CrystalRep

        Try

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                '.Formulas(1) = "HORA='" + Format(Now, "HH:mm") + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpCatMPri.rpt"
                .SelectionFormula = "{Articulos.Tipo}='MP'"
                .PrintReport()
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGArticulos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGArticulos.KeyDown
        DGArticulos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGArticulos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGArticulos.KeyUp
        DGArticulos_CellClick(Nothing, Nothing)
    End Sub



    Private Sub TNomGrpMat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNomGrpMat.TextChanged, CBNomGrpMat.SelectedIndexChanged
        Try
            If Not FormLoad Then Return
            If CBNomGrpMat.Text = "" Then Return
            TCodGrpMat.Text = Devuelve_CodigoGrpMat(CBNomGrpMat.Text)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnSalir_Click(sender As Object, e As EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub mnInterfazArt_Click(sender As Object, e As EventArgs) Handles mnInterfazArt.Click
        Try
            Resp = Shell(Ruta + "ChrInterfazArt.EXE", AppWinStyle.NormalFocus)
        Catch ex As Exception
        MsgError(ex)
        End Try
    End Sub
End Class