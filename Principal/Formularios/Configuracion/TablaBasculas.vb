Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class TablaBasculas


    Private DBasculas As AdoSQL
    Private DVarios As AdoSQL
    Private Fila As Integer
    Private DFil() As DataRow
    Private DR As DataRow

    Private Sub TablaBasculas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            DBasculas = New AdoSQL("BASCULAS")
            DBasculas.Open("select * from BASCULAS")
            DVarios = New AdoSQL("LINEASPROD")
            DVarios.Open("Select LINEA FROM LINEASPROD")

            ''LLenaComboBox(CLinea, DVarios.DataTable, "LINEA")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGBasculas, DBasculas.DataTable)

            If DGBasculas.Rows.Count > 0 Then DGBasculas_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGBasculas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGBasculas.CellClick
        Try
            If DGBasculas.RowCount = 0 Then Exit Sub
            TBascula.ReadOnly = True
            TModo.ReadOnly = True
            TBascula.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("bascula").Value.ToString
            ''CLinea.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("Linea").Value.ToString
            TIncMin.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("InclusionMin").Value.ToString
            TCapacidad.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("Capac").Value.ToString
            TNombreSeccion.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("NombreSeccion").Value.ToString
            ChImprimir.Checked = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("Imprimir").Value
            TModo.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("A").Value.ToString

            Fila = DGBasculas.CurrentRow.Index

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub




    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
        TBascula.ReadOnly = True
        TModo.ReadOnly = True
        TCapacidad.Focus()
        ''CLinea.Focus()
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try


            If Eval(TBascula.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Báscula")
                Exit Sub
            End If

            'If CLinea.Text.Trim = "" Then
            '    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Línea")
            '    Exit Sub
            'End If

            If Eval(TIncMin.Text) = 0 And TModo.Text = "A" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " inclusión mínima de báscula")
                Exit Sub
            End If

            If Eval(TCapacidad.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " capacidad de báscula")
                Exit Sub
            End If

            DBasculas.Open("select * from BASCULAS where BASCULA=" + TBascula.Text)
            If DBasculas.Count > 0 Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DBasculas.AddNew()
            End If

            DBasculas.RecordSet("PLANTA") = Planta
            ''DBasculas.RecordSet("LINEA") = CLeft(CLinea.Text.ToUpper, 15)
            DBasculas.RecordSet("BASCULA") = Eval(TBascula.Text)
            DBasculas.RecordSet("CAPAC") = Eval(TCapacidad.Text)
            DBasculas.RecordSet("INCLUSIONMIN") = Eval(TIncMin.Text)
            DBasculas.RecordSet("IMPRIMIR") = ChImprimir.Checked
            DBasculas.RecordSet("NOMBRESECCION") = TNombreSeccion.Text
            DBasculas.Update()

            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        TablaBasculas_Load(Nothing, Nothing)
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
        ChImprimir.Checked = False
        TBascula.ReadOnly = True
        TModo.ReadOnly = True
        BActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.KeyUp
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TBascula_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBascula.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        TCapacidad.Focus()
    End Sub

    Private Sub TCapacidad_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCapacidad.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        TIncMin.Focus()
    End Sub

    Private Sub TIncMin_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TIncMin.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar.Focus()
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class