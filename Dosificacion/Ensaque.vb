Option Explicit On

Imports System
Imports System.Data

Public Class Ensaque

    Private DEmpaque As AdoNet
    Private DConfig As AdoNet

    Public TOPs As ArrayControles(Of TextBox)
    Public TCodProd As ArrayControles(Of TextBox)
    Public TPresent As ArrayControles(Of TextBox)
    Public TNomProd As ArrayControles(Of TextBox)
    Public TPreset As ArrayControles(Of TextBox)
    Public TSacos As ArrayControles(Of TextBox)
    Private TPesoTot As ArrayControles(Of TextBox)
    Public TSacosAjuste As ArrayControles(Of TextBox)
    Public TResiduo As ArrayControles(Of TextBox)
    Public TFechaUlt As ArrayControles(Of TextBox)
    Public TTMuerto As ArrayControles(Of TextBox)
    Public TOrigen As ArrayControles(Of TextBox)
    Public TDestino As ArrayControles(Of TextBox)
    Public TSupervisor As ArrayControles(Of TextBox)
    Public TEmpacador As ArrayControles(Of TextBox)
    Public TCosedor As ArrayControles(Of TextBox)
    Private FNuevoEmp As ArrayControles(Of Button)
    Private MesDia As Long

    Public Sub Ensaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DEmpaque = New AdoNet("EMPAQUE", CONN, DbProvedor)
            DConfig = New AdoNet("Config", CONN, DbProvedor)

            DConfig.Open("select * from CONFIG")

            TOPs = New ArrayControles(Of TextBox)("TOPs", Me)
            TCodProd = New ArrayControles(Of TextBox)("TCodProd", Me)
            TPresent = New ArrayControles(Of TextBox)("TPresent", Me)
            TNomProd = New ArrayControles(Of TextBox)("TNomProd", Me)
            TPreset = New ArrayControles(Of TextBox)("TPreset", Me)
            TSacos = New ArrayControles(Of TextBox)("TSacos", Me)
            TPesoTot = New ArrayControles(Of TextBox)("TPesoTot", Me)
            TSacosAjuste = New ArrayControles(Of TextBox)("TSacosAjuste", Me)
            TResiduo = New ArrayControles(Of TextBox)("TResiduo", Me)
            TFechaUlt = New ArrayControles(Of TextBox)("TFechaUlt", Me)
            TTMuerto = New ArrayControles(Of TextBox)("TTMuerto", Me)
            TOrigen = New ArrayControles(Of TextBox)("TOrigen", Me)
            TDestino = New ArrayControles(Of TextBox)("TDestino", Me)
            TSupervisor = New ArrayControles(Of TextBox)("TSupervisor", Me)
            TEmpacador = New ArrayControles(Of TextBox)("TEmpacador", Me)
            TCosedor = New ArrayControles(Of TextBox)("TCosedor", Me)
            FNuevoEmp = New ArrayControles(Of Button)("FNuevoEmp", Me)


            For Each B As Button In FNuevoEmp.Values
                AddHandler B.Click, AddressOf FNuevoEmp_Click
            Next

            For Each T As TextBox In TSacos.Values
                AddHandler T.TextChanged, AddressOf TSacos_TextChanged
            Next

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FNuevoEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Index As Int32 = FNuevoEmp.Index(CType(sender, Button))
        Try

            If Eval(TSacos(Index).Text) = 0 Then Exit Sub
            If Eval(TOPs(Index).Text) = 0 Then Exit Sub

            MesDia = Now.ToString("MMdd")

            DEmpaque.AddNew()
            DEmpaque.RecordSet("MAQUINA") = Index
            DEmpaque.RecordSet("MesDia") = MesDia
            DEmpaque.RecordSet("OP") = Eval(TOPs(Index).Text)
            DEmpaque.RecordSet("FechaIni") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DEmpaque.RecordSet("DETALLE") = "AUTOM"
            DEmpaque.RecordSet("EMPACADOR") = CLeft(TEmpacador(Index).Text, 10)
            DEmpaque.RecordSet("Usuario") = CLeft(TSupervisor(Index).Text, 10)
            DEmpaque.RecordSet("COSEDOR") = CLeft(TCosedor(Index).Text, 10)
            DEmpaque.Update()
        
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub TSacos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Index As Int32 = TSacos.Index(CType(sender, TextBox))
        Try
            If Eval(TSacos(Index).Text) = 0 Then Exit Sub
            If Eval(TOPs(Index).Text) = 0 Then Exit Sub

            TPesoTot(Index).Text = (Eval(TSacos(Index).Text) * Eval(TPreset(Index).Text)).ToString
            TFechaUlt(Index).Text = Now.ToString("yyyy/mm/dd HH:mm:ss")


            DEmpaque.Open("Select * from EMPAQUE where OP=" + TOPs(Index).Text + " AND MAQUINA=" + Index.ToString + " ORDER BY CONT desc")

            If DEmpaque.RecordCount = 0 Then
                FNuevoEmp_Click(FNuevoEmp(Index), Nothing)
            End If

            DEmpaque.Refresh()

            If DEmpaque.RecordSet("Sacos") > Eval(TSacos(Index).Text) Then
                FNuevoEmp_Click(FNuevoEmp(Index), Nothing)
                DEmpaque.Refresh()
            End If

            DEmpaque.RecordSet("CodProd") = Eval(TCodProd(Index).Text)
            If TNomProd(Index).Text <> "" Then DEmpaque.RecordSet("NOMPROD") = CLeft(TNomProd(Index).Text, 30)
            DEmpaque.RecordSet("OP") = Eval(TOPs(Index).Text)
            DEmpaque.RecordSet("ORIGEN") = Eval(TOrigen(Index).Text)
            DEmpaque.RecordSet("DESTINO") = CLeft(TDestino(Index).Text, 2)
            DEmpaque.RecordSet("Sacos") = Eval(TSacos(Index).Text)
            DEmpaque.RecordSet("PESO") = Eval(TPesoTot(Index).Text)
            DEmpaque.RecordSet("PRESKG") = Eval(TPreset(Index).Text)
            DEmpaque.RecordSet("PRESEMP") = CLeft(TPresent(Index).Text, 1)
            DEmpaque.RecordSet("RESIDUO") = Eval(TResiduo(Index).Text)
            DEmpaque.RecordSet("SACOSAJUSTE") = Eval(TSacosAjuste(Index).Text)
            DEmpaque.RecordSet("PESOAJUSTE") = (Eval(TSacosAjuste(Index).Text) * Eval(TPreset(Index).Text)).ToString
            DEmpaque.RecordSet("FechaFin") = Now.ToString("yyyy/mm/dd HH:mm:ss")
            DEmpaque.Update()

            DConfig.Refresh()
            If Eval(TTMuerto(Index).Text) < DConfig.RecordSet("TMUERTOENSAQ") Then TTMuerto(Index).Text = 0

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try
            TSeg.Text = (Eval(TSeg.Text) + 1).ToString

            TTMuerto(1).Text = (Eval(TTMuerto(1).Text) + 1).ToString
            If Eval(TTMuerto(1).Text) > 100000 Then TTMuerto(1).Text = 1
            TTMuerto(2).Text = (Eval(TTMuerto(2).Text) + 1).ToString
            If Eval(TTMuerto(2).Text) > 100000 Then TTMuerto(2).Text = 1
            TTMuerto(3).Text = (Eval(TTMuerto(3).Text) + 1).ToString
            If Eval(TTMuerto(3).Text) > 100000 Then TTMuerto(3).Text = 1

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    
    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

   
    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Hide()
    End Sub

   
    Private Sub mnServidorHorner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnServidorHorner.Click
        Try
            ServidorHorner.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub mnRepeso1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepeso1.Click
        Try
            ServidorRep.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub mnRepeso2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepeso2.Click
        Try
            ServidorRep2.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
End Class