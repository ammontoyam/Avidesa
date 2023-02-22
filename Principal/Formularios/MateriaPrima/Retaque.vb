Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports ClassLibrary

Public Class Retaque

    Private DTolvas As AdoSQL
    Private DArt As AdoSQL
    Private LTolva As ArrayControles(Of Label)
    Private TNomMatTolva As ArrayControles(Of Label)
    Private TPorc As ArrayControles(Of Label)
    Private TTotalTolva As ArrayControles(Of TextBox)
    Private BNivelTolva As ArrayControles(Of Button)
    Private PosIni(0 To 30) As Integer

    Private Sub TimVisualiza_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimVisualiza.Tick
        Dim Sel As Int32 = 0
        Dim n As Int32 = 0
        Dim Capacidad As Int32 = 0
        Dim AlturaMeta = 103 'Este valor es la altura del objeto cuando el peso alcanza la capacidad de la Tolva
        Dim Altura As Int32
        Try

            n = CListTolvas.SelectedIndex
            DTolvas.Refresh()

            For i = 1 To 30
                LTolva(i).Text = "-"
                TNomMatTolva(i).Text = "LIBRE"
                TTotalTolva(i).Text = 0
                TTotalTolva(i).ReadOnly = True
                TNomMatTolva(i).BackColor = Color.Gainsboro
                LTolva(i).ForeColor = Color.Black
                TTotalTolva(i).ForeColor = Color.Black
                TPorc(i).Text = ""
                With BNivelTolva(i)
                    .Height = 0
                    .Top = PosIni(i)
                End With
            Next
            For i As Integer = 1 To 30
                Sel = 30 * n + i
                If Sel > DTolvas.Count Then Exit For
                LTolva(i).Text = DTolvas.Rows(Sel - 1).Item("TOLVA").ToString
                If DTolvas.Rows(Sel - 1).Item("NOMTOLVA").ToString <> "-" Then
                    LTolva(i).Text += "-" + DTolvas.Rows(Sel - 1).Item("NOMTOLVA").ToString
                End If
                TNomMatTolva(i).Text = DTolvas.Rows(Sel - 1).Item("NOMBRE").ToString
                TTotalTolva(i).Text = DTolvas.Rows(Sel - 1).Item("TOTAL").ToString
                TTotalTolva(i).BackColor = Color.Cornsilk
                TNomMatTolva(i).BackColor = Color.Gainsboro
                LTolva(i).ForeColor = Color.Blue

                Capacidad = DTolvas.Rows(Sel - 1).Item("CAPACIDAD").ToString
                If Capacidad = 0 Then
                    Altura = 0
                Else
                    Altura = CInt(Eval(TTotalTolva(i).Text) * AlturaMeta / Capacidad)
                End If

                If Altura <= 0 Then Altura = 0
                With BNivelTolva(i)
                    .Height = Altura
                    .Top = PosIni(i) - Altura
                End With
                TPorc(i).Text = 0
                TPorc(i).Visible = False
                If Eval(TTotalTolva(i).Text) > 0 AndAlso Capacidad > 0 Then
                    TPorc(i).Text = (Math.Round((Eval(TTotalTolva(i).Text) / Capacidad) * 100, 0)).ToString + "%"
                    TPorc(i).Visible = True
                    TPorc(i).AutoSize = True
                End If
            Next

            AsignaDataGrid(DGTolvas, DTolvas.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub Retaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LTolva = New ArrayControles(Of Label)("LTolva", Me)
            TNomMatTolva = New ArrayControles(Of Label)("TNomMatTolva", Me)
            TTotalTolva = New ArrayControles(Of TextBox)("TTotalTolva", Me)
            BNivelTolva = New ArrayControles(Of Button)("BNivelTolva", Me)
            TPorc = New ArrayControles(Of Label)("TPorc", Me)

            DTolvas = New AdoSQL("TOLVAS")
            DArt = New AdoSQL("ARTICULOS")

            DTolvas.Open("select * from TOLVAS where PROCESO='DOSIFICACION' order by Tolva")
            AsignaDataGrid(DGTolvas, DTolvas.DataTable)

            For i = 1 To 30
                PosIni(i) = BNivelTolva(i).Top
            Next

            CListTolvas.SelectedIndex = 0
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CListTolvas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CListTolvas.SelectedIndexChanged
        Try
            TimVisualiza_Tick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BSilos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSilos.Click
        'If DRUsuario("Silos_Ver") Then
        If ValidaPermiso("Silos_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If

        Silos.ShowDialog()
    End Sub

End Class