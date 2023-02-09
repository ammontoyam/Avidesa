<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Acceso
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents TUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TClave As System.Windows.Forms.TextBox
    Friend WithEvents BCancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Acceso))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.TUsuario = New System.Windows.Forms.TextBox()
        Me.TClave = New System.Windows.Forms.TextBox()
        Me.BCancel = New System.Windows.Forms.Button()
        Me.BOk = New System.Windows.Forms.Button()
        Me.LCambTurno = New System.Windows.Forms.Label()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(1, -2)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(193, 203)
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.ForeColor = System.Drawing.Color.Blue
        Me.UsernameLabel.Location = New System.Drawing.Point(218, 40)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(139, 23)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Nombre de usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.ForeColor = System.Drawing.Color.Blue
        Me.PasswordLabel.Location = New System.Drawing.Point(235, 87)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(108, 23)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TUsuario
        '
        Me.TUsuario.Location = New System.Drawing.Point(200, 60)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.Size = New System.Drawing.Size(192, 20)
        Me.TUsuario.TabIndex = 1
        '
        'TClave
        '
        Me.TClave.Location = New System.Drawing.Point(200, 113)
        Me.TClave.Name = "TClave"
        Me.TClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TClave.Size = New System.Drawing.Size(192, 20)
        Me.TClave.TabIndex = 3
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Image = CType(resources.GetObject("BCancel.Image"), System.Drawing.Image)
        Me.BCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BCancel.Location = New System.Drawing.Point(287, 157)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 22)
        Me.BCancel.TabIndex = 5
        Me.BCancel.Text = "&Cancelar"
        Me.BCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BOk
        '
        Me.BOk.Image = CType(resources.GetObject("BOk.Image"), System.Drawing.Image)
        Me.BOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BOk.Location = New System.Drawing.Point(200, 157)
        Me.BOk.Name = "BOk"
        Me.BOk.Size = New System.Drawing.Size(64, 21)
        Me.BOk.TabIndex = 6
        Me.BOk.Text = "&Aceptar"
        Me.BOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BOk.UseVisualStyleBackColor = True
        '
        'LCambTurno
        '
        Me.LCambTurno.AutoSize = True
        Me.LCambTurno.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCambTurno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LCambTurno.Location = New System.Drawing.Point(232, 12)
        Me.LCambTurno.Name = "LCambTurno"
        Me.LCambTurno.Size = New System.Drawing.Size(127, 18)
        Me.LCambTurno.TabIndex = 9
        Me.LCambTurno.Text = "CAMBIO DE TURNO"
        Me.LCambTurno.Visible = False
        '
        'Acceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.BCancel
        Me.ClientSize = New System.Drawing.Size(401, 201)
        Me.ControlBox = False
        Me.Controls.Add(Me.LCambTurno)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.BOk)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.TClave)
        Me.Controls.Add(Me.TUsuario)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Acceso"
        Me.Opacity = 0.9R
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Acceso"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BOk As System.Windows.Forms.Button
    Friend WithEvents LCambTurno As Label
End Class
