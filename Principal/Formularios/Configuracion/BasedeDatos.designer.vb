<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasedeDatos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BasedeDatos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.OpBorrado = New System.Windows.Forms.RadioButton()
        Me.OpSeleccion = New System.Windows.Forms.RadioButton()
        Me.TabBD = New System.Windows.Forms.TabControl()
        Me.Seleccion = New System.Windows.Forms.TabPage()
        Me.PanBorrar = New System.Windows.Forms.Panel()
        Me.PanSel = New System.Windows.Forms.Panel()
        Me.OpNuevaConsulta = New System.Windows.Forms.CheckBox()
        Me.BConsultar = New System.Windows.Forms.Button()
        Me.TOrden = New System.Windows.Forms.TextBox()
        Me.TCondicion = New System.Windows.Forms.TextBox()
        Me.TCampos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TTabla = New System.Windows.Forms.ComboBox()
        Me.BEjecutar = New System.Windows.Forms.Button()
        Me.TSentencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BTraeTablas = New System.Windows.Forms.Button()
        Me.DGDataBase = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TNoRegistros = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAcercaD = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnBBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnBGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnBCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1.SuspendLayout()
        Me.TabBD.SuspendLayout()
        Me.Seleccion.SuspendLayout()
        Me.PanBorrar.SuspendLayout()
        Me.PanSel.SuspendLayout()
        CType(Me.DGDataBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.OpBorrado)
        Me.GroupBox1.Controls.Add(Me.OpSeleccion)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(145, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Operación"
        '
        'OpBorrado
        '
        Me.OpBorrado.AutoSize = True
        Me.OpBorrado.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.OpBorrado.Location = New System.Drawing.Point(33, 42)
        Me.OpBorrado.Name = "OpBorrado"
        Me.OpBorrado.Size = New System.Drawing.Size(95, 17)
        Me.OpBorrado.TabIndex = 1
        Me.OpBorrado.Text = "Borrado | Otras"
        Me.OpBorrado.UseVisualStyleBackColor = True
        '
        'OpSeleccion
        '
        Me.OpSeleccion.AutoSize = True
        Me.OpSeleccion.Checked = True
        Me.OpSeleccion.Location = New System.Drawing.Point(33, 19)
        Me.OpSeleccion.Name = "OpSeleccion"
        Me.OpSeleccion.Size = New System.Drawing.Size(72, 17)
        Me.OpSeleccion.TabIndex = 0
        Me.OpSeleccion.TabStop = True
        Me.OpSeleccion.Text = "Selección"
        Me.OpSeleccion.UseVisualStyleBackColor = True
        '
        'TabBD
        '
        Me.TabBD.Controls.Add(Me.Seleccion)
        Me.TabBD.Location = New System.Drawing.Point(178, 52)
        Me.TabBD.Name = "TabBD"
        Me.TabBD.SelectedIndex = 0
        Me.TabBD.Size = New System.Drawing.Size(599, 147)
        Me.TabBD.TabIndex = 1
        '
        'Seleccion
        '
        Me.Seleccion.BackColor = System.Drawing.SystemColors.Control
        Me.Seleccion.Controls.Add(Me.PanBorrar)
        Me.Seleccion.Location = New System.Drawing.Point(4, 22)
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Padding = New System.Windows.Forms.Padding(3)
        Me.Seleccion.Size = New System.Drawing.Size(591, 121)
        Me.Seleccion.TabIndex = 0
        Me.Seleccion.Text = "Seleccion"
        '
        'PanBorrar
        '
        Me.PanBorrar.BackColor = System.Drawing.SystemColors.Control
        Me.PanBorrar.Controls.Add(Me.PanSel)
        Me.PanBorrar.Controls.Add(Me.BEjecutar)
        Me.PanBorrar.Controls.Add(Me.TSentencia)
        Me.PanBorrar.Controls.Add(Me.Label5)
        Me.PanBorrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanBorrar.Location = New System.Drawing.Point(3, 3)
        Me.PanBorrar.Name = "PanBorrar"
        Me.PanBorrar.Size = New System.Drawing.Size(585, 115)
        Me.PanBorrar.TabIndex = 10
        '
        'PanSel
        '
        Me.PanSel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PanSel.Controls.Add(Me.OpNuevaConsulta)
        Me.PanSel.Controls.Add(Me.BConsultar)
        Me.PanSel.Controls.Add(Me.TOrden)
        Me.PanSel.Controls.Add(Me.TCondicion)
        Me.PanSel.Controls.Add(Me.TCampos)
        Me.PanSel.Controls.Add(Me.Label4)
        Me.PanSel.Controls.Add(Me.Label3)
        Me.PanSel.Controls.Add(Me.Label2)
        Me.PanSel.Controls.Add(Me.Label1)
        Me.PanSel.Controls.Add(Me.TTabla)
        Me.PanSel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanSel.Location = New System.Drawing.Point(0, 0)
        Me.PanSel.Name = "PanSel"
        Me.PanSel.Size = New System.Drawing.Size(585, 115)
        Me.PanSel.TabIndex = 6
        '
        'OpNuevaConsulta
        '
        Me.OpNuevaConsulta.AutoSize = True
        Me.OpNuevaConsulta.Location = New System.Drawing.Point(354, 8)
        Me.OpNuevaConsulta.Name = "OpNuevaConsulta"
        Me.OpNuevaConsulta.Size = New System.Drawing.Size(102, 17)
        Me.OpNuevaConsulta.TabIndex = 9
        Me.OpNuevaConsulta.Text = "Nueva Consulta"
        Me.OpNuevaConsulta.UseVisualStyleBackColor = True
        '
        'BConsultar
        '
        Me.BConsultar.Image = CType(resources.GetObject("BConsultar.Image"), System.Drawing.Image)
        Me.BConsultar.Location = New System.Drawing.Point(230, 82)
        Me.BConsultar.Name = "BConsultar"
        Me.BConsultar.Size = New System.Drawing.Size(41, 30)
        Me.BConsultar.TabIndex = 8
        Me.ToolTip1.SetToolTip(Me.BConsultar, "Consultar Datos en la Base de Datos")
        Me.BConsultar.UseVisualStyleBackColor = True
        '
        'TOrden
        '
        Me.TOrden.Location = New System.Drawing.Point(73, 84)
        Me.TOrden.Name = "TOrden"
        Me.TOrden.Size = New System.Drawing.Size(142, 20)
        Me.TOrden.TabIndex = 7
        '
        'TCondicion
        '
        Me.TCondicion.Location = New System.Drawing.Point(73, 61)
        Me.TCondicion.Name = "TCondicion"
        Me.TCondicion.Size = New System.Drawing.Size(498, 20)
        Me.TCondicion.TabIndex = 6
        '
        'TCampos
        '
        Me.TCampos.Location = New System.Drawing.Point(64, 36)
        Me.TCampos.Name = "TCampos"
        Me.TCampos.Size = New System.Drawing.Size(463, 20)
        Me.TCampos.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Orden"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Condición"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Campos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tabla"
        '
        'TTabla
        '
        Me.TTabla.Enabled = False
        Me.TTabla.FormattingEnabled = True
        Me.TTabla.Location = New System.Drawing.Point(64, 5)
        Me.TTabla.Name = "TTabla"
        Me.TTabla.Size = New System.Drawing.Size(281, 21)
        Me.TTabla.TabIndex = 0
        '
        'BEjecutar
        '
        Me.BEjecutar.Image = CType(resources.GetObject("BEjecutar.Image"), System.Drawing.Image)
        Me.BEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BEjecutar.Location = New System.Drawing.Point(212, 60)
        Me.BEjecutar.Name = "BEjecutar"
        Me.BEjecutar.Size = New System.Drawing.Size(95, 32)
        Me.BEjecutar.TabIndex = 5
        Me.BEjecutar.Text = "   Ejecutar"
        Me.BEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BEjecutar.UseVisualStyleBackColor = True
        '
        'TSentencia
        '
        Me.TSentencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TSentencia.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSentencia.ForeColor = System.Drawing.Color.Red
        Me.TSentencia.Location = New System.Drawing.Point(95, 22)
        Me.TSentencia.Name = "TSentencia"
        Me.TSentencia.Size = New System.Drawing.Size(455, 22)
        Me.TSentencia.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(34, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Sentencia"
        '
        'BTraeTablas
        '
        Me.BTraeTablas.Location = New System.Drawing.Point(28, 137)
        Me.BTraeTablas.Name = "BTraeTablas"
        Me.BTraeTablas.Size = New System.Drawing.Size(75, 23)
        Me.BTraeTablas.TabIndex = 2
        Me.BTraeTablas.Text = "Trae Tablas"
        Me.BTraeTablas.UseVisualStyleBackColor = True
        Me.BTraeTablas.Visible = False
        '
        'DGDataBase
        '
        Me.DGDataBase.AllowUserToAddRows = False
        Me.DGDataBase.AllowUserToDeleteRows = False
        Me.DGDataBase.AllowUserToResizeRows = False
        Me.DGDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGDataBase.Location = New System.Drawing.Point(28, 229)
        Me.DGDataBase.Name = "DGDataBase"
        Me.DGDataBase.ReadOnly = True
        Me.DGDataBase.Size = New System.Drawing.Size(749, 279)
        Me.DGDataBase.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(679, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Registros"
        '
        'TNoRegistros
        '
        Me.TNoRegistros.Location = New System.Drawing.Point(736, 201)
        Me.TNoRegistros.Name = "TNoRegistros"
        Me.TNoRegistros.Size = New System.Drawing.Size(62, 20)
        Me.TNoRegistros.TabIndex = 25
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnAcercaD})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(810, 24)
        Me.MenuStrip1.TabIndex = 36
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
        Me.mnSalir.Size = New System.Drawing.Size(106, 22)
        Me.mnSalir.Text = "&Salir"
        '
        'mnAcercaD
        '
        Me.mnAcercaD.Image = CType(resources.GetObject("mnAcercaD.Image"), System.Drawing.Image)
        Me.mnAcercaD.Name = "mnAcercaD"
        Me.mnAcercaD.Size = New System.Drawing.Size(102, 20)
        Me.mnAcercaD.Text = "Acerca de...."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.BSalir, Me.ToolStripSeparator9, Me.mnEditar, Me.ToolStripSeparator8, Me.mnNuevo, Me.ToolStripSeparator5, Me.mnBBorrar, Me.ToolStripSeparator6, Me.mnBGuardar, Me.ToolStripButton1, Me.mnBCancelar, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(810, 25)
        Me.ToolStrip1.TabIndex = 37
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'mnEditar
        '
        Me.mnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnEditar.Image = CType(resources.GetObject("mnEditar.Image"), System.Drawing.Image)
        Me.mnEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnEditar.Name = "mnEditar"
        Me.mnEditar.Size = New System.Drawing.Size(23, 22)
        Me.mnEditar.Text = "Editar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'mnNuevo
        '
        Me.mnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnNuevo.Image = CType(resources.GetObject("mnNuevo.Image"), System.Drawing.Image)
        Me.mnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnNuevo.Name = "mnNuevo"
        Me.mnNuevo.Size = New System.Drawing.Size(23, 22)
        Me.mnNuevo.Text = "Nuevo"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'mnBBorrar
        '
        Me.mnBBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnBBorrar.Image = CType(resources.GetObject("mnBBorrar.Image"), System.Drawing.Image)
        Me.mnBBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnBBorrar.Name = "mnBBorrar"
        Me.mnBBorrar.Size = New System.Drawing.Size(23, 22)
        Me.mnBBorrar.Text = "Borrar"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'mnBGuardar
        '
        Me.mnBGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnBGuardar.Image = CType(resources.GetObject("mnBGuardar.Image"), System.Drawing.Image)
        Me.mnBGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnBGuardar.Name = "mnBGuardar"
        Me.mnBGuardar.Size = New System.Drawing.Size(23, 22)
        Me.mnBGuardar.Text = "Guardar"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(6, 25)
        '
        'mnBCancelar
        '
        Me.mnBCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnBCancelar.Image = CType(resources.GetObject("mnBCancelar.Image"), System.Drawing.Image)
        Me.mnBCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnBCancelar.Name = "mnBCancelar"
        Me.mnBCancelar.Size = New System.Drawing.Size(23, 22)
        Me.mnBCancelar.Text = "Cancelar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BasedeDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 530)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TNoRegistros)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGDataBase)
        Me.Controls.Add(Me.BTraeTablas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabBD)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BasedeDatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BasedeDatos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabBD.ResumeLayout(False)
        Me.Seleccion.ResumeLayout(False)
        Me.PanBorrar.ResumeLayout(False)
        Me.PanBorrar.PerformLayout()
        Me.PanSel.ResumeLayout(False)
        Me.PanSel.PerformLayout()
        CType(Me.DGDataBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents OpBorrado As System.Windows.Forms.RadioButton
    Friend WithEvents OpSeleccion As System.Windows.Forms.RadioButton
    Friend WithEvents TabBD As System.Windows.Forms.TabControl
    Friend WithEvents Seleccion As System.Windows.Forms.TabPage
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PanBorrar As System.Windows.Forms.Panel
    Friend WithEvents PanSel As System.Windows.Forms.Panel
    Friend WithEvents BConsultar As System.Windows.Forms.Button
    Friend WithEvents TOrden As System.Windows.Forms.TextBox
    Friend WithEvents TCondicion As System.Windows.Forms.TextBox
    Friend WithEvents TCampos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TTabla As System.Windows.Forms.ComboBox
    Friend WithEvents BEjecutar As System.Windows.Forms.Button
    Friend WithEvents TSentencia As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTraeTablas As System.Windows.Forms.Button
    Friend WithEvents OpNuevaConsulta As System.Windows.Forms.CheckBox
    Friend WithEvents DGDataBase As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TNoRegistros As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnAcercaD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnBBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnBGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnBCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
