Imports ClassLibrary
Public Class Silos

    Private DCSilos As AdoSQL
    Private DArt As AdoSQL
    Private DMovSilos As AdoSQL
    Private DVarios As AdoSQL
    Private Fila As Integer
    Private Campos() As String

    Private Sub Silos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DCSilos = New AdoSQL("DCSILOS")
            DArt = New AdoSQL("ARTICULOS")
            DMovSilos = New AdoSQL("MOVSILOS")
            DVarios = New AdoSQL("VARIOS")

            DCSilos.Open("select * from CSILOS order by CODSILO")
            DArt.Open("select * from ARTICULOS where TIPO='MP'")

            AsignaDataGrid(DGSilos, DCSilos.DataTable)
            If DGSilos.RowCount > 0 Then DGSilos_CellClick(Nothing, Nothing)
            'GBDatosSilos.Enabled = False
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)

            Campos = {"CodSilo@Cód.Silo", "NomSilo@Nom.Silo"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DCSilos.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            ChActivo.Checked = False
            'GBDatosSilos.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGSilos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSilos.CellClick
        Try
            If DGSilos.CurrentRow Is Nothing AndAlso DGSilos.Rows.Count = 0 Then Exit Sub

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            BAceptar.Enabled = False
            'GBDatosSilos.Enabled = False
            TCodSilo.Text = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("Codsilo").Value.ToString
            TSilo.Text = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("NomSilo").Value.ToString
            TCodMat.Text = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("CodMat").Value.ToString
            TNomMat.Text = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("NomMat").Value.ToString
            TInventIni.Text = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("INVINI").Value.ToString
            TConsumo.Text = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("Consumo").Value.ToString
            ChActivo.Checked = DGSilos.Rows(DGSilos.CurrentRow.Index).Cells("ACTIVO").Value

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BResetInvIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BResetInvIni.Click
        TInventIni.Text = 0
    End Sub

    Private Sub BResetCons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BResetCons.Click
        Try
            TConsumo.Text = 0
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If ChActivo.Checked Then
                DVarios.Open("select * from SILOS where ACTIVO=1 and CODMAT='" + TCodMat.Text + "' and " +
                               "CODSILO<>'" + TCodSilo.Text + "'")

                If DVarios.Count > 0 Then
                    RespInput = MsgBox("Hay otro silo Activo con el mismo producto, desea continuar ? ", vbYesNo + vbInformation)
                    If RespInput = vbNo Then Exit Sub
                End If
            End If

            DVarios.Open("Select * from SILOS where CODSILO='" + TCodSilo.Text + "'")
            If DVarios.Count = 0 Then Return
            DVarios.RecordSet("CODMAT") = TCodMat.Text
            DVarios.RecordSet("NOMMAT") = TNomMat.Text
            DVarios.RecordSet("INVINI") = Eval(TInventIni.Text) + Eval(TAdicion.Text)
            DVarios.RecordSet("ACTIVO") = ChActivo.Checked
            If Eval(TConsumo.Text) = 0 Then
                DVarios.RecordSet("CONSUMO") = 0
            End If


            DMovSilos.Open("Select * from MOVSILOS where CONT=0")
            DMovSilos.AddNew()
            DMovSilos.RecordSet("FECHAINI") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DMovSilos.RecordSet("CODSILO") = TCodSilo.Text
            DMovSilos.RecordSet("CODMAT") = TCodMat.Text
            DMovSilos.RecordSet("NOMMAT") = CLeft(TNomMat.Text, 30)
            DMovSilos.RecordSet("PESOREAL") = Eval(TAdicion.Text)
            DMovSilos.RecordSet("SALDO") = DVarios.RecordSet("INVINI") - DVarios.RecordSet("CONSUMO")
            If DMovSilos.RecordSet("SALDO") < 300 Then Alarma("Saldo en " + TSilo.Text + " por debajo de 300 tn")
            DMovSilos.Update(Me)
            DVarios.Update(Me)



            BCancelar_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            'If DRUsuario("ModInvSilos") Then
            If ValidaPermiso("Silos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            BAceptar.Enabled = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TConsumo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TConsumo.TextChanged
        Try
            TSaldo.Text = Format(Eval(TInventIni.Text) - Eval(TConsumo.Text), "# ###.##")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMat_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodMat.KeyUp
        Try
            If e.KeyCode = Keys.Enter And Eval(TCodMat.Text) <> 0 Then

                DArt.Find("CODINT='" + TCodMat.Text + "'")
                If DArt.EOF = False Then
                    TNomMat.Text = DArt.RecordSet("NOMBRE")
                Else
                    TNomMat.Text = "-"
                End If
            End If

            TInventIni.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodMat.TextChanged
        Try
            If Eval(TCodMat.Text) = 0 Then Return

            DArt.Find("CODINT='" + TCodMat.Text + "'")
            If DArt.EOF = False Then
                TNomMat.Text = DArt.RecordSet("NOMBRE")
            Else
                TNomMat.Text = "-"
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGSilos.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGSilos.Rows(Fila).Selected = True
            DGSilos.FirstDisplayedScrollingRowIndex = Fila
            DGSilos.CurrentCell = DGSilos(0, Fila)
            DGSilos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGSilos.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGSilos.Rows(Fila).Selected = True
            DGSilos.FirstDisplayedScrollingRowIndex = Fila
            DGSilos.CurrentCell = DGSilos(0, Fila)
            DGSilos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGSilos.Rows.Count = 0 Then Exit Sub
            Fila = DGSilos.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGSilos.Rows(Fila).Selected = True
            DGSilos.FirstDisplayedScrollingRowIndex = Fila
            DGSilos.CurrentCell = DGSilos(0, Fila)
            DGSilos_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGSilos.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGSilos.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGSilos.Rows(Fila).Selected = True
            DGSilos.FirstDisplayedScrollingRowIndex = Fila
            DGSilos.CurrentCell = DGSilos(0, Fila)
            DGSilos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            'Silos_Load(Nothing, Nothing)
            DCSilos.Open("select * from CSILOS order by CODSILO")
            DArt.Open("select * from ARTICULOS where TIPO='MP'")

            AsignaDataGrid(DGSilos, DCSilos.DataTable)
            If DGSilos.RowCount > 0 Then DGSilos_CellClick(Nothing, Nothing)
            'GBDatosSilos.Enabled = False
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                Silos_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGSilos, DCSilos.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGSilos_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodSilo_KeyUp(sender As Object, e As KeyEventArgs) Handles TCodSilo.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        TCodMat.Focus()
    End Sub

    Private Sub TInventIni_KeyUp(sender As Object, e As KeyEventArgs) Handles TInventIni.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        TAdicion.Focus()
    End Sub

    Private Sub TAdicion_KeyUp(sender As Object, e As KeyEventArgs) Handles TAdicion.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        ChActivo.Focus()
    End Sub

    Private Sub TActivo_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar.Focus()
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class