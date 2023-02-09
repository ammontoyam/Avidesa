Option Explicit On


Public Class TablaLineasProd

    Private DLineasProd As AdoSQL
    Private Fila As Integer
    Private Sub TablaLineasProd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            DLineasProd = New AdoSQL("LINEASPROD")

            DLineasProd.Open("Select * from LINEASPROD order by tipo")
            AsignaDataGrid(DGLineasProd, DLineasProd.DataTable)
            DGLineasProd.Enabled = True
            'If DGLineasProd.Rows.Count > 0 Then DGLineasProd_CellClick(Nothing, Nothing)

            GBDatosDesc.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGLineasProd_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGLineasProd.CellClick
        Try

            If DGLineasProd.RowCount = 0 Then Return

            TLineaProd.Text = DGLineasProd.Rows(e.RowIndex).Cells("LINEA").Value.ToString
            CTipo.Text = DGLineasProd.Rows(e.RowIndex).Cells("TIPO").Value.ToString
            TDescripcion.Text = DGLineasProd.Rows(e.RowIndex).Cells("DESCRIPCION").Value.ToString
            TKgxHzPelet1.Text = DGLineasProd.Rows(e.RowIndex).Cells("KgxHzPelet1").Value.ToString
            TKgxHzPelet2.Text = DGLineasProd.Rows(e.RowIndex).Cells("KgxHzPelet2").Value.ToString
            TKgxHzPelet3.Text = DGLineasProd.Rows(e.RowIndex).Cells("KgxHzPelet3").Value.ToString
            TPresionMin.Text = DGLineasProd.Rows(e.RowIndex).Cells("PresionMin").Value.ToString
            TPresionMax.Text = DGLineasProd.Rows(e.RowIndex).Cells("PresionMax").Value.ToString
            TTempMax.Text = DGLineasProd.Rows(e.RowIndex).Cells("TempMax").Value.ToString
            TTempMin.Text = DGLineasProd.Rows(e.RowIndex).Cells("TempMin").Value.ToString
            '' ChManejaPx.Checked = DGLineasProd.Rows(e.RowIndex).Cells("ManejaPx").Value
            TPorcMerma.Text = DGLineasProd.Rows(e.RowIndex).Cells("PorcMerma").Value.ToString
            TDiasVenc.Text = DGLineasProd.Rows(e.RowIndex).Cells("DiasVenc").Value
            ChLineaExterna.Checked = DGLineasProd.Rows(e.RowIndex).Cells("LineaExterna").Value
            CBPresent.Text = DGLineasProd.Rows(e.RowIndex).Cells("Present").Value
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BCancelar.Click
        Try

            Limpiar_Habilitar_TextBox(Panel1.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Panel1.Controls, AccionTextBox.Deshabilitar)

            CTipo.Enabled = False
            CTipo.Text = ""
            DGLineasProd.Enabled = True
            ChLineaExterna.Checked = False
            CBPresent.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BNuevo.Click
        Try
            Limpiar_Habilitar_TextBox(Panel1.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Panel1.Controls, AccionTextBox.Habilitar)
            DGLineasProd.Enabled = False
            CTipo.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BAceptar.Click
        Try

            If TLineaProd.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "línea", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Nombre incorrecto para la línea de planta", vbInformation)
                Return
            End If


            If CTipo.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "tipo de Línea", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Debe seleccionar un tipo para la línea de planta", vbInformation)
                Return
            End If
            If CTipo.Text = "PT" And Val(TDiasVenc.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "debe ingresar los dias de vencimiento para la línea de producto terminado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Debe ingresar los dias de vencimiento para la línea de producto terminado", vbInformation)
                Return
            End If

            DLineasProd.Open("Select * from LINEASPROD where LINEA='" + TLineaProd.Text + "' and TIPO='" + CTipo.Text + "'")

            If DLineasProd.Count > 0 Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                'Resp = MsgBox("La línea de planta ya existe, ¿desea modificar los datos?", vbInformation + MsgBoxStyle.YesNo)
                If Resp = vbNo Then Return
            Else
                DLineasProd.AddNew()
            End If

            DLineasProd.RecordSet("LINEA") = TLineaProd.Text
            DLineasProd.RecordSet("TIPO") = CTipo.Text
            DLineasProd.RecordSet("DESCRIPCION") = TLineaProd.Text
            DLineasProd.RecordSet("KgxHzPelet1") = Eval(TKgxHzPelet1.Text)
            DLineasProd.RecordSet("KgxHzPelet2") = Eval(TKgxHzPelet2.Text)
            DLineasProd.RecordSet("KgxHzPelet3") = Eval(TKgxHzPelet3.Text)
            DLineasProd.RecordSet("PresionMin") = Eval(TPresionMin.Text)
            DLineasProd.RecordSet("PresionMax") = Eval(TPresionMax.Text)
            DLineasProd.RecordSet("TempMax") = Eval(TTempMax.Text)
            DLineasProd.RecordSet("TempMin") = Eval(TTempMin.Text)
            ''DLineasProd.RecordSet("ManejaPx") = ChManejaPx.Checked
            DLineasProd.RecordSet("PorcMerma") = Eval(TPorcMerma.Text)
            DLineasProd.RecordSet("DiasVenc") = Eval(TDiasVenc.Text)
            DLineasProd.RecordSet("LineaExterna") = ChLineaExterna.Checked
            DLineasProd.RecordSet("Present") = CBPresent.Text
            DLineasProd.Update(Me)

            BCancelar_Click(Nothing, Nothing)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(sender As System.Object, e As System.EventArgs) Handles BBorrar.Click
        Try

            If DGLineasProd.RowCount = 0 Then Return
            If TLineaProd.Text = "" Then Return

            DGLineasProd.Enabled = False
            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR) + "línea de planta", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If Resp = vbNo Then Return

            DLineasProd.Delete("Delete from LINEASPROD where LINEA='" + TLineaProd.Text + "'", Me)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(sender As System.Object, e As System.EventArgs) Handles BActualizar.Click
        Try
            TablaLineasProd_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CTipo.SelectedIndexChanged
        Try
            ChLineaExterna.Enabled = False
            If CTipo.Text = "PT" Then
                GBDatosDesc.Visible = True
                GBPresent.Visible = True
                GBLimPelets.Visible = True
                GBDatosCortes.Visible = False
                ChLineaExterna.Enabled = True
                ChLineaExterna.Visible = True
            ElseIf CTipo.Text = "MP" Then
                GBDatosCortes.Visible = True
            Else
                GBDatosDesc.Visible = False
                GBLimPelets.Visible = False
                GBDatosCortes.Visible = False
                GBPresent.Visible = False
                ChLineaExterna.Visible = False
            End If



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(sender As System.Object, e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub mnSalir_Click(sender As System.Object, e As System.EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        If DGLineasProd.RowCount = 0 Then Return
        Fila = DGLineasProd.RowCount - 1
        mnTCuenta.Text = (Fila + 1).ToString()
        DGLineasProd.Rows(Fila).Selected = True
        DGLineasProd.FirstDisplayedScrollingRowIndex = Fila
        DGLineasProd.CurrentCell = DGLineasProd(0, Fila)

        DGLineasProd_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Dim indifila As Integer = 0
        If DGLineasProd.RowCount = 0 Then Return
        indifila = DGLineasProd.RowCount - 1
        Fila += 1
        If Fila > indifila Then Fila = indifila
        mnTCuenta.Text = (Fila + 1).ToString()
        DGLineasProd.Rows(Fila).Selected = True
        DGLineasProd.FirstDisplayedScrollingRowIndex = Fila
        DGLineasProd.CurrentCell = DGLineasProd(0, Fila)
        DGLineasProd_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click
        If DGLineasProd.RowCount = 0 Then Return
        Fila -= 1
        If Fila < 0 Then Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGLineasProd.Rows(Fila).Selected = True
        DGLineasProd.FirstDisplayedScrollingRowIndex = Fila
        DGLineasProd.CurrentCell = DGLineasProd(0, Fila)
        DGLineasProd_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        If DGLineasProd.RowCount = 0 Then Return
        Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGLineasProd.Rows(Fila).Selected = True
        DGLineasProd.FirstDisplayedScrollingRowIndex = Fila
        DGLineasProd.CurrentCell = DGLineasProd(0, Fila)
        DGLineasProd_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BEditar_Click(sender As System.Object, e As System.EventArgs) Handles BEditar.Click
        Try
            Limpiar_Habilitar_TextBox(Panel1.Controls, AccionTextBox.Habilitar)
            TLineaProd.ReadOnly = True
            CTipo.Enabled = False
            DGLineasProd.Enabled = False
            CBPresent.Enabled = True
            CTipo.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub
End Class

