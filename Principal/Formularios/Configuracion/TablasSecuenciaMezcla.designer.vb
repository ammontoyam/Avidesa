<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablasSecuenciaMezcla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TablasSecuenciaMezcla))
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
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMateriales = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaD = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TNombre = New System.Windows.Forms.TextBox()
        Me.TCodigo = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTraeDatos = New System.Windows.Forms.Button()
        Me.OpGrpFor = New System.Windows.Forms.RadioButton()
        Me.OpGrpMat = New System.Windows.Forms.RadioButton()
        Me.OpEspecies = New System.Windows.Forms.RadioButton()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.LDatosSel = New System.Windows.Forms.Label()
        Me.LSeleccion = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BPrimero, Me.ToolStripSeparator1, Me.BAnterior, Me.ToolStripSeparator2, Me.mnTCuenta, Me.ToolStripLabel1, Me.mnLCuenta, Me.ToolStripSeparator7, Me.BSiguiente, Me.ToolStripSeparator3, Me.BUltimo, Me.ToolStripSeparator4, Me.BEditar, Me.ToolStripSeparator8, Me.BNuevo, Me.ToolStripSeparator5, Me.BBorrar, Me.ToolStripSeparator6, Me.BActualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(608, 25)
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
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
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnMateriales, Me.mnOtros, Me.mnAcercaD})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(608, 24)
        Me.MenuStrip1.TabIndex = 30
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
        'mnMateriales
        '
        Me.mnMateriales.Image = CType(resources.GetObject("mnMateriales.Image"), System.Drawing.Image)
        Me.mnMateriales.Name = "mnMateriales"
        Me.mnMateriales.Size = New System.Drawing.Size(93, 20)
        Me.mnMateriales.Text = "Materiales"
        '
        'mnOtros
        '
        Me.mnOtros.Image = CType(resources.GetObject("mnOtros.Image"), System.Drawing.Image)
        Me.mnOtros.Name = "mnOtros"
        Me.mnOtros.Size = New System.Drawing.Size(66, 20)
        Me.mnOtros.Text = "Otros"
        '
        'mnAcercaD
        '
        Me.mnAcercaD.Image = CType(resources.GetObject("mnAcercaD.Image"), System.Drawing.Image)
        Me.mnAcercaD.Name = "mnAcercaD"
        Me.mnAcercaD.Size = New System.Drawing.Size(102, 20)
        Me.mnAcercaD.Text = "Acerca de...."
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TNombre)
        Me.Panel1.Controls.Add(Me.TCodigo)
        Me.Panel1.Controls.Add(Me.BCancelar)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Location = New System.Drawing.Point(28, 180)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(215, 152)
        Me.Panel1.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Nombre"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Código"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TNombre
        '
        Me.TNombre.Location = New System.Drawing.Point(3, 72)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.ReadOnly = True
        Me.TNombre.Size = New System.Drawing.Size(206, 20)
        Me.TNombre.TabIndex = 2
        '
        'TCodigo
        '
        Me.TCodigo.Location = New System.Drawing.Point(60, 24)
        Me.TCodigo.Name = "TCodigo"
        Me.TCodigo.ReadOnly = True
        Me.TCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TCodigo.TabIndex = 1
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(115, 111)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 11
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(54, 111)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 10
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTraeDatos)
        Me.GroupBox1.Controls.Add(Me.OpGrpFor)
        Me.GroupBox1.Controls.Add(Me.OpGrpMat)
        Me.GroupBox1.Controls.Add(Me.OpEspecies)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(28, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 75)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione una Opción "
        '
        'BTraeDatos
        '
        Me.BTraeDatos.Location = New System.Drawing.Point(167, 42)
        Me.BTraeDatos.Name = "BTraeDatos"
        Me.BTraeDatos.Size = New System.Drawing.Size(79, 23)
        Me.BTraeDatos.TabIndex = 3
        Me.BTraeDatos.Text = "BTraeDatos"
        Me.BTraeDatos.UseVisualStyleBackColor = True
        Me.BTraeDatos.Visible = False
        '
        'OpGrpFor
        '
        Me.OpGrpFor.AutoSize = True
        Me.OpGrpFor.Location = New System.Drawing.Point(7, 42)
        Me.OpGrpFor.Name = "OpGrpFor"
        Me.OpGrpFor.Size = New System.Drawing.Size(131, 18)
        Me.OpGrpFor.TabIndex = 2
        Me.OpGrpFor.Text = "Grupo de Fórmulas"
        Me.OpGrpFor.UseVisualStyleBackColor = True
        '
        'OpGrpMat
        '
        Me.OpGrpMat.AutoSize = True
        Me.OpGrpMat.Location = New System.Drawing.Point(107, 19)
        Me.OpGrpMat.Name = "OpGrpMat"
        Me.OpGrpMat.Size = New System.Drawing.Size(137, 18)
        Me.OpGrpMat.TabIndex = 1
        Me.OpGrpMat.Text = "Grupo de Materiales"
        Me.OpGrpMat.UseVisualStyleBackColor = True
        '
        'OpEspecies
        '
        Me.OpEspecies.AutoSize = True
        Me.OpEspecies.Checked = True
        Me.OpEspecies.Location = New System.Drawing.Point(7, 19)
        Me.OpEspecies.Name = "OpEspecies"
        Me.OpEspecies.Size = New System.Drawing.Size(75, 18)
        Me.OpEspecies.TabIndex = 0
        Me.OpEspecies.TabStop = True
        Me.OpEspecies.Text = "Especies"
        Me.OpEspecies.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AllowUserToResizeRows = False
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Location = New System.Drawing.Point(302, 86)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(294, 258)
        Me.DG.TabIndex = 32
        '
        'LDatosSel
        '
        Me.LDatosSel.AutoSize = True
        Me.LDatosSel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LDatosSel.ForeColor = System.Drawing.Color.Blue
        Me.LDatosSel.Location = New System.Drawing.Point(25, 164)
        Me.LDatosSel.Name = "LDatosSel"
        Me.LDatosSel.Size = New System.Drawing.Size(99, 15)
        Me.LDatosSel.TabIndex = 33
        Me.LDatosSel.Text = "Datos Selección"
        '
        'LSeleccion
        '
        Me.LSeleccion.AutoSize = True
        Me.LSeleccion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSeleccion.ForeColor = System.Drawing.Color.Teal
        Me.LSeleccion.Location = New System.Drawing.Point(347, 67)
        Me.LSeleccion.Name = "LSeleccion"
        Me.LSeleccion.Size = New System.Drawing.Size(71, 16)
        Me.LSeleccion.TabIndex = 34
        Me.LSeleccion.Text = "Selección"
        Me.LSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IngEspGrpForMat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 356)
        Me.Controls.Add(Me.LSeleccion)
        Me.Controls.Add(Me.LDatosSel)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IngEspGrpForMat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Especies, Grupo de Fórmulas y Grupo de Materiales"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents BEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnMateriales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TNombre As System.Windows.Forms.TextBox
    Friend WithEvents TCodigo As System.Windows.Forms.TextBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OpGrpFor As System.Windows.Forms.RadioButton
    Friend WithEvents OpGrpMat As System.Windows.Forms.RadioButton
    Friend WithEvents OpEspecies As System.Windows.Forms.RadioButton
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents BTraeDatos As System.Windows.Forms.Button
    Friend WithEvents LDatosSel As System.Windows.Forms.Label
    Friend WithEvents LSeleccion As System.Windows.Forms.Label
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
End Class
