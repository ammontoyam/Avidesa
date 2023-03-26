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

            'If DGEnsaque.Rows.Count > 0 Then DGBasculas_CellClick(Nothing, Nothing)

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

            If TBuscar.Text = "" Then
                'FRefrescaDG_Click(Nothing, Nothing)
                Exit Sub
            End If

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

            'TGranel.Visible = False
            'TEmpaque.Visible = False
            'TGranel = "Gr."
            'TEmpaque = "Emp."
            If RBDosificado.Checked Then
                GBLinea1.visible = True
                GBLinea1.Visible = True
            End If

            TTotSacosL1.Text = 0
            TKgL1.Text = 0

            'TGranel1.Caption = "Granel"
            'TGranel2.Caption = "Granel"
            'TEmpaque1.Caption = "Empaque"
            'TEmpaque2.Caption = "Empaque"
            'TTotSacos1 = 0
            'TKg1 = 0
            'TTotSacos2 = 0
            'TKg2 = 0


            DVarios.Open("select round(sum(Peso),3) as TotalKg, round(sum(Sacos + SacosDev),3) as TotalSacos from EMPAQUE where " + filtro)

            If DVarios.EOF = False Then
                TTotSacos.Text = Val(DVarios.RecordSet("TOTALSACOS"))
                TTotKg.Text = Format(Val(DVarios.RecordSet("TOTALKG")), "# ### ###.00") 'TKg = Val(DVarios!TotalKg)
            End If


            DVarios.Open("select round(sum(PesoDev),3) as TotalKg from EMPAQUE where " + filtro + " and sacos > 0")

            If DVarios.EOF = False Then
                If Not IsDBNull(DVarios.RecordSet("TOTALKG")) Then TTotKg.Text = Format(Val(TTotKg.Text) + Val(DVarios.RecordSet("TOTALKG")), "# ### ###.00") 'TKg = Val(DVarios!TotalKg)
            End If


            DVarios.Open("select round(sum(Peso),3) as Peso, CODEMP from EMPAQUE where " + filtro + " group by CODEMP")

            '        If DVarios.EOF = False Then
            '            Do While Not DVarios.EOF
            '                If UCase(DVarios.RecordSet("CODEMP")) = "GRANEL" Then
            '                    TGranel.Caption = "Gr. " + Format(Round((DVarios!Peso), 3), "# ### ###.00")
            '                ElseIf UCase(DVarios!CodEmp) = "EMPAQUE" Then
            '                    TEmpaque.Caption = "Emp. " + Format(Round(Val(DVarios!Peso), 3), "# ### ###.00")
            '                End If
            '                DVarios.MoveNext
            '            Loop
            '        End If

            '        If OPLiq.Value = 0 Then TDest.Visible = False

            '        If OPMaq2 = True Or OPDosificado = True Then

            '            If DVarios.State Then DVarios.Close
            '            DVarios.Open "select sum(Peso) as Peso, CODEMP, MAQUINA from EMPAQUE where " + filtro + " group by CODEMP, MAQUINA"

            'If DVarios.EOF = False Then
            '                Do While Not DVarios.EOF
            '                    If UCase(DVarios!CodEmp) = "GRANEL" Then
            '                        If Val(DVarios!Maquina) = 7 Then TGranel1.Caption = "Gr. " + Format(Round(Val(DVarios!Peso), 3), "# ### ###.00")
            '                        If Val(DVarios!Maquina) = 71 Then TGranel2.Caption = "Gr. " + Format(Round(Val(DVarios!Peso), 3), "# ### ###.00")
            '                    ElseIf UCase(DVarios!CodEmp) = "EMPAQUE" Then
            '                        If Val(DVarios!Maquina) = 7 Then TEmpaque1.Caption = "Emp. " + Format(Round(Val(DVarios!Peso), 3), "# ### ###.00")
            '                        If Val(DVarios!Maquina) = 71 Then TEmpaque2.Caption = "Emp. " + Format(Round(Val(DVarios!Peso), 3), "# ### ###.00")
            '                    End If
            '                    DVarios.MoveNext
            '                Loop
            '            End If


            '            If DVarios.State Then DVarios.Close
            '            DVarios.Open "select sum(peso) as TotalKg, sum(sacos + sacosdev) as TotalSacos, maquina from EMPAQUE where " + filtro + " group by maquina"

            'Do While DVarios.EOF = False
            '                If DVarios.EOF = False Then
            '                    If Val(DVarios!Maquina) = 7 Then
            '                        TTotSacos1 = Val(DVarios!TotalSacos)
            '                        TKg1 = Format(Val(DVarios!totalkg), "# ### ###.00")
            '                    ElseIf Val(DVarios!Maquina) = 2 Then
            '                        TTotSacos1 = Val(DVarios!TotalSacos)
            '                        TKg1 = Format(Val(DVarios!totalkg), "# ### ###.00")
            '                    End If
            '                    If Val(DVarios!Maquina) = 71 Then
            '                        TTotSacos2 = Val(DVarios!TotalSacos)
            '                        TKg2 = Format(Val(DVarios!totalkg), "# ### ###.00")
            '                    ElseIf Val(DVarios!Maquina) = 21 Then
            '                        TTotSacos2 = Val(DVarios!TotalSacos)
            '                        TKg2 = Format(Val(DVarios!totalkg), "# ### ###.00")
            '                    End If
            '                End If
            '                DVarios.MoveNext
            '            Loop

            '            If DVarios.State Then DVarios.Close
            '            DVarios.Open "select sum(PesoDev) as TotalKg, maquina from EMPAQUE where " + filtro + " and sacos > 0 group by maquina"

            'Do While DVarios.EOF = False
            '                If DVarios.EOF = False Then
            '                    If Val(DVarios!Maquina) = 7 Then
            '                        If Not IsNull(DVarios!totalkg) Then TKg1 = Format(Val(TKg1) + Val(DVarios!totalkg), "# ### ###.00")
            '                    ElseIf Val(DVarios!Maquina) = 2 Then
            '                        If Not IsNull(DVarios!totalkg) Then TKg1 = Format(Val(TKg1) + Val(DVarios!totalkg), "# ### ###.00")
            '                    End If
            '                    If Val(DVarios!Maquina) = 71 Then
            '                        If Not IsNull(DVarios!totalkg) Then TKg2 = Format(Val(TKg2) + Val(DVarios!totalkg), "# ### ###.00")
            '                    ElseIf Val(DVarios!Maquina) = 21 Then
            '                        If Not IsNull(DVarios!totalkg) Then TKg2 = Format(Val(TKg2) + Val(DVarios!totalkg), "# ### ###.00")
            '                    End If
            '                End If
            '                DVarios.MoveNext
            '            Loop

            '            '
            '            If OPMaq2 = True Then
            '                FrLinea1.Caption = "Ensacadora 1"
            '                FrLinea2.Caption = "Ensacadora 2"
            '            Else
            '                FrLinea1.Caption = "Dosificado 1"
            '                FrLinea2.Caption = "Dosificado 2"
            '            End If

            '            FrLinea1.Visible = True
            '            FrLinea2.Visible = True
            '        Else
            '            FrLinea1.Visible = False
            '            FrLinea2.Visible = False
            '        End If


        Catch ex As Exception
            MsgError(ex)
        End Try
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