<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaldosIni
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
        Me.TProdProc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BRevisar = New System.Windows.Forms.Button()
        Me.TCodProd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BCorregir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TProdProc
        '
        Me.TProdProc.Location = New System.Drawing.Point(185, 63)
        Me.TProdProc.Name = "TProdProc"
        Me.TProdProc.Size = New System.Drawing.Size(100, 20)
        Me.TProdProc.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Productos A Procesar"
        '
        'BRevisar
        '
        Me.BRevisar.Location = New System.Drawing.Point(16, 26)
        Me.BRevisar.Name = "BRevisar"
        Me.BRevisar.Size = New System.Drawing.Size(127, 23)
        Me.BRevisar.TabIndex = 2
        Me.BRevisar.Text = "BRevisar"
        Me.BRevisar.UseVisualStyleBackColor = True
        '
        'TCodProd
        '
        Me.TCodProd.Location = New System.Drawing.Point(185, 90)
        Me.TCodProd.Name = "TCodProd"
        Me.TCodProd.Size = New System.Drawing.Size(100, 20)
        Me.TCodProd.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Un Solo Producto"
        '
        'BCorregir
        '
        Me.BCorregir.Location = New System.Drawing.Point(185, 127)
        Me.BCorregir.Name = "BCorregir"
        Me.BCorregir.Size = New System.Drawing.Size(100, 23)
        Me.BCorregir.TabIndex = 5
        Me.BCorregir.Text = "BCorregir"
        Me.BCorregir.UseVisualStyleBackColor = True
        '
        'SaldosIni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 332)
        Me.Controls.Add(Me.BCorregir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TCodProd)
        Me.Controls.Add(Me.BRevisar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TProdProc)
        Me.Name = "SaldosIni"
        Me.Text = "SaldosIni"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TProdProc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BRevisar As System.Windows.Forms.Button
    Friend WithEvents TCodProd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BCorregir As System.Windows.Forms.Button
End Class
