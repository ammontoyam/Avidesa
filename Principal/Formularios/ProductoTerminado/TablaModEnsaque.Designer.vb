<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TablaModEnsaque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TablaModEnsaque))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TNomForm = New System.Windows.Forms.TextBox()
        Me.TCodForm = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BFCambiar = New System.Windows.Forms.Button()
        Me.TSacosDev = New System.Windows.Forms.TextBox()
        Me.TPesoDev = New System.Windows.Forms.TextBox()
        Me.TCodHilaza = New System.Windows.Forms.TextBox()
        Me.TCodEtiqueta = New System.Windows.Forms.TextBox()
        Me.TCodEmpaque = New System.Windows.Forms.TextBox()
        Me.TResiduo = New System.Windows.Forms.TextBox()
        Me.TFecha = New System.Windows.Forms.TextBox()
        Me.TPromedio = New System.Windows.Forms.TextBox()
        Me.TPeso = New System.Windows.Forms.TextBox()
        Me.TSacos = New System.Windows.Forms.TextBox()
        Me.TPresentacion = New System.Windows.Forms.TextBox()
        Me.TNomProducto = New System.Windows.Forms.TextBox()
        Me.TCodProducto = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TMaquina = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TOP = New System.Windows.Forms.TextBox()
        Me.TConsecutivo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TOrdDespacho = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TContador = New System.Windows.Forms.TextBox()
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TNomForm)
        Me.Panel1.Controls.Add(Me.TCodForm)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.BFCambiar)
        Me.Panel1.Controls.Add(Me.TSacosDev)
        Me.Panel1.Controls.Add(Me.TPesoDev)
        Me.Panel1.Controls.Add(Me.TCodHilaza)
        Me.Panel1.Controls.Add(Me.TCodEtiqueta)
        Me.Panel1.Controls.Add(Me.TCodEmpaque)
        Me.Panel1.Controls.Add(Me.TResiduo)
        Me.Panel1.Controls.Add(Me.TFecha)
        Me.Panel1.Controls.Add(Me.TPromedio)
        Me.Panel1.Controls.Add(Me.TPeso)
        Me.Panel1.Controls.Add(Me.TSacos)
        Me.Panel1.Controls.Add(Me.TPresentacion)
        Me.Panel1.Controls.Add(Me.TNomProducto)
        Me.Panel1.Controls.Add(Me.TCodProducto)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TMaquina)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TOP)
        Me.Panel1.Controls.Add(Me.TConsecutivo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TOrdDespacho)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TContador)
        Me.Panel1.Controls.Add(Me.BAceptar)
        Me.Panel1.Location = New System.Drawing.Point(3, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(343, 538)
        Me.Panel1.TabIndex = 29
        '
        'TNomForm
        '
        Me.TNomForm.Location = New System.Drawing.Point(116, 169)
        Me.TNomForm.Name = "TNomForm"
        Me.TNomForm.ReadOnly = True
        Me.TNomForm.Size = New System.Drawing.Size(97, 20)
        Me.TNomForm.TabIndex = 57
        '
        'TCodForm
        '
        Me.TCodForm.Location = New System.Drawing.Point(116, 144)
        Me.TCodForm.Name = "TCodForm"
        Me.TCodForm.ReadOnly = True
        Me.TCodForm.Size = New System.Drawing.Size(97, 20)
        Me.TCodForm.TabIndex = 56
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(17, 172)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 14)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Nomb. Fórmula:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(17, 147)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 14)
        Me.Label20.TabIndex = 54
        Me.Label20.Text = "Cóf. Fórmula:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BFCambiar
        '
        Me.BFCambiar.Location = New System.Drawing.Point(260, 147)
        Me.BFCambiar.Name = "BFCambiar"
        Me.BFCambiar.Size = New System.Drawing.Size(73, 21)
        Me.BFCambiar.TabIndex = 53
        Me.BFCambiar.Text = "FCambiar"
        Me.BFCambiar.UseVisualStyleBackColor = True
        Me.BFCambiar.Visible = False
        '
        'TSacosDev
        '
        Me.TSacosDev.Location = New System.Drawing.Point(116, 469)
        Me.TSacosDev.Name = "TSacosDev"
        Me.TSacosDev.Size = New System.Drawing.Size(97, 20)
        Me.TSacosDev.TabIndex = 52
        '
        'TPesoDev
        '
        Me.TPesoDev.Location = New System.Drawing.Point(116, 494)
        Me.TPesoDev.Name = "TPesoDev"
        Me.TPesoDev.ReadOnly = True
        Me.TPesoDev.Size = New System.Drawing.Size(97, 20)
        Me.TPesoDev.TabIndex = 51
        '
        'TCodHilaza
        '
        Me.TCodHilaza.Location = New System.Drawing.Point(116, 444)
        Me.TCodHilaza.Name = "TCodHilaza"
        Me.TCodHilaza.ReadOnly = True
        Me.TCodHilaza.Size = New System.Drawing.Size(97, 20)
        Me.TCodHilaza.TabIndex = 50
        '
        'TCodEtiqueta
        '
        Me.TCodEtiqueta.Location = New System.Drawing.Point(116, 419)
        Me.TCodEtiqueta.Name = "TCodEtiqueta"
        Me.TCodEtiqueta.ReadOnly = True
        Me.TCodEtiqueta.Size = New System.Drawing.Size(97, 20)
        Me.TCodEtiqueta.TabIndex = 49
        '
        'TCodEmpaque
        '
        Me.TCodEmpaque.Location = New System.Drawing.Point(116, 394)
        Me.TCodEmpaque.Name = "TCodEmpaque"
        Me.TCodEmpaque.ReadOnly = True
        Me.TCodEmpaque.Size = New System.Drawing.Size(97, 20)
        Me.TCodEmpaque.TabIndex = 48
        '
        'TResiduo
        '
        Me.TResiduo.Location = New System.Drawing.Point(116, 344)
        Me.TResiduo.Name = "TResiduo"
        Me.TResiduo.Size = New System.Drawing.Size(97, 20)
        Me.TResiduo.TabIndex = 47
        '
        'TFecha
        '
        Me.TFecha.Location = New System.Drawing.Point(116, 369)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.ReadOnly = True
        Me.TFecha.Size = New System.Drawing.Size(161, 20)
        Me.TFecha.TabIndex = 46
        '
        'TPromedio
        '
        Me.TPromedio.Location = New System.Drawing.Point(116, 319)
        Me.TPromedio.Name = "TPromedio"
        Me.TPromedio.Size = New System.Drawing.Size(97, 20)
        Me.TPromedio.TabIndex = 45
        '
        'TPeso
        '
        Me.TPeso.Location = New System.Drawing.Point(116, 294)
        Me.TPeso.Name = "TPeso"
        Me.TPeso.Size = New System.Drawing.Size(97, 20)
        Me.TPeso.TabIndex = 44
        '
        'TSacos
        '
        Me.TSacos.Location = New System.Drawing.Point(116, 244)
        Me.TSacos.Name = "TSacos"
        Me.TSacos.ReadOnly = True
        Me.TSacos.Size = New System.Drawing.Size(97, 20)
        Me.TSacos.TabIndex = 43
        '
        'TPresentacion
        '
        Me.TPresentacion.Location = New System.Drawing.Point(116, 269)
        Me.TPresentacion.Name = "TPresentacion"
        Me.TPresentacion.ReadOnly = True
        Me.TPresentacion.Size = New System.Drawing.Size(97, 20)
        Me.TPresentacion.TabIndex = 42
        '
        'TNomProducto
        '
        Me.TNomProducto.Location = New System.Drawing.Point(116, 219)
        Me.TNomProducto.Name = "TNomProducto"
        Me.TNomProducto.ReadOnly = True
        Me.TNomProducto.Size = New System.Drawing.Size(214, 20)
        Me.TNomProducto.TabIndex = 41
        '
        'TCodProducto
        '
        Me.TCodProducto.Location = New System.Drawing.Point(116, 194)
        Me.TCodProducto.Name = "TCodProducto"
        Me.TCodProducto.ReadOnly = True
        Me.TCodProducto.Size = New System.Drawing.Size(97, 20)
        Me.TCodProducto.TabIndex = 40
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(17, 497)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 14)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Peso Dev.:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(17, 472)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 14)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "Sacos Dev.:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(17, 447)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 14)
        Me.Label14.TabIndex = 37
        Me.Label14.Text = "Hilaza:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(17, 422)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 14)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Etiqueta:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(17, 372)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 14)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Fecha:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(17, 397)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 14)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Empaque:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(17, 347)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 14)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Residuo:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(17, 322)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 14)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Promedio:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(17, 297)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 14)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Peso:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(17, 272)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 14)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Presentación:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(17, 247)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 14)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Sacos:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(17, 222)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 14)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Producto:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(17, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 14)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Cód. Producto:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TMaquina
        '
        Me.TMaquina.Location = New System.Drawing.Point(116, 94)
        Me.TMaquina.Name = "TMaquina"
        Me.TMaquina.Size = New System.Drawing.Size(97, 20)
        Me.TMaquina.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Maquina:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(17, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "OP:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TOP
        '
        Me.TOP.Location = New System.Drawing.Point(116, 119)
        Me.TOP.Name = "TOP"
        Me.TOP.Size = New System.Drawing.Size(97, 20)
        Me.TOP.TabIndex = 23
        '
        'TConsecutivo
        '
        Me.TConsecutivo.Location = New System.Drawing.Point(116, 69)
        Me.TConsecutivo.Name = "TConsecutivo"
        Me.TConsecutivo.ReadOnly = True
        Me.TConsecutivo.Size = New System.Drawing.Size(97, 20)
        Me.TConsecutivo.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(17, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 14)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Consecutivo:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TOrdDespacho
        '
        Me.TOrdDespacho.Location = New System.Drawing.Point(144, 44)
        Me.TOrdDespacho.Name = "TOrdDespacho"
        Me.TOrdDespacho.ReadOnly = True
        Me.TOrdDespacho.Size = New System.Drawing.Size(103, 20)
        Me.TOrdDespacho.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Ordén de Despacho:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(17, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 14)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Contador:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TContador
        '
        Me.TContador.Location = New System.Drawing.Point(116, 19)
        Me.TContador.Name = "TContador"
        Me.TContador.ReadOnly = True
        Me.TContador.Size = New System.Drawing.Size(97, 20)
        Me.TContador.TabIndex = 1
        '
        'BAceptar
        '
        Me.BAceptar.Image = CType(resources.GetObject("BAceptar.Image"), System.Drawing.Image)
        Me.BAceptar.Location = New System.Drawing.Point(297, 496)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(35, 31)
        Me.BAceptar.TabIndex = 4
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(358, 25)
        Me.ToolStrip1.TabIndex = 32
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
        'TablaModEnsaque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 589)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TablaModEnsaque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar registro de ensaque"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TConsecutivo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TOrdDespacho As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TContador As System.Windows.Forms.TextBox
    Friend WithEvents BAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label5 As Label
    Friend WithEvents TOP As TextBox
    Friend WithEvents TMaquina As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TSacosDev As TextBox
    Friend WithEvents TPesoDev As TextBox
    Friend WithEvents TCodHilaza As TextBox
    Friend WithEvents TCodEtiqueta As TextBox
    Friend WithEvents TCodEmpaque As TextBox
    Friend WithEvents TResiduo As TextBox
    Friend WithEvents TFecha As TextBox
    Friend WithEvents TPromedio As TextBox
    Friend WithEvents TPeso As TextBox
    Friend WithEvents TSacos As TextBox
    Friend WithEvents TPresentacion As TextBox
    Friend WithEvents TNomProducto As TextBox
    Friend WithEvents TCodProducto As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BFCambiar As Button
    Friend WithEvents TNomForm As TextBox
    Friend WithEvents TCodForm As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label20 As Label
End Class
