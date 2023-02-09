<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inventarios
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inventarios))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BPrimero = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BAnterior = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnTCuenta = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.mnLCuenta = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BUltimo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.BActInvUNO = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.BAjustarInv = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.DGInv = New System.Windows.Forms.DataGridView()
        Me.CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipomat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bascula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvChronos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvFisico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvUno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.A = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContexMenuInv = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnAjustarInv = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnInvChronos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnInvFisico = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GBFiltrar = New System.Windows.Forms.GroupBox()
        Me.OPPrem = New System.Windows.Forms.RadioButton()
        Me.OPLiquidos = New System.Windows.Forms.RadioButton()
        Me.OPAditivos = New System.Windows.Forms.RadioButton()
        Me.OPTodos = New System.Windows.Forms.RadioButton()
        Me.OPEtiquetas = New System.Windows.Forms.RadioButton()
        Me.OPEmpaque = New System.Windows.Forms.RadioButton()
        Me.OPPT = New System.Windows.Forms.RadioButton()
        Me.OPMP = New System.Windows.Forms.RadioButton()
        Me.GBAjustes = New System.Windows.Forms.GroupBox()
        Me.TLote = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TCodInt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TObservaciones = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TSale = New System.Windows.Forms.TextBox()
        Me.CUbicacion = New System.Windows.Forms.ComboBox()
        Me.TEntra = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContexMenuInv.SuspendLayout()
        Me.GBFiltrar.SuspendLayout()
        Me.GBAjustes.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BPrimero, Me.ToolStripSeparator1, Me.BAnterior, Me.ToolStripSeparator2, Me.mnTCuenta, Me.ToolStripLabel1, Me.mnLCuenta, Me.ToolStripSeparator7, Me.BSiguiente, Me.ToolStripSeparator3, Me.BUltimo, Me.ToolStripSeparator4, Me.BActualizar, Me.ToolStripSeparator10, Me.ToolStripLabel2, Me.BActInvUNO, Me.ToolStripSeparator5, Me.ToolStripLabel4, Me.BAjustarInv, Me.ToolStripSeparator6, Me.ToolStripLabel3, Me.CBBuscar, Me.TBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(927, 25)
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
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'BPrimero
        '
        Me.BPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BPrimero.Image = CType(resources.GetObject("BPrimero.Image"), System.Drawing.Image)
        Me.BPrimero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BPrimero.Name = "BPrimero"
        Me.BPrimero.Size = New System.Drawing.Size(23, 22)
        Me.BPrimero.Text = "First"
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
        'mnTCuenta
        '
        Me.mnTCuenta.BackColor = System.Drawing.Color.White
        Me.mnTCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnTCuenta.Name = "mnTCuenta"
        Me.mnTCuenta.ReadOnly = True
        Me.mnTCuenta.Size = New System.Drawing.Size(50, 25)
        Me.mnTCuenta.Text = "1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(20, 22)
        Me.ToolStripLabel1.Text = "de"
        '
        'mnLCuenta
        '
        Me.mnLCuenta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnLCuenta.Name = "mnLCuenta"
        Me.mnLCuenta.Size = New System.Drawing.Size(21, 22)
        Me.mnLCuenta.Text = "{0}"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
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
        'BUltimo
        '
        Me.BUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BUltimo.Image = CType(resources.GetObject("BUltimo.Image"), System.Drawing.Image)
        Me.BUltimo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BUltimo.Name = "BUltimo"
        Me.BUltimo.Size = New System.Drawing.Size(23, 22)
        Me.BUltimo.Text = "Last"
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
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripLabel2.Text = "Act. Inv. UNO"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Image = CType(resources.GetObject("ToolStripLabel4.Image"), System.Drawing.Image)
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel4.Text = "Ajustar Inventario"
        Me.ToolStripLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Image = CType(resources.GetObject("ToolStripLabel3.Image"), System.Drawing.Image)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel3.Text = "Buscar"
        Me.ToolStripLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBBuscar
        '
        Me.CBBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscar.DropDownWidth = 80
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(90, 25)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(200, 25)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnOtros, Me.mnAcercaDe})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(927, 24)
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
        'DGInv
        '
        Me.DGInv.AllowUserToAddRows = False
        Me.DGInv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGInv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGInv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodInt, Me.tipomat, Me.Bascula, Me.Nombre, Me.InvChronos, Me.InvFisico, Me.InvUno, Me.Tipo, Me.A})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGInv.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGInv.Location = New System.Drawing.Point(28, 174)
        Me.DGInv.MultiSelect = False
        Me.DGInv.Name = "DGInv"
        Me.DGInv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGInv.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGInv.Size = New System.Drawing.Size(882, 506)
        Me.DGInv.TabIndex = 130
        '
        'CodInt
        '
        Me.CodInt.HeaderText = "Cód.Int."
        Me.CodInt.Name = "CodInt"
        Me.CodInt.ReadOnly = True
        Me.CodInt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodInt.Width = 70
        '
        'tipomat
        '
        Me.tipomat.HeaderText = "tipomat"
        Me.tipomat.Name = "tipomat"
        Me.tipomat.Visible = False
        '
        'Bascula
        '
        Me.Bascula.HeaderText = "bascula"
        Me.Bascula.Name = "Bascula"
        Me.Bascula.Visible = False
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Nombre.Width = 180
        '
        'InvChronos
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.InvChronos.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvChronos.HeaderText = "Inv. ChronoSoft"
        Me.InvChronos.Name = "InvChronos"
        Me.InvChronos.ReadOnly = True
        Me.InvChronos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.InvChronos.Width = 150
        '
        'InvFisico
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.InvFisico.DefaultCellStyle = DataGridViewCellStyle3
        Me.InvFisico.HeaderText = "Inv. Físico"
        Me.InvFisico.Name = "InvFisico"
        Me.InvFisico.ReadOnly = True
        Me.InvFisico.Width = 150
        '
        'InvUno
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.InvUno.DefaultCellStyle = DataGridViewCellStyle4
        Me.InvUno.HeaderText = "Inv. Uno"
        Me.InvUno.Name = "InvUno"
        Me.InvUno.ReadOnly = True
        Me.InvUno.Width = 150
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 50
        '
        'A
        '
        Me.A.HeaderText = "Modo"
        Me.A.Name = "A"
        Me.A.Visible = False
        '
        'ContexMenuInv
        '
        Me.ContexMenuInv.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnAjustarInv})
        Me.ContexMenuInv.Name = "ContexMenuFor"
        Me.ContexMenuInv.Size = New System.Drawing.Size(168, 26)
        '
        'mnAjustarInv
        '
        Me.mnAjustarInv.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnInvChronos, Me.mnInvFisico})
        Me.mnAjustarInv.Image = CType(resources.GetObject("mnAjustarInv.Image"), System.Drawing.Image)
        Me.mnAjustarInv.Name = "mnAjustarInv"
        Me.mnAjustarInv.Size = New System.Drawing.Size(167, 22)
        Me.mnAjustarInv.Text = "Ajustar Inventario"
        '
        'mnInvChronos
        '
        Me.mnInvChronos.Name = "mnInvChronos"
        Me.mnInvChronos.Size = New System.Drawing.Size(135, 22)
        Me.mnInvChronos.Text = "ChronoSoft"
        '
        'mnInvFisico
        '
        Me.mnInvFisico.Name = "mnInvFisico"
        Me.mnInvFisico.Size = New System.Drawing.Size(135, 22)
        Me.mnInvFisico.Text = "Físico"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(221, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(308, 22)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Inventario Global de ChronoSoft"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(751, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 14)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Materia Prima"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(751, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 14)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Producto Terminado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(751, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Etiquetas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(751, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 14)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Empaque"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Cornsilk
        Me.Label6.Location = New System.Drawing.Point(735, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightCoral
        Me.Label7.Location = New System.Drawing.Point(735, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightCyan
        Me.Label8.Location = New System.Drawing.Point(735, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "-"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(735, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 140
        Me.Label9.Text = "-"
        '
        'GBFiltrar
        '
        Me.GBFiltrar.Controls.Add(Me.OPPrem)
        Me.GBFiltrar.Controls.Add(Me.OPLiquidos)
        Me.GBFiltrar.Controls.Add(Me.OPAditivos)
        Me.GBFiltrar.Controls.Add(Me.OPTodos)
        Me.GBFiltrar.Controls.Add(Me.OPEtiquetas)
        Me.GBFiltrar.Controls.Add(Me.OPEmpaque)
        Me.GBFiltrar.Controls.Add(Me.OPPT)
        Me.GBFiltrar.Controls.Add(Me.OPMP)
        Me.GBFiltrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBFiltrar.ForeColor = System.Drawing.Color.Blue
        Me.GBFiltrar.Location = New System.Drawing.Point(24, 120)
        Me.GBFiltrar.Name = "GBFiltrar"
        Me.GBFiltrar.Size = New System.Drawing.Size(888, 48)
        Me.GBFiltrar.TabIndex = 141
        Me.GBFiltrar.TabStop = False
        Me.GBFiltrar.Text = "Filtrar por Tipo"
        '
        'OPPrem
        '
        Me.OPPrem.AutoSize = True
        Me.OPPrem.ForeColor = System.Drawing.Color.Blue
        Me.OPPrem.Location = New System.Drawing.Point(347, 20)
        Me.OPPrem.Name = "OPPrem"
        Me.OPPrem.Size = New System.Drawing.Size(100, 20)
        Me.OPPrem.TabIndex = 7
        Me.OPPrem.TabStop = True
        Me.OPPrem.Text = "Premezclas"
        Me.OPPrem.UseVisualStyleBackColor = True
        '
        'OPLiquidos
        '
        Me.OPLiquidos.AutoSize = True
        Me.OPLiquidos.ForeColor = System.Drawing.Color.Blue
        Me.OPLiquidos.Location = New System.Drawing.Point(254, 20)
        Me.OPLiquidos.Name = "OPLiquidos"
        Me.OPLiquidos.Size = New System.Drawing.Size(80, 20)
        Me.OPLiquidos.TabIndex = 6
        Me.OPLiquidos.TabStop = True
        Me.OPLiquidos.Text = "Liquidos"
        Me.OPLiquidos.UseVisualStyleBackColor = True
        '
        'OPAditivos
        '
        Me.OPAditivos.AutoSize = True
        Me.OPAditivos.ForeColor = System.Drawing.Color.Blue
        Me.OPAditivos.Location = New System.Drawing.Point(151, 19)
        Me.OPAditivos.Name = "OPAditivos"
        Me.OPAditivos.Size = New System.Drawing.Size(76, 20)
        Me.OPAditivos.TabIndex = 5
        Me.OPAditivos.TabStop = True
        Me.OPAditivos.Text = "Aditivos"
        Me.OPAditivos.UseVisualStyleBackColor = True
        '
        'OPTodos
        '
        Me.OPTodos.AutoSize = True
        Me.OPTodos.ForeColor = System.Drawing.Color.Blue
        Me.OPTodos.Location = New System.Drawing.Point(823, 20)
        Me.OPTodos.Name = "OPTodos"
        Me.OPTodos.Size = New System.Drawing.Size(63, 20)
        Me.OPTodos.TabIndex = 4
        Me.OPTodos.TabStop = True
        Me.OPTodos.Text = "Todos"
        Me.OPTodos.UseVisualStyleBackColor = True
        '
        'OPEtiquetas
        '
        Me.OPEtiquetas.AutoSize = True
        Me.OPEtiquetas.ForeColor = System.Drawing.Color.Blue
        Me.OPEtiquetas.Location = New System.Drawing.Point(732, 21)
        Me.OPEtiquetas.Name = "OPEtiquetas"
        Me.OPEtiquetas.Size = New System.Drawing.Size(84, 20)
        Me.OPEtiquetas.TabIndex = 3
        Me.OPEtiquetas.TabStop = True
        Me.OPEtiquetas.Text = "Etiquetas"
        Me.OPEtiquetas.UseVisualStyleBackColor = True
        '
        'OPEmpaque
        '
        Me.OPEmpaque.AutoSize = True
        Me.OPEmpaque.ForeColor = System.Drawing.Color.Blue
        Me.OPEmpaque.Location = New System.Drawing.Point(631, 20)
        Me.OPEmpaque.Name = "OPEmpaque"
        Me.OPEmpaque.Size = New System.Drawing.Size(86, 20)
        Me.OPEmpaque.TabIndex = 2
        Me.OPEmpaque.TabStop = True
        Me.OPEmpaque.Text = "Empaque"
        Me.OPEmpaque.UseVisualStyleBackColor = True
        '
        'OPPT
        '
        Me.OPPT.AutoSize = True
        Me.OPPT.ForeColor = System.Drawing.Color.Blue
        Me.OPPT.Location = New System.Drawing.Point(463, 20)
        Me.OPPT.Name = "OPPT"
        Me.OPPT.Size = New System.Drawing.Size(155, 20)
        Me.OPPT.TabIndex = 1
        Me.OPPT.TabStop = True
        Me.OPPT.Text = "Producto Terminado"
        Me.OPPT.UseVisualStyleBackColor = True
        '
        'OPMP
        '
        Me.OPMP.AutoSize = True
        Me.OPMP.ForeColor = System.Drawing.Color.Blue
        Me.OPMP.Location = New System.Drawing.Point(10, 19)
        Me.OPMP.Name = "OPMP"
        Me.OPMP.Size = New System.Drawing.Size(116, 20)
        Me.OPMP.TabIndex = 0
        Me.OPMP.TabStop = True
        Me.OPMP.Text = "Materia Prima"
        Me.OPMP.UseVisualStyleBackColor = True
        '
        'GBAjustes
        '
        Me.GBAjustes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GBAjustes.Controls.Add(Me.TLote)
        Me.GBAjustes.Controls.Add(Me.Label16)
        Me.GBAjustes.Controls.Add(Me.Label15)
        Me.GBAjustes.Controls.Add(Me.TCodInt)
        Me.GBAjustes.Controls.Add(Me.Label14)
        Me.GBAjustes.Controls.Add(Me.Label13)
        Me.GBAjustes.Controls.Add(Me.TObservaciones)
        Me.GBAjustes.Controls.Add(Me.BCancelar)
        Me.GBAjustes.Controls.Add(Me.BAceptar)
        Me.GBAjustes.Controls.Add(Me.TSale)
        Me.GBAjustes.Controls.Add(Me.CUbicacion)
        Me.GBAjustes.Controls.Add(Me.TEntra)
        Me.GBAjustes.Controls.Add(Me.Label12)
        Me.GBAjustes.Controls.Add(Me.Label11)
        Me.GBAjustes.Controls.Add(Me.Label10)
        Me.GBAjustes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBAjustes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GBAjustes.Location = New System.Drawing.Point(562, 209)
        Me.GBAjustes.Name = "GBAjustes"
        Me.GBAjustes.Size = New System.Drawing.Size(247, 257)
        Me.GBAjustes.TabIndex = 142
        Me.GBAjustes.TabStop = False
        Me.GBAjustes.Visible = False
        '
        'TLote
        '
        Me.TLote.Location = New System.Drawing.Point(21, 154)
        Me.TLote.Name = "TLote"
        Me.TLote.Size = New System.Drawing.Size(100, 22)
        Me.TLote.TabIndex = 167
        Me.TLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 135)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 16)
        Me.Label16.TabIndex = 166
        Me.Label16.Text = "Lote"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 16)
        Me.Label15.TabIndex = 165
        Me.Label15.Text = "Código"
        '
        'TCodInt
        '
        Me.TCodInt.Location = New System.Drawing.Point(22, 62)
        Me.TCodInt.Name = "TCodInt"
        Me.TCodInt.Size = New System.Drawing.Size(100, 22)
        Me.TCodInt.TabIndex = 164
        Me.TCodInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(44, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 16)
        Me.Label14.TabIndex = 163
        Me.Label14.Text = " Ajustes de Inventario"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 16)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "Observaciones"
        '
        'TObservaciones
        '
        Me.TObservaciones.Location = New System.Drawing.Point(20, 198)
        Me.TObservaciones.Multiline = True
        Me.TObservaciones.Name = "TObservaciones"
        Me.TObservaciones.Size = New System.Drawing.Size(173, 52)
        Me.TObservaciones.TabIndex = 161
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(198, 223)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(36, 31)
        Me.BCancelar.TabIndex = 160
        Me.BCancelar.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(197, 194)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(37, 31)
        Me.BAceptar.TabIndex = 159
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'TSale
        '
        Me.TSale.Location = New System.Drawing.Point(134, 107)
        Me.TSale.Name = "TSale"
        Me.TSale.Size = New System.Drawing.Size(100, 22)
        Me.TSale.TabIndex = 158
        Me.TSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CUbicacion
        '
        Me.CUbicacion.FormattingEnabled = True
        Me.CUbicacion.Location = New System.Drawing.Point(135, 154)
        Me.CUbicacion.Name = "CUbicacion"
        Me.CUbicacion.Size = New System.Drawing.Size(98, 24)
        Me.CUbicacion.TabIndex = 157
        '
        'TEntra
        '
        Me.TEntra.Location = New System.Drawing.Point(21, 107)
        Me.TEntra.Name = "TEntra"
        Me.TEntra.Size = New System.Drawing.Size(100, 22)
        Me.TEntra.TabIndex = 3
        Me.TEntra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(134, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Ubicación"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(132, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 16)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Sale"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Entra"
        '
        'Inventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 692)
        Me.Controls.Add(Me.GBAjustes)
        Me.Controls.Add(Me.GBFiltrar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGInv)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Inventarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventarios"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContexMenuInv.ResumeLayout(False)
        Me.GBFiltrar.ResumeLayout(False)
        Me.GBFiltrar.PerformLayout()
        Me.GBAjustes.ResumeLayout(False)
        Me.GBAjustes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnTCuenta As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents mnLCuenta As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BActInvUNO As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGInv As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents GBFiltrar As System.Windows.Forms.GroupBox
    Friend WithEvents OPEtiquetas As System.Windows.Forms.RadioButton
    Friend WithEvents OPEmpaque As System.Windows.Forms.RadioButton
    Friend WithEvents OPPT As System.Windows.Forms.RadioButton
    Friend WithEvents OPMP As System.Windows.Forms.RadioButton
    Friend WithEvents OPTodos As System.Windows.Forms.RadioButton
    Friend WithEvents GBAjustes As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TEntra As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TSale As System.Windows.Forms.TextBox
    Friend WithEvents CUbicacion As System.Windows.Forms.ComboBox
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents ContexMenuInv As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnAjustarInv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnInvChronos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnInvFisico As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TCodInt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents OPLiquidos As System.Windows.Forms.RadioButton
    Friend WithEvents OPAditivos As System.Windows.Forms.RadioButton
    Friend WithEvents OPPrem As System.Windows.Forms.RadioButton
    Friend WithEvents CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipomat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bascula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvChronos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvFisico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvUno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents A As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BAjustarInv As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TLote As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
