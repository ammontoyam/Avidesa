Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing


Public Class ArrayControles(Of T As Control)
    Inherits Generic.Dictionary(Of Int32, T)

    Private mNombre As String

    Public Sub New(ByVal elNombre As String)
        MyBase.New()

        If String.IsNullOrEmpty(elNombre) Then
            Throw New ArgumentException( _
                        "El nombre del control no puede ser una cadena vacía")
        End If
        mNombre = elNombre

        'Me.Cast(Of T)()
        'Me.Add(34, button)

    End Sub

    Public Sub New( _
                   ByVal elNombre As String, _
                   ByVal ctrls As Control.ControlCollection)
        Me.New(elNombre)
        Me.Clear()
        asignarLosControles(ctrls)
        ' Me.CasT(Of T)()

    End Sub
    Public Sub New( _
                    ByVal elNombre As String, _
                    ByVal contenedor As ContainerControl)

        Me.New(elNombre, contenedor.Controls)

    End Sub

    Private Sub asignarLosControles(ByVal ctrls As Control.ControlCollection)
        ' El tipo debe ser Control, para tener en cuenta todos los controles
        ' que haya en la colección indicada.
        For Each ctr As Control In ctrls
            ' Hacer una llamada recursiva por si este control "contiene" otros
            If ctr.Controls.Count > 0 Then
                asignarLosControles(ctr.Controls)
            End If

            If ctr.Name.Contains(mNombre) Then
                Dim Nme As String = Replace(ctr.Name, mNombre, "")
                Dim Ind As Integer = 0
                If IsNumeric(Nme) Then
                    Ind = CType(Nme, Integer)
                    'MsgBox(ctr.GetType.Name)
                    Me.Add(Ind, CType(ctr, T))
                    'Me.Add(TryCast(ctr, T))
                End If
            End If
            'If InStr(1, ctr.Name, mNombre) > 0 Then
            '    Dim Nme As String = Mid(ctr.Name, InStr(1, ctr.Name, mNombre) + 1, ctr.Name.Length - InStr(1, ctr.Name, mNombre))
            '    Dim Ind As Integer = 0
            '    If IsNumeric(Nme) Then
            '        Ind = CType(Nme, Integer)
            '        'MsgBox(ctr.GetType.Name)
            '        Me.Add(Ind, CType(ctr, T))
            '        'Me.Add(TryCast(ctr, T))
            '    End If
            'End If
            'Application.DoEvents()
            'Dim Nme As String = ctr.Name.Substring(m_Nombre.Length - 1, ctr.Name.Length)

            'If ctr.Name.IndexOf(m_Nombre) > -1 Then
            'Me.Add(TryCast(ctr, T))
            'End If
        Next
    End Sub
    Public Function Index(ByVal obj As Object) As Integer
        Dim ctr As Control = TryCast(obj, Control)
        If ctr Is Nothing Then
            Return -1
        End If

        Dim i As Integer = 0
        If ctr.Name.Contains(mNombre) Then
            Dim Nme As String = Replace(ctr.Name, mNombre, "")
            If IsNumeric(Nme) Then
                i = CType(Nme, Integer)
            Else
                i = -1
            End If
        End If
        'i = Convert.ToInt32(Mid(ctr.Name, InStr(1, ctr.Name, mNombre) + 1, ctr.Name.Length - InStr(1, ctr.Name, mNombre)))
        'i = ctrl.Name.LastIndexOf("_")

        If i = -1 Then
            Throw New ArgumentException( _
                          "El Objeto solicitado no pertenece a la lista")
            Exit Function
        End If

        Return i
    End Function
End Class
