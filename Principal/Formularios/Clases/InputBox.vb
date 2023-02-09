Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Module InputBox
    Public Function InputBox(ByVal title As String, ByVal promptText As String, ByRef value As String, Optional ByVal Ver As Boolean = True) As DialogResult
        Dim form As New Form()
        Dim label As New Label()
        Dim textBox As New TextBox()
        Dim buttonOk As New Button()
        Dim buttonCancel As New Button()
        form.Text = title
        label.Text = promptText
        label.TextAlign = ContentAlignment.MiddleCenter
        textBox.Text = value
        buttonOk.Text = "OK"
        buttonCancel.Text = "Cancel"
        buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        label.SetBounds(9, 20, 372, 13)
        textBox.SetBounds(12, 36, 372, 20)
        buttonOk.SetBounds(228, 72, 75, 23)
        buttonCancel.SetBounds(309, 72, 75, 23)
        label.AutoSize = True
        textBox.Anchor = textBox.Anchor Or AnchorStyles.Right
        buttonOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        buttonCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        form.ClientSize = New Size(396, 107)
        If Ver = False Then textBox.PasswordChar = "*"
        form.Controls.AddRange(New Control() {textBox, buttonOk, buttonCancel, label})

        form.ClientSize = New Size(Math.Max(300, label.Right + 10), form.ClientSize.Height)

        form.FormBorderStyle = FormBorderStyle.FixedDialog
        form.StartPosition = FormStartPosition.CenterScreen
        form.MinimizeBox = False
        form.MaximizeBox = False
        form.AcceptButton = buttonOk
        form.CancelButton = buttonCancel
        Dim dialogResult As DialogResult = form.ShowDialog()
        value = textBox.Text
        Return dialogResult

    End Function
End Module
