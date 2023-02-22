Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports ClassLibrary
Public Class Tolvas
    Private DTolvas As AdoSQL
    Private DArt As AdoSQL
    Private Fila As Integer
    Private Campos() As String
    Private Proceso As String = "DOSIFICACION"
    Private Sub Tolvas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DTolvas = New AdoSQL("Tolvas")
            DArt = New AdoSQL("ARTICULOS")

            DTolvas.Open("select * from TOLVAS where PROCESO='" + Proceso + "' order by TOLVA")
            DArt.Open("select * from ARTICULOS where TIPO='MP'")

            AsignaDataGrid(DGTolvas, DTolvas.DataTable)
            AsignaDataGrid(DGMateriales, DArt.DataTable, True)
            FrConstantes.Enabled = False
            TTolva.ReadOnly = True
            TextNum(TTolva)
            TCodInt.Enabled = False
            FrActiva.Enabled = False
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            DGTolvas_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))

            Campos = {"Nombre@NombreMaterial", "Nomtolva@NombreTolva"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DTolvas.DataTable)

            If ValidaFuncionalidad("Intervalo.Jogs") Then TJogInterv.Enabled = True
        Catch ex As Exception
            MsgError(ex)
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
            TCodInt.Text = DTolvas.RecordSet("CodInt")
            TNombre.Text = DTolvas.RecordSet("Nombre")
            TTotal.Text = Format(DTolvas.RecordSet("TOTAL"), "# ###")
            TAlarma.Text = Format(DTolvas.RecordSet("Alarma"), "# ###")
            TDesc.Text = DTolvas.RecordSet("TAMDESC")
            TCapacidad.Text = DTolvas.RecordSet("Capacidad")
            TBascula.Text = DTolvas.RecordSet("Bascula")
            TJogTime.Text = DTolvas.RecordSet("JogTime")
            If ValidaFuncionalidad("Intervalo.Jogs") Then
                TJogInterv.Text = DTolvas.RecordSet("JogInterval")
            End If
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

            mnLCuenta.Text = DGTolvas.Rows.Count.ToString
            Fila = DGTolvas.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGMateriales_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMateriales.CellClick
        Dim Mat As String
        Try
            If DGMateriales.RowCount = 0 Then Return

            Mat = DGMateriales.Rows(DGMateriales.CurrentRow.Index).Cells("DGMateriales_CodInt").Value.ToString

            DArt.Find("CODINT='" + Mat + "'")

            If DArt.EOF Then Return

            TCodInt.Text = DArt.RecordSet("CODINT")
            TNombre.Text = DArt.RecordSet("NOMBRE")

            DGMateriales.Visible = False

        Catch ex As Exception
            MsgError(ex)
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

            If Val(TTolva.Text) = 0 Then Exit Sub

            DTolvas.Find("TOLVA=" + TTolva.Text + " and  PROCESO='" + Proceso + "'")
            If DTolvas.EOF = False Then
                Resp = MessageBox.Show("La tolva ya existe ¿desea sobre escribirla?", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub

                Evento("CAMBIA MP EN TOLVA: " + TTolva.Text + " " + TNomTolva.Text + " CODMATINI: " + DTolvas.RecordSet("CodInt").ToString + " " + DTolvas.RecordSet("Nombre"))

            Else
                DTolvas.AddNew()
            End If

            DTolvas.RecordSet("TOLVA") = TTolva.Text
            DTolvas.RecordSet("CodInt") = TCodInt.Text
            DTolvas.RecordSet("Nombre") = TNombre.Text
            DTolvas.RecordSet("TOTAL") = Eval(TTotal.Text) + Eval(TAdicion.Text)
            DTolvas.RecordSet("Alarma") = Eval(TAlarma.Text)
            DTolvas.RecordSet("TAMDESC") = Eval(TDesc.Text)
            DTolvas.RecordSet("CAPACIDAD") = Eval(TCapacidad.Text)
            DTolvas.RecordSet("NOMTOLVA") = TNomTolva.Text

            If ODosificacion.Checked Then DTolvas.RecordSet("PROCESO") = "DOSIFICACION"
            If OEmpaque.Checked Then DTolvas.RecordSet("PROCESO") = "EMPAQUE"
            If OPeletizado.Checked Then DTolvas.RecordSet("PROCESO") = "PELETIZADO"

            If OpTvHabil.Checked Then
                DTolvas.RecordSet("Activa") = "X"
            ElseIf OpTvDesHab.Checked Then
                DTolvas.RecordSet("Activa") = "-"
            End If

            If FrConstantes.Enabled Then

                If Eval(TJogTime.Text) < Eval(ConfigParametros("JogTime")) Or Eval(TJogTime.Text) > 10 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "TIEMPO DE JOG, está fuera de límite (0-10)"), vbInformation)
                    Exit Sub
                End If

                If Eval(TAFina.Text) < 0 Or Eval(TAFina.Text) > Eval(ConfigParametros("AlimentacionFina")) Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "ALIMENTACION FINA, está fuera de límite (0-2000)"), vbInformation)
                    Exit Sub
                End If

                If Eval(TVelFina.Text) < 5 Or Eval(TVelFina.Text) > Eval(ConfigParametros("VelocidadFina")) Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "VELOCIDAD FINA, está fuera de límite (5-80)"), vbInformation)
                    Exit Sub
                End If

                If Eval(TVelGruesa.Text) < 10 Or Eval(TVelGruesa.Text) > Eval(ConfigParametros("VelocidadGruesa")) Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "VELOCIDAD GRUESA, está fuera de límite (20-100)"), vbInformation)
                    Exit Sub
                End If

                If Eval(TCompens.Text) < 0 Or Eval(TCompens.Text) > Eval(ConfigParametros("Compensacion")) Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "COMPENSACION, está fuera de límite (0-200)"), vbInformation)
                    Exit Sub
                End If


                DTolvas.RecordSet("Bascula") = Eval(TBascula.Text)
                DTolvas.RecordSet("JogTime") = Eval(TJogTime.Text)
                If ValidaFuncionalidad("Intervalo.Jogs") Then DTolvas.RecordSet("JogInterval") = Eval(TJogInterv.Text)
                DTolvas.RecordSet("AFina") = Eval(TAFina.Text)
                DTolvas.RecordSet("VelFina") = Eval(TVelFina.Text)
                DTolvas.RecordSet("VelGruesa") = Eval(TVelGruesa.Text)
                DTolvas.RecordSet("TolInf") = Eval(TTolInf.Text)
                DTolvas.RecordSet("TolSup") = Eval(TTolSup.Text)
                DTolvas.RecordSet("Compens") = Eval(TCompens.Text)

                If OpCompensAuto.Checked Then
                    DTolvas.RecordSet("CompensAuto") = "X"
                ElseIf OpCompensManual.Checked Then
                    DTolvas.RecordSet("CompensAuto") = "-"
                End If



                Evento("Cambia Constantes de tolvas Tolva:" + TTolva.Text + " JT:" + TJogTime.Text + " AFina:" + TAFina.Text + " VelFina: " + TVelFina.Text + " VelG" + TVelGruesa.Text +
                " Comp: " + TCompens.Text + " TolInf: " + TTolInf.Text + " Tolsup " + TTolSup.Text + " Tv Activa: " + DTolvas.RecordSet("Activa"))

            End If
            Evento("CAMBIA MP EN TOLVA: " + TTolva.Text + " " + TNomTolva.Text + " CODMATFINAL: " + DTolvas.RecordSet("CodInt").ToString + " " + DTolvas.RecordSet("Nombre"))
            Evento("ALTERA INVENTARIOS TOLVA " + TTolva.Text + " DE " + DTolvas.RecordSet("TOTAL").ToString + " A " + (Eval(TTotal.Text) + Eval(TAdicion.Text)).ToString)

            DTolvas.Update(Me)

            FrConstantes.Enabled = False

            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try

            If ValidaPermiso("Tolvas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Habilitar)
            TNombre.ReadOnly = True
            TCodInt.Enabled = True
            FrActiva.Enabled = True
            DGTolvas.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If ValidaPermiso("Configuracion") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            FrConstantes.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Habilitar)
            Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)
            TNombre.ReadOnly = True
            TCodInt.Enabled = True
            FrActiva.Enabled = True
        Catch ex As Exception
            MsgError(ex)
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
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodInt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodInt.Enter
        Try
            DGMateriales.Visible = True

        Catch ex As Exception
            MsgError(ex)
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


    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGTolvas.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGTolvas.Rows(Fila).Selected = True
            DGTolvas.FirstDisplayedScrollingRowIndex = Fila
            DGTolvas.CurrentCell = DGTolvas(0, Fila)
            DGTolvas_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGTolvas.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGTolvas.Rows(Fila).Selected = True
            DGTolvas.FirstDisplayedScrollingRowIndex = Fila
            DGTolvas.CurrentCell = DGTolvas(0, Fila)
            DGTolvas_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGTolvas.Rows.Count = 0 Then Exit Sub
            Fila = DGTolvas.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGTolvas.Rows(Fila).Selected = True
            DGTolvas.FirstDisplayedScrollingRowIndex = Fila
            DGTolvas.CurrentCell = DGTolvas(0, Fila)
            DGTolvas_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGTolvas.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGTolvas.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGTolvas.Rows(Fila).Selected = True
            DGTolvas.FirstDisplayedScrollingRowIndex = Fila
            DGTolvas.CurrentCell = DGTolvas(0, Fila)
            DGTolvas_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "a buscar"), vbInformation), vbInformation)
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
            MsgError(ex)
        End Try
    End Sub

    Private Sub BModConstantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModConstantes.Click
        Try
            'If DRUsuario("Config") Then
            If ValidaPermiso("Tolvas_Parametros") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE) + "de las constantes?. Son datos muy delicados para el proceso de dosificación", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            'RespInput = MsgBox("Seguro desea alterar los datos de las constantes?. Son datos muy delicados para el proceso de dosificación", vbYesNo + vbInformation)
            If Resp = vbYes Then
                FrConstantes.Enabled = True
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimir.Click
        Dim RepSap As CrystalRep

        Try

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                'If TipoServer <> "SQLSERVER" Then .ServerName = NomDB
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpInvTol.rpt"
                .PrintReport()
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ODosificacion_Click(sender As System.Object, e As System.EventArgs) Handles ODosificacion.Click
        If ODosificacion.Checked Then
            Proceso = "DOSIFICACION"
            If TCodInt.Enabled = False Then
                DTolvas.Open("select * from TOLVAS where PROCESO='" + Proceso + "' order by TOLVA")
                AsignaDataGrid(DGTolvas, DTolvas.DataTable)
                DGTolvas_CellClick(Nothing, Nothing)
            End If

            DArt.Open("select * from ARTICULOS where TIPO='MP'")
            AsignaDataGrid(DGMateriales, DArt.DataTable, True)
        End If
    End Sub

    Private Sub OPeletizado_Click(sender As System.Object, e As System.EventArgs) Handles OPeletizado.Click
        If OPeletizado.Checked Then
            Proceso = "PELETIZADO"
            If TCodInt.Enabled = False Then
                DTolvas.Open("select * from TOLVAS where PROCESO='" + Proceso + "' order by TOLVA")
                AsignaDataGrid(DGTolvas, DTolvas.DataTable)
                DGTolvas_CellClick(Nothing, Nothing)
            End If
            DArt.Open("select * from ARTICULOS where TIPO='PT'")
            AsignaDataGrid(DGMateriales, DArt.DataTable, True)
        End If
    End Sub

    Private Sub OEmpaque_Click(sender As System.Object, e As System.EventArgs) Handles OEmpaque.Click
        If OEmpaque.Checked Then
            Proceso = "EMPAQUE"
            If TCodInt.Enabled = False Then
                DTolvas.Open("select * from TOLVAS where PROCESO='" + Proceso + "' order by TOLVA")
                AsignaDataGrid(DGTolvas, DTolvas.DataTable)
                DGTolvas_CellClick(Nothing, Nothing)
            End If
            DArt.Open("select * from ARTICULOS where TIPO='PT'")
            AsignaDataGrid(DGMateriales, DArt.DataTable, True)
        End If
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
                MsgError(ex)
            End Try
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodInt_Click(sender As System.Object, e As System.EventArgs) Handles TCodInt.Click
        DGMateriales.Visible = True
    End Sub
End Class