Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO


Public Class Usuarios
    Private DUsuarios As AdoSQL
    Private DUsuariosPermisos As AdoSQL
    Private DUsuariosDetalle As AdoSQL
    Private DVarios As AdoSQL
    Private DCargos As AdoSQL
    Private FormLoad As Boolean


    Private NuevoUsu As Boolean, ModificaUsu As Boolean
    'Private UsuarioSel As String = ""

    Private Sub Usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cont As Integer = 0

        Try

            If FormLoad Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            GBLineaNegocio.Enabled = False


            DUsuariosPermisos = New AdoSQL("USUARIOSPERMISOS")
            DUsuariosDetalle = New AdoSQL("USUARIOSDETALLE")
            DVarios = New AdoSQL("VARIOS")

            DUsuarios = New AdoSQL("USUARIOS")
            DUsuarios.Open("select * from USUARIOS ")

            DCargos = New AdoSQL("CARGOS")
            DCargos.Open("Select * from CARGOS order by CODCARGO")

            LLenaComboBox(CbCargo, DCargos.DataTable, "CARGO")

            CbUsuarios.DataSource = DUsuarios.DataTable
            CbUsuarios.ValueMember = DUsuarios.DataTable.Columns("USUARIO").ToString()
            CbUsuarios.DisplayMember = DUsuarios.DataTable.Columns("USUARIO").ToString()

            DUsuarios.Find("USUARIO='" + CbUsuarios.Text + "'")
            If DUsuarios.EOF Then Exit Sub
            ''ChActivo.Checked = True 'DUsuarios.RecordSet("ACTIVO")

            DUsuariosPermisos.Open("select * from USUARIOSPERMISOS order by TEXTOBOTON")

            Dim X = 0
            Dim Y = 0
            For Each Recordset As DataRow In DUsuariosPermisos.Rows
                Dim Chk As CheckBox = New CheckBox()
                With Chk
                    .Name = "Ch" + Recordset("PERMISO").ToString
                    .Location = New Point(22 + X * 228, 8 + Y * 21)
                    .Size = New Size(200, 17)

                    .Text = Recordset("TEXTOBOTON")
                    .BackColor = Color.Transparent
                    .Parent = PanelPerm
                    .Enabled = True
                End With

                Y += 1
                If Y Mod 25 = 0 Then
                    X += 1
                    Y = 0
                End If

            Next

            CbUsuarios_SelectedIndexChanged(Nothing, Nothing)

            PanNueUsua.Enabled = False

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click

        Dim ChPermiso As String

        Try
            DUsuarios.Find("USUARIO='" + CbUsuarios.Text + "'")
            If DUsuarios.EOF = False Then
                'Resp = MessageBox.Show("El Usuario ya existe desea Sobre escribirlo", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                Resp = MsgBox(DevuelveEvento(CodEvento.USUARIO_EXISTENTE), MessageBoxButtons.YesNo + MessageBoxIcon.Information, "ChronoSoft")
                If Resp = vbNo Then Exit Sub

                DUsuarios.RecordSet("USUARIO") = TUsuario.Text.Trim 'El update se hace en cascada en la BD (USUARIOS y USUARIOSDETALLE)
                DUsuarios.RecordSet("CARGO") = UCase(CbCargo.Text.Trim)
                DUsuarios.RecordSet("CODIGO") = Val(TCodigo.Text)
                If Funcion_ManejaRestriccionLineasNegocio Then
                    DUsuarios.RecordSet("LINEANEGOCIO") = TLineaNegocio.Text
                End If
                DUsuarios.Update(Me)

                UsuariosLog("Modifica usuario " + TUsuario.Text, "Configuración", "")
                Resp = MsgBox(DevuelveEvento(CodEvento.USUARIO_MODIFICARCLAVE), MessageBoxButtons.YesNo + MessageBoxIcon.Information, "ChronoSoft")
                If Resp = vbYes Then
                    UsuariosClave.TUsuario.Text = TUsuario.Text
                    UsuariosClave.ShowDialog()
                    DUsuarios.Open("select * from USUARIOS where USUARIO='" + TUsuario.Text + "'")
                    'Else
                    ''DUsuarios.RecordSet("ACTIVO") = ChActivo.Checked
                    'DUsuarios.RecordSet("CARGO") = UCase(CbCargo.Text.Trim)
                    'DUsuarios.RecordSet("CODIGO") = Val(TCodigo.Text)
                    'If Funcion_ManejaRestriccionLineasNegocio Then
                    '    DUsuarios.RecordSet("LINEANEGOCIO") = TLineaNegocio.Text
                    'End If
                    'DUsuarios.Update(Me)
                End If

            Else
                DUsuarios.AddNew()
                UsuariosLog("Crea usuario " + TUsuario.Text, "Configuración", "")
                DUsuarios.RecordSet("USUARIO") = UCase(TUsuario.Text)
                DUsuarios.RecordSet("CLAVE") = "H"      'Por defecto debe ponerse 
                DUsuarios.RecordSet("CARGO") = UCase(CbCargo.Text.Trim)
                DUsuarios.RecordSet("CODIGO") = Val(TCodigo.Text)

                If Funcion_ManejaRestriccionLineasNegocio Then
                    DUsuarios.RecordSet("LINEANEGOCIO") = TLineaNegocio.Text
                End If
                ''DUsuarios.RecordSet("ACTIVO") = ChActivo.Checked
                DUsuarios.Update(Me)
                UsuariosClave.TUsuario.Text = TUsuario.Text
                UsuariosClave.ShowDialog()
                DUsuarios.Open("select * from USUARIOS where USUARIO='" + TUsuario.Text + "'")
            End If

            For Each Ch As CheckBox In PanelPerm.Controls
                ChPermiso = Ch.Name.Substring(2)
                ''If ChPermiso = "Activo" Then Continue For
                DUsuariosDetalle.Open("select * from USUARIOSDETALLE where USUARIO='" + TUsuario.Text + "' and PERMISO='" + ChPermiso + "'")

                If DUsuariosDetalle.Count = 0 AndAlso Ch.Checked = True Then
                    DUsuariosDetalle.AddNew()
                    DUsuariosDetalle.RecordSet("USUARIO") = TUsuario.Text  'CbUsuarios.Text
                    DUsuariosDetalle.RecordSet("PERMISO") = ChPermiso
                    ' DUsuariosDetalle.RecordSet("ACTIVO") = Ch.Checked
                    DUsuariosDetalle.Update(Me)
                ElseIf DUsuariosDetalle.Count > 0 AndAlso Ch.Checked = False Then
                    For Each Fila As DataRow In DUsuariosDetalle.Rows
                        'Si por algun motivo existen permisos iguales para el mismo usuario
                        DVarios.Delete("delete from USUARIOSDETALLE where ID = " + Fila("ID").ToString, Me)
                    Next

                    'ElseIf DUsuariosDetalle.Count = 1 AndAlso DUsuariosDetalle.RecordSet("ACTIVO") <> Ch.Checked Then

                    '    'DUsuariosDetalle.RecordSet("ACTIVO") = Ch.Checked
                    '    DUsuariosDetalle.Update(Me)
                End If
            Next

            CbUsuarios_SelectedIndexChanged(Nothing, Nothing)
            MsgBox("Los cambios serán aplicados una vez reinicie ChronoSoft", MsgBoxStyle.Information)
            TUsuario.ReadOnly = True
            CbCargo.Enabled = False
            PanNueUsua.Text = "Usuario"
            BModificar.Enabled = True
            BEliminar.Enabled = True
            ChSelecTodos.Checked = False
            ModificaUsu = False
            NuevoUsu = False
            GBLineaNegocio.Enabled = False
            TCodigo.ReadOnly = True
            CbUsuarios.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        Finally
            PanelPerm.Enabled = False
            'TUsuario.Text = ""
            'TCodigo.Text = ""
            'TFechaVenc.Text = ""

        End Try
    End Sub

    Private Sub CbUsuarios_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbUsuarios.SelectedIndexChanged
        Try
            If NuevoUsu = True Or ModificaUsu = True Then Exit Sub
            If CbUsuarios.ValueMember = "" Then Exit Sub

            For Each Ch As CheckBox In PanelPerm.Controls
                Ch.Checked = False
            Next

            DUsuarios.Find("USUARIO='" + CbUsuarios.Text + "'")
            If DUsuarios.EOF Then Exit Sub
            ''ChActivo.Checked = DUsuarios.RecordSet("ACTIVO")

            TFechaVenc.Text = DUsuarios.RecordSet("FECHAEXPPASS")
            TUsuario.Text = DUsuarios.RecordSet("USUARIO")
            CbCargo.Text = DUsuarios.RecordSet("CARGO")
            TCodigo.Text = DUsuarios.RecordSet("CODIGO")

            If Funcion_ManejaRestriccionLineasNegocio Then
                TLineaNegocio.Text = DUsuarios.RecordSet("LINEANEGOCIO")
            End If

            DUsuariosDetalle.Open("select * from USUARIOSDETALLE where USUARIO='" + CbUsuarios.Text + "'")
            If DUsuariosDetalle.EOF Then Exit Sub

            For Each Recordset As DataRow In DUsuariosDetalle.Rows
                Dim nPermiso = PanelPerm.Controls.Find("Ch" + Recordset("PERMISO"), True)

                If nPermiso.Length = 0 Then Continue For
                DirectCast(nPermiso(0), System.Windows.Forms.CheckBox).Checked = True 'Recordset("ACTIVO")
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEliminar.Click
        Try

            If CbUsuarios.Text.Contains("SERVIDOR") Then
                MsgBox("Este es un usuario del sistema, no se puede eliminar", vbInformation)
                Return
            End If

            Resp = MsgBox("¿Seguro desea eliminar al usuario " + CbUsuarios.Text + " de ChronoSoft?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If Resp = vbNo Then Return

            DUsuarios.Find("USUARIO='" + CbUsuarios.Text + "'")

            If DUsuarios.EOF Then Exit Sub

            DVarios.Delete("delete FROM USUARIOS where USUARIO='" + CbUsuarios.Text + "'", Me)

            CbUsuarios.Text = ""
            BCancelar_Click(Nothing, Nothing)

            MsgBox("Proceso Finalizado", vbInformation)

            Usuarios_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try

            TUsuario.Text = ""
            TFechaVenc.Text = ""
            CbCargo.Items.Add("")
            CbCargo.Text = ""
            CbCargo.Items.Remove("")
            CbUsuarios.Text = ""
            CbUsuarios.Enabled = True
            TUsuario.ReadOnly = True
            CbCargo.Enabled = False
            PanelPerm.Enabled = False
            TCodigo.Text = ""

            For Each Ch As CheckBox In PanelPerm.Controls
                Ch.Checked = False
            Next

            GBLineaNegocio.Enabled = False
            PanNueUsua.Text = "Usuario"
            NuevoUsu = False
            ModificaUsu = False
            BEliminar.Enabled = True
            BModificar.Enabled = True
            BNuevo.Enabled = True
            BAceptar.Enabled = False
            BCancelar.Enabled = False
            PanNueUsua.Enabled = False
            TCodigo.ReadOnly = True

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TUsuario.TextChanged
        TUsuario.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub BModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModificar.Click
        Try
            PanNueUsua.Enabled = True
            PanelPerm.Enabled = True
            If Funcion_ManejaRestriccionLineasNegocio Then GBLineaNegocio.Enabled = True
            CbUsuarios.Enabled = False
            CbCargo.Enabled = True
            TUsuario.ReadOnly = False
            DUsuarios.Find("USUARIO='" + CbUsuarios.Text + "'")
            If DUsuarios.EOF Then Exit Sub
            TCodigo.ReadOnly = False
            TUsuario.Text = DUsuarios.RecordSet("USUARIO").ToString
            TFechaVenc.Text = ""

            PanNueUsua.Text = "Modificar Usuario"
            ModificaUsu = True

        Catch ex As Exception
            MsgError(ex)
        Finally
            BAceptar.Enabled = True
            BCancelar.Enabled = True
        End Try

    End Sub


    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            PanelPerm.Enabled = True
            TUsuario.ReadOnly = False
            If Funcion_ManejaRestriccionLineasNegocio Then GBLineaNegocio.Enabled = True

            For Each Ch As CheckBox In PanelPerm.Controls
                Ch.Checked = False
            Next

            CbUsuarios.Enabled = False
            CbUsuarios.Text = ""
            PanNueUsua.Enabled = True
            PanNueUsua.Text = "Nuevo Usuario"
            TUsuario.Text = ""
            NuevoUsu = True
            TFechaVenc.Text = ""
            TCodigo.ReadOnly = False

            BEliminar.Enabled = False
            BModificar.Enabled = False
            BAceptar.Enabled = True
            BCancelar.Enabled = True
            CbCargo.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnModificar.Click
        BModificar_Click(Nothing, Nothing)
    End Sub

    Private Sub mnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEliminar.Click
        BEliminar_Click(Nothing, Nothing)
    End Sub

    Private Sub mnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnNuevo.Click
        BNuevo_Click(Nothing, Nothing)
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        ModificaUsu = False
        NuevoUsu = False
        Me.Hide()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BSaveRulesPass_Click(sender As System.Object, e As System.EventArgs) Handles BSaveRulesPass.Click
        If Val(TVigenciaPass.Text) = 0 Then
            MsgBox("Ingrese un valor en días para la vigencia de la contraseña", vbInformation)
            Exit Sub
        End If
        If Val(TLongMin.Text) = 0 Then
            MsgBox("Ingrese un valor para la longitud mínima de caracteres que debe tener la contraseña", vbInformation)
            Exit Sub
        End If
        If Val(TNumIntentos.Text) = 0 Then
            MsgBox("Ingrese un valor para el numero de intentos de inicio de sesión", vbInformation)
            Exit Sub
        End If
        If Val(TNumUpper.Text) = 0 Then
            MsgBox("Ingrese un valor para la cantidad mínima de letras mayúsculas que debe tener la contraseña", vbInformation)
            Exit Sub
        End If
        If Val(TNumLower.Text) = 0 Then
            MsgBox("Ingrese un valor para la cantidad mínima de letras minúsculas que debe tener la contraseña", vbInformation)
            Exit Sub
        End If
        If Val(TNumNumbers.Text) = 0 Then
            MsgBox("Ingrese un valor para la cantidad mínima de números que debe tener la contraseña", vbInformation)
            Exit Sub
        End If
        If Val(TNumCharSpecial.Text) = 0 Then
            MsgBox("Ingrese un valor para la cantidad mínima de caracteres especiales que debe tener la contraseña", vbInformation)
            Exit Sub
        End If

        ParamClave(0) = TVigenciaPass.Text
        ParamClave(1) = TLongMin.Text
        ParamClave(2) = TNumIntentos.Text
        ParamClave(3) = TNumUpper.Text
        ParamClave(4) = TNumLower.Text
        ParamClave(5) = TNumNumbers.Text
        ParamClave(6) = TNumCharSpecial.Text
        ParamClave(7) = TNumClaves.Text

        WriteConfigVar("PARAMETROSCLAVE", String.Join(",", ParamClave))
        GBRulesPass.Visible = False
        UsuariosLog("Modifica reglas de password", "Configuración", String.Join(",", ParamClave))

    End Sub

    Private Sub ChSelecTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChSelecTodos.CheckedChanged
        Try
            Dim Seleccionar As Boolean = False

            If ChSelecTodos.Checked Then Seleccionar = True

            For Each Ch As CheckBox In PanelPerm.Controls
                Ch.Checked = Seleccionar
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TUsuario_KeyUp(sender As Object, e As KeyEventArgs) Handles TUsuario.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TCargo_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TVigenciaPass_KeyUp(sender As Object, e As KeyEventArgs) Handles TVigenciaPass.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TNumIntentos_KeyUp(sender As Object, e As KeyEventArgs) Handles TNumIntentos.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TLongMin_KeyUp(sender As Object, e As KeyEventArgs) Handles TLongMin.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TNumUpper_KeyUp(sender As Object, e As KeyEventArgs) Handles TNumUpper.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TNumLower_KeyUp(sender As Object, e As KeyEventArgs) Handles TNumLower.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TNumNumbers_KeyUp(sender As Object, e As KeyEventArgs) Handles TNumNumbers.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TNumCharSpecial_KeyUp(sender As Object, e As KeyEventArgs) Handles TNumCharSpecial.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TNumClaves_KeyUp(sender As Object, e As KeyEventArgs) Handles TNumClaves.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub mnImpUsuarioActual_Click(sender As Object, e As EventArgs) Handles mnImpUsuarioActual.Click

        'UsuarioSel = "{CPermisosUsuarios.Usuario}='" + TUsuario.Text + "'"
        ImprimirPermisos(TUsuario.Text)  '(UsuarioSel)

    End Sub

    Private Sub mnImpTodos_Click(sender As Object, e As EventArgs) Handles mnImpTodos.Click

        'UsuarioSel = ""
        ImprimirPermisos("")   '(UsuarioSel)

    End Sub

    Private Sub ImprimirPermisos(ByVal Filtro As String)
        Dim RepSap As CrystalRep

        Try
            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpUsuarios.rpt"
                If Filtro.Length > 0 Then .SelectionFormula = "{CPermisosUsuarios.Usuario}='" + Filtro + "'"
                .PrintReport()
            End With

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpListaPermisos_Click(sender As Object, e As EventArgs) Handles mnImpListaPermisos.Click
        Dim RepSap As CrystalRep

        Try
            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpListaPermisos.rpt"
                .PrintReport()
            End With

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ImportarPermisosToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Try
            If ValidaPermiso("Configuracion") Then
                DUsuariosDetalle.Open("select * from USUARIOSDETALLE ")
                DUsuariosPermisos.Open("select * from USUARIOSPERMISOS")

                For Each regPermiso As DataRow In DUsuariosPermisos.Rows
                    If regPermiso("PERMISOANTERIOR") = "-" Or regPermiso("PERMISOANTERIOR") = "" Then Continue For

                    DVarios.Open("select USUARIO," + regPermiso("PERMISOANTERIOR") + " from USUARIOS")

                    For Each regDvarios As DataRow In DVarios.Rows
                        If regDvarios(regPermiso("PERMISOANTERIOR")) = False Then Continue For
                        DUsuariosDetalle.AddNew()
                        DUsuariosDetalle.RecordSet("USUARIO") = regDvarios("USUARIO")
                        DUsuariosDetalle.RecordSet("PERMISO") = regPermiso("PERMISO")
                        'DUsuariosDetalle.RecordSet("ACTIVO") = regDvarios(regPermiso("PERMISOANTERIOR"))
                        DUsuariosDetalle.Update()

                    Next
                Next
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DUsuariosPermisos = New AdoSQL("USUARIOSPERMISOS")
            DUsuariosDetalle = New AdoSQL("USUARIOSDETALLE")
            DVarios = New AdoSQL("VARIOS")

            DUsuarios = New AdoSQL("USUARIOS")
            DUsuarios.Open("select * from USUARIOS ")

            DCargos = New AdoSQL("CARGOS")
            DCargos.Open("Select * from CARGOS order by CODCARGO")

            LLenaComboBox(CbCargo, DCargos.DataTable, "CARGO")

            CbUsuarios.DataSource = DUsuarios.DataTable
            CbUsuarios.ValueMember = DUsuarios.DataTable.Columns("USUARIO").ToString()
            CbUsuarios.DisplayMember = DUsuarios.DataTable.Columns("USUARIO").ToString()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CbCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbCargo.SelectedIndexChanged
        If CbCargo.SelectedItem = "DOSIFICADOR" AndAlso (ModificaUsu = True Or NuevoUsu = True) Then
            TCodigo.ReadOnly = False
        End If
    End Sub

    'Esta función no quedó en la versión 1910.24a.G se pone acá para que entre en el próximo cambio
    Private Sub BRulesPass_Click(sender As System.Object, e As System.EventArgs) Handles BRulesPass.Click
        Try
            'If DRUsuario("CONFIG") Then
            If ValidaPermiso("Usuarios_Editar") Then
            Else
                'MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            RespInput = MsgBox(DevuelveEvento(CodEvento.USUARIO_MODIFICARPARAMETROSCLAVE), vbYesNo + vbInformation)
            If RespInput = vbYes Then
                If Split(ReadConfigVar("PARAMETROSCLAVE"), ",").Length = 8 Then
                    ParamClave = Split(ReadConfigVar("PARAMETROSCLAVE"), ",")
                    TVigenciaPass.Text = ParamClave(0)
                    TLongMin.Text = ParamClave(1)
                    TNumIntentos.Text = ParamClave(2)
                    TNumUpper.Text = ParamClave(3)
                    TNumLower.Text = ParamClave(4)
                    TNumNumbers.Text = ParamClave(5)
                    TNumCharSpecial.Text = ParamClave(6)
                    TNumClaves.Text = ParamClave(7)
                Else
                    TVigenciaPass.Text = 30
                    TLongMin.Text = 8
                    TNumIntentos.Text = 3
                    TNumUpper.Text = 1
                    TNumLower.Text = 1
                    TNumNumbers.Text = 1
                    TNumCharSpecial.Text = 1
                    TNumClaves.Text = 5
                End If

                GBRulesPass.Visible = True

            End If
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


End Class