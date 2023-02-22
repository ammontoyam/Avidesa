Imports System.IO
Imports System.Threading.Thread
Public Class ServPLC
    Private TEstado As ArrayControles(Of TextBox)
    Private TNetoRep As ArrayControles(Of TextBox)
    Private TNeto As ArrayControles(Of TextBox)
    Private TBruto As ArrayControles(Of TextBox)

    Private IGComPlc As EthernetIPforCLXComm
    Public Shared ModulosPLC(30) As Int32
    Private RespAB As Int32
    Private FormLoad As Boolean
    Private OPRep As Int32

    Private DVarios2 As AdoNet
    Private DEquipos As AdoNet
    Private DProc As AdoNet
    Private DProcPend As AdoNet
    Private DOPs As AdoNet
    Private DTolvasD As AdoNet
    Private DVarios As AdoNet
    Private DDatosFor As AdoNet
    Private DBaches As AdoNet
    Private DFor As AdoNet
    Private DConfig As AdoNet
    Private DTMuertos As AdoNet
    Private DCons As AdoNet
    Private DArt As AdoNet

    Private IOsMsg As String
    Private Palabra As String
    Private Seccion As String
    Private Msg As String
    Private Reportando As Boolean = False
    Private FinBacheEvaluado As Boolean = False
    Private CodMatImp(5) As String
    Private ContImp(5) As String
    Public Alarmas(5) As String
    Private EstadoAnt(5) As String
    Private Palabra2 As String
    Public DatosOKPLC(5) As Boolean

    Private TmpoDosif As Date = Now
    Private TmpoBache As Date = Now


    Private Sub ServPLC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True

    End Sub


    Public Sub ServPLC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FormLoad = True Then Return
            FormLoad = True

            TEstado = New ArrayControles(Of TextBox)("TEstado", Me)
            TNetoRep = New ArrayControles(Of TextBox)("TNetoRep", Me)
            TNeto = New ArrayControles(Of TextBox)("TNeto", Me)
            TBruto = New ArrayControles(Of TextBox)("TBruto", Me)

            DVarios2 = New AdoNet("-", CONN, DbProvedor)
            DEquipos = New AdoNet("-", CONN, DbProvedor)
            DProc = New AdoNet("-", CONN, DbProvedor)
            DProcPend = New AdoNet("-", CONN, DbProvedor)
            DOPs = New AdoNet("-", CONN, DbProvedor)
            DTolvasD = New AdoNet("-", CONN, DbProvedor)
            DVarios = New AdoNet("-", CONN, DbProvedor)
            DDatosFor = New AdoNet("-", CONN, DbProvedor)
            DBaches = New AdoNet("-", CONN, DbProvedor)
            DFor = New AdoNet("-", CONN, DbProvedor)
            DConfig = New AdoNet("-", CONN, DbProvedor)
            DTMuertos = New AdoNet("-", CONN, DbProvedor)
            DCons = New AdoNet("-", CONN, DbProvedor)
            DArt = New AdoNet("-", CONN, DbProvedor)

            Seccion = "AUTO"

            IGComPlc = New EthernetIPforCLXComm

            IGComPlc.AsyncMode = False
            IGComPlc.DisableSubscriptions = False
            IGComPlc.ProcessorSlot = 0

            DEquipos.Open("select * from EQUIPOS where EQUIPO=12")    'PLC
            If DEquipos.RecordCount Then
                Tip.Text = DEquipos.RecordSet("IP")
                IGComPlc.IPAddress = Tip.Text
                'TStartM2.Text = IGComPlc.ReadAny("M2Start")

                If IGComPlc.Conected Then
                    Tip.BackColor = Color.GreenYellow
                Else
                    Tip.BackColor = Color.Red
                End If
                TError.Text = IGComPlc.FallasPLC
            End If

            BConectar_Click(0, Nothing)

        Catch ex As Exception
            TError.Text = ex.Message
        End Try

    End Sub

    Public Sub BLeer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLeer1.Click
        TValorLeido1.Text = IGComPlc.ReadAny(TNomTag1.Text)
    End Sub

    Public Sub BEscribir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEscribir1.Click
        IGComPlc.WriteData(TNomTag1.Text, CInt(TValorEscribir1.Text))
    End Sub

    Private Shared Function ReadBit(ByVal Modulo As Int32, ByVal Bit As Int32) As Double
        ReadBit = Val(Convert.ToString(ModulosPLC(Modulo), 2).ToCharArray()(Bit))
    End Function


    Private Sub TimScan_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimScan.Tick
        Try

            TSeg.Text = Val(TSeg.Text) + 1
            If Val(TSeg.Text) > 100000 Then TSeg.Text = 1

            If IGComPlc.Conected Then
                For K = 1 To 4
                    TNeto(K).Text = IGComPlc.ReadAny("Chr_Neto_B" + K.ToString)
                    TBruto(K).Text = IGComPlc.ReadAny("Chr_Bruto_B" + K.ToString)
                    TEstado(K).Text = IGComPlc.ReadAny("Chr_Estado_B" + K.ToString)
                    If EstadoAnt(K) <> TEstado(K).Text Then
                        FEstados_Click(K, Nothing)
                        EstadoAnt(K) = TEstado(K).Text
                        FProceso_Click(K, Nothing)
                    End If
                Next K


                If TSegToPLC.Text = "1" Then
                    TSegToPLC.Text = 0
                Else
                    TSegToPLC.Text = 1
                End If
                IGComPlc.WriteData("Chr_WatchDog", CInt(TSegToPLC.Text))

                If PDosifica.shRxPLC.Visible = True Then
                    PDosifica.shRxPLC.Visible = False
                Else
                    PDosifica.shRxPLC.Visible = True
                End If

            End If

            If Val(TSeg.Text) Mod 20 = 0 Then
                FProceso_Click(0, Nothing)
            End If

            'Registra el estado de las básculas
            If Val(TSeg.Text) Mod 30 = 0 Then
                For G = 1 To 4
                    APlanoBascProc(G)
                Next G
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
            IGComPlc.IPAddress = Tip.Text
            TEstado1.Text = IGComPlc.ReadAny("Chr_Estado_B1")

            If IGComPlc.Conected Then
                Tip.BackColor = Color.GreenYellow
            Else
                Tip.BackColor = Color.Red
                TError.Text = IGComPlc.FallasPLC
            End If
        Catch ex As Exception
            TError.Text = TError.Text + " " + ex.ToString
        End Try
    End Sub

    Public Sub FNuevoBache_Click(sender As System.Object, e As System.EventArgs) Handles FNuevoBache.Click
        Try
            'Se escribe en la tabla Proceso para inciar el bache  -------------------------------------------------------
            Dim BascF As Integer
            Dim Bache As Integer = 0
            Dim Contador As String = "0"
     
            TmpoDosif = Now
            TmpoBache = Now

            'Lee uno de los ingrediente pendientes para sacar el numero del bache que sigue
            DProcPend.Open("select TOP 1 * from PROCDOSIFPEND where PROCESO='" + Seccion + "' order by ID")
            If DProcPend.RecordCount Then
                Bache = DProcPend.RecordSet("BACHE")
                Contador = "000" + Bache.ToString
                Contador = DProcPend.RecordSet("OP").ToString + CRight(Contador, 3)

                Resp = Esc1Reg("Chr_Bache", Bache)
                'Resp = Esc1Reg("Chr_Destino", Val(PDosifica.TDestino.Text))

                'Quita del PLC el OK Micros
                Resp = Esc1Reg("Chr_OK_Micros", 0)
                PDosifica.shMicrosOK.Visible = False

                If Resp = 0 Then Resp = Esc1Reg("Chr_OK_Micros", 0)
                PDosifica.TProc.Text = PDosifica.TProc.Text + "OK Micros" + vbCrLf

                If Resp = 0 Then
                    MsgBox("Error en envío de Chr_Bache a PLC", vbIgnore)
                    Return
                End If
                DOPs.Open("select * from OPS where OP=" + DProcPend.RecordSet("OP"))
            End If

            'Se ponen los datos de la OP en cada una de las básculas
            For BascF = 1 To 4
                DProc.Open("select  * from PROCDOSIF where PROCESO = '" + Seccion + "' and BASCULA=" + BascF.ToString)
                If DProc.RecordCount Then
                    'Se debe escrbir los datos de la OP  la B1, así no lleve ingredientes por ahi.
                    If DOPs.RecordCount Then
                        DProc.RecordSet("NOMFOR") = DOPs.RecordSet("NOMFORB")
                        DProc.RecordSet("BACHES") = DOPs.RecordSet("META")
                        DProc.RecordSet("PORC") = DOPs.RecordSet("PORC")
                        DProc.RecordSet("CODFOR") = DOPs.RecordSet("CODFOR")
                        DProc.RecordSet("LP") = DOPs.RecordSet("LP")
                        DProc.RecordSet("OP") = DOPs.RecordSet("OP")
                        DProc.RecordSet("CONT") = Val(Contador)
                        DProc.RecordSet("BACHE") = Bache
                        'DProc.RecordSet("DESTINO") = Val(PDosifica.TDestino.Text)
                        DProc.Update("Proc FnuevoBache")
                    End If
                End If
            Next BascF
            PDosifica.FLeeProc_Click(0, Nothing)

            'Busca si se deben pedir degussa y manuales al PLC. Actualmente  2019.03 son solo enclavamientos
            If Bache > 0 Then
                DProc.Open("select  * from PROCDOSIF where PROCESO = 'DEGUSSA'")
                If DProc.RecordCount Then
                    DProcPend.Open("select  * from PROCDOSIFPEND where PROCESO='DEGUSSA' and BACHE=" + Bache.ToString)
                    If DProcPend.RecordCount Then
                        DProc.RecordSet("OP") = DOPs.RecordSet("OP")
                        DProc.RecordSet("BACHE") = Bache
                        RespInput = Esc1Reg("Chr_Sol_Degussa", 1)
                        DProcPend.Open("delete from PROCDOSIFPEND where PROCESO='DEGUSSA' and BACHE=" + Bache.ToString)
                        PDosifica.TProc.Text += "Solicita Degussa" + vbCrLf
                        APlanoPLC(0, "Solicitud Degussa")
                    Else
                        DProc.RecordSet("OP") = 0
                        DProc.RecordSet("BACHE") = 0
                        RespInput = Esc1Reg("Chr_Sol_Degussa", 0)
                        PDosifica.TProc.Text += "Sin Degussa" + vbCrLf
                        APlanoPLC(0, "Sin Degussa")
                    End If
                    DProc.Update("Proc FNuevo Bache 2")
                End If
                DProc.Open("select  * from PROCDOSIF where PROCESO = 'MANUALES'")
                If DProc.RecordCount Then
                    DProcPend.Open("select  * from PROCDOSIFPEND where PROCESO='MANUALES' and BACHE=" + Bache.ToString)
                    If DProcPend.RecordCount Then
                        DProc.RecordSet("OP") = DOPs.RecordSet("OP")
                        DProc.RecordSet("BACHE") = Bache
                        RespInput = Esc1Reg("Chr_Sol_Micros", 1)
                        DProcPend.Open("delete from PROCDOSIFPEND where PROCESO='MANUALES' and BACHE=" + Bache.ToString)
                        PDosifica.TProc.Text += "Solicita Micros" + vbCrLf
                    Else
                        DProc.RecordSet("OP") = 0
                        DProc.RecordSet("BACHE") = 0
                        RespInput = Esc1Reg("Chr_Sol_Micros", 0)
                        PDosifica.TProc.Text += "Sin Micros" + vbCrLf
                        APlanoPLC(0, "Sin Micros")
                    End If
                    DProc.Update("Proc Fnuevo Bache 3")
                End If

            End If

            For BascF = 1 To 4
                FSigMat_Click(BascF, Nothing)
                Sleep(500)
            Next

        Catch ex As Exception
            TError.Text = TimeOfDay.ToString + "  " + ex.ToString
            EvError(ex.ToString)
        End Try

    End Sub

    Public Sub FSigMat_Click(sender As System.Object, e As System.EventArgs) Handles FSigMat.Click
        Try
            Dim N As Integer
            N = sender
            DProc.Open("select * from PROCDOSIF where PROCESO='" + Seccion + "' and BASCULA=" + N.ToString)

            DProcPend.Open("select * from PROCDOSIFPEND where PROCESO='" + Seccion + "' and  BACHE=" + DProc.RecordSet("BACHE").ToString + " and BASCULA=" + N.ToString + " and OP=" + DProc.RecordSet("OP") + " order by ID")
            If DProcPend.RecordCount = 0 Then
                DProc.RecordSet("NOMMAT") = "-"
                DProc.RecordSet("METAT") = 0
                'DProc.RecordSet("LOTE") = "-"
                'DProc.RecordSet("UBIC") = "-"
                DProc.RecordSet("CODMAT") = "-"
                DProc.RecordSet("CODMATB") = "-"
                'DProc.RecordSet("ESTADO") = "LIBRE"
                DProc.Update("Proc FSigMat")

                RespInput = Esc1Reg("Chr_Bache_Listo_B" + N.ToString, 1)
                PDosifica.TProc.Text += "B.Listo " + N.ToString + vbCrLf

                PDosifica.FLeeProc_Click(0, Nothing)
                Return
            End If

            DProc.RecordSet("BACHE") = DProcPend.RecordSet("BACHE")
            DProc.RecordSet("BASCULA") = DProcPend.RecordSet("BASCULA")
            DProc.RecordSet("PASO") = DProcPend.RecordSet("PASO")
            DProc.RecordSet("CODMAT") = DProcPend.RecordSet("CODMAT")
            DProc.RecordSet("CODMATB") = DProcPend.RecordSet("CODMATB")
            DProc.RecordSet("NOMMAT") = DProcPend.RecordSet("NOMMAT")
            DProc.RecordSet("METAT") = DProcPend.RecordSet("METAT")
            'DProc.RecordSet("METAMIN") = DProcPend.RecordSet("METAMIN")
            'DProc.RecordSet("METAMAX") = DProcPend.RecordSet("METAMAX")
            DProc.RecordSet("TOLVA") = DProcPend.RecordSet("TOLVA")
            'DProc.RecordSet("LOTE") = "-"
            DProc.RecordSet("ESTADO") = "ENVIANDO.."
            DProc.RecordSet("OUTPUT") = 0  ' Por seguridad
            DTolvasD.Open("select * from TOLVASDOSIF where TOLVA=0" + DProcPend.RecordSet("TOLVA").ToString)
            If DTolvasD.RecordCount Then
                DProc.RecordSet("METAF") = DProc.RecordSet("METAT") - DTolvasD.RecordSet("COMPENS")
                DProc.RecordSet("METAMIN") = DProc.RecordSet("METAT") - DTolvasD.RecordSet("TOLINF")
                DProc.RecordSet("METAMAX") = DProc.RecordSet("METAT") + DTolvasD.RecordSet("TOLSUP")

                If DProc.RecordSet("METAMAX") < 1 Then
                    PDosifica.TMsgGen.Text += "Ingred." + DProc.RecordSet("NOMMAT") + " con METAMAX menor de 1 Kg. Revisar Tolerancias y Compensación"
                    Return
                End If
                If DProc.RecordSet("METAMIN") < 1 Then
                    PDosifica.TMsgGen.Text += "Ingred." + DProc.RecordSet("NOMMAT") + " con METAMIN menor de 1 Kg. Revisar Tolerancias y Compensación"
                    Return
                End If

                DProc.RecordSet("METAG") = DProc.RecordSet("METAT") - DTolvasD.RecordSet("AFINA")
                If DProc.RecordSet("METAG") < 1 Then DProc.RecordSet("METAG") = 1
                DProc.RecordSet("VELG") = DTolvasD.RecordSet("VELGRUESA")
                DProc.RecordSet("VELF") = DTolvasD.RecordSet("VELFINA")

                'DProc.RecordSet("JOGTIME") = DTolvasD.RecordSet("JOGTIME")
                DProc.RecordSet("JOGSMAX") = DTolvasD.RecordSet("JOGSMAX")
                DProc.RecordSet("OUTPUT") = DTolvasD.RecordSet("TOLVA")
                DProc.RecordSet("COMPENSACION") = DTolvasD.RecordSet("COMPENS")
                DProc.RecordSet("NOMTOLVA") = DTolvasD.RecordSet("NOMTOLVA")
            End If
            'Genera el archivo plano
            Msg = vbCrLf
            Msg += "Ini. " + Seccion + vbTab + " "
            Msg += "Bch " + DProc.RecordSet("BACHE").ToString + vbTab + " "
            Msg += "Cod " + DProc.RecordSet("CODMAT") + vbTab + " "
            Msg += "T " + DProc.RecordSet("NOMTOLVA") + vbTab + " "
            Msg += "MT" + DProc.RecordSet("METAT").ToString + vbTab + " "
            Msg += "Mm " + DProc.RecordSet("METAMIN").ToString + vbTab + " "
            Msg += "MM " + DProc.RecordSet("METAMAX").ToString + vbTab + " "
            Msg += "MG " + DProc.RecordSet("METAG").ToString + vbTab + " "
            Msg += "MF " + DProc.RecordSet("METAF").ToString + vbTab + " "
            Msg += "VG " + DProc.RecordSet("VELG").ToString + vbTab + " "
            Msg += "VF " + DProc.RecordSet("VELF").ToString + vbTab + " "
            Msg += "O " + DProc.RecordSet("OUTPUT").ToString + vbTab + " "

            APlanoPLC(N, Msg)

            DVarios.Open("delete from PROCDOSIFPEND where ID=" + DProcPend.RecordSet("ID").ToString)
            DProc.Update("Proc. SigMat 2")
            Alarmas(N) = "-"
            FEnviaIngPLC_Click(N, Nothing)
            If DatosOKPLC(N) Then
                RespInput = Esc1Reg("Chr_Inicio_B" + N.ToString, 1)
                If RespInput = 0 Then RespInput = Esc1Reg("Chr_Inicio_B" + N.ToString, 1)
                PDosifica.TProc.Text = PDosifica.TProc.Text + "Start " + N.ToString + " " + DProc.RecordSet("NOMTOLVA") + vbCrLf
            Else
                MsgBox("Error de Datos a PLC Básc." + N.ToString)
            End If

            PDosifica.FLeeProc_Click(0, Nothing)
        Catch ex As Exception
            TError.Text = Format(Now, "HH:mm:ss") + ":   " + (ex.ToString)
            EvError(ex.ToString)
        End Try

    End Sub

    Private Sub FEnviaIngPLC_Click(sender As System.Object, e As System.EventArgs) Handles FEnviaIngPLC.Click
        Try
            Dim Basc As Integer
            Basc = sender
            'Inicia Envíos
            DProc.Open("select * from PROCDOSIF where PROCESO='" + Seccion + "' and BASCULA=" + Basc.ToString)
            If DProc.RecordCount Then


                DatosOKPLC(Basc) = False
                Resp = Esc1Reg("Chr_Peso_Meta_B" + Basc.ToString, DProc.RecordSet("METAT"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Meta_Corte_B" + Basc.ToString, DProc.RecordSet("METAF"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Meta_Maximo_B" + Basc.ToString, DProc.RecordSet("METAMAX"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Meta_Minimo_B" + Basc.ToString, DProc.RecordSet("METAMIN"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Alimentacion_Fina_B" + Basc.ToString, DProc.RecordSet("METAT") - DProc.RecordSet("METAG"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Velocidad_Gru_B" + Basc.ToString, DProc.RecordSet("VELG"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Velocidad_Fina_B" + Basc.ToString, DProc.RecordSet("VELF"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Max_Num_Jogs_B" + Basc.ToString, DProc.RecordSet("JOGSMAX"))
                If Resp <= 0 Then Return
                Resp = Esc1Reg("Chr_Alimentador_Num_B" + Basc.ToString, DProc.RecordSet("OUTPUT"))
                If Resp <= 0 Then Return

                DatosOKPLC(Basc) = True
            End If      'DProc.RecordCount

        Catch ex As Exception
            TError.Text = Format(Now, "HH:mm:ss") + ":   " + (ex.ToString)
            EvError(ex.ToString)
        End Try

    End Sub

    Function Esc1Reg(ByVal Tag As String, ByVal Dato As String) As Integer
        Try
            Dim Basc As Integer
            Basc = Val(CRight(Tag, 1))

            IGComPlc.WriteData(Tag, Dato)
            APlanoPLC(Basc, "W " + Tag + "  : " + Dato)

            RespInput = IGComPlc.ReadAny(Tag)
            APlanoPLC(Basc, "R " + Tag + "  : " + RespInput)

            If RespInput = "False" Then
                If Dato = "0" Then
                    Return 1
                Else
                    Return 0
                    APlanoPLC(Basc, "Error " + Tag + "  : " + RespInput + " : " + Dato)
                End If
            End If
            If RespInput = "True" Then
                If Dato = "1" Then
                    Return 1
                Else
                    Return 0
                    APlanoPLC(Basc, "Error " + Tag + "  : " + RespInput + " : " + Dato)
                End If
            End If


            If IsNumeric(RespInput) Then
                If Val(RespInput) = Val(Dato) Then
                    Return 1
                Else
                    Return 0
                    APlanoPLC(Basc, "Error " + Tag + "  : " + RespInput + " : " + Dato)
                End If
            Else
                If RespInput = Dato Then
                    Return 1
                Else
                    Return 0
                    APlanoPLC(Basc, "Error " + Tag + "  : " + RespInput + " : " + Dato)
                End If
            End If

        Catch ex As Exception
            TError.Text = (ex.ToString)
            APlanoPLC(Val(CRight(Tag, 1)), "Error " + Tag + "  : " + ex.ToString)
        End Try

    End Function

    Public Sub FProceso_Click(sender As System.Object, e As System.EventArgs) Handles FProceso.Click
        Try
            Dim K As Integer
            For K = 1 To 4
                If Estado(K) = "PESO OK" Then

                    TNetoRep(K).Text = IGComPlc.ReadAny("Chr_Neto_Rep_B" + K.ToString)
                    NetoRep(K) = TNetoRep(K).Text

                    If NetoRep(K) > 0 Then
                        FCaptRep_Click(K, Nothing)
                        Reportando = False
                        DProc.Open("select * from PROCDOSIF where PROCESO='AUTO' and BASCULA='" + K.ToString + "'")
                        If DProc.RecordCount Then
                            DProc.RecordSet("ESTADO") = "REP.OK"
                            DProc.Update("Proc Fproceso")
                        End If
                        PDosifica.FLeeProc_Click(0, Nothing)
                    End If
                End If

                If Estado(K) = "REP.OK" Then
                    'If BitsPLCDos(2) = 0 Then      'Start Ingrediente 
                    PDosifica.TMsgGen.Text = ""
                    FSigMat_Click(K, Nothing)
                    'Retardo para que el PLC tome correctamente el dato
                    Sleep(300)
                    'End If
                End If
            Next K

            'Nuevo Bache 1, 2 y 4
            If Estado(1) = "LIBRE" And Estado(2) = "LIBRE" And Estado(3) = "LIBRE" And Estado(4) = "LIBRE" Then
                PDosifica.TTmpoBache.Text = DateDiff(DateInterval.Second, TmpoBache, Now)
                TmpoBache = Now

                If Val(PDosifica.TBacheNo1.Text) < Val(PDosifica.TBaches.Text) And Val(PDosifica.TBacheNo1.Text) > 0 Then
                    If CicloSostenido = False Then
                        FinBacheEvaluado = False
                        FNuevoBache_Click(K, Nothing)
                    Else
                        If InStr(PDosifica.TMsgGen.Text, "Ciclo sostenido") = 0 Then PDosifica.TMsgGen.Text += "Ciclo sostenido "
                    End If
                End If
            End If

            'Condiciones para la descarga de las Básculas 1, 2 3 y 4. Chr habilita al PLC para descargar
            If Estado(1) = "FIN BASC." And Estado(2) = "FIN BASC." And Estado(3) = "FIN BASC." And Estado(4) = "FIN BASC." _
                                             And FinBacheEvaluado = False And Val(TSeg.Text) > 2 Then
                Dim MetaBasc As Single
                Dim PorcError As Single
                PDosifica.TTmpoDosif.Text = DateDiff(DateInterval.Second, TmpoDosif, Now)

                ''La solicitud se borra de Chr, pero no quiere decir que ya se hayan reconocido..
                'PDosifica.shConDeg.Visible = False
                'PDosifica.shConMicros.Visible = False
                PDosifica.TMsgGen.Text = ""
                For K = 1 To 4
                    DVarios.Open("select SUM(VALOR) as META from DATOSFOR where CODFOR=" + PDosifica.TCodFor1.Text + " and LP='" + PDosifica.TLP.Text + "' and BASCULA=" + K.ToString)
                    If Not IsDBNull(DVarios.RecordSet("META")) Then
                        MetaBasc = DVarios.RecordSet("META") * Val(PDosifica.TPorc.Text) / 100
                        PorcError = Math.Abs((MetaBasc - Bruto(K)) / MetaBasc * 100)
                        If K <> 3 Then
                            If PorcError > 3 Then
                                PDosifica.TMsgGen.Text += "Báscula " + K.ToString + " fuera del 3%. Meta: " + MetaBasc.ToString + " P.Bruto " + Bruto(K).ToString + vbCrLf
                                APlanoPLC(K, "No descarga por 3%. Meta: " + MetaBasc.ToString + " P.Bruto " + Bruto(K).ToString)
                            End If
                        Else
                            If PorcError > 5 Then
                                PDosifica.TMsgGen.Text += "Báscula " + K.ToString + " fuera del 5%. Meta: " + MetaBasc.ToString + " P.Bruto " + Bruto(K).ToString + vbCrLf
                                APlanoPLC(K, "No descarga por 5%. Meta: " + MetaBasc.ToString + " P.Bruto " + Bruto(K).ToString)
                            End If

                        End If
                    End If
                Next K

                If PDosifica.TMsgGen.Text = "" Then
                    RespInput = Esc1Reg("Chr_OK_Descarga_Basc", 1)
                    APlanoPLC(0, "Chr Habilita descarga")
                    PDosifica.TProc.Text += "Hab. Desc. Básc." + vbCrLf
                    FinBacheEvaluado = True
                End If
            End If


        Catch ex As Exception
            TError.Text = TimeOfDay.ToString + "  " + ex.ToString
            EvError(ex.ToString)
        End Try

    End Sub

    Private Sub FCaptRep_Click(sender As System.Object, e As System.EventArgs) Handles FCaptRep.Click
        Try
            Dim FechaRepAnt As String = ""
            Dim Minutos As Single = 0
            Dim Destino As Int16 = 0
            Dim PorcBache As Single
            Dim Tirilla As String = ""
            Dim SumPaqPrem As Double = 0
            Dim SumPaqPremReal As Double = 0
            Dim BascRep As String = ""
            Dim CodMat As String = ""
            Dim OP As String
            Dim Real As Single
            Dim Meta As Single
            Dim Bache As Integer
            Dim CodFor As String
            Dim LP As String
            Dim Factor As Integer
            Dim FechaRep As String
            Dim Tolva As Integer = 0
            Dim Contador As String
            Dim DifCompens As Single

            BascRep = Val(sender)

            Reportando = True

            OP = PDosifica.TOPB(1).Text     'Todas las basculas van con la misma OP

            DOPs.Open("select * from OPS where OP='" + OP + "'")
            If DOPs.RecordCount = 0 Then Exit Sub

            DProc.Open("Select * from PROCDOSIF where PROCESO='AUTO' and BASCULA=" + BascRep.ToString)
            If DProc.RecordCount = 0 Then Exit Sub

            Contador = DProc.RecordSet("CONT")
            CodMat = DProc.RecordSet("CODMAT")
            Tolva = DProc.RecordSet("TOLVA")


            Real = NetoRep(BascRep)
            Bache = DProc.RecordSet("BACHE")
            PorcBache = DOPs.RecordSet("PORC")


            CodFor = DOPs.RecordSet("CODFOR")
            LP = DOPs.RecordSet("LP")
            Factor = DOPs.RecordSet("PORC")
            Meta = DProc.RecordSet("METAT")

            If OP <> DProc.RecordSet("OP") Or CodMat <> DProc.RecordSet("CODMAT") Then
                Evento("Error Se intentó reportar OP: " + OP + " Cod.Mat. " + CodMat)
                Reportando = False
                Return
            End If

            FechaRep = FechaC()

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and CODMAT='" + CodMat + "'")
            If DDatosFor.RecordCount = 0 Then
                Evento("Se intentó reportar ingred." + CodMat + " que no pertenece a la fórmula : " + CodFor + " LP: " + LP)
                Reportando = False
                Return
            End If

            DBaches.Open("select TOP 1 * from BACHES order by FECHA desc")
            If DBaches.RecordCount > 0 Then
                FechaRepAnt = DBaches.RecordSet("FECHA")
            End If

            DBaches.Open("select  * from BACHES where Cont=" + Contador)    '-----------------------------------------------------
            If DBaches.RecordCount = 0 Then
                Evento("RECIBE REPORTES Fórm: " + CodFor + " N." + Contador)

                DBaches.AddNew()

                'Encabezado de la tirilla de impresión
                Tirilla = vbCrLf + vbCrLf + vbCrLf + "---------------------------------------------------------------------------------------------------------"
                Tirilla += vbCrLf + "AVIDESA" + vbTab
                Tirilla += Format(Now, "MMM/dd/yyyy HH:mm:ss") + vbCrLf
                Tirilla += vbCrLf + vbCrLf + "    REPORTE DE MATERIALES PESADOS" + vbCrLf
                Tirilla += " OP : " + OP.ToString + vbTab + " Fórmula: " + CodFor.ToString + vbTab + DOPs.RecordSet("NOMFORB") + vbTab
                Tirilla += "Bache : " + Bache.ToString + vbTab + " Consecutivo: " + Contador.ToString + vbCrLf
                Tirilla += vbCrLf + "Hora" + vbTab + "Código" + vbTab + "Material" + vbTab + vbTab + vbTab + "Meta kg" + vbTab + "Real kg" + vbTab + "E kg" + vbTab
                Tirilla += "E(%)" + vbTab + "PBruto" + vbTab + "TOLVA" + vbTab + "ALARMA" + vbCrLf

                DBaches.RecordSet("CONT") = Val(Contador)
                DBaches.RecordSet("CONTABILIZADO") = "N"
                DBaches.RecordSet("FECHAPROCESO") = Format(Now.Date, "dd/MM/yyyy")
                DBaches.RecordSet("TRANSMITIDOSAP") = "N"
                DBaches.RecordSet("TRANSMITIDOFINOP") = "N"
                DBaches.RecordSet("DOCUMENTOSAP") = 0
                'DBaches.RecordSet("CONTMAQ") = 0
                DBaches.RecordSet("FECHA") = FechaRep
                DBaches.RecordSet("LP") = LP
                DBaches.RecordSet("CODFOR") = CodFor
                DBaches.RecordSet("FACTOR") = Factor
                DBaches.RecordSet("ESTADOS") = "I"

                DConfig.Open("select * from CONFIG")
                If DConfig.RecordCount > 0 Then
                    DConfig.RecordSet("ULTIMAFORPROD") = CodFor + "-" + LP
                End If

                DFor.Open("select * from FORMULAS where CODFOR='" + CodFor + "' and LP='" + LP + "'")
                If DFor.RecordCount > 0 Then
                    DBaches.RecordSet("CODFORB") = DFor.RecordSet("CODFORB")
                    DBaches.RecordSet("NOMFORB") = DFor.RecordSet("NOMFOR")
                    DBaches.RecordSet("PASOS") = DFor.RecordCount
                    DBaches.RecordSet("PESOMETA") = DFor.RecordSet("TOTALFOR")
                End If

                If FechaRepAnt.Contains(" ") Then
                    Minutos = DateDiff("n", CDate(FechaRepAnt), CDate(FechaRep))
                    If Minutos < 0 Then Minutos *= -1
                    If Minutos > DConfig.RecordSet("TMPOMXMTO") Then Minutos = DConfig.RecordSet("TMPOBACHE")
                Else
                    Minutos = DConfig.RecordSet("TMPOBACHE")
                End If
                DBaches.RecordSet("MNTOS") = Minutos
                If Minutos > DConfig.RecordSet("TMPOBACHE") Then DBaches.RecordSet("TMPOMTO") = Minutos - DConfig.RecordSet("TMPOBACHE")
                If Minutos > (DConfig.RecordSet("TMPOBACHE")) Then
                    DTMuertos.Open("select * from TMUERTOS WHERE CONT=" + Contador)
                    If DTMuertos.RecordCount = 0 Then
                        DTMuertos.AddNew()
                        UsuarioDosificacion = ReadConfigVar("UsuarioDosif")
                        DTMuertos.RecordSet("CONT") = Contador
                        DTMuertos.RecordSet("FECHAINI") = DBaches.RecordSet("Fecha")
                        DTMuertos.RecordSet("PROCESO") = "DOSIF"
                        DTMuertos.RecordSet("TIEMPO") = Minutos - DConfig.RecordSet("TMPOBACHE")
                        DTMuertos.RecordSet("Usuario") = UsuarioDosificacion  ' CLeft(DRUsuario("USUARIO"), 10)
                        Evento("Tiempo MUERTO : " + DTMuertos.RecordSet("TIEMPO").ToString + " minutos")
                        DTMuertos.Update("TMuertos FCaptRep ")
                    End If
                End If
                DBaches.RecordSet("USUARIO") = CLeft(UsuarioDosificacion, 10)
                DBaches.RecordSet("OP") = OP
                DBaches.RecordSet("DESTINO") = 0        ' Val(PDosifica.TDestino.Text)
                DBaches.RecordSet("ENLACE") = 1
                DBaches.RecordSet("ESTADO") = 1


                DOPs.Open("Select * From OPS WHERE OP='" + OP + "'")
                If DOPs.RecordCount > 0 Then

                    If Val(DOPs.RecordSet("FECHAINI").ToString) = 0 Then DOPs.RecordSet("FECHAINI") = CLeft(FechaRep, 16)
                    If Val(DOPs.RecordSet("FECHA1")) = 0 Then DOPs.RecordSet("FECHA1") = CLeft(FechaC, 10)
                    If Val(DOPs.RecordSet("HORA1")) = 0 Then DOPs.RecordSet("HORA1") = Mid(FechaC, 12, 5)
                    DOPs.RecordSet("FECHAFIN") = CLeft(FechaRep, 16)
                    DOPs.RecordSet("FECHA2") = CLeft(FechaC, 10)
                    DOPs.RecordSet("HORA2") = Mid(FechaC, 12, 5)


                    DVarios.Open("Select * from BACHES where OP='" + OP + "'")

                    If DVarios.RecordCount = 0 Then
                        DOPs.RecordSet("REAL") = 1
                    Else
                        DOPs.RecordSet("REAL") = DVarios.RecordCount + 1
                    End If
                    DBaches.RecordSet("FINOP") = "N"

                    'DOPs.RecordSet("REAL") += 1
                    If DOPs.RecordSet("REAL") >= DOPs.RecordSet("META") Then
                        DOPs.RecordSet("FINALIZADO") = "S"
                        DOPs.RecordSet("COMPLETO") = "S"
                        DBaches.RecordSet("FINOP") = "S"
                    End If

                    DBaches.RecordSet("PRODUCTO") = Trim(DOPs.RecordSet("CODPROD"))
                    DBaches.RecordSet("BACHESMETA") = DOPs.RecordSet("META")
                    DBaches.RecordSet("BACHE") = DOPs.RecordSet("REAL")
                    DBaches.RecordSet("MAQUILA") = DOPs.RecordSet("MAQUILA")


                    DOPs.Update("OPs FCapRep 3")
                End If

                DConfig.RecordSet("ULTIMOBACHE") = Contador
                DConfig.Update("Config FcaptRep")


                'Revisa los Baches anteriores para actualizar el peso en la tabla baches------------------
                DBaches.Update("Baches FCaptRep 8")
                FBachesAnt_Click(Nothing, Nothing)



                DBaches.Open("select  * from BACHES where Cont=" + Contador)
                ''----------------------------------------------------Reportamos los Ingredientes manuales -----------------------------------------------------------------------------------------------
                DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor.Trim + "' and LP='" + LP + "' and TIPON>=7")
                For Each RecordSet As DataRow In DDatosFor.Rows

                    DCons.Open("select * from CONSUMOS where CONT=" + Contador + " and CODMAT='" + RecordSet("CodMat").ToString + "'")

                    If DCons.RecordCount = 0 Then
                        DCons.AddNew()
                        DCons.RecordSet("CONT") = Contador
                        DCons.RecordSet("ALARMAS") = 123
                        DCons.RecordSet("PASO") = 0
                        DCons.RecordSet("CodFor") = CodFor
                        DCons.RecordSet("CodForB") = RecordSet("CODFORB")
                        DCons.RecordSet("CodMat") = RecordSet("CODMAT")
                        DCons.RecordSet("PESOREAL") = Eval(RecordSet("VALOR") * PorcBache / 100)
                        DCons.RecordSet("PesoMeta") = Eval(RecordSet("VALOR") * PorcBache / 100)

                        'Si está empezando el cambio de tolva, el peso meta se iguala al real para que no salga tanto error en los reportes.
                        If PesoParcial(BascRep) Then
                            DCons.RecordSet("PesoMeta") = DCons.RecordSet("PESOREAL")
                        End If

                        DCons.RecordSet("TIPOMAT") = RecordSet("TIPON")
                        DCons.RecordSet("OP") = OP
                        DCons.RecordSet("REPORTADO") = 0
                        DCons.RecordSet("POSICIONSAP") = 0
                        DCons.RecordSet("TERMINADO") = "S"
                        'DCons.RecordSet("Tolva") = Tolva
                        If DCons.RecordSet("PESOREAL") = 0 Then DCons.RecordSet("PESOREAL") = DCons.RecordSet("PesoMeta")
                        DCons.RecordSet("CodMatB") = RecordSet("CODMATB")

                        DArt.Open("select * from MATPESADOS where CODMAT='" + RecordSet("CODMAT").ToString + "'")
                        If DArt.RecordCount Then
                            DCons.RecordSet("NOMMAT") = DArt.RecordSet("NOMMAT")
                            DCons.RecordSet("COD3") = DArt.RecordSet("COD3")
                            DCons.RecordSet("MOTONAVE") = DArt.RecordSet("MOTONAVE")
                            DCons.RecordSet("LOTE") = DArt.RecordSet("LOTE")
                            DCons.RecordSet("PESOMERMA") = DCons.RecordSet("PESOREAL") * DArt.RecordSet("PORCENTAJEMERMAPROCESO")
                        End If

                        'CortesLote(DCons.RecordSet("CODMAT"), DCons.RecordSet("PESOREAL"))
                        'DCons.RecordSet("CORTELOTE") = ContCortesMP
                        'DCons.RecordSet("Lote") = LoteCortesMP
                        'DCons.RecordSet("PRECIO") = Math.Round(PrecioKgLote * DCons.RecordSet("PESOREAL"), 2)
                        'If LoteCortesMP <> "-" Then MovInv(DCons.RecordSet("CODMAT"), LoteCortesMP, OP, 0, DCons.RecordSet("PESOREAL"))


                        DCons.Update("Consumos CaptRep")
                        DBaches.RecordSet("PASOS") += 1

                    End If
                Next

                DBaches.Update("Baches CaptRep 9")

            End If 'Nuevo bache

            '**************************************************** INGREDIENTE A CONSUMOS *********************************************


            DCons.Open("select * from CONSUMOS where CONT=0" + Contador + " and CODMAT='" + CodMat + "' and PESOMETA=" + (Eval(Meta).ToString))
            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and CODMAT='" + CodMat + "'") ' and PESOMETA=" + Replace(Format((Eval(Meta) * 100 / Factor), "0.000"), ",", "."))

            If DDatosFor.RecordCount = 0 Then
                If Val(CodMat) > 0 Then
                    Evento("Se reportó el ingrediente " + CodMat + " que no pertenece a la fórmula " + CodFor)
                Else
                    Evento("GSE reporta ingrediente codigo 0 " + CodFor)
                End If
            End If


            DOPs.Open("select * from OPS where OP='" + OP.ToString + "'")


            ' ------------------------TIRILLA---------------------------------------------

            If CodMatImp(BascRep) <> CodMat Or ContImp(BascRep) <> Contador Then          'Impide que se imprima dos veces en la tirilla

                CodMatImp(BascRep) = CodMat
                ContImp(BascRep) = Contador
                Tirilla += vbCrLf + Format(TimeOfDay, "HH:mm:ss") + vbTab + CodMat.ToString + vbTab
                If DDatosFor.RecordCount Then Tirilla += Mid(DDatosFor.RecordSet("NOMMAT") + "____________________", 1, 20) + vbTab
                Tirilla += Meta.ToString + vbTab + Real.ToString + vbTab + FormatNumber(Meta - Real, 2) + vbTab
                Tirilla += FormatNumber((1 - (Real / (Meta + 0.000000001))) * 100, 1) + vbTab
                Tirilla += PDosifica.TBruto(BascRep).Text + vbTab + Tolva.ToString + vbTab

            End If

            If DDatosFor.RecordCount > 0 And DCons.RecordCount = 0 Then
                DCons.AddNew()
                DCons.RecordSet("CONT") = Contador
                DCons.RecordSet("PASO") = 0
                DCons.RecordSet("ALARMAS") = "-"
                If Alarmas(BascRep) <> "" Then
                    DCons.RecordSet("ALARMAS") = Mid(Alarmas(BascRep), 1, 10)
                End If
                DCons.RecordSet("CodFor") = CodFor
                DCons.RecordSet("CodForB") = DDatosFor.RecordSet("CODFORB")
                DCons.RecordSet("CodMat") = CodMat
                DCons.RecordSet("PESOREAL") = Real
                 DCons.RecordSet("PesoMeta") = Meta
                DCons.RecordSet("TIPOMAT") = DDatosFor.RecordSet("TIPON")
                DCons.RecordSet("LOTE") = "-"
                DCons.RecordSet("REPORTADO") = 0
                DCons.RecordSet("Tolva") = Tolva
                DCons.RecordSet("Bascula") = BascRep
                DCons.RecordSet("OP") = OP
                DCons.RecordSet("Est") = DDatosFor.RecordSet("A")
                DCons.RecordSet("POSICIONSAP") = 0
                DCons.RecordSet("TERMINADO") = "S"


                DBaches.Update("Baches CaptRep 1")
                'Pone el valor de alarmas por defecto para el siguiente ingrediente

                If DCons.RecordSet("PESOREAL") = 0 Then DCons.RecordSet("PESOREAL") = DCons.RecordSet("PesoMeta")
                DCons.RecordSet("CodMatB") = DDatosFor.RecordSet("CODMATB")

                DArt.Open("select * from MATPESADOS where CODMAT='" + CodMat + "'")
                If DArt.RecordCount Then
                    DCons.RecordSet("NOMMAT") = DArt.RecordSet("NOMMAT")
                    DCons.RecordSet("COD3") = DArt.RecordSet("COD3")
                    DCons.RecordSet("MOTONAVE") = DArt.RecordSet("MOTONAVE")
                    DCons.RecordSet("LOTE") = DArt.RecordSet("LOTE")
                    DCons.RecordSet("PESOMERMA") = DCons.RecordSet("PESOREAL") * DArt.RecordSet("PORCENTAJEMERMAPROCESO")
                End If

                'CortesLote(CodMat, Real)
                'DCons.RecordSet("CORTELOTE") = ContCortesMP
                'DCons.RecordSet("Lote") = LoteCortesMP
                'DCons.RecordSet("PRECIO") = Math.Round(PrecioKgLote * DCons.RecordSet("PESOREAL"), 2)
                'If LoteCortesMP <> "-" Then MovInv(CodMat, LoteCortesMP, OP, 0, DCons.RecordSet("PESOREAL"))

                DBaches.Refresh()

                'Compensación Automática
                DTolvasD.Open("select * from TOLVASDOSIF where TOLVA=0" + Tolva.ToString)
                If DTolvasD.RecordCount Then
                    If DTolvasD.RecordSet("COMPENSAUTO") = "X" Then
                        DifCompens = Real - Meta
 
                        DTolvasD.RecordSet("COMPENS") = Math.Round(DTolvasD.RecordSet("COMPENS") + DifCompens * 0.5, 2)
                        If DTolvasD.RecordSet("COMPENS") < 0 Then DTolvasD.RecordSet("COMPENS") = 0
                        If DTolvasD.RecordSet("COMPENS") > DTolvasD.RecordSet("AFINA") Then DTolvasD.RecordSet("COMPENS") = DTolvasD.RecordSet("AFINA") * 0.5
                        DTolvasD.Update("Tolvas CapRep")
                    End If
                End If

                DBaches.RecordSet("PESOREAL") += DCons.RecordSet("PESOREAL")
                DBaches.RecordSet("PESO") = DBaches.RecordSet("PESOREAL")
                'DBaches.RecordSet("FECHAFIN") = FechaRep
                'DBaches.RecordSet("TNHORA") = DBaches.RecordSet("PESOREAL") * 60 / ((DateDiff("n", CDate(DBaches.RecordSet("FECHA")), CDate(DBaches.RecordSet("FECHAFIN"))) + Eval(0.001)) * 1000)

                DBaches.Update("Baches CapRep 2")

                DOPs.Refresh()
                DOPs.RecordSet("FECHAFIN") = CLeft(FechaRep, 16)
                DOPs.Update("OPs CapRep2")

                DCons.Update("Consumos CapRep3")

            End If
            ImpTirilla(Tirilla)
            PesoParcial(BascRep) = False
            Reportando = False
        Catch ex As Exception
            TError.Text = TimeOfDay.ToString + "   " + ex.ToString
            EvError(ex.ToString)

        End Try
    End Sub

    Private Sub FBachesAnt_Click(sender As System.Object, e As System.EventArgs) Handles FBachesAnt.Click
        Try
            'Revisa los Baches anteriores para verificar si están completo-s------------------
            Dim SumaMeta As Single
            Dim SumaReal As Single
            Dim Proceso As ProcesoPlanta = ProcesoPlanta.EMPAQUE

            'Se seleccionan los baches que falten por verificar el estado
            DBaches.Open("select TOP 10 * from BACHES where ESTADO<10 and FECHA>'2019/02' order by FECHA DESC")
            DCons.Open("select * from CONSUMOS where ID=0")      'Vacía para crear registros nuevos
            For Each RBach As DataRow In DBaches.Rows
                'Como muchos micros se hacen después de dosificar el primer ingrediente de macros, pasamos los ConsumosMed que estén rezagados
                SumaMeta = 0
                SumaReal = 0
                DCons.Open("select sum(PESOMETA) as TOTMETA, sum(PESOREAL) as TOTREAL from CONSUMOS where CONT=" + RBach("CONT").ToString)
                If Not IsDBNull(DCons.RecordSet("TOTMETA")) Then
                    SumaMeta = DCons.RecordSet("TOTMETA")
                    SumaReal = DCons.RecordSet("TOTREAL")
                End If
           
                RBach("PESOREAL") = SumaReal
                RBach("PESO") = SumaReal
                'RecordSet("PESOMETA") = SumaMeta
                'RecordSet("PASOSREP") = DConsumos.RecordCount
                'Si la suma del peso meta de los consumos es igual al peso meta del bache se cambia el estado del bache a 10
                If Math.Abs(RBach("PESOMETA") - SumaMeta) < RBach("PESOMETA") * 0.00005 Then
                    RBach("ESTADO") = 10

                End If
                DBaches.Update("Baches BachesAnt")
            Next

        Catch ex As Exception
            TError.Text = TimeOfDay.ToString + "  " + ex.ToString
            EvError(ex.ToString)
        End Try
    End Sub

    Private Sub FEstados_Click(sender As System.Object, e As System.EventArgs) Handles FEstados.Click
        Try
            Dim Index As Integer


            'Index = Val(CRight(DirectCast(sender, System.Windows.Forms.TextBox).Name, 1))
            Index = sender
            EstadoNum(Index) = Val(TEstado(Index).Text)

            PDosifica.BRecAlarma(Index).Visible = False
            If EstadoNum(Index) = 1 Then
                PDosifica.TStatB(Index).Text = "LIBRE"
            ElseIf EstadoNum(Index) = 3 Then
                PDosifica.TStatB(Index).Text = "LIM. TARA"
            ElseIf EstadoNum(Index) = 5 Then
                PDosifica.TStatB(Index).Text = "TARANDO"
            ElseIf EstadoNum(Index) = 10 Then
                PDosifica.TStatB(Index).Text = "ALIM.GRUESA"
            ElseIf EstadoNum(Index) = 15 Then
                PDosifica.TStatB(Index).Text = "ALIM.FINA"
            ElseIf EstadoNum(Index) = 18 Then
                PDosifica.TStatB(Index).Text = "ESTABIL.FIJA"
            ElseIf EstadoNum(Index) = 20 Then
                PDosifica.TStatB(Index).Text = "ESTABILIZANDO"
            ElseIf EstadoNum(Index) = 25 Then
                PDosifica.TStatB(Index).Text = "AJUSTANDO"
                Alarmas(Index) = Alarmas(Index) + "AJ."
            ElseIf EstadoNum(Index) = 30 Then
                PDosifica.TStatB(Index).Text = "PESO OK"
            ElseIf EstadoNum(Index) = 35 Then
                PDosifica.TStatB(Index).Text = "BAJO PESO"
                PDosifica.BRecAlarma(Index).Visible = True
                Alarmas(Index) = Alarmas(Index) + "BP."
            ElseIf EstadoNum(Index) = 40 Then
                PDosifica.TStatB(Index).Text = "SOBRE PESO"
                'PDosifica.BRecAlarma(Index).Text = "ALARMA"
                PDosifica.BRecAlarma(Index).Visible = True
                Alarmas(Index) = Alarmas(Index) + "SP."
            ElseIf EstadoNum(Index) = 45 Then
                PDosifica.TStatB(Index).Text = "ALIM.LENTA"
                'PDosifica.BRecAlarma(Index).Text = "ALARMA"
                PDosifica.BRecAlarma(Index).Visible = True
                Alarmas(Index) = Alarmas(Index) + "AL."
            ElseIf EstadoNum(Index) = 50 Then
                PDosifica.TStatB(Index).Text = "FIN BASC."
            ElseIf EstadoNum(Index) = 55 Then
                Estado(Index) = "DESCARGANDO"
                PDosifica.TStatB(Index).Text = "DESCARGANDO"
            ElseIf EstadoNum(Index) = 60 Then
                PDosifica.TStatB(Index).Text = "LIMPIANDO"
            ElseIf EstadoNum(Index) = 65 Then
                PDosifica.TStatB(Index).Text = "CERRANDO"
            Else
                Estado(Index) = EstadoNum(Index).ToString
                'PDosifica.BRecAlarma(Index).Text = "ALARMA"
                PDosifica.TStatB(Index).Text = EstadoNum(Index).ToString
            End If
            Estado(Index) = PDosifica.TStatB(Index).Text
            DProc.Open("select * from PROCDOSIF where PROCESO='AUTO' and BASCULA='" + Index.ToString + "'")
            If DProc.RecordCount Then
                DProc.RecordSet("ESTADO") = Estado(Index)
                DProc.Update("Proc FEstados")
                PDosifica.FLeeProc_Click(0, Nothing)
            End If
            APlanoPLC(Index, Estado(Index) + vbTab + " N " + Neto(Index).ToString + vbTab + " B " + Bruto(Index).ToString)
            APlanoBascProc(Index)
            FProceso_Click(0, Nothing)
        Catch ex As Exception
            TError.Text = (ex.ToString)
        End Try

    End Sub

    Public Sub BAbortarPLC_Click(sender As System.Object, e As System.EventArgs) Handles BAbortarPLC.Click
        RespInput = Esc1Reg("Chr_Abortar", 1)
    End Sub

    Public Sub FNuevaOP_Click(sender As System.Object, e As System.EventArgs) Handles FNuevaOP.Click
        Try
            Dim OPs As Int32

            OPs = sender

            DOPs.Open("select * from OPS where OP='" + OPs.ToString + "'")
            If DOPs.RecordCount = 0 Then
                MsgBox("OP no encontrada en FNuevaOP " + OPs.ToString)
                Return
            End If

            DatosOKPLC(0) = False
            Resp = Esc1Reg("Chr_OP", OPs)
            If Resp <= 0 Then Return
            Resp = Esc1Reg("Chr_Cod_Formula", DOPs.RecordSet("CODFOR"))
            If Resp <= 0 Then Return
            Resp = Esc1Reg("Chr_Nom_Formula", DOPs.RecordSet("NOMFORB"))
            If Resp <= 0 Then Return
            Resp = Esc1Reg("Chr_Baches", DOPs.RecordSet("META"))
            If Resp <= 0 Then Return
            DatosOKPLC(0) = True

        Catch ex As Exception
            TError.Text = (ex.ToString)
        End Try
    End Sub

    
    Private Sub TNeto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TNeto1.TextChanged, TNeto2.TextChanged, TNeto3.TextChanged, TNeto4.TextChanged
        Try
            Dim Index As Integer
            Index = Val(CRight(DirectCast(sender, System.Windows.Forms.TextBox).Name, 1))

            'redondea los decimales
            If Index <= 3 Then
                PDosifica.TNeto(Index).Text = Math.Round(Val(TNeto(Index).Text), 1)
            Else
                PDosifica.TNeto(Index).Text = Math.Round(Val(TNeto(Index).Text), 2)
            End If
            Neto(Index) = Math.Round(Val(TNeto(Index).Text), 1)

            If Estado(Index) <> "LIBRE" Then
                PDosifica.TFalta(Index).Text = Math.Round(Eval(PDosifica.TMeta(Index).Text) - Neto(Index), 1)
            End If

        Catch ex As Exception
            TError.Text = (ex.ToString)
        End Try
    End Sub

    Private Sub TBruto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TBruto1.TextChanged, TBruto2.TextChanged, TBruto3.TextChanged, TBruto4.TextChanged
        Try
            Dim Index As Integer

            Index = Val(CRight(DirectCast(sender, System.Windows.Forms.TextBox).Name, 1))
            Bruto(Index) = Math.Round(Val(TBruto(Index).Text), 1)
            PDosifica.TBruto(Index).Text = Bruto(Index)
            If Bruto(Index) > PDosifica.BarraBruto(Index).Maximum Then
                PDosifica.BarraBruto(Index).Value = PDosifica.BarraBruto(Index).Maximum
            ElseIf Bruto(Index) < 0 Then
                PDosifica.BarraBruto(Index).Value = 0
            Else
                PDosifica.BarraBruto(Index).Value = Int(Bruto(Index))
            End If

        Catch ex As Exception
            TError.Text = (ex.ToString)
        End Try
    End Sub

    Public Sub FRecAlarma_Click(sender As System.Object, e As System.EventArgs) Handles FRecAlarma.Click
        Try
            Dim X As Integer

            X = sender

            If InStr(PDosifica.TStatB(sender).Text, "BAJO") Then
                RespInput = Esc1Reg("Chr_Reconoce_Alarma_B" + sender.ToString, 1)
             
            ElseIf InStr(PDosifica.TStatB(sender).Text, "SOBRE") Then
                RespInput = Esc1Reg("Chr_Reconoce_Alarma_B" + sender.ToString, 2)

            ElseIf InStr(PDosifica.TStatB(sender).Text, "LENTA") Then
                RespInput = Esc1Reg("Chr_Reconoce_Alarma_B" + sender.ToString, 3)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BLeerPLC_Click(sender As System.Object, e As System.EventArgs) Handles BLeerPLC.Click
        Try
            TOPs.Text = IGComPlc.ReadAny("Chr_OP")
            TCodFor.Text = IGComPlc.ReadAny("Chr_Cod_Formula")
            TNomFor.Text = IGComPlc.ReadAny("Chr_Nom_Formula")
            TBache.Text = IGComPlc.ReadAny("Chr_Bache")
            TBaches.Text = IGComPlc.ReadAny("Chr_Baches")

            'Bascula 1
            TMeta1.Text = IGComPlc.ReadAny("Chr_Peso_Meta_B1")
            TMetaMax1.Text = IGComPlc.ReadAny("Chr_Meta_Maximo_B1")
            TMetaMin1.Text = IGComPlc.ReadAny("Chr_Meta_Minimo_B1")
            TJogsMax1.Text = IGComPlc.ReadAny("Chr_Max_Num_Jogs_B1")
            TOutput1.Text = IGComPlc.ReadAny("Chr_Alimentador_Num_B1")
            TVelG1.Text = IGComPlc.ReadAny("Chr_Velocidad_Gru_B1")
            TVelF1.Text = IGComPlc.ReadAny("Chr_Velocidad_Fina_B1")
            TAFina1.Text = IGComPlc.ReadAny("Chr_Alimentacion_Fina_B1")
            TStart1.Text = IGComPlc.ReadAny("Chr_Inicio_B1")
            TEstado1.Text = IGComPlc.ReadAny("Chr_Estado_B1")
            TRecAlarma1.Text = IGComPlc.ReadAny("Chr_Reconoce_Alarma_B1")
            TNetoRep1.Text = IGComPlc.ReadAny("Chr_Neto_Rep_B1")
            TBacheListo1.Text = IGComPlc.ReadAny("Chr_Bache_Listo_B1")

            'Bascula 2
            TMeta2.Text = IGComPlc.ReadAny("Chr_Peso_Meta_B2")
            TMetaMax2.Text = IGComPlc.ReadAny("Chr_Meta_Maximo_B2")
            TMetaMin2.Text = IGComPlc.ReadAny("Chr_Meta_Minimo_B2")
            TJogsMax2.Text = IGComPlc.ReadAny("Chr_Max_Num_Jogs_B2")
            TOutput2.Text = IGComPlc.ReadAny("Chr_Alimentador_Num_B2")
            TVelG2.Text = IGComPlc.ReadAny("Chr_Velocidad_Gru_B2")
            TVelF2.Text = IGComPlc.ReadAny("Chr_Velocidad_Fina_B2")
            TAFina2.Text = IGComPlc.ReadAny("Chr_Alimentacion_Fina_B2")
            TStart2.Text = IGComPlc.ReadAny("Chr_Inicio_B2")
            TEstado2.Text = IGComPlc.ReadAny("Chr_Estado_B2")
            TRecAlarma2.Text = IGComPlc.ReadAny("Chr_Reconoce_Alarma_B2")
            TNetoRep2.Text = IGComPlc.ReadAny("Chr_Neto_Rep_B2")
            TBacheListo2.Text = IGComPlc.ReadAny("Chr_Bache_Listo_B2")

            'Bascula 3
            TMeta3.Text = IGComPlc.ReadAny("Chr_Peso_Meta_B3")
            TMetaMax3.Text = IGComPlc.ReadAny("Chr_Meta_Maximo_B3")
            TMetaMin3.Text = IGComPlc.ReadAny("Chr_Meta_Minimo_B3")
            TJogsMax3.Text = IGComPlc.ReadAny("Chr_Max_Num_Jogs_B3")
            TOutput3.Text = IGComPlc.ReadAny("Chr_Alimentador_Num_B3")
            TVelG3.Text = IGComPlc.ReadAny("Chr_Velocidad_Gru_B3")
            TVelF3.Text = IGComPlc.ReadAny("Chr_Velocidad_Fina_B3")
            TAFina3.Text = IGComPlc.ReadAny("Chr_Alimentacion_Fina_B3")
            TStart3.Text = IGComPlc.ReadAny("Chr_Inicio_B3")
            TEstado3.Text = IGComPlc.ReadAny("Chr_Estado_B3")
            TRecAlarma3.Text = IGComPlc.ReadAny("Chr_Reconoce_Alarma_B3")
            TNetoRep3.Text = IGComPlc.ReadAny("Chr_Neto_Rep_B3")
            TBacheListo3.Text = IGComPlc.ReadAny("Chr_Bache_Listo_B3")

            'Bascula 4
            TMeta4.Text = IGComPlc.ReadAny("Chr_Peso_Meta_B4")
            TMetaMax4.Text = IGComPlc.ReadAny("Chr_Meta_Maximo_B4")
            TMetaMin4.Text = IGComPlc.ReadAny("Chr_Meta_Minimo_B4")
            TJogsMax4.Text = IGComPlc.ReadAny("Chr_Max_Num_Jogs_B4")
            TOutput4.Text = IGComPlc.ReadAny("Chr_Alimentador_Num_B4")
            TVelG4.Text = IGComPlc.ReadAny("Chr_Velocidad_Gru_B4")
            TVelF4.Text = IGComPlc.ReadAny("Chr_Velocidad_Fina_B4")
            TAFina4.Text = IGComPlc.ReadAny("Chr_Alimentacion_Fina_B4")
            TStart4.Text = IGComPlc.ReadAny("Chr_Inicio_B4")
            TEstado4.Text = IGComPlc.ReadAny("Chr_Estado_B4")
            TRecAlarma4.Text = IGComPlc.ReadAny("Chr_Reconoce_Alarma_B4")
            TNetoRep4.Text = IGComPlc.ReadAny("Chr_Neto_Rep_B4")
            TBacheListo4.Text = IGComPlc.ReadAny("Chr_Bache_Listo_B4")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

   
    Private Sub BEscStart1_Click(sender As System.Object, e As System.EventArgs)
        IGComPlc.WriteData("Chr_Inicio_B1", 1)
    End Sub

   
    Private Sub BEscribir2_Click(sender As System.Object, e As System.EventArgs) Handles BEscribir2.Click
        IGComPlc.WriteData(TNomTag2.Text, CInt(TValorEscribir2.Text))
    End Sub

    Private Sub BLeer2_Click(sender As System.Object, e As System.EventArgs) Handles BLeer2.Click
        TValorLeido2.Text = IGComPlc.ReadAny(TNomTag2.Text)
    End Sub

    Private Sub TNomTag1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TNomTag1.SelectedIndexChanged
        BLeer1_Click(0, Nothing)
    End Sub

    Private Sub TNomTag2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TNomTag2.SelectedIndexChanged
        BLeer2_Click(0, Nothing)
    End Sub


    Public Sub FRecMicros_Click(sender As System.Object, e As System.EventArgs) Handles FRecMicros.Click
        Try
            Resp = Esc1Reg("Chr_OK_Micros", 1)
            If Resp = 0 Then Resp = Esc1Reg("Chr_OK_Micros", 1)
            PDosifica.TProc.Text = PDosifica.TProc.Text + "OK Micros" + vbCrLf
            PDosifica.shMicrosOK.Visible = True

        Catch ex As Exception
            TError.Text = Format(Now, "HH:mm:ss") + ":   " + (ex.ToString)
            EvError(ex.ToString)
        End Try

    End Sub
End Class
