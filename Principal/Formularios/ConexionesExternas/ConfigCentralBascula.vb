
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class ConfigCentralBascula

    Private DConceptosCB As AdoSQL
    Private DVarios As AdoSQL
    Private FormLoad As Boolean

    Private Sub ConfigCentralBascula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If FormLoad Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If
            DConceptosCB = New AdoSQL("CONCEPTOSCB")
            DVarios = New AdoSQL("VARIOS")
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DConceptosCB.Open("Select * from CONCEPTOSCONTBASC ORDER BY CONCEPTO")
            AsignaDataGrid(DGConceptosCB, DConceptosCB.DataTable)

            'If DGConceptosCB.RowCount > 0 Then DGConceptCB_CellClick(Nothing, Nothing)

            'Se trae centro operación y compañia de la tabla ConfigParametros

            TCia.Text = ConfigParametros("COMPAÑIACB")
            TCentroOper.Text = ConfigParametros("CENTROOPERCB")
            TUltRowID.Text = ConfigParametros("UltContadorCB")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGConceptCB_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGConceptosCB.CellClick
        Try
            If DGConceptosCB.RowCount = 0 Then Exit Sub
            TConcepto.Text = DGConceptosCB.Rows(DGConceptosCB.CurrentRow.Index).Cells("Concepto").Value

            DVarios.Open("Select * from CONCEPTOSCONTBASC WHERE CONCEPTO='" + TConcepto.Text + "'")
            If DVarios.Count = 0 Then Return

            TDescripcion.Text = DVarios.RecordSet("DESCRIPCION")
            CBTipoMov.Text = DVarios.RecordSet("TIPOMOV")
            CBTipoLote.Text = DVarios.RecordSet("TIPOLOTE")


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Try
            Me.Hide()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            GBParametros.Enabled = True
            CBTipoMov.Enabled = True
            CBTipoLote.Enabled = True
            DGConceptosCB.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            GBParametros.Enabled = False
            CBTipoMov.Enabled = False
            CBTipoLote.Enabled = False
            DGConceptosCB.Enabled = True
            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        Try
            TDescripcion.Text = ""
            TConcepto.Text = ""
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            GBParametros.Enabled = False
            CBTipoMov.Enabled = True
            CBTipoLote.Enabled = True
            DGConceptosCB.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        Try

            If TConcepto.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Concepto"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            If TDescripcion.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Descripción"), MsgBoxStyle.Critical)
                Exit Sub
            End If

            DConceptosCB.Open("Select * from CONCEPTOSCONTBASC WHERE CONCEPTO='" + TConcepto.Text.Trim + "'")

            If DConceptosCB.Count Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DConceptosCB.AddNew()
            End If

            DConceptosCB.RecordSet("CONCEPTO") = TConcepto.Text
            DConceptosCB.RecordSet("DESCRIPCION") = TDescripcion.Text
            DConceptosCB.RecordSet("TIPOLOTE") = CBTipoLote.Text
            DConceptosCB.RecordSet("TIPOMOV") = CBTipoMov.Text

            DConceptosCB.Update(Me)

            'Se valida si hay cambios en los parametros centrooperacion y compañia
            If GBParametros.Enabled Then
                If TCia.Text <> ConfigParametros("COMPAÑIACB") Then
                    WriteConfigParametros("COMPAÑIACB", TCia.Text)
                End If
                If TCentroOper.Text <> ConfigParametros("CENTROOPERCB") Then
                    WriteConfigParametros("CENTROOPERCB", TCentroOper.Text)
                End If
                If Val(TUltRowID.Text) <> Val(ConfigParametros("UltContadorCB")) Then
                    WriteConfigParametros("UltContadorCB", TUltRowID.Text)
                End If

            End If

            BCancelar_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(sender As Object, e As EventArgs) Handles BBorrar.Click
        Try

            If TConcepto.Text = "" Then Return

            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            DConceptosCB.Delete("delete from CONCEPTOSCONTBASC where CONCEPTO='" + TConcepto.Text + "'", Me)

            BCancelar_Click(Nothing, Nothing)

            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Class