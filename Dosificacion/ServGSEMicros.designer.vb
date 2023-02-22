<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServGSEMicros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServGSEMicros))
        Me.COM = New System.IO.Ports.SerialPort(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BLimpiar = New System.Windows.Forms.Button()
        Me.TimRx = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnMateriales = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnEnviarMaterial = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOtros = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnServImp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnComunicacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnConfigurar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ShRx = New System.Windows.Forms.Panel()
        Me.TCodFor = New System.Windows.Forms.TextBox()
        Me.TCont = New System.Windows.Forms.TextBox()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.BPruebaCoM = New System.Windows.Forms.Button()
        Me.BPideRep = New System.Windows.Forms.Button()
        Me.TEstadoW = New System.Windows.Forms.TextBox()
        Me.TMonRx = New System.Windows.Forms.TextBox()
        Me.TTx = New System.Windows.Forms.TextBox()
        Me.TRx = New System.Windows.Forms.TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BBorraRep = New System.Windows.Forms.Button()
        Me.BRecRep = New System.Windows.Forms.Button()
        Me.BEnviaOP = New System.Windows.Forms.Button()
        Me.BEnviaFor = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BLimpiar
        '
        Me.BLimpiar.Image = CType(resources.GetObject("BLimpiar.Image"), System.Drawing.Image)
        Me.BLimpiar.Location = New System.Drawing.Point(488, 213)
        Me.BLimpiar.Name = "BLimpiar"
        Me.BLimpiar.Size = New System.Drawing.Size(27, 21)
        Me.BLimpiar.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.BLimpiar, " Limpiar Texto")
        Me.BLimpiar.UseVisualStyleBackColor = True
        '
        'TimRx
        '
        Me.TimRx.Enabled = True
        Me.TimRx.Interval = 407
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.mnMateriales, Me.mnOtros, Me.mnComunicacion})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 27
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.Image = CType(resources.GetObject("ArchivoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'mnMateriales
        '
        Me.mnMateriales.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnEnviarMaterial})
        Me.mnMateriales.Image = CType(resources.GetObject("mnMateriales.Image"), System.Drawing.Image)
        Me.mnMateriales.Name = "mnMateriales"
        Me.mnMateriales.Size = New System.Drawing.Size(93, 20)
        Me.mnMateriales.Text = "Materiales"
        '
        'mnEnviarMaterial
        '
        Me.mnEnviarMaterial.Enabled = False
        Me.mnEnviarMaterial.Name = "mnEnviarMaterial"
        Me.mnEnviarMaterial.Size = New System.Drawing.Size(234, 22)
        Me.mnEnviarMaterial.Text = "Enviar un solo Material al GSE"
        '
        'mnOtros
        '
        Me.mnOtros.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnServImp})
        Me.mnOtros.Image = CType(resources.GetObject("mnOtros.Image"), System.Drawing.Image)
        Me.mnOtros.Name = "mnOtros"
        Me.mnOtros.Size = New System.Drawing.Size(66, 20)
        Me.mnOtros.Text = "Otros"
        '
        'mnServImp
        '
        Me.mnServImp.Name = "mnServImp"
        Me.mnServImp.Size = New System.Drawing.Size(206, 22)
        Me.mnServImp.Text = "Servidor Impresora GSE"
        '
        'mnComunicacion
        '
        Me.mnComunicacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnConfigurar})
        Me.mnComunicacion.Image = CType(resources.GetObject("mnComunicacion.Image"), System.Drawing.Image)
        Me.mnComunicacion.Name = "mnComunicacion"
        Me.mnComunicacion.Size = New System.Drawing.Size(127, 20)
        Me.mnComunicacion.Text = "Comunicaciones"
        Me.mnComunicacion.ToolTipText = "Comunicaciones"
        '
        'mnConfigurar
        '
        Me.mnConfigurar.Image = CType(resources.GetObject("mnConfigurar.Image"), System.Drawing.Image)
        Me.mnConfigurar.Name = "mnConfigurar"
        Me.mnConfigurar.Size = New System.Drawing.Size(133, 22)
        Me.mnConfigurar.Text = "&Configurar"
        Me.mnConfigurar.ToolTipText = "Configurar Comunicaciones"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 52)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(548, 499)
        Me.TabControl1.TabIndex = 29
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.ShRx)
        Me.TabPage1.Controls.Add(Me.TCodFor)
        Me.TabPage1.Controls.Add(Me.TCont)
        Me.TabPage1.Controls.Add(Me.TOPs)
        Me.TabPage1.Controls.Add(Me.BPruebaCoM)
        Me.TabPage1.Controls.Add(Me.BPideRep)
        Me.TabPage1.Controls.Add(Me.TEstadoW)
        Me.TabPage1.Controls.Add(Me.TMonRx)
        Me.TabPage1.Controls.Add(Me.BLimpiar)
        Me.TabPage1.Controls.Add(Me.TTx)
        Me.TabPage1.Controls.Add(Me.TRx)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(540, 473)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información de GSE"
        '
        'ShRx
        '
        Me.ShRx.BackColor = System.Drawing.Color.Silver
        Me.ShRx.Location = New System.Drawing.Point(299, 10)
        Me.ShRx.Name = "ShRx"
        Me.ShRx.Size = New System.Drawing.Size(14, 16)
        Me.ShRx.TabIndex = 59
        '
        'TCodFor
        '
        Me.TCodFor.Location = New System.Drawing.Point(235, 229)
        Me.TCodFor.Name = "TCodFor"
        Me.TCodFor.Size = New System.Drawing.Size(100, 20)
        Me.TCodFor.TabIndex = 49
        '
        'TCont
        '
        Me.TCont.Location = New System.Drawing.Point(128, 229)
        Me.TCont.Name = "TCont"
        Me.TCont.Size = New System.Drawing.Size(100, 20)
        Me.TCont.TabIndex = 48
        '
        'TOPs
        '
        Me.TOPs.Location = New System.Drawing.Point(16, 229)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.Size = New System.Drawing.Size(100, 20)
        Me.TOPs.TabIndex = 44
        '
        'BPruebaCoM
        '
        Me.BPruebaCoM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPruebaCoM.ForeColor = System.Drawing.Color.Blue
        Me.BPruebaCoM.Image = CType(resources.GetObject("BPruebaCoM.Image"), System.Drawing.Image)
        Me.BPruebaCoM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BPruebaCoM.Location = New System.Drawing.Point(108, 433)
        Me.BPruebaCoM.Name = "BPruebaCoM"
        Me.BPruebaCoM.Size = New System.Drawing.Size(95, 24)
        Me.BPruebaCoM.TabIndex = 41
        Me.BPruebaCoM.Text = "TestCoM"
        Me.BPruebaCoM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BPruebaCoM.UseVisualStyleBackColor = True
        '
        'BPideRep
        '
        Me.BPideRep.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPideRep.ForeColor = System.Drawing.Color.Blue
        Me.BPideRep.Image = CType(resources.GetObject("BPideRep.Image"), System.Drawing.Image)
        Me.BPideRep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BPideRep.Location = New System.Drawing.Point(209, 433)
        Me.BPideRep.Name = "BPideRep"
        Me.BPideRep.Size = New System.Drawing.Size(84, 24)
        Me.BPideRep.TabIndex = 40
        Me.BPideRep.Text = "Pedir Rep"
        Me.BPideRep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BPideRep.UseVisualStyleBackColor = True
        '
        'TEstadoW
        '
        Me.TEstadoW.BackColor = System.Drawing.Color.White
        Me.TEstadoW.Location = New System.Drawing.Point(380, 8)
        Me.TEstadoW.Multiline = True
        Me.TEstadoW.Name = "TEstadoW"
        Me.TEstadoW.ReadOnly = True
        Me.TEstadoW.Size = New System.Drawing.Size(16, 16)
        Me.TEstadoW.TabIndex = 38
        Me.TEstadoW.Text = "7"
        Me.TEstadoW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMonRx
        '
        Me.TMonRx.Location = New System.Drawing.Point(318, 6)
        Me.TMonRx.Name = "TMonRx"
        Me.TMonRx.ReadOnly = True
        Me.TMonRx.Size = New System.Drawing.Size(57, 20)
        Me.TMonRx.TabIndex = 36
        '
        'TTx
        '
        Me.TTx.Location = New System.Drawing.Point(7, 253)
        Me.TTx.Multiline = True
        Me.TTx.Name = "TTx"
        Me.TTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TTx.Size = New System.Drawing.Size(475, 174)
        Me.TTx.TabIndex = 29
        '
        'TRx
        '
        Me.TRx.Location = New System.Drawing.Point(6, 32)
        Me.TRx.Multiline = True
        Me.TRx.Name = "TRx"
        Me.TRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TRx.Size = New System.Drawing.Size(475, 191)
        Me.TRx.TabIndex = 28
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BSalir, Me.ToolStripSeparator9})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(792, 25)
        Me.ToolStrip2.TabIndex = 33
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
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BBorraRep)
        Me.Panel2.Controls.Add(Me.BRecRep)
        Me.Panel2.Controls.Add(Me.BEnviaOP)
        Me.Panel2.Controls.Add(Me.BEnviaFor)
        Me.Panel2.Location = New System.Drawing.Point(566, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(170, 480)
        Me.Panel2.TabIndex = 34
        '
        'BBorraRep
        '
        Me.BBorraRep.Location = New System.Drawing.Point(3, 66)
        Me.BBorraRep.Name = "BBorraRep"
        Me.BBorraRep.Size = New System.Drawing.Size(75, 24)
        Me.BBorraRep.TabIndex = 48
        Me.BBorraRep.Text = "BBorraRep"
        Me.BBorraRep.UseVisualStyleBackColor = True
        Me.BBorraRep.Visible = False
        '
        'BRecRep
        '
        Me.BRecRep.Location = New System.Drawing.Point(3, 45)
        Me.BRecRep.Name = "BRecRep"
        Me.BRecRep.Size = New System.Drawing.Size(75, 24)
        Me.BRecRep.TabIndex = 47
        Me.BRecRep.Text = "BRecRep"
        Me.BRecRep.UseVisualStyleBackColor = True
        Me.BRecRep.Visible = False
        '
        'BEnviaOP
        '
        Me.BEnviaOP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BEnviaOP.ForeColor = System.Drawing.Color.Blue
        Me.BEnviaOP.Image = CType(resources.GetObject("BEnviaOP.Image"), System.Drawing.Image)
        Me.BEnviaOP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BEnviaOP.Location = New System.Drawing.Point(3, 3)
        Me.BEnviaOP.Name = "BEnviaOP"
        Me.BEnviaOP.Size = New System.Drawing.Size(95, 24)
        Me.BEnviaOP.TabIndex = 46
        Me.BEnviaOP.Text = "Enviar OP"
        Me.BEnviaOP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BEnviaOP.UseVisualStyleBackColor = True
        Me.BEnviaOP.Visible = False
        '
        'BEnviaFor
        '
        Me.BEnviaFor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BEnviaFor.ForeColor = System.Drawing.Color.Blue
        Me.BEnviaFor.Image = CType(resources.GetObject("BEnviaFor.Image"), System.Drawing.Image)
        Me.BEnviaFor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BEnviaFor.Location = New System.Drawing.Point(4, 24)
        Me.BEnviaFor.Name = "BEnviaFor"
        Me.BEnviaFor.Size = New System.Drawing.Size(95, 24)
        Me.BEnviaFor.TabIndex = 45
        Me.BEnviaFor.Text = "Enviar For"
        Me.BEnviaFor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BEnviaFor.UseVisualStyleBackColor = True
        Me.BEnviaFor.Visible = False
        '
        'ServGSEMicros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 557)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServGSEMicros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor GSE Micros"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents COM As System.IO.Ports.SerialPort
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TimRx As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnMateriales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOtros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnComunicacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnConfigurar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents BPruebaCoM As System.Windows.Forms.Button
    Friend WithEvents BPideRep As System.Windows.Forms.Button
    Friend WithEvents TEstadoW As System.Windows.Forms.TextBox
    Friend WithEvents TMonRx As System.Windows.Forms.TextBox
    Friend WithEvents BLimpiar As System.Windows.Forms.Button
    Friend WithEvents TTx As System.Windows.Forms.TextBox
    Friend WithEvents TRx As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents TCodFor As System.Windows.Forms.TextBox
    Friend WithEvents TCont As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BBorraRep As System.Windows.Forms.Button
    Friend WithEvents BRecRep As System.Windows.Forms.Button
    Friend WithEvents BEnviaOP As System.Windows.Forms.Button
    Friend WithEvents BEnviaFor As System.Windows.Forms.Button
    Friend WithEvents mnServImp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnEnviarMaterial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShRx As System.Windows.Forms.Panel
End Class
