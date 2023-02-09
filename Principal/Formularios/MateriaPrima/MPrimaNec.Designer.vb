<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MPrimaNec
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPrimaNec))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BSumAditivos = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TPesoPaqPrem = New System.Windows.Forms.TextBox()
        Me.TLP = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBaches = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TPrioridad = New System.Windows.Forms.TextBox()
        Me.TPorc = New System.Windows.Forms.TextBox()
        Me.TCodForB = New System.Windows.Forms.TextBox()
        Me.TCodFor = New System.Windows.Forms.ComboBox()
        Me.TNomFor = New System.Windows.Forms.ComboBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BElimTodo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnImp = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnImpProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnImpNecMP = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnImpPrem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.BExportMpNec = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGPrimaNec = New System.Windows.Forms.DataGridView()
        Me.CODFOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Baches = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prioridad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PesoPaqPrem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BCDate = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.TBaches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGPrimaNec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BSumAditivos)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TPesoPaqPrem)
        Me.Panel1.Controls.Add(Me.TLP)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TBaches)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BCancelar)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Controls.Add(Me.TPrioridad)
        Me.Panel1.Controls.Add(Me.TPorc)
        Me.Panel1.Controls.Add(Me.TCodForB)
        Me.Panel1.Controls.Add(Me.TCodFor)
        Me.Panel1.Controls.Add(Me.TNomFor)
        Me.Panel1.Location = New System.Drawing.Point(31, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 162)
        Me.Panel1.TabIndex = 2
        '
        'BSumAditivos
        '
        Me.BSumAditivos.Location = New System.Drawing.Point(213, 133)
        Me.BSumAditivos.Name = "BSumAditivos"
        Me.BSumAditivos.Size = New System.Drawing.Size(85, 23)
        Me.BSumAditivos.TabIndex = 7
        Me.BSumAditivos.Text = "BSumAditivos"
        Me.BSumAditivos.UseVisualStyleBackColor = True
        Me.BSumAditivos.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(134, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Peso Aditivos Bache:"
        '
        'TPesoPaqPrem
        '
        Me.TPesoPaqPrem.Location = New System.Drawing.Point(243, 85)
        Me.TPesoPaqPrem.Name = "TPesoPaqPrem"
        Me.TPesoPaqPrem.Size = New System.Drawing.Size(54, 20)
        Me.TPesoPaqPrem.TabIndex = 10
        '
        'TLP
        '
        Me.TLP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TLP.FormattingEnabled = True
        Me.TLP.Location = New System.Drawing.Point(69, 56)
        Me.TLP.Name = "TLP"
        Me.TLP.Size = New System.Drawing.Size(111, 21)
        Me.TLP.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "No. Orden"
        '
        'TBaches
        '
        Me.TBaches.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBaches.Location = New System.Drawing.Point(71, 83)
        Me.TBaches.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.TBaches.Name = "TBaches"
        Me.TBaches.Size = New System.Drawing.Size(54, 25)
        Me.TBaches.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Prioridad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Porcentaje"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Baches"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fórmula"
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(361, 123)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 15
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(321, 123)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 14
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'TPrioridad
        '
        Me.TPrioridad.Location = New System.Drawing.Point(71, 137)
        Me.TPrioridad.Name = "TPrioridad"
        Me.TPrioridad.Size = New System.Drawing.Size(54, 20)
        Me.TPrioridad.TabIndex = 13
        '
        'TPorc
        '
        Me.TPorc.Location = New System.Drawing.Point(71, 114)
        Me.TPorc.Name = "TPorc"
        Me.TPorc.Size = New System.Drawing.Size(54, 20)
        Me.TPorc.TabIndex = 12
        Me.TPorc.Text = "100"
        '
        'TCodForB
        '
        Me.TCodForB.Location = New System.Drawing.Point(188, 31)
        Me.TCodForB.Name = "TCodForB"
        Me.TCodForB.ReadOnly = True
        Me.TCodForB.Size = New System.Drawing.Size(100, 20)
        Me.TCodForB.TabIndex = 2
        '
        'TCodFor
        '
        Me.TCodFor.FormattingEnabled = True
        Me.TCodFor.Location = New System.Drawing.Point(71, 30)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.Size = New System.Drawing.Size(111, 21)
        Me.TCodFor.TabIndex = 9
        '
        'TNomFor
        '
        Me.TNomFor.FormattingEnabled = True
        Me.TNomFor.Location = New System.Drawing.Point(71, 3)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.Size = New System.Drawing.Size(250, 21)
        Me.TNomFor.TabIndex = 8
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator9, Me.BSalir, Me.ToolStripSeparator4, Me.BNuevo, Me.ToolStripSeparator5, Me.BBorrar, Me.ToolStripSeparator1, Me.BImportar, Me.ToolStripDropDownButton1, Me.BElimTodo, Me.ToolStripSeparator6, Me.mnImp, Me.ToolStripSeparator2, Me.BActualizar, Me.ToolStripSeparator10, Me.BExportMpNec})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(621, 25)
        Me.ToolStrip2.TabIndex = 1
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BImportar
        '
        Me.BImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImportar.Image = CType(resources.GetObject("BImportar.Image"), System.Drawing.Image)
        Me.BImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImportar.Name = "BImportar"
        Me.BImportar.Size = New System.Drawing.Size(23, 22)
        Me.BImportar.Text = "Importar programa de producción"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(6, 25)
        '
        'BElimTodo
        '
        Me.BElimTodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BElimTodo.Image = CType(resources.GetObject("BElimTodo.Image"), System.Drawing.Image)
        Me.BElimTodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BElimTodo.Name = "BElimTodo"
        Me.BElimTodo.Size = New System.Drawing.Size(23, 22)
        Me.BElimTodo.Text = "Borrar todo el programa"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'mnImp
        '
        Me.mnImp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnImpProg, Me.mnImpNecMP, Me.mnImpPrem})
        Me.mnImp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnImp.Image = CType(resources.GetObject("mnImp.Image"), System.Drawing.Image)
        Me.mnImp.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.mnImp.ImageTransparentColor = System.Drawing.Color.White
        Me.mnImp.Name = "mnImp"
        Me.mnImp.Size = New System.Drawing.Size(87, 22)
        Me.mnImp.Text = "Imprimir"
        Me.mnImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnImpProg
        '
        Me.mnImpProg.Image = CType(resources.GetObject("mnImpProg.Image"), System.Drawing.Image)
        Me.mnImpProg.Name = "mnImpProg"
        Me.mnImpProg.Size = New System.Drawing.Size(210, 22)
        Me.mnImpProg.Text = "Programa"
        '
        'mnImpNecMP
        '
        Me.mnImpNecMP.Image = CType(resources.GetObject("mnImpNecMP.Image"), System.Drawing.Image)
        Me.mnImpNecMP.Name = "mnImpNecMP"
        Me.mnImpNecMP.Size = New System.Drawing.Size(210, 22)
        Me.mnImpNecMP.Text = "Necesidad Materia Prima"
        '
        'mnImpPrem
        '
        Me.mnImpPrem.Image = CType(resources.GetObject("mnImpPrem.Image"), System.Drawing.Image)
        Me.mnImpPrem.Name = "mnImpPrem"
        Me.mnImpPrem.Size = New System.Drawing.Size(210, 22)
        Me.mnImpPrem.Text = "Necesidad Premezcla"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'BExportMpNec
        '
        Me.BExportMpNec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BExportMpNec.Enabled = False
        Me.BExportMpNec.Image = CType(resources.GetObject("BExportMpNec.Image"), System.Drawing.Image)
        Me.BExportMpNec.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BExportMpNec.Name = "BExportMpNec"
        Me.BExportMpNec.Size = New System.Drawing.Size(23, 22)
        Me.BExportMpNec.Text = "Exportar programa a Premezclas"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.MaterialesToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(621, 24)
        Me.MenuStrip1.TabIndex = 0
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
        'DGPrimaNec
        '
        Me.DGPrimaNec.AllowUserToAddRows = False
        Me.DGPrimaNec.AllowUserToDeleteRows = False
        Me.DGPrimaNec.AllowUserToResizeRows = False
        Me.DGPrimaNec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGPrimaNec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODFOR, Me.LP, Me.NomFor, Me.Baches, Me.Porc, Me.Prioridad, Me.PesoPaqPrem, Me.ID})
        Me.DGPrimaNec.Location = New System.Drawing.Point(31, 232)
        Me.DGPrimaNec.MultiSelect = False
        Me.DGPrimaNec.Name = "DGPrimaNec"
        Me.DGPrimaNec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGPrimaNec.Size = New System.Drawing.Size(575, 206)
        Me.DGPrimaNec.TabIndex = 34
        '
        'CODFOR
        '
        Me.CODFOR.HeaderText = "Código"
        Me.CODFOR.Name = "CODFOR"
        Me.CODFOR.ReadOnly = True
        Me.CODFOR.Width = 80
        '
        'LP
        '
        Me.LP.HeaderText = "Versión"
        Me.LP.Name = "LP"
        Me.LP.ReadOnly = True
        Me.LP.Width = 60
        '
        'NomFor
        '
        Me.NomFor.HeaderText = "Nombre"
        Me.NomFor.Name = "NomFor"
        Me.NomFor.ReadOnly = True
        Me.NomFor.Width = 160
        '
        'Baches
        '
        Me.Baches.HeaderText = "Baches"
        Me.Baches.Name = "Baches"
        Me.Baches.Width = 50
        '
        'Porc
        '
        Me.Porc.HeaderText = "Porc."
        Me.Porc.Name = "Porc"
        Me.Porc.ReadOnly = True
        Me.Porc.Width = 40
        '
        'Prioridad
        '
        Me.Prioridad.HeaderText = "Prioridad"
        Me.Prioridad.Name = "Prioridad"
        Me.Prioridad.ReadOnly = True
        Me.Prioridad.Width = 50
        '
        'PesoPaqPrem
        '
        Me.PesoPaqPrem.HeaderText = "PaqPrem (Kg)"
        Me.PesoPaqPrem.Name = "PesoPaqPrem"
        Me.PesoPaqPrem.Width = 80
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'BCDate
        '
        Me.BCDate.Location = New System.Drawing.Point(393, 91)
        Me.BCDate.Name = "BCDate"
        Me.BCDate.Size = New System.Drawing.Size(75, 23)
        Me.BCDate.TabIndex = 3
        Me.BCDate.Text = "BCDate"
        Me.BCDate.UseVisualStyleBackColor = True
        Me.BCDate.Visible = False
        '
        'MPrimaNec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 448)
        Me.Controls.Add(Me.BCDate)
        Me.Controls.Add(Me.DGPrimaNec)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MPrimaNec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Necesidad de Materia Prima"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TBaches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGPrimaNec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TPrioridad As System.Windows.Forms.TextBox
    Friend WithEvents TPorc As System.Windows.Forms.TextBox
    Friend WithEvents TCodForB As System.Windows.Forms.TextBox
    Friend WithEvents TCodFor As System.Windows.Forms.ComboBox
    Friend WithEvents TNomFor As System.Windows.Forms.ComboBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents TBaches As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGPrimaNec As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TLP As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnImp As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents mnImpProg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnImpNecMP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnImpPrem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BCDate As System.Windows.Forms.Button
    Friend WithEvents BImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BElimTodo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TPesoPaqPrem As System.Windows.Forms.TextBox
    Friend WithEvents BSumAditivos As System.Windows.Forms.Button
    Friend WithEvents CODFOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Baches As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Porc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prioridad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PesoPaqPrem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BExportMpNec As System.Windows.Forms.ToolStripButton
End Class
