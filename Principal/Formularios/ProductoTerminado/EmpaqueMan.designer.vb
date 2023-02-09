<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpaqueMan
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpaqueMan))
        Me.DGEmpaque = New System.Windows.Forms.DataGridView()
        Me.fechaini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maquina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sacostot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoTot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresKg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sacosnc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sacosajuste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reproceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pesoreproceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TCodInt = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.PDatos = New System.Windows.Forms.Panel()
        Me.GBPaqueteo = New System.Windows.Forms.GroupBox()
        Me.TCodEtiqBolsa = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TNroBolsas = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CBPresKgBolsa = New System.Windows.Forms.ComboBox()
        Me.CBPresKgPaca = New System.Windows.Forms.ComboBox()
        Me.TCodEtiqPaca = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TCodEmpBolsa = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TCodEmpPaca = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CBOrigen = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RBAjuste = New System.Windows.Forms.RadioButton()
        Me.RBManual = New System.Windows.Forms.RadioButton()
        Me.CBDestino = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TCodEtiq = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TMaquina = New System.Windows.Forms.TextBox()
        Me.TSacosAjuste = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TPesoSaco = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TSacos = New System.Windows.Forms.TextBox()
        Me.TNumNc = New System.Windows.Forms.Label()
        Me.TDetalle = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CBPresent = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TObservOP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TPeso = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBTipo = New System.Windows.Forms.ComboBox()
        Me.TNomFor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCodFor = New System.Windows.Forms.TextBox()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.BHabilComboBox = New System.Windows.Forms.Button()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.BFinalizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.TCodEmp = New System.Windows.Forms.ComboBox()
        CType(Me.DGEmpaque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PDatos.SuspendLayout()
        Me.GBPaqueteo.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGEmpaque
        '
        Me.DGEmpaque.AllowUserToAddRows = False
        Me.DGEmpaque.AllowUserToDeleteRows = False
        Me.DGEmpaque.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmpaque.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGEmpaque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEmpaque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fechaini, Me.cont, Me.Tipo, Me.Maquina, Me.sacostot, Me.PesoTot, Me.PresKg, Me.sacosnc, Me.Detalle, Me.sacosajuste, Me.reproceso, Me.pesoreproceso, Me.Estado})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEmpaque.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGEmpaque.Location = New System.Drawing.Point(386, 52)
        Me.DGEmpaque.MultiSelect = False
        Me.DGEmpaque.Name = "DGEmpaque"
        Me.DGEmpaque.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmpaque.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGEmpaque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEmpaque.Size = New System.Drawing.Size(707, 557)
        Me.DGEmpaque.TabIndex = 28
        '
        'fechaini
        '
        Me.fechaini.HeaderText = "Fecha"
        Me.fechaini.Name = "fechaini"
        Me.fechaini.ReadOnly = True
        '
        'cont
        '
        Me.cont.HeaderText = "cont"
        Me.cont.Name = "cont"
        Me.cont.ReadOnly = True
        Me.cont.Visible = False
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'Maquina
        '
        Me.Maquina.HeaderText = "Maq"
        Me.Maquina.Name = "Maquina"
        Me.Maquina.ReadOnly = True
        Me.Maquina.Width = 30
        '
        'sacostot
        '
        Me.sacostot.HeaderText = "Sacos"
        Me.sacostot.Name = "sacostot"
        Me.sacostot.ReadOnly = True
        Me.sacostot.Width = 40
        '
        'PesoTot
        '
        Me.PesoTot.HeaderText = "Peso"
        Me.PesoTot.Name = "PesoTot"
        Me.PesoTot.ReadOnly = True
        Me.PesoTot.Width = 80
        '
        'PresKg
        '
        Me.PresKg.HeaderText = "Pres"
        Me.PresKg.Name = "PresKg"
        Me.PresKg.ReadOnly = True
        Me.PresKg.Width = 40
        '
        'sacosnc
        '
        Me.sacosnc.HeaderText = "SNC"
        Me.sacosnc.Name = "sacosnc"
        Me.sacosnc.ReadOnly = True
        Me.sacosnc.Width = 30
        '
        'Detalle
        '
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ReadOnly = True
        Me.Detalle.Width = 70
        '
        'sacosajuste
        '
        Me.sacosajuste.HeaderText = "Ajuste"
        Me.sacosajuste.Name = "sacosajuste"
        Me.sacosajuste.ReadOnly = True
        Me.sacosajuste.Width = 40
        '
        'reproceso
        '
        Me.reproceso.HeaderText = "Reemp."
        Me.reproceso.Name = "reproceso"
        Me.reproceso.ReadOnly = True
        Me.reproceso.Width = 50
        '
        'pesoreproceso
        '
        Me.pesoreproceso.HeaderText = "PesoReproc"
        Me.pesoreproceso.Name = "pesoreproceso"
        Me.pesoreproceso.ReadOnly = True
        Me.pesoreproceso.Width = 80
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Visible = False
        Me.Estado.Width = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Producto"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(253, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "OP"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCodInt
        '
        Me.TCodInt.Location = New System.Drawing.Point(68, 49)
        Me.TCodInt.Name = "TCodInt"
        Me.TCodInt.ReadOnly = True
        Me.TCodInt.Size = New System.Drawing.Size(75, 20)
        Me.TCodInt.TabIndex = 14
        Me.TCodInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(176, 521)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 11
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'PDatos
        '
        Me.PDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PDatos.Controls.Add(Me.TCodEmp)
        Me.PDatos.Controls.Add(Me.GBPaqueteo)
        Me.PDatos.Controls.Add(Me.CBOrigen)
        Me.PDatos.Controls.Add(Me.Label12)
        Me.PDatos.Controls.Add(Me.RBAjuste)
        Me.PDatos.Controls.Add(Me.RBManual)
        Me.PDatos.Controls.Add(Me.CBDestino)
        Me.PDatos.Controls.Add(Me.Label17)
        Me.PDatos.Controls.Add(Me.TCodEtiq)
        Me.PDatos.Controls.Add(Me.Label16)
        Me.PDatos.Controls.Add(Me.Label15)
        Me.PDatos.Controls.Add(Me.TMaquina)
        Me.PDatos.Controls.Add(Me.TSacosAjuste)
        Me.PDatos.Controls.Add(Me.Label13)
        Me.PDatos.Controls.Add(Me.Label5)
        Me.PDatos.Controls.Add(Me.TPesoSaco)
        Me.PDatos.Controls.Add(Me.Label6)
        Me.PDatos.Controls.Add(Me.TSacos)
        Me.PDatos.Controls.Add(Me.TNumNc)
        Me.PDatos.Controls.Add(Me.TDetalle)
        Me.PDatos.Controls.Add(Me.Label11)
        Me.PDatos.Controls.Add(Me.CBPresent)
        Me.PDatos.Controls.Add(Me.Label10)
        Me.PDatos.Controls.Add(Me.Label9)
        Me.PDatos.Controls.Add(Me.TObservOP)
        Me.PDatos.Controls.Add(Me.Label8)
        Me.PDatos.Controls.Add(Me.TPeso)
        Me.PDatos.Controls.Add(Me.Label7)
        Me.PDatos.Controls.Add(Me.Label4)
        Me.PDatos.Controls.Add(Me.CBTipo)
        Me.PDatos.Controls.Add(Me.TNomFor)
        Me.PDatos.Controls.Add(Me.Label2)
        Me.PDatos.Controls.Add(Me.TCodFor)
        Me.PDatos.Controls.Add(Me.TNombre)
        Me.PDatos.Controls.Add(Me.TOPs)
        Me.PDatos.Controls.Add(Me.Label3)
        Me.PDatos.Controls.Add(Me.Label1)
        Me.PDatos.Controls.Add(Me.TCodInt)
        Me.PDatos.Controls.Add(Me.BCancelar)
        Me.PDatos.Controls.Add(Me.BAceptar)
        Me.PDatos.Location = New System.Drawing.Point(0, 52)
        Me.PDatos.Name = "PDatos"
        Me.PDatos.Size = New System.Drawing.Size(371, 557)
        Me.PDatos.TabIndex = 29
        '
        'GBPaqueteo
        '
        Me.GBPaqueteo.Controls.Add(Me.TCodEtiqBolsa)
        Me.GBPaqueteo.Controls.Add(Me.Label24)
        Me.GBPaqueteo.Controls.Add(Me.TNroBolsas)
        Me.GBPaqueteo.Controls.Add(Me.Label23)
        Me.GBPaqueteo.Controls.Add(Me.CBPresKgBolsa)
        Me.GBPaqueteo.Controls.Add(Me.CBPresKgPaca)
        Me.GBPaqueteo.Controls.Add(Me.TCodEtiqPaca)
        Me.GBPaqueteo.Controls.Add(Me.Label18)
        Me.GBPaqueteo.Controls.Add(Me.Label19)
        Me.GBPaqueteo.Controls.Add(Me.TCodEmpBolsa)
        Me.GBPaqueteo.Controls.Add(Me.Label20)
        Me.GBPaqueteo.Controls.Add(Me.Label21)
        Me.GBPaqueteo.Controls.Add(Me.TCodEmpPaca)
        Me.GBPaqueteo.Controls.Add(Me.Label22)
        Me.GBPaqueteo.Location = New System.Drawing.Point(7, 284)
        Me.GBPaqueteo.Name = "GBPaqueteo"
        Me.GBPaqueteo.Size = New System.Drawing.Size(348, 143)
        Me.GBPaqueteo.TabIndex = 61
        Me.GBPaqueteo.TabStop = False
        Me.GBPaqueteo.Text = "Paqueteo"
        Me.GBPaqueteo.Visible = False
        '
        'TCodEtiqBolsa
        '
        Me.TCodEtiqBolsa.Location = New System.Drawing.Point(255, 61)
        Me.TCodEtiqBolsa.Name = "TCodEtiqBolsa"
        Me.TCodEtiqBolsa.Size = New System.Drawing.Size(88, 20)
        Me.TCodEtiqBolsa.TabIndex = 54
        Me.TCodEtiqBolsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(201, 65)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 13)
        Me.Label24.TabIndex = 53
        Me.Label24.Text = "Etiq.Bolsa"
        '
        'TNroBolsas
        '
        Me.TNroBolsas.Location = New System.Drawing.Point(101, 106)
        Me.TNroBolsas.Name = "TNroBolsas"
        Me.TNroBolsas.Size = New System.Drawing.Size(85, 20)
        Me.TNroBolsas.TabIndex = 52
        Me.TNroBolsas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(15, 110)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Cantidad Bolsas"
        '
        'CBPresKgBolsa
        '
        Me.CBPresKgBolsa.FormattingEnabled = True
        Me.CBPresKgBolsa.Items.AddRange(New Object() {"1", "2", "5", "10"})
        Me.CBPresKgBolsa.Location = New System.Drawing.Point(100, 82)
        Me.CBPresKgBolsa.Name = "CBPresKgBolsa"
        Me.CBPresKgBolsa.Size = New System.Drawing.Size(87, 21)
        Me.CBPresKgBolsa.TabIndex = 50
        '
        'CBPresKgPaca
        '
        Me.CBPresKgPaca.FormattingEnabled = True
        Me.CBPresKgPaca.Items.AddRange(New Object() {"8", "20", "30", "40", "50"})
        Me.CBPresKgPaca.Location = New System.Drawing.Point(100, 36)
        Me.CBPresKgPaca.Name = "CBPresKgPaca"
        Me.CBPresKgPaca.Size = New System.Drawing.Size(87, 21)
        Me.CBPresKgPaca.TabIndex = 49
        '
        'TCodEtiqPaca
        '
        Me.TCodEtiqPaca.Location = New System.Drawing.Point(256, 14)
        Me.TCodEtiqPaca.Name = "TCodEtiqPaca"
        Me.TCodEtiqPaca.Size = New System.Drawing.Size(88, 20)
        Me.TCodEtiqPaca.TabIndex = 48
        Me.TCodEtiqPaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(202, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Etiq.Paca"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(15, 90)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Peso Bolsa"
        '
        'TCodEmpBolsa
        '
        Me.TCodEmpBolsa.Location = New System.Drawing.Point(100, 60)
        Me.TCodEmpBolsa.Name = "TCodEmpBolsa"
        Me.TCodEmpBolsa.Size = New System.Drawing.Size(88, 20)
        Me.TCodEmpBolsa.TabIndex = 44
        Me.TCodEmpBolsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(15, 66)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 13)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Cód.EmpBolsa"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(15, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 13)
        Me.Label21.TabIndex = 41
        Me.Label21.Text = "Peso Paca"
        '
        'TCodEmpPaca
        '
        Me.TCodEmpPaca.Location = New System.Drawing.Point(101, 14)
        Me.TCodEmpPaca.Name = "TCodEmpPaca"
        Me.TCodEmpPaca.Size = New System.Drawing.Size(85, 20)
        Me.TCodEmpPaca.TabIndex = 40
        Me.TCodEmpPaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(15, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 13)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Cód.EmpPaca"
        '
        'CBOrigen
        '
        Me.CBOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBOrigen.Enabled = False
        Me.CBOrigen.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBOrigen.FormattingEnabled = True
        Me.CBOrigen.Items.AddRange(New Object() {"TV", "ZR", "ML", "QR", "EN", "GR", "CD", "B1", "B2", "SC"})
        Me.CBOrigen.Location = New System.Drawing.Point(256, 230)
        Me.CBOrigen.Name = "CBOrigen"
        Me.CBOrigen.Size = New System.Drawing.Size(47, 22)
        Me.CBOrigen.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(194, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 14)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Origen"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RBAjuste
        '
        Me.RBAjuste.AutoSize = True
        Me.RBAjuste.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBAjuste.Location = New System.Drawing.Point(145, 17)
        Me.RBAjuste.Name = "RBAjuste"
        Me.RBAjuste.Size = New System.Drawing.Size(65, 20)
        Me.RBAjuste.TabIndex = 1
        Me.RBAjuste.TabStop = True
        Me.RBAjuste.Text = "Ajuste" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.RBAjuste.UseVisualStyleBackColor = True
        '
        'RBManual
        '
        Me.RBManual.AutoSize = True
        Me.RBManual.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBManual.Location = New System.Drawing.Point(19, 17)
        Me.RBManual.Name = "RBManual"
        Me.RBManual.Size = New System.Drawing.Size(105, 20)
        Me.RBManual.TabIndex = 0
        Me.RBManual.TabStop = True
        Me.RBManual.Text = "Emp.Manual"
        Me.RBManual.UseVisualStyleBackColor = True
        '
        'CBDestino
        '
        Me.CBDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBDestino.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBDestino.FormattingEnabled = True
        Me.CBDestino.Items.AddRange(New Object() {"", "     "})
        Me.CBDestino.Location = New System.Drawing.Point(256, 254)
        Me.CBDestino.Name = "CBDestino"
        Me.CBDestino.Size = New System.Drawing.Size(47, 22)
        Me.CBDestino.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(194, 258)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 14)
        Me.Label17.TabIndex = 53
        Me.Label17.Text = "Destino"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCodEtiq
        '
        Me.TCodEtiq.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodEtiq.Location = New System.Drawing.Point(105, 255)
        Me.TCodEtiq.Name = "TCodEtiq"
        Me.TCodEtiq.ReadOnly = True
        Me.TCodEtiq.Size = New System.Drawing.Size(75, 20)
        Me.TCodEtiq.TabIndex = 52
        Me.TCodEtiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(5, 258)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 14)
        Me.Label16.TabIndex = 51
        Me.Label16.Text = "Código Etiqueta"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(194, 209)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 14)
        Me.Label15.TabIndex = 50
        Me.Label15.Text = "Máquina"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TMaquina
        '
        Me.TMaquina.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMaquina.Location = New System.Drawing.Point(256, 206)
        Me.TMaquina.Name = "TMaquina"
        Me.TMaquina.ReadOnly = True
        Me.TMaquina.Size = New System.Drawing.Size(75, 20)
        Me.TMaquina.TabIndex = 49
        Me.TMaquina.Text = "10"
        Me.TMaquina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSacosAjuste
        '
        Me.TSacosAjuste.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSacosAjuste.Location = New System.Drawing.Point(87, 176)
        Me.TSacosAjuste.Name = "TSacosAjuste"
        Me.TSacosAjuste.Size = New System.Drawing.Size(75, 20)
        Me.TSacosAjuste.TabIndex = 7
        Me.TSacosAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(5, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 14)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Sacos Ajuste"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(4, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Sacos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TPesoSaco
        '
        Me.TPesoSaco.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPesoSaco.Location = New System.Drawing.Point(256, 151)
        Me.TPesoSaco.Name = "TPesoSaco"
        Me.TPesoSaco.ReadOnly = True
        Me.TPesoSaco.Size = New System.Drawing.Size(75, 20)
        Me.TPesoSaco.TabIndex = 43
        Me.TPesoSaco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(177, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 14)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Peso Saco"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TSacos
        '
        Me.TSacos.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSacos.Location = New System.Drawing.Point(87, 152)
        Me.TSacos.Name = "TSacos"
        Me.TSacos.Size = New System.Drawing.Size(75, 20)
        Me.TSacos.TabIndex = 6
        Me.TSacos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNumNc
        '
        Me.TNumNc.AutoSize = True
        Me.TNumNc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNumNc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TNumNc.Location = New System.Drawing.Point(173, 131)
        Me.TNumNc.Name = "TNumNc"
        Me.TNumNc.Size = New System.Drawing.Size(94, 14)
        Me.TNumNc.TabIndex = 40
        Me.TNumNc.Text = "(Numero de NC)"
        Me.TNumNc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TNumNc.Visible = False
        '
        'TDetalle
        '
        Me.TDetalle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDetalle.Location = New System.Drawing.Point(88, 128)
        Me.TDetalle.Name = "TDetalle"
        Me.TDetalle.Size = New System.Drawing.Size(75, 20)
        Me.TDetalle.TabIndex = 5
        Me.TDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(5, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Detalle"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBPresent
        '
        Me.CBPresent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPresent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPresent.FormattingEnabled = True
        Me.CBPresent.Items.AddRange(New Object() {"H", "P", "Q", "E", "1", "2", "NC", ""})
        Me.CBPresent.Location = New System.Drawing.Point(284, 101)
        Me.CBPresent.Name = "CBPresent"
        Me.CBPresent.Size = New System.Drawing.Size(47, 22)
        Me.CBPresent.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(198, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 14)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Presentación"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(8, 451)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 14)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Observaciones OP:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TObservOP
        '
        Me.TObservOP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObservOP.Location = New System.Drawing.Point(11, 467)
        Me.TObservOP.Multiline = True
        Me.TObservOP.Name = "TObservOP"
        Me.TObservOP.Size = New System.Drawing.Size(317, 49)
        Me.TObservOP.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(5, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Código Empaque"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TPeso
        '
        Me.TPeso.Enabled = False
        Me.TPeso.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPeso.Location = New System.Drawing.Point(95, 206)
        Me.TPeso.Name = "TPeso"
        Me.TPeso.Size = New System.Drawing.Size(85, 20)
        Me.TPeso.TabIndex = 8
        Me.TPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(5, 209)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 14)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Peso Total Kg"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(4, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Tipo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBTipo
        '
        Me.CBTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTipo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTipo.FormattingEnabled = True
        Me.CBTipo.Items.AddRange(New Object() {"EMP.MANUAL", "PAQUETEO", "GRANEL", "NC SACOS", "NC KILOS", "REEMPAQUE", "COLA"})
        Me.CBTipo.Location = New System.Drawing.Point(68, 101)
        Me.CBTipo.Name = "CBTipo"
        Me.CBTipo.Size = New System.Drawing.Size(124, 22)
        Me.CBTipo.TabIndex = 3
        '
        'TNomFor
        '
        Me.TNomFor.Location = New System.Drawing.Point(145, 75)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.ReadOnly = True
        Me.TNomFor.Size = New System.Drawing.Size(209, 20)
        Me.TNomFor.TabIndex = 21
        Me.TNomFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Fórmula"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TCodFor
        '
        Me.TCodFor.Location = New System.Drawing.Point(68, 75)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.ReadOnly = True
        Me.TCodFor.Size = New System.Drawing.Size(75, 20)
        Me.TCodFor.TabIndex = 19
        Me.TCodFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNombre
        '
        Me.TNombre.Location = New System.Drawing.Point(144, 49)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.ReadOnly = True
        Me.TNombre.Size = New System.Drawing.Size(211, 20)
        Me.TNombre.TabIndex = 18
        Me.TNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOPs
        '
        Me.TOPs.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPs.Location = New System.Drawing.Point(280, 18)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.Size = New System.Drawing.Size(75, 20)
        Me.TOPs.TabIndex = 2
        Me.TOPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TOPs, " Digite la OP y a continuación la tecla enter para buscar los registros de empaqu" &
        "e ")
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(134, 521)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 12
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'BHabilComboBox
        '
        Me.BHabilComboBox.Location = New System.Drawing.Point(422, 138)
        Me.BHabilComboBox.Name = "BHabilComboBox"
        Me.BHabilComboBox.Size = New System.Drawing.Size(102, 23)
        Me.BHabilComboBox.TabIndex = 60
        Me.BHabilComboBox.Text = "BHabilComboBox"
        Me.BHabilComboBox.UseVisualStyleBackColor = True
        Me.BHabilComboBox.Visible = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1123, 24)
        Me.MenuStrip2.TabIndex = 35
        Me.MenuStrip2.Text = "MenuStrip2"
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
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator1, Me.BEditar, Me.ToolStripSeparator4, Me.BNuevo, Me.BFinalizar, Me.ToolStripSeparator5, Me.BActualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1123, 25)
        Me.ToolStrip1.TabIndex = 36
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'BFinalizar
        '
        Me.BFinalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BFinalizar.Image = CType(resources.GetObject("BFinalizar.Image"), System.Drawing.Image)
        Me.BFinalizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BFinalizar.Name = "BFinalizar"
        Me.BFinalizar.Size = New System.Drawing.Size(23, 22)
        Me.BFinalizar.ToolTipText = "Finalizar OP"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(422, 108)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(134, 24)
        Me.FRefrescaDG.TabIndex = 60
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'TCodEmp
        '
        Me.TCodEmp.FormattingEnabled = True
        Me.TCodEmp.Location = New System.Drawing.Point(105, 231)
        Me.TCodEmp.Name = "TCodEmp"
        Me.TCodEmp.Size = New System.Drawing.Size(75, 21)
        Me.TCodEmp.TabIndex = 62
        '
        'EmpaqueMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 611)
        Me.Controls.Add(Me.FRefrescaDG)
        Me.Controls.Add(Me.BHabilComboBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.DGEmpaque)
        Me.Controls.Add(Me.PDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmpaqueMan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empaque Manual"
        CType(Me.DGEmpaque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PDatos.ResumeLayout(False)
        Me.PDatos.PerformLayout()
        Me.GBPaqueteo.ResumeLayout(False)
        Me.GBPaqueteo.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGEmpaque As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TCodInt As System.Windows.Forms.TextBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents PDatos As System.Windows.Forms.Panel
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents TNombre As System.Windows.Forms.TextBox
    Friend WithEvents TNomFor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TCodFor As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TObservOP As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CBDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TCodEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TMaquina As System.Windows.Forms.TextBox
    Friend WithEvents TSacosAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TPesoSaco As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TSacos As System.Windows.Forms.TextBox
    Friend WithEvents TNumNc As System.Windows.Forms.Label
    Friend WithEvents TDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CBPresent As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BFinalizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents RBAjuste As System.Windows.Forms.RadioButton
    Friend WithEvents RBManual As System.Windows.Forms.RadioButton
    Friend WithEvents CBOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BHabilComboBox As System.Windows.Forms.Button
    Friend WithEvents GBPaqueteo As System.Windows.Forms.GroupBox
    Friend WithEvents TNroBolsas As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CBPresKgBolsa As System.Windows.Forms.ComboBox
    Friend WithEvents CBPresKgPaca As System.Windows.Forms.ComboBox
    Friend WithEvents TCodEtiqPaca As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TCodEmpBolsa As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TCodEmpPaca As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TCodEtiqBolsa As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents FRefrescaDG As Button
    Friend WithEvents fechaini As DataGridViewTextBoxColumn
    Friend WithEvents cont As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents Maquina As DataGridViewTextBoxColumn
    Friend WithEvents sacostot As DataGridViewTextBoxColumn
    Friend WithEvents PesoTot As DataGridViewTextBoxColumn
    Friend WithEvents PresKg As DataGridViewTextBoxColumn
    Friend WithEvents sacosnc As DataGridViewTextBoxColumn
    Friend WithEvents Detalle As DataGridViewTextBoxColumn
    Friend WithEvents sacosajuste As DataGridViewTextBoxColumn
    Friend WithEvents reproceso As DataGridViewTextBoxColumn
    Friend WithEvents pesoreproceso As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents TCodEmp As ComboBox
End Class
