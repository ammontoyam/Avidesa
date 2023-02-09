

Public Class UsuariosClave
    Private DUsuarios As AdoSQL
    Private DVarios As AdoSQL
    Private numClavesHist As Int16


    Public Sub NuevaClave_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DUsuarios = New AdoSQL("Usuarios")
        DVarios = New AdoSQL("Usuarios")

        DUsuarios.Open("Select * from USUARIOS ")
        ParamClave = Split(ReadConfigVar("PARAMETROSCLAVE"), ",")

        TCondiciones.Text = "- Tener una longitud mínima de caracteres de " + ParamClave(1).ToString + vbCrLf +
                   "- Incluir Mayúsculas (A-Z): " + ParamClave(3).ToString + vbCrLf +
                   "- Incluir Mínusculas (a-z):  " + ParamClave(4).ToString + vbCrLf +
                   "- Incluir números (0-9): " + ParamClave(5).ToString + vbCrLf +
                   "- Incluir Caracteres especiales (por ejemplo ?,#,$,%,&,@): " + ParamClave(6).ToString
        numClavesHist = Val(ParamClave(7))

        'TNClave.Focus()
        SendKeys.Send("{TAB}")
        'Se mira cual es el usuario que tiene abierto el programa para saber si muestra pedir clave
        DUsuarios.Find("USUARIO='" + UsuarioPrincipal + "'")
        If DUsuarios.RecordSet("USUAMOD") Then chPedirClave.Visible = True

    End Sub

    Private Sub BCancel_Click(sender As System.Object, e As System.EventArgs) Handles BCancel.Click
        CerrarChr = True    'Se usa para cuando 
        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub BOk_Click(sender As System.Object, e As System.EventArgs) Handles BOk.Click
        Try
            Dim nClave As String = ""
            Dim VerifSeg As Boolean = False

            If TReingClave.Text.Trim <> TNClave.Text.Trim Then 'validacion de la nueva para confirmarla
                'MsgBox("Claves no coinciden verifíquela e intentelo de nuevo", vbOKOnly + vbExclamation, "Validación de la clave")
                MsgBox(DevuelveEvento(CodEvento.USUARIO_CLAVESNOCOINCIDEN), MessageBoxButtons.OK + MessageBoxIcon.Exclamation, "Validación de la clave")
                TNClave.Text = ""
                TReingClave.Text = ""
                Exit Sub
            End If


            nClave = TNClave.Text.Trim
            TNClave.Text = ""
            TReingClave.Text = ""
            VerifSeg = ValidaSeguridad(nClave)

            If VerifSeg = False Then
                'MsgBox("La contraseña no cumple con las condiciones de seguridad", vbExclamation, "Reglas seguridad")
                MsgBox(DevuelveEvento(CodEvento.USUARIO_SEGURIDADCONTRASEÑA), MessageBoxIcon.Exclamation)
                Exit Sub
            End If


            For K = 1 To Len(nClave)
                TNClave.Text = TNClave.Text + Chr(Asc(Mid(nClave, K, 1)) + (K * 2) + 5)
            Next K


            If VerifClaveHist(TUsuario.Text, TNClave.Text) = False Then
                'MsgBox("La clave ya fue usada recientemente, debe cambiarla", vbInformation)
                MsgBox(DevuelveEvento(CodEvento.USUARIO_CLAVEUSADA), MessageBoxIcon.Information)
                TNClave.Text = ""
                TReingClave.Text = ""
                TNClave.Focus()
                Return
            End If

            DUsuarios.Find("USUARIO='" + TUsuario.Text + "'")
            If DUsuarios.EOF = False Then
                DUsuarios.RecordSet("CLAVE") = TNClave.Text.Trim
                DUsuarios.RecordSet("FECHAEXPPASS") = DateAdd("d", vigPass, DateTime.Now).ToString("yyyy/MM/dd")
                DUsuarios.RecordSet("CAMBIOCLAVE") = False
                If chPedirClave.Checked Then DUsuarios.RecordSet("CAMBIOCLAVE") = True
                DUsuarios.Update(Me)
                solCambClave = False        'Si había solicitud se cancela por ahora ya que ya están cambiando la clave
            End If
            TNClave.Text = ""

            'MsgBox("La clave ha sido modificada satisfactoriamente.", vbOKOnly + vbInformation)
            MsgBox(DevuelveEvento(CodEvento.USUARIO_CLAVEMODIFICADA), MessageBoxButtons.OK + MessageBoxIcon.Information)
            UsuariosLog("Usuario cambia Clave: ", "Configuración", TUsuario.Text)

            CerrarChr = False

            'Dim FechaV As Date
            'Dim FechaVStr
            'FechaV = DateAdd(DateInterval.Year, -2, Now.Date)
            'FechaVStr = FechaV.Year.ToString("0000") + "/" + FechaV.Month.ToString("00") + "/" + FechaV.Day.ToString("00")
            'DVarios.Open("delete from USUARIOSHIST where FECHA<'" + FechaVStr + "'")

            Me.Dispose()
            Me.Close()

        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub

    Private Sub TNClave_KeyUp(sender As Object, e As KeyEventArgs) Handles TNClave.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TReingClave_KeyUp(sender As Object, e As KeyEventArgs) Handles TReingClave.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        SendKeys.Send("{TAB}")
    End Sub
End Class