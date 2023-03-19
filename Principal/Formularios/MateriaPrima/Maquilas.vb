Option Explicit On


Imports ClassLibrary

Public Class Maquilas

    Private DMaquila As AdoSQL

    Private Sub Maquilas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DMaquila = New AdoSQL("MAQUILA")

            DMaquila.Open("select * from MAQUILAS order by CENTROTRABAJO")
            AsignaDataGrid(DGMaquilas, DMaquila.DataTable)

            DGMaquilas_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGMaquilas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMaquilas.CellClick
        Try
            If DGMaquilas.Rows.Count = 0 Then Exit Sub

            TCodMaquila.Text = DGMaquilas.CurrentRow.Cells("CENTROTRABAJO").Value
            TNombreMaquila.Text = DGMaquilas.CurrentRow.Cells("NOMBREMAQ").Value
            ChActivo.Checked = DGMaquilas.CurrentRow.Cells("ACTIVO").Value
            TObservaciones.Text = DGMaquilas.CurrentRow.Cells("OBSERVACIONES").Value

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Dispose()
        Close()
    End Sub

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        Try

            TCodMaquila.Text = ""
            TNombreMaquila.Text = ""
            TObservaciones.Text = ""

            ChActivo.Checked = False
            GBMaquilas.Enabled = True

            BEditar.Enabled = False
            BBorrar.Enabled = False
            BNuevo.Enabled = False
            BActualizar.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BBorrar_Click(sender As Object, e As EventArgs) Handles BBorrar.Click
        Try
            If ValidaPermiso("Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If (TCodMaquila.Text.Trim <> "") Then
                DMaquila.Delete("delete from MAQUILAS where CENTROTRABAJO ='" + Trim(TCodMaquila.Text) + "'", Me)
            End If

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DMaquila.Open("select * from MAQUILAS order by CENTROTRABAJO")
            AsignaDataGrid(DGMaquilas, DMaquila.DataTable)

            DGMaquilas_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        Try
            BEditar.Enabled = False
            BBorrar.Enabled = False
            BNuevo.Enabled = False
            BActualizar.Enabled = False
            GBMaquilas.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Try
            TCodMaquila.Text = ""
            TNombreMaquila.Text = ""
            TObservaciones.Text = ""

            ChActivo.Checked = False
            GBMaquilas.Enabled = False

            BEditar.Enabled = True
            BBorrar.Enabled = True
            BNuevo.Enabled = True
            BActualizar.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        Try

            If ValidaPermiso("Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If TCodMaquila.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de la maquila"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TNombreMaquila.Text.Trim = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre del maquilador"), MsgBoxStyle.Critical)
                Exit Sub
            End If


            DMaquila.Open("select * from MAQUILAS where CENTROTRABAJO ='" + TCodMaquila.Text + "'order by CENTROTRABAJO")

            If DMaquila.Count Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DMaquila.AddNew()
            End If

            DMaquila.RecordSet("CENTROTRABAJO") = TCodMaquila.Text
            DMaquila.RecordSet("NOMBREMAQ") = CLeft(TNombreMaquila.Text, 30).ToUpper
            DMaquila.RecordSet("ACTIVO") = ChActivo.CheckState
            If TObservaciones.Text.Trim = "" Then
                DMaquila.RecordSet("OBSERVACIONES") = "-"
            Else
                DMaquila.RecordSet("OBSERVACIONES") = TObservaciones.Text
            End If
            DMaquila.Update()

            BCancelar_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

End Class