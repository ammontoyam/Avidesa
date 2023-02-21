Option Explicit On

Imports System
Imports System.Data
Imports System.Threading
Imports System.Threading.Thread

Public Class Empaque

    Private DEmpaque As AdoNet
    Private DConfig As AdoNet
    Private DOPs As AdoNet
    Private DVarios As AdoNet
    Private DProcEnLinea As AdoNet
    Private DTolvas As AdoNet
    Public TOPs As ArrayControles(Of TextBox)
    Public TCodProd As ArrayControles(Of TextBox)
    Public TPresent As ArrayControles(Of TextBox)
    Public TNomProd As ArrayControles(Of TextBox)
    Public TPreset As ArrayControles(Of TextBox)
    Public TSacos As ArrayControles(Of TextBox)
    Private TPesoTot As ArrayControles(Of TextBox)
    Public TAjuste As ArrayControles(Of TextBox)
    Public TResiduo As ArrayControles(Of TextBox)
    Public TFechaUlt As ArrayControles(Of TextBox)
    Public TTMuerto As ArrayControles(Of TextBox)
    Public TOrigen As ArrayControles(Of TextBox)
    Public TDestino As ArrayControles(Of TextBox)
    Public TSupervisor As ArrayControles(Of TextBox)
    Public TEmpacador As ArrayControles(Of TextBox)
    Public TCosedor As ArrayControles(Of TextBox)
    Public TCodEmp As ArrayControles(Of TextBox)
    Public TCodEtiq As ArrayControles(Of TextBox)
    Public TGrupoEmp As ArrayControles(Of TextBox)
    Private FNuevoEmp As ArrayControles(Of Button)
    Public FLimpiar As ArrayControles(Of Button)
    Private MesDia As Long
    Private SacosAnt As Int64
    Private SacosATolva As Int64
    Private AcumuladoB As Double

    Public Sub Ensaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DEmpaque = New AdoNet("EMPAQUE", CONN, DbProvedor)
            DConfig = New AdoNet("Config", CONN, DbProvedor)
            DOPs = New AdoNet("OPS", CONN, DbProvedor)
            DVarios = New AdoNet("VARIOS", CONN, DbProvedor)
            DProcEnLinea = New AdoNet("PROCESOENLINEA", CONN, DbProvedor)
            DTolvas = New AdoNet("TOLVAS", CONN, DbProvedor)
            DConfig.Open("select * from CONFIG")

            TFrecRep.Text = DConfig.RecordSet("FRECREPESO")
            If Trim(TFrecRep.Text) <> "" Then
                TFrecRep.BackColor = Color.Aqua
            End If
            TOPs = New ArrayControles(Of TextBox)("TOPs", Me)
            TCodProd = New ArrayControles(Of TextBox)("TCodProd", Me)
            TPresent = New ArrayControles(Of TextBox)("TPresent", Me)
            TNomProd = New ArrayControles(Of TextBox)("TNomProd", Me)
            TPreset = New ArrayControles(Of TextBox)("TPreset", Me)
            TSacos = New ArrayControles(Of TextBox)("TSacos", Me)
            TPesoTot = New ArrayControles(Of TextBox)("TPesoTot", Me)
            TAjuste = New ArrayControles(Of TextBox)("TAjuste", Me)
            TResiduo = New ArrayControles(Of TextBox)("TResiduo", Me)
            TFechaUlt = New ArrayControles(Of TextBox)("TFechaUlt", Me)
            TTMuerto = New ArrayControles(Of TextBox)("TTMuerto", Me)
            TOrigen = New ArrayControles(Of TextBox)("TOrigen", Me)
            TDestino = New ArrayControles(Of TextBox)("TDestino", Me)
            TSupervisor = New ArrayControles(Of TextBox)("TSupervisor", Me)
            TEmpacador = New ArrayControles(Of TextBox)("TEmpacador", Me)
            TCosedor = New ArrayControles(Of TextBox)("TCosedor", Me)
            TGrupoEmp = New ArrayControles(Of TextBox)("TGrupoEmp", Me)
            TCodEmp = New ArrayControles(Of TextBox)("TCodEmp", Me)
            TCodEtiq = New ArrayControles(Of TextBox)("TCodEtiq", Me)
            FNuevoEmp = New ArrayControles(Of Button)("FNuevoEmp", Me)
            FLimpiar = New ArrayControles(Of Button)("FLimpiar", Me)

            For Each B As Button In FNuevoEmp.Values
                AddHandler B.Click, AddressOf FNuevoEmp_Click
            Next

            For Each B As Button In FLimpiar.Values
                AddHandler B.Click, AddressOf FLimpiar_Click
            Next
            For Each T As TextBox In TSacos.Values
                AddHandler T.TextChanged, AddressOf TSacos_TextChanged
            Next

            For Each T As TextBox In TAjuste.Values
                AddHandler T.TextChanged, AddressOf TAjuste_TextChanged
            Next
            For Each T As TextBox In TResiduo.Values
                AddHandler T.TextChanged, AddressOf TResiduo_TextChanged
            Next
            TSeg.Focus()

            Me.Show()

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub FNuevoEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Index As Int32 = FNuevoEmp.Index(CType(sender, Button))
        Try

            If Eval(TSacos(Index).Text) = 0 Then Exit Sub
            If Eval(TOPs(Index).Text) = 0 Then Exit Sub
            If TCodProd(Index).Text = "" Then Exit Sub


            MesDia = Now.ToString("MMdd")

            DEmpaque.AddNew()
            DEmpaque.RecordSet("MAQUINA") = Index
            DEmpaque.RecordSet("MesDia") = MesDia
            DEmpaque.RecordSet("OP") = Eval(TOPs(Index).Text)
            DEmpaque.RecordSet("FechaIni") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DEmpaque.RecordSet("DETALLE") = "AUTOM"
            DEmpaque.RecordSet("ACUMULADO") = AcumuladoB
            DEmpaque.RecordSet("ACUMULADO2") = 0
            DEmpaque.RecordSet("EMPACADOR") = CLeft(TEmpacador(Index).Text, 10)
            DEmpaque.RecordSet("Usuario") = CLeft(TSupervisor(Index).Text, 10)
            DEmpaque.RecordSet("COSEDOR") = CLeft(TCosedor(Index).Text, 10)
            DEmpaque.RecordSet("GRUPOEMP") = Eval(TGrupoEmp(Index).Text)
            DEmpaque.RecordSet("CODEMP") = CLeft(TCodEmp(Index).Text, 15)
            DEmpaque.RecordSet("CODETIQ") = CLeft(TCodEtiq(Index).Text, 15)



            'Asignamos la línea de inventario al empaque para visualización de sackoff por línea en la aplicación
            'chrpantallas

            DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodProd(Index).Text + "'")

            If DVarios.RecordCount > 0 AndAlso Not IsDBNull(DVarios.RecordSet("LINEA")) Then
                DEmpaque.RecordSet("LINEAINVENT") = DVarios.RecordSet("LINEA")
                DEmpaque.RecordSet("GRPBASE") = DVarios.RecordSet("GRPBASE")
            End If

            'Ponemos la fecha de inicio de la OP en el empaque para visualización del sackoff, para que no se descuadre si se empacó al
            'mes siguiente de la producción
            'DVarios.Open("Select * from OPS where OP='" + TOPs(Index).Text + "'")

            'If DVarios.RecordCount > 0 AndAlso Not IsDBNull(DVarios.RecordSet("FECHAINI")) Then
            '    DEmpaque.RecordSet("FECHAINIOP") = DVarios.RecordSet("FECHAINI")
            'End If

            DEmpaque.Update()

            EventoEmp("Crea registro empaque CONT: " + DEmpaque.RecordSet("CONT").ToString + " OP: " + TOPs(Index).Text)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub TSacos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSacos1.TextChanged, TSacos2.TextChanged
        If TSacos Is Nothing Then Return
        Dim Index As Int32 = TSacos.Index(CType(sender, TextBox))
        Try
            If Eval(TSacos(Index).Text) = 0 Then Exit Sub
            If Eval(TOPs(Index).Text) = 0 Then Exit Sub


            TPesoTot(Index).Text = (Eval(TSacos(Index).Text) * Eval(TPreset(Index).Text)).ToString
            TFechaUlt(Index).Text = Now.ToString("yyyy/MM/dd HH:mm:ss")

            EventoEmp("TSacos_TextChanged OP:" + TOPs(Index).Text + " SACOS: " + TSacos(Index).Text)

            DEmpaque.Open("Select * from EMPAQUE where OP='" + TOPs(Index).Text.Trim + "' AND MAQUINA=" + Index.ToString + " ORDER BY CONT desc")

            If DEmpaque.RecordCount = 0 Then
                DOPs.Open("select * from OPS where OP='" + TOPs(Index).Text + "'")
                If DOPs.RecordCount = 0 Then
                    EventoEmp("No se encontró OP: " + TOPs(Index).Text)
                    Return
                End If

                AcumuladoB = 0
                FNuevoEmp_Click(FNuevoEmp(Index), Nothing)
                DEmpaque.Refresh()
            End If

            If DEmpaque.RecordSet("Sacos") > Eval(TSacos(Index).Text) Then
                DOPs.Open("select * from OPS where OP='" + TOPs(Index).Text + "'")
                If DOPs.RecordCount = 0 Then
                    EventoEmp("No se encontró OP: " + TOPs(Index).Text)
                    Return
                End If
                AcumuladoB = 0
                FNuevoEmp_Click(FNuevoEmp(Index), Nothing)
                DEmpaque.Refresh()
            End If

            AcumuladoB = DEmpaque.RecordSet("ACUMULADO2")

            'Evaluamos si el registro de empaque ya fue recibido en bodega, si es asi se crea un registro nuevo

            If DEmpaque.RecordSet("RecEmp") Then
                DOPs.Open("select * from OPS where OP='" + TOPs(Index).Text + "'")
                If DOPs.RecordCount = 0 Then
                    EventoEmp("No se encontró OP: " + TOPs(Index).Text)
                    Return
                End If
                FNuevoEmp_Click(FNuevoEmp(Index), Nothing)
                DEmpaque.Refresh()
            End If


            If Eval(TSacos(Index).Text) <= DEmpaque.RecordSet("ACUMULADO2") Then
                EventoEmp("CANCELA ACTUALIZACIÓN SAC:" + TSacos(Index).Text + " ACUM2:" + DEmpaque.RecordSet("ACUMULADO2").ToString)
                Exit Sub ' No puede llegar el mismo valor de sacos o menor al registro actual desde el GSE
            End If


            DEmpaque.RecordSet("CodProd") = TCodProd(Index).Text
            If TNomProd(Index).Text <> "" Then DEmpaque.RecordSet("NOMPROD") = CLeft(TNomProd(Index).Text, 30)
            DEmpaque.RecordSet("OP") = Eval(TOPs(Index).Text)
            DEmpaque.RecordSet("ORIGEN") = Eval(TOrigen(Index).Text)
            DEmpaque.RecordSet("DESTINO") = CLeft(TDestino(Index).Text, 2)

            DEmpaque.RecordSet("ACUMULADO2") = Eval(TSacos(Index).Text)
            SacosAnt = DEmpaque.RecordSet("Sacos")
            DEmpaque.RecordSet("SACOS") = DEmpaque.RecordSet("ACUMULADO2") - DEmpaque.RecordSet("ACUMULADO")
            DEmpaque.RecordSet("PRESKG") = Eval(TPreset(Index).Text)
            DEmpaque.RecordSet("PESO") = DEmpaque.RecordSet("SACOS") * DEmpaque.RecordSet("PRESKG")
            DEmpaque.RecordSet("PRESEMP") = CLeft(TPresent(Index).Text, 2)

           

            'End If


            'Se revisa en la tabla PRODEQUIVALENTES si el producto tiene un codigo equivalente para ponerlo en el 
            'campo CodProd2

            'DVarios.Open("Select * from PRODEQUIVALENTES where PRESENT='" + DEmpaque.RecordSet("PRESEMP") + _
            '   "' and CODPROD='" + DEmpaque.RecordSet("CodProd") + "'")
            'If DVarios.RecordCount > 0 Then
            '    DEmpaque.RecordSet("CODPROD2") = DVarios.RecordSet("CODPRODEQUI")
            'End If

            DEmpaque.RecordSet("CODPROD2") = DEmpaque.RecordSet("CODPROD")
            DEmpaque.RecordSet("RESIDUO") = Eval(TResiduo(Index).Text)
            DEmpaque.RecordSet("SACOSAJUSTE") = Eval(TAjuste(Index).Text)
            DEmpaque.RecordSet("PESOAJUSTE") = (Eval(TAjuste(Index).Text) * Eval(TPreset(Index).Text)).ToString
            DEmpaque.RecordSet("FechaFin") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DEmpaque.RecordSet("MNTOS") = Format(DateDiff(DateInterval.Minute, CDate(DEmpaque.RecordSet("FECHAINI")), CDate(DEmpaque.RecordSet("FECHAFIN"))), "0.00")

            DEmpaque.Update()

            EventoEmp("Actualiza empaque OP: " + TOPs(Index).Text + " sacos: " + TSacos(Index).Text)

            'Descuento a tolvas

            If Eval(DEmpaque.RecordSet("ORIGEN")) > 0 Then
                SacosATolva = DEmpaque.RecordSet("Sacos") - SacosAnt
                DescTolvas(DEmpaque.RecordSet("ORIGEN"), -SacosATolva * DEmpaque.RecordSet("PRESKG"), DEmpaque.RecordSet("CodProd"), ProcesoPlanta.EMPAQUE, DEmpaque.RecordSet("OP"))
            End If

            DConfig.Refresh()

            If Eval(TTMuerto(Index).Text) < DConfig.RecordSet("TMUERTOENSAQ") Then TTMuerto(Index).Text = 0

            'Se llena la tabla de proceso en línea para el empaque

            DProcEnLinea.Open("Select * from PROCESOENLINEA where PROCESO='EMPAQUE' and MAQUINA=" + Index.ToString)

            If DProcEnLinea.RecordCount = 0 Then Return

            DProcEnLinea.RecordSet("OP") = Eval(TOPs(Index).Text)
            DProcEnLinea.RecordSet("PRESEMP") = CLeft(TPresent(Index).Text, 1)
            DProcEnLinea.RecordSet("NOMPROD") = CLeft(TNomProd(Index).Text, 30)
            DProcEnLinea.RecordSet("SACOS") = Eval(TSacos(Index).Text)
            DProcEnLinea.RecordSet("ORIGEN") = Eval(TOrigen(Index).Text)
            DProcEnLinea.RecordSet("DESTINO") = CLeft(TDestino(Index).Text, 2)
            DProcEnLinea.Update()

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try
            TSeg.Text = (Eval(TSeg.Text) + 1).ToString

            TTMuerto(1).Text = (Eval(TTMuerto(1).Text) + 1).ToString
            If Eval(TTMuerto(1).Text) > 100000 Then TTMuerto(1).Text = 1
            'TTMuerto(2).Text = (Eval(TTMuerto(2).Text) + 1).ToString
            'If Eval(TTMuerto(2).Text) > 100000 Then TTMuerto(2).Text = 1
            'TTMuerto(3).Text = (Eval(TTMuerto(3).Text) + 1).ToString
            'If Eval(TTMuerto(3).Text) > 100000 Then TTMuerto(3).Text = 1

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.WindowState = FormWindowState.Minimized
        'Me.Hide()
    End Sub


    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Me.Hide()
    End Sub

    'Private Sub mnRepeso1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepeso1.Click
    '    Try
    '        ServidorRep.ShowDialog()
    '    Catch ex As Exception
    '        MsgError(ex.ToString)
    '    End Try
    'End Sub

    'Private Sub mnRepeso2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepeso2.Click
    '    Try
    '        ServidorRep2.ShowDialog()
    '    Catch ex As Exception
    '        MsgError(ex.ToString)
    '    End Try
    'End Sub

    Private Sub Empaque_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub TAjuste_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Index As Int32 = TAjuste.Index(CType(sender, TextBox))
            'TSacos_TextChanged(TSacos(Index), Nothing)
            If Eval(TAjuste(Index).Text) = 0 OrElse Math.Abs(Eval(TAjuste(Index).Text)) > 10 Then Return
            DEmpaque.Open("Select TOP 1 * from EMPAQUE where MAQUINA=" + Index.ToString + " ORDER BY CONT desc")
            If DEmpaque.RecordCount = 0 Then Return

            DEmpaque.RecordSet("SACOSAJUSTE") = Eval(TAjuste(Index).Text)
            DEmpaque.RecordSet("PESOAJUSTE") = (Eval(TAjuste(Index).Text) * Eval(DEmpaque.RecordSet("PRESKG").ToString)).ToString
            DEmpaque.Update()

            Evento("Realiza Ajuste de EMPAQUE OP=" + DEmpaque.RecordSet("OP").ToString + " Ajuste " + TAjuste(Index).Text)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TResiduo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Index As Int32 = TResiduo.Index(CType(sender, TextBox))
            'TSacos_TextChanged(TSacos(Index), Nothing)
            If Eval(TResiduo(Index).Text) <= 0 OrElse Eval(TResiduo(Index).Text) > 40 Then Return
            DEmpaque.Open("Select TOP 1 * from EMPAQUE where  MAQUINA=" + Index.ToString + " ORDER BY CONT desc")
            If DEmpaque.RecordCount = 0 Then Return

            DEmpaque.RecordSet("RESIDUO") = Eval(TResiduo(Index).Text)
            DEmpaque.Update()
            Evento("Registra Residuo de EMPAQUE OP=" + DEmpaque.RecordSet("OP").ToString + " Residuo " + TResiduo(Index).Text)
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BAsigDatosEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAsigDatosEmp.Click
        Try
            AsignaDatosEmp.ShowDialog()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Public Sub FLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles FLimpiar1.Click, FLimpiar2.Click
        Try
            Dim Index As Int32 = FLimpiar.Index(CType(sender, Button))

            TOPs(Index).Text = ""
            TSacos(Index).Text = ""
            TCodProd(Index).Text = ""
            TPresent(Index).Text = ""
            TPreset(Index).Text = ""
            TPesoTot(Index).Text = ""
            TAjuste(Index).Text = ""
            TResiduo(Index).Text = ""
            TTMuerto(Index).Text = ""
            TOrigen(Index).Text = ""
            TDestino(Index).Text = ""
            TCodEmp(Index).Text = ""
            TCodEtiq(Index).Text = ""

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    'Private Sub mnServWEmpaque_Click(sender As System.Object, e As System.EventArgs) Handles mnServWEmpaque.Click
    '    ServWEmpaque.Show()
    'End Sub

    Private Sub BActualizar_Click(sender As System.Object, e As System.EventArgs) Handles BActualizar.Click
        Me.Show()
    End Sub

    'Private Sub BFrecRep_Click(sender As System.Object, e As System.EventArgs) Handles BFrecRep.Click
    '    Try
    '        RespInput = ""
    '        If Trim(ServWEmpaque.TMsg1.Text) = "EMPAQUE DETENIDO" OrElse Trim(ServWEmpaque.TMsg1.Text) = "" Then
    '            If InputBox.InputBox("Frecuencia de repeso", "Dígite la nueva frecuencia de repeso", RespInput) <> DialogResult.OK Then Return
    '            If RespInput <> "" Then
    '                DConfig.Open("select FRECREPESO from CONFIG")
    '                If DConfig.RecordCount > 0 Then
    '                    DConfig.Open("Update CONFIG set FRECREPESO = '" + RespInput + "'")
    '                    Evento("Modifica frecuencia de repeso para la empacadora uno.")
    '                    MsgBox("Se ha actualizado la frecuencia de repeso de empaque.", vbInformation)
    '                End If
    '            End If
    '        Else
    '            MsgBox("No es posible realizar o modificar la frecuencia de repeso ya que está en proceso. Finalice primero el proceso actual.", vbInformation)
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        MsgError(ex.ToString)
    '    End Try
    'End Sub

End Class