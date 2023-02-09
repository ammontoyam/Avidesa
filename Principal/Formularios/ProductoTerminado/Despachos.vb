Option Explicit On
Imports System.String
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Threading.Thread



Public Class Despachos
    Private ConnString As String
    Private DCONNCB As AdoSQL
    Private DEncFact As AdoSQL
    Private DDetalle As AdoSQL
    Private DMovInv As AdoSQL
    Private DVarios As AdoSQL
    Private DFacturas As AdoSQL
    Private DUbic As AdoSQL
    Private DSaldosInvPT As AdoSQL
    Private DOPs As AdoSQL
    Private DProdEquiv As AdoSQL
    Private DCortes As AdoSQL
    Private DEmpRec As AdoSQL
    Private Tipo As String = ""
    Private ContCB As Int32 = 0
    Private DOrdDespDet As AdoSQL
    Private ImpresoraDesp As String = ""



    Private Sub FacturasUNO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DMovInv = New AdoSQL("InvIni")

            DDetalle = New AdoSQL("CONSULTA_CB", RutaDB_ControlBascula)
            DVarios = New AdoSQL("VARIOS")
            DFacturas = New AdoSQL("FACTURAS")
            DUbic = New AdoSQL("UBICACIONES")
            DSaldosInvPT = New AdoSQL("DSaldosInvPT")
            DOPs = New AdoSQL("OPS")
            DProdEquiv = New AdoSQL("ProductosEquiv")
            DCortes = New AdoSQL("CORTESLOTE")
            DEmpRec = New AdoSQL("Empaque")
            DOrdDespDet = New AdoSQL("ORDENDESPDET")

            ImpresoraDesp = ConfigParametros("NOMIMPTIRILLACARGUEPT")

            RBPlaca_Click(Nothing, Nothing)

            DFacturas.Open("Delete from facturas where FECHA<'" + DateAdd(DateInterval.Year, -1, Now).ToString("yyyy/MM/dd") + "'")



        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub BBuscarFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscarFact.Click
        Try

            'Buscamos la factura en la base de datos de ControlBáscula

            If RBFactura.Checked Then
                If Eval(TFiltro.Text) = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " factura"), vbCritical)
                    Return
                End If
            Else

                If TFiltro.Text = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " placa"), vbCritical)
                    Return
                End If
            End If

            Limpiar_Habilitar_TextBox(Me.GBPropiedades1.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Me.GBPropiedades2.Controls, AccionTextBox.Limpiar)
            ''Limpiar_Habilitar_TextBox(Me.GBPropiedades3.Controls, AccionTextBox.Limpiar)

            TSaldoUbi.Text = ""
            TSaldoPlanta.Text = ""
            TSacosComp.Text = ""
            TCantDesp.Text = ""
            TSaldoLote.Text = ""
            TSacNoDesp.Text = ""


            LDetalle.Text = "Detalle " + LPlacaFact.Text
            LEstadoCon.Text = ""
            LEstadoCon.Visible = True
            LEstadoCon.Text = "Buscando Documento..."
            LEstadoCon.ForeColor = Color.Magenta
            Application.DoEvents()
            Sleep(100)

            TSumSacosPlaca.Text = ""
            'Buscamos la factura en la tabla mediante consulta realizada a la BD de controlbascula
            BBuscaDetFact_Click(Nothing, Nothing)
            TSumSacosProd.Text = 0

            If DDetalle.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE), vbInformation)
                LEstadoCon.Text = ""
                LEstadoCon.Text = "Fallo Búsqueda..."
                LEstadoCon.Visible = True
                LEstadoCon.ForeColor = Color.Red
                Return
            End If

            LEstadoCon.Text = ""
            LEstadoCon.Text = "Conexión establecida OK"
            LEstadoCon.Visible = True
            LEstadoCon.ForeColor = Color.Green

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGDetFact_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetFact.CellClick
        Try
            If DGDetFact.RowCount = 0 Then Return

            Dim CodProdFinal As String = ""

            TCodProd.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("CODPROD").Value.ToString

            'Se busca si los códigos corresponden a productos de maquila para cambiar al Cod.Int ChronoSoft
            If InStr(TCodProd.Text, "MQ") Or InStr(TCodProd.Text, "MK") Then
                DVarios.Open("Select CODINT,PRESKG from ARTICULOS where CODMAQ='" + TCodProd.Text + "'")
                If DVarios.Count > 0 Then
                    TMaquila.Text = "S"
                    'Cuando el código es MK es un granel, entonces se divide sobre el PRESKG para recuperar el numero de sacos
                    'If Not IsDBNull(DVarios.RecordSet("PRESKG") And DVarios.RecordSet("PRESKG") <> 0 And InStr(DG.Cells("CODPROD").Value.ToString, "MK")) Then
                    '    DG.Cells("SACOS").Value = DG.Cells("PESO").Value / DVarios.RecordSet("PRESKG")
                    'End If
                    TCodProd.Text = DVarios.RecordSet("CODINT")
                End If
            End If

            CodProdFinal = CLeft(TCodProd.Text, 4)


            TSacos.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("SACOS").Value
            TPeso.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("PESO").Value
            TNomProd.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("NOMPROD").Value
            TPlaca.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("PLACA").Value
            TNit.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("NIT").Value
            TTercero.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("TERCERO").Value
            TFecha.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("FECHA").Value
            TConductor.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("CONDUCTOR").Value
            TFactura.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("NUMFRA").Value
            TIdRow.Text = DGDetFact.Rows(DGDetFact.CurrentRow.Index).Cells("IDROW").Value



            DVarios.Open("Select PRESKG,TIPO from ARTICULOS where CODINT='" + CodProdFinal + "'")
            If DVarios.Count > 0 Then
                TPesoSaco.Text = DVarios.RecordSet("PRESKG")
                Tipo = DVarios.RecordSet("TIPO")
            End If


            BSaldosPT_Click(Nothing, Nothing)

            EntregaLotesDisp(CodProdFinal)

            DGParcial.Rows.Clear()


            If Tipo = "PT" Then
                BParcial.Enabled = True
                BAceptar.Enabled = False
            Else
                BParcial.Enabled = False
                BAceptar.Enabled = True
            End If
            DUbic.Open("Select * from UBICACIONES where TIPO='" + Tipo + "' and VerEnModDesp=1 order by CODUBI")
            LLenaComboBox(CUbi, DUbic.DataTable, "CODUBI")

            TSumSacosProd.Text = 0

            For Each Fila As DataGridViewRow In DGDetFact.Rows
                If Fila.Cells("CODPROD").Value <> TCodProd.Text Then Continue For
                TSumSacosProd.Text = Val(TSumSacosProd.Text) + Fila.Cells("SACOS").Value
            Next


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim Unidades As Double

            If Tipo = "PT" Then
                If DGParcial.RowCount = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " con lotes disponibles para despacho"), MsgBoxStyle.Information)
                    GoTo Salir
                End If
            End If


            BAceptar.Enabled = False

            If TCodProd.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " producto"), MsgBoxStyle.Information)
                GoTo Salir
            End If

            'If Eval(TSacos.Text) = 0 Then
            '    MsgBox("Número de sacos no válido para descuento de inventarios", MsgBoxStyle.Information)
            '    GoTo Salir
            'End If

            If Tipo = "MP" Then
                If Eval(TPeso.Text) = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " peso"), MsgBoxStyle.Information)
                    GoTo Salir
                End If
            End If


            If CUbi.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " ubicación"), MsgBoxStyle.Information)
                GoTo Salir
            End If

            If Eval(TSacNoDesp.Text) > Eval(TSacos.Text) Then
                MsgBox("El número de Despacho no puede superar los sacos del detalle de la factura", MsgBoxStyle.Information)
                GoTo Salir
            End If

            'DVarios.Open("Select * from OPS where OP='" + TOPs.Text + "'")



            DVarios.Open("Select * from ARTICULOS where CODINT='" + CLeft(TCodProd.Text, 4) + "'")

            If DVarios.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " código de articulo"), vbInformation)
                GoTo Salir
            End If


            Dim Tip As Int32 = 0
            If DVarios.RecordSet("TIPO") = "PT" Then
                Tip = DetOperacion.SLPT
            ElseIf DVarios.RecordSet("TIPO") = "MP" Then
                Tip = DetOperacion.SLMP

                'Verificamos si existe el lote en un corte de MP

                DCortes.Open("Select * from CORTESLOTE where LOTE='" + TLoteOP.Text + "' and CODMAT='" + TCodProd.Text + "'")

                If DCortes.Count = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " lote de materia prima"), vbInformation)
                    GoTo Salir
                End If
                Unidades = Eval(TPeso.Text) - Eval(TSacNoDesp.Text) * -1
                AjusteCorte(TLoteOP.Text, TCodProd.Text, Unidades, "Factura No " + TFactura.Text + " Placa " + TPlaca.Text + " Usuario " + UsuarioPrincipal)
            End If

            'Objeto usado para realizar el descuento del inventario
            Dim Invent As New DescInvent


            If Tipo = "MP" Then
                With Invent
                    .CodInt = CLeft(TCodProd.Text, 4)
                    .Cantidad = Unidades
                    .TipoInv = DescInvent.TipoInvent.CHRONOS
                    .Lote = TLoteOP.Text
                    .Detalle = Tip
                    .Ubicacion = CUbi.Text
                    .Unds = Unidades
                    .PromSac = Eval(TPesoSaco.Text)
                    .FacturaNro = TFactura.Text
                    .Observaciones = TObservaciones.Text
                    .Usuario = UsuarioPrincipal
                    .ContadorCB = ContCB
                    .IDRowCB = TIdRow.Text
                    .PlacaCB = TPlaca.Text
                    If TMaquila.Text = "S" Then .Maquila = DVarios.RecordSet("CODMAQ")
                    'Si la función no pudo crear el registro de inventario no genera el despacho de la factura
                    If .Inventario() = False Then GoTo Salir
                End With

            Else
                For Each Fila As DataGridViewRow In DGParcial.Rows

                    Dim Sacos As Int16 = Fila.Cells("SACDESP").Value
                    Dim SacosNoDesp As Int16 = Fila.Cells("SACNODESP").Value
                    Dim Lote As String = Fila.Cells("LOTE").Value

                    Unidades = Math.Abs(Sacos - SacosNoDesp) * -1

                    With Invent
                        .CodInt = CLeft(TCodProd.Text, 4)
                        .Cantidad = Unidades
                        .TipoInv = DescInvent.TipoInvent.CHRONOS
                        .Lote = Lote
                        .Detalle = Tip
                        .Ubicacion = CUbi.Text
                        .Unds = Unidades
                        .PromSac = Eval(TPesoSaco.Text)
                        .FacturaNro = TFactura.Text
                        .Observaciones = TObservaciones.Text
                        .Usuario = UsuarioPrincipal
                        .ContadorCB = ContCB
                        .IDRowCB = TIdRow.Text
                        .PlacaCB = TPlaca.Text
                        If TMaquila.Text = "S" Then .Maquila = DVarios.RecordSet("CODMAQ")
                        'Si la función no pudo crear el registro de inventario no genera el despacho de la factura
                        If .Inventario() = False Then GoTo Salir
                    End With

                Next

            End If



            'If TMaquila.Text = "S" Then
            '    'Si la función no pudo crear el registro de inventario no genera el despacho de la factura
            '    If Inventario(TCodProd.Text, Unidades, TipoInv.CHRONOS, TOPs.Text, Tip, CUbicacion.Text, "-", Unidades, + _
            '           Eval(TPesoSaco.Text), TNumFactura.Text, TObservaciones.Text, DVarios.RecordSet("CODMAQ"), Usuario) = False Then
            '        GoTo Salir
            '    End If

            'Else
            '    'Si la función no pudo crear el registro de inventario no genera el despacho de la factura
            '    If Inventario(TCodProd.Text, Unidades, TipoInv.CHRONOS, TOPs.Text, Tip, CUbicacion.Text, "-", Unidades, + _
            '           Eval(TPesoSaco.Text), TNumFactura.Text, TObservaciones.Text, "-", Usuario) = False Then
            '        GoTo salir
            '    End If

            'End If


            'Se guarda registro en la tabla FACTURAS 

            DFacturas.Open("Select * from FACTURAS where CODPROD='" + TCodProd.Text + "' and FACTURANRO='" + TFiltro.Text + "'")

            If DFacturas.Count > 0 Then
                DFacturas.RecordSet("NIT") = CLeft(TNit.Text, 15)
                DFacturas.RecordSet("FECHA") = TFecha.Text + " 00:00"
                DFacturas.RecordSet("TERCERO") = CLeft(TTercero.Text, 80)
                DFacturas.RecordSet("CODUBI") = CUbi.Text
                DFacturas.RecordSet("SACOS") = Eval(TSacos.Text)
                DFacturas.RecordSet("PESO") = Eval(TPeso.Text)
                DFacturas.RecordSet("PRESKG") = Eval(TPesoSaco.Text)
                DFacturas.RecordSet("DESPACHADA") = 10    'Numero que indica que ya se despachó el producto
                DFacturas.RecordSet("FECHADESP") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                DFacturas.RecordSet("SACNODESP") = Eval(TSacNoDesp.Text)    'Ingresa los sacos que no han sido despachados
                DFacturas.RecordSet("USUARIODESP") = UsuarioPrincipal
                'DFacturas.RecordSet("CODEMP") = CodEmp
                'DFacturas.RecordSet("CODETIQ") = CodEtiq
                DFacturas.Update()

            End If

            BLimpiaDet_Click(Nothing, Nothing)

            DGDetFact.Rows.RemoveAt(DGDetFact.CurrentRow.Index)

            BBuscarFact_Click(Nothing, Nothing)

