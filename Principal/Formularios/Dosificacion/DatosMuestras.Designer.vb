<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatosMuestras
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
        Me.TCeniza = New System.Windows.Forms.TextBox()
        Me.TGrasa = New System.Windows.Forms.TextBox()
        Me.THumedad = New System.Windows.Forms.TextBox()
        Me.TProteina = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TimSeg = New System.Windows.Forms.Timer(Me.components)
        Me.TFecha = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TLote = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BLeerArchivo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TCeniza
        '
        Me.TCeniza.Location = New System.Drawing.Point(105, 71)
        Me.TCeniza.Name = "TCeniza"
        Me.TCeniza.Size = New System.Drawing.Size(100, 20)
        Me.TCeniza.TabIndex = 0
        '
        'TGrasa
        '
        Me.TGrasa.Location = New System.Drawing.Point(105, 98)
        Me.TGrasa.Name = "TGrasa"
        Me.TGrasa.Size = New System.Drawing.Size(100, 20)
        Me.TGrasa.TabIndex = 1
        '
        'THumedad
        '
        Me.THumedad.Location = New System.Drawing.Point(105, 125)
        Me.THumedad.Name = "THumedad"
        Me.THumedad.Size = New System.Drawing.Size(100, 20)
        Me.THumedad.TabIndex = 2
        '
        'TProteina
        '
        Me.TProteina.Location = New System.Drawing.Point(105, 152)
        Me.TProteina.Name = "TProteina"
        Me.TProteina.Size = New System.Drawing.Size(100, 20)
        Me.TProteina.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ceniza"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Grasa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Humedad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Proteina"
        '
        'TCodigo
        '
        Me.TCodigo.Location = New System.Drawing.Point(105, 39)
        Me.TCodigo.Name = "TCodigo"
        Me.TCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TCodigo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Producto"
        '
        'TimSeg
        '
        Me.TimSeg.Enabled = True
        Me.TimSeg.Interval = 1000
        '
        'TFecha
        '
        Me.TFecha.Location = New System.Drawing.Point(105, 178)
        Me.TFecha.Name = "TFecha"
        Me.TFecha.Size = New System.Drawing.Size(100, 20)
        Me.TFecha.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha"
        '
        'TLote
        '
        Me.TLote.Location = New System.Drawing.Point(301, 37)
        Me.TLote.Name = "TLote"
        Me.TLote.Size = New System.Drawing.Size(100, 20)
        Me.TLote.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(233, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Lote"
        '
        'BLeerArchivo
        '
        Me.BLeerArchivo.Location = New System.Drawing.Point(301, 105)
        Me.BLeerArchivo.Name = "BLeerArchivo"
        Me.BLeerArchivo.Size = New System.Drawing.Size(75, 23)
        Me.BLeerArchivo.TabIndex = 14
        Me.BLeerArchivo.Text = "BLeerArchivo"
        Me.BLeerArchivo.UseVisualStyleBackColor = True
        '
        'DatosMuestras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 220)
        Me.Controls.Add(Me.BLeerArchivo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TLote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TCodigo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TProteina)
        Me.Controls.Add(Me.THumedad)
        Me.Controls.Add(Me.TGrasa)
        Me.Controls.Add(Me.TCeniza)
        Me.Name = "DatosMuestras"
        Me.Text = "DatosMuestras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TCeniza As System.Windows.Forms.TextBox
    Friend WithEvents TGrasa As System.Windows.Forms.TextBox
    Friend WithEvents THumedad As System.Windows.Forms.TextBox
    Friend WithEvents TProteina As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TimSeg As System.Windows.Forms.Timer
    Friend WithEvents TFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TLote As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BLeerArchivo As System.Windows.Forms.Button
End Class
