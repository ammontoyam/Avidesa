<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetBacheMic
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetBacheMic))
        Me.DGDetBach = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TLP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LAviso = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TFecha = New System.Windows.Forms.TextBox()
        Me.TBacheNo = New System.Windows.Forms.TextBox()
        Me.TNomFor = New System.Windows.Forms.TextBox()
        Me.TCodFor = New System.Windows.Forms.TextBox()
        Me.TCodForB = New System.Windows.Forms.TextBox()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEliminar = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnEliminaIng = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TContador = New System.Windows.Forms.TextBox()
        Me.BVerBache = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TTotMeta = New System.Windows.Forms.TextBox()
        Me.TTotReal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CodMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGDetBach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGDetBach
        '
        Me.DGDetBach.AllowUserToAddRows = False
        Me.DGDetBach.AllowUserToDeleteRows = False
        Me.DGDetBach.AllowUserToResizeRows = False
        Me.DGDetBach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetBach.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodMat, Me.NomMat, Me.PesoMeta, Me.PesoReal, Me.ID})
        Me.DGDetBach.Location = New System.Drawing.Point(231, 59)
        Me.DGDetBach.MultiSelect = False
        Me.DGDetBach.Name = "DGDetBach"
        Me.DGDetBach.ReadOnly = True
        Me.DGDetBach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGDetBach.Size = New System.Drawing.Size(377, 404)
        Me.DGDetBach.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TLP)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.LAviso)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TFecha)
        Me.Panel1.Controls.Add(Me.TBacheNo)
        Me.Panel1.Controls.Add(Me.TNomFor)
        Me.Panel1.Controls.Add(Me.TCodFor)
        Me.Panel1.Controls.Add(Me.TCodForB)
        Me.Panel1.Controls.Add(Me.TOPs)
        Me.Panel1.Location = New System.Drawing.Point(12, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(201, 235)
        Me.Panel1.TabIndex = 27
        '
        'TLP
        '
        Me.TLP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLP.Location = New System.Drawing.Point(49, 98)
        Me.TLP.Name = "TLP"
        Me.TLP.Size = New System.Drawing.Size(101, 21)
        Me.TLP.TabIndex = 12
        Me.TLP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Versión"
        '
        'LAviso
        '
        Me.LAviso.AutoSize = True
        Me.LAviso.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LAviso.ForeColor = System.Drawing.Color.Navy
        Me.LAviso.Location = New System.Drawing.Point(3, 201)
        Me.LAviso.Name = "LAviso"
        Me.LAviso.Size = New System.Drawing.Size(38, 15)
        Me.LAviso.TabIndex = 10
        Me.LAviso.Text = "Aviso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Bache"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Fórmula"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "O. Producción"
        '
        'TFecha
        '
        Me.TFecha.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFecha.Location = New System.Drawing.Point(46, 153)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.Size = New System.Drawing.Size(101, 21)
        Me.TFecha.TabIndex = 5
        Me.TFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBacheNo
        '
        Me.TBacheNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBacheNo.Location = New System.Drawing.Point(48, 127)
        Me.TBacheNo.Name = "TBacheNo"
        Me.TBacheNo.Size = New System.Drawing.Size(49, 21)
        Me.TBacheNo.TabIndex = 4
        Me.TBacheNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNomFor
        '
        Me.TNomFor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNomFor.Location = New System.Drawing.Point(6, 74)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.Size = New System.Drawing.Size(189, 21)
        Me.TNomFor.TabIndex = 3
        Me.TNomFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodFor
        '
        Me.TCodFor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodFor.Location = New System.Drawing.Point(48, 47)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.Size = New System.Drawing.Size(60, 21)
        Me.TCodFor.TabIndex = 2
        Me.TCodFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodForB
        '
        Me.TCodForB.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodForB.Location = New System.Drawing.Point(117, 47)
        Me.TCodForB.Name = "TCodForB"
        Me.TCodForB.Size = New System.Drawing.Size(60, 21)
        Me.TCodForB.TabIndex = 1
        Me.TCodForB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOPs
        '
        Me.TOPs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPs.Location = New System.Drawing.Point(84, 13)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.Size = New System.Drawing.Size(69, 21)
        Me.TOPs.TabIndex = 0
        Me.TOPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BEliminar, Me.ToolStripSeparator4})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(620, 25)
        Me.ToolStrip2.TabIndex = 30
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'BEliminar
        '
        Me.BEliminar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnEliminaIng})
        Me.BEliminar.Image = CType(resources.GetObject("BEliminar.Image"), System.Drawing.Image)
        Me.BEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEliminar.Name = "BEliminar"
        Me.BEliminar.Size = New System.Drawing.Size(82, 22)
        Me.BEliminar.Text = "Eliminar"
        '
        'mnEliminaIng
        '
        Me.mnEliminaIng.Name = "mnEliminaIng"
        Me.mnEliminaIng.Size = New System.Drawing.Size(134, 22)
        Me.mnEliminaIng.Text = "Ingrediente"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.MaterialesToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(620, 24)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'MaterialesToolStripMenuItem
        '
        Me.MaterialesToolStripMenuItem.Image = CType(resources.GetObject("MaterialesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MaterialesToolStripMenuItem.Name = "MaterialesToolStripMenuItem"
        Me.MaterialesToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.MaterialesToolStripMenuItem.Text = "Materiales"
        '
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.Image = CType(resources.GetObject("OtrosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.OtrosToolStripMenuItem.Text = "Otros"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de...."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BAnterior
        '
        Me.BAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BAnterior.Image = CType(resources.GetObject("BAnterior.Image"), System.Drawing.Image)
        Me.BAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAnterior.Name = "BAnterior"
        Me.BAnterior.Size = New System.Drawing.Size(23, 22)
        Me.BAnterior.Text = "Previus"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BSiguiente
        '
        Me.BSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSiguiente.Image = CType(resources.GetObject("BSiguiente.Image"), System.Drawing.Image)
        Me.BSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSiguiente.Name = "BSiguiente"
        Me.BSiguiente.Size = New System.Drawing.Size(23, 22)
        Me.BSiguiente.Text = "Next"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.BAnterior, Me.ToolStripSeparator2, Me.BSiguiente, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(130, 83)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(67, 25)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TContador
        '
        Me.TContador.BackColor = System.Drawing.Color.DarkCyan
        Me.TContador.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TContador.ForeColor = System.Drawing.Color.White
        Me.TContador.Location = New System.Drawing.Point(11, 79)
        Me.TContador.Name = "TContador"
        Me.TContador.Size = New System.Drawing.Size(121, 29)
        Me.TContador.TabIndex = 32
        Me.TContador.Text = "1234567890"
        Me.TContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BVerBache
        '
        Me.BVerBache.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BVerBache.ForeColor = System.Drawing.Color.Red
        Me.BVerBache.Image = CType(resources.GetObject("BVerBache.Image"), System.Drawing.Image)
        Me.BVerBache.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BVerBache.Location = New System.Drawing.Point(19, 114)
        Me.BVerBache.Name = "BVerBache"
        Me.BVerBache.Size = New System.Drawing.Size(145, 29)
        Me.BVerBache.TabIndex = 33
        Me.BVerBache.Text = "Ver Bache"
        Me.BVerBache.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(42, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Bache No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(410, 472)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Totales"
        '
        'TTotMeta
        '
        Me.TTotMeta.BackColor = System.Drawing.Color.White
        Me.TTotMeta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTotMeta.ForeColor = System.Drawing.Color.DarkCyan
        Me.TTotMeta.Location = New System.Drawing.Point(462, 472)
        Me.TTotMeta.Name = "TTotMeta"
        Me.TTotMeta.ReadOnly = True
        Me.TTotMeta.Size = New System.Drawing.Size(63, 21)
        Me.TTotMeta.TabIndex = 36
        '
        'TTotReal
        '
        Me.TTotReal.BackColor = System.Drawing.Color.White
        Me.TTotReal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTotReal.ForeColor = System.Drawing.Color.DarkCyan
        Me.TTotReal.Location = New System.Drawing.Point(531, 472)
        Me.TTotReal.Name = "TTotReal"
        Me.TTotReal.ReadOnly = True
        Me.TTotReal.Size = New System.Drawing.Size(63, 21)
        Me.TTotReal.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(600, 476)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Kg"
        '
        'CodMat
        '
        Me.CodMat.HeaderText = "Cod"
        Me.CodMat.Name = "CodMat"
        Me.CodMat.ReadOnly = True
        Me.CodMat.Width = 50
        '
        'NomMat
        '
        Me.NomMat.HeaderText = "Nombre"
        Me.NomMat.Name = "NomMat"
        Me.NomMat.ReadOnly = True
        Me.NomMat.Width = 140
        '
        'PesoMeta
        '
        Me.PesoMeta.HeaderText = "P.Meta"
        Me.PesoMeta.Name = "PesoMeta"
        Me.PesoMeta.ReadOnly = True
        Me.PesoMeta.Width = 60
        '
        'PesoReal
        '
        Me.PesoReal.HeaderText = "P.Real"
        Me.PesoReal.Name = "PesoReal"
        Me.PesoReal.ReadOnly = True
        Me.PesoReal.Width = 60
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'DetBacheMic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 502)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TTotReal)
        Me.Controls.Add(Me.TTotMeta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BVerBache)
        Me.Controls.Add(Me.TContador)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGDetBach)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DetBacheMic"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de bache micros"
        CType(Me.DGDetBach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGDetBach As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TFecha As System.Windows.Forms.TextBox
    Friend WithEvents TBacheNo As System.Windows.Forms.TextBox
    Friend WithEvents TNomFor As System.Windows.Forms.TextBox
    Friend WithEvents TCodFor As System.Windows.Forms.TextBox
    Friend WithEvents TCodForB As System.Windows.Forms.TextBox
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LAviso As System.Windows.Forms.Label
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BEliminar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents mnEliminaIng As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TContador As System.Windows.Forms.TextBox
    Friend WithEvents BVerBache As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TTotMeta As System.Windows.Forms.TextBox
    Friend WithEvents TTotReal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CodMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoMeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TLP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
End Class
