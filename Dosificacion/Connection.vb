Option Explicit On

Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports System.Windows.Forms
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread

Public Class Connection
    Private W As WinSock
    Private COMM As Com
    Private TypeConnection As TipoConnection
    Private Config As String
    Private Estado As Long
    Private EstadoAnt As Long
    Private DR As DataRow

#Region "EVENTOS"
    Public Event ConnectClose()
    Public Event Connect()
#End Region

    Public Sub New(ByVal Tipo As TipoConnection, ByVal IP As String, ByVal IPPort As String)
        MyBase.New()
        Try
            If Tipo <> TipoConnection.Ethernet Then
                Throw New ArgumentException("Tipo de Conexión no válida")
            End If

            If String.IsNullOrEmpty(IP) OrElse String.IsNullOrEmpty(IPPort) Then
                Throw New ArgumentException("Parametros de conexión no válidos ")
            End If

            TypeConnection = Tipo

            If TypeConnection = TipoConnection.Ethernet Then
                W = New WinSock
                W.RemoteHost = IP
                W.RemotePort = IPPort
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub New(ByVal Tipo As TipoConnection, ByVal ParSerial As String)
        MyBase.New()
        Try
            If Tipo <> TipoConnection.Serial Then
                Throw New ArgumentException("Tipo de Conexión no válida")
            End If

            If String.IsNullOrEmpty(ParSerial) Then
                Throw New ArgumentException("Parametros de conexión no válidos ")
            End If

            TypeConnection = Tipo

            If TypeConnection = TipoConnection.Serial Then
                COMM = New Com
                COMM.Settings = ParSerial

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Enum TipoConnection As Long
        Serial = 0
        Ethernet = 1
    End Enum
#Region "Propiedades"
    Public ReadOnly Property ConfigConnection() As String
        Get
            If TypeConnection = TipoConnection.Serial Then
                Config = COMM.PortCom
            End If
            If TypeConnection = TipoConnection.Ethernet Then
                Config = W.RemoteHost + "," + W.RemotePort
            End If
            ConfigConnection = Config
        End Get

    End Property

    Public ReadOnly Property TypeConn() As TipoConnection
        Get
            TypeConn = TypeConnection
        End Get
    End Property

    Public Enum StateConnection
        Connected = 7
        Desconnected = 6
    End Enum
    Public ReadOnly Property State As StateConnection
        Get
            If TypeConnection = TipoConnection.Serial Then
                Estado = COMM.State
            End If
            If TypeConnection = TipoConnection.Ethernet Then
                Estado = W.State
            End If
            If Estado = 7 Then
                State = StateConnection.Connected
            Else
                State = StateConnection.Desconnected
            End If

            If TypeConnection = TipoConnection.Ethernet Then
                If Estado <> 7 AndAlso Estado <> EstadoAnt Then
                    EstadoAnt = Estado
                    RaiseEvent ConnectClose()
                End If
            End If

        End Get
    End Property

#End Region
#Region "Metodos"
#Region "Conectar al Host"
    Public Sub Conect()
        Try
            If TypeConnection = TipoConnection.Ethernet Then
                W.Conect()
            End If
            If TypeConnection = TipoConnection.Serial Then
                COMM.Conect()
            End If

            If TypeConnection = TipoConnection.Ethernet AndAlso State = StateConnection.Connected Then
                RaiseEvent Connect()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Sub
#End Region
#Region "Enviar Datos"
    Public Sub SendData(ByVal Datos As String)
        Try
            If TypeConnection = TipoConnection.Serial Then
                COMM.SendData(Datos)
            End If
            If TypeConnection = TipoConnection.Ethernet Then
                W.SendData(Datos)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region
#Region "Leer Datos"
    Public Sub GetData(ByRef Datos As String)
        Try
            If TypeConnection = TipoConnection.Serial Then
                COMM.GetData(Datos)
            End If
            If TypeConnection = TipoConnection.Ethernet Then
                W.GetData(Datos)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
#End Region
#Region "Cierre de Conexión"
    Public Sub Close()
        Try
            If TypeConnection = TipoConnection.Serial Then
                COMM.Close()
            End If
            If TypeConnection = TipoConnection.Ethernet Then
                W.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
#End Region

    Private Class WinSock
        
#Region "VARIABLES"
        Private Strm As NetworkStream 'Utilizado para enviar datos al Servidor y recibir datos del mismo 
        Private IP As String 'Direccion del objeto de la clase Servidor 
        Private Port As String 'Puerto donde escucha el objeto de la clase Servidor 
        Private Estado As Integer = 0
        Private tcpClient As New TcpClient
        Private HacePing As Thread
        Private TimeOutConn As Double = 50 / 1000 ' 50ms
        Private EstadoPing As Integer = 0
#End Region
#Region "PROPIEDADES"
#Region "Host al que nos quermos Conectar"

        Public Property RemoteHost() As String
            Get
                RemoteHost = Ip
            End Get
            Set(ByVal Value As String)
                Ip = Value
            End Set
        End Property
