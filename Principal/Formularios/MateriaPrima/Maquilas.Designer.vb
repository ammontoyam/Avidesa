<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Maquilas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Maquilas))
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TNombreMaquila = New System.Windows.Forms.TextBox()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.GBMaquilas = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TObservaciones = New System.Windows.Forms.TextBox()
        Me.ChActivo = New System.Windows.Forms.CheckBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCodMaquila = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGMaquilas = New System.Windows.Forms.DataGridView()
        Me.CentroTrabajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreMaq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBMaquilas.SuspendLayout()
        CType(Me.DGMaquilas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TNombreMaquila
        '
        Me.TNombreMaquila.Location = New System.Drawing.Point(8, 87)
        Me.TNombreMaquila.Name = "TNombreMaquila"
        Me.TNombreMaquila.Size = New System.Drawing.Size(178, 20)
        Me.TNombreMaquila.TabIndex = 4
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'GBMaquilas
        '
        Me.GBMaquilas.Controls.Add(Me.Label16)
        Me.GBMaquilas.Controls.Add(Me.TObservaciones)
        Me.GBMaquilas.Controls.Add(Me.ChActivo)
        Me.GBMaquilas.Controls.Add(Me.TNombreMaquila)
        Me.GBMaquilas.Controls.Add(Me.BCancelar)
        Me.GBMaquilas.Controls.Add(Me.BAceptar)
        Me.GBMaquilas.Controls.Add(Me.Label4)
        Me.GBMaquilas.Controls.Add(Me.TCodMaquila)
        Me.GBMaquilas.Controls.Add(Me.Label1)
        Me.GBMaquilas.Enabled = False
        Me.GBMaquilas.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBMaquilas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBMaquilas.Location = New System.Drawing.Point(12, 38)
        Me.GBMaquilas.Name = "GBMaquilas"
        Me.GBMaquilas.Size = New System.Drawing.Size(201, 259)
        Me.GBMaquilas.TabIndex = 1
        Me.GBMaquilas.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 142)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 14)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Observaciones"
        '
        'TObservaciones
        '
        Me.TObservaciones.Location = New System.Drawing.Point(8, 158)
        Me.TObservaciones.Multiline = True
        Me.TObservaciones.Name = "TObservaciones"
        Me.TObservaciones.Size = New System.Drawing.Size(182, 62)
        Me.TObservaciones.TabIndex = 6
        '
        'ChActivo
        '
        Me.ChActivo.AutoSize = True
        Me.ChActivo.Location = New System.Drawing.Point(67, 115)
        Me.ChActivo.Name = "ChActivo"
        Me.ChActivo.Size = New System.Drawing.Size(60, 18)
        Me.ChActivo.TabIndex = 5
        Me.ChActivo.Text = "Activo"
        Me.ChActivo.UseVisualStyleBackColor = True
        '
        'BCancelar
        '
        Me.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(130, 224)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 8
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
        Me.BAceptar.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.BAceptar, "Guardar cambios")
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nombre de Maquilador:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCodMaquila
        '
        Me.TCodMaquila.Location = New System.Drawing.Point(8, 38)
        Me.TCodMaquila.Name = "TCodMaquila"
        Me.TCodMaquila.Size = New System.Drawing.Size(52, 20)
        Me.TCodMaquila.TabIndex = 3
        Me.TCodMaquila.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código Maquila:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DGMaquilas
        '
        Me.DGMaquilas.AllowUserToAddRows = False
        Me.DGMaquilas.AllowUserToDeleteRows = False
        Me.DGMaquilas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMaquilas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CentroTrabajo, Me.NombreMaq, Me.Activo, Me.Observaciones})
        Me.DGMaquilas.Location = New System.Drawing.Point(220, 38)
        Me.DGMaquilas.MultiSelect = False
        Me.DGMaquilas.Name = "DGMaquilas"
        Me.DGMaquilas.ReadOnly = True
        Me.DGMaquilas.Size = New System.Drawing.Size(357, 259)
        Me.DGMaquilas.TabIndex = 2
        '
        'CentroTrabajo
        '
        Me.CentroTrabajo.HeaderText = "Cod. Maquila"
        Me.CentroTrabajo.Name = "CentroTrabajo"
        Me.CentroTrabajo.ReadOnly = True
        Me.CentroTrabajo.Width = 60
        '
        'NombreMaq
        '
        Me.NombreMaq.HeaderText = "Nombre de Maquilador"
        Me.NombreMaq.Name = "NombreMaq"
        Me.NombreMaq.ReadOnly = True
        Me.NombreMaq.Width = 170
        '
        'Activo
        '
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        Me.Activo.ReadOnly = True
        Me.Activo.Width = 80
        '
        'Observaciones
        '
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BNuevo, Me.ToolStripSeparator1, Me.BEditar, Me.ToolStripSeparator2, Me.BBorrar, Me.ToolStripSeparator3, Me.BActualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(590, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'BNuevo
        '
        Me.BNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BNuevo.Image = CType(resources.GetObject("BNuevo.Image"), System.Drawing.Image)
        Me.BNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(23, 22)
        Me.BNuevo.Text = "Nuevo"
        '
        'BEditar
        '
        Me.BEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEditar.Image = CType(resources.GetObject("BEditar.Image"), System.Drawing.Image)
        Me.BEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEditar.Name = "BEditar"
        Me.BEditar.Size = New System.Drawing.Size(23, 22)
        Me.BEditar.Text = "Editar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'Maquilas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 307)
        Me.ControlBox = False
        Me.Controls.Add(Me.GBMaquilas)
        Me.Controls.Add(Me.DGMaquilas)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Maquilas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maquilas"
        Me.GBMaquilas.ResumeLayout(False)
        Me.GBMaquilas.PerformLayout()
        CType(Me.DGMaquilas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BBorrar As ToolStripButton
    Friend WithEvents TNombreMaquila As TextBox
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents BSalir As ToolStripButton
    Friend WithEvents BCancelar As Button
    Friend WithEvents BAceptar As Button
    Friend WithEvents GBMaquilas As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TCodMaquila As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DGMaquilas As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ChActivo As CheckBox
    Friend WithEvents BNuevo As ToolStripButton
    Friend WithEvents BEditar As ToolStripButton
    Friend WithEvents Label16 As Label
    Friend WithEvents TObservaciones As TextBox
    Friend WithEvents CentroTrabajo As DataGridViewTextBoxColumn
    Friend WithEvents NombreMaq As DataGridViewTextBoxColumn
    Friend WithEvents Activo As DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
End Class
