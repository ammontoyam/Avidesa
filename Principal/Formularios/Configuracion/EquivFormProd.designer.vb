<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquivFormProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EquivFormProd))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.TabProductosDet = New System.Windows.Forms.TabControl()
        Me.ProductosEquiv = New System.Windows.Forms.TabPage()
        Me.DGEquivFormProd = New System.Windows.Forms.DataGridView()
        Me.DGEquivFormProd_CodProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGEquivFormProd_NomProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FRefrescaDGProd = New System.Windows.Forms.Button()
        Me.DGProd = New System.Windows.Forms.DataGridView()
        Me.DGProd_CodInt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGProd_Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TSOrgProg = New System.Windows.Forms.ToolStrip()
        Me.BAdicionaProd = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEliminaProd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.CBBuscarProd = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscarProd = New System.Windows.Forms.ToolStripTextBox()
        Me.DGFor = New System.Windows.Forms.DataGridView()
        Me.CodFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.TabProductosDet.SuspendLayout()
        Me.ProductosEquiv.SuspendLayout()
        CType(Me.DGEquivFormProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TSOrgProg.SuspendLayout()
        CType(Me.DGFor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BActualizar, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(912, 27)
        Me.ToolStrip1.TabIndex = 29
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BSalir
        '
        Me.BSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSalir.Image = CType(resources.GetObject("BSalir.Image"), System.Drawing.Image)
        Me.BSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(24, 24)
        Me.BSalir.Text = "Salir"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 27)
        '
        'BActualizar
        '
        Me.BActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BActualizar.Image = CType(resources.GetObject("BActualizar.Image"), System.Drawing.Image)
        Me.BActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BActualizar.Name = "BActualizar"
        Me.BActualizar.Size = New System.Drawing.Size(24, 24)
        Me.BActualizar.Text = "Actualizar"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(62, 24)
        Me.ToolStripLabel2.Text = "Buscar"
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBBuscar
        '
        Me.CBBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscar.DropDownWidth = 80
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(75, 27)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(80, 27)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'TabProductosDet
        '
        Me.TabProductosDet.Controls.Add(Me.ProductosEquiv)
        Me.TabProductosDet.Location = New System.Drawing.Point(10, 318)
        Me.TabProductosDet.Name = "TabProductosDet"
        Me.TabProductosDet.SelectedIndex = 0
        Me.TabProductosDet.Size = New System.Drawing.Size(888, 221)
        Me.TabProductosDet.TabIndex = 56
        '
        'ProductosEquiv
        '
        Me.ProductosEquiv.BackColor = System.Drawing.SystemColors.Control
        Me.ProductosEquiv.Controls.Add(Me.DGEquivFormProd)
        Me.ProductosEquiv.Controls.Add(Me.GroupBox3)
        Me.ProductosEquiv.Location = New System.Drawing.Point(4, 22)
        Me.ProductosEquiv.Name = "ProductosEquiv"
        Me.ProductosEquiv.Padding = New System.Windows.Forms.Padding(3)
        Me.ProductosEquiv.Size = New System.Drawing.Size(880, 195)
        Me.ProductosEquiv.TabIndex = 0
        Me.ProductosEquiv.Text = "Productos Equivalentes"
        '
        'DGEquivFormProd
        '
        Me.DGEquivFormProd.AllowUserToAddRows = False
        Me.DGEquivFormProd.AllowUserToDeleteRows = False
        Me.DGEquivFormProd.AllowUserToResizeRows = False
        Me.DGEquivFormProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGEquivFormProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGEquivFormProd_CodProd, Me.DGEquivFormProd_NomProd})
        Me.DGEquivFormProd.Location = New System.Drawing.Point(484, 9)
        Me.DGEquivFormProd.MultiSelect = False
        Me.DGEquivFormProd.Name = "DGEquivFormProd"
        Me.DGEquivFormProd.ReadOnly = True
        Me.DGEquivFormProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGEquivFormProd.Size = New System.Drawing.Size(343, 174)
        Me.DGEquivFormProd.TabIndex = 53
        '
        'DGEquivFormProd_CodProd
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DGEquivFormProd_CodProd.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGEquivFormProd_CodProd.HeaderText = "Código Producto"
        Me.DGEquivFormProd_CodProd.Name = "DGEquivFormProd_CodProd"
        Me.DGEquivFormProd_CodProd.ReadOnly = True
        Me.DGEquivFormProd_CodProd.Width = 120
        '
        'DGEquivFormProd_NomProd
        '
        Me.DGEquivFormProd_NomProd.HeaderText = "Nombre"
        Me.DGEquivFormProd_NomProd.Name = "DGEquivFormProd_NomProd"
        Me.DGEquivFormProd_NomProd.ReadOnly = True
        Me.DGEquivFormProd_NomProd.Width = 150
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.FRefrescaDGProd)
        Me.GroupBox3.Controls.Add(Me.DGProd)
        Me.GroupBox3.Controls.Add(Me.TSOrgProg)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(14, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(447, 180)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        '
        'FRefrescaDGProd
        '
        Me.FRefrescaDGProd.Location = New System.Drawing.Point(234, 96)
        Me.FRefrescaDGProd.Name = "FRefrescaDGProd"
        Me.FRefrescaDGProd.Size = New System.Drawing.Size(154, 23)
        Me.FRefrescaDGProd.TabIndex = 54
        Me.FRefrescaDGProd.Text = "FRefrescaDGProd"
        Me.FRefrescaDGProd.UseVisualStyleBackColor = True
        Me.FRefrescaDGProd.Visible = False
        '
        'DGProd
        '
        Me.DGProd.AllowUserToAddRows = False
        Me.DGProd.AllowUserToDeleteRows = False
        Me.DGProd.AllowUserToResizeRows = False
        Me.DGProd.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DGProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGProd_CodInt, Me.DGProd_Nombre})
        Me.DGProd.GridColor = System.Drawing.Color.Gray
        Me.DGProd.Location = New System.Drawing.Point(11, 50)
        Me.DGProd.MultiSelect = False
        Me.DGProd.Name = "DGProd"
        Me.DGProd.ReadOnly = True
        Me.DGProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGProd.Size = New System.Drawing.Size(408, 124)
        Me.DGProd.TabIndex = 54
        '
        'DGProd_CodInt
        '
        Me.DGProd_CodInt.HeaderText = "Código"
        Me.DGProd_CodInt.Name = "DGProd_CodInt"
        Me.DGProd_CodInt.ReadOnly = True
        '
        'DGProd_Nombre
        '
        Me.DGProd_Nombre.HeaderText = "Nombre"
        Me.DGProd_Nombre.Name = "DGProd_Nombre"
        Me.DGProd_Nombre.ReadOnly = True
        Me.DGProd_Nombre.Width = 250
        '
        'TSOrgProg
        '
        Me.TSOrgProg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BAdicionaProd, Me.ToolStripSeparator3, Me.BEliminaProd, Me.ToolStripSeparator18, Me.CBBuscarProd, Me.TBuscarProd})
        Me.TSOrgProg.Location = New System.Drawing.Point(3, 16)
        Me.TSOrgProg.Name = "TSOrgProg"
        Me.TSOrgProg.Size = New System.Drawing.Size(441, 25)
        Me.TSOrgProg.TabIndex = 53
        Me.TSOrgProg.Text = "ToolStrip2"
        '
        'BAdicionaProd
        '
        Me.BAdicionaProd.Image = CType(resources.GetObject("BAdicionaProd.Image"), System.Drawing.Image)
        Me.BAdicionaProd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BAdicionaProd.Name = "BAdicionaProd"
        Me.BAdicionaProd.Size = New System.Drawing.Size(16, 22)
        Me.BAdicionaProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BAdicionaProd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BAdicionaProd.ToolTipText = "Adicionar codigo de empaque"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BEliminaProd
        '
        Me.BEliminaProd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEliminaProd.Image = CType(resources.GetObject("BEliminaProd.Image"), System.Drawing.Image)
        Me.BEliminaProd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEliminaProd.Name = "BEliminaProd"
        Me.BEliminaProd.Size = New System.Drawing.Size(23, 22)
        Me.BEliminaProd.ToolTipText = "Eliminar código de empaque"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'CBBuscarProd
        '
        Me.CBBuscarProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscarProd.DropDownWidth = 80
        Me.CBBuscarProd.Name = "CBBuscarProd"
        Me.CBBuscarProd.Size = New System.Drawing.Size(75, 25)
        Me.CBBuscarProd.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscarProd
        '
        Me.TBuscarProd.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscarProd.Name = "TBuscarProd"
        Me.TBuscarProd.Size = New System.Drawing.Size(100, 25)
        '
        'DGFor
        '
        Me.DGFor.AllowUserToAddRows = False
        Me.DGFor.AllowUserToDeleteRows = False
        Me.DGFor.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGFor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGFor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGFor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodFor, Me.NomFor})
        Me.DGFor.Location = New System.Drawing.Point(14, 57)
        Me.DGFor.Name = "DGFor"
        Me.DGFor.ReadOnly = True
        Me.DGFor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGFor.Size = New System.Drawing.Size(468, 241)
        Me.DGFor.TabIndex = 57
        '
        'CodFor
        '
        Me.CodFor.HeaderText = "Cód. For"
        Me.CodFor.Name = "CodFor"
        Me.CodFor.ReadOnly = True
        '
        'NomFor
        '
        Me.NomFor.HeaderText = "Nombre"
        Me.NomFor.Name = "NomFor"
        Me.NomFor.ReadOnly = True
        Me.NomFor.Width = 300
        '
        'EquivFormProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 551)
        Me.Controls.Add(Me.DGFor)
        Me.Controls.Add(Me.TabProductosDet)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "EquivFormProd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tabla Equivalencias Fórmulas-Productos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabProductosDet.ResumeLayout(False)
        Me.ProductosEquiv.ResumeLayout(False)
        CType(Me.DGEquivFormProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TSOrgProg.ResumeLayout(False)
        Me.TSOrgProg.PerformLayout()
        CType(Me.DGFor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents CBBuscar As ToolStripComboBox
    Friend WithEvents TBuscar As ToolStripTextBox
    Friend WithEvents TabProductosDet As TabControl
    Friend WithEvents ProductosEquiv As TabPage
    Friend WithEvents DGEquivFormProd As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents FRefrescaDGProd As Button
    Friend WithEvents DGProd As DataGridView
    Friend WithEvents TSOrgProg As ToolStrip
    Friend WithEvents BAdicionaProd As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BEliminaProd As ToolStripButton
    Friend WithEvents ToolStripSeparator18 As ToolStripSeparator
    Friend WithEvents CBBuscarProd As ToolStripComboBox
    Friend WithEvents TBuscarProd As ToolStripTextBox
    Friend WithEvents DGFor As DataGridView
    Friend WithEvents DGProd_CodInt As DataGridViewTextBoxColumn
    Friend WithEvents DGProd_Nombre As DataGridViewTextBoxColumn
    Friend WithEvents CodFor As DataGridViewTextBoxColumn
    Friend WithEvents NomFor As DataGridViewTextBoxColumn
    Friend WithEvents DGEquivFormProd_CodProd As DataGridViewTextBoxColumn
    Friend WithEvents DGEquivFormProd_NomProd As DataGridViewTextBoxColumn
End Class
