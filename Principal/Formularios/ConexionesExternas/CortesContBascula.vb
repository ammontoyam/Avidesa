Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class CortesContBascula
    Private DConceptos As AdoSQL
    Private DCortesMP As AdoSQL
    Private DArt As AdoSQL
    Private DTiqDet As AdoSQL
    Private DVarios As AdoSQL
    Private DTolvas As AdoSQL
    Private Sentencia As String = ""
    Private Fila As Int32
    Private Campos() As String
    Private Cont As Double
    Private DOBsCortesMP As AdoSQL
    Private DMovEntSal As AdoSQL
    Private DTercero As AdoSQL
    Private DEmpaque As AdoSQL
    Private DOPs As AdoSQL
    Private DRet As AdoSQL
    Private FormLoad As Boolean


    Public Sub CortesControlBascula_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then Return

            'Dim TextCptos As String = ""
            'Dim Cptos() As String


            'Conexión con base de datos controlbascula
            DTiqDet = New AdoSQL("ControlBascula tabla tqte_dtlle", RutaDB_ControlBascula)
            DTercero = New AdoSQL("ControlBascula tabla trcro", RutaDB_ControlBascula)
            ''Descomentar para pruebas LOCALES
            'DTiqDet = New AdoSQL("ControlBascula tabla tqte_dtlle")
            'DTercero = New AdoSQL("ControlBascula tabla trcro")

            'Conexión base de datos ChronoSoft
            DArt = New AdoSQL("ARTICULOS")
            DArt.Open("Select * from ARTICULOS")

            DCortesMP = New AdoSQL("CORTESMP")
            DVarios = New AdoSQL("VARIOS")
            DOBsCortesMP = New AdoSQL("OBSCORTESMP")
            DMovEntSal = New AdoSQL("MOVENTSAL")
            DEmpaque = New AdoSQL("EMPAQUE")
            DOPs = New AdoSQL("OPS")
            DConceptos = New AdoSQL("CONCEPTOSCONTBASC")
            DRet = New AdoSQL("RETAQUE")
            DTolvas = New AdoSQL("TOLVAS")

            Sentencia = ""
            'Leemos los conceptos en la nueva tabla "CONCEPTOSCONTBASC"
            Dconceptos.Open("Select * from CONCEPTOSCONTBASC")

            For Each Reg As DataRow In Dconceptos.Rows
                Sentencia = Sentencia + "'" + Reg("CONCEPTO") + "',"
            Next
            Sentencia = Sentencia.Trim(",")

            DTiqDet.Open("Select * from tqte_dtlle where CNCPTO IN (" + Sentencia + ") and (td_rowid>" + ConfigParametros("ULTCONTADORCB") + ") order by td_rowid")

            AsignaDataGrid(DGCortesNept, DTiqDet.DataTable)

            Campos = {"ARTCLO@Cod.Mat", "LTE@Lote", "CNCPTO@Concpto"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DTiqDet.DataTable)

            If DGCortesNept.Rows.Count > 0 AndAlso Me.Visible Then DGCortesNept_CellClick(Nothing, Nothing)

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGCortesNept_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            If DGCortesNept.Rows.Count = 0 Then Return
            mnLCuenta.Text = DGCortesNept.Rows.Count.ToString
            Fila = DGCortesNept.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString

            Dim CodARTCLO As String = DGCortesNept.Rows(DGCortesNept.CurrentRow.Index).Cells("ARTCLO").Value.ToString

            DArt.Find("CODINT='" + CodARTCLO + "'")

            If DArt.EOF Then
                MsgBox("Material: " + CodARTCLO + " no registrado en ChronoSoft", MsgBoxStyle.Critical)
                Return
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub FRefrescaDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRefrescaDG.Click
        Try
            DTiqDet.Open("Select * from tqte_dtlle where CNCPTO IN (" + Sentencia + ") and (td_rowid>" + ConfigParametros("ULTCONTADORCB") + ") order by td_rowid")
            AsignaDataGrid(DGCortesNept, DTiqDet.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGCortesNept.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGCortesNept.RowCount - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            Fila += 1
            If Fila > indifila Then Fila = indifila

            DGCortesNept.Rows(Fila).Selected = True
            DGCortesNept.FirstDisplayedScrollingRowIndex = Fila
            DGCortesNept.CurrentCell = DGCortesNept(0, Fila)
            DGCortesNept_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGCortesNept.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGCortesNept.Rows(Fila).Selected = True
            DGCortesNept.FirstDisplayedScrollingRowIndex = Fila
            DGCortesNept.CurrentCell = DGCortesNept(0, Fila)
            DGCortesNept_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGCortesNept.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGCortesNept.Rows(Fila).Selected = True
            DGCortesNept.FirstDisplayedScrollingRowIndex = Fila
            DGCortesNept.CurrentCell = DGCortesNept(0, Fila)
            DGCortesNept_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGCortesNept.Rows.Count = 0 Then Exit Sub
            Fila = DGCortesNept.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGCortesNept.Rows(Fila).Selected = True
            DGCortesNept.FirstDisplayedScrollingRowIndex = Fila
            DGCortesNept.CurrentCell = DGCortesNept(0, Fila)

            DGCortesNept_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGCortesNept_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        DGCortesNept_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGCortesNept_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        DGCortesNept_CellClick(Nothing, Nothing)
    End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                FRefrescaDG_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub

            BusquedaDG(DGCortesNept, DTiqDet.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGCortesNept_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try
            Cont = Cont + 1
            If Cont > 100000 Then Cont = 1
            If ServComM = True AndAlso Cont Mod 60 = 0 Then
                FImport_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub FImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FImport.Click
        Try
            Dim TipoOperacion As String = ""
            Dim Placa As String = ""
            Dim CampoLote As String = ""
            Dim Lote As String = ""
            Dim Observacion As String = ""
            Dim UbicLote As String = ""
            Dim CodMat As String = ""
            Dim Consecutivo As String = ""
            Dim Td_RowId_CB As String = "" 'Variable para almacenar el id de lac tabla de controlbascula, para no repetir ingresos
            Dim UltContadorCB As String = ConfigParametros("ULTCONTADORCB")

            If VerificarConexionDB(RutaDB_ControlBascula) = False Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " conexión con base de datos Control Báscula. No se importará los cortes de materia prima", vbCritical)
                Return
            End If


            'Se abre el recordset con los registros pendientes por realizar las importaciones de cortes de lote

            'DTiqDet.Open("Select * from tqte_dtlle where (" + Sentencia + ") and (td_rowid>" + ReadConfigVar("ULTCONTADORCB") + ") order by td_rowid")
            'If Planta.Contains("NOBOL") Then
            '    DTiqDet.Open("Select * from tqte_dtlle where CNCPTO IN (" + Sentencia + ") and (cnsctvo>" + UltContadorCB + ") order by td_rowid")
            'Else
            DTiqDet.Open("Select * from tqte_dtlle where CNCPTO IN (" + Sentencia + ") and (td_rowid>" + UltContadorCB + ") order by td_rowid")
            'End If


            For Each Recordset As DataRow In DTiqDet.Rows


                Td_RowId_CB = Recordset("td_rowid")


                WriteConfigParametros("ULTCONTADORCB", Td_RowId_CB)

                DConceptos.Find("CONCEPTO = '" + Recordset("cncpto") + "'")

                Placa = Recordset("PLCA")
                Consecutivo = Recordset("cnsctvo")

                Observacion = DConceptos.RecordSet("DESCRIPCION") + "  TIQ: " + Consecutivo + "  PLACA: " + Placa
                TipoOperacion = DConceptos.RecordSet("TIPOMOV")

                CampoLote = DConceptos.RecordSet("TIPOLOTE")
                Lote = Recordset(CampoLote).ToString.Trim
                If Lote = "" Then Continue For 'Si el lote es vacio se descarta el lote

                UbicLote = Recordset("ubccion")
                '-------------------------------------------------------------------------------------------------------------------------------------------



                '-------------------------------------------------------------------------------------------------------------------------------------------
                ''Abrimos la table tqte de controlbascula para sacar la ubicacion del lote
                'DTiq.Open("Select TOP 1 dstno from TQTE where cnsctvo=" + consecutivo + " order BY FCHA DESC")
                'If DTiq.Count Then

                'End If

                If TipoOperacion = "ENTRADA" Or TipoOperacion = "SALIDA" Then
                    'Sacamos el valor del articulo porque en controlbascula esta con ceros a la izquierda
                    CodMat = Val(Recordset("ARTCLO")).ToString

                    If CodMat = 0 Then Continue For


                    'Si comat=62 se cambia por el 56 para que quede el corte en chronosoft, ya que el 62 que es frijol no esta en chronosoft, esta el 56
                    '   ue es frijol cocinado, a este se le realiza corte
                    If Planta.Contains("PALMIRA") Then
                        If CodMat = 62 Then CodMat = 56
                    End If


                    DArt.Open("select * from ARTICULOS where CODINT='" + CodMat + "' and TIPO='MP' And MANEJACORTELOTE = 1")

                    'si el material no se encuentra registrado en la tabla articulos continua con el sgt
                    If DArt.Count = 0 Then Continue For

                    'If DArt.RecordSet("LINEA") = "ADITIVOS" Then
                    '    'Si la materia prima es de la linea de inventario aditivos se descarta el lote
                    '    GoTo DescartarLote
                    'End If

                    'Traslados internos en funza
                    If Funcion_AlimentaTolvasDesdeCB And Recordset("cncpto") = "F12" Then
                        Dim Bultos As Int16 = 0
                        If Not IsDBNull(Recordset("cntdad")) Then Bultos = Recordset("cntdad")
                        AlimentaTolva(DArt.RecordSet("CODINT").ToString, Lote, Recordset("KLOS"), Observacion, Bultos)
                    End If

                    DCortesMP.Open("Select * from CORTESLOTE where CODMAT='" + DArt.RecordSet("CODINT") + "' and LOTE='" + Lote + "' and FINALIZADO<>'S' and UBICLOTE='" + UbicLote + "'")

                    If DCortesMP.Count > 0 Then

                        'DOBsCortesMP.Open("Select * from OBSCORTESMP where CORTE=0")
                        'Se revisa si el ID de controlbascula ya se adicionó a la tabla de ChronoSoft
                        DOBsCortesMP.Open("Select * from OBSCORTESMP where CORTE=" + DCortesMP.RecordSet("CONT").ToString + " AND TdRowIDCB=" + Td_RowId_CB)
                        'No debe haber ninguna observación con ese ID de controlbascula, si ya existe 
                        If DOBsCortesMP.Count Then Continue For

                        DOBsCortesMP.AddNew()
                        DOBsCortesMP.RecordSet("CORTE") = DCortesMP.RecordSet("CONT")
                        DOBsCortesMP.RecordSet("CANTIDAD") = Recordset("KLOS")
                        DOBsCortesMP.RecordSet("FECHA") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        DOBsCortesMP.RecordSet("PLACA") = Placa
                        DOBsCortesMP.RecordSet("OBSERVACION") = Observacion
                        DOBsCortesMP.RecordSet("UBICLOTE") = UbicLote
                        DOBsCortesMP.RecordSet("TDROWIDCB") = Td_RowId_CB

                        If TipoOperacion = "SALIDA" Then DOBsCortesMP.RecordSet("TIPO") = 4
                        If TipoOperacion = "ENTRADA" Then DOBsCortesMP.RecordSet("TIPO") = 3

                        DOBsCortesMP.Update()

                        'Se revisan todas las entradas y salidas para colocar el ajuste 

                        DVarios.Open(" select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + DCortesMP.RecordSet("CONT").ToString + " and TIPO=3")

                        If Not IsDBNull(DVarios.RecordSet("Acum")) Then DCortesMP.RecordSet("AJUSTE3") = DVarios.RecordSet("Acum")

                        DVarios.Open(" select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + DCortesMP.RecordSet("CONT").ToString + " and TIPO=4")

                        If Not IsDBNull(DVarios.RecordSet("Acum")) Then DCortesMP.RecordSet("AJUSTE4") = -DVarios.RecordSet("Acum")

                    Else
                        'RespInput = MsgBox("¿No existe un corte para este material y lote, desea crear uno nuevo?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
                        'If RespInput = vbNo Then GoTo Salir
                        DCortesMP.AddNew()
                        DVarios.Open("select max(CORTESLOTE.CONT) AS CONTMAX from CORTESLOTE")
                        DCortesMP.RecordSet("CONT") = 1
                        If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("CONTMAX")) Then DCortesMP.RecordSet("CONT") = DVarios.RecordSet("CONTMAX") + 1
                        DCortesMP.RecordSet("CODMAT") = DArt.RecordSet("CODINT")
                        DCortesMP.RecordSet("NOMMAT") = DArt.RecordSet("NOMBRE")
                        DCortesMP.RecordSet("NOMMAT") = DArt.RecordSet("NOMBRE")
                        DCortesMP.RecordSet("FECHAENT") = FechaC()

                        'Se busca la linea para actualizar el porcentaje de merma

                        DVarios.Open("select * from LINEASPROD where TIPO='MP' and LINEA='" + DArt.RecordSet("LINEA") + "'")

                        If DVarios.Count Then
                            DCortesMP.RecordSet("PORCMERMA") = DVarios.RecordSet("PORCMERMA")
                            DCortesMP.RecordSet("LINEA") = DVarios.RecordSet("LINEA")
                        End If

                        DCortesMP.RecordSet("INVINI") = Recordset("KLOS")
                        DCortesMP.RecordSet("LOTE") = Lote
                        DCortesMP.RecordSet("ALARMA") = Math.Round(Recordset("KLOS") * 0.01, 2)
                        DCortesMP.RecordSet("ESTADO") = "C"
                        DCortesMP.RecordSet("UBICLOTE") = UbicLote

                        'Bucamos la descripción del codigo de la ubicación del lote
                        DVarios.Open("select DESCRIPCION from UBICACIONES where CODUBI='" + UbicLote + "'")

                        If DVarios.Count Then
                            DCortesMP.RecordSet("DESCUBICLOTE") = DVarios.RecordSet("DESCRIPCION")
                        End If


                        If Not IsDBNull(Recordset("CNTDAD")) Then
                            If Not IsDBNull(DCortesMP.RecordSet("SACOS")) Then
                                DCortesMP.RecordSet("SACOS") += Recordset("CNTDAD")
                            Else
                                DCortesMP.RecordSet("SACOS") = Recordset("CNTDAD")
                            End If
                        Else
                            DCortesMP.RecordSet("SACOS") = 0
                        End If

                        'llenamos el campo pesoprom de la tabla corteslote

                        If Not IsDBNull(DCortesMP.RecordSet("INVINI")) And DCortesMP.RecordSet("SACOS") > 0 Then
                            DCortesMP.RecordSet("PESOPROM") = Eval(Format((DCortesMP.RecordSet("INVINI") / DCortesMP.RecordSet("SACOS")), ".00"))
                        Else
                            DCortesMP.RecordSet("PESOPROM") = 0
                        End If

                    End If

                Else
                    'Tipo de operación GRANEL, se crea un registro automatico de empaque con el peso despachado y con 
                    'la OP que viene en el LOTE

                    DOPs.Open("select * from OPS where FINPLANILLA<>'S' and OP='" + Lote + "'")

                    If DOPs.Count = 0 Then
                        Alarma("No se crea registro de empaque, lote ingresado en báscula no existe en tabla OPs o está finalizada por planilla Lote: " + Lote)
                        Continue For
                    End If

                    DEmpaque.Open("select * from EMPAQUE where OP='" + Lote + "' and TdRowIDCB=" + Td_RowId_CB)

                    If DEmpaque.Count = 0 Then
                        DEmpaque.AddNew()
                    Else
                        Continue For
                    End If

                    DEmpaque.RecordSet("OP") = Lote
                    DEmpaque.RecordSet("CODPROD") = DOPs.RecordSet("CODPROD")
                    DEmpaque.RecordSet("TDROWIDCB") = Td_RowId_CB

                    DVarios.Open("select * from ARTICULOS where TIPO='PT' and CODINT='" + DOPs.RecordSet("CODPROD") + "'")

                    If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("LINEA")) Then
                        DEmpaque.RecordSet("LINEAINVENT") = DVarios.RecordSet("LINEA")
                        DEmpaque.RecordSet("GRPBASE") = DVarios.RecordSet("GRPBASE")
                        DEmpaque.RecordSet("NOMPROD") = DVarios.RecordSet("NOMBRE")
                        DEmpaque.RecordSet("PRESKG") = DVarios.RecordSet("PRESKG")
                    End If

                    DVarios.Open("select * from PRODEQUIVALENTES where PRESENT='GR' " + " and CODPROD='" + DOPs.RecordSet("CODPROD").ToString + "'")
                    If DVarios.Count = 0 Then
                        'Alarma("No se crea registro de empaque, no existe codprod equivalente para CODPROD: " + DOPs.RecordSet("CODPROD").ToString)
                        DEmpaque.RecordSet("CODPROD2") = DEmpaque.RecordSet("CODPROD")
                    Else
                        DEmpaque.RecordSet("CODPROD2") = DVarios.RecordSet("CODPRODEQUI")
                    End If

                    DEmpaque.RecordSet("MAQUINA") = 9
                    DEmpaque.RecordSet("PESO") = Recordset("KLOS")
                    DEmpaque.RecordSet("PRESEMP") = "GR"
                    DEmpaque.RecordSet("FECHAINI") = Format(Now, "yyyy/MM/dd HH:mm")
                    DEmpaque.RecordSet("FECHAFIN") = Format(Now, "yyyy/MM/dd HH:mm")
                    DEmpaque.RecordSet("TIPO") = "GRANEL"
                    DEmpaque.RecordSet("DETALLE") = Placa  'DTiqDet.RecordSet("PLCA")
                    DEmpaque.RecordSet("USUARIO") = "BASCULA"
                    DEmpaque.RecordSet("DESTINO") = "GR"
                    ''DEmpaque.RecordSet("RECEMP") = True
                    DEmpaque.RecordSet("FINALIZADO") = "S"
                    DEmpaque.Update()

                    Evento("Crea registro automático GRANEL tabla EMPAQUE OP: " + DOPs.RecordSet("OP").ToString + "' and PESO: " +
                           Recordset("KLOS").ToString + " Kg PLACA: " + DTiqDet.RecordSet("PLCA") + " CONTADOR CB:" + Td_RowId_CB)
                    Continue For
                End If

                'Creamos un registro nuevo en la tabla detalle de inventario con el lote creado

                'If Not IsDBNull(DCortesMP.RecordSet("LOTE")) Then
                '    Inventario(DCortesMP.RecordSet("CODMAT"), Recordset("KLOS"), TipoInv.CHRONOS, DCortesMP.RecordSet("LOTE"), DetOperacion.ENMP, , , , , , , , Usuario)
                'End If

                If TipoOperacion = "ENTRADA" Then
                    'Creamos un registro en la tabla MOVENTSAL por cada corte de lote creado
                    DMovEntSal.Open("Select * from MOVENTSAL where ID=0")

                    DMovEntSal.AddNew()

                    DMovEntSal.RecordSet("CODINT") = DArt.RecordSet("CODINT")
                    DMovEntSal.RecordSet("NOMBRE") = DArt.RecordSet("NOMBRE")
                    DMovEntSal.RecordSet("PLACA") = Recordset("PLCA")
                    DMovEntSal.RecordSet("FECHA") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                    DMovEntSal.RecordSet("CANTIDAD") = Recordset("KLOS")
                    DMovEntSal.RecordSet("TIPO") = TipoOperacion
                    DMovEntSal.RecordSet("LOTE") = Lote
                    DMovEntSal.RecordSet("CONTCORTE") = DCortesMP.RecordSet("CONT")

                    'Buscamos el nombre del cliente en la tabla tcro de controlbascula
                    If Not IsDBNull(Recordset("TRCRO")) AndAlso Recordset("TRCRO") <> "" Then
                        DTercero.Open("Select * from TRCRO where CDGO='" + Recordset("TRCRO") + "'")

                        If DTercero.Count > 0 Then
                            DMovEntSal.RecordSet("CODTERCERO") = CLeft(DTercero.RecordSet("CDGO"), 15)
                            DMovEntSal.RecordSet("NOMTERCERO") = CLeft(DTercero.RecordSet("NMBRE"), 30)
                        End If
                    End If

                    DMovEntSal.Update()

                End If

                DCortesMP.Update()


            Next

            'CortesMP.BActualizar_Click(Nothing, Nothing)
            'MsgBox("Proceso Finalizado", MsgBoxStyle.Information
            FRefrescaDG_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub AlimentaTolva(ByVal CodMat As String, ByVal Lote As String, ByVal Peso As Single, ByVal Observacion As String, ByVal Bultos As Int16)
        Try
            If CodMat = "" Or Lote = "" Or Peso = 0 Then Return

            'Se busca el código de material en la tabla tolvas, para saber a que tolva se cargará el inventario

            DTolvas.Open("Select * from TOLVAS where ACTIVA='X' and CODINT='" + CodMat + "'")
            If DTolvas.Count = 0 Then
                Evento("No se alimenta tolva, no existe la materia prima en tolva")
                Return
            End If
            DRet.Open("Select * from RETAQUE WHERE CONT=0")
            DRet.AddNew()
            DRet.RecordSet("TOLVA") = DTolvas.RecordSet("TOLVA")
            DRet.RecordSet("CODMAT") = CodMat
            DRet.RecordSet("ORIGEN") = 100
            DRet.RecordSet("NOMMAT") = DTolvas.RecordSet("NOMBRE")
            DRet.RecordSet("LINEA") = 4
            DRet.RecordSet("LOTE") = CLeft(Lote, 15)
            DRet.RecordSet("BULTOS") = Bultos
            If Bultos > 1 Then
                DRet.RecordSet("PROMBULTOS") = Math.Round(Peso / Bultos, 2)
            End If
            DRet.RecordSet("PROMBULTOS") = 0
            DRet.RecordSet("PESOREAL") = Peso
            DRet.RecordSet("FECHAFIN") = FechaC()
            DRet.RecordSet("FECHAINI") = FechaC()
            DRet.RecordSet("STATUS") = 1
            DRet.RecordSet("OPERARIO") = "BASCULA"
            DRet.RecordSet("MINUTOS") = 0
            DRet.RecordSet("OBSERVACION") = CLeft(Observacion, 30)

            DTolvas.RecordSet("TOTAL") = DTolvas.RecordSet("TOTAL") + Peso
            DTolvas.Update()

            Evento("Realiza Cargue desde CONTROLBASCULA a tolva " + DRet.RecordSet("TOLVA").ToString + " cantidad KG " + Peso.ToString + " LOTE: " + Lote)
            DRet.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImpTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImpTodos.Click
        Try
            FImport_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class