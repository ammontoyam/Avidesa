Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO

Public Class Ubicaciones


    Private DUbicacion As AdoSQL
    Private Fila As Integer
    Private DFil() As DataRow
    Private DR As DataRow
    Private FormLoad As Boolean
    Private TipoFiltro As String

    Private Sub Ubicaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FormLoad Then Return

            DUbicacion = New AdoSQL("UBICACIONES")

            TipoFiltro = "LT"

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)

            FRefrescaDG_Click(Nothing, Nothing)

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        Try

            If DG.RowCount = 0 Then Exit Sub

            Dim Tipo As String = ""

            TCodigo.Text = DG.Rows(DG.CurrentRow.Index).Cells("CodUbi").Value.ToString.Trim
            TDescripcion.Text = DG.Rows(DG.CurrentRow.Index).Cells("Descripcion").Value.ToString.Trim
            TTipo.Text =  DG.Rows(DG.CurrentRow.Index).Cells("Tipo").Value.ToString.Trim
            ChConsumo.Checked = DG.Rows(DG.CurrentRow.Index).Cells("Consumo").Value

            Fila = DG.CurrentRow.Index

            mnTCuenta.Text = (Fila + 1).ToString
            mnLCuenta.Text = DG.RowCount.ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        If DG.RowCount = 0 Then Return
        Fila = DG.RowCount - 1
        mnTCuenta.Text = (Fila + 1).ToString()
        DG.Rows(Fila).Selected = True
        DG.FirstDisplayedScrollingRowIndex = Fila
        DG.CurrentCell = DG(0, Fila)

        DG_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Dim indifila As Integer = 0
        If DG.RowCount = 0 Then Return
        indifila = DG.RowCount - 1
        Fila += 1
        If Fila > indifila Then Fila = indifila
        mnTCuenta.Text = (Fila + 1).ToString()
        DG.Rows(Fila).Selected = True
        DG.FirstDisplayedScrollingRowIndex = Fila
        DG.CurrentCell = DG(0, Fila)
        DG_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click
        If DG.RowCount = 0 Then Return
        Fila -= 1
        If Fila < 0 Then Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DG.Rows(Fila).Selected = True
        DG.FirstDisplayedScrollingRowIndex = Fila
        DG.CurrentCell = DG(0, Fila)
        DG_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        If DG.RowCount = 0 Then Return
        Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DG.Rows(Fila).Selected = True
        DG.FirstDisplayedScrollingRowIndex = Fila
        DG.CurrentCell = DG(0, Fila)
        DG_CellClick(Nothing, Nothing)

    End Sub


    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        TCodigo.ReadOnly = False
        TDescripcion.ReadOnly = False
        TCodigo.Focus()
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try


            If TDescripcion.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Descripción", vbInformation)
                Exit Sub
            End If

            If TCodigo.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Código ")
                Exit Sub
            End If

            DUbicacion.Open("select * from UBICACIONES where CODUBI='" + TCodigo.Text.Trim + "'")
            If DUbicacion.Count > 0 Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DUbicacion.AddNew()
            End If


            DUbicacion.RecordSet("CodUbi") = CLeft(TCodigo.Text.ToUpper, 15)
            DUbicacion.RecordSet("Descripcion") = CLeft(TDescripcion.Text.ToUpper, 30)
            DUbicacion.RecordSet("Tipo") = TTipo.Text.ToUpper
            DUbicacion.RecordSet("Consumo") = ChConsumo.Checked


            DUbicacion.Update(Me)

            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        TCodigo.ReadOnly = True
        TDescripcion.ReadOnly = True
        BActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        TCodigo.ReadOnly = False
        TDescripcion.ReadOnly = False
        TCodigo.Text = ""
        TDescripcion.Text = ""
        TTipo.Text = ""

        TCodigo.Focus()
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try

            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            DUbicacion.Delete("delete from UBICACIONES where Codubi='" + TCodigo.Text.Trim + "'", Me)

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




    Private Sub FRefrescaDG_Click(sender As System.Object, e As System.EventArgs) Handles FRefrescaDG.Click
        Try

            If TipoFiltro = "" Then Return

            DUbicacion.Open("Select * from UBICACIONES where TIPO='" + TipoFiltro + "' order by CODUBI")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DG, DUbicacion.DataTable)

            If DG.Rows.Count > 0 Then DG_CellClick(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RBLT_Click(sender As System.Object, e As System.EventArgs) Handles RBLT.Click
        TipoFiltro = "LT"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

   
    Private Sub RBPT_Click(sender As System.Object, e As System.EventArgs) Handles RBPT.Click
        TipoFiltro = "PT"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub


    Private Sub RBMP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBMP.CheckedChanged
        TipoFiltro = "MP"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub TCodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles TCodigo.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        TDescripcion.Focus()
    End Sub

    Private Sub TDescripcion_KeyUp(sender As Object, e As KeyEventArgs) Handles TDescripcion.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        TTipo.Focus()
    End Sub

    Private Sub TTipo_KeyUp(sender As Object, e As KeyEventArgs) Handles TTipo.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        ChConsumo.Focus()
    End Sub

    Private Sub ChConsumo_KeyUp(sender As Object, e As KeyEventArgs) Handles ChConsumo.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar.Focus()
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub RBUPT_Click(sender As Object, e As EventArgs) Handles RBUPT.Click
        TipoFiltro = "UPT"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub
End Class