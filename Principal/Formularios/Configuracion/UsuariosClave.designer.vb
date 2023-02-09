<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuariosClave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UsuariosClave))
        Me.BOk = New System.Windows.Forms.Button()
        Me.BCancel = New System.Windows.Forms.Button()
        Me.TReingClave = New System.Windows.Forms.TextBox()
        Me.TNClave = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.TCondiciones = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TUsuario = New System.Windows.Forms.Label()
        Me.chPedirClave = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BOk
        '
        Me.BOk.Image = CType(resources.GetObject("BOk.Image"), System.Drawing.Image)
        Me.BOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BOk.Location = New System.Drawing.Point(143, 365)
        Me.BOk.Name = "BOk"
        Me.BOk.Size = New System.Drawing.Size(64, 30)
        Me.BOk.TabIndex = 9
        Me.BOk.Text = "&Aceptar"
        Me.BOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BOk.UseVisualStyleBackColor = True
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Image = CType(resources.GetObject("BCancel.Image"), System.Drawing.Image)
        Me.BCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BCancel.Location = New System.Drawing.Point(221, 365)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 30)
        Me.BCancel.TabIndex = 10
        Me.BCancel.Text = "&Cancelar"
        Me.BCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TReingClave
        '
        Me.TReingClave.Location = New System.Drawing.Point(160, 292)
        Me.TReingClave.Name = "TReingClave"
        Me.TReingClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TReingClave.Size = New System.Drawing.Size(157, 20)
        Me.TReingClave.TabIndex = 8
        Me.TReingClave.UseSystemPasswordChar = True
        '
        'TNClave
        '
        Me.TNClave.Location = New System.Drawing.Point(160, 258)
        Me.TNClave.Name = "TNClave"
        Me.TNClave.Size = New System.Drawing.Size(157, 20)
        Me.TNClave.TabIndex = 7
        Me.TNClave.UseSystemPasswordChar = True
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.ForeColor = System.Drawing.Color.Blue
        Me.PasswordLabel.Location = New System.Drawing.Point(67, 287)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(93, 28)
        Me.PasswordLabel.TabIndex = 5
        Me.PasswordLabel.Text = "Repetir Clave:"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.Blue
        Me.UsernameLabel.Location = New System.Drawing.Point(67, 256)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(93, 23)
        Me.UsernameLabel.TabIndex = 4
        Me.UsernameLabel.Text = "Clave Nueva:"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TCondiciones
        '
        Me.TCondiciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCondiciones.Location = New System.Drawing.Point(12, 67)
        Me.TCondiciones.Name = "TCondiciones"
        Me.TCondiciones.Size = New System.Drawing.Size(436, 121)
        Me.TCondiciones.TabIndex = 1
        Me.TCondiciones.Text = "-------"
        Me.TCondiciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(67, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Condiciones de la clave"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(67, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Usuario:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TUsuario
        '
        Me.TUsuario.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUsuario.ForeColor = System.Drawing.Color.Blue
        Me.TUsuario.Location = New System.Drawing.Point(157, 210)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.Size = New System.Drawing.Size(224, 23)
        Me.TUsuario.TabIndex = 3
        Me.TUsuario.Text = "Condiciones de la clave"
        Me.TUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chPedirClave
        '
        Me.chPedirClave.AutoSize = True
        Me.chPedirClave.Location = New System.Drawing.Point(118, 330)
        Me.chPedirClave.Name = "chPedirClave"
        Me.chPedirClave.Size = New System.Drawing.Size(219, 17)
        Me.chPedirClave.TabIndex = 6
        Me.chPedirClave.Text = "Solicitar al usuario cambio de contraseña"
        Me.chPedirClave.UseVisualStyleBackColor = True
        Me.chPedirClave.Visible = False
        '
        'UsuariosClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.chPedirClave)
        Me.Controls.Add(Me.TUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCondiciones)
        Me.Controls.Add(Me.BOk)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.TReingClave)
        Me.Controls.Add(Me.TNClave)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UsuariosClave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion de clave"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BOk As System.Windows.Forms.Button
    Friend WithEvents BCancel As System.Windows.Forms.Button
    Friend WithEvents TReingClave As System.Windows.Forms.TextBox
    Friend WithEvents TNClave As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents TCondiciones As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TUsuario As System.Windows.Forms.Label
    Friend WithEvents chPedirClave As System.Windows.Forms.CheckBox
End Class
