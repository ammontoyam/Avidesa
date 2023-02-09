<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiaMicrosOP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambiaMicrosOP))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGConsumosMed = New System.Windows.Forms.DataGridView()
        Me.Cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bache = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TBaches = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TRealMedDest = New System.Windows.Forms.TextBox()
        Me.TRealDest = New System.Windows.Forms.TextBox()
        Me.TMetaDest = New System.Windows.Forms.TextBox()
        Me.TNomForDest = New System.Windows.Forms.TextBox()
        Me.TLPDest = New System.Windows.Forms.TextBox()
        Me.TCodForDest = New System.Windows.Forms.TextBox()
        Me.TOPDest = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TRealMedOrig = New System.Windows.Forms.TextBox()
        Me.TRealOrig = New System.Windows.Forms.TextBox()
        Me.TMetaOrig = New System.Windows.Forms.TextBox()
        Me.TNomForOrig = New System.Windows.Forms.TextBox()
        Me.TLPOrig = New System.Windows.Forms.TextBox()
        Me.TCodForOrig = New System.Windows.Forms.TextBox()
        Me.TOPOrig = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TCodPremOrig = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TCodPremDest = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGConsumosMed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(844, 25)
        Me.ToolStrip1.TabIndex = 29
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnAcercaDe})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(844, 24)
        Me.MenuStrip1.TabIndex = 30
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
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'mnAcercaDe
        '
        Me.mnAcercaDe.Image = CType(resources.GetObject("mnAcercaDe.Image"), System.Drawing.Image)
        Me.mnAcercaDe.Name = "mnAcercaDe"
        Me.mnAcercaDe.Size = New System.Drawing.Size(102, 20)
        Me.mnAcercaDe.Text = "Acerca de...."
        '
        'DGConsumosMed
        '
        Me.DGConsumosMed.AllowUserToAddRows = False
        Me.DGConsumosMed.AllowUserToDeleteRows = False
        Me.DGConsumosMed.AllowUserToResizeRows = False
        Me.DGConsumosMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGConsumosMed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cont, Me.OP, Me.CodFor, Me.NomFor, Me.Bache})
        Me.DGConsumosMed.Location = New System.Drawing.Point(335, 52)
        Me.DGConsumosMed.Name = "DGConsumosMed"
        Me.DGConsumosMed.ReadOnly = True
        Me.DGConsumosMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGConsumosMed.Size = New System.Drawing.Size(494, 384)
        Me.DGConsumosMed.TabIndex = 28
        '
        'Cont
        '
        Me.Cont.HeaderText = "Cont"
        Me.Cont.Name = "Cont"
        Me.Cont.ReadOnly = True
        Me.Cont.Width = 60
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
        'NomFor
        '
        Me.NomFor.HeaderText = "Nombre"
        Me.NomFor.Name = "NomFor"
        Me.NomFor.ReadOnly = True
        Me.NomFor.Width = 200
        '
        'Bache
        '
        Me.Bache.HeaderText = "Bache"
        Me.Bache.Name = "Bache"
        Me.Bache.ReadOnly = True
        Me.Bache.Width = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BCancelar)
        Me.GroupBox1.Controls.Add(Me.BAceptar)
        Me.GroupBox1.Controls.Add(Me.TBaches)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(317, 275)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de OPs"
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(224, 231)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 13
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(183, 231)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 12
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'TBaches
        '
        Me.TBaches.Location = New System.Drawing.Point(127, 239)
        Me.TBaches.Name = "TBaches"
        Me.TBaches.ReadOnly = True
        Me.TBaches.Size = New System.Drawing.Size(34, 20)
        Me.TBaches.TabIndex = 3
        Me.TBaches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, 240)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Baches a Trasladar:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.TCodPremDest)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.TRealMedDest)
        Me.GroupBox3.Controls.Add(Me.TRealDest)
        Me.GroupBox3.Controls.Add(Me.TMetaDest)
        Me.GroupBox3.Controls.Add(Me.TNomForDest)
        Me.GroupBox3.Controls.Add(Me.TLPDest)
        Me.GroupBox3.Controls.Add(Me.TCodForDest)
        Me.GroupBox3.Controls.Add(Me.TOPDest)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 95)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OP Destino"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(148, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Orden:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(266, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 9)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "MICROS"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(235, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 9)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "REAL"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(196, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 9)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "META"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(148, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Baches:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Form:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "OP:"
        '
        'TRealMedDest
        '
        Me.TRealMedDest.Location = New System.Drawing.Point(267, 23)
        Me.TRealMedDest.Name = "TRealMedDest"
        Me.TRealMedDest.ReadOnly = True
        Me.TRealMedDest.Size = New System.Drawing.Size(32, 20)
        Me.TRealMedDest.TabIndex = 6
        Me.TRealMedDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TRealDest
        '
        Me.TRealDest.Location = New System.Drawing.Point(229, 23)
        Me.TRealDest.Name = "TRealDest"
        Me.TRealDest.ReadOnly = True
        Me.TRealDest.Size = New System.Drawing.Size(32, 20)
        Me.TRealDest.TabIndex = 5
        Me.TRealDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaDest
        '
        Me.TMetaDest.Location = New System.Drawing.Point(195, 23)
        Me.TMetaDest.Name = "TMetaDest"
        Me.TMetaDest.ReadOnly = True
        Me.TMetaDest.Size = New System.Drawing.Size(28, 20)
        Me.TMetaDest.TabIndex = 4
        Me.TMetaDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNomForDest
        '
        Me.TNomForDest.Location = New System.Drawing.Point(7, 69)
        Me.TNomForDest.Name = "TNomForDest"
        Me.TNomForDest.ReadOnly = True
        Me.TNomForDest.Size = New System.Drawing.Size(163, 20)
        Me.TNomForDest.TabIndex = 3
        Me.TNomForDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TLPDest
        '
        Me.TLPDest.Location = New System.Drawing.Point(195, 45)
        Me.TLPDest.Name = "TLPDest"
        Me.TLPDest.ReadOnly = True
        Me.TLPDest.Size = New System.Drawing.Size(89, 20)
        Me.TLPDest.TabIndex = 2
        Me.TLPDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodForDest
        '
        Me.TCodForDest.Location = New System.Drawing.Point(42, 45)
        Me.TCodForDest.Name = "TCodForDest"
        Me.TCodForDest.ReadOnly = True
        Me.TCodForDest.Size = New System.Drawing.Size(100, 20)
        Me.TCodForDest.TabIndex = 1
        Me.TCodForDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOPDest
        '
        Me.TOPDest.Location = New System.Drawing.Point(42, 19)
        Me.TOPDest.Name = "TOPDest"
        Me.TOPDest.Size = New System.Drawing.Size(100, 20)
        Me.TOPDest.TabIndex = 0
        Me.TOPDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TCodPremOrig)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TRealMedOrig)
        Me.GroupBox2.Controls.Add(Me.TRealOrig)
        Me.GroupBox2.Controls.Add(Me.TMetaOrig)
        Me.GroupBox2.Controls.Add(Me.TNomForOrig)
        Me.GroupBox2.Controls.Add(Me.TLPOrig)
        Me.GroupBox2.Controls.Add(Me.TCodForOrig)
        Me.GroupBox2.Controls.Add(Me.TOPOrig)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 95)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OP Origen"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(148, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Orden:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(266, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 9)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "MICROS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(235, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 9)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "REAL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(196, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 9)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "META"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(148, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Baches:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Form:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "OP:"
        '
        'TRealMedOrig
        '
        Me.TRealMedOrig.Location = New System.Drawing.Point(267, 23)
        Me.TRealMedOrig.Name = "TRealMedOrig"
        Me.TRealMedOrig.ReadOnly = True
        Me.TRealMedOrig.Size = New System.Drawing.Size(32, 20)
        Me.TRealMedOrig.TabIndex = 6
        Me.TRealMedOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TRealOrig
        '
        Me.TRealOrig.Location = New System.Drawing.Point(229, 23)
        Me.TRealOrig.Name = "TRealOrig"
        Me.TRealOrig.ReadOnly = True
        Me.TRealOrig.Size = New System.Drawing.Size(32, 20)
        Me.TRealOrig.TabIndex = 5
        Me.TRealOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaOrig
        '
        Me.TMetaOrig.Location = New System.Drawing.Point(195, 23)
        Me.TMetaOrig.Name = "TMetaOrig"
        Me.TMetaOrig.ReadOnly = True
        Me.TMetaOrig.Size = New System.Drawing.Size(28, 20)
        Me.TMetaOrig.TabIndex = 4
        Me.TMetaOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNomForOrig
        '
        Me.TNomForOrig.Location = New System.Drawing.Point(6, 69)
        Me.TNomForOrig.Name = "TNomForOrig"
        Me.TNomForOrig.ReadOnly = True
        Me.TNomForOrig.Size = New System.Drawing.Size(163, 20)
        Me.TNomForOrig.TabIndex = 3
        Me.TNomForOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TLPOrig
        '
        Me.TLPOrig.Location = New System.Drawing.Point(195, 45)
        Me.TLPOrig.Name = "TLPOrig"
        Me.TLPOrig.ReadOnly = True
        Me.TLPOrig.Size = New System.Drawing.Size(89, 20)
        Me.TLPOrig.TabIndex = 2
        Me.TLPOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodForOrig
        '
        Me.TCodForOrig.Location = New System.Drawing.Point(42, 45)
        Me.TCodForOrig.Name = "TCodForOrig"
        Me.TCodForOrig.ReadOnly = True
        Me.TCodForOrig.Size = New System.Drawing.Size(100, 20)
        Me.TCodForOrig.TabIndex = 1
        Me.TCodForOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOPOrig
        '
        Me.TOPOrig.Location = New System.Drawing.Point(42, 19)
        Me.TOPOrig.Name = "TOPOrig"
        Me.TOPOrig.Size = New System.Drawing.Size(100, 20)
        Me.TOPOrig.TabIndex = 0
        Me.TOPOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(12, 333)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(305, 87)
        Me.Button1.TabIndex = 61
        Me.Button1.Text = "En la tabla se muestran los baches disponibles" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para traslado, se trasladaran sol" &
    "o los baches seleccionados"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(174, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Prem:"
        '
        'TCodPremOrig
        '
        Me.TCodPremOrig.Location = New System.Drawing.Point(216, 69)
        Me.TCodPremOrig.Name = "TCodPremOrig"
        Me.TCodPremOrig.ReadOnly = True
        Me.TCodPremOrig.Size = New System.Drawing.Size(89, 20)
        Me.TCodPremOrig.TabIndex = 14
        Me.TCodPremOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(170, 72)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Prem:"
        '
        'TCodPremDest
        '
        Me.TCodPremDest.Location = New System.Drawing.Point(212, 69)
        Me.TCodPremDest.Name = "TCodPremDest"
        Me.TCodPremDest.ReadOnly = True
        Me.TCodPremDest.Size = New System.Drawing.Size(89, 20)
        Me.TCodPremDest.TabIndex = 16
        Me.TCodPremDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CambiaMicrosOP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 446)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DGConsumosMed)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambiaMicrosOP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de Micros por OPs"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGConsumosMed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGConsumosMed As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TRealMedOrig As System.Windows.Forms.TextBox
    Friend WithEvents TRealOrig As System.Windows.Forms.TextBox
    Friend WithEvents TMetaOrig As System.Windows.Forms.TextBox
    Friend WithEvents TNomForOrig As System.Windows.Forms.TextBox
    Friend WithEvents TLPOrig As System.Windows.Forms.TextBox
    Friend WithEvents TCodForOrig As System.Windows.Forms.TextBox
    Friend WithEvents TOPOrig As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TRealMedDest As System.Windows.Forms.TextBox
    Friend WithEvents TRealDest As System.Windows.Forms.TextBox
    Friend WithEvents TMetaDest As System.Windows.Forms.TextBox
    Friend WithEvents TNomForDest As System.Windows.Forms.TextBox
    Friend WithEvents TLPDest As System.Windows.Forms.TextBox
    Friend WithEvents TCodForDest As System.Windows.Forms.TextBox
    Friend WithEvents TOPDest As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TBaches As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Cont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bache As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label17 As Label
    Friend WithEvents TCodPremDest As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TCodPremOrig As TextBox
End Class
