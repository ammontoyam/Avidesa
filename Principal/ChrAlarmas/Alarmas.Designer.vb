<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Alarmas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Alarmas))
        Me.TMensaje = New System.Windows.Forms.TextBox()
        Me.DGAlarmas = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alarma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BReconoceAlarm = New System.Windows.Forms.Button()
        Me.TimUnload = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DGAlarmas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TMensaje
        '
        Me.TMensaje.BackColor = System.Drawing.Color.Yellow
        Me.TMensaje.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TMensaje.Location = New System.Drawing.Point(22, 29)
        Me.TMensaje.Multiline = True
        Me.TMensaje.Name = "TMensaje"
        Me.TMensaje.ReadOnly = True
        Me.TMensaje.Size = New System.Drawing.Size(802, 87)
        Me.TMensaje.TabIndex = 2
        Me.TMensaje.Text = "-"
        Me.TMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DGAlarmas
        '
        Me.DGAlarmas.AllowUserToAddRows = False
        Me.DGAlarmas.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGAlarmas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGAlarmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGAlarmas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Fecha, Me.Alarma})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGAlarmas.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGAlarmas.Location = New System.Drawing.Point(22, 130)
        Me.DGAlarmas.Name = "DGAlarmas"
        Me.DGAlarmas.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGAlarmas.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGAlarmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGAlarmas.Size = New System.Drawing.Size(802, 338)
        Me.DGAlarmas.TabIndex = 1
        '
        'ID
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ID.DefaultCellStyle = DataGridViewCellStyle2
        Me.ID.HeaderText = "  ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 50
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "     Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 180
        '
        'Alarma
        '
        Me.Alarma.HeaderText = "Mensaje"
        Me.Alarma.Name = "Alarma"
        Me.Alarma.ReadOnly = True
        Me.Alarma.Width = 520
        '
        'BReconoceAlarm
        '
        Me.BReconoceAlarm.BackColor = System.Drawing.Color.Orange
        Me.BReconoceAlarm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BReconoceAlarm.ForeColor = System.Drawing.Color.Black
        Me.BReconoceAlarm.Image = CType(resources.GetObject("BReconoceAlarm.Image"), System.Drawing.Image)
        Me.BReconoceAlarm.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.BReconoceAlarm.Location = New System.Drawing.Point(308, 474)
        Me.BReconoceAlarm.Name = "BReconoceAlarm"
        Me.BReconoceAlarm.Size = New System.Drawing.Size(179, 47)
        Me.BReconoceAlarm.TabIndex = 2
        Me.BReconoceAlarm.Text = "Reconoce Alarma"
        Me.BReconoceAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BReconoceAlarm.UseVisualStyleBackColor = False
        '
        'TimUnload
        '
        Me.TimUnload.Enabled = True
        Me.TimUnload.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(775, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "V.13.11.26"
        '
        'Alarmas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 533)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BReconoceAlarm)
        Me.Controls.Add(Me.DGAlarmas)
        Me.Controls.Add(Me.TMensaje)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Alarmas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensajes de Alarmas  de ChronoSoft"
        CType(Me.DGAlarmas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TMensaje As System.Windows.Forms.TextBox
    Friend WithEvents DGAlarmas As System.Windows.Forms.DataGridView
    Friend WithEvents BReconoceAlarm As System.Windows.Forms.Button
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Alarma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimUnload As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
