<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CortesContBascula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CortesContBascula))
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
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CBBuscar = New System.Windows.Forms.ToolStripComboBox()
        Me.TBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.BImpTodos = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaterialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FImport = New System.Windows.Forms.Button()
        Me.FRefrescaDG = New System.Windows.Forms.Button()
        Me.TimSeg = New System.Windows.Forms.Timer(Me.components)
        Me.DGCortesNept = New System.Windows.Forms.DataGridView()
        Me.cnsctvo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.artclo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.klos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cntdad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lteorgen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cncpto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.td_rowid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGCortesNept, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BPrimero, Me.ToolStripSeparator1, Me.BAnterior, Me.ToolStripSeparator2, Me.mnTCuenta, Me.ToolStripLabel1, Me.mnLCuenta, Me.ToolStripSeparator7, Me.BSiguiente, Me.ToolStripSeparator3, Me.BUltimo, Me.ToolStripSeparator4, Me.BActualizar, Me.ToolStripSeparator10, Me.ToolStripLabel2, Me.CBBuscar, Me.TBuscar, Me.BImpTodos})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(821, 25)
        Me.ToolStrip1.TabIndex = 30
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
        Me.mnTCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
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
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBBuscar
        '
        Me.CBBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBBuscar.DropDownWidth = 80
        Me.CBBuscar.Name = "CBBuscar"
        Me.CBBuscar.Size = New System.Drawing.Size(90, 25)
        Me.CBBuscar.ToolTipText = "Seleccione el campo a buscar"
        '
        'TBuscar
        '
        Me.TBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TBuscar.Name = "TBuscar"
        Me.TBuscar.Size = New System.Drawing.Size(80, 25)
        Me.TBuscar.ToolTipText = "Digite el valor a consultar"
        '
        'BImpTodos
        '
        Me.BImpTodos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImpTodos.Image = CType(resources.GetObject("BImpTodos.Image"), System.Drawing.Image)
        Me.BImpTodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImpTodos.Name = "BImpTodos"
        Me.BImpTodos.Size = New System.Drawing.Size(23, 22)
        Me.BImpTodos.ToolTipText = "Importar todos los lotes"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.MaterialesToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(821, 24)
        Me.MenuStrip1.TabIndex = 31
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
        'FImport
        '
        Me.FImport.Location = New System.Drawing.Point(429, 224)
        Me.FImport.Name = "FImport"
        Me.FImport.Size = New System.Drawing.Size(92, 23)
        Me.FImport.TabIndex = 52
        Me.FImport.Text = "FImport"
        Me.FImport.UseVisualStyleBackColor = True
        Me.FImport.Visible = False
        '
        'FRefrescaDG
        '
        Me.FRefrescaDG.Location = New System.Drawing.Point(429, 195)
        Me.FRefrescaDG.Name = "FRefrescaDG"
        Me.FRefrescaDG.Size = New System.Drawing.Size(92, 23)
        Me.FRefrescaDG.TabIndex = 40
        Me.FRefrescaDG.Text = "FRefrescaDG"
        Me.FRefrescaDG.UseVisualStyleBackColor = True
        Me.FRefrescaDG.Visible = False
        '
        'TimSeg
        '
        Me.TimSeg.Enabled = True
        Me.TimSeg.Interval = 1000
        '
        'DGCortesNept
        '
        Me.DGCortesNept.AllowUserToAddRows = False
        Me.DGCortesNept.AllowUserToDeleteRows = False
        Me.DGCortesNept.AllowUserToResizeRows = False
        Me.DGCortesNept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCortesNept.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cnsctvo, Me.plca, Me.artclo, Me.klos, Me.cntdad, Me.lte, Me.lteorgen, Me.cncpto, Me.td_rowid})
        Me.DGCortesNept.Location = New System.Drawing.Point(12, 71)
        Me.DGCortesNept.MultiSelect = False
        Me.DGCortesNept.Name = "DGCortesNept"
        Me.DGCortesNept.ReadOnly = True
        Me.DGCortesNept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGCortesNept.Size = New System.Drawing.Size(795, 387)
        Me.DGCortesNept.TabIndex = 41
        '
        'cnsctvo
        '
        Me.cnsctvo.HeaderText = "Consecutivo"
        Me.cnsctvo.Name = "cnsctvo"
        Me.cnsctvo.ReadOnly = True
        Me.cnsctvo.Width = 80
        '
        'plca
        '
        Me.plca.HeaderText = "Placa"
        Me.plca.Name = "plca"
        Me.plca.ReadOnly = True
        '
        'artclo
        '
        Me.artclo.HeaderText = "Código"
        Me.artclo.Name = "artclo"
        Me.artclo.ReadOnly = True
        '
        'klos
        '
        Me.klos.HeaderText = "Cantidad"
        Me.klos.Name = "klos"
        Me.klos.ReadOnly = True
        Me.klos.Width = 80
        '
        'cntdad
        '
        Me.cntdad.HeaderText = "Sacos"
        Me.cntdad.Name = "cntdad"
        Me.cntdad.ReadOnly = True
        '
        'lte
        '
        Me.lte.HeaderText = "LoteDest"
        Me.lte.Name = "lte"
        Me.lte.ReadOnly = True
        '
        'lteorgen
        '
        Me.lteorgen.HeaderText = "LoteOrig"
        Me.lteorgen.Name = "lteorgen"
        Me.lteorgen.ReadOnly = True
        '
        'cncpto
        '
        Me.cncpto.HeaderText = "Concepto"
        Me.cncpto.Name = "cncpto"
        Me.cncpto.ReadOnly = True
        Me.cncpto.Width = 70
        '
        'td_rowid
        '
        Me.td_rowid.HeaderText = "ID"
        Me.td_rowid.Name = "td_rowid"
        Me.td_rowid.ReadOnly = True
        Me.td_rowid.Visible = False
        '
        'CortesContBascula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 470)
        Me.Controls.Add(Me.FRefrescaDG)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.FImport)
        Me.Controls.Add(Me.DGCortesNept)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CortesContBascula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conexión Control Báscula"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGCortesNept, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents CBBuscar As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaterialesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FRefrescaDG As System.Windows.Forms.Button
    Friend WithEvents TimSeg As System.Windows.Forms.Timer
    Friend WithEvents FImport As System.Windows.Forms.Button
    Friend WithEvents BImpTodos As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGCortesNept As DataGridView
    Friend WithEvents cnsctvo As DataGridViewTextBoxColumn
    Friend WithEvents plca As DataGridViewTextBoxColumn
    Friend WithEvents artclo As DataGridViewTextBoxColumn
    Friend WithEvents klos As DataGridViewTextBoxColumn
    Friend WithEvents cntdad As DataGridViewTextBoxColumn
    Friend WithEvents lte As DataGridViewTextBoxColumn
    Friend WithEvents lteorgen As DataGridViewTextBoxColumn
    Friend WithEvents cncpto As DataGridViewTextBoxColumn
    Friend WithEvents td_rowid As DataGridViewTextBoxColumn
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
End Class
