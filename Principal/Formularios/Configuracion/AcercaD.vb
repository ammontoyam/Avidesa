Public NotInheritable Class AcercaD
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOk.Click
        Me.Close()
    End Sub


    Private Sub AcercaD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TPlanta.Text = Planta
    End Sub
End Class
