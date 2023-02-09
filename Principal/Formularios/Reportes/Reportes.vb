Public Class Reportes
    Private DConfigReportes As AdoSQL
    Private DConsultas As AdoSQL
    Private DVarios As AdoSQL
    Private DFor As AdoSQL
    Private DArt As AdoSQL
    Private DBaches As AdoSQL
    Private DConsumosMed As AdoSQL
    Private DEmp As AdoSQL
    Private DHumedades As AdoSQL
    Private DTurnos As AdoSQL
    Private DTrazabSec As AdoSQL
    Private Rep1 As CrystalRep


    Private FormLoad As Boolean
    Private OKFecha As Boolean = True
    Private OKBCDate As Boolean
    Private FechaIni As String
    Private FechaFin As String
    Private PlantaPrem As String

    'Variables informe de producción
    Private OPLiq, NomLiq, SackoffLiq, SackOffPor As String
    Private BachesMezclados, Corridas, TonLimpieza As String
    Private OPGranel, CantGranel As String
    Private Datos, Datos1 As String

    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If FormLoad Then Return

        If Not Funcion_PlantasExternas Then CPlantExternas.Enabled = False ' Habilitar el combobox para filtrar por Planta EXterna

        OP24Horas_Click(Nothing, Nothing)
        CbLineaExterna.SelectedText = "NO"
        CLimpieza.SelectedText = "NO"

        DVarios = New AdoSQL("VARIOS")
        DArt = New AdoSQL("ARTICULOS")
        DFor = New AdoSQL("FORMULAS")
        DHumedades = New AdoSQL("HUMEDADES")
        DTurnos = New AdoSQL("TURNOS")
        DTrazabSec = New AdoSQL("TRAZABSEC")
        DBaches = New AdoSQL("TRAZABSEC")
        DConsumosMed = New AdoSQL("CONSUMOSMED")
        DEmp = New AdoSQL("EMPAQUE")


        DConsultas = New AdoSQL("CONSULTAS")
        DConsultas.Open("Select * from CONSULTAS")

        DConfigReportes = New AdoSQL("CONFIGREPORTES")

        DConfigReportes.Open("select * from CONFIGREPORTES where CONTENEDOR = 'ENTRADA - TRASLADO MATERIA PRIMA'  order by TEXTOBOTON")
        CrearBotones(DConfigReportes.DataTable, DConfigReportes.RecordSet("CONTENEDOR"))

        DConfigReportes.Open("select * from CONFIGREPORTES where CONTENEDOR = 'DOSIFICACION PREMEZCLAS Y PESADA MENOR'  order by TEXTOBOTON")
        CrearBotones(DConfigReportes.DataTable, DConfigReportes.RecordSet("CONTENEDOR"))

        DConfigReportes.Open("select * from CONFIGREPORTES where CONTENEDOR = 'DOSIFICACION MAYORES'  order by TEXTOBOTON")
        CrearBotones(DConfigReportes.DataTable, DConfigReportes.RecordSet("CONTENEDOR"))

        DConfigReportes.Open("select * from CONFIGREPORTES where CONTENEDOR = 'EMPAQUE'  order by TEXTOBOTON")
        CrearBotones(DConfigReportes.DataTable, DConfigReportes.RecordSet("CONTENEDOR"))

        DConfigReportes.Open("select * from CONFIGREPORTES where CONTENEDOR = 'PELETIZADO'  order by TEXTOBOTON")
        CrearBotones(DConfigReportes.DataTable, DConfigReportes.RecordSet("CONTENEDOR"))

        DConfigReportes.Open("select * from CONFIGREPORTES where CONTENEDOR = 'TIEMPOS DE PROCESO - OTROS'  order by TEXTOBOTON")
        CrearBotones(DConfigReportes.DataTable, DConfigReportes.RecordSet("CONTENEDOR"))

        FormLoad = True

    End Sub

    Private Sub CrearBotones(ByVal Registros As DataTable, ByVal nContenedor As String)

        Dim X = 0
        Dim Y = 0

        Dim selTabPage = New TabPage
        With selTabPage
            .Name = nContenedor
            .Text = nContenedor
        End With

        TabControlRep.TabPages.Add(selTabPage)

        For Each Recordset As DataRow In Registros.Rows
            Dim Bt As Button = New Button()
            With Bt
                .Name = Recordset("NOMBREBOTON").ToString
                .Location = New Point(10 + X * 260, 30 + Y * 29)
                .Size = New Size(23, 23)
                .BackColor = Color.Silver
                .Enabled = Recordset("ACTIVO")
                .Parent = selTabPage
                If Recordset("ACTIVO") Then .BackColor = Color.Gray
            End With

            Dim Lbl As Label = New Label()
            With Lbl
                .Name = "L" + Recordset("NOMBREBOTON").ToString
                .Location = New Point(38 + X * 260, 35 + Y * 29)
                '.Size = New Size(205, 13)
                .AutoSize = True
                .Text = Recordset("TEXTOBOTON")
                .BackColor = SystemColors.Control
                .Enabled = Recordset("ACTIVO")
                .Parent = selTabPage
            End With

            Y += 1
            If Y Mod 15 = 0 Then
                X += 1
                Y = 0
            End If

            AddHandler Bt.Click, AddressOf BReportes_Click

        Next

    End Sub

    Private Sub BReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            Dim Boton As Button = CType(sender, Button)
            Dim nBoton As String = Boton.Name
            Dim TabActual As String = TabControlRep.SelectedTab.Name
            Dim LineaExterna As String = "False"


            Dim PlantaExt As String = CPlantExternas.Text

            If Funcion_PlantasExternas Then
                Select Case PlantaExt
                    Case "Girardota"
                        PlantaPrem = "GIR"

                    Case "Santa Rosa de Osos"
                        PlantaPrem = "STRO"

                    Case " Yarumal"
                        PlantaPrem = "YAR"

                End Select

            End If


            BCDate_Click(Nothing, Nothing)
            If OKFecha = False Then Exit Sub

            If CbLineaExterna.Text = "SI" Then LineaExterna = "True"

            Select Case TabActual
