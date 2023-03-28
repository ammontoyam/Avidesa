Imports ClassLibrary


Public Class TamDescarga
    Private DTamDesc As AdoSQL
    Private Sub TamDescarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DTamDesc = New AdoSQL("TamanoDescarga")
            DTamDesc.Open("select * from TAMDESC order by CODDESC")
            AsignaDataGrid(DGTamDescarga, DTamDesc.DataTable)
            DGTamDescarga_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        Try
            GBConfiguracion.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)

            BEditar.Enabled = False
            BBorrar.Enabled = False
            BNuevo.Enabled = False
            BActualizar.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)
            BActualizar_Click(Nothing, Nothing)

            BEditar.Enabled = True
            BBorrar.Enabled = True
            BNuevo.Enabled = True
            BActualizar.Enabled = True
            GBConfiguracion.Enabled = False

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
            GBConfiguracion.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            TamDescarga_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGTamDescarga_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTamDescarga.CellClick
        Try
            If DGTamDescarga.Rows.Count = 0 Then Exit Sub

            DTamDesc.Find("CODDESC=" + DGTamDescarga.Rows(DGTamDescarga.CurrentRow.Index).Cells("CODDESC").Value.ToString)
            If DTamDesc.Count = 0 Then Exit Sub

            TCodigo.Text = DTamDesc.RecordSet("CODDESC")
            TNombre.Text = DTamDesc.RecordSet("NOMBRE")
            TTamDescarga.Text = DTamDesc.RecordSet("TAMDESC")
            TAlimFina.Text = DTamDesc.RecordSet("AFINA")
            TTolSuperior.Text = DTamDesc.RecordSet("TOLSUP")
            TTolInferior.Text = DTamDesc.RecordSet("TOLINF")
            TTiempoSolt.Text = DTamDesc.RecordSet("TIEMPOSOLT")
            TVelDescarga.Text = DTamDesc.RecordSet("VDESC")
            TAlimFina2.Text = DTamDesc.RecordSet("AFINA2")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        Try
            If Val(TCodigo.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de descarga"), vbInformation)
                Return
            End If

            If TNombre.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre"), vbInformation)
                Return
            End If

            If Val(TTamDescarga.Text) <= 0 Then
                MsgBox("El Valor de descarga debe ser mayor a cero", vbInformation)
                Return
            End If

            If Val(TAlimFina.Text) > Val(TTamDescarga.Text) Then
                MsgBox("La Alimentación Fina debe ser menor al Tamaño de Descarga", vbInformation)
                Return
            End If

            If Val(TAlimFina2.Text) > Val(TTamDescarga.Text) Then
                MsgBox("La Alimentación Fina debe ser menor al Tamaño de Descarga", vbInformation)
                Return
            End If

            DTamDesc.Find("CODDESC=" + TCodigo.Text.Trim)
            If Not DTamDesc.EOF Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DTamDesc.AddNew()
            End If

            DTamDesc.RecordSet("CODDESC") = Val(TCodigo.Text)
            DTamDesc.RecordSet("NOMBRE") = CLeft(TNombre.Text, 30)
            DTamDesc.RecordSet("TAMDESC") = Val(TTamDescarga.Text)
            DTamDesc.RecordSet("AFINA") = Val(TAlimFina.Text)
            DTamDesc.RecordSet("TOLSUP") = Val(TTolSuperior.Text)
            DTamDesc.RecordSet("TOLINF") = Val(TTolInferior.Text)
            DTamDesc.RecordSet("TIEMPOSOLT") = Val(TTiempoSolt.Text)
            DTamDesc.RecordSet("VDESC") = Val(TVelDescarga.Text)
            DTamDesc.RecordSet("AFINA2") = Val(TAlimFina2.Text)

            DTamDesc.Update()
            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(sender As Object, e As EventArgs) Handles BBorrar.Click
        Try
            DTamDesc.Find("CODDESC=" + TCodigo.Text.Trim)
            If Not DTamDesc.EOF Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            End If

            DTamDesc.Delete("Delete from TamDesc Where CODDESC = " + TCodigo.Text.Trim, Me)
            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
End Class