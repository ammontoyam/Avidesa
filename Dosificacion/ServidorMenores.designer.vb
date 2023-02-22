<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServPantWMicros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServPantWMicros))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TRxPant = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimRx = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TTxPant = New System.Windows.Forms.TextBox()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.FVerDatosFor = New System.Windows.Forms.Button()
        Me.FBuscaOP = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TSegPant = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TSegRepPant = New System.Windows.Forms.TextBox()
        Me.FRxPant = New System.Windows.Forms.Button()
        Me.FPideDatosPant = New System.Windows.Forms.Button()
        Me.FEscribPant = New System.Windows.Forms.Button()
        Me.TSeg = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TEstadoWPant = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ShRx = New System.Windows.Forms.TextBox()
        Me.FActDatos = New System.Windows.Forms.Button()
        Me.FSigMat = New System.Windows.Forms.Button()
        Me.FPrepBache = New System.Windows.Forms.Button()
        Me.FCaptRep = New System.Windows.Forms.Button()
        Me.FProceso = New System.Windows.Forms.Button()
        Me.FGenArchOGA = New System.Windows.Forms.Button()
        Me.FTMuertos = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TError = New System.Windows.Forms.TextBox()
        Me.FArchivaProc = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TTolInf = New System.Windows.Forms.TextBox()
        Me.TTolSup = New System.Windows.Forms.TextBox()
        Me.TBache = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBrutoB1 = New System.Windows.Forms.TextBox()
        Me.TMetaSup = New System.Windows.Forms.TextBox()
        Me.TMetaInf = New System.Windows.Forms.TextBox()
        Me.TMetaT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.TNomFor = New System.Windows.Forms.TextBox()
        Me.TBaches = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TCodFor = New System.Windows.Forms.TextBox()
        Me.TPorcDif = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TDifNetoB1 = New System.Windows.Forms.TextBox()
        Me.TEstableB1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TContRep = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TCodBarras = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TRxPant
        '
        Me.TRxPant.BackColor = System.Drawing.Color.White
        Me.TRxPant.Location = New System.Drawing.Point(48, 220)
        Me.TRxPant.Multiline = True
        Me.TRxPant.Name = "TRxPant"
        Me.TRxPant.ReadOnly = True
        Me.TRxPant.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TRxPant.Size = New System.Drawing.Size(435, 109)
        Me.TRxPant.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TRxPant, " Hay un bit que debe moverse proveniente de la pantalla. Es segundero")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(919, 24)
        Me.MenuStrip1.TabIndex = 36
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSalir})
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(77, 20)
        Me.ToolStripMenuItem1.Text = "Archivo"
        '
        'mnSalir
        '
        Me.mnSalir.Name = "mnSalir"
        Me.mnSalir.Size = New System.Drawing.Size(98, 22)
        Me.mnSalir.Text = "&Salir"
        '
        'TimRx
        '
        Me.TimRx.Interval = 300
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(16, 79)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(741, 423)
        Me.TabControl1.TabIndex = 145
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPage2.Size = New System.Drawing.Size(733, 397)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Comunicaciones"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TRxPant)
        Me.GroupBox2.Controls.Add(Me.TTxPant)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(657, 345)
        Me.GroupBox2.TabIndex = 150
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pantalla"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(20, 45)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 14)
        Me.Label21.TabIndex = 148
        Me.Label21.Text = "Tx:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(20, 223)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 14)
        Me.Label17.TabIndex = 147
        Me.Label17.Text = "Rx:"
        '
        'TTxPant
        '
        Me.TTxPant.BackColor = System.Drawing.Color.White
        Me.TTxPant.Location = New System.Drawing.Point(48, 42)
        Me.TTxPant.Multiline = True
        Me.TTxPant.Name = "TTxPant"
        Me.TTxPant.ReadOnly = True
        Me.TTxPant.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TTxPant.Size = New System.Drawing.Size(435, 176)
        Me.TTxPant.TabIndex = 1
        '
        'BCancelar
        '
        Me.BCancelar.Location = New System.Drawing.Point(763, 310)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(90, 22)
        Me.BCancelar.TabIndex = 253
        Me.BCancelar.Text = "Cancelar"
        Me.BCancelar.UseVisualStyleBackColor = True
        Me.BCancelar.Visible = False
        '
        'FVerDatosFor
        '
        Me.FVerDatosFor.Location = New System.Drawing.Point(763, 252)
        Me.FVerDatosFor.Name = "FVerDatosFor"
        Me.FVerDatosFor.Size = New System.Drawing.Size(90, 23)
        Me.FVerDatosFor.TabIndex = 230
        Me.FVerDatosFor.Text = "FVerDatosFor"
        Me.FVerDatosFor.UseVisualStyleBackColor = True
        Me.FVerDatosFor.Visible = False
        '
        'FBuscaOP
        '
        Me.FBuscaOP.Location = New System.Drawing.Point(763, 286)
        Me.FBuscaOP.Name = "FBuscaOP"
        Me.FBuscaOP.Size = New System.Drawing.Size(90, 23)
        Me.FBuscaOP.TabIndex = 229
        Me.FBuscaOP.Text = "FBuscaOP"
        Me.FBuscaOP.UseVisualStyleBackColor = True
        Me.FBuscaOP.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(760, 131)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 155
        Me.Label25.Text = "Seg. en Pant."
        '
        'TSegPant
        '
        Me.TSegPant.Location = New System.Drawing.Point(838, 128)
        Me.TSegPant.Name = "TSegPant"
        Me.TSegPant.ReadOnly = True
        Me.TSegPant.Size = New System.Drawing.Size(58, 20)
        Me.TSegPant.TabIndex = 156
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(760, 102)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Seg. sin datos:"
        '
        'TSegRepPant
        '
        Me.TSegRepPant.Location = New System.Drawing.Point(853, 99)
        Me.TSegRepPant.Name = "TSegRepPant"
        Me.TSegRepPant.ReadOnly = True
        Me.TSegRepPant.Size = New System.Drawing.Size(43, 20)
        Me.TSegRepPant.TabIndex = 11
        '
        'FRxPant
        '
        Me.FRxPant.Location = New System.Drawing.Point(763, 192)
        Me.FRxPant.Name = "FRxPant"
        Me.FRxPant.Size = New System.Drawing.Size(90, 25)
        Me.FRxPant.TabIndex = 146
        Me.FRxPant.Text = "FRxPant"
        Me.FRxPant.UseVisualStyleBackColor = True
        Me.FRxPant.Visible = False
        '
        'FPideDatosPant
        '
        Me.FPideDatosPant.Location = New System.Drawing.Point(763, 162)
        Me.FPideDatosPant.Name = "FPideDatosPant"
        Me.FPideDatosPant.Size = New System.Drawing.Size(90, 25)
        Me.FPideDatosPant.TabIndex = 152
        Me.FPideDatosPant.Text = "FPideDatosPant"
        Me.FPideDatosPant.UseVisualStyleBackColor = True
        Me.FPideDatosPant.Visible = False
        '
        'FEscribPant
        '
        Me.FEscribPant.Location = New System.Drawing.Point(763, 221)
        Me.FEscribPant.Name = "FEscribPant"
        Me.FEscribPant.Size = New System.Drawing.Size(90, 25)
        Me.FEscribPant.TabIndex = 151
        Me.FEscribPant.Text = "FEscribPant"
        Me.FEscribPant.UseVisualStyleBackColor = True
        Me.FEscribPant.Visible = False
        '
        'TSeg
        '
        Me.TSeg.Location = New System.Drawing.Point(853, 73)
        Me.TSeg.Name = "TSeg"
        Me.TSeg.Size = New System.Drawing.Size(36, 20)
        Me.TSeg.TabIndex = 157
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(554, 61)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(34, 13)
        Me.Label24.TabIndex = 150
        Me.Label24.Text = "Conx:"
        '
        'TEstadoWPant
        '
        Me.TEstadoWPant.BackColor = System.Drawing.Color.White
        Me.TEstadoWPant.Location = New System.Drawing.Point(594, 57)
        Me.TEstadoWPant.Multiline = True
        Me.TEstadoWPant.Name = "TEstadoWPant"
        Me.TEstadoWPant.ReadOnly = True
        Me.TEstadoWPant.Size = New System.Drawing.Size(21, 17)
        Me.TEstadoWPant.TabIndex = 41
        Me.TEstadoWPant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(919, 25)
        Me.ToolStrip1.TabIndex = 146
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
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(794, 80)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(29, 13)
        Me.Label26.TabIndex = 158
        Me.Label26.Text = "Seg."
        '
        'ShRx
        '
        Me.ShRx.BackColor = System.Drawing.Color.Silver
        Me.ShRx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShRx.Location = New System.Drawing.Point(621, 61)
        Me.ShRx.Multiline = True
        Me.ShRx.Name = "ShRx"
        Me.ShRx.ReadOnly = True
        Me.ShRx.Size = New System.Drawing.Size(10, 12)
        Me.ShRx.TabIndex = 160
        Me.ShRx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ShRx.Visible = False
        '
        'FActDatos
        '
        Me.FActDatos.Location = New System.Drawing.Point(763, 458)
        Me.FActDatos.Name = "FActDatos"
        Me.FActDatos.Size = New System.Drawing.Size(90, 23)
        Me.FActDatos.TabIndex = 162
        Me.FActDatos.Text = "FActDatos"
        Me.FActDatos.UseVisualStyleBackColor = True
        Me.FActDatos.Visible = False
        '
        'FSigMat
        '
        Me.FSigMat.Location = New System.Drawing.Point(763, 435)
        Me.FSigMat.Name = "FSigMat"
        Me.FSigMat.Size = New System.Drawing.Size(90, 23)
        Me.FSigMat.TabIndex = 163
        Me.FSigMat.Text = "FSigMat"
        Me.FSigMat.UseVisualStyleBackColor = True
        Me.FSigMat.Visible = False
        '
        'FPrepBache
        '
        Me.FPrepBache.Location = New System.Drawing.Point(763, 376)
        Me.FPrepBache.Name = "FPrepBache"
        Me.FPrepBache.Size = New System.Drawing.Size(90, 27)
        Me.FPrepBache.TabIndex = 164
        Me.FPrepBache.Text = "FPrepBache"
        Me.FPrepBache.UseVisualStyleBackColor = True
        Me.FPrepBache.Visible = False
        '
        'FCaptRep
        '
        Me.FCaptRep.Location = New System.Drawing.Point(763, 482)
        Me.FCaptRep.Name = "FCaptRep"
        Me.FCaptRep.Size = New System.Drawing.Size(90, 23)
        Me.FCaptRep.TabIndex = 254
        Me.FCaptRep.Text = "FCaptRep"
        Me.FCaptRep.UseVisualStyleBackColor = True
        Me.FCaptRep.Visible = False
        '
        'FProceso
        '
        Me.FProceso.Location = New System.Drawing.Point(763, 338)
        Me.FProceso.Name = "FProceso"
        Me.FProceso.Size = New System.Drawing.Size(90, 38)
        Me.FProceso.TabIndex = 255
        Me.FProceso.Text = "FProceso"
        Me.FProceso.UseVisualStyleBackColor = True
        Me.FProceso.Visible = False
        '
        'FGenArchOGA
        '
        Me.FGenArchOGA.Location = New System.Drawing.Point(763, 409)
        Me.FGenArchOGA.Name = "FGenArchOGA"
        Me.FGenArchOGA.Size = New System.Drawing.Size(90, 23)
        Me.FGenArchOGA.TabIndex = 256
        Me.FGenArchOGA.Text = "FGenArcOGA"
        Me.FGenArchOGA.UseVisualStyleBackColor = True
        Me.FGenArchOGA.Visible = False
        '
        'FTMuertos
        '
        Me.FTMuertos.Location = New System.Drawing.Point(763, 502)
        Me.FTMuertos.Name = "FTMuertos"
        Me.FTMuertos.Size = New System.Drawing.Size(90, 27)
        Me.FTMuertos.TabIndex = 257
        Me.FTMuertos.Text = "FTMuertos"
        Me.FTMuertos.UseVisualStyleBackColor = True
        Me.FTMuertos.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(17, 509)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(50, 13)
        Me.Label37.TabIndex = 259
        Me.Label37.Text = "Mensaje:"
        '
        'TError
        '
        Me.TError.BackColor = System.Drawing.SystemColors.Control
        Me.TError.Location = New System.Drawing.Point(16, 531)
        Me.TError.Multiline = True
        Me.TError.Name = "TError"
        Me.TError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TError.Size = New System.Drawing.Size(741, 64)
        Me.TError.TabIndex = 258
        '
        'FArchivaProc
        '
        Me.FArchivaProc.Location = New System.Drawing.Point(765, 533)
        Me.FArchivaProc.Name = "FArchivaProc"
        Me.FArchivaProc.Size = New System.Drawing.Size(87, 26)
        Me.FArchivaProc.TabIndex = 260
        Me.FArchivaProc.Text = "FarcivaProc"
        Me.FArchivaProc.UseVisualStyleBackColor = True
        Me.FArchivaProc.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label34)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.TContRep)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.TEstableB1)
        Me.GroupBox3.Controls.Add(Me.TDifNetoB1)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.TPorcDif)
        Me.GroupBox3.Controls.Add(Me.TCodFor)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.TBaches)
        Me.GroupBox3.Controls.Add(Me.TNomFor)
        Me.GroupBox3.Controls.Add(Me.TOPs)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TMetaT)
        Me.GroupBox3.Controls.Add(Me.TMetaInf)
        Me.GroupBox3.Controls.Add(Me.TMetaSup)
        Me.GroupBox3.Controls.Add(Me.TBrutoB1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TBache)
        Me.GroupBox3.Controls.Add(Me.TTolSup)
        Me.GroupBox3.Controls.Add(Me.TTolInf)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(710, 289)
        Me.GroupBox3.TabIndex = 40
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Micros Monocangilón"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(236, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 176
        Me.Label5.Text = "Toler. Inf."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(236, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "Toler. Sup."
        '
        'TTolInf
        '
        Me.TTolInf.Location = New System.Drawing.Point(317, 234)
        Me.TTolInf.Name = "TTolInf"
        Me.TTolInf.ReadOnly = True
        Me.TTolInf.Size = New System.Drawing.Size(44, 21)
        Me.TTolInf.TabIndex = 174
        Me.TTolInf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TTolSup
        '
        Me.TTolSup.Location = New System.Drawing.Point(317, 208)
        Me.TTolSup.Name = "TTolSup"
        Me.TTolSup.ReadOnly = True
        Me.TTolSup.Size = New System.Drawing.Size(44, 21)
        Me.TTolSup.TabIndex = 173
        Me.TTolSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TBache
        '
        Me.TBache.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBache.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBache.Location = New System.Drawing.Point(114, 80)
        Me.TBache.Name = "TBache"
        Me.TBache.ReadOnly = True
        Me.TBache.Size = New System.Drawing.Size(55, 29)
        Me.TBache.TabIndex = 178
        Me.TBache.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Peso Meta:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(24, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 17)
        Me.Label13.TabIndex = 179
        Me.Label13.Text = "Bache no."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 169
        Me.Label1.Text = "Peso Bruto:"
        '
        'TBrutoB1
        '
        Me.TBrutoB1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBrutoB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBrutoB1.Location = New System.Drawing.Point(114, 181)
        Me.TBrutoB1.Name = "TBrutoB1"
        Me.TBrutoB1.ReadOnly = True
        Me.TBrutoB1.Size = New System.Drawing.Size(73, 20)
        Me.TBrutoB1.TabIndex = 168
        Me.TBrutoB1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TMetaSup
        '
        Me.TMetaSup.Location = New System.Drawing.Point(367, 208)
        Me.TMetaSup.Name = "TMetaSup"
        Me.TMetaSup.ReadOnly = True
        Me.TMetaSup.Size = New System.Drawing.Size(44, 21)
        Me.TMetaSup.TabIndex = 182
        Me.TMetaSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TMetaInf
        '
        Me.TMetaInf.Location = New System.Drawing.Point(367, 234)
        Me.TMetaInf.Name = "TMetaInf"
        Me.TMetaInf.ReadOnly = True
        Me.TMetaInf.Size = New System.Drawing.Size(44, 21)
        Me.TMetaInf.TabIndex = 183
        Me.TMetaInf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TMetaT
        '
        Me.TMetaT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TMetaT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMetaT.Location = New System.Drawing.Point(114, 152)
        Me.TMetaT.Name = "TMetaT"
        Me.TMetaT.ReadOnly = True
        Me.TMetaT.Size = New System.Drawing.Size(73, 20)
        Me.TMetaT.TabIndex = 165
        Me.TMetaT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 15)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "OP"
        '
        'TOPs
        '
        Me.TOPs.Location = New System.Drawing.Point(114, 33)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.ReadOnly = True
        Me.TOPs.Size = New System.Drawing.Size(154, 21)
        Me.TOPs.TabIndex = 155
        '
        'TNomFor
        '
        Me.TNomFor.Location = New System.Drawing.Point(205, 60)
        Me.TNomFor.Name = "TNomFor"
        Me.TNomFor.ReadOnly = True
        Me.TNomFor.Size = New System.Drawing.Size(270, 21)
        Me.TNomFor.TabIndex = 160
        '
        'TBaches
        '
        Me.TBaches.Location = New System.Drawing.Point(114, 108)
        Me.TBaches.Name = "TBaches"
        Me.TBaches.ReadOnly = True
        Me.TBaches.Size = New System.Drawing.Size(45, 21)
        Me.TBaches.TabIndex = 152
        Me.TBaches.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(52, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 154
        Me.Label10.Text = "Baches:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 15)
        Me.Label9.TabIndex = 153
        Me.Label9.Text = "Fórmula:"
        '
        'TCodFor
        '
        Me.TCodFor.Location = New System.Drawing.Point(114, 60)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.ReadOnly = True
        Me.TCodFor.Size = New System.Drawing.Size(73, 21)
        Me.TCodFor.TabIndex = 151
        Me.TCodFor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TPorcDif
        '
        Me.TPorcDif.Location = New System.Drawing.Point(457, 233)
        Me.TPorcDif.Name = "TPorcDif"
        Me.TPorcDif.ReadOnly = True
        Me.TPorcDif.Size = New System.Drawing.Size(44, 21)
        Me.TPorcDif.TabIndex = 202
        Me.TPorcDif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(433, 240)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(18, 15)
        Me.Label18.TabIndex = 203
        Me.Label18.Text = "%"
        '
        'TDifNetoB1
        '
        Me.TDifNetoB1.Location = New System.Drawing.Point(461, 206)
        Me.TDifNetoB1.Name = "TDifNetoB1"
        Me.TDifNetoB1.Size = New System.Drawing.Size(47, 21)
        Me.TDifNetoB1.TabIndex = 214
        '
        'TEstableB1
        '
        Me.TEstableB1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TEstableB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.74545!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEstableB1.Location = New System.Drawing.Point(638, 114)
        Me.TEstableB1.Name = "TEstableB1"
        Me.TEstableB1.ReadOnly = True
        Me.TEstableB1.Size = New System.Drawing.Size(45, 28)
        Me.TEstableB1.TabIndex = 215
        Me.TEstableB1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(577, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 15)
        Me.Label12.TabIndex = 217
        Me.Label12.Text = "Estable"
        '
        'TContRep
        '
        Me.TContRep.Location = New System.Drawing.Point(461, 33)
        Me.TContRep.Name = "TContRep"
        Me.TContRep.ReadOnly = True
        Me.TContRep.Size = New System.Drawing.Size(73, 21)
        Me.TContRep.TabIndex = 218
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(377, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 15)
        Me.Label15.TabIndex = 219
        Me.Label15.Text = "Cont.Rep."
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(433, 214)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(22, 15)
        Me.Label34.TabIndex = 228
        Me.Label34.Text = "Dif"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 349)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 220
        Me.Label16.Text = "Desde Pant:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(37, 376)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(65, 13)
        Me.Label38.TabIndex = 259
        Me.Label38.Text = "Cód. Barras:"
        '
        'TCodBarras
        '
        Me.TCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TCodBarras.Location = New System.Drawing.Point(100, 375)
        Me.TCodBarras.Name = "TCodBarras"
        Me.TCodBarras.ReadOnly = True
        Me.TCodBarras.Size = New System.Drawing.Size(162, 18)
        Me.TCodBarras.TabIndex = 285
        Me.TCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.TCodBarras)
        Me.TabPage1.Controls.Add(Me.Label38)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.ImageIndex = 0
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(733, 397)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Proceso"
        '
        'ServPantWMicros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 607)
        Me.Controls.Add(Me.FArchivaProc)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.TError)
        Me.Controls.Add(Me.FTMuertos)
        Me.Controls.Add(Me.FGenArchOGA)
        Me.Controls.Add(Me.FProceso)
        Me.Controls.Add(Me.FCaptRep)
        Me.Controls.Add(Me.FPrepBache)
        Me.Controls.Add(Me.FSigMat)
        Me.Controls.Add(Me.FBuscaOP)
        Me.Controls.Add(Me.FVerDatosFor)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.FActDatos)
        Me.Controls.Add(Me.ShRx)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.FRxPant)
        Me.Controls.Add(Me.TSegPant)
        Me.Controls.Add(Me.TSeg)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TEstadoWPant)
        Me.Controls.Add(Me.FPideDatosPant)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.FEscribPant)
        Me.Controls.Add(Me.TSegRepPant)
        Me.Controls.Add(Me.Label24)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServPantWMicros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla Micros Monocangilón"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents TimRx As System.Windows.Forms.Timer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TEstadoWPant As System.Windows.Forms.TextBox
    Friend WithEvents TSegRepPant As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TTxPant As System.Windows.Forms.TextBox
    Friend WithEvents TRxPant As System.Windows.Forms.TextBox
    Friend WithEvents FRxPant As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents FEscribPant As System.Windows.Forms.Button
    Friend WithEvents FPideDatosPant As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TSegPant As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSeg As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ShRx As System.Windows.Forms.TextBox
    Friend WithEvents FActDatos As System.Windows.Forms.Button
    Friend WithEvents FVerDatosFor As System.Windows.Forms.Button
    Friend WithEvents FBuscaOP As System.Windows.Forms.Button
    Friend WithEvents BCancelar As System.Windows.Forms.Button
    Friend WithEvents FSigMat As System.Windows.Forms.Button
    Friend WithEvents FPrepBache As System.Windows.Forms.Button
    Friend WithEvents FCaptRep As System.Windows.Forms.Button
    Friend WithEvents FProceso As System.Windows.Forms.Button
    Friend WithEvents FGenArchOGA As System.Windows.Forms.Button
    Friend WithEvents FTMuertos As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TError As System.Windows.Forms.TextBox
    Friend WithEvents FArchivaProc As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TCodBarras As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TContRep As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TEstableB1 As System.Windows.Forms.TextBox
    Friend WithEvents TDifNetoB1 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TPorcDif As System.Windows.Forms.TextBox
    Friend WithEvents TCodFor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TBaches As System.Windows.Forms.TextBox
    Friend WithEvents TNomFor As System.Windows.Forms.TextBox
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TMetaT As System.Windows.Forms.TextBox
    Friend WithEvents TMetaInf As System.Windows.Forms.TextBox
    Friend WithEvents TMetaSup As System.Windows.Forms.TextBox
    Friend WithEvents TBrutoB1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TBache As System.Windows.Forms.TextBox
    Friend WithEvents TTolSup As System.Windows.Forms.TextBox
    Friend WithEvents TTolInf As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
