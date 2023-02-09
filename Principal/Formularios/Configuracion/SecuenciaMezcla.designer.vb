<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SecuenciaMezcla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecuenciaMezcla))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BVerEspGrpForMat = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMateriales = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnFormulación = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaD = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabContCruz = New System.Windows.Forms.TabControl()
        Me.TabEspecie = New System.Windows.Forms.TabPage()
        Me.PEspecies = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BAdEspRes = New System.Windows.Forms.Button()
        Me.TNomEsp = New System.Windows.Forms.TextBox()
        Me.CEspecies = New System.Windows.Forms.ComboBox()
        Me.DGEspeciesRest = New System.Windows.Forms.DataGridView()
        Me.DGEsp_CodEspecie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEsp_NomEspecie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEspecies = New System.Windows.Forms.DataGridView()
        Me.CodEspecie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomEspecie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabGrpFor = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BAdGrpForRes = New System.Windows.Forms.Button()
        Me.TNomGrpFor = New System.Windows.Forms.TextBox()
        Me.CFormulas = New System.Windows.Forms.ComboBox()
        Me.DGGrpForRest = New System.Windows.Forms.DataGridView()
        Me.DGGrpFor_CodGrpFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGGrpFor_NomGrpFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGGrpFor = New System.Windows.Forms.DataGridView()
        Me.CodGrpFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomGrpFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabGrpMat = New System.Windows.Forms.TabPage()
        Me.PGrpMat = New System.Windows.Forms.Panel()
        Me.LSel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.OpEsp = New System.Windows.Forms.RadioButton()
        Me.OpGrpFor = New System.Windows.Forms.RadioButton()
        Me.OpGrpMat = New System.Windows.Forms.RadioButton()
        Me.BAdSel = New System.Windows.Forms.Button()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.CCodigo = New System.Windows.Forms.ComboBox()
        Me.DGGrpSelRes = New System.Windows.Forms.DataGridView()
        Me.DGGrpMat = New System.Windows.Forms.DataGridView()
        Me.CodGrpMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomGrpMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabContCruz.SuspendLayout()
        Me.TabEspecie.SuspendLayout()
        Me.PEspecies.SuspendLayout()
        CType(Me.DGEspeciesRest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGEspecies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGrpFor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGGrpForRest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGGrpFor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabGrpMat.SuspendLayout()
        Me.PGrpMat.SuspendLayout()
        CType(Me.DGGrpSelRes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGGrpMat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BVerEspGrpForMat, Me.ToolStripSeparator1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(769, 25)
        Me.ToolStrip2.TabIndex = 34
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
        'BVerEspGrpForMat
        '
        Me.BVerEspGrpForMat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BVerEspGrpForMat.Image = CType(resources.GetObject("BVerEspGrpForMat.Image"), System.Drawing.Image)
        Me.BVerEspGrpForMat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BVerEspGrpForMat.Name = "BVerEspGrpForMat"
        Me.BVerEspGrpForMat.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnArchivo, Me.mnMateriales, Me.mnOtros, Me.mnAcercaD})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(769, 24)
        Me.MenuStrip1.TabIndex = 35
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnArchivo
        '
        Me.mnArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSalir})
        Me.mnArchivo.Image = CType(resources.GetObject("mnArchivo.Image"), System.Drawing.Image)
        Me.mnArchivo.Name = "mnArchivo"
        Me.mnArchivo.Size = New System.Drawing.Size(77, 20)
        Me.mnArchivo.Text = "Archivo"
        '
        'mnSalir
        '
        Me.mnSalir.Name = "mnSalir"
        Me.mnSalir.Size = New System.Drawing.Size(98, 22)
        Me.mnSalir.Text = "&Salir"
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
        'mnAcercaD
        '
        Me.mnAcercaD.Image = CType(resources.GetObject("mnAcercaD.Image"), System.Drawing.Image)
        Me.mnAcercaD.Name = "mnAcercaD"
        Me.mnAcercaD.Size = New System.Drawing.Size(102, 20)
        Me.mnAcercaD.Text = "Acerca de...."
        '
        'TabContCruz
        '
        Me.TabContCruz.Controls.Add(Me.TabEspecie)
        Me.TabContCruz.Controls.Add(Me.TabGrpFor)
        Me.TabContCruz.Controls.Add(Me.TabGrpMat)
        Me.TabContCruz.ImageList = Me.ImageList1
        Me.TabContCruz.Location = New System.Drawing.Point(12, 52)
        Me.TabContCruz.Name = "TabContCruz"
        Me.TabContCruz.SelectedIndex = 0
        Me.TabContCruz.Size = New System.Drawing.Size(752, 367)
        Me.TabContCruz.TabIndex = 37
        '
        'TabEspecie
        '
        Me.TabEspecie.BackColor = System.Drawing.Color.White
        Me.TabEspecie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabEspecie.Controls.Add(Me.PEspecies)
        Me.TabEspecie.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabEspecie.ImageIndex = 0
        Me.TabEspecie.Location = New System.Drawing.Point(4, 23)
        Me.TabEspecie.Name = "TabEspecie"
        Me.TabEspecie.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEspecie.Size = New System.Drawing.Size(744, 340)
        Me.TabEspecie.TabIndex = 0
        Me.TabEspecie.Text = "Especies"
        '
        'PEspecies
        '
        Me.PEspecies.BackColor = System.Drawing.Color.LemonChiffon
        Me.PEspecies.Controls.Add(Me.Label3)
        Me.PEspecies.Controls.Add(Me.Label2)
        Me.PEspecies.Controls.Add(Me.Label1)
        Me.PEspecies.Controls.Add(Me.BAdEspRes)
        Me.PEspecies.Controls.Add(Me.TNomEsp)
        Me.PEspecies.Controls.Add(Me.CEspecies)
        Me.PEspecies.Controls.Add(Me.DGEspeciesRest)
        Me.PEspecies.Controls.Add(Me.DGEspecies)
        Me.PEspecies.Location = New System.Drawing.Point(6, 19)
        Me.PEspecies.Name = "PEspecies"
        Me.PEspecies.Size = New System.Drawing.Size(728, 313)
        Me.PEspecies.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(317, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 30)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Especies a Restringir"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(513, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 15)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Especies Restringidas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(73, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 15)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Listado de Especies"
        '
        'BAdEspRes
        '
        Me.BAdEspRes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAdEspRes.Image = CType(resources.GetObject("BAdEspRes.Image"), System.Drawing.Image)
        Me.BAdEspRes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BAdEspRes.Location = New System.Drawing.Point(320, 135)
        Me.BAdEspRes.Name = "BAdEspRes"
        Me.BAdEspRes.Size = New System.Drawing.Size(95, 38)
        Me.BAdEspRes.TabIndex = 37
        Me.BAdEspRes.Text = "Adicionar"
        Me.BAdEspRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAdEspRes.UseVisualStyleBackColor = True
        '
        'TNomEsp
        '
        Me.TNomEsp.Location = New System.Drawing.Point(306, 104)
        Me.TNomEsp.Name = "TNomEsp"
        Me.TNomEsp.Size = New System.Drawing.Size(119, 21)
        Me.TNomEsp.TabIndex = 36
        '
        'CEspecies
        '
        Me.CEspecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CEspecies.FormattingEnabled = True
        Me.CEspecies.Location = New System.Drawing.Point(307, 77)
        Me.CEspecies.Name = "CEspecies"
        Me.CEspecies.Size = New System.Drawing.Size(121, 23)
        Me.CEspecies.TabIndex = 35
        '
        'DGEspeciesRest
        '
        Me.DGEspeciesRest.AllowUserToAddRows = False
        Me.DGEspeciesRest.AllowUserToDeleteRows = False
        Me.DGEspeciesRest.AllowUserToResizeRows = False
        Me.DGEspeciesRest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGEspeciesRest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEspeciesRest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEsp_CodEspecie, Me.DGEsp_NomEspecie})
        Me.DGEspeciesRest.Location = New System.Drawing.Point(431, 39)
        Me.DGEspeciesRest.MultiSelect = False
        Me.DGEspeciesRest.Name = "DGEspeciesRest"
        Me.DGEspeciesRest.ReadOnly = True
        Me.DGEspeciesRest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEspeciesRest.Size = New System.Drawing.Size(294, 258)
        Me.DGEspeciesRest.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.DGEspeciesRest, "Suprimir para eliminar Restrinción")
        '
        'DGEsp_CodEspecie
        '
        Me.DGEsp_CodEspecie.FillWeight = 60.9137!
        Me.DGEsp_CodEspecie.HeaderText = "Código"
        Me.DGEsp_CodEspecie.Name = "DGEsp_CodEspecie"
        Me.DGEsp_CodEspecie.ReadOnly = True
        '
        'DGEsp_NomEspecie
        '
        Me.DGEsp_NomEspecie.FillWeight = 139.0863!
        Me.DGEsp_NomEspecie.HeaderText = "Nombre"
        Me.DGEsp_NomEspecie.Name = "DGEsp_NomEspecie"
        Me.DGEsp_NomEspecie.ReadOnly = True
        '
        'DGEspecies
        '
        Me.DGEspecies.AllowUserToAddRows = False
        Me.DGEspecies.AllowUserToDeleteRows = False
        Me.DGEspecies.AllowUserToResizeRows = False
        Me.DGEspecies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGEspecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEspecies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodEspecie, Me.NomEspecie})
        Me.DGEspecies.Location = New System.Drawing.Point(6, 39)
        Me.DGEspecies.MultiSelect = False
        Me.DGEspecies.Name = "DGEspecies"
        Me.DGEspecies.ReadOnly = True
        Me.DGEspecies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEspecies.Size = New System.Drawing.Size(294, 258)
        Me.DGEspecies.TabIndex = 33
        '
        'CodEspecie
        '
        Me.CodEspecie.FillWeight = 57.86803!
        Me.CodEspecie.HeaderText = "Codigo"
        Me.CodEspecie.Name = "CodEspecie"
        Me.CodEspecie.ReadOnly = True
        '
        'NomEspecie
        '
        Me.NomEspecie.FillWeight = 142.132!
        Me.NomEspecie.HeaderText = "Nombre"
        Me.NomEspecie.Name = "NomEspecie"
        Me.NomEspecie.ReadOnly = True
        '
        'TabGrpFor
        '
        Me.TabGrpFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabGrpFor.Controls.Add(Me.Panel1)
        Me.TabGrpFor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabGrpFor.ImageIndex = 1
        Me.TabGrpFor.Location = New System.Drawing.Point(4, 23)
        Me.TabGrpFor.Name = "TabGrpFor"
        Me.TabGrpFor.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGrpFor.Size = New System.Drawing.Size(744, 340)
        Me.TabGrpFor.TabIndex = 1
        Me.TabGrpFor.Text = "Grupo de Fórmulas"
        Me.TabGrpFor.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.BAdGrpForRes)
        Me.Panel1.Controls.Add(Me.TNomGrpFor)
        Me.Panel1.Controls.Add(Me.CFormulas)
        Me.Panel1.Controls.Add(Me.DGGrpForRest)
        Me.Panel1.Controls.Add(Me.DGGrpFor)
        Me.Panel1.Location = New System.Drawing.Point(8, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(728, 306)
        Me.Panel1.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(317, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 46)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Grupo de Fórmulas a Restringir"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(482, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(189, 15)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Grupo de Fórmulas Restringidas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(73, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Listado de Grupo de Fórmulas"
        '
        'BAdGrpForRes
        '
        Me.BAdGrpForRes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAdGrpForRes.Image = CType(resources.GetObject("BAdGrpForRes.Image"), System.Drawing.Image)
        Me.BAdGrpForRes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BAdGrpForRes.Location = New System.Drawing.Point(320, 131)
        Me.BAdGrpForRes.Name = "BAdGrpForRes"
        Me.BAdGrpForRes.Size = New System.Drawing.Size(95, 38)
        Me.BAdGrpForRes.TabIndex = 37
        Me.BAdGrpForRes.Text = "Adicionar"
        Me.BAdGrpForRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAdGrpForRes.UseVisualStyleBackColor = True
        '
        'TNomGrpFor
        '
        Me.TNomGrpFor.Location = New System.Drawing.Point(306, 100)
        Me.TNomGrpFor.Name = "TNomGrpFor"
        Me.TNomGrpFor.Size = New System.Drawing.Size(119, 21)
        Me.TNomGrpFor.TabIndex = 36
        '
        'CFormulas
        '
        Me.CFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CFormulas.FormattingEnabled = True
        Me.CFormulas.Location = New System.Drawing.Point(307, 73)
        Me.CFormulas.Name = "CFormulas"
        Me.CFormulas.Size = New System.Drawing.Size(121, 23)
        Me.CFormulas.TabIndex = 35
        '
        'DGGrpForRest
        '
        Me.DGGrpForRest.AllowUserToAddRows = False
        Me.DGGrpForRest.AllowUserToDeleteRows = False
        Me.DGGrpForRest.AllowUserToResizeRows = False
        Me.DGGrpForRest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGGrpForRest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGGrpForRest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGGrpFor_CodGrpFor, Me.DGGrpFor_NomGrpFor})
        Me.DGGrpForRest.Location = New System.Drawing.Point(431, 35)
        Me.DGGrpForRest.MultiSelect = False
        Me.DGGrpForRest.Name = "DGGrpForRest"
        Me.DGGrpForRest.ReadOnly = True
        Me.DGGrpForRest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGGrpForRest.Size = New System.Drawing.Size(294, 259)
        Me.DGGrpForRest.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.DGGrpForRest, "Suprimir para eliminar Restrinción")
        '
        'DGGrpFor_CodGrpFor
        '
        Me.DGGrpFor_CodGrpFor.FillWeight = 60.9137!
        Me.DGGrpFor_CodGrpFor.HeaderText = "Código"
        Me.DGGrpFor_CodGrpFor.Name = "DGGrpFor_CodGrpFor"
        Me.DGGrpFor_CodGrpFor.ReadOnly = True
        '
        'DGGrpFor_NomGrpFor
        '
        Me.DGGrpFor_NomGrpFor.FillWeight = 139.0863!
        Me.DGGrpFor_NomGrpFor.HeaderText = "Nombre"
        Me.DGGrpFor_NomGrpFor.Name = "DGGrpFor_NomGrpFor"
        Me.DGGrpFor_NomGrpFor.ReadOnly = True
        '
        'DGGrpFor
        '
        Me.DGGrpFor.AllowUserToAddRows = False
        Me.DGGrpFor.AllowUserToDeleteRows = False
        Me.DGGrpFor.AllowUserToResizeRows = False
        Me.DGGrpFor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGGrpFor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGGrpFor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodGrpFor, Me.NomGrpFor})
        Me.DGGrpFor.Location = New System.Drawing.Point(6, 35)
        Me.DGGrpFor.MultiSelect = False
        Me.DGGrpFor.Name = "DGGrpFor"
        Me.DGGrpFor.ReadOnly = True
        Me.DGGrpFor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGGrpFor.Size = New System.Drawing.Size(294, 259)
        Me.DGGrpFor.TabIndex = 33
        '
        'CodGrpFor
        '
        Me.CodGrpFor.FillWeight = 57.86803!
        Me.CodGrpFor.HeaderText = "Codigo"
        Me.CodGrpFor.Name = "CodGrpFor"
        Me.CodGrpFor.ReadOnly = True
        '
        'NomGrpFor
        '
        Me.NomGrpFor.FillWeight = 142.132!
        Me.NomGrpFor.HeaderText = "Nombre"
        Me.NomGrpFor.Name = "NomGrpFor"
        Me.NomGrpFor.ReadOnly = True
        '
        'TabGrpMat
        '
        Me.TabGrpMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabGrpMat.Controls.Add(Me.PGrpMat)
        Me.TabGrpMat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabGrpMat.ImageIndex = 2
        Me.TabGrpMat.Location = New System.Drawing.Point(4, 23)
        Me.TabGrpMat.Name = "TabGrpMat"
        Me.TabGrpMat.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGrpMat.Size = New System.Drawing.Size(744, 340)
        Me.TabGrpMat.TabIndex = 2
        Me.TabGrpMat.Text = "Grupo de Materiales"
        Me.TabGrpMat.UseVisualStyleBackColor = True
        '
        'PGrpMat
        '
        Me.PGrpMat.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.PGrpMat.Controls.Add(Me.LSel)
        Me.PGrpMat.Controls.Add(Me.Label8)
        Me.PGrpMat.Controls.Add(Me.Label7)
        Me.PGrpMat.Controls.Add(Me.OpEsp)
        Me.PGrpMat.Controls.Add(Me.OpGrpFor)
        Me.PGrpMat.Controls.Add(Me.OpGrpMat)
        Me.PGrpMat.Controls.Add(Me.BAdSel)
        Me.PGrpMat.Controls.Add(Me.TNombre)
        Me.PGrpMat.Controls.Add(Me.CCodigo)
        Me.PGrpMat.Controls.Add(Me.DGGrpSelRes)
        Me.PGrpMat.Controls.Add(Me.DGGrpMat)
        Me.PGrpMat.Location = New System.Drawing.Point(8, 22)
        Me.PGrpMat.Name = "PGrpMat"
        Me.PGrpMat.Size = New System.Drawing.Size(728, 310)
        Me.PGrpMat.TabIndex = 40
        '
        'LSel
        '
        Me.LSel.AutoSize = True
        Me.LSel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSel.Location = New System.Drawing.Point(471, 17)
        Me.LSel.Name = "LSel"
        Me.LSel.Size = New System.Drawing.Size(64, 15)
        Me.LSel.TabIndex = 45
        Me.LSel.Text = "Resultado"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(303, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 37)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Restricción a Aplicar"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 15)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Listado de Grupo  Materiales"
        '
        'OpEsp
        '
        Me.OpEsp.AutoSize = True
        Me.OpEsp.Location = New System.Drawing.Point(302, 107)
        Me.OpEsp.Name = "OpEsp"
        Me.OpEsp.Size = New System.Drawing.Size(77, 19)
        Me.OpEsp.TabIndex = 40
        Me.OpEsp.Text = "Especies"
        Me.OpEsp.UseVisualStyleBackColor = True
        '
        'OpGrpFor
        '
        Me.OpGrpFor.AutoSize = True
        Me.OpGrpFor.Location = New System.Drawing.Point(302, 82)
        Me.OpGrpFor.Name = "OpGrpFor"
        Me.OpGrpFor.Size = New System.Drawing.Size(115, 19)
        Me.OpGrpFor.TabIndex = 39
        Me.OpGrpFor.Text = "Grupo Fórmulas"
        Me.OpGrpFor.UseVisualStyleBackColor = True
        '
        'OpGrpMat
        '
        Me.OpGrpMat.AutoSize = True
        Me.OpGrpMat.Checked = True
        Me.OpGrpMat.Location = New System.Drawing.Point(302, 57)
        Me.OpGrpMat.Name = "OpGrpMat"
        Me.OpGrpMat.Size = New System.Drawing.Size(119, 19)
        Me.OpGrpMat.TabIndex = 38
        Me.OpGrpMat.TabStop = True
        Me.OpGrpMat.Text = "Grupo Materiales"
        Me.OpGrpMat.UseVisualStyleBackColor = True
        '
        'BAdSel
        '
        Me.BAdSel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAdSel.Image = CType(resources.GetObject("BAdSel.Image"), System.Drawing.Image)
        Me.BAdSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BAdSel.Location = New System.Drawing.Point(316, 199)
        Me.BAdSel.Name = "BAdSel"
        Me.BAdSel.Size = New System.Drawing.Size(95, 38)
        Me.BAdSel.TabIndex = 37
        Me.BAdSel.Text = "Adicionar"
        Me.BAdSel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAdSel.UseVisualStyleBackColor = True
        '
        'TNombre
        '
        Me.TNombre.Location = New System.Drawing.Point(302, 168)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(119, 21)
        Me.TNombre.TabIndex = 36
        '
        'CCodigo
        '
        Me.CCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CCodigo.FormattingEnabled = True
        Me.CCodigo.Location = New System.Drawing.Point(303, 141)
        Me.CCodigo.Name = "CCodigo"
        Me.CCodigo.Size = New System.Drawing.Size(121, 23)
        Me.CCodigo.TabIndex = 35
        '
        'DGGrpSelRes
        '
        Me.DGGrpSelRes.AllowUserToAddRows = False
        Me.DGGrpSelRes.AllowUserToDeleteRows = False
        Me.DGGrpSelRes.AllowUserToResizeRows = False
        Me.DGGrpSelRes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGGrpSelRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGGrpSelRes.Location = New System.Drawing.Point(427, 35)
        Me.DGGrpSelRes.MultiSelect = False
        Me.DGGrpSelRes.Name = "DGGrpSelRes"
        Me.DGGrpSelRes.ReadOnly = True
        Me.DGGrpSelRes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGGrpSelRes.Size = New System.Drawing.Size(294, 264)
        Me.DGGrpSelRes.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.DGGrpSelRes, "Suprimir para eliminar Restrinción")
        '
        'DGGrpMat
        '
        Me.DGGrpMat.AllowUserToAddRows = False
        Me.DGGrpMat.AllowUserToDeleteRows = False
        Me.DGGrpMat.AllowUserToResizeRows = False
        Me.DGGrpMat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGGrpMat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGGrpMat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodGrpMat, Me.NomGrpMat})
        Me.DGGrpMat.Location = New System.Drawing.Point(2, 35)
        Me.DGGrpMat.MultiSelect = False
        Me.DGGrpMat.Name = "DGGrpMat"
        Me.DGGrpMat.ReadOnly = True
        Me.DGGrpMat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGGrpMat.Size = New System.Drawing.Size(294, 264)
        Me.DGGrpMat.TabIndex = 33
        '
        'CodGrpMat
        '
        Me.CodGrpMat.FillWeight = 57.86803!
        Me.CodGrpMat.HeaderText = "Codigo"
        Me.CodGrpMat.Name = "CodGrpMat"
        Me.CodGrpMat.ReadOnly = True
        '
        'NomGrpMat
        '
        Me.NomGrpMat.FillWeight = 142.132!
        Me.NomGrpMat.HeaderText = "Nombre"
        Me.NomGrpMat.Name = "NomGrpMat"
        Me.NomGrpMat.ReadOnly = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Organizational Unit.ico")
        Me.ImageList1.Images.SetKeyName(1, "shape_align_middle.ico")
        Me.ImageList1.Images.SetKeyName(2, "images.ico")
        '
        'SecuenciaMezcla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 424)
        Me.Controls.Add(Me.TabContCruz)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SecuenciaMezcla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Secuencia de Mezcla"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabContCruz.ResumeLayout(False)
        Me.TabEspecie.ResumeLayout(False)
        Me.PEspecies.ResumeLayout(False)
        Me.PEspecies.PerformLayout()
        CType(Me.DGEspeciesRest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGEspecies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGrpFor.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGGrpForRest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGGrpFor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabGrpMat.ResumeLayout(False)
        Me.PGrpMat.ResumeLayout(False)
        Me.PGrpMat.PerformLayout()
        CType(Me.DGGrpSelRes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGGrpMat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnArchivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnMateriales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BVerEspGrpForMat As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabContCruz As System.Windows.Forms.TabControl
    Friend WithEvents TabEspecie As System.Windows.Forms.TabPage
    Friend WithEvents PEspecies As System.Windows.Forms.Panel
    Friend WithEvents BAdEspRes As System.Windows.Forms.Button
    Friend WithEvents TNomEsp As System.Windows.Forms.TextBox
    Friend WithEvents CEspecies As System.Windows.Forms.ComboBox
    Friend WithEvents DGEspeciesRest As System.Windows.Forms.DataGridView
    Friend WithEvents DGEspecies As System.Windows.Forms.DataGridView
    Friend WithEvents TabGrpFor As System.Windows.Forms.TabPage
    Friend WithEvents CodEspecie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomEspecie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEsp_CodEspecie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEsp_NomEspecie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BAdGrpForRes As System.Windows.Forms.Button
    Friend WithEvents TNomGrpFor As System.Windows.Forms.TextBox
    Friend WithEvents CFormulas As System.Windows.Forms.ComboBox
    Friend WithEvents DGGrpForRest As System.Windows.Forms.DataGridView
    Friend WithEvents DGGrpFor As System.Windows.Forms.DataGridView
    Friend WithEvents DGGrpFor_CodGrpFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGGrpFor_NomGrpFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodGrpFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomGrpFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabGrpMat As System.Windows.Forms.TabPage
    Friend WithEvents PGrpMat As System.Windows.Forms.Panel
    Friend WithEvents OpEsp As System.Windows.Forms.RadioButton
    Friend WithEvents OpGrpFor As System.Windows.Forms.RadioButton
    Friend WithEvents OpGrpMat As System.Windows.Forms.RadioButton
    Friend WithEvents BAdSel As System.Windows.Forms.Button
    Friend WithEvents TNombre As System.Windows.Forms.TextBox
    Friend WithEvents CCodigo As System.Windows.Forms.ComboBox
    Friend WithEvents DGGrpSelRes As System.Windows.Forms.DataGridView
    Friend WithEvents DGGrpMat As System.Windows.Forms.DataGridView
    Friend WithEvents CodGrpMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomGrpMat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LSel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnFormulación As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnReportes As System.Windows.Forms.ToolStripMenuItem
End Class
