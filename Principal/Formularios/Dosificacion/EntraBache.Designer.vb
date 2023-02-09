<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntraBache
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EntraBache))
        Me.DGEntraBach = New System.Windows.Forms.DataGridView()
        Me.CodMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoMeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LInfo1 = New System.Windows.Forms.Label()
        Me.LInfo2 = New System.Windows.Forms.Label()
        Me.TContador = New System.Windows.Forms.TextBox()
        Me.TCodFor = New System.Windows.Forms.TextBox()
        Me.TCodForB = New System.Windows.Forms.TextBox()
        Me.TNomFor = New System.Windows.Forms.TextBox()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.TPorc = New System.Windows.Forms.TextBox()
        Me.TPeso = New System.Windows.Forms.TextBox()
        Me.TFecha = New System.Windows.Forms.TextBox()
        Me.TBaches = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.FBaches = New System.Windows.Forms.Button()
        Me.TLP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OPPremezclas = New System.Windows.Forms.RadioButton()
        Me.OPMayores = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FBachesPrem = New System.Windows.Forms.Button()
        Me.GBEtiqueta = New System.Windows.Forms.GroupBox()
        Me.BImpEtiq = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TNoCopias = New System.Windows.Forms.NumericUpDown()
        Me.ChEtiqueta = New System.Windows.Forms.CheckBox()
        Me.ChPlanta2 = New System.Windows.Forms.CheckBox()
        Me.GBReimprimir = New System.Windows.Forms.GroupBox()
        Me.BReimprimir = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TOPReimp = New System.Windows.Forms.TextBox()
        Me.DGConsumosMed = New System.Windows.Forms.DataGridView()
        Me.Cont2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bache = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGEntraBach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GBEtiqueta.SuspendLayout()
        CType(Me.TNoCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBReimprimir.SuspendLayout()
        CType(Me.DGConsumosMed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGEntraBach
        '
        Me.DGEntraBach.AllowUserToAddRows = False
        Me.DGEntraBach.AllowUserToDeleteRows = False
        Me.DGEntraBach.AllowUserToResizeRows = False
        Me.DGEntraBach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEntraBach.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodMat, Me.NomMat, Me.PesoMeta})
        Me.DGEntraBach.Location = New System.Drawing.Point(464, 51)
        Me.DGEntraBach.MultiSelect = False
        Me.DGEntraBach.Name = "DGEntraBach"
        Me.DGEntraBach.ReadOnly = True
        Me.DGEntraBach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEntraBach.Size = New System.Drawing.Size(312, 473)
        Me.DGEntraBach.TabIndex = 27
        '
        'CodMat
        '
        Me.CodMat.HeaderText = "Cod"
        Me.CodMat.Name = "CodMat"
        Me.CodMat.ReadOnly = True
        Me.CodMat.Width = 50
        '
        'NomMat
        '
        Me.NomMat.HeaderText = "Nombre"
        Me.NomMat.Name = "NomMat"
        Me.NomMat.ReadOnly = True
        Me.NomMat.Width = 140
        '
        'PesoMeta
        '
        Me.PesoMeta.HeaderText = "P.Meta"
        Me.PesoMeta.Name = "PesoMeta"
        Me.PesoMeta.ReadOnly = True
        Me.PesoMeta.Width = 60
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1213, 25)
        Me.ToolStrip2.TabIndex = 32
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.MaterialesToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1213, 24)
        Me.MenuStrip1.TabIndex = 33
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'MaterialesToolStripMenuItem
        '
        Me.MaterialesToolStripMenuItem.Image = CType(resources.GetObject("MaterialesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MaterialesToolStripMenuItem.Name = "MaterialesToolStripMenuItem"
        Me.MaterialesToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.MaterialesToolStripMenuItem.Text = "Materiales"
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
        'LInfo1
        '
        Me.LInfo1.Location = New System.Drawing.Point(51, 139)
        Me.LInfo1.Name = "LInfo1"
        Me.LInfo1.Size = New System.Drawing.Size(199, 47)
        Me.LInfo1.TabIndex = 34
        Me.LInfo1.Text = "Este Formulario se utiliza para agregar a los consumos un bache que no haya sido " &
    "reportado en forma automática. "
        Me.LInfo1.Visible = False
        '
        'LInfo2
        '
        Me.LInfo2.Location = New System.Drawing.Point(51, 186)
        Me.LInfo2.Name = "LInfo2"
        Me.LInfo2.Size = New System.Drawing.Size(206, 54)
        Me.LInfo2.TabIndex = 35
        Me.LInfo2.Text = "Si el bache reportó en forma automática al menos un ingrediente, debe salir y uti" &
    "lizar el formulario de Ingresar Ingrediente para los ingredientes restantes"
        Me.LInfo2.Visible = False
        '
        'TContador
        '
        Me.TContador.Location = New System.Drawing.Point(84, 247)
        Me.TContador.Name = "TContador"
        Me.TContador.Size = New System.Drawing.Size(100, 20)
        Me.TContador.TabIndex = 1
        Me.TContador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TContador.Visible = False
        '
        'TCodFor
        '
        Me.TCodFor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodFor.Location = New System.Drawing.Point(84, 299)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.ReadOnly = True
        Me.TCodFor.Size = New System.Drawing.Size(85, 21)
        Me.TCodFor.TabIndex = 37
        Me.TCodFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodForB
        '
        Me.TCodForB.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodForB.Location = New System.Drawing.Point(175, 299)
        Me.TCodForB.Name = "TCodForB"
        Me.TCodForB.ReadOnly = True
        Me.TCodForB.Size = New System.Drawing.Size(93, 21)
        Me.TCodForB.TabIndex = 38
        Me.TCodForB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNomFor
        '
        Me.TNomFor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNomFor.Location = New System.Drawing.Point(84, 325)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.ReadOnly = True
        Me.TNomFor.Size = New System.Drawing.Size(185, 21)
        Me.TNomFor.TabIndex = 39
        Me.TNomFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOPs
        '
        Me.TOPs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPs.Location = New System.Drawing.Point(84, 273)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.Size = New System.Drawing.Size(100, 21)
        Me.TOPs.TabIndex = 2
        Me.TOPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TPorc
        '
        Me.TPorc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPorc.Location = New System.Drawing.Point(86, 382)
        Me.TPorc.Name = "TPorc"
        Me.TPorc.ReadOnly = True
        Me.TPorc.Size = New System.Drawing.Size(100, 21)
        Me.TPorc.TabIndex = 41
        Me.TPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TPeso
        '
        Me.TPeso.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TPeso.Location = New System.Drawing.Point(86, 408)
        Me.TPeso.Name = "TPeso"
        Me.TPeso.ReadOnly = True
        Me.TPeso.Size = New System.Drawing.Size(100, 21)
        Me.TPeso.TabIndex = 42
        Me.TPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TFecha
        '
        Me.TFecha.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFecha.Location = New System.Drawing.Point(86, 434)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.ReadOnly = True
        Me.TFecha.Size = New System.Drawing.Size(164, 21)
        Me.TFecha.TabIndex = 43
        Me.TFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBaches
        '
        Me.TBaches.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBaches.Location = New System.Drawing.Point(86, 460)
        Me.TBaches.Name = "TBaches"
        Me.TBaches.Size = New System.Drawing.Size(100, 21)
        Me.TBaches.TabIndex = 44
        Me.TBaches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-2, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Consecutivo:"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 275)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 15)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "OP:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 301)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Fórmula:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 388)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "%Bache:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1, 410)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Peso Bache:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(34, 440)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Fecha:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 462)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 15)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Baches:"
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(242, 493)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 54
        Me.ToolTip1.SetToolTip(Me.BCancelar, "Cancelar")
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(202, 493)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 53
        Me.ToolTip1.SetToolTip(Me.BAceptar, "Aceptar")
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'FBaches
        '
        Me.FBaches.Location = New System.Drawing.Point(336, 425)
        Me.FBaches.Name = "FBaches"
        Me.FBaches.Size = New System.Drawing.Size(75, 23)
        Me.FBaches.TabIndex = 55
        Me.FBaches.Text = "FBaches"
        Me.FBaches.UseVisualStyleBackColor = True
        Me.FBaches.Visible = False
        '
        'TLP
        '
        Me.TLP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TLP.Location = New System.Drawing.Point(86, 352)
        Me.TLP.Name = "TLP"
        Me.TLP.ReadOnly = True
        Me.TLP.Size = New System.Drawing.Size(100, 21)
        Me.TLP.TabIndex = 56
        Me.TLP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 355)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Versión:"
        '
        'OPPremezclas
        '
        Me.OPPremezclas.AutoSize = True
        Me.OPPremezclas.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPPremezclas.Location = New System.Drawing.Point(12, 106)
        Me.OPPremezclas.Name = "OPPremezclas"
        Me.OPPremezclas.Size = New System.Drawing.Size(132, 27)
        Me.OPPremezclas.TabIndex = 58
        Me.OPPremezclas.TabStop = True
        Me.OPPremezclas.Text = "PREMEZCLAS"
        Me.OPPremezclas.UseVisualStyleBackColor = True
        '
        'OPMayores
        '
        Me.OPMayores.AutoSize = True
        Me.OPMayores.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPMayores.Location = New System.Drawing.Point(175, 106)
        Me.OPMayores.Name = "OPMayores"
        Me.OPMayores.Size = New System.Drawing.Size(159, 27)
        Me.OPMayores.TabIndex = 59
        Me.OPMayores.TabStop = True
        Me.OPMayores.Text = "MAYORES-SALES"
        Me.OPMayores.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(37, 52)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(255, 47)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "Seleccione el proceso al que desea " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ingresar baches manuales" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FBachesPrem
        '
        Me.FBachesPrem.Location = New System.Drawing.Point(304, 454)
        Me.FBachesPrem.Name = "FBachesPrem"
        Me.FBachesPrem.Size = New System.Drawing.Size(83, 23)
        Me.FBachesPrem.TabIndex = 61
        Me.FBachesPrem.Text = "FBachesPrem"
        Me.FBachesPrem.UseVisualStyleBackColor = True
        Me.FBachesPrem.Visible = False
        '
        'GBEtiqueta
        '
        Me.GBEtiqueta.Controls.Add(Me.BImpEtiq)
        Me.GBEtiqueta.Controls.Add(Me.Label29)
        Me.GBEtiqueta.Controls.Add(Me.TNoCopias)
        Me.GBEtiqueta.Enabled = False
        Me.GBEtiqueta.Location = New System.Drawing.Point(290, 238)
        Me.GBEtiqueta.Name = "GBEtiqueta"
        Me.GBEtiqueta.Size = New System.Drawing.Size(153, 94)
        Me.GBEtiqueta.TabIndex = 62
        Me.GBEtiqueta.TabStop = False
        Me.GBEtiqueta.Text = "Datos Etiqueta"
        Me.GBEtiqueta.Visible = False
        '
        'BImpEtiq
        '
        Me.BImpEtiq.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BImpEtiq.Image = CType(resources.GetObject("BImpEtiq.Image"), System.Drawing.Image)
        Me.BImpEtiq.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BImpEtiq.Location = New System.Drawing.Point(10, 41)
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
        Me.Label29.Location = New System.Drawing.Point(8, 21)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 13)
        Me.Label29.TabIndex = 167
        Me.Label29.Text = "Número de copias"
        '
        'TNoCopias
        '
        Me.TNoCopias.Location = New System.Drawing.Point(102, 19)
        Me.TNoCopias.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.TNoCopias.Name = "TNoCopias"
        Me.TNoCopias.Size = New System.Drawing.Size(46, 20)
        Me.TNoCopias.TabIndex = 166
        Me.TNoCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TNoCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ChEtiqueta
        '
        Me.ChEtiqueta.AutoSize = True
        Me.ChEtiqueta.Location = New System.Drawing.Point(190, 275)
        Me.ChEtiqueta.Name = "ChEtiqueta"
        Me.ChEtiqueta.Size = New System.Drawing.Size(103, 17)
        Me.ChEtiqueta.TabIndex = 63
        Me.ChEtiqueta.Text = "Imprimir Etiqueta"
        Me.ChEtiqueta.UseVisualStyleBackColor = True
        Me.ChEtiqueta.Visible = False
        '
        'ChPlanta2
        '
        Me.ChPlanta2.AutoSize = True
        Me.ChPlanta2.Location = New System.Drawing.Point(86, 501)
        Me.ChPlanta2.Name = "ChPlanta2"
        Me.ChPlanta2.Size = New System.Drawing.Size(95, 17)
        Me.ChPlanta2.TabIndex = 64
        Me.ChPlanta2.Text = "Planta Externa"
        Me.ChPlanta2.UseVisualStyleBackColor = True
        Me.ChPlanta2.Visible = False
        '
        'GBReimprimir
        '
        Me.GBReimprimir.Controls.Add(Me.BReimprimir)
        Me.GBReimprimir.Controls.Add(Me.Label11)
        Me.GBReimprimir.Controls.Add(Me.TOPReimp)
        Me.GBReimprimir.Controls.Add(Me.DGConsumosMed)
        Me.GBReimprimir.Enabled = False
        Me.GBReimprimir.Location = New System.Drawing.Point(793, 51)
        Me.GBReimprimir.Name = "GBReimprimir"
        Me.GBReimprimir.Size = New System.Drawing.Size(408, 472)
        Me.GBReimprimir.TabIndex = 65
        Me.GBReimprimir.TabStop = False
        Me.GBReimprimir.Text = "Reimprimir Etiquetas"
        '
        'BReimprimir
        '
        Me.BReimprimir.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BReimprimir.Image = CType(resources.GetObject("BReimprimir.Image"), System.Drawing.Image)
        Me.BReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BReimprimir.Location = New System.Drawing.Point(170, 353)
        Me.BReimprimir.Name = "BReimprimir"
        Me.BReimprimir.Size = New System.Drawing.Size(95, 33)
        Me.BReimprimir.TabIndex = 169
        Me.BReimprimir.Text = "Imprimir"
        Me.BReimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BReimprimir.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 361)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 15)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "OP:"
        '
        'TOPReimp
        '
        Me.TOPReimp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPReimp.Location = New System.Drawing.Point(41, 359)
        Me.TOPReimp.Name = "TOPReimp"
        Me.TOPReimp.Size = New System.Drawing.Size(100, 21)
        Me.TOPReimp.TabIndex = 63
        Me.TOPReimp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DGConsumosMed
        '
        Me.DGConsumosMed.AllowUserToAddRows = False
        Me.DGConsumosMed.AllowUserToDeleteRows = False
        Me.DGConsumosMed.AllowUserToResizeRows = False
        Me.DGConsumosMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGConsumosMed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cont2, Me.OP, Me.CodFor, Me.Bache})
        Me.DGConsumosMed.Location = New System.Drawing.Point(6, 19)
        Me.DGConsumosMed.Name = "DGConsumosMed"
        Me.DGConsumosMed.ReadOnly = True
        Me.DGConsumosMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGConsumosMed.Size = New System.Drawing.Size(378, 321)
        Me.DGConsumosMed.TabIndex = 29
        '
        'Cont2
        '
        Me.Cont2.HeaderText = "Cont"
        Me.Cont2.Name = "Cont2"
        Me.Cont2.ReadOnly = True
        Me.Cont2.Width = 150
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
        Me.CodFor.Width = 60
        '
        'Bache
        '
        Me.Bache.HeaderText = "Bache"
        Me.Bache.Name = "Bache"
        Me.Bache.ReadOnly = True
        Me.Bache.Width = 50
        '
        'EntraBache
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1213, 535)
        Me.Controls.Add(Me.GBReimprimir)
        Me.Controls.Add(Me.ChPlanta2)
        Me.Controls.Add(Me.ChEtiqueta)
        Me.Controls.Add(Me.GBEtiqueta)
        Me.Controls.Add(Me.FBachesPrem)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OPMayores)
        Me.Controls.Add(Me.OPPremezclas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TLP)
        Me.Controls.Add(Me.FBaches)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BAceptar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBaches)
        Me.Controls.Add(Me.TFecha)
        Me.Controls.Add(Me.TPeso)
        Me.Controls.Add(Me.TPorc)
        Me.Controls.Add(Me.TOPs)
        Me.Controls.Add(Me.TNomFor)
        Me.Controls.Add(Me.TCodForB)
        Me.Controls.Add(Me.TCodFor)
        Me.Controls.Add(Me.TContador)
        Me.Controls.Add(Me.LInfo2)
        Me.Controls.Add(Me.LInfo1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DGEntraBach)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EntraBache"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de baches manual"
        CType(Me.DGEntraBach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GBEtiqueta.ResumeLayout(False)
        Me.GBEtiqueta.PerformLayout()
        CType(Me.TNoCopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBReimprimir.ResumeLayout(False)
        Me.GBReimprimir.PerformLayout()
        CType(Me.DGConsumosMed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGEntraBach As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LInfo1 As System.Windows.Forms.Label
    Friend WithEvents LInfo2 As System.Windows.Forms.Label
    Friend WithEvents TContador As System.Windows.Forms.TextBox
    Friend WithEvents TCodFor As System.Windows.Forms.TextBox
    Friend WithEvents TCodForB As System.Windows.Forms.TextBox
    Friend WithEvents TNomFor As System.Windows.Forms.TextBox
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents TPorc As System.Windows.Forms.TextBox
    Friend WithEvents TPeso As System.Windows.Forms.TextBox
    Friend WithEvents TFecha As System.Windows.Forms.TextBox
    Friend WithEvents TBaches As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents FBaches As System.Windows.Forms.Button
    Friend WithEvents TLP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CodMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoMeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPPremezclas As System.Windows.Forms.RadioButton
    Friend WithEvents OPMayores As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FBachesPrem As System.Windows.Forms.Button
    Friend WithEvents GBEtiqueta As System.Windows.Forms.GroupBox
    Friend WithEvents BImpEtiq As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TNoCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChEtiqueta As System.Windows.Forms.CheckBox
    Friend WithEvents ChPlanta2 As System.Windows.Forms.CheckBox
    Friend WithEvents GBReimprimir As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TOPReimp As System.Windows.Forms.TextBox
    Friend WithEvents DGConsumosMed As System.Windows.Forms.DataGridView
    Friend WithEvents BReimprimir As System.Windows.Forms.Button
    Friend WithEvents Cont2 As DataGridViewTextBoxColumn
    Friend WithEvents OP As DataGridViewTextBoxColumn
    Friend WithEvents CodFor As DataGridViewTextBoxColumn
    Friend WithEvents Bache As DataGridViewTextBoxColumn
End Class
