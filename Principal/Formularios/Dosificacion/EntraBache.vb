Option Explicit On

Imports System.Data.Common
Imports System.Data
Imports System.Windows.Forms
Imports ChronoSoftNet
Imports System.Threading.Thread
Imports ClassLibrary

Public Class EntraBache

    Private DConsumos As AdoSQL
    Private DBaches As AdoSQL
    Private DDatosFor As AdoSQL
    Private DCortes As AdoSQL
    Private DTolvas As AdoSQL
    Private DOPs As AdoSQL
    Private DConfig As AdoSQL
    Private DFor As AdoSQL
    Private DConsumosMed As AdoSQL
    Private DArt As AdoSQL
    Private DVarios As AdoSQL
    Private DEquipos As AdoSQL
    Private DFila() As DataRow
    Private DR As DataRow
    Private Row As Long
    'Private Cont2 As Long
    Private Conx As Connection
    Private ComImp As Int16
    Private FormLoad As Boolean
    Private DEtiqMic As AdoSQL
    Private NomImpresoraMicros As String


    Private Sub EntraBache_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            DBaches = New AdoSQL("Baches")
            DConsumos = New AdoSQL("Consumos")
            DDatosFor = New AdoSQL("DatosFor")
            DOPs = New AdoSQL("OPS")
            DCortes = New AdoSQL("Cortes")
            DTolvas = New AdoSQL("Tolvas")
            DConfig = New AdoSQL("Config")
            DFor = New AdoSQL("Formulas")
            DConsumosMed = New AdoSQL("ConsumosMed")
            DArt = New AdoSQL("Articulos")
            DVarios = New AdoSQL("VARIOS")
            DEquipos = New AdoSQL("EQUIPOS")
            DEtiqMic = New AdoSQL("ETIQMICROS")
            DBaches.Open("select * from BACHES where CONT=0 order by FECHA desc")
            DConfig.Open("select * from CONFIG")

            TPeso.Text = ""
            TCodForB.Text = ""
            TNomFor.Text = ""
            TCodFor.Text = ""
            TFecha.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")

            GBReimprimir.Visible = False
            Me.Width = Me.Width - GBReimprimir.Width
            'Valida si en la planta estan habilitadas las funcionalidades
            If ValidaFuncionalidad("Imprimir.Etiqueta.Micros", NombrePC, Me) Then
                GBReimprimir.Enabled = True
                GBEtiqueta.Enabled = True

                If ValidaFuncionalidad("Imprimir.Etiqueta.Usb", NombrePC, Me) Then
                    NomImpresoraMicros = ConfigParametros("NomImpMicros")
                    ChEtiqueta.Visible = True
                    GBEtiqueta.Visible = True
                    GBEtiqueta.Enabled = False
                    GBReimprimir.Visible = True
                    Me.Width = Me.Width + GBReimprimir.Width
                Else

                    DEquipos.Open("Select * from EQUIPOS where CodEquipo='Zebra.Micros'")

                    If DEquipos.Count = 0 Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " Falta Configuración serial impresora", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'MsgBox("Falta configuración para puerto serial de impresora, tabla equipos", vbCritical)
                        Return
                    Else
                        If (DEquipos.RecordSet("PCCONEXION") = Sesion Or DEquipos.RecordSet("PCCONEXION") = NombrePC) And FormLoad = False And ValidaPermiso("ReportarPremezclas") Then 'DRUsuario("RepPremezclas") Then
                            ComImp = DEquipos.RecordSet("COM")

                            If Eval(ComImp) = 0 Then
                                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " configuración puerto serial", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                'MsgBox("Error en configuración puerto serial", vbCritical)
                                Return
                            End If

                            Conx = New Connection(Connection.TipoConnection.Serial, ComImp.ToString)
                            Conx.Conect()
                            If Conx.State <> Connection.StateConnection.Connected Then
                                BImpEtiq.Enabled = False
                                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "conexión con la impresora", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                'MsgBox("Error, compruebe la conexión con la impresora", vbCritical)
                            End If

                            ChEtiqueta.Visible = True
                            GBEtiqueta.Visible = True
                            GBEtiqueta.Enabled = False
                            GBReimprimir.Visible = True
                            Me.Width = Me.Width + GBReimprimir.Width

                        End If

                    End If
                End If

            End If

            'If DRUsuario("RepPremezclas") And DRUsuario("RepBacheMan") = False Then
            If ValidaPermiso("ReportarPremezclas") AndAlso ValidaPermiso("ReportarBacheManual") = False Then
                OPMayores.Enabled = False
                OPPremezclas.Enabled = True
                OPPremezclas.Checked = True
                'ElseIf DRUsuario("RepPremezclas") = False And DRUsuario("RepBacheMan") Then
            ElseIf ValidaPermiso("ReportarPremezclas") = False AndAlso ValidaPermiso("ReportarBacheManual") Then
                OPMayores.Enabled = True
                OPPremezclas.Enabled = False
                OPMayores.Checked = True
                'ElseIf DRUsuario("RepPremezclas") And DRUsuario("RepBacheMan") Then
            ElseIf ValidaPermiso("ReportarPremezclas") AndAlso ValidaPermiso("ReportarBacheManual") Then
                OPMayores.Enabled = True
                OPPremezclas.Enabled = True
            Else
                OPMayores.Enabled = False
                OPPremezclas.Enabled = False
            End If

            TextNum(TBaches)
            FormLoad = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click

        Try
            If TCodFor.Text = "" OrElse TCodForB.Text = "" OrElse TPeso.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " fórmula "), MessageBoxButtons.OK + MessageBoxIcon.Information)
                Exit Sub
            End If

            If Val(TBaches.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " baches"), MessageBoxButtons.OK + MessageBoxIcon.Information)
            Else
                DOPs.Open("select * from OPS where OP=" + TOPs.Text + " and FINALIZADO<>'S'")
                If DOPs.Count = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.OP_FINALIZADA), MessageBoxButtons.OK + MessageBoxIcon.Information)
                    Exit Sub
                Else
                    ' Verificamos que los baches a ingresar no superen la cantidad de baches programados en la OP
                    If OPMayores.Checked = True Then
                        If (Val(TBaches.Text) + DOPs.RecordSet("Real")) > DOPs.RecordSet("Meta") Then
                            MsgBox(DevuelveEvento(CodEvento.OP_BACHESCOMPLETOS), MessageBoxButtons.OK + MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                    If OPPremezclas.Checked = True Then
                        If (Val(TBaches.Text) + DOPs.RecordSet("Realmed")) > DOPs.RecordSet("Meta") Then
                            MsgBox(DevuelveEvento(CodEvento.OP_BACHESCOMPLETOS), MessageBoxButtons.OK + MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                End If
            End If
            'Incrementamos el contador 2 de micros de la tabla configvar para ponerlo en la tabla consumosmed

            If Val(ReadConfigVar("Consec2Micros")) + 1 > 999999 Then
                WriteConfigVar("Consec2Micros", "0")
            End If

            WriteConfigVar("Consec2Micros", (Val(ReadConfigVar("Consec2Micros")) + 1).ToString)

            'Cont2 = Val(ReadConfigVar("Consec2Micros"))

            For i As Integer = 1 To Eval(TBaches.Text)
                If OPPremezclas.Checked Then
                    FBachesPrem_Click(Nothing, Nothing)
                Else
                    FBaches_Click(Nothing, Nothing)
                End If
            Next
            'Se mandan a imprimir todas las etiquetas
            If OPPremezclas.Checked Then
                If GBEtiqueta.Visible Then
                    BImpEtiq_Click(Nothing, Nothing)
                End If
            End If

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)
            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPs.KeyDown
        Try
            If e.KeyCode <> Keys.Enter Then Exit Sub

            If OPPremezclas.Checked = False And OPMayores.Checked = False Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "proceso premezclas o mayores", MessageBoxButtons.OK + MessageBoxIcon.Information)
                Exit Sub
            End If

            DOPs.Open("select * from OPS where OP='" + TOPs.Text + "'")

            If DOPs.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "la OP no se encuentra", MessageBoxButtons.OK + MessageBoxIcon.Information)
                Return
            End If

            If DOPs.RecordSet("LINEAINVENT") <> "GANADERIA" And ((DOPs.RecordSet("FINALIZADO") = "S" Or DOPs.RecordSet("FINPLANILLA") = "S")) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "la OP ya esta finalizada", MessageBoxButtons.OK + MessageBoxIcon.Error)
                Return
            End If


            DFor.Open("Select * from FORMULAS where CODFOR='" + DOPs.RecordSet("CODFOR") + "' and LP='" + DOPs.RecordSet("LP") + "'")

            If DFor.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + ", la Fórmula no se encuentra", MessageBoxButtons.OK + MessageBoxIcon.Error)
                Exit Sub
            End If

            TLP.Text = DOPs.RecordSet("LP")
            TCodFor.Text = DFor.RecordSet("CodFor")
            TCodForB.Text = DFor.RecordSet("CodForB")
            TNomFor.Text = DFor.RecordSet("NomFor")
            TPorc.Text = DOPs.RecordSet("Porc")

            TBaches.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodFor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodFor.TextChanged
        Try

            If TCodFor.Text = "" Then Exit Sub

            If OPPremezclas.Checked OrElse Funcion_PlantasExternas Then
                DDatosFor.Open("select * from DATOSFOR where TIPOMAT=6 AND CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
            Else
                'If Funcion_PlantasExternas Then
                '    DDatosFor.Open("select * from DATOSFOR where TIPOMAT=6 AND CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                'Else
                DDatosFor.Open("select * from DATOSFOR where TIPOMAT<>6 AND CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")
                'End If

            End If

            If DDatosFor.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + ", formula no existe o no tiene ingredientes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            AsignaDataGrid(DGEntraBach, DDatosFor.DataTable)

            TPeso.Text = SumColumn(DGEntraBach, "PESOMETA").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FBaches_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FBaches.Click
        Try

            DConfig.Refresh()
            TContador.Text = DConfig.RecordSet("ConsecMan") + 1
            DBaches.Open("Select * from BACHES where BACHEAUTOMATICO=0 AND CONT=" + TContador.Text)
            Do While DBaches.Count > 0
                TContador.Text = Val(TContador.Text) + 1
                DBaches.Open("Select * from BACHES where BACHEAUTOMATICO=0 AND CONT=" + TContador.Text)
            Loop

            DBaches.AddNew()

            DBaches.RecordSet("CONT") = Eval(TContador.Text)
            DBaches.RecordSet("CodForB") = CLeft(TCodForB.Text, 15)
            DBaches.RecordSet("CodFor") = CLeft(TCodFor.Text, 15)
            DBaches.RecordSet("NomFor") = CLeft(TNomFor.Text, 30)
            DBaches.RecordSet("OP") = CLeft(TOPs.Text, 15)
            DBaches.RecordSet("Fecha") = CLeft(TFecha.Text, 20)
            DBaches.RecordSet("FechaFIN") = CLeft(TFecha.Text, 20)
            DBaches.RecordSet("PesoReal") = Eval(TPeso.Text)
            DBaches.RecordSet("PesoMeta") = Eval(TPeso.Text)
            DBaches.RecordSet("Factor") = Eval(TPorc.Text)
            DBaches.RecordSet("LP") = CLeft(TLP.Text, 15)

            DOPs.RecordSet("Real") = DOPs.RecordSet("Real") + 1
            If Eval(DOPs.RecordSet("FECHAINI").ToString) = 0 Then DOPs.RecordSet("FECHAINI") = CLeft(TFecha.Text, 20)
            DOPs.RecordSet("FECHAFIN") = CLeft(TFecha.Text, 20)

            If DOPs.RecordSet("REAL") >= DOPs.RecordSet("META") Then
                DOPs.RecordSet("FINALIZADO") = "S"
                DOPs.RecordSet("COMPLETO") = "S"
            End If

            DBaches.RecordSet("BACHESMETA") = DOPs.RecordSet("META")
            DBaches.RecordSet("Bache") = DOPs.RecordSet("REAL")
            DBaches.RecordSet("LINEA") = DOPs.RecordSet("LINEA")
            'DBaches.RecordSet("PESOMETA") = DOPs.RecordSet("TAMBACHE")
            DBaches.RecordSet("PROGRAMA") = DOPs.RecordSet("PROGRAMA")
            DBaches.RecordSet("PRODUCTO") = DOPs.RecordSet("CODPROD")
            DBaches.RecordSet("USUARIO") = CLeft(UsuarioPrincipal, 20)
            DBaches.RecordSet("BACHEAUTOMATICO") = 0


            'Asignamos la línea de inventario al bache para visualización de sackoff por línea en la aplicación
            'chrpantallas


            If Not IsDBNull(DBaches.RecordSet("PRODUCTO")) Then
                DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + DBaches.RecordSet("PRODUCTO") + "'")

                If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("LINEA")) Then
                    DBaches.RecordSet("LINEAINVENT") = DVarios.RecordSet("LINEA")
                End If
            End If

            DBaches.RecordSet("ESTADO") = 10

            DBaches.Update(Me)
            DOPs.Update(Me)

            Evento("Reporte Manual Entra.Bache Form." + TCodFor.Text + " N." + TContador.Text)

            DConsumos.Open("delete from CONSUMOS where CONT=" + TContador.Text)

            DConsumos.Open("Select * from CONSUMOS WHERE cont=0")

            If Funcion_PlantasExternas Then
                DDatosFor.Open("select * from DATOSFOR where TIPOMAT=6 and CODFOR='" + Trim(TCodFor.Text) + "' and LP='" + TLP.Text + "'")
            Else
                DDatosFor.Open("select * from DATOSFOR where CODFOR='" + Trim(TCodFor.Text) + "' and LP='" + TLP.Text + "' and TIPOMAT<>6") 'and A='PR'
            End If


            For Each Fila As DataRow In DDatosFor.DataTable.Rows



                DConsumos.AddNew()

                DConsumos.RecordSet("CONT") = Eval(TContador.Text)
                DConsumos.RecordSet("CodForB") = TCodForB.Text
                DConsumos.RecordSet("CodFor") = TCodFor.Text
                DConsumos.RecordSet("Paso") = Fila("PASO")
                DConsumos.RecordSet("CodMat") = Fila("CODMAT")
                DConsumos.RecordSet("CodMatB") = Fila("CODMATB")
                DConsumos.RecordSet("NOMMAT") = Fila("NOMMAT")
                DConsumos.RecordSet("PESOMETA") = Eval((Fila("PESOMETA") * Eval(TPorc.Text) / 100))
                DConsumos.RecordSet("PESOREAL") = Eval(Fila("PESOMETA") * Eval(TPorc.Text) / 100)



                'Si el ingrediente es la premezcla, se busca el peso real en la tabla consumosmed, y se
                'actualiza el contador a los registros
                If Fila("TIPOMAT") = 7 Then
                    DVarios.Open("Select sum(PESOREAL) as SUMPESOREAL from CONSUMOSMED where OP='" + TOPs.Text + "' and BACHE=" + DOPs.RecordSet("REAL").ToString)

                    If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("SUMPESOREAL")) Then

                        If Math.Abs(DVarios.RecordSet("SUMPESOREAL") - DConsumos.RecordSet("PESOMETA")) < 0.5 Then
                            DConsumos.RecordSet("PESOREAL") = DVarios.RecordSet("SUMPESOREAL")
                        End If
                        DConsumos.RecordSet("LOTE") = CLeft(TOPs.Text, 15)

                        DVarios.Open("Update CONSUMOSMED set CONT=" + TContador.Text + " where OP='" + TOPs.Text + "' and BACHE=" + DOPs.RecordSet("REAL").ToString)

                    End If
                End If
                DConsumos.RecordSet("ALARMAS") = 126
                DConsumos.RecordSet("TIPOMAT") = 12

                CortesLote(DConsumos.RecordSet("CODMAT").ToString, DConsumos.RecordSet("PESOREAL"), LoteCortesMP, ContCortesMP, UbicLoteMP)
                If LoteCortesMP <> "" AndAlso ContCortesMP <> "" Then
                    DConsumos.RecordSet("CORTELOTE") = ContCortesMP
                    DConsumos.RecordSet("Lote") = LoteCortesMP
                    DConsumos.RecordSet("UbicLote") = UbicLoteMP
                End If

                ' Actualiza el inventario de tolvas
                DTolvas.Open("select * from TOLVAS where CODINT='" + Fila("CODMAT").ToString + "'")

                If DTolvas.Count > 0 Then
                    DescTolvas(DTolvas.RecordSet("TOLVA"), -DConsumos.RecordSet("PESOREAL"), DConsumos.RecordSet("CODMAT").ToString, ProcesoPlanta.DOSIFICACION)
                End If
                DConsumos.Update(Me)

                If Not IsDBNull(DConsumos.RecordSet("LOTE")) Then
                    'Inventario(DConsumos.RecordSet("CODMAT"), -DConsumos.RecordSet("PESOREAL"), TipoInv.CHRONOS, DConsumos.RecordSet("LOTE"), DetOperacion.INGMANUAL, , , , , , , , Usuario)

                    'Objeto usado para realizar el descuento del inventario
                    Dim Invent As New DescInvent

                    With Invent
                        .CodInt = DConsumos.RecordSet("CODMAT")
                        .Cantidad = -DConsumos.RecordSet("PESOREAL")
                        .TipoInv = DescInvent.TipoInvent.CHRONOS
                        .Lote = DConsumos.RecordSet("LOTE")
                        .Detalle = DetOperacion.INGMANUAL
                        .Usuario = UsuarioPrincipal
                        .Inventario()
                    End With
                End If
            Next

            DConfig.Refresh()
            DConfig.RecordSet("ConsecMan") = TContador.Text
            DConfig.Update(Me)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        If GBEtiqueta.Enabled Then
            If DEquipos.RecordSet("PCCONEXION") = Sesion Or DEquipos.RecordSet("PCCONEXION") = NombrePC Then
                If Conx.State = Connection.StateConnection.Connected Then Conx.Close()
            End If
        End If
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            ChPlanta2.Checked = False
            TFecha.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialesToolStripMenuItem.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub


    Private Sub OPMayores_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles OPMayores.CheckedChanged
        Try
            If OPMayores.Checked Then
                LInfo1.Visible = True
                LInfo2.Visible = True
            Else
                LInfo1.Visible = False
                LInfo2.Visible = False
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FBachesPrem_Click(sender As System.Object, e As System.EventArgs) Handles FBachesPrem.Click
        Try
            'Adelantamos los registros de la tabla consumosMED

            'Dim Contador As Integer = Val(ReadConfigVar("CONSECMIC")) + 1

            ' DConsumosMed.Open("Select * from CONSUMOSMED where CONT=" + Contador.ToString)

            'Do While DConsumosMed.Count > 0
            '    Contador += 1
            '    DConsumosMed.Open("Select * from CONSUMOSMED where CONT=" + Contador.ToString)
            'Loop

            DOPs.RecordSet("RealMed") = DOPs.RecordSet("RealMed") + 1

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "' and TIPOMAT=6 ") 'and A='PR'

            For Each RecordSet As DataRow In DDatosFor.Rows

                'Agrega los consumos de la premezcla en la tabla ConsumosMed

                DConsumosMed.Open("select * from CONSUMOSMED where BACHE=" + DOPs.RecordSet("RealMed").ToString + " and OP='" + TOPs.Text + "' and CODMAT='" + RecordSet("CODMAT") + "' and PESOMETA=" + Replace(RecordSet("PESOMETA").ToString, ",", "."))
                If DConsumosMed.Count = 0 Then
                    DConsumosMed.AddNew()
                    DConsumosMed.RecordSet("CONT") = TOPs.Text + DOPs.RecordSet("RealMed").ToString
                    DConsumosMed.RecordSet("CONT2") = DConsumosMed.RecordSet("CONT")
                    DConsumosMed.RecordSet("CONTBASC") = DConsumosMed.RecordSet("CONT")
                    DConsumosMed.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
                    DConsumosMed.RecordSet("FACTOR") = TPorc.Text
                    DConsumosMed.RecordSet("CODFORB") = RecordSet("CODFORB")
                    DConsumosMed.RecordSet("CODFOR") = RecordSet("CODFOR")
                    DConsumosMed.RecordSet("NOMFOR") = CLeft(DFor.RecordSet("NOMFOR"), 30)
                    DConsumosMed.RecordSet("CODMAT") = RecordSet("CODMAT")
                    DConsumosMed.RecordSet("CODMATB") = RecordSet("CODMATB")
                    DConsumosMed.RecordSet("NOMMAT") = RecordSet("NOMMAT")
                    DConsumosMed.RecordSet("TIPOMAT") = RecordSet("TIPOMAT")
                    DConsumosMed.RecordSet("PESOMETA") = RecordSet("PESOMETA")
                    DConsumosMed.RecordSet("PESOREAL") = RecordSet("PESOMETA")
                    DConsumosMed.RecordSet("OP") = TOPs.Text
                    DConsumosMed.RecordSet("BACHE") = DOPs.RecordSet("RealMed").ToString
                    DConsumosMed.RecordSet("USUARIO") = CLeft(UsuarioPrincipal, 20)

                    DConsumosMed.RecordSet("ESTADO") = 10
                    DConsumosMed.RecordSet("PLANTA2") = ChPlanta2.Checked
                    CortesLote(DConsumosMed.RecordSet("CODMATB").ToString, DConsumosMed.RecordSet("PESOREAL"), LoteCortesMP, ContCortesMP, UbicLoteMP)
                    If LoteCortesMP <> "" AndAlso ContCortesMP <> "" Then
                        DConsumosMed.RecordSet("CORTELOTE") = ContCortesMP
                        DConsumosMed.RecordSet("Lote") = LoteCortesMP
                        DConsumosMed.RecordSet("UbicLote") = UbicLoteMP
                    End If

                    ''Generamos el detalle del inventario para la premezcla

                    'If Not IsDBNull(DConsumosMed.RecordSet("LOTE")) Then
                    '    Inventario(DConsumosMed.RecordSet("CODMAT"), -DConsumosMed.RecordSet("PESOREAL"), TipoInv.CHRONOS, DConsumosMed.RecordSet("LOTE"), DetOperacion.CONSUMO, , , , , , , , Usuario)
                    'End If


                    DConsumosMed.Update(Me)
                    'DOPs.Update(Me)


                    'Sleep(10)

                    'Application.DoEvents()
                End If
            Next

            DOPs.Update(Me)

            'WriteConfigVar("CONSECMIC", Contador.ToString)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ChEtiqueta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChEtiqueta.CheckedChanged
        Try
            If ChEtiqueta.Checked = True Then
                GBEtiqueta.Enabled = True
            Else
                GBEtiqueta.Enabled = False
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImpEtiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImpEtiq.Click
        Try
            Dim TramaImpresion As String
            Dim Renglon() As String
            Dim Tipo As String = ""

            'Validaciones

            'If CUbicacion.Text = "" Then
            '    MsgBox("Campo ubiación de lote vacío, no se puede imprimir la etiqueta", vbInformation)
            '    Return
            'End If
            If TOPs.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "OP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("Campo OP vacío, no se puede imprimir la etiqueta", vbInformation)
                Return
            End If

            If TNoCopias.Value = 0 Then Return

            Dim i As Integer

            TramaImpresion = ""

            If ChPlanta2.Checked Then

                If ValidaFuncionalidad("Imprimir.Etiqueta.Usb", NombrePC, Me) Then
                    ImprimirUSB(TOPs.Text, "0", Val(TNoCopias.Value))
                Else
                    TramaImpresion = TramaEtiquetaPR(TOPs.Text, "0")
                    Renglon = Split(TramaImpresion, vbNewLine)
                    For j = 0 To TNoCopias.Value - 1
                        For i = 0 To UBound(Renglon)
                            Conx.SendData(Renglon(i) + vbNewLine)
                            Sleep(10)
                        Next
                        Sleep(100)
                    Next
                End If
            Else
                'Se buscan todos los contadores de consumosmed que no han sido escaneados
                DConsumosMed.Open("Select DISTINCT(CONT2) AS CONT2,OP from CONSUMOSMED where ETIQIMPRESA=0 and ETIQLEIDA=0 AND OP='" + TOPs.Text + "' ORDER BY CONT2")

                If DConsumosMed.Count = 0 Then
                        MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "No hay baches disponibles para generar etiquetas", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'MsgBox("No hay baches disponibles para generar etiquetas", vbCritical)
                        Return
                    End If

                For Each Fila As DataRow In DConsumosMed.Rows

                    If ValidaFuncionalidad("Imprimir.Etiqueta.Usb", NombrePC, Me) Then
                        ImprimirUSB(TOPs.Text, Fila("CONT2").ToString)
                    Else
                        TramaImpresion = TramaEtiquetaPR(Fila("OP"), Fila("CONT2").ToString)
                        Renglon = Split(TramaImpresion, vbNewLine)
                        For i = 0 To UBound(Renglon)
                            Conx.SendData(Renglon(i) + vbNewLine)
                            Sleep(10)
                        Next
                    End If
                    Sleep(100)
                    DVarios.Open("Update CONSUMOSMED set ETIQIMPRESA=1 where CONT2=" + Fila("CONT2").ToString)
                Next

                'Se actualizan todos los consumosmed en el campo ETIQLEIDA=1 para los consumos de planta 2

                DVarios.Open("Update CONSUMOSMED set ETIQLEIDA=1 where PLANTA2=1")
                End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPReimp_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TOPReimp.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return
            If Val(TOPReimp.Text) = 0 Then Return
            DOPs.Open("Select * from OPS WHERE OP='" + TOPReimp.Text + "'")

            If DOPs.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "La OP no se encuentra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("La OP ingresada no existe", vbInformation)
                Return
            End If

            DConsumosMed.Open("select MIN(OP) as OP,MIN(CodFor) AS CodFor,min(NomFor) as NomFor,min(Bache) as Bache,Cont2 from ConsumosMed where ETIQLEIDA=0 AND OP='" + TOPReimp.Text + "' Group by Cont2")

            If DConsumosMed.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "La OP no tiene baches de micros disponibles para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("La OP Ingresada no tiene baches de micros disponibles para imprimir", vbInformation)
                Return
            End If

            AsignaDataGrid(DGConsumosMed, DConsumosMed.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BReimprimir_Click(sender As System.Object, e As System.EventArgs) Handles BReimprimir.Click
        Try

            Dim TramaImpresion As String
            Dim Renglon() As String
            For Each Fila As DataGridViewRow In DGConsumosMed.SelectedRows

                If ValidaFuncionalidad("Imprimir.Etiqueta.Usb", NombrePC, Me) Then
                    ImprimirUSB(Fila.Cells("OP").Value.ToString, Fila.Cells("CONT2").Value.ToString)
                Else
                    TramaImpresion = TramaEtiquetaPR(Fila.Cells("OP").Value.ToString, Fila.Cells("CONT2").Value.ToString)
                    If IsNothing(TramaImpresion) Then Return
                    Renglon = Split(TramaImpresion, vbNewLine)
                    For i = 0 To UBound(Renglon)
                        Conx.SendData(Renglon(i) + vbNewLine)
                        Sleep(10)
                    Next
                End If
                Sleep(100)
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub ImprimirUSB(ByVal OP As String, ByVal Cont As String, Optional ByVal NoCopias As Int16 = 1)
        Try
            'Dim Secuencia As Integer = Val(TSecuencia.Text)
            Dim j As Integer
            Dim Rellenar As Char = "0"
            Dim CodigoBarras As New BarCode
            Dim RepSap As CrystalRep
            Dim Separador As String = "K"
            Dim Fecha As String = ""
            Dim Peso As String
            Dim CodigoPx As String
            'RepSap = New CrystalRep

            If Val(OP) = 0 Then Return
            DOPs.Open("Select * from OPS where OP='" + OP + "'")

            DDatosFor.Open("select * from DATOSFOR where CODFOR='" + DOPs.RecordSet("CODFOR") + "' and LP='" + DOPs.RecordSet("LP") + "' and TIPOMAT=7")

            If DDatosFor.Count = 0 Then
                MsgBox("La fórmula " + DOPs.RecordSet("CODFOR") + " versión " + DOPs.RecordSet("LP") + " no se encuentra o no contiene ingredientes tipo PR", MsgBoxStyle.Critical)
                Return
            End If

            Peso = DDatosFor.RecordSet("PESOMETA").ToString
            CodigoPx = DDatosFor.RecordSet("CODMAT").ToString

            For j = 0 To TNoCopias.Value - 1
                Dim Bm As Bitmap
                Application.DoEvents()

                'Codigo de barras del Codigo DE Material
                CodigoBarras.DescCarpeta = "MP"
                CodigoBarras.NombreArchivoBMP = "CodBarMicros.bmp"

                Bm = CodigoBarras.Code128(OP + Separador + Cont, BarCode.Code128SubTypes.CODE128, True, 70)

                CodigoBarras.Guardar(Bm)
                RepSap = New CrystalRep
                With RepSap
                    .ServerName = ServidorSQL
                    .DataBaseName = NomDB
                    .UserId = UserDB
                    .Password = PWD
                    .Formulas(0) = "NOMFOR='" + DOPs.RecordSet("NOMFOR") + "'"
                    .Formulas(1) = "FECHA='" + FechaC() + "'"
                    .Formulas(2) = "PLANTA='" + Planta + "'"
                    .Formulas(3) = "CODIGOPX='" + CodigoPx + "'"
                    .Formulas(4) = "OP='" + OP + "'"
                    .Formulas(5) = "PESO='" + Peso + " Kg'"
                    .Formulas(6) = "OBSERVOP='" + DOPs.RecordSet("OBSERVOP") + "'"
                    .Formulas(7) = "CODFOR='" + DOPs.RecordSet("CODFOR") + "'"
                    .Formulas(8) = "LP='" + DOPs.RecordSet("LP") + "'"
                    .Destination = CrystalRep.Destinacion.crToPrinter
                    .WindowState = FormWindowState.Maximized
                    '.ChoosePrint = True
                    .MaximizeBox = True
                    .MinimizeBox = True
                    .Copias = 1

                End With

                RepSap.ReportFileName = RutaRep + "rpEtiqMicros.rpt"
                'Se envian el nombre de la impresora, el  ancho en centesimas de pulgada, el alto en centesimas de pulgada
                '1 mm = 3.93701 centesimas de pulgada, las dimensiones de la etiqueta son Ancho=100 mm, alto=50 mm
                RepSap.PrintReport(NomImpresoraMicros, 393.701, 196.8505)
            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class