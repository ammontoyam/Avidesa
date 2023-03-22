Imports System.IO

Public Class Start

    Private Sub TimStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimStart.Tick
        TimStart.Enabled = False
        Me.Dispose()
        Me.Close()
        Fondo.Show()
    End Sub

    Private Sub Start_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TPlanta.Text = "AVIDESA BUCARAMANGA"

        If InStr(UCase(Application.StartupPath), "AVI") Then TimStart.Interval = 10

        'Ahorra tiempo mientras desarrollamos
        If InStr(UCase(Application.ExecutablePath), "FEED") > 0 Then TimStart_Tick(0, Nothing)

        TimStart.Enabled = True
    End Sub
End Class