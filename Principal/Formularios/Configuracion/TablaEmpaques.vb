Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO

Public Class TablaEmpaques
    Private Campos() As String
    Private DArt As AdoSQL
    Private Fila As Integer
    Private DFil() As DataRow
    Private DR As DataRow
    Private EmpEtiq As String = ""
    Private DLineasProd As AdoSQL

    Private Sub TablaEmpaques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DLineasProd = New AdoSQL("LineasProd")
            DLineasProd.Open("Select * from LINEASPROD where TIPO='PT'")
            LLenaComboBox(CLinea, DLineasProd.DataTable, "LINEA")

            DArt = New AdoSQL("ARTICULOS")
            DArt.Open("select * from ARTICULOS where TIPO='EM' or TIPO='ET'")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGEmpaques, DArt.DataTable)

            If DGEmpaques.Rows.Count > 0 Then DGEmpaques_CellClick(Nothing, Nothing)

            Campos = {"CodInt@Cód.Int.", "Nombre@Nombre"}

            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DArt.DataTable)

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGEmpaques_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpaques.CellClick
        Try

            If DGEmpaques.RowCount = 0 Then Exit Sub

            Dim Tipo As String = ""

            TCodInt.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("CodINT").Value.ToString.Trim
            TNombre.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("Nombre").Value.ToString.Trim
            Tipo = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("TIPO").Value.ToString.Trim
            CLinea.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("LINEA").Value.ToString.Trim

            If Tipo = "EM" Then
                OEmpaque.Checked = True
            Else
                OEtiqueta.Checked = True
            End If

            'TCodInt.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("CODEMP").Value.ToString.Trim
            'TCodEtiq.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("CODETIQ").Value.ToString.Trim
            'TCodHilo.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("CODHILO").Value.ToString.Trim

            Fila = DGEmpaques.CurrentRow.Index

            mnTCuenta.Text = (Fila + 1).ToString
            mnLCuenta.Text = DGEmpaques.RowCount.ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        If DGEmpaques.RowCount = 0 Then Return
        Fila = DGEmpaques.RowCount - 1
        mnTCuenta.Text = (Fila + 1).ToString()
        DGEmpaques.Rows(Fila).Selected = True
        DGEmpaques.FirstDisplayedScrollingRowIndex = Fila
        DGEmpaques.CurrentCell = DGEmpaques(0, Fila)

        DGEmpaques_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Dim indifila As Integer = 0
        If DGEmpaques.RowCount = 0 Then Return
        indifila = DGEmpaques.RowCount - 1
        Fila += 1
        If Fila > indifila Then Fila = indifila
        mnTCuenta.Text = (Fila + 1).ToString()
        DGEmpaques.Rows(Fila).Selected = True
        DGEmpaques.FirstDisplayedScrollingRowIndex = Fila
        DGEmpaques.CurrentCell = DGEmpaques(0, Fila)
        DGEmpaques_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click
        If DGEmpaques.RowCount = 0 Then Return
        Fila -= 1
        If Fila < 0 Then Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGEmpaques.Rows(Fila).Selected = True
        DGEmpaques.FirstDisplayedScrollingRowIndex = Fila
        DGEmpaques.CurrentCell = DGEmpaques(0, Fila)
        DGEmpaques_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        If DGEmpaques.RowCount = 0 Then Return
        Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGEmpaques.Rows(Fila).Selected = True
        DGEmpaques.FirstDisplayedScrollingRowIndex = Fila
        DGEmpaques.CurrentCell = DGEmpaques(0, Fila)
        DGEmpaques_CellClick(Nothing, Nothing)

    End Sub


    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        TCodInt.ReadOnly = False
        TNombre.ReadOnly = False
        CLinea.Enabled = True
        TCodInt.Focus()
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim nuevo As Boolean = True

            If TNombre.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Nombre")
                Exit Sub
            End If

            If TCodInt.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Código")
                Exit Sub
            End If

            If OEmpaque.Checked = True Then
                EmpEtiq = "EM"
            End If

            If OEtiqueta.Checked = True Then
                EmpEtiq = "ET"
            End If

            DArt.Open("select * from ARTICULOS where Codint='" + TCodInt.Text.Trim + "' and TIPO='" + EmpEtiq + "'")
            If DArt.Count > 0 Then
                Resp = MessageBox.Show("El Código de Empaque ya existe desea sobre escribirlo", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
                nuevo = False
            Else
                DArt.AddNew()
            End If

            DArt.RecordSet("Codint") = CLeft(TCodInt.Text.ToUpper, 15)
            DArt.RecordSet("Nombre") = CLeft(TNombre.Text.ToUpper, 30)
            DArt.RecordSet("LINEA") = CLinea.Text

            If OEmpaque.Checked = True Then
                DArt.RecordSet("TIPO") = "EM"
            End If

            If OEtiqueta.Checked = True Then
                DArt.RecordSet("TIPO") = "ET"
            End If

            DArt.Update(Me)

            BCancelar_Click(Nothing, Nothing)

            If nuevo Then
                Evento("Se crea el Artículo " + TCodInt.Text + " con asignación " + DArt.RecordSet("TIPO"))
            Else
                Evento("Se modifica el Artículo " + TCodInt.Text + " Tipo " + DArt.RecordSet("TIPO"))
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        TablaEmpaques_Load(Nothing, Nothing)
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        TCodInt.ReadOnly = True
        TNombre.ReadOnly = True
        CLinea.Text = ""
        BActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        TCodInt.ReadOnly = False
        TNombre.ReadOnly = False
        CLinea.Enabled = True
        TCodInt.Text = ""
        TNombre.Text = ""
        OEmpaque.Checked = False
        OEtiqueta.Checked = False
        TCodInt.Focus()
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            If OEmpaque.Checked = True Then
                EmpEtiq = "EM"
            End If

            If OEtiqueta.Checked = True Then
                EmpEtiq = "ET"
            End If

            Resp = MessageBox.Show("Desea Eliminar el código " + TNombre.Text, "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            DArt.Delete("delete from ARTICULOS where CodInt='" + TCodInt.Text.Trim + "' and TIPO='" + EmpEtiq + "'", Me)

            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BNuevo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
        TCodInt.Focus()
    End Sub

    Private Sub BEditar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
    End Sub

    Private Sub TBuscar_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try


            If CBBuscar.Text = "" Then
                'CBBuscar.Focus()
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " a buscar")
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                FRefrescaDG_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGEmpaques, DArt.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGEmpaques_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDG_Click(sender As System.Object, e As System.EventArgs) Handles FRefrescaDG.Click
        Try
            'Refresca el DataGrid de empaques y etiquetas
            DArt.Open("select * from ARTICULOS where TIPO='EM' or TIPO='ET'")
            AsignaDataGrid(DGEmpaques, DArt.DataTable)
            If DGEmpaques.RowCount > 0 Then DGEmpaques_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class