Salir:
            BAceptar.Enabled = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)

            AsignaDataGrid(DGDetFact, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TSacos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            TPeso.Text = Eval(TSacos.Text) * Eval(TPesoSaco.Text)
            TPeso.Text = Format(TPeso.Text, "0.00")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BIngFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            'Ingresa todo el detalle de la factura a la tabla facturas para saber cuales estan pendientes por despachar

            If TFiltro.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " factura o placa"), vbInformation)
                Return
            End If

            If TNit.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " nit"), vbInformation)
                Return
            End If

            If TTercero.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " tercero"), vbInformation)
                Return
            End If

            For Each DG As DataGridViewRow In DGDetFact.Rows

                DFacturas.Open("Select * from FACTURAS where CODPROD='" + DG.Cells("CODPROD").Value.ToString + "' and FACTURANRO='" + TFiltro.Text + "'")

                If DFacturas.Count = 0 Then

                    DFacturas.AddNew()

                    DFacturas.RecordSet("FACTURANRO") = TFiltro.Text
                    DFacturas.RecordSet("NIT") = TNit.Text
                    DFacturas.RecordSet("FECHA") = TFecha.Text
                    DFacturas.RecordSet("CODPROD") = DG.Cells("CODPROD").Value.ToString
                    'DFacturas.RecordSet("UBICACION") = CUbicacion.Text
                    DFacturas.RecordSet("DESPACHARA") = TTercero.Text

                    DVarios.Open("Select * from ARTICULOS where CODINT='" + DG.Cells("CODPROD").Value.ToString + "'")

                    If DVarios.Count = 0 Then
                        DFacturas.RecordSet("NOMPROD") = DG.Cells("NOMPROD").Value.ToString
                    Else
                        DFacturas.RecordSet("NOMPROD") = DVarios.RecordSet("NOMBRE")
                    End If

                    DFacturas.RecordSet("SACOS") = DG.Cells("SACOS").Value.ToString
                    DFacturas.RecordSet("PESO") = DG.Cells("PESO").Value.ToString
                    DFacturas.RecordSet("PRESKG") = DG.Cells("PRESKG").Value.ToString

                    DFacturas.Update()

                End If

            Next

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGDetFact_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGDetFact.CellFormatting
        Try
            If DGDetFact.Columns(e.ColumnIndex).Name.ToUpper = "SACOS" Then
                DGDetFact.Rows(e.RowIndex).Cells("SACOS").Value = Format(Math.Round(Eval(DGDetFact.Rows(e.RowIndex).Cells("SACOS").Value), 1), "0")
            End If

            If DGDetFact.Columns(e.ColumnIndex).Name.ToUpper = "PESO" Then
                DGDetFact.Rows(e.RowIndex).Cells("PESO").Value = Format(Math.Round(Eval(DGDetFact.Rows(e.RowIndex).Cells("PESO").Value), 1), "0.00")
            End If

            If DGDetFact.Columns(e.ColumnIndex).Name.ToUpper = "PRESKG" Then
                DGDetFact.Rows(e.RowIndex).Cells("PRESKG").Value = Format(Math.Round(Eval(DGDetFact.Rows(e.RowIndex).Cells("PRESKG").Value), 1), "0.00")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBuscaDetFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBuscaDetFact.Click
        Try

            Dim CodProdExc As String
            Dim IDRowExc As String = ""
            Dim Factura As String = ""



            If RBPlaca.Checked Then
                'Recuperamos el consecutivo de controlbascula para filtrar los productos
                DDetalle.Open("Select dbo.trnsto_dtlle.cnsctvo,dbo.trnsto_dtlle.IdRow,dbo.trnsto_dtlle.dcmnto AS NumFra, dbo.trnsto_dtlle.plca AS Placa, dbo.trnsto_dtlle.artclo AS CodProd, dbo.trnsto_dtlle.cntdad AS Sacos, dbo.trnsto_dtlle.klos AS Peso, " +
                                  "dbo.trcro.nmbre AS Tercero, dbo.trcro.nit, dbo.artclo.nmbre AS NomProd, dbo.artclo.pso AS PresKg, SUBSTRING(CONVERT(nvarchar(24), dbo.trnsto_dtlle.fcha_lte,111), 1, 10) AS Fecha, " +
                                  "dbo.trnsto_dtlle.cnsctvo as ContadorCB, dbo.trnsto.cndctor AS Conductor FROM         dbo.trnsto_dtlle INNER JOIN dbo.artclo ON dbo.trnsto_dtlle.artclo = dbo.artclo.cdgo LEFT OUTER JOIN dbo.trnsto ON dbo.trnsto_dtlle.plca = dbo.trnsto.plca LEFT OUTER JOIN " +
                                  "dbo.trcro ON dbo.trnsto_dtlle.trcro = dbo.trcro.cdgo WHERE dbo.trnsto_dtlle.plca ='" + TFiltro.Text + "' and dbo.trnsto_dtlle.cntdad>0")

                If DDetalle.Count Then ContCB = DDetalle.RecordSet("cnsctvo")

                If ContCB > 0 Then
                    DMovInv.Open("Select * from MOVINV where ContadorCB=" + ContCB.ToString)
                End If
            Else
                DMovInv.Open("Select * from MOVINV where FACTURANRO='" + Eval(TFiltro.Text).ToString + "'")
            End If

            CodProdExc = ""
            IDRowExc = ""


            'Se busca en el movimiento de inventario si el registro quedó guardado con maquila

            For Each Recordset As DataRow In DMovInv.DataTable.Rows

                If Recordset("CODMAQ").ToString.Contains("M") AndAlso Recordset("CODMAQ").ToString.Trim.Length > 3 Then
                    DVarios.Open("select * from ARTICULOS where CODMAQ='" + Recordset("CODMAQ").ToString + "'")
                    If DVarios.Count = 0 Then
                        MsgBox("El código de máquila no se encuentra registrado en ChronoSoft", MsgBoxStyle.Information)
                        Return
                    Else
                        CodProdExc += " dbo.Trnsto_dtlle.artclo NOT LIKE '%" + DVarios.RecordSet("CODMAQ") + "%' and"
                        IDRowExc += " dbo.Trnsto_dtlle.IDRow <>" + Recordset("IDRowCB").ToString + " and"
                    End If

                Else
                    CodProdExc += " dbo.Trnsto_dtlle.artclo NOT LIKE '%" + Recordset("CODINT") + "%' and"
                    IDRowExc += " dbo.Trnsto_dtlle.IDRow <>" + Recordset("IDRowCB").ToString + " and"
                End If

            Next


            'Se busca el detalle de la factura
            If RBFactura.Checked Then
                If CodProdExc <> "" Then
                    CodProdExc = CLeft(CodProdExc, InStrRev(CodProdExc, "and") - 1)

                    DDetalle.Open("Select dbo.trnsto_dtlle.cnsctvo,dbo.trnsto_dtlle.IdRow,dbo.trnsto_dtlle.dcmnto AS NumFra, dbo.trnsto_dtlle.plca AS Placa, dbo.trnsto_dtlle.artclo AS CodProd, dbo.trnsto_dtlle.cntdad AS Sacos, dbo.trnsto_dtlle.klos AS Peso, " +
                                    "dbo.trcro.nmbre AS Tercero, dbo.trcro.nit, dbo.artclo.nmbre AS NomProd, dbo.artclo.pso AS PresKg, SUBSTRING(CONVERT(nvarchar(24), dbo.trnsto_dtlle.fcha_lte,111), 1, 10) AS Fecha, " +
                                    "dbo.trnsto_dtlle.cnsctvo as ContadorCB, dbo.trnsto.cndctor AS Conductor FROM dbo.trnsto_dtlle INNER JOIN dbo.artclo ON dbo.trnsto_dtlle.artclo = dbo.artclo.cdgo LEFT OUTER JOIN dbo.trnsto ON dbo.trnsto_dtlle.plca = dbo.trnsto.plca LEFT OUTER JOIN " +
                                    "dbo.trcro ON dbo.trnsto_dtlle.trcro = dbo.trcro.cdgo WHERE (dbo.trnsto_dtlle.cntdad>0 and dbo.trnsto_dtlle.dcmnto ='" + TFiltro.Text + "' and " + CodProdExc + ")")
                Else

                    DDetalle.Open("Select dbo.trnsto_dtlle.cnsctvo,dbo.trnsto_dtlle.IdRow,dbo.trnsto_dtlle.dcmnto AS NumFra, dbo.trnsto_dtlle.plca AS Placa, dbo.trnsto_dtlle.artclo AS CodProd, dbo.trnsto_dtlle.cntdad AS Sacos, dbo.trnsto_dtlle.klos AS Peso, " +
                                   "dbo.trcro.nmbre AS Tercero, dbo.trcro.nit, dbo.artclo.nmbre AS NomProd, dbo.artclo.pso AS PresKg, SUBSTRING(CONVERT(nvarchar(24), dbo.trnsto_dtlle.fcha_lte,111), 1, 10) AS Fecha, " +
                                   "dbo.trnsto_dtlle.cnsctvo as ContadorCB, dbo.trnsto.cndctor AS Conductor FROM         dbo.trnsto_dtlle INNER JOIN dbo.artclo ON dbo.trnsto_dtlle.artclo = dbo.artclo.cdgo LEFT OUTER JOIN dbo.trnsto ON dbo.trnsto_dtlle.plca = dbo.trnsto.plca LEFT OUTER JOIN " +
                                   "dbo.trcro ON dbo.trnsto_dtlle.trcro = dbo.trcro.cdgo WHERE (dbo.trnsto_dtlle.cntdad>0 and dbo.trnsto_dtlle.dcmnto ='" + TFiltro.Text + "')")
                End If

            Else

                'Se busca por placa

                If CodProdExc <> "" Then
                    CodProdExc = CLeft(CodProdExc, InStrRev(CodProdExc, "and") - 1)
                    IDRowExc = CLeft(IDRowExc, InStrRev(IDRowExc, "and") - 1)

                    DDetalle.Open("Select dbo.trnsto_dtlle.cnsctvo,dbo.trnsto_dtlle.IdRow,dbo.trnsto_dtlle.dcmnto AS NumFra, dbo.trnsto_dtlle.plca AS Placa, dbo.trnsto_dtlle.artclo AS CodProd, dbo.trnsto_dtlle.cntdad AS Sacos, dbo.trnsto_dtlle.klos AS Peso, " +
                                    "dbo.trcro.nmbre AS Tercero, dbo.trcro.nit, dbo.artclo.nmbre AS NomProd, dbo.artclo.pso AS PresKg, SUBSTRING(CONVERT(nvarchar(24), dbo.trnsto_dtlle.fcha_lte,111), 1, 10) AS Fecha, " +
                                    "dbo.trnsto_dtlle.cnsctvo as ContadorCB, dbo.trnsto.cndctor AS Conductor FROM dbo.trnsto_dtlle INNER JOIN dbo.artclo ON dbo.trnsto_dtlle.artclo = dbo.artclo.cdgo LEFT OUTER JOIN dbo.trnsto ON dbo.trnsto_dtlle.plca = dbo.trnsto.plca LEFT OUTER JOIN " +
                                    "dbo.trcro ON dbo.trnsto_dtlle.trcro = dbo.trcro.cdgo WHERE (dbo.trnsto_dtlle.cntdad>0 and dbo.trnsto_dtlle.plca ='" + TFiltro.Text + "' and " + IDRowExc + " )")
                Else

                    DDetalle.Open("Select dbo.trnsto_dtlle.cnsctvo,dbo.trnsto_dtlle.IdRow,dbo.trnsto_dtlle.dcmnto AS NumFra, dbo.trnsto_dtlle.plca AS Placa, dbo.trnsto_dtlle.artclo AS CodProd, dbo.trnsto_dtlle.cntdad AS Sacos, dbo.trnsto_dtlle.klos AS Peso, " +
                                   "dbo.trcro.nmbre AS Tercero, dbo.trcro.nit, dbo.artclo.nmbre AS NomProd, dbo.artclo.pso AS PresKg, SUBSTRING(CONVERT(nvarchar(24), dbo.trnsto_dtlle.fcha_lte,111), 1, 10) AS Fecha, " +
                                   "dbo.trnsto_dtlle.cnsctvo as ContadorCB, dbo.trnsto.cndctor AS Conductor FROM         dbo.trnsto_dtlle INNER JOIN dbo.artclo ON dbo.trnsto_dtlle.artclo = dbo.artclo.cdgo LEFT OUTER JOIN dbo.trnsto ON dbo.trnsto_dtlle.plca = dbo.trnsto.plca LEFT OUTER JOIN " +
                                   "dbo.trcro ON dbo.trnsto_dtlle.trcro = dbo.trcro.cdgo WHERE (dbo.trnsto_dtlle.cntdad>0 and dbo.trnsto_dtlle.plca ='" + TFiltro.Text + "')")
                End If
            End If


            'If DDetalle.Count > 0 Then
            '    'Asignamos la fecha primero para guardarla en la tabla facturas
            '    TFecha.Text = DDetalle.RecordSet("FECHA")
            '    TNit.Text = DDetalle.RecordSet("NIT")
            '    TTercero.Text = DDetalle.RecordSet("TERCERO")

            'End If
            AsignaDataGrid(DGDetFact, DDetalle.DataTable)



            For Each DG As DataGridViewRow In DGDetFact.Rows


                Factura = DG.Cells("NumFra").Value

                'Se guarda registro en la tabla FACTURAS 

                'If Eval(DG.Cells("CODPROD").Value.ToString) = 0 Then Continue For

                Dim CodProd As String
                CodProd = DG.Cells("CODPROD").Value.ToString

                If InStr(CodProd, "MQ") Or InStr(CodProd, "MK") Then
                    DVarios.Open("Select CODINT from ARTICULOS where TIPO='PT' and CODMAQ='" + CodProd + "'")
                    If DVarios.Count > 0 Then
                        CodProd = DVarios.RecordSet("CODINT")
                    End If
                End If

                DFacturas.Open("Select * from FACTURAS where CODPROD='" + CodProd + "' and FACTURANRO='" + Factura + "' and SACOS=" + Math.Round(Eval(DG.Cells("SACOS").Value), 1).ToString)

                If DFacturas.Count = 0 Then

                    DFacturas.AddNew()

                    DFacturas.RecordSet("FACTURANRO") = Factura
                    DFacturas.RecordSet("CODPROD") = CodProd

                    DVarios.Open("Select * from ARTICULOS where CODINT='" + CodProd + "'")

                    If DVarios.Count = 0 Then
                        DFacturas.RecordSet("NOMPROD") = CLeft(DG.Cells("NOMPROD").Value.ToString, 50)

                    Else
                        DFacturas.RecordSet("NOMPROD") = DVarios.RecordSet("NOMBRE")
                        DFacturas.RecordSet("PRESKG") = DVarios.RecordSet("PRESKg")
                    End If

                    DFacturas.RecordSet("SACOS") = Math.Round(Eval(DG.Cells("SACOS").Value), 1)
                    DFacturas.RecordSet("PESO") = Math.Round(Eval(DG.Cells("PESO").Value), 2)
                    DFacturas.RecordSet("FECHA") = DG.Cells("FECHA").Value
                    DFacturas.RecordSet("NIT") = DG.Cells("NIT").Value
                    DFacturas.RecordSet("TERCERO") = DG.Cells("TERCERO").Value
                    DFacturas.RecordSet("PLACA") = DG.Cells("PLACA").Value
                    DFacturas.Update(Me)

                    Evento("Ingresa Fra: " + Factura + " en espera de despacho")



                End If

            Next

            TSumSacosPlaca.Text = SumColumn(DGDetFact, "SACOS")



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BLimpiaDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLimpiaDet.Click
        Try
            TCodProd.Text = ""
            TNomProd.Text = ""
            TLoteOP.Text = ""
            TSacos.Text = ""
            TPesoSaco.Text = ""
            TPeso.Text = ""
            GBPropiedades3.Text = ""
            TSacNoDesp.Text = ""
            TMaquila.Text = ""
            TCantDesp.Text = ""
            TLoteOP.Text = ""
            TLoteOP.Items.Clear()
            TSacosComp.Text = ""

            DGParcial.Rows.Clear()
            CUbi.Text = ""

            'Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            TFiltro.Text = Eval(TFiltro.Text) + 1
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            TFiltro.Text = Eval(TFiltro.Text) - 1
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub AjusteCorte(ByVal Lote As String, ByVal CodMat As String, ByVal Cantidad As String, ByVal Observacion As String)
        Try
            Dim DOBsCortes As New AdoSQL("OBSCORTES")
            Dim DCortes As New AdoSQL("CORTESMP")

            DCortes.Open("select * from CORTESLOTE where LOTE='" + Lote + "' and CODMAT='" + CodMat + "'")

            If DCortes.Count = 0 Then
                DVarios.Open("select * from CORTESLOTE where CODMAT='" + CodMat + "' and ESTADO='A'")
                If DVarios.Count = 0 Then
                    Evento("No se encuentra Corte para el Material " + CodMat)
                    Return
                End If
            End If

            Dim Cont As String = DCortes.RecordSet("CONT").ToString

            DOBsCortes.Open("select * from OBSCORTESMP where CONT=0")
            DOBsCortes.AddNew()
            DOBsCortes.RecordSet("CORTE") = Cont
            DOBsCortes.RecordSet("TIPO") = 4 'Salida Inv 
            DOBsCortes.RecordSet("Cantidad") = Eval(Cantidad)
            DOBsCortes.RecordSet("Observacion") = CLeft(Observacion, 100)
            DOBsCortes.RecordSet("Fecha") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DOBsCortes.Update()

            DOBsCortes.Open("select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + Cont + " and TIPO=4")

            If DCortes.Count > 0 AndAlso Not IsDBNull(DOBsCortes.RecordSet("Acum")) Then
                DCortes.RecordSet("AJUSTE4") = -DOBsCortes.RecordSet("Acum")
                DCortes.Update()
            End If
            Evento("Realiza Ajuste de Cortes de Lote por salida de Materia Prima Corte " + Cont)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSaldosPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaldosPT.Click
        Try
            TSaldoPlanta.Text = ""
            TSaldoUbi.Text = ""
            CUbi.Text = ""

            DSaldosInvPT.Open("Select * from MOVINV where TIPOMOV='CHRONOS' and CODINT='" + TCodProd.Text.Trim + "' order by ID desc")

            If DSaldosInvPT.Count = 0 Then Return

            TSaldoPlanta.Text = Format(DSaldosInvPT.RecordSet("SALDOFIN"), "#,###.00")

            DVarios.Open("select DISTINCT CODUBI from MOVINV where TIPOMOV='CHRONOS' and CODINT='" + TCodProd.Text.Trim + "'")

            LLenaComboBox(CUbi, DVarios.DataTable, "CODUBI")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CUbi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUbi.SelectedIndexChanged
        Try
            Dim SaldoUbi As Double = 0

            If TCodProd.Text = "" Then Return
            If DSaldosInvPT.Count = 0 Then Return

            TSaldoUbi.Text = 0

            DSaldosInvPT.Find("CODUBI='" + CUbi.Text + "'")
            If DSaldosInvPT.EOF Then Return

            For Each Saldo As DataRow In DSaldosInvPT.Rows

                If Saldo("CodUbi") = CUbi.Text Then
                    SaldoUbi += Saldo("ENTRA") + Saldo("SALE")
                End If

            Next

            TSaldoUbi.Text = Format(SaldoUbi, "#,###.00")


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub RBFactura_Click(sender As System.Object, e As System.EventArgs) Handles RBFactura.Click
        LPlacaFact.Text = "FACTURA"
    End Sub

    Private Sub RBPlaca_Click(sender As System.Object, e As System.EventArgs) Handles RBPlaca.Click
        LPlacaFact.Text = "PLACA"
    End Sub

    Private Function EntregaLotesDisp(ByVal CodProd As String)
        EntregaLotesDisp = Nothing
        If CodProd = "" Then
            Exit Function
        End If

        TLoteOP.Items.Clear()

        'Función encargada de revisar que lotes tienen disponibilidad y agregarlos al combobox TLoteOP


        If Tipo = "PT" Then
            'Primero se revisan las OPs recibidas en bodega
            DEmpRec.Open("SELECT OP,CODPROD,MIN(FechaIni) AS FECHAINI FROM EMPAQUE WHERE RECEMP=1 AND DESPACHADO<>'S' AND (CODPROD='" + CodProd + "' OR CODPROD2='" + CodProd + "') GROUP BY OP,CODPROD ORDER BY FECHAINI")

            If DEmpRec.Count > 0 Then
                For Each Fila As DataRow In DEmpRec.Rows
                    'Se revisa en la tabla movinv si hay disponibilidad de sacos para esa OP
                    DMovInv.Open("Select Sum(ENTRA)+SUM(SALE) as TOTAL from MOVINV where LOTE='" + Fila("OP") + "'")

                    If DMovInv.Count AndAlso Not IsDBNull(DMovInv.RecordSet("TOTAL")) Then
                        If DMovInv.RecordSet("TOTAL") > 0 Then
                            TLoteOP.Items.Add(Fila("OP"))
                        End If
                    End If
                Next
            Else
                'Si no encontró movimiento en la tabla de empaque, quiere decir que el producto viene de otra planta, por lo cual el ingreso se hace manual
                'directamente por ajustes de inventario, por lo cual se busca movimiento en la tabla movinv
                DMovInv.Open("Select Sum(ENTRA)+SUM(SALE) as TOTAL,LOTE from MOVINV where FECHA>'" + Format(DateAdd(DateInterval.Month, -2, Now), "yyyy/MM/dd") + "' and CODINT='" + CodProd + "' GROUP BY LOTE")

                For Each Fila As DataRow In DMovInv.Rows
                    If Fila("TOTAL") < 0 Then Continue For
                    TLoteOP.Items.Add(Fila("LOTE"))
                Next

            End If

        Else

            'Se busca en la tabla movinv el inventario fisico tomado despues de las 5 am

            DMovInv.Open("Select LOTE,CODINT from MOVINV where TIPOMOV='FISICO' and CODINT='" + CodProd + "' and FECHA>'" + Now.ToString("yyyy/MM/dd 05:00") + "' group by LOTE,CODINT")

            For Each Fila As DataRow In DMovInv.Rows
                TLoteOP.Items.Add(Fila("LOTE"))
            Next

        End If

    End Function

    Private Function EntregaSaldoLotePT(ByVal Lote As String) As Int16
        EntregaSaldoLotePT = 0

        If Lote = "" Then Exit Function

        DMovInv.Open("Select Sum(ENTRA)+SUM(SALE) as TOTAL from MOVINV where TIPOMOV='CHRONOS' and LOTE='" + Lote + "'")

        If DMovInv.Count AndAlso Not IsDBNull(DMovInv.RecordSet("TOTAL")) Then
            If DMovInv.RecordSet("TOTAL") > 0 Then
                EntregaSaldoLotePT = DMovInv.RecordSet("TOTAL")
            Else
                'Actualizamos los registros de la tabla de empaque poniendo que ya fueron despachados
                DVarios.Open("Update EMPAQUE set DESPACHADO='S' where OP='" + Lote + "'")

                Evento("Actualiza tabla empaque LOTE despachado OP: " + Lote)

            End If
        End If
    End Function

    Private Function EntregaSaldoLoteMP(ByVal Lote As String) As Double
        EntregaSaldoLoteMP = 0

        If Lote = "" Then Exit Function

        DMovInv.Open("Select Sum(ENTRA)+SUM(SALE) as TOTAL,MIN(CODUBI) as CODUBI from MOVINV where TIPOMOV='FISICO' and LOTE='" + Lote + "' and FECHA>'" + Now.ToString("yyyy/MM/dd 05:00") + "'")

        If DMovInv.Count AndAlso Not IsDBNull(DMovInv.RecordSet("TOTAL")) Then
            If DMovInv.RecordSet("TOTAL") > 0 Then
                EntregaSaldoLoteMP = DMovInv.RecordSet("TOTAL")
                CUbi.Text = DMovInv.RecordSet("CODUBI")
            End If
        End If

    End Function



    Private Sub TLoteOP_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TLoteOP.SelectedIndexChanged
        Try
            If TLoteOP.Text = "" Then Return

            Dim SacosADespReal As Int16 = 0

            TSacosComp.Text = SumColumn(DGParcial, "SACDESP")
            SacosADespReal = Val(TSacos.Text) - Val(TSacosComp.Text)

            If Tipo = "PT" Then
                TSaldoLote.Text = EntregaSaldoLotePT(TLoteOP.Text).ToString
                If SacosADespReal <= Val(TSaldoLote.Text) Then
                    TCantDesp.Text = SacosADespReal
                Else
                    TCantDesp.Text = TSaldoLote.Text
                End If
            Else
                TSaldoLote.Text = EntregaSaldoLoteMP(TLoteOP.Text).ToString
                TCantDesp.Text = TPeso.Text
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPs_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TLoteOP.KeyUp
        Try

            If e.KeyCode <> Keys.Enter Then Return

            'Se valida que el codigo del producto corresponda al que se desea despachar

            DVarios.Open("Select * from OPs where OP='" + TLoteOP.Text + "' AND CODPROD='" + CLeft(TCodProd.Text, 4) + "'")

            If DVarios.Count = 0 Then
                MsgBox("La OP seleccionada no corresponde al producto a despachar", vbCritical)
                TLoteOP.Text = ""
                Return
            End If

            TLoteOP_SelectedIndexChanged(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BParcial_Click(sender As System.Object, e As System.EventArgs) Handles BParcial.Click
        Try
            'Agrega al DGParcial el lote y la cantidad de los sacos a despachar

            Dim i As Int16 = DGParcial.RowCount

            DGParcial.Rows.Add()
            DGParcial.Rows(i).Cells("LOTE").Value = TLoteOP.Text
            DGParcial.Rows(i).Cells("SACDESP").Value = Val(TCantDesp.Text)
            DGParcial.Rows(i).Cells("SACNODESP").Value = Val(TSacNoDesp.Text)

            TCantDesp.Text = ""
            TSaldoLote.Text = ""

            TSacosComp.Text = SumColumn(DGParcial, "SACDESP")

            If Val(TSacosComp.Text) = Val(TSacos.Text) Then
                BParcial.Enabled = False
                BAceptar.Enabled = True
            End If

            TSacosComp.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGParcial_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGParcial.KeyUp
        Try
            If e.KeyCode <> Keys.Delete Then Return

            TSacosComp.Text = SumColumn(DGParcial, "SACDESP")
            BParcial.Enabled = True
            If Val(TSacosComp.Text) = Val(TSacos.Text) Then
                BParcial.Enabled = False
            End If

            TSacosComp.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BImprimir.Click
        Try
            Dim RepSap As CrystalRep
            Dim CodProd As String = ""
            Dim TotSacos As Int16 = 0

            'Se carga la tabla OrdenDespDet con los registros seleccionados

            DOrdDespDet.Open("Delete from ORDENDESPDET")

            DOrdDespDet.Open("Select * from ORDENDESPDET where ID=0")

            For Each Fila As DataGridViewRow In DGDetFact.Rows

                CodProd = CLeft(Fila.Cells("CODPROD").Value, 4)
                If Fila.Cells("Imprimir_NI_").Value = False Then Continue For


                DOrdDespDet.Open("Select * from ORDENDESPDET where CODPROD='" + CodProd + "'")

                '' If DOrdDespDet.Count = 0 Then
                DOrdDespDet.AddNew()
                '' End If

                DOrdDespDet.RecordSet("CODPROD") = CLeft(Fila.Cells("CODPROD").Value, 4)
                DOrdDespDet.RecordSet("NOMPROD") = CLeft(Fila.Cells("NOMPROD").Value, 40).Trim
                ''If IsDBNull(DOrdDespDet.RecordSet("SACOS")) Then
                DOrdDespDet.RecordSet("SACOS") = Fila.Cells("SACOS").Value
                'Else
                'DOrdDespDet.RecordSet("SACOS") = DOrdDespDet.RecordSet("SACOS") + Fila.Cells("SACOS").Value
                'End If

                TotSacos += Fila.Cells("SACOS").Value

                DOrdDespDet.Update()
            Next

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "PLACA='" + TFiltro.Text + "'"
                .Formulas(2) = "USUARIO='" + UsuarioPrincipal + "'"
                .Formulas(3) = "TOTSACOS='" + TotSacos.ToString + "'"
                '.Formulas(1) = "HORA='" + Format(Now, "HH:mm") + "'"
                .Destination = CrystalRep.Destinacion.crToPrinter
                ''.Destination = CrystalRep.Destinacion.crToWindows

                .ReportFileName = RutaRep + "rpOrdenDespacho.rpt"
                ''.PrintReport()

                '.SelectionFormula = "{Articulos.Tipo}='MP'"

            End With

            RepSap.PrintReport(ImpresoraDesp)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGDetFact_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetFact.CellContentClick
        Try

            If e Is Nothing Then Return

            If e.RowIndex < 0 Then Return

            If Convert.ToBoolean(DGDetFact.Rows(e.RowIndex).Cells("Imprimir_NI_").Value) Then
                DGDetFact.Rows(e.RowIndex).Cells("Imprimir_NI_").Value = False
            Else
                DGDetFact.Rows(e.RowIndex).Cells("Imprimir_NI_").Value = True
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSelTodos_Click(sender As System.Object, e As System.EventArgs) Handles BSelTodos.Click
        Try

            For Each Fila As DataGridViewRow In DGDetFact.Rows
                Fila.Cells("Imprimir_NI_").Value = True
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNoSelec_Click(sender As System.Object, e As System.EventArgs) Handles BNoSelec.Click
        Try

            For Each Fila As DataGridViewRow In DGDetFact.Rows
                Fila.Cells("Imprimir_NI_").Value = False
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

End Class