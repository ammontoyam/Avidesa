<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Despachos
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Despachos))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGDetFact = New System.Windows.Forms.DataGridView()
        Me.IDRow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContadorCB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumFra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomprod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sacos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Placa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Conductor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imprimir_NI_ = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LDetalle = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BSelTodos = New System.Windows.Forms.Button()
        Me.BNoSelec = New System.Windows.Forms.Button()
        Me.BImprimir = New System.Windows.Forms.Button()
        Me.BBuscarFact = New System.Windows.Forms.Button()
        Me.LPlacaFact = New System.Windows.Forms.Label()
        Me.TFiltro = New System.Windows.Forms.TextBox()
        Me.BBuscaDetFact = New System.Windows.Forms.Button()
        Me.BLimpiaDet = New System.Windows.Forms.Button()
        Me.LEstadoCon = New System.Windows.Forms.Label()
        Me.BSaldosPT = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBPlaca = New System.Windows.Forms.RadioButton()
        Me.RBFactura = New System.Windows.Forms.RadioButton()
        Me.GBPropiedades1 = New System.Windows.Forms.GroupBox()
        Me.TIdRow = New System.Windows.Forms.TextBox()
        Me.TSacos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TPlaca = New System.Windows.Forms.TextBox()
        Me.TPesoSaco = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TPeso = New System.Windows.Forms.TextBox()
        Me.TNomProd = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TCodProd = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TFactura = New System.Windows.Forms.TextBox()
        Me.GBPropiedades2 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TConductor = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TFecha = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TTercero = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TNit = New System.Windows.Forms.TextBox()
        Me.GBPropiedades3 = New System.Windows.Forms.GroupBox()
        Me.TObservaciones = New System.Windows.Forms.TextBox()
        Me.TSacosComp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCantDesp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TSaldoLote = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BParcial = New System.Windows.Forms.Button()
        Me.DGParcial = New System.Windows.Forms.DataGridView()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SacDesp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SacNoDesp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TLoteOP = New System.Windows.Forms.ComboBox()
        Me.CUbi = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TSaldoPlanta = New System.Windows.Forms.TextBox()
        Me.TSaldoUbi = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TSacNoDesp = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TMaquila = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TSumSacosProd = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BSalir = New System.Windows.Forms.Button()
        Me.BNuevo = New System.Windows.Forms.Button()
        Me.TSumSacosPlaca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.DGDetFact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBPropiedades1.SuspendLayout()
        Me.GBPropiedades2.SuspendLayout()
        Me.GBPropiedades3.SuspendLayout()
        CType(Me.DGParcial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGDetFact
        '
        Me.DGDetFact.AllowUserToAddRows = False
        Me.DGDetFact.AllowUserToDeleteRows = False
        Me.DGDetFact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDetFact.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDRow, Me.ContadorCB, Me.NumFra, Me.codprod, Me.nomprod, Me.sacos, Me.Peso, Me.Placa, Me.Nit, Me.Tercero, Me.Fecha, Me.Conductor, Me.Imprimir_NI_})
        Me.DGDetFact.Location = New System.Drawing.Point(12, 111)
        Me.DGDetFact.MultiSelect = False
        Me.DGDetFact.Name = "DGDetFact"
        Me.DGDetFact.ReadOnly = True
        Me.DGDetFact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGDetFact.Size = New System.Drawing.Size(1171, 276)
        Me.DGDetFact.TabIndex = 42
        '
        'IDRow
        '
        Me.IDRow.HeaderText = "IDRow"
        Me.IDRow.Name = "IDRow"
        Me.IDRow.ReadOnly = True
        Me.IDRow.Visible = False
        '
        'ContadorCB
        '
        Me.ContadorCB.HeaderText = "ContadorCB"
        Me.ContadorCB.Name = "ContadorCB"
        Me.ContadorCB.ReadOnly = True
        Me.ContadorCB.Visible = False
        '
        'NumFra
        '
        Me.NumFra.HeaderText = "Factura"
        Me.NumFra.Name = "NumFra"
        Me.NumFra.ReadOnly = True
        Me.NumFra.Width = 60
        '
        'codprod
        '
        Me.codprod.HeaderText = "Código"
        Me.codprod.Name = "codprod"
        Me.codprod.ReadOnly = True
        Me.codprod.Width = 70
        '
        'nomprod
        '
        Me.nomprod.HeaderText = "Descripción"
        Me.nomprod.Name = "nomprod"
        Me.nomprod.ReadOnly = True
        Me.nomprod.Width = 180
        '
        'sacos
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.sacos.DefaultCellStyle = DataGridViewCellStyle6
        Me.sacos.HeaderText = "Sacos"
        Me.sacos.Name = "sacos"
        Me.sacos.ReadOnly = True
        Me.sacos.Width = 50
        '
        'Peso
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "0.00"
        Me.Peso.DefaultCellStyle = DataGridViewCellStyle7
        Me.Peso.HeaderText = "Kilos"
        Me.Peso.Name = "Peso"
        Me.Peso.ReadOnly = True
        Me.Peso.Width = 60
        '
        'Placa
        '
        Me.Placa.HeaderText = "Placa"
        Me.Placa.Name = "Placa"
        Me.Placa.ReadOnly = True
        Me.Placa.Width = 60
        '
        'Nit
        '
        Me.Nit.HeaderText = "Nit"
        Me.Nit.Name = "Nit"
        Me.Nit.ReadOnly = True
        '
        'Tercero
        '
        Me.Tercero.HeaderText = "Tercero"
        Me.Tercero.Name = "Tercero"
        Me.Tercero.ReadOnly = True
        Me.Tercero.Width = 200
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 60
        '
        'Conductor
        '
        Me.Conductor.HeaderText = "Conductor"
        Me.Conductor.Name = "Conductor"
        Me.Conductor.ReadOnly = True
        Me.Conductor.Width = 200
        '
        'Imprimir_NI_
        '
        Me.Imprimir_NI_.HeaderText = "Imprimir"
        Me.Imprimir_NI_.Name = "Imprimir_NI_"
        Me.Imprimir_NI_.ReadOnly = True
        Me.Imprimir_NI_.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Imprimir_NI_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Imprimir_NI_.Width = 60
        '
        'LDetalle
        '
        Me.LDetalle.AutoSize = True
        Me.LDetalle.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LDetalle.ForeColor = System.Drawing.Color.Blue
        Me.LDetalle.Location = New System.Drawing.Point(454, 83)
        Me.LDetalle.Name = "LDetalle"
        Me.LDetalle.Size = New System.Drawing.Size(78, 22)
        Me.LDetalle.TabIndex = 59
        Me.LDetalle.Text = "Detalle "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BSelTodos)
        Me.GroupBox1.Controls.Add(Me.BNoSelec)
        Me.GroupBox1.Controls.Add(Me.BImprimir)
        Me.GroupBox1.Controls.Add(Me.BBuscarFact)
        Me.GroupBox1.Controls.Add(Me.LPlacaFact)
        Me.GroupBox1.Controls.Add(Me.TFiltro)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(530, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(640, 62)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'BSelTodos
        '
        Me.BSelTodos.Image = CType(resources.GetObject("BSelTodos.Image"), System.Drawing.Image)
        Me.BSelTodos.Location = New System.Drawing.Point(477, 17)
        Me.BSelTodos.Name = "BSelTodos"
        Me.BSelTodos.Size = New System.Drawing.Size(49, 37)
        Me.BSelTodos.TabIndex = 163
        Me.BSelTodos.UseVisualStyleBackColor = True
        '
        'BNoSelec
        '
        Me.BNoSelec.Image = CType(resources.GetObject("BNoSelec.Image"), System.Drawing.Image)
        Me.BNoSelec.Location = New System.Drawing.Point(530, 17)
        Me.BNoSelec.Name = "BNoSelec"
        Me.BNoSelec.Size = New System.Drawing.Size(49, 37)
        Me.BNoSelec.TabIndex = 162
        Me.BNoSelec.UseVisualStyleBackColor = True
        '
        'BImprimir
        '
        Me.BImprimir.Image = CType(resources.GetObject("BImprimir.Image"), System.Drawing.Image)
        Me.BImprimir.Location = New System.Drawing.Point(582, 17)
        Me.BImprimir.Name = "BImprimir"
        Me.BImprimir.Size = New System.Drawing.Size(49, 37)
        Me.BImprimir.TabIndex = 161
        Me.BImprimir.UseVisualStyleBackColor = True
        '
        'BBuscarFact
        '
        Me.BBuscarFact.Image = CType(resources.GetObject("BBuscarFact.Image"), System.Drawing.Image)
        Me.BBuscarFact.Location = New System.Drawing.Point(366, 17)
        Me.BBuscarFact.Name = "BBuscarFact"
        Me.BBuscarFact.Size = New System.Drawing.Size(49, 37)
        Me.BBuscarFact.TabIndex = 160
        Me.BBuscarFact.UseVisualStyleBackColor = True
        '
        'LPlacaFact
        '
        Me.LPlacaFact.AutoSize = True
        Me.LPlacaFact.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPlacaFact.ForeColor = System.Drawing.Color.Blue
        Me.LPlacaFact.Location = New System.Drawing.Point(62, 26)
        Me.LPlacaFact.Name = "LPlacaFact"
        Me.LPlacaFact.Size = New System.Drawing.Size(127, 19)
        Me.LPlacaFact.TabIndex = 1
        Me.LPlacaFact.Text = "Factura / Placa:"
        '
        'TFiltro
        '
        Me.TFiltro.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFiltro.Location = New System.Drawing.Point(220, 17)
        Me.TFiltro.Name = "TFiltro"
        Me.TFiltro.Size = New System.Drawing.Size(129, 35)
        Me.TFiltro.TabIndex = 0
        Me.TFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BBuscaDetFact
        '
        Me.BBuscaDetFact.Location = New System.Drawing.Point(387, 252)
        Me.BBuscaDetFact.Name = "BBuscaDetFact"
        Me.BBuscaDetFact.Size = New System.Drawing.Size(106, 23)
        Me.BBuscaDetFact.TabIndex = 63
        Me.BBuscaDetFact.Text = "BBuscaDetFact"
        Me.BBuscaDetFact.UseVisualStyleBackColor = True
        Me.BBuscaDetFact.Visible = False
        '
        'BLimpiaDet
        '
        Me.BLimpiaDet.Location = New System.Drawing.Point(231, 322)
        Me.BLimpiaDet.Name = "BLimpiaDet"
        Me.BLimpiaDet.Size = New System.Drawing.Size(100, 23)
        Me.BLimpiaDet.TabIndex = 64
        Me.BLimpiaDet.Text = "BLimpiaDet"
        Me.BLimpiaDet.UseVisualStyleBackColor = True
        Me.BLimpiaDet.Visible = False
        '
        'LEstadoCon
        '
        Me.LEstadoCon.AutoSize = True
        Me.LEstadoCon.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEstadoCon.Location = New System.Drawing.Point(24, 89)
        Me.LEstadoCon.Name = "LEstadoCon"
        Me.LEstadoCon.Size = New System.Drawing.Size(75, 15)
        Me.LEstadoCon.TabIndex = 65
        Me.LEstadoCon.Text = "LEstadoCon"
        Me.LEstadoCon.Visible = False
        '
        'BSaldosPT
        '
        Me.BSaldosPT.Location = New System.Drawing.Point(530, 322)
        Me.BSaldosPT.Name = "BSaldosPT"
        Me.BSaldosPT.Size = New System.Drawing.Size(75, 23)
        Me.BSaldosPT.TabIndex = 159
        Me.BSaldosPT.Text = "BSaldosPT"
        Me.BSaldosPT.UseVisualStyleBackColor = True
        Me.BSaldosPT.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPlaca)
        Me.GroupBox2.Controls.Add(Me.RBFactura)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(245, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(274, 61)
        Me.GroupBox2.TabIndex = 161
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar productos filtrando por:"
        '
        'RBPlaca
        '
        Me.RBPlaca.AutoSize = True
        Me.RBPlaca.Checked = True
        Me.RBPlaca.Location = New System.Drawing.Point(38, 36)
        Me.RBPlaca.Name = "RBPlaca"
        Me.RBPlaca.Size = New System.Drawing.Size(69, 23)
        Me.RBPlaca.TabIndex = 1
        Me.RBPlaca.TabStop = True
        Me.RBPlaca.Text = "Placa"
        Me.RBPlaca.UseVisualStyleBackColor = True
        '
        'RBFactura
        '
        Me.RBFactura.AutoSize = True
        Me.RBFactura.Location = New System.Drawing.Point(152, 36)
        Me.RBFactura.Name = "RBFactura"
        Me.RBFactura.Size = New System.Drawing.Size(85, 23)
        Me.RBFactura.TabIndex = 0
        Me.RBFactura.Text = "Factura"
        Me.RBFactura.UseVisualStyleBackColor = True
        '
        'GBPropiedades1
        '
        Me.GBPropiedades1.Controls.Add(Me.TIdRow)
        Me.GBPropiedades1.Controls.Add(Me.TSacos)
        Me.GBPropiedades1.Controls.Add(Me.Label8)
        Me.GBPropiedades1.Controls.Add(Me.Label17)
        Me.GBPropiedades1.Controls.Add(Me.TPlaca)
        Me.GBPropiedades1.Controls.Add(Me.TPesoSaco)
        Me.GBPropiedades1.Controls.Add(Me.Label9)
        Me.GBPropiedades1.Controls.Add(Me.TPeso)
        Me.GBPropiedades1.Controls.Add(Me.TNomProd)
        Me.GBPropiedades1.Controls.Add(Me.Label7)
        Me.GBPropiedades1.Controls.Add(Me.Label6)
        Me.GBPropiedades1.Controls.Add(Me.TCodProd)
        Me.GBPropiedades1.Location = New System.Drawing.Point(12, 396)
        Me.GBPropiedades1.Name = "GBPropiedades1"
        Me.GBPropiedades1.Size = New System.Drawing.Size(373, 187)
        Me.GBPropiedades1.TabIndex = 162
        Me.GBPropiedades1.TabStop = False
        '
        'TIdRow
        '
        Me.TIdRow.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIdRow.Location = New System.Drawing.Point(246, 21)
        Me.TIdRow.Name = "TIdRow"
        Me.TIdRow.ReadOnly = True
        Me.TIdRow.Size = New System.Drawing.Size(83, 26)
        Me.TIdRow.TabIndex = 192
        Me.TIdRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TIdRow.Visible = False
        '
        'TSacos
        '
        Me.TSacos.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSacos.Location = New System.Drawing.Point(109, 113)
        Me.TSacos.Name = "TSacos"
        Me.TSacos.ReadOnly = True
        Me.TSacos.Size = New System.Drawing.Size(82, 26)
        Me.TSacos.TabIndex = 191
        Me.TSacos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(13, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "Sacos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(12, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 185
        Me.Label17.Text = "Placa"
        '
        'TPlaca
        '
        Me.TPlaca.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPlaca.Location = New System.Drawing.Point(109, 19)
        Me.TPlaca.Name = "TPlaca"
        Me.TPlaca.ReadOnly = True
        Me.TPlaca.Size = New System.Drawing.Size(83, 26)
        Me.TPlaca.TabIndex = 184
        Me.TPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TPesoSaco
        '
        Me.TPesoSaco.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPesoSaco.Location = New System.Drawing.Point(200, 143)
        Me.TPesoSaco.Name = "TPesoSaco"
        Me.TPesoSaco.ReadOnly = True
        Me.TPesoSaco.Size = New System.Drawing.Size(27, 26)
        Me.TPesoSaco.TabIndex = 181
        Me.TPesoSaco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TPesoSaco.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(13, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 180
        Me.Label9.Text = "Peso Total (Kg)"
        '
        'TPeso
        '
        Me.TPeso.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPeso.Location = New System.Drawing.Point(111, 143)
        Me.TPeso.Name = "TPeso"
        Me.TPeso.ReadOnly = True
        Me.TPeso.Size = New System.Drawing.Size(82, 26)
        Me.TPeso.TabIndex = 179
        Me.TPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TNomProd
        '
        Me.TNomProd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNomProd.Location = New System.Drawing.Point(109, 85)
        Me.TNomProd.Name = "TNomProd"
        Me.TNomProd.ReadOnly = True
        Me.TNomProd.Size = New System.Drawing.Size(253, 26)
        Me.TNomProd.TabIndex = 176
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(13, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "Descripción"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(12, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "Código"
        '
        'TCodProd
        '
        Me.TCodProd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodProd.Location = New System.Drawing.Point(109, 54)
        Me.TCodProd.Name = "TCodProd"
        Me.TCodProd.ReadOnly = True
        Me.TCodProd.Size = New System.Drawing.Size(83, 26)
        Me.TCodProd.TabIndex = 173
        Me.TCodProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(15, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 15)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Factura"
        '
        'TFactura
        '
        Me.TFactura.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFactura.Location = New System.Drawing.Point(88, 15)
        Me.TFactura.Name = "TFactura"
        Me.TFactura.ReadOnly = True
        Me.TFactura.Size = New System.Drawing.Size(124, 26)
        Me.TFactura.TabIndex = 182
        Me.TFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBPropiedades2
        '
        Me.GBPropiedades2.Controls.Add(Me.Label23)
        Me.GBPropiedades2.Controls.Add(Me.TConductor)
        Me.GBPropiedades2.Controls.Add(Me.Label12)
        Me.GBPropiedades2.Controls.Add(Me.Label22)
        Me.GBPropiedades2.Controls.Add(Me.TFactura)
        Me.GBPropiedades2.Controls.Add(Me.TFecha)
        Me.GBPropiedades2.Controls.Add(Me.Label19)
        Me.GBPropiedades2.Controls.Add(Me.TTercero)
        Me.GBPropiedades2.Controls.Add(Me.Label18)
        Me.GBPropiedades2.Controls.Add(Me.TNit)
        Me.GBPropiedades2.Location = New System.Drawing.Point(392, 398)
        Me.GBPropiedades2.Name = "GBPropiedades2"
        Me.GBPropiedades2.Size = New System.Drawing.Size(301, 184)
        Me.GBPropiedades2.TabIndex = 163
        Me.GBPropiedades2.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(15, 148)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 15)
        Me.Label23.TabIndex = 191
        Me.Label23.Text = "Conductor"
        '
        'TConductor
        '
        Me.TConductor.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TConductor.Location = New System.Drawing.Point(87, 140)
        Me.TConductor.Name = "TConductor"
        Me.TConductor.ReadOnly = True
        Me.TConductor.Size = New System.Drawing.Size(204, 26)
        Me.TConductor.TabIndex = 190
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(15, 119)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(41, 15)
        Me.Label22.TabIndex = 189
        Me.Label22.Text = "Fecha"
        '
        'TFecha
        '
        Me.TFecha.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFecha.Location = New System.Drawing.Point(87, 111)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.ReadOnly = True
        Me.TFecha.Size = New System.Drawing.Size(123, 26)
        Me.TFecha.TabIndex = 188
        Me.TFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(15, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 15)
        Me.Label19.TabIndex = 187
        Me.Label19.Text = "Tercero"
        '
        'TTercero
        '
        Me.TTercero.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTercero.Location = New System.Drawing.Point(87, 79)
        Me.TTercero.Name = "TTercero"
        Me.TTercero.ReadOnly = True
        Me.TTercero.Size = New System.Drawing.Size(205, 26)
        Me.TTercero.TabIndex = 186
        Me.TTercero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(15, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 15)
        Me.Label18.TabIndex = 185
        Me.Label18.Text = "Nit"
        '
        'TNit
        '
        Me.TNit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNit.Location = New System.Drawing.Point(87, 47)
        Me.TNit.Name = "TNit"
        Me.TNit.ReadOnly = True
        Me.TNit.Size = New System.Drawing.Size(125, 26)
        Me.TNit.TabIndex = 184
        Me.TNit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBPropiedades3
        '
        Me.GBPropiedades3.Controls.Add(Me.TObservaciones)
        Me.GBPropiedades3.Controls.Add(Me.TSacosComp)
        Me.GBPropiedades3.Controls.Add(Me.Label4)
        Me.GBPropiedades3.Controls.Add(Me.TCantDesp)
        Me.GBPropiedades3.Controls.Add(Me.Label3)
        Me.GBPropiedades3.Controls.Add(Me.BAceptar)
        Me.GBPropiedades3.Controls.Add(Me.TSaldoLote)
        Me.GBPropiedades3.Controls.Add(Me.Label2)
        Me.GBPropiedades3.Controls.Add(Me.BParcial)
        Me.GBPropiedades3.Controls.Add(Me.DGParcial)
        Me.GBPropiedades3.Controls.Add(Me.TLoteOP)
        Me.GBPropiedades3.Controls.Add(Me.CUbi)
        Me.GBPropiedades3.Controls.Add(Me.Label21)
        Me.GBPropiedades3.Controls.Add(Me.Label20)
        Me.GBPropiedades3.Controls.Add(Me.Label10)
        Me.GBPropiedades3.Controls.Add(Me.Label13)
        Me.GBPropiedades3.Controls.Add(Me.TSaldoPlanta)
        Me.GBPropiedades3.Controls.Add(Me.TSaldoUbi)
        Me.GBPropiedades3.Controls.Add(Me.Label16)
        Me.GBPropiedades3.Controls.Add(Me.TSacNoDesp)
        Me.GBPropiedades3.Controls.Add(Me.Label11)
        Me.GBPropiedades3.Controls.Add(Me.TMaquila)
        Me.GBPropiedades3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GBPropiedades3.Location = New System.Drawing.Point(701, 394)
        Me.GBPropiedades3.Name = "GBPropiedades3"
        Me.GBPropiedades3.Size = New System.Drawing.Size(482, 270)
        Me.GBPropiedades3.TabIndex = 164
        Me.GBPropiedades3.TabStop = False
        '
        'TObservaciones
        '
        Me.TObservaciones.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TObservaciones.Location = New System.Drawing.Point(275, 50)
        Me.TObservaciones.Multiline = True
        Me.TObservaciones.Name = "TObservaciones"
        Me.TObservaciones.Size = New System.Drawing.Size(201, 41)
        Me.TObservaciones.TabIndex = 195
        '
        'TSacosComp
        '
        Me.TSacosComp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSacosComp.Location = New System.Drawing.Point(133, 205)
        Me.TSacosComp.Name = "TSacosComp"
        Me.TSacosComp.ReadOnly = True
        Me.TSacosComp.Size = New System.Drawing.Size(100, 26)
        Me.TSacosComp.TabIndex = 194
        Me.TSacosComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 193
        Me.Label4.Text = "Cant. Comp."
        '
        'TCantDesp
        '
        Me.TCantDesp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCantDesp.Location = New System.Drawing.Point(133, 177)
        Me.TCantDesp.Name = "TCantDesp"
        Me.TCantDesp.ReadOnly = True
        Me.TCantDesp.Size = New System.Drawing.Size(100, 26)
        Me.TCantDesp.TabIndex = 192
        Me.TCantDesp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Cant. Despachar"
        '
        'BAceptar
        '
        Me.BAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.BAceptar.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAceptar.Location = New System.Drawing.Point(369, 215)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(107, 47)
        Me.BAceptar.TabIndex = 190
        Me.BAceptar.Text = "Aceptar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despacho" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BAceptar.UseVisualStyleBackColor = False
        '
        'TSaldoLote
        '
        Me.TSaldoLote.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSaldoLote.Location = New System.Drawing.Point(133, 149)
        Me.TSaldoLote.Name = "TSaldoLote"
        Me.TSaldoLote.ReadOnly = True
        Me.TSaldoLote.Size = New System.Drawing.Size(100, 26)
        Me.TSaldoLote.TabIndex = 187
        Me.TSaldoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "Saldo Lote"
        '
        'BParcial
        '
        Me.BParcial.Image = CType(resources.GetObject("BParcial.Image"), System.Drawing.Image)
        Me.BParcial.Location = New System.Drawing.Point(239, 176)
        Me.BParcial.Name = "BParcial"
        Me.BParcial.Size = New System.Drawing.Size(30, 27)
        Me.BParcial.TabIndex = 185
        Me.BParcial.UseVisualStyleBackColor = True
        '
        'DGParcial
        '
        Me.DGParcial.AllowUserToAddRows = False
        Me.DGParcial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGParcial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Lote, Me.SacDesp, Me.SacNoDesp})
        Me.DGParcial.Location = New System.Drawing.Point(277, 97)
        Me.DGParcial.Name = "DGParcial"
        Me.DGParcial.Size = New System.Drawing.Size(199, 111)
        Me.DGParcial.TabIndex = 184
        '
        'Lote
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Lote.DefaultCellStyle = DataGridViewCellStyle8
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.Width = 60
        '
        'SacDesp
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SacDesp.DefaultCellStyle = DataGridViewCellStyle9
        Me.SacDesp.HeaderText = "Sacos"
        Me.SacDesp.Name = "SacDesp"
        Me.SacDesp.Width = 40
        '
        'SacNoDesp
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SacNoDesp.DefaultCellStyle = DataGridViewCellStyle10
        Me.SacNoDesp.HeaderText = "No Desp"
        Me.SacNoDesp.Name = "SacNoDesp"
        Me.SacNoDesp.Width = 80
        '
        'TLoteOP
        '
        Me.TLoteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLoteOP.FormattingEnabled = True
        Me.TLoteOP.Location = New System.Drawing.Point(133, 118)
        Me.TLoteOP.Name = "TLoteOP"
        Me.TLoteOP.Size = New System.Drawing.Size(100, 28)
        Me.TLoteOP.TabIndex = 183
        '
        'CUbi
        '
        Me.CUbi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CUbi.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CUbi.FormattingEnabled = True
        Me.CUbi.Location = New System.Drawing.Point(133, 23)
        Me.CUbi.Name = "CUbi"
        Me.CUbi.Size = New System.Drawing.Size(50, 22)
        Me.CUbi.TabIndex = 182
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(14, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 16)
        Me.Label21.TabIndex = 181
        Me.Label21.Text = "Ubicación"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(14, 97)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 16)
        Me.Label20.TabIndex = 180
        Me.Label20.Text = "Saldo en Planta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(272, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 15)
        Me.Label10.TabIndex = 171
        Me.Label10.Text = "Observaciones"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(14, 126)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 173
        Me.Label13.Text = "Lote/OP"
        '
        'TSaldoPlanta
        '
        Me.TSaldoPlanta.BackColor = System.Drawing.Color.Orange
        Me.TSaldoPlanta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSaldoPlanta.ForeColor = System.Drawing.Color.White
        Me.TSaldoPlanta.Location = New System.Drawing.Point(133, 93)
        Me.TSaldoPlanta.Name = "TSaldoPlanta"
        Me.TSaldoPlanta.Size = New System.Drawing.Size(100, 21)
        Me.TSaldoPlanta.TabIndex = 179
        Me.TSaldoPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSaldoUbi
        '
        Me.TSaldoUbi.Location = New System.Drawing.Point(133, 59)
        Me.TSaldoUbi.Name = "TSaldoUbi"
        Me.TSaldoUbi.Size = New System.Drawing.Size(63, 20)
        Me.TSaldoUbi.TabIndex = 172
        Me.TSaldoUbi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(14, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 16)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Saldo Ubicación"
        '
        'TSacNoDesp
        '
        Me.TSacNoDesp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSacNoDesp.Location = New System.Drawing.Point(134, 233)
        Me.TSacNoDesp.Name = "TSacNoDesp"
        Me.TSacNoDesp.Size = New System.Drawing.Size(99, 26)
        Me.TSacNoDesp.TabIndex = 176
        Me.TSacNoDesp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(15, 244)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 15)
        Me.Label11.TabIndex = 177
        Me.Label11.Text = "No Despachados"
        '
        'TMaquila
        '
        Me.TMaquila.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMaquila.Location = New System.Drawing.Point(205, 59)
        Me.TMaquila.Name = "TMaquila"
        Me.TMaquila.Size = New System.Drawing.Size(16, 26)
        Me.TMaquila.TabIndex = 178
        Me.TMaquila.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TMaquila.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.TSumSacosPlaca)
        Me.GroupBox5.Controls.Add(Me.TSumSacosProd)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 589)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(683, 75)
        Me.GroupBox5.TabIndex = 167
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total Sacos"
        '
        'TSumSacosProd
        '
        Me.TSumSacosProd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TSumSacosProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSumSacosProd.Location = New System.Drawing.Point(257, 19)
        Me.TSumSacosProd.Name = "TSumSacosProd"
        Me.TSumSacosProd.Size = New System.Drawing.Size(93, 47)
        Me.TSumSacosProd.TabIndex = 168
        Me.TSumSacosProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BNuevo)
        Me.GroupBox3.Controls.Add(Me.BSalir)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(15, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(224, 62)
        Me.GroupBox3.TabIndex = 168
        Me.GroupBox3.TabStop = False
        '
        'BSalir
        '
        Me.BSalir.Image = CType(resources.GetObject("BSalir.Image"), System.Drawing.Image)
        Me.BSalir.Location = New System.Drawing.Point(14, 15)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(49, 37)
        Me.BSalir.TabIndex = 163
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'BNuevo
        '
        Me.BNuevo.Image = CType(resources.GetObject("BNuevo.Image"), System.Drawing.Image)
        Me.BNuevo.Location = New System.Drawing.Point(65, 15)
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(49, 37)
        Me.BNuevo.TabIndex = 164
        Me.BNuevo.UseVisualStyleBackColor = True
        '
        'TSumSacosPlaca
        '
        Me.TSumSacosPlaca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSumSacosPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSumSacosPlaca.Location = New System.Drawing.Point(564, 19)
        Me.TSumSacosPlaca.Name = "TSumSacosPlaca"
        Me.TSumSacosPlaca.Size = New System.Drawing.Size(93, 47)
        Me.TSumSacosPlaca.TabIndex = 170
        Me.TSumSacosPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(115, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 32)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Producto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(429, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 32)
        Me.Label5.TabIndex = 182
        Me.Label5.Text = "Vehiculo"
        '
        'Despachos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 676)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GBPropiedades3)
        Me.Controls.Add(Me.GBPropiedades2)
        Me.Controls.Add(Me.GBPropiedades1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BSaldosPT)
        Me.Controls.Add(Me.LEstadoCon)
        Me.Controls.Add(Me.BLimpiaDet)
        Me.Controls.Add(Me.BBuscaDetFact)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LDetalle)
        Me.Controls.Add(Me.DGDetFact)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Despachos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Despachos"
        CType(Me.DGDetFact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBPropiedades1.ResumeLayout(False)
        Me.GBPropiedades1.PerformLayout()
        Me.GBPropiedades2.ResumeLayout(False)
        Me.GBPropiedades2.PerformLayout()
        Me.GBPropiedades3.ResumeLayout(False)
        Me.GBPropiedades3.PerformLayout()
        CType(Me.DGParcial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGDetFact As System.Windows.Forms.DataGridView
    Friend WithEvents LDetalle As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TFiltro As System.Windows.Forms.TextBox
    Friend WithEvents LPlacaFact As System.Windows.Forms.Label
    Friend WithEvents BBuscaDetFact As System.Windows.Forms.Button
    Friend WithEvents BLimpiaDet As System.Windows.Forms.Button
    Friend WithEvents LEstadoCon As System.Windows.Forms.Label
    Friend WithEvents BSaldosPT As System.Windows.Forms.Button
    Friend WithEvents BBuscarFact As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPlaca As System.Windows.Forms.RadioButton
    Friend WithEvents RBFactura As System.Windows.Forms.RadioButton
    Friend WithEvents GBPropiedades1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TPlaca As System.Windows.Forms.TextBox
    Friend WithEvents TPesoSaco As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TPeso As System.Windows.Forms.TextBox
    Friend WithEvents TNomProd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TCodProd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TFactura As System.Windows.Forms.TextBox
    Friend WithEvents GBPropiedades2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TConductor As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TTercero As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TNit As System.Windows.Forms.TextBox
    Friend WithEvents GBPropiedades3 As System.Windows.Forms.GroupBox
    Friend WithEvents TLoteOP As System.Windows.Forms.ComboBox
    Friend WithEvents CUbi As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TSaldoPlanta As System.Windows.Forms.TextBox
    Friend WithEvents TSaldoUbi As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TSacNoDesp As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TMaquila As System.Windows.Forms.TextBox
    Friend WithEvents TSaldoLote As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BParcial As System.Windows.Forms.Button
    Friend WithEvents DGParcial As System.Windows.Forms.DataGridView
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents TSacos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TCantDesp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TSacosComp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TSumSacosProd As System.Windows.Forms.TextBox
    Friend WithEvents TIdRow As System.Windows.Forms.TextBox
    Friend WithEvents TObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SacDesp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SacNoDesp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BImprimir As System.Windows.Forms.Button
    Friend WithEvents BSelTodos As System.Windows.Forms.Button
    Friend WithEvents BNoSelec As System.Windows.Forms.Button
    Friend WithEvents IDRow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContadorCB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumFra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents codprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomprod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sacos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Peso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Placa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tercero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Conductor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Imprimir_NI_ As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BSalir As System.Windows.Forms.Button
    Friend WithEvents BNuevo As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TSumSacosPlaca As System.Windows.Forms.TextBox
End Class
