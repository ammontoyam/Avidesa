Imports System.IO

Public Class Start

    Private Sub TimStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimStart.Tick
        TimStart.Enabled = False
        Me.Dispose()
        Me.Close()
        Fondo.Show()
    End Sub

    Private Sub Start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim ArchivoLog As StreamReader
        'Dim ContenidoLog As String
        'Dim UsuarioReg As Boolean
        'Dim AuxSesion As String

        'Sesion = My.User.Name

        'Ruta = Application.StartupPath
        'If Ruta.Last.ToString <> "\" Then Ruta = Ruta + "\"


        'If Not File.Exists(Ruta + "EventChr.log") Then
        '    WriteFile(Ruta + "EventChr.Log", "Eventos de ingreso sistema ChronoSoft " + vbCrLf)
        'End If

        'Dim PosLog As Long

        'ArchivoLog = File.OpenText(Ruta + "EventChr.log")
        'ContenidoLog = ArchivoLog.ReadToEnd

        'ArchivoLog.Close()

        ''AuxSesion = Mid(Sesion, InStr(1, Sesion, "\") + 1)
        'Sesion = Environment.UserName
        'PosLog = InStr(1, ContenidoLog, Sesion)

        'UsuarioReg = False

        'If PosLog > 0 Then UsuarioReg = True

        'If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 And UsuarioReg Then
        '    MessageBox.Show("La aplicación ya se esta ejecutando", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End
        'Else
        '    If UsuarioReg = False Then WriteFile(Ruta + "EventChr.log", Sesion + Space(20) + Now.ToString("yyyy/MM/dd HH:mm:ss"))
        'End If

        TimStart.Enabled = True
    End Sub
End Class