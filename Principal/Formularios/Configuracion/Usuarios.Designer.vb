<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Usuarios
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelPerm = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbUsuarios = New System.Windows.Forms.ComboBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.BModificar = New System.Windows.Forms.Button()
        Me.BEliminar = New System.Windows.Forms.Button()
        Me.BNuevo = New System.Windows.Forms.Button()
        Me.PanNueUsua = New System.Windows.Forms.GroupBox()
        Me.LCodigo = New System.Windows.Forms.Label()
        Me.TCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TFechaVenc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbCargo = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnModificar = New System.Windows.Forms.ToolStripButton()
        Me.mnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.mnImpUsuarioActual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnImpTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnImpListaPermisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BRulesPass = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.GBRulesPass = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TNumClaves = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TNumNumbers = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TNumCharSpecial = New System.Windows.Forms.TextBox()
        Me.BSaveRulesPass = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TNumLower = New System.Windows.Forms.TextBox()
        Me.TNumUpper = New System.Windows.Forms.TextBox()
        Me.TLongMin = New System.Windows.Forms.TextBox()
        Me.TNumIntentos = New System.Windows.Forms.TextBox()
        Me.TVigenciaPass = New System.Windows.Forms.TextBox()
        Me.ChSelecTodos = New System.Windows.Forms.CheckBox()
        Me.GBLineaNegocio = New System.Windows.Forms.GroupBox()
        Me.TLineaNegocio = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1.SuspendLayout()
        Me.PanNueUsua.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GBRulesPass.SuspendLayout()
        Me.GBLineaNegocio.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1135, 24)
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
        'PanelPerm
        '
        Me.PanelPerm.BackColor = System.Drawing.Color.Transparent
        Me.PanelPerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPerm.Enabled = False
        Me.PanelPerm.Location = New System.Drawing.Point(267, 78)
        Me.PanelPerm.Name = "PanelPerm"
        Me.PanelPerm.Size = New System.Drawing.Size(856, 573)
        Me.PanelPerm.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(45, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lista de Usuarios"
        '
        'CbUsuarios
        '
        Me.CbUsuarios.FormattingEnabled = True
        Me.CbUsuarios.Location = New System.Drawing.Point(45, 91)
        Me.CbUsuarios.Name = "CbUsuarios"
        Me.CbUsuarios.Size = New System.Drawing.Size(136, 21)
        Me.CbUsuarios.TabIndex = 3
        '
        'BCancelar
        '
        Me.BCancelar.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancelar.ForeColor = System.Drawing.Color.Purple
        Me.BCancelar.Location = New System.Drawing.Point(57, 393)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(97, 21)
        Me.BCancelar.TabIndex = 9
        Me.BCancelar.Text = "Cancelar"
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAceptar.ForeColor = System.Drawing.Color.Purple
        Me.BAceptar.Location = New System.Drawing.Point(12, 352)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(78, 22)
        Me.BAceptar.TabIndex = 5
        Me.BAceptar.Text = "Aceptar"
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'BModificar
        '
        Me.BModificar.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BModificar.ForeColor = System.Drawing.Color.Purple
        Me.BModificar.Location = New System.Drawing.Point(127, 352)
        Me.BModificar.Name = "BModificar"
        Me.BModificar.Size = New System.Drawing.Size(81, 21)
        Me.BModificar.TabIndex = 8
        Me.BModificar.Text = "Modificar"
        Me.BModificar.UseVisualStyleBackColor = True
        '
        'BEliminar
        '
        Me.BEliminar.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BEliminar.ForeColor = System.Drawing.Color.Purple
        Me.BEliminar.Location = New System.Drawing.Point(138, 318)
        Me.BEliminar.Name = "BEliminar"
        Me.BEliminar.Size = New System.Drawing.Size(70, 22)
        Me.BEliminar.TabIndex = 7
        Me.BEliminar.Text = "Eliminar"
        Me.BEliminar.UseVisualStyleBackColor = True
        '
        'BNuevo
        '
        Me.BNuevo.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BNuevo.ForeColor = System.Drawing.Color.Purple
        Me.BNuevo.Location = New System.Drawing.Point(12, 318)
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(75, 22)
        Me.BNuevo.TabIndex = 6
        Me.BNuevo.Text = "Nuevo"
        Me.BNuevo.UseVisualStyleBackColor = True
        '
        'PanNueUsua
        '
        Me.PanNueUsua.Controls.Add(Me.LCodigo)
        Me.PanNueUsua.Controls.Add(Me.TCodigo)
        Me.PanNueUsua.Controls.Add(Me.Label3)
        Me.PanNueUsua.Controls.Add(Me.TFechaVenc)
        Me.PanNueUsua.Controls.Add(Me.Label4)
        Me.PanNueUsua.Controls.Add(Me.TUsuario)
        Me.PanNueUsua.Controls.Add(Me.Label2)
        Me.PanNueUsua.Controls.Add(Me.CbCargo)
        Me.PanNueUsua.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanNueUsua.Location = New System.Drawing.Point(12, 118)
        Me.PanNueUsua.Name = "PanNueUsua"
        Me.PanNueUsua.Size = New System.Drawing.Size(196, 143)
        Me.PanNueUsua.TabIndex = 4
        Me.PanNueUsua.TabStop = False
        Me.PanNueUsua.Text = "Usuario"
        '
        'LCodigo
        '
        Me.LCodigo.AutoSize = True
        Me.LCodigo.Location = New System.Drawing.Point(10, 81)
        Me.LCodigo.Name = "LCodigo"
        Me.LCodigo.Size = New System.Drawing.Size(47, 15)
        Me.LCodigo.TabIndex = 2
        Me.LCodigo.Text = "Código"
        '
        'TCodigo
        '
        Me.TCodigo.Location = New System.Drawing.Point(67, 78)
        Me.TCodigo.Name = "TCodigo"
        Me.TCodigo.ReadOnly = True
        Me.TCodigo.Size = New System.Drawing.Size(121, 21)
        Me.TCodigo.TabIndex = 6
        Me.TCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "F.Venc."
        '
        'TFechaVenc
        '
        Me.TFechaVenc.Location = New System.Drawing.Point(67, 106)
        Me.TFechaVenc.Name = "TFechaVenc"
        Me.TFechaVenc.ReadOnly = True
        Me.TFechaVenc.Size = New System.Drawing.Size(121, 21)
        Me.TFechaVenc.TabIndex = 7
        Me.TFechaVenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Cargo"
        '
        'TUsuario
        '
        Me.TUsuario.Location = New System.Drawing.Point(67, 20)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.ReadOnly = True
        Me.TUsuario.Size = New System.Drawing.Size(121, 21)
        Me.TUsuario.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Usuario"
        '
        'CbCargo
        '
        Me.CbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbCargo.FormattingEnabled = True
        Me.CbCargo.Location = New System.Drawing.Point(67, 48)
        Me.CbCargo.Name = "CbCargo"
        Me.CbCargo.Size = New System.Drawing.Size(121, 23)
        Me.CbCargo.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.BSalir, Me.ToolStripSeparator2, Me.mnNuevo, Me.ToolStripSeparator3, Me.mnModificar, Me.mnEliminar, Me.ToolStripSeparator4, Me.ToolStripSeparator5, Me.BImprimir, Me.ToolStripSeparator6, Me.BActualizar, Me.ToolStripSeparator8, Me.BRulesPass, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1135, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "Salir"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'mnModificar
        '
        Me.mnModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnModificar.Image = CType(resources.GetObject("mnModificar.Image"), System.Drawing.Image)
        Me.mnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnModificar.Name = "mnModificar"
        Me.mnModificar.Size = New System.Drawing.Size(23, 22)
        Me.mnModificar.Text = "Modificar"
        '
        'mnEliminar
        '
        Me.mnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.mnEliminar.Image = CType(resources.GetObject("mnEliminar.Image"), System.Drawing.Image)
        Me.mnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnEliminar.Name = "mnEliminar"
        Me.mnEliminar.Size = New System.Drawing.Size(23, 22)
        Me.mnEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'BImprimir
        '
        Me.BImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnImpUsuarioActual, Me.mnImpTodos, Me.mnImpListaPermisos})
        Me.BImprimir.Image = CType(resources.GetObject("BImprimir.Image"), System.Drawing.Image)
        Me.BImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BImprimir.Name = "BImprimir"
        Me.BImprimir.Size = New System.Drawing.Size(32, 22)
        Me.BImprimir.Text = "Imprimir Usuarios"
        '
        'mnImpUsuarioActual
        '
        Me.mnImpUsuarioActual.Name = "mnImpUsuarioActual"
        Me.mnImpUsuarioActual.Size = New System.Drawing.Size(186, 22)
        Me.mnImpUsuarioActual.Text = "Usuario seleccionado"
        '
        'mnImpTodos
        '
        Me.mnImpTodos.Name = "mnImpTodos"
        Me.mnImpTodos.Size = New System.Drawing.Size(186, 22)
        Me.mnImpTodos.Text = "Todos los usuarios"
        '
        'mnImpListaPermisos
        '
        Me.mnImpListaPermisos.Name = "mnImpListaPermisos"
        Me.mnImpListaPermisos.Size = New System.Drawing.Size(186, 22)
        Me.mnImpListaPermisos.Text = "Lista de permisos"
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
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'BRulesPass
        '
        Me.BRulesPass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BRulesPass.Image = CType(resources.GetObject("BRulesPass.Image"), System.Drawing.Image)
        Me.BRulesPass.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BRulesPass.Name = "BRulesPass"
        Me.BRulesPass.Size = New System.Drawing.Size(23, 22)
        Me.BRulesPass.ToolTipText = "Modificar parametros  de contraseñas"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'GBRulesPass
        '
        Me.GBRulesPass.BackColor = System.Drawing.SystemColors.Control
        Me.GBRulesPass.Controls.Add(Me.Label13)
        Me.GBRulesPass.Controls.Add(Me.TNumClaves)
        Me.GBRulesPass.Controls.Add(Me.Label12)
        Me.GBRulesPass.Controls.Add(Me.TNumNumbers)
        Me.GBRulesPass.Controls.Add(Me.Label11)
        Me.GBRulesPass.Controls.Add(Me.TNumCharSpecial)
        Me.GBRulesPass.Controls.Add(Me.BSaveRulesPass)
        Me.GBRulesPass.Controls.Add(Me.Label10)
        Me.GBRulesPass.Controls.Add(Me.Label9)
        Me.GBRulesPass.Controls.Add(Me.Label8)
        Me.GBRulesPass.Controls.Add(Me.Label7)
        Me.GBRulesPass.Controls.Add(Me.Label6)
        Me.GBRulesPass.Controls.Add(Me.Label5)
        Me.GBRulesPass.Controls.Add(Me.TNumLower)
        Me.GBRulesPass.Controls.Add(Me.TNumUpper)
        Me.GBRulesPass.Controls.Add(Me.TLongMin)
        Me.GBRulesPass.Controls.Add(Me.TNumIntentos)
        Me.GBRulesPass.Controls.Add(Me.TVigenciaPass)
        Me.GBRulesPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBRulesPass.Location = New System.Drawing.Point(11, 421)
        Me.GBRulesPass.Margin = New System.Windows.Forms.Padding(2)
        Me.GBRulesPass.Name = "GBRulesPass"
        Me.GBRulesPass.Padding = New System.Windows.Forms.Padding(2)
        Me.GBRulesPass.Size = New System.Drawing.Size(253, 267)
        Me.GBRulesPass.TabIndex = 10
        Me.GBRulesPass.TabStop = False
        Me.GBRulesPass.Text = "Parametros de seguridad contraseñas"
        Me.GBRulesPass.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(2, 192)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Núm.de claves a recordar:"
        '
        'TNumClaves
        '
        Me.TNumClaves.Location = New System.Drawing.Point(159, 190)
        Me.TNumClaves.Margin = New System.Windows.Forms.Padding(2)
        Me.TNumClaves.Name = "TNumClaves"
        Me.TNumClaves.Size = New System.Drawing.Size(36, 21)
        Me.TNumClaves.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(25, 148)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 15)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Cantidad de números:"
        '
        'TNumNumbers
        '
        Me.TNumNumbers.Location = New System.Drawing.Point(159, 145)
        Me.TNumNumbers.Margin = New System.Windows.Forms.Padding(2)
        Me.TNumNumbers.Name = "TNumNumbers"
        Me.TNumNumbers.Size = New System.Drawing.Size(36, 21)
        Me.TNumNumbers.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 167)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 15)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Núm.de caract.especiales:"
        '
        'TNumCharSpecial
        '
        Me.TNumCharSpecial.Location = New System.Drawing.Point(159, 167)
        Me.TNumCharSpecial.Margin = New System.Windows.Forms.Padding(2)
        Me.TNumCharSpecial.Name = "TNumCharSpecial"
        Me.TNumCharSpecial.Size = New System.Drawing.Size(36, 21)
        Me.TNumCharSpecial.TabIndex = 15
        '
        'BSaveRulesPass
        '
        Me.BSaveRulesPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSaveRulesPass.Image = CType(resources.GetObject("BSaveRulesPass.Image"), System.Drawing.Image)
        Me.BSaveRulesPass.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BSaveRulesPass.Location = New System.Drawing.Point(99, 217)
        Me.BSaveRulesPass.Margin = New System.Windows.Forms.Padding(2)
        Me.BSaveRulesPass.Name = "BSaveRulesPass"
        Me.BSaveRulesPass.Size = New System.Drawing.Size(53, 39)
        Me.BSaveRulesPass.TabIndex = 17
        Me.BSaveRulesPass.Text = "Guardar"
        Me.BSaveRulesPass.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BSaveRulesPass.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(30, 127)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 15)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Núm. de minúsculas:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 103)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Núm. de mayúsculas:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 80)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Longitud mínima clave:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 58)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Núm. de intentos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(199, 36)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "días"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 36)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Vigencia de la contraseña:"
        '
        'TNumLower
        '
        Me.TNumLower.Location = New System.Drawing.Point(159, 123)
        Me.TNumLower.Margin = New System.Windows.Forms.Padding(2)
        Me.TNumLower.Name = "TNumLower"
        Me.TNumLower.Size = New System.Drawing.Size(36, 21)
        Me.TNumLower.TabIndex = 13
        '
        'TNumUpper
        '
        Me.TNumUpper.Location = New System.Drawing.Point(159, 100)
        Me.TNumUpper.Margin = New System.Windows.Forms.Padding(2)
        Me.TNumUpper.Name = "TNumUpper"
        Me.TNumUpper.Size = New System.Drawing.Size(36, 21)
        Me.TNumUpper.TabIndex = 12
        '
        'TLongMin
        '
        Me.TLongMin.Location = New System.Drawing.Point(159, 77)
        Me.TLongMin.Margin = New System.Windows.Forms.Padding(2)
        Me.TLongMin.Name = "TLongMin"
        Me.TLongMin.Size = New System.Drawing.Size(36, 21)
        Me.TLongMin.TabIndex = 11
        '
        'TNumIntentos
        '
        Me.TNumIntentos.Location = New System.Drawing.Point(159, 55)
        Me.TNumIntentos.Margin = New System.Windows.Forms.Padding(2)
        Me.TNumIntentos.Name = "TNumIntentos"
        Me.TNumIntentos.Size = New System.Drawing.Size(36, 21)
        Me.TNumIntentos.TabIndex = 10
        '
        'TVigenciaPass
        '
        Me.TVigenciaPass.Location = New System.Drawing.Point(159, 33)
        Me.TVigenciaPass.Margin = New System.Windows.Forms.Padding(2)
        Me.TVigenciaPass.Name = "TVigenciaPass"
        Me.TVigenciaPass.Size = New System.Drawing.Size(36, 21)
        Me.TVigenciaPass.TabIndex = 9
        '
        'ChSelecTodos
        '
        Me.ChSelecTodos.AutoSize = True
        Me.ChSelecTodos.Location = New System.Drawing.Point(290, 55)
        Me.ChSelecTodos.Name = "ChSelecTodos"
        Me.ChSelecTodos.Size = New System.Drawing.Size(115, 17)
        Me.ChSelecTodos.TabIndex = 49
        Me.ChSelecTodos.Text = "Seleccionar Todos"
        Me.ChSelecTodos.UseVisualStyleBackColor = True
        '
        'GBLineaNegocio
        '
        Me.GBLineaNegocio.Controls.Add(Me.TLineaNegocio)
        Me.GBLineaNegocio.Location = New System.Drawing.Point(11, 268)
        Me.GBLineaNegocio.Name = "GBLineaNegocio"
        Me.GBLineaNegocio.Size = New System.Drawing.Size(200, 44)
        Me.GBLineaNegocio.TabIndex = 50
        Me.GBLineaNegocio.TabStop = False
        Me.GBLineaNegocio.Text = "Línea Negocio"
        '
        'TLineaNegocio
        '
        Me.TLineaNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TLineaNegocio.FormattingEnabled = True
        Me.TLineaNegocio.Items.AddRange(New Object() {"PRINCIPAL", "MASCOTAS"})
        Me.TLineaNegocio.Location = New System.Drawing.Point(74, 17)
        Me.TLineaNegocio.Name = "TLineaNegocio"
        Me.TLineaNegocio.Size = New System.Drawing.Size(121, 21)
        Me.TLineaNegocio.TabIndex = 4
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 727)
        Me.Controls.Add(Me.GBLineaNegocio)
        Me.Controls.Add(Me.ChSelecTodos)
        Me.Controls.Add(Me.GBRulesPass)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PanNueUsua)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BAceptar)
        Me.Controls.Add(Me.BModificar)
        Me.Controls.Add(Me.BEliminar)
        Me.Controls.Add(Me.BNuevo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbUsuarios)
        Me.Controls.Add(Me.PanelPerm)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.PanNueUsua.ResumeLayout(False)
        Me.PanNueUsua.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GBRulesPass.ResumeLayout(False)
        Me.GBRulesPass.PerformLayout()
        Me.GBLineaNegocio.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelPerm As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CbUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents BModificar As System.Windows.Forms.Button
    Friend WithEvents BEliminar As System.Windows.Forms.Button
    Friend WithEvents BNuevo As System.Windows.Forms.Button
    Friend WithEvents PanNueUsua As System.Windows.Forms.GroupBox
    Friend WithEvents TUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TFechaVenc As System.Windows.Forms.TextBox
    Friend WithEvents BRulesPass As System.Windows.Forms.ToolStripButton
    Friend WithEvents GBRulesPass As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TNumClaves As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TNumNumbers As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TNumCharSpecial As System.Windows.Forms.TextBox
    Friend WithEvents BSaveRulesPass As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TNumLower As System.Windows.Forms.TextBox
    Friend WithEvents TNumUpper As System.Windows.Forms.TextBox
    Friend WithEvents TLongMin As System.Windows.Forms.TextBox
    Friend WithEvents TNumIntentos As System.Windows.Forms.TextBox
    Friend WithEvents TVigenciaPass As System.Windows.Forms.TextBox
    Public WithEvents ChSelecTodos As CheckBox
    Friend WithEvents LCodigo As Label
    Friend WithEvents TCodigo As TextBox
    Friend WithEvents CbCargo As ComboBox
    Friend WithEvents BImprimir As ToolStripSplitButton
    Friend WithEvents mnImpUsuarioActual As ToolStripMenuItem
    Friend WithEvents mnImpTodos As ToolStripMenuItem
    Friend WithEvents mnImpListaPermisos As ToolStripMenuItem
    Friend WithEvents BActualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents GBLineaNegocio As GroupBox
    Friend WithEvents TLineaNegocio As ComboBox
End Class
