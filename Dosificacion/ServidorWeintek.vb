Imports System

Public Class ServidorWeintek

    Private Dato As Int32
    Private Palab As String
    Private Envio As String
    Private Encab As String
    Private Longitud As Long
    Private Recibido As String
    Private Pos1 As Long
    Private Pos2 As Long
    Private TxBlink As Boolean

    Private FormLoad As Boolean
    Private WithEvents Conx As Connection

    Private FRxPant As ArrayControles(Of Button)
    Private FPideDatosPant As ArrayControles(Of Button)
    Private FEnviaDatos As ArrayControles(Of Button)
    Private FBuscaOP As ArrayControles(Of Button)
    Private FTx As ArrayControles(Of Button)
    Private BLimpiar As ArrayControles(Of Button)
    Private TOPs As ArrayControles(Of TextBox)
    Private TOPSol As ArrayControles(Of TextBox)
    Private TCodProd As ArrayControles(Of TextBox)
    Private TNomProd As ArrayControles(Of TextBox)
    Private TOrig As ArrayControles(Of TextBox)
    Private TDest As ArrayControles(Of TextBox)
    Private TPresent As ArrayControles(Of TextBox)
    Private TGrp As ArrayControles(Of TextBox)
    Private TSacMeta As ArrayControles(Of TextBox)
    Private TSacTot As ArrayControles(Of TextBox)
    Private TSac As ArrayControles(Of TextBox)
    Private TBotones As ArrayControles(Of TextBox)
    Private TOnOffTMto As ArrayControles(Of TextBox)
    Private THabStartEmp As ArrayControles(Of TextBox)
    Public TMsg As ArrayControles(Of TextBox)
    Public TSacSinRep As ArrayControles(Of TextBox)
    Public TAlarma As ArrayControles(Of TextBox)
    Private TCodTMuerto As ArrayControles(Of TextBox)
    Private TAjuste As ArrayControles(Of TextBox)

    Private OPDigAnt(3) As String

    Private SacAnt(3) As Double
    Private SacAjus(3) As Double
    Private Datos(3) As String
    Private Preset(3) As String

    Private DArt As AdoNet
    Private DOPs As AdoNet
    Private DEmp As AdoNet
    Private DVarios As AdoNet
    Private DEquipos As AdoNet
    Private DConfig As AdoNet
    Private DTMuertos As AdoNet
    Private DTMuertosCat As AdoNet
    Private DProcEnLinea As AdoNet
    Private EmpSinSacOff(3) As Int32
    Private ChkSacOpAct(3) As Int32
    Private SacosAnt(3) As Int32

    Private Sub ServidorWeintek_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Public Sub ServidorWeintek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Si el formulario ya está cargado no lo vuelve a cargar
            If FormLoad = True Then Return

            FRxPant = New ArrayControles(Of Button)("FRxPant", Me)
            FPideDatosPant = New ArrayControles(Of Button)("FPideDatosPant", Me)
            FEnviaDatos = New ArrayControles(Of Button)("FEnviaDatos", Me)
            FBuscaOP = New ArrayControles(Of Button)("FBuscaOP", Me)
            FTx = New ArrayControles(Of Button)("FTx", Me)
            BLimpiar = New ArrayControles(Of Button)("BLimpiar", Me)
            TOPs = New ArrayControles(Of TextBox)("TOPs", Me)
            TOPSol = New ArrayControles(Of TextBox)("TOPSol", Me)
            TCodProd = New ArrayControles(Of TextBox)("TCodProd", Me)
            TNomProd = New ArrayControles(Of TextBox)("TNomProd", Me)
            TOrig = New ArrayControles(Of TextBox)("TOrig", Me)
            TDest = New ArrayControles(Of TextBox)("TDest", Me)
            TPresent = New ArrayControles(Of TextBox)("TPresent", Me)
            TGrp = New ArrayControles(Of TextBox)("TGrp", Me)
            TSacMeta = New ArrayControles(Of TextBox)("TSacMeta", Me)
            TSacTot = New ArrayControles(Of TextBox)("TSacTot", Me)
            TSac = New ArrayControles(Of TextBox)("TSac", Me)
            TBotones = New ArrayControles(Of TextBox)("TBotones", Me)
            TOnOffTMto = New ArrayControles(Of TextBox)("TOnOffTMto", Me)
            THabStartEmp = New ArrayControles(Of TextBox)("THabStartEmp", Me)
            TMsg = New ArrayControles(Of TextBox)("TMsg", Me)
            TSacSinRep = New ArrayControles(Of TextBox)("TSacSinRep", Me)
            TAlarma = New ArrayControles(Of TextBox)("TAlarma", Me)
            TCodTMuerto = New ArrayControles(Of TextBox)("TCodTMuerto", Me)
            TAjuste = New ArrayControles(Of TextBox)("TAjuste", Me)

            DOPs = New AdoNet("OPS", CONN, DbProvedor)
            DArt = New AdoNet("ARTICULOS", CONN, DbProvedor)
            DEquipos = New AdoNet("Equipos", CONN, DbProvedor)
            DVarios = New AdoNet("VARIOS", CONN, DbProvedor)
            DEmp = New AdoNet("EMPAQUE", CONN, DbProvedor)
            DConfig = New AdoNet("CONFIG", CONN, DbProvedor)
            DTMuertos = New AdoNet("TMUERTOS", CONN, DbProvedor)
            DTMuertosCat = New AdoNet("TMUERTOSCAT", CONN, DbProvedor)
            DProcEnLinea = New AdoNet("ProcEnLinea", CONN, DbProvedor)

            DConfig.Open("select * from CONFIG")
            DTMuertos.Open("select * from TMUERTOS where CONT=0")
            DEquipos.Open("select * from EQUIPOS")

            DEquipos.Find("EQUIPO=2")
            If DEquipos.EOF = False Then
                If DEquipos.RecordSet("TIPOCONEXION").ToString.ToUpper = "SERIAL" Then
                    '1,9600,8,0,1,0
                    Conx = New Connection(Connection.TipoConnection.Serial, DEquipos.RecordSet("COM").ToString + ",19200,8,0,1,0")
                ElseIf DEquipos.RecordSet("TIPOCONEXION").ToString.ToUpper = "ETHERNET" Then
                    Conx = New Connection(Connection.TipoConnection.Ethernet, DEquipos.RecordSet("IP").ToString, DEquipos.RecordSet("IPPORT").ToString)
                End If
                Conx.Conect()
            Else
                MsgError("No existe el Equipo 2 en la tabla equipos")
            End If


            For Each Boton As Button In FRxPant.Values
                AddHandler Boton.Click, AddressOf FRxPant_Click
            Next
            For Each Boton As Button In FPideDatosPant.Values
                AddHandler Boton.Click, AddressOf FPideDatosPant_Click
            Next

            For Each Boton As Button In FBuscaOP.Values
                AddHandler Boton.Click, AddressOf FBuscaOP_Click
            Next
            For Each Boton As Button In FTx.Values
                AddHandler Boton.Click, AddressOf FTx_Click
            Next
            For Each Boton As Button In BLimpiar.Values
                AddHandler Boton.Click, AddressOf BLimpiar_Click
            Next

            FormLoad = True
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FRxPant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRxPant1.Click, FRxPant2.Click
        Try

            If FRxPant Is Nothing Then Return

            Dim Index As Int32 = FRxPant.Index(CType(sender, Button))

            Recibido = ""

            If Not Conx Is Nothing Then
                If Conx.State = Connection.StateConnection.Connected Then
                    Conx.GetData(Recibido)
                    TEstadoW.Text = "7"
                    TEstadoW.BackColor = Color.GreenYellow
                    Empaque.TEstadoW.Text = "Connection ON"
                    Empaque.TEstadoW.BackColor = Color.LimeGreen
                Else
                    TEstadoW.BackColor = Color.White
                    TEstadoW.Text = "6"
                    Empaque.TEstadoW.Text = "Connection OFF"
                    Empaque.TEstadoW.BackColor = Color.White
                End If


                If CInt(Eval(TMonRx.Text)) Mod 5 = 0 Then
                    If Conx.TypeConn = Connection.TipoConnection.Ethernet AndAlso Conx.State = Connection.StateConnection.Desconnected Then
                        Conx.Conect()
                    End If
                End If

            End If

            If Len(TRx.Text) > 500 Then TRx.Text = Mid(TRx.Text, 500)

            'If Recibido = "" Then Exit Sub

            For K = 1 To Len(Recibido)
                TRx.Text = TRx.Text + Format(Asc(Mid(Recibido, K, 1)), "000 ")
            Next


            Pos1 = InStr(1, TRx.Text, "253 253 000 000")  'Detecta el inicio de la trama de llegada de 8 registros
            If Pos1 > 0 Then
                TRx.Text = Mid(TRx.Text, Pos1)
                Pos1 = InStr(2, TRx.Text, "253 253 000 000")    'Detecta si hay mas datos acumulados
                Do While Pos1 > 0
                    TRx.Text = Mid(TRx.Text, Pos1)
                    Pos1 = InStr(2, TRx.Text, "253 253 000 000")    'Detecta si hay mas tramas acumuladas
                Loop

                TBotones(Index).Text = Eval(Mid(TRx.Text, 37, 3)) * 256 + Eval(Mid(TRx.Text, 41, 3))
                TPresent(Index).Text = Chr(Eval(Mid(TRx.Text, 49, 3))) + Chr(Eval(Mid(TRx.Text, 45, 3)))
                If Eval(Mid(TRx.Text, 45, 3)) * 256 = 0 Then TPresent(Index).Text = Chr(Eval(Mid(TRx.Text, 49, 3)))
                TOrig(Index).Text = Eval(Mid(TRx.Text, 53, 3)) * 256 + Eval(Mid(TRx.Text, 57, 3))
                TDest(Index).Text = Chr(Eval(Mid(TRx.Text, 65, 3))) + Chr(Eval(Mid(TRx.Text, 61, 3)))
                TGrp(Index).Text = Eval(Mid(TRx.Text, 69, 3)) * 256 + Eval(Mid(TRx.Text, 73, 3))
                TSac(Index).Text = Eval(Mid(TRx.Text, 77, 3)) * 256 + Eval(Mid(TRx.Text, 81, 3))
                TOPSol(Index).Text = Eval(Mid(TRx.Text, 85, 3)) * 256 + Eval(Mid(TRx.Text, 89, 3)) + Eval(Mid(TRx.Text, 93, 3)) * 2 ^ 24 + Eval(Mid(TRx.Text, 97, 3)) * 2 ^ 16
                TCodTMuerto(Index).Text = Eval(Mid(TRx.Text, 101, 3)) * 256 + Eval(Mid(TRx.Text, 105, 3))
                TAjuste(Index).Text = Eval(Mid(TRx.Text, 109, 3)) * 256 + Eval(Mid(TRx.Text, 113, 3))
                If Eval(Mid(TRx.Text, 109, 3)) = 255 Then TAjuste(Index).Text = -(256 - Eval(Mid(TRx.Text, 113, 3)))

                Index = 2

                TBotones(Index).Text = Eval(Mid(TRx.Text, 117, 3)) * 256 + Eval(Mid(TRx.Text, 121, 3))
                TPresent(Index).Text = Chr(Eval(Mid(TRx.Text, 129, 3))) + Chr(Eval(Mid(TRx.Text, 125, 3)))
                If Eval(Mid(TRx.Text, 129, 3)) * 256 = 0 Then TPresent(Index).Text = Chr(Eval(Mid(TRx.Text, 129, 3)))
                TOrig(Index).Text = Eval(Mid(TRx.Text, 133, 3)) * 256 + Eval(Mid(TRx.Text, 137, 3))
                TDest(Index).Text = Chr(Eval(Mid(TRx.Text, 145, 3))) + Chr(Eval(Mid(TRx.Text, 141, 3)))
                TGrp(Index).Text = Eval(Mid(TRx.Text, 149, 3)) * 256 + Eval(Mid(TRx.Text, 153, 3))
                TSac(Index).Text = Eval(Mid(TRx.Text, 157, 3)) * 256 + Eval(Mid(TRx.Text, 161, 3))
                TOPSol(Index).Text = Eval(Mid(TRx.Text, 165, 3)) * 256 + Eval(Mid(TRx.Text, 169, 3)) + Eval(Mid(TRx.Text, 173, 3)) * 2 ^ 24 + Eval(Mid(TRx.Text, 177, 3)) * 2 ^ 16
                TCodTMuerto(Index).Text = Eval(Mid(TRx.Text, 181, 3)) * 256 + Eval(Mid(TRx.Text, 185, 3))
                TAjuste(Index).Text = Eval(Mid(TRx.Text, 189, 3)) * 256 + Eval(Mid(TRx.Text, 193, 3))
                If Eval(Mid(TRx.Text, 189, 3)) = 255 Then TAjuste(Index).Text = -(256 - Eval(Mid(TRx.Text, 193, 3)))
                Dim Libre As String = Eval(Mid(TRx.Text, 197, 3)) * 256 + Eval(Mid(TRx.Text, 201, 3))
                TContPant.Text = Eval(Mid(TRx.Text, 205, 3)) * 256 + Eval(Mid(TRx.Text, 209, 3))

                Dim OPEmpAct(3) As String

                OPEmpAct(1) = Eval(Mid(TRx.Text, 213, 3)) * 256 + Eval(Mid(TRx.Text, 217, 3)) + Eval(Mid(TRx.Text, 221, 3)) * 2 ^ 24 + Eval(Mid(TRx.Text, 225, 3)) * 2 ^ 16
                OPEmpAct(2) = Eval(Mid(TRx.Text, 229, 3)) * 256 + Eval(Mid(TRx.Text, 233, 3)) + Eval(Mid(TRx.Text, 237, 3)) * 2 ^ 24 + Eval(Mid(TRx.Text, 241, 3)) * 2 ^ 16

                For Index = 1 To 2

                    If Eval(TBotones(Index).Text) = 8 Then 'Stop
                        BLimpiar_Click(BLimpiar(Index), Nothing)
                        TBotones(Index).Text = 10    'Asigno este valor para que la pantalla reincie el valor de botones
                        TMsg(Index).Text = "  EMPAQUE DETENIDO  "
                    End If

                    If Eval(TOPSol(Index).Text) > 0 Then
                        ChkSacOpAct(Index) = 20
                        FBuscaOP_Click(FBuscaOP(Index), Nothing)
                    ElseIf Eval(OPEmpAct(Index)) > 0 AndAlso Eval(TOPSol(Index).Text) = 0 AndAlso Eval(TOPs(Index).Text) = 0 Then
                        TOPSol(Index).Text = OPEmpAct(Index)
                        ChkSacOpAct(Index) = 10
                        FBuscaOP_Click(FBuscaOP(Index), Nothing)
                    Else
                        ChkSacOpAct(Index) = 30 'No hace nada
                    End If

                    If Eval(TOPSol(Index).Text) > 0 Then
                        FBuscaOP_Click(FBuscaOP(Index), Nothing)
                    End If

                    'AndAlso Eval(TOPSol(Index).Text) <> OPDigAnt(Index) Then
                    'OPDigAnt(Index) = Eval(TOPSol(Index).Text)

                    Datos(Index) = "OP," + TOPs(Index).Text + ",SACOS," + TSac(Index).Text + ",ORI," + TOrig(Index).Text + ",DES," + TDest(Index).Text + ",AJUS," + TAjuste(Index).Text + _
                    ",EMP," + TPresent(Index).Text + ",TMTO," + TCodTMuerto(Index).Text
                    If Eval(TSac(Index).Text) <> SacAnt(Index) OrElse Eval(TAjuste(Index).Text) <> SacAjus(Index) Then
                        WriteFile(Ruta + "APlanos\Sac" + Index.ToString + "_" + Now.ToString("yyMMdd") + ".txt", Now.ToString("HH:mm:ss    ") + vbCrLf + Datos(Index))
                        SacAnt(Index) = Eval(TSac(Index).Text)
                        SacAjus(Index) = Eval(TAjuste(Index).Text)
                    End If

                Next

            End If

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FPideDatosPant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FPideDatosPant1.Click, FPideDatosPant2.Click
        Try
            If FPideDatosPant Is Nothing Then Return

            Dim Index As Int32 = FPideDatosPant.Index(CType(sender, Button))


            'Los datos de empaque de la ensacadora 1 del Registro 135 en adelante

            'Encabezado Modbus IP
            Encab = Chr(253) + Chr(253)      'ID de transaccion. Puede ser cualquiera. Se escogio esta para el mensaje de LECTURA de reportes
            Encab = Encab + Chr(0) + Chr(0) 'Protocolo Hi y Lo
            Encab = Encab + Chr(0) + Chr(6) 'Longitud Hi y Lo.Cuando se escriben varios reg. esta long. se le suma 7.

            'Encabezado ModBus normal
            Encab = Encab + Chr(1)               'Direccion del equipo
            Encab = Encab + Chr(3)               'Comando 3, para lectura de varios registros
            Dato = 300         'Direccion donde se va a leer.
            Encab = Encab + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)   'Direccion Hi y Lo donde se va a leer.
            Encab = Encab + Chr(0) + Chr(26)     'Cantidad HI y Lo de registros a leer en Words, se deben leer 9 en este caso,

            'Se unen el encabezado y los datos
            Envio = Encab

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(Envio)
                TTx.Text = ""
                For K = 1 To Len(Envio)
                    TTx.Text = TTx.Text + Format(Asc(Mid(Envio, K, 1)), "000 ")
                Next
            End If

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FEnviaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEnviaDatos1.Click, FEnviaDatos2.Click
        Try
            If FEnviaDatos Is Nothing Then Return

            Dim Index As Int32 = FEnviaDatos.Index(CType(sender, Button))

            Envio = ""


            Palab = TOPs(Index).Text + Space(6)    ' Enviamos el dato de la OP 6 caracteres
            For K = 1 To 5 Step 2
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K

            Palab = TCodProd(Index).Text + Space(14)    ' Enviamos el dato del CodProd 14 caracteres
            For K = 1 To 13 Step 2
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K

            Palab = TNomProd(Index).Text + Space(30)    ' Enviamos el dato del NomProd 30 caracteres
            For K = 1 To 29 Step 2
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K

            Dato = Eval(TSacTot(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)  ' Enviamos Sacos Total

            Dato = Eval(TSacMeta(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256) ' Enviamos Sacos Meta 

            Dato = Eval(TSacSinRep(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256) ' Enviamos Sacos sin Rep 

            Palab = TMsg(Index).Text + Space(20)    ' Enviamos el dato de Mensajes 20 caracteres
            For K = 1 To 19 Step 2
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K

            Dato = Eval(THabStartEmp(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256) ' Enviamos Flag para Hab Emp 

            Dato = Eval(TOnOffTMto(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256) ' Enviamos Flag para Ventana de Alarma 

            Dato = Eval(TBotones(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256) ' Enviamos Botones

            Dato = Eval(TCodTMuerto(Index).Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256) ' Enviamos Botones

            If Index = 1 Then
                If TxBlink Then
                    Envio = Envio + Chr(0) + Chr(1)   'TxBlink para mmostrar en pantalla
                    TxBlink = False
                Else
                    Envio = Envio + Chr(0) + Chr(0)
                    TxBlink = True
                End If
            End If

            'Encabezado Modbus IP
            Encab = Chr(254) + Chr(254)      'ID de transaccion. Puede ser cualquiera. Se escogio esta para el mensaje de escritura 
            Encab = Encab + Chr(0) + Chr(0) 'Protocolo Hi y Lo
            Longitud = Len(Envio)     'Longitud en bytes de los datos. 
            Encab = Encab + Chr(0) + Chr(Longitud + 7) 'Longitud Hi y Lo.Cuando se escriben varios reg. esta long. se le suma 7. Se supone que nunca sera mayor a 248 + 7 (255)

            'Encabezado ModBus normal
            Encab = Encab + Chr(1)               'Direccion del equipo
            Encab = Encab + Chr(16)               'Comando 16, para escribir varios registros
            Encab = Encab + Chr(0) + Chr(100 * Index)     'Direccion Hi y Lo donde se va a escribir. En la pantalla es LW 100 Emp1 200 Emp2
            Encab = Encab + Chr(0) + Chr(Longitud / 2)     'Cantidad HI y Lo de registros a escribir en Words
            Encab = Encab + Chr(Longitud)     'Cantidad de bytes que van de datos. Es un solo byte

            'Se unen el encabezado y los datos
            Envio = Encab + Envio

            If Conx.State = Connection.StateConnection.Connected Then
                Conx.SendData(Envio)
                TTx.Text = ""
                For K = 1 To Len(Envio)
                    TTx.Text = TTx.Text + Format(Asc(Mid(Envio, K, 1)), "000 ")
                Next
            End If

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub TimRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimRx.Tick
        Try

            TMonRx.Text = Eval(TMonRx.Text) + 1
            If Eval(TMonRx.Text) > 20000 Then TMonRx.Text = 1

            FRxPant_Click(FRxPant(1), Nothing)

            If Eval(TMonRx.Text) Mod 3 = 0 Then
                FPideDatosPant_Click(FPideDatosPant(1), Nothing)
            End If

            If Eval(TMonRx.Text) Mod 5 = 0 Then
                FTx_Click(FTx(1), Nothing)
                FTx_Click(FTx(2), Nothing)
                FEnviaDatos_Click(FEnviaDatos(1), Nothing)
                FEnviaDatos_Click(FEnviaDatos(2), Nothing)
            End If

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FBuscaOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FBuscaOP1.Click, FBuscaOP2.Click
        Try
            If FBuscaOP Is Nothing Then Return
            Dim Index As Int32 = FBuscaOP.Index(CType(sender, Button))

            DOPs.Open("select * from OPS where OP='" + TOPSol(Index).Text + "' and FINPLANILLA<>'S'")
            EmpSinSacOff(Index) = 0
            If DOPs.RecordCount = 0 Then
                BLimpiar_Click(BLimpiar(Index), Nothing)
                TNomProd(Index).Text = "OP NO EXISTE"
                TMsg(Index).Text = "OP NO EXISTE"
                Return
            End If

            If Eval(ChkSacOpAct(Index)) = 20 AndAlso Eval(TSac(Index).Text) > 0 Then
                BLimpiar_Click(BLimpiar(Index), Nothing)
                TNomProd(Index).Text = "DEBE DAR STOP PRIMERO"
                TMsg(Index).Text = "DEBE DAR STOP"
                Return
            End If

            TOPs(Index).Text = DOPs.RecordSet("OP")
            TCodProd(Index).Text = DOPs.RecordSet("CODPROD")

            DArt.Open("select * from ARTICULOS where TIPO='PT' and CodInt='" + TCodProd(Index).Text + "'")
            If DArt.RecordCount = 0 Then
                BLimpiar_Click(BLimpiar(Index), Nothing)
                TNomProd(Index).Text = "PROD NO EXISTE"
                TMsg(Index).Text = "PROD NO EXISTE"
                Return
            End If

            'DVarios.Open("Select * from PRODEQUIVALENTES where CODPROD='" + TCodProd(Index).Text + "' and PRESENT='" + TPresent(Index).Text + "'")
            'If DVarios.RecordCount = 0 Then
            '    BLimpiar_Click(BLimpiar(Index), Nothing)
            '    TNomProd(Index).Text = "PROD SIN CODIGO EQUIVA."
            '    TMsg(Index).Text = "PROD SIN CODIGO"
            '    Return
            'End If

            TNomProd(Index).Text = DArt.RecordSet("Nombre")
            Empaque.TNomProd(Index).Text = DArt.RecordSet("NOMBRE")
            Empaque.TPreset(Index).Text = DArt.RecordSet("PRESKG")
            Empaque.TCodEmp(Index).Text = DArt.RecordSet("CODEMP")
            Empaque.TCodEtiq(Index).Text = DArt.RecordSet("CODETIQ")
            Empaque.TCodProd(Index).Text = DOPs.RecordSet("CodProd").ToString
            Empaque.TOPs(Index).Text = TOPs(Index).Text
            Empaque.TAjuste(Index).Text = TAjuste(Index).Text

            Preset(Index) = DArt.RecordSet("PRESKG").ToString

            If DOPs.RecordSet("SINCONTROLSACKOFF") Then EmpSinSacOff(Index) = 10

            FTx_Click(FTx(Index), Nothing)
            THabStartEmp(Index).Text = "1"
            TAlarma(Index).Text = "0"
            TOnOffTMto(Index).Text = "0"

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FTx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FTx1.Click, FTx2.Click
        Try

            If FTx Is Nothing Then Return
            Dim Index As Int32 = FTx.Index(CType(sender, Button))

            If Eval(TOPs(Index).Text) = 0 Then Return


            Empaque.TResiduo(Index).Text = "0"
            Empaque.TPresent(Index).Text = TPresent(Index).Text
            Empaque.TDestino(Index).Text = TDest(Index).Text
            Empaque.TOrigen(Index).Text = TOrig(Index).Text
            Empaque.TSacos(Index).Text = TSac(Index).Text
            Empaque.TGrupoEmp(Index).Text = TGrp(Index).Text
            Empaque.TAjuste(Index).Text = TAjuste(Index).Text

            ServidorRep.TSacos.Text = TSac(1).Text
            ServidorRep2.TSacos.Text = TSac(2).Text
            ServidorRep.TPreset.Text = Preset(1)
            ServidorRep2.TPreset.Text = Preset(2)

            'Por defecto esta en 1 se evaluan los casos y se asigna 0 para detener el empaque
            THabStartEmp(Index).Text = "1"

            If TPresent(Index).Text = "" OrElse TDest(Index).Text = "" OrElse TOrig(Index).Text = "0" OrElse TGrp(Index).Text = "0" Then
                TMsg(Index).Text = "Datos Incompletos"
                THabStartEmp(Index).Text = 0
                EventoEmp(TMsg(Index).Text)
                Return
            End If

            DVarios.Open("select OP, Sum(" + SentenciaSacos + ") AS TOTSACOS From EMPAQUE where MAQUINA<>101 group by OP HAVING OP='" + Eval(TOPs(Index).Text).ToString + "'")
            If DVarios.RecordCount > 0 Then
                TSacTot(Index).Text = DVarios.RecordSet("TOTSACOS").ToString
                If TAlarma(Index).Text <> "77" Then
                    TMsg(Index).Text = "SACOS " + DVarios.RecordSet("TOTSACOS").ToString
                End If
            Else
                TMsg(Index).Text = " SACOS TOT 0"
            End If

            DVarios.Open("select OP, Sum(PESO) AS TOTGRANEL From EMPAQUE where (MAQUINA=4 OR MAQUINA=5) AND TIPO='GRANEL' group by OP HAVING OP='" + Eval(TOPs(Index).Text).ToString + "'")
            If DVarios.RecordCount > 0 Then
                TSacTot(Index).Text = Eval(TSacTot(Index).Text) + DVarios.RecordSet("TOTGRANEL") \ Eval(Empaque.TPreset(Index).Text)
                If TAlarma(Index).Text <> "77" Then TMsg(Index).Text = "SACOS " + TSacTot(Index).Text.ToString
            End If

            DVarios.Open("select OP, Sum(PESOREAL) AS TOTALKG From BACHES group by OP HAVING (OP)='" + Eval(TOPs(Index).Text).ToString + "'")
            If DVarios.RecordCount > 0 AndAlso IsDBNull(DVarios.RecordSet("TOTALKG")) = False Then
                If Eval(Empaque.TPreset(Index).Text) > 0 Then
                    TSacMeta(Index).Text = (CInt(Eval(DVarios.RecordSet("TOTALKG").ToString) / Eval(Empaque.TPreset(Index).Text))).ToString
                    If TAlarma(Index).Text <> "77" Then TMsg(Index).Text += "/" + (CInt(Eval(DVarios.RecordSet("TOTALKG")) / Eval(Empaque.TPreset(Index).Text))).ToString
                    If DVarios.RecordSet("TOTALKG") < Eval(Empaque.TPreset(Index).Text) And Eval(TAlarma(Index).Text) < 10 Then TAlarma(Index).Text = 9
                End If
            Else
                If EmpSinSacOff(Index) <> 10 Then
                    TAlarma(Index).Text = 9 ' Alarma en 9 =OP sin priduccion
                    TMsg(Index).Text = "OP sin produccion"
                    THabStartEmp(Index).Text = 0
                End If
            End If

           
            If EmpSinSacOff(Index) <> 10 AndAlso Eval(TSacTot(Index).Text) >= Eval(TSacMeta(Index).Text) * 1.015 Then
                BLimpiar_Click(BLimpiar(Index), Nothing)
                TMsg(Index).Text = "SAC.REAL > META"
                TAlarma(Index).Text = "8"
                THabStartEmp(Index).Text = 0
            End If

            If Eval(TSacSinRep(Index).Text) > DConfig.RecordSet("FRECREPESO") Then
                TAlarma(Index).Text = "2"
                THabStartEmp(Index).Text = 0
                TMsg(Index).Text = "PONGA SACO BASC.REP"
            End If

            If Eval(Empaque.TTMuerto(Index).Text) > DConfig.RecordSet("TMUERTOENSAQ") Then
                TAlarma(Index).Text = "11"
                TOnOffTMto(Index).Text = "1"
                THabStartEmp(Index).Text = 0
            End If

            If Eval(TAlarma(Index).Text) = 11 AndAlso Eval(TCodTMuerto(Index).Text) > 0 AndAlso Eval(TBotones(Index).Text) = 16 Then
                DTMuertosCat.Open("select * from TMUERTOSCAT where CODMOTIVO=" + Eval(TCodTMuerto(Index).Text).ToString)
                If DTMuertosCat.RecordCount > 0 Then
                    TAlarma(Index).Text = "0"
                    DTMuertos.AddNew()
                    DTMuertos.RecordSet("PROCESO") = "ENSAQ"
                    DTMuertos.RecordSet("Fecha") = Now.ToString("yyyy/MM/dd HH:mm:dd")
                    DTMuertos.RecordSet("TIEMPO") = Eval(Empaque.TTMuerto(Index).Text) / 60
                    DTMuertos.RecordSet("CODMOTIVO") = Eval(TCodTMuerto(Index).Text)
                    DTMuertos.RecordSet("Usuario") = "ENSAQUE " + Trim(Index)
                    DTMuertos.RecordSet("GrupoEmp") = Eval(TGrp(Index).Text)
                    DTMuertos.RecordSet("Maquina") = Index
                    DTMuertos.RecordSet("Observacion") = DTMuertosCat.RecordSet("MOTIVO")
                    DTMuertos.Update()
                    Empaque.TTMuerto(Index).Text = 0
                    TOnOffTMto(Index).Text = "0"
                    THabStartEmp(Index).Text = "1"
                    TBotones(Index).Text = "10" 'Asignamos el valor en 10 para que la pantalla me resete los botones
                    TCodTMuerto(Index).Text = "10" 'Asignamos el valor en 10 para que la pantalla me resete el codTMuerto
                End If
            End If

            If TAlarma(Index).Text = "77" AndAlso Eval(TMonRx.Text) Mod 2 = 0 Then
                TAlarma(Index).Text = "0"
                TSacSinRep(Index).Text = "0"
            End If

            Dim Hora As String = Format(Now, "HH:mm")

            If Hora = "05:59" OrElse Hora = "13:59" OrElse Hora = "21:59" Then
                THabStartEmp(Index).Text = "0"
                TMsg(Index).Text = "CAMBIO DE TURNO"
                TNomProd(Index).Text = "CAMBIO DE TURNO DE STOP"
            End If

            If SacosAnt(Index) <> Val(TSac(Index).Text) Then
                SacosAnt(Index) = Val(TSac(Index).Text)
                EventoEmp(TMsg(Index).Text)
                EventoEmp("ENVIA DATOS FORMULARIO EMPAQUE OP:" + TOPs(Index).Text + " SACOS: " + TSac(Index).Text)
            End If

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLimpiar1.Click, BLimpiar2.Click
        Try
            If BLimpiar Is Nothing Then Return
            Dim Index As Int32 = BLimpiar.Index(CType(sender, Button))

            TOPs(Index).Text = ""
            TCodProd(Index).Text = ""
            TNomProd(Index).Text = ""
            TSacMeta(Index).Text = ""
            TSacTot(Index).Text = ""
            TSacSinRep(Index).Text = ""
            TMsg(Index).Text = ""
            THabStartEmp(Index).Text = "0"
            TOnOffTMto(Index).Text = "0"
            TAlarma(Index).Text = "0"

            Empaque.FLimpiar_Click(Empaque.FLimpiar(Index), Nothing)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub Conx_Connect() Handles Conx.Connect
        Evento("Conectado " + Conx.ConfigConnection)
    End Sub

    Private Sub Conx_Close() Handles Conx.ConnectClose
        Evento("Desconectado " + Conx.ConfigConnection)
    End Sub

    Private Sub TSac_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSac1.TextChanged, TSac2.TextChanged
        Try
            If TSac Is Nothing Then Return
            Dim Index As Integer = TSac.Index(CType(sender, TextBox))


            TSacSinRep(Index).Text = Eval(TSacSinRep(Index).Text) + 1
            If Eval(TSac(Index).Text) = 0 Then TSacSinRep(Index).Text = 0

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub
End Class