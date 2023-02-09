<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificaEmpEtiq
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
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificaEmpEtiq))
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGEmp = New System.Windows.Forms.DataGridView()
        Me.DGEmp_CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEmp_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCantEmp = New System.Windows.Forms.TextBox()
        Me.BCancelarEmp = New System.Windows.Forms.Button()
        Me.BAdicionarEmp = New System.Windows.Forms.Button()
        Me.TNomEmp = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TCodEmp = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.DGListEmp = New System.Windows.Forms.DataGridView()
        Me.DGListEmp_Cont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGListEmp_OP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGListEmp_CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGListEmp_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGListEmp_Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGListEmp_CantTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TCantEtiq = New System.Windows.Forms.TextBox()
        Me.BCancelarEtiq = New System.Windows.Forms.Button()
        Me.BAdicionarEtiq = New System.Windows.Forms.Button()
        Me.TNomEtiq = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TCodEtiq = New System.Windows.Forms.TextBox()
        Me.DGEtiq = New System.Windows.Forms.DataGridView()
        Me.DGEtiq_CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEtiq_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TCont = New System.Windows.Forms.TextBox()
        CType(Me.DGEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGListEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGEtiq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGEmp
        '
        Me.DGEmp.AllowUserToAddRows = False
        Me.DGEmp.AllowUserToDeleteRows = False
        Me.DGEmp.AllowUserToResizeRows = False
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.DGEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEmp_CodInt, Me.DGEmp_Nombre})
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEmp.DefaultCellStyle = DataGridViewCellStyle29
        Me.DGEmp.Location = New System.Drawing.Point(7, 376)
        Me.DGEmp.MultiSelect = False
        Me.DGEmp.Name = "DGEmp"
        Me.DGEmp.ReadOnly = True
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEmp.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.DGEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEmp.Size = New System.Drawing.Size(372, 25)
        Me.DGEmp.TabIndex = 67
        Me.DGEmp.Visible = False
        '
        'DGEmp_CodInt
        '
        Me.DGEmp_CodInt.HeaderText = "Código"
        Me.DGEmp_CodInt.Name = "DGEmp_CodInt"
        Me.DGEmp_CodInt.ReadOnly = True
        Me.DGEmp_CodInt.Width = 60
        '
        'DGEmp_Nombre
        '
        Me.DGEmp_Nombre.HeaderText = "Nombre"
        Me.DGEmp_Nombre.Name = "DGEmp_Nombre"
        Me.DGEmp_Nombre.ReadOnly = True
        Me.DGEmp_Nombre.Width = 250
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label24.Location = New System.Drawing.Point(16, 358)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(132, 15)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Listado de empaques "
        Me.Label24.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.TCantEmp)
        Me.GroupBox5.Controls.Add(Me.BCancelarEmp)
        Me.GroupBox5.Controls.Add(Me.BAdicionarEmp)
        Me.GroupBox5.Controls.Add(Me.TNomEmp)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.TCodEmp)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox5.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(373, 83)
        Me.GroupBox5.TabIndex = 70
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Adicionar o Modificar Empaque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(146, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Cantidad"
        '
        'TCantEmp
        '
        Me.TCantEmp.Location = New System.Drawing.Point(206, 22)
        Me.TCantEmp.Name = "TCantEmp"
        Me.TCantEmp.Size = New System.Drawing.Size(62, 20)
        Me.TCantEmp.TabIndex = 31
        Me.TCantEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BCancelarEmp
        '
        Me.BCancelarEmp.Image = CType(resources.GetObject("BCancelarEmp.Image"), System.Drawing.Image)
        Me.BCancelarEmp.Location = New System.Drawing.Point(336, 13)
        Me.BCancelarEmp.Name = "BCancelarEmp"
        Me.BCancelarEmp.Size = New System.Drawing.Size(30, 26)
        Me.BCancelarEmp.TabIndex = 30
        Me.BCancelarEmp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BCancelarEmp.UseVisualStyleBackColor = True
        '
        'BAdicionarEmp
        '
        Me.BAdicionarEmp.Image = CType(resources.GetObject("BAdicionarEmp.Image"), System.Drawing.Image)
        Me.BAdicionarEmp.Location = New System.Drawing.Point(307, 13)
        Me.BAdicionarEmp.Name = "BAdicionarEmp"
        Me.BAdicionarEmp.Size = New System.Drawing.Size(30, 26)
        Me.BAdicionarEmp.TabIndex = 29
        Me.BAdicionarEmp.UseVisualStyleBackColor = True
        '
        'TNomEmp
        '
        Me.TNomEmp.Location = New System.Drawing.Point(12, 48)
        Me.TNomEmp.Name = "TNomEmp"
        Me.TNomEmp.ReadOnly = True
        Me.TNomEmp.Size = New System.Drawing.Size(256, 20)
        Me.TNomEmp.TabIndex = 24
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(9, 25)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(46, 14)
        Me.Label37.TabIndex = 14
        Me.Label37.Text = "Código"
        '
        'TCodEmp
        '
        Me.TCodEmp.Location = New System.Drawing.Point(61, 22)
        Me.TCodEmp.Name = "TCodEmp"
        Me.TCodEmp.ReadOnly = True
        Me.TCodEmp.Size = New System.Drawing.Size(62, 20)
        Me.TCodEmp.TabIndex = 1
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(478, 260)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 72
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(439, 260)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 71
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.BActualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(768, 25)
        Me.ToolStrip1.TabIndex = 73
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
        'BActualizar
        '
        Me.BActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActualizar.Image = CType(resources.GetObject("BActualizar.Image"), System.Drawing.Image)
        Me.BActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BActualizar.Name = "BActualizar"
        Me.BActualizar.Size = New System.Drawing.Size(23, 22)
        Me.BActualizar.Text = "Actualizar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(16, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 15)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Listado de empaques y etiquetas de la OP"
        '
        'TOPs
        '
        Me.TOPs.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TOPs.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOPs.ForeColor = System.Drawing.Color.Navy
        Me.TOPs.Location = New System.Drawing.Point(557, 179)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.ReadOnly = True
        Me.TOPs.Size = New System.Drawing.Size(100, 40)
        Me.TOPs.TabIndex = 75
        Me.TOPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DGListEmp
        '
        Me.DGListEmp.AllowUserToAddRows = False
        Me.DGListEmp.AllowUserToDeleteRows = False
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGListEmp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.DGListEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGListEmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGListEmp_Cont, Me.DGListEmp_OP, Me.DGListEmp_CodInt, Me.DGListEmp_Nombre, Me.DGListEmp_Tipo, Me.DGListEmp_CantTotal})
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGListEmp.DefaultCellStyle = DataGridViewCellStyle33
        Me.DGListEmp.Location = New System.Drawing.Point(18, 158)
        Me.DGListEmp.MultiSelect = False
        Me.DGListEmp.Name = "DGListEmp"
        Me.DGListEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGListEmp.Size = New System.Drawing.Size(495, 96)
        Me.DGListEmp.TabIndex = 76
        '
        'DGListEmp_Cont
        '
        Me.DGListEmp_Cont.HeaderText = "Cont"
        Me.DGListEmp_Cont.Name = "DGListEmp_Cont"
        Me.DGListEmp_Cont.Width = 80
        '
        'DGListEmp_OP
        '
        Me.DGListEmp_OP.HeaderText = "OP"
        Me.DGListEmp_OP.Name = "DGListEmp_OP"
        Me.DGListEmp_OP.Visible = False
        Me.DGListEmp_OP.Width = 60
        '
        'DGListEmp_CodInt
        '
        Me.DGListEmp_CodInt.HeaderText = "Código"
        Me.DGListEmp_CodInt.Name = "DGListEmp_CodInt"
        Me.DGListEmp_CodInt.Width = 60
        '
        'DGListEmp_Nombre
        '
        Me.DGListEmp_Nombre.HeaderText = "Nombre"
        Me.DGListEmp_Nombre.Name = "DGListEmp_Nombre"
        Me.DGListEmp_Nombre.Width = 200
        '
        'DGListEmp_Tipo
        '
        Me.DGListEmp_Tipo.HeaderText = "Tipo"
        Me.DGListEmp_Tipo.Name = "DGListEmp_Tipo"
        Me.DGListEmp_Tipo.Width = 40
        '
        'DGListEmp_CantTotal
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DGListEmp_CantTotal.DefaultCellStyle = DataGridViewCellStyle32
        Me.DGListEmp_CantTotal.HeaderText = "Cant"
        Me.DGListEmp_CantTotal.Name = "DGListEmp_CantTotal"
        Me.DGListEmp_CantTotal.Width = 60
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TCantEtiq)
        Me.GroupBox1.Controls.Add(Me.BCancelarEtiq)
        Me.GroupBox1.Controls.Add(Me.BAdicionarEtiq)
        Me.GroupBox1.Controls.Add(Me.TNomEtiq)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TCodEtiq)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(390, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 83)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Adicionar o Modificar Etiqueta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(146, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Cantidad"
        '
        'TCantEtiq
        '
        Me.TCantEtiq.Location = New System.Drawing.Point(206, 22)
        Me.TCantEtiq.Name = "TCantEtiq"
        Me.TCantEtiq.Size = New System.Drawing.Size(62, 20)
        Me.TCantEtiq.TabIndex = 33
        Me.TCantEtiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BCancelarEtiq
        '
        Me.BCancelarEtiq.Image = CType(resources.GetObject("BCancelarEtiq.Image"), System.Drawing.Image)
        Me.BCancelarEtiq.Location = New System.Drawing.Point(337, 13)
        Me.BCancelarEtiq.Name = "BCancelarEtiq"
        Me.BCancelarEtiq.Size = New System.Drawing.Size(30, 26)
        Me.BCancelarEtiq.TabIndex = 30
        Me.BCancelarEtiq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BCancelarEtiq.UseVisualStyleBackColor = True
        '
        'BAdicionarEtiq
        '
        Me.BAdicionarEtiq.Image = CType(resources.GetObject("BAdicionarEtiq.Image"), System.Drawing.Image)
        Me.BAdicionarEtiq.Location = New System.Drawing.Point(308, 13)
        Me.BAdicionarEtiq.Name = "BAdicionarEtiq"
        Me.BAdicionarEtiq.Size = New System.Drawing.Size(30, 26)
        Me.BAdicionarEtiq.TabIndex = 29
        Me.BAdicionarEtiq.UseVisualStyleBackColor = True
        '
        'TNomEtiq
        '
        Me.TNomEtiq.Location = New System.Drawing.Point(12, 48)
        Me.TNomEtiq.Name = "TNomEtiq"
        Me.TNomEtiq.ReadOnly = True
        Me.TNomEtiq.Size = New System.Drawing.Size(256, 20)
        Me.TNomEtiq.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Código"
        '
        'TCodEtiq
        '
        Me.TCodEtiq.Location = New System.Drawing.Point(61, 22)
        Me.TCodEtiq.Name = "TCodEtiq"
        Me.TCodEtiq.ReadOnly = True
        Me.TCodEtiq.Size = New System.Drawing.Size(62, 20)
        Me.TCodEtiq.TabIndex = 1
        '
        'DGEtiq
        '
        Me.DGEtiq.AllowUserToAddRows = False
        Me.DGEtiq.AllowUserToDeleteRows = False
        Me.DGEtiq.AllowUserToResizeRows = False
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEtiq.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.DGEtiq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEtiq.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEtiq_CodInt, Me.DGEtiq_Nombre})
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGEtiq.DefaultCellStyle = DataGridViewCellStyle35
        Me.DGEtiq.Location = New System.Drawing.Point(385, 376)
        Me.DGEtiq.MultiSelect = False
        Me.DGEtiq.Name = "DGEtiq"
        Me.DGEtiq.ReadOnly = True
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGEtiq.RowHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.DGEtiq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEtiq.Size = New System.Drawing.Size(372, 25)
        Me.DGEtiq.TabIndex = 77
        Me.DGEtiq.Visible = False
        '
        'DGEtiq_CodInt
        '
        Me.DGEtiq_CodInt.HeaderText = "Código"
        Me.DGEtiq_CodInt.Name = "DGEtiq_CodInt"
        Me.DGEtiq_CodInt.ReadOnly = True
        Me.DGEtiq_CodInt.Width = 60
        '
        'DGEtiq_Nombre
        '
        Me.DGEtiq_Nombre.HeaderText = "Nombre"
        Me.DGEtiq_Nombre.Name = "DGEtiq_Nombre"
        Me.DGEtiq_Nombre.ReadOnly = True
        Me.DGEtiq_Nombre.Width = 250
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label3.Location = New System.Drawing.Point(376, 358)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 15)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Listado de Etiquetas "
        Me.Label3.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(579, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 37)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "OP"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(561, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 22)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Contador"
        '
        'TCont
        '
        Me.TCont.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TCont.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCont.ForeColor = System.Drawing.Color.Navy
        Me.TCont.Location = New System.Drawing.Point(557, 247)
        Me.TCont.Name = "TCont"
        Me.TCont.ReadOnly = True
        Me.TCont.Size = New System.Drawing.Size(100, 26)
        Me.TCont.TabIndex = 81
        Me.TCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ModificaEmpEtiq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 305)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TCont)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGEtiq)
        Me.Controls.Add(Me.DGListEmp)
        Me.Controls.Add(Me.TOPs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BAceptar)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.DGEmp)
        Me.Controls.Add(Me.Label24)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModificaEmpEtiq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Empaques y Etiquetas"
        CType(Me.DGEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGListEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGEtiq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGEmp As System.Windows.Forms.DataGridView
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BCancelarEmp As System.Windows.Forms.Button
    Friend WithEvents BAdicionarEmp As System.Windows.Forms.Button
    Friend WithEvents TNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents DGListEmp As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BCancelarEtiq As System.Windows.Forms.Button
    Friend WithEvents BAdicionarEtiq As System.Windows.Forms.Button
    Friend WithEvents TNomEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TCodEtiq As System.Windows.Forms.TextBox
    Friend WithEvents DGEtiq As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TCantEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TCantEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DGEmp_CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEmp_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEtiq_CodInt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGEtiq_Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents Label7 As Label
    Friend WithEvents TCont As TextBox
    Friend WithEvents DGListEmp_Cont As DataGridViewTextBoxColumn
    Friend WithEvents DGListEmp_OP As DataGridViewTextBoxColumn
    Friend WithEvents DGListEmp_CodInt As DataGridViewTextBoxColumn
    Friend WithEvents DGListEmp_Nombre As DataGridViewTextBoxColumn
    Friend WithEvents DGListEmp_Tipo As DataGridViewTextBoxColumn
    Friend WithEvents DGListEmp_CantTotal As DataGridViewTextBoxColumn
End Class
