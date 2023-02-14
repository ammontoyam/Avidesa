Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class BachesAbort

    Private DBachesAbort As AdoSQL
    Private DVarios As AdoSQL
    Dim Fila As Int32


    Private Sub BachesAbort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DBachesAbort = New AdoSQL("BachesAbort")
            DVarios = New AdoSQL("Varios")

            DBachesAbort.Open("Select * from BACHESABORT order by FECHA desc")

            AsignaDataGrid(DGBachesAbort, DBachesAbort.DataTable, False)

            If DBachesAbort.Rows.Count > 0 Then DGBachesAbort_CellClick(Nothing, Nothing)

            BAceptar.Enabled = False


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    
    Private Sub DGBachesAbort_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGBachesAbort.CellClick
        Try

            If DGBachesAbort.Rows.Count = 0 Then Return

            mnLCuenta.Text = DGBachesAbort.Rows.Count.ToString
            Fila = DGBachesAbort.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString

            TID.Text = DGBachesAbort.Rows(DGBachesAbort.CurrentRow.Index).Cells("ID").Value.ToString
            TCont.Text = DGBachesAbort.Rows(DGBachesAbort.CurrentRow.Index).Cells("CONT").Value.ToString
            TUsuario.Text = DGBachesAbort.Rows(DGBachesAbort.CurrentRow.Index).Cells("USUARIO").Value.ToString
            TObservacion.Text = DGBachesAbort.Rows(DGBachesAbort.CurrentRow.Index).Cells("OBSERV").Value.ToString
            TFecha.Text = DGBachesAbort.Rows(DGBachesAbort.CurrentRow.Index).Cells("FECHA").Value.ToString

            BAceptar.Enabled = True


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click

        Try

            If Eval(TID.Text) = 0 Then Return

            DBachesAbort.Open("Select * from BACHESABORT where ID=" + TID.Text)

            If DBachesAbort.Count > 0 Then


                DBachesAbort.RecordSet("OBSERV") = CLeft(TObservacion.Text, 100)
                DBachesAbort.Update()

                BCancelar_Click(Nothing, Nothing)

                DBachesAbort.Open("Select * from BACHESABORT order by FECHA desc")
                AsignaDataGrid(DGBachesAbort, DBachesAbort.DataTable)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGBachesAbort.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGBachesAbort.RowCount - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            Fila += 1
            If Fila > indifila Then Fila = indifila


            DGBachesAbort.Rows(Fila).Selected = True
            DGBachesAbort.FirstDisplayedScrollingRowIndex = Fila
            DGBachesAbort.CurrentCell = DGBachesAbort(0, Fila)
            DGBachesAbort_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGBachesAbort.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGBachesAbort.Rows(Fila).Selected = True
            DGBachesAbort.FirstDisplayedScrollingRowIndex = Fila
            DGBachesAbort.CurrentCell = DGBachesAbort(0, Fila)
            DGBachesAbort_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGBachesAbort.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGBachesAbort.Rows(Fila).Selected = True
            DGBachesAbort.FirstDisplayedScrollingRowIndex = Fila
            DGBachesAbort.CurrentCell = DGBachesAbort(0, Fila)
            DGBachesAbort_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGBachesAbort.Rows.Count = 0 Then Exit Sub
            Fila = DGBachesAbort.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGBachesAbort.Rows(Fila).Selected = True
            DGBachesAbort.FirstDisplayedScrollingRowIndex = Fila
            DGBachesAbort.CurrentCell = DGBachesAbort(0, Fila)
            DGBachesAbort_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGBachesAbort_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGBachesAbort.KeyDown
        DGBachesAbort_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGBachesAbort_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGBachesAbort.KeyUp
        DGBachesAbort_CellClick(Nothing, Nothing)
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        BachesAbort_Load(Nothing, Nothing)
    End Sub

    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Materiales.ShowDialog()
    End Sub

    Private Sub mnAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaDe.Click

    End Sub
End Class