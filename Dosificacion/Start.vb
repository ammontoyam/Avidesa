Public Class Start
    Private Sub TimStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimStart.Tick
        TimStart.Enabled = False
        Acceso.ShowDialog()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Start_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Planta = "AVIDESA BUCARAMANGA"
        TPlanta.Text = Planta

        If InStr(UCase(Application.StartupPath), "AVI") Then TimStart.Interval = 10

        'Ahorra tiempo mientras desarrollamos
        If InStr(UCase(Application.ExecutablePath), "FEED") > 0 Then TimStart_Tick(0, Nothing)

    End Sub
End Class