'-------------------------------------------------------------------------------------------
' Reportes del grupo "Dosificacion Mayores"
'-------------------------------------------------------------------------------------------
                Case "Dosificacion Mayores"

                    Select Case nBoton
                        Case "Consumos_Agrupados_Cliente"
                            Rep1.ReportFileName = RutaRep + "rpconcli.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Consumos_Agrupados_Lote"
                            Rep1.ReportFileName = RutaRep + "rpConLote.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Consumos_Agrupados_Modo_MP"
                            If CModoMat.Text = "" Then
                                MsgBox("Seleccione un modo de Material", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rpConModoMat.rpt"
                            'SentenciaLineasPm = "{CConsumos.LineaExterna} = " + LineaExterna + " AND {CCONSUMOS.BASCULA}='8')"                          
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna + " AND {CCONSUMOS.A}='" + CModoMat.Text + "'"

                        Case "Consumos_Agrupados_MP"
                            Rep1.ReportFileName = RutaRep + "rpcongen.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Consumos_Agrupados_OP"
                            Rep1.ReportFileName = RutaRep + "rpconop.rpt"

                            If TOPs.Text = "" Then 'Todas las OP
                                Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                            Else    'Una sola OP
                                Rep1.SelectionFormula = "{CCONSUMOS.OP}='" + Trim(Eval(TOPs.Text)) + "' AND " + "{CConsumos.LineaExterna} = " + LineaExterna

                            End If

                        Case "Consumos_Agua_OP"
                            Rep1.ReportFileName = RutaRep + "rptotopAgua.rpt"
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CCONSUMOSAGUA.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Consumos_Liquidos_Agrupados"
                            Rep1.SelectionFormula = ""
                            Rep1.ReportFileName = RutaRep + "rpconsLq.rpt"
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CRepLiquidos.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Consumos_Liquidos_Agrupados_OP"
                            Rep1.SelectionFormula = ""
                            Rep1.ReportFileName = RutaRep + "rpconsLqOP.rpt"
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CRepLiquidos.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Consumos_Liquidos_Listado"
                            Rep1.SelectionFormula = ""
                            Rep1.ReportFileName = RutaRep + "rpListconsLq.rpt"
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CRepLiquidos.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Consumos_Agua_Listado_Baches"
                            Rep1.ReportFileName = RutaRep + "rplisbacAgua.rpt"
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CCONSUMOSAGUA.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Consumos_Listado_MP"
                            If TCodMat.Text = "" Then
                                MsgBox("Ingrese el código de la materia prima", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rpListconunamp.rpt"
                            Rep1.SelectionFormula = "{CConsumos.Codmat}='" + TCodMat.Text + "'"

                        Case "Consumos_Metionina_Listado"
                            Rep1.ReportFileName = RutaRep + "RpConsMet.rpt"
                            Rep1.SelectionFormula = ""

                        Case "Consumos_UnaMP"
                            If TCodMat.Text = "" Then
                                MsgBox("Ingrese el código de la materia prima", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rpconunamp.rpt"
                            Rep1.SelectionFormula = "{CConsumos.CODMAT}='" + Trim(Eval(TCodMat.Text)) + "' AND " + "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Cortes_Consolidado"
                            Rep1.ReportFileName = RutaRep + "rpConsolidadoCortes.rpt"
                            Rep1.SelectionFormula = "{CCORTESLOTE2.DESCARTADO}=false"

                            If TCorte.Text <> "" Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCORTESLOTE2.CODMAT}='" + TCorte.Text + "'"
                        Case "Cortes_Ubicacion"
                            Rep1.ReportFileName = RutaRep + "rpCortesUbicacion.rpt"

                            If TUbicLote.Text <> "" Then Rep1.SelectionFormula = "{CCORTESLOTEUBIC.UBICLOTE}='" + TUbicLote.Text + "'"

                            If TCodMat.Text <> "" Then Rep1.SelectionFormula = "{CCORTESLOTEUBIC.CODMAT}='" + TCodMat.Text + "'"
                        Case "Eventos_GSE"
                            Rep1.ReportFileName = RutaRep + "RpEventosGSE.rpt"
                            Rep1.SelectionFormula = ""
                        Case "OPs_Listado_Abiertas"
                            Rep1.ReportFileName = RutaRep + "rpoplis.rpt"
                            Rep1.SelectionFormula = ""
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{COPs.OP}='" + Eval(TOPs.Text).ToString + "'"
                        Case "Produccion_Agrupada_Formula"
                            Rep1.ReportFileName = RutaRep + "rptotfor.rpt"

                            If TCodFor.Text = "" Then   'Todas las formulas
                                Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                            Else    'Una sola formula
                                Rep1.SelectionFormula = "{CCONSUMOS.CODFOR}='" + Trim(Eval(TCodFor.Text)) + "' and " + "{CConsumos.LineaExterna} = " + LineaExterna

                            End If

                        Case "Produccion_Agrupada_OP"
                            Rep1.ReportFileName = RutaRep + "rptotop.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Agrupada_Producto"
                            Rep1.ReportFileName = RutaRep + "rptotprod.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Agrupada_Usuario"
                            Rep1.ReportFileName = RutaRep + "rptotusu.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Baches_Detalle"
                            Rep1.ReportFileName = RutaRep + "rpdetbac.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Baches_Detalle_OP"
                            If TOPs.Text = "" Then
                                MsgBox("Ingrese el número de la OP", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rpdetbac.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOS.OP}='" + Trim(Eval(TOPs.Text)) + "' and " + "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Baches_Listado"
                            Rep1.ReportFileName = RutaRep + "rplisbac.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Baches_Listado_OP"
                            If TOPs.Text = "" Then
                                MsgBox("Ingrese el número de la OP", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rplisbac.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOS.OP}='" + Trim(Eval(TOPs.Text)) + "' and " + "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Baches_Listado_Producto"
                            Rep1.ReportFileName = RutaRep + "rpLisbacProd.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "Produccion_Informe"
                            FInfProduc_Click(Nothing, Nothing)

                            Rep1.ReportFileName = RutaRep + "rpInfProd.rpt"
                            Rep1.Formulas(12) = "OPLIQ='" + OPLiq + "'"
                            ' Rep1.Formulas(13) = "PRODLIQ='" + NomLiq + "'"
                            Rep1.Formulas(14) = "SACKOF='" + SackoffLiq + "'"
                            Rep1.Formulas(15) = "SACKOFF%='" + SackOffPor + "'"
                            Rep1.Formulas(16) = "BACHESMX='" + BachesMezclados + "'"
                            Rep1.Formulas(17) = "CORRIDAS='" + Corridas + "'"
                            Rep1.Formulas(18) = "TONMAIZLIMP='" + TonLimpieza + "'"
                            Rep1.Formulas(19) = "OPGRANEL='" + OPGranel + "'"
                            ' Rep1.Formulas(20) = "PRODGRANEL='" + NomGranel + "'"
                            Rep1.Formulas(21) = "CANTGRANEL='" + CantGranel + "'"
                            'Rep1.Formulas(22) = "MEZCLADO='" + Mezclado + "'"
                            'Rep1.Formulas(23) = "VACEO='" + Vaceo + "'"
                            'Rep1.Formulas(24) = "PELET1='" + Pelet1 + "'"
                            'Rep1.Formulas(25) = "PELET2='" + Pelet2 + "'"
                            'Rep1.Formulas(26) = "PELET3='" + Pelet3 + "'"
                            'Rep1.Formulas(27) = "PELET4='" + Pelet4 + "'"
                            'Rep1.Formulas(28) = "PELET5='" + Pelet5 + "'"
                            'Rep1.Formulas(29) = "EMP1='" + Emp1 + "'"
                            'Rep1.Formulas(30) = "EMP2='" + Emp2 + "'"
                            'Rep1.Formulas(31) = "EMP3='" + Emp3 + "'"
                            ''Rep1.Formulas(32) = "EMP4='" + Emp4 + "'"
                            'Rep1.Formulas(33) = "EMP5='" + Emp5 + "'"
                            Rep1.Formulas(34) = "DATOS='" + Datos + "'"
                            Rep1.Formulas(35) = "DATOS1='" + Datos1 + "'"

                        Case "Produccion_OP_Afectada_Formula"
                            If TCodFor.Text = "" Then
                                MsgBox("Ingrese un código de fórmula", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rptotforOP.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOS.CODFOR}='" + Trim(Eval(TCodFor.Text)) + "'"

                        Case "Produccion_PesoMezcladora"
                            Rep1.ReportFileName = RutaRep + "RpLisbacPesos.rpt"

                        Case "Produccion_ProductoProceso"
                            DConsultas.Refresh()

                            DConsultas.RecordSet("F1") = Format(DateAdd(DateInterval.Day, -90, Now), "yyyy/MM/dd")
                            DConsultas.RecordSet("F2") = Format(DateAdd(DateInterval.Day, 30, Now), "yyyy/MM/dd")
                            DConsultas.Update()

                            Rep1.ReportFileName = RutaRep + "rpProdProceso.rpt"
                            Rep1.SelectionFormula = "{CEmpSackoffOP.LineaExterna} = " + LineaExterna

                            Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CEmpSackoffOP.FinPlanilla}<>'S'"

                        Case "Produccion_Programa"
                            Rep1.ReportFileName = RutaRep + "RpProgProduccion.rpt"

                        Case "Tolvas_Consumos"
                            Rep1.ReportFileName = RutaRep + "rpConsTvas.rpt"
                            Rep1.SelectionFormula = "{CConsumos.Tolva}>0"

                        Case "Tolvas_Error"
                            Rep1.ReportFileName = RutaRep + "rpErrTol.rpt"
                            Rep1.SelectionFormula = ""
                            If TCodMat.Text <> "" Then Rep1.SelectionFormula = "{CErrorTolvas.Codmat}='" + TCodMat.Text + "'"

                        Case "Dosificacion_Manual"
                            Rep1.ReportFileName = RutaRep + "rpDosifMan.rpt"
                            Rep1.SelectionFormula = ""
                    End Select
'-------------------------------------------------------------------------------------------
' Reportes del grupo "Entrada - Traslado Materia Prima"
'-------------------------------------------------------------------------------------------
                Case "Entrada - Traslado Materia Prima"
                    Select Case nBoton
                        Case "Cargue_Agrupado_Linea"
                            Rep1.ReportFileName = RutaRep + "rpRetLinea.rpt"
                            Rep1.SelectionFormula = "{CRetaque.Linea}<10"
                            If Eval(TLinea.Text) > 0 Then Rep1.SelectionFormula = "{CRetaque.Linea}=" + Trim(TLinea.Text)

                        Case "Cargue_Agrupado_Lote"
                            Rep1.ReportFileName = RutaRep + "rpRetLot.rpt"
                            Rep1.SelectionFormula = "{CRetaque.Linea}<10"

                        Case "Cargue_Agrupado_MP"
                            Rep1.ReportFileName = RutaRep + "rpRetMat.rpt"
                            Rep1.SelectionFormula = "{CRetaque.Linea}<10"

                        Case "Cargue_Listado"
                            Rep1.ReportFileName = RutaRep + "RpRetaque.rpt"
                            Rep1.SelectionFormula = "{CRetaque.Linea}<10"
                            If Eval(TCodMat.Text) > 0 Then Rep1.SelectionFormula = "{CRetaque.CodMat}='" + TCodMat.Text.Trim + "'"

                        Case "Cargue_VaceoManual"
                            'Rep1.SelectionFormula = "{CRetaque.Linea}=10"
                            Rep1.ReportFileName = RutaRep + "rpRetVaceo.rpt"

                        Case "Cargue_ConfirmacionTolvas"
                            Rep1.ReportFileName = RutaRep + "rpConfirmTolvas.rpt"

                        Case "Entradas"
                            Rep1.ReportFileName = RutaRep + "rpEntradasMP.rpt"
                            Rep1.SelectionFormula = ""

                        Case "Silos"
                            Rep1.ReportFileName = RutaRep + "RpMovSil.rpt"
                            Rep1.SelectionFormula = ""

                        Case "Cargue_ConsumoFylax"
                            Rep1.ReportFileName = RutaRep + "RpLisFylaxRec.rpt"
                            Rep1.SelectionFormula = ""

                        Case "CargueDesdePto_Listado"
                            Rep1.ReportFileName = RutaRep + "RpTransferPuertoLis.rpt"
                            Rep1.SelectionFormula = ""

                        Case "CargueDesdePto_MP"
                            Rep1.ReportFileName = RutaRep + "RpTransferPuertoMP.rpt"
                            Rep1.SelectionFormula = ""

                        Case "CargueDesdePto_Origen"
                            Rep1.ReportFileName = RutaRep + "RpTransferPuertoOrig.rpt"
                            Rep1.SelectionFormula = ""

                        Case "CargueDesdePto_Destino"
                            Rep1.ReportFileName = RutaRep + "RpTransferPuertoDest.rpt"
                            Rep1.SelectionFormula = ""

                        Case "CargueDesdePto_SiloDesp"
                            Rep1.ReportFileName = RutaRep + "RpTransferPuertoSiloDesp.rpt"
                            Rep1.SelectionFormula = ""

                    End Select
'-------------------------------------------------------------------------------------------
' Reportes del grupo "Empaque"
'-------------------------------------------------------------------------------------------
                Case "Empaque"
                    Select Case nBoton
                        Case "Empaque_Agrupado_Maquina"
                            Rep1.ReportFileName = RutaRep + "rpEmpLisMaq.rpt"
                            Rep1.SelectionFormula = "{CEmpaque.LineaExterna} = " + LineaExterna

                        Case "Empaque_Agrupado_MaquinayOP"
                            Rep1.ReportFileName = RutaRep + "rpEmpMaqOP.rpt"
                            Rep1.SelectionFormula = "{CEmpaque.LineaExterna} = " + LineaExterna

                        Case "Empaque_Agrupado_OP"
                            Rep1.ReportFileName = RutaRep + "rpEmpop.rpt"
                            Rep1.SelectionFormula = ""
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CEMPAQUE.OP}='" + Trim(Eval(TOPs.Text)) + "'"

                        Case "Empaque_Agrupado_OP_Pacas"
                            Rep1.ReportFileName = RutaRep + "rpEmpopPacas.rpt"
                            Rep1.SelectionFormula = ""
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CEMPAQUEPACAS.OP}='" + Trim(Eval(TOPs.Text)) + "'"


                        Case "Empaque_EmpaquesEtiquetas_Listado"
                            Rep1.ReportFileName = RutaRep + "rpEmpEtiqDet.rpt"
                            Rep1.SelectionFormula = ""
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CEMPETIQDET.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Empaque_Listado"
                            Rep1.ReportFileName = RutaRep + "rpEmpLis.rpt"
                            Rep1.SelectionFormula = "{CEmpaque.LineaExterna} = " + LineaExterna

                        Case "Empaque_ListadoPacas"
                            Rep1.ReportFileName = RutaRep + "rpEmpLisPacas.rpt"
                            Rep1.SelectionFormula = "{CEmpaquePacas.LineaExterna} = " + LineaExterna


                        Case "Empaque_ListadoDevMaq"
                            Rep1.ReportFileName = RutaRep + "RpEmpDevMaq.rpt"
                            Rep1.SelectionFormula = "{CEMPAQUE.SACOS}<=-1"

                        Case "Empaque_Planilla"

                            If Eval(TOPs.Text) = 0 Then
                                MsgBox(DevuelveEvento(CodEvento.REPORTES_SELECCIONAROP), vbInformation)
                                Return
                            End If

                            FForPlanilla_Click(Nothing, Nothing)

                            Rep1.ReportFileName = RutaRep + "rpPlanilla.rpt"
                            Rep1.SelectionFormula = "{CEMPAQUE.OP}='" + Trim(Eval(TOPs.Text)) + "' and {CEmpaque.Maquina}<100"

                        Case "Empaque_RecibidoAlmacen"
                            Rep1.ReportFileName = RutaRep + "rpEmpRecBod.rpt"
                            Rep1.SelectionFormula = "{CEmpRecBod.LineaExterna} = " + LineaExterna

                            Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CEmpRecBod.RecEmp}=TRUE and {CEmpRecBod.UsuarioRec}<>'-'"

                        Case "Empaque_RecibidoProduccion"
                            Rep1.ReportFileName = RutaRep + "rpEmpRecProd.rpt"
                            Rep1.SelectionFormula = "{CEmpRecProd.LineaExterna} = " + LineaExterna

                            Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CEmpRecProd.RecProd}=TRUE and {CEmpRecProd.UsuarioRecProd}<>'-'"

                        Case "Empaque_Repeso_Agrupado_OP"
                            Rep1.ReportFileName = RutaRep + "rpRepesoOP.rpt"

                            Rep1.SelectionFormula = ""
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CREPESO.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Empaque_Repeso_Listado"
                            Rep1.ReportFileName = RutaRep + "rpRepesoList.rpt"
                            Rep1.SelectionFormula = ""

                        Case "Empaque_SackOff"
                            Rep1.ReportFileName = RutaRep + "rpSackOffOP.rpt"

                            If CLimpieza.Text = "SI" Then
                                Rep1.SelectionFormula = "{CEmpSackoffOP2.LineaInvent}='LIMPIEZA'"
                            Else
                                Rep1.SelectionFormula = "{CEmpSackoffOP2.FinPlanilla}='S' and  {CEmpSackoffOP2.LineaInvent}<>'LIMPIEZA'"
                            End If

                        Case "Empaque_SinRecibirAlmacen"
                            Rep1.ReportFileName = RutaRep + "rpEmpSinRec.rpt"
                            Rep1.SelectionFormula = "{CEmpaque.LineaExterna} = " + LineaExterna
                            Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CEmpaque.SACOS}<>0 
                                                                              And {CEmpaque.Maquina}<>100 And {CEmpaque.RecEmp}<>True
                                                                              And {CEmpaque.CodProd}<>'99'"

                        Case "Empaque_Trazabilidad"

                            If Eval(TOPs.Text) = 0 Then
                                MsgBox(DevuelveEvento(CodEvento.REPORTES_SELECCIONAROP), vbInformation)
                                Return
                            End If

                            'Este reporte solo se puede abrir si la OP ya está finalizada por planilla
                            DVarios.Open("Select * FROM OPS where FINPLANILLA='S' and OP='" + TOPs.Text + "'")
                            If DVarios.Count = 0 Then
                                MsgBox(DevuelveEvento(CodEvento.REPORTES_OPFINPLANILLA), vbInformation)
                                Return
                            End If

                            Dim DTrazab02 As AdoSQL
                            DTrazab02 = New AdoSQL("CTrazab02")


                            DConsultas.Refresh()
                            DConsultas.RecordSet("I2") = TOPs.Text
                            DConsultas.Update()

                            DTrazab02.Open("select * from CTRAZAB02")
                            If DTrazab02.Count Then
                                Rep1.Formulas(1) = "FECHA='" + FechaC() + "'"
                                Rep1.Formulas(2) = "PESOREPROCESO='" + DTrazab02.RecordSet("PESOREPROCESO").ToString + "'"
                                Rep1.Formulas(3) = "BACHES='" + DTrazab02.RecordSet("BACHES").ToString + "'"
                                Rep1.Formulas(4) = "FECHAINIEMP='" + DTrazab02.RecordSet("FECHAINIEMP") + "'"
                                Rep1.Formulas(5) = "MAQUINAEMP='" + DTrazab02.RecordSet("MAQUINAEMP").ToString + "'"

                                DVarios.Open("select * from OPSFINPLANILLA where OP='" + TOPs.Text + "'")
                                If DVarios.Count Then
                                    Rep1.Formulas(6) = "DOSIFICADOKG='" + DVarios.RecordSet("DOSIFICADOKG").ToString + "'"
                                    Rep1.Formulas(7) = "EMPKG='" + DVarios.RecordSet("EMPACADOKG").ToString + "'"
                                    Rep1.Formulas(8) = "VARIACIONKG='" + Math.Round(DVarios.RecordSet("DIFERENCIAKG"), 1).ToString + "'"
                                    Rep1.Formulas(9) = "SACKOFFPORC='" + DVarios.RecordSet("SACKOFFPORC").ToString + "'"

                                End If

                            End If

                            DTrazabSec.Open("Delete from TRAZABSEC")

                            'Búsqueda de los antes y despues de esta OP
                            'Baches
                            DBaches.Open("select FECHA,CODFOR,CONT from BACHES where OP='" + TOPs.Text + "' order by FECHA")
                            'Busqueda de todas las corridas anteriores
                            For Each Fila As DataRow In DBaches.Rows
                                Dim FechaA = Fila("FECHA")
                                Dim Cont As String = Fila("CONT")
                                DVarios.Open("select TOP 1 * from BACHES where BACHEAUTOMATICO=1 AND FECHA<'" + FechaA + "' order by FECHA DESC")
                                If DVarios.Count And TOPs.Text <> DVarios.RecordSet("OP") Then
                                    'Rep1.Formulas(10) = "DOSIFANTES='OP:" + DVarios.RecordSet("OP") + " " + DVarios.RecordSet("NOMFOR") + "'"
                                    DTrazabSec.Open("Select * from TRAZABSEC where ID=0")
                                    DTrazabSec.AddNew()
                                    DTrazabSec.RecordSet("FECHAINI") = FechaA
                                    DTrazabSec.RecordSet("CONTINI") = Cont
                                    DTrazabSec.RecordSet("PROCESO") = "DOSIF"
                                    DTrazabSec.RecordSet("OPANT") = DVarios.RecordSet("OP")
                                    DTrazabSec.RecordSet("PRODANT") = DVarios.RecordSet("NOMFOR")
                                    DTrazabSec.RecordSet("MAQUINA") = 1
                                    DTrazabSec.Update()
                                End If
                            Next

                            'Buscamos corridas despues para sacar los productos dosificados despues
                            'Abrimos la tabla que ya empezamps a llenar de trazabilidad

                            DTrazabSec.Open("Select * FROM TRAZABSEC where PROCESO='DOSIF' order by id")
                            For Each FTrazab As DataRow In DTrazabSec.Rows
                                'Se ubica el contador para arrancar la consulta desde alli
                                Dim FechaA = FTrazab("FECHAINI")
                                Dim Cont As String = FTrazab("CONTINI")
                                DBaches.Open("select TOP 50 * from BACHES where BACHEAUTOMATICO=1 AND CONT>" + Cont + " AND FECHA>'" + FechaA + "' order by FECHA")

                                For Each FBaches As DataRow In DBaches.Rows

                                    If TOPs.Text <> FBaches("OP") Then
                                        FTrazab("OPDESP") = FBaches("OP")
                                        FTrazab("PRODDESP") = FBaches("NOMFOR")
                                        FTrazab("FECHAFIN") = FBaches("FECHA")
                                        FTrazab("CONTFIN") = FBaches("CONT") - 1
                                        DTrazabSec.Update()
                                        'Si ya encontró el producto diferente, continua con el siguiente registro de la tabla de trazabilidad
                                        Exit For
                                    End If
                                Next FBaches
                            Next FTrazab

                            'Búsqueda de los antes y despues de esta OP
                            'Emapaque
                            DEmp.Open("select FECHAINI,CONT,MAQUINA from EMPAQUE where MAQUINA<10 AND OP='" + TOPs.Text + "' order by CONT")
                            'Busqueda de todas las corridas anteriores
                            For Each FEmp As DataRow In DEmp.Rows
                                Dim FechaA = FEmp("FECHAINI")
                                Dim Cont As String = FEmp("CONT")
                                Dim Maquina As Int16 = FEmp("MAQUINA")
                                DVarios.Open("select TOP 1 * from EMPAQUE where MAQUINA=" + Maquina.ToString + " AND FECHAINI<'" + FechaA + "' order by CONT DESC")
                                If DVarios.Count And TOPs.Text <> DVarios.RecordSet("OP") Then
                                    'Rep1.Formulas(10) = "DOSIFANTES='OP:" + DVarios.RecordSet("OP") + " " + DVarios.RecordSet("NOMFOR") + "'"
                                    DTrazabSec.Open("Select * from TRAZABSEC where ID=0")
                                    DTrazabSec.AddNew()
                                    DTrazabSec.RecordSet("FECHAINI") = FechaA
                                    DTrazabSec.RecordSet("CONTINI") = Cont
                                    DTrazabSec.RecordSet("PROCESO") = "EMPAQUE"
                                    DTrazabSec.RecordSet("OPANT") = DVarios.RecordSet("OP")
                                    DTrazabSec.RecordSet("PRODANT") = DVarios.RecordSet("NOMPROD")
                                    DTrazabSec.RecordSet("MAQUINA") = Maquina
                                    DTrazabSec.Update()
                                End If
                            Next


                            'Buscamos corridas despues para sacar los productos dosificados despues
                            'Abrimos la tabla que ya empezamps a llenar de trazabilidad

                            DTrazabSec.Open("Select * FROM TRAZABSEC where PROCESO='EMPAQUE' order by id")
                            For Each FTrazab As DataRow In DTrazabSec.Rows
                                'Se ubica el contador para arrancar la consulta desde alli
                                Dim FechaA = FTrazab("FECHAINI")
                                Dim Cont As String = FTrazab("CONTINI")
                                Dim Maquina As Int16 = FTrazab("MAQUINA")

                                DEmp.Open("select TOP 50 * from EMPAQUE where MAQUINA=" + Maquina.ToString + " AND CONT>" + Cont + " AND FECHAINI>'" + FechaA + "' order by CONT")
                                For Each FEmp As DataRow In DEmp.Rows
                                    If TOPs.Text <> FEmp("OP") Then
                                        FTrazab("OPDESP") = FEmp("OP")
                                        FTrazab("PRODDESP") = FEmp("NOMPROD")
                                        FTrazab("FECHAFIN") = FEmp("FECHAINI")
                                        DTrazabSec.Update()
                                        'Si ya encontró el producto diferente, continua con el siguiente registro de la tabla de trazabilidad
                                        Exit For
                                    End If
                                Next FEmp
                            Next FTrazab



                            'Búsqueda de los antes y despues de esta OP
                            'Micros
                            DConsumosMed.Open("select FECHA,ID from CONSUMOSMED where OP='" + TOPs.Text + "' order by ID")
                            'Busqueda de todas las corridas anteriores
                            Dim FechaMedAnt As String = ""
                            For Each FConsMed As DataRow In DConsumosMed.Rows
                                Dim FechaA = FConsMed("FECHA")
                                Dim Cont As String = FConsMed("ID")
                                If FechaA <> FechaMedAnt Then
                                    DVarios.Open("select TOP 1 * from CONSUMOSMED where FECHA<'" + FechaA + "' order by ID DESC")
                                    FechaMedAnt = FechaA
                                    If DVarios.Count And TOPs.Text <> DVarios.RecordSet("OP") Then
                                        'Rep1.Formulas(10) = "DOSIFANTES='OP:" + DVarios.RecordSet("OP") + " " + DVarios.RecordSet("NOMFOR") + "'"
                                        DTrazabSec.Open("Select * from TRAZABSEC where ID=0")
                                        DTrazabSec.AddNew()
                                        DTrazabSec.RecordSet("FECHAINI") = FechaA
                                        DTrazabSec.RecordSet("CONTINI") = Cont
                                        DTrazabSec.RecordSet("PROCESO") = "MICROS"
                                        DTrazabSec.RecordSet("OPANT") = DVarios.RecordSet("OP")
                                        DTrazabSec.RecordSet("PRODANT") = DVarios.RecordSet("NOMFOR")
                                        DTrazabSec.RecordSet("MAQUINA") = 1
                                        DTrazabSec.Update()
                                    End If
                                End If
                            Next


                            'Buscamos corridas despues para sacar los productos dosificados despues
                            'Abrimos la tabla que ya empezamps a llenar de trazabilidad
                            FechaMedAnt = ""
                            DTrazabSec.Open("Select * FROM TRAZABSEC where PROCESO='MICROS' order by id")
                            For Each FTrazab As DataRow In DTrazabSec.Rows
                                'Se ubica el contador para arrancar la consulta desde alli
                                Dim FechaA = FTrazab("FECHAINI")
                                Dim ID As String = FTrazab("CONTINI")
                                DEmp.Open("select TOP 800 * from CONSUMOSMED where ID>" + ID + " AND FECHA>'" + FechaA + "' order by ID")
                                For Each FEmp As DataRow In DEmp.Rows
                                    If TOPs.Text <> FEmp("OP") Then
                                        FTrazab("OPDESP") = FEmp("OP")
                                        FTrazab("PRODDESP") = FEmp("NOMFOR")
                                        FTrazab("FECHAFIN") = FEmp("FECHA")
                                        DTrazabSec.Update()
                                        'Si ya encontró el producto diferente, continua con el siguiente registro de la tabla de trazabilidad
                                        Exit For
                                    End If
                                Next FEmp
                            Next FTrazab


                            Rep1.ReportFileName = RutaRep + "rpTrazabilidad.rpt"

                    End Select
