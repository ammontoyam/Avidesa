<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServPLC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServPLC))
        Me.BLeer1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TValorLeido1 = New System.Windows.Forms.TextBox()
        Me.TValorEscribir1 = New System.Windows.Forms.TextBox()
        Me.BEscribir1 = New System.Windows.Forms.Button()
        Me.TimScan = New System.Windows.Forms.Timer(Me.components)
        Me.TSeg = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TError = New System.Windows.Forms.TextBox()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.Tip = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BConectar = New System.Windows.Forms.Button()
        Me.TMetaMin1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TMetaMax1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TJogsMax1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TAFina1 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TVelG1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TVelF1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TOutput1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TStart1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TNeto1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TBruto1 = New System.Windows.Forms.TextBox()
        Me.TSegToPLC = New System.Windows.Forms.TextBox()
        Me.TEstado1 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TRecAlarma1 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TBacheListo1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TMeta1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TBaches = New System.Windows.Forms.TextBox()
        Me.TBache = New System.Windows.Forms.TextBox()
        Me.TNomFor = New System.Windows.Forms.TextBox()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.TCodFor = New System.Windows.Forms.TextBox()
        Me.TMeta2 = New System.Windows.Forms.TextBox()
        Me.TBacheListo2 = New System.Windows.Forms.TextBox()
        Me.TRecAlarma2 = New System.Windows.Forms.TextBox()
        Me.TEstado2 = New System.Windows.Forms.TextBox()
        Me.TBruto2 = New System.Windows.Forms.TextBox()
        Me.TNeto2 = New System.Windows.Forms.TextBox()
        Me.TStart2 = New System.Windows.Forms.TextBox()
        Me.TOutput2 = New System.Windows.Forms.TextBox()
        Me.TVelF2 = New System.Windows.Forms.TextBox()
        Me.TVelG2 = New System.Windows.Forms.TextBox()
        Me.TAFina2 = New System.Windows.Forms.TextBox()
        Me.TJogsMax2 = New System.Windows.Forms.TextBox()
        Me.TMetaMax2 = New System.Windows.Forms.TextBox()
        Me.TMetaMin2 = New System.Windows.Forms.TextBox()
        Me.FNuevoBache = New System.Windows.Forms.Button()
        Me.FProceso = New System.Windows.Forms.Button()
        Me.FBachesAnt = New System.Windows.Forms.Button()
        Me.FCaptRep = New System.Windows.Forms.Button()
        Me.FEnviaIngPLC = New System.Windows.Forms.Button()
        Me.FSigMat = New System.Windows.Forms.Button()
        Me.BLeerPLC = New System.Windows.Forms.Button()
        Me.TNetoRep4 = New System.Windows.Forms.TextBox()
        Me.TEstado4 = New System.Windows.Forms.TextBox()
        Me.TMetaMin4 = New System.Windows.Forms.TextBox()
        Me.TMetaMax4 = New System.Windows.Forms.TextBox()
        Me.TJogsMax4 = New System.Windows.Forms.TextBox()
        Me.TAFina4 = New System.Windows.Forms.TextBox()
        Me.TVelG4 = New System.Windows.Forms.TextBox()
        Me.TVelF4 = New System.Windows.Forms.TextBox()
        Me.TOutput4 = New System.Windows.Forms.TextBox()
        Me.TStart4 = New System.Windows.Forms.TextBox()
        Me.TMeta4 = New System.Windows.Forms.TextBox()
        Me.TNeto4 = New System.Windows.Forms.TextBox()
        Me.TBruto4 = New System.Windows.Forms.TextBox()
        Me.TRecAlarma4 = New System.Windows.Forms.TextBox()
        Me.TBacheListo4 = New System.Windows.Forms.TextBox()
        Me.TNetoRep3 = New System.Windows.Forms.TextBox()
        Me.TEstado3 = New System.Windows.Forms.TextBox()
        Me.TMetaMin3 = New System.Windows.Forms.TextBox()
        Me.TMetaMax3 = New System.Windows.Forms.TextBox()
        Me.TJogsMax3 = New System.Windows.Forms.TextBox()
        Me.TAFina3 = New System.Windows.Forms.TextBox()
        Me.TVelG3 = New System.Windows.Forms.TextBox()
        Me.TVelF3 = New System.Windows.Forms.TextBox()
        Me.TOutput3 = New System.Windows.Forms.TextBox()
        Me.TStart3 = New System.Windows.Forms.TextBox()
        Me.TMeta3 = New System.Windows.Forms.TextBox()
        Me.TNeto3 = New System.Windows.Forms.TextBox()
        Me.TBruto3 = New System.Windows.Forms.TextBox()
        Me.TRecAlarma3 = New System.Windows.Forms.TextBox()
        Me.TBacheListo3 = New System.Windows.Forms.TextBox()
        Me.TNetoRep1 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TNetoRep2 = New System.Windows.Forms.TextBox()
        Me.BAbortarPLC = New System.Windows.Forms.Button()
        Me.FNuevaOP = New System.Windows.Forms.Button()
        Me.FRecAlarma = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TNomTag1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FEstados = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TNomTag2 = New System.Windows.Forms.ComboBox()
        Me.TValorEscribir2 = New System.Windows.Forms.TextBox()
        Me.BEscribir2 = New System.Windows.Forms.Button()
        Me.TValorLeido2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BLeer2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FRecMicros = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BLeer1
        '
        Me.BLeer1.Location = New System.Drawing.Point(23, 50)
        Me.BLeer1.Name = "BLeer1"
        Me.BLeer1.Size = New System.Drawing.Size(60, 23)
        Me.BLeer1.TabIndex = 0
        Me.BLeer1.Text = "Leer"
        Me.BLeer1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NombreTag:"
        '
        'TValorLeido1
        '
        Me.TValorLeido1.Location = New System.Drawing.Point(89, 53)
        Me.TValorLeido1.Name = "TValorLeido1"
        Me.TValorLeido1.ReadOnly = True
        Me.TValorLeido1.Size = New System.Drawing.Size(46, 20)
        Me.TValorLeido1.TabIndex = 4
        '
        'TValorEscribir1
        '
        Me.TValorEscribir1.Location = New System.Drawing.Point(141, 53)
        Me.TValorEscribir1.Name = "TValorEscribir1"
        Me.TValorEscribir1.Size = New System.Drawing.Size(58, 20)
        Me.TValorEscribir1.TabIndex = 9
        '
        'BEscribir1
        '
        Me.BEscribir1.Location = New System.Drawing.Point(205, 50)
        Me.BEscribir1.Name = "BEscribir1"
        Me.BEscribir1.Size = New System.Drawing.Size(70, 23)
        Me.BEscribir1.TabIndex = 5
        Me.BEscribir1.Text = "Escribir"
        Me.BEscribir1.UseVisualStyleBackColor = True
        '
        'TimScan
        '
        Me.TimScan.Enabled = True
        Me.TimScan.Interval = 1000
        '
        'TSeg
        '
        Me.TSeg.BackColor = System.Drawing.SystemColors.Control
        Me.TSeg.Location = New System.Drawing.Point(373, 54)
        Me.TSeg.Name = "TSeg"
        Me.TSeg.Size = New System.Drawing.Size(42, 20)
        Me.TSeg.TabIndex = 59
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(834, 24)
        Me.MenuStrip1.TabIndex = 86
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
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(34, 54)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(57, 13)
        Me.Label37.TabIndex = 261
        Me.Label37.Text = "WatchDT:"
        '
        'TError
        '
        Me.TError.BackColor = System.Drawing.SystemColors.Control
        Me.TError.Location = New System.Drawing.Point(509, 302)
        Me.TError.Multiline = True
        Me.TError.Name = "TError"
        Me.TError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TError.Size = New System.Drawing.Size(292, 294)
        Me.TError.TabIndex = 260
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(834, 25)
        Me.ToolStrip2.TabIndex = 85
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'Tip
        '
        Me.Tip.Location = New System.Drawing.Point(100, 54)
        Me.Tip.Name = "Tip"
        Me.Tip.Size = New System.Drawing.Size(108, 20)
        Me.Tip.TabIndex = 262
        Me.Tip.Text = "192.168.1.10"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "IP:"
        '
        'BConectar
        '
        Me.BConectar.Location = New System.Drawing.Point(239, 52)
        Me.BConectar.Name = "BConectar"
        Me.BConectar.Size = New System.Drawing.Size(98, 22)
        Me.BConectar.TabIndex = 264
        Me.BConectar.Text = "Conectar"
        Me.BConectar.UseVisualStyleBackColor = True
        '
        'TMetaMin1
        '
        Me.TMetaMin1.Location = New System.Drawing.Point(222, 45)
        Me.TMetaMin1.Name = "TMetaMin1"
        Me.TMetaMin1.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMin1.TabIndex = 270
        Me.TMetaMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(85, -1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(749, 25)
        Me.Label4.TabIndex = 303
        Me.Label4.Text = "Enlace con PLC "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(163, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 305
        Me.Label9.Text = "Meta Min:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(160, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 319
        Me.Label10.Text = "Meta Max:"
        '
        'TMetaMax1
        '
        Me.TMetaMax1.Location = New System.Drawing.Point(222, 69)
        Me.TMetaMax1.Name = "TMetaMax1"
        Me.TMetaMax1.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMax1.TabIndex = 318
        Me.TMetaMax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(165, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 323
        Me.Label11.Text = "JogsMax:"
        '
        'TJogsMax1
        '
        Me.TJogsMax1.Location = New System.Drawing.Point(222, 94)
        Me.TJogsMax1.Name = "TJogsMax1"
        Me.TJogsMax1.Size = New System.Drawing.Size(54, 20)
        Me.TJogsMax1.TabIndex = 322
        Me.TJogsMax1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(177, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 327
        Me.Label13.Text = "A.Fina:"
        '
        'TAFina1
        '
        Me.TAFina1.Location = New System.Drawing.Point(222, 117)
        Me.TAFina1.Name = "TAFina1"
        Me.TAFina1.Size = New System.Drawing.Size(54, 20)
        Me.TAFina1.TabIndex = 326
        Me.TAFina1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(181, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 331
        Me.Label15.Text = "Vel.G."
        '
        'TVelG1
        '
        Me.TVelG1.Location = New System.Drawing.Point(222, 140)
        Me.TVelG1.Name = "TVelG1"
        Me.TVelG1.Size = New System.Drawing.Size(54, 20)
        Me.TVelG1.TabIndex = 330
        Me.TVelG1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(183, 169)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 335
        Me.Label16.Text = "Vel.F."
        '
        'TVelF1
        '
        Me.TVelF1.Location = New System.Drawing.Point(222, 166)
        Me.TVelF1.Name = "TVelF1"
        Me.TVelF1.Size = New System.Drawing.Size(54, 20)
        Me.TVelF1.TabIndex = 334
        Me.TVelF1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(178, 196)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 339
        Me.Label17.Text = "Salida:"
        '
        'TOutput1
        '
        Me.TOutput1.Location = New System.Drawing.Point(222, 192)
        Me.TOutput1.Name = "TOutput1"
        Me.TOutput1.Size = New System.Drawing.Size(54, 20)
        Me.TOutput1.TabIndex = 338
        Me.TOutput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(185, 221)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 13)
        Me.Label18.TabIndex = 343
        Me.Label18.Text = "Start:"
        '
        'TStart1
        '
        Me.TStart1.Location = New System.Drawing.Point(222, 218)
        Me.TStart1.Name = "TStart1"
        Me.TStart1.Size = New System.Drawing.Size(54, 20)
        Me.TStart1.TabIndex = 342
        Me.TStart1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(184, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(33, 13)
        Me.Label19.TabIndex = 347
        Me.Label19.Text = "Neto:"
        '
        'TNeto1
        '
        Me.TNeto1.Location = New System.Drawing.Point(222, 55)
        Me.TNeto1.Name = "TNeto1"
        Me.TNeto1.Size = New System.Drawing.Size(54, 20)
        Me.TNeto1.TabIndex = 346
        Me.TNeto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(182, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 349
        Me.Label20.Text = "Bruto:"
        '
        'TBruto1
        '
        Me.TBruto1.Location = New System.Drawing.Point(222, 81)
        Me.TBruto1.Name = "TBruto1"
        Me.TBruto1.Size = New System.Drawing.Size(54, 20)
        Me.TBruto1.TabIndex = 348
        Me.TBruto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TSegToPLC
        '
        Me.TSegToPLC.Location = New System.Drawing.Point(97, 51)
        Me.TSegToPLC.Name = "TSegToPLC"
        Me.TSegToPLC.Size = New System.Drawing.Size(34, 20)
        Me.TSegToPLC.TabIndex = 350
        Me.TSegToPLC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEstado1
        '
        Me.TEstado1.Location = New System.Drawing.Point(222, 29)
        Me.TEstado1.Name = "TEstado1"
        Me.TEstado1.Size = New System.Drawing.Size(54, 20)
        Me.TEstado1.TabIndex = 351
        Me.TEstado1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(174, 32)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 352
        Me.Label21.Text = "Estado:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(152, 248)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 354
        Me.Label22.Text = "Rec.Alarma:"
        '
        'TRecAlarma1
        '
        Me.TRecAlarma1.Location = New System.Drawing.Point(222, 245)
        Me.TRecAlarma1.Name = "TRecAlarma1"
        Me.TRecAlarma1.Size = New System.Drawing.Size(54, 20)
        Me.TRecAlarma1.TabIndex = 353
        Me.TRecAlarma1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(151, 274)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 13)
        Me.Label23.TabIndex = 358
        Me.Label23.Text = "Bache Listo:"
        '
        'TBacheListo1
        '
        Me.TBacheListo1.Location = New System.Drawing.Point(222, 271)
        Me.TBacheListo1.Name = "TBacheListo1"
        Me.TBacheListo1.Size = New System.Drawing.Size(54, 20)
        Me.TBacheListo1.TabIndex = 357
        Me.TBacheListo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(183, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 362
        Me.Label5.Text = "Meta:"
        '
        'TMeta1
        '
        Me.TMeta1.Location = New System.Drawing.Point(222, 19)
        Me.TMeta1.Name = "TMeta1"
        Me.TMeta1.Size = New System.Drawing.Size(54, 20)
        Me.TMeta1.TabIndex = 361
        Me.TMeta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 374
        Me.Label6.Text = "Baches:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 373
        Me.Label8.Text = "Cod.For:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 372
        Me.Label7.Text = "Nombre:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(20, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 371
        Me.Label12.Text = "Bache:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(36, 91)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(25, 13)
        Me.Label14.TabIndex = 370
        Me.Label14.Text = "OP:"
        '
        'TBaches
        '
        Me.TBaches.Location = New System.Drawing.Point(66, 189)
        Me.TBaches.Name = "TBaches"
        Me.TBaches.Size = New System.Drawing.Size(54, 20)
        Me.TBaches.TabIndex = 369
        Me.TBaches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBache
        '
        Me.TBache.Location = New System.Drawing.Point(66, 163)
        Me.TBache.Name = "TBache"
        Me.TBache.Size = New System.Drawing.Size(54, 20)
        Me.TBache.TabIndex = 368
        Me.TBache.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNomFor
        '
        Me.TNomFor.Location = New System.Drawing.Point(66, 140)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.Size = New System.Drawing.Size(54, 20)
        Me.TNomFor.TabIndex = 367
        Me.TNomFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOPs
        '
        Me.TOPs.Location = New System.Drawing.Point(66, 88)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.Size = New System.Drawing.Size(54, 20)
        Me.TOPs.TabIndex = 366
        Me.TOPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TCodFor
        '
        Me.TCodFor.Location = New System.Drawing.Point(66, 114)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.Size = New System.Drawing.Size(54, 20)
        Me.TCodFor.TabIndex = 365
        Me.TCodFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMeta2
        '
        Me.TMeta2.Location = New System.Drawing.Point(282, 19)
        Me.TMeta2.Name = "TMeta2"
        Me.TMeta2.Size = New System.Drawing.Size(54, 20)
        Me.TMeta2.TabIndex = 454
        Me.TMeta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBacheListo2
        '
        Me.TBacheListo2.Location = New System.Drawing.Point(282, 271)
        Me.TBacheListo2.Name = "TBacheListo2"
        Me.TBacheListo2.Size = New System.Drawing.Size(54, 20)
        Me.TBacheListo2.TabIndex = 451
        Me.TBacheListo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TRecAlarma2
        '
        Me.TRecAlarma2.Location = New System.Drawing.Point(282, 245)
        Me.TRecAlarma2.Name = "TRecAlarma2"
        Me.TRecAlarma2.Size = New System.Drawing.Size(54, 20)
        Me.TRecAlarma2.TabIndex = 448
        Me.TRecAlarma2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEstado2
        '
        Me.TEstado2.Location = New System.Drawing.Point(282, 29)
        Me.TEstado2.Name = "TEstado2"
        Me.TEstado2.Size = New System.Drawing.Size(54, 20)
        Me.TEstado2.TabIndex = 447
        Me.TEstado2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBruto2
        '
        Me.TBruto2.Location = New System.Drawing.Point(282, 81)
        Me.TBruto2.Name = "TBruto2"
        Me.TBruto2.Size = New System.Drawing.Size(54, 20)
        Me.TBruto2.TabIndex = 446
        Me.TBruto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNeto2
        '
        Me.TNeto2.Location = New System.Drawing.Point(282, 55)
        Me.TNeto2.Name = "TNeto2"
        Me.TNeto2.Size = New System.Drawing.Size(54, 20)
        Me.TNeto2.TabIndex = 445
        Me.TNeto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TStart2
        '
        Me.TStart2.Location = New System.Drawing.Point(282, 218)
        Me.TStart2.Name = "TStart2"
        Me.TStart2.Size = New System.Drawing.Size(54, 20)
        Me.TStart2.TabIndex = 442
        Me.TStart2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOutput2
        '
        Me.TOutput2.Location = New System.Drawing.Point(282, 192)
        Me.TOutput2.Name = "TOutput2"
        Me.TOutput2.Size = New System.Drawing.Size(54, 20)
        Me.TOutput2.TabIndex = 439
        Me.TOutput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVelF2
        '
        Me.TVelF2.Location = New System.Drawing.Point(282, 166)
        Me.TVelF2.Name = "TVelF2"
        Me.TVelF2.Size = New System.Drawing.Size(54, 20)
        Me.TVelF2.TabIndex = 436
        Me.TVelF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVelG2
        '
        Me.TVelG2.Location = New System.Drawing.Point(282, 140)
        Me.TVelG2.Name = "TVelG2"
        Me.TVelG2.Size = New System.Drawing.Size(54, 20)
        Me.TVelG2.TabIndex = 433
        Me.TVelG2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TAFina2
        '
        Me.TAFina2.Location = New System.Drawing.Point(282, 117)
        Me.TAFina2.Name = "TAFina2"
        Me.TAFina2.Size = New System.Drawing.Size(54, 20)
        Me.TAFina2.TabIndex = 430
        Me.TAFina2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TJogsMax2
        '
        Me.TJogsMax2.Location = New System.Drawing.Point(282, 94)
        Me.TJogsMax2.Name = "TJogsMax2"
        Me.TJogsMax2.Size = New System.Drawing.Size(54, 20)
        Me.TJogsMax2.TabIndex = 427
        Me.TJogsMax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaMax2
        '
        Me.TMetaMax2.Location = New System.Drawing.Point(282, 69)
        Me.TMetaMax2.Name = "TMetaMax2"
        Me.TMetaMax2.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMax2.TabIndex = 424
        Me.TMetaMax2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaMin2
        '
        Me.TMetaMin2.Location = New System.Drawing.Point(282, 45)
        Me.TMetaMin2.Name = "TMetaMin2"
        Me.TMetaMin2.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMin2.TabIndex = 421
        Me.TMetaMin2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FNuevoBache
        '
        Me.FNuevoBache.Location = New System.Drawing.Point(612, 382)
        Me.FNuevoBache.Name = "FNuevoBache"
        Me.FNuevoBache.Size = New System.Drawing.Size(86, 23)
        Me.FNuevoBache.TabIndex = 490
        Me.FNuevoBache.Text = "FNuevoBache"
        Me.FNuevoBache.UseVisualStyleBackColor = True
        Me.FNuevoBache.Visible = False
        '
        'FProceso
        '
        Me.FProceso.Location = New System.Drawing.Point(616, 430)
        Me.FProceso.Name = "FProceso"
        Me.FProceso.Size = New System.Drawing.Size(86, 57)
        Me.FProceso.TabIndex = 489
        Me.FProceso.Text = "FProceso"
        Me.FProceso.UseVisualStyleBackColor = True
        Me.FProceso.Visible = False
        '
        'FBachesAnt
        '
        Me.FBachesAnt.Location = New System.Drawing.Point(520, 464)
        Me.FBachesAnt.Name = "FBachesAnt"
        Me.FBachesAnt.Size = New System.Drawing.Size(90, 23)
        Me.FBachesAnt.TabIndex = 488
        Me.FBachesAnt.Text = "FBachesAnt"
        Me.FBachesAnt.UseVisualStyleBackColor = True
        Me.FBachesAnt.Visible = False
        '
        'FCaptRep
        '
        Me.FCaptRep.Location = New System.Drawing.Point(520, 428)
        Me.FCaptRep.Name = "FCaptRep"
        Me.FCaptRep.Size = New System.Drawing.Size(90, 30)
        Me.FCaptRep.TabIndex = 487
        Me.FCaptRep.Text = "FCaptRep"
        Me.FCaptRep.UseVisualStyleBackColor = True
        Me.FCaptRep.Visible = False
        '
        'FEnviaIngPLC
        '
        Me.FEnviaIngPLC.Location = New System.Drawing.Point(704, 378)
        Me.FEnviaIngPLC.Name = "FEnviaIngPLC"
        Me.FEnviaIngPLC.Size = New System.Drawing.Size(90, 23)
        Me.FEnviaIngPLC.TabIndex = 486
        Me.FEnviaIngPLC.Text = "FEnviaIngPLC"
        Me.FEnviaIngPLC.UseVisualStyleBackColor = True
        Me.FEnviaIngPLC.Visible = False
        '
        'FSigMat
        '
        Me.FSigMat.Location = New System.Drawing.Point(704, 353)
        Me.FSigMat.Name = "FSigMat"
        Me.FSigMat.Size = New System.Drawing.Size(90, 23)
        Me.FSigMat.TabIndex = 485
        Me.FSigMat.Text = "FSigMat"
        Me.FSigMat.UseVisualStyleBackColor = True
        Me.FSigMat.Visible = False
        '
        'BLeerPLC
        '
        Me.BLeerPLC.Location = New System.Drawing.Point(22, 32)
        Me.BLeerPLC.Name = "BLeerPLC"
        Me.BLeerPLC.Size = New System.Drawing.Size(98, 33)
        Me.BLeerPLC.TabIndex = 488
        Me.BLeerPLC.Text = "Leer"
        Me.BLeerPLC.UseVisualStyleBackColor = True
        '
        'TNetoRep4
        '
        Me.TNetoRep4.Location = New System.Drawing.Point(402, 297)
        Me.TNetoRep4.Name = "TNetoRep4"
        Me.TNetoRep4.Size = New System.Drawing.Size(54, 20)
        Me.TNetoRep4.TabIndex = 487
        Me.TNetoRep4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEstado4
        '
        Me.TEstado4.Location = New System.Drawing.Point(402, 29)
        Me.TEstado4.Name = "TEstado4"
        Me.TEstado4.Size = New System.Drawing.Size(54, 20)
        Me.TEstado4.TabIndex = 483
        Me.TEstado4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaMin4
        '
        Me.TMetaMin4.Location = New System.Drawing.Point(402, 45)
        Me.TMetaMin4.Name = "TMetaMin4"
        Me.TMetaMin4.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMin4.TabIndex = 473
        Me.TMetaMin4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaMax4
        '
        Me.TMetaMax4.Location = New System.Drawing.Point(402, 69)
        Me.TMetaMax4.Name = "TMetaMax4"
        Me.TMetaMax4.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMax4.TabIndex = 474
        Me.TMetaMax4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TJogsMax4
        '
        Me.TJogsMax4.Location = New System.Drawing.Point(402, 94)
        Me.TJogsMax4.Name = "TJogsMax4"
        Me.TJogsMax4.Size = New System.Drawing.Size(54, 20)
        Me.TJogsMax4.TabIndex = 475
        Me.TJogsMax4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TAFina4
        '
        Me.TAFina4.Location = New System.Drawing.Point(402, 117)
        Me.TAFina4.Name = "TAFina4"
        Me.TAFina4.Size = New System.Drawing.Size(54, 20)
        Me.TAFina4.TabIndex = 476
        Me.TAFina4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVelG4
        '
        Me.TVelG4.Location = New System.Drawing.Point(402, 140)
        Me.TVelG4.Name = "TVelG4"
        Me.TVelG4.Size = New System.Drawing.Size(54, 20)
        Me.TVelG4.TabIndex = 477
        Me.TVelG4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVelF4
        '
        Me.TVelF4.Location = New System.Drawing.Point(402, 166)
        Me.TVelF4.Name = "TVelF4"
        Me.TVelF4.Size = New System.Drawing.Size(54, 20)
        Me.TVelF4.TabIndex = 478
        Me.TVelF4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOutput4
        '
        Me.TOutput4.Location = New System.Drawing.Point(402, 192)
        Me.TOutput4.Name = "TOutput4"
        Me.TOutput4.Size = New System.Drawing.Size(54, 20)
        Me.TOutput4.TabIndex = 479
        Me.TOutput4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TStart4
        '
        Me.TStart4.Location = New System.Drawing.Point(402, 218)
        Me.TStart4.Name = "TStart4"
        Me.TStart4.Size = New System.Drawing.Size(54, 20)
        Me.TStart4.TabIndex = 480
        Me.TStart4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMeta4
        '
        Me.TMeta4.Location = New System.Drawing.Point(402, 19)
        Me.TMeta4.Name = "TMeta4"
        Me.TMeta4.Size = New System.Drawing.Size(54, 20)
        Me.TMeta4.TabIndex = 486
        Me.TMeta4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNeto4
        '
        Me.TNeto4.Location = New System.Drawing.Point(402, 55)
        Me.TNeto4.Name = "TNeto4"
        Me.TNeto4.Size = New System.Drawing.Size(54, 20)
        Me.TNeto4.TabIndex = 481
        Me.TNeto4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBruto4
        '
        Me.TBruto4.Location = New System.Drawing.Point(402, 81)
        Me.TBruto4.Name = "TBruto4"
        Me.TBruto4.Size = New System.Drawing.Size(54, 20)
        Me.TBruto4.TabIndex = 482
        Me.TBruto4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TRecAlarma4
        '
        Me.TRecAlarma4.Location = New System.Drawing.Point(402, 245)
        Me.TRecAlarma4.Name = "TRecAlarma4"
        Me.TRecAlarma4.Size = New System.Drawing.Size(54, 20)
        Me.TRecAlarma4.TabIndex = 484
        Me.TRecAlarma4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBacheListo4
        '
        Me.TBacheListo4.Location = New System.Drawing.Point(402, 271)
        Me.TBacheListo4.Name = "TBacheListo4"
        Me.TBacheListo4.Size = New System.Drawing.Size(54, 20)
        Me.TBacheListo4.TabIndex = 485
        Me.TBacheListo4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNetoRep3
        '
        Me.TNetoRep3.Location = New System.Drawing.Point(342, 297)
        Me.TNetoRep3.Name = "TNetoRep3"
        Me.TNetoRep3.Size = New System.Drawing.Size(54, 20)
        Me.TNetoRep3.TabIndex = 472
        Me.TNetoRep3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEstado3
        '
        Me.TEstado3.Location = New System.Drawing.Point(342, 29)
        Me.TEstado3.Name = "TEstado3"
        Me.TEstado3.Size = New System.Drawing.Size(54, 20)
        Me.TEstado3.TabIndex = 468
        Me.TEstado3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaMin3
        '
        Me.TMetaMin3.Location = New System.Drawing.Point(342, 45)
        Me.TMetaMin3.Name = "TMetaMin3"
        Me.TMetaMin3.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMin3.TabIndex = 458
        Me.TMetaMin3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMetaMax3
        '
        Me.TMetaMax3.Location = New System.Drawing.Point(342, 69)
        Me.TMetaMax3.Name = "TMetaMax3"
        Me.TMetaMax3.Size = New System.Drawing.Size(54, 20)
        Me.TMetaMax3.TabIndex = 459
        Me.TMetaMax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TJogsMax3
        '
        Me.TJogsMax3.Location = New System.Drawing.Point(342, 94)
        Me.TJogsMax3.Name = "TJogsMax3"
        Me.TJogsMax3.Size = New System.Drawing.Size(54, 20)
        Me.TJogsMax3.TabIndex = 460
        Me.TJogsMax3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TAFina3
        '
        Me.TAFina3.Location = New System.Drawing.Point(342, 117)
        Me.TAFina3.Name = "TAFina3"
        Me.TAFina3.Size = New System.Drawing.Size(54, 20)
        Me.TAFina3.TabIndex = 461
        Me.TAFina3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVelG3
        '
        Me.TVelG3.Location = New System.Drawing.Point(342, 140)
        Me.TVelG3.Name = "TVelG3"
        Me.TVelG3.Size = New System.Drawing.Size(54, 20)
        Me.TVelG3.TabIndex = 462
        Me.TVelG3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TVelF3
        '
        Me.TVelF3.Location = New System.Drawing.Point(342, 166)
        Me.TVelF3.Name = "TVelF3"
        Me.TVelF3.Size = New System.Drawing.Size(54, 20)
        Me.TVelF3.TabIndex = 463
        Me.TVelF3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TOutput3
        '
        Me.TOutput3.Location = New System.Drawing.Point(342, 192)
        Me.TOutput3.Name = "TOutput3"
        Me.TOutput3.Size = New System.Drawing.Size(54, 20)
        Me.TOutput3.TabIndex = 464
        Me.TOutput3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TStart3
        '
        Me.TStart3.Location = New System.Drawing.Point(342, 218)
        Me.TStart3.Name = "TStart3"
        Me.TStart3.Size = New System.Drawing.Size(54, 20)
        Me.TStart3.TabIndex = 465
        Me.TStart3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMeta3
        '
        Me.TMeta3.Location = New System.Drawing.Point(342, 19)
        Me.TMeta3.Name = "TMeta3"
        Me.TMeta3.Size = New System.Drawing.Size(54, 20)
        Me.TMeta3.TabIndex = 471
        Me.TMeta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNeto3
        '
        Me.TNeto3.Location = New System.Drawing.Point(342, 55)
        Me.TNeto3.Name = "TNeto3"
        Me.TNeto3.Size = New System.Drawing.Size(54, 20)
        Me.TNeto3.TabIndex = 466
        Me.TNeto3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBruto3
        '
        Me.TBruto3.Location = New System.Drawing.Point(342, 81)
        Me.TBruto3.Name = "TBruto3"
        Me.TBruto3.Size = New System.Drawing.Size(54, 20)
        Me.TBruto3.TabIndex = 467
        Me.TBruto3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TRecAlarma3
        '
        Me.TRecAlarma3.Location = New System.Drawing.Point(342, 245)
        Me.TRecAlarma3.Name = "TRecAlarma3"
        Me.TRecAlarma3.Size = New System.Drawing.Size(54, 20)
        Me.TRecAlarma3.TabIndex = 469
        Me.TRecAlarma3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBacheListo3
        '
        Me.TBacheListo3.Location = New System.Drawing.Point(342, 271)
        Me.TBacheListo3.Name = "TBacheListo3"
        Me.TBacheListo3.Size = New System.Drawing.Size(54, 20)
        Me.TBacheListo3.TabIndex = 470
        Me.TBacheListo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TNetoRep1
        '
        Me.TNetoRep1.Location = New System.Drawing.Point(222, 297)
        Me.TNetoRep1.Name = "TNetoRep1"
        Me.TNetoRep1.Size = New System.Drawing.Size(54, 20)
        Me.TNetoRep1.TabIndex = 455
        Me.TNetoRep1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(164, 300)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 456
        Me.Label29.Text = "NetoRep:"
        '
        'TNetoRep2
        '
        Me.TNetoRep2.Location = New System.Drawing.Point(282, 297)
        Me.TNetoRep2.Name = "TNetoRep2"
        Me.TNetoRep2.Size = New System.Drawing.Size(54, 20)
        Me.TNetoRep2.TabIndex = 457
        Me.TNetoRep2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BAbortarPLC
        '
        Me.BAbortarPLC.Location = New System.Drawing.Point(520, 352)
        Me.BAbortarPLC.Name = "BAbortarPLC"
        Me.BAbortarPLC.Size = New System.Drawing.Size(86, 23)
        Me.BAbortarPLC.TabIndex = 492
        Me.BAbortarPLC.Text = "Abortar PLC"
        Me.BAbortarPLC.UseVisualStyleBackColor = True
        Me.BAbortarPLC.Visible = False
        '
        'FNuevaOP
        '
        Me.FNuevaOP.Location = New System.Drawing.Point(612, 353)
        Me.FNuevaOP.Name = "FNuevaOP"
        Me.FNuevaOP.Size = New System.Drawing.Size(86, 23)
        Me.FNuevaOP.TabIndex = 493
        Me.FNuevaOP.Text = "FNuevaOP"
        Me.FNuevaOP.UseVisualStyleBackColor = True
        Me.FNuevaOP.Visible = False
        '
        'FRecAlarma
        '
        Me.FRecAlarma.Location = New System.Drawing.Point(520, 381)
        Me.FRecAlarma.Name = "FRecAlarma"
        Me.FRecAlarma.Size = New System.Drawing.Size(86, 23)
        Me.FRecAlarma.TabIndex = 494
        Me.FRecAlarma.Text = "FRecAlarma"
        Me.FRecAlarma.UseVisualStyleBackColor = True
        Me.FRecAlarma.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(233, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 13)
        Me.Label30.TabIndex = 489
        Me.Label30.Text = "B1"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(298, 13)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(20, 13)
        Me.Label31.TabIndex = 490
        Me.Label31.Text = "B2"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(358, 13)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(20, 13)
        Me.Label32.TabIndex = 491
        Me.Label32.Text = "B3"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(420, 13)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(20, 13)
        Me.Label33.TabIndex = 492
        Me.Label33.Text = "B4"
        '
        'TNomTag1
        '
        Me.TNomTag1.FormattingEnabled = True
        Me.TNomTag1.Items.AddRange(New Object() {"Chr_OP", "Chr_Cod_Formula", "Chr_Nom_Formula", "Chr_Bache", "Chr_Baches", "", "----Báscula 1  ----", "Chr_Neto_B1", "Chr_Bruto_B1", "Chr_Peso_Meta_B1", "Chr_Meta_Maximo_B1", "Chr_Meta_Minimo_B1", "Chr_Max_Num_Jogs_B1", "Chr_Alimentador_Num_B1", "Chr_Velocidad_Gru_B1", "Chr_Velocidad_Fina_B1", "Chr_Alimentacion_Fina_B1", "Chr_Inicio_B1", "Chr_Estado_B1", "Chr_Reconoce_Alarma_B1", "Chr_Neto_Rep_B1", "Chr_Bache_Listo_B1", "Chr_Meta_Corte_B1", "Chr_Fin_Alimentador_B1", "", "----Báscula 2  ----", "Chr_Neto_B2", "Chr_Bruto_B2", "Chr_Peso_Meta_B2", "Chr_Meta_Maximo_B2", "Chr_Meta_Minimo_B2", "Chr_Max_Num_Jogs_B2", "Chr_Alimentador_Num_B2", "Chr_Velocidad_Gru_B2", "Chr_Velocidad_Fina_B2", "Chr_Alimentacion_Fina_B2", "Chr_Inicio_B2", "Chr_Estado_B2", "Chr_Reconoce_Alarma_B2", "Chr_Neto_Rep_B2", "Chr_Bache_Listo_B2", "Chr_Meta_Corte_B2", "Chr_Fin_Alimentador_B2", "", "----Báscula 3  ----", "Chr_Neto_B3", "Chr_Bruto_B3", "Chr_Peso_Meta_B3", "Chr_Meta_Maximo_B3", "Chr_Meta_Minimo_B3", "Chr_Max_Num_Jogs_B3", "Chr_Alimentador_Num_B3", "Chr_Velocidad_Gru_B3", "Chr_Velocidad_Fina_B3", "Chr_Alimentacion_Fina_B3", "Chr_Inicio_B3", "Chr_Estado_B3", "Chr_Reconoce_Alarma_B3", "Chr_Neto_Rep_B3", "Chr_Bache_Listo_B3", "Chr_Meta_Corte_B3", "Chr_Fin_Alimentador_B3", "", "----Báscula 4  ----", "Chr_Neto_B4", "Chr_Bruto_B4", "Chr_Peso_Meta_B4", "Chr_Meta_Maximo_B4", "Chr_Meta_Minimo_B4", "Chr_Max_Num_Jogs_B4", "Chr_Alimentador_Num_B4", "Chr_Velocidad_Gru_B4", "Chr_Velocidad_Fina_B4", "Chr_Alimentacion_Fina_B4", "Chr_Inicio_B4", "Chr_Estado_B4", "Chr_Reconoce_Alarma_B4", "Chr_Neto_Rep_B4", "Chr_Bache_Listo_B4", "Chr_Meta_Corte_B4", "Chr_Fin_Alimentador_B4", "", "---  Varios ---", "Chr_OK_Descarga_Basc", "Chr_Sol_Micros", "Chr_Sol_Degussa", "Chr_Abortar", "Chr_Destino", "Chr_Alarma"})
        Me.TNomTag1.Location = New System.Drawing.Point(89, 26)
        Me.TNomTag1.Name = "TNomTag1"
        Me.TNomTag1.Size = New System.Drawing.Size(186, 21)
        Me.TNomTag1.TabIndex = 504
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FEstados)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.TEstado4)
        Me.GroupBox1.Controls.Add(Me.TNeto4)
        Me.GroupBox1.Controls.Add(Me.TBruto4)
        Me.GroupBox1.Controls.Add(Me.TEstado3)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.TBruto2)
        Me.GroupBox1.Controls.Add(Me.TNeto2)
        Me.GroupBox1.Controls.Add(Me.TNeto3)
        Me.GroupBox1.Controls.Add(Me.TBruto3)
        Me.GroupBox1.Controls.Add(Me.TEstado1)
        Me.GroupBox1.Controls.Add(Me.TEstado2)
        Me.GroupBox1.Controls.Add(Me.TSegToPLC)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.TNeto1)
        Me.GroupBox1.Controls.Add(Me.TBruto1)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 112)
        Me.GroupBox1.TabIndex = 505
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lectura Automática"
        '
        'FEstados
        '
        Me.FEstados.Location = New System.Drawing.Point(282, 26)
        Me.FEstados.Name = "FEstados"
        Me.FEstados.Size = New System.Drawing.Size(86, 23)
        Me.FEstados.TabIndex = 514
        Me.FEstados.Text = "FEstados"
        Me.FEstados.UseVisualStyleBackColor = True
        Me.FEstados.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BLeerPLC)
        Me.GroupBox2.Controls.Add(Me.TMetaMin4)
        Me.GroupBox2.Controls.Add(Me.TMetaMax4)
        Me.GroupBox2.Controls.Add(Me.TJogsMax4)
        Me.GroupBox2.Controls.Add(Me.TAFina4)
        Me.GroupBox2.Controls.Add(Me.TNetoRep4)
        Me.GroupBox2.Controls.Add(Me.TVelG4)
        Me.GroupBox2.Controls.Add(Me.TVelF4)
        Me.GroupBox2.Controls.Add(Me.TOutput4)
        Me.GroupBox2.Controls.Add(Me.TNetoRep3)
        Me.GroupBox2.Controls.Add(Me.TStart4)
        Me.GroupBox2.Controls.Add(Me.TMeta4)
        Me.GroupBox2.Controls.Add(Me.TRecAlarma4)
        Me.GroupBox2.Controls.Add(Me.TBacheListo4)
        Me.GroupBox2.Controls.Add(Me.TMetaMin3)
        Me.GroupBox2.Controls.Add(Me.TMetaMax3)
        Me.GroupBox2.Controls.Add(Me.TJogsMax3)
        Me.GroupBox2.Controls.Add(Me.TNetoRep1)
        Me.GroupBox2.Controls.Add(Me.TAFina3)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.TVelG3)
        Me.GroupBox2.Controls.Add(Me.TNetoRep2)
        Me.GroupBox2.Controls.Add(Me.TVelF3)
        Me.GroupBox2.Controls.Add(Me.TBacheListo2)
        Me.GroupBox2.Controls.Add(Me.TOutput3)
        Me.GroupBox2.Controls.Add(Me.TRecAlarma2)
        Me.GroupBox2.Controls.Add(Me.TStart3)
        Me.GroupBox2.Controls.Add(Me.TMeta3)
        Me.GroupBox2.Controls.Add(Me.TMeta2)
        Me.GroupBox2.Controls.Add(Me.TStart2)
        Me.GroupBox2.Controls.Add(Me.TRecAlarma3)
        Me.GroupBox2.Controls.Add(Me.TOutput2)
        Me.GroupBox2.Controls.Add(Me.TBacheListo3)
        Me.GroupBox2.Controls.Add(Me.TVelF2)
        Me.GroupBox2.Controls.Add(Me.TVelG2)
        Me.GroupBox2.Controls.Add(Me.TAFina2)
        Me.GroupBox2.Controls.Add(Me.TJogsMax2)
        Me.GroupBox2.Controls.Add(Me.TMetaMax2)
        Me.GroupBox2.Controls.Add(Me.TMetaMin1)
        Me.GroupBox2.Controls.Add(Me.TMetaMin2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TMetaMax1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TJogsMax1)
        Me.GroupBox2.Controls.Add(Me.TMeta1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TCodFor)
        Me.GroupBox2.Controls.Add(Me.TAFina1)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TOPs)
        Me.GroupBox2.Controls.Add(Me.TVelG1)
        Me.GroupBox2.Controls.Add(Me.TBacheListo1)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TNomFor)
        Me.GroupBox2.Controls.Add(Me.TVelF1)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TBache)
        Me.GroupBox2.Controls.Add(Me.TOutput1)
        Me.GroupBox2.Controls.Add(Me.TRecAlarma1)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TBaches)
        Me.GroupBox2.Controls.Add(Me.TStart1)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(473, 355)
        Me.GroupBox2.TabIndex = 506
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lectura Manual"
        '
        'TNomTag2
        '
        Me.TNomTag2.FormattingEnabled = True
        Me.TNomTag2.Items.AddRange(New Object() {"Chr_OP", "Chr_Cod_Formula", "Chr_Nom_Formula", "Chr_Bache", "Chr_Baches", "", "----Báscula 1  ----", "Chr_Neto_B1", "Chr_Bruto_B1", "Chr_Peso_Meta_B1", "Chr_Meta_Maximo_B1", "Chr_Meta_Minimo_B1", "Chr_Max_Num_Jogs_B1", "Chr_Alimentador_Num_B1", "Chr_Velocidad_Gru_B1", "Chr_Velocidad_Fina_B1", "Chr_Alimentacion_Fina_B1", "Chr_Inicio_B1", "Chr_Estado_B1", "Chr_Reconoce_Alarma_B1", "Chr_Neto_Rep_B1", "Chr_Bache_Listo_B1", "Chr_Meta_Corte_B1", "Chr_Fin_Alimentador__B1", "", "----Báscula 2  ----", "Chr_Neto_B2", "Chr_Bruto_B2", "Chr_Peso_Meta_B2", "Chr_Meta_Maximo_B2", "Chr_Meta_Minimo_B2", "Chr_Max_Num_Jogs_B2", "Chr_Alimentador_Num_B2", "Chr_Velocidad_Gru_B2", "Chr_Velocidad_Fina_B2", "Chr_Alimentacion_Fina_B2", "Chr_Inicio_B2", "Chr_Estado_B2", "Chr_Reconoce_Alarma_B2", "Chr_Neto_Rep_B2", "Chr_Bache_Listo_B2", "Chr_Meta_Corte_B2", "Chr_Fin_Alimentador__B2", "", "----Báscula 3  ----", "Chr_Neto_B3", "Chr_Bruto_B3", "Chr_Peso_Meta_B3", "Chr_Meta_Maximo_B3", "Chr_Meta_Minimo_B3", "Chr_Max_Num_Jogs_B3", "Chr_Alimentador_Num_B3", "Chr_Velocidad_Gru_B3", "Chr_Velocidad_Fina_B3", "Chr_Alimentacion_Fina_B3", "Chr_Inicio_B3", "Chr_Estado_B3", "Chr_Reconoce_Alarma_B3", "Chr_Neto_Rep_B3", "Chr_Bache_Listo_B3", "Chr_Meta_Corte_B3", "Chr_Fin_Alimentador__B3", "", "----Báscula 4  ----", "Chr_Neto_B4", "Chr_Bruto_B4", "Chr_Peso_Meta_B4", "Chr_Meta_Maximo_B4", "Chr_Meta_Minimo_B4", "Chr_Max_Num_Jogs_B4", "Chr_Alimentador_Num_B4", "Chr_Velocidad_Gru_B4", "Chr_Velocidad_Fina_B4", "Chr_Alimentacion_Fina_B4", "Chr_Inicio_B4", "Chr_Estado_B4", "Chr_Reconoce_Alarma_B4", "Chr_Neto_Rep_B4", "Chr_Bache_Listo_B4", "Chr_Meta_Corte_B4", "Chr_Fin_Alimentador_B4", "", "---  Varios ---", "Chr_OK_Descarga_Basc", "Chr_Sol_Micros", "Chr_Sol_Degussa", "Chr_Abortar", "Chr_Destino", "Chr_Alarma"})
        Me.TNomTag2.Location = New System.Drawing.Point(89, 96)
        Me.TNomTag2.Name = "TNomTag2"
        Me.TNomTag2.Size = New System.Drawing.Size(186, 21)
        Me.TNomTag2.TabIndex = 512
        '
        'TValorEscribir2
        '
        Me.TValorEscribir2.Location = New System.Drawing.Point(141, 123)
        Me.TValorEscribir2.Name = "TValorEscribir2"
        Me.TValorEscribir2.Size = New System.Drawing.Size(58, 20)
        Me.TValorEscribir2.TabIndex = 511
        '
        'BEscribir2
        '
        Me.BEscribir2.Location = New System.Drawing.Point(205, 120)
        Me.BEscribir2.Name = "BEscribir2"
        Me.BEscribir2.Size = New System.Drawing.Size(70, 23)
        Me.BEscribir2.TabIndex = 510
        Me.BEscribir2.Text = "Escribir"
        Me.BEscribir2.UseVisualStyleBackColor = True
        '
        'TValorLeido2
        '
        Me.TValorLeido2.Location = New System.Drawing.Point(89, 123)
        Me.TValorLeido2.Name = "TValorLeido2"
        Me.TValorLeido2.ReadOnly = True
        Me.TValorLeido2.Size = New System.Drawing.Size(46, 20)
        Me.TValorLeido2.TabIndex = 509
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "NombreTag:"
        '
        'BLeer2
        '
        Me.BLeer2.Location = New System.Drawing.Point(23, 120)
        Me.BLeer2.Name = "BLeer2"
        Me.BLeer2.Size = New System.Drawing.Size(60, 23)
        Me.BLeer2.TabIndex = 507
        Me.BLeer2.Text = "Leer"
        Me.BLeer2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TNomTag2)
        Me.GroupBox3.Controls.Add(Me.TValorEscribir2)
        Me.GroupBox3.Controls.Add(Me.BEscribir2)
        Me.GroupBox3.Controls.Add(Me.TValorLeido2)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.BLeer2)
        Me.GroupBox3.Controls.Add(Me.TNomTag1)
        Me.GroupBox3.Controls.Add(Me.TValorEscribir1)
        Me.GroupBox3.Controls.Add(Me.BEscribir1)
        Me.GroupBox3.Controls.Add(Me.TValorLeido1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.BLeer1)
        Me.GroupBox3.Location = New System.Drawing.Point(509, 109)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(292, 169)
        Me.GroupBox3.TabIndex = 513
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Escritura Manual"
        '
        'FRecMicros
        '
        Me.FRecMicros.Location = New System.Drawing.Point(704, 402)
        Me.FRecMicros.Name = "FRecMicros"
        Me.FRecMicros.Size = New System.Drawing.Size(86, 23)
        Me.FRecMicros.TabIndex = 514
        Me.FRecMicros.Text = "FRecMicros"
        Me.FRecMicros.UseVisualStyleBackColor = True
        Me.FRecMicros.Visible = False
        '
        'ServPLC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 624)
        Me.Controls.Add(Me.FRecMicros)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.FRecAlarma)
        Me.Controls.Add(Me.FNuevaOP)
        Me.Controls.Add(Me.BAbortarPLC)
        Me.Controls.Add(Me.FNuevoBache)
        Me.Controls.Add(Me.FProceso)
        Me.Controls.Add(Me.FBachesAnt)
        Me.Controls.Add(Me.FCaptRep)
        Me.Controls.Add(Me.FEnviaIngPLC)
        Me.Controls.Add(Me.FSigMat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BConectar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Tip)
        Me.Controls.Add(Me.TError)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TSeg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServPLC"
        Me.Text = "PLC AB"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BLeer1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TValorLeido1 As System.Windows.Forms.TextBox
    Friend WithEvents TValorEscribir1 As System.Windows.Forms.TextBox
    Friend WithEvents BEscribir1 As System.Windows.Forms.Button
    Friend WithEvents TimScan As System.Windows.Forms.Timer

    Friend WithEvents TSeg As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TError As System.Windows.Forms.TextBox
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents Tip As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BConectar As System.Windows.Forms.Button
    Friend WithEvents TMetaMin1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TMetaMax1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TJogsMax1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TAFina1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TVelG1 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TVelF1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TOutput1 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TStart1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TNeto1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TBruto1 As System.Windows.Forms.TextBox
    Friend WithEvents TSegToPLC As System.Windows.Forms.TextBox
    Friend WithEvents TEstado1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TRecAlarma1 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TBacheListo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TMeta1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TBaches As System.Windows.Forms.TextBox
    Friend WithEvents TBache As System.Windows.Forms.TextBox
    Friend WithEvents TNomFor As System.Windows.Forms.TextBox
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents TCodFor As System.Windows.Forms.TextBox
    Friend WithEvents TMeta2 As System.Windows.Forms.TextBox
    Friend WithEvents TBacheListo2 As System.Windows.Forms.TextBox
    Friend WithEvents TRecAlarma2 As System.Windows.Forms.TextBox
    Friend WithEvents TEstado2 As System.Windows.Forms.TextBox
    Friend WithEvents TBruto2 As System.Windows.Forms.TextBox
    Friend WithEvents TNeto2 As System.Windows.Forms.TextBox
    Friend WithEvents TStart2 As System.Windows.Forms.TextBox
    Friend WithEvents TOutput2 As System.Windows.Forms.TextBox
    Friend WithEvents TVelF2 As System.Windows.Forms.TextBox
    Friend WithEvents TVelG2 As System.Windows.Forms.TextBox
    Friend WithEvents TAFina2 As System.Windows.Forms.TextBox
    Friend WithEvents TJogsMax2 As System.Windows.Forms.TextBox
    Friend WithEvents TMetaMax2 As System.Windows.Forms.TextBox
    Friend WithEvents TMetaMin2 As System.Windows.Forms.TextBox
    Friend WithEvents FNuevoBache As System.Windows.Forms.Button
    Friend WithEvents FProceso As System.Windows.Forms.Button
    Friend WithEvents FBachesAnt As System.Windows.Forms.Button
    Friend WithEvents FCaptRep As System.Windows.Forms.Button
    Friend WithEvents FEnviaIngPLC As System.Windows.Forms.Button
    Friend WithEvents FSigMat As System.Windows.Forms.Button
    Friend WithEvents TNetoRep1 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TNetoRep2 As System.Windows.Forms.TextBox
    Friend WithEvents BAbortarPLC As System.Windows.Forms.Button
    Friend WithEvents FNuevaOP As System.Windows.Forms.Button
    Friend WithEvents FRecAlarma As System.Windows.Forms.Button
    Friend WithEvents TNetoRep4 As System.Windows.Forms.TextBox
    Friend WithEvents TEstado4 As System.Windows.Forms.TextBox
    Friend WithEvents TMetaMin4 As System.Windows.Forms.TextBox
    Friend WithEvents TMetaMax4 As System.Windows.Forms.TextBox
    Friend WithEvents TJogsMax4 As System.Windows.Forms.TextBox
    Friend WithEvents TAFina4 As System.Windows.Forms.TextBox
    Friend WithEvents TVelG4 As System.Windows.Forms.TextBox
    Friend WithEvents TVelF4 As System.Windows.Forms.TextBox
    Friend WithEvents TOutput4 As System.Windows.Forms.TextBox
    Friend WithEvents TStart4 As System.Windows.Forms.TextBox
    Friend WithEvents TMeta4 As System.Windows.Forms.TextBox
    Friend WithEvents TNeto4 As System.Windows.Forms.TextBox
    Friend WithEvents TBruto4 As System.Windows.Forms.TextBox
    Friend WithEvents TRecAlarma4 As System.Windows.Forms.TextBox
    Friend WithEvents TBacheListo4 As System.Windows.Forms.TextBox
    Friend WithEvents TNetoRep3 As System.Windows.Forms.TextBox
    Friend WithEvents TEstado3 As System.Windows.Forms.TextBox
    Friend WithEvents TMetaMin3 As System.Windows.Forms.TextBox
    Friend WithEvents TMetaMax3 As System.Windows.Forms.TextBox
    Friend WithEvents TJogsMax3 As System.Windows.Forms.TextBox
    Friend WithEvents TAFina3 As System.Windows.Forms.TextBox
    Friend WithEvents TVelG3 As System.Windows.Forms.TextBox
    Friend WithEvents TVelF3 As System.Windows.Forms.TextBox
    Friend WithEvents TOutput3 As System.Windows.Forms.TextBox
    Friend WithEvents TStart3 As System.Windows.Forms.TextBox
    Friend WithEvents TMeta3 As System.Windows.Forms.TextBox
    Friend WithEvents TNeto3 As System.Windows.Forms.TextBox
    Friend WithEvents TBruto3 As System.Windows.Forms.TextBox
    Friend WithEvents TRecAlarma3 As System.Windows.Forms.TextBox
    Friend WithEvents TBacheListo3 As System.Windows.Forms.TextBox
    Friend WithEvents BLeerPLC As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TNomTag1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TNomTag2 As System.Windows.Forms.ComboBox
    Friend WithEvents TValorEscribir2 As System.Windows.Forms.TextBox
    Friend WithEvents BEscribir2 As System.Windows.Forms.Button
    Friend WithEvents TValorLeido2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BLeer2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents FEstados As System.Windows.Forms.Button
    Friend WithEvents FRecMicros As System.Windows.Forms.Button

End Class
