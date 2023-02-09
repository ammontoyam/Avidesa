Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data

Public Class RecPremezclas
    Private DConsumosMed As AdoSQL
    Private DUsuarios As AdoSQL
    Private DOPs As AdoSQL
    Private DUbicaciones As AdoSQL
    Private OPDestino As ArrayControles(Of RadioButton)
    Private Sentencia As String
    Private SentenciaSacos As String
    Private SentenciaPeso As String
    Private Fila As Integer
    Private Campos() As String
    Private FiltroPlanta As String
    Private FormLoad As Boolean

    Private Sub RecPremezclas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DConsumosMed = New AdoSQL("ConsumosMed")
            DUsuarios = New AdoSQL("Usuarios")
            DOPs = New AdoSQL("OPS")

            TFecha.Value = Now
            THora.Value = Now
            DUsuarios.Open("Select * from USUARIOS where EMPMOD=1")
            LLenaComboBox(CUsuario, DUsuarios.DataTable, "Usuario")

            FiltroPlanta = "Yar"

            'SentenciaSacos = "Sacos + SacosAjuste + SacosNC + Reproceso"
            'SentenciaPeso = "peso+pesoajuste+residuo+(SacosNC+Reproceso)*PresKg"
            FRefrescaDG_Click(Nothing, Nothing)

            Campos = {"OP@OP", "codfor@Código Fórmula", "NomFor@Nombre de Fórmula"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DConsumosMed.DataTable)

           

            If DGPrem.RowCount > 0 Then DGPrem_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGPrem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPrem.CellClick
        Dim Cont As String
        Try
            If DGPrem.CurrentRow Is Nothing Then Return
            If DGPrem.RowCount = 0 Then Return
            If e Is Nothing Then Return

            If DGPrem.Columns(e.ColumnIndex).Name.ToUpper.Contains("COLACEPTAR") Then
                DGPrem.ReadOnly = False
            Else
                DGPrem.ReadOnly = True
            End If

            Cont = DGPrem.Rows(DGPrem.CurrentRow.Index).Cells("CONT2").Value.ToString

            DConsumosMed.Find("CONT2=" + Cont.Trim)

            If DConsumosMed.EOF Then Exit Sub

            TOPs.Text = DConsumosMed.RecordSet("OP")
            TCodPrem.Text = DConsumosMed.RecordSet("CODPREMEZCLA")
            TNomFor.Text = DConsumosMed.RecordSet("NOMFOR")
            TPesoMeta.Text = DConsumosMed.RecordSet("PESOMETA")
            TFechaIni.Text = DConsumosMed.RecordSet("FECHA")
            TPesoReal.Text = DConsumosMed.RecordSet("PESOREAL")
            TFecha.Text = Format(Now.Date, "yyyy/MM/dd")
            THora.Text = Format(Now.ToLocalTime, "HH:mm:ss")




            'If CUsuario.Text = "-" Then
            '    CUsuario.Enabled = True
            'Else
            '    CUsuario.Enabled = False
            'End If
            TUsuarioRec.Text = UsuarioPrincipal   'DRUsuario("USUARIO").ToString

            'DOPs.Open("Select * from OPs where OP=" + TOPs.Text.Trim)

            'If DOPs.Count > 0 Then
            '    TObservCostos.Text = DOPs.RecordSet("ObservCostos")
            'End If

            mnLCuenta.Text = DGPrem.Rows.Count.ToString
            Fila = DGPrem.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPFilt_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyData <> Keys.Enter Then Return

            ''If Eval(TOPFilt.Text) = 0 Then Exit Sub

            'DEmpRecib.Open("Select " + SentenciaSacos + " AS SACOSTOT," + SentenciaPeso + " AS PESOTOT,* from EMPAQUE where RECCOSTOS=0 and RECEMP=1" + _
            '                 " and MAQUINA<>100 and CODPROD<>'99' and OP=" + TOPFilt.Text + " ORDER BY OP DESC")

            'AsignaDataGrid(DGEmpaque, DEmpRecib.DataTable)

            'If DEmpRecib.Count > 0 Then
            '    DGEmpaque_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
            'Else
            '    BCancelar_Click(Nothing, Nothing)
            'End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try

            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            ChAceptados.Checked = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Dim Cont As String = ""
        Dim Sacos As String = ""
        Dim CodProd As String = ""
        Dim OP As String = ""
        Dim Destino As String = ""
        Try
            If DGPrem.RowCount = 0 Then Return

            For Each Fila As DataGridViewRow In DGPrem.Rows

                If Fila.Cells("ColAceptar_NI_").Value = False Then Continue For

                Cont = Fila.Cells("CONT2").Value.ToString
                'Sacos = Fila.Cells("SACOSTOT").Value.ToString
                OP = Fila.Cells("OP").Value.ToString
                'Destino = Fila.Cells("DESTINO").Value.ToString

                DConsumosMed.Open("Update CONSUMOSMED set RECPREM=1,USUARIOREC='" + CLeft(TUsuarioRec.Text, 10) + "',FechaRec='" +
                                  Format(TFecha.Value, "yyyy/MM/dd") + " " + Format(THora.Value, "HH:mm") + "' where CONT2=" + Cont)



                'DOPs.Open("Select * from OPS where OP='" + OP + "'")

                'If DOPs.Count > 0 And TObservCostos.TextLength > 3 Then

                '    DOPs.RecordSet("ObservCostos") = CLeft(Replace(TObservCostos.Text, vbCrLf, " - "), 250)
                '    DOPs.Update()
                'End If

                Evento(" Bodega Recibe Premezclas  OP: " + OP + " contador: " + Cont)

            Next

            BCancelar_Click(Nothing, Nothing)
            FRefrescaDG_Click(Nothing, Nothing)
            DGPrem_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
            ChAceptarTodos.Checked = False
            ChAceptarSel.Checked = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGPrem.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGPrem.Rows(Fila).Selected = True
            DGPrem.FirstDisplayedScrollingRowIndex = Fila
            DGPrem.CurrentCell = DGPrem(0, Fila)
            DGPrem_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGPrem.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGPrem.Rows(Fila).Selected = True
            DGPrem.FirstDisplayedScrollingRowIndex = Fila
            DGPrem.CurrentCell = DGPrem(0, Fila)
            DGPrem_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGPrem.Rows.Count = 0 Then Exit Sub
            Fila = DGPrem.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGPrem.Rows(Fila).Selected = True
            DGPrem.FirstDisplayedScrollingRowIndex = Fila
            DGPrem.CurrentCell = DGPrem(0, Fila)
            DGPrem_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGPrem.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGPrem.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGPrem.Rows(Fila).Selected = True
            DGPrem.FirstDisplayedScrollingRowIndex = Fila
            DGPrem.CurrentCell = DGPrem(0, Fila)
            DGPrem_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        'RecEmpCostos_Load(Nothing, Nothing)
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub



    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try

            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO))
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                FRefrescaDG_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGPrem, DConsumosMed.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGPrem_CellClick(Nothing, Nothing)

            'TSumSacos.Text = SumColumn(DGPrem, "sacostot")

        Catch ex As Exception
            MsgError(ex)
        End Try


    End Sub

    Private Sub FRefrescaDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRefrescaDG.Click
        Try

            Sentencia = "Select * from CPREMXREC where PLANTA='" + FiltroPlanta + "' and FECHA>'" + Format(DateAdd(DateInterval.Day, -20, Now), "yyyy/MM/dd HH:mm") + "' order BY FECHA DESC"
            DConsumosMed.Open(Sentencia)
            AsignaDataGrid(DGPrem, DConsumosMed.DataTable)

            'TSumSacos.Text = SumColumn(DGPrem, "sacostot")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEmpaque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGPrem.KeyDown
        DGPrem_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGEmpaque_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGPrem.KeyUp
        DGPrem_CellClick(Nothing, Nothing)
    End Sub
    Private Sub ChAceptados_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChAceptados.CheckedChanged
        Try
            If ChAceptados.Checked Then

                For Each Fila As DataGridViewRow In DGPrem.Rows
                    If Fila.Cells("ColAceptar_NI_").Value Then
                    Else
                        DGPrem.Rows(Fila.Index).Visible = False
                    End If
                Next

                TSumSacos.Text = SumColumn(DGPrem, "SacosTot")
            Else
                FRefrescaDG_Click(Nothing, Nothing)
                DGPrem_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ChAceptarTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChAceptarTodos.CheckedChanged
        Try
            For Each Fila As DataGridViewRow In DGPrem.Rows
                Fila.Cells("ColAceptar_NI_").Value = ChAceptarTodos.Checked
            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ChAceptarSel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChAceptarSel.CheckedChanged
        For Each Fila As DataGridViewRow In DGPrem.Rows
            If Not Fila.Selected Then Continue For
            Fila.Cells("ColAceptar_NI_").Value = ChAceptarSel.Checked
        Next
    End Sub

    Private Sub OpPlantaYar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OpPlantaYar.CheckedChanged
        If FormLoad = False Then Return
        If OpPlantaYar.Checked = False Then Return
        FiltroPlanta = "YAR"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub OpPlantaSta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OpPlantaSta.CheckedChanged
        If FormLoad = False Then Return
        If OpPlantaSta.Checked = False Then Return
        FiltroPlanta = "STRO"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub OPPlantaGir_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OPPlantaGir.CheckedChanged
        If FormLoad = False Then Return
        If OPPlantaGir.Checked = False Then Return
        FiltroPlanta = "GIR"
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub
End Class
