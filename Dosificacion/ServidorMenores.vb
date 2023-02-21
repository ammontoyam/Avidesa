Imports System.Data
Imports System.String
Imports System.IO
Imports System.Data.Common
Imports System.Windows.Forms
Imports System.Threading.Thread
Imports System.Text

Public Class ServPantWMicros
    Private EquipoNo As Int16
    Private Tipo As String
    Private ContFila As Integer
    Private DVarios As AdoNet
    Private DOPs As AdoNet
    Private DDatosFor As AdoNet
    Private DDatosForTemp As AdoNet
    Private DDatosForTempOGA As AdoNet
    Private DEquipos As AdoNet
    Private DConfigVar As AdoNet
    Private DConsumosPrem As AdoNet
    Private DBasculas As AdoNet
    Private DProcDosif As AdoNet
    Private DConsMed As AdoNet
    Private DBaches As AdoNet
    Private DBaches2 As AdoNet
    Private DCons As AdoNet
    Private DFor As AdoNet
    Private DMat As AdoNet
    Private DTolvas As AdoNet
    Private DTMuertos As AdoNet
    Private DConfig As AdoNet

    Private TararAnt As String
    Private TmpoMaxMezcla6 As Integer
    Private TmpoMaxAlist6 As Integer
    Private ContRep As Long
    Private MntosAlist As Int32


    Private EstadoProc As String = "Detenido"
    Private ConGSE As Connection
    Private RecibGSE As String
    Private RecibPant As String
    Private Pos1 As Integer
    Private Pos2 As Integer
    Private TaraB1 As Single
    Private BrutoB1 As Single
    Private NetoB1 As Single
    Private MetaSupB1 As Single
    Private MetaInfB1 As Single
    Private NumLectEstabB1 As Integer = 4
    Private BrutoAntB1(20) As Single
    Private CapacB1 As Single = 80
    Private RangoEstabB1 As Single = 0.005
    Private LimTaraB1 As Single = 0.01
    Private FueraDeTaraB1 As Boolean
    Private Contador As Double
    Private ConsecBache As Double
    Private Max As Single
    Private Min As Single
    Private ConPant As Connection
    Private Envio As String
    Private Encab As String
    Private Longitud As Int16
    Private Dato As Int32
    Private Palab As String
    Private TxBlink As Boolean
    Private OPNo(20) As Int16       'Luego se redimensiona
    Private OPsCount As Int16
    Private OPIndex As Int16
    Private BotonesPant As Integer
    Private DifAnt As String
    Private OPPantIni As String
    Private SigIng As Int32 = 0
    Private TotalForm As Single
    Private AcumForm As Single
    Private ConImp As Connection
    Private ImpEtiq As Boolean
    Private OPAnt As String
    Private EstadoPant As String
    Private FormLoad As Boolean
    Private Basc As Int16 = 3
    Private SiguienteBache As Int16 = 10
    Private IniciarPesaje As Int16
    Private EstadoBAnt As String

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Close()
        Me.Dispose()

    End Sub


    Public Sub ServidorMen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad = True Then Return
            FormLoad = True

            If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
                'essageBox.Show("La aplicación ya se esta ejecutando", "ChronoSoft Comms", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End
            End If

            Ruta = Application.StartupPath
            If Ruta.Last.ToString <> "\" Then Ruta = Ruta + "\"

            If InStr(Ruta, "Fuentes") > 0 Then
                Ruta = Ruta.Substring(0, InStr(Ruta, "Fuentes") - 1)
                Fuentes = True
            End If


            If File.Exists(Ruta + "Ruta.txt") = False Then
                MsgBox("No existe el archivo ruta el cual contiene el nombre del Motor de Base de Datos", MsgBoxStyle.Information)
                End
            Else
                Dim rd As StreamReader = New StreamReader(Ruta + "Ruta.txt", True)
                'TipoServer = "SQLSERVER"
                ServidorSQL = rd.ReadLine.Trim
            End If

            NomDB = "CHRSOLBUG"
            UserDB = "Admin"
            PWD = "NEP"

            NombrePC = My.Computer.Name
            'UsuarioDosificacion = "-"
            If File.Exists(Ruta + "b") = True Then
                'Evento(" Se cierra ChrComItalBar por archivo b " + Me.Name)
                End
            End If

            RutaRep = Ruta + "DB\"

            RutaDB = "Data Source=" + ServidorSQL + "; Initial Catalog=" + NomDB + "; User Id=" + UserDB + "; Password=" + PWD

            DVarios = New AdoNet("Varios", CONN, DbProvedor)
            DConfigVar = New AdoNet("CONFIGVAR", CONN, DbProvedor)
            DOPs = New AdoNet("OPs", CONN, DbProvedor)
            DDatosFor = New AdoNet("DatosFor", CONN, DbProvedor)
            DEquipos = New AdoNet("Equipos", CONN, DbProvedor)
            DProcDosif = New AdoNet("ProcDosif", CONN, DbProvedor)
            DConsMed = New AdoNet("CONSUMOSMED", CONN, DbProvedor)
            DBaches = New AdoNet("BACHES", CONN, DbProvedor)
            DCons = New AdoNet("CONSUMOS", CONN, DbProvedor)
            DFor = New AdoNet("FORMULAS", CONN, DbProvedor)
            DMat = New AdoNet("MATPESADOS", CONN, DbProvedor)
            DTMuertos = New AdoNet("TMUERTOS", CONN, DbProvedor)

            DBasculas.Open("Select * from BASCULAS where BASC=3")       'Menores
            If DBasculas.RecordCount Then
                'NumLectEstabB1 = DBasculas.RecordSet("LECTESTAB")
                'RangoEstabB1 = DBasculas.RecordSet("RANGOESTAB")
                LimTaraB1 = DBasculas.RecordSet("LIMTARA")
                CapacB1 = DBasculas.RecordSet("CAPAC")
            End If

            'Memoriza los tiempos max de mezcla y alistamiento por cada línea
            DVarios.Open("select * from LINEAS where LINEA=6")
            If DVarios.RecordCount Then
                TmpoMaxMezcla6 = DVarios.RecordSet("TPOMAXMEZCLA")
                TmpoMaxAlist6 = DVarios.RecordSet("TPOMAXALIST")

            End If

            DProcDosif.Open("select * from PROCDOSIF where BASCULA=" + Basc.ToString)
            If DProcDosif.RecordCount Then
                TOPs.Text = DProcDosif.RecordSet("OP")
                TEstadoChr.Text = DProcDosif.RecordSet("ESTADO")
                TContRep.Text = DProcDosif.RecordSet("CONT")
                TBache.Text = DProcDosif.RecordSet("BACHE")
                TPaso.Text = DProcDosif.RecordSet("PASO")
                TCodMat.Text = DProcDosif.RecordSet("CODMAT")
                TNomMat.Text = DProcDosif.RecordSet("NOMMAT")
                TLote.Text = DProcDosif.RecordSet("LOTE")
                TMetaT.Text = DProcDosif.RecordSet("METAT")
                TTolSup.Text = DProcDosif.RecordSet("TOLSUP")
                TTolInf.Text = DProcDosif.RecordSet("TOLINF")
                If Val(TCodMat.Text) <> 999 Then     'Cambio de recipiente
                    TMetaInf.Text = Eval(TMetaT.Text) - Eval(TTolInf.Text)
                    TMetaSup.Text = Eval(TMetaT.Text) + Eval(TTolSup.Text)
                Else
                    TMetaInf.Text = 0.1
                    TMetaSup.Text = 2
                End If
            End If

            DEquipos.Open("select * from EQUIPOS where EQUIPO=2")    'Pant Menores
            If DEquipos.RecordCount Then
                If DEquipos.RecordSet("TIPOCONEXION").ToString.ToUpper = "SERIAL" Then
                    '1,9600,8,0,1,0
                    ConPant = New Connection(Connection.TipoConnection.Serial, DEquipos.RecordSet("COM").ToString + ",9600,8,0,1,0")
                ElseIf DEquipos.RecordSet("TIPOCONEXION").ToString.ToUpper.Trim = "ETHERNET" Then
                    ConPant = New Connection(Connection.TipoConnection.Ethernet, DEquipos.RecordSet("IP").ToString, DEquipos.RecordSet("IPPORT").ToString)
                End If
                'ConPant = New Connection(Connection.TipoConnection.Ethernet, DEquipos.RecordSet("IP"), DEquipos.RecordSet("IPPORT").ToString)
                ConPant.Conect()
            End If
            TimRx.Enabled = True
        Catch ex As Exception
            TError.Text = Now.ToString + "  " + ex.ToString
        End Try
    End Sub


    Private Sub TimRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimRx.Tick
        Try
            TSeg.Text = Val(TSeg.Text) + 1
            If Val(TSeg.Text) > 10000 Then TSeg.Text = 1
            ShRx.Visible = False

            TSegRepPant.Text = Val(TSegRepPant.Text) + 1
            If Val(TSegRepPant.Text) > 10000 Then TSegRepPant.Text = 1

            If CInt(Val(TSeg.Text)) Mod 35 = 0 Then
                If Not ConPant Is Nothing AndAlso ConPant.State = ConnectionState.Closed Then
                    ConPant.Conect()
                End If
            End If

            TRxPant.Text = ""
            FRxPant_Click(0, Nothing)

            'Se lee lento ya que  no es necesario tan rápida y así libera carga a la cpu
            If Val(TSeg.Text) Mod 2 = 0 Then
                FPideDatosPant_Click(0, Nothing)
            End If

            If Val(TSeg.Text) Mod 10 = 0 Then
                FEscribPant_Click(0, Nothing) 'Se hace desde el servidor del GSE para que esriba el peso rápido en la pantalla
            End If

            If Val(TSeg.Text) Mod 2 = 0 Then
                FProceso_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub



    Private Sub FRxPant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRxPant.Click
        Try
            Dim CodBarras As String

            If TRxPant.Text.Length > 500 Then TRxPant.Text = ""

            RecibPant = ""
            If ConPant.State = Connection.StateConnection.Connected Then
                ConPant.GetData(RecibPant)
                TEstadoWPant.Text = "7"
                TEstadoWPant.BackColor = Color.GreenYellow
            Else
                TEstadoWPant.BackColor = Color.White
                TEstadoWPant.Text = "6"
                If (Val(TSeg.Text) Mod 10 = 0) Then ConPant.Conect()
            End If
            If RecibPant = "" Then
                Return
            End If

            TSegRepPant.Text = 1
            For K = 1 To Len(RecibPant)
                TRxPant.Text = TRxPant.Text + Asc(Mid(RecibPant, K, 1)).ToString("000 ")
            Next
            'WriteFile(Ruta + "Aplanos\" + Now.ToString("yyMMdd") + "_PantMic" + ".txt", RecibPant)

            Pos1 = InStr(1, TRxPant.Text, "253 253 000 000")  'Detecta el inicio de la trama de llegada de 8 registros 
            If Pos1 > 0 Then
                ShRx.Visible = True
                TRxPant.Text = Mid(TRxPant.Text, Pos1)
                Pos1 = InStr(2, TRxPant.Text, "253 253 000 000")    'Detecta si hay mas datos acumulados
                Do While Pos1 > 0
                    TRxPant.Text = Mid(TRxPant.Text, Pos1)
                    Pos1 = InStr(2, TRxPant.Text, "253 253 000 000")    'Detecta si hay mas tramas acumuladas
                Loop


                Pos1 = InStr(1, TRxPant.Text, "254 254 000 000")     'Detecta la respuesta por escritura de datos

                TOPPant.Text = Eval(Mid(TRxPant.Text, 37, 3)) * 256 + Eval(Mid(TRxPant.Text, 41, 3)) + Eval(Mid(TRxPant.Text, 45, 3)) * 2 ^ 24 + Eval(Mid(TRxPant.Text, 49, 3)) * 2 ^ 16
                TOPSol.Text = Eval(Mid(TRxPant.Text, 53, 3)) * 256 + Eval(Mid(TRxPant.Text, 57, 3)) + Eval(Mid(TRxPant.Text, 61, 3)) * 2 ^ 24 + Eval(Mid(TRxPant.Text, 65, 3)) * 2 ^ 16

                IniciarPesaje = Eval(Mid(TRxPant.Text, 69, 3)) * 256 + Eval(Mid(TRxPant.Text, 73, 3))

                EstadoPant = ""
                For K = 77 To 149 Step 8
                    If Val(Mid(TRxPant.Text, K + 4, 3)) >= 20 And Val(Mid(TRxPant.Text, K + 4, 3)) <= 126 Then
                        EstadoPant = EstadoPant + Chr(Val((Mid(TRxPant.Text, K + 4, 3))))
                    End If
                    If Val(Mid(TRxPant.Text, K, 3)) >= 20 And Val(Mid(TRxPant.Text, K, 3)) <= 126 Then
                        EstadoPant = EstadoPant + Chr(Val((Mid(TRxPant.Text, K, 3))))
                    End If
                Next
                TEstadoProcPant.Text = (Mid(EstadoPant, 3, 15)).Trim     'A veces llegan los dos primeros caracteres con chr 0 y no deja que funcione esto

                TSegPant.Text = Val(Mid(TRxPant.Text, 157, 3)) * 256 + Val(Mid(TRxPant.Text, 161, 3))
                TBotonesPant.Text = Val(Mid(TRxPant.Text, 165, 3)) * 256 + Val(Mid(TRxPant.Text, 169, 3))
                TEstableB1.Text = Val(Mid(TRxPant.Text, 173, 3)) * 256 + Val(Mid(TRxPant.Text, 177, 3))
                TNetoB1.Text = Val(Mid(TRxPant.Text, 181, 3)) * 256 + Val(Mid(TRxPant.Text, 185, 3)) + Eval(Mid(TRxPant.Text, 189, 3)) * 2 ^ 24 + Eval(Mid(TRxPant.Text, 193, 3)) * 2 ^ 16
                If Val(TNetoB1.Text) > 32000 Then TNetoB1.Text = Val(TNetoB1.Text) - 65536
                TNetoB1.Text = Val(TNetoB1.Text) / 10

                TNumEstadoPant.Text = Val(Mid(TRxPant.Text, 197, 3)) * 256 + Val(Mid(TRxPant.Text, 201, 3)) '+ Eval(Mid(TRxPant.Text, 205, 3)) * 2 ^ 24 + Eval(Mid(TRxPant.Text, 209, 3)) * 2 ^ 16
                TIOsGSE.Text = Val(Mid(TRxPant.Text, 205, 3)) * 256 + Val(Mid(TRxPant.Text, 209, 3)) '+ Eval(Mid(TRxPant.Text, 205, 3)) * 2 ^ 24 + Eval(Mid(TRxPant.Text, 209, 3)) * 2 ^ 16

                CodBarras = ""
                For K = 221 To 337 Step 8
                    CodBarras = CodBarras + Chr(Val((Mid(TRxPant.Text, K + 4, 3))))
                    CodBarras = CodBarras + Chr(Val((Mid(TRxPant.Text, K, 3))))
                Next
                TCodBarras.Text = CodBarras.Trim

                'If Val(TOPPant.Text) > 0 Then
                '    FBuscaOP_Click(Nothing, Nothing)
                'End If

                If IniciarPesaje = 16 And (TEstadoProcPant.Text.Trim() = "LIBRE") Then
                    FPrepBache_Click(Nothing, Nothing)
                    FGenArchOGA_Click(0, Nothing)
                End If


                If Val(TBotonesPant.Text) > 0 Then
                    If (Val(TBotonesPant.Text) And 16) = 16 Then
                        If Val(TNumEstadoChr.Text) <> 1 Then
                            BCancelar_Click(Nothing, Nothing)
                            TNumEstadoChr.Text = 1
                        End If
                    ElseIf (Val(TBotonesPant.Text) And 8) = 8 Then
                        If Val(TNumEstadoChr.Text) <> 20 Then
                            FVerDatosFor_Click(Nothing, Nothing)
                        End If

                    End If
                    ' Se asigna este valor para que la pantalla reinicie el registro de los botones
                    '    If Val(TBotonesPant.Text) = 20 Then TNumEstadoChr.Text = 15 ' Respuesta de Inicio de Pesaje en Pant

                End If

            End If



        Catch ex As Exception
            TError.Text = Now.ToString + "  " + ex.ToString
        End Try

    End Sub

    Public Sub FEscribPant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FEscribPant.Click
        Try
            'Primero se organizan los datos y al final se pone el encabezado al principio de la trama
            Dato = Val(TOPs.Text)
            Envio = ""
            Dim Valor1, Valor2, Valor3, Valor4 As Int64
            Dim Byte3, Byte2, Byte1, Byte0 As Int32

            Valor1 = Dato

            Byte3 = Valor1 \ 2 ^ 24
            Valor2 = Valor1 - (Byte3 * 2 ^ 24)
            Byte2 = Valor2 \ 2 ^ 16
            Valor3 = Valor2 - (Byte2 * 2 ^ 16)
            Byte1 = Valor3 \ 2 ^ 8
            Valor4 = Valor3 - (Byte1 * 2 ^ 8)
            Byte0 = Valor4

            Envio = Envio + Chr(Byte1) + Chr(Byte0) + Chr(Byte3) + Chr(Byte2)  ' Enviamos OP reg 100

            Dato = Val(TCodFor.Text)

            Valor1 = Dato

            Byte3 = Valor1 \ 2 ^ 24
            Valor2 = Valor1 - (Byte3 * 2 ^ 24)
            Byte2 = Valor2 \ 2 ^ 16
            Valor3 = Valor2 - (Byte2 * 2 ^ 16)
            Byte1 = Valor3 \ 2 ^ 8
            Valor4 = Valor3 - (Byte1 * 2 ^ 8)
            Byte0 = Valor4

            Envio = Envio + Chr(Byte1) + Chr(Byte0) + Chr(Byte3) + Chr(Byte2)  ' Enviamos CodFor

            Palab = TNomFor.Text + Space(30)
            For K = 1 To 29 Step 2                                                      'NomFor
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K
            Dato = Val(TBaches.Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'Baches


            If TEstadoChr.Text.Trim = "DOSIFICANDO" AndAlso Val(TNetoB1.Text) > 0 AndAlso Val(TMetaT.Text) > 0 Then
                TPorcDif.Text = Eval(TNumEstadoPant.Text) / Eval(TMetaT.Text) * 10
            Else
                TPorcDif.Text = 0
            End If

            'Libre
            Dato = 0

            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'PorcDif
            Dato = Eval(TPorc.Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'Porc


            'Se adiciona el Acum de la formula
            Dato = TotalForm * 10   'Un decimales
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'TotalForm

            Dato = Val(TBache.Text)
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'Bache


            Dato = 0
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'Libre


            Palab = TCodMat.Text + " " + TNomMat.Text + Space(34)
            For K = 1 To 33 Step 2                                                      'CodMat y NomMat
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K


            Dato = Eval(TMetaT.Text) * 10
            Valor1 = Dato
            Byte3 = Valor1 \ 2 ^ 24
            Valor2 = Valor1 - (Byte3 * 2 ^ 24)
            Byte2 = Valor2 \ 2 ^ 16
            Valor3 = Valor2 - (Byte2 * 2 ^ 16)
            Byte1 = Valor3 \ 2 ^ 8
            Valor4 = Valor3 - (Byte1 * 2 ^ 8)
            Byte0 = Valor4
            Envio = Envio + Chr(Byte1) + Chr(Byte0) + Chr(Byte3) + Chr(Byte2)  ' Enviamos Peso Meta

            Dato = Math.Abs(Eval(TMetaInf.Text) * 10)
            Valor1 = Dato
            Byte3 = Valor1 \ 2 ^ 24
            Valor2 = Valor1 - (Byte3 * 2 ^ 24)
            Byte2 = Valor2 \ 2 ^ 16
            Valor3 = Valor2 - (Byte2 * 2 ^ 16)
            Byte1 = Valor3 \ 2 ^ 8
            Valor4 = Valor3 - (Byte1 * 2 ^ 8)
            Byte0 = Valor4
            Envio = Envio + Chr(Byte1) + Chr(Byte0) + Chr(Byte3) + Chr(Byte2)  ' Enviamos Peso Meta Inferior

            Dato = Math.Abs(Eval(TMetaSup.Text) * 10)
            Valor1 = Dato
            Byte3 = Valor1 \ 2 ^ 24
            Valor2 = Valor1 - (Byte3 * 2 ^ 24)
            Byte2 = Valor2 \ 2 ^ 16
            Valor3 = Valor2 - (Byte2 * 2 ^ 16)
            Byte1 = Valor3 \ 2 ^ 8
            Valor4 = Valor3 - (Byte1 * 2 ^ 8)
            Byte0 = Valor4
            Envio = Envio + Chr(Byte1) + Chr(Byte0) + Chr(Byte3) + Chr(Byte2)  ' Enviamos Peso Meta Superior


            Palab = TLote.Text + Space(30)
            For K = 1 To 15 Step 2                                                      'Lote
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K


            'Palab = Space(24)
            'For K = 1 To 15 Step 2                                                      '9 libres
            '    Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            'Next K

            Palab = TEstadoChr.Text + Space(20)
            For K = 1 To 19 Step 2                                                      'EstadoChr
                Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
            Next K

            Dato = 0
            Envio = Envio + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)    'Libre

            If TxBlink Then
                Envio = Envio + Chr(0) + Chr(1)   'TxBlink para mmostrar en pantalla
                TxBlink = False
            Else
                Envio = Envio + Chr(0) + Chr(0)
                TxBlink = True
            End If
            Envio = Envio + Chr(0) + Chr(Val(TNumEstadoChr.Text))           '



            'Encabezado Modbus IP
            Encab = Chr(254) + Chr(254)      'ID de transaccion. Puede ser cualquiera. Se escogio esta para el mensaje de escritura 
            Encab = Encab + Chr(0) + Chr(0) 'Protocolo Hi y Lo
            Longitud = Len(Envio)     'Longitud en bytes de los datos. 138 a Abril 23 de 2014
            Encab = Encab + Chr(0) + Chr(Longitud + 7) 'Longitud Hi y Lo.Cuando se escriben varios reg. esta long. se le suma 7. Se supone que nunca sera mayor a 248 + 7 (255)

            'Encabezado ModBus normal
            Encab = Encab + Chr(1)               'Direccion del equipo
            Encab = Encab + Chr(16)               'Comando 16, para escribir varios registros
            Encab = Encab + Chr(0) + Chr(100)     'Direccion Hi y Lo donde se va a escribir. En la pantalla es LW100
            Encab = Encab + Chr(0) + Chr(Longitud / 2)     'Cantidad HI y Lo de registros a escribir en Words
            Encab = Encab + Chr(Longitud)     'Cantidad de bytes que van de datos. Es un solo byte

            'Se unen el encabezado y los datos
            Envio = Encab + Envio


            If ConPant.State = Connection.StateConnection.Connected Then ConPant.SendData(Envio)
            TTxPant.Text = ""
            For K = 1 To Len(Envio)
                TTxPant.Text = TTxPant.Text + Asc(Mid(Envio, K, 1)).ToString("000 ")
            Next
        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try


    End Sub

    Private Sub FPideDatosPant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FPideDatosPant.Click
        Try


            'Encabezado Modbus IP
            Encab = Chr(253) + Chr(253)      'ID de transaccion. Pueden ser cualquiera. Se escogio este para pedido de datos a la pantalla
            Encab = Encab + Chr(0) + Chr(0) 'Protocolo Hi y Lo
            Encab = Encab + Chr(0) + Chr(6) 'Longitud Hi y Lo. 6 cuando es pedido de datos 

            'Encabezado ModBus normal
            Encab = Encab + Chr(1)               'Direccion del equipo
            Encab = Encab + Chr(3)               'Comando 3, para pedir  registros
            Encab = Encab + Chr(0) + Chr(170)     'Direccion Hi y Lo de donde se va a leer. En la pantalla empieza en LW168
            Encab = Encab + Chr(0) + Chr(38)     'Cantidad HI y Lo de registros a Leer en Words

            'Se envia a la pantalla
            Envio = Encab

            If ConPant.State = Connection.StateConnection.Connected Then ConPant.SendData(Envio)
            TTxPant.Text = ""
            For K = 1 To Len(Envio)
                TTxPant.Text = TTxPant.Text + Asc(Mid(Envio, K, 1)).ToString("000 ")
            Next

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try

    End Sub
    Private Sub ArchivarProc()
        Try

            Dim Wrt As StreamWriter = New StreamWriter(Ruta + "Aplanos\" + Now.ToString("yyMMdd") + "_ProcMicros" + ".txt", True)
            Wrt.Write(TimeOfDay.ToString("HH:mm:ss") + vbTab)
            Wrt.Write(CLeft(EstadoProc, 8) + vbTab)
            Wrt.Write(CLeft(TEstadoChr.Text, 8) + vbTab)
            Wrt.Write("OP:" + TOPs.Text + vbTab)
            Wrt.Write("Frm:" + TCodFor.Text + vbTab)
            Wrt.Write("Bch:" + TBache.Text + vbTab)
            Wrt.Write("Mat:" + TCodMat.Text + vbTab)
            Wrt.Write("Meta:" + TMetaInf.Text + "-" + TMetaSup.Text + vbTab)
            Wrt.Write("Net:" + TNetoB1.Text + vbTab)
            Wrt.Write("Brt:" + TBrutoB1.Text + vbTab)
            Wrt.WriteLine()
            Wrt.Close()
            Wrt.Dispose()
        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try

    End Sub



    Private Sub Micros_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Me.Hide()

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub


    Public Sub FActDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FActDatos.Click
        Try

            DProcDosif.Open("select * from PROCDOSIF where BASCULA=" + Basc.ToString)
            If DProcDosif.RecordCount Then
                TOPs.Text = DProcDosif.RecordSet("OP")
                TNomFor.Text = DProcDosif.RecordSet("NOMFOR")
                TEstadoChr.Text = DProcDosif.RecordSet("ESTADO")
                TContRep.Text = DProcDosif.RecordSet("CONT")
                TBache.Text = DProcDosif.RecordSet("BACHE")
                TPaso.Text = DProcDosif.RecordSet("PASO")
                TCodMat.Text = DProcDosif.RecordSet("CODMAT")
                TNomMat.Text = DProcDosif.RecordSet("NOMMAT")
                TLote.Text = DProcDosif.RecordSet("LOTE")
                TMetaT.Text = DProcDosif.RecordSet("METAT")
                If DProcDosif.RecordSet("CODMAT") <> "999" Then
                    TTolSup.Text = DProcDosif.RecordSet("TOLSUP")
                    TTolInf.Text = DProcDosif.RecordSet("TOLINF")
                    TMetaInf.Text = Eval(TMetaT.Text) - Eval(TTolInf.Text)
                    TMetaSup.Text = Eval(TMetaT.Text) + Eval(TTolSup.Text)
                Else
                    TMetaInf.Text = 0
                    TMetaSup.Text = 1
                End If

            End If


            If TEstadoChr.Text.Trim = "DOSIFICANDO" Then
                TNumEstadoChr.Text = 10 'Orden para Tarar
                Sleep(200)
            End If
            FEscribPant_Click(Nothing, Nothing)
            Sleep(200)

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub

    Private Sub FVerDatosFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FVerDatosFor.Click
        Try
            Dim Registro As Integer
            DDatosForTemp.Open("select * from DATOSFORTEMP where  NombrePC='" + NombrePC + "' and OP=0" + TOPs.Text + " and BASC=3 order by PASO")

            If DDatosForTemp.RecordCount = 0 Then Return

            For Index = 1 To 15
                Envio = ""
                Registro = Index
                'Si estamos en los renglones vacíos ponemos el utlimo registro de datosfortemp pero no lo usamos
                If Index > DDatosForTemp.RecordCount Then Registro = DDatosForTemp.RecordCount

                Dim RecordSet As DataRow = DDatosForTemp.Rows(Registro - 1)

                Palab = RecordSet("CodMat").ToString.Trim + Space(10)
                If Index > DDatosForTemp.RecordCount Then Palab = Space(10) 'rengon vacio
                For K = 1 To 9 Step 2
                    Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
                Next K

                Palab = RecordSet("NomMat").ToString.Trim + Space(30)
                If Index > DDatosForTemp.RecordCount Then Palab = Space(30) 'rengon vacio
                For K = 1 To 29 Step 2
                    Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
                Next K

                Palab = Format(RecordSet("VALOR"), "0.000").ToString.Trim + Space(8)
                If Index > DDatosForTemp.RecordCount Then Palab = Space(20) 'rengon vacio
                For K = 1 To 7 Step 2
                    Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
                Next K

                ' Dato de la bascula de dosificacion
                Dato = 1
                Palab = Dato.ToString + Space(2)
                If Index > DDatosForTemp.RecordCount Then Palab = Space(4) 'rengon vacio
                For K = 1 To 1 Step 2
                    Envio = Envio + Mid(Palab, K + 1, 1) + Mid(Palab, K, 1)
                Next K

                'Encabezado Modbus IP
                Encab = Chr(254) + Chr(254)      'ID de transaccion. Puede ser cualquiera. Se escogio este para escritura.
                Encab = Encab + Chr(0) + Chr(0) 'Protocolo Hi y Lo
                Longitud = Len(Envio)     'Longitud en bytes de los datos.
                Encab = Encab + Chr(0) + Chr(Longitud + 7) 'Longitud Hi y Lo.Cuando se escriben varios reg. esta long. se le suma 7. Se supone que nunca sera mayor a 248 + 7 (255)

                'Encabezado ModBus normal
                Encab = Encab + Chr(1)               'Direccion del equipo
                Encab = Encab + Chr(16)               'Comando 16, para escribir varios registros
                Dato = 30 * (Index - 1) + 300               'Direccion donde se va a escribir.
                Encab = Encab + Chr(Int(Dato / 256)) + Chr(Dato - Int(Dato / 256) * 256)   'Direccion Hi y Lo donde se va a escribir.
                Encab = Encab + Chr(0) + Chr(Longitud / 2)     'Cantidad HI y Lo de registros a escribir en Words
                Encab = Encab + Chr(Longitud)     'Cantidad de bytes que van de datos. Es un solo byte

                'Se unen el encabezado y los datos
                Envio = Encab + Envio

                If ConPant.State = Connection.StateConnection.Connected Then
                    ConPant.SendData(Envio)
                    TTxPant.Text = ""
                    For K = 1 To Len(Envio)
                        TTxPant.Text = TTxPant.Text + Format(Asc(Mid(Envio, K, 1)), "000 ")
                    Next
                End If


            Next
        Catch ex As Exception
            TError.Text = Now.ToString + "  " + ex.ToString
        End Try

    End Sub

    Private Sub FBuscaOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FBuscaOP.Click
        Try

            If TNumEstadoPant.Text = "" Then Return

            DOPs.Open("select * from OPS where OP=" + (Val(TOPSol.Text) + 1000000000).ToString + " and FINALIZADO<>'S'")

            If DOPs.RecordCount = 0 Then
                BCancelar_Click(Nothing, Nothing)
                TNomFor.Text = "OP NO EXISTE "
                TEstadoChr.Text = "OP NO EXISTE " + TOPSol.Text
                FArchivaProc_Click(0, Nothing)
                Return
            End If

            'DDatosForTemp.Open("select * from DATOSFORTEMP where OP=0" + DOPs.RecordSet("OP").ToString + " and NOMBREPC='" + nombrepc + "' and BASC=3  ORDER BY PASO")

            'If DDatosForTemp.RecordCount = 0 Then
            '    '   MsgBox("La fórmula no tiene ingredientes", vbInformation)
            '    TNomFor.Text = "FORMULA SIN INGREDIENTES"
            '    Exit Sub
            'End If

            DConfig.Open("select * from CONFIG")
            DConfig.RecordSet("ULTIMAOP") = DOPs.RecordSet("OP")
            DConfig.Update()

            Sleep(2000)



            DDatosForTemp.Open("select * from DATOSFORTEMP where OP=0" + DOPs.RecordSet("OP").ToString + " and NOMBREPC='" + NombrePC + "' and BASC=4  and TOLVA=0")

            If DDatosForTemp.RecordCount > 0 Then
                TNomFor.Text = "MATERIAL " + DDatosForTemp.RecordSet("CODMAT").ToString + " SIN TOLVA ASIGNADA"
                Exit Sub
            End If




            TOPs.Text = DOPs.RecordSet("OP")
            TCodFor.Text = DOPs.RecordSet("CODFOR")
            TNomFor.Text = DOPs.RecordSet("NOMFOR")
            'TLP.Text = DOPs.RecordSet("LP")
            TPorc.Text = DOPs.RecordSet("PORC")
            'TBachesTanda.Text = DOPs.RecordSet("BACHESMETA")

            TBaches.Text = DOPs.RecordSet("BACHESMETA")
            TNumEstadoChr.Text = 5   'Estado pidiendo OP
            FEscribPant_Click(0, Nothing)

            TEstadoChr.Text = "OP OK " + TOPSol.Text
            FArchivaProc_Click(0, Nothing)

            Sleep(2000)

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try

            DProcDosif.Open("Select * from PROCDOSIF where BASCULA=" + Basc.ToString)
            TEstadoChr.Text = "CANCELANDO"
            FArchivaProc_Click(0, Nothing)

            DProcDosif.RecordSet("OP") = 0
            DProcDosif.RecordSet("BACHE") = 0
            DProcDosif.RecordSet("CODFOR") = 0
            DProcDosif.RecordSet("NOMFOR") = "-"
            DProcDosif.RecordSet("LP") = "-"
            DProcDosif.RecordSet("OUTPUT") = 0     ' Por seguridad mientras se encuentra la verdadera salida
            DProcDosif.RecordSet("NOMTOLVA") = "-"     '
            DProcDosif.RecordSet("PASO") = 0
            DProcDosif.RecordSet("CODMAT") = 0
            DProcDosif.RecordSet("NOMMAT") = "-"
            DProcDosif.RecordSet("LOTE") = "-"
            DProcDosif.RecordSet("METAT") = 0
            DProcDosif.RecordSet("TOLSUP") = 0
            DProcDosif.RecordSet("TOLINF") = 0
            DProcDosif.RecordSet("ESTADO") = "LIBRE"
            DProcDosif.Update()

            FActDatos_Click(Nothing, Nothing)
            FArchivaProc_Click(0, Nothing)

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub

    Private Sub FSigMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSigMat.Click
        Try

            TEstadoChr.Text = "PIDE SIG.M."
            FArchivaProc_Click(0, Nothing)

            DOPs.Open("select * from OPS where OP='" + TOPs.Text + "'")
            If DOPs.RecordCount Then
                DProcDosif.Open("Select * from PROCDOSIF where BASCULA=" + Basc.ToString)
                For Each RegPD As DataRow In DProcDosif.Rows
                    RegPD("OP") = DOPs.RecordSet("OP")
                    RegPD("CODFOR") = DOPs.RecordSet("CODFOR")
                    RegPD("NOMFOR") = Mid(DOPs.RecordSet("NOMFOR"), 1, 30)
                    'RegPD("LP") = DOPs.RecordSet("LP")
                    RegPD("OUTPUT") = 0     ' Por seguridad mientras se encuentra la verdadera salida
                    RegPD("TOLSUP") = 0
                    RegPD("TOLINF") = 0
                    If Val(RegPD("PASO")) = 0 Then RegPD("BACHE") = DOPs.RecordSet("BACHESREAL") + 1

                    'Pendiente definir si se asigna bascula 20 a los micros o si solo con el tipomat se trabaja
                    'DDatosFor.Open("select TOP 1 * from DATOSFOR where CODFOR='" + RegPD("CODFOR") + "' and LP='" + RegPD("LP") + "' and BASCULA=" + Basc.ToString + " and PASO>" + RegPD("PASO").ToString + " and TIPOMAT=7 order by PASO")

                    DDatosForTemp.Open("select TOP 1 * from DATOSFORTEMP where OP=0" + TOPs.Text + " and NombrePC='" + NombrePC + "' and PASO>" + RegPD("PASO").ToString + " and BASC=3 order by PASO")

                    If DDatosForTemp.RecordCount Then
                        RegPD("PASO") = DDatosForTemp.RecordSet("PASO")
                        RegPD("CODMAT") = DDatosForTemp.RecordSet("CODMAT")
                        RegPD("NOMMAT") = DDatosForTemp.RecordSet("NOMMAT")
                        RegPD("LOTE") = Mid(DDatosForTemp.RecordSet("LOTE"), 1, 15)
                        RegPD("METAT") = DDatosForTemp.RecordSet("VALOR") * Eval(TPorc.Text) / 100 '* Val(TBachesTanda.Text) 'ddatosfortemp.RecordSet("PESOMETA") 
                        RegPD("TOLSUP") = DDatosForTemp.RecordSet("TOLSUP")
                        RegPD("TOLINF") = DDatosForTemp.RecordSet("TOLINF")
                        RegPD("ESTADO") = "DOSIFICANDO"
                        TNumEstadoChr.Text = 10         'Orden para tarar
                        TEstadoChr.Text = "SIG.M.OK"
                    Else
                        RegPD("PASO") = 0
                        RegPD("CODMAT") = 0
                        RegPD("NOMMAT") = "-"
                        RegPD("METAT") = 0
                        RegPD("LOTE") = 0
                        RegPD("TOLSUP") = 0
                        RegPD("TOLINF") = 0
                        RegPD("ESTADO") = "FIN BACHE"
                        TNumEstadoChr.Text = 70  'Fin Bache
                        TEstadoChr.Text = "FIN BACHE"
                        DDatosForTemp.Open("delete from DATOSFORTEMP where OP=0" + RegPD("OP").ToString + " and BASC<>4")
                    End If
                Next

                DProcDosif.Update()
            End If
            FArchivaProc_Click(0, Nothing)

            FActDatos_Click(Nothing, Nothing)

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub

    Private Sub FPrepBache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FPrepBache.Click
        Try
            Contador = Val(ReadConfigVar("ConsecBaches")) + 1

            DProcDosif.Open("Select * from PROCDOSIF where BASCULA=" + Basc.ToString)
            DProcDosif.RecordSet("CONT") = Contador
            DProcDosif.RecordSet("OP") = TOPs.Text
            DProcDosif.Update()
            TEstadoChr.Text = "PREP.BACHE"
            FArchivaProc_Click(0, Nothing)


            FSigMat_Click(Nothing, Nothing)
        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub


    Private Sub FCaptRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FCaptRep.Click
        Try
            Dim CodFor As Long
            'Dim MntosAlist As Single
            'Dim ContConsMed As Int32

            ContRep = Val(TContRep.Text)
            CodFor = Val(TCodFor.Text)

            If Val(TCodMat.Text) = 999 Then Return 'Cambio de recipiente

            DOPs.Open("select * from OPS where OP='" + TOPs.Text + "'")
            If DOPs.RecordCount = 0 Then Exit Sub
            If Val(DOPs.RecordSet("FECHAINI")) = 0 Then DOPs.RecordSet("FECHAINI") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DOPs.Update()

            DProcDosif.Open("Select * from PROCDOSIF where BASCULA=" + Basc.ToString)
            If DProcDosif.RecordCount = 0 Then Exit Sub

            ''       ---------------------------- SI ES BACHE NUEVO ---------------------------------------------------

            'DBaches.Open("select * from BACHES where CONT=0" + ContRep.ToString)
            'If DBaches.RecordCount = 0 Then
            '    FTMuertos_Click(0, Nothing)
            '    DBaches.AddNew()
            '    DBaches.RecordSet("CONT") = Val(TContRep.Text)
            '    DBaches.RecordSet("LINEA") = 6
            '    DBaches.RecordSet("FECHA") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            '    DBaches.RecordSet("FECHAFIN") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            '    DBaches.RecordSet("CODFOR") = CodFor
            '    DBaches.RecordSet("PESOMETA") = Eval(TMetaT.Text)
            '    DBaches.RecordSet("MNTOSALIST") = MntosAlist
            '    DBaches.RecordSet("FACTOR") = Val(TPorc.Text)
            '    DBaches.RecordSet("NOMFOR") = Mid(TNomFor.Text, 1, 40)
            '    DFor.Open("select * from FORMULAS where OP=0" + TOPs.Text + " and CODFOR='" + CodFor.ToString + "'")

            '    If DFor.RecordCount Then
            '        DBaches.RecordSet("CODFORB") = DFor.RecordSet("CODFORB")
            '        DBaches.RecordSet("FASE") = DFor.RecordSet("FASE")
            '    Else
            '        DBaches.RecordSet("CODFORB") = DBaches.RecordSet("CODFOR")
            '    End If

            '    DBaches.RecordSet("USUARIO") = Mid(Usuario, 1, 10)
            '    DBaches.RecordSet("OP") = Val(TOPs.Text)
            '    DBaches.RecordSet("BACHE") = Val(TBache.Text)
            '    DBaches.RecordSet("BACHESMETA") = Val(TBaches.Text)
            '    DBaches.RecordSet("PESOMETA") = DOPs.RecordSet("META")
            '    WriteConfigVar("ConsecBaches", ContRep.ToString)
            '    DBaches.Update()

            '    'Trae los datos de consumosmed -------------------
            '    DConsMed.Open("select * from CONSUMOSMED where OP=" + TOPs.Text + " order by CONT")
            '    If DConsMed.RecordCount Then
            '        ContConsMed = DConsMed.RecordSet("CONT")
            '        DConsMed.Open("select * from CONSUMOSMED where OP=" + TOPs.Text + " and CONT=0" + ContConsMed.ToString)
            '        For Each RegConsMed As DataRow In DConsMed.Rows
            '            DDatosFor.Open("select * from DATOSFOR where OP=0" + TOPs.Text + " and CODMAT='" + RegConsMed("CODMAT") + "'")
            '            DCons.Open("select * from CONSUMOS where CONT=0" + ContRep.ToString + " AND CODMAT='" + RegConsMed("CODMAT") + "' and PESOMETA=0" + RegConsMed("PESOMETA").ToString)
            '            If DCons.RecordCount = 0 Then

            '                If DCons.RecordCount = 0 Then
            '                    DCons.AddNew()
            '                    DCons.RecordSet("CONT") = ContRep
            '                    DCons.RecordSet("ALARMAS") = 1
            '                    DCons.RecordSet("OP") = DBaches.RecordSet("OP")
            '                    DCons.RecordSet("CODFOR") = CodFor
            '                    DCons.RecordSet("CODFORB") = DBaches.RecordSet("CODFORB")
            '                    DCons.RecordSet("CODMAT") = RegConsMed("CODMAT")
            '                    DCons.RecordSet("PESOREAL") = RegConsMed("PESOREAL")
            '                    DCons.RecordSet("PESOMETA") = RegConsMed("PESOMETA")
            '                    DCons.RecordSet("CODMATB") = RegConsMed("CODMATB")
            '                    DCons.RecordSet("PBRUTO") = 0
            '                    DCons.RecordSet("BASC") = RegConsMed("BASCULA")
            '                    DCons.RecordSet("CODBAR") = "-"         'Left(CodBar, 20)
            '                    DCons.RecordSet("LOTEGSE") = "-"
            '                    DCons.RecordSet("TOLVA") = 88       'Por micros
            '                    DCons.RecordSet("LOTE") = RegConsMed("LOTE")
            '                    If DDatosFor.RecordCount Then
            '                        DCons.RecordSet("ALMACEN") = DDatosFor.RecordSet("ALMACEN")
            '                    End If

            '                    DMat.Open("select * from MATPESADOS where CODMAT='" + RegConsMed("CODMAT") + "'")
            '                    If DMat.RecordCount Then
            '                        DCons.RecordSet("NOMMAT") = Mid(DMat.RecordSet("NOMMAT"), 1, 40)
            '                    End If
            '                    DCons.Update()
            '                End If      'DCons.AddNew
            '            End If      'Dcons.Recordset=0
            '        Next        'For Each DconsMed
            '        DConsMed.Open("delete from CONSUMOSMED where OP=" + TOPs.Text + " and CONT=0" + ContConsMed.ToString)
            '    End If      'DCons.recordcount
            'End If      'Baches AddNew

            ' ----------------------------------------  Procesa el Material---------------------------------------------------

            DBaches.Open("select * from BACHES where CONT=0" + ContRep.ToString)
            DDatosFor.Open("select * from DATOSFOR where OP=0" + TOPs.Text + " and CODMAT='" + TCodMat.Text + "'")
            'DDatosForTemp.Open("select * from DATOSFORTEMP where OP=0" + TOPs.Text + " and PASO=0" + TPaso.Text)
            DCons.Open("select * from CONSUMOS where CONT=0" + ContRep.ToString + " AND CODMAT='" + TCodMat.Text + "' and PESOMETA=0" + TMetaT.Text)

            If DDatosFor.RecordCount = 0 Then
                Evento("Pantalla " + " Reportó ingrediente " + TCodMat.Text + "  que no aparece en la fórmula " + CodFor.ToString)
            End If

            If DCons.RecordCount = 0 Then
                DCons.AddNew()
                DCons.RecordSet("CONT") = ContRep
                DCons.RecordSet("ALARMAS") = 1
                DCons.RecordSet("OP") = DBaches.RecordSet("OP")
                DCons.RecordSet("CODFOR") = CodFor
                DCons.RecordSet("CODFORB") = DBaches.RecordSet("CODFORB")
                DCons.RecordSet("CODMAT") = TCodMat.Text.Trim
                DCons.RecordSet("PESOREAL") = Eval(TNetoB1.Text)
                DCons.RecordSet("PESOMETA") = Eval(TMetaT.Text)
                DCons.RecordSet("CODMATB") = TCodMat.Text.Trim
                DCons.RecordSet("PBRUTO") = 0
                DCons.RecordSet("BASC") = 3
                DCons.RecordSet("CODBAR") = "-"         'Left(CodBar, 20)
                'DCons.RecordSet("LOTEGSE") = "-"
                If TLoteBarr1.Text.Trim = "" Then
                    DCons.RecordSet("LOTEGSE") = "Bypass"
                Else
                    DCons.RecordSet("LOTEGSE") = TLoteBarr1.Text.Trim
                    TLoteBarr1.Text = ""
                    TCodMatBarr1.Text = ""
                End If
                DCons.RecordSet("TOLVA") = 150      'Por Menores
                DCons.RecordSet("LOTE") = Mid(TLote.Text.Trim, 1, 15)                   'DDatosFor(Index).Recordset("LOTE")                           'Left(Lote, 15)
                If DDatosFor.RecordCount Then
                    DCons.RecordSet("ALMACEN") = DDatosFor.RecordSet("ALMACEN")
                End If


                DMat.Open("select * from MATPESADOS where CODMAT='" + TCodMat.Text.Trim + "'")
                If DMat.RecordCount Then
                    DCons.RecordSet("NOMMAT") = Mid(DMat.RecordSet("NOMMAT"), 1, 40)
                End If

                DCons.Update()
            End If
            If TEstadoChr.Text.Trim = "DOSIFICANDO" Then
                TNumEstadoChr.Text = 60 'Reporte capturado
                FEscribPant_Click(0, Nothing)
                Sleep(200)
            End If


        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try
    End Sub

    Private Sub FProceso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FProceso.Click
        Try

            If TEstadoProcPant.Text.Trim = "TARANDO" And Eval(TNetoB1.Text) = 0 Then
                FArchivaProc_Click(0, Nothing)
                TNumEstadoChr.Text = 12      'Entra a Proceso de validación de Escaner
                TCodBarras.Text = ""
            End If

            If TEstadoProcPant.Text.Trim <> "PESO OK" Then EstadoBAnt = "A REPORTAR"
            If TEstadoProcPant.Text.Trim = "PESO OK" AndAlso EstadoBAnt = "A REPORTAR" _
                                AndAlso Eval(TNetoB1.Text) >= Eval(TMetaInf.Text) _
                                AndAlso Eval(TNetoB1.Text) <= Eval(TMetaSup.Text) Then
                If (Val(TIOsGSE.Text) And 8) = 8 Then  'Or (Val(TBotonesPant.Text) And 32) = 32 Then
                    EstadoBAnt = "REPORTANDO"
                    TEstadoChr.Text = "REPORTANDO"
                    FArchivaProc_Click(0, Nothing)
                    FCaptRep_Click(Nothing, Nothing)
                    FSigMat_Click(Nothing, Nothing)

                Else
                    Return      'Se queda esperando el botón de reconocer peso en la pantalla
                End If
            End If

        Catch ex As Exception
            TError.Text = Now.ToString + "  " + ex.ToString
        End Try
    End Sub

    Private Sub TOPSol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If Val(TOPSol.Text) = 0 Then Return

            FBuscaOP_Click(Nothing, Nothing)
            TEstadoChr.Text = "PIDE OP " + TOPSol.Text
            FArchivaProc_Click(0, Nothing)

        Catch ex As Exception
            TError.Text = Now.ToString + "  " + ex.ToString
        End Try
    End Sub



    Private Sub FGenArchOGA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FGenArchOGA.Click
        Try
            Dim CodFor As Long
            Dim MntosAlist As Single
            Dim ContConsMed As Int32

            ContRep = Val(TContRep.Text)
            CodFor = Val(TCodFor.Text)

            DOPs.Open("select * from OPS where OP='" + TOPs.Text + "' AND REAL = 0")
            If DOPs.RecordCount = 0 Then Exit Sub
            If Val(DOPs.RecordSet("FECHAINI")) = 0 Then DOPs.RecordSet("FECHAINI") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DOPs.Update()

            '       ---------------------------- SI ES BACHE NUEVO ---------------------------------------------------

            DBaches.Open("select * from BACHES where CONT=0" + ContRep.ToString)
            If DBaches.RecordCount = 0 Then
                FTMuertos_Click(0, Nothing)
                DBaches.AddNew()
                DBaches.RecordSet("CONT") = Val(TContRep.Text)
                DBaches.RecordSet("LINEA") = 6
                DBaches.RecordSet("FECHA") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                DBaches.RecordSet("FECHAFIN") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                DBaches.RecordSet("CODFOR") = CodFor
                DBaches.RecordSet("PESOMETA") = Eval(TMetaT.Text)
                DBaches.RecordSet("MNTOSALIST") = MntosAlist
                DBaches.RecordSet("FACTOR") = Val(TPorc.Text)
                DBaches.RecordSet("NOMFOR") = Mid(TNomFor.Text, 1, 40)
                DFor.Open("select * from FORMULAS where OP=0" + TOPs.Text + " and CODFOR='" + CodFor.ToString + "'")

                If DFor.RecordCount Then
                    DBaches.RecordSet("CODFORB") = DFor.RecordSet("CODFORB")
                    DBaches.RecordSet("FASE") = DFor.RecordSet("FASE")
                Else
                    DBaches.RecordSet("CODFORB") = DBaches.RecordSet("CODFOR")
                End If

                DBaches.RecordSet("USUARIO") = Mid(Usuario, 1, 10)
                DBaches.RecordSet("OP") = Val(TOPs.Text)
                DBaches.RecordSet("BACHE") = Val(TBache.Text)
                DBaches.RecordSet("BACHESMETA") = Val(TBaches.Text)
                DBaches.RecordSet("PESOMETA") = DOPs.RecordSet("META")
                WriteConfigVar("ConsecBaches", ContRep.ToString)
                DBaches.Update()

                'Trae los datos de consumosmed -------------------
                DConsMed.Open("select * from CONSUMOSMED where OP=" + TOPs.Text + " order by CONT desc")
                If DConsMed.RecordCount Then
                    ContConsMed = DConsMed.RecordSet("CONT")
                    DConsMed.Open("select * from CONSUMOSMED where OP=" + TOPs.Text + " and CONT=0" + ContConsMed.ToString)
                    For Each RegConsMed As DataRow In DConsMed.Rows
                        DDatosFor.Open("select * from DATOSFOR where OP=0" + TOPs.Text + " and CODMAT='" + RegConsMed("CODMAT") + "'")
                        DCons.Open("select * from CONSUMOS where CONT=0" + ContRep.ToString + " AND CODMAT='" + RegConsMed("CODMAT") + "' and PESOMETA=0" + RegConsMed("PESOMETA").ToString)
                        If DCons.RecordCount = 0 Then

                            If DCons.RecordCount = 0 Then
                                DCons.AddNew()
                                DCons.RecordSet("CONT") = ContRep
                                DCons.RecordSet("ALARMAS") = 1
                                DCons.RecordSet("OP") = DBaches.RecordSet("OP")
                                DCons.RecordSet("CODFOR") = CodFor
                                DCons.RecordSet("CODFORB") = DBaches.RecordSet("CODFORB")
                                DCons.RecordSet("CODMAT") = RegConsMed("CODMAT")
                                DCons.RecordSet("PESOREAL") = RegConsMed("PESOREAL")
                                DCons.RecordSet("PESOMETA") = RegConsMed("PESOMETA")
                                DCons.RecordSet("CODMATB") = RegConsMed("CODMATB")
                                DCons.RecordSet("PBRUTO") = 0
                                DCons.RecordSet("BASC") = RegConsMed("BASCULA")
                                DCons.RecordSet("CODBAR") = "-"         'Left(CodBar, 20)
                                'DCons.RecordSet("LOTEGSE") = "-"
                                DCons.RecordSet("LOTEGSE") = RegConsMed("LOTEGSE")
                                DCons.RecordSet("TOLVA") = 88       'Por micros
                                DCons.RecordSet("LOTE") = RegConsMed("LOTE")
                                If DDatosFor.RecordCount Then
                                    DCons.RecordSet("ALMACEN") = DDatosFor.RecordSet("ALMACEN")
                                End If

                                DMat.Open("select * from MATPESADOS where CODMAT='" + RegConsMed("CODMAT") + "'")
                                If DMat.RecordCount Then
                                    DCons.RecordSet("NOMMAT") = Mid(DMat.RecordSet("NOMMAT"), 1, 40)
                                End If
                                DCons.Update()
                            End If      'DCons.AddNew
                        End If      'Dcons.Recordset=0
                    Next        'For Each DconsMed
                    DConsMed.Open("delete from CONSUMOSMED where OP=" + TOPs.Text + " and CONT=0" + ContConsMed.ToString)
                End If      'DCons.recordcount






                Dim Archivo As FileStream
                Dim RutaOGA As String
                Dim byteData() As Byte
                Dim FraseOGA As String

                If Val(TOPs.Text) = 0 Then Return

                RutaOGA = ReadConfigVar("RutaArchOGA")
                'Primero lo escribimos dentro de ChronoSoft
                Archivo = New FileStream(Ruta + "APLanosOGA\OP_" + Now.ToString("yyMMdd_HHmmss") + "_" + TOPs.Text + ".txt", FileMode.Create)

                FraseOGA = "OP;" + TOPs.Text.Trim + ";" + TBaches.Text.Trim + vbCrLf

                For K As Integer = 1 To 9
                    FraseOGA = FraseOGA + "T" + K.ToString + ";"
                    DDatosForTempOGA.Open("select * from DATOSFORTEMP where OP=0" + TOPs.Text + " and NOMBREPC='" + NombrePC + "' and BASC=4 and TOLVA=0" + K.ToString)
                    If DDatosForTempOGA.RecordCount Then
                        FraseOGA = FraseOGA + DDatosForTempOGA.RecordSet("CODMAT").ToString + ";"
                        FraseOGA = FraseOGA + DDatosForTempOGA.RecordSet("VALOR").ToString + ";"
                        FraseOGA = FraseOGA + DDatosForTempOGA.RecordSet("TOLINF").ToString + vbCrLf
                    Else
                        DTolvas.Open("select * from TOLVAS where TOLVA=0" + K.ToString)
                        If DTolvas.RecordCount Then
                            FraseOGA = FraseOGA + DTolvas.RecordSet("CODMAT").ToString + ";"
                            FraseOGA = FraseOGA + "0;0" + vbCrLf
                        End If
                    End If
                Next K

                DDatosForTemp.Open("delete from DATOSFORTEMP where OP=0" + TOPs.Text + " and BASC=4")

                byteData = Encoding.Default.GetBytes(FraseOGA)

                Archivo.Write(byteData, 0, byteData.Length)
                Archivo.Close()

                'Copiamos esl archivo a la ruta de OGA
                FileCopy(Ruta + "APLanosOGA\OP_" + Now.ToString("yyMMdd_HHmmss") + "_" + TOPs.Text + ".txt", RutaOGA + "\OGA_OP\OP_" + TOPs.Text + ".txt")

                Sleep(200)

            End If      'Baches AddNew

        Catch ex As Exception
            TError.Text = Now.ToString + "  " + ex.ToString
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FGenArchOGA_Click(0, Nothing)
    End Sub

    Private Sub FTMuertos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FTMuertos.Click
        ''Calcula  para inscribir el tiempo muerto en tabla TMUERTOS
        Try
            DBaches2.Open("select TOP 1 * from BACHES where LINEA=6 order by FECHA desc")
            If DBAChes2.RecordCount Then
                If DBAChes2.RecordSet("MNTOS") > TmpoMaxMezcla6 Then
                    DBAChes2.RecordSet("TMPOMTO") = DBAChes2.RecordSet("MNTOS") - TmpoMaxMezcla6
                    DBAChes2.Update()
                    'Si el tiempo muerto es mayor al establecido agrega tiempo muertos a tabla Tmuertos para
                    'ingresar motivo
                    If DBAChes2.RecordSet("TMPOMTO") >= Val(ReadConfigVar("CONDTMPOMTO")) Then
                        DTMuertos.Open("SELECT * from TMUERTOS WHERE CONT=0" + ContRep.ToString + "AND TIPO = 'MEZCLA'")
                        If DTMuertos.RecordCount = 0 Then
                            'se agrega tiempo muerto a tabla Tmuertos
                            Evento("Tmpo Muerto de Mezcla en cont: " + ContRep.ToString)
                            DTMuertos.AddNew()
                            DTMuertos.RecordSet("Cont") = ContRep
                            DTMuertos.RecordSet("Fecha") = DBAChes2.RecordSet("FECHA")
                            DTMuertos.RecordSet("Tiempo") = DBAChes2.RecordSet("TMPOMTO")
                            DTMuertos.RecordSet("Tipo") = "MEZCLA"
                            DTMuertos.RecordSet("Linea") = 6
                            DTMuertos.RecordSet("OP") = TOPs.Text
                            DTMuertos.RecordSet("CodFor") = TCodFor.Text
                            DTMuertos.RecordSet("NomFor") = Mid(TNomFor.Text, 1, 40)
                            DTMuertos.Update()
                            Alarma("Tiempo Muerto Linea 6 tiempo: " + DTMuertos.RecordSet("Tiempo").ToString)
                        End If
                    End If ' fin si se cumple condicion para motivo de tmpo muerto
                End If
            End If

            'Busca el anterior bache de la linea para tomar el tiempo de alistamiento.
            DBaches2.Open("select TOP 1 * from BACHES where LINEA=6 order by FECHA desc")
            If DBaches2.RecordCount Then
                Pos1 = InStr(1, DBaches2.RecordSet("FECHAFIN"), " ")
                If Pos1 > 0 Then
                    MntosAlist = DateDiff("n", CDate(Mid(DBaches2.RecordSet("FECHAFIN"), Pos1 + 1, 8)), Now.ToString("HH:mm:ss"))
                    If MntosAlist < 0 Then  'bache al siguiente dia calendario
                        'primer bache del dia(jornada despues de 6am), el ultimo fue el dia anterior, referencia desde las 6am:
                        MntosAlist = 1440 + MntosAlist
                        If (MntosAlist > 120) And (Now.ToString("HH:mm:ss") > "06:00:00") Then
                            MntosAlist = DateDiff("n", CDate("6:00:00"), CDate(Now.ToString("HH:mm:ss")))
                        End If
                    End If
                    If MntosAlist > 120 Then
                        'primer bache de la jornada, el ultimo fue en la magrugada del mismo dia(jornada anterior) referencia desde las 6am:
                        If (Now.ToString("HH:mm:ss") > "06:00:00") And CDate(Mid(DBaches2.RecordSet("FECHAFIN"), Pos1 + 1, 8)) < CDate("06:00:00") Then
                            MntosAlist = DateDiff("n", CDate("6:00:00"), CDate(Now.ToString("HH:mm:ss")))

                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try

    End Sub

    Private Sub FArchivaProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FArchivaProc.Click
        Try

            Dim Wrt As StreamWriter = New StreamWriter(Ruta + "Aplanos\" + Now.ToString("yyMMdd") + "_ProcMenores" + ".txt", True)
            Wrt.Write(TimeOfDay.ToString("HH:mm:ss") + vbTab)
            Wrt.Write(CLeft(TEstadoChr.Text, 8) + vbTab)
            Wrt.Write(CLeft(TEstadoProcPant.Text, 8) + vbTab)
            Wrt.Write("OP:" + TOPs.Text + vbTab)
            Wrt.Write("Frm:" + TCodFor.Text + vbTab)
            Wrt.Write("Paso:" + TPaso.Text + vbTab)
            Wrt.Write("Mat:" + TCodMat.Text + vbTab)
            Wrt.Write(Mid(TNomMat.Text, 1, 8) + vbTab)
            Wrt.Write("Meta:" + TMetaInf.Text + vbTab + TMetaSup.Text + vbTab)
            Wrt.Write("Net:" + TNetoB1.Text + vbTab)
            Wrt.Write("EstPant:" + TEstadoProcPant.Text + vbTab)
            Wrt.Write("Btnes:" + TBotonesPant.Text + vbTab)
            Wrt.WriteLine()
            Wrt.Close()
            Wrt.Dispose()
        Catch ex As Exception
            terror.text = now.tostring + "  " + ex.tostring
        End Try

    End Sub




    Private Sub TCodBarras_TextChanged(sender As Object, e As EventArgs) Handles TCodBarras.TextChanged
        If TCodBarras.Text.Trim = "" Then Return
        If TNumEstadoPant.Text = 12 Or TNumEstadoPant.Text = 13 OrElse TNumEstadoPant.Text = 14 Then   'Escanar, mal codmat o mal lote
            'Evalúa si es la etiqueta de Bypass
            Pos1 = InStr(1, TCodBarras.Text, "475*INICIAL*")
            If Pos1 Then
                TNumEstadoChr.Text = 15     'Permite el proceso en la pantalla : falta-sobra
                Evento("ByPass general Cod.Mat. " + TCodMat.Text + " Lote: " + TLote.Text)
                Return
            End If

            If TEstadoProcPant.Text = "COD.MAT." Then
                Pos1 = InStr(1, TCodBarras.Text, "9599*INICIAL*")
                If Pos1 Then
                    TNumEstadoChr.Text = 15     'Permite el proceso en la pantalla : falta-sobra
                    Evento("ByPass por Lote Cod.Mat. " + TCodMat.Text + " Lote: " + TLote.Text)
                    Return
                End If
            End If

            TCodMatBarr1.Text = "-"
            TLoteBarr1.Text = "-"

            TNumEstadoChr.Text = 13     'Verificando CodMat
            Pos1 = InStr(1, TCodBarras.Text, "*")
            If Pos1 > 0 Then
                TCodMatBarr1.Text = Mid(TCodBarras.Text, 1, Pos1 - 1)
                Pos2 = InStr(Pos1 + 1, TCodBarras.Text, "*")
                If Pos2 > 0 Then TLoteBarr1.Text = Mid(TCodBarras.Text, Pos1 + 1, Pos2 - Pos1 - 1)
                If TCodMat.Text = TCodMatBarr1.Text Then
                    TNumEstadoChr.Text = 14     'Ya escaner y CodMat. Verificando Lote
                    If TLoteBarr1.Text <> "" Then
                        TNumEstadoChr.Text = 15      'Ya escaner OK. Permite el proceso en la pantalla : falta-sobra
                        If TLote.Text.Trim <> TLoteBarr1.Text Then
                            Evento("ByPass por Lote Cod.Mat. " + TCodMat.Text + " Lote: " + TLote.Text + " LoteGSE: " + TLoteBarr1.Text)
                        End If
                    End If
                End If
            End If
        End If

    End Sub
End Class