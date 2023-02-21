<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioTolva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambioTolva))
        Me.TCodMat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TTolvaAct = New System.Windows.Forms.TextBox()
        Me.TNomMat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CBNuevaTolva = New System.Windows.Forms.ComboBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TTolva = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBascActual = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBascNueva = New System.Windows.Forms.TextBox()
        Me.TNomTv = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TCodMat
        '
        Me.TCodMat.Location = New System.Drawing.Point(115, 41)
        Me.TCodMat.Name = "TCodMat"
        Me.TCodMat.ReadOnly = True
        Me.TCodMat.Size = New System.Drawing.Size(101, 20)
        Me.TCodMat.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Material:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tolva Actual:"
        '
        'TTolvaAct
        '
        Me.TTolvaAct.Location = New System.Drawing.Point(291, 68)
        Me.TTolvaAct.Name = "TTolvaAct"
        Me.TTolvaAct.ReadOnly = True
        Me.TTolvaAct.Size = New System.Drawing.Size(33, 20)
        Me.TTolvaAct.TabIndex = 2
        '
        'TNomMat
        '
        Me.TNomMat.Location = New System.Drawing.Point(222, 41)
        Me.TNomMat.Name = "TNomMat"
        Me.TNomMat.ReadOnly = True
        Me.TNomMat.Size = New System.Drawing.Size(254, 20)
        Me.TNomMat.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nueva Tolva:"
        '
        'CBNuevaTolva
        '
        Me.CBNuevaTolva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBNuevaTolva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBNuevaTolva.FormattingEnabled = True
        Me.CBNuevaTolva.Location = New System.Drawing.Point(114, 94)
        Me.CBNuevaTolva.Name = "CBNuevaTolva"
        Me.CBNuevaTolva.Size = New System.Drawing.Size(101, 28)
        Me.CBNuevaTolva.TabIndex = 6
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(196, 160)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(74, 45)
        Me.BCancelar.TabIndex = 25
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(114, 160)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(74, 45)
        Me.BAceptar.TabIndex = 24
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'TTolva
        '
        Me.TTolva.Location = New System.Drawing.Point(291, 94)
        Me.TTolva.Name = "TTolva"
        Me.TTolva.ReadOnly = True
        Me.TTolva.Size = New System.Drawing.Size(33, 20)
        Me.TTolva.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "No.Tolva:"
        '
        'TBascActual
        '
        Me.TBascActual.Enabled = False
        Me.TBascActual.Location = New System.Drawing.Point(415, 71)
        Me.TBascActual.Name = "TBascActual"
        Me.TBascActual.ReadOnly = True
        Me.TBascActual.Size = New System.Drawing.Size(29, 20)
        Me.TBascActual.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(343, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Basc Actual:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(343, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Basc Nueva:"
        '
        'TBascNueva
        '
        Me.TBascNueva.Enabled = False
        Me.TBascNueva.Location = New System.Drawing.Point(415, 97)
        Me.TBascNueva.Name = "TBascNueva"
        Me.TBascNueva.ReadOnly = True
        Me.TBascNueva.Size = New System.Drawing.Size(29, 20)
        Me.TBascNueva.TabIndex = 30
        '
        'TNomTv
        '
        Me.TNomTv.Location = New System.Drawing.Point(116, 68)
        Me.TNomTv.Name = "TNomTv"
        Me.TNomTv.ReadOnly = True
        Me.TNomTv.Size = New System.Drawing.Size(99, 20)
        Me.TNomTv.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(234, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "No.Tolva:"
        '
        'CambioTolva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 244)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TNomTv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TBascNueva)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TBascActual)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TTolva)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BAceptar)
        Me.Controls.Add(Me.CBNuevaTolva)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TNomMat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TTolvaAct)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TCodMat)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambioTolva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Tolva Ingrediente en Curso"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TCodMat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TTolvaAct As System.Windows.Forms.TextBox
    Friend WithEvents TNomMat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CBNuevaTolva As System.Windows.Forms.ComboBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents TTolva As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TBascActual As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TBascNueva As System.Windows.Forms.TextBox
    Friend WithEvents TNomTv As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
