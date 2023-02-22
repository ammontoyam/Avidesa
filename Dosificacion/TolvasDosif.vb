Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data

Public Class TolvasDosif
    Private DTolvas As AdoNet
    Private DArt As AdoNet
    Private Fila As Integer
    Private Campos() As String
    Private Proceso As String = "DOSIFICACION"
    Private Sub Tolvas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DTolvas = New AdoNet("Tolvas", CONN, DbProvedor)
            DArt = New AdoNet("ARTICULOS", CONN, DbProvedor)

            DTolvas.Open("select * from TOLVASDOSIF  order by TOLVA")
            DArt.Open("select * from MATPESADOS  order by NOMMATB")

            AsignaDataGrid(DGTolvas, DTolvas.DataTable)
            AsignaDataGrid(DGMateriales, DArt.DataTable, True)
            FrConstantes.Enabled = False
            TextNum(TTolva)
            TCodInt.Enabled = False
            FrActiva.Enabled = False
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            DGTolvas_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))

            Campos = {"Nombre@NombreMaterial", "Nomtolva@NombreTolva"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DTolvas.DataTable)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub DGTolvas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTolvas.CellClick
        Dim Tv As String
        Try
            If DGTolvas.CurrentRow Is Nothing Then Return
            If DGTolvas.RowCount = 0 Then Return

            Tv = DGTolvas.Rows(DGTolvas.CurrentRow.Index).Cells("TOLVA").Value.ToString

            DTolvas.Find("TOLVA=" + Tv)

            If DTolvas.EOF = True Then Return

            TTolva.Text = DTolvas.RecordSet("TOLVA")
            TCodInt.Text = DTolvas.RecordSet("CODINT")
            TNombre.Text = DTolvas.RecordSet("Nombre")
            TTotal.Text = Format(DTolvas.RecordSet("TOTAL"), "# ###")
            TAlarma.Text = Format(DTolvas.RecordSet("Alarma"), "# ###")
            TDesc.Text = DTolvas.RecordSet("TAMDESC")
            TCapacidad.Text = DTolvas.RecordSet("Capacidad")
            TJogs.Text = DTolvas.RecordSet("JOGSMAX")
            TJogTime.Text = DTolvas.RecordSet("JogTime")
            TAFina.Text = DTolvas.RecordSet("AFina")
            TVelFina.Text = DTolvas.RecordSet("VelFina")
            TVelGruesa.Text = DTolvas.RecordSet("VelGruesa")
            TTolInf.Text = DTolvas.RecordSet("TolInf")
            TTolSup.Text = DTolvas.RecordSet("TolSup")
            TCompens.Text = DTolvas.RecordSet("Compens")
            TNomTolva.Text = DTolvas.RecordSet("NomTolva")

            If DTolvas.RecordSet("CompensAuto") = "X" Then
                OpCompensAuto.Checked = True
                OpCompensManual.Checked = False
            Else
                OpCompensAuto.Checked = False
                OpCompensManual.Checked = True
            End If

            If DTolvas.RecordSet("Activa") = "X" Then
                OpTvHabil.Checked = True
                OpTvDesHab.Checked = False
            Else
                OpTvHabil.Checked = False
                OpTvDesHab.Checked = True
            End If

            Fila = DGTolvas.CurrentRow.Index
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub DGMateriales_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMateriales.CellClick
        Dim Mat As String
        Try
            If DGMateriales.RowCount = 0 Then Return

            Mat = DGMateriales.Rows(DGMateriales.CurrentRow.Index).Cells("DGMateriales_CodMat").Value.ToString

            DArt.Find("CODMAT='" + Mat + "'")

            If DArt.EOF Then Return

            TCodInt.Text = DArt.RecordSet("CODMAT")
            TNombre.Text = DArt.RecordSet("NOMMAT")

            DGMateriales.Visible = False

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
        DGMateriales.Visible = False
        DGTolvas.Enabled = True
        Tolvas_Load(Nothing, Nothing)
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try


            DTolvas.Find("TOLVA=" + TTolva.Text)
            If DTolvas.EOF = False Then
                'Resp = MessageBox.Show("La tolva ya existe ¿desea sobre escribirla?", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                'If Resp = vbNo Then Exit Sub
            Else
                Return
            End If

            DTolvas.RecordSet("TOLVA") = TTolva.Text
            DTolvas.RecordSet("CodInt") = TCodInt.Text
            DTolvas.RecordSet("Nombre") = TNombre.Text
            DTolvas.RecordSet("TOTAL") = Eval(TTotal.Text) + Eval(TAdicion.Text)
            DTolvas.RecordSet("Alarma") = Eval(TAlarma.Text)
            DTolvas.RecordSet("TAMDESC") = Eval(TDesc.Text)
            DTolvas.RecordSet("CAPACIDAD") = Eval(TCapacidad.Text)
            DTolvas.RecordSet("NOMTOLVA") = TNomTolva.Text

            If OpTvHabil.Checked Then
                DTolvas.RecordSet("Activa") = "X"
            Else
                DTolvas.RecordSet("Activa") = "-"
            End If

            If FrConstantes.Enabled Then

                'If Eval(TJogTime.Text) < 0.1 Or Eval(TJogTime.Text) > 2 Then
                '    MsgBox("El valor del TIEMPO DE JOG está fuera de límite (0-2)", vbInformation)
                '    Exit Sub
                'End If

                If Eval(TAFina.Text) < 0 Or Eval(TAFina.Text) > 2000 Then
                    MsgBox("El valor de ALIMENTACION FINA está fuera de límite (0-2000", vbInformation)
                    Exit Sub
                End If

                If Eval(TVelFina.Text) < 10 Or Eval(TVelFina.Text) > 100 Then
                    MsgBox("El valor de VELOCIDAD FINA está fuera de límite (10-100)", vbInformation)
                    Exit Sub
                End If

                If Eval(TVelGruesa.Text) < 20 Or Eval(TVelGruesa.Text) > 100 Then
                    MsgBox("El valor de VELOCIDAD GRUESA está fuera de límite (20-100)", vbInformation)
                    Exit Sub
                End If

                If Eval(TCompens.Text) < 0 Or Eval(TCompens.Text) > 200 Then
                    MsgBox("El valor de COMPENSACION está fuera de límite (0-200)", vbInformation)
                    Exit Sub
                End If

                DTolvas.RecordSet("JOGSMAX") = Eval(TJogs.Text)
                DTolvas.RecordSet("JogTime") = Eval(TJogTime.Text)
                DTolvas.RecordSet("AFina") = Eval(TAFina.Text)
                DTolvas.RecordSet("VelFina") = Eval(TVelFina.Text)
                DTolvas.RecordSet("VelGruesa") = Eval(TVelGruesa.Text)
                DTolvas.RecordSet("TolInf") = Eval(TTolInf.Text)
                DTolvas.RecordSet("TolSup") = Eval(TTolSup.Text)
                DTolvas.RecordSet("Compens") = Eval(TCompens.Text)

                If OpCompensAuto.Checked Then
                    DTolvas.RecordSet("CompensAuto") = "X"
                Else
                    DTolvas.RecordSet("CompensAuto") = "-"
                End If



                Evento("Cambia Constantes de tolvas Tolva:" + TTolva.Text + " JT:" + TJogTime.Text + " AFina:" + TAFina.Text + " VelFina: " + TVelFina.Text + " VelG" + TVelGruesa.Text + _
                " Comp: " + TCompens.Text + " TolInf: " + TTolInf.Text + " Tolsup " + TTolSup.Text + " Tv Activa: " + DTolvas.RecordSet("Activa"))

            End If
            Evento("ALTERA INVENTARIOS TOLVA " + TTolva.Text + " DE " + DTolvas.RecordSet("TOTAL").ToString + " A " + (Eval(TTotal.Text) + Eval(TAdicion.Text)).ToString)

            DTolvas.Update("Tolvas Aceptar")

            FrConstantes.Enabled = False

            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Habilitar)
            TNombre.ReadOnly = True
            TCodInt.Enabled = True
            FrActiva.Enabled = True
            DGTolvas.Enabled = False
            TTolva.ReadOnly = True
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Tolvas_Load(Nothing, Nothing)
    End Sub

    Private Sub TTolva_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTolva.KeyDown
        Try
            If e.KeyCode <> Keys.Enter Then Return

            TCodInt.Focus()

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TCodInt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodInt.Enter
        Try
            DGMateriales.Visible = True

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub


    Private Sub TTotal_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTotal.Enter
        DGMateriales.Visible = False
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
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
                Tolvas_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGTolvas, DTolvas.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGTolvas_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BModConstantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModConstantes.Click
        Try
            'If DRUsuario("Config") Then
            'Else
            '    MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            RespInput = MsgBox("Seguro desea alterar los datos de las constantes?. Son datos muy delicados para el proceso de dosificación", vbYesNo + vbInformation)
            If RespInput = vbYes Then
                FrConstantes.Enabled = True
                Evento("Usuario antra a configuración de parámetros de Tolvas")
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

  
    Private Sub TCodInt_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyUp
        Try
            Try

                If e.KeyCode = Keys.Enter AndAlso DGMateriales.Rows.Count = 1 Then
                    DGMateriales_CellClick(Nothing, Nothing)
                    Exit Sub
                End If

                If TCodInt.Text = "" Then
                    TCodInt.Focus()
                    'MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                    TCodInt.Text = ""
                    AsignaDataGrid(DGMateriales, DArt.DataTable, True)
                    Exit Sub
                End If

                If e.KeyCode = Keys.Back Then
                    TNombre.Text = ""
                End If

                Dim Hallado As Boolean

                BusquedaDG(DGMateriales, DArt.DataTable, TCodInt.Text, "CODINT", Hallado)

                If Hallado = False Then
                    'CBBuscar.Focus()
                    'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                    Exit Sub
                End If

            Catch ex As Exception
                MsgError(ex.ToString)
            End Try
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TCodInt_Click(sender As System.Object, e As System.EventArgs) Handles TCodInt.Click
        DGMateriales.Visible = True
    End Sub


End Class