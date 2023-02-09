Option Explicit On
Imports System
Imports System.Data
Imports System.IO
Public Class Inventarios
    Private DArt As AdoSQL
    Private DUbic As AdoSQL
    Private DVarios As AdoSQL
    Private Fila As Int32
    Private InvTipo As TipoInv
    Private Campos() As String

    Public Sub BActInvUNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActInvUNO.Click
        Try
            Dim RutaArchUno As String = ""
            Dim Item As String
            'Dim Descripcion As String
            Dim Cantidad As String
            'Dim UnidadMed As String
            'Dim ValUnitario As String
            'Dim ValTotal As String
            'Dim Ubicacion As String
            Dim LecArch As StreamReader
            Dim Contenido As String
            Dim Renglon As String, Renglones() As String
            Dim Campos() As String
            ' Dim Pos As Int32
            Dim Invent As New DescInvent


            OpenFile.InitialDirectory = "C:\"
            OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                RutaArchUno = OpenFile.FileName
            End If

            If File.Exists(RutaArchUno) = False Then
                MsgBox(DevuelveEvento(CodEvento.ARCHIVO_NOEXISTE) + " ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show("No se encontro el archivo seleccionado", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If


            LecArch = File.OpenText(RutaArchUno)
            Contenido = LecArch.ReadToEnd
            LecArch.Close()

            Renglones = Contenido.Split(ControlChars.NewLine)

            'If Not Contenido.Contains("UNO - VER") AndAlso Not Contenido.Contains("ITALCOL") AndAlso Not Contenido.Contains("EXISTENCIAS EN CANTIDADES") Then
            '    MessageBox.Show("El archivo no tiene el formato de Importación", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Return
            'End If



            For i As Integer = 0 To Renglones.Length
                'If i = 0 Then Continue For
                Renglon = Renglones(i)

                If Renglon.Contains(Chr(34)) Then Renglon = Replace(Renglon, Chr(34), "")

                Campos = Split(Renglon.Trim, Chr(32))
                Item = Campos(0)

                'Si el item es carbon tehn
                If Item.Contains("INOM") Then Continue For


                'Modificacion para validar si archivo tiene configuración regional invertida '.' - Separador de miles; ',' - separador decimal
                ' Se confirma en traa posición de '.' menor que la posición de ',' para remmplazarla
                If InStr(Campos(1).Trim, ".") > 0 And InStr(Campos(1).Trim, ".") < InStr(Campos(1).Trim, ",") Then
                    Campos(1) = Replace(Campos(1), ".", "")
                End If

                'Se confirma que posición de ',' es como simbolo separador decimal, máximo se manejan hasta 3 dígitos
                If Len(Campos(1).Trim) - InStr(Campos(1).Trim, ",") <= 3 Then
                    Campos(1) = Replace(Campos(1), ",", ".")
                End If

                ' Se obtiene la cantidad de inventario sin tener en cuenta la ',' como separador de miles, en caso de que el valor lo tenga así asignado
                Cantidad = Val(Replace(Campos(1), ",", ""))

                If InStr(Renglon, "Gran total") > 0 Then
                    MsgBox("Fin de Archivo OK", vbInformation)
                    Exit For
                End If

                'Inventario(Item, Cantidad, TipoInv.UNO, "-", DetOperacion.LEEINVENTARIO, , , , , , , , Usuario)

                With Invent
                    .CodInt = Item
                    .Cantidad = Cantidad
                    .TipoInv = DescInvent.TipoInvent.UNO
                    .Detalle = DescInvent.DetOperacion.LEEINVENTARIO
                    .Usuario = UsuarioPrincipal
                    .Inventario()
                End With

            Next

            Inventarios_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub Inventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            DArt = New AdoSQL("ARTICULOS")
            DUbic = New AdoSQL("UBICACIONES")
            DVarios = New AdoSQL("VARIOS")

            DArt.Open("select * from ARTICULOS order by CODINT")
            DUbic.Open("Select * from UBICACIONES order by CODUBI")


            AsignaDataGrid(DGInv, DArt.DataTable)
            If DGInv.RowCount > 0 Then DGInv_CellClick(Nothing, Nothing)

            'Llenamos el combobox ubicaciones
            LLenaComboBox(CUbicacion, DUbic.DataTable, "CODUBI")

            Campos = {"CodInt@Cód.Int.", "Tipo@Tipo", "Nombre@Nombre", "Bascula@Báscula", "A@Modo", "TipoMat@TipoMat"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DArt.DataTable)
            Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            MsgError(ex)
            Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub DGInv_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGInv.CellFormatting
        Try
            If DGInv.Columns(e.ColumnIndex).Name = "Tipo" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)

                    Select Case valor
                        Case "MP"
                            DGInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Cornsilk
                        Case "PT"
                            DGInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightCoral
                        Case "ET"
                            DGInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightCyan
                        Case "EM"
                            DGInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightBlue
                    End Select

                    'If (valor <> "-") Then
                    '    DGInv.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                    '    ' DGSoliCargue.RowsDefaultCellStyle.BackColor = Color.Yellow
                    '    ' e.CellStyle.BackColor = Color.Yellow
                    'End If
                End If
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub




    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGInv.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGInv.Rows(Fila).Selected = True
            DGInv.FirstDisplayedScrollingRowIndex = Fila
            DGInv.CurrentCell = DGInv(0, Fila)
            DGInv_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGInv.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGInv.Rows(Fila).Selected = True
            DGInv.FirstDisplayedScrollingRowIndex = Fila
            DGInv.CurrentCell = DGInv(0, Fila)
            DGInv_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGInv.Rows.Count = 0 Then Exit Sub
            Fila = DGInv.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGInv.Rows(Fila).Selected = True
            DGInv.FirstDisplayedScrollingRowIndex = Fila
            DGInv.CurrentCell = DGInv(0, Fila)
            DGInv_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGInv.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGInv.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGInv.Rows(Fila).Selected = True
            DGInv.FirstDisplayedScrollingRowIndex = Fila
            DGInv.CurrentCell = DGInv(0, Fila)
            DGInv_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            Inventarios_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGInv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGInv.CellClick
        Try
            If DGInv.CurrentRow Is Nothing Then Return
            If DGInv.Rows.Count = 0 Then Exit Sub
            mnLCuenta.Text = DGInv.Rows.Count.ToString
            Fila = DGInv.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGInv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGInv.KeyUp
        DGInv_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGInv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGInv.KeyDown
        DGInv_CellClick(Nothing, Nothing)
    End Sub



    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp, CBBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                'MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                BActualizar_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DArt.DataTable) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub

            If TipoCampo(Campos(x), DArt.DataTable) <> "String" Then
                BusquedaDGContains(DGInv, Campos(x), TBuscar.Text, Hallado)
            Else
                BusquedaDG(DGInv, DArt.DataTable, TBuscar.Text, Campos(x), Hallado)
            End If
            'BusquedaDGContains(DGInv, Campos(x), TBuscar.Text, Hallado)
            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            'DGInv_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub OPMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPMP.Click
        Try
            CBBuscar.Text = "Tipo"
            TBuscar.Text = "MP"
            TBuscar_KeyUp(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPPT.Click
        Try
            'BActualizar_Click(Nothing, Nothing)
            CBBuscar.Text = "Tipo"
            TBuscar.Text = "PT"
            TBuscar_KeyUp(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPEmpaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPEmpaque.Click
        Try
            'BActualizar_Click(Nothing, Nothing)
            CBBuscar.Text = "Tipo"
            TBuscar.Text = "EM"
            TBuscar_KeyUp(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPEtiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPEtiquetas.Click
        Try
            'BActualizar_Click(Nothing, Nothing)
            CBBuscar.Text = "Tipo"
            TBuscar.Text = "ET"
            TBuscar_KeyUp(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTodos.Click
        Try
            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub TEntra_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEntra.Enter
        TEntra.Text = ""
        TEntra.ReadOnly = False
        TSale.ReadOnly = True
    End Sub

    Private Sub TSale_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSale.Enter
        TSale.Text = ""
        TSale.ReadOnly = False
        TEntra.ReadOnly = True
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim Cantidad As Double
            Dim Unidades As Integer
            Dim TipoMat As String
            Dim Observaciones As String

            If TCodInt.Text = "" Then Return

            If Eval(TEntra.Text) > 0 And Eval(TSale.Text) > 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " realizar un ajuste con las 2 cantidades", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' MsgBox("No puede realizar un ajuste con las 2 cantidades", vbInformation)
                Return
            End If

            TipoMat = DGInv.Rows(DGInv.CurrentRow.Index).Cells("TIPO").Value.ToString

            If Eval(TEntra.Text) > 0 Then
                Cantidad = Eval(TEntra.Text)
            End If

            If Eval(TSale.Text) > 0 Then
                Cantidad = -Eval(TSale.Text)
            End If

            If Cantidad = 0 Then Return


            Unidades = 0

            If InvTipo = TipoInv.FISICO And TipoMat = "PT" Then
                DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodInt.Text + "'")
                If DVarios.Count > 0 Then
                    If DVarios.RecordSet("PRESKG") And Not IsDBNull(DVarios.RecordSet("PRESKG")) > 0 Then Unidades = Cantidad / DVarios.RecordSet("PRESKG")
                End If
            End If

            If TObservaciones.TextLength > 0 Then
                Observaciones = TObservaciones.Text
            Else
                Observaciones = "Ajuste de inventario " + InvTipo.ToString
            End If

            Inventario(TCodInt.Text, Cantidad, InvTipo, TLote.Text, DetOperacion.AJUSTEINVENTARIO, CUbicacion.Text, , Unidades, , , Observaciones, , UsuarioPrincipal)
            GBAjustes.Visible = False
            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO))

            BCancelar_Click(Nothing, Nothing)

            Inventarios_Load(Nothing, Nothing)

            OPTodos_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub mnInvChronos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnInvChronos.Click
        Try
            Resp = MsgBox(DevuelveEvento(CodEvento.FUNCION_AJUSTES) + " el inventario ChronoSoft", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
            'Resp = MsgBox("¿Está seguro de realizar un ajuste en el inventario ChronoSoft?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
            If Resp = vbNo Then Return
            InvTipo = TipoInv.CHRONOS
            TCodInt.Text = DGInv.Rows(DGInv.CurrentRow.Index).Cells("CODINT").Value.ToString
            GBAjustes.Location = New Point(470, 209)
            GBAjustes.Visible = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnInvFisico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnInvFisico.Click
        Try
            Resp = MsgBox(DevuelveEvento(CodEvento.FUNCION_AJUSTES) + " el inventario ChronoSoft", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
            'Resp = MsgBox("¿Está seguro de realizar un ajuste en el inventario físico?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
            If Resp = vbNo Then Return
            InvTipo = TipoInv.FISICO
            GBAjustes.Location = New Point(590, 209)
            TCodInt.Text = DGInv.Rows(DGInv.CurrentRow.Index).Cells("CODINT").Value.ToString
            GBAjustes.Visible = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            TEntra.Text = ""
            TSale.Text = ""
            CUbicacion.Text = ""
            TObservaciones.Text = ""
            TLote.Text = ""
            GBAjustes.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OPAditivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPAditivos.Click
        Try
            'BActualizar_Click(Nothing, Nothing)
            CBBuscar.Text = "TipoMat"
            TBuscar.Text = "6"
            TBuscar_KeyUp(Nothing, New System.Windows.Forms.KeyEventArgs(Keys.Enter))
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OPLiquidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPLiquidos.Click
        Try
            'BActualizar_Click(Nothing, Nothing)
            CBBuscar.Text = "TipoMat"
            TBuscar.Text = "4"
            TBuscar_KeyUp(Nothing, New System.Windows.Forms.KeyEventArgs(Keys.Enter))
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPPrem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPPrem.Click
        Try
            'BActualizar_Click(Nothing, Nothing)
            CBBuscar.Text = "TipoMat"
            TBuscar.Text = "7"
            TBuscar_KeyUp(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAjustarInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAjustarInv.Click
        Try

            'If DRUsuario("InvAjuste") Then
            If ValidaPermiso("InventarioAjuste_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO))
                'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If
            AjustesInv.ShowDialog()

            BActualizar_Click(Nothing, Nothing)

            'RespInput = ""
            'InputBox.InputBox("Ajuste de Inventario", "Ingrese el tipo de inventario para realizar ajuste 1.ChronoSoft 2.Físico", RespInput)

            'If Eval(RespInput) < 1 Or Eval(RespInput) > 2 Then
            '    MsgBox("Respuesta no válida", vbInformation)
            '    Return
            'End If

            'If Eval(RespInput) = 1 Then
            '    mnInvChronos_Click(Nothing, Nothing)
            'Else
            '    mnInvFisico_Click(Nothing, Nothing)
            'End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Class