'-------------------------------------------------------------------------------------------
' Reportes del grupo "Dosificacion Premezclas y Pesada Menor"
'-------------------------------------------------------------------------------------------
                Case "Dosificacion Premezclas y Pesada Menor"
                    Select Case nBoton
                        Case "Cortes_Premezclas_Listado"

                        Case "PesadaMenor_Agrupados_OP"
                            Rep1.ReportFileName = RutaRep + "rpPmOP.rpt"
                            Rep1.SelectionFormula = "{CConsumosMan.LineaExterna} = " + LineaExterna

                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMAN.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "PesadaMenor_Baches_Detalle"
                            Rep1.ReportFileName = RutaRep + "rpPmdetbac.rpt"
                            Rep1.SelectionFormula = "{CConsumosMan.LineaExterna} = " + LineaExterna

                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMAN.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "PesadaMenor_Listado"
                            Rep1.ReportFileName = RutaRep + "rpPMList.rpt"
                            Rep1.SelectionFormula = "{CConsumosMan.LineaExterna} = " + LineaExterna

                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMAN.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "PesadaMenor_Agrupados_MP"
                            Rep1.ReportFileName = RutaRep + "rppmcongen.rpt"
                            Rep1.SelectionFormula = "{CConsumosMan.LineaExterna} = " + LineaExterna


                        Case "PesadaMenor_PendientesVacear"
                            Rep1.ReportFileName = RutaRep + "rpPendVacearPM.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOSMAN.ALARMAS}=0 "
                            If Eval(TOPs.Text) > 0 Then
                                Rep1.SelectionFormula = " and {CCONSUMOSMAN.OP}='" + Eval(TOPs.Text).ToString + "'"
                            End If

                        Case "Premezcclas_Escaner_Detalle"
                            Rep1.ReportFileName = RutaRep + "rpEscanerdetbac.rpt"
                            If Val(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CCONSUMOSESCANER.OP}='" + Trim(Eval(TOPs.Text)) + "'"

                        Case "Premezclas_Agrupados_MP"
                            Rep1.ReportFileName = RutaRep + "rpcongenMed.rpt"
                            Rep1.SelectionFormula = "{CConsumosMed.LineaExterna} = " + LineaExterna
                            If Funcion_PlantasExternas Then
                                Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.PLANTA}=" + PlantaPrem
                            End If

                        Case "Premezclas_Agrupados_OP"
                            Rep1.ReportFileName = RutaRep + "rpPremOP.rpt"
                            Rep1.SelectionFormula = "{CConsumosMed.LineaExterna} = " + LineaExterna
                            If Funcion_PlantasExternas Then
                                Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.PLANTA}=" + PlantaPrem
                            End If

                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.OP}='" + Eval(TOPs.Text).ToString + "'"
                            If TCodPrem.Text.Length > 0 Then Rep1.SelectionFormula += " AND {CCONSUMOSMED.CODPREMEZCLA}='" + TCodPrem.Text + "'"

                        Case "Premezclas_Baches_Detalle"
                            Rep1.ReportFileName = RutaRep + "rpPremdetbac.rpt"
                            Rep1.SelectionFormula = "{CConsumosMed.LineaExterna} = " + LineaExterna
                            If Funcion_PlantasExternas Then
                                Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.PLANTA}=" + PlantaPrem
                            End If

                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Premezclas_Escaner_Listado"
                            Rep1.ReportFileName = RutaRep + "rpEscanerlist.rpt"
                            If Val(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CCONSUMOSESCANER.OP}='" + Trim(Eval(TOPs.Text)) + "'"

                        Case "Premezclas_Escaner_OP"
                            Rep1.ReportFileName = RutaRep + "rpEscanerop.rpt"
                            If Val(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CCONSUMOSESCANER.OP}='" + Trim(Eval(TOPs.Text)) + "'"

                        Case "Premezclas_Listado"
                            Rep1.ReportFileName = RutaRep + "rppremlist.rpt"
                            Rep1.SelectionFormula = "{CConsumosMed.LineaExterna} = " + LineaExterna
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Premezclas_Traslados"
                            Rep1.ReportFileName = RutaRep + "rppremtraslados.rpt"
                            Rep1.SelectionFormula = "{CConsumosMed.Traslado} = true and {CConsumosMed.LineaExterna} = " + LineaExterna
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Premezclas_Listado_SinRecibir"
                            Rep1.ReportFileName = RutaRep + "rppremlist.rpt"
                            Rep1.SelectionFormula = "{CConsumosMed.LineaExterna} = " + LineaExterna
                            If Funcion_PlantasExternas Then
                                Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.PLANTA}=" + PlantaPrem
                            End If

                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Premezclas_RecibidasBodega"
                            Rep1.SelectionFormula = ""
                            Rep1.SelectionFormula = "{CConsumosMed.LineaExterna} = " + LineaExterna

                            If Funcion_PlantasExternas Then
                                Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSMED.PLANTA}=" + PlantaPrem
                            End If

                            Rep1.SelectionFormula += " and {CCONSUMOSMED.RECPREM}=TRUE"
                            Rep1.ReportFileName = RutaRep + "rpPremListRec.rpt"

                        Case "Premezclas_UnaMP"
                            If TCodMat.Text = "" Then
                                MsgBox("Ingrese un código de materia prima", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rpconunampmed.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOSMED.CODMAT}='" + Eval(TCodMat.Text).ToString + "'  and " + "{CConsumosMed.LineaExterna} = " + LineaExterna

                        Case "Medicados_Agrupados_MP"
                            Rep1.ReportFileName = RutaRep + "rpcongenPF.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOSPF.LineaExterna} = " + LineaExterna
                            If Funcion_PlantasExternas Then
                                Rep1.SelectionFormula = Rep1.SelectionFormula + " and {CCONSUMOSPF.PLANTA}=" + PlantaPrem
                            End If

                        Case "Medicados_UnaMP"
                            If TCodMat.Text = "" Then
                                MsgBox("Ingrese un código de materia prima", vbInformation)
                                Return
                            End If
                            Rep1.ReportFileName = RutaRep + "rpconunamppf.rpt"
                            Rep1.SelectionFormula = "{CCONSUMOSPF.CODMAT}='" + Eval(TCodMat.Text).ToString + "'  and " + "{CCONSUMOSPF.LineaExterna} = " + LineaExterna

                    End Select
