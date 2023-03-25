<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Productos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnInterfazArt = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarArticulosDetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGProd = New System.Windows.Forms.DataGridView()
        Me.CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACTIVO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PresKg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GRANEL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
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
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.BImprimir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.GroupBox()
        Me.TTamDescarga = New System.Windows.Forms.TextBox()
        Me.CBCodDescarga = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TPorcMerma = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TAlimFina = New System.Windows.Forms.TextBox()
        Me.ChGranel = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TNomDescarga = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TCodHilo = New System.Windows.Forms.TextBox()
        Me.ChPaqueteo = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TRegIca = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TDensidad = New System.Windows.Forms.TextBox()
        Me.TCodMaq = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TRef = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ChActivo = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCodEtiq = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCodEmp = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CBPreskg = New System.Windows.Forms.ComboBox()
        Me.CBEmpaque = New System.Windows.Forms.ComboBox()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.CBTextura = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCodInt = New System.Windows.Forms.TextBox()
        Me.GBLinea = New System.Windows.Forms.GroupBox()
        Me.CLinea = New System.Windows.Forms.ComboBox()
        Me.GBPaqueteo = New System.Windows.Forms.GroupBox()
        Me.TUdsPaca = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TCodEtiqBolsa = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TCodEmpBolsa = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TVencxLinea = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TVencxProd = New System.Windows.Forms.TextBox()
        Me.TObserv = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DGEmpaques = New System.Windows.Forms.DataGridView()
        Me.DGEmpaques_CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEmpaques_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.TabProductosDet = New System.Windows.Forms.TabControl()
        Me.CodigosEquivalentes = New System.Windows.Forms.TabPage()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BEditarEquiv = New System.Windows.Forms.Button()
        Me.BBorrarEquiv = New System.Windows.Forms.Button()
        Me.BNuevaEquiv = New System.Windows.Forms.Button()
        Me.GBEquivalencias = New System.Windows.Forms.GroupBox()
        Me.TPresKgEquiv = New System.Windows.Forms.ComboBox()
        Me.LPesoEquiv = New System.Windows.Forms.Label()
        Me.BCancelarEquiv = New System.Windows.Forms.Button()
        Me.BAceptarEquiv = New System.Windows.Forms.Button()
        Me.TEquivalencia = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CBPresent = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DGEquivalencias = New System.Windows.Forms.DataGridView()
        Me.DGEquivalencias_CodProdEqui = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEquivalencias_Present = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEquivalencias_PresKg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatosPeletizado = New System.Windows.Forms.TabPage()
        Me.TMalla12 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TMalla30 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TMalla6 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TDurabilidad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TDureza = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TMalla8 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TMalla16 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TPorcPlato = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ArticulosDet = New System.Windows.Forms.TabPage()
        Me.FRefrescaDGArticulosDet = New System.Windows.Forms.Button()
        Me.DGArticulosDet = New System.Windows.Forms.DataGridView()
        Me.DGArticulosDet_CodIntDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGArticulosDet_NombreDet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FRefrescaDGEmp = New System.Windows.Forms.Button()
        Me.DGEmpaques2 = New System.Windows.Forms.DataGridView()
        Me.DGEmpaques2_CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEmpaques2_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TSOrgProg = New System.Windows.Forms.ToolStrip()
        Me.BAdicionaEmp = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEliminaEmp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.CBBuscarEmp = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscarEmp = New System.Windows.Forms.ToolStripTextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GBLinea.SuspendLayout()
        Me.GBPaqueteo.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGEmpaques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabProductosDet.SuspendLayout()
        Me.CodigosEquivalentes.SuspendLayout()
        Me.GBEquivalencias.SuspendLayout()
        CType(Me.DGEquivalencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DatosPeletizado.SuspendLayout()
        Me.ArticulosDet.SuspendLayout()
        CType(Me.DGArticulosDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGEmpaques2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOrgProg.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.MaterialesToolStripMenuItem, Me.mnInterfazArt, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(919, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSalir})
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(81, 24)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'MaterialesToolStripMenuItem
        '
        Me.MaterialesToolStripMenuItem.Image = CType(resources.GetObject("MaterialesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MaterialesToolStripMenuItem.Name = "MaterialesToolStripMenuItem"
        Me.MaterialesToolStripMenuItem.Size = New System.Drawing.Size(97, 24)
        Me.MaterialesToolStripMenuItem.Text = "Materiales"
        Me.MaterialesToolStripMenuItem.Visible = False
        '
        'mnInterfazArt
        '
        Me.mnInterfazArt.Name = "mnInterfazArt"
        Me.mnInterfazArt.Size = New System.Drawing.Size(114, 24)
        Me.mnInterfazArt.Text = "Interfaz Artículos"
        Me.mnInterfazArt.Visible = False
        '
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurarArticulosDetToolStripMenuItem})
        Me.OtrosToolStripMenuItem.Image = CType(resources.GetObject("OtrosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(70, 24)
        Me.OtrosToolStripMenuItem.Text = "Otros"
        Me.OtrosToolStripMenuItem.Visible = False
        '
        'ConfigurarArticulosDetToolStripMenuItem
        '
        Me.ConfigurarArticulosDetToolStripMenuItem.Name = "ConfigurarArticulosDetToolStripMenuItem"
        Me.ConfigurarArticulosDetToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ConfigurarArticulosDetToolStripMenuItem.Text = "Configurar ArticulosDet"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Image = CType(resources.GetObject("AcercaDeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(106, 24)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de...."
        Me.AcercaDeToolStripMenuItem.Visible = False
        '
        'DGProd
        '
        Me.DGProd.AllowUserToAddRows = False
        Me.DGProd.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGProd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodInt, Me.Nombre, Me.ACTIVO, Me.PresKg, Me.GRANEL})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGProd.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGProd.Location = New System.Drawing.Point(435, 83)
        Me.DGProd.Name = "DGProd"
        Me.DGProd.ReadOnly = True
        Me.DGProd.RowHeadersWidth = 25
        Me.DGProd.Size = New System.Drawing.Size(475, 410)
        Me.DGProd.TabIndex = 3
        '
        'CodInt
        '
        Me.CodInt.DataPropertyName = "CODPROD"
        Me.CodInt.HeaderText = "Código"
        Me.CodInt.Name = "CodInt"
        Me.CodInt.ReadOnly = True
        Me.CodInt.Width = 80
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "NOMPROD"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 200
        '
        'ACTIVO
        '
        Me.ACTIVO.HeaderText = "Activo"
        Me.ACTIVO.Name = "ACTIVO"
        Me.ACTIVO.ReadOnly = True
        Me.ACTIVO.Width = 45
        '
        'PresKg
        '
        Me.PresKg.DataPropertyName = "PRESKG"
        Me.PresKg.HeaderText = "Present"
        Me.PresKg.Name = "PresKg"
        Me.PresKg.ReadOnly = True
        Me.PresKg.Width = 60
        '
        'GRANEL
        '
        Me.GRANEL.HeaderText = "Granel"
        Me.GRANEL.Name = "GRANEL"
        Me.GRANEL.ReadOnly = True
        Me.GRANEL.Width = 45
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BEditar, Me.ToolStripSeparator8, Me.BNuevo, Me.ToolStripSeparator5, Me.BBorrar, Me.ToolStripSeparator6, Me.BActualizar, Me.ToolStripSeparator10, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar, Me.BImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(919, 27)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BSalir
        '
        Me.BSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSalir.Image = CType(resources.GetObject("BSalir.Image"), System.Drawing.Image)
        Me.BSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(24, 24)
        Me.BSalir.Text = "Salir"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 27)
        '
        'BEditar
        '
        Me.BEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEditar.Image = CType(resources.GetObject("BEditar.Image"), System.Drawing.Image)
        Me.BEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEditar.Name = "BEditar"
        Me.BEditar.Size = New System.Drawing.Size(24, 24)
        Me.BEditar.Text = "Editar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 27)
        '
        'BNuevo
        '
        Me.BNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BNuevo.Image = CType(resources.GetObject("BNuevo.Image"), System.Drawing.Image)
        Me.BNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(24, 24)
        Me.BNuevo.Text = "Nuevo"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
        '
        'BBorrar
        '
        Me.BBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBorrar.Image = CType(resources.GetObject("BBorrar.Image"), System.Drawing.Image)
        Me.BBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBorrar.Name = "BBorrar"
        Me.BBorrar.Size = New System.Drawing.Size(24, 24)
        Me.BBorrar.Text = "Borrar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
        '
        'BActualizar
        '
        Me.BActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActualizar.Image = CType(resources.GetObject("BActualizar.Image"), System.Drawing.Image)
        Me.BActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BActualizar.Name = "BActualizar"
        Me.BActualizar.Size = New System.Drawing.Size(24, 24)
        Me.BActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 27)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(62, 24)
        Me.ToolStripLabel2.Text = "Buscar"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBBuscar
        '
        Me.CBBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscar.DropDownWidth = 80
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(75, 27)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(100, 27)
        '
        'BImprimir
        '
        Me.BImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImprimir.Image = CType(resources.GetObject("BImprimir.Image"), System.Drawing.Image)
        Me.BImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImprimir.Name = "BImprimir"
        Me.BImprimir.Size = New System.Drawing.Size(24, 24)
        Me.BImprimir.Text = "Imprimir Productos"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TTamDescarga)
        Me.Panel1.Controls.Add(Me.CBCodDescarga)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Controls.Add(Me.TPorcMerma)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.TAlimFina)
        Me.Panel1.Controls.Add(Me.ChGranel)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Controls.Add(Me.TNomDescarga)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.TCodHilo)
        Me.Panel1.Controls.Add(Me.ChPaqueteo)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.TRegIca)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.TDensidad)
        Me.Panel1.Controls.Add(Me.TCodMaq)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.TRef)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.ChActivo)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TCodEtiq)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TCodEmp)
        Me.Panel1.Controls.Add(Me.BCancelar)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.CBPreskg)
        Me.Panel1.Controls.Add(Me.CBEmpaque)
        Me.Panel1.Controls.Add(Me.TNombre)
        Me.Panel1.Controls.Add(Me.CBTextura)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TCodInt)
        Me.Panel1.Enabled = False
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.Blue
        Me.Panel1.Location = New System.Drawing.Point(9, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(411, 417)
        Me.Panel1.TabIndex = 2
        Me.Panel1.TabStop = False
        Me.Panel1.Text = "Datos"
        '
        'TTamDescarga
        '
        Me.TTamDescarga.Location = New System.Drawing.Point(111, 317)
        Me.TTamDescarga.Name = "TTamDescarga"
        Me.TTamDescarga.ReadOnly = True
        Me.TTamDescarga.Size = New System.Drawing.Size(87, 21)
        Me.TTamDescarga.TabIndex = 38
        '
        'CBCodDescarga
        '
        Me.CBCodDescarga.FormattingEnabled = True
        Me.CBCodDescarga.Location = New System.Drawing.Point(111, 250)
        Me.CBCodDescarga.Name = "CBCodDescarga"
        Me.CBCodDescarga.Size = New System.Drawing.Size(87, 23)
        Me.CBCodDescarga.TabIndex = 33
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(14, 353)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 15)
        Me.Label40.TabIndex = 10
        Me.Label40.Text = "Porc. Merma"
        '
        'TPorcMerma
        '
        Me.TPorcMerma.Location = New System.Drawing.Point(111, 350)
        Me.TPorcMerma.Name = "TPorcMerma"
        Me.TPorcMerma.Size = New System.Drawing.Size(87, 21)
        Me.TPorcMerma.TabIndex = 34
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(12, 320)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(92, 15)
        Me.Label37.TabIndex = 9
        Me.Label37.Text = "Tam. Descarga"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(232, 320)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(61, 15)
        Me.Label38.TabIndex = 16
        Me.Label38.Text = "Alim. Fina"
        '
        'TAlimFina
        '
        Me.TAlimFina.Location = New System.Drawing.Point(313, 317)
        Me.TAlimFina.Name = "TAlimFina"
        Me.TAlimFina.ReadOnly = True
        Me.TAlimFina.Size = New System.Drawing.Size(87, 21)
        Me.TAlimFina.TabIndex = 23
        Me.TAlimFina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ChGranel
        '
        Me.ChGranel.AutoSize = True
        Me.ChGranel.Location = New System.Drawing.Point(293, 21)
        Me.ChGranel.Name = "ChGranel"
        Me.ChGranel.Size = New System.Drawing.Size(63, 19)
        Me.ChGranel.TabIndex = 26
        Me.ChGranel.Text = "Granel"
        Me.ChGranel.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(14, 287)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(87, 15)
        Me.Label36.TabIndex = 8
        Me.Label36.Text = "Nombre Desc."
        '
        'TNomDescarga
        '
        Me.TNomDescarga.Location = New System.Drawing.Point(111, 284)
        Me.TNomDescarga.Name = "TNomDescarga"
        Me.TNomDescarga.ReadOnly = True
        Me.TNomDescarga.Size = New System.Drawing.Size(207, 21)
        Me.TNomDescarga.TabIndex = 37
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(14, 254)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(90, 15)
        Me.Label35.TabIndex = 7
        Me.Label35.Text = "Cód. Descarga"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(14, 221)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 15)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Cód. Hil"
        '
        'TCodHilo
        '
        Me.TCodHilo.Location = New System.Drawing.Point(90, 218)
        Me.TCodHilo.Name = "TCodHilo"
        Me.TCodHilo.Size = New System.Drawing.Size(87, 21)
        Me.TCodHilo.TabIndex = 32
        '
        'ChPaqueteo
        '
        Me.ChPaqueteo.AutoSize = True
        Me.ChPaqueteo.Location = New System.Drawing.Point(313, 87)
        Me.ChPaqueteo.Name = "ChPaqueteo"
        Me.ChPaqueteo.Size = New System.Drawing.Size(80, 19)
        Me.ChPaqueteo.TabIndex = 17
        Me.ChPaqueteo.Text = "Paqueteo"
        Me.ChPaqueteo.UseVisualStyleBackColor = True
        Me.ChPaqueteo.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(232, 254)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 15)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "Reg. Ica"
        Me.Label24.Visible = False
        '
        'TRegIca
        '
        Me.TRegIca.Location = New System.Drawing.Point(313, 251)
        Me.TRegIca.Name = "TRegIca"
        Me.TRegIca.Size = New System.Drawing.Size(87, 21)
        Me.TRegIca.TabIndex = 22
        Me.TRegIca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TRegIca.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(232, 221)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(60, 15)
        Me.Label34.TabIndex = 14
        Me.Label34.Text = "Densidad"
        Me.Label34.Visible = False
        '
        'TDensidad
        '
        Me.TDensidad.Location = New System.Drawing.Point(313, 218)
        Me.TDensidad.Name = "TDensidad"
        Me.TDensidad.Size = New System.Drawing.Size(87, 21)
        Me.TDensidad.TabIndex = 21
        Me.TDensidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TDensidad.Visible = False
        '
        'TCodMaq
        '
        Me.TCodMaq.Location = New System.Drawing.Point(313, 185)
        Me.TCodMaq.Name = "TCodMaq"
        Me.TCodMaq.Size = New System.Drawing.Size(87, 21)
        Me.TCodMaq.TabIndex = 20
        Me.TCodMaq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TCodMaq.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(232, 188)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(79, 15)
        Me.Label31.TabIndex = 13
        Me.Label31.Text = "Cód. Maquila"
        Me.Label31.Visible = False
        '
        'TRef
        '
        Me.TRef.Location = New System.Drawing.Point(313, 152)
        Me.TRef.Name = "TRef"
        Me.TRef.Size = New System.Drawing.Size(87, 21)
        Me.TRef.TabIndex = 19
        Me.TRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TRef.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(232, 155)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(60, 15)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "Ref. Emp."
        Me.Label32.Visible = False
        '
        'ChActivo
        '
        Me.ChActivo.AutoSize = True
        Me.ChActivo.Location = New System.Drawing.Point(207, 21)
        Me.ChActivo.Name = "ChActivo"
        Me.ChActivo.Size = New System.Drawing.Size(61, 19)
        Me.ChActivo.TabIndex = 25
        Me.ChActivo.Text = "Activo"
        Me.ChActivo.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(14, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Cód. Etiq"
        '
        'TCodEtiq
        '
        Me.TCodEtiq.Location = New System.Drawing.Point(90, 185)
        Me.TCodEtiq.Name = "TCodEtiq"
        Me.TCodEtiq.Size = New System.Drawing.Size(87, 21)
        Me.TCodEtiq.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(14, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cód. Emp"
        '
        'TCodEmp
        '
        Me.TCodEmp.Location = New System.Drawing.Point(90, 152)
        Me.TCodEmp.Name = "TCodEmp"
        Me.TCodEmp.Size = New System.Drawing.Size(87, 21)
        Me.TCodEmp.TabIndex = 30
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(370, 380)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 36
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(313, 380)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 35
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Peso"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(232, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Empaque"
        Me.Label5.Visible = False
        '
        'CBPreskg
        '
        Me.CBPreskg.FormattingEnabled = True
        Me.CBPreskg.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30", "35", "40", "45", "50"})
        Me.CBPreskg.Location = New System.Drawing.Point(90, 118)
        Me.CBPreskg.Name = "CBPreskg"
        Me.CBPreskg.Size = New System.Drawing.Size(87, 23)
        Me.CBPreskg.TabIndex = 29
        '
        'CBEmpaque
        '
        Me.CBEmpaque.FormattingEnabled = True
        Me.CBEmpaque.Items.AddRange(New Object() {"BULT", "GRAN"})
        Me.CBEmpaque.Location = New System.Drawing.Point(313, 118)
        Me.CBEmpaque.Name = "CBEmpaque"
        Me.CBEmpaque.Size = New System.Drawing.Size(87, 23)
        Me.CBEmpaque.TabIndex = 18
        Me.CBEmpaque.Visible = False
        '
        'TNombre
        '
        Me.TNombre.Location = New System.Drawing.Point(90, 53)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(283, 21)
        Me.TNombre.TabIndex = 27
        Me.TNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CBTextura
        '
        Me.CBTextura.FormattingEnabled = True
        Me.CBTextura.Location = New System.Drawing.Point(90, 85)
        Me.CBTextura.Name = "CBTextura"
        Me.CBTextura.Size = New System.Drawing.Size(87, 23)
        Me.CBTextura.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(14, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Textura"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(14, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código"
        '
        'TCodInt
        '
        Me.TCodInt.Location = New System.Drawing.Point(90, 20)
        Me.TCodInt.Name = "TCodInt"
        Me.TCodInt.Size = New System.Drawing.Size(87, 21)
        Me.TCodInt.TabIndex = 24
        Me.TCodInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GBLinea
        '
        Me.GBLinea.Controls.Add(Me.CLinea)
        Me.GBLinea.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBLinea.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBLinea.Location = New System.Drawing.Point(452, 267)
        Me.GBLinea.Name = "GBLinea"
        Me.GBLinea.Size = New System.Drawing.Size(251, 51)
        Me.GBLinea.TabIndex = 33
        Me.GBLinea.TabStop = False
        Me.GBLinea.Text = "Asignación de Línea"
        Me.GBLinea.Visible = False
        '
        'CLinea
        '
        Me.CLinea.Enabled = False
        Me.CLinea.FormattingEnabled = True
        Me.CLinea.Location = New System.Drawing.Point(20, 19)
        Me.CLinea.Name = "CLinea"
        Me.CLinea.Size = New System.Drawing.Size(212, 22)
        Me.CLinea.TabIndex = 1
        '
        'GBPaqueteo
        '
        Me.GBPaqueteo.Controls.Add(Me.TUdsPaca)
        Me.GBPaqueteo.Controls.Add(Me.Label13)
        Me.GBPaqueteo.Controls.Add(Me.TCodEtiqBolsa)
        Me.GBPaqueteo.Controls.Add(Me.Label14)
        Me.GBPaqueteo.Controls.Add(Me.TCodEmpBolsa)
        Me.GBPaqueteo.Controls.Add(Me.Label15)
        Me.GBPaqueteo.Location = New System.Drawing.Point(481, 412)
        Me.GBPaqueteo.Name = "GBPaqueteo"
        Me.GBPaqueteo.Size = New System.Drawing.Size(383, 65)
        Me.GBPaqueteo.TabIndex = 59
        Me.GBPaqueteo.TabStop = False
        Me.GBPaqueteo.Visible = False
        '
        'TUdsPaca
        '
        Me.TUdsPaca.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TUdsPaca.FormattingEnabled = True
        Me.TUdsPaca.Items.AddRange(New Object() {"2", "4", "10", "20"})
        Me.TUdsPaca.Location = New System.Drawing.Point(248, 34)
        Me.TUdsPaca.Name = "TUdsPaca"
        Me.TUdsPaca.Size = New System.Drawing.Size(47, 22)
        Me.TUdsPaca.TabIndex = 55
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(240, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Uds. Paca"
        '
        'TCodEtiqBolsa
        '
        Me.TCodEtiqBolsa.Location = New System.Drawing.Point(131, 35)
        Me.TCodEtiqBolsa.Name = "TCodEtiqBolsa"
        Me.TCodEtiqBolsa.Size = New System.Drawing.Size(75, 20)
        Me.TCodEtiqBolsa.TabIndex = 50
        Me.TCodEtiqBolsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(15, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Cód. Etiq Bolsa"
        '
        'TCodEmpBolsa
        '
        Me.TCodEmpBolsa.Location = New System.Drawing.Point(131, 12)
        Me.TCodEmpBolsa.Name = "TCodEmpBolsa"
        Me.TCodEmpBolsa.Size = New System.Drawing.Size(75, 20)
        Me.TCodEmpBolsa.TabIndex = 44
        Me.TCodEmpBolsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(15, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Cód.EmpBolsa"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.TVencxLinea)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.TVencxProd)
        Me.GroupBox5.Location = New System.Drawing.Point(452, 330)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(200, 67)
        Me.GroupBox5.TabIndex = 57
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Vencimiento"
        Me.GroupBox5.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(17, 44)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(54, 13)
        Me.Label39.TabIndex = 5
        Me.Label39.Text = "Por Línea"
        '
        'TVencxLinea
        '
        Me.TVencxLinea.Location = New System.Drawing.Point(121, 42)
        Me.TVencxLinea.Name = "TVencxLinea"
        Me.TVencxLinea.ReadOnly = True
        Me.TVencxLinea.Size = New System.Drawing.Size(61, 20)
        Me.TVencxLinea.TabIndex = 4
        Me.TVencxLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(17, 23)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 13)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Por Producto"
        '
        'TVencxProd
        '
        Me.TVencxProd.Location = New System.Drawing.Point(121, 18)
        Me.TVencxProd.Name = "TVencxProd"
        Me.TVencxProd.Size = New System.Drawing.Size(61, 20)
        Me.TVencxProd.TabIndex = 2
        Me.TVencxProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TObserv
        '
        Me.TObserv.Location = New System.Drawing.Point(679, 348)
        Me.TObserv.Multiline = True
        Me.TObserv.Name = "TObserv"
        Me.TObserv.Size = New System.Drawing.Size(181, 56)
        Me.TObserv.TabIndex = 44
        Me.TObserv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TObserv.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(682, 330)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(81, 13)
        Me.Label25.TabIndex = 43
        Me.Label25.Text = "Observaciones:"
        Me.Label25.Visible = False
        '
        'DGEmpaques
        '
        Me.DGEmpaques.AllowUserToAddRows = False
        Me.DGEmpaques.AllowUserToDeleteRows = False
        Me.DGEmpaques.AllowUserToResizeRows = False
        Me.DGEmpaques.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmpaques.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGEmpaques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEmpaques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEmpaques_CodInt, Me.DGEmpaques_Nombre})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEmpaques.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGEmpaques.GridColor = System.Drawing.Color.Gray
        Me.DGEmpaques.Location = New System.Drawing.Point(517, 120)
        Me.DGEmpaques.MultiSelect = False
        Me.DGEmpaques.Name = "DGEmpaques"
        Me.DGEmpaques.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmpaques.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGEmpaques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEmpaques.Size = New System.Drawing.Size(324, 239)
        Me.DGEmpaques.TabIndex = 45
        Me.DGEmpaques.Visible = False
        '
        'DGEmpaques_CodInt
        '
        Me.DGEmpaques_CodInt.HeaderText = "Código"
        Me.DGEmpaques_CodInt.Name = "DGEmpaques_CodInt"
        Me.DGEmpaques_CodInt.ReadOnly = True
        '
        'DGEmpaques_Nombre
        '
        Me.DGEmpaques_Nombre.HeaderText = "Nombre"
        Me.DGEmpaques_Nombre.Name = "DGEmpaques_Nombre"
        Me.DGEmpaques_Nombre.ReadOnly = True
        Me.DGEmpaques_Nombre.Width = 250
        '
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(494, 238)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(101, 23)
        Me.FRefrescaDG.TabIndex = 46
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'TabProductosDet
        '
        Me.TabProductosDet.Controls.Add(Me.CodigosEquivalentes)
        Me.TabProductosDet.Controls.Add(Me.DatosPeletizado)
        Me.TabProductosDet.Controls.Add(Me.ArticulosDet)
        Me.TabProductosDet.Controls.Add(Me.TabPage1)
        Me.TabProductosDet.Location = New System.Drawing.Point(10, 499)
        Me.TabProductosDet.Name = "TabProductosDet"
        Me.TabProductosDet.SelectedIndex = 0
        Me.TabProductosDet.Size = New System.Drawing.Size(888, 198)
        Me.TabProductosDet.TabIndex = 55
        Me.TabProductosDet.Visible = False
        '
        'CodigosEquivalentes
        '
        Me.CodigosEquivalentes.BackColor = System.Drawing.SystemColors.Control
        Me.CodigosEquivalentes.Controls.Add(Me.Label16)
        Me.CodigosEquivalentes.Controls.Add(Me.BEditarEquiv)
        Me.CodigosEquivalentes.Controls.Add(Me.BBorrarEquiv)
        Me.CodigosEquivalentes.Controls.Add(Me.BNuevaEquiv)
        Me.CodigosEquivalentes.Controls.Add(Me.GBEquivalencias)
        Me.CodigosEquivalentes.Controls.Add(Me.DGEquivalencias)
        Me.CodigosEquivalentes.Location = New System.Drawing.Point(4, 22)
        Me.CodigosEquivalentes.Name = "CodigosEquivalentes"
        Me.CodigosEquivalentes.Size = New System.Drawing.Size(880, 172)
        Me.CodigosEquivalentes.TabIndex = 2
        Me.CodigosEquivalentes.Text = "Códigos Equivalentes"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(687, 2)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(146, 168)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = resources.GetString("Label16.Text")
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BEditarEquiv
        '
        Me.BEditarEquiv.Image = CType(resources.GetObject("BEditarEquiv.Image"), System.Drawing.Image)
        Me.BEditarEquiv.Location = New System.Drawing.Point(328, 104)
        Me.BEditarEquiv.Name = "BEditarEquiv"
        Me.BEditarEquiv.Size = New System.Drawing.Size(35, 31)
        Me.BEditarEquiv.TabIndex = 56
        Me.BEditarEquiv.UseVisualStyleBackColor = True
        '
        'BBorrarEquiv
        '
        Me.BBorrarEquiv.Image = CType(resources.GetObject("BBorrarEquiv.Image"), System.Drawing.Image)
        Me.BBorrarEquiv.Location = New System.Drawing.Point(328, 70)
        Me.BBorrarEquiv.Name = "BBorrarEquiv"
        Me.BBorrarEquiv.Size = New System.Drawing.Size(35, 31)
        Me.BBorrarEquiv.TabIndex = 57
        Me.BBorrarEquiv.UseVisualStyleBackColor = True
        '
        'BNuevaEquiv
        '
        Me.BNuevaEquiv.Image = CType(resources.GetObject("BNuevaEquiv.Image"), System.Drawing.Image)
        Me.BNuevaEquiv.Location = New System.Drawing.Point(328, 37)
        Me.BNuevaEquiv.Name = "BNuevaEquiv"
        Me.BNuevaEquiv.Size = New System.Drawing.Size(35, 31)
        Me.BNuevaEquiv.TabIndex = 58
        Me.BNuevaEquiv.UseVisualStyleBackColor = True
        '
        'GBEquivalencias
        '
        Me.GBEquivalencias.Controls.Add(Me.TPresKgEquiv)
        Me.GBEquivalencias.Controls.Add(Me.LPesoEquiv)
        Me.GBEquivalencias.Controls.Add(Me.BCancelarEquiv)
        Me.GBEquivalencias.Controls.Add(Me.BAceptarEquiv)
        Me.GBEquivalencias.Controls.Add(Me.TEquivalencia)
        Me.GBEquivalencias.Controls.Add(Me.Label11)
        Me.GBEquivalencias.Controls.Add(Me.CBPresent)
        Me.GBEquivalencias.Controls.Add(Me.Label12)
        Me.GBEquivalencias.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBEquivalencias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBEquivalencias.Location = New System.Drawing.Point(378, 24)
        Me.GBEquivalencias.Name = "GBEquivalencias"
        Me.GBEquivalencias.Size = New System.Drawing.Size(292, 131)
        Me.GBEquivalencias.TabIndex = 55
        Me.GBEquivalencias.TabStop = False
        Me.GBEquivalencias.Text = "Equivalencia:"
        '
        'TPresKgEquiv
        '
        Me.TPresKgEquiv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPresKgEquiv.FormattingEnabled = True
        Me.TPresKgEquiv.Items.AddRange(New Object() {"1 Kg", "2 Kg", "10 Kg", "20 Kg"})
        Me.TPresKgEquiv.Location = New System.Drawing.Point(136, 85)
        Me.TPresKgEquiv.Name = "TPresKgEquiv"
        Me.TPresKgEquiv.Size = New System.Drawing.Size(47, 22)
        Me.TPresKgEquiv.TabIndex = 54
        '
        'LPesoEquiv
        '
        Me.LPesoEquiv.AutoSize = True
        Me.LPesoEquiv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPesoEquiv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LPesoEquiv.Location = New System.Drawing.Point(7, 88)
        Me.LPesoEquiv.Name = "LPesoEquiv"
        Me.LPesoEquiv.Size = New System.Drawing.Size(110, 14)
        Me.LPesoEquiv.TabIndex = 53
        Me.LPesoEquiv.Text = "Peso Bolsa Interna"
        Me.LPesoEquiv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BCancelarEquiv
        '
        Me.BCancelarEquiv.Image = CType(resources.GetObject("BCancelarEquiv.Image"), System.Drawing.Image)
        Me.BCancelarEquiv.Location = New System.Drawing.Point(243, 94)
        Me.BCancelarEquiv.Name = "BCancelarEquiv"
        Me.BCancelarEquiv.Size = New System.Drawing.Size(35, 31)
        Me.BCancelarEquiv.TabIndex = 52
        Me.BCancelarEquiv.UseVisualStyleBackColor = True
        '
        'BAceptarEquiv
        '
        Me.BAceptarEquiv.Image = CType(resources.GetObject("BAceptarEquiv.Image"), System.Drawing.Image)
        Me.BAceptarEquiv.Location = New System.Drawing.Point(202, 94)
        Me.BAceptarEquiv.Name = "BAceptarEquiv"
        Me.BAceptarEquiv.Size = New System.Drawing.Size(35, 31)
        Me.BAceptarEquiv.TabIndex = 51
        Me.BAceptarEquiv.UseVisualStyleBackColor = True
        '
        'TEquivalencia
        '
        Me.TEquivalencia.Location = New System.Drawing.Point(135, 55)
        Me.TEquivalencia.Name = "TEquivalencia"
        Me.TEquivalencia.ReadOnly = True
        Me.TEquivalencia.Size = New System.Drawing.Size(83, 20)
        Me.TEquivalencia.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(6, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 14)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "CodProd Equivalente:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBPresent
        '
        Me.CBPresent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPresent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPresent.FormattingEnabled = True
        Me.CBPresent.Items.AddRange(New Object() {"H", "P", "Q", "E", "PKH", "PKP", "PKQ", "PKE", "MQ", "MD", "GR", "CL"})
        Me.CBPresent.Location = New System.Drawing.Point(135, 27)
        Me.CBPresent.Name = "CBPresent"
        Me.CBPresent.Size = New System.Drawing.Size(47, 22)
        Me.CBPresent.TabIndex = 39
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(6, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 14)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Presentación"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DGEquivalencias
        '
        Me.DGEquivalencias.AllowUserToAddRows = False
        Me.DGEquivalencias.AllowUserToDeleteRows = False
        Me.DGEquivalencias.AllowUserToResizeRows = False
        Me.DGEquivalencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEquivalencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEquivalencias_CodProdEqui, Me.DGEquivalencias_Present, Me.DGEquivalencias_PresKg})
        Me.DGEquivalencias.Location = New System.Drawing.Point(29, 23)
        Me.DGEquivalencias.MultiSelect = False
        Me.DGEquivalencias.Name = "DGEquivalencias"
        Me.DGEquivalencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEquivalencias.Size = New System.Drawing.Size(293, 134)
        Me.DGEquivalencias.TabIndex = 53
        '
        'DGEquivalencias_CodProdEqui
        '
        Me.DGEquivalencias_CodProdEqui.HeaderText = "Equivalencia"
        Me.DGEquivalencias_CodProdEqui.Name = "DGEquivalencias_CodProdEqui"
        '
        'DGEquivalencias_Present
        '
        Me.DGEquivalencias_Present.HeaderText = "Presentación"
        Me.DGEquivalencias_Present.Name = "DGEquivalencias_Present"
        '
        'DGEquivalencias_PresKg
        '
        Me.DGEquivalencias_PresKg.HeaderText = "Kg"
        Me.DGEquivalencias_PresKg.Name = "DGEquivalencias_PresKg"
        Me.DGEquivalencias_PresKg.Width = 30
        '
        'DatosPeletizado
        '
        Me.DatosPeletizado.BackColor = System.Drawing.SystemColors.Control
        Me.DatosPeletizado.Controls.Add(Me.TMalla12)
        Me.DatosPeletizado.Controls.Add(Me.Label33)
        Me.DatosPeletizado.Controls.Add(Me.Label8)
        Me.DatosPeletizado.Controls.Add(Me.TMalla30)
        Me.DatosPeletizado.Controls.Add(Me.Label30)
        Me.DatosPeletizado.Controls.Add(Me.TMalla6)
        Me.DatosPeletizado.Controls.Add(Me.Label29)
        Me.DatosPeletizado.Controls.Add(Me.TDurabilidad)
        Me.DatosPeletizado.Controls.Add(Me.Label9)
        Me.DatosPeletizado.Controls.Add(Me.TDureza)
        Me.DatosPeletizado.Controls.Add(Me.Label10)
        Me.DatosPeletizado.Controls.Add(Me.TMalla8)
        Me.DatosPeletizado.Controls.Add(Me.Label26)
        Me.DatosPeletizado.Controls.Add(Me.TMalla16)
        Me.DatosPeletizado.Controls.Add(Me.Label27)
        Me.DatosPeletizado.Controls.Add(Me.TPorcPlato)
        Me.DatosPeletizado.Controls.Add(Me.Label28)
        Me.DatosPeletizado.Location = New System.Drawing.Point(4, 22)
        Me.DatosPeletizado.Name = "DatosPeletizado"
        Me.DatosPeletizado.Size = New System.Drawing.Size(880, 172)
        Me.DatosPeletizado.TabIndex = 1
        Me.DatosPeletizado.Text = "Párametros Tamizado"
        '
        'TMalla12
        '
        Me.TMalla12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMalla12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TMalla12.Location = New System.Drawing.Point(136, 64)
        Me.TMalla12.Name = "TMalla12"
        Me.TMalla12.Size = New System.Drawing.Size(58, 21)
        Me.TMalla12.TabIndex = 59
        Me.TMalla12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(20, 67)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(101, 13)
        Me.Label33.TabIndex = 58
        Me.Label33.Text = "Porcentaje Malla 12"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Porcentaje Malla 30"
        '
        'TMalla30
        '
        Me.TMalla30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMalla30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TMalla30.Location = New System.Drawing.Point(136, 112)
        Me.TMalla30.Name = "TMalla30"
        Me.TMalla30.Size = New System.Drawing.Size(58, 21)
        Me.TMalla30.TabIndex = 56
        Me.TMalla30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(20, 91)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(101, 13)
        Me.Label30.TabIndex = 55
        Me.Label30.Text = "Porcentaje Malla 16"
        '
        'TMalla6
        '
        Me.TMalla6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMalla6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TMalla6.Location = New System.Drawing.Point(136, 16)
        Me.TMalla6.Name = "TMalla6"
        Me.TMalla6.Size = New System.Drawing.Size(58, 21)
        Me.TMalla6.TabIndex = 54
        Me.TMalla6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(20, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(95, 13)
        Me.Label29.TabIndex = 53
        Me.Label29.Text = "Porcentaje Malla 6"
        '
        'TDurabilidad
        '
        Me.TDurabilidad.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDurabilidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TDurabilidad.Location = New System.Drawing.Point(324, 62)
        Me.TDurabilidad.Name = "TDurabilidad"
        Me.TDurabilidad.Size = New System.Drawing.Size(58, 21)
        Me.TDurabilidad.TabIndex = 52
        Me.TDurabilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(208, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Durabilidad"
        '
        'TDureza
        '
        Me.TDureza.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDureza.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TDureza.Location = New System.Drawing.Point(324, 39)
        Me.TDureza.Name = "TDureza"
        Me.TDureza.Size = New System.Drawing.Size(58, 21)
        Me.TDureza.TabIndex = 50
        Me.TDureza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(208, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Dureza"
        '
        'TMalla8
        '
        Me.TMalla8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMalla8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TMalla8.Location = New System.Drawing.Point(136, 40)
        Me.TMalla8.Name = "TMalla8"
        Me.TMalla8.Size = New System.Drawing.Size(58, 21)
        Me.TMalla8.TabIndex = 48
        Me.TMalla8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(208, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(85, 13)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "Porcentaje Plato"
        '
        'TMalla16
        '
        Me.TMalla16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMalla16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TMalla16.Location = New System.Drawing.Point(136, 88)
        Me.TMalla16.Name = "TMalla16"
        Me.TMalla16.Size = New System.Drawing.Size(58, 21)
        Me.TMalla16.TabIndex = 46
        Me.TMalla16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(15, 67)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(0, 13)
        Me.Label27.TabIndex = 45
        '
        'TPorcPlato
        '
        Me.TPorcPlato.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPorcPlato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TPorcPlato.Location = New System.Drawing.Point(324, 16)
        Me.TPorcPlato.Name = "TPorcPlato"
        Me.TPorcPlato.Size = New System.Drawing.Size(58, 21)
        Me.TPorcPlato.TabIndex = 44
        Me.TPorcPlato.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(20, 43)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(95, 13)
        Me.Label28.TabIndex = 43
        Me.Label28.Text = "Porcentaje Malla 8"
        '
        'ArticulosDet
        '
        Me.ArticulosDet.BackColor = System.Drawing.SystemColors.Control
        Me.ArticulosDet.Controls.Add(Me.FRefrescaDGArticulosDet)
        Me.ArticulosDet.Controls.Add(Me.DGArticulosDet)
        Me.ArticulosDet.Controls.Add(Me.GroupBox3)
        Me.ArticulosDet.Location = New System.Drawing.Point(4, 22)
        Me.ArticulosDet.Name = "ArticulosDet"
        Me.ArticulosDet.Padding = New System.Windows.Forms.Padding(3)
        Me.ArticulosDet.Size = New System.Drawing.Size(880, 172)
        Me.ArticulosDet.TabIndex = 0
        Me.ArticulosDet.Text = "Códigos de empaque por producto"
        '
        'FRefrescaDGArticulosDet
        '
        Me.FRefrescaDGArticulosDet.Location = New System.Drawing.Point(564, 87)
        Me.FRefrescaDGArticulosDet.Name = "FRefrescaDGArticulosDet"
        Me.FRefrescaDGArticulosDet.Size = New System.Drawing.Size(152, 23)
        Me.FRefrescaDGArticulosDet.TabIndex = 55
        Me.FRefrescaDGArticulosDet.Text = "FRefrescaDGArticulosDet"
        Me.FRefrescaDGArticulosDet.UseVisualStyleBackColor = True
        Me.FRefrescaDGArticulosDet.Visible = False
        '
        'DGArticulosDet
        '
        Me.DGArticulosDet.AllowUserToAddRows = False
        Me.DGArticulosDet.AllowUserToDeleteRows = False
        Me.DGArticulosDet.AllowUserToResizeRows = False
        Me.DGArticulosDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGArticulosDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGArticulosDet_CodIntDet, Me.DGArticulosDet_NombreDet})
        Me.DGArticulosDet.Location = New System.Drawing.Point(485, 17)
        Me.DGArticulosDet.MultiSelect = False
        Me.DGArticulosDet.Name = "DGArticulosDet"
        Me.DGArticulosDet.ReadOnly = True
        Me.DGArticulosDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGArticulosDet.Size = New System.Drawing.Size(343, 147)
        Me.DGArticulosDet.TabIndex = 53
        '
        'DGArticulosDet_CodIntDet
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGArticulosDet_CodIntDet.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGArticulosDet_CodIntDet.HeaderText = "Código Empaque"
        Me.DGArticulosDet_CodIntDet.Name = "DGArticulosDet_CodIntDet"
        Me.DGArticulosDet_CodIntDet.ReadOnly = True
        Me.DGArticulosDet_CodIntDet.Width = 120
        '
        'DGArticulosDet_NombreDet
        '
        Me.DGArticulosDet_NombreDet.HeaderText = "Nombre"
        Me.DGArticulosDet_NombreDet.Name = "DGArticulosDet_NombreDet"
        Me.DGArticulosDet_NombreDet.ReadOnly = True
        Me.DGArticulosDet_NombreDet.Width = 150
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.FRefrescaDGEmp)
        Me.GroupBox3.Controls.Add(Me.DGEmpaques2)
        Me.GroupBox3.Controls.Add(Me.TSOrgProg)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(14, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(447, 155)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        '
        'FRefrescaDGEmp
        '
        Me.FRefrescaDGEmp.Location = New System.Drawing.Point(234, 96)
        Me.FRefrescaDGEmp.Name = "FRefrescaDGEmp"
        Me.FRefrescaDGEmp.Size = New System.Drawing.Size(101, 23)
        Me.FRefrescaDGEmp.TabIndex = 54
        Me.FRefrescaDGEmp.Text = "FRefrescaDGEmp"
        Me.FRefrescaDGEmp.UseVisualStyleBackColor = True
        Me.FRefrescaDGEmp.Visible = False
        '
        'DGEmpaques2
        '
        Me.DGEmpaques2.AllowUserToAddRows = False
        Me.DGEmpaques2.AllowUserToDeleteRows = False
        Me.DGEmpaques2.AllowUserToResizeRows = False
        Me.DGEmpaques2.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DGEmpaques2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEmpaques2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEmpaques2_CodInt, Me.DGEmpaques2_Nombre})
        Me.DGEmpaques2.GridColor = System.Drawing.Color.Gray
        Me.DGEmpaques2.Location = New System.Drawing.Point(11, 50)
        Me.DGEmpaques2.MultiSelect = False
        Me.DGEmpaques2.Name = "DGEmpaques2"
        Me.DGEmpaques2.ReadOnly = True
        Me.DGEmpaques2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEmpaques2.Size = New System.Drawing.Size(408, 85)
        Me.DGEmpaques2.TabIndex = 54
        '
        'DGEmpaques2_CodInt
        '
        Me.DGEmpaques2_CodInt.HeaderText = "Código"
        Me.DGEmpaques2_CodInt.Name = "DGEmpaques2_CodInt"
        Me.DGEmpaques2_CodInt.ReadOnly = True
        '
        'DGEmpaques2_Nombre
        '
        Me.DGEmpaques2_Nombre.HeaderText = "Nombre"
        Me.DGEmpaques2_Nombre.Name = "DGEmpaques2_Nombre"
        Me.DGEmpaques2_Nombre.ReadOnly = True
        Me.DGEmpaques2_Nombre.Width = 250
        '
        'TSOrgProg
        '
        Me.TSOrgProg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BAdicionaEmp, Me.ToolStripSeparator3, Me.BEliminaEmp, Me.ToolStripSeparator18, Me.CBBuscarEmp, Me.TBuscarEmp})
        Me.TSOrgProg.Location = New System.Drawing.Point(3, 16)
        Me.TSOrgProg.Name = "TSOrgProg"
        Me.TSOrgProg.Size = New System.Drawing.Size(441, 25)
        Me.TSOrgProg.TabIndex = 53
        Me.TSOrgProg.Text = "ToolStrip2"
        '
        'BAdicionaEmp
        '
        Me.BAdicionaEmp.Image = CType(resources.GetObject("BAdicionaEmp.Image"), System.Drawing.Image)
        Me.BAdicionaEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAdicionaEmp.Name = "BAdicionaEmp"
        Me.BAdicionaEmp.Size = New System.Drawing.Size(16, 22)
        Me.BAdicionaEmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BAdicionaEmp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BAdicionaEmp.ToolTipText = "Adicionar codigo de empaque"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BEliminaEmp
        '
        Me.BEliminaEmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEliminaEmp.Image = CType(resources.GetObject("BEliminaEmp.Image"), System.Drawing.Image)
        Me.BEliminaEmp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEliminaEmp.Name = "BEliminaEmp"
        Me.BEliminaEmp.Size = New System.Drawing.Size(23, 22)
        Me.BEliminaEmp.ToolTipText = "Eliminar código de empaque"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'CBBuscarEmp
        '
        Me.CBBuscarEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscarEmp.DropDownWidth = 80
        Me.CBBuscarEmp.Name = "CBBuscarEmp"
        Me.CBBuscarEmp.Size = New System.Drawing.Size(75, 25)
        Me.CBBuscarEmp.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscarEmp
        '
        Me.TBuscarEmp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscarEmp.Name = "TBuscarEmp"
        Me.TBuscarEmp.Size = New System.Drawing.Size(100, 25)
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(880, 172)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Paqueteo"
        '
        'mnSalir
        '
        Me.mnSalir.Name = "mnSalir"
        Me.mnSalir.Size = New System.Drawing.Size(180, 22)
        Me.mnSalir.Text = "Salir"
        '
        'Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 699)
        Me.Controls.Add(Me.GBLinea)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TObserv)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GBPaqueteo)
        Me.Controls.Add(Me.FRefrescaDG)
        Me.Controls.Add(Me.DGEmpaques)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DGProd)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabProductosDet)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GBLinea.ResumeLayout(False)
        Me.GBPaqueteo.ResumeLayout(False)
        Me.GBPaqueteo.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGEmpaques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabProductosDet.ResumeLayout(False)
        Me.CodigosEquivalentes.ResumeLayout(False)
        Me.CodigosEquivalentes.PerformLayout()
        Me.GBEquivalencias.ResumeLayout(False)
        Me.GBEquivalencias.PerformLayout()
        CType(Me.DGEquivalencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DatosPeletizado.ResumeLayout(False)
        Me.DatosPeletizado.PerformLayout()
        Me.ArticulosDet.ResumeLayout(False)
        CType(Me.DGArticulosDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGEmpaques2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOrgProg.ResumeLayout(False)
        Me.TSOrgProg.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGProd As System.Windows.Forms.DataGridView
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
    Friend WithEvents Panel1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TCodInt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBPreskg As System.Windows.Forms.ComboBox
    Friend WithEvents CBEmpaque As System.Windows.Forms.ComboBox
    Friend WithEvents TNombre As System.Windows.Forms.TextBox
    Friend WithEvents CBTextura As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TCodEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents DGEmpaques As System.Windows.Forms.DataGridView
    Friend WithEvents FRefrescaDG As System.Windows.Forms.Button
    Friend WithEvents GBLinea As System.Windows.Forms.GroupBox
    Friend WithEvents CLinea As System.Windows.Forms.ComboBox
    Friend WithEvents BImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGEmpaques_CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEmpaques_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TObserv As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TabProductosDet As System.Windows.Forms.TabControl
    Friend WithEvents ArticulosDet As System.Windows.Forms.TabPage
    Friend WithEvents DGArticulosDet As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TSOrgProg As System.Windows.Forms.ToolStrip
    Friend WithEvents BAdicionaEmp As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BEliminaEmp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DGEmpaques2 As System.Windows.Forms.DataGridView
    Friend WithEvents CBBuscarEmp As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscarEmp As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FRefrescaDGEmp As System.Windows.Forms.Button
    Friend WithEvents FRefrescaDGArticulosDet As System.Windows.Forms.Button
    Friend WithEvents DGEmpaques2_CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEmpaques2_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConfigurarArticulosDetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGArticulosDet_CodIntDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGArticulosDet_NombreDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DatosPeletizado As TabPage
    Friend WithEvents CodigosEquivalentes As TabPage
    Friend WithEvents BEditarEquiv As Button
    Friend WithEvents BBorrarEquiv As Button
    Friend WithEvents BNuevaEquiv As Button
    Friend WithEvents GBEquivalencias As GroupBox
    Friend WithEvents BCancelarEquiv As Button
    Friend WithEvents BAceptarEquiv As Button
    Friend WithEvents TEquivalencia As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CBPresent As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents DGEquivalencias As DataGridView
    Friend WithEvents Label30 As Label
    Friend WithEvents TMalla6 As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TDurabilidad As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TDureza As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TMalla8 As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents TMalla16 As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents TPorcPlato As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents ChActivo As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TMalla30 As TextBox
    Friend WithEvents TCodMaq As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TRef As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents TMalla12 As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents TDensidad As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label39 As Label
    Friend WithEvents TVencxLinea As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents TVencxProd As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents TRegIca As TextBox
    Friend WithEvents mnInterfazArt As ToolStripMenuItem
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBPaqueteo As GroupBox
    Friend WithEvents TCodEtiqBolsa As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TCodEmpBolsa As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ChPaqueteo As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TPresKgEquiv As ComboBox
    Friend WithEvents LPesoEquiv As Label
    Friend WithEvents TUdsPaca As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents DGEquivalencias_CodProdEqui As DataGridViewTextBoxColumn
    Friend WithEvents DGEquivalencias_Present As DataGridViewTextBoxColumn
    Friend WithEvents DGEquivalencias_PresKg As DataGridViewTextBoxColumn
    Friend WithEvents Label17 As Label
    Friend WithEvents TCodHilo As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents TNomDescarga As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents ChGranel As CheckBox
    Friend WithEvents Label40 As Label
    Friend WithEvents TPorcMerma As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents TAlimFina As TextBox
    Friend WithEvents CBCodDescarga As ComboBox
    Friend WithEvents TTamDescarga As TextBox
    Friend WithEvents CodInt As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents ACTIVO As DataGridViewCheckBoxColumn
    Friend WithEvents PresKg As DataGridViewTextBoxColumn
    Friend WithEvents GRANEL As DataGridViewCheckBoxColumn
    Friend WithEvents mnSalir As ToolStripMenuItem
End Class
