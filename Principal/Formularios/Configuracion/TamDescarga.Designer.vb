<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TamDescarga
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TamDescarga))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DGTamDescarga = New System.Windows.Forms.DataGridView()
        Me.CODDESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GBConfiguracion = New System.Windows.Forms.GroupBox()
        Me.TAlimFina2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TVelDescarga = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TTiempoSolt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TTolInferior = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TTolSuperior = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TAlimFina = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TTamDescarga = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGTamDescarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBConfiguracion.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BNuevo, Me.ToolStripSeparator1, Me.BEditar, Me.ToolStripSeparator2, Me.BBorrar, Me.ToolStripSeparator3, Me.BActualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(684, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'DGTamDescarga
        '
        Me.DGTamDescarga.AllowUserToAddRows = False
        Me.DGTamDescarga.AllowUserToDeleteRows = False
        Me.DGTamDescarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTamDescarga.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODDESC, Me.NOMBRE})
        Me.DGTamDescarga.Location = New System.Drawing.Point(345, 43)
        Me.DGTamDescarga.MultiSelect = False
        Me.DGTamDescarga.Name = "DGTamDescarga"
        Me.DGTamDescarga.ReadOnly = True
        Me.DGTamDescarga.Size = New System.Drawing.Size(328, 335)
        Me.DGTamDescarga.TabIndex = 3
        '
        'CODDESC
        '
        Me.CODDESC.HeaderText = "Cod. Descarga"
        Me.CODDESC.Name = "CODDESC"
        Me.CODDESC.ReadOnly = True
        Me.CODDESC.Width = 80
        '
        'NOMBRE
        '
        Me.NOMBRE.HeaderText = "Nombre"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        Me.NOMBRE.Width = 200
        '
        'GBConfiguracion
        '
        Me.GBConfiguracion.Controls.Add(Me.TAlimFina2)
        Me.GBConfiguracion.Controls.Add(Me.Label9)
        Me.GBConfiguracion.Controls.Add(Me.TVelDescarga)
        Me.GBConfiguracion.Controls.Add(Me.Label7)
        Me.GBConfiguracion.Controls.Add(Me.TTiempoSolt)
        Me.GBConfiguracion.Controls.Add(Me.Label8)
        Me.GBConfiguracion.Controls.Add(Me.TTolInferior)
        Me.GBConfiguracion.Controls.Add(Me.Label5)
        Me.GBConfiguracion.Controls.Add(Me.TTolSuperior)
        Me.GBConfiguracion.Controls.Add(Me.Label6)
        Me.GBConfiguracion.Controls.Add(Me.TAlimFina)
        Me.GBConfiguracion.Controls.Add(Me.Label3)
        Me.GBConfiguracion.Controls.Add(Me.TTamDescarga)
        Me.GBConfiguracion.Controls.Add(Me.Label2)
        Me.GBConfiguracion.Controls.Add(Me.TNombre)
        Me.GBConfiguracion.Controls.Add(Me.BCancelar)
        Me.GBConfiguracion.Controls.Add(Me.BAceptar)
        Me.GBConfiguracion.Controls.Add(Me.Label4)
        Me.GBConfiguracion.Controls.Add(Me.TCodigo)
        Me.GBConfiguracion.Controls.Add(Me.Label1)
        Me.GBConfiguracion.Enabled = False
        Me.GBConfiguracion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBConfiguracion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBConfiguracion.Location = New System.Drawing.Point(12, 43)
        Me.GBConfiguracion.Name = "GBConfiguracion"
        Me.GBConfiguracion.Size = New System.Drawing.Size(321, 335)
        Me.GBConfiguracion.TabIndex = 4
        Me.GBConfiguracion.TabStop = False
        '
        'TAlimFina2
        '
        Me.TAlimFina2.Location = New System.Drawing.Point(101, 256)
        Me.TAlimFina2.Name = "TAlimFina2"
        Me.TAlimFina2.Size = New System.Drawing.Size(70, 20)
        Me.TAlimFina2.TabIndex = 22
        Me.TAlimFina2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(9, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 14)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Alim. Fina B2:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TVelDescarga
        '
        Me.TVelDescarga.Location = New System.Drawing.Point(101, 226)
        Me.TVelDescarga.Name = "TVelDescarga"
        Me.TVelDescarga.Size = New System.Drawing.Size(70, 20)
        Me.TVelDescarga.TabIndex = 20
        Me.TVelDescarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(8, 229)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 14)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Vel. Descarga:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TTiempoSolt
        '
        Me.TTiempoSolt.Location = New System.Drawing.Point(101, 196)
        Me.TTiempoSolt.Name = "TTiempoSolt"
        Me.TTiempoSolt.Size = New System.Drawing.Size(70, 20)
        Me.TTiempoSolt.TabIndex = 18
        Me.TTiempoSolt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(8, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 14)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Tiempo Solt.:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TTolInferior
        '
        Me.TTolInferior.Location = New System.Drawing.Point(101, 166)
        Me.TTolInferior.Name = "TTolInferior"
        Me.TTolInferior.Size = New System.Drawing.Size(70, 20)
        Me.TTolInferior.TabIndex = 16
        Me.TTolInferior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 14)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Tol. Inferior:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TTolSuperior
        '
        Me.TTolSuperior.Location = New System.Drawing.Point(101, 136)
        Me.TTolSuperior.Name = "TTolSuperior"
        Me.TTolSuperior.Size = New System.Drawing.Size(70, 20)
        Me.TTolSuperior.TabIndex = 14
        Me.TTolSuperior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 14)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Tol. Superior:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TAlimFina
        '
        Me.TAlimFina.Location = New System.Drawing.Point(101, 106)
        Me.TAlimFina.Name = "TAlimFina"
        Me.TAlimFina.Size = New System.Drawing.Size(70, 20)
        Me.TAlimFina.TabIndex = 12
        Me.TAlimFina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Alim. Fina B1:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TTamDescarga
        '
        Me.TTamDescarga.Location = New System.Drawing.Point(101, 76)
        Me.TTamDescarga.Name = "TTamDescarga"
        Me.TTamDescarga.Size = New System.Drawing.Size(70, 20)
        Me.TTamDescarga.TabIndex = 10
        Me.TTamDescarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Tam. Descarga:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TNombre
        '
        Me.TNombre.Location = New System.Drawing.Point(101, 46)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(178, 20)
        Me.TNombre.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nombre:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCodigo
        '
        Me.TCodigo.Location = New System.Drawing.Point(116, 16)
        Me.TCodigo.Name = "TCodigo"
        Me.TCodigo.Size = New System.Drawing.Size(70, 20)
        Me.TCodigo.TabIndex = 3
        Me.TCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código Descarga:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BCancelar
        '
        Me.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(188, 296)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 8
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(92, 296)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 7
        Me.BAceptar.UseVisualStyleBackColor = True
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
        'BBorrar
        '
        Me.BBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBorrar.Image = CType(resources.GetObject("BBorrar.Image"), System.Drawing.Image)
        Me.BBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBorrar.Name = "BBorrar"
        Me.BBorrar.Size = New System.Drawing.Size(23, 22)
        Me.BBorrar.Text = "Borrar"
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
        'TamDescarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 391)
        Me.Controls.Add(Me.GBConfiguracion)
        Me.Controls.Add(Me.DGTamDescarga)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TamDescarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipos de Descarga"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGTamDescarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBConfiguracion.ResumeLayout(False)
        Me.GBConfiguracion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents BNuevo As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BEditar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents BBorrar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents DGTamDescarga As DataGridView
    Friend WithEvents GBConfiguracion As GroupBox
    Friend WithEvents TNombre As TextBox
    Friend WithEvents BCancelar As Button
    Friend WithEvents BAceptar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TVelDescarga As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TTiempoSolt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TTolInferior As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TTolSuperior As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TAlimFina As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TTamDescarga As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TAlimFina2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CODDESC As DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As DataGridViewTextBoxColumn
End Class