'-------------------------------------------------------------------------------------------
' Reportes del grupo "Tiempos de proceso - Otros"
'-------------------------------------------------------------------------------------------
                Case "Tiempos de proceso - Otros"
                    Select Case nBoton
                        Case "TiemposMuertos_Listado"
                            Rep1.ReportFileName = RutaRep + "rpTMuertos.rpt"
                            Rep1.SelectionFormula = ""

                        Case "TiemposProceso_Bache"
                            Rep1.ReportFileName = RutaRep + "rptiemposprocbache.rpt"
                            If Val(TCont.Text) > 0 Then Rep1.SelectionFormula = "{CTIEMPOSPROCESO.CONT}=" + TCont.Text

                        Case "TiemposProceso_Listado_Baches"
                            Rep1.ReportFileName = RutaRep + "rplisbacTiempos.rpt"
                            Rep1.SelectionFormula = "{CConsumos.LineaExterna} = " + LineaExterna

                        Case "TiemposProceso_OP"
                            Rep1.ReportFileName = RutaRep + "rptiemposprocbache.rpt"
                            If Val(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CTIEMPOSPROCESO.OP}='" + TOPs.Text + "'"

                        Case "TiemposProceso_Tolvas_Listado"
                            Rep1.ReportFileName = RutaRep + "rptiemposdettolvas.rpt"
                            Rep1.SelectionFormula = "{CTIEMPOSPROCESO.PROCESO}='TOLVAS'"
                        Case "ParametrosFylax_Listado"
                            Rep1.ReportFileName = RutaRep + "rpLisBacFylax.rpt"
                    End Select
