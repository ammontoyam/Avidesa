<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComparativoInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComparativoInv))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAdicionarArt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAdicionaTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnInhabilitar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGCompInv = New System.Windows.Forms.DataGridView()
        Me.CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvFisico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntPend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalPend = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvUno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DifFisicoUno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConsumoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcVariacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservBodega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservCostos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservMaquilas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuDG = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnMenuDGNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMenuDGEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.CBActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GBFiltrar = New System.Windows.Forms.GroupBox()
        Me.OPPrem = New System.Windows.Forms.RadioButton()
        Me.OPAditivos = New System.Windows.Forms.RadioButton()
        Me.OPEtiquetas = New System.Windows.Forms.RadioButton()
        Me.OPEmpaque = New System.Windows.Forms.RadioButton()
        Me.OPPT = New System.Windows.Forms.RadioButton()
        Me.OPMP = New System.Windows.Forms.RadioButton()
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.FSeparador = New System.Windows.Forms.Button()
        Me.TimSeg = New System.Windows.Forms.Timer(Me.components)
        Me.TSeg = New System.Windows.Forms.TextBox()
        Me.FResetInv = New System.Windows.Forms.Button()
        Me.Iconos = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.TEstadoInv = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BarraProgreso = New System.Windows.Forms.ToolStripProgressBar()
        Me.TEstadoBarra = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FRevEstadoCierre = New System.Windows.Forms.Button()
        Me.TimIni = New System.Windows.Forms.Timer(Me.components)
        Me.GBFechas = New System.Windows.Forms.GroupBox()
        Me.TSFechas = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.TFechaCierreInvFisico = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.TFechaActUNO = New System.Windows.Forms.ToolStripLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TSTotales = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSumInvMin = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSumInvFisico = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSumInvUno = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSumEntPend = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSumSalPend = New System.Windows.Forms.ToolStripLabel()
        Me.FCalcTot = New System.Windows.Forms.Button()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BMateriales = New System.Windows.Forms.ToolStripButton()
        Me.BProductos = New System.Windows.Forms.ToolStripButton()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.TBActInvFisico = New System.Windows.Forms.ToolStripLabel()
        Me.BActInvUNO = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BCerrarInv = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BAjustarInv = New System.Windows.Forms.ToolStripButton()
        Me.BActInvFisico = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BReportesInv = New System.Windows.Forms.ToolStripButton()
        Me.FExportExcel = New System.Windows.Forms.Button()
        Me.FGuardaHist = New System.Windows.Forms.Button()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGCompInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuDG.SuspendLayout()
        Me.GBFiltrar.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.GBFechas.SuspendLayout()
        Me.TSFechas.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TSTotales.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.mnAcercaDe})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1362, 24)
        Me.MenuStrip1.TabIndex = 36
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
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnArticulos, Me.mnInhabilitar})
        Me.OtrosToolStripMenuItem.Image = CType(resources.GetObject("OtrosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.OtrosToolStripMenuItem.Text = "Otros"
        '
        'mnArticulos
        '
        Me.mnArticulos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnAdicionarArt, Me.mnAdicionaTodos})
        Me.mnArticulos.Image = CType(resources.GetObject("mnArticulos.Image"), System.Drawing.Image)
        Me.mnArticulos.Name = "mnArticulos"
        Me.mnArticulos.Size = New System.Drawing.Size(165, 22)
        Me.mnArticulos.Text = "Artículos"
        '
        'mnAdicionarArt
        '
        Me.mnAdicionarArt.Image = CType(resources.GetObject("mnAdicionarArt.Image"), System.Drawing.Image)
        Me.mnAdicionarArt.Name = "mnAdicionarArt"
        Me.mnAdicionarArt.Size = New System.Drawing.Size(161, 22)
        Me.mnAdicionarArt.Text = "Adicionar"
        '
        'mnAdicionaTodos
        '
        Me.mnAdicionaTodos.Name = "mnAdicionaTodos"
        Me.mnAdicionaTodos.Size = New System.Drawing.Size(161, 22)
        Me.mnAdicionaTodos.Text = "Adicionar todos"
        '
        'mnInhabilitar
        '
        Me.mnInhabilitar.Name = "mnInhabilitar"
        Me.mnInhabilitar.Size = New System.Drawing.Size(165, 22)
        Me.mnInhabilitar.Text = "Inhabilitar Todos"
        '
        'mnAcercaDe
        '
        Me.mnAcercaDe.Image = CType(resources.GetObject("mnAcercaDe.Image"), System.Drawing.Image)
        Me.mnAcercaDe.Name = "mnAcercaDe"
        Me.mnAcercaDe.Size = New System.Drawing.Size(102, 20)
        Me.mnAcercaDe.Text = "Acerca de...."
        '
        'DGCompInv
        '
        Me.DGCompInv.AllowUserToAddRows = False
        Me.DGCompInv.AllowUserToDeleteRows = False
        Me.DGCompInv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        Me.DGCompInv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCompInv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGCompInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCompInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodInt, Me.Nombre, Me.InvMin, Me.InvFisico, Me.EntPend, Me.SalPend, Me.InvUno, Me.DifFisicoUno, Me.ConsumoMes, Me.PorcVariacion, Me.ObservBodega, Me.ObservCostos, Me.ObservMaquilas, Me.Linea, Me.ID})
        Me.DGCompInv.ContextMenuStrip = Me.MenuDG
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGCompInv.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGCompInv.EnableHeadersVisualStyles = False
        Me.DGCompInv.Location = New System.Drawing.Point(12, 123)
        Me.DGCompInv.Name = "DGCompInv"
        Me.DGCompInv.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCompInv.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGCompInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCompInv.Size = New System.Drawing.Size(1353, 510)
        Me.DGCompInv.TabIndex = 45
        '
        'CodInt
        '
        Me.CodInt.DataPropertyName = "CodInt"
        Me.CodInt.HeaderText = "CÓD. INT."
        Me.CodInt.Name = "CodInt"
        Me.CodInt.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "NOMBRE"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 200
        '
        'InvMin
        '
        Me.InvMin.DataPropertyName = "InvMin"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.InvMin.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvMin.HeaderText = "INV. MÍNIMO"
        Me.InvMin.Name = "InvMin"
        Me.InvMin.ReadOnly = True
        Me.InvMin.Width = 90
        '
        'InvFisico
        '
        Me.InvFisico.DataPropertyName = "InvFisico"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.InvFisico.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvFisico.HeaderText = "INV. FÍSICO"
        Me.InvFisico.Name = "InvFisico"
        Me.InvFisico.ReadOnly = True
        Me.InvFisico.Width = 90
        '
        'EntPend
        '
        Me.EntPend.DataPropertyName = "EntPend"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.EntPend.DefaultCellStyle = DataGridViewCellStyle5
        Me.EntPend.HeaderText = "ENT. PENDIENTES"
        Me.EntPend.Name = "EntPend"
        Me.EntPend.ReadOnly = True
        Me.EntPend.Width = 90
        '
        'SalPend
        '
        Me.SalPend.DataPropertyName = "SalPend"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SalPend.DefaultCellStyle = DataGridViewCellStyle6
        Me.SalPend.HeaderText = "SAL. PENDIENTES"
        Me.SalPend.Name = "SalPend"
        Me.SalPend.ReadOnly = True
        Me.SalPend.Width = 90
        '
        'InvUno
        '
        Me.InvUno.DataPropertyName = "InvUno"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.InvUno.DefaultCellStyle = DataGridViewCellStyle7
        Me.InvUno.HeaderText = "INV. UNO"
        Me.InvUno.Name = "InvUno"
        Me.InvUno.ReadOnly = True
        Me.InvUno.Width = 90
        '
        'DifFisicoUno
        '
        Me.DifFisicoUno.DataPropertyName = "DifFisicoUno"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DifFisicoUno.DefaultCellStyle = DataGridViewCellStyle8
        Me.DifFisicoUno.HeaderText = "DIFERENCIA"
        Me.DifFisicoUno.Name = "DifFisicoUno"
        Me.DifFisicoUno.ReadOnly = True
        Me.DifFisicoUno.Width = 90
        '
        'ConsumoMes
        '
        Me.ConsumoMes.DataPropertyName = "ConsumoMes"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ConsumoMes.DefaultCellStyle = DataGridViewCellStyle9
        Me.ConsumoMes.HeaderText = "CONSUMO MES"
        Me.ConsumoMes.Name = "ConsumoMes"
        Me.ConsumoMes.ReadOnly = True
        Me.ConsumoMes.Width = 90
        '
        'PorcVariacion
        '
        Me.PorcVariacion.DataPropertyName = "PorcVariacion"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PorcVariacion.DefaultCellStyle = DataGridViewCellStyle10
        Me.PorcVariacion.HeaderText = "% VAR."
        Me.PorcVariacion.Name = "PorcVariacion"
        Me.PorcVariacion.ReadOnly = True
        Me.PorcVariacion.Width = 60
        '
        'ObservBodega
        '
        Me.ObservBodega.DataPropertyName = "ObservBodega"
        Me.ObservBodega.HeaderText = "OBSERV. BODEGA"
        Me.ObservBodega.Name = "ObservBodega"
        Me.ObservBodega.ReadOnly = True
        Me.ObservBodega.Width = 150
        '
        'ObservCostos
        '
        Me.ObservCostos.DataPropertyName = "ObservCostos"
        Me.ObservCostos.HeaderText = "OBSERV. COSTOS"
        Me.ObservCostos.Name = "ObservCostos"
        Me.ObservCostos.ReadOnly = True
        Me.ObservCostos.Width = 150
        '
        'ObservMaquilas
        '
        Me.ObservMaquilas.DataPropertyName = "ObservMaquilas"
        Me.ObservMaquilas.HeaderText = "MÁQUILAS-VENTAS"
        Me.ObservMaquilas.Name = "ObservMaquilas"
        Me.ObservMaquilas.ReadOnly = True
        Me.ObservMaquilas.Width = 150
        '
        'Linea
        '
        Me.Linea.DataPropertyName = "Linea"
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Visible = False
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'MenuDG
        '
        Me.MenuDG.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnMenuDGNuevo, Me.mnMenuDGEliminar, Me.CBActualizar})
        Me.MenuDG.Name = "ContexMenuFor"
        Me.MenuDG.Size = New System.Drawing.Size(174, 70)
        '
        'mnMenuDGNuevo
        '
        Me.mnMenuDGNuevo.Image = CType(resources.GetObject("mnMenuDGNuevo.Image"), System.Drawing.Image)
        Me.mnMenuDGNuevo.Name = "mnMenuDGNuevo"
        Me.mnMenuDGNuevo.Size = New System.Drawing.Size(173, 22)
        Me.mnMenuDGNuevo.Text = "Nuevo Artículo"
        '
        'mnMenuDGEliminar
        '
        Me.mnMenuDGEliminar.Image = CType(resources.GetObject("mnMenuDGEliminar.Image"), System.Drawing.Image)
        Me.mnMenuDGEliminar.Name = "mnMenuDGEliminar"
        Me.mnMenuDGEliminar.Size = New System.Drawing.Size(173, 22)
        Me.mnMenuDGEliminar.Text = "Eliminar Articulo "
        '
        'CBActualizar
        '
        Me.CBActualizar.Image = CType(resources.GetObject("CBActualizar.Image"), System.Drawing.Image)
        Me.CBActualizar.Name = "CBActualizar"
        Me.CBActualizar.Size = New System.Drawing.Size(173, 22)
        Me.CBActualizar.Text = "Actualizar Fórmula"
        '
        'GBFiltrar
        '
        Me.GBFiltrar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GBFiltrar.Controls.Add(Me.OPPrem)
        Me.GBFiltrar.Controls.Add(Me.OPAditivos)
        Me.GBFiltrar.Controls.Add(Me.OPEtiquetas)
        Me.GBFiltrar.Controls.Add(Me.OPEmpaque)
        Me.GBFiltrar.Controls.Add(Me.OPPT)
        Me.GBFiltrar.Controls.Add(Me.OPMP)
        Me.GBFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBFiltrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GBFiltrar.Location = New System.Drawing.Point(12, 66)
        Me.GBFiltrar.Name = "GBFiltrar"
        Me.GBFiltrar.Size = New System.Drawing.Size(700, 48)
        Me.GBFiltrar.TabIndex = 142
        Me.GBFiltrar.TabStop = False
        Me.GBFiltrar.Text = "Filtrar por Tipo"
        '
        'OPPrem
        '
        Me.OPPrem.AutoSize = True
        Me.OPPrem.BackColor = System.Drawing.Color.Transparent
        Me.OPPrem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OPPrem.Location = New System.Drawing.Point(233, 20)
        Me.OPPrem.Name = "OPPrem"
        Me.OPPrem.Size = New System.Drawing.Size(100, 20)
        Me.OPPrem.TabIndex = 7
        Me.OPPrem.Text = "Premezclas"
        Me.OPPrem.UseVisualStyleBackColor = False
        '
        'OPAditivos
        '
        Me.OPAditivos.AutoSize = True
        Me.OPAditivos.BackColor = System.Drawing.Color.Transparent
        Me.OPAditivos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OPAditivos.Location = New System.Drawing.Point(151, 19)
        Me.OPAditivos.Name = "OPAditivos"
        Me.OPAditivos.Size = New System.Drawing.Size(76, 20)
        Me.OPAditivos.TabIndex = 5
        Me.OPAditivos.Text = "Aditivos"
        Me.OPAditivos.UseVisualStyleBackColor = False
        '
        'OPEtiquetas
        '
        Me.OPEtiquetas.AutoSize = True
        Me.OPEtiquetas.BackColor = System.Drawing.Color.Transparent
        Me.OPEtiquetas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OPEtiquetas.Location = New System.Drawing.Point(601, 22)
        Me.OPEtiquetas.Name = "OPEtiquetas"
        Me.OPEtiquetas.Size = New System.Drawing.Size(84, 20)
        Me.OPEtiquetas.TabIndex = 3
        Me.OPEtiquetas.Text = "Etiquetas"
        Me.OPEtiquetas.UseVisualStyleBackColor = False
        '
        'OPEmpaque
        '
        Me.OPEmpaque.AutoSize = True
        Me.OPEmpaque.BackColor = System.Drawing.Color.Transparent
        Me.OPEmpaque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OPEmpaque.Location = New System.Drawing.Point(500, 22)
        Me.OPEmpaque.Name = "OPEmpaque"
        Me.OPEmpaque.Size = New System.Drawing.Size(86, 20)
        Me.OPEmpaque.TabIndex = 2
        Me.OPEmpaque.Text = "Empaque"
        Me.OPEmpaque.UseVisualStyleBackColor = False
        '
        'OPPT
        '
        Me.OPPT.AutoSize = True
        Me.OPPT.BackColor = System.Drawing.Color.Transparent
        Me.OPPT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OPPT.Location = New System.Drawing.Point(339, 21)
        Me.OPPT.Name = "OPPT"
        Me.OPPT.Size = New System.Drawing.Size(155, 20)
        Me.OPPT.TabIndex = 1
        Me.OPPT.Text = "Producto Terminado"
        Me.OPPT.UseVisualStyleBackColor = False
        '
        'OPMP
        '
        Me.OPMP.AutoSize = True
        Me.OPMP.BackColor = System.Drawing.Color.Transparent
        Me.OPMP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.OPMP.Location = New System.Drawing.Point(10, 19)
        Me.OPMP.Name = "OPMP"
        Me.OPMP.Size = New System.Drawing.Size(116, 20)
        Me.OPMP.TabIndex = 0
        Me.OPMP.Text = "Materia Prima"
        Me.OPMP.UseVisualStyleBackColor = False
        '
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(22, 176)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(116, 23)
        Me.FRefrescaDG.TabIndex = 143
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'FSeparador
        '
        Me.FSeparador.Location = New System.Drawing.Point(21, 200)
        Me.FSeparador.Name = "FSeparador"
        Me.FSeparador.Size = New System.Drawing.Size(116, 22)
        Me.FSeparador.TabIndex = 144
        Me.FSeparador.Text = "FSeparador"
        Me.FSeparador.UseVisualStyleBackColor = True
        Me.FSeparador.Visible = False
        '
        'TimSeg
        '
        Me.TimSeg.Enabled = True
        Me.TimSeg.Interval = 1000
        '
        'TSeg
        '
        Me.TSeg.Location = New System.Drawing.Point(1311, 176)
        Me.TSeg.Name = "TSeg"
        Me.TSeg.Size = New System.Drawing.Size(37, 20)
        Me.TSeg.TabIndex = 145
        Me.TSeg.Visible = False
        '
        'FResetInv
        '
        Me.FResetInv.Location = New System.Drawing.Point(22, 229)
        Me.FResetInv.Name = "FResetInv"
        Me.FResetInv.Size = New System.Drawing.Size(116, 23)
        Me.FResetInv.TabIndex = 146
        Me.FResetInv.Text = "FResetInv"
        Me.FResetInv.UseVisualStyleBackColor = True
        Me.FResetInv.Visible = False
        '
        'Iconos
        '
        Me.Iconos.ImageStream = CType(resources.GetObject("Iconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Iconos.TransparentColor = System.Drawing.Color.Transparent
        Me.Iconos.Images.SetKeyName(0, "lock.ico")
        Me.Iconos.Images.SetKeyName(1, "lock_open.ico")
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TEstadoInv, Me.BarraProgreso, Me.TEstadoBarra})
        Me.StatusBar.Location = New System.Drawing.Point(0, 687)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(1362, 22)
        Me.StatusBar.TabIndex = 147
        Me.StatusBar.Text = "Alarma"
        '
        'TEstadoInv
        '
        Me.TEstadoInv.BackColor = System.Drawing.Color.LightCoral
        Me.TEstadoInv.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEstadoInv.Name = "TEstadoInv"
        Me.TEstadoInv.Size = New System.Drawing.Size(60, 17)
        Me.TEstadoInv.Text = "Cerrado "
        '
        'BarraProgreso
        '
        Me.BarraProgreso.Name = "BarraProgreso"
        Me.BarraProgreso.Size = New System.Drawing.Size(100, 16)
        '
        'TEstadoBarra
        '
        Me.TEstadoBarra.Name = "TEstadoBarra"
        Me.TEstadoBarra.Size = New System.Drawing.Size(12, 17)
        Me.TEstadoBarra.Text = "-"
        '
        'FRevEstadoCierre
        '
        Me.FRevEstadoCierre.Location = New System.Drawing.Point(22, 258)
        Me.FRevEstadoCierre.Name = "FRevEstadoCierre"
        Me.FRevEstadoCierre.Size = New System.Drawing.Size(117, 23)
        Me.FRevEstadoCierre.TabIndex = 148
        Me.FRevEstadoCierre.Text = "FRevEstadoCierre"
        Me.FRevEstadoCierre.UseVisualStyleBackColor = True
        Me.FRevEstadoCierre.Visible = False
        '
        'TimIni
        '
        Me.TimIni.Enabled = True
        Me.TimIni.Interval = 40
        '
        'GBFechas
        '
        Me.GBFechas.Controls.Add(Me.TSFechas)
        Me.GBFechas.Location = New System.Drawing.Point(718, 66)
        Me.GBFechas.Name = "GBFechas"
        Me.GBFechas.Size = New System.Drawing.Size(599, 48)
        Me.GBFechas.TabIndex = 149
        Me.GBFechas.TabStop = False
        '
        'TSFechas
        '
        Me.TSFechas.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSFechas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.ToolStripSeparator12, Me.TFechaCierreInvFisico, Me.ToolStripSeparator13, Me.ToolStripLabel5, Me.ToolStripSeparator17, Me.TFechaActUNO})
        Me.TSFechas.Location = New System.Drawing.Point(3, 16)
        Me.TSFechas.Name = "TSFechas"
        Me.TSFechas.Size = New System.Drawing.Size(593, 25)
        Me.TSFechas.TabIndex = 0
        Me.TSFechas.Text = "ToolStrip2"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Lime
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(147, 22)
        Me.ToolStripLabel3.Text = "FECHA CIERRE INV. FISICO"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'TFechaCierreInvFisico
        '
        Me.TFechaCierreInvFisico.Name = "TFechaCierreInvFisico"
        Me.TFechaCierreInvFisico.Size = New System.Drawing.Size(65, 22)
        Me.TFechaCierreInvFisico.Text = "2014/04/25"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.BackColor = System.Drawing.Color.Lime
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripLabel5.Text = "FECHA ACTUALIZACIÓN INV. UNO"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'TFechaActUNO
        '
        Me.TFechaActUNO.Name = "TFechaActUNO"
        Me.TFechaActUNO.Size = New System.Drawing.Size(65, 22)
        Me.TFechaActUNO.Text = "2014/04/25"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TSTotales)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 633)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1355, 48)
        Me.GroupBox1.TabIndex = 150
        Me.GroupBox1.TabStop = False
        '
        'TSTotales
        '
        Me.TSTotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSTotales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripSeparator18, Me.ToolStripLabel6, Me.ToolStripSeparator19, Me.TSumInvMin, Me.ToolStripSeparator21, Me.ToolStripLabel8, Me.ToolStripSeparator22, Me.TSumInvFisico, Me.ToolStripSeparator23, Me.ToolStripLabel7, Me.ToolStripSeparator24, Me.TSumInvUno, Me.ToolStripSeparator25, Me.ToolStripLabel11, Me.ToolStripSeparator26, Me.TSumEntPend, Me.ToolStripSeparator27, Me.ToolStripLabel10, Me.ToolStripSeparator20, Me.TSumSalPend})
        Me.TSTotales.Location = New System.Drawing.Point(3, 16)
        Me.TSTotales.Name = "TSTotales"
        Me.TSTotales.Size = New System.Drawing.Size(1349, 25)
        Me.TSTotales.TabIndex = 0
        Me.TSTotales.Text = "ToolStrip2"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.BackColor = System.Drawing.Color.Lime
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel4.Text = "TOTALES (Kg):"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel6.Text = "INV.MIN:"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'TSumInvMin
        '
        Me.TSumInvMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSumInvMin.Name = "TSumInvMin"
        Me.TSumInvMin.Size = New System.Drawing.Size(13, 22)
        Me.TSumInvMin.Text = "0"
        Me.TSumInvMin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabel8.Text = "INV.FÍSICO"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(6, 25)
        '
        'TSumInvFisico
        '
        Me.TSumInvFisico.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSumInvFisico.Name = "TSumInvFisico"
        Me.TSumInvFisico.Size = New System.Drawing.Size(13, 22)
        Me.TSumInvFisico.Text = "0"
        Me.TSumInvFisico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel7.Text = "INV.UNO"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'TSumInvUno
        '
        Me.TSumInvUno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSumInvUno.Name = "TSumInvUno"
        Me.TSumInvUno.Size = New System.Drawing.Size(13, 22)
        Me.TSumInvUno.Text = "0"
        Me.TSumInvUno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel11
        '
        Me.ToolStripLabel11.Name = "ToolStripLabel11"
        Me.ToolStripLabel11.Size = New System.Drawing.Size(64, 22)
        Me.ToolStripLabel11.Text = "ENT.PEND."
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'TSumEntPend
        '
        Me.TSumEntPend.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSumEntPend.Name = "TSumEntPend"
        Me.TSumEntPend.Size = New System.Drawing.Size(13, 22)
        Me.TSumEntPend.Text = "0"
        Me.TSumEntPend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel10.Text = "SAL.PEND."
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'TSumSalPend
        '
        Me.TSumSalPend.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSumSalPend.Name = "TSumSalPend"
        Me.TSumSalPend.Size = New System.Drawing.Size(13, 22)
        Me.TSumSalPend.Text = "0"
        Me.TSumSalPend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FCalcTot
        '
        Me.FCalcTot.Location = New System.Drawing.Point(21, 287)
        Me.FCalcTot.Name = "FCalcTot"
        Me.FCalcTot.Size = New System.Drawing.Size(117, 23)
        Me.FCalcTot.TabIndex = 151
        Me.FCalcTot.Text = "FCalcTot"
        Me.FCalcTot.UseVisualStyleBackColor = True
        Me.FCalcTot.Visible = False
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
        'BMateriales
        '
        Me.BMateriales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BMateriales.Image = CType(resources.GetObject("BMateriales.Image"), System.Drawing.Image)
        Me.BMateriales.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BMateriales.Name = "BMateriales"
        Me.BMateriales.Size = New System.Drawing.Size(23, 22)
        Me.BMateriales.Text = "Materiales"
        '
        'BProductos
        '
        Me.BProductos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BProductos.Image = CType(resources.GetObject("BProductos.Image"), System.Drawing.Image)
        Me.BProductos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BProductos.Name = "BProductos"
        Me.BProductos.Size = New System.Drawing.Size(23, 22)
        Me.BProductos.Text = "Productos"
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
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'TBActInvFisico
        '
        Me.TBActInvFisico.Enabled = False
        Me.TBActInvFisico.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBActInvFisico.Image = CType(resources.GetObject("TBActInvFisico.Image"), System.Drawing.Image)
        Me.TBActInvFisico.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TBActInvFisico.Name = "TBActInvFisico"
        Me.TBActInvFisico.Size = New System.Drawing.Size(100, 22)
        Me.TBActInvFisico.Text = "Act. Inv. Físico"
        Me.TBActInvFisico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TBActInvFisico.Visible = False
        '
        'BActInvUNO
        '
        Me.BActInvUNO.BackColor = System.Drawing.Color.Gray
        Me.BActInvUNO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActInvUNO.Image = CType(resources.GetObject("BActInvUNO.Image"), System.Drawing.Image)
        Me.BActInvUNO.ImageTransparentColor = System.Drawing.Color.White
        Me.BActInvUNO.Name = "BActInvUNO"
        Me.BActInvUNO.Size = New System.Drawing.Size(23, 22)
        Me.BActInvUNO.Text = "Actualizar Inv. Sistema UNO"
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BImprimir
        '
        Me.BImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImprimir.Image = CType(resources.GetObject("BImprimir.Image"), System.Drawing.Image)
        Me.BImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImprimir.Name = "BImprimir"
        Me.BImprimir.Size = New System.Drawing.Size(23, 22)
        Me.BImprimir.Text = "Imprimir Comparativo Inventarios"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'BCerrarInv
        '
        Me.BCerrarInv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BCerrarInv.Image = CType(resources.GetObject("BCerrarInv.Image"), System.Drawing.Image)
        Me.BCerrarInv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BCerrarInv.Name = "BCerrarInv"
        Me.BCerrarInv.Size = New System.Drawing.Size(23, 22)
        Me.BCerrarInv.ToolTipText = "Cerrar Inventario"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BMateriales, Me.ToolStripSeparator2, Me.BProductos, Me.ToolStripSeparator1, Me.BActualizar, Me.ToolStripSeparator11, Me.BBorrar, Me.ToolStripSeparator14, Me.ToolStripLabel12, Me.BActInvUNO, Me.ToolStripSeparator8, Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.BAjustarInv, Me.ToolStripSeparator5, Me.TBActInvFisico, Me.BActInvFisico, Me.ToolStripSeparator7, Me.BImprimir, Me.ToolStripSeparator6, Me.BReportesInv, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar, Me.BCerrarInv})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1362, 25)
        Me.ToolStrip1.TabIndex = 35
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel12.Image = CType(resources.GetObject("ToolStripLabel12.Image"), System.Drawing.Image)
        Me.ToolStripLabel12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripLabel12.Text = "Act. Inv. UNO"
        Me.ToolStripLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Image = CType(resources.GetObject("ToolStripLabel1.Image"), System.Drawing.Image)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel1.Text = "Ajustar Inventario"
        Me.ToolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BAjustarInv
        '
        Me.BAjustarInv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BAjustarInv.Image = CType(resources.GetObject("BAjustarInv.Image"), System.Drawing.Image)
        Me.BAjustarInv.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAjustarInv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAjustarInv.Name = "BAjustarInv"
        Me.BAjustarInv.Size = New System.Drawing.Size(23, 22)
        Me.BAjustarInv.Text = "Ajustar Inventario"
        Me.BAjustarInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BActInvFisico
        '
        Me.BActInvFisico.BackColor = System.Drawing.Color.Gray
        Me.BActInvFisico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActInvFisico.Enabled = False
        Me.BActInvFisico.Image = CType(resources.GetObject("BActInvFisico.Image"), System.Drawing.Image)
        Me.BActInvFisico.ImageTransparentColor = System.Drawing.Color.White
        Me.BActInvFisico.Name = "BActInvFisico"
        Me.BActInvFisico.Size = New System.Drawing.Size(23, 22)
        Me.BActInvFisico.Text = "Actualizar Inv. Físico"
        Me.BActInvFisico.Visible = False
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'BReportesInv
        '
        Me.BReportesInv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BReportesInv.Image = CType(resources.GetObject("BReportesInv.Image"), System.Drawing.Image)
        Me.BReportesInv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BReportesInv.Name = "BReportesInv"
        Me.BReportesInv.Size = New System.Drawing.Size(23, 22)
        Me.BReportesInv.ToolTipText = "Detalle Inventarios"
        '
        'FExportExcel
        '
        Me.FExportExcel.Location = New System.Drawing.Point(21, 316)
        Me.FExportExcel.Name = "FExportExcel"
        Me.FExportExcel.Size = New System.Drawing.Size(117, 23)
        Me.FExportExcel.TabIndex = 152
        Me.FExportExcel.Text = "FExportExcel"
        Me.FExportExcel.UseVisualStyleBackColor = True
        Me.FExportExcel.Visible = False
        '
        'FGuardaHist
        '
        Me.FGuardaHist.Location = New System.Drawing.Point(23, 345)
        Me.FGuardaHist.Name = "FGuardaHist"
        Me.FGuardaHist.Size = New System.Drawing.Size(116, 23)
        Me.FGuardaHist.TabIndex = 153
        Me.FGuardaHist.Text = "FGuardaHist"
        Me.FGuardaHist.UseVisualStyleBackColor = True
        Me.FGuardaHist.Visible = False
        '
        'ComparativoInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 709)
        Me.Controls.Add(Me.FGuardaHist)
        Me.Controls.Add(Me.FCalcTot)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FExportExcel)
        Me.Controls.Add(Me.GBFechas)
        Me.Controls.Add(Me.FRevEstadoCierre)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.FResetInv)
        Me.Controls.Add(Me.TSeg)
        Me.Controls.Add(Me.FSeparador)
        Me.Controls.Add(Me.FRefrescaDG)
        Me.Controls.Add(Me.GBFiltrar)
        Me.Controls.Add(Me.DGCompInv)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ComparativoInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comparativo Inventarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGCompInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuDG.ResumeLayout(False)
        Me.GBFiltrar.ResumeLayout(False)
        Me.GBFiltrar.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.GBFechas.ResumeLayout(False)
        Me.GBFechas.PerformLayout()
        Me.TSFechas.ResumeLayout(False)
        Me.TSFechas.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TSTotales.ResumeLayout(False)
        Me.TSTotales.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnArticulos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAdicionarArt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnInhabilitar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGCompInv As System.Windows.Forms.DataGridView
    Friend WithEvents GBFiltrar As System.Windows.Forms.GroupBox
    Friend WithEvents OPPrem As System.Windows.Forms.RadioButton
    Friend WithEvents OPAditivos As System.Windows.Forms.RadioButton
    Friend WithEvents OPEtiquetas As System.Windows.Forms.RadioButton
    Friend WithEvents OPEmpaque As System.Windows.Forms.RadioButton
    Friend WithEvents OPPT As System.Windows.Forms.RadioButton
    Friend WithEvents OPMP As System.Windows.Forms.RadioButton
    Friend WithEvents FRefrescaDG As System.Windows.Forms.Button
    Friend WithEvents FSeparador As System.Windows.Forms.Button
    Friend WithEvents TimSeg As System.Windows.Forms.Timer
    Friend WithEvents TSeg As System.Windows.Forms.TextBox
    Friend WithEvents FResetInv As System.Windows.Forms.Button
    Friend WithEvents Iconos As System.Windows.Forms.ImageList
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents TEstadoInv As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FRevEstadoCierre As System.Windows.Forms.Button
    Friend WithEvents mnAdicionaTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimIni As System.Windows.Forms.Timer
    Friend WithEvents BarraProgreso As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TEstadoBarra As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GBFechas As System.Windows.Forms.GroupBox
    Friend WithEvents TSFechas As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TFechaCierreInvFisico As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TFechaActUNO As System.Windows.Forms.ToolStripLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TSTotales As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel11 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel10 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FCalcTot As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSumInvMin As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSumInvFisico As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSumInvUno As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSumEntPend As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSumSalPend As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MenuDG As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnMenuDGNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnMenuDGEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBActualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BMateriales As System.Windows.Forms.ToolStripButton
    Friend WithEvents BProductos As System.Windows.Forms.ToolStripButton
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TBActInvFisico As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BActInvUNO As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BCerrarInv As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BAjustarInv As System.Windows.Forms.ToolStripButton
    Friend WithEvents FExportExcel As System.Windows.Forms.Button
    Friend WithEvents FGuardaHist As System.Windows.Forms.Button
    Friend WithEvents CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvFisico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntPend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalPend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvUno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DifFisicoUno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConsumoMes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PorcVariacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservBodega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservCostos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservMaquilas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BReportesInv As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel12 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActInvFisico As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
End Class
