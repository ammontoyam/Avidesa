Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ChronoSoftNet.AdoNet

Public Class TablasSecuenciaMezcla

    Private DEspecies As AdoSQL
    Private DGrpFor As AdoSQL
    Private DGrpMat As AdoSQL

    Private Fila As Integer
    Private DFila() As DataRow
    Private DR As DataRow


    Private Sub DG_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        Try
            If DG.RowCount = 0 Then Exit Sub
            TCodigo.Text = DG.Rows(DG.CurrentRow.Index).Cells(0).Value.ToString.Trim
            TNombre.Text = DG.Rows(DG.CurrentRow.Index).Cells(1).Value.ToString.Trim
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
        Try
            If ValidaPermiso("SecuenciaMezcla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            TCodigo.ReadOnly = False
            TNombre.ReadOnly = False
            TCodigo.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub IngEspGrpForMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DEspecies = New AdoSQL("Especies")
            DGrpFor = New AdoSQL("GrpFor")
            DGrpMat = New AdoSQL("GrpMat")


            BTraeDatos_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BTraeDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTraeDatos.Click
        Try
            TNombre.Text = ""
            TCodigo.Text = ""
            DG.DataSource = Nothing
            DG.Rows.Clear()
            DG.Columns.Clear()

            If OpEspecies.Checked = True Then
                LSeleccion.Text = "Listado de Especies"
                LDatosSel.Text = "Especie"

                DEspecies.Open("select * from ESPECIES order by CODESPECIE")

                If DEspecies.Count = 0 Then Return

                DG.DataSource = DEspecies.DataTable
                DG_CellClick(Nothing, Nothing)
                Return


            End If

            If OpGrpFor.Checked = True Then
                LSeleccion.Text = "Listado de Grupo de Fórmulas"
                LDatosSel.Text = "Grupo de Fórmulas"

                DGrpFor.Open("select * from GRPFORMULAS")

                If DGrpFor.Count = 0 Then Return

                DG.DataSource = DGrpFor.DataTable
                DG_CellClick(Nothing, Nothing)
                Return

            End If
            If OpGrpMat.Checked = True Then
                LSeleccion.Text = "Listado de Grupo de Materiales"
                LDatosSel.Text = "Grupo de Materiales"

                DGrpMat.Open("select * from GRPMATERIALES")

                If DGrpMat.Count = 0 Then Return

                DG.DataSource = DGrpMat.DataTable
                DG_CellClick(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OpEspecies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpEspecies.Click
        BTraeDatos_Click(Nothing, Nothing)
    End Sub

    Private Sub OpGrpMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpGrpMat.Click
        BTraeDatos_Click(Nothing, Nothing)
    End Sub

    Private Sub OpGrpFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpGrpFor.Click
        BTraeDatos_Click(Nothing, Nothing)
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            TCodigo.ReadOnly = True
            TNombre.ReadOnly = True
            TCodigo.Text = ""
            TNombre.Text = ""
            BTraeDatos_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If TCodigo.ReadOnly = True Then Return

            If TNombre.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Nombre")
                Exit Sub
            End If

            If TCodigo.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + " Código")
                Exit Sub
            End If

            If OpEspecies.Checked = True Then

                DEspecies.Open("select * from ESPECIES where CODESPECIE='" + TCodigo.Text + "'")

                If DEspecies.Count > 0 Then
                    Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGYAEXISTE), MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                    'Resp = MessageBox.Show("La Especie ya existe desea Sobre escribirla", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Resp = vbNo Then Exit Sub
                Else
                    DEspecies.AddNew()
                End If

                DEspecies.RecordSet("CODESPECIE") = CLeft(TCodigo.Text.ToUpper, 15)
                DEspecies.RecordSet("NOMESPECIE") = CLeft(TNombre.Text.ToUpper, 30)

                DEspecies.Update(Me)

                BCancelar_Click(Nothing, Nothing)
                Return
            End If

            If OpGrpFor.Checked = True Then

                DGrpFor.Open("select * from GRPFORMULAS where CODGRPFOR='" + TCodigo.Text + "'")

                If DGrpFor.Count > 0 Then
                    Resp = MessageBox.Show("El Grupo de Fórmula ya existe desea Sobre escribirlo", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Resp = vbNo Then Exit Sub
                Else
                    DGrpFor.AddNew()
                End If
                DGrpFor.RecordSet("CODGRPFOR") = CLeft(TCodigo.Text.ToUpper, 15)
                DGrpFor.RecordSet("NOMGRPFOR") = CLeft(TNombre.Text.ToUpper, 30)

                DGrpFor.Update(Me)

                BCancelar_Click(Nothing, Nothing)
                Return
            End If
            If OpGrpMat.Checked = True Then

                DGrpMat.Open("select * from GRPMATERIALES where CODGRPMAT='" + TCodigo.Text + "'")


                If DGrpMat.Count > 0 Then
                    Resp = MessageBox.Show("El Grupo de Materiales ya existe desea Sobre escribirlo", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If Resp = vbNo Then Exit Sub
                Else
                    DGrpMat.AddNew()
                End If

                DGrpMat.RecordSet("CODGRPMAT") = CLeft(TCodigo.Text.ToUpper, 15)
                DGrpMat.RecordSet("NOMGRPMAT") = CLeft(TNombre.Text.ToUpper, 30)

                DGrpMat.Update(Me)
                BCancelar_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            If ValidaPermiso("SecuenciaMezcla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            TCodigo.ReadOnly = False
            TNombre.ReadOnly = False
            TCodigo.Text = ""
            TNombre.Text = ""
            TCodigo.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodigo.TextChanged
        TCodigo.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TNombre.TextChanged
        TNombre.CharacterCasing = CharacterCasing.Upper
    End Sub


    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            If ValidaPermiso("SecuenciaMezcla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If OpEspecies.Checked = True Then

                DEspecies.Delete("delete from ESPECIES where CODESPECIE='" + TCodigo.Text + "'", Me)
                BCancelar_Click(Nothing, Nothing)
                Return
            End If
            If OpGrpFor.Checked = True Then
                DGrpFor.Delete("delete from GRPFORMULAS where CODGRPFOR='" + TCodigo.Text + "'", Me)
                BCancelar_Click(Nothing, Nothing)
                Return
            End If
            If OpGrpMat.Checked = True Then
                DGrpMat.Delete("delete from GRPMATERIALES where CODGRPMAT='" + TCodigo.Text + "'", Me)
                BCancelar_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMateriales.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub mnAcercaD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaD.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class