'-------------------------------------------------------------------------------------------
' Reportes del grupo "Peleitizado"
'-------------------------------------------------------------------------------------------
                Case "Peletizado"
                    Select Case nBoton
                        Case "ControlDiario"
                            Rep1.ReportFileName = RutaRep + "rpControlDiario.rpt"

                        Case "DatosPelets"
                            Rep1.ReportFileName = RutaRep + "rpPelets.rpt"
                            Rep1.SelectionFormula = ""

                        Case "Engrase"
                            Rep1.ReportFileName = RutaRep + "rptotopEngrase.rpt"
                            If Eval(TOPs.Text) > 0 Then Rep1.SelectionFormula = "{CCONSUMOSENGOP.OP}='" + Eval(TOPs.Text).ToString + "'"

                        Case "Humedades"
                            Rep1.ReportFileName = RutaRep + "rpHumedades.rpt"

                        Case "Tamizados"
                            Rep1.ReportFileName = RutaRep + "rpTamizados.rpt"
                            Rep1.SelectionFormula = "{CTAMIZADOS.PRESENT}<>'HARINA'"

                        Case "Tamizados_Harinas"
                            Rep1.ReportFileName = RutaRep + "rpTamizados.rpt"
                            Rep1.SelectionFormula = "{CTAMIZADOS.PRESENT}='HARINA'"

                    End Select

            End Select

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCDate.Click
        Dim RepSap As CrystalRep
        Try

            OKFecha = True
            FechaIni = Format(TFechaIni.Value, "yyyy/MM/dd ") + Format(THoraIni.Value, "HH:mm")
            FechaFin = Format(TFechaFin.Value, "yyyy/MM/dd ") + Format(THoraFin.Value, "HH:mm")

            If CDate(FechaFin) <= CDate(FechaIni) Then
                MsgBox("La Fecha Inicial no puede ser Superior o Igual a la Fecha Final", MsgBoxStyle.Exclamation, "Error en Fechas")
                OKFecha = False
                Exit Sub
            End If

            DConsultas.Refresh()

            DConsultas.RecordSet("F1") = FechaIni
            DConsultas.RecordSet("F2") = FechaFin
            DConsultas.RecordSet("T12") = Now.ToString("yyMMdd")
            DConsultas.Update()

            RepSap = New CrystalRep
            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .Formulas(2) = "DESDE='" + FechaIni + "'"
                .Formulas(3) = "HASTA='" + FechaFin + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With
            Rep1 = RepSap

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub OP24Horas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OP24Horas.Click
        Try
            TFechaIni.Value = Now
            TFechaFin.Value = DateAdd(DateInterval.Day, 1, Now)
            THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))
            THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPTurno1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTurno1.Click
        Try
            TFechaIni.Value = Now
            TFechaFin.Value = Now

            DTurnos.Open("Select * from TURNOS where TURNO=1")

            If DTurnos.Count > 0 Then
                THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd " + DTurnos.RecordSet("HORAINI").ToString))
                THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd " + DTurnos.RecordSet("HORAFIN").ToString))
            Else
                THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 06:00"))
                THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 14:00"))
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPTurno2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTurno2.Click
        Try
            TFechaIni.Value = Now
            TFechaFin.Value = Now

            DTurnos.Open("Select * from TURNOS where TURNO=2")

            If DTurnos.Count > 0 Then
                THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd " + DTurnos.RecordSet("HORAINI").ToString))
                THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd " + DTurnos.RecordSet("HORAFIN").ToString))
            Else
                THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 14:00"))
                THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 22:00"))
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OPTurno3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTurno3.Click
        Try
            'TFechaIni.Value = CDate(DateAdd(DateInterval.Day, -1, Now))
            TFechaIni.Value = Now
            TFechaFin.Value = DateAdd(DateInterval.Day, 1, Now)

            DTurnos.Open("Select * from TURNOS where TURNO=3")

            If DTurnos.Count > 0 Then
                THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd " + DTurnos.RecordSet("HORAINI").ToString))
                THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd " + DTurnos.RecordSet("HORAFIN").ToString))
            Else
                THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 22:00"))
                THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 06:00"))
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnSalir_Click(sender As Object, e As EventArgs) Handles mnSalir.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub FForPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FForPlanilla.Click
        Try



            Dim PromHumEmp As Single = 0
            Dim PromHumHar As Single = 0
            Dim PromDifHum As Single = 0
            Dim PromHumAcond As Single = 0
            Dim PromHumForm As Single = 0

            'Para Palmira
            Dim TotDosificado As Single = 0
            Dim EnergiaTot As Single = 0
            Dim AJGRASAEXT As Single = 0
            Dim AuxRealDosif As Double = 0

            DConsultas.Refresh()
            DConsultas.RecordSet("F1") = Format(DateAdd(DateInterval.Day, -30, TFechaIni.Value), "yyyy/MM/dd")
            DConsultas.RecordSet("F2") = Format(DateAdd(DateInterval.Day, 1, Now), "yyyy/MM/dd")
            DConsultas.RecordSet("I1") = Eval(TOPs.Text)
            DConsultas.Update()

            Rep1.Formulas(0) = "PLANTA='" + Planta + "'"
            Rep1.Formulas(1) = "FECHA='" + Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
            Rep1.Formulas(2) = "FECHADOSIF='-'"
            Rep1.Formulas(3) = "BACHES='0'"
            Rep1.Formulas(4) = "BACHESMETA='0'"
            Rep1.Formulas(5) = "CODFOR='0'"
            Rep1.Formulas(6) = "METADOSIF='0'"
            Rep1.Formulas(7) = "REALDOSIF='0'"
            Rep1.Formulas(8) = "MEDICADOCLIENTE='-'"
            Rep1.Formulas(19) = "LIQEXTERN='-'"
            Rep1.Formulas(20) = "OBSERVFINPLANILLA='-'"
            Rep1.Formulas(21) = "OBSERVALMACEN='-'"
            Rep1.Formulas(22) = "OBSERVCOSTOS='-'"
            Rep1.Formulas(23) = "NOMFOR='-'"
            Rep1.Formulas(24) = "PROMHUMHARINA='-'"
            Rep1.Formulas(25) = "PROMHUMEMPAQUE='-'"
            Rep1.Formulas(26) = "PRESET='-'"
            Rep1.Formulas(28) = "CENIZA='0'"
            Rep1.Formulas(29) = "GRASA='0'"
            Rep1.Formulas(30) = "HUMEDAD='0'"
            Rep1.Formulas(31) = "PROTEINA='0'"
            Rep1.Formulas(32) = "CODFORB='0'"
            Rep1.Formulas(33) = "LP='0'"
            Rep1.Formulas(34) = "PRODUCTIVIDAD='0'"
            Rep1.Formulas(35) = "CARGA='0'"
            Rep1.Formulas(36) = "TEMPERATURA='0'"
            Rep1.Formulas(37) = "PRESION='0'"
            Rep1.Formulas(38) = "GANHUMEDAD='0'"
            Rep1.Formulas(39) = "CONSUMOENER='0'"
            Rep1.Formulas(40) = "PORCM8PELET='0'"
            Rep1.Formulas(41) = "PORCM12PELET='0'"
            Rep1.Formulas(42) = "PORCM16PELET='0'"
            Rep1.Formulas(43) = "PORCPLATOPELET='0'"
            Rep1.Formulas(44) = "PORCDURABILIDADPELET='0'"
            Rep1.Formulas(45) = "DUREZAPELET='0'"
            Rep1.Formulas(46) = "PORCM8QUEB='0'"
            Rep1.Formulas(47) = "PORCM12QUEB='0'"
            Rep1.Formulas(48) = "PORCM16QUEB='0'"
            Rep1.Formulas(49) = "PORCPLATOQUEB='0'"
            Rep1.Formulas(50) = "PORCDURABILIDADQUEB='0'"
            Rep1.Formulas(51) = "DUREZAQUEB='0'"
            Rep1.Formulas(52) = "HUMEDADFORM='0'"
            Rep1.Formulas(53) = "OBSERVCALIDAD='-'"
            Rep1.Formulas(54) = "OBSERVPRODUCCION='-'"

            '---------------------------------------------------------------------------------------
            'Para Pereira, Yarumal
            '---------------------------------------------------------------------------------------
            'Se revisa si hay datos de humedades para esta OP y actualizar los datos en la tabla OPs
            'DHumedades.Open("Select AVG(PORCDIFHARINA) AS DIFHUMEDAD,AVG(PORCHARINA) AS PROMHUMHAR," +
            '                "AVG(PORCEMPAQUE) AS PROMHUMEMP,AVG(PORCACOND) AS PROMHUMACOND,AVG(PORCFORMULADA) AS PROMHUMFORM  from HUMEDADES WHERE OP='" + TOP.Text.Trim + "'")

            'If DHumedades.Count > 0 Then
            '    If Not IsDBNull(DHumedades.RecordSet("DIFHUMEDAD")) Then PromDifHum = DHumedades.RecordSet("DIFHUMEDAD")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMHAR")) Then PromHumHar = DHumedades.RecordSet("PROMHUMHAR")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMEMP")) Then PromHumEmp = DHumedades.RecordSet("PROMHUMEMP")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMACOND")) Then PromHumAcond = DHumedades.RecordSet("PROMHUMACOND")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMFORM")) Then PromHumForm = DHumedades.RecordSet("PROMHUMFORM")
            'End If

            ''Actualizamos los datos de las humedades en la tabla OPs
            'DVarios.Open("Update OPS set DIFHUMEDAD=" + PromDifHum.ToString + ",PROMHUMHAR=" + PromHumHar.ToString +
            '             ",PROMHUMEMP=" + PromHumEmp.ToString + ",PROMHUMACOND=" + PromHumAcond.ToString + " where OP='" + TOP.Text.Trim + "'")
            '---------------------------------------------------------------------------------------

            DVarios.Open("select * from OPS where OP='" + Trim(TOPs.Text) + "'")
            If DVarios.Count Then
                If DVarios.RecordSet("FINPLANILLA") = "S" Then
                    Rep1.Formulas(13) = "AVISO='" + " PLANILLA FINAL " + "'"
                Else
                    Rep1.Formulas(13) = "AVISO='" + " PLANILLA PRELIMINAR " + "'"
                End If

                If DVarios.RecordSet("NUMFINPLANILLA") > 0 Then
                    Rep1.Formulas(13) = "AVISO='" + " RELIQUIDACIÓN PLANILLA " + "'"
                End If

                Rep1.Formulas(3) = "BACHES='" + Trim(DVarios.RecordSet("REAL")) + "'"
                Rep1.Formulas(4) = "BACHESMETA='" + Trim(DVarios.RecordSet("META")) + "'"
                Rep1.Formulas(5) = "CODFOR='" + Trim(DVarios.RecordSet("CODFOR")) + "'"
                Rep1.Formulas(8) = "MEDICADOCLIENTE='" + DVarios.RecordSet("OBSERVOP") + "'"
                Rep1.Formulas(12) = "AJGRASAEXT='" + Format(DVarios.RecordSet("GRASAEXT"), "###0.00") + "'"

                'Se usa en Palmira:
                ' Se almacena del valor del ajuste de grasa de la OP
                'AJGRASAEXT = DVarios.RecordSet("GRASAEXT")
                'TotDosificado = DVarios.RecordSet("GRASAEXT")

                Rep1.Formulas(14) = "REPROCESO='" + Format(DVarios.RecordSet("REPROCESO"), "###0.00") + "'"
                Rep1.Formulas(16) = "CODPROD='" + Trim(DVarios.RecordSet("CODPROD")) + "'"
                Rep1.Formulas(15) = "NOMPROD='-'"

                DFor.Open("select * from FORMULAS WHERE CODFOR='" + Trim(DVarios.RecordSet("CODFOR")) + "' AND LP='" + Trim(DVarios.RecordSet("LP")) + "'")
                If DFor.Count > 0 Then Rep1.Formulas(32) = "CODFORB='" + Trim(DFor.RecordSet("CODFORB")) + "'"
                Rep1.Formulas(33) = "LP='" + Trim(DVarios.RecordSet("LP")) + "'"

                DArt.Open("select * from ARTICULOS where CODINT='" + DVarios.RecordSet("CODPROD") + "'")
                If DArt.Count > 0 Then Rep1.Formulas(15) = "NOMPROD='" + DArt.RecordSet("NOMBRE") + "'"

                Rep1.Formulas(23) = "NOMFOR='" + Trim(DVarios.RecordSet("NOMFOR")) + "'"
                Rep1.Formulas(24) = "PROMHUMHARINA='" + Trim(DVarios.RecordSet("PROMHUMHAR")) + "'"
                Rep1.Formulas(25) = "PROMHUMEMPAQUE='" + Trim(DVarios.RecordSet("PROMHUMEMP")) + "'"
                Rep1.Formulas(27) = "EQUIPO='" + Trim(DVarios.RecordSet("EQUIPO")) + "'"
                Rep1.Formulas(52) = "HUMEDADFORM='" + PromHumForm.ToString + "'"
                '---------------------------------------------------------------------------------------
                'En Funza Premezclas, Girardota, Palermo, Pereira, Yarumal estas líneas estan comentadas
                '---------------------------------------------------------------------------------------
                If DVarios.RecordSet("DIFHUMEDAD") > 0 Then
                    Rep1.Formulas(17) = "GANHUM='" + Format(DVarios.RecordSet("DIFHUMEDAD"), "#,##0.00") + "'"
                    Rep1.Formulas(18) = "PERHUM='" + Format(0, "#,##0.00") + "'"
                Else
                    Rep1.Formulas(18) = "PERHUM='" + Format(DVarios.RecordSet("DIFHUMEDAD"), "#,##0.00") + "'"
                    Rep1.Formulas(17) = "GANHUM='" + Format(0, "#,##0.00") + "'"
                End If
                '---------------------------------------------------------------------------------------
                'en su  lugar se utiliza:
                '---------------------------------------------------------------------------------------
                'Calculo de perdida y ganancia de humedad
                'Para la ganancia se calcula PROMHUMACOND-PROMHUMHAR

                'Rep1.Formulas(17) = "GANHUM='" + Format(PromHumAcond - PromHumHar, "#,##0.00") + "'"
                'Rep1.Formulas(18) = "HUMACOND='" + Format(PromHumAcond, "#,##0.00") + "'"
                '---------------------------------------------------------------------------------------

                If Len(DVarios.RecordSet("LIQEXT")) > 2 Then
                    Rep1.Formulas(19) = "LIQEXTERN='" + DVarios.RecordSet("LIQEXT") + "'"
                End If

                If Len(DVarios.RecordSet("OBSERVFINPLANILLA")) > 2 Then
                    Rep1.Formulas(20) = "OBSERVFINPLANILLA='" + LimpiarCadena(DVarios.RecordSet("OBSERVFINPLANILLA")) + "'"
                End If

                If Len(DVarios.RecordSet("OBSERVALMACEN")) > 2 Then
                    Rep1.Formulas(21) = "OBSERVALMACEN='" + LimpiarCadena(DVarios.RecordSet("OBSERVALMACEN")) + "'"
                End If

                If Len(DVarios.RecordSet("OBSERVCOSTOS")) > 2 Then
                    Rep1.Formulas(22) = "OBSERVCOSTOS='" + LimpiarCadena(DVarios.RecordSet("OBSERVCOSTOS")) + "'"
                End If

                If Len(DVarios.RecordSet("OBSERVCALIDAD")) > 2 Then
                    Rep1.Formulas(53) = "OBSERVCALIDAD='" + LimpiarCadena(DVarios.RecordSet("OBSERVCALIDAD")) + "'"
                End If

                If Len(DVarios.RecordSet("OBSERVPRODUCCION")) > 2 Then
                    Rep1.Formulas(54) = "OBSERVPRODUCCION='" + LimpiarCadena(DVarios.RecordSet("OBSERVPRODUCCION")) + "'"
                End If


            End If


            DVarios.Open("select * from CCONSUMOSOPTOT where OP='" + Trim(TOPs.Text) + "'")
            If DVarios.Count Then
                Rep1.Formulas(2) = "FECHADOSIF='" + Trim(DVarios.RecordSet("FECHAINI")) + "'"
                Rep1.Formulas(6) = "METADOSIF='" + Format(DVarios.RecordSet("PESOMETA"), "#,##0.00") + "'"
                Rep1.Formulas(7) = "AUXREALDOSIF='" + Trim(Format(DVarios.RecordSet("PESOREAL"), ".00")) + "'"
                '---------------------------------------------------------------------------------------
                'En Palmira      
                '---------------------------------------------------------------------------------------
                'AuxRealDosif = DVarios.RecordSet("PESOREAL")
                'Rep1.Formulas(7) = "AUXREALDOSIF='" + Trim(Format(DVarios.RecordSet("PESOREAL"), ".00")) + "'"
                'TotDosificado += DVarios.RecordSet("PESOREAL")

            End If

            DVarios.Open("SELECT Empaque.OP, Empaque.Tipo, Sum(Empaque.Peso) AS Total From Empaque " +
                                                    "GROUP BY Empaque.OP, Empaque.Tipo HAVING (Empaque.OP='" + Trim(TOPs.Text) + "' AND Empaque.Tipo='GRANEL');")
            If DVarios.Count > 0 Then
                Rep1.Formulas(9) = "TOTGRANEL='" + Format(DVarios.RecordSet("TOTAL"), "####0") + "'"
            Else
                Rep1.Formulas(9) = "TOTGRANEL='0'"
            End If

            DVarios.Open("SELECT Empaque.OP, Empaque.Tipo, Sum(Empaque.Peso) AS Total From Empaque " +
                                                    "GROUP BY Empaque.OP, Empaque.Tipo HAVING (Empaque.OP='" + Trim(TOPs.Text) + "' AND Empaque.Tipo='COLA');")
            If DVarios.Count > 0 Then
                Rep1.Formulas(10) = "TOTCOLA='" + Format(DVarios.RecordSet("TOTAL"), "###0") + "'"
            Else
                Rep1.Formulas(10) = "TOTCOLA='0'"
            End If

            DVarios.Open("SELECT Empaque.OP, Empaque.Tipo, Sum(Empaque.PesoReproceso) AS Total, max(Empaque.PresEmp) AS PresEmp From Empaque " +
                                                    "GROUP BY Empaque.OP, Empaque.Tipo HAVING (Empaque.OP='" + Trim(TOPs.Text) + "' AND Empaque.Tipo='NC KILOS');")
            If DVarios.Count > 0 Then
                Rep1.Formulas(11) = "TOTNCKILOS='" + Format(DVarios.RecordSet("TOTAL"), "###0") + "'"
                '        Rep1.Formulas(26) = "PRESET='" + Format(DVarios.Recordset("PRESET"), "###0") + "'"
            Else
                Rep1.Formulas(11) = "TOTNCKILOS='0'"
                '        Rep1.Formulas(26) = "PRESET='0'"
            End If

            'Si hay varias muestras de laboratorio para la OP (tabla DatosMuestras) se calcula el promedio y se imprime en la planilla

            DVarios.Open("select AVG(Ceniza) as PromCeniza, AVG(proteina) as PromProteina, AVG (humedad) as PromHumedad, avg(grasa) as PromGrasa from DATOSMUESTRAS where OP='" + TOPs.Text + "'")

            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMCENIZA")) Then Rep1.Formulas(28) = "CENIZA='" + Format(DVarios.RecordSet("PROMCENIZA"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMGRASA")) Then Rep1.Formulas(29) = "GRASA='" + Format(DVarios.RecordSet("PROMGRASA"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMHUMEDAD")) Then Rep1.Formulas(30) = "HUMEDAD='" + Format(DVarios.RecordSet("PROMHUMEDAD"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPROTEINA")) Then Rep1.Formulas(31) = "PROTEINA='" + Format(DVarios.RecordSet("PROMPROTEINA"), "0.00") + "'"
            End If

            'Se abren las consultas CAvgTamizados y CAvgControlDiarioPelet para traer los promedios de la OP

            DVarios.Open("select * from CAVGCONTROLDIARIO where OP='" + TOPs.Text + "'")
            'DVarios.Open("select * from CAVGCONTROLDIARIOPELET where OP='" + TOP.Text + "'")

            If DVarios.Count > 0 Then

                If Not IsDBNull(DVarios.RecordSet("PROMPRODUCTIVIDAD")) Then Rep1.Formulas(34) = "PRODUCTIVIDAD='" + Format(DVarios.RecordSet("PROMPRODUCTIVIDAD"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMCARGA")) Then Rep1.Formulas(35) = "CARGA='" + Format(DVarios.RecordSet("PROMCARGA"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMTEMPACOND")) Then Rep1.Formulas(36) = "TEMPERATURA='" + Format(DVarios.RecordSet("PROMTEMPACOND"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPRESIONENT")) Then Rep1.Formulas(37) = "PRESION='" + Format(DVarios.RecordSet("PROMPRESIONENT"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMCONSUMOENER")) Then Rep1.Formulas(39) = "CONSUMOENER='" + Format(DVarios.RecordSet("PROMCONSUMOENER"), "0.00") + "'"
            End If

            'Se abre la tabla de datos de peletizado para traer los datos de corrientes, presion y temperatura de la OP 
            'Nota: Estos datos salen solamente si el peletizador ingresa bien la op a la hora de empezar a peletizar, si no ChronoSoft
            'no registra ningún dato.
            'Se llenan primero los campos de arriba por si los datos son de las extruder, esos no se tienen por archivo plano

            DVarios.Open("Select AVG(Temperatura) as PROMTEMPERATURA, AVG(Presion) as PROMPRESION, max(Energia) as CONSUMOENER, AVG(FRECUENCIA) as PROMCARGA from DATOSPELETS where OP='" + TOPs.Text + "'")

            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMTEMPERATURA")) Then Rep1.Formulas(36) = "TEMPERATURA='" + Format(DVarios.RecordSet("PROMTEMPERATURA"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPRESION")) Then Rep1.Formulas(37) = "PRESION='" + Format(DVarios.RecordSet("PROMPRESION"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("CONSUMOENER")) Then Rep1.Formulas(39) = "CONSUMOENER='" + Format(DVarios.RecordSet("CONSUMOENER"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMCARGA")) Then Rep1.Formulas(35) = "CARGA='" + Format(DVarios.RecordSet("PROMCARGA"), "0.00") + "'"
            End If

            DVarios.Open("Select AVG(PORCGANANCIA) as PROMGANHUMEDAD from HUMEDADES where OP='" + TOPs.Text + "'")
            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMGANHUMEDAD")) Then Rep1.Formulas(38) = "GANHUMEDAD='" + Format(DVarios.RecordSet("PROMGANHUMEDAD"), "0.00") + "'"
                '---------------------------------------------------------------------------------------
                'En Palmira      
                '---------------------------------------------------------------------------------------
                'If InStr(1, Planta, "PALMIRA") > 0 Then
                '    If Not IsDBNull(DVarios.RecordSet("PROMHUMHAR")) Then Rep1.Formulas(24) = "PROMHUMHARINA='" + Format(DVarios.RecordSet("PROMHUMHAR"), "#,##0.00") + "'"
                '    If Not IsDBNull(DVarios.RecordSet("PROMHUMEMP")) Then Rep1.Formulas(25) = "PROMHUMEMPAQUE='" + Format(DVarios.RecordSet("PROMHUMEMP"), "#,##0.00") + "'"

                '    If Not IsDBNull(DVarios.RecordSet("DIFHUMEDAD")) Then
                '        If DVarios.RecordSet("DIFHUMEDAD") > 0 Then
                '            Rep1.Formulas(17) = "GANHUM='" + Format((DVarios.RecordSet("DIFHUMEDAD") - TotDosificado) / 100, "#,##0.00") + "'"
                '            Rep1.Formulas(18) = "PERHUM='" + Format(0, "#,##0.00") + "'"
                '        Else
                '            Rep1.Formulas(18) = "PERHUM='" + Format((DVarios.RecordSet("DIFHUMEDAD") - TotDosificado) / 100, "#,##0.00") + "'"
                '            Rep1.Formulas(17) = "GANHUM='" + Format(0, "#,##0.00") + "'"
                '        End If
                '    End If
                '    Dim Equipo As String = ""
                '    Dim NumPelets As Int32 = ReadConfigVar("NUMPELETS")

                '    DVarios.Open("select * from HUMEDADES where OP='" + TOP.Text + "'")
                '    If DVarios.Count > 0 Then
                '        For i = 1 To NumPelets
                '            DVarios.Find("MAQUINA=" + i.ToString)
                '            If DVarios.EOF = False Then
                '                Equipo += i.ToString
                '            End If
                '        Next
                '    End If
                '    Rep1.Formulas(27) = "EQUIPO='" + Trim(Equipo) + "'"
                '    If TotDosificado > 0 Then
                '        Rep1.Formulas(39) = "CONSUMOENER='" + Format(Eval(EnergiaTot / (TotDosificado / 1000)), "0.00") + "'"
                '    End If
                'End If
                '---------------------------------------------------------------------------------------

            End If

            DConsultas.Refresh()

            DConsultas.RecordSet("T8") = "PELET"
            DConsultas.Update()

            'Abrimos la consulta para sacar promedio por presentacion Pelet
            DVarios.Open("select * from CAVGTAMIZADOS where OP='" + TOPs.Text + "'")

            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM8")) Then Rep1.Formulas(40) = "PORCM8PELET='" + Format(DVarios.RecordSet("PROMPORCM8"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM12")) Then Rep1.Formulas(41) = "PORCM12PELET='" + Format(DVarios.RecordSet("PROMPORCM12"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM16")) Then Rep1.Formulas(42) = "PORCM16PELET='" + Format(DVarios.RecordSet("PROMPORCM16"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCPLATO")) Then Rep1.Formulas(43) = "PORCPLATOPELET='" + Format(DVarios.RecordSet("PROMPORCPLATO"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCDURABILIDAD")) Then Rep1.Formulas(44) = "PORCDURABILIDADPELET='" + Format(DVarios.RecordSet("PROMPORCDURABILIDAD"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMDUREZA")) Then Rep1.Formulas(45) = "DUREZAPELET='" + Format(DVarios.RecordSet("PROMDUREZA"), "0.00") + "'"
            End If

            DConsultas.Refresh()

            DConsultas.RecordSet("T8") = "QUEB"
            DConsultas.Update()

            ''Abrimos la consulta para sacar promedio por presentacion Pelet
            DVarios.Open("select * from CAVGTAMIZADOS where OP='" + TOPs.Text + "'")

            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM8")) Then Rep1.Formulas(46) = "PORCM8QUEB='" + Format(DVarios.RecordSet("PROMPORCM8"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM12")) Then Rep1.Formulas(47) = "PORCM12QUEB='" + Format(DVarios.RecordSet("PROMPORCM12"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM16")) Then Rep1.Formulas(48) = "PORCM16QUEB='" + Format(DVarios.RecordSet("PROMPORCM16"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCPLATO")) Then Rep1.Formulas(49) = "PORCPLATOQUEB='" + Format(DVarios.RecordSet("PROMPORCPLATO"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMPORCDURABILIDAD")) Then Rep1.Formulas(50) = "PORCDURABILIDADQUEB='" + Format(DVarios.RecordSet("PROMPORCDURABILIDAD"), "0.00") + "'"
                If Not IsDBNull(DVarios.RecordSet("PROMDUREZA")) Then Rep1.Formulas(51) = "DUREZAQUEB='" + Format(DVarios.RecordSet("PROMDUREZA"), "0.00") + "'"
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub FInfProduc_Click(sender As Object, e As EventArgs) Handles FInfProduc.Click
        Try
            Dim DOPs As New AdoSQL("OPS")
            Dim DRetaque As New AdoSQL("RETAQUE")
            Dim DEmp As New AdoSQL("Empaque")
            Dim DBaches As New AdoSQL("BACHES")
            Dim DVarios As New AdoSQL("VARIOS")
            Dim DControlDiaPelet As New AdoSQL("ControlDia")
            Dim DExclusionesPT As New AdoSQL("ExclusionesPT")

            Dim Datos2, Datos3 As String
            Dim HorasEmp As String
            Dim HorasPelet As New List(Of String)
            Dim HorasTurno As String
            Dim Mezclado, Vaceo, Pelet1, Pelet2, Pelet3, Pelet4, Pelet5, Emp1, Emp2, Emp3, Emp4, Emp5 As String
            Dim TamN As Int32 = 11
            Dim TiempoMto As String
            Dim TiempoMtoPelet As New List(Of String)
            Dim TiempoMtoEmp As String
            Dim NomGranel As String
            Dim CodLimpieza As String = ""

            DRetaque.Open("SELECT SUM(dbo.Retaque.PesoReal)/1000 AS TotalVaceo " +
                        "FROM Retaque where LINEA<=10 AND FechaIni >='" + FechaIni + "' and fechafin<'" + FechaFin + "' ")

            DBaches.Open("select SUM(CConsumos.PesoReal)/1000 as TotalMezclado from CConsumos where Fecha>='" + FechaIni + "' and  Fecha<'" + FechaFin + "' ")

            '--------------------------------------------------------------------------------------------------------------------------------
            ' Palmira
            '--------------------------------------------------------------------------------------------------------------------------------
            'If Planta.Contains("PALMIRA") Then
            '    DControlDiaPelet.Open("select SUM(TotTn)as TotalPelet,Maquina from " +
            '                   "DATOSPELETS   " +
            '                   " where Fecha >='" + FechaIni + "'  AND Fecha <'" + FechaFin + "' AND OP> '0' AND IPel> 10" +
            '                   " group by Maquina")
            'Else
            DControlDiaPelet.Open("select SUM(TonReal)as TotalPelet,Maquina from ControlDiario   " +
                                     " where Fecha >='" + FechaIni + "'  AND Fecha <'" + FechaFin + "' " +
                                     " group by Maquina")
            'End If
            '--------------------------------------------------------------------------------------------------------------------------------   

            DEmp.Open("SELECT SUM(dbo.Empaque.Sacos + dbo.Empaque.SacosAjuste + dbo.Empaque.SacosNC + dbo.Empaque.Reproceso)AS TotalEmp, " +
                    "sum((dbo.Empaque.Sacos + dbo.Empaque.SacosAjuste + dbo.Empaque.SacosNC + dbo.Empaque.Reproceso)-PresKg)/1000 AS TotalKg," +
                     "Maquina FROM         dbo.Empaque INNER JOIN " +
                    "dbo.Consultas ON dbo.Empaque.Fechaini >= dbo.Consultas.F1 AND dbo.Empaque.Fechaini < dbo.Consultas.F2 " +
                    "group by Maquina")
            '---------------------------------------------------------------------------------------------------------------------------------
            ' Barranquilla, Funza Premezclas, Girardota, Girardota Premezclas, Pereira, Yarumal
            '---------------------------------------------------------------------------------------------------------------------------------
            'DEmp.Open("SELECT SUM(dbo.Empaque.Sacos + dbo.Empaque.SacosAjuste + dbo.Empaque.SacosNC + dbo.Empaque.Reproceso)AS TotalEmp, " +
            '        "sum(dbo.Empaque.Peso+dbo.Empaque.Residuo+dbo.Empaque.PesoAjuste+(Reproceso+SacosNC)-PresKg)/1000 AS TotalKg," +
            '         "Maquina FROM         dbo.Empaque INNER JOIN " +
            '        "dbo.Consultas ON dbo.Empaque.Fechaini >= dbo.Consultas.F1 AND dbo.Empaque.Fechaini < dbo.Consultas.F2 " +
            '        "group by Maquina")
            '---------------------------------------------------------------------------------------------------------------------------------
            If DBaches.Count = 0 Then
                MsgBox("No hay datos de consumos para generar el informe", MsgBoxStyle.Information)
                Return
            End If

            If DRetaque.Count = 0 Then
                MsgBox("No hay datos de vaceo para generar el informe", MsgBoxStyle.Information)
                Return
            End If
            If DControlDiaPelet.Count = 0 Then
                MsgBox("No hay datos de peletizado para generar el informe", MsgBoxStyle.Information)
                Return
            End If
            If DEmp.Count = 0 Then
                MsgBox("No hay datos de empaque para generar el informe", MsgBoxStyle.Information)
                Return
            End If

            Datos = ""

            If Not IsDBNull(DBaches.RecordSet("TotalMezclado")) Then
                Datos += Eval(Format(DBaches.RecordSet("TotalMezclado"), ".000")).ToString + ","
            Else
                Datos += New String(" ", TamN) + ","
            End If

            If Not IsDBNull(DRetaque.RecordSet("TotalVaceo")) Then
                Datos += Eval(Format(DRetaque.RecordSet("TotalVaceo"), ".000")).ToString + ","
            Else
                Datos += New String(" ", TamN) + ","
            End If

            For i As Int32 = 1 To 5 'Cinco Pelet
                'DControlDiaPelet.Find("MAQUINA=" + i.ToString)
                DControlDiaPelet.Find("MAQUINA = 'P" + i.ToString + "'")    ' Barranquilla, Funza Premezclas, Girardota, Girardota Premezclas, Yarumal
                If DControlDiaPelet.EOF = False Then
                    Datos += Eval(Format(DControlDiaPelet.RecordSet("TotalPelet"), ".000")).ToString + ","
                Else
                    Datos += New String(" ", TamN) + ","
                End If
            Next

            For i As Int32 = 1 To 10 'Cinco Empacadoras
                DEmp.Find("MAQUINA=" + i.ToString)
                If DEmp.EOF = False Then
                    Datos += DEmp.RecordSet("TotalEmp").ToString + "," 'Sacos
                Else
                    Datos += New String(" ", TamN) + ","
                End If
                '-----------------------------------------------------------------------
                ' Barranquilla, Funza Premezclas, Girardota, Girardota Premezclas, Pereira, Yarumal
                '-----------------------------------------------------------------------
                'If i <> 3 Then
                '    Datos += DEmp.RecordSet("TotalEmp").ToString + "," 'Sacos
                'Else
                '    Datos += DEmp.RecordSet("TotalKg").ToString + "," 'Sacos
                'End If
                '-----------------------------------------------------------------------
            Next
            '-------------------------------------------- Promedio TON/H ----------------------------------------
            'Calculo de Horas turno y tiempos muertos
            'If Planta.Contains("PALMIRA") Then
            DVarios.Open("select SUM(Tiempo) as TiempoMto from TMuertos where PROCESO='DOSIF' and FECHA>='" + FechaIni + "' and FECHA<'" + FechaFin + "'")
            'Else
            '    DVarios.Open("Select SUM(TmpoMto) as TiempoMto from BACHES where FECHA>='" + FechaIni + "' and FECHA<'" + FechaFin + "' and TmpoMto>5")
            'End If

            If Not IsDBNull(DVarios.RecordSet("TIEMPOMTO")) Then
                TiempoMto = Eval(Format(DVarios.RecordSet("TiempoMto"), "0.00")).ToString
            Else
                TiempoMto = 0
            End If

            HorasTurno = DateDiff(DateInterval.Hour, CDate(FechaIni), CDate(FechaFin)).ToString

            'If Planta.Contains("PALMIRA") Then
            '    DVarios.Open("select sum(TpFP+TpTvLLn+TpAR+TpCD+TpMtto+TpCP)/60 AS TiempoMtoPelet,MAQUINA from DatosPelets where FECHA>='" + FechaIni + "' and FECHA<'" + FechaFin + "' group by MAQUINA")
            'Else
            DVarios.Open("select SUM(TIEMPOMTO) AS TiempoMtoPelet,MAQUINA from ControlDiario where FECHA>='" + FechaIni + "' and FECHA<'" + FechaFin + "' group by MAQUINA")
            'End If

            For i As Integer = 0 To 5
                TiempoMtoPelet.Add(0)
                HorasPelet.Add(0)
            Next

            For i As Int32 = 1 To 5 'Cinco Pelet
                DVarios.Find("MAQUINA= 'P" + i.ToString + "'")
                If DVarios.EOF = False Then
                    If Not IsDBNull(DVarios.RecordSet("TiempoMtoPelet")) Then
                        TiempoMtoPelet(i) = Eval(Format(DVarios.RecordSet("TiempoMtoPelet"), "0.00")).ToString
                    Else
                        TiempoMtoPelet(i) = 0
                    End If
                    HorasPelet(i) = DateDiff(DateInterval.Hour, CDate(FechaIni), CDate(FechaFin)).ToString
                End If
            Next

            'DVarios.Open("select SUM(TIEMPO) as TiempoMtoEmp from TMuertos where Proceso='ENSAQ' and FECHA>='" + FechaIni + "' and FECHA<'" + FechaFin + "'")

            TiempoMtoEmp = 0
            HorasEmp = DateDiff(DateInterval.Hour, CDate(FechaIni), CDate(FechaFin)).ToString

            If Eval(HorasTurno) = 0 Then HorasTurno = 0.0000001
            '----------------------------------------------------------------------
            Datos1 = ""

            If Not IsDBNull(DBaches.RecordSet("TotalMezclado")) Then
                Datos1 = Eval(Format(DBaches.RecordSet("TotalMezclado") / Eval(HorasTurno), ".000")).ToString + ","
            Else
                Datos1 += New String(" ", TamN) + ","
            End If

            If Not IsDBNull(DRetaque.RecordSet("TotalVaceo")) Then
                Datos1 += Eval(Format(DRetaque.RecordSet("TotalVaceo") / Eval(HorasTurno), ".000")).ToString + ","
            Else
                Datos1 += New String(" ", TamN) + ","
            End If

            For i As Int32 = 1 To 5 'Cinco Pelet
                DControlDiaPelet.Find("MAQUINA = 'P" + i.ToString + "'")
                If DControlDiaPelet.EOF = False Then
                    Datos1 += Eval(Format(DControlDiaPelet.RecordSet("TotalPelet") / (Eval(HorasPelet(i) + 0.00001)), ".000")).ToString + ","
                Else
                    Datos1 += "0,"
                End If
            Next

            For i As Int32 = 1 To 5 'Cinco Empacadoras
                DEmp.Find("MAQUINA=" + i.ToString)
                If DEmp.EOF = False Then
                    Datos1 += Eval(Format(DEmp.RecordSet("TotalKg") / Eval(HorasEmp), ".000")).ToString + "," 'Peso
                Else
                    Datos1 += "0,"
                End If
            Next
            'Datos += Chr(10)

            ' ---------- Horas Productivas -----------------------
            Datos2 = HorasTurno + ","
            Datos2 += HorasTurno + ","
            For i As Integer = 1 To 5
                Datos2 += HorasPelet(i) + ","
            Next
            For i As Integer = 1 To 5
                Datos2 += HorasEmp + ","
            Next
            ' ----------------- Tiempos Muertos

            Datos3 = TiempoMto + ","
            Datos3 += "0," 'Vaceo va en cero no hay tiempos muertos
            For i As Integer = 1 To 5
                Datos3 += TiempoMtoPelet(i) + ","
            Next
            For i As Integer = 1 To 5
                Datos3 += TiempoMtoEmp + ","
            Next
            ' -------------------- Alistamiento de los produtos liquidados ---------------------------

            Dim DatosInf(), DatosInf1(), DatosInf2(), DatosInf3() As String
            DatosInf = Datos.Split(",")
            DatosInf1 = Datos1.Split(",")
            DatosInf2 = Datos2.Split(",")
            DatosInf3 = Datos3.Split(",")

            Mezclado = DatosInf(0).PadLeft(TamN, " ") + "#" + DatosInf1(0).PadLeft(TamN, " ") + "#" + DatosInf2(0).PadLeft(TamN, " ") + "#" + DatosInf3(0).PadLeft(TamN, " ") + "#"
            Vaceo = DatosInf(1).PadLeft(TamN, " ") + "=" + DatosInf1(1).PadLeft(TamN, " ") + "=" + DatosInf2(1).PadLeft(TamN, " ") + "=" + DatosInf3(1).PadLeft(TamN, " ") + "="
            Pelet1 = DatosInf(2).PadLeft(TamN, " ") + "^" + DatosInf1(2).PadLeft(TamN, " ") + "^" + DatosInf2(2).PadLeft(TamN, " ") + "^" + DatosInf3(2).PadLeft(TamN, " ") + "^"
            Pelet2 = DatosInf(3).PadLeft(TamN, " ") + "?" + DatosInf1(3).PadLeft(TamN, " ") + "?" + DatosInf2(3).PadLeft(TamN, " ") + "?" + DatosInf3(3).PadLeft(TamN, " ") + "?"
            Pelet3 = DatosInf(4).PadLeft(TamN, " ") + "¡" + DatosInf1(4).PadLeft(TamN, " ") + "¡" + DatosInf2(4).PadLeft(TamN, " ") + "¡" + DatosInf3(4).PadLeft(TamN, " ") + "¡"
            Pelet4 = DatosInf(5).PadLeft(TamN, " ") + "{" + DatosInf1(5).PadLeft(TamN, " ") + "{" + DatosInf2(5).PadLeft(TamN, " ") + "{" + DatosInf3(5).PadLeft(TamN, " ") + "{"
            Pelet5 = DatosInf(6).PadLeft(TamN, " ") + "!" + DatosInf1(6).PadLeft(TamN, " ") + "!" + DatosInf2(6).PadLeft(TamN, " ") + "!" + DatosInf3(6).PadLeft(TamN, " ") + "!"
            Emp1 = DatosInf(7).PadLeft(TamN, " ") + "%" + DatosInf1(7).PadLeft(TamN, " ") + "%" + DatosInf2(7).PadLeft(TamN, " ") + "%" + DatosInf3(7).PadLeft(TamN, " ") + "%"
            Emp2 = DatosInf(8).PadLeft(TamN, " ") + "(" + DatosInf1(8).PadLeft(TamN, " ") + "(" + DatosInf2(8).PadLeft(TamN, " ") + "(" + DatosInf3(8).PadLeft(TamN, " ") + "("
            Emp3 = DatosInf(9).PadLeft(TamN, " ") + ")" + DatosInf1(9).PadLeft(TamN, " ") + ")" + DatosInf2(9).PadLeft(TamN, " ") + ")" + DatosInf3(9).PadLeft(TamN, " ") + ")"
            Emp4 = DatosInf(10).PadLeft(TamN, " ") + "[" + DatosInf1(10).PadLeft(TamN, " ") + "[" + DatosInf2(10).PadLeft(TamN, " ") + "[" + DatosInf3(10).PadLeft(TamN, " ") + "["
            Emp5 = DatosInf(11).PadLeft(TamN, " ") + "]" + DatosInf1(11).PadLeft(TamN, " ") + "]" + DatosInf2(11).PadLeft(TamN, " ") + "]" + DatosInf3(11).PadLeft(TamN, " ") + "]"

            Datos1 = Mezclado + Vaceo + Pelet1 + Pelet2 + Pelet3 + Pelet4 + Pelet5 + Emp1 + Emp2 + Emp3 + Emp4 + Emp5

            Dim OPAnt As String = ""
            DBaches.Open("select OP from BACHES where FECHA>'" + FechaIni + "' and FECHA<'" + FechaFin + "' order by CONT ")

            BachesMezclados = 0
            If DBaches.Count > 0 Then
                BachesMezclados = DBaches.Count
                OPAnt = DBaches.RecordSet("OP")
            End If

            Corridas = 0
            For Each Record As DataRow In DBaches.Rows
                If Record("OP") <> OPAnt Then
                    OPAnt = Record("OP")
                    Corridas = (Eval(Corridas) + 1).ToString
                End If
            Next

            DExclusionesPT.Open("select * from EXCLUSIONESPT where PROCESO = 'LIMPIEZA'")

            For Each Recordset As DataRow In DExclusionesPT.Rows
                CodLimpieza += Recordset("CODIGO") + ","
            Next
            CodLimpieza = CodLimpieza.Trim(",")

            DBaches.Open("SELECT sum(PesoReal)/1000 AS TotLimpieza FROM  dbo.Baches " +
                        " where dbo.Baches.Fecha >='" + FechaIni + "' AND dbo.Baches.Fecha <'" + FechaFin + "' " +
                        " and CodFor IN ('" + CodLimpieza + "')")
            '-------------------------------------------------------------------------------------------------------
            'Funza Premezclas, Pereira, Yarumal
            '-------------------------------------------------------------------------------------------------------
            'DBaches.Open("SELECT sum(PesoReal)/1000 AS TotLimpieza FROM  " +
            '            "dbo.Baches " +
            '            " where dbo.Baches.Fecha >='" + FechaIni + "' AND dbo.Baches.Fecha <'" + FechaFin + "' " +
            '            " and CodFor='50'")
            '-------------------------------------------------------------------------------------------------------
            'Palmira
            '-------------------------------------------------------------------------------------------------------
            'DBaches.Open("SELECT sum(PesoReal)/1000 AS TotLimpieza FROM  " +
            '            "dbo.Baches " +
            '            " where dbo.Baches.Fecha >='" + FechaIni + "' AND dbo.Baches.Fecha <'" + FechaFin + "' " +
            '            " and (CodFor='303035' AND CodFor='300004')")
            '-------------------------------------------------------------------------------------------------------

            TonLimpieza = 0
            If IsDBNull(DBaches.RecordSet("TotLimpieza")) = False Then TonLimpieza = Format(DBaches.RecordSet("TotLimpieza"), "0.000")

            DOPs.Open("SELECT dbo.OPs.OP, dbo.Articulos.Nombre, dbo.OPs.SackOffKg, dbo.OPs.SackOffPorc, dbo.OPs.ObservFinPlanilla " +
                    "FROM dbo.OPs INNER JOIN " +
                    "dbo.Articulos ON dbo.OPs.CodProd = dbo.Articulos.CodInt " +
                    "where FechaFinPlanilla >='" + FechaIni + "' AND dbo.OPs.FechaFinPlanilla<'" + FechaFin + "' and FINPLANILLA='S'")


            OPLiq = ""
            NomLiq = ""
            SackoffLiq = ""
            SackOffPor = ""
            Datos = ""
            For Each RecordOp As DataRow In DOPs.Rows
                OPLiq += RecordOp("OP").ToString.PadRight(TamN, " ")
                NomLiq += CLeft(RecordOp("Nombre"), 15).ToString.PadRight(15, " ")
                Datos += CLeft(RecordOp("Nombre"), 20).ToString.PadRight(20, " ") + "="
                SackoffLiq += CalcSackOff(RecordOp("OP"), Valor.Kilogramos).ToString.PadRight(TamN, " ")
                SackOffPor += CalcSackOff(RecordOp("OP"), Valor.Porcentaje).ToString.PadRight(TamN, " ")
            Next

            DEmp.Open("SELECT SUM(dbo.Empaque.Peso)AS TotalKg, " +
                    "OP,min(NomProd) as Nombre FROM  dbo.Empaque where Fechaini>='" + FechaIni + "' and  Fechaini<'" + FechaFin + "' " +
                    " and TIPO='GRANEL' group by OP")

            OPGranel = ""
            NomGranel = ""
            CantGranel = ""
            For Each RecordEmp As DataRow In DEmp.Rows
                OPGranel += RecordEmp("OP").ToString.PadRight(TamN, " ")
                NomGranel += CLeft(RecordEmp("Nombre"), 15).ToString.PadRight(15, " ")
                Datos += CLeft(RecordEmp("Nombre"), 20).ToString.PadRight(20, " ") + "#"
                CantGranel += RecordEmp("TotalKg").ToString.PadRight(TamN, " ")
                'Datos3 += Chr(10)

            Next

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

End Class
