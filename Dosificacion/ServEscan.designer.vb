<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServEscan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServEscan))
        Me.TimRx = New System.Windows.Forms.Timer(Me.components)
        Me.TSeg = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.BSalir = New System.Windows.Forms.ToolStripButton()
        Me.Tip = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BConectar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TError = New System.Windows.Forms.TextBox()
        Me.TPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShRx = New System.Windows.Forms.TextBox()
        Me.TEstadoWPant = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TRx = New System.Windows.Forms.TextBox()
        Me.FConsMed = New System.Windows.Forms.Button()
        Me.TOPs = New System.Windows.Forms.TextBox()
        Me.TBache = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.THora = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimRx
        '
        Me.TimRx.Enabled = True
        Me.TimRx.Interval = 950
        '
        'TSeg
        '
        Me.TSeg.BackColor = System.Drawing.SystemColors.Control
        Me.TSeg.Location = New System.Drawing.Point(328, 56)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(399, 24)
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
        Me.ToolStrip2.Size = New System.Drawing.Size(399, 25)
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
        Me.Tip.Location = New System.Drawing.Point(49, 54)
        Me.Tip.Name = "Tip"
        Me.Tip.Size = New System.Drawing.Size(120, 20)
        Me.Tip.TabIndex = 262
        Me.Tip.Text = "192.168.1.10"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "IP:"
        '
        'BConectar
        '
        Me.BConectar.Location = New System.Drawing.Point(101, 80)
        Me.BConectar.Name = "BConectar"
        Me.BConectar.Size = New System.Drawing.Size(68, 22)
        Me.BConectar.TabIndex = 264
        Me.BConectar.Text = "Conectar"
        Me.BConectar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(98, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(239, 25)
        Me.Label4.TabIndex = 303
        Me.Label4.Text = "Enlace con Escáner de Micros"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TError
        '
        Me.TError.BackColor = System.Drawing.SystemColors.Control
        Me.TError.Location = New System.Drawing.Point(12, 196)
        Me.TError.Multiline = True
        Me.TError.Name = "TError"
        Me.TError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TError.Size = New System.Drawing.Size(358, 304)
        Me.TError.TabIndex = 304
        '
        'TPort
        '
        Me.TPort.Location = New System.Drawing.Point(49, 80)
        Me.TPort.Name = "TPort"
        Me.TPort.Size = New System.Drawing.Size(46, 20)
        Me.TPort.TabIndex = 305
        Me.TPort.Text = "4097"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 306
        Me.Label1.Text = "Port:"
        '
        'ShRx
        '
        Me.ShRx.BackColor = System.Drawing.Color.Silver
        Me.ShRx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShRx.Location = New System.Drawing.Point(254, 54)
        Me.ShRx.Multiline = True
        Me.ShRx.Name = "ShRx"
        Me.ShRx.ReadOnly = True
        Me.ShRx.Size = New System.Drawing.Size(10, 17)
        Me.ShRx.TabIndex = 309
        Me.ShRx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ShRx.Visible = False
        '
        'TEstadoWPant
        '
        Me.TEstadoWPant.BackColor = System.Drawing.Color.White
        Me.TEstadoWPant.Location = New System.Drawing.Point(227, 54)
        Me.TEstadoWPant.Multiline = True
        Me.TEstadoWPant.Name = "TEstadoWPant"
        Me.TEstadoWPant.ReadOnly = True
        Me.TEstadoWPant.Size = New System.Drawing.Size(21, 17)
        Me.TEstadoWPant.TabIndex = 307
        Me.TEstadoWPant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(187, 58)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(34, 13)
        Me.Label24.TabIndex = 308
        Me.Label24.Text = "Conx:"
        '
        'TRx
        '
        Me.TRx.BackColor = System.Drawing.Color.White
        Me.TRx.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TRx.Location = New System.Drawing.Point(12, 108)
        Me.TRx.Multiline = True
        Me.TRx.Name = "TRx"
        Me.TRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TRx.Size = New System.Drawing.Size(157, 82)
        Me.TRx.TabIndex = 310
        '
        'FConsMed
        '
        Me.FConsMed.Location = New System.Drawing.Point(286, 159)
        Me.FConsMed.Name = "FConsMed"
        Me.FConsMed.Size = New System.Drawing.Size(84, 22)
        Me.FConsMed.TabIndex = 311
        Me.FConsMed.Text = "FConsMed"
        Me.FConsMed.UseVisualStyleBackColor = True
        Me.FConsMed.Visible = False
        '
        'TOPs
        '
        Me.TOPs.Location = New System.Drawing.Point(316, 84)
        Me.TOPs.Name = "TOPs"
        Me.TOPs.Size = New System.Drawing.Size(54, 20)
        Me.TOPs.TabIndex = 372
        Me.TOPs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBache
        '
        Me.TBache.Location = New System.Drawing.Point(316, 108)
        Me.TBache.Name = "TBache"
        Me.TBache.Size = New System.Drawing.Size(54, 20)
        Me.TBache.TabIndex = 373
        Me.TBache.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(286, 87)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(25, 13)
        Me.Label14.TabIndex = 374
        Me.Label14.Text = "OP:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(270, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 375
        Me.Label12.Text = "Bache:"
        '
        'THora
        '
        Me.THora.Location = New System.Drawing.Point(291, 131)
        Me.THora.Name = "THora"
        Me.THora.Size = New System.Drawing.Size(79, 13)
        Me.THora.TabIndex = 376
        Me.THora.Text = "Bache:"
        '
        'ServEscan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 533)
        Me.Controls.Add(Me.THora)
        Me.Controls.Add(Me.TOPs)
        Me.Controls.Add(Me.TBache)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.FConsMed)
        Me.Controls.Add(Me.TRx)
        Me.Controls.Add(Me.ShRx)
        Me.Controls.Add(Me.TEstadoWPant)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TPort)
        Me.Controls.Add(Me.TError)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BConectar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Tip)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TSeg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ServEscan"
        Me.Text = "Servidor Escáner de Micros"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimRx As System.Windows.Forms.Timer

    Friend WithEvents TSeg As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents Tip As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BConectar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TError As System.Windows.Forms.TextBox
    Friend WithEvents TPort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShRx As System.Windows.Forms.TextBox
    Friend WithEvents TEstadoWPant As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TRx As System.Windows.Forms.TextBox
    Friend WithEvents FConsMed As System.Windows.Forms.Button
    Friend WithEvents TOPs As System.Windows.Forms.TextBox
    Friend WithEvents TBache As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents THora As System.Windows.Forms.Label

End Class
