<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecPremezclas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecPremezclas))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TUsuarioRec = New System.Windows.Forms.TextBox()
        Me.THora = New System.Windows.Forms.DateTimePicker()
        Me.TFecha = New System.Windows.Forms.DateTimePicker()
        Me.TObservCostos = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CUsuario = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TPesoReal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TFechaIni = New System.Windows.Forms.TextBox()
        Me.TPesoMeta = New System.Windows.Forms.TextBox()
        Me.TNomFor = New System.Windows.Forms.TextBox()
        Me.TCodPrem = New System.Windows.Forms.TextBox()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGPrem = New System.Windows.Forms.DataGridView()
        Me.ColAceptar_NI_ = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cont2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.TSumSacos = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ChAceptados = New System.Windows.Forms.CheckBox()
        Me.ChAceptarTodos = New System.Windows.Forms.CheckBox()
        Me.ChAceptarSel = New System.Windows.Forms.CheckBox()
        Me.GBFiltro = New System.Windows.Forms.GroupBox()
        Me.OpPlantaYar = New System.Windows.Forms.RadioButton()
        Me.OpPlantaSta = New System.Windows.Forms.RadioButton()
        Me.OPPlantaGir = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGPrem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GBFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'BCancelar
        '
        Me.BCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(325, 363)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(52, 40)
        Me.BCancelar.TabIndex = 63
        Me.BCancelar.UseVisualStyleBackColor = False
        '
        'BAceptar
        '
        Me.BAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(267, 363)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(52, 40)
        Me.BAceptar.TabIndex = 62
        Me.BAceptar.UseVisualStyleBackColor = False
        '
        'TUsuarioRec
        '
        Me.TUsuarioRec.Location = New System.Drawing.Point(132, 386)
        Me.TUsuarioRec.Name = "TUsuarioRec"
        Me.TUsuarioRec.ReadOnly = True
        Me.TUsuarioRec.Size = New System.Drawing.Size(109, 20)
        Me.TUsuarioRec.TabIndex = 61
        '
        'THora
        '
        Me.THora.CustomFormat = "HH:MM:ss"
        Me.THora.Enabled = False
        Me.THora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.THora.Location = New System.Drawing.Point(96, 363)
        Me.THora.Name = "THora"
        Me.THora.Size = New System.Drawing.Size(98, 20)
        Me.THora.TabIndex = 60
        '
        'TFecha
        '
        Me.TFecha.CustomFormat = "yyyy/MM/dd"
        Me.TFecha.Enabled = False
        Me.TFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TFecha.Location = New System.Drawing.Point(96, 340)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.Size = New System.Drawing.Size(98, 20)
        Me.TFecha.TabIndex = 59
        '
        'TObservCostos
        '
        Me.TObservCostos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObservCostos.Location = New System.Drawing.Point(12, 515)
        Me.TObservCostos.Multiline = True
        Me.TObservCostos.Name = "TObservCostos"
        Me.TObservCostos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TObservCostos.Size = New System.Drawing.Size(329, 14)
        Me.TObservCostos.TabIndex = 58
        Me.TObservCostos.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(26, 498)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(150, 14)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Observaciones de Costos"
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 389)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 14)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Usuario que Recibe"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 369)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 14)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Hora Recibo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 344)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 14)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Fecha Recibo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CUsuario)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TPesoReal)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TFechaIni)
        Me.GroupBox2.Controls.Add(Me.TPesoMeta)
        Me.GroupBox2.Controls.Add(Me.TNomFor)
        Me.GroupBox2.Controls.Add(Me.TCodPrem)
        Me.GroupBox2.Controls.Add(Me.TOPs)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 202)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Empaque"
        '
        'CUsuario
        '
        Me.CUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CUsuario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CUsuario.ForeColor = System.Drawing.Color.Red
        Me.CUsuario.FormattingEnabled = True
        Me.CUsuario.Location = New System.Drawing.Point(102, 161)
        Me.CUsuario.Name = "CUsuario"
        Me.CUsuario.Size = New System.Drawing.Size(199, 22)
        Me.CUsuario.TabIndex = 43
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 164)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 16)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Supervisor"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(193, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(21, 14)
        Me.Label16.TabIndex = 41
        Me.Label16.Text = "Kg"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(193, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 14)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Kg"
        '
        'TPesoReal
        '
        Me.TPesoReal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TPesoReal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPesoReal.Location = New System.Drawing.Point(104, 102)
        Me.TPesoReal.Name = "TPesoReal"
        Me.TPesoReal.ReadOnly = True
        Me.TPesoReal.Size = New System.Drawing.Size(83, 20)
        Me.TPesoReal.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 102)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Peso Real"
        '
        'TFechaIni
        '
        Me.TFechaIni.BackColor = System.Drawing.Color.White
        Me.TFechaIni.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFechaIni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TFechaIni.Location = New System.Drawing.Point(102, 135)
        Me.TFechaIni.Name = "TFechaIni"
        Me.TFechaIni.ReadOnly = True
        Me.TFechaIni.Size = New System.Drawing.Size(164, 20)
        Me.TFechaIni.TabIndex = 13
        '
        'TPesoMeta
        '
        Me.TPesoMeta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TPesoMeta.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPesoMeta.Location = New System.Drawing.Point(104, 76)
        Me.TPesoMeta.Name = "TPesoMeta"
        Me.TPesoMeta.ReadOnly = True
        Me.TPesoMeta.Size = New System.Drawing.Size(81, 20)
        Me.TPesoMeta.TabIndex = 12
        '
        'TNomFor
        '
        Me.TNomFor.BackColor = System.Drawing.SystemColors.Control
        Me.TNomFor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNomFor.Location = New System.Drawing.Point(102, 52)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.ReadOnly = True
        Me.TNomFor.Size = New System.Drawing.Size(261, 21)
        Me.TNomFor.TabIndex = 11
        '
        'TCodPrem
        '
        Me.TCodPrem.BackColor = System.Drawing.SystemColors.Control
        Me.TCodPrem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodPrem.Location = New System.Drawing.Point(228, 24)
        Me.TCodPrem.Name = "TCodPrem"
        Me.TCodPrem.ReadOnly = True
        Me.TCodPrem.Size = New System.Drawing.Size(81, 21)
        Me.TCodPrem.TabIndex = 10
        '
        'TOPs
        '
        Me.TOPs.BackColor = System.Drawing.Color.White
        Me.TOPs.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPs.Location = New System.Drawing.Point(70, 23)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.ReadOnly = True
        Me.TOPs.Size = New System.Drawing.Size(81, 22)
        Me.TOPs.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Peso Meta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "NomFor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CodPrem"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OP"
        '
        'DGPrem
        '
        Me.DGPrem.AllowUserToAddRows = False
        Me.DGPrem.AllowUserToDeleteRows = False
        Me.DGPrem.AllowUserToResizeRows = False
        Me.DGPrem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPrem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColAceptar_NI_, Me.Cont2, Me.OP, Me.CodFor, Me.NomFor, Me.PesoMeta, Me.PesoReal, Me.Fecha})
        Me.DGPrem.Location = New System.Drawing.Point(385, 128)
        Me.DGPrem.Name = "DGPrem"
        Me.DGPrem.ReadOnly = True
        Me.DGPrem.RowHeadersVisible = False
        Me.DGPrem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPrem.Size = New System.Drawing.Size(825, 275)
        Me.DGPrem.TabIndex = 51
        '
        'ColAceptar_NI_
        '
        Me.ColAceptar_NI_.HeaderText = "Aceptar"
        Me.ColAceptar_NI_.Name = "ColAceptar_NI_"
        Me.ColAceptar_NI_.ReadOnly = True
        Me.ColAceptar_NI_.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColAceptar_NI_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColAceptar_NI_.Width = 50
        '
        'Cont2
        '
        Me.Cont2.HeaderText = "Cont"
        Me.Cont2.Name = "Cont2"
        Me.Cont2.ReadOnly = True
        Me.Cont2.Visible = False
        Me.Cont2.Width = 60
        '
        'OP
        '
        Me.OP.HeaderText = "OP"
        Me.OP.Name = "OP"
        Me.OP.ReadOnly = True
        Me.OP.Width = 60
        '
        'CodFor
        '
        Me.CodFor.HeaderText = "CodFor"
        Me.CodFor.Name = "CodFor"
        Me.CodFor.ReadOnly = True
        Me.CodFor.Width = 50
        '
        'NomFor
        '
        Me.NomFor.HeaderText = "NomFor"
        Me.NomFor.Name = "NomFor"
        Me.NomFor.ReadOnly = True
        Me.NomFor.Width = 200
        '
        'PesoMeta
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.PesoMeta.DefaultCellStyle = DataGridViewCellStyle7
        Me.PesoMeta.HeaderText = "PesoMeta"
        Me.PesoMeta.Name = "PesoMeta"
        Me.PesoMeta.ReadOnly = True
        Me.PesoMeta.Width = 80
        '
        'PesoReal
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.PesoReal.DefaultCellStyle = DataGridViewCellStyle8
        Me.PesoReal.HeaderText = "PesoReal"
        Me.PesoReal.Name = "PesoReal"
        Me.PesoReal.ReadOnly = True
        Me.PesoReal.Width = 80
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 120
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BPrimero, Me.ToolStripSeparator1, Me.BAnterior, Me.ToolStripSeparator2, Me.mnTCuenta, Me.ToolStripLabel1, Me.mnLCuenta, Me.ToolStripSeparator7, Me.BSiguiente, Me.ToolStripSeparator3, Me.BUltimo, Me.ToolStripSeparator4, Me.BActualizar, Me.CBBuscar, Me.ToolStripLabel2, Me.TBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1273, 25)
        Me.ToolStrip1.TabIndex = 49
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
        Me.mnTCuenta.Name = "mnTCuenta"
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
        'CBBuscar
        '
        Me.CBBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscar.DropDownWidth = 80
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(125, 25)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel2.Text = "Buscar"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBuscar
        '
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(125, 25)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1273, 24)
        Me.MenuStrip1.TabIndex = 50
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
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(435, 183)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(101, 23)
        Me.FRefrescaDG.TabIndex = 65
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'TSumSacos
        '
        Me.TSumSacos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSumSacos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSumSacos.Location = New System.Drawing.Point(504, 517)
        Me.TSumSacos.Name = "TSumSacos"
        Me.TSumSacos.ReadOnly = True
        Me.TSumSacos.Size = New System.Drawing.Size(81, 20)
        Me.TSumSacos.TabIndex = 67
        Me.TSumSacos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TSumSacos.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label15.Location = New System.Drawing.Point(381, 515)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 23)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Total sacos"
        Me.Label15.Visible = False
        '
        'ChAceptados
        '
        Me.ChAceptados.AutoSize = True
        Me.ChAceptados.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ChAceptados.Location = New System.Drawing.Point(600, 519)
        Me.ChAceptados.Name = "ChAceptados"
        Me.ChAceptados.Size = New System.Drawing.Size(132, 18)
        Me.ChAceptados.TabIndex = 68
        Me.ChAceptados.Text = "Ver solo aceptados"
        Me.ChAceptados.UseVisualStyleBackColor = True
        Me.ChAceptados.Visible = False
        '
        'ChAceptarTodos
        '
        Me.ChAceptarTodos.AutoSize = True
        Me.ChAceptarTodos.Location = New System.Drawing.Point(386, 105)
        Me.ChAceptarTodos.Name = "ChAceptarTodos"
        Me.ChAceptarTodos.Size = New System.Drawing.Size(150, 17)
        Me.ChAceptarTodos.TabIndex = 69
        Me.ChAceptarTodos.Text = "Aceptar todos los registros"
        Me.ChAceptarTodos.UseVisualStyleBackColor = True
        '
        'ChAceptarSel
        '
        Me.ChAceptarSel.AutoSize = True
        Me.ChAceptarSel.Location = New System.Drawing.Point(542, 105)
        Me.ChAceptarSel.Name = "ChAceptarSel"
        Me.ChAceptarSel.Size = New System.Drawing.Size(176, 17)
        Me.ChAceptarSel.TabIndex = 70
        Me.ChAceptarSel.Text = "Aceptar registros seleccionados"
        Me.ChAceptarSel.UseVisualStyleBackColor = True
        '
        'GBFiltro
        '
        Me.GBFiltro.Controls.Add(Me.OPPlantaGir)
        Me.GBFiltro.Controls.Add(Me.OpPlantaSta)
        Me.GBFiltro.Controls.Add(Me.OpPlantaYar)
        Me.GBFiltro.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBFiltro.Location = New System.Drawing.Point(714, 65)
        Me.GBFiltro.Name = "GBFiltro"
        Me.GBFiltro.Size = New System.Drawing.Size(496, 57)
        Me.GBFiltro.TabIndex = 71
        Me.GBFiltro.TabStop = False
        Me.GBFiltro.Text = "Ver Solo Pre Mezclas de Planta..."
        '
        'OpPlantaYar
        '
        Me.OpPlantaYar.AutoSize = True
        Me.OpPlantaYar.Checked = True
        Me.OpPlantaYar.Location = New System.Drawing.Point(22, 26)
        Me.OpPlantaYar.Name = "OpPlantaYar"
        Me.OpPlantaYar.Size = New System.Drawing.Size(78, 20)
        Me.OpPlantaYar.TabIndex = 0
        Me.OpPlantaYar.TabStop = True
        Me.OpPlantaYar.Text = "Yarumal"
        Me.OpPlantaYar.UseVisualStyleBackColor = True
        '
        'OpPlantaSta
        '
        Me.OpPlantaSta.AutoSize = True
        Me.OpPlantaSta.Location = New System.Drawing.Point(169, 26)
        Me.OpPlantaSta.Name = "OpPlantaSta"
        Me.OpPlantaSta.Size = New System.Drawing.Size(98, 20)
        Me.OpPlantaSta.TabIndex = 1
        Me.OpPlantaSta.Text = "Santa Rosa"
        Me.OpPlantaSta.UseVisualStyleBackColor = True
        '
        'OPPlantaGir
        '
        Me.OPPlantaGir.AutoSize = True
        Me.OPPlantaGir.Location = New System.Drawing.Point(326, 26)
        Me.OPPlantaGir.Name = "OPPlantaGir"
        Me.OPPlantaGir.Size = New System.Drawing.Size(86, 20)
        Me.OPPlantaGir.TabIndex = 2
        Me.OPPlantaGir.Text = "Girardota"
        Me.OPPlantaGir.UseVisualStyleBackColor = True
        '
        'RecPremezclas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1273, 452)
        Me.ControlBox = False
        Me.Controls.Add(Me.GBFiltro)
        Me.Controls.Add(Me.ChAceptarSel)
        Me.Controls.Add(Me.ChAceptarTodos)
        Me.Controls.Add(Me.ChAceptados)
        Me.Controls.Add(Me.TSumSacos)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.FRefrescaDG)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BAceptar)
        Me.Controls.Add(Me.TUsuarioRec)
        Me.Controls.Add(Me.THora)
        Me.Controls.Add(Me.TFecha)
        Me.Controls.Add(Me.TObservCostos)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DGPrem)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RecPremezclas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibir Premezclas"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGPrem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GBFiltro.ResumeLayout(False)
        Me.GBFiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents TUsuarioRec As System.Windows.Forms.TextBox
    Friend WithEvents THora As System.Windows.Forms.DateTimePicker
    Friend WithEvents TFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TObservCostos As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TPesoReal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TFechaIni As System.Windows.Forms.TextBox
    Friend WithEvents TPesoMeta As System.Windows.Forms.TextBox
    Friend WithEvents TNomFor As System.Windows.Forms.TextBox
    Friend WithEvents TCodPrem As System.Windows.Forms.TextBox
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGPrem As System.Windows.Forms.DataGridView
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
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents FRefrescaDG As System.Windows.Forms.Button
    Friend WithEvents TSumSacos As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ChAceptados As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColAceptar_NI_ As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cont2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoMeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChAceptarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents ChAceptarSel As System.Windows.Forms.CheckBox
    Friend WithEvents GBFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents OPPlantaGir As System.Windows.Forms.RadioButton
    Friend WithEvents OpPlantaSta As System.Windows.Forms.RadioButton
    Friend WithEvents OpPlantaYar As System.Windows.Forms.RadioButton
End Class
