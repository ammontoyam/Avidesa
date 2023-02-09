<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecibePT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecibePT))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.BImprimir = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SCRecibePT = New System.Windows.Forms.SplitContainer()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TObservProceso = New System.Windows.Forms.TextBox()
        Me.GBObserv = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TObsAlmacen = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TObsCalidad = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TObsProduccion = New System.Windows.Forms.TextBox()
        Me.GBDatosEmpaque = New System.Windows.Forms.GroupBox()
        Me.TUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TDetalle = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TUsuarioRecCal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TUsuarioRecProd = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TFechaRecCal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TFechaRecProd = New System.Windows.Forms.TextBox()
        Me.TBodega = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TPeso = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TFechaUEmp = New System.Windows.Forms.TextBox()
        Me.TSacos = New System.Windows.Forms.TextBox()
        Me.TNomProd = New System.Windows.Forms.TextBox()
        Me.TCodProd = New System.Windows.Forms.TextBox()
        Me.TOPEmp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBProceso3 = New System.Windows.Forms.RadioButton()
        Me.RBProceso2 = New System.Windows.Forms.RadioButton()
        Me.RBProceso1 = New System.Windows.Forms.RadioButton()
        Me.ChAceptarSel = New System.Windows.Forms.CheckBox()
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.ChAceptados = New System.Windows.Forms.CheckBox()
        Me.TSumSacos = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GBFiltro = New System.Windows.Forms.GroupBox()
        Me.OpVerSolo = New System.Windows.Forms.RadioButton()
        Me.DGEmpaque = New System.Windows.Forms.DataGridView()
        Me.ColAceptar_NI_ = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodProd2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresKg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresEmp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SacosTot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoTot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SacosNC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoReProceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CtModCodProd2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnModCodProd2Emp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SCRecibePT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCRecibePT.Panel1.SuspendLayout()
        Me.SCRecibePT.Panel2.SuspendLayout()
        Me.SCRecibePT.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GBObserv.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GBDatosEmpaque.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GBFiltro.SuspendLayout()
        CType(Me.DGEmpaque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CtModCodProd2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator4, Me.BActualizar, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar, Me.BImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1344, 25)
        Me.ToolStrip1.TabIndex = 30
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
        'BActualizar
        '
        Me.BActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActualizar.Image = CType(resources.GetObject("BActualizar.Image"), System.Drawing.Image)
        Me.BActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BActualizar.Name = "BActualizar"
        Me.BActualizar.Size = New System.Drawing.Size(23, 22)
        Me.BActualizar.Text = "Actualizar"
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
        Me.CBBuscar.Size = New System.Drawing.Size(125, 25)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(125, 25)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'BImprimir
        '
        Me.BImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImprimir.Image = CType(resources.GetObject("BImprimir.Image"), System.Drawing.Image)
        Me.BImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImprimir.Name = "BImprimir"
        Me.BImprimir.Size = New System.Drawing.Size(23, 22)
        Me.BImprimir.ToolTipText = " Imprimir listado pendiente por recibir"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1344, 24)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
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
        'SCRecibePT
        '
        Me.SCRecibePT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCRecibePT.Location = New System.Drawing.Point(0, 49)
        Me.SCRecibePT.Name = "SCRecibePT"
        '
        'SCRecibePT.Panel1
        '
        Me.SCRecibePT.Panel1.Controls.Add(Me.GroupBox6)
        Me.SCRecibePT.Panel1.Controls.Add(Me.GBObserv)
        Me.SCRecibePT.Panel1.Controls.Add(Me.GBDatosEmpaque)
        Me.SCRecibePT.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SCRecibePT.Panel2
        '
        Me.SCRecibePT.Panel2.Controls.Add(Me.ChAceptarSel)
        Me.SCRecibePT.Panel2.Controls.Add(Me.FRefrescaDG)
        Me.SCRecibePT.Panel2.Controls.Add(Me.ChAceptados)
        Me.SCRecibePT.Panel2.Controls.Add(Me.TSumSacos)
        Me.SCRecibePT.Panel2.Controls.Add(Me.Label15)
        Me.SCRecibePT.Panel2.Controls.Add(Me.GBFiltro)
        Me.SCRecibePT.Panel2.Controls.Add(Me.DGEmpaque)
        Me.SCRecibePT.Size = New System.Drawing.Size(1344, 607)
        Me.SCRecibePT.SplitterDistance = 472
        Me.SCRecibePT.TabIndex = 32
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.BCancelar)
        Me.GroupBox6.Controls.Add(Me.BAceptar)
        Me.GroupBox6.Controls.Add(Me.TObservProceso)
        Me.GroupBox6.Location = New System.Drawing.Point(22, 523)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(444, 75)
        Me.GroupBox6.TabIndex = 41
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Observaciones proceso"
        '
        'BCancelar
        '
        Me.BCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(389, 29)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(52, 40)
        Me.BCancelar.TabIndex = 89
        Me.BCancelar.UseVisualStyleBackColor = False
        '
        'BAceptar
        '
        Me.BAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(331, 29)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(52, 40)
        Me.BAceptar.TabIndex = 88
        Me.BAceptar.UseVisualStyleBackColor = False
        '
        'TObservProceso
        '
        Me.TObservProceso.BackColor = System.Drawing.Color.White
        Me.TObservProceso.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObservProceso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TObservProceso.Location = New System.Drawing.Point(7, 19)
        Me.TObservProceso.Multiline = True
        Me.TObservProceso.Name = "TObservProceso"
        Me.TObservProceso.Size = New System.Drawing.Size(322, 50)
        Me.TObservProceso.TabIndex = 16
        Me.TObservProceso.WordWrap = False
        '
        'GBObserv
        '
        Me.GBObserv.Controls.Add(Me.GroupBox3)
        Me.GBObserv.Controls.Add(Me.GroupBox5)
        Me.GBObserv.Controls.Add(Me.GroupBox4)
        Me.GBObserv.Enabled = False
        Me.GBObserv.Location = New System.Drawing.Point(22, 305)
        Me.GBObserv.Name = "GBObserv"
        Me.GBObserv.Size = New System.Drawing.Size(444, 214)
        Me.GBObserv.TabIndex = 40
        Me.GBObserv.TabStop = False
        Me.GBObserv.Text = "Observaciones otros procesos"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TObsAlmacen)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 143)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(422, 59)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Almacen"
        '
        'TObsAlmacen
        '
        Me.TObsAlmacen.BackColor = System.Drawing.Color.White
        Me.TObsAlmacen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObsAlmacen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TObsAlmacen.Location = New System.Drawing.Point(6, 13)
        Me.TObsAlmacen.Multiline = True
        Me.TObsAlmacen.Name = "TObsAlmacen"
        Me.TObsAlmacen.ReadOnly = True
        Me.TObsAlmacen.Size = New System.Drawing.Size(401, 34)
        Me.TObsAlmacen.TabIndex = 15
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TObsCalidad)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 81)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(422, 59)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Calidad"
        '
        'TObsCalidad
        '
        Me.TObsCalidad.BackColor = System.Drawing.Color.White
        Me.TObsCalidad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObsCalidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TObsCalidad.Location = New System.Drawing.Point(6, 13)
        Me.TObsCalidad.Multiline = True
        Me.TObsCalidad.Name = "TObsCalidad"
        Me.TObsCalidad.ReadOnly = True
        Me.TObsCalidad.Size = New System.Drawing.Size(401, 34)
        Me.TObsCalidad.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TObsProduccion)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(422, 59)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Producción"
        '
        'TObsProduccion
        '
        Me.TObsProduccion.BackColor = System.Drawing.Color.White
        Me.TObsProduccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObsProduccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TObsProduccion.Location = New System.Drawing.Point(6, 13)
        Me.TObsProduccion.Multiline = True
        Me.TObsProduccion.Name = "TObsProduccion"
        Me.TObsProduccion.ReadOnly = True
        Me.TObsProduccion.Size = New System.Drawing.Size(401, 34)
        Me.TObsProduccion.TabIndex = 15
        '
        'GBDatosEmpaque
        '
        Me.GBDatosEmpaque.Controls.Add(Me.TUbicacion)
        Me.GBDatosEmpaque.Controls.Add(Me.Label12)
        Me.GBDatosEmpaque.Controls.Add(Me.Label5)
        Me.GBDatosEmpaque.Controls.Add(Me.TDetalle)
        Me.GBDatosEmpaque.Controls.Add(Me.GroupBox7)
        Me.GBDatosEmpaque.Controls.Add(Me.GroupBox2)
        Me.GBDatosEmpaque.Controls.Add(Me.TBodega)
        Me.GBDatosEmpaque.Controls.Add(Me.Label2)
        Me.GBDatosEmpaque.Controls.Add(Me.TPeso)
        Me.GBDatosEmpaque.Controls.Add(Me.Label13)
        Me.GBDatosEmpaque.Controls.Add(Me.TFechaUEmp)
        Me.GBDatosEmpaque.Controls.Add(Me.TSacos)
        Me.GBDatosEmpaque.Controls.Add(Me.TNomProd)
        Me.GBDatosEmpaque.Controls.Add(Me.TCodProd)
        Me.GBDatosEmpaque.Controls.Add(Me.TOPEmp)
        Me.GBDatosEmpaque.Controls.Add(Me.Label7)
        Me.GBDatosEmpaque.Controls.Add(Me.Label6)
        Me.GBDatosEmpaque.Controls.Add(Me.Label4)
        Me.GBDatosEmpaque.Controls.Add(Me.Label3)
        Me.GBDatosEmpaque.Controls.Add(Me.Label1)
        Me.GBDatosEmpaque.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBDatosEmpaque.Location = New System.Drawing.Point(22, 58)
        Me.GBDatosEmpaque.Name = "GBDatosEmpaque"
        Me.GBDatosEmpaque.Size = New System.Drawing.Size(442, 242)
        Me.GBDatosEmpaque.TabIndex = 39
        Me.GBDatosEmpaque.TabStop = False
        Me.GBDatosEmpaque.Text = "Datos de Empaque"
        '
        'TUbicacion
        '
        Me.TUbicacion.FormattingEnabled = True
        Me.TUbicacion.Location = New System.Drawing.Point(276, 118)
        Me.TUbicacion.Name = "TUbicacion"
        Me.TUbicacion.Size = New System.Drawing.Size(100, 24)
        Me.TUbicacion.TabIndex = 48
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(197, 123)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 16)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Ubicación:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(196, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 14)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Último Empaque:"
        '
        'TDetalle
        '
        Me.TDetalle.BackColor = System.Drawing.Color.White
        Me.TDetalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDetalle.Location = New System.Drawing.Point(304, 21)
        Me.TDetalle.Name = "TDetalle"
        Me.TDetalle.ReadOnly = True
        Me.TDetalle.Size = New System.Drawing.Size(100, 20)
        Me.TDetalle.TabIndex = 45
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.TUsuarioRecCal)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.TUsuarioRecProd)
        Me.GroupBox7.Location = New System.Drawing.Point(231, 151)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(205, 84)
        Me.GroupBox7.TabIndex = 44
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Usuarios Recibo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 14)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Calidad:"
        '
        'TUsuarioRecCal
        '
        Me.TUsuarioRecCal.BackColor = System.Drawing.Color.White
        Me.TUsuarioRecCal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUsuarioRecCal.Location = New System.Drawing.Point(93, 50)
        Me.TUsuarioRecCal.Name = "TUsuarioRecCal"
        Me.TUsuarioRecCal.ReadOnly = True
        Me.TUsuarioRecCal.Size = New System.Drawing.Size(100, 20)
        Me.TUsuarioRecCal.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Producción:"
        '
        'TUsuarioRecProd
        '
        Me.TUsuarioRecProd.BackColor = System.Drawing.Color.White
        Me.TUsuarioRecProd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUsuarioRecProd.Location = New System.Drawing.Point(93, 29)
        Me.TUsuarioRecProd.Name = "TUsuarioRecProd"
        Me.TUsuarioRecProd.ReadOnly = True
        Me.TUsuarioRecProd.Size = New System.Drawing.Size(100, 20)
        Me.TUsuarioRecProd.TabIndex = 18
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TFechaRecCal)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TFechaRecProd)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(207, 84)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fechas Recibo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 14)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Calidad:"
        '
        'TFechaRecCal
        '
        Me.TFechaRecCal.BackColor = System.Drawing.Color.White
        Me.TFechaRecCal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaRecCal.Location = New System.Drawing.Point(91, 50)
        Me.TFechaRecCal.Name = "TFechaRecCal"
        Me.TFechaRecCal.ReadOnly = True
        Me.TFechaRecCal.Size = New System.Drawing.Size(107, 20)
        Me.TFechaRecCal.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 14)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Producción:"
        '
        'TFechaRecProd
        '
        Me.TFechaRecProd.BackColor = System.Drawing.Color.White
        Me.TFechaRecProd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaRecProd.Location = New System.Drawing.Point(91, 29)
        Me.TFechaRecProd.Name = "TFechaRecProd"
        Me.TFechaRecProd.ReadOnly = True
        Me.TFechaRecProd.Size = New System.Drawing.Size(107, 20)
        Me.TFechaRecProd.TabIndex = 18
        '
        'TBodega
        '
        Me.TBodega.FormattingEnabled = True
        Me.TBodega.Location = New System.Drawing.Point(100, 121)
        Me.TBodega.Name = "TBodega"
        Me.TBodega.Size = New System.Drawing.Size(82, 24)
        Me.TBodega.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Producto:"
        '
        'TPeso
        '
        Me.TPeso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TPeso.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPeso.Location = New System.Drawing.Point(276, 96)
        Me.TPeso.Name = "TPeso"
        Me.TPeso.ReadOnly = True
        Me.TPeso.Size = New System.Drawing.Size(100, 20)
        Me.TPeso.TabIndex = 18
        Me.TPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(198, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Peso (Kg):"
        '
        'TFechaUEmp
        '
        Me.TFechaUEmp.BackColor = System.Drawing.Color.White
        Me.TFechaUEmp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaUEmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TFechaUEmp.Location = New System.Drawing.Point(304, 47)
        Me.TFechaUEmp.Name = "TFechaUEmp"
        Me.TFechaUEmp.ReadOnly = True
        Me.TFechaUEmp.Size = New System.Drawing.Size(100, 20)
        Me.TFechaUEmp.TabIndex = 13
        '
        'TSacos
        '
        Me.TSacos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSacos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSacos.Location = New System.Drawing.Point(101, 96)
        Me.TSacos.Name = "TSacos"
        Me.TSacos.ReadOnly = True
        Me.TSacos.Size = New System.Drawing.Size(81, 20)
        Me.TSacos.TabIndex = 12
        Me.TSacos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TNomProd
        '
        Me.TNomProd.BackColor = System.Drawing.SystemColors.Control
        Me.TNomProd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNomProd.Location = New System.Drawing.Point(101, 73)
        Me.TNomProd.Name = "TNomProd"
        Me.TNomProd.ReadOnly = True
        Me.TNomProd.Size = New System.Drawing.Size(228, 21)
        Me.TNomProd.TabIndex = 11
        '
        'TCodProd
        '
        Me.TCodProd.BackColor = System.Drawing.SystemColors.Control
        Me.TCodProd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodProd.Location = New System.Drawing.Point(101, 49)
        Me.TCodProd.Name = "TCodProd"
        Me.TCodProd.ReadOnly = True
        Me.TCodProd.Size = New System.Drawing.Size(81, 21)
        Me.TCodProd.TabIndex = 10
        '
        'TOPEmp
        '
        Me.TOPEmp.BackColor = System.Drawing.Color.White
        Me.TOPEmp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPEmp.Location = New System.Drawing.Point(101, 25)
        Me.TOPEmp.Name = "TOPEmp"
        Me.TOPEmp.ReadOnly = True
        Me.TOPEmp.Size = New System.Drawing.Size(81, 22)
        Me.TOPEmp.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(226, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Detalle:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Bodega:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Sacos:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OP:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBProceso3)
        Me.GroupBox1.Controls.Add(Me.RBProceso2)
        Me.GroupBox1.Controls.Add(Me.RBProceso1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 50)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proceso"
        '
        'RBProceso3
        '
        Me.RBProceso3.AutoSize = True
        Me.RBProceso3.Location = New System.Drawing.Point(324, 20)
        Me.RBProceso3.Name = "RBProceso3"
        Me.RBProceso3.Size = New System.Drawing.Size(66, 17)
        Me.RBProceso3.TabIndex = 2
        Me.RBProceso3.Text = "Almacen"
        Me.RBProceso3.UseVisualStyleBackColor = True
        '
        'RBProceso2
        '
        Me.RBProceso2.AutoSize = True
        Me.RBProceso2.Location = New System.Drawing.Point(178, 20)
        Me.RBProceso2.Name = "RBProceso2"
        Me.RBProceso2.Size = New System.Drawing.Size(60, 17)
        Me.RBProceso2.TabIndex = 1
        Me.RBProceso2.Text = "Calidad"
        Me.RBProceso2.UseVisualStyleBackColor = True
        '
        'RBProceso1
        '
        Me.RBProceso1.AutoSize = True
        Me.RBProceso1.Checked = True
        Me.RBProceso1.Location = New System.Drawing.Point(28, 20)
        Me.RBProceso1.Name = "RBProceso1"
        Me.RBProceso1.Size = New System.Drawing.Size(79, 17)
        Me.RBProceso1.TabIndex = 0
        Me.RBProceso1.TabStop = True
        Me.RBProceso1.Text = "Producción"
        Me.RBProceso1.UseVisualStyleBackColor = True
        '
        'ChAceptarSel
        '
        Me.ChAceptarSel.AutoSize = True
        Me.ChAceptarSel.Location = New System.Drawing.Point(11, 132)
        Me.ChAceptarSel.Name = "ChAceptarSel"
        Me.ChAceptarSel.Size = New System.Drawing.Size(176, 17)
        Me.ChAceptarSel.TabIndex = 85
        Me.ChAceptarSel.Text = "Aceptar registros seleccionados"
        Me.ChAceptarSel.UseVisualStyleBackColor = True
        '
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(11, 186)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(101, 23)
        Me.FRefrescaDG.TabIndex = 84
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'ChAceptados
        '
        Me.ChAceptados.AutoSize = True
        Me.ChAceptados.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ChAceptados.Location = New System.Drawing.Point(236, 571)
        Me.ChAceptados.Name = "ChAceptados"
        Me.ChAceptados.Size = New System.Drawing.Size(132, 18)
        Me.ChAceptados.TabIndex = 83
        Me.ChAceptados.Text = "Ver solo aceptados"
        Me.ChAceptados.UseVisualStyleBackColor = True
        '
        'TSumSacos
        '
        Me.TSumSacos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSumSacos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSumSacos.Location = New System.Drawing.Point(133, 569)
        Me.TSumSacos.Name = "TSumSacos"
        Me.TSumSacos.ReadOnly = True
        Me.TSumSacos.Size = New System.Drawing.Size(81, 20)
        Me.TSumSacos.TabIndex = 82
        Me.TSumSacos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.Location = New System.Drawing.Point(10, 567)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 23)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "Total sacos"
        '
        'GBFiltro
        '
        Me.GBFiltro.Controls.Add(Me.OpVerSolo)
        Me.GBFiltro.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBFiltro.Location = New System.Drawing.Point(11, 13)
        Me.GBFiltro.Name = "GBFiltro"
        Me.GBFiltro.Size = New System.Drawing.Size(832, 110)
        Me.GBFiltro.TabIndex = 38
        Me.GBFiltro.TabStop = False
        Me.GBFiltro.Text = "Ver Solo..."
        '
        'OpVerSolo
        '
        Me.OpVerSolo.AutoSize = True
        Me.OpVerSolo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpVerSolo.Location = New System.Drawing.Point(581, 26)
        Me.OpVerSolo.Name = "OpVerSolo"
        Me.OpVerSolo.Size = New System.Drawing.Size(145, 18)
        Me.OpVerSolo.TabIndex = 4
        Me.OpVerSolo.TabStop = True
        Me.OpVerSolo.Text = "12345678901234567890"
        Me.OpVerSolo.UseVisualStyleBackColor = True
        Me.OpVerSolo.Visible = False
        '
        'DGEmpaque
        '
        Me.DGEmpaque.AllowUserToAddRows = False
        Me.DGEmpaque.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmpaque.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGEmpaque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEmpaque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColAceptar_NI_, Me.Cont, Me.OP, Me.CodProd, Me.CodProd2, Me.CodEmp, Me.NomProd, Me.PresKg, Me.PresEmp, Me.SacosTot, Me.FechaFin, Me.PesoTot, Me.Destino, Me.Destino2, Me.SacosNC, Me.PesoReProceso})
        Me.DGEmpaque.ContextMenuStrip = Me.CtModCodProd2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEmpaque.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGEmpaque.Location = New System.Drawing.Point(11, 155)
        Me.DGEmpaque.Name = "DGEmpaque"
        Me.DGEmpaque.ReadOnly = True
        Me.DGEmpaque.RowHeadersVisible = False
        Me.DGEmpaque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEmpaque.Size = New System.Drawing.Size(836, 401)
        Me.DGEmpaque.TabIndex = 37
        '
        'ColAceptar_NI_
        '
        Me.ColAceptar_NI_.HeaderText = "Aceptar"
        Me.ColAceptar_NI_.Name = "ColAceptar_NI_"
        Me.ColAceptar_NI_.ReadOnly = True
        Me.ColAceptar_NI_.Width = 50
        '
        'Cont
        '
        Me.Cont.HeaderText = "Cont"
        Me.Cont.Name = "Cont"
        Me.Cont.ReadOnly = True
        Me.Cont.Visible = False
        Me.Cont.Width = 60
        '
        'OP
        '
        Me.OP.HeaderText = "OP"
        Me.OP.Name = "OP"
        Me.OP.ReadOnly = True
        Me.OP.Width = 60
        '
        'CodProd
        '
        Me.CodProd.HeaderText = "Producto"
        Me.CodProd.Name = "CodProd"
        Me.CodProd.ReadOnly = True
        Me.CodProd.Width = 60
        '
        'CodProd2
        '
        Me.CodProd2.HeaderText = "Producto2"
        Me.CodProd2.Name = "CodProd2"
        Me.CodProd2.ReadOnly = True
        Me.CodProd2.Width = 60
        '
        'CodEmp
        '
        Me.CodEmp.HeaderText = "CodEmp"
        Me.CodEmp.Name = "CodEmp"
        Me.CodEmp.ReadOnly = True
        Me.CodEmp.Width = 60
        '
        'NomProd
        '
        Me.NomProd.HeaderText = "NomProd"
        Me.NomProd.Name = "NomProd"
        Me.NomProd.ReadOnly = True
        '
        'PresKg
        '
        Me.PresKg.HeaderText = "Pres"
        Me.PresKg.Name = "PresKg"
        Me.PresKg.ReadOnly = True
        Me.PresKg.Width = 40
        '
        'PresEmp
        '
        Me.PresEmp.HeaderText = "Pres."
        Me.PresEmp.Name = "PresEmp"
        Me.PresEmp.ReadOnly = True
        Me.PresEmp.Width = 40
        '
        'SacosTot
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.SacosTot.DefaultCellStyle = DataGridViewCellStyle2
        Me.SacosTot.HeaderText = "Sacos"
        Me.SacosTot.Name = "SacosTot"
        Me.SacosTot.ReadOnly = True
        Me.SacosTot.Width = 40
        '
        'FechaFin
        '
        Me.FechaFin.HeaderText = "FechaFin"
        Me.FechaFin.Name = "FechaFin"
        Me.FechaFin.ReadOnly = True
        Me.FechaFin.Width = 80
        '
        'PesoTot
        '
        Me.PesoTot.HeaderText = "Peso"
        Me.PesoTot.Name = "PesoTot"
        Me.PesoTot.ReadOnly = True
        Me.PesoTot.Width = 50
        '
        'Destino
        '
        Me.Destino.HeaderText = "Destino"
        Me.Destino.Name = "Destino"
        Me.Destino.ReadOnly = True
        Me.Destino.Width = 50
        '
        'Destino2
        '
        Me.Destino2.HeaderText = "Destino2"
        Me.Destino2.Name = "Destino2"
        Me.Destino2.ReadOnly = True
        Me.Destino2.Width = 50
        '
        'SacosNC
        '
        Me.SacosNC.HeaderText = "SacosNC"
        Me.SacosNC.Name = "SacosNC"
        Me.SacosNC.ReadOnly = True
        Me.SacosNC.Width = 60
        '
        'PesoReProceso
        '
        Me.PesoReProceso.HeaderText = "PesoRep."
        Me.PesoReProceso.Name = "PesoReProceso"
        Me.PesoReProceso.ReadOnly = True
        Me.PesoReProceso.Width = 80
        '
        'CtModCodProd2
        '
        Me.CtModCodProd2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnModCodProd2Emp})
        Me.CtModCodProd2.Name = "CtModCodProd2"
        Me.CtModCodProd2.Size = New System.Drawing.Size(185, 26)
        Me.CtModCodProd2.Text = "Modifcar CodProd2"
        '
        'mnModCodProd2Emp
        '
        Me.mnModCodProd2Emp.Image = CType(resources.GetObject("mnModCodProd2Emp.Image"), System.Drawing.Image)
        Me.mnModCodProd2Emp.Name = "mnModCodProd2Emp"
        Me.mnModCodProd2Emp.Size = New System.Drawing.Size(184, 22)
        Me.mnModCodProd2Emp.Text = "Modificar CodProd 2"
        '
        'RecibePT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1344, 656)
        Me.Controls.Add(Me.SCRecibePT)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RecibePT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RecibePT"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SCRecibePT.Panel1.ResumeLayout(False)
        Me.SCRecibePT.Panel2.ResumeLayout(False)
        Me.SCRecibePT.Panel2.PerformLayout()
        CType(Me.SCRecibePT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCRecibePT.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GBObserv.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GBDatosEmpaque.ResumeLayout(False)
        Me.GBDatosEmpaque.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GBFiltro.ResumeLayout(False)
        Me.GBFiltro.PerformLayout()
        CType(Me.DGEmpaque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CtModCodProd2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents CBBuscar As ToolStripComboBox
    Friend WithEvents TBuscar As ToolStripTextBox
    Friend WithEvents BImprimir As ToolStripButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SCRecibePT As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RBProceso3 As RadioButton
    Friend WithEvents RBProceso2 As RadioButton
    Friend WithEvents RBProceso1 As RadioButton
    Friend WithEvents GBDatosEmpaque As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TPeso As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TFechaUEmp As TextBox
    Friend WithEvents TSacos As TextBox
    Friend WithEvents TNomProd As TextBox
    Friend WithEvents TCodProd As TextBox
    Friend WithEvents TOPEmp As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GBObserv As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TObservProceso As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TObsCalidad As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TObsProduccion As TextBox
    Friend WithEvents DGEmpaque As DataGridView
    Friend WithEvents GBFiltro As GroupBox
    Friend WithEvents OpVerSolo As RadioButton
    Friend WithEvents ChAceptados As CheckBox
    Friend WithEvents TSumSacos As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TObsAlmacen As TextBox
    Friend WithEvents FRefrescaDG As Button
    Friend WithEvents ChAceptarSel As CheckBox
    Friend WithEvents TBodega As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TFechaRecCal As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TFechaRecProd As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TDetalle As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TUsuarioRecCal As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TUsuarioRecProd As TextBox
    Friend WithEvents CtModCodProd2 As ContextMenuStrip
    Friend WithEvents mnModCodProd2Emp As ToolStripMenuItem
    Friend WithEvents BCancelar As Button
    Friend WithEvents BAceptar As Button
    Friend WithEvents ColAceptar_NI_ As DataGridViewCheckBoxColumn
    Friend WithEvents Cont As DataGridViewTextBoxColumn
    Friend WithEvents OP As DataGridViewTextBoxColumn
    Friend WithEvents CodProd As DataGridViewTextBoxColumn
    Friend WithEvents CodProd2 As DataGridViewTextBoxColumn
    Friend WithEvents CodEmp As DataGridViewTextBoxColumn
    Friend WithEvents NomProd As DataGridViewTextBoxColumn
    Friend WithEvents PresKg As DataGridViewTextBoxColumn
    Friend WithEvents PresEmp As DataGridViewTextBoxColumn
    Friend WithEvents SacosTot As DataGridViewTextBoxColumn
    Friend WithEvents FechaFin As DataGridViewTextBoxColumn
    Friend WithEvents PesoTot As DataGridViewTextBoxColumn
    Friend WithEvents Destino As DataGridViewTextBoxColumn
    Friend WithEvents Destino2 As DataGridViewTextBoxColumn
    Friend WithEvents SacosNC As DataGridViewTextBoxColumn
    Friend WithEvents PesoReProceso As DataGridViewTextBoxColumn
    Friend WithEvents TUbicacion As ComboBox
    Friend WithEvents Label12 As Label
End Class
