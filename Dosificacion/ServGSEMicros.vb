Option Explicit On

Imports System.Windows.Forms
Imports System.Threading
Imports System.Data
Imports System.IO
Imports System.Data.Common
Imports System.Threading.Thread


Public Class ServGSEMicros

    Private DDatosFor As AdoNet
    Private DOPs As AdoNet
    Private DVarios As AdoNet
    Private DFor As AdoNet
    Private DArt As AdoNet
    Private DEquipos As AdoNet
    Private DConsMed As AdoNet
    Private Row As Long

    'Private W As New WinSock
    Private Red As Boolean
    Private WithEvents Conx As Connection

    Private Pos As Long, Pos1 As Long
    Private Posi As Long, Posi1 As Long
    Private Reportes, Reportes2 As String
    Private Recibido As String
    Private Renglon As String
    Private Trama As String

    'Variables de Reportes
    Private Contador As String
    Private ContMaq As String
    Private CodMat As String
    Private OP As String
    Private Meta As String
    Private Real As String
    Private Bache As String
    Private CodFor As String
    Private LP As String
    Private Factor As String
    Private NomFor As String
    Private FechaRep As String
    Private HoraRep As String
    Private FormLoad As Boolean
    'Arrays de Controles


    Public Sub ServGSEMicros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Si el formulario ya está cargado no lo vuelve a cargar
            If FormLoad = True Then Return

            Me.Width = 570

            DFor = New AdoNet("Formulas", CONN, DbProvedor)
            DOPs = New AdoNet("OPS", CONN, DbProvedor)
            DDatosFor = New AdoNet("DatosFor", CONN, DbProvedor)
            DArt = New AdoNet("ARTICULOS", CONN, DbProvedor)
            DEquipos = New AdoNet("Equipos", CONN, DbProvedor)
            DVarios = New AdoNet("VARIOS", CONN, DbProvedor)
            DConsMed = New AdoNet("ConsumosMed", CONN, DbProvedor)
            DEquipos.Open("select * from EQUIPOS")

            DEquipos.Find("EQUIPO=5")
            If DEquipos.EOF = False Then
                If DEquipos.RecordSet("TIPOCONEXION").ToString.ToUpper = "SERIAL" Then
                    '1,9600,8,0,1,0
                    Conx = New Connection(Connection.TipoConnection.Serial, DEquipos.RecordSet("COM").ToString + ",19200,8,0,1,0")
                ElseIf DEquipos.RecordSet("TIPOCONEXION").ToString.ToUpper = "ETHERNET" Then
                    Conx = New Connection(Connection.TipoConnection.Ethernet, DEquipos.RecordSet("IP").ToString, DEquipos.RecordSet("IPPORT").ToString)
                End If
                Conx.Conect()
            Else
                MsgError("No existe el Equipo 1 en la tabla equipos")
            End If

            FormLoad = True
            Me.Show()
            Sleep(400)
            'Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            MsgBox(e.ToString)
        End Try
    End Sub




    Private Sub BEnviaOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEnviaOP.Click

        Dim Pos1 As Long, OP As Long
        Try

            Pos1 = InStr(1, Renglon, "OPRODUCCION,")
            If Pos1 = 0 Then Exit Sub
            Renglon = Mid(Renglon, Pos1 + 12)
            OP = Val(Renglon)

            DOPs.Open("select TOP 1  * from OPs where OP=" + OP.ToString + " and FINALIZADO='N'")
            If DOPs.RecordCount = 0 Then
                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.SendData(vbCr + "OrdenProD0" + vbCr)
                    Sleep(100)
                    Conx.SendData(Chr(26))
                End If
                Exit Sub
            End If


            OP = Eval(DOPs.RecordSet("OP").ToString)

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(vbCr + "OrdenProD0" + vbCr)
            End If

            TOPs.Text = OP.ToString
            Renglon = ""

            Sleep(200)

            For Each Fila As DataRow In DOPs.Rows

                Renglon = Renglon + Fila("OP").ToString + ","
                Renglon = Renglon + Fila("CODFOR").ToString + ","
                Renglon = Renglon + Trim(Fila("META") - Fila("REALMED")) + ","
                Renglon = Renglon + Fila("PORC").ToString + ",0"
                Renglon = Renglon + vbCrLf

                TTx.Text = Renglon


                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.SendData(Renglon)
                End If
                Sleep(100)
                WriteFile(Ruta + "Aplanos\GSE2_" + Format(Now, "yyMMdd") + ".txt", Renglon)

                Renglon = ""

            Next

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(Chr(26))
            End If
            Sleep(20)
            Evento("ENVIA OPs " + OP.ToString)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub




    Private Sub BEnviaFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEnviaFor.Click
        Dim Pos1 As Long, Formula As Long
        Try
            Dim SumaCodMat As Integer = 0
            Dim SumPeso As Single = 0


            Pos1 = InStr(1, Renglon, "FORMULA,")
            If Pos1 = 0 Then Exit Sub
            Renglon = Mid(Renglon, Pos1 + 8)
            Pos1 = InStr(1, Renglon, ",")
            If Pos1 = 0 Then Exit Sub
            Renglon = Renglon.Substring(0, Pos1 - 1)
            Formula = Eval(Renglon)
            Renglon = Mid(Renglon, Pos1)

            DOPs.Open("select * from OPS where OP='" + Trim(TOPs.Text) + "'")
            If DOPs.RecordCount = 0 Then Exit Sub

            DFor.Open("select * from FORMULAS where CODFOR='" + Formula.ToString + "' and LP='" + DOPs.RecordSet("LP").ToString.Trim + "'")

            If DFor.RecordCount = 0 Then Exit Sub

   
            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(vbCr + "FormulA0" + vbCr)
            End If

            TTx.Text += vbCrLf + "FormulA0" + vbCrLf
            Sleep(500)

            For Each Fila As DataRow In DFor.Rows
                Renglon = Fila("CODFOR").trim + ","
                Renglon += Chr(34) + CLeft(Fila("NOMFOR"), 25) + Chr(34)
                Renglon += vbCrLf

                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.SendData(Renglon)
                End If

                WriteFile(Ruta + "Aplanos\GSE2_" + Format(Now, "yyMMdd") + ".txt", Format(Now, "HH:mm:ss") + vbNewLine + Renglon)
                Sleep(20)
                TTx.Text += Renglon
            Next

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(Chr(26))
            End If

            Sleep(500)
            Renglon = ""

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + Formula.ToString + "' and LP='" + DOPs.RecordSet("LP").ToString.Trim + "' and TIPOMAT=6 order by PASO")
             Dim Paso As Long = 1
            For Each Fila As DataRow In DDatosFor.Rows

                Renglon = Fila("CODFOR") + ","
                Renglon += Fila("CODMAT").ToString + ","
                Renglon += Chr(34) + Mid(Fila("NOMMAT"), 1, 17) + Chr(34) + ","
                Renglon += "M" + ","
                 Renglon += Replace(Format(Fila("PESOMETA"), "#.000"), ",", ".")
                Renglon += vbCrLf

                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.SendData(Renglon)
                Else
                    WriteFile(Ruta + "Aplanos\GSE2_" + Format(Now, "yyMMdd") + ".txt", "No conexión " + Renglon)
                End If

                Sleep(100)
                WriteFile(Ruta + "Aplanos\GSE2_" + Format(Now, "yyMMdd") + ".txt", Renglon)
                Paso += 1
                TTx.Text += Renglon
            Next

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(Chr(26))
            End If
            Sleep(30)
            Renglon = ""

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Public Sub BEnviaMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            DArt.Open("select * from ARTICULOS where TIPO='MP'")
            If DArt.RecordCount = 0 Then Exit Sub
            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(vbCr + "IngredienteS0" + vbCr)
            End If

            TTx.Text += "BORRANDO MATERIALES EN EL GSE...." + vbCrLf
            TTx.Refresh()
            Sleep(5000)
            TTx.Text += "BORRANDO MATERIALES EN EL GSE...." + vbCrLf
            TTx.Refresh()
            Sleep(5000)

            For Each Fila As DataRow In DArt.Rows
                Renglon = Fila("CODINT").ToString + "," + CLeft(Fila("NOMBRE").ToString, 10) + vbCrLf

                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.SendData(Renglon)
                End If

                Sleep(50)
                WriteFile(Ruta + "Aplanos\GSE2_" + Format(Now, "yyMMdd") + ".txt", Renglon)
                TTx.Text += Renglon
                TTx.Refresh()
            Next

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(Chr(26))
            End If
            Sleep(20)
            Renglon = ""
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLimpiar.Click
        Try
            TRx.Text = ""
            TTx.Text = ""
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TimRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimRx.Tick
        Try
            ShRx.Visible = False
            Recibido = ""
            If Not Conx Is Nothing Then
                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.GetData(Recibido)
                    TEstadoW.Text = "7"
                    TEstadoW.BackColor = Color.GreenYellow
                Else
                    TEstadoW.BackColor = Color.White
                    TEstadoW.Text = "6"
                End If
                If Not Conx Is Nothing Then
                    If CInt(Eval(TMonRx.Text)) Mod 5 = 0 Then
                        If Conx.TypeConn = Connection.TipoConnection.Ethernet AndAlso Conx.State = Connection.StateConnection.Desconnected Then
                            Conx.Conect()
                        End If
                    End If
                End If

            End If
            'If Not Conx Is Nothing Then
            '    If Conx.State = Connection.StateConnection.Connected Then
            '        If CInt(Eval(TMonRx.Text)) > 0 AndAlso CInt(Eval(TMonRx.Text)) Mod 600 = 0 Then
            '            'BPideRep_Click(Nothing, Nothing)
            '            BActHoraGSE_Click(Nothing, Nothing)
            '        End If

            '    End If
            'End If

            TMonRx.Text = (Eval(TMonRx.Text) + 1).ToString

            If Len(Recibido) Then
                TRx.Text += Recibido
                ShRx.Visible = True
                WriteFile(Ruta + "Aplanos\GSE2_" + Format(Now, "yyMMdd") + ".txt", Format(Now, "HH:mm:ss") + vbNewLine + Recibido)
            End If


            If Len(TRx.Text) > 50000 Then TRx.Text = ""
            If TRx.Text.Length < 5 Then Return


            Pos = InStr(1, TRx.Text, "FINCOPYREPORT,")
            If Pos > 0 Then
                Pos1 = InStr(1, TRx.Text, "INIREPORT,")
                If Pos1 > 0 And Pos > Pos1 Then

                    Posi = InStr(TRx.Text, "FINREPORT," + vbCrLf)
                    If Posi > Pos1 Then
                        Reportes = Mid(TRx.Text, Pos1 + 12, Posi - Pos1 - 12)
                    Else
                        Return
                    End If
                    Reportes2 = ""
                    Posi1 = InStr(TRx.Text, "INICOPYREPORT,")
                    If Posi1 > 0 Then
                        If Pos > Posi1 Then
                            Reportes2 = Mid(TRx.Text, Posi1 + 16, Pos - Posi1 - 16)
                        End If
                    End If
                    If Reportes <> Reportes2 Then
                        Evento("BRecRep. Copia de reportes diferente: " + vbCrLf + Now.ToString("HH:mm:ss") + vbCrLf + TRx.Text)
                        TRx.Text = ""
                        Return
                    End If
                    TRx.Text = Mid(TRx.Text, Pos + 15)
                    BRecRep_Click(Nothing, Nothing)
                    Return
                End If
            End If

            Pos = InStr(1, TRx.Text, "OPRODUCCION,")
            If Pos <> 0 Then
                Renglon = TRx.Text
                TRx.Text = Mid(TRx.Text, Pos + 12)
                BEnviaOP_Click(Nothing, Nothing)
                Exit Sub
            End If

            Pos = InStr(1, TRx.Text, "FORMULA,")
            If Pos > 0 Then
                Renglon = TRx.Text
                TRx.Text = Mid(TRx.Text, Pos + 9)
                BEnviaFor_Click(Nothing, Nothing)
            End If


            Pos = InStr(1, TRx.Text, "INGRED,")
            If Pos <> 0 Then
                BEnviaMat_Click(Nothing, Nothing)
                TRx.Text = Mid(TRx.Text, Pos + 10, 200)
                Exit Sub
            End If

            Pos = InStr(1, TRx.Text, "RESPONDIENDO DESDE GSE")
            If Pos > 0 Then
                TRx.Text = Mid(TRx.Text, Pos + 35)
                MsgBox("COMUNICACIONES CON GSE OK !!!!!", MsgBoxStyle.Information)
            End If

            'Va quitando los ENTER seguidos que se quedan en RX
            Pos1 = InStr(1, TRx.Text, vbCrLf + vbCrLf)
            If Pos1 > 0 Then
                TRx.Text = CLeft(TRx.Text, Pos1 + 1) + Mid(TRx.Text, Pos1 + 4)

            End If


            'Va quitando los chr(10) seguidos que se quedan en RX
            Pos1 = InStr(1, TRx.Text, Chr(10) + Chr(10))
            If Pos1 > 0 Then
                TRx.Text = CLeft(TRx.Text, Pos1 - 1) + Mid(TRx.Text, Pos1 + 1)

            End If


            If InStr(1, TRx.Text, "REPORT") = 0 And Len(TRx.Text) > 5000 Then TRx.Text = ""


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

   
    Private Sub BRecRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRecRep.Click
        Try
            Dim FechaRepAnt As String = ""
            Dim Minutos As Single = 0
            Dim FechaAux As String
            Dim Destino As Int16 = 0

            Reportes = Replace(Reportes, ",", ";")
            Do While (Len(Reportes)) > 20

                Application.DoEvents()

                If Eval(Reportes) = 0 Then Continue Do

                ContMaq = Eval(Reportes).ToString

                Pos1 = InStr(1, Reportes, ";")
                Reportes = Mid(Reportes, Pos1 + 1)
                OP = Eval(Reportes)

                Pos1 = InStr(1, Reportes, ";")
                Reportes = Mid(Reportes, Pos1 + 1)
                CodMat = Eval(Reportes)

                Pos1 = InStr(1, Reportes, ";")
                Reportes = Mid(Reportes, Pos1 + 1)
                Meta = Eval(Reportes)

                Pos1 = InStr(1, Reportes, ";")
                Reportes = Mid(Reportes, Pos1 + 1)
                Real = Eval(Reportes)

                Pos1 = InStr(1, Reportes, ";")
                Reportes = Mid(Reportes, Pos1 + 1)
                Bache = Eval(Reportes)

                Pos1 = InStr(1, Reportes, ";")
                Reportes = Mid(Reportes, Pos1 + 1)
                Pos1 = InStr(1, Reportes, ";")
                FechaRep = "20" + Mid(Reportes, 1, Pos1 - 1)

                Reportes = Mid(Reportes, Pos1 + 1)
                Pos1 = InStr(1, Reportes, vbCrLf)
                HoraRep = Mid(Reportes, 1, Pos1 - 1)

                Reportes = Mid(Reportes, Pos1 + 2)

                Contador = Eval(Format(Now, "MMdd")) * 1000000 + Eval(ContMaq).ToString

                DOPs.Open("Select * from OPS where OP='" + Trim(OP) + "'")
                If DOPs.RecordCount = 0 Then Continue Do

                CodFor = DOPs.RecordSet("CODFOR")
                NomFor = DOPs.RecordSet("NOMFOR")
                LP = DOPs.RecordSet("LP")

   
                TOPs.Text = OP
                TCodFor.Text = CodFor
                TCont.Text = Contador

                FechaAux = FechaRep + " " + HoraRep

                DConsMed.Open("select * from CONSUMOSMED where CONT=" + Contador + " and CODMAT='" + CodMat + "' and PESOMETA=" + Replace(Format(Eval(Meta), "0.000"), ",", "."))
                DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and CODMAT='" + CStr(CodMat) + "'") ' and PESOMETA=" + Replace(Format((Eval(Meta) * 100 / Factor), "0.000"), ",", "."))

                If DDatosFor.RecordCount = 0 Then Evento("Se reportó el ingrediente " + CodMat + " que no pertenece a la fórmula " + CodFor)


                If DConsMed.RecordCount = 0 And DDatosFor.RecordCount > 0 Then
                    DConsMed.AddNew()
                    DConsMed.RecordSet("CONT") = Contador
                     DConsMed.RecordSet("CodFor") = CodFor
                    DConsMed.RecordSet("OP") = DOPs.RecordSet("OP")
                    DConsMed.RecordSet("CodForB") = DDatosFor.RecordSet("CODFORB")
                    DConsMed.RecordSet("CodMat") = CodMat
                    DConsMed.RecordSet("CodMatB") = DDatosFor.RecordSet("CODMATB")
                    DConsMed.RecordSet("PESOREAL") = Real
                    DConsMed.RecordSet("PesoMeta") = Meta
                    DConsMed.RecordSet("TIPOMAT") = DDatosFor.RecordSet("TIPOMAT")
                     If DConsMed.RecordSet("PESOREAL") = 0 Then DConsMed.RecordSet("PESOREAL") = DConsMed.RecordSet("PesoMeta")
                    DConsMed.RecordSet("NOMMAT") = DDatosFor.RecordSet("NOMMAT")
                    DConsMed.RecordSet("FACTOR") = DOPs.RecordSet("PORC")
                    DConsMed.RecordSet("NOMFOR") = DOPs.RecordSet("NOMFOR")
                    DConsMed.RecordSet("BACHE") = Bache

                    DConsMed.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")

                DConsMed.Update()

                End If

            Loop

            BBorraRep_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BBorraRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorraRep.Click
        Try
            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(vbCr + "BorraReporteS0" + vbCr)
            End If

            TTx.Text += "BorraReporteS0"
            Sleep(200)

        Catch ex As Exception
            MsgBox(ex.Message)
            Evento(ex.ToString)
        End Try
    End Sub

    Private Sub BPideRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPideRep.Click
        Try
            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(vbCr + "ReporteS0" + vbCr)
            End If
            TTx.Text += vbCr + "ReporteS0" + vbCr

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub mnConfigurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnConfigurar.Click
        Try
            If Fuentes = False Then
                If Convert.ToBoolean(DRUsuario("Config")) = False Then
                    MsgBox(" El Usuario no tiene permisos para ejecutar la acción solicitada ", vbInformation)
                    Exit Sub
                End If
            End If

            DEquipos.Open("select * from EQUIPOS where EQUIPO=1")
            If DEquipos.RecordCount = 0 Then Exit Sub

            If DEquipos.RecordSet("TIPOCONEXION") = "ETHERNET" Then

                RespInput = DEquipos.RecordSet("IP").ToString
                If InputBox.InputBox("Configuración de Comunicaciones", "Ingrese la dirección IP para establecer la Conexión", RespInput) = DialogResult.OK Then
                    If RespInput.Trim = "" Then
                        MessageBox.Show("El valor ingresado no es válido", "Error en Configuración de Comunicaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    DEquipos.RecordSet("IP") = RespInput.Trim
                Else
                    Return
                End If

            Else
                RespInput = DEquipos.RecordSet("COM").ToString
                If InputBox.InputBox("Configuración de Comunicaciones", "Ingrese el Puerto COM para establecer la Conexión", RespInput) = DialogResult.OK Then
                    If RespInput.Trim = "" Then
                        MessageBox.Show("El valor ingresado no es válido", "Error en Configuración de Comunicaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    DEquipos.RecordSet("COM") = RespInput.Trim
                Else
                    Return
                End If
            End If

            DEquipos.Update()
            MsgBox("Se ha realizado la configuración de comunicaciones correctamente. Para que los cambios se apliquen hay que salir e ingresar nuevamente a la ChronoSoft.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
            Evento(ex.ToString)
        End Try
    End Sub


    Private Sub BPruebaCoM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPruebaCoM.Click
        Try
            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(vbCr + "PruebaComM0" + vbCr)
            Else
                MsgBox("El canal de Comunicaciones está cerrado", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub


   
  
    Private Sub Servidor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub


 
 
  

    Private Sub Conx_Connect() Handles Conx.Connect
        Evento("Conectado " + Conx.ConfigConnection)
    End Sub

    Private Sub Conx_Close() Handles Conx.ConnectClose
        Evento("Desconectado " + Conx.ConfigConnection)
    End Sub


    Private Sub TTx_TextChanged(sender As System.Object, e As System.EventArgs) Handles TTx.TextChanged
        If Len(TTx.Text) > 500 Then TTx.Text = Mid(TTx.Text, 450)
    End Sub

   
End Class