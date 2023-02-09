Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO

Public Class TMuertos

    Private DTMuertos As AdoSQL
    Private DMotivos As AdoSQL
    'Private DVarios As AdoSQL
    Private Fila As Integer = 0


    Private Sub TMuertos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DTMuertos = New AdoSQL("TMuertos")
            DTMuertos.Open("Select * from TMUERTOS where CODMOTIVO='0' order by FECHA desc")

            DMotivos = New AdoSQL("TMuertosCat")
            DMotivos.Open("Select * from TMUERTOSCAT order by CODMOTIVO")

            AsignaDataGrid(DGMotivos, DMotivos.DataTable, True)
            AsignaDataGrid(DGTMuertos, DTMuertos.DataTable)

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            TObservacion.ReadOnly = False
            TCodMotivo.ReadOnly = False

            If DGTMuertos.RowCount > 0 Then DGTMuertos_CellClick(Nothing, Nothing)

            BAceptar.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DGTMuertos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTMuertos.CellClick
        Try
            If DGTMuertos.Rows.Count = 0 Then Exit Sub
            'mnLCuenta.Text = DGTMuertos.Rows.Count.ToString
            'Fila = DGTMuertos.CurrentRow.Index
            'mnTCuenta.Text = (Fila + 1).ToString


            TID.Text = DGTMuertos.Rows(DGTMuertos.CurrentRow.Index).Cells("ID").Value.ToString
            TUsuario.Text = DGTMuertos.Rows(DGTMuertos.CurrentRow.Index).Cells("USUARIO").Value.ToString
            TFecha.Text = DGTMuertos.Rows(DGTMuertos.CurrentRow.Index).Cells("FECHA").Value.ToString
            TTiempo.Text = DGTMuertos.Rows(DGTMuertos.CurrentRow.Index).Cells("TIEMPO").Value.ToString

            BAceptar.Enabled = True


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGMotivos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMotivos.CellClick
        Try

            If DGMotivos.RowCount = 0 Then Return

            TCodMotivo.Text = DGMotivos.Rows(DGMotivos.CurrentRow.Index).Cells("DGMOTIVOS_CODMOTIVO").Value.ToString
            TMotivo.Text = DGMotivos.Rows(DGMotivos.CurrentRow.Index).Cells("DGMOTIVOS_MOTIVO").Value.ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            If Eval(TID.Text) = 0 Then Return

            DTMuertos.Open("Select * from TMUERTOS where ID=" + TID.Text)

            If DTMuertos.Count > 0 Then

                DTMuertos.RecordSet("CODMOTIVO") = Eval(TCodMotivo.Text)
                DTMuertos.RecordSet("OBSERVACION") = TObservacion.Text

                If Len(TObservacion.Text) < 3 Then DTMuertos.RecordSet("OBSERVACION") = TMotivo.Text

                DTMuertos.Update()

                BCancelar_Click(Nothing, Nothing)

                DTMuertos.Open("Select * from TMUERTOS where CODMOTIVO='0' order by FECHA desc")
                AsignaDataGrid(DGTMuertos, DTMuertos.DataTable)

                If DGTMuertos.RowCount > 0 Then DGTMuertos_CellClick(Nothing, Nothing)

            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMotivo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodMotivo.KeyUp
        Try

            If e.KeyCode = Keys.Enter AndAlso DGMotivos.Rows.Count = 1 Then
                DGMotivos_CellClick(Nothing, Nothing)
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGMotivos, DMotivos.DataTable, True)
                Exit Sub
            End If


            If e.KeyCode = Keys.Back Then
                TCodMotivo.Text = ""
                TMotivo.Text = ""
            End If

            If TCodMotivo.Text = "" Then
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGMotivos, DMotivos.DataTable, True)
                Exit Sub
            End If

            Dim Hallado As Boolean

            BusquedaDG(DGMotivos, DMotivos.DataTable, TCodMotivo.Text, "CODMOTIVO", Hallado)

            If Hallado = False Then
                TCodMotivo.Focus()
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE), MsgBoxStyle.Critical)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try


            'If DRUsuario("CONFIG") Then
            If ValidaPermiso("Calidad") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If


            GBNuevoMot.Visible = True
            TCodMotivo2.Text = ""
            TCodMotivo2.ReadOnly = False
            TMotivo2.Text = ""
            TMotivo2.ReadOnly = False
            DGMotivos.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar2.Click
        Try
            TCodMotivo2.Text = ""
            TMotivo2.Text = ""
            DGMotivos.Enabled = True
            GBNuevoMot.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar2.Click
        Try
            If TCodMotivo2.Text = "" Then Return
            If TMotivo2.Text = "" Then Return

            DMotivos.Open("Select * from TMUERTOSCAT where CODMOTIVO='" + TCodMotivo2.Text + "'")

            If DMotivos.Count Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DMotivos.AddNew()
            End If

            DMotivos.RecordSet("CODMOTIVO") = CLeft(TCodMotivo2.Text, 15)
            DMotivos.RecordSet("MOTIVO") = CLeft(TMotivo2.Text, 100)
            DMotivos.Update()

            DMotivos.Open("Select * from TMUERTOSCAT ORDER by CODMOTIVO")
            AsignaDataGrid(DGMotivos, DMotivos.DataTable, True)

            GBNuevoMot.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            GBNuevoMot.Visible = True
            TCodMotivo2.Text = ""
            TCodMotivo2.ReadOnly = False
            TMotivo2.Text = ""
            TMotivo2.ReadOnly = False
            DGMotivos.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If DGTMuertos.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGTMuertos.RowCount - 1
            ''mnTCuenta.Text = (Fila + 1).ToString()
            Fila += 1
            If Fila > indifila Then Fila = indifila


            DGTMuertos.Rows(Fila).Selected = True
            DGTMuertos.FirstDisplayedScrollingRowIndex = Fila
            DGTMuertos.CurrentCell = DGTMuertos(0, Fila)
            DGTMuertos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            If DGTMuertos.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            '' mnTCuenta.Text = (Fila + 1).ToString()

            DGTMuertos.Rows(Fila).Selected = True
            DGTMuertos.FirstDisplayedScrollingRowIndex = Fila
            DGTMuertos.CurrentCell = DGTMuertos(0, Fila)
            DGTMuertos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If DGTMuertos.Rows.Count = 0 Then Exit Sub

            Fila = 0
            '' mnTCuenta.Text = (Fila + 1).ToString()

            DGTMuertos.Rows(Fila).Selected = True
            DGTMuertos.FirstDisplayedScrollingRowIndex = Fila
            DGTMuertos.CurrentCell = DGTMuertos(0, Fila)
            DGTMuertos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If DGTMuertos.Rows.Count = 0 Then Exit Sub
            Fila = DGTMuertos.Rows.Count - 1
            ' mnTCuenta.Text = (Fila + 1).ToString()
            DGTMuertos.Rows(Fila).Selected = True
            DGTMuertos.FirstDisplayedScrollingRowIndex = Fila
            DGTMuertos.CurrentCell = DGTMuertos(0, Fila)
            DGTMuertos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        TMuertos_Load(Nothing, Nothing)
    End Sub


    Private Sub DGTMuertos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGTMuertos.KeyUp
        DGTMuertos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGTMuertos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGTMuertos.KeyDown
        DGTMuertos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGMotivos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGMotivos.KeyDown
        DGMotivos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGMotivos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGMotivos.KeyUp
        DGMotivos_CellClick(Nothing, Nothing)
    End Sub

    Private Sub BBorrar_Click(sender As System.Object, e As System.EventArgs) Handles BBorrar.Click
        Try
            If TCodMotivo.Text = "" Then Return

            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGELIMINAR), vbCritical + vbYesNo)
            If Resp = vbNo Then Return
            DMotivos.Delete("Delete from TMUERTOSCAT where CODMOTIVO='" + TCodMotivo.Text + "'", Me)

            Evento("Elimina motivo de tiempo muerto código" + TCodMotivo.Text)

            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class