#End Region
#Region "Puerto de Host al que nos queremos Conectar"
        Public Property RemotePort() As String
            Get
                RemotePort = Port
            End Get
            Set(ByVal Value As String)
                Port = Value
            End Set
        End Property
#End Region
#Region "Estado de la Conexión"
        Public ReadOnly Property State() As Integer
            Get
                 If tcpClient.Client Is Nothing Then
                    Estado = 6
                ElseIf EstadoPing = 7 AndAlso tcpClient.Connected Then
                    Estado = 7
                Else
                    tcpClient.Close()
                    Estado = 6
                End If
                State = Estado
            End Get
        End Property
#End Region
#End Region

#Region "METODOS"

#Region "Instacia de Clase"
        Public Sub New()
            MyBase.New()
        End Sub
#End Region
#Region "Conectar"

        Public Sub Conect()

            'AddHandler NetworkChange.NetworkAddressChanged, AddressOf AddressChangedCallback

            If tcpClient.Client Is Nothing OrElse tcpClient.Client.Connected = False Then tcpClient = New TcpClient
            If Not HacePing Is Nothing AndAlso HacePing.IsAlive Then HacePing.Abort()

            Dim ar As IAsyncResult = tcpClient.BeginConnect(IP, Port, Nothing, Nothing)
            Dim wh As Threading.WaitHandle = ar.AsyncWaitHandle

            Try
                If (Not ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(TimeOutConn), False)) Then
                    tcpClient.Close()
                    Estado = 6
                    wh.Close()
                    Return
                    'Throw New TimeoutException()
                End If
                tcpClient.EndConnect(ar)
                EstadoPing = 7
                HacePing = New Thread(AddressOf EstadoConn)
                HacePing.Start()

                Dim NetworkStrm As NetworkStream = tcpClient.GetStream()

                If NetworkStrm.CanWrite And NetworkStrm.CanRead Then
                    Estado = 7
                ElseIf Not NetworkStrm.CanRead Then
                    Estado = 6
                    tcpClient.Close()
                ElseIf Not NetworkStrm.CanWrite Then
                    Estado = 9
                    tcpClient.Close()
                End If

            Catch ex As Exception
                Estado = 6
            Finally
                wh.Close()
            End Try
        End Sub
#End Region
#Region "Obtener Dato, es decir la funcion de lectura de datos"

        Public Sub GetData(ByRef Datos As String)
            Try
                Dim NetworkStrm As NetworkStream = tcpClient.GetStream()

                If NetworkStrm.CanWrite And NetworkStrm.CanRead Then
                    '' Read the NetworkStream into a byte buffer.
                    Dim bytes(tcpClient.Available) As Byte

                    If NetworkStrm.DataAvailable = False Then Exit Sub

                    NetworkStrm.Read(bytes, 0, bytes.Length)
                    '' Output the data received from the host to the console.
                    Dim returndata As String = Encoding.Default.GetString(bytes)
                    Datos = returndata
                    If tcpClient.Connected Then Estado = 7

                ElseIf Not NetworkStrm.CanRead Then
                    Estado = 6
                    tcpClient.Close()
                ElseIf Not NetworkStrm.CanWrite Then
                    Estado = 9
                    tcpClient.Close()
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub
#End Region

#Region "Enviar Datos"

        Public Sub SendData(ByVal Datos As String)
            Try
                Dim NetworkStrm As NetworkStream = tcpClient.GetStream()

                If NetworkStrm.CanWrite And NetworkStrm.CanRead Then

                    '' Send the NetworkStream into a byte buffer.
                    Dim bytes() As Byte

                    'bytes = ASCIIEncoding.ASCII.GetBytes(Datos)
                    bytes = Encoding.Default.GetBytes(Datos)

                    If IsNothing(bytes) Then Exit Sub

                    NetworkStrm.Write(bytes, 0, bytes.Length)
                    NetworkStrm.Flush()

                    If tcpClient.Connected Then Estado = 7


                ElseIf Not NetworkStrm.CanRead Then
                    Estado = 6
                    tcpClient.Close()
                ElseIf Not NetworkStrm.CanWrite Then
                    Estado = 9
                    tcpClient.Close()
                End If

            Catch ex As Exception
                EvError(ex.ToString)
            End Try
        End Sub
#End Region
#Region "Close Conection"
        Public Sub Close()
            Try
                If tcpClient.Connected Then tcpClient.Close()
                Estado = 6
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Sub

