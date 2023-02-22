Option Explicit On
Imports System.Net.Sockets
Imports System.Text
Imports System.Net.NetworkInformation


Public Class WinSock
    Private Estado As Integer = 0
    Private tcpClient As New TcpClient

    Public Sub New()
        MyBase.New()
     End Sub

#Region "VARIABLES"
    Private Strm As NetworkStream 'Utilizado para enviar datos al Servidor y recibir datos del mismo 
    Private IP As String 'Direccion del objeto de la clase Servidor 
    Private Port As String 'Puerto donde escucha el objeto de la clase Servidor 
#End Region
#Region "PROPIEDADES"
#Region "Host al que nos quermos Conectar"

    Public Property RemoteHost() As String
        Get
            RemoteHost = IP
        End Get
        Set(ByVal Value As String)
            IP = Value
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
            If tcpClient.Connected Then
                Estado = 7
            Else
                Estado = 6
            End If

            State = Estado
        End Get
    End Property
#End Region
#End Region
#Region "EVENTOS"
    Public Event ConexionTerminada()
    Public Event DatosRecibidos(ByVal datos As String)
#End Region
#Region "METODOS"
#Region "Conectar"

    Public Sub Conect()
        Try
            AddHandler NetworkChange.NetworkAddressChanged, AddressOf AddressChangedCallback

            If tcpClient.Connected = False Then tcpClient = New TcpClient

            tcpClient.Connect(IP, Port)

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

        Catch ex As SocketException
            Evento(ex.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Estado = 6
            'MsgBox(ex.ToString)
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
#Region "Obtener Dato, es decir la funcion de lectura de datos"

    Public Sub GetData(ByRef Datos As String)
        Try
            Dim NetworkStrm As NetworkStream = TcpClient.GetStream()

            If NetworkStrm.CanWrite And NetworkStrm.CanRead Then
                '' Read the NetworkStream into a byte buffer.
                Dim bytes(TcpClient.ReceiveBufferSize) As Byte

                If NetworkStrm.DataAvailable = False Then Exit Sub

                NetworkStrm.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
                '' Output the data received from the host to the console.
                Dim returndata As String = Encoding.ASCII.GetString(bytes)
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
#Region " Evento de Desconexion"
    Private Sub AddressChangedCallback(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If My.Computer.Network.Ping(Me.RemoteHost) = True Then
                Estado = 7
            Else
                tcpClient.Close()
                Estado = 6
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
        'Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        'Dim n As NetworkInterface
        'For Each n In adapters
        '    n.GetIPProperties.GetIPv4Properties.ToString()

        '    MsgBox("   {0} is {1}" & n.Name & n.OperationalStatus)
        'Next n
    End Sub

#End Region
#Region "Enviar Datos"

    Public Sub SendData(ByVal Datos As String)
        Try
            Dim NetworkStrm As NetworkStream = tcpClient.GetStream()

            If NetworkStrm.CanWrite And NetworkStrm.CanRead Then


                '' Send the NetworkStream into a byte buffer.
                Dim bytes() As Byte
                bytes = Encoding.Default.GetBytes(Datos)
                'bytes = ASCIIEncoding.ASCII.GetBytes(Datos)

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
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#End Region
   
End Class

