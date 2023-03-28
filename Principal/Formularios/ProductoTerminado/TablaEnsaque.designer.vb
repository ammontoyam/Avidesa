<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablaEnsaque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TablaEnsaque))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GBTotales = New System.Windows.Forms.GroupBox()
        Me.LEmpaque = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LGranel = New System.Windows.Forms.Label()
        Me.TTotKg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TTotSacos = New System.Windows.Forms.TextBox()
        Me.GBLinea2 = New System.Windows.Forms.GroupBox()
        Me.LEmpaque2 = New System.Windows.Forms.Label()
        Me.LGranel2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TKg2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TTotSacos2 = New System.Windows.Forms.TextBox()
        Me.GBLinea1 = New System.Windows.Forms.GroupBox()
        Me.LEmpaque1 = New System.Windows.Forms.Label()
        Me.LGranel1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TKg1 = New System.Windows.Forms.TextBox()
        Me.TTotSacos1 = New System.Windows.Forms.TextBox()
        Me.CBDestino = New System.Windows.Forms.ComboBox()
        Me.BFTotal = New System.Windows.Forms.Button()
        Me.RBManual = New System.Windows.Forms.RadioButton()
        Me.RBLiquidos = New System.Windows.Forms.RadioButton()
        Me.RBSoya = New System.Windows.Forms.RadioButton()
        Me.RBHarinas = New System.Windows.Forms.RadioButton()
        Me.RBDosificado = New System.Windows.Forms.RadioButton()
        Me.RBMolienda = New System.Windows.Forms.RadioButton()
        Me.RBGranelera2 = New System.Windows.Forms.RadioButton()
        Me.RBEnsacadora = New System.Windows.Forms.RadioButton()
        Me.RBGranelera = New System.Windows.Forms.RadioButton()
        Me.DGEnsaque = New System.Windows.Forms.DataGridView()
        Me.ORDENDESP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAQUINA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORIGEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPROD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMPROD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTINO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SACOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRESENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAINI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RESIDUO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SACOSDEV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESODEV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODETIQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODHILAZA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.Panel1.SuspendLayout()
        Me.GBTotales.SuspendLayout()
        Me.GBLinea2.SuspendLayout()
        Me.GBLinea1.SuspendLayout()
        CType(Me.DGEnsaque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GBTotales)
        Me.Panel1.Controls.Add(Me.GBLinea2)
        Me.Panel1.Controls.Add(Me.GBLinea1)
        Me.Panel1.Controls.Add(Me.CBDestino)
        Me.Panel1.Controls.Add(Me.BFTotal)
        Me.Panel1.Controls.Add(Me.RBManual)
        Me.Panel1.Controls.Add(Me.RBLiquidos)
        Me.Panel1.Controls.Add(Me.RBSoya)
        Me.Panel1.Controls.Add(Me.RBHarinas)
        Me.Panel1.Controls.Add(Me.RBDosificado)
        Me.Panel1.Controls.Add(Me.RBMolienda)
        Me.Panel1.Controls.Add(Me.RBGranelera2)
        Me.Panel1.Controls.Add(Me.RBEnsacadora)
        Me.Panel1.Controls.Add(Me.RBGranelera)
        Me.Panel1.Location = New System.Drawing.Point(3, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1245, 90)
        Me.Panel1.TabIndex = 29
        '
        'GBTotales
        '
        Me.GBTotales.Controls.Add(Me.LEmpaque)
        Me.GBTotales.Controls.Add(Me.Label5)
        Me.GBTotales.Controls.Add(Me.LGranel)
        Me.GBTotales.Controls.Add(Me.TTotKg)
        Me.GBTotales.Controls.Add(Me.Label6)
        Me.GBTotales.Controls.Add(Me.TTotSacos)
        Me.GBTotales.Location = New System.Drawing.Point(525, 4)
        Me.GBTotales.Name = "GBTotales"
        Me.GBTotales.Size = New System.Drawing.Size(254, 80)
        Me.GBTotales.TabIndex = 39
        Me.GBTotales.TabStop = False
        Me.GBTotales.Text = "Totales"
        '
        'LEmpaque
        '
        Me.LEmpaque.AutoSize = True
        Me.LEmpaque.Location = New System.Drawing.Point(1, 35)
        Me.LEmpaque.Name = "LEmpaque"
        Me.LEmpaque.Size = New System.Drawing.Size(52, 13)
        Me.LEmpaque.TabIndex = 8
        Me.LEmpaque.Text = "Empaque"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Kg"
        '
        'LGranel
        '
        Me.LGranel.AutoSize = True
        Me.LGranel.Location = New System.Drawing.Point(1, 16)
        Me.LGranel.Name = "LGranel"
        Me.LGranel.Size = New System.Drawing.Size(38, 13)
        Me.LGranel.TabIndex = 7
        Me.LGranel.Text = "Granel"
        '
        'TTotKg
        '
        Me.TTotKg.Location = New System.Drawing.Point(154, 53)
        Me.TTotKg.Name = "TTotKg"
        Me.TTotKg.ReadOnly = True
        Me.TTotKg.Size = New System.Drawing.Size(93, 20)
        Me.TTotKg.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Sacos"
        '
        'TTotSacos
        '
        Me.TTotSacos.Location = New System.Drawing.Point(42, 53)
        Me.TTotSacos.Name = "TTotSacos"
        Me.TTotSacos.ReadOnly = True
        Me.TTotSacos.Size = New System.Drawing.Size(84, 20)
        Me.TTotSacos.TabIndex = 2
        '
        'GBLinea2
        '
        Me.GBLinea2.Controls.Add(Me.LEmpaque2)
        Me.GBLinea2.Controls.Add(Me.LGranel2)
        Me.GBLinea2.Controls.Add(Me.Label3)
        Me.GBLinea2.Controls.Add(Me.TKg2)
        Me.GBLinea2.Controls.Add(Me.Label4)
        Me.GBLinea2.Controls.Add(Me.TTotSacos2)
        Me.GBLinea2.Location = New System.Drawing.Point(1016, 4)
        Me.GBLinea2.Name = "GBLinea2"
        Me.GBLinea2.Size = New System.Drawing.Size(221, 80)
        Me.GBLinea2.TabIndex = 38
        Me.GBLinea2.TabStop = False
        Me.GBLinea2.Text = "Linea 2"
        '
        'LEmpaque2
        '
        Me.LEmpaque2.AutoSize = True
        Me.LEmpaque2.Location = New System.Drawing.Point(6, 35)
        Me.LEmpaque2.Name = "LEmpaque2"
        Me.LEmpaque2.Size = New System.Drawing.Size(52, 13)
        Me.LEmpaque2.TabIndex = 7
        Me.LEmpaque2.Text = "Empaque"
        '
        'LGranel2
        '
        Me.LGranel2.AutoSize = True
        Me.LGranel2.Location = New System.Drawing.Point(6, 16)
        Me.LGranel2.Name = "LGranel2"
        Me.LGranel2.Size = New System.Drawing.Size(38, 13)
        Me.LGranel2.TabIndex = 6
        Me.LGranel2.Text = "Granel"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(114, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kg"
        '
        'TKg2
        '
        Me.TKg2.Location = New System.Drawing.Point(137, 53)
        Me.TKg2.Name = "TKg2"
        Me.TKg2.ReadOnly = True
        Me.TKg2.Size = New System.Drawing.Size(81, 20)
        Me.TKg2.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Bultos"
        '
        'TTotSacos2
        '
        Me.TTotSacos2.Location = New System.Drawing.Point(49, 53)
        Me.TTotSacos2.Name = "TTotSacos2"
        Me.TTotSacos2.ReadOnly = True
        Me.TTotSacos2.Size = New System.Drawing.Size(60, 20)
        Me.TTotSacos2.TabIndex = 2
        '
        'GBLinea1
        '
        Me.GBLinea1.Controls.Add(Me.LEmpaque1)
        Me.GBLinea1.Controls.Add(Me.LGranel1)
        Me.GBLinea1.Controls.Add(Me.Label2)
        Me.GBLinea1.Controls.Add(Me.Label1)
        Me.GBLinea1.Controls.Add(Me.TKg1)
        Me.GBLinea1.Controls.Add(Me.TTotSacos1)
        Me.GBLinea1.Location = New System.Drawing.Point(781, 4)
        Me.GBLinea1.Name = "GBLinea1"
        Me.GBLinea1.Size = New System.Drawing.Size(221, 80)
        Me.GBLinea1.TabIndex = 37
        Me.GBLinea1.TabStop = False
        Me.GBLinea1.Text = "Linea 1"
        '
        'LEmpaque1
        '
        Me.LEmpaque1.AutoSize = True
        Me.LEmpaque1.Location = New System.Drawing.Point(7, 35)
        Me.LEmpaque1.Name = "LEmpaque1"
        Me.LEmpaque1.Size = New System.Drawing.Size(52, 13)
        Me.LEmpaque1.TabIndex = 6
        Me.LEmpaque1.Text = "Empaque"
        '
        'LGranel1
        '
        Me.LGranel1.AutoSize = True
        Me.LGranel1.Location = New System.Drawing.Point(7, 16)
        Me.LGranel1.Name = "LGranel1"
        Me.LGranel1.Size = New System.Drawing.Size(38, 13)
        Me.LGranel1.TabIndex = 5
        Me.LGranel1.Text = "Granel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(114, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Kg"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Bultos"
        '
        'TKg1
        '
        Me.TKg1.Location = New System.Drawing.Point(137, 53)
        Me.TKg1.Name = "TKg1"
        Me.TKg1.ReadOnly = True
        Me.TKg1.Size = New System.Drawing.Size(81, 20)
        Me.TKg1.TabIndex = 1
        '
        'TTotSacos1
        '
        Me.TTotSacos1.Location = New System.Drawing.Point(51, 53)
        Me.TTotSacos1.Name = "TTotSacos1"
        Me.TTotSacos1.ReadOnly = True
        Me.TTotSacos1.Size = New System.Drawing.Size(60, 20)
        Me.TTotSacos1.TabIndex = 0
        '
        'CBDestino
        '
        Me.CBDestino.FormattingEnabled = True
        Me.CBDestino.Items.AddRange(New Object() {"1", "2", "3", "5", "10"})
        Me.CBDestino.Location = New System.Drawing.Point(391, 36)
        Me.CBDestino.Name = "CBDestino"
        Me.CBDestino.Size = New System.Drawing.Size(39, 21)
        Me.CBDestino.TabIndex = 36
        '
        'BFTotal
        '
        Me.BFTotal.Location = New System.Drawing.Point(340, 61)
        Me.BFTotal.Name = "BFTotal"
        Me.BFTotal.Size = New System.Drawing.Size(75, 23)
        Me.BFTotal.TabIndex = 33
        Me.BFTotal.Text = "FTotal"
        Me.BFTotal.UseVisualStyleBackColor = True
        Me.BFTotal.Visible = False
        '
        'RBManual
        '
        Me.RBManual.AutoSize = True
        Me.RBManual.Location = New System.Drawing.Point(226, 38)
        Me.RBManual.Name = "RBManual"
        Me.RBManual.Size = New System.Drawing.Size(60, 17)
        Me.RBManual.TabIndex = 35
        Me.RBManual.TabStop = True
        Me.RBManual.Text = "Manual"
        Me.RBManual.UseVisualStyleBackColor = True
        '
        'RBLiquidos
        '
        Me.RBLiquidos.AutoSize = True
        Me.RBLiquidos.Location = New System.Drawing.Point(320, 38)
        Me.RBLiquidos.Name = "RBLiquidos"
        Me.RBLiquidos.Size = New System.Drawing.Size(66, 17)
        Me.RBLiquidos.TabIndex = 34
        Me.RBLiquidos.TabStop = True
        Me.RBLiquidos.Text = "Líquidos"
        Me.RBLiquidos.UseVisualStyleBackColor = True
        '
        'RBSoya
        '
        Me.RBSoya.AutoSize = True
        Me.RBSoya.Location = New System.Drawing.Point(120, 38)
        Me.RBSoya.Name = "RBSoya"
        Me.RBSoya.Size = New System.Drawing.Size(89, 17)
        Me.RBSoya.TabIndex = 33
        Me.RBSoya.TabStop = True
        Me.RBSoya.Text = "Paso P. Soya"
        Me.RBSoya.UseVisualStyleBackColor = True
        '
        'RBHarinas
        '
        Me.RBHarinas.AutoSize = True
        Me.RBHarinas.Location = New System.Drawing.Point(13, 38)
        Me.RBHarinas.Name = "RBHarinas"
        Me.RBHarinas.Size = New System.Drawing.Size(95, 17)
        Me.RBHarinas.TabIndex = 32
        Me.RBHarinas.TabStop = True
        Me.RBHarinas.Text = "Paso Ent. Frijol"
        Me.RBHarinas.UseVisualStyleBackColor = True
        '
        'RBDosificado
        '
        Me.RBDosificado.AutoSize = True
        Me.RBDosificado.Location = New System.Drawing.Point(439, 15)
        Me.RBDosificado.Name = "RBDosificado"
        Me.RBDosificado.Size = New System.Drawing.Size(75, 17)
        Me.RBDosificado.TabIndex = 31
        Me.RBDosificado.TabStop = True
        Me.RBDosificado.Text = "Dosificado"
        Me.RBDosificado.UseVisualStyleBackColor = True
        '
        'RBMolienda
        '
        Me.RBMolienda.AutoSize = True
        Me.RBMolienda.Location = New System.Drawing.Point(320, 15)
        Me.RBMolienda.Name = "RBMolienda"
        Me.RBMolienda.Size = New System.Drawing.Size(95, 17)
        Me.RBMolienda.TabIndex = 30
        Me.RBMolienda.TabStop = True
        Me.RBMolienda.Text = "Paso Molienda"
        Me.RBMolienda.UseVisualStyleBackColor = True
        '
        'RBGranelera2
        '
        Me.RBGranelera2.AutoSize = True
        Me.RBGranelera2.Location = New System.Drawing.Point(120, 15)
        Me.RBGranelera2.Name = "RBGranelera2"
        Me.RBGranelera2.Size = New System.Drawing.Size(80, 17)
        Me.RBGranelera2.TabIndex = 29
        Me.RBGranelera2.TabStop = True
        Me.RBGranelera2.Text = "Granelera 2"
        Me.RBGranelera2.UseVisualStyleBackColor = True
        '
        'RBEnsacadora
        '
        Me.RBEnsacadora.AutoSize = True
        Me.RBEnsacadora.Location = New System.Drawing.Point(226, 15)
        Me.RBEnsacadora.Name = "RBEnsacadora"
        Me.RBEnsacadora.Size = New System.Drawing.Size(82, 17)
        Me.RBEnsacadora.TabIndex = 28
        Me.RBEnsacadora.TabStop = True
        Me.RBEnsacadora.Text = "Ensacadora"
        Me.RBEnsacadora.UseVisualStyleBackColor = True
        '
        'RBGranelera
        '
        Me.RBGranelera.AutoSize = True
        Me.RBGranelera.Location = New System.Drawing.Point(13, 15)
        Me.RBGranelera.Name = "RBGranelera"
        Me.RBGranelera.Size = New System.Drawing.Size(71, 17)
        Me.RBGranelera.TabIndex = 27
        Me.RBGranelera.TabStop = True
        Me.RBGranelera.Text = "Granelera"
        Me.RBGranelera.UseVisualStyleBackColor = True
        '
        'DGEnsaque
        '
        Me.DGEnsaque.AllowUserToAddRows = False
        Me.DGEnsaque.AllowUserToDeleteRows = False
        Me.DGEnsaque.AllowUserToResizeRows = False
        Me.DGEnsaque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEnsaque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ORDENDESP, Me.OP, Me.MAQUINA, Me.ORIGEN, Me.CODPROD, Me.NOMPROD, Me.DESTINO, Me.SACOS, Me.PRESENT, Me.PESO, Me.FECHAINI, Me.RESIDUO, Me.SACOSDEV, Me.PESODEV, Me.CODEMP, Me.CODETIQ, Me.CODHILAZA, Me.CONT})
        Me.DGEnsaque.Location = New System.Drawing.Point(3, 142)
        Me.DGEnsaque.MultiSelect = False
        Me.DGEnsaque.Name = "DGEnsaque"
        Me.DGEnsaque.ReadOnly = True
        Me.DGEnsaque.RowHeadersWidth = 25
        Me.DGEnsaque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEnsaque.Size = New System.Drawing.Size(1249, 575)
        Me.DGEnsaque.TabIndex = 28
        '
        'ORDENDESP
        '
        Me.ORDENDESP.HeaderText = "Ord. Despacho"
        Me.ORDENDESP.Name = "ORDENDESP"
        Me.ORDENDESP.ReadOnly = True
        Me.ORDENDESP.Width = 80
        '
        'OP
        '
        Me.OP.HeaderText = "OP"
        Me.OP.Name = "OP"
        Me.OP.ReadOnly = True
        Me.OP.Width = 70
        '
        'MAQUINA
        '
        Me.MAQUINA.HeaderText = "Máquina"
        Me.MAQUINA.Name = "MAQUINA"
        Me.MAQUINA.ReadOnly = True
        Me.MAQUINA.Width = 55
        '
        'ORIGEN
        '
        Me.ORIGEN.HeaderText = "Origen"
        Me.ORIGEN.Name = "ORIGEN"
        Me.ORIGEN.ReadOnly = True
        Me.ORIGEN.Width = 55
        '
        'CODPROD
        '
        Me.CODPROD.HeaderText = "Cód. Producto"
        Me.CODPROD.Name = "CODPROD"
        Me.CODPROD.ReadOnly = True
        Me.CODPROD.Width = 55
        '
        'NOMPROD
        '
        Me.NOMPROD.HeaderText = "Nom. Producto"
        Me.NOMPROD.Name = "NOMPROD"
        Me.NOMPROD.ReadOnly = True
        Me.NOMPROD.Width = 120
        '
        'DESTINO
        '
        Me.DESTINO.HeaderText = "Destino"
        Me.DESTINO.Name = "DESTINO"
        Me.DESTINO.ReadOnly = True
        '
        'SACOS
        '
        Me.SACOS.HeaderText = "Sacos"
        Me.SACOS.Name = "SACOS"
        Me.SACOS.ReadOnly = True
        Me.SACOS.Width = 65
        '
        'PRESENT
        '
        Me.PRESENT.HeaderText = "Present."
        Me.PRESENT.Name = "PRESENT"
        Me.PRESENT.ReadOnly = True
        Me.PRESENT.Width = 55
        '
        'PESO
        '
        Me.PESO.HeaderText = "Total kg"
        Me.PESO.Name = "PESO"
        Me.PESO.ReadOnly = True
        Me.PESO.Width = 75
        '
        'FECHAINI
        '
        Me.FECHAINI.HeaderText = "Fecha"
        Me.FECHAINI.Name = "FECHAINI"
        Me.FECHAINI.ReadOnly = True
        '
        'RESIDUO
        '
        Me.RESIDUO.HeaderText = "Residuo"
        Me.RESIDUO.Name = "RESIDUO"
        Me.RESIDUO.ReadOnly = True
        Me.RESIDUO.Width = 50
        '
        'SACOSDEV
        '
        Me.SACOSDEV.HeaderText = "Sacos Dev."
        Me.SACOSDEV.Name = "SACOSDEV"
        Me.SACOSDEV.ReadOnly = True
        Me.SACOSDEV.Width = 50
        '
        'PESODEV
        '
        Me.PESODEV.HeaderText = "Peso Dev."
        Me.PESODEV.Name = "PESODEV"
        Me.PESODEV.ReadOnly = True
        Me.PESODEV.Width = 50
        '
        'CODEMP
        '
        Me.CODEMP.HeaderText = "Tipo Empaque"
        Me.CODEMP.Name = "CODEMP"
        Me.CODEMP.ReadOnly = True
        Me.CODEMP.Width = 55
        '
        'CODETIQ
        '
        Me.CODETIQ.HeaderText = "Cód. Etiqueta"
        Me.CODETIQ.Name = "CODETIQ"
        Me.CODETIQ.ReadOnly = True
        Me.CODETIQ.Width = 50
        '
        'CODHILAZA
        '
        Me.CODHILAZA.HeaderText = "Cód. Hilaza"
        Me.CODHILAZA.Name = "CODHILAZA"
        Me.CODHILAZA.ReadOnly = True
        Me.CODHILAZA.Width = 50
        '
        'CONT
        '
        Me.CONT.HeaderText = "Cons. Empaque"
        Me.CONT.Name = "CONT"
        Me.CONT.ReadOnly = True
        Me.CONT.Width = 70
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator7, Me.BEditar, Me.ToolStripSeparator8, Me.BBorrar, Me.ToolStripSeparator10, Me.BActualizar, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1260, 25)
        Me.ToolStrip1.TabIndex = 32
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
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
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
        'BBorrar
        '
        Me.BBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBorrar.Image = CType(resources.GetObject("BBorrar.Image"), System.Drawing.Image)
        Me.BBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBorrar.Name = "BBorrar"
        Me.BBorrar.Size = New System.Drawing.Size(23, 22)
        Me.BBorrar.ToolTipText = "Finalizar OP"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
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
        Me.CBBuscar.Items.AddRange(New Object() {"OP", "Cód. Producto", "Año"})
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(95, 25)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(100, 25)
        '
        'TablaEnsaque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 729)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGEnsaque)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TablaEnsaque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabla de Ensaque"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GBTotales.ResumeLayout(False)
        Me.GBTotales.PerformLayout()
        Me.GBLinea2.ResumeLayout(False)
        Me.GBLinea2.PerformLayout()
        Me.GBLinea1.ResumeLayout(False)
        Me.GBLinea1.PerformLayout()
        CType(Me.DGEnsaque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DGEnsaque As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RBMolienda As RadioButton
    Friend WithEvents RBGranelera2 As RadioButton
    Friend WithEvents RBEnsacadora As RadioButton
    Friend WithEvents RBGranelera As RadioButton
    Friend WithEvents BBorrar As ToolStripButton
    Friend WithEvents RBDosificado As RadioButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents CBBuscar As ToolStripComboBox
    Friend WithEvents TBuscar As ToolStripTextBox
    Friend WithEvents BFTotal As Button
    Friend WithEvents RBSoya As RadioButton
    Friend WithEvents RBHarinas As RadioButton
    Friend WithEvents RBManual As RadioButton
    Friend WithEvents RBLiquidos As RadioButton
    Friend WithEvents CBDestino As ComboBox
    Friend WithEvents GBLinea2 As GroupBox
    Friend WithEvents GBLinea1 As GroupBox
    Friend WithEvents TTotSacos1 As TextBox
    Friend WithEvents TKg1 As TextBox
    Friend WithEvents TTotKg As TextBox
    Friend WithEvents TTotSacos As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TKg2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TTotSacos2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LEmpaque2 As Label
    Friend WithEvents LGranel2 As Label
    Friend WithEvents LEmpaque1 As Label
    Friend WithEvents LGranel1 As Label
    Friend WithEvents GBTotales As GroupBox
    Friend WithEvents LEmpaque As Label
    Friend WithEvents LGranel As Label
    Friend WithEvents ORDENDESP As DataGridViewTextBoxColumn
    Friend WithEvents OP As DataGridViewTextBoxColumn
    Friend WithEvents MAQUINA As DataGridViewTextBoxColumn
    Friend WithEvents ORIGEN As DataGridViewTextBoxColumn
    Friend WithEvents CODPROD As DataGridViewTextBoxColumn
    Friend WithEvents NOMPROD As DataGridViewTextBoxColumn
    Friend WithEvents DESTINO As DataGridViewTextBoxColumn
    Friend WithEvents SACOS As DataGridViewTextBoxColumn
    Friend WithEvents PRESENT As DataGridViewTextBoxColumn
    Friend WithEvents PESO As DataGridViewTextBoxColumn
    Friend WithEvents FECHAINI As DataGridViewTextBoxColumn
    Friend WithEvents RESIDUO As DataGridViewTextBoxColumn
    Friend WithEvents SACOSDEV As DataGridViewTextBoxColumn
    Friend WithEvents PESODEV As DataGridViewTextBoxColumn
    Friend WithEvents CODEMP As DataGridViewTextBoxColumn
    Friend WithEvents CODETIQ As DataGridViewTextBoxColumn
    Friend WithEvents CODHILAZA As DataGridViewTextBoxColumn
    Friend WithEvents CONT As DataGridViewTextBoxColumn
End Class
