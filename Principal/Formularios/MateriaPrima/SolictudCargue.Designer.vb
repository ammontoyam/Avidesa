<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolictudCargue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolictudCargue))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TCantidad = New System.Windows.Forms.TextBox()
        Me.TLote = New System.Windows.Forms.TextBox()
        Me.TNomMat = New System.Windows.Forms.TextBox()
        Me.TCodMat = New System.Windows.Forms.TextBox()
        Me.TTolva = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGSoliCargue = New System.Windows.Forms.DataGridView()
        Me.Cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tolva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalTolva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Falta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Habilitado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBajar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSubir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.BImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.BHabCargue = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.BInhabilitar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.BImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGSoliCargue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnOtros, Me.mnAcercaDe})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1152, 24)
        Me.MenuStrip1.TabIndex = 121
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSalir})
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'mnSalir
        '
        Me.mnSalir.Name = "mnSalir"
        Me.mnSalir.Size = New System.Drawing.Size(98, 22)
        Me.mnSalir.Text = "Salir"
        '
        'mnOtros
        '
        Me.mnOtros.Image = CType(resources.GetObject("mnOtros.Image"), System.Drawing.Image)
        Me.mnOtros.Name = "mnOtros"
        Me.mnOtros.Size = New System.Drawing.Size(66, 20)
        Me.mnOtros.Text = "Otros"
        '
        'mnAcercaDe
        '
        Me.mnAcercaDe.Image = CType(resources.GetObject("mnAcercaDe.Image"), System.Drawing.Image)
        Me.mnAcercaDe.Name = "mnAcercaDe"
        Me.mnAcercaDe.Size = New System.Drawing.Size(102, 20)
        Me.mnAcercaDe.Text = "Acerca de...."
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TCantidad)
        Me.Panel1.Controls.Add(Me.TLote)
        Me.Panel1.Controls.Add(Me.TNomMat)
        Me.Panel1.Controls.Add(Me.TCodMat)
        Me.Panel1.Controls.Add(Me.TTolva)
        Me.Panel1.Controls.Add(Me.BCancelar)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 170)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 279)
        Me.Panel1.TabIndex = 123
        '
        'TCantidad
        '
        Me.TCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TCantidad.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCantidad.ForeColor = System.Drawing.Color.Green
        Me.TCantidad.Location = New System.Drawing.Point(91, 191)
        Me.TCantidad.Name = "TCantidad"
        Me.TCantidad.ReadOnly = True
        Me.TCantidad.Size = New System.Drawing.Size(122, 26)
        Me.TCantidad.TabIndex = 30
        Me.TCantidad.Text = "----"
        Me.TCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TLote
        '
        Me.TLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TLote.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLote.ForeColor = System.Drawing.Color.Green
        Me.TLote.Location = New System.Drawing.Point(92, 165)
        Me.TLote.Name = "TLote"
        Me.TLote.ReadOnly = True
        Me.TLote.Size = New System.Drawing.Size(106, 21)
        Me.TLote.TabIndex = 29
        Me.TLote.Text = "----"
        Me.TLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNomMat
        '
        Me.TNomMat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNomMat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TNomMat.Location = New System.Drawing.Point(3, 128)
        Me.TNomMat.Name = "TNomMat"
        Me.TNomMat.ReadOnly = True
        Me.TNomMat.Size = New System.Drawing.Size(247, 21)
        Me.TNomMat.TabIndex = 28
        Me.TNomMat.Text = "----"
        Me.TNomMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodMat
        '
        Me.TCodMat.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodMat.ForeColor = System.Drawing.Color.Red
        Me.TCodMat.Location = New System.Drawing.Point(99, 80)
        Me.TCodMat.Name = "TCodMat"
        Me.TCodMat.ReadOnly = True
        Me.TCodMat.Size = New System.Drawing.Size(67, 26)
        Me.TCodMat.TabIndex = 27
        Me.TCodMat.Text = "0000"
        Me.TCodMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTolva
        '
        Me.TTolva.BackColor = System.Drawing.Color.White
        Me.TTolva.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTolva.ForeColor = System.Drawing.Color.Red
        Me.TTolva.Location = New System.Drawing.Point(114, 19)
        Me.TTolva.Name = "TTolva"
        Me.TTolva.ReadOnly = True
        Me.TTolva.Size = New System.Drawing.Size(67, 26)
        Me.TTolva.TabIndex = 26
        Me.TTolva.Text = "000"
        Me.TTolva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BCancelar
        '
        Me.BCancelar.Enabled = False
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(114, 234)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(74, 40)
        Me.BCancelar.TabIndex = 25
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Enabled = False
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(32, 234)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(74, 40)
        Me.BAceptar.TabIndex = 24
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(213, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 19)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Kg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 19)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 19)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Lote"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(15, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(48, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 19)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cód."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(15, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Materia Prima"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(85, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(10, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A Tolva"
        '
        'DGSoliCargue
        '
        Me.DGSoliCargue.AllowUserToAddRows = False
        Me.DGSoliCargue.AllowUserToDeleteRows = False
        Me.DGSoliCargue.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGSoliCargue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGSoliCargue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGSoliCargue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cont, Me.Tolva, Me.CodMat, Me.NomMat, Me.Lote, Me.PesoMeta, Me.TotalTolva, Me.Falta, Me.Habilitado})
        Me.DGSoliCargue.Location = New System.Drawing.Point(282, 67)
        Me.DGSoliCargue.MultiSelect = False
        Me.DGSoliCargue.Name = "DGSoliCargue"
        Me.DGSoliCargue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSoliCargue.Size = New System.Drawing.Size(845, 523)
        Me.DGSoliCargue.TabIndex = 124
        '
        'Cont
        '
        Me.Cont.HeaderText = "Cont"
        Me.Cont.Name = "Cont"
        Me.Cont.ReadOnly = True
        Me.Cont.Width = 80
        '
        'Tolva
        '
        Me.Tolva.HeaderText = "Tolva"
        Me.Tolva.Name = "Tolva"
        Me.Tolva.ReadOnly = True
        Me.Tolva.Width = 80
        '
        'CodMat
        '
        Me.CodMat.HeaderText = "Cód."
        Me.CodMat.Name = "CodMat"
        Me.CodMat.ReadOnly = True
        Me.CodMat.Width = 80
        '
        'NomMat
        '
        Me.NomMat.HeaderText = "Nombre"
        Me.NomMat.Name = "NomMat"
        Me.NomMat.ReadOnly = True
        Me.NomMat.Width = 180
        '
        'Lote
        '
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 80
        '
        'PesoMeta
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.PesoMeta.DefaultCellStyle = DataGridViewCellStyle2
        Me.PesoMeta.HeaderText = "Peso Meta "
        Me.PesoMeta.Name = "PesoMeta"
        Me.PesoMeta.ReadOnly = True
        Me.PesoMeta.Width = 80
        '
        'TotalTolva
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        Me.TotalTolva.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalTolva.HeaderText = "Total Tolva"
        Me.TotalTolva.Name = "TotalTolva"
        Me.TotalTolva.Width = 80
        '
        'Falta
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        Me.Falta.DefaultCellStyle = DataGridViewCellStyle4
        Me.Falta.HeaderText = "Falta Tolva"
        Me.Falta.Name = "Falta"
        Me.Falta.Width = 80
        '
        'Habilitado
        '
        Me.Habilitado.HeaderText = "Hab."
        Me.Habilitado.Name = "Habilitado"
        Me.Habilitado.Width = 50
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BEditar, Me.ToolStripSeparator8, Me.BNuevo, Me.ToolStripSeparator5, Me.BBorrar, Me.ToolStripSeparator6, Me.BActualizar, Me.ToolStripSeparator10, Me.BBajar, Me.ToolStripSeparator11, Me.BSubir, Me.ToolStripSeparator12, Me.BImportar, Me.ToolStripSeparator16, Me.BHabCargue, Me.ToolStripSeparator13, Me.BInhabilitar, Me.ToolStripSeparator14, Me.BImprimir, Me.ToolStripSeparator15})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1152, 25)
        Me.ToolStrip1.TabIndex = 125
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
        'BEditar
        '
        Me.BEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEditar.Image = CType(resources.GetObject("BEditar.Image"), System.Drawing.Image)
        Me.BEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEditar.Name = "BEditar"
        Me.BEditar.Size = New System.Drawing.Size(23, 22)
        Me.BEditar.Text = "Editar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'BBajar
        '
        Me.BBajar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBajar.Image = CType(resources.GetObject("BBajar.Image"), System.Drawing.Image)
        Me.BBajar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBajar.Name = "BBajar"
        Me.BBajar.Size = New System.Drawing.Size(23, 22)
        Me.BBajar.Text = "  Bajar a la siguiente posición  "
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'BSubir
        '
        Me.BSubir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSubir.Image = CType(resources.GetObject("BSubir.Image"), System.Drawing.Image)
        Me.BSubir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSubir.Name = "BSubir"
        Me.BSubir.Size = New System.Drawing.Size(23, 22)
        Me.BSubir.Text = "Subir a la siguiente posición"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'BImportar
        '
        Me.BImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImportar.Image = CType(resources.GetObject("BImportar.Image"), System.Drawing.Image)
        Me.BImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImportar.Name = "BImportar"
        Me.BImportar.Size = New System.Drawing.Size(23, 22)
        Me.BImportar.Text = "Importar Programa"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'BHabCargue
        '
        Me.BHabCargue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BHabCargue.Image = CType(resources.GetObject("BHabCargue.Image"), System.Drawing.Image)
        Me.BHabCargue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BHabCargue.Name = "BHabCargue"
        Me.BHabCargue.Size = New System.Drawing.Size(23, 22)
        Me.BHabCargue.Text = "Habilitar Todos"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'BInhabilitar
        '
        Me.BInhabilitar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BInhabilitar.Image = CType(resources.GetObject("BInhabilitar.Image"), System.Drawing.Image)
        Me.BInhabilitar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BInhabilitar.Name = "BInhabilitar"
        Me.BInhabilitar.Size = New System.Drawing.Size(23, 22)
        Me.BInhabilitar.Text = " Inhabilitar todos los registros"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'BImprimir
        '
        Me.BImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImprimir.Image = CType(resources.GetObject("BImprimir.Image"), System.Drawing.Image)
        Me.BImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImprimir.Name = "BImprimir"
        Me.BImprimir.Size = New System.Drawing.Size(23, 22)
        Me.BImprimir.Text = "Imprimir programa habilitado de vaceo"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'SolictudCargue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 602)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DGSoliCargue)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SolictudCargue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solictud de Vaceo"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGSoliCargue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TLote As System.Windows.Forms.TextBox
    Friend WithEvents TNomMat As System.Windows.Forms.TextBox
    Friend WithEvents TCodMat As System.Windows.Forms.TextBox
    Friend WithEvents TTolva As System.Windows.Forms.TextBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents DGSoliCargue As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBajar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BSubir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BHabCargue As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BInhabilitar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Cont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tolva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoMeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalTolva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Falta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Habilitado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
End Class
