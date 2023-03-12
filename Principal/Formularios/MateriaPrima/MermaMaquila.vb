Option Explicit On


Imports ClassLibrary

Public Class MermaMaquila

    Private DMermaMaq As AdoSQL
    Private DMaquila As AdoSQL

    Private Sub MermaMaquila_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DMermaMaq = New AdoSQL("MERMAMAQUILA")
            DMaquila = New AdoSQL("MERMAMAQUILA")

            DMaquila.Open("select CENTROTRABAJO from MAQUILAS order by CENTROTRABAJO")
            DMermaMaq.Open("select * from MERMAMAQ order by CENTROTRABAJO")

            LLenaComboBox(CMaquila, DMaquila.DataTable, "CENTROTRABAJO")
            AsignaDataGrid(DGMermaMaq, DMermaMaq.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Dispose()
        Close()
    End Sub

    Private Sub BBorrar_Click(sender As Object, e As EventArgs) Handles BBorrar.Click
        Try
            If ValidaPermiso("Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If (TCodInt.Text.Trim <> "") Then
                DMermaMaq.Open("delete MERMAMAQ where CENTROTRABAJO ='" + Trim(CMaquila.Text) + "' and CODINT = " + Trim(TCodInt.Text))
            End If

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CMaquila_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMaquila.SelectedIndexChanged
        Try
            DMaquila.Open("select * from MAQUILAS where CENTROTRABAJO=" + CMaquila.Text + "order by CENTROTRABAJO")
            If DMaquila.Count Then
                TNombreMaquila.Text = DMaquila.RecordSet("NOMBREMAQ")
            End If
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

            If Trim(TCodInt.Text) = "" Or Trim(CMaquila.Text) = "" Then
                Exit Sub
            End If

            DMermaMaq.Open("select * from MERMAMAQ where CENTROTRABAJO ='" + Trim(CMaquila.Text) + "' and CODINT = " + Trim(TCodInt.Text))
            If DMermaMaq.Count = 0 Then
                DMermaMaq.AddNew()
            End If

            DMermaMaq.RecordSet("CENTROTRABAJO") = Trim(CMaquila.Text)
            DMermaMaq.RecordSet("CODINT") = Trim(TCodInt.Text)
            DMermaMaq.RecordSet("PORCMERMA") = Val(TPorcMerma.Text)
            DMermaMaq.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")

            DMermaMaq.Update()

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DMaquila.Open("select CENTROTRABAJO from MAQUILAS order by CENTROTRABAJO")
            DMermaMaq.Open("select * from MERMAMAQ order by CENTROTRABAJO")

            LLenaComboBox(CMaquila, DMaquila.DataTable, "CENTROTRABAJO")
            AsignaDataGrid(DGMermaMaq, DMermaMaq.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Try
            CMaquila.Text = ""
            TPorcMerma.Text = ""
            TNombreMaquila.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGMermaMaq_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGMermaMaq.CellClick
        Try
            If DGMermaMaq.Rows.Count = 0 Then Exit Sub

            'DMermaMaq.Find("CodInt='" + DGMermaMaq.Rows(DGMermaMaq.CurrentRow.Index).Cells("CodInt").Value.ToString.Trim + "'")
            'If DMermaMaq.EOF Then Exit Sub

            CMaquila.Text = DGMermaMaq.CurrentRow.Cells("CENTROTRABAJO").Value
            TPorcMerma.Text = DGMermaMaq.CurrentRow.Cells("PORCMERMA").Value

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class