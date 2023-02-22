Imports System.IO
Imports System.Threading.Thread
Public Class ServEscan
  
    Private FormLoad As Boolean

    Private DEquipos As AdoNet
    Private DConsMed As AdoNet
    Private DCons As AdoNet
    Private DVarios As AdoNet

    Private ConEsc As Connection
    Private Recibe As String
    Private Pos As Int32

  

    Public Sub ServEscan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True

    End Sub


    Public Sub ServEscan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FormLoad = True Then Return
            FormLoad = True
            APlanoEscan("Entra a CHR")

            DEquipos = New AdoNet("-", CONN, DbProvedor)
            DConsMed = New AdoNet("-", CONN, DbProvedor)
            DVarios = New AdoNet("-", CONN, DbProvedor)
            DCons = New AdoNet("-", CONN, DbProvedor)

            DEquipos.Open("select * from EQUIPOS where EQUIPO=13")    'Escaner Micros
            If DEquipos.RecordCount Then
                Tip.Text = DEquipos.RecordSet("IP")
                TPort.Text = DEquipos.RecordSet("IPPORT")
                ConEsc = New Connection(Connection.TipoConnection.Ethernet, Tip.Text, TPort.Text)
                ConEsc.Conect()
            End If



        Catch ex As Exception
            TError.Text = ex.Message
        End Try

    End Sub

    Private Sub TimRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimRx.Tick
        Try

            TSeg.Text = Val(TSeg.Text) + 1
            If Val(TSeg.Text) > 100000 Then TSeg.Text = 1
            ShRx.Visible = False

            Recibe = ""
            If ConEsc.State = Connection.StateConnection.Connected Then
                ConEsc.GetData(Recibe)
                TEstadoWPant.Text = "7"
                TEstadoWPant.BackColor = Color.GreenYellow
            Else
                TEstadoWPant.BackColor = Color.White
                TEstadoWPant.Text = "6"
                If (Val(TSeg.Text) Mod 10 = 0) Then ConEsc.Conect()
            End If

            ShRx.Visible = True

            If Recibe <> "" Then
                TRx.Text = TRx.Text + Recibe
                APlanoEscan(Recibe)
                THora.Text = Now.ToString("HH:mm:ss")
            End If

            If Len(TRx.Text) < 5 Then Return

            If Mid(TRx.Text, 1, 1) <> "M" Then Return
            TOPs.Text = ""
            TBache.Text = ""

            Pos = InStr(TRx.Text, Chr(10))
            If Pos Then
                TBache.Text = Val(Mid(TRx.Text, 2, 3))
                TOPs.Text = Val(Mid(TRx.Text, 5, 6))
                If Val(TOPs.Text) > 0 And Val(TBache.Text) > 0 Then
                    FConsMed_Click(0, Nothing)
                    TRx.Text = ""
                End If
            End If


        Catch ex As Exception
            TError.Text = ex.Message
        End Try
    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()

    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BConectar_Click(sender As System.Object, e As System.EventArgs) Handles BConectar.Click
        Try
            ConEsc = New Connection(Connection.TipoConnection.Ethernet, Tip.Text, TPort.Text)
            ConEsc.Conect()
        Catch ex As Exception
            TError.Text = ex.Message
        End Try
    End Sub

    Private Sub FConsMed_Click(sender As System.Object, e As System.EventArgs) Handles FConsMed.Click
        Try
            Dim ContStr As String

    
            If Val(TOPs.Text) <> Val(PDosifica.TOPB1.Text) Then
                PDosifica.TMsgGen.Text = "OP de micros escaneada es diferente: " + TOPs.Text
                Evento("OP de micros escaneada es diferente: " + TOPs.Text + " debería ser " + PDosifica.TOPB1.Text)
                Return
            End If
            If Val(TBache.Text) = 0 Then
                PDosifica.TMsgGen.Text = "Bache de micros escaneado en ceros: " + TOPs.Text
                Evento("Bache de micros escaneado en ceros: " + TOPs.Text)
                Return
            End If
            DConsMed.Open("select * from CONSUMOSMED where OP=" + TOPs.Text + " and BACHE=" + TBache.Text)
            If DConsMed.RecordCount = 0 Then
                PDosifica.TMsgGen.Text = "Bache de Micros no existe Reportes OP:" + TOPs.Text + " Bache: " + TBache.Text
                Evento("Bache de Micros no existe Reportes OP:" + TOPs.Text + " Bache: " + TBache.Text)
                Return
            End If

            ContStr = "000" + TBache.Text
            ContStr = TOPs.Text + CRight(ContStr, 3)

            'Se hace barrido en cons y se busca si hay valor neuvo en ConsMed, es más rápido asi que hacer un select por cada COns donde la tabla es muy grande
            DCons.Open("select * from CONSUMOS where CONT=" + ContStr)
            For Each RCons As DataRow In DCons.Rows
                DConsMed.Open("select * from CONSUMOSMED where OP=" + TOPs.Text + " and BACHE=" + TBache.Text + " and CODMAT=" + RCons("CODMAT").ToString)
                If DConsMed.RecordCount Then
                    RCons("PESOREAL") = DConsMed.RecordSet("PESOREAL")
                    RCons("ALARMAS") = 147
                    DCons.Update("Consumos")
                End If

            Next RCons



            DConsMed.Open("delete from CONSUMOSMED where OP=" + TOPs.Text + " and BACHE=" + TBache.Text)

            Resp = ServPLC.Esc1Reg("Chr_OK_Micros", 1)
            If Resp = 0 Then Resp = ServPLC.Esc1Reg("Chr_OK_Micros", 1)
            PDosifica.TProc.Text += "Micros OK" + vbCrLf
            PDosifica.shMicrosOK.Visible = True

        Catch ex As Exception
            TError.Text = ex.Message
            EvError(ex.Message)
        End Try
    End Sub

    Private Sub TRx_TextChanged(sender As System.Object, e As System.EventArgs) Handles TRx.TextChanged
        If Len(TRx.Text) > 100 Then TRx.Text = ""
    End Sub
End Class
