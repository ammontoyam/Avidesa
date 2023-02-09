<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TMuertos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TMuertos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TID = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.TObservacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TMotivo = New System.Windows.Forms.TextBox()
        Me.TCodMotivo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TTiempo = New System.Windows.Forms.TextBox()
        Me.TUsuario = New System.Windows.Forms.TextBox()
        Me.TFecha = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BNuevo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.BActualizar = New System.Windows.Forms.ToolStripButton()
        Me.GBNuevoMot = New System.Windows.Forms.GroupBox()
        Me.BCancelar2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BAceptar2 = New System.Windows.Forms.Button()
        Me.TMotivo2 = New System.Windows.Forms.TextBox()
        Me.TCodMotivo2 = New System.Windows.Forms.TextBox()
        Me.DGMotivos = New System.Windows.Forms.DataGridView()
        Me.DGMotivos_CodMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGMotivos_Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGTMuertos = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.GBNuevoMot.SuspendLayout()
        CType(Me.DGMotivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGTMuertos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(767, 25)
        Me.ToolStrip1.TabIndex = 28
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
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.OtrosToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(767, 24)
        Me.MenuStrip1.TabIndex = 29
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
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
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TID)
        Me.Panel1.Controls.Add(Me.BCancelar)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Controls.Add(Me.TObservacion)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TMotivo)
        Me.Panel1.Controls.Add(Me.TCodMotivo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TTiempo)
        Me.Panel1.Controls.Add(Me.TUsuario)
        Me.Panel1.Controls.Add(Me.TFecha)
        Me.Panel1.Location = New System.Drawing.Point(12, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 312)
        Me.Panel1.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 14)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "ID"
        Me.Label8.Visible = False
        '
        'TID
        '
        Me.TID.Location = New System.Drawing.Point(88, 0)
        Me.TID.Name = "TID"
        Me.TID.Size = New System.Drawing.Size(120, 20)
        Me.TID.TabIndex = 1
        Me.TID.Visible = False
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(162, 277)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar.TabIndex = 13
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(121, 277)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 12
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'TObservacion
        '
        Me.TObservacion.Location = New System.Drawing.Point(23, 206)
        Me.TObservacion.MaxLength = 100
        Me.TObservacion.Multiline = True
        Me.TObservacion.Name = "TObservacion"
        Me.TObservacion.Size = New System.Drawing.Size(279, 66)
        Me.TObservacion.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 14)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Observaciones"
        '
        'TMotivo
        '
        Me.TMotivo.Location = New System.Drawing.Point(23, 146)
        Me.TMotivo.Name = "TMotivo"
        Me.TMotivo.Size = New System.Drawing.Size(279, 20)
        Me.TMotivo.TabIndex = 6
        '
        'TCodMotivo
        '
        Me.TCodMotivo.Location = New System.Drawing.Point(86, 113)
        Me.TCodMotivo.Name = "TCodMotivo"
        Me.TCodMotivo.Size = New System.Drawing.Size(126, 20)
        Me.TCodMotivo.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Motivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Minutos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Usuario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha"
        '
        'TTiempo
        '
        Me.TTiempo.Location = New System.Drawing.Point(85, 79)
        Me.TTiempo.Name = "TTiempo"
        Me.TTiempo.Size = New System.Drawing.Size(126, 20)
        Me.TTiempo.TabIndex = 4
        '
        'TUsuario
        '
        Me.TUsuario.Location = New System.Drawing.Point(86, 51)
        Me.TUsuario.Name = "TUsuario"
        Me.TUsuario.Size = New System.Drawing.Size(126, 20)
        Me.TUsuario.TabIndex = 3
        '
        'TFecha
        '
        Me.TFecha.Location = New System.Drawing.Point(86, 23)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.Size = New System.Drawing.Size(126, 20)
        Me.TFecha.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ToolStrip2)
        Me.GroupBox1.Controls.Add(Me.GBNuevoMot)
        Me.GroupBox1.Controls.Add(Me.DGMotivos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 383)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(734, 292)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Motivos"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BNuevo, Me.ToolStripSeparator16, Me.BEditar, Me.ToolStripSeparator17, Me.BBorrar, Me.ToolStripSeparator18, Me.BActualizar})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(728, 25)
        Me.ToolStrip2.TabIndex = 29
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'BNuevo
        '
        Me.BNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BNuevo.Image = CType(resources.GetObject("BNuevo.Image"), System.Drawing.Image)
        Me.BNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(23, 22)
        Me.BNuevo.Text = "Nuevo"
        Me.BNuevo.ToolTipText = "Nuevo Motivo"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'BEditar
        '
        Me.BEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEditar.Image = CType(resources.GetObject("BEditar.Image"), System.Drawing.Image)
        Me.BEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEditar.Name = "BEditar"
        Me.BEditar.Size = New System.Drawing.Size(23, 22)
        Me.BEditar.Text = "Editar"
        Me.BEditar.ToolTipText = "Editar Motivo"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'BBorrar
        '
        Me.BBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBorrar.Image = CType(resources.GetObject("BBorrar.Image"), System.Drawing.Image)
        Me.BBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBorrar.Name = "BBorrar"
        Me.BBorrar.Size = New System.Drawing.Size(23, 22)
        Me.BBorrar.Text = "Borrar"
        Me.BBorrar.ToolTipText = "Borrar Motivo"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
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
        'GBNuevoMot
        '
        Me.GBNuevoMot.Controls.Add(Me.BCancelar2)
        Me.GBNuevoMot.Controls.Add(Me.Label2)
        Me.GBNuevoMot.Controls.Add(Me.Label1)
        Me.GBNuevoMot.Controls.Add(Me.BAceptar2)
        Me.GBNuevoMot.Controls.Add(Me.TMotivo2)
        Me.GBNuevoMot.Controls.Add(Me.TCodMotivo2)
        Me.GBNuevoMot.Location = New System.Drawing.Point(26, 227)
        Me.GBNuevoMot.Name = "GBNuevoMot"
        Me.GBNuevoMot.Size = New System.Drawing.Size(700, 56)
        Me.GBNuevoMot.TabIndex = 1
        Me.GBNuevoMot.TabStop = False
        Me.GBNuevoMot.Visible = False
        '
        'BCancelar2
        '
        Me.BCancelar2.Image = CType(resources.GetObject("BCancelar2.Image"), System.Drawing.Image)
        Me.BCancelar2.Location = New System.Drawing.Point(553, 21)
        Me.BCancelar2.Name = "BCancelar2"
        Me.BCancelar2.Size = New System.Drawing.Size(35, 31)
        Me.BCancelar2.TabIndex = 20
        Me.BCancelar2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Motivo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Código"
        '
        'BAceptar2
        '
        Me.BAceptar2.Image = CType(resources.GetObject("BAceptar2.Image"), System.Drawing.Image)
        Me.BAceptar2.Location = New System.Drawing.Point(518, 21)
        Me.BAceptar2.Name = "BAceptar2"
        Me.BAceptar2.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar2.TabIndex = 17
        Me.BAceptar2.UseVisualStyleBackColor = True
        '
        'TMotivo2
        '
        Me.TMotivo2.Location = New System.Drawing.Point(57, 32)
        Me.TMotivo2.Name = "TMotivo2"
        Me.TMotivo2.Size = New System.Drawing.Size(455, 20)
        Me.TMotivo2.TabIndex = 16
        '
        'TCodMotivo2
        '
        Me.TCodMotivo2.Location = New System.Drawing.Point(58, 8)
        Me.TCodMotivo2.Name = "TCodMotivo2"
        Me.TCodMotivo2.Size = New System.Drawing.Size(100, 20)
        Me.TCodMotivo2.TabIndex = 15
        '
        'DGMotivos
        '
        Me.DGMotivos.AllowUserToAddRows = False
        Me.DGMotivos.AllowUserToDeleteRows = False
        Me.DGMotivos.AllowUserToResizeRows = False
        Me.DGMotivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGMotivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGMotivos_CodMotivo, Me.DGMotivos_Motivo})
        Me.DGMotivos.Location = New System.Drawing.Point(23, 47)
        Me.DGMotivos.Name = "DGMotivos"
        Me.DGMotivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGMotivos.Size = New System.Drawing.Size(703, 175)
        Me.DGMotivos.TabIndex = 0
        '
        'DGMotivos_CodMotivo
        '
        Me.DGMotivos_CodMotivo.HeaderText = "Código"
        Me.DGMotivos_CodMotivo.Name = "DGMotivos_CodMotivo"
        '
        'DGMotivos_Motivo
        '
        Me.DGMotivos_Motivo.HeaderText = "Motivo"
        Me.DGMotivos_Motivo.Name = "DGMotivos_Motivo"
        Me.DGMotivos_Motivo.Width = 535
        '
        'DGTMuertos
        '
        Me.DGTMuertos.AllowUserToAddRows = False
        Me.DGTMuertos.AllowUserToDeleteRows = False
        Me.DGTMuertos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTMuertos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.Usuario, Me.Tiempo, Me.Proceso, Me.ID})
        Me.DGTMuertos.Location = New System.Drawing.Point(335, 66)
        Me.DGTMuertos.MultiSelect = False
        Me.DGTMuertos.Name = "DGTMuertos"
        Me.DGTMuertos.ReadOnly = True
        Me.DGTMuertos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGTMuertos.Size = New System.Drawing.Size(426, 310)
        Me.DGTMuertos.TabIndex = 42
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Usuario
        '
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        '
        'Tiempo
        '
        Me.Tiempo.HeaderText = "Tiempo"
        Me.Tiempo.Name = "Tiempo"
        Me.Tiempo.ReadOnly = True
        Me.Tiempo.Width = 50
        '
        'Proceso
        '
        Me.Proceso.HeaderText = "Proceso"
        Me.Proceso.Name = "Proceso"
        Me.Proceso.ReadOnly = True
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'TMuertos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 678)
        Me.Controls.Add(Me.DGTMuertos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TMuertos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tiempos Muertos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GBNuevoMot.ResumeLayout(False)
        Me.GBNuevoMot.PerformLayout()
        CType(Me.DGMotivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGTMuertos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TMotivo As System.Windows.Forms.TextBox
    Friend WithEvents TCodMotivo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TTiempo As System.Windows.Forms.TextBox
    Friend WithEvents TUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TFecha As System.Windows.Forms.TextBox
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGMotivos As System.Windows.Forms.DataGridView
    Friend WithEvents DGMotivos_CodMotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGMotivos_Motivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GBNuevoMot As System.Windows.Forms.GroupBox
    Friend WithEvents BCancelar2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BAceptar2 As System.Windows.Forms.Button
    Friend WithEvents TMotivo2 As System.Windows.Forms.TextBox
    Friend WithEvents TCodMotivo2 As System.Windows.Forms.TextBox
    Friend WithEvents DGTMuertos As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proceso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BActualizar As System.Windows.Forms.ToolStripButton
End Class
