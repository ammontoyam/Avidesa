<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Auditoria
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Auditoria))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EventosLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEventosLog = New ChronoSoftNet.DsEventosLog()
        Me.EventosLogTableAdapter = New ChronoSoftNet.DsEventosLogTableAdapters.EventosLogTableAdapter()
        Me.GBFiltrar = New System.Windows.Forms.GroupBox()
        Me.TDetalle = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TValor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CCampo = New System.Windows.Forms.ComboBox()
        Me.BReporte = New System.Windows.Forms.Button()
        Me.BNuevaConsulta = New System.Windows.Forms.Button()
        Me.BCDate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.THoraIni = New System.Windows.Forms.DateTimePicker()
        Me.TFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.THoraFin = New System.Windows.Forms.DateTimePicker()
        Me.TFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.CAccion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CModulo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CUsuario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BFiltrar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.TcLogEventos = New System.Windows.Forms.TabControl()
        Me.TpDatos = New System.Windows.Forms.TabPage()
        Me.DGIntFazEventos = New System.Windows.Forms.DataGridView()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tabla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Campo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombrePC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rpLogEventos = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.EventosLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEventosLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBFiltrar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TcLogEventos.SuspendLayout()
        Me.TpDatos.SuspendLayout()
        CType(Me.DGIntFazEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'EventosLogBindingSource
        '
        Me.EventosLogBindingSource.DataMember = "EventosLog"
        Me.EventosLogBindingSource.DataSource = Me.DsEventosLog
        '
        'DsEventosLog
        '
        Me.DsEventosLog.DataSetName = "DsEventosLog"
        Me.DsEventosLog.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EventosLogTableAdapter
        '
        Me.EventosLogTableAdapter.ClearBeforeFill = True
        '
        'GBFiltrar
        '
        Me.GBFiltrar.Controls.Add(Me.TDetalle)
        Me.GBFiltrar.Controls.Add(Me.Label6)
        Me.GBFiltrar.Controls.Add(Me.Label5)
        Me.GBFiltrar.Controls.Add(Me.TValor)
        Me.GBFiltrar.Controls.Add(Me.Label2)
        Me.GBFiltrar.Controls.Add(Me.CCampo)
        Me.GBFiltrar.Controls.Add(Me.BReporte)
        Me.GBFiltrar.Controls.Add(Me.BNuevaConsulta)
        Me.GBFiltrar.Controls.Add(Me.BCDate)
        Me.GBFiltrar.Controls.Add(Me.GroupBox1)
        Me.GBFiltrar.Controls.Add(Me.GroupBox2)
        Me.GBFiltrar.Controls.Add(Me.CAccion)
        Me.GBFiltrar.Controls.Add(Me.Label4)
        Me.GBFiltrar.Controls.Add(Me.CModulo)
        Me.GBFiltrar.Controls.Add(Me.Label3)
        Me.GBFiltrar.Controls.Add(Me.CUsuario)
        Me.GBFiltrar.Controls.Add(Me.Label1)
        Me.GBFiltrar.Controls.Add(Me.BFiltrar)
        Me.GBFiltrar.Dock = System.Windows.Forms.DockStyle.Top
        Me.GBFiltrar.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBFiltrar.Location = New System.Drawing.Point(0, 25)
        Me.GBFiltrar.Name = "GBFiltrar"
        Me.GBFiltrar.Size = New System.Drawing.Size(1350, 96)
        Me.GBFiltrar.TabIndex = 2
        Me.GBFiltrar.TabStop = False
        Me.GBFiltrar.Text = "Filtrar"
        '
        'TDetalle
        '
        Me.TDetalle.Location = New System.Drawing.Point(804, 58)
        Me.TDetalle.Name = "TDetalle"
        Me.TDetalle.Size = New System.Drawing.Size(374, 20)
        Me.TDetalle.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(758, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Detalle:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(520, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Valor:"
        '
        'TValor
        '
        Me.TValor.Location = New System.Drawing.Point(573, 58)
        Me.TValor.Name = "TValor"
        Me.TValor.Size = New System.Drawing.Size(176, 20)
        Me.TValor.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Campo:"
        '
        'CCampo
        '
        Me.CCampo.FormattingEnabled = True
        Me.CCampo.Location = New System.Drawing.Point(332, 57)
        Me.CCampo.Name = "CCampo"
        Me.CCampo.Size = New System.Drawing.Size(176, 22)
        Me.CCampo.Sorted = True
        Me.CCampo.TabIndex = 9
        '
        'BReporte
        '
        Me.BReporte.Image = CType(resources.GetObject("BReporte.Image"), System.Drawing.Image)
        Me.BReporte.Location = New System.Drawing.Point(1228, 11)
        Me.BReporte.Name = "BReporte"
        Me.BReporte.Size = New System.Drawing.Size(48, 37)
        Me.BReporte.TabIndex = 15
        Me.BReporte.UseVisualStyleBackColor = True
        '
        'BNuevaConsulta
        '
        Me.BNuevaConsulta.Image = CType(resources.GetObject("BNuevaConsulta.Image"), System.Drawing.Image)
        Me.BNuevaConsulta.Location = New System.Drawing.Point(1282, 11)
        Me.BNuevaConsulta.Name = "BNuevaConsulta"
        Me.BNuevaConsulta.Size = New System.Drawing.Size(48, 37)
        Me.BNuevaConsulta.TabIndex = 16
        Me.BNuevaConsulta.UseVisualStyleBackColor = True
        '
        'BCDate
        '
        Me.BCDate.Location = New System.Drawing.Point(1341, 17)
        Me.BCDate.Name = "BCDate"
        Me.BCDate.Size = New System.Drawing.Size(75, 23)
        Me.BCDate.TabIndex = 134
        Me.BCDate.Text = "BCDate"
        Me.BCDate.UseVisualStyleBackColor = True
        Me.BCDate.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.THoraIni)
        Me.GroupBox1.Controls.Add(Me.TFechaIni)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(46, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 42)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Desde:"
        '
        'THoraIni
        '
        Me.THoraIni.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.THoraIni.CustomFormat = "HH:mm"
        Me.THoraIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.THoraIni.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.THoraIni.Location = New System.Drawing.Point(136, 14)
        Me.THoraIni.Name = "THoraIni"
        Me.THoraIni.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.THoraIni.ShowUpDown = True
        Me.THoraIni.Size = New System.Drawing.Size(55, 20)
        Me.THoraIni.TabIndex = 1
        '
        'TFechaIni
        '
        Me.TFechaIni.CustomFormat = "yyyy/MM/dd"
        Me.TFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TFechaIni.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TFechaIni.Location = New System.Drawing.Point(48, 14)
        Me.TFechaIni.Name = "TFechaIni"
        Me.TFechaIni.Size = New System.Drawing.Size(82, 20)
        Me.TFechaIni.TabIndex = 0
        Me.TFechaIni.Value = New Date(2011, 12, 5, 0, 0, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.THoraFin)
        Me.GroupBox2.Controls.Add(Me.TFechaFin)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(46, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 42)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hasta:"
        '
        'THoraFin
        '
        Me.THoraFin.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.THoraFin.CustomFormat = "HH:mm"
        Me.THoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.THoraFin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.THoraFin.Location = New System.Drawing.Point(136, 14)
        Me.THoraFin.Name = "THoraFin"
        Me.THoraFin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.THoraFin.ShowUpDown = True
        Me.THoraFin.Size = New System.Drawing.Size(55, 20)
        Me.THoraFin.TabIndex = 1
        Me.THoraFin.Value = New Date(2008, 12, 29, 0, 0, 0, 0)
        '
        'TFechaFin
        '
        Me.TFechaFin.CustomFormat = "yyyy/MM/dd"
        Me.TFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TFechaFin.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TFechaFin.Location = New System.Drawing.Point(48, 14)
        Me.TFechaFin.Name = "TFechaFin"
        Me.TFechaFin.Size = New System.Drawing.Size(82, 20)
        Me.TFechaFin.TabIndex = 0
        '
        'CAccion
        '
        Me.CAccion.FormattingEnabled = True
        Me.CAccion.Location = New System.Drawing.Point(804, 22)
        Me.CAccion.Name = "CAccion"
        Me.CAccion.Size = New System.Drawing.Size(148, 22)
        Me.CAccion.Sorted = True
        Me.CAccion.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(758, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Acción:"
        '
        'CModulo
        '
        Me.CModulo.FormattingEnabled = True
        Me.CModulo.Location = New System.Drawing.Point(573, 22)
        Me.CModulo.Name = "CModulo"
        Me.CModulo.Size = New System.Drawing.Size(176, 22)
        Me.CModulo.Sorted = True
        Me.CModulo.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(520, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Módulo:"
        '
        'CUsuario
        '
        Me.CUsuario.FormattingEnabled = True
        Me.CUsuario.Location = New System.Drawing.Point(332, 22)
        Me.CUsuario.Name = "CUsuario"
        Me.CUsuario.Size = New System.Drawing.Size(176, 22)
        Me.CUsuario.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(280, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Usuario:"
        '
        'BFiltrar
        '
        Me.BFiltrar.Image = CType(resources.GetObject("BFiltrar.Image"), System.Drawing.Image)
        Me.BFiltrar.Location = New System.Drawing.Point(1174, 11)
        Me.BFiltrar.Name = "BFiltrar"
        Me.BFiltrar.Size = New System.Drawing.Size(48, 37)
        Me.BFiltrar.TabIndex = 14
        Me.BFiltrar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1350, 25)
        Me.ToolStrip1.TabIndex = 1
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
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'TcLogEventos
        '
        Me.TcLogEventos.Controls.Add(Me.TpDatos)
        Me.TcLogEventos.Controls.Add(Me.TabPage2)
        Me.TcLogEventos.Location = New System.Drawing.Point(0, 147)
        Me.TcLogEventos.Name = "TcLogEventos"
        Me.TcLogEventos.SelectedIndex = 0
        Me.TcLogEventos.Size = New System.Drawing.Size(1350, 564)
        Me.TcLogEventos.TabIndex = 3
        '
        'TpDatos
        '
        Me.TpDatos.Controls.Add(Me.DGIntFazEventos)
        Me.TpDatos.Location = New System.Drawing.Point(4, 22)
        Me.TpDatos.Name = "TpDatos"
        Me.TpDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.TpDatos.Size = New System.Drawing.Size(1342, 538)
        Me.TpDatos.TabIndex = 0
        Me.TpDatos.Text = "Datos"
        Me.TpDatos.UseVisualStyleBackColor = True
        '
        'DGIntFazEventos
        '
        Me.DGIntFazEventos.AllowUserToAddRows = False
        Me.DGIntFazEventos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        Me.DGIntFazEventos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGIntFazEventos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGIntFazEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGIntFazEventos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fecha, Me.Usuario, Me.Modulo, Me.Accion, Me.Tabla, Me.Campo, Me.Valor, Me.Detalle, Me.NombrePC, Me.IP})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.NullValue = Nothing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGIntFazEventos.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGIntFazEventos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGIntFazEventos.Location = New System.Drawing.Point(3, 3)
        Me.DGIntFazEventos.Name = "DGIntFazEventos"
        Me.DGIntFazEventos.ReadOnly = True
        Me.DGIntFazEventos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGIntFazEventos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DGIntFazEventos.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DGIntFazEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGIntFazEventos.Size = New System.Drawing.Size(1336, 532)
        Me.DGIntFazEventos.TabIndex = 0
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha"
        Me.fecha.Name = "fecha"
        Me.fecha.ReadOnly = True
        Me.fecha.Width = 120
        '
        'Usuario
        '
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        '
        'Modulo
        '
        Me.Modulo.HeaderText = "Módulo"
        Me.Modulo.Name = "Modulo"
        Me.Modulo.ReadOnly = True
        Me.Modulo.Width = 120
        '
        'Accion
        '
        Me.Accion.HeaderText = "Accion"
        Me.Accion.Name = "Accion"
        Me.Accion.ReadOnly = True
        Me.Accion.Width = 80
        '
        'Tabla
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Tabla.DefaultCellStyle = DataGridViewCellStyle3
        Me.Tabla.HeaderText = "Tabla"
        Me.Tabla.Name = "Tabla"
        Me.Tabla.ReadOnly = True
        Me.Tabla.Width = 150
        '
        'Campo
        '
        Me.Campo.HeaderText = "Campo"
        Me.Campo.Name = "Campo"
        Me.Campo.ReadOnly = True
        Me.Campo.Width = 80
        '
        'Valor
        '
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        Me.Valor.Width = 150
        '
        'Detalle
        '
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ReadOnly = True
        Me.Detalle.Width = 600
        '
        'NombrePC
        '
        Me.NombrePC.HeaderText = "Equipo"
        Me.NombrePC.Name = "NombrePC"
        Me.NombrePC.ReadOnly = True
        '
        'IP
        '
        Me.IP.HeaderText = "Dirección IP"
        Me.IP.Name = "IP"
        Me.IP.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rpLogEventos)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1342, 538)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Reporte"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'rpLogEventos
        '
        Me.rpLogEventos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpLogEventos.LocalReport.ReportEmbeddedResource = "ChronoSoftNet.rpEventosLog.rdlc"
        Me.rpLogEventos.Location = New System.Drawing.Point(3, 3)
        Me.rpLogEventos.Name = "rpLogEventos"
        Me.rpLogEventos.ServerReport.BearerToken = Nothing
        Me.rpLogEventos.Size = New System.Drawing.Size(1336, 532)
        Me.rpLogEventos.TabIndex = 1
        '
        'Auditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 711)
        Me.Controls.Add(Me.TcLogEventos)
        Me.Controls.Add(Me.GBFiltrar)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Auditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auditoria Eventos de Usuario"
        CType(Me.EventosLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEventosLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBFiltrar.ResumeLayout(False)
        Me.GBFiltrar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TcLogEventos.ResumeLayout(False)
        Me.TpDatos.ResumeLayout(False)
        CType(Me.DGIntFazEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EventosLogBindingSource As BindingSource
    Friend WithEvents DsEventosLog As DsEventosLog
    Friend WithEvents EventosLogTableAdapter As DsEventosLogTableAdapters.EventosLogTableAdapter
    Friend WithEvents GBFiltrar As GroupBox
    Friend WithEvents TDetalle As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TValor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CCampo As ComboBox
    Friend WithEvents BReporte As Button
    Friend WithEvents BNuevaConsulta As Button
    Friend WithEvents BCDate As Button
    Friend WithEvents GroupBox1 As GroupBox
    Private WithEvents THoraIni As DateTimePicker
    Friend WithEvents TFechaIni As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Private WithEvents THoraFin As DateTimePicker
    Friend WithEvents TFechaFin As DateTimePicker
    Friend WithEvents CAccion As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CModulo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CUsuario As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BFiltrar As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents TcLogEventos As TabControl
    Friend WithEvents TpDatos As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents rpLogEventos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DGIntFazEventos As DataGridView
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
    Friend WithEvents Modulo As DataGridViewTextBoxColumn
    Friend WithEvents Accion As DataGridViewTextBoxColumn
    Friend WithEvents Tabla As DataGridViewTextBoxColumn
    Friend WithEvents Campo As DataGridViewTextBoxColumn
    Friend WithEvents Valor As DataGridViewTextBoxColumn
    Friend WithEvents Detalle As DataGridViewTextBoxColumn
    Friend WithEvents NombrePC As DataGridViewTextBoxColumn
    Friend WithEvents IP As DataGridViewTextBoxColumn
End Class
