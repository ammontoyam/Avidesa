Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class TablaEnsaque


    Private DEmpaque As AdoSQL
    Private DVarios As AdoSQL

    Private Campos() As String

    Private Sub TablaEnsaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DEmpaque = New AdoSQL("EMPAQUE")
            DVarios = New AdoSQL("VARIOS")

            DEmpaque.Open("Select * From EMPAQUE Order By CONT desc")
            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGEnsaque, DEmpaque.DataTable)

            'Busqueda general del formulario
            Campos = {"OP@OP", "NomProd@Nombre Prod.", "FechaIni@Fecha"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DEmpaque.DataTable)

            GBLinea1.Visible = False
            GBLinea2.Visible = False
            'GBTotales.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TBuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then Exit Sub


            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DEmpaque.DataTable) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub

            BusquedaDG(DGEnsaque, DEmpaque.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(sender As Object, e As EventArgs) Handles BBorrar.Click
        Try
            If ValidaPermiso("Empaque_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim contEmpaque As String = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("CONT").Value.ToString
            DEmpaque.Find("CONT=" + contEmpaque)
            If Not DEmpaque.EOF Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            End If

            DVarios.Open("select * from PRODTERM where CONTEMP=" + contEmpaque + " and TRANSMITIDOSAP = 'S'")

            If DVarios.Count Then
                RespInput = MsgBox("En Producto Terminado este registro aparece Transmitido a SAP, desea eliminar en ambas tablas de todas formas?", vbYesNo + vbInformation)
                If RespInput = vbNo Then Exit Sub
            End If

            DEmpaque.Delete("Delete from EMPAQUE Where CONT = " + contEmpaque, Me)
            DVarios.Delete("delete from PRODTERM where CONTEMP=" + contEmpaque, Me)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        Try
            TablaModEnsaque.TContador.Text = DEmpaque.RecordSet("CONT")
            TablaModEnsaque.ShowDialog()
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DEmpaque.Open("Select * From EMPAQUE Order By CONT desc")
            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGEnsaque, DEmpaque.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BFTotal_Click(sender As Object, e As EventArgs) Handles BFTotal.Click
        Try
            Dim filtro As String
            Dim Sentencia As String

            Sentencia = "select * from EMPAQUE where "
            filtro = ""
            If CBBuscar.Text = "OP" Then
                If Val(TBuscar.Text) > 0 Then
                    Sentencia = Sentencia + " OP= " + TBuscar.Text + " and "
                    filtro = "OP = " + TBuscar.Text + " and  "
                End If
            End If


            If RBGranelera.Checked Then
                Sentencia = Sentencia + " MAQUINA=1 order by CONT desc"
                filtro = filtro + "MAQUINA = 1"
            ElseIf RBEnsacadora.Checked Then
                Sentencia = Sentencia + " (MAQUINA=2 or MAQUINA = 21)  order by CONT desc"
                filtro = filtro + "(MAQUINA = 2 or MAQUINA = 21)"
            ElseIf RBGranelera2.Checked Then
                Sentencia = Sentencia + " MAQUINA=3 order by CONT desc"
                filtro = filtro + "MAQUINA = 3"
            ElseIf RBMolienda.Checked Then
                Sentencia = Sentencia + " MAQUINA=4 order by CONT desc"
                filtro = filtro + "MAQUINA = 4"
            ElseIf RBHarinas.Checked Then
                Sentencia = Sentencia + " MAQUINA=5 order by CONT desc"
                filtro = filtro + "MAQUINA = 5"
            ElseIf RBSoya.Checked Then
                Sentencia = Sentencia + " MAQUINA=6 order by CONT desc"
                filtro = filtro + "MAQUINA = 6"
            ElseIf RBLiquidos.Checked Then
                filtro = filtro + "MAQUINA = 8"
                If Val(CBDestino.Text) > 0 Then
                    Sentencia = Sentencia + " CODEMP = " + CBDestino.Text + " and "
                    filtro = filtro + " and CODEMP = " + CBDestino.Text
                End If
                Sentencia = Sentencia + " MAQUINA=8 order by CONT desc"

            ElseIf RBManual.Checked Then
                Sentencia = Sentencia + " MAQUINA=11 order by CONT desc"
                filtro = filtro + "MAQUINA = 11"
            ElseIf RBDosificado.Checked Then
                Sentencia = Sentencia + " (MAQUINA=7 or MAQUINA = 71) order by CONT desc"
                filtro = filtro + "(MAQUINA = 7 or MAQUINA = 71)"
            End If


            DEmpaque.Open(Sentencia)

            LGranel.Visible = False
            LEmpaque.Visible = False
            LGranel.Text = "Gr."
            LEmpaque.Text = "Emp."

            If RBDosificado.Checked Then
                LGranel.Visible = True
                LEmpaque.Visible = True
                LGranel1.Visible = True
                LEmpaque1.Visible = True
                LGranel2.Visible = True
                LEmpaque2.Visible = True

            End If

            TTotSacos.Text = 0
            TTotKg.Text = 0

            LGranel1.Text = "Granel"
            LGranel2.Text = "Granel"
            LEmpaque1.Text = "Empaque"
            LEmpaque2.Text = "Empaque"
            TTotSacos1.Text = 0
            TKg1.Text = 0
            TTotSacos2.Text = 0
            TKg2.Text = 0


            DVarios.Open("select round(sum(PESO),3) as TOTALKG, round(sum(SACOS + SACOSDEV),3) as TOTALSACOS from EMPAQUE where " + filtro)

            If Not IsDBNull(DVarios.RecordSet("TOTALSACOS")) Then
                TTotSacos.Text = Val(DVarios.RecordSet("TOTALSACOS"))
                TTotKg.Text = Format(Val(DVarios.RecordSet("TOTALKG")), "# ### ###.00")
            End If


            DVarios.Open("select round(sum(PESODEV),3) as TOTALKG from EMPAQUE where " + filtro + " and SACOS > 0")

            If Not IsDBNull(DVarios.RecordSet("TOTALKG")) Then
                TTotKg.Text = Format(Val(TTotKg.Text) + Val(DVarios.RecordSet("TOTALKG")), "# ### ###.00")
            End If


            DVarios.Open("select round(sum(PESO),3) as TOTALPESO, CODEMP from EMPAQUE where " + filtro + " group by CODEMP")

            If (DVarios.Count) AndAlso (Not IsDBNull(DVarios.RecordSet("TOTALPESO"))) Then

                For Each RecordSet In DVarios.Rows

                    If UCase(RecordSet("CODEMP")) = "GRANEL" Then
                        LGranel.Text = "Gr. " + Format(Math.Round(RecordSet("TOTALPESO"), 3), "# ### ###.00")
                    ElseIf UCase(DVarios.RecordSet("CODEMP")) = "EMPAQUE" Then
                        LEmpaque.Text = "Emp. " + Format(Math.Round(Val(RecordSet("TOTALPESO")), 3), "# ### ###.00")
                    End If

                Next
            End If

            If RBLiquidos.Checked = 0 Then CBDestino.Visible = False

            If RBEnsacadora.Checked = True OrElse RBDosificado.Checked = True Then

                DVarios.Open("select sum(PESO) as PESO, CODEMP, MAQUINA from EMPAQUE where " + filtro + " group by CODEMP, MAQUINA")

                If (DVarios.Count) AndAlso (Not IsDBNull(DVarios.RecordSet("PESO"))) Then
                    For Each RecordSet In DVarios.Rows
                        If UCase(RecordSet("CODEMP")) = "GRANEL" Then
                            If Val(RecordSet("MAQUINA")) = 7 Then
                                LGranel1.Text = "Gr. " + Format(Math.Round(Val(RecordSet("PESO")), 3), "# ### ###.00")
                            ElseIf Val(RecordSet("MAQUINA")) = 71 Then
                                LGranel2.Text = "Gr. " + Format(Math.Round(Val(RecordSet("PESO")), 3), "# ### ###.00")
                            End If

                        ElseIf UCase(RecordSet("CODEMP")) = "EMPAQUE" Then
                            If Val(RecordSet("MAQUINA")) = 7 Then
                                LEmpaque1.Text = "Emp. " + Format(Math.Round(Val(RecordSet("PESO")), 3), "# ### ###.00")

                            ElseIf Val(RecordSet("MAQUINA")) = 71 Then
                                LEmpaque2.Text = "Emp. " + Format(Math.Round(Val(RecordSet("PESO")), 3), "# ### ###.00")
                            End If
                        End If
                    Next
                End If


                DVarios.Open("select sum(PESO) as TOTALKG, sum(SACOS + SACOSDEV) as TOTALSACOS, MAQUINA from EMPAQUE where " + filtro + " group by MAQUINA")

                If (DVarios.Count) AndAlso (Not IsDBNull(DVarios.RecordSet("TOTALSACOS"))) Then
                    For Each RecordSet In DVarios.Rows
                        If Val(RecordSet("MAQUINA")) = 7 Then
                            TTotSacos1.Text = Val(RecordSet("TOTALSACOS"))
                            TKg1.Text = Format(Val(RecordSet("TOTALKG")), "# ### ###.00")
                        ElseIf Val(RecordSet("MAQUINA")) = 2 Then
                            TTotSacos1.Text = Val(RecordSet("TOTALSACOS"))
                            TKg1.Text = Format(Val(RecordSet("TOTALKG")), "# ### ###.00")
                            '
                        ElseIf Val(RecordSet("MAQUINA")) = 71 Then
                            TTotSacos2.Text = Val(RecordSet("TOTALSACOS"))
                            TKg2.Text = Format(Val(RecordSet("TOTALKG")), "# ### ###.00")
                        ElseIf Val(DVarios.RecordSet("MAQUINA")) = 21 Then
                            TTotSacos2.Text = Val(RecordSet("TOTALSACOS"))
                            TKg2.Text = Format(Val(RecordSet("TOTALKG")), "# ### ###.00")
                        End If
                    Next
                End If


                DVarios.Open("select sum(PESODEV) as TOTALKG, MAQUINA from EMPAQUE where " + filtro + " and SACOS > 0 group by MAQUINA")

                If (DVarios.Count) AndAlso (Not IsDBNull(DVarios.RecordSet("TOTALKG"))) Then
                    For Each RecordSet In DVarios.Rows
                        If Val(RecordSet("MAQUINA")) = 7 Then
                            If Not IsDBNull(RecordSet("TOTALKG")) Then
                                TKg1.Text = Format(Val(TKg1.Text) + Val(RecordSet("TOTALKG")), "# ### ###.00")
                            End If

                        ElseIf Val(RecordSet("MAQUINA")) = 2 Then
                            If Not IsDBNull(RecordSet("TOTALKG")) Then
                                TKg1.Text = Format(Val(TKg1.Text) + Val(RecordSet("TOTALKG")), "# ### ###.00")
                            End If

                        ElseIf Val(RecordSet("MAQUINA")) = 71 Then
                            If Not IsDBNull(RecordSet("TOTALKG")) Then
                                TKg2.Text = Format(Val(TKg2.Text) + Val(RecordSet("TOTALKG")), "# ### ###.00")
                            End If

                        ElseIf Val(RecordSet("MAQUINA")) = 21 Then
                            If Not IsDBNull(RecordSet("TOTALKG")) Then
                                TKg2.Text = Format(Val(TKg2.Text) + Val(RecordSet("TOTALKG")), "# ### ###.00")
                            End If

                        End If
                    Next
                End If

                If RBEnsacadora.Checked = True Then
                    GBLinea1.Text = "Ensacadora 1"
                    GBLinea2.Text = "Ensacadora 2"
                Else
                    GBLinea1.Text = "Dosificado 1"
                    GBLinea2.Text = "Dosificado 2"
                End If

                GBLinea1.Visible = True
                GBLinea2.Visible = True
            Else
                GBLinea1.Visible = False
                GBLinea2.Visible = False
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub RBGranelera_Click(sender As Object, e As EventArgs) Handles RBGranelera.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBGranelera2_Click(sender As Object, e As EventArgs) Handles RBGranelera2.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBEnsacadora_Click(sender As Object, e As EventArgs) Handles RBEnsacadora.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBMolienda_Click(sender As Object, e As EventArgs) Handles RBMolienda.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBDosificado_Click(sender As Object, e As EventArgs) Handles RBDosificado.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBHarinas_Click(sender As Object, e As EventArgs) Handles RBHarinas.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBSoya_Click(sender As Object, e As EventArgs) Handles RBSoya.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBManual_Click(sender As Object, e As EventArgs) Handles RBManual.Click
        BFTotal_Click(Nothing, Nothing)
    End Sub

    Private Sub RBLiquidos_Click(sender As Object, e As EventArgs) Handles RBLiquidos.Click
        CBDestino.Visible = True
    End Sub




    'Private Sub DGBasculas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEnsaque.CellClick
    '    Try
    '        If DGEnsaque.RowCount = 0 Then Exit Sub
    '        TBascula.ReadOnly = True
    '        TModo.ReadOnly = True
    '        TBascula.Text = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("bascula").Value.ToString
    '        ''CLinea.Text = DGBasculas.Rows(DGBasculas.CurrentRow.Index).Cells("Linea").Value.ToString
    '        TIncMin.Text = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("InclusionMin").Value.ToString
    '        TCapacidad.Text = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("Capac").Value.ToString
    '        TNombreSeccion.Text = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("NombreSeccion").Value.ToString
    '        ChImprimir.Checked = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("Imprimir").Value
    '        TModo.Text = DGEnsaque.Rows(DGEnsaque.CurrentRow.Index).Cells("A").Value.ToString

    '        Fila = DGEnsaque.CurrentRow.Index

    '    Catch ex As Exception
    '         MsgError(ex)
    '    End Try
    'End Sub

End Class