#End Region
#Region "Ping de Conectividad"
        Dim Ping As New NetworkInformation.Ping
        Dim myPingCompletedEventHandler As NetworkInformation.PingCompletedEventHandler = New NetworkInformation.PingCompletedEventHandler(AddressOf PingCompletedCallback)

        Private Sub EstadoConn()
            Dim Intervalo As Integer = 7 ' segundos que pasan para hacer ping
            Dim ValorPrevio As DateTime = DateTime.Parse(Now)
            Dim ValorAct As DateTime

            While True
                Try

                    ValorAct = DateTime.Parse(Now)
                    Sleep(2000)
                    If ValorAct.Subtract(ValorPrevio).Duration.Seconds > Intervalo Then
                        ValorPrevio = DateTime.Parse(Now)
                        Dim waiter As AutoResetEvent = New AutoResetEvent(False)
                        AddHandler Ping.PingCompleted, myPingCompletedEventHandler
                        Ping.SendAsync(IP, 1000, waiter)
                    End If

                Catch ex As Exception
                    EstadoPing = 6
                End Try
            End While
        End Sub

        Private Sub PingCompletedCallback(ByVal sender As Object, ByVal e As PingCompletedEventArgs)
            Try

                If e.Reply.Status = NetworkInformation.IPStatus.Success Then
                    EstadoPing = 7
                Else
                    EstadoPing = 6
                End If
                '*do something*
                RemoveHandler Ping.PingCompleted, myPingCompletedEventHandler

            Catch ex As Exception
                EstadoPing = 6
            End Try
        End Sub
#End Region

#End Region
    End Class
    Private Class Com

        Private Comm As SerialPort
        Private PuertoCom As String = ""
        Private Config As String
        Private ParSerial As String = "1,9600,8,0,1,0"
        Private ConexStab As Integer

        Public Sub New()
            MyBase.New()
            Comm = New SerialPort
        End Sub

#Region "PROPIEDADES"
#Region "Puerto Serial al que nos quermos Conectar"
        Public Property PortCom() As String
            Get
                PortCom = PuertoCom
            End Get
            Set(ByVal Value As String)
                PuertoCom = Value
            End Set
        End Property
#End Region
#Region "Settins"
        Public Property Settings As String
            Get
                Settings = Config
            End Get
            Set(ByVal value As String)
                Config = value
            End Set
        End Property
#End Region
#Region "Estado de la Conexión"
        Public ReadOnly Property State() As Integer
            Get
                If ConexStab = 7 AndAlso Comm.IsOpen Then
                    State = 7
                Else
                    State = 6
                End If

            End Get
        End Property
#End Region
#End Region
#Region "Metodos"
#Region "Conectar"

        Public Sub Conect()
            Try
                Dim ParSer() As String

                ParSer = Settings.Split(",")
                Comm.PortName = "COM" + ParSer(0)
                If ParSer.Length < 2 Then ParSer = ParSerial.Split(",")
                Comm.BaudRate = ParSer(1)
                Comm.DataBits = ParSer(2)
                Comm.Parity = ParSer(3)
                Comm.StopBits = ParSer(4)
                Comm.Handshake = ParSer(5)

                If Comm.IsOpen = False Then Comm.Open()
                ConexStab = 7
            Catch ex As System.IO.IOException
                MsgBox("Error abriendo el puerto: " & _
                vbCrLf & ex.Message & vbCrLf)
                ConexStab = 6
            Catch ex As System.UnauthorizedAccessException
                MsgBox("El pueto ya esta abierto: " & vbCrLf & _
                ex.Message & vbCrLf)
                ConexStab = 6
            Catch ex As Exception
                MsgBox(ex.ToString)
                ConexStab = 6
            End Try

        End Sub
#End Region
#Region "Obtener Dato, es decir la funcion de lectura de datos"

        Public Sub GetData(ByRef Datos As String)
            Try
                If Comm.IsOpen = False Then Return
                Datos = Comm.ReadExisting()

            Catch ex As System.IO.IOException
                MsgBox("Error abriendo el puerto: " & _
                vbCrLf & ex.Message & vbCrLf)
            Catch ex As System.UnauthorizedAccessException
                MsgBox("El pueto ya esta abierto: " & vbCrLf & _
                ex.Message & vbCrLf)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub
#End Region
#Region "Enviar Datos"
        Public Sub SendData(ByVal Datos As String)
            Try
                Comm.Encoding = Encoding.Default

                If String.IsNullOrEmpty(Datos) Then Return
                If Comm.IsOpen = False Then Return

                Comm.Write(Datos)

            Catch ex As System.IO.IOException
                MsgBox("Error abriendo el puerto: " & _
                vbCrLf & ex.Message & vbCrLf)
            Catch ex As System.UnauthorizedAccessException
                MsgBox("El pueto ya esta abierto: " & vbCrLf & _
                ex.Message & vbCrLf)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub

#End Region
#Region "Close Conection"
        Public Sub Close()
            Try
                If Comm.IsOpen Then Comm.Close()

            Catch ex As System.IO.IOException
                MsgBox("Error abriendo el puerto: " & _
                vbCrLf & ex.Message & vbCrLf)
            Catch ex As System.UnauthorizedAccessException
                MsgBox("El pueto ya esta abierto: " & vbCrLf & _
                ex.Message & vbCrLf)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Sub
#End Region
#End Region
    End Class

End Class

