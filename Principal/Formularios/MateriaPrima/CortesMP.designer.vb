<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CortesMP
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CortesMP))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGCortes = New System.Windows.Forms.DataGridView()
        Me.Cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UbicLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescUbicLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Finalizado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VIGENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.invini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pesoprom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BFinalizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.BImportLotes = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BDescartar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActConsumo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnVer = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnAbiertos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCerrados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnVerFinalizados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.BAbrirCorte = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.BCerrarCorte = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnImp = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnImpCorteAct = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnImpAbiertos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnObservCortes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCortesPrem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBusquedaAvanz = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.BExportar = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMateriales = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnFormulación = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OPEtiq = New System.Windows.Forms.RadioButton()
        Me.OPEmp = New System.Windows.Forms.RadioButton()
        Me.DGArticulos = New System.Windows.Forms.DataGridView()
        Me.CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpMP = New System.Windows.Forms.RadioButton()
        Me.TContCorte = New System.Windows.Forms.TextBox()
        Me.PanDatos = New System.Windows.Forms.Panel()
        Me.TabDatos = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBProveedor = New System.Windows.Forms.GroupBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TNomCli = New System.Windows.Forms.TextBox()
        Me.TCodCli = New System.Windows.Forms.TextBox()
        Me.THora = New System.Windows.Forms.DateTimePicker()
        Me.TFecha = New System.Windows.Forms.DateTimePicker()
        Me.LFechaIng = New System.Windows.Forms.Label()
        Me.TPaqporBache = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TPesoProm = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TDescUbicacion = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TUbicacion = New System.Windows.Forms.TextBox()
        Me.TCondicion = New System.Windows.Forms.ComboBox()
        Me.TEstado = New System.Windows.Forms.ComboBox()
        Me.BAdicionar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TSalInv = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TEntInv = New System.Windows.Forms.TextBox()
        Me.TAjusteEnt = New System.Windows.Forms.TextBox()
        Me.TAjusteSal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TLote = New System.Windows.Forms.TextBox()
        Me.TObserv = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LMas = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCantAdic = New System.Windows.Forms.TextBox()
        Me.TFaltaAprox = New System.Windows.Forms.TextBox()
        Me.TConsumo = New System.Windows.Forms.TextBox()
        Me.TAlarma = New System.Windows.Forms.TextBox()
        Me.TInvIni = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GBEtiqueta = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TSecuencia = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TFechaEnt = New System.Windows.Forms.TextBox()
        Me.BImpEtiq = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TNoCopias = New System.Windows.Forms.NumericUpDown()
        Me.TPesoPromEdit = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.THumedad = New System.Windows.Forms.TextBox()
        Me.TGrasa = New System.Windows.Forms.TextBox()
        Me.TProteina = New System.Windows.Forms.TextBox()
        Me.TCeniza = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TFechaFin = New System.Windows.Forms.TextBox()
        Me.TFechaIni = New System.Windows.Forms.TextBox()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.PanMat = New System.Windows.Forms.Panel()
        Me.TLinea = New System.Windows.Forms.TextBox()
        Me.TCodMat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TNomMat = New System.Windows.Forms.ComboBox()
        Me.BLimpiar = New System.Windows.Forms.Button()
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.BCDate = New System.Windows.Forms.Button()
        Me.FrFiltrar = New System.Windows.Forms.GroupBox()
        Me.TUbicacionF = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.OPFinalizados = New System.Windows.Forms.CheckBox()
        Me.TLoteF = New System.Windows.Forms.TextBox()
        Me.TNomMatF = New System.Windows.Forms.TextBox()
        Me.TCodMatF = New System.Windows.Forms.TextBox()
        Me.BCancelarFiltrar = New System.Windows.Forms.Button()
        Me.BOKFiltrar = New System.Windows.Forms.Button()
        Me.DGUbic = New System.Windows.Forms.DataGridView()
        Me.CODUBI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Consumo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BExportCortes = New System.Windows.Forms.Button()
        Me.BExportArt = New System.Windows.Forms.Button()
        Me.MnTrasladaCorte = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnModCodProd2Emp = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGClientes = New System.Windows.Forms.DataGridView()
        Me.CODCLI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomCli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChTodos = New System.Windows.Forms.CheckBox()
        CType(Me.DGCortes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanDatos.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBProveedor.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GBEtiqueta.SuspendLayout()
        CType(Me.TNoCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.PanMat.SuspendLayout()
        Me.FrFiltrar.SuspendLayout()
        CType(Me.DGUbic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MnTrasladaCorte.SuspendLayout()
        CType(Me.DGClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGCortes
        '
        Me.DGCortes.AllowUserToAddRows = False
        Me.DGCortes.AllowUserToDeleteRows = False
        Me.DGCortes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGCortes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGCortes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCortes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cont, Me.CodMat, Me.NomMat, Me.UbicLote, Me.DescUbicLote, Me.Lote, Me.Estado, Me.Finalizado, Me.VIGENTE, Me.invini, Me.pesoprom})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGCortes.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGCortes.Location = New System.Drawing.Point(536, 85)
        Me.DGCortes.MultiSelect = False
        Me.DGCortes.Name = "DGCortes"
        Me.DGCortes.ReadOnly = True
        Me.DGCortes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCortes.Size = New System.Drawing.Size(769, 605)
        Me.DGCortes.TabIndex = 25
        '
        'Cont
        '
        Me.Cont.HeaderText = "Cont"
        Me.Cont.Name = "Cont"
        Me.Cont.ReadOnly = True
        Me.Cont.Width = 80
        '
        'CodMat
        '
        Me.CodMat.HeaderText = "Código"
        Me.CodMat.Name = "CodMat"
        Me.CodMat.ReadOnly = True
        Me.CodMat.Width = 80
        '
        'NomMat
        '
        Me.NomMat.HeaderText = "Nombre"
        Me.NomMat.Name = "NomMat"
        Me.NomMat.ReadOnly = True
        Me.NomMat.Width = 120
        '
        'UbicLote
        '
        Me.UbicLote.HeaderText = "Ubicacion"
        Me.UbicLote.Name = "UbicLote"
        Me.UbicLote.ReadOnly = True
        Me.UbicLote.Width = 70
        '
        'DescUbicLote
        '
        Me.DescUbicLote.HeaderText = "Nombre Ubic"
        Me.DescUbicLote.Name = "DescUbicLote"
        Me.DescUbicLote.ReadOnly = True
        '
        'Lote
        '
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 80
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 50
        '
        'Finalizado
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Finalizado.DefaultCellStyle = DataGridViewCellStyle2
        Me.Finalizado.HeaderText = "Finalizado"
        Me.Finalizado.Name = "Finalizado"
        Me.Finalizado.ReadOnly = True
        Me.Finalizado.Width = 55
        '
        'VIGENTE
        '
        Me.VIGENTE.HeaderText = "Vigente"
        Me.VIGENTE.Name = "VIGENTE"
        Me.VIGENTE.ReadOnly = True
        '
        'invini
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "#,###.#"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.invini.DefaultCellStyle = DataGridViewCellStyle3
        Me.invini.HeaderText = "Inv.Ini"
        Me.invini.Name = "invini"
        Me.invini.ReadOnly = True
        Me.invini.Width = 80
        '
        'pesoprom
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.pesoprom.DefaultCellStyle = DataGridViewCellStyle4
        Me.pesoprom.HeaderText = "PromSaco"
        Me.pesoprom.Name = "pesoprom"
        Me.pesoprom.ReadOnly = True
        Me.pesoprom.Width = 70
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BModificar, Me.ToolStripSeparator8, Me.BNuevo, Me.ToolStripSeparator5, Me.BFinalizar, Me.ToolStripSeparator14, Me.BImportLotes, Me.ToolStripSeparator6, Me.BEliminar, Me.ToolStripSeparator2, Me.BDescartar, Me.ToolStripSeparator1, Me.BActConsumo, Me.ToolStripSeparator15, Me.BActualizar, Me.ToolStripSeparator10, Me.mnVer, Me.ToolStripSeparator11, Me.BAbrirCorte, Me.ToolStripSeparator12, Me.BCerrarCorte, Me.ToolStripSeparator13, Me.mnImp, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar, Me.ToolStripSeparator16, Me.BBusquedaAvanz, Me.ToolStripSeparator17, Me.BExportar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1317, 25)
        Me.ToolStrip1.TabIndex = 28
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
        'BModificar
        '
        Me.BModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BModificar.Image = CType(resources.GetObject("BModificar.Image"), System.Drawing.Image)
        Me.BModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BModificar.Name = "BModificar"
        Me.BModificar.Size = New System.Drawing.Size(23, 22)
        Me.BModificar.Text = "Editar"
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
        'BFinalizar
        '
        Me.BFinalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BFinalizar.Image = CType(resources.GetObject("BFinalizar.Image"), System.Drawing.Image)
        Me.BFinalizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BFinalizar.Name = "BFinalizar"
        Me.BFinalizar.Size = New System.Drawing.Size(23, 22)
        Me.BFinalizar.Text = " Eliminar"
        Me.BFinalizar.ToolTipText = " Finalizar"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'BImportLotes
        '
        Me.BImportLotes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImportLotes.Image = CType(resources.GetObject("BImportLotes.Image"), System.Drawing.Image)
        Me.BImportLotes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImportLotes.Name = "BImportLotes"
        Me.BImportLotes.Size = New System.Drawing.Size(23, 22)
        Me.BImportLotes.Text = "Importar lotes de sistema neptuno"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'BEliminar
        '
        Me.BEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEliminar.Image = CType(resources.GetObject("BEliminar.Image"), System.Drawing.Image)
        Me.BEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEliminar.Name = "BEliminar"
        Me.BEliminar.Size = New System.Drawing.Size(23, 22)
        Me.BEliminar.Text = "Descartar Corte"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BDescartar
        '
        Me.BDescartar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BDescartar.Image = CType(resources.GetObject("BDescartar.Image"), System.Drawing.Image)
        Me.BDescartar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BDescartar.Name = "BDescartar"
        Me.BDescartar.Size = New System.Drawing.Size(23, 22)
        Me.BDescartar.Text = "Descartar Corte"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BActConsumo
        '
        Me.BActConsumo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActConsumo.Image = CType(resources.GetObject("BActConsumo.Image"), System.Drawing.Image)
        Me.BActConsumo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BActConsumo.Name = "BActConsumo"
        Me.BActConsumo.Size = New System.Drawing.Size(23, 22)
        Me.BActConsumo.Text = "Actualizar"
        Me.BActConsumo.ToolTipText = "Actualizar consumo"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
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
        'mnVer
        '
        Me.mnVer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnVer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnAbiertos, Me.mnCerrados, Me.mnVerFinalizados, Me.mnTodos})
        Me.mnVer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnVer.Name = "mnVer"
        Me.mnVer.Size = New System.Drawing.Size(103, 22)
        Me.mnVer.Text = "Ver Cortes MP"
        '
        'mnAbiertos
        '
        Me.mnAbiertos.Name = "mnAbiertos"
        Me.mnAbiertos.Size = New System.Drawing.Size(135, 22)
        Me.mnAbiertos.Text = "Abiertos"
        '
        'mnCerrados
        '
        Me.mnCerrados.Name = "mnCerrados"
        Me.mnCerrados.Size = New System.Drawing.Size(135, 22)
        Me.mnCerrados.Text = "Cerrados"
        '
        'mnVerFinalizados
        '
        Me.mnVerFinalizados.Name = "mnVerFinalizados"
        Me.mnVerFinalizados.Size = New System.Drawing.Size(135, 22)
        Me.mnVerFinalizados.Text = "Finalizados"
        '
        'mnTodos
        '
        Me.mnTodos.Name = "mnTodos"
        Me.mnTodos.Size = New System.Drawing.Size(135, 22)
        Me.mnTodos.Text = "Todos"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'BAbrirCorte
        '
        Me.BAbrirCorte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BAbrirCorte.Image = CType(resources.GetObject("BAbrirCorte.Image"), System.Drawing.Image)
        Me.BAbrirCorte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BAbrirCorte.Name = "BAbrirCorte"
        Me.BAbrirCorte.Size = New System.Drawing.Size(23, 22)
        Me.BAbrirCorte.Text = " Abrir Corte"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'BCerrarCorte
        '
        Me.BCerrarCorte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BCerrarCorte.Image = CType(resources.GetObject("BCerrarCorte.Image"), System.Drawing.Image)
        Me.BCerrarCorte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BCerrarCorte.Name = "BCerrarCorte"
        Me.BCerrarCorte.Size = New System.Drawing.Size(23, 22)
        Me.BCerrarCorte.Text = " Cerrar Corte"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'mnImp
        '
        Me.mnImp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnImpCorteAct, Me.mnImpAbiertos, Me.mnObservCortes, Me.mnCortesPrem})
        Me.mnImp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnImp.Image = CType(resources.GetObject("mnImp.Image"), System.Drawing.Image)
        Me.mnImp.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.mnImp.ImageTransparentColor = System.Drawing.Color.White
        Me.mnImp.Name = "mnImp"
        Me.mnImp.Size = New System.Drawing.Size(87, 22)
        Me.mnImp.Text = "Imprimir"
        Me.mnImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnImpCorteAct
        '
        Me.mnImpCorteAct.Image = CType(resources.GetObject("mnImpCorteAct.Image"), System.Drawing.Image)
        Me.mnImpCorteAct.Name = "mnImpCorteAct"
        Me.mnImpCorteAct.Size = New System.Drawing.Size(180, 22)
        Me.mnImpCorteAct.Text = "Corte actual"
        '
        'mnImpAbiertos
        '
        Me.mnImpAbiertos.Image = CType(resources.GetObject("mnImpAbiertos.Image"), System.Drawing.Image)
        Me.mnImpAbiertos.Name = "mnImpAbiertos"
        Me.mnImpAbiertos.Size = New System.Drawing.Size(180, 22)
        Me.mnImpAbiertos.Text = "Cortes Abiertos"
        '
        'mnObservCortes
        '
        Me.mnObservCortes.Name = "mnObservCortes"
        Me.mnObservCortes.Size = New System.Drawing.Size(180, 22)
        Me.mnObservCortes.Text = "Ajustes Realizados"
        '
        'mnCortesPrem
        '
        Me.mnCortesPrem.Name = "mnCortesPrem"
        Me.mnCortesPrem.Size = New System.Drawing.Size(180, 22)
        Me.mnCortesPrem.Text = "Cortes Premezclas"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TBuscar.Size = New System.Drawing.Size(80, 25)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'BBusquedaAvanz
        '
        Me.BBusquedaAvanz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBusquedaAvanz.Image = CType(resources.GetObject("BBusquedaAvanz.Image"), System.Drawing.Image)
        Me.BBusquedaAvanz.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBusquedaAvanz.Name = "BBusquedaAvanz"
        Me.BBusquedaAvanz.Size = New System.Drawing.Size(23, 22)
        Me.BBusquedaAvanz.Text = "Busqueda Avanzada"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'BExportar
        '
        Me.BExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BExportar.Image = CType(resources.GetObject("BExportar.Image"), System.Drawing.Image)
        Me.BExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BExportar.Name = "BExportar"
        Me.BExportar.Size = New System.Drawing.Size(23, 22)
        Me.BExportar.Text = "Exportar Registros de Cortes"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnMateriales, Me.mnOtros})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1317, 24)
        Me.MenuStrip1.TabIndex = 29
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
        'mnMateriales
        '
        Me.mnMateriales.Image = CType(resources.GetObject("mnMateriales.Image"), System.Drawing.Image)
        Me.mnMateriales.Name = "mnMateriales"
        Me.mnMateriales.Size = New System.Drawing.Size(93, 20)
        Me.mnMateriales.Text = "Materiales"
        '
        'mnOtros
        '
        Me.mnOtros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnFormulación, Me.mnReportes})
        Me.mnOtros.Image = CType(resources.GetObject("mnOtros.Image"), System.Drawing.Image)
        Me.mnOtros.Name = "mnOtros"
        Me.mnOtros.Size = New System.Drawing.Size(66, 20)
        Me.mnOtros.Text = "Otros"
        '
        'mnFormulación
        '
        Me.mnFormulación.Name = "mnFormulación"
        Me.mnFormulación.Size = New System.Drawing.Size(142, 22)
        Me.mnFormulación.Text = "Formulación"
        '
        'mnReportes
        '
        Me.mnReportes.Name = "mnReportes"
        Me.mnReportes.Size = New System.Drawing.Size(142, 22)
        Me.mnReportes.Text = "Reportes"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.OPEtiq)
        Me.Panel1.Controls.Add(Me.OPEmp)
        Me.Panel1.Controls.Add(Me.DGArticulos)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.OpMP)
        Me.Panel1.Controls.Add(Me.TContCorte)
        Me.Panel1.Controls.Add(Me.PanDatos)
        Me.Panel1.Location = New System.Drawing.Point(12, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(509, 636)
        Me.Panel1.TabIndex = 30
        '
        'OPEtiq
        '
        Me.OPEtiq.AutoSize = True
        Me.OPEtiq.Location = New System.Drawing.Point(384, 11)
        Me.OPEtiq.Name = "OPEtiq"
        Me.OPEtiq.Size = New System.Drawing.Size(69, 17)
        Me.OPEtiq.TabIndex = 175
        Me.OPEtiq.Text = "Etiquetas"
        Me.OPEtiq.UseVisualStyleBackColor = True
        '
        'OPEmp
        '
        Me.OPEmp.AutoSize = True
        Me.OPEmp.Location = New System.Drawing.Point(290, 11)
        Me.OPEmp.Name = "OPEmp"
        Me.OPEmp.Size = New System.Drawing.Size(75, 17)
        Me.OPEmp.TabIndex = 174
        Me.OPEmp.Text = "Empaques"
        Me.OPEmp.UseVisualStyleBackColor = True
        '
        'DGArticulos
        '
        Me.DGArticulos.AllowUserToAddRows = False
        Me.DGArticulos.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodInt, Me.codext, Me.Nombre, Me.Linea})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGArticulos.DefaultCellStyle = DataGridViewCellStyle7
        Me.DGArticulos.Location = New System.Drawing.Point(137, 81)
        Me.DGArticulos.MultiSelect = False
        Me.DGArticulos.Name = "DGArticulos"
        Me.DGArticulos.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGArticulos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DGArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGArticulos.Size = New System.Drawing.Size(364, 73)
        Me.DGArticulos.TabIndex = 42
        Me.DGArticulos.Visible = False
        '
        'CodInt
        '
        Me.CodInt.HeaderText = "Cód.Int"
        Me.CodInt.Name = "CodInt"
        Me.CodInt.ReadOnly = True
        Me.CodInt.Width = 50
        '
        'codext
        '
        Me.codext.HeaderText = "Cód.Ext"
        Me.codext.Name = "codext"
        Me.codext.ReadOnly = True
        Me.codext.Width = 60
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 200
        '
        'Linea
        '
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Corte"
        '
        'OpMP
        '
        Me.OpMP.AutoSize = True
        Me.OpMP.Checked = True
        Me.OpMP.Location = New System.Drawing.Point(172, 11)
        Me.OpMP.Name = "OpMP"
        Me.OpMP.Size = New System.Drawing.Size(89, 17)
        Me.OpMP.TabIndex = 1
        Me.OpMP.TabStop = True
        Me.OpMP.Text = "Materia Prima"
        Me.OpMP.UseVisualStyleBackColor = True
        '
        'TContCorte
        '
        Me.TContCorte.BackColor = System.Drawing.Color.White
        Me.TContCorte.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TContCorte.Location = New System.Drawing.Point(48, 8)
        Me.TContCorte.Name = "TContCorte"
        Me.TContCorte.ReadOnly = True
        Me.TContCorte.Size = New System.Drawing.Size(118, 26)
        Me.TContCorte.TabIndex = 0
        Me.TContCorte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PanDatos
        '
        Me.PanDatos.BackColor = System.Drawing.SystemColors.Control
        Me.PanDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanDatos.Controls.Add(Me.TabDatos)
        Me.PanDatos.Controls.Add(Me.BCancelar)
        Me.PanDatos.Controls.Add(Me.Panel4)
        Me.PanDatos.Controls.Add(Me.BAceptar)
        Me.PanDatos.Controls.Add(Me.PanMat)
        Me.PanDatos.Location = New System.Drawing.Point(3, 37)
        Me.PanDatos.Name = "PanDatos"
        Me.PanDatos.Size = New System.Drawing.Size(481, 592)
        Me.PanDatos.TabIndex = 1
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.TabPage1)
        Me.TabDatos.Controls.Add(Me.TabPage2)
        Me.TabDatos.Location = New System.Drawing.Point(11, 157)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.SelectedIndex = 0
        Me.TabDatos.Size = New System.Drawing.Size(459, 394)
        Me.TabDatos.TabIndex = 40
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GBProveedor)
        Me.TabPage1.Controls.Add(Me.THora)
        Me.TabPage1.Controls.Add(Me.TFecha)
        Me.TabPage1.Controls.Add(Me.LFechaIng)
        Me.TabPage1.Controls.Add(Me.TPaqporBache)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.TPesoProm)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.TDescUbicacion)
        Me.TabPage1.Controls.Add(Me.Label37)
        Me.TabPage1.Controls.Add(Me.TUbicacion)
        Me.TabPage1.Controls.Add(Me.TCondicion)
        Me.TabPage1.Controls.Add(Me.TEstado)
        Me.TabPage1.Controls.Add(Me.BAdicionar)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.TSalInv)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.TEntInv)
        Me.TabPage1.Controls.Add(Me.TAjusteEnt)
        Me.TabPage1.Controls.Add(Me.TAjusteSal)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TLote)
        Me.TabPage1.Controls.Add(Me.TObserv)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.LMas)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.TCantAdic)
        Me.TabPage1.Controls.Add(Me.TFaltaAprox)
        Me.TabPage1.Controls.Add(Me.TConsumo)
        Me.TabPage1.Controls.Add(Me.TAlarma)
        Me.TabPage1.Controls.Add(Me.TInvIni)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(451, 368)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos"
        '
        'GBProveedor
        '
        Me.GBProveedor.Controls.Add(Me.Label41)
        Me.GBProveedor.Controls.Add(Me.TNomCli)
        Me.GBProveedor.Controls.Add(Me.TCodCli)
        Me.GBProveedor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBProveedor.ForeColor = System.Drawing.Color.Blue
        Me.GBProveedor.Location = New System.Drawing.Point(13, 234)
        Me.GBProveedor.Name = "GBProveedor"
        Me.GBProveedor.Size = New System.Drawing.Size(409, 49)
        Me.GBProveedor.TabIndex = 233
        Me.GBProveedor.TabStop = False
        Me.GBProveedor.Text = "Proveedor"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(6, 22)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(46, 14)
        Me.Label41.TabIndex = 14
        Me.Label41.Text = "Código"
        '
        'TNomCli
        '
        Me.TNomCli.Location = New System.Drawing.Point(148, 19)
        Me.TNomCli.Name = "TNomCli"
        Me.TNomCli.ReadOnly = True
        Me.TNomCli.Size = New System.Drawing.Size(254, 20)
        Me.TNomCli.TabIndex = 2
        '
        'TCodCli
        '
        Me.TCodCli.Location = New System.Drawing.Point(58, 19)
        Me.TCodCli.Name = "TCodCli"
        Me.TCodCli.Size = New System.Drawing.Size(68, 20)
        Me.TCodCli.TabIndex = 1
        '
        'THora
        '
        Me.THora.CustomFormat = "HH:MM:ss"
        Me.THora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.THora.Location = New System.Drawing.Point(324, 289)
        Me.THora.Name = "THora"
        Me.THora.Size = New System.Drawing.Size(98, 20)
        Me.THora.TabIndex = 232
        '
        'TFecha
        '
        Me.TFecha.CustomFormat = "yyyy/MM/dd"
        Me.TFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TFecha.Location = New System.Drawing.Point(220, 289)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.Size = New System.Drawing.Size(98, 20)
        Me.TFecha.TabIndex = 231
        '
        'LFechaIng
        '
        Me.LFechaIng.AutoSize = True
        Me.LFechaIng.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LFechaIng.Location = New System.Drawing.Point(130, 293)
        Me.LFechaIng.Name = "LFechaIng"
        Me.LFechaIng.Size = New System.Drawing.Size(85, 14)
        Me.LFechaIng.TabIndex = 229
        Me.LFechaIng.Text = "Fecha Ingreso"
        '
        'TPaqporBache
        '
        Me.TPaqporBache.BackColor = System.Drawing.Color.White
        Me.TPaqporBache.Location = New System.Drawing.Point(400, 20)
        Me.TPaqporBache.Name = "TPaqporBache"
        Me.TPaqporBache.ReadOnly = True
        Me.TPaqporBache.Size = New System.Drawing.Size(39, 20)
        Me.TPaqporBache.TabIndex = 228
        Me.TPaqporBache.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(329, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(71, 13)
        Me.Label25.TabIndex = 227
        Me.Label25.Text = "Paq x Bache."
        '
        'TPesoProm
        '
        Me.TPesoProm.BackColor = System.Drawing.Color.White
        Me.TPesoProm.Location = New System.Drawing.Point(257, 21)
        Me.TPesoProm.Name = "TPesoProm"
        Me.TPesoProm.ReadOnly = True
        Me.TPesoProm.Size = New System.Drawing.Size(62, 20)
        Me.TPesoProm.TabIndex = 226
        Me.TPesoProm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(183, 24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(74, 13)
        Me.Label28.TabIndex = 225
        Me.Label28.Text = "P.P Saco (Kg)"
        '
        'TDescUbicacion
        '
        Me.TDescUbicacion.Location = New System.Drawing.Point(177, 204)
        Me.TDescUbicacion.Name = "TDescUbicacion"
        Me.TDescUbicacion.Size = New System.Drawing.Size(197, 20)
        Me.TDescUbicacion.TabIndex = 224
        Me.TDescUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(12, 208)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(55, 13)
        Me.Label37.TabIndex = 223
        Me.Label37.Text = "Ubicación"
        '
        'TUbicacion
        '
        Me.TUbicacion.Location = New System.Drawing.Point(71, 204)
        Me.TUbicacion.Name = "TUbicacion"
        Me.TUbicacion.Size = New System.Drawing.Size(103, 20)
        Me.TUbicacion.TabIndex = 222
        Me.TUbicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TCondicion
        '
        Me.TCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TCondicion.Enabled = False
        Me.TCondicion.FormattingEnabled = True
        Me.TCondicion.Items.AddRange(New Object() {"-", "ENCONSUMO", "CONTRANALI", "EMPACADO", "FUMIGADO", "FUMIGAR", "PM", "INFESTADO", "RECHAZADO", "ANALIZADO", "TRATAR", "VENTAS"})
        Me.TCondicion.Location = New System.Drawing.Point(14, 179)
        Me.TCondicion.Name = "TCondicion"
        Me.TCondicion.Size = New System.Drawing.Size(106, 21)
        Me.TCondicion.TabIndex = 221
        '
        'TEstado
        '
        Me.TEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TEstado.FormattingEnabled = True
        Me.TEstado.Items.AddRange(New Object() {"-", "APROBADO"})
        Me.TEstado.Location = New System.Drawing.Point(130, 179)
        Me.TEstado.Name = "TEstado"
        Me.TEstado.Size = New System.Drawing.Size(107, 21)
        Me.TEstado.TabIndex = 220
        '
        'BAdicionar
        '
        Me.BAdicionar.Image = CType(resources.GetObject("BAdicionar.Image"), System.Drawing.Image)
        Me.BAdicionar.Location = New System.Drawing.Point(375, 105)
        Me.BAdicionar.Name = "BAdicionar"
        Me.BAdicionar.Size = New System.Drawing.Size(40, 50)
        Me.BAdicionar.TabIndex = 219
        Me.BAdicionar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(335, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 218
        Me.Label8.Text = "Kg"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(191, 138)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 217
        Me.Label21.Text = "Salidas Inv."
        '
        'TSalInv
        '
        Me.TSalInv.BackColor = System.Drawing.Color.White
        Me.TSalInv.Location = New System.Drawing.Point(267, 134)
        Me.TSalInv.Name = "TSalInv"
        Me.TSalInv.ReadOnly = True
        Me.TSalInv.Size = New System.Drawing.Size(62, 20)
        Me.TSalInv.TabIndex = 216
        Me.TSalInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(335, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(20, 13)
        Me.Label18.TabIndex = 215
        Me.Label18.Text = "Kg"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(157, 141)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 214
        Me.Label19.Text = "Kg"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(157, 116)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 13)
        Me.Label20.TabIndex = 213
        Me.Label20.Text = "Kg"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(191, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 212
        Me.Label14.Text = "Entradas Inv."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 211
        Me.Label13.Text = "Ajuste Entrada"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Ajuste Salida"
        '
        'TEntInv
        '
        Me.TEntInv.BackColor = System.Drawing.Color.White
        Me.TEntInv.Location = New System.Drawing.Point(267, 111)
        Me.TEntInv.Name = "TEntInv"
        Me.TEntInv.ReadOnly = True
        Me.TEntInv.Size = New System.Drawing.Size(62, 20)
        Me.TEntInv.TabIndex = 209
        Me.TEntInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TAjusteEnt
        '
        Me.TAjusteEnt.BackColor = System.Drawing.Color.White
        Me.TAjusteEnt.Location = New System.Drawing.Point(89, 135)
        Me.TAjusteEnt.Name = "TAjusteEnt"
        Me.TAjusteEnt.ReadOnly = True
        Me.TAjusteEnt.Size = New System.Drawing.Size(62, 20)
        Me.TAjusteEnt.TabIndex = 208
        Me.TAjusteEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TAjusteSal
        '
        Me.TAjusteSal.BackColor = System.Drawing.Color.White
        Me.TAjusteSal.Location = New System.Drawing.Point(89, 112)
        Me.TAjusteSal.Name = "TAjusteSal"
        Me.TAjusteSal.ReadOnly = True
        Me.TAjusteSal.Size = New System.Drawing.Size(62, 20)
        Me.TAjusteSal.TabIndex = 207
        Me.TAjusteSal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 206
        Me.Label4.Text = "Lote"
        '
        'TLote
        '
        Me.TLote.Location = New System.Drawing.Point(72, 20)
        Me.TLote.Name = "TLote"
        Me.TLote.Size = New System.Drawing.Size(100, 20)
        Me.TLote.TabIndex = 205
        '
        'TObserv
        '
        Me.TObserv.Location = New System.Drawing.Point(10, 326)
        Me.TObserv.Multiline = True
        Me.TObserv.Name = "TObserv"
        Me.TObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TObserv.Size = New System.Drawing.Size(412, 36)
        Me.TObserv.TabIndex = 204
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(11, 307)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 13)
        Me.Label26.TabIndex = 203
        Me.Label26.Text = "Observaciones"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(13, 163)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(54, 13)
        Me.Label23.TabIndex = 202
        Me.Label23.Text = "Condición"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(129, 163)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 201
        Me.Label22.Text = "Estado"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(333, 78)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(20, 13)
        Me.Label17.TabIndex = 200
        Me.Label17.Text = "Kg"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(139, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 13)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = "Kg"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(388, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 13)
        Me.Label15.TabIndex = 198
        Me.Label15.Text = "Kg"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 196
        Me.Label10.Text = "Consumo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(275, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 195
        Me.Label9.Text = "Alarma"
        '
        'LMas
        '
        Me.LMas.AutoSize = True
        Me.LMas.Location = New System.Drawing.Point(139, 52)
        Me.LMas.Name = "LMas"
        Me.LMas.Size = New System.Drawing.Size(13, 13)
        Me.LMas.TabIndex = 194
        Me.LMas.Text = "+"
        Me.LMas.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "Cant. (Kg)"
        '
        'TCantAdic
        '
        Me.TCantAdic.Location = New System.Drawing.Point(158, 49)
        Me.TCantAdic.Name = "TCantAdic"
        Me.TCantAdic.Size = New System.Drawing.Size(61, 20)
        Me.TCantAdic.TabIndex = 192
        Me.TCantAdic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TCantAdic.Visible = False
        '
        'TFaltaAprox
        '
        Me.TFaltaAprox.Location = New System.Drawing.Point(265, 75)
        Me.TFaltaAprox.Name = "TFaltaAprox"
        Me.TFaltaAprox.ReadOnly = True
        Me.TFaltaAprox.Size = New System.Drawing.Size(60, 20)
        Me.TFaltaAprox.TabIndex = 191
        Me.TFaltaAprox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TConsumo
        '
        Me.TConsumo.Location = New System.Drawing.Point(71, 75)
        Me.TConsumo.Name = "TConsumo"
        Me.TConsumo.ReadOnly = True
        Me.TConsumo.Size = New System.Drawing.Size(62, 20)
        Me.TConsumo.TabIndex = 190
        Me.TConsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TAlarma
        '
        Me.TAlarma.Location = New System.Drawing.Point(320, 49)
        Me.TAlarma.Name = "TAlarma"
        Me.TAlarma.Size = New System.Drawing.Size(62, 20)
        Me.TAlarma.TabIndex = 189
        Me.TAlarma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TInvIni
        '
        Me.TInvIni.Location = New System.Drawing.Point(71, 49)
        Me.TInvIni.Name = "TInvIni"
        Me.TInvIni.Size = New System.Drawing.Size(62, 20)
        Me.TInvIni.TabIndex = 188
        Me.TInvIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(189, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 197
        Me.Label11.Text = "Falta Aprox."
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GBEtiqueta)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(451, 368)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Imprimir "
        '
        'GBEtiqueta
        '
        Me.GBEtiqueta.Controls.Add(Me.Label38)
        Me.GBEtiqueta.Controls.Add(Me.TSecuencia)
        Me.GBEtiqueta.Controls.Add(Me.Label40)
        Me.GBEtiqueta.Controls.Add(Me.TFechaEnt)
        Me.GBEtiqueta.Controls.Add(Me.BImpEtiq)
        Me.GBEtiqueta.Controls.Add(Me.Label29)
        Me.GBEtiqueta.Controls.Add(Me.TNoCopias)
        Me.GBEtiqueta.Controls.Add(Me.TPesoPromEdit)
        Me.GBEtiqueta.Controls.Add(Me.Label24)
        Me.GBEtiqueta.Controls.Add(Me.CUbicacion)
        Me.GBEtiqueta.Controls.Add(Me.Label27)
        Me.GBEtiqueta.Location = New System.Drawing.Point(28, 37)
        Me.GBEtiqueta.Name = "GBEtiqueta"
        Me.GBEtiqueta.Size = New System.Drawing.Size(386, 186)
        Me.GBEtiqueta.TabIndex = 38
        Me.GBEtiqueta.TabStop = False
        Me.GBEtiqueta.Text = "Datos Etiqueta"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(122, 57)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(58, 13)
        Me.Label38.TabIndex = 178
        Me.Label38.Text = "Secuencia"
        '
        'TSecuencia
        '
        Me.TSecuencia.Location = New System.Drawing.Point(123, 70)
        Me.TSecuencia.Name = "TSecuencia"
        Me.TSecuencia.ReadOnly = True
        Me.TSecuencia.Size = New System.Drawing.Size(113, 20)
        Me.TSecuencia.TabIndex = 177
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(122, 16)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(77, 13)
        Me.Label40.TabIndex = 176
        Me.Label40.Text = "Fecha Entrada"
        '
        'TFechaEnt
        '
        Me.TFechaEnt.Location = New System.Drawing.Point(123, 32)
        Me.TFechaEnt.Name = "TFechaEnt"
        Me.TFechaEnt.ReadOnly = True
        Me.TFechaEnt.Size = New System.Drawing.Size(113, 20)
        Me.TFechaEnt.TabIndex = 175
        '
        'BImpEtiq
        '
        Me.BImpEtiq.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BImpEtiq.Image = CType(resources.GetObject("BImpEtiq.Image"), System.Drawing.Image)
        Me.BImpEtiq.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BImpEtiq.Location = New System.Drawing.Point(280, 141)
        Me.BImpEtiq.Name = "BImpEtiq"
        Me.BImpEtiq.Size = New System.Drawing.Size(95, 33)
        Me.BImpEtiq.TabIndex = 168
        Me.BImpEtiq.Text = "Imprimir"
        Me.BImpEtiq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BImpEtiq.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(219, 117)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 13)
        Me.Label29.TabIndex = 167
        Me.Label29.Text = "Número de copias"
        '
        'TNoCopias
        '
        Me.TNoCopias.Location = New System.Drawing.Point(312, 115)
        Me.TNoCopias.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.TNoCopias.Name = "TNoCopias"
        Me.TNoCopias.Size = New System.Drawing.Size(61, 20)
        Me.TNoCopias.TabIndex = 166
        Me.TNoCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TNoCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TPesoPromEdit
        '
        Me.TPesoPromEdit.BackColor = System.Drawing.Color.White
        Me.TPesoPromEdit.Location = New System.Drawing.Point(6, 68)
        Me.TPesoPromEdit.Name = "TPesoPromEdit"
        Me.TPesoPromEdit.ReadOnly = True
        Me.TPesoPromEdit.Size = New System.Drawing.Size(62, 20)
        Me.TPesoPromEdit.TabIndex = 158
        Me.TPesoPromEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 51)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(109, 13)
        Me.Label24.TabIndex = 157
        Me.Label24.Text = "Peso Promedio Saco."
        '
        'CUbicacion
        '
        Me.CUbicacion.FormattingEnabled = True
        Me.CUbicacion.Location = New System.Drawing.Point(6, 28)
        Me.CUbicacion.Name = "CUbicacion"
        Me.CUbicacion.Size = New System.Drawing.Size(87, 21)
        Me.CUbicacion.TabIndex = 156
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 155
        Me.Label27.Text = "Ubicación"
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(266, 557)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(34, 31)
        Me.BCancelar.TabIndex = 39
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.THumedad)
        Me.Panel4.Controls.Add(Me.TGrasa)
        Me.Panel4.Controls.Add(Me.TProteina)
        Me.Panel4.Controls.Add(Me.TCeniza)
        Me.Panel4.Controls.Add(Me.Label32)
        Me.Panel4.Controls.Add(Me.Label33)
        Me.Panel4.Controls.Add(Me.Label30)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.TFechaFin)
        Me.Panel4.Controls.Add(Me.TFechaIni)
        Me.Panel4.Location = New System.Drawing.Point(10, 83)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(439, 63)
        Me.Panel4.TabIndex = 1
        '
        'THumedad
        '
        Me.THumedad.Location = New System.Drawing.Point(365, 31)
        Me.THumedad.Name = "THumedad"
        Me.THumedad.ReadOnly = True
        Me.THumedad.Size = New System.Drawing.Size(53, 20)
        Me.THumedad.TabIndex = 14
        '
        'TGrasa
        '
        Me.TGrasa.Location = New System.Drawing.Point(365, 10)
        Me.TGrasa.Name = "TGrasa"
        Me.TGrasa.ReadOnly = True
        Me.TGrasa.Size = New System.Drawing.Size(53, 20)
        Me.TGrasa.TabIndex = 13
        '
        'TProteina
        '
        Me.TProteina.Location = New System.Drawing.Point(249, 31)
        Me.TProteina.Name = "TProteina"
        Me.TProteina.ReadOnly = True
        Me.TProteina.Size = New System.Drawing.Size(53, 20)
        Me.TProteina.TabIndex = 12
        '
        'TCeniza
        '
        Me.TCeniza.Location = New System.Drawing.Point(249, 9)
        Me.TCeniza.Name = "TCeniza"
        Me.TCeniza.ReadOnly = True
        Me.TCeniza.Size = New System.Drawing.Size(53, 20)
        Me.TCeniza.TabIndex = 11
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(309, 35)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(53, 13)
        Me.Label32.TabIndex = 10
        Me.Label32.Text = "Humedad"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(309, 13)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(35, 13)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "Grasa"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(203, 35)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(46, 13)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "Proteina"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(203, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(39, 13)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "Ceniza"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "FechaFin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "FechaIni"
        '
        'TFechaFin
        '
        Me.TFechaFin.Location = New System.Drawing.Point(81, 33)
        Me.TFechaFin.Name = "TFechaFin"
        Me.TFechaFin.ReadOnly = True
        Me.TFechaFin.Size = New System.Drawing.Size(113, 20)
        Me.TFechaFin.TabIndex = 4
        '
        'TFechaIni
        '
        Me.TFechaIni.Location = New System.Drawing.Point(81, 7)
        Me.TFechaIni.Name = "TFechaIni"
        Me.TFechaIni.ReadOnly = True
        Me.TFechaIni.Size = New System.Drawing.Size(113, 20)
        Me.TFechaIni.TabIndex = 3
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(226, 557)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(34, 31)
        Me.BAceptar.TabIndex = 38
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'PanMat
        '
        Me.PanMat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanMat.Controls.Add(Me.TLinea)
        Me.PanMat.Controls.Add(Me.TCodMat)
        Me.PanMat.Controls.Add(Me.Label3)
        Me.PanMat.Controls.Add(Me.Label2)
        Me.PanMat.Controls.Add(Me.TNomMat)
        Me.PanMat.Enabled = False
        Me.PanMat.Location = New System.Drawing.Point(10, 15)
        Me.PanMat.Name = "PanMat"
        Me.PanMat.Size = New System.Drawing.Size(439, 63)
        Me.PanMat.TabIndex = 0
        '
        'TLinea
        '
        Me.TLinea.Location = New System.Drawing.Point(223, 5)
        Me.TLinea.Name = "TLinea"
        Me.TLinea.Size = New System.Drawing.Size(100, 20)
        Me.TLinea.TabIndex = 163
        '
        'TCodMat
        '
        Me.TCodMat.Location = New System.Drawing.Point(66, 4)
        Me.TCodMat.Name = "TCodMat"
        Me.TCodMat.Size = New System.Drawing.Size(100, 20)
        Me.TCodMat.TabIndex = 162
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cód 1."
        '
        'TNomMat
        '
        Me.TNomMat.FormattingEnabled = True
        Me.TNomMat.Location = New System.Drawing.Point(68, 33)
        Me.TNomMat.Name = "TNomMat"
        Me.TNomMat.Size = New System.Drawing.Size(285, 21)
        Me.TNomMat.TabIndex = 1
        '
        'BLimpiar
        '
        Me.BLimpiar.Location = New System.Drawing.Point(830, 351)
        Me.BLimpiar.Name = "BLimpiar"
        Me.BLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.BLimpiar.TabIndex = 31
        Me.BLimpiar.Text = "BLimpiar"
        Me.BLimpiar.UseVisualStyleBackColor = True
        Me.BLimpiar.Visible = False
        '
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(646, 316)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(101, 23)
        Me.FRefrescaDG.TabIndex = 40
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'BCDate
        '
        Me.BCDate.Location = New System.Drawing.Point(650, 341)
        Me.BCDate.Name = "BCDate"
        Me.BCDate.Size = New System.Drawing.Size(75, 23)
        Me.BCDate.TabIndex = 41
        Me.BCDate.Text = "BCDate"
        Me.BCDate.UseVisualStyleBackColor = True
        Me.BCDate.Visible = False
        '
        'FrFiltrar
        '
        Me.FrFiltrar.Controls.Add(Me.TUbicacionF)
        Me.FrFiltrar.Controls.Add(Me.Label42)
        Me.FrFiltrar.Controls.Add(Me.Label36)
        Me.FrFiltrar.Controls.Add(Me.Label35)
        Me.FrFiltrar.Controls.Add(Me.Label34)
        Me.FrFiltrar.Controls.Add(Me.OPFinalizados)
        Me.FrFiltrar.Controls.Add(Me.TLoteF)
        Me.FrFiltrar.Controls.Add(Me.TNomMatF)
        Me.FrFiltrar.Controls.Add(Me.TCodMatF)
        Me.FrFiltrar.Controls.Add(Me.BCancelarFiltrar)
        Me.FrFiltrar.Controls.Add(Me.BOKFiltrar)
        Me.FrFiltrar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FrFiltrar.Location = New System.Drawing.Point(658, 131)
        Me.FrFiltrar.Name = "FrFiltrar"
        Me.FrFiltrar.Size = New System.Drawing.Size(260, 179)
        Me.FrFiltrar.TabIndex = 42
        Me.FrFiltrar.TabStop = False
        Me.FrFiltrar.Text = "Busqueda Avanzada"
        Me.FrFiltrar.Visible = False
        '
        'TUbicacionF
        '
        Me.TUbicacionF.FormattingEnabled = True
        Me.TUbicacionF.Location = New System.Drawing.Point(68, 66)
        Me.TUbicacionF.Name = "TUbicacionF"
        Me.TUbicacionF.Size = New System.Drawing.Size(121, 22)
        Me.TUbicacionF.TabIndex = 50
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 69)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(62, 14)
        Me.Label42.TabIndex = 49
        Me.Label42.Text = "Ubicación:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(32, 96)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(35, 14)
        Me.Label36.TabIndex = 48
        Me.Label36.Text = "Lote:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(13, 46)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(54, 14)
        Me.Label35.TabIndex = 47
        Me.Label35.Text = "Nombre:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(13, 24)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(52, 14)
        Me.Label34.TabIndex = 46
        Me.Label34.Text = "CodMat:"
        '
        'OPFinalizados
        '
        Me.OPFinalizados.AutoSize = True
        Me.OPFinalizados.Location = New System.Drawing.Point(45, 128)
        Me.OPFinalizados.Name = "OPFinalizados"
        Me.OPFinalizados.Size = New System.Drawing.Size(109, 18)
        Me.OPFinalizados.TabIndex = 45
        Me.OPFinalizados.Text = "Ver Finalizados"
        Me.OPFinalizados.UseVisualStyleBackColor = True
        '
        'TLoteF
        '
        Me.TLoteF.Location = New System.Drawing.Point(68, 91)
        Me.TLoteF.Name = "TLoteF"
        Me.TLoteF.Size = New System.Drawing.Size(100, 20)
        Me.TLoteF.TabIndex = 44
        '
        'TNomMatF
        '
        Me.TNomMatF.Location = New System.Drawing.Point(68, 43)
        Me.TNomMatF.Name = "TNomMatF"
        Me.TNomMatF.Size = New System.Drawing.Size(179, 20)
        Me.TNomMatF.TabIndex = 43
        '
        'TCodMatF
        '
        Me.TCodMatF.Location = New System.Drawing.Point(68, 20)
        Me.TCodMatF.Name = "TCodMatF"
        Me.TCodMatF.Size = New System.Drawing.Size(57, 20)
        Me.TCodMatF.TabIndex = 42
        '
        'BCancelarFiltrar
        '
        Me.BCancelarFiltrar.Image = CType(resources.GetObject("BCancelarFiltrar.Image"), System.Drawing.Image)
        Me.BCancelarFiltrar.Location = New System.Drawing.Point(138, 146)
        Me.BCancelarFiltrar.Name = "BCancelarFiltrar"
        Me.BCancelarFiltrar.Size = New System.Drawing.Size(34, 31)
        Me.BCancelarFiltrar.TabIndex = 41
        Me.BCancelarFiltrar.UseVisualStyleBackColor = True
        '
        'BOKFiltrar
        '
        Me.BOKFiltrar.Image = CType(resources.GetObject("BOKFiltrar.Image"), System.Drawing.Image)
        Me.BOKFiltrar.Location = New System.Drawing.Point(105, 146)
        Me.BOKFiltrar.Name = "BOKFiltrar"
        Me.BOKFiltrar.Size = New System.Drawing.Size(34, 31)
        Me.BOKFiltrar.TabIndex = 40
        Me.BOKFiltrar.UseVisualStyleBackColor = True
        '
        'DGUbic
        '
        Me.DGUbic.AllowUserToAddRows = False
        Me.DGUbic.AllowUserToDeleteRows = False
        Me.DGUbic.AllowUserToResizeRows = False
        Me.DGUbic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGUbic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODUBI, Me.Descripcion, Me.Tipo, Me.Consumo})
        Me.DGUbic.Location = New System.Drawing.Point(568, 416)
        Me.DGUbic.MultiSelect = False
        Me.DGUbic.Name = "DGUbic"
        Me.DGUbic.ReadOnly = True
        Me.DGUbic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGUbic.Size = New System.Drawing.Size(447, 244)
        Me.DGUbic.TabIndex = 44
        Me.DGUbic.Visible = False
        '
        'CODUBI
        '
        Me.CODUBI.HeaderText = "Código"
        Me.CODUBI.Name = "CODUBI"
        Me.CODUBI.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 220
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Visible = False
        Me.Tipo.Width = 40
        '
        'Consumo
        '
        Me.Consumo.HeaderText = "Consumo"
        Me.Consumo.Name = "Consumo"
        Me.Consumo.ReadOnly = True
        Me.Consumo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Consumo.Width = 60
        '
        'BExportCortes
        '
        Me.BExportCortes.Location = New System.Drawing.Point(1016, 315)
        Me.BExportCortes.Name = "BExportCortes"
        Me.BExportCortes.Size = New System.Drawing.Size(103, 23)
        Me.BExportCortes.TabIndex = 45
        Me.BExportCortes.Text = "BExportCortes"
        Me.BExportCortes.UseVisualStyleBackColor = True
        Me.BExportCortes.Visible = False
        '
        'BExportArt
        '
        Me.BExportArt.Location = New System.Drawing.Point(1016, 346)
        Me.BExportArt.Name = "BExportArt"
        Me.BExportArt.Size = New System.Drawing.Size(103, 23)
        Me.BExportArt.TabIndex = 46
        Me.BExportArt.Text = "BExportArt"
        Me.BExportArt.UseVisualStyleBackColor = True
        Me.BExportArt.Visible = False
        '
        'MnTrasladaCorte
        '
        Me.MnTrasladaCorte.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnModCodProd2Emp})
        Me.MnTrasladaCorte.Name = "CtModCodProd2"
        Me.MnTrasladaCorte.Size = New System.Drawing.Size(230, 26)
        Me.MnTrasladaCorte.Text = "Modifcar CodProd2"
        '
        'mnModCodProd2Emp
        '
        Me.mnModCodProd2Emp.Image = CType(resources.GetObject("mnModCodProd2Emp.Image"), System.Drawing.Image)
        Me.mnModCodProd2Emp.Name = "mnModCodProd2Emp"
        Me.mnModCodProd2Emp.Size = New System.Drawing.Size(229, 22)
        Me.mnModCodProd2Emp.Text = "Trasladar Corte Materia Prima"
        '
        'DGClientes
        '
        Me.DGClientes.AllowUserToAddRows = False
        Me.DGClientes.AllowUserToDeleteRows = False
        Me.DGClientes.AllowUserToResizeRows = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCLI, Me.NomCli})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGClientes.DefaultCellStyle = DataGridViewCellStyle10
        Me.DGClientes.Location = New System.Drawing.Point(584, 485)
        Me.DGClientes.MultiSelect = False
        Me.DGClientes.Name = "DGClientes"
        Me.DGClientes.ReadOnly = True
        Me.DGClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGClientes.Size = New System.Drawing.Size(334, 110)
        Me.DGClientes.TabIndex = 47
        Me.DGClientes.Visible = False
        '
        'CODCLI
        '
        Me.CODCLI.HeaderText = "Código"
        Me.CODCLI.Name = "CODCLI"
        Me.CODCLI.ReadOnly = True
        '
        'NomCli
        '
        Me.NomCli.HeaderText = "Nombre"
        Me.NomCli.Name = "NomCli"
        Me.NomCli.ReadOnly = True
        Me.NomCli.Width = 180
        '
        'ChTodos
        '
        Me.ChTodos.AutoSize = True
        Me.ChTodos.Location = New System.Drawing.Point(536, 62)
        Me.ChTodos.Name = "ChTodos"
        Me.ChTodos.Size = New System.Drawing.Size(154, 17)
        Me.ChTodos.TabIndex = 48
        Me.ChTodos.Text = "Ver todos los cortes de lote"
        Me.ChTodos.UseVisualStyleBackColor = True
        '
        'CortesMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 707)
        Me.Controls.Add(Me.ChTodos)
        Me.Controls.Add(Me.DGClientes)
        Me.Controls.Add(Me.BExportArt)
        Me.Controls.Add(Me.BExportCortes)
        Me.Controls.Add(Me.DGUbic)
        Me.Controls.Add(Me.FrFiltrar)
        Me.Controls.Add(Me.BCDate)
        Me.Controls.Add(Me.FRefrescaDG)
        Me.Controls.Add(Me.BLimpiar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DGCortes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CortesMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cortes de Materia Prima"
        CType(Me.DGCortes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanDatos.ResumeLayout(False)
        Me.TabDatos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GBProveedor.ResumeLayout(False)
        Me.GBProveedor.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GBEtiqueta.ResumeLayout(False)
        Me.GBEtiqueta.PerformLayout()
        CType(Me.TNoCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.PanMat.ResumeLayout(False)
        Me.PanMat.PerformLayout()
        Me.FrFiltrar.ResumeLayout(False)
        Me.FrFiltrar.PerformLayout()
        CType(Me.DGUbic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MnTrasladaCorte.ResumeLayout(False)
        CType(Me.DGClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGCortes As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BFinalizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnMateriales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnVer As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents mnAbiertos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnCerrados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanDatos As System.Windows.Forms.Panel
    Friend WithEvents TContCorte As System.Windows.Forms.TextBox
    Friend WithEvents PanMat As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TFechaFin As System.Windows.Forms.TextBox
    Friend WithEvents TFechaIni As System.Windows.Forms.TextBox
    Friend WithEvents TNomMat As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BAbrirCorte As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BCerrarCorte As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BLimpiar As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FRefrescaDG As System.Windows.Forms.Button
    Friend WithEvents BImportLotes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnImp As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents mnImpCorteAct As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnImpAbiertos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BCDate As System.Windows.Forms.Button
    Friend WithEvents mnFormulación As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents THumedad As System.Windows.Forms.TextBox
    Friend WithEvents TGrasa As System.Windows.Forms.TextBox
    Friend WithEvents TProteina As System.Windows.Forms.TextBox
    Friend WithEvents TCeniza As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents BDescartar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnVerFinalizados As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnObservCortes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBusquedaAvanz As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FrFiltrar As System.Windows.Forms.GroupBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents OPFinalizados As System.Windows.Forms.CheckBox
    Friend WithEvents TLoteF As System.Windows.Forms.TextBox
    Friend WithEvents TNomMatF As System.Windows.Forms.TextBox
    Friend WithEvents TCodMatF As System.Windows.Forms.TextBox
    Friend WithEvents BCancelarFiltrar As System.Windows.Forms.Button
    Friend WithEvents BOKFiltrar As System.Windows.Forms.Button
    Friend WithEvents TCodMat As System.Windows.Forms.TextBox
    Friend WithEvents DGArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents OpMP As System.Windows.Forms.RadioButton
    Friend WithEvents OPEtiq As System.Windows.Forms.RadioButton
    Friend WithEvents OPEmp As System.Windows.Forms.RadioButton
    Friend WithEvents CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TLinea As System.Windows.Forms.TextBox
    Friend WithEvents DGUbic As System.Windows.Forms.DataGridView
    Friend WithEvents CODUBI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consumo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UbicLote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescUbicLote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Finalizado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VIGENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents invini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pesoprom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BExportCortes As System.Windows.Forms.Button
    Friend WithEvents BExportArt As System.Windows.Forms.Button
    Friend WithEvents TabDatos As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents THora As DateTimePicker
    Friend WithEvents TFecha As DateTimePicker
    Friend WithEvents LFechaIng As Label
    Friend WithEvents TPaqporBache As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TPesoProm As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents TDescUbicacion As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TUbicacion As TextBox
    Friend WithEvents TCondicion As ComboBox
    Friend WithEvents TEstado As ComboBox
    Friend WithEvents BAdicionar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TSalInv As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TEntInv As TextBox
    Friend WithEvents TAjusteEnt As TextBox
    Friend WithEvents TAjusteSal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TLote As TextBox
    Friend WithEvents TObserv As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LMas As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TCantAdic As TextBox
    Friend WithEvents TFaltaAprox As TextBox
    Friend WithEvents TConsumo As TextBox
    Friend WithEvents TAlarma As TextBox
    Friend WithEvents TInvIni As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GBEtiqueta As GroupBox
    Friend WithEvents BImpEtiq As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents TNoCopias As NumericUpDown
    Friend WithEvents TPesoPromEdit As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents CUbicacion As ComboBox
    Friend WithEvents Label27 As Label
    Friend WithEvents MnTrasladaCorte As ContextMenuStrip
    Friend WithEvents mnModCodProd2Emp As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents BActConsumo As ToolStripButton
    Friend WithEvents mnCortesPrem As ToolStripMenuItem
    Friend WithEvents Label38 As Label
    Friend WithEvents TSecuencia As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents TFechaEnt As TextBox
    Friend WithEvents GBProveedor As GroupBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TNomCli As TextBox
    Friend WithEvents TCodCli As TextBox
    Friend WithEvents DGClientes As DataGridView
    Friend WithEvents CODCLI As DataGridViewTextBoxColumn
    Friend WithEvents NomCli As DataGridViewTextBoxColumn
    Friend WithEvents BEliminar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ChTodos As CheckBox
    Friend WithEvents TUbicacionF As ComboBox
    Friend WithEvents Label42 As Label
End Class
