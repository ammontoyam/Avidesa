<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargueMan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CargueMan))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BInicarVaceo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGSoliCargue = New System.Windows.Forms.DataGridView()
        Me.Cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tolva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TCantidad = New System.Windows.Forms.TextBox()
        Me.TLote = New System.Windows.Forms.TextBox()
        Me.TNomMat = New System.Windows.Forms.TextBox()
        Me.TCodMat = New System.Windows.Forms.TextBox()
        Me.TTolva = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TOperario = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TLoteVaceo = New System.Windows.Forms.TextBox()
        Me.TPromedio = New System.Windows.Forms.TextBox()
        Me.TBultos = New System.Windows.Forms.TextBox()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.FramEtiq = New System.Windows.Forms.GroupBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.TTrama = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TObservaciones = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGSoliCargue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.FramEtiq.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator4, Me.BEditar, Me.ToolStripSeparator5, Me.BBorrar, Me.ToolStripSeparator6, Me.BActualizar, Me.ToolStripSeparator10, Me.BInicarVaceo, Me.ToolStripSeparator8, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(955, 25)
        Me.ToolStrip1.TabIndex = 127
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'BInicarVaceo
        '
        Me.BInicarVaceo.BackColor = System.Drawing.SystemColors.Control
        Me.BInicarVaceo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BInicarVaceo.Image = CType(resources.GetObject("BInicarVaceo.Image"), System.Drawing.Image)
        Me.BInicarVaceo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BInicarVaceo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BInicarVaceo.Name = "BInicarVaceo"
        Me.BInicarVaceo.Size = New System.Drawing.Size(96, 22)
        Me.BInicarVaceo.Text = "Iniciar Vaceo"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel2.Text = "Buscar"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBBuscar
        '
        Me.CBBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscar.DropDownWidth = 80
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(75, 25)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(80, 25)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnOtros, Me.mnAcercaDe})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(955, 24)
        Me.MenuStrip1.TabIndex = 126
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
        Me.DGSoliCargue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cont, Me.Tolva, Me.CodMat, Me.NomMat, Me.Lote, Me.PesoMeta, Me.FechaIni})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGSoliCargue.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGSoliCargue.Location = New System.Drawing.Point(276, 69)
        Me.DGSoliCargue.MultiSelect = False
        Me.DGSoliCargue.Name = "DGSoliCargue"
        Me.DGSoliCargue.ReadOnly = True
        Me.DGSoliCargue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGSoliCargue.Size = New System.Drawing.Size(667, 480)
        Me.DGSoliCargue.TabIndex = 129
        '
        'Cont
        '
        Me.Cont.HeaderText = "Cont"
        Me.Cont.Name = "Cont"
        Me.Cont.ReadOnly = True
        Me.Cont.Width = 60
        '
        'Tolva
        '
        Me.Tolva.HeaderText = "Tolva"
        Me.Tolva.Name = "Tolva"
        Me.Tolva.ReadOnly = True
        Me.Tolva.Width = 60
        '
        'CodMat
        '
        Me.CodMat.HeaderText = "Cód."
        Me.CodMat.Name = "CodMat"
        Me.CodMat.ReadOnly = True
        Me.CodMat.Width = 60
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
        Me.Lote.Width = 60
        '
        'PesoMeta
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PesoMeta.DefaultCellStyle = DataGridViewCellStyle2
        Me.PesoMeta.HeaderText = "Kg"
        Me.PesoMeta.Name = "PesoMeta"
        Me.PesoMeta.ReadOnly = True
        Me.PesoMeta.Width = 60
        '
        'FechaIni
        '
        Me.FechaIni.HeaderText = "FechaIni"
        Me.FechaIni.Name = "FechaIni"
        Me.FechaIni.ReadOnly = True
        Me.FechaIni.Width = 120
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TCantidad)
        Me.Panel1.Controls.Add(Me.TLote)
        Me.Panel1.Controls.Add(Me.TNomMat)
        Me.Panel1.Controls.Add(Me.TCodMat)
        Me.Panel1.Controls.Add(Me.TTolva)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(6, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 207)
        Me.Panel1.TabIndex = 128
        '
        'TCantidad
        '
        Me.TCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TCantidad.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCantidad.ForeColor = System.Drawing.Color.Green
        Me.TCantidad.Location = New System.Drawing.Point(82, 179)
        Me.TCantidad.Name = "TCantidad"
        Me.TCantidad.ReadOnly = True
        Me.TCantidad.Size = New System.Drawing.Size(67, 21)
        Me.TCantidad.TabIndex = 30
        Me.TCantidad.Text = "----"
        Me.TCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TLote
        '
        Me.TLote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TLote.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLote.ForeColor = System.Drawing.Color.Green
        Me.TLote.Location = New System.Drawing.Point(82, 153)
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
        Me.TNomMat.Location = New System.Drawing.Point(3, 117)
        Me.TNomMat.Name = "TNomMat"
        Me.TNomMat.ReadOnly = True
        Me.TNomMat.Size = New System.Drawing.Size(247, 21)
        Me.TNomMat.TabIndex = 28
        Me.TNomMat.Text = "----"
        Me.TNomMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodMat
        '
        Me.TCodMat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodMat.ForeColor = System.Drawing.Color.Red
        Me.TCodMat.Location = New System.Drawing.Point(86, 83)
        Me.TCodMat.Name = "TCodMat"
        Me.TCodMat.ReadOnly = True
        Me.TCodMat.Size = New System.Drawing.Size(67, 21)
        Me.TCodMat.TabIndex = 27
        Me.TCodMat.Text = "0000"
        Me.TCodMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTolva
        '
        Me.TTolva.BackColor = System.Drawing.Color.White
        Me.TTolva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTolva.ForeColor = System.Drawing.Color.Red
        Me.TTolva.Location = New System.Drawing.Point(89, 26)
        Me.TTolva.Name = "TTolva"
        Me.TTolva.ReadOnly = True
        Me.TTolva.Size = New System.Drawing.Size(67, 22)
        Me.TTolva.TabIndex = 26
        Me.TTolva.Text = "000"
        Me.TTolva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(155, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Kg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Lote"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Teal
        Me.Label4.Location = New System.Drawing.Point(15, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Teal
        Me.Label3.Location = New System.Drawing.Point(48, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cód."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(15, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Materia Prima"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(60, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(10, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A Tolva"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TOperario)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TLoteVaceo)
        Me.GroupBox1.Controls.Add(Me.TPromedio)
        Me.GroupBox1.Controls.Add(Me.TBultos)
        Me.GroupBox1.Controls.Add(Me.BAceptar)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 305)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 121)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Vaceo"
        '
        'TOperario
        '
        Me.TOperario.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOperario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TOperario.Location = New System.Drawing.Point(82, 83)
        Me.TOperario.Name = "TOperario"
        Me.TOperario.ReadOnly = True
        Me.TOperario.Size = New System.Drawing.Size(114, 21)
        Me.TOperario.TabIndex = 36
        Me.TOperario.Text = "----"
        Me.TOperario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(120, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 14)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Kg"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 14)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Operario"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(124, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 14)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Lote"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 14)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Prom."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Bultos"
        '
        'TLoteVaceo
        '
        Me.TLoteVaceo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TLoteVaceo.Location = New System.Drawing.Point(156, 26)
        Me.TLoteVaceo.Name = "TLoteVaceo"
        Me.TLoteVaceo.ReadOnly = True
        Me.TLoteVaceo.Size = New System.Drawing.Size(92, 22)
        Me.TLoteVaceo.TabIndex = 28
        Me.TLoteVaceo.Text = "----"
        Me.TLoteVaceo.Visible = False
        '
        'TPromedio
        '
        Me.TPromedio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TPromedio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TPromedio.Location = New System.Drawing.Point(44, 54)
        Me.TPromedio.Name = "TPromedio"
        Me.TPromedio.Size = New System.Drawing.Size(73, 22)
        Me.TPromedio.TabIndex = 27
        Me.TPromedio.Text = "0000"
        Me.TPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBultos
        '
        Me.TBultos.ForeColor = System.Drawing.Color.Blue
        Me.TBultos.Location = New System.Drawing.Point(44, 26)
        Me.TBultos.Name = "TBultos"
        Me.TBultos.Size = New System.Drawing.Size(73, 22)
        Me.TBultos.TabIndex = 26
        Me.TBultos.Text = "0000"
        Me.TBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BAceptar
        '
        Me.BAceptar.Enabled = False
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(212, 78)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 25
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'FramEtiq
        '
        Me.FramEtiq.Controls.Add(Me.BCancelar)
        Me.FramEtiq.Controls.Add(Me.TTrama)
        Me.FramEtiq.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FramEtiq.Location = New System.Drawing.Point(300, 90)
        Me.FramEtiq.Name = "FramEtiq"
        Me.FramEtiq.Size = New System.Drawing.Size(480, 74)
        Me.FramEtiq.TabIndex = 131
        Me.FramEtiq.TabStop = False
        Me.FramEtiq.Text = "Leer Etiqueta"
        Me.FramEtiq.Visible = False
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(444, 39)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(30, 26)
        Me.BCancelar.TabIndex = 5
        Me.BCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'TTrama
        '
        Me.TTrama.Location = New System.Drawing.Point(28, 34)
        Me.TTrama.Name = "TTrama"
        Me.TTrama.Size = New System.Drawing.Size(391, 26)
        Me.TTrama.TabIndex = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(2, 430)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 14)
        Me.Label21.TabIndex = 133
        Me.Label21.Text = "Observaciones"
        '
        'TObservaciones
        '
        Me.TObservaciones.Location = New System.Drawing.Point(2, 447)
        Me.TObservaciones.Multiline = True
        Me.TObservaciones.Name = "TObservaciones"
        Me.TObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TObservaciones.Size = New System.Drawing.Size(272, 49)
        Me.TObservaciones.TabIndex = 132
        '
        'CargueMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 558)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TObservaciones)
        Me.Controls.Add(Me.FramEtiq)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGSoliCargue)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CargueMan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargue a Tolva Manual"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGSoliCargue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.FramEtiq.ResumeLayout(False)
        Me.FramEtiq.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGSoliCargue As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TCantidad As System.Windows.Forms.TextBox
    Friend WithEvents TLote As System.Windows.Forms.TextBox
    Friend WithEvents TNomMat As System.Windows.Forms.TextBox
    Friend WithEvents TCodMat As System.Windows.Forms.TextBox
    Friend WithEvents TTolva As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BInicarVaceo As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TLoteVaceo As System.Windows.Forms.TextBox
    Friend WithEvents TPromedio As System.Windows.Forms.TextBox
    Friend WithEvents TBultos As System.Windows.Forms.TextBox
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents BEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FramEtiq As System.Windows.Forms.GroupBox
    Friend WithEvents TTrama As System.Windows.Forms.TextBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Cont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tolva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoMeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOperario As System.Windows.Forms.TextBox
End Class
