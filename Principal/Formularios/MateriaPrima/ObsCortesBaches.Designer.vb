<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObsCortesBaches
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObsCortesBaches))
        Me.TObservaciones = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TLote = New System.Windows.Forms.TextBox()
        Me.TNomMat = New System.Windows.Forms.TextBox()
        Me.TCodMat = New System.Windows.Forms.TextBox()
        Me.BAceptarObsCorte = New System.Windows.Forms.Button()
        Me.TContCorte = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TDiferenciaKg = New System.Windows.Forms.TextBox()
        Me.ChCerrarUbicacion = New System.Windows.Forms.CheckBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.TContBache = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'TObservaciones
        '
        Me.TObservaciones.Location = New System.Drawing.Point(18, 228)
        Me.TObservaciones.Multiline = True
        Me.TObservaciones.Name = "TObservaciones"
        Me.TObservaciones.Size = New System.Drawing.Size(229, 77)
        Me.TObservaciones.TabIndex = 2
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(18, 209)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(93, 14)
        Me.Label41.TabIndex = 63
        Me.Label41.Text = "Observaciones:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(15, 166)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(97, 14)
        Me.Label40.TabIndex = 62
        Me.Label40.Text = "Contador Bache:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(15, 139)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(35, 14)
        Me.Label37.TabIndex = 60
        Me.Label37.Text = "Lote:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(15, 116)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(54, 14)
        Me.Label38.TabIndex = 59
        Me.Label38.Text = "Nombre:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label39.Location = New System.Drawing.Point(15, 94)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(52, 14)
        Me.Label39.TabIndex = 58
        Me.Label39.Text = "CodMat:"
        '
        'TLote
        '
        Me.TLote.Location = New System.Drawing.Point(56, 136)
        Me.TLote.Name = "TLote"
        Me.TLote.ReadOnly = True
        Me.TLote.Size = New System.Drawing.Size(77, 20)
        Me.TLote.TabIndex = 4
        '
        'TNomMat
        '
        Me.TNomMat.Location = New System.Drawing.Point(71, 113)
        Me.TNomMat.Name = "TNomMat"
        Me.TNomMat.ReadOnly = True
        Me.TNomMat.Size = New System.Drawing.Size(236, 20)
        Me.TNomMat.TabIndex = 30
        '
        'TCodMat
        '
        Me.TCodMat.Location = New System.Drawing.Point(71, 88)
        Me.TCodMat.Name = "TCodMat"
        Me.TCodMat.ReadOnly = True
        Me.TCodMat.Size = New System.Drawing.Size(57, 20)
        Me.TCodMat.TabIndex = 10
        '
        'BAceptarObsCorte
        '
        Me.BAceptarObsCorte.Image = CType(resources.GetObject("BAceptarObsCorte.Image"), System.Drawing.Image)
        Me.BAceptarObsCorte.Location = New System.Drawing.Point(254, 228)
        Me.BAceptarObsCorte.Name = "BAceptarObsCorte"
        Me.BAceptarObsCorte.Size = New System.Drawing.Size(53, 31)
        Me.BAceptarObsCorte.TabIndex = 3
        Me.BAceptarObsCorte.UseVisualStyleBackColor = True
        '
        'TContCorte
        '
        Me.TContCorte.Location = New System.Drawing.Point(151, 87)
        Me.TContCorte.Name = "TContCorte"
        Me.TContCorte.ReadOnly = True
        Me.TContCorte.Size = New System.Drawing.Size(96, 20)
        Me.TContCorte.TabIndex = 20
        Me.TContCorte.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 61)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(142, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 14)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Diferencia Kg:"
        '
        'TDiferenciaKg
        '
        Me.TDiferenciaKg.Location = New System.Drawing.Point(230, 136)
        Me.TDiferenciaKg.Name = "TDiferenciaKg"
        Me.TDiferenciaKg.ReadOnly = True
        Me.TDiferenciaKg.Size = New System.Drawing.Size(77, 20)
        Me.TDiferenciaKg.TabIndex = 5
        '
        'ChCerrarUbicacion
        '
        Me.ChCerrarUbicacion.AutoSize = True
        Me.ChCerrarUbicacion.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChCerrarUbicacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChCerrarUbicacion.Location = New System.Drawing.Point(158, 191)
        Me.ChCerrarUbicacion.Name = "ChCerrarUbicacion"
        Me.ChCerrarUbicacion.Size = New System.Drawing.Size(160, 27)
        Me.ChCerrarUbicacion.TabIndex = 68
        Me.ChCerrarUbicacion.Text = "Cerrar Ubicación "
        Me.ChCerrarUbicacion.UseVisualStyleBackColor = True
        '
        'BCancelar
        '
        Me.BCancelar.Image = CType(resources.GetObject("BCancelar.Image"), System.Drawing.Image)
        Me.BCancelar.Location = New System.Drawing.Point(254, 274)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(53, 31)
        Me.BCancelar.TabIndex = 69
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'TContBache
        '
        Me.TContBache.FormattingEnabled = True
        Me.TContBache.Location = New System.Drawing.Point(118, 162)
        Me.TContBache.Name = "TContBache"
        Me.TContBache.Size = New System.Drawing.Size(121, 21)
        Me.TContBache.TabIndex = 70
        '
        'ObsCortesBaches
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 309)
        Me.ControlBox = False
        Me.Controls.Add(Me.TContBache)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.ChCerrarUbicacion)
        Me.Controls.Add(Me.TDiferenciaKg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TContCorte)
        Me.Controls.Add(Me.TObservaciones)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.TLote)
        Me.Controls.Add(Me.TNomMat)
        Me.Controls.Add(Me.TCodMat)
        Me.Controls.Add(Me.BAceptarObsCorte)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ObsCortesBaches"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Observaciones Interfaz Costos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TLote As System.Windows.Forms.TextBox
    Friend WithEvents TNomMat As System.Windows.Forms.TextBox
    Friend WithEvents TCodMat As System.Windows.Forms.TextBox
    Friend WithEvents BAceptarObsCorte As System.Windows.Forms.Button
    Friend WithEvents TContCorte As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TDiferenciaKg As System.Windows.Forms.TextBox
    Friend WithEvents ChCerrarUbicacion As CheckBox
    Friend WithEvents BCancelar As Button
    Friend WithEvents TContBache As ComboBox
End Class
