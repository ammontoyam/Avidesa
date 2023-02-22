<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsgEvError
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TError = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TError
        '
        Me.TError.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TError.Location = New System.Drawing.Point(29, 24)
        Me.TError.Multiline = True
        Me.TError.Name = "TError"
        Me.TError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TError.Size = New System.Drawing.Size(504, 553)
        Me.TError.TabIndex = 0
        '
        'MsgEvError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 606)
        Me.Controls.Add(Me.TError)
        Me.Name = "MsgEvError"
        Me.Text = "Mensaje. Favor tomar foto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TError As System.Windows.Forms.TextBox
End Class
