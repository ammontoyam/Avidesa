<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablaLineasProd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TablaLineasProd))
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
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChLineaExterna = New System.Windows.Forms.CheckBox()
        Me.TDiasVenc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChManejaPx = New System.Windows.Forms.CheckBox()
        Me.GBDatosCortes = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TPorcMerma = New System.Windows.Forms.TextBox()
        Me.GBLimPelets = New System.Windows.Forms.GroupBox()
        Me.TTempMax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TTempMin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TPresionMax = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TPresionMin = New System.Windows.Forms.TextBox()
        Me.CTipo = New System.Windows.Forms.ComboBox()
        Me.TLineaProd = New System.Windows.Forms.TextBox()
        Me.GBDatosDesc = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TKgxHzPelet3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TKgxHzPelet2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TKgxHzPelet1 = New System.Windows.Forms.TextBox()
        Me.TDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.DGLineasProd = New System.Windows.Forms.DataGridView()
        Me.GBPresent = New System.Windows.Forms.GroupBox()
        Me.CBPresent = New System.Windows.Forms.ComboBox()
        Me.linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresionMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresionMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempMin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TempMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgxHzPelet1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgxHzPelet2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KgxHzPelet3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcMerma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LineaExterna = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DiasVenc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Present = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GBDatosCortes.SuspendLayout()
        Me.GBLimPelets.SuspendLayout()
        Me.GBDatosDesc.SuspendLayout()
        CType(Me.DGLineasProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBPresent.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9, Me.BPrimero, Me.ToolStripSeparator1, Me.BAnterior, Me.ToolStripSeparator2, Me.mnTCuenta, Me.ToolStripLabel1, Me.mnLCuenta, Me.ToolStripSeparator7, Me.BSiguiente, Me.ToolStripSeparator3, Me.BUltimo, Me.ToolStripSeparator4, Me.BEditar, Me.ToolStripSeparator8, Me.BNuevo, Me.ToolStripSeparator5, Me.BBorrar, Me.ToolStripSeparator6, Me.BActualizar, Me.ToolStripSeparator10})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(691, 25)
        Me.ToolStrip1.TabIndex = 34
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
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(691, 24)
        Me.MenuStrip1.TabIndex = 33
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GBPresent)
        Me.Panel1.Controls.Add(Me.ChLineaExterna)
        Me.Panel1.Controls.Add(Me.TDiasVenc)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.ChManejaPx)
        Me.Panel1.Controls.Add(Me.GBDatosCortes)
        Me.Panel1.Controls.Add(Me.GBLimPelets)
        Me.Panel1.Controls.Add(Me.CTipo)
        Me.Panel1.Controls.Add(Me.TLineaProd)
        Me.Panel1.Controls.Add(Me.GBDatosDesc)
        Me.Panel1.Controls.Add(Me.TDescripcion)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BCancelar)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Location = New System.Drawing.Point(14, 70)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 576)
        Me.Panel1.TabIndex = 36
        '
        'ChLineaExterna
        '
        Me.ChLineaExterna.AutoSize = True
        Me.ChLineaExterna.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChLineaExterna.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChLineaExterna.Location = New System.Drawing.Point(18, 119)
        Me.ChLineaExterna.Name = "ChLineaExterna"
        Me.ChLineaExterna.Size = New System.Drawing.Size(100, 18)
        Me.ChLineaExterna.TabIndex = 31
        Me.ChLineaExterna.Text = "Línea Externa"
        Me.ChLineaExterna.UseVisualStyleBackColor = True
        Me.ChLineaExterna.Visible = False
        '
        'TDiasVenc
        '
        Me.TDiasVenc.Location = New System.Drawing.Point(128, 82)
        Me.TDiasVenc.Name = "TDiasVenc"
        Me.TDiasVenc.ReadOnly = True
        Me.TDiasVenc.Size = New System.Drawing.Size(55, 20)
        Me.TDiasVenc.TabIndex = 30
        Me.TDiasVenc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(9, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 14)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Vencimiento (días):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChManejaPx
        '
        Me.ChManejaPx.AutoSize = True
        Me.ChManejaPx.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChManejaPx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChManejaPx.Location = New System.Drawing.Point(18, 172)
        Me.ChManejaPx.Name = "ChManejaPx"
        Me.ChManejaPx.Size = New System.Drawing.Size(133, 18)
        Me.ChManejaPx.TabIndex = 4
        Me.ChManejaPx.Text = "Maneja Premezclas"
        Me.ChManejaPx.UseVisualStyleBackColor = True
        Me.ChManejaPx.Visible = False
        '
        'GBDatosCortes
        '
        Me.GBDatosCortes.Controls.Add(Me.Label13)
        Me.GBDatosCortes.Controls.Add(Me.TPorcMerma)
        Me.GBDatosCortes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBDatosCortes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBDatosCortes.Location = New System.Drawing.Point(12, 196)
        Me.GBDatosCortes.Name = "GBDatosCortes"
        Me.GBDatosCortes.Size = New System.Drawing.Size(266, 50)
        Me.GBDatosCortes.TabIndex = 26
        Me.GBDatosCortes.TabStop = False
        Me.GBDatosCortes.Text = "Datos para Informe de cortes"
        Me.GBDatosCortes.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(16, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(131, 14)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Porcentaje Merma (%):"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TPorcMerma
        '
        Me.TPorcMerma.Location = New System.Drawing.Point(159, 21)
        Me.TPorcMerma.Name = "TPorcMerma"
        Me.TPorcMerma.ReadOnly = True
        Me.TPorcMerma.Size = New System.Drawing.Size(45, 20)
        Me.TPorcMerma.TabIndex = 5
        Me.TPorcMerma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBLimPelets
        '
        Me.GBLimPelets.Controls.Add(Me.TTempMax)
        Me.GBLimPelets.Controls.Add(Me.Label10)
        Me.GBLimPelets.Controls.Add(Me.TTempMin)
        Me.GBLimPelets.Controls.Add(Me.Label7)
        Me.GBLimPelets.Controls.Add(Me.Label8)
        Me.GBLimPelets.Controls.Add(Me.TPresionMax)
        Me.GBLimPelets.Controls.Add(Me.Label9)
        Me.GBLimPelets.Controls.Add(Me.TPresionMin)
        Me.GBLimPelets.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBLimPelets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBLimPelets.Location = New System.Drawing.Point(11, 380)
        Me.GBLimPelets.Name = "GBLimPelets"
        Me.GBLimPelets.Size = New System.Drawing.Size(266, 154)
        Me.GBLimPelets.TabIndex = 25
        Me.GBLimPelets.TabStop = False
        Me.GBLimPelets.Text = "Límites de Control Peletizado para Software de Monitoreo de Procesos"
        Me.GBLimPelets.Visible = False
        '
        'TTempMax
        '
        Me.TTempMax.Location = New System.Drawing.Point(159, 114)
        Me.TTempMax.Name = "TTempMax"
        Me.TTempMax.ReadOnly = True
        Me.TTempMax.Size = New System.Drawing.Size(45, 20)
        Me.TTempMax.TabIndex = 12
        Me.TTempMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(16, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 14)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Temperatura Máx. (° C): "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TTempMin
        '
        Me.TTempMin.Location = New System.Drawing.Point(159, 90)
        Me.TTempMin.Name = "TTempMin"
        Me.TTempMin.ReadOnly = True
        Me.TTempMin.Size = New System.Drawing.Size(45, 20)
        Me.TTempMin.TabIndex = 11
        Me.TTempMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(16, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 14)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Temperatura Mín. (° C): "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(16, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 14)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Presión Máxima (psi): "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TPresionMax
        '
        Me.TPresionMax.Location = New System.Drawing.Point(159, 66)
        Me.TPresionMax.Name = "TPresionMax"
        Me.TPresionMax.ReadOnly = True
        Me.TPresionMax.Size = New System.Drawing.Size(45, 20)
        Me.TPresionMax.TabIndex = 10
        Me.TPresionMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(16, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 14)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Presión Mínima (psi):"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TPresionMin
        '
        Me.TPresionMin.Location = New System.Drawing.Point(159, 43)
        Me.TPresionMin.Name = "TPresionMin"
        Me.TPresionMin.ReadOnly = True
        Me.TPresionMin.Size = New System.Drawing.Size(45, 20)
        Me.TPresionMin.TabIndex = 9
        Me.TPresionMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CTipo
        '
        Me.CTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CTipo.Enabled = False
        Me.CTipo.FormattingEnabled = True
        Me.CTipo.Items.AddRange(New Object() {"MP", "PT", "LN"})
        Me.CTipo.Location = New System.Drawing.Point(84, 29)
        Me.CTipo.Name = "CTipo"
        Me.CTipo.Size = New System.Drawing.Size(53, 21)
        Me.CTipo.TabIndex = 2
        '
        'TLineaProd
        '
        Me.TLineaProd.Location = New System.Drawing.Point(84, 6)
        Me.TLineaProd.Name = "TLineaProd"
        Me.TLineaProd.ReadOnly = True
        Me.TLineaProd.Size = New System.Drawing.Size(205, 20)
        Me.TLineaProd.TabIndex = 1
        '
        'GBDatosDesc
        '
        Me.GBDatosDesc.Controls.Add(Me.Label6)
        Me.GBDatosDesc.Controls.Add(Me.TKgxHzPelet3)
        Me.GBDatosDesc.Controls.Add(Me.Label4)
        Me.GBDatosDesc.Controls.Add(Me.TKgxHzPelet2)
        Me.GBDatosDesc.Controls.Add(Me.Label5)
        Me.GBDatosDesc.Controls.Add(Me.TKgxHzPelet1)
        Me.GBDatosDesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBDatosDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBDatosDesc.Location = New System.Drawing.Point(11, 263)
        Me.GBDatosDesc.Name = "GBDatosDesc"
        Me.GBDatosDesc.Size = New System.Drawing.Size(266, 100)
        Me.GBDatosDesc.TabIndex = 22
        Me.GBDatosDesc.TabStop = False
        Me.GBDatosDesc.Text = "Datos para descuento de tolvas peletizado"
        Me.GBDatosDesc.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(16, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 14)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "KgxHz Peletizadora 3 :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TKgxHzPelet3
        '
        Me.TKgxHzPelet3.Location = New System.Drawing.Point(159, 69)
        Me.TKgxHzPelet3.Name = "TKgxHzPelet3"
        Me.TKgxHzPelet3.ReadOnly = True
        Me.TKgxHzPelet3.Size = New System.Drawing.Size(45, 20)
        Me.TKgxHzPelet3.TabIndex = 8
        Me.TKgxHzPelet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(16, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 14)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "KgxHz Peletizadora 2 :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TKgxHzPelet2
        '
        Me.TKgxHzPelet2.Location = New System.Drawing.Point(159, 44)
        Me.TKgxHzPelet2.Name = "TKgxHzPelet2"
        Me.TKgxHzPelet2.ReadOnly = True
        Me.TKgxHzPelet2.Size = New System.Drawing.Size(45, 20)
        Me.TKgxHzPelet2.TabIndex = 7
        Me.TKgxHzPelet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 14)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "KgxHz Peletizadora 1 :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TKgxHzPelet1
        '
        Me.TKgxHzPelet1.Location = New System.Drawing.Point(159, 21)
        Me.TKgxHzPelet1.Name = "TKgxHzPelet1"
        Me.TKgxHzPelet1.ReadOnly = True
        Me.TKgxHzPelet1.Size = New System.Drawing.Size(45, 20)
        Me.TKgxHzPelet1.TabIndex = 6
        Me.TKgxHzPelet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TDescripcion
        '
        Me.TDescripcion.Location = New System.Drawing.Point(84, 54)
        Me.TDescripcion.Name = "TDescripcion"
        Me.TDescripcion.ReadOnly = True
        Me.TDescripcion.Size = New System.Drawing.Size(205, 20)
        Me.TDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Descripción:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 14)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Tipo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Línea:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(170, 540)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 14
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(109, 540)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 13
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'DGLineasProd
        '
        Me.DGLineasProd.AllowUserToAddRows = False
        Me.DGLineasProd.AllowUserToDeleteRows = False
        Me.DGLineasProd.AllowUserToResizeRows = False
        Me.DGLineasProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGLineasProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.linea, Me.PresionMin, Me.PresionMax, Me.TempMin, Me.TempMax, Me.Descripcion, Me.Tipo, Me.KgxHzPelet1, Me.KgxHzPelet2, Me.KgxHzPelet3, Me.PorcMerma, Me.LineaExterna, Me.DiasVenc, Me.Present})
        Me.DGLineasProd.Location = New System.Drawing.Point(340, 69)
        Me.DGLineasProd.MultiSelect = False
        Me.DGLineasProd.Name = "DGLineasProd"
        Me.DGLineasProd.ReadOnly = True
        Me.DGLineasProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGLineasProd.Size = New System.Drawing.Size(318, 577)
        Me.DGLineasProd.TabIndex = 35
        '
        'GBPresent
        '
        Me.GBPresent.Controls.Add(Me.CBPresent)
        Me.GBPresent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GBPresent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GBPresent.Location = New System.Drawing.Point(128, 113)
        Me.GBPresent.Name = "GBPresent"
        Me.GBPresent.Size = New System.Drawing.Size(168, 51)
        Me.GBPresent.TabIndex = 34
        Me.GBPresent.TabStop = False
        Me.GBPresent.Text = "Presentación:"
        Me.GBPresent.Visible = False
        '
        'CBPresent
        '
        Me.CBPresent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPresent.Enabled = False
        Me.CBPresent.FormattingEnabled = True
        Me.CBPresent.Items.AddRange(New Object() {"PELETIZADO", "EXTRUIDO", "-"})
        Me.CBPresent.Location = New System.Drawing.Point(15, 19)
        Me.CBPresent.Name = "CBPresent"
        Me.CBPresent.Size = New System.Drawing.Size(143, 22)
        Me.CBPresent.TabIndex = 33
        '
        'linea
        '
        Me.linea.HeaderText = "Linea"
        Me.linea.Name = "linea"
        Me.linea.ReadOnly = True
        Me.linea.Width = 150
        '
        'PresionMin
        '
        Me.PresionMin.HeaderText = "PresionMin"
        Me.PresionMin.Name = "PresionMin"
        Me.PresionMin.ReadOnly = True
        Me.PresionMin.Visible = False
        '
        'PresionMax
        '
        Me.PresionMax.HeaderText = "PresionMax"
        Me.PresionMax.Name = "PresionMax"
        Me.PresionMax.ReadOnly = True
        Me.PresionMax.Visible = False
        '
        'TempMin
        '
        Me.TempMin.HeaderText = "TempMin"
        Me.TempMin.Name = "TempMin"
        Me.TempMin.ReadOnly = True
        Me.TempMin.Visible = False
        '
        'TempMax
        '
        Me.TempMax.HeaderText = "TempMax"
        Me.TempMax.Name = "TempMax"
        Me.TempMax.ReadOnly = True
        Me.TempMax.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Visible = False
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'KgxHzPelet1
        '
        Me.KgxHzPelet1.HeaderText = "TKgxHzPelet1"
        Me.KgxHzPelet1.Name = "KgxHzPelet1"
        Me.KgxHzPelet1.ReadOnly = True
        Me.KgxHzPelet1.Visible = False
        '
        'KgxHzPelet2
        '
        Me.KgxHzPelet2.HeaderText = "TKgxHzPelet1"
        Me.KgxHzPelet2.Name = "KgxHzPelet2"
        Me.KgxHzPelet2.ReadOnly = True
        Me.KgxHzPelet2.Visible = False
        '
        'KgxHzPelet3
        '
        Me.KgxHzPelet3.HeaderText = "TKgxHzPelet3"
        Me.KgxHzPelet3.Name = "KgxHzPelet3"
        Me.KgxHzPelet3.ReadOnly = True
        Me.KgxHzPelet3.Visible = False
        '
        'PorcMerma
        '
        Me.PorcMerma.HeaderText = "PorcMerma"
        Me.PorcMerma.Name = "PorcMerma"
        Me.PorcMerma.ReadOnly = True
        Me.PorcMerma.Visible = False
        '
        'LineaExterna
        '
        Me.LineaExterna.HeaderText = "LineaExterna"
        Me.LineaExterna.Name = "LineaExterna"
        Me.LineaExterna.ReadOnly = True
        Me.LineaExterna.Visible = False
        '
        'DiasVenc
        '
        Me.DiasVenc.HeaderText = "DiasVenc"
        Me.DiasVenc.Name = "DiasVenc"
        Me.DiasVenc.ReadOnly = True
        Me.DiasVenc.Visible = False
        '
        'Present
        '
        Me.Present.HeaderText = "Present"
        Me.Present.Name = "Present"
        Me.Present.ReadOnly = True
        Me.Present.Visible = False
        '
        'TablaLineasProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 678)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGLineasProd)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "TablaLineasProd"
        Me.Text = "Líneas Planta"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GBDatosCortes.ResumeLayout(False)
        Me.GBDatosCortes.PerformLayout()
        Me.GBLimPelets.ResumeLayout(False)
        Me.GBLimPelets.PerformLayout()
        Me.GBDatosDesc.ResumeLayout(False)
        Me.GBDatosDesc.PerformLayout()
        CType(Me.DGLineasProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBPresent.ResumeLayout(False)
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
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents DGLineasProd As System.Windows.Forms.DataGridView
    Friend WithEvents GBDatosDesc As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TKgxHzPelet3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TKgxHzPelet2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TKgxHzPelet1 As System.Windows.Forms.TextBox
    Friend WithEvents CTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TLineaProd As System.Windows.Forms.TextBox
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GBLimPelets As System.Windows.Forms.GroupBox
    Friend WithEvents TTempMax As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TTempMin As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TPresionMax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TPresionMin As System.Windows.Forms.TextBox
    Friend WithEvents GBDatosCortes As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TPorcMerma As System.Windows.Forms.TextBox
    Friend WithEvents ChManejaPx As CheckBox
    Friend WithEvents TDiasVenc As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ChLineaExterna As CheckBox
    Friend WithEvents GBPresent As GroupBox
    Friend WithEvents CBPresent As ComboBox
    Friend WithEvents linea As DataGridViewTextBoxColumn
    Friend WithEvents PresionMin As DataGridViewTextBoxColumn
    Friend WithEvents PresionMax As DataGridViewTextBoxColumn
    Friend WithEvents TempMin As DataGridViewTextBoxColumn
    Friend WithEvents TempMax As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents KgxHzPelet1 As DataGridViewTextBoxColumn
    Friend WithEvents KgxHzPelet2 As DataGridViewTextBoxColumn
    Friend WithEvents KgxHzPelet3 As DataGridViewTextBoxColumn
    Friend WithEvents PorcMerma As DataGridViewTextBoxColumn
    Friend WithEvents LineaExterna As DataGridViewCheckBoxColumn
    Friend WithEvents DiasVenc As DataGridViewTextBoxColumn
    Friend WithEvents Present As DataGridViewTextBoxColumn
End Class
