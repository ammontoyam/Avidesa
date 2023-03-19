<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MermaMaquila
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MermaMaquila))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCodInt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GBNombre = New System.Windows.Forms.GroupBox()
        Me.TPorcMerma = New System.Windows.Forms.TextBox()
        Me.TNombreMaquila = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMaquila = New System.Windows.Forms.ComboBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.DGMermaMaq = New System.Windows.Forms.DataGridView()
        Me.CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroTrabajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMerma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBNombre.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGMermaMaq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Código Interno:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Maquila:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCodInt
        '
        Me.TCodInt.Location = New System.Drawing.Point(17, 43)
        Me.TCodInt.Name = "TCodInt"
        Me.TCodInt.ReadOnly = True
        Me.TCodInt.Size = New System.Drawing.Size(100, 20)
        Me.TCodInt.TabIndex = 21
        Me.TCodInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(17, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 14)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Por. Merma:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GBNombre
        '
        Me.GBNombre.Controls.Add(Me.TPorcMerma)
        Me.GBNombre.Controls.Add(Me.TNombreMaquila)
        Me.GBNombre.Controls.Add(Me.Label3)
        Me.GBNombre.Controls.Add(Me.CMaquila)
        Me.GBNombre.Controls.Add(Me.BCancelar)
        Me.GBNombre.Controls.Add(Me.BAceptar)
        Me.GBNombre.Controls.Add(Me.Label4)
        Me.GBNombre.Controls.Add(Me.TCodInt)
        Me.GBNombre.Controls.Add(Me.Label2)
        Me.GBNombre.Controls.Add(Me.Label1)
        Me.GBNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBNombre.Location = New System.Drawing.Point(12, 39)
        Me.GBNombre.Name = "GBNombre"
        Me.GBNombre.Size = New System.Drawing.Size(201, 259)
        Me.GBNombre.TabIndex = 19
        Me.GBNombre.TabStop = False
        '
        'TPorcMerma
        '
        Me.TPorcMerma.Location = New System.Drawing.Point(17, 92)
        Me.TPorcMerma.Name = "TPorcMerma"
        Me.TPorcMerma.Size = New System.Drawing.Size(100, 20)
        Me.TPorcMerma.TabIndex = 29
        '
        'TNombreMaquila
        '
        Me.TNombreMaquila.Location = New System.Drawing.Point(17, 187)
        Me.TNombreMaquila.Name = "TNombreMaquila"
        Me.TNombreMaquila.ReadOnly = True
        Me.TNombreMaquila.Size = New System.Drawing.Size(171, 20)
        Me.TNombreMaquila.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(17, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Nombre Maquila:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CMaquila
        '
        Me.CMaquila.FormattingEnabled = True
        Me.CMaquila.Location = New System.Drawing.Point(17, 137)
        Me.CMaquila.Name = "CMaquila"
        Me.CMaquila.Size = New System.Drawing.Size(96, 22)
        Me.CMaquila.TabIndex = 26
        '
        'BCancelar
        '
        Me.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(130, 224)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.BCancelar, "Cancelar cambios")
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(34, 224)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 24
        Me.ToolTip1.SetToolTip(Me.BAceptar, "Guardar cambios")
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BBorrar, Me.ToolStripSeparator1, Me.BActualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(589, 25)
        Me.ToolStrip1.TabIndex = 24
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BSalir
        '
        Me.BSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSalir.Image = CType(resources.GetObject("BSalir.Image"), System.Drawing.Image)
        Me.BSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(23, 22)
        Me.BSalir.Text = "Salir"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'BBorrar
        '
        Me.BBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBorrar.Image = CType(resources.GetObject("BBorrar.Image"), System.Drawing.Image)
        Me.BBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBorrar.Name = "BBorrar"
        Me.BBorrar.Size = New System.Drawing.Size(23, 22)
        Me.BBorrar.Text = "Borrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BActualizar
        '
        Me.BActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActualizar.Image = CType(resources.GetObject("BActualizar.Image"), System.Drawing.Image)
        Me.BActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BActualizar.Name = "BActualizar"
        Me.BActualizar.Size = New System.Drawing.Size(23, 22)
        Me.BActualizar.Text = "Actualizar"
        '
        'DGMermaMaq
        '
        Me.DGMermaMaq.AllowUserToAddRows = False
        Me.DGMermaMaq.AllowUserToDeleteRows = False
        Me.DGMermaMaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMermaMaq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodInt, Me.CentroTrabajo, Me.PorcMerma, Me.Fecha})
        Me.DGMermaMaq.Location = New System.Drawing.Point(220, 39)
        Me.DGMermaMaq.MultiSelect = False
        Me.DGMermaMaq.Name = "DGMermaMaq"
        Me.DGMermaMaq.ReadOnly = True
        Me.DGMermaMaq.Size = New System.Drawing.Size(358, 259)
        Me.DGMermaMaq.TabIndex = 25
        '
        'CodInt
        '
        Me.CodInt.HeaderText = "Cod. Interno"
        Me.CodInt.Name = "CodInt"
        Me.CodInt.ReadOnly = True
        Me.CodInt.Width = 60
        '
        'CentroTrabajo
        '
        Me.CentroTrabajo.HeaderText = "Maquila"
        Me.CentroTrabajo.Name = "CentroTrabajo"
        Me.CentroTrabajo.ReadOnly = True
        Me.CentroTrabajo.Width = 50
        '
        'PorcMerma
        '
        Me.PorcMerma.HeaderText = "Porc. Merma"
        Me.PorcMerma.Name = "PorcMerma"
        Me.PorcMerma.ReadOnly = True
        Me.PorcMerma.Width = 80
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 120
        '
        'MermaMaquila
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 318)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGMermaMaq)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GBNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MermaMaquila"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MermaMaquila"
        Me.GBNombre.ResumeLayout(False)
        Me.GBNombre.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGMermaMaq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TCodInt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GBNombre As GroupBox
    Friend WithEvents BCancelar As Button
    Friend WithEvents BAceptar As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents DGMermaMaq As DataGridView
    Friend WithEvents CMaquila As ComboBox
    Friend WithEvents BBorrar As ToolStripButton
    Friend WithEvents TNombreMaquila As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TPorcMerma As TextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents CodInt As DataGridViewTextBoxColumn
    Friend WithEvents CentroTrabajo As DataGridViewTextBoxColumn
    Friend WithEvents PorcMerma As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
End Class
