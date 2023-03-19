Option Explicit On

Imports System.Windows.Forms
Imports System.Threading
Imports System.Data
Imports System.IO
Imports System.Data.Common
Imports System.Threading.Thread
'Imports ChronoSoftNet


Public Class ODs1

    Private DODesp As AdoNet
    Private DODespDet As AdoNet
    Private DClientes As AdoNet
    Private DOPs As AdoNet
    Private DArt As AdoNet
    Private DVarios As AdoNet
    Private DVarios2 As AdoNet
    Private DConsultas As AdoNet
    Private DEmp As AdoNet
    Private DCortesL As AdoNet
    Private DGranjas As AdoNet
    Private DOrdDespTemp As AdoNet
    Private DConductores As AdoNet
    Private DVehiculos As AdoNet

    Private Fila As Integer
    Private Campos() As String
    Private Rep1 As CrystalRep

    Private DProd As AdoNet         'Por tener Chr en VB6

    Private LEnc As StreamReader
    Private Contenido As String
    Private RutaArchivo As String
    Private Posi As Int32
    Private Posi2 As Int32
    Private CodCliArch As String
    Private NomCliArch As String
    Private CodProdArch As String
    Private NomProdArch As String
    Private SacosMetaArch As String
    Private OdespArch As String
    Private OVentaArch As String
    Private Renglones() As String
    Private Renglon As String
    Private QuintArch As Single
    Private Nuevo As Boolean

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ODs1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DODesp = New AdoNet("ODs", CONNAnt, DbProvedorAnt)
            DODespDet = New AdoNet("ODsDet", CONNAnt, DbProvedorAnt)
            DOrdDespTemp = New AdoNet("ODsDet", CONNAnt, DbProvedorAnt)
            DClientes = New AdoNet("Clientes", CONN, DbProvedor)
            DOPs = New AdoNet("OPs", CONN, DbProvedor)
            DArt = New AdoNet("PRODUCTOS", CONN, DbProvedor)
            DVarios = New AdoNet("DVarios", CONNAnt, DbProvedorAnt)
            DVarios2 = New AdoNet("-", CONN, DbProvedor)
            DConsultas = New AdoNet("Consultas", CONN, DbProvedor)
            DProd = New AdoNet("-", CONN, DbProvedor)
            DEmp = New AdoNet("-", CONN, DbProvedor)
            DCortesL = New AdoNet("-", CONN, DbProvedor)
            DGranjas = New AdoNet("-", CONNAnt, DbProvedorAnt)
            DConductores = New AdoNet("-", CONNBasc, DbProvedorBasc)
            DVehiculos = New AdoNet("-", CONNBasc, DbProvedorBasc)

            'FrDatosOD.Enabled = False
            'GBTipDoc.Enabled = False
            OEmpaque.Enabled = False
            OGranel.Enabled = False

            TFechaVer.Value = Now

            DODesp.Open("Select * from ORDDESPACHO  where FINALIZADO<>'S' and FECHAPROG LIKE '" + Format(TFechaVer.Value, "yyyy/MM/dd").ToString + "%' order by ORDENDESP")
            DClientes.Open("Select * from CLIENTES order by NOMCLI")
            DConsultas.Open("Select * from CONSULTAS")

            AsignaDataGrid(DGOrdenDesp, DODesp.DataTable)
            'DGDespDet.Rows.Clear()

            If DODesp.RecordCount > 0 Then DGOrdenDesp_CellClick(Nothing, Nothing)

            ''llena los combos donde se va a seleccionar el producto para los detalles de la Orden de despacho

            Campos = {"ORDDESPACHO@Orden.Desp"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DODesp.DataTable)
            CBBuscar.Text = "Orden.Desp"

            'DOPs.Open("Select * from OPS order by OP desc")
            ' DProd.Open("Select * from Articulos where Tipo='PT'")
            DGranjas.Open("Select CodGranja, NomGranja as Nomgranja2 from GRANJAS order by NOMGRANJA")
            DODesp.Open("Select * from ORDDESPACHO  where FINALIZADO<>'S' and FECHAPROG LIKE '" + Format(TFechaVer.Value, "yyyy/MM/dd").ToString + "%' order by ORDENDESP")

            DOrdDespTemp.Open("Select * from ORDDESPACHOTEMP") 'where FINALIZADO = 'N' order by SDDOCO"

            If DODesp.RecordCount > 0 Then AsignaDataGrid(DGOrdenDesp, DODesp.DataTable, True)
            If DGranjas.RecordCount > 0 Then AsignaDataGrid(GridGranjas, DGranjas.DataTable, True)
            'If DOrdDespJDE.RecordCount > 0 Then Set GridST_JDE.DataSource = DOrdDespJDE

            Dim Fila As Integer
            Fila = 1
            'Do While Not DGranjas.EOF
            '        GridGranjas.TextMatrix(Fila, 0) = DGranjas!CodGranja
            '        GridGranjas.TextMatrix(Fila, 1) = DGranjas!NOMGranja
            '        Fila = Fila + 1
            '        DGranjas.MoveNext
            'Loop
            Nuevo = False

            If DODesp.RecordCount > 0 Then BTraeDatos_Click(Nothing, Nothing)

            TFechaDesp.Text = FechaC()

            DConductores.Open("Select CODCOND,NOMCOND from CONDUCTORES order by NOMCOND")

            If DConductores.RecordCount > 0 Then AsignaDataGrid(GridConductores, DConductores.DataTable, True)


            DVehiculos.Open("Select PLACA,TARAAPROX from VEHICULOS order by PLACA")

            If DVehiculos.RecordCount > 0 Then AsignaDataGrid(GridVehiculos, DVehiculos.DataTable, True)


        Catch ex As Exception
            MsgError(ex.ToString)

        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            If EditDatos = False Then
                MsgBox("Esta en una red de replicacion de datos por lo tanto no puede editar informacion, solo visualizarla.", MsgBoxStyle.Information)
                Return
            Else
                Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)
                TCodCond.Text = ""
                TNomCond.Text = ""
                TPlaca.Text = ""

                TOrdDesp.Text = "1"

                'Verifica que la Orden no exista y busca hasta encontrar una nueva.

                BCancelar_Click(Nothing, Nothing)
                BTraeOTransJDE.Visible = True
                Nuevo = True
                BNuevo.Enabled = False
                BModificar.Enabled = False

                If Permisos("Despachos Editar") = False Then
                    MsgBox("No tiene permiso para ejecutar la acción solicitada", vbInformation)
                    Exit Sub
                End If

                FramDatos.Enabled = True
                FrConductores.Enabled = True
                FrDatosOD.Enabled = True
                OEmpaque.Enabled = True
                OGranel.Enabled = True
                OGranel.Checked = False
                OEmpaque.Checked = False

                'TCodGranja = ""
                'TNomGranja = ""
                'TEdad = ""
                TFechaDesp.Text = FechaC()

                DODespDet.Open("Select * from ORDDESPDET where ORDENDESP=0")

                DVarios.Open("select Max(ORDENDESP) as ORDMAY from ORDDESPACHO")

                If Val(DVarios.RecordSet("ORDMAY")) = 0 Then
                    TOrdDesp.Text = 1
                Else
                    TOrdDesp.Text = DVarios.RecordSet("ORDMAY") + 1
                End If
                BTraeDatos_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub TFechaProg_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'If EditDatos = False Then
            '    MsgBox("Esta en una red de replicacion de datos por lo tanto no puede editar informacion, solo visualizarla.", MsgBoxStyle.Information)
            '    Return
            'Else
            '    Dim Fila As Integer = 1
            '    Dim PresKg As Int16 = 1 'Si es despacho a granel tiene valor 1, si es empaque en sacos tiene el valor del Preskg

            '    'If Val(TCantGranel.Text) > 0 Then
            '    '    If Val(TSacMeta.Text) > 0 Then
            '    '        MsgBox("No Puede soliciar al tiempo despacho a Granel y en Sacos", vbInformation)
            '    '        Return
            '    '    End If
            '    'End If

            '    If Eval(TCodCli.Text) = 0 Then
            '        MsgBox("Debe ingresar un valor válido para el código del cliente", MsgBoxStyle.Critical)
            '        Exit Sub
            '    End If
            '    If Eval(TPresKg.Text) = 0 Then
            '        MsgBox("Debe ingresar un valor válido para la Presentación en kg.", MsgBoxStyle.Critical)
            '        Exit Sub
            '    End If

            '    If TNomCli.Text = "" Then
            '        MsgBox("Debe ingresar un nombre válido para el cliente", MsgBoxStyle.Critical)
            '        Exit Sub
            '    End If

            '    If Val(TOrdDesp.Text) = 0 Then
            '        MsgBox("No hay una Orden de Despacho asociada", vbInformation)
            '        Return
            '    End If
            '    If TNomProd.Text = "" OrElse (Val(TCantGranel.Text) = 0 And Val(TSacMeta.Text) = 0) Then Return


            '    'If Eval(TDosificado.Text) >= 0 Then
            '    '    If Eval(TMetaDespKg.Text) + Eval(TCantGranel.Text) * PresKg > Eval(TDosificado.Text) Then
            '    '        Resp = MsgBox("La cantidad meta a despachar sobrepasa el valor dosificado para esta OP, ¿desea guardar los datos de la orden de despacho?", vbCritical + vbYesNo)
            '    '        If Resp = vbNo Then
            '    '            TCantGranel.Text = ""
            '    '            Return
            '    '        End If
            '    '    End If
            '    'End If

            '    'If Eval(TCantGranel.Text) * PresKg > Eval(TDisponibleKg.Text) Then
            '    '    'Resp = MsgBox("La cantidad de sacos a despachar sobrepasa el valor disponible para esta OP, ¿desea guardar los datos de la orden de despacho?", vbCritical + vbYesNo)
            '    '    MsgBox("La cantidad de sacos a despachar sobrepasa el valor disponible para esta OP, no se realizará la operación solicitada", vbCritical)
            '    '    'If Resp = vbNo Then
            '    '    '    TSacos.Text = ""
            '    '    '    Return
            '    '    'End If
            '    '    Return
            '    'End If



            '    DODespDet.AddNew()
            '    DODespDet.RecordSet("ORDENDESP") = TOrdDesp.Text

            '    DODespDet.RecordSet("CODPROD") = Mid(TCodProd.Text, 1, 15)
            '    DODespDet.RecordSet("NOMPROD") = Mid(TNomProd.Text, 1, 30)
            '    DODespDet.RecordSet("CODCLI") = Mid(TCodCli.Text, 1, 15)
            '    DODespDet.RecordSet("NOMCLI") = Mid(TNomCli.Text, 1, 30)
            '    DODespDet.RecordSet("OVENTA") = Mid(TOVenta.Text, 1, 15)
            '    DODespDet.RecordSet("LOTEPROD") = "."
            '    DODespDet.RecordSet("PESOMETA") = Format(Val(TSacMeta.Text) * Eval(TPresKg.Text), "0.00")
            '    'If Val(TSacMeta.Text) > 0 Then
            '    DODespDet.RecordSet("SACOSMETA") = Val(TSacMeta.Text)
            '    'End If
            '    DODespDet.Update()

            '    DVarios2.Open("select * from ORDENDESP where ORDENDESP='" + TOrdDesp.Text + "'")
            '    If DVarios2.RecordCount = 0 Then
            '        MsgBox("La Orden de Despacho no ha sido creada aún", vbInformation)
            '        Return
            '    End If

            '    DVarios.Open("Select SUM(PESOMETA) as PESOMETA, SUM(SACOSMETA) as SACOSMETA from ORDENDESPDET where ORDENDESP='" + TOrdDesp.Text + "'")
            '    If Not IsDBNull(DVarios.RecordSet("SACOSMETA")) Then
            '        DVarios2.RecordSet("SACOSMETA") = DVarios.RecordSet("SACOSMETA")
            '        DVarios2.RecordSet("PESOMETA") = DVarios.RecordSet("PESOMETA")
            '        DVarios2.Update()
            '    End If



            '    DODespDet.Open("select * from ORDENDESPDET where ORDENDESP='" + TOrdDesp.Text + "'")
            '    AsignaDataGrid(DGDespDet, DODespDet.DataTable, True)
            '    DODesp.Open("Select * from ORDENDESP where FINALIZADO<>'S' and FECHAPROG > '" + Format(TFechaVer.Value, "yyyy/MM/dd") + "%' order by ORDENDESP")
            '    AsignaDataGrid(DGOrdenDesp, DODesp.DataTable, True)


            '    TDisponibleKg.Text = ""
            '    TDisponibleSac.Text = ""
            '    TNomProd.Text = ""

            '    TCantGranel.Text = ""
            '    TSacMeta.Text = ""

            'End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BCancelarOPs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'If Val(TID.Text) = 0 Then Return
            'DVarios.Open("delete from ORDENDESPDET where ID=0" + TID.Text)

            'DVarios2.Open("select * from ORDENDESP where ORDENDESP='" + TOrdDesp.Text + "'")
            'If DVarios2.RecordCount = 0 Then
            '    Return
            'End If

            'DVarios.Open("Select SUM(PESOMETA) as PESOMETA, SUM(SACOSMETA) as SACOSMETA from ORDENDESPDET where ORDENDESP='" + TOrdDesp.Text + "'")
            'If Not IsDBNull(DVarios.RecordSet("SACOSMETA")) Then
            '    DVarios2.RecordSet("SACOSMETA") = DVarios.RecordSet("SACOSMETA")
            '    DVarios2.RecordSet("PESOMETA") = DVarios.RecordSet("PESOMETA")
            '    DVarios2.Update()
            'End If

            'AsignaDataGrid(DGDespDet, DODespDet.DataTable, True)
            'DODesp.Open("Select * from ORDENDESP where FINALIZADO<>'S' and FECHAPROG > '" + Format(TFechaVer.Value, "yyyy/MM/dd") + "%' order by ORDENDESP")
            'AsignaDataGrid(DGOrdenDesp, DODesp.DataTable, True)

            'TID.Text = ""

            'TCodProd.Text = ""
            'TNomProd.Text = ""
            'TCodCli.Text = ""
            'TNomCli.Text = ""
            'TSacMeta.Text = ""
            'TOVenta.Text = ""


        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If Permisos("Despachos Editar") = False Then
                MsgBox("No tiene permiso para ejecutar la acción solicitada", vbInformation)
                Exit Sub
            End If
            If EditDatos = False Then
                MsgBox("Esta en una red de replicacion de datos por lo tanto no puede editar informacion, solo visualizarla.", MsgBoxStyle.Information)
                Return
            Else
                Dim SumPesoMeta As Single

                If Val(TOrdDesp.Text) = 0 Then
                    MsgBox("Falta el código de la ORDEN DE DESPACHO", vbInformation)
                    Exit Sub
                End If

                If Trim(TCodGranja.Text) = "" Then
                    MsgBox("Falta el código de la Granja", vbInformation)
                    Exit Sub
                End If

                If TNomGranja.Text = "" Then
                    MsgBox("Falta el nombre de la Granja", vbInformation)
                    Exit Sub
                End If

                If Val(TEdad.Text) < 0 Then
                    MsgBox("Debe indicar una edad válida", vbInformation)
                    Exit Sub
                End If

                If OEmpaque.Checked = True Then

                    If Val(TManifiesto.Text) = 0 Then
                        MsgBox("Debe indicar un valor válido para el número de manifiesto", vbInformation)
                        Exit Sub
                    End If

                    If TCodCond.Text = "" Then
                        MsgBox("Falta el campo cédula del conductor", vbInformation)
                        Exit Sub
                    End If

                    If TNomCond.Text = "" Then
                        MsgBox("Falta el campo nombre del conductor", vbInformation)
                        Exit Sub
                    End If

                    If TPlaca.Text = "" Then
                        MsgBox("Falta el campo placa del vehículo", vbInformation)
                        Exit Sub
                    End If

                End If

                DVarios.Open("Select * from ORDDESPDET WHERE ORDENDESP=" + Trim(TOrdDesp.Text))

                If DVarios.RecordCount > 0 Then
                    For Each reg As DataRow In DVarios.Rows
                        SumPesoMeta = SumPesoMeta + reg("PESOMETA")
                    Next
                Else
                    MsgBox("Esta Orden de Despacho no tiene OPs grabadas, no se guardará ningún dato")
                    Exit Sub
                End If

                DODesp.Open("select * from ORDDESPACHO where ORDENDESP=" + Trim(TOrdDesp.Text))

                If DODesp.RecordCount = 0 Then
                Else
                    Resp = MsgBox("Esta Orden de Despacho ya existe, desea sobreescribirla con los datos nuevos?", vbYesNo + vbInformation)
                    If Resp = vbNo Then
                        BCancelar_Click(Nothing, Nothing)
                        Exit Sub
                    End If
                End If


                If DODesp.RecordCount = 0 Then DODesp.AddNew()

                DODesp.RecordSet("OrdenDesp") = TOrdDesp.Text
                DODesp.RecordSet("SDDOCO") = Val(TST_JDE.Text)
                DODesp.RecordSet("SDLNID") = Val(TLinea.Text)
                DODesp.RecordSet("Usuario2") = CLeft(Usuario, 15)
                'Se llenan los campos de la OP, codprod.... de la tabla ORDDESPACHO pues con esta tabla es la que trabaja GRANEL
                If DVarios.RecordCount = 1 Then
                    DODesp.RecordSet("OP") = DVarios.RecordSet("OP")
                    DODesp.RecordSet("CodProd") = DVarios.RecordSet("CodProd")
                    DODesp.RecordSet("NomProd") = DVarios.RecordSet("NomProd")
                    DODesp.RecordSet("CodForB") = DVarios.RecordSet("CodForB")
                    DODesp.RecordSet("NomForB") = DVarios.RecordSet("NomForB")
                End If

                DODesp.RecordSet("CodGranja") = (TCodGranja.Text)
                DODesp.RecordSet("NOMGranja") = CLeft(TNomGranja.Text, 30)
                DODesp.RecordSet("edad") = Val(TEdad.Text)
                DODesp.RecordSet("Placa") = CLeft(TPlaca.Text, 10)

                If OEmpaque.Checked = True Then
                    DODesp.RecordSet("Manifiesto") = Val(TManifiesto.Text)
                    DODesp.RecordSet("CodConductor") = CLeft(TCodCond.Text, 20)
                    DODesp.RecordSet("NOMCONDUCTOR") = CLeft(TNomCond.Text, 40)
                End If

                If OGranel.Checked = True Then DODesp.RecordSet("granel") = "S"

                DODesp.RecordSet("Fechaprog") = Format(TFechaDesp.Value, "yyyy/MM/dd").ToString()

                DODesp.RecordSet("PESOMETA") = SumPesoMeta
                DODesp.RecordSet("ObservModif") = CLeft(DODesp.RecordSet("ObservModif") + " " + TObserv.Text, 200)


                DODesp.Update()

                DODesp.Open("Select * from ORDDESPACHO  where FINALIZADO<>'S' and FECHAPROG LIKE '" + Format(TFechaVer.Value, "yyyy/MM/dd").ToString() + "%' order by ORDENDESP")

                AsignaDataGrid(DGOrdenDesp, DODesp.DataTable)

                Nuevo = False

                BCancelar_Click(Nothing, Nothing)
                BTraeDatos_Click(Nothing, Nothing)
                ODesp_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub DGOrdenDesp_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOrdenDesp.CellClick
        FODesp_Cell_Click(0, Nothing)
    End Sub

    Public Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        'ODesp_Load(Nothing, Nothing)
        Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)
        BModificar.Enabled = True
        BNuevo.Enabled = True
        FrDatosOD.Enabled = False
        FrConductores.Enabled = False
        GridODDet.Rows.Clear()

    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModificar.Click
        If EditDatos = False Then
            MsgBox("Esta en una red de replicacion de datos por lo tanto no puede editar informacion, solo visualizarla.", MsgBoxStyle.Information)
            Return
        Else
            If Permisos("Despachos Editar") = False Then
                MsgBox("No tiene permiso para ejecutar la acción solicitada", vbInformation)
                Exit Sub
            End If

            If Val(TOrdDesp.Text) = 0 Then Exit Sub
            If DODespDet.RecordCount = 0 Then
                MsgBox("No hay OPs asignadas a esta órden de despacho", vbCritical)
                BCancelar_Click(Nothing, Nothing)
                Exit Sub
            End If
            If DODespDet.RecordCount = 1 Then
                ObservOD.TOrdenDesp.Text = DODespDet.RecordSet("OrdenDesp")
                ObservOD.TOPs.Text = DODespDet.RecordSet("OP")
                ObservOD.TCodForB.Text = DODespDet.RecordSet("CodForB")
                ObservOD.TNomForB.Text = DODespDet.RecordSet("NomForB")

            Else
                ObservOD.TOrdenDesp.Text = TOrdDesp.Text
                ObservOD.TOPs.Text = "VARIAS"
                ObservOD.TCodForB.Text = "-"
                ObservOD.TNomForB.Text = "-"

            End If

            ObservOD.Show()

            FramDatos.Enabled = True
            FrConductores.Enabled = True
            FrDatosOD.Enabled = True
        End If

    End Sub


    Private Sub TFechaVer_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TFechaVer.ValueChanged
        Try
            If DODesp Is Nothing Then Return
            Dim fechaAux As String

            fechaAux = Format(TFechaVer.Value, "yyyy/MM/dd")
            DODesp.Open("Select * from ORDDESPACHO  where FINALIZADO<>'S' and FECHAPROG LIKE '" + Trim(fechaAux) + "%'")
            AsignaDataGrid(DGOrdenDesp, DODesp.DataTable)

            If DODesp.RecordCount > 0 Then DGOrdenDesp_CellClick(Nothing, Nothing)
            'BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click

        Try
            If EditDatos = False Then
                MsgBox("Esta en una red de replicacion de datos por lo tanto no puede editar informacion, solo visualizarla.", MsgBoxStyle.Information)
                Return
            Else

                DODesp.Open("Select * from ORDENDESP where ORDENDESP='" + TOrdDesp.Text + "'")

                If DODesp.RecordCount = 0 Then Return

                DODesp.RecordSet("FINALIZADO") = "S"
                DODesp.RecordSet("PESOMETA") = 0
                DODesp.RecordSet("SACOS") = 0
                DODesp.Update()

                DODespDet.Delete("delete from ORDENDESPDET where ORDENDESP='" + TOrdDesp.Text + "'")

                Evento("Finaliza manual Orden de Despacho No. " + TOrdDesp.Text)

                BActualizar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        ODesp_Load(Nothing, Nothing)
    End Sub


    Private Sub DGOrdenDesp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGOrdenDesp.KeyDown
        DGOrdenDesp_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGOrdenDesp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGOrdenDesp.KeyUp
        DGOrdenDesp_CellClick(Nothing, Nothing)
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
                ODesp_Load(Nothing, Nothing)
                Exit Sub
            End If

            DODesp.Open("Select * from ORDENDESP where FINALIZADO<>'S' and ORDENDESP LIKE '%" + TBuscar.Text + "%' and  FECHAPROG LIKE '" + Format(TFechaVer.Value, "yyyy/MM/dd") + "%' order by ORDENDESP")
            AsignaDataGrid(DGOrdenDesp, DODesp.DataTable)

            DGOrdenDesp_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub



    Private Sub BImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimir.Click
        Dim RepSap As CrystalRep
        Try
            DConsultas.Refresh()

            DConsultas.RecordSet("F1") = Format(TFechaVer.Value, "yyyy/MM/dd")
            DConsultas.RecordSet("F2") = Format(DateAdd("d", 1, TFechaVer.Value), "yyyy/MM/dd")
            DConsultas.Update()

            If ReportesSap = True Then

                RepSap = New CrystalRep

                With RepSap
                    .ServerName = ServidorSQL
                    If TipoServer <> "SQLSERVER" Then .ServerName = ServidorSQL
                    .DataBaseName = NomDB2
                    .UserId = UserDB
                    .Password = PWD
                    .Formulas(0) = "PLANTA='" + Planta + "'"
                    .Formulas(1) = "HORA='" + Format(Now, "HH:mm") + "'"
                    .Formulas(2) = "DESDE='" + Format(TFechaVer.Value, "yyyy/MM/dd") + "'"
                    .Formulas(3) = "HASTA='" + Format(DateAdd("d", 1, TFechaVer.Value), "yyyy/MM/dd") + "'"
                    .Destination = CrystalRep.Destinacion.crToWindows
                    .WindowState = FormWindowState.Maximized
                    .ChoosePrint = True
                    .MaximizeBox = True
                    .MinimizeBox = True
                End With

                RepSap.ReportFileName = RutaRep + "rplisOrdDespProg.rpt"
                RepSap.SelectionFormula = "{CDESPDET.FINALIZADO}='N'"

                RepSap.PrintReport()

            Else

            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BImpDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim RepSap As CrystalRep
        Try
            If TOrdDesp.Text = "" Then Return

            DConsultas.Refresh()

            DConsultas.RecordSet("I1") = Val(TOrdDesp.Text)
            DConsultas.Update()

            RepSap = New CrystalRep
            With RepSap
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"

                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With
            'Rep1 = RepSap
            RepSap.ReportFileName = RutaRep + "rpOdesp.rpt"
            RepSap.SelectionFormula = "{CORDENDESPDET.ORDENDESP}='" + TOrdDesp.Text + "'"

            RepSap.PrintReport()

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub mnAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcercaD.ShowDialog()
    End Sub

    Private Sub OGranel_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If OGranel.Checked Then
            'TEmpacadoSac.Visible = False
            'TDisponibleSac.Visible = False
            'TEmpacadoKg.Visible = False
            'TMetaDespSac.Visible = False

        Else
            'TGranel.Visible = False
        End If
    End Sub

    Private Sub OEmpaque_CheckedChanged(sender As System.Object, e As System.EventArgs)
        If OEmpaque.Checked Then
            'TEmpacadoSac.Visible = True
            'TDisponibleSac.Visible = True
            'TEmpacadoKg.Visible = True
            'TMetaDespSac.Visible = True

        Else
            'TGranel.Visible = True
        End If
    End Sub

    Private Sub BEmpMan_Click(sender As System.Object, e As System.EventArgs)
        If Permisos("Empaque Editar") Then
        Else
            MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
            Exit Sub
        End If
        'EmpaqueMan.ShowDialog()
    End Sub

    Private Sub TCodProd_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'Try
        '    TNomProd.Text = ""
        '    TDisponibleKg.Text = 0
        '    TDisponibleSac.Text = 0
        '    If TCodProd.Text = "" Then Return
        '    DVarios.Open("select NOMBRE,PRESKG,TIPO from ARTICULOS where CODEXT='" + TCodProd.Text + "'")
        '    If DVarios.RecordCount Then
        '        TNomProd.Text = DVarios.RecordSet("NOMBRE")
        '        TPresKg.Text = DVarios.RecordSet("PRESKG")
        '        TLote.Text = ""
        '        If DVarios.RecordSet("TIPO") = "PT" Then
        '            TLote.Text = "."
        '        Else
        '            DCortesL.Open("select LOTE from CORTESLOTE where ESTADO='A' and CODMAT='" + TCodProd.Text + "'")
        '            If DCortesL.RecordCount Then
        '                TLote.Text = DCortesL.RecordSet("LOTE")
        '            Else
        '                MsgBox("No hay Lote en consumo...No se puede despachar")
        '            End If
        '        End If
        '    End If
        '    If TLote.Text <> "" Then
        '        TDisponibleKg.Text = SaldoLote(TCodProd.Text, TLote.Text)
        '        If Val(TPresKg.Text) Then TDisponibleSac.Text = Math.Round(Eval(TDisponibleKg.Text) / Eval(TPresKg.Text), 1)
        '    End If
        'Catch ex As Exception
        '    MsgBox(Format(Now, "HH:mm:ss   ") + ex.ToString)
        'End Try

    End Sub



    '    Private Sub FProd_Cell_Click(sender As System.Object, e As System.EventArgs) Handles FProd_Cell.Click
    '        Try
    '            Dim ID As Int32
    '            DGEmp.Visible = False

    '            TNomProd.Items.Clear()
    '            DEmp.Open("select * from EMPAQUE where OP=" + TOPs.Text)
    '            For Each RDemp As DataRow In DEmp.Rows
    '                TNomProd.Items.Add(RDemp("CODPROD") + vbTab + RDemp("NOMPROD"))
    '            Next

    '            'TLoteProd.Text = DOPs.RecordSet("LOTEPROD")

    '            DArt.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + DOPs.RecordSet("CODPROD") + "'")
    '            If DArt.RecordCount = 0 Then
    '                MsgBox("Producto no creado : " + DOPs.RecordSet("CODPROD"), MsgBoxStyle.Information)
    '                GoTo Limpiar
    '                Return
    '            End If

    '            TNomProd.Text = DArt.RecordSet("NOMBRE")
    '            DVarios.Open("Select * from CONSULTAS")
    '            DVarios.RecordSet("F1") = Format(DateAdd("d", -400, Now), "yyyy/MM/dd")
    '            DVarios.RecordSet("F2") = Format(DateAdd("d", 1, Now), "yyyy/MM/dd")
    '            DVarios.Update()

    '            TDosificado.Text = 0
    '            DVarios.Open("Select PESOREAL from CCONSUMOSOPTOT where OP='" + Trim(TOPs.Text) + "'")
    '            If DVarios.RecordCount > 0 Then
    '                TDosificado.Text = Format(DVarios.RecordSet("PESOREAL"), "# ##0")
    '            Else
    '                MsgBox("No existen datos de mezcla para esta OP", MsgBoxStyle.Information)
    '                TDosificado.Text = 0
    '                TDisponibleKg.Text = 0
    '                GoTo limpiar
    '            End If

    '            'Verifica el meta de las OPs que ya tengan despachos para alertar al operario si el meta sobrepasa la producción
    '            DVarios.Open("Select SUM(PESOMETA) as SPESOMETA,SUM(SACOSMETA) as SSACOSMETA from  ORDENDESPDET where OP='" + Trim(TOPs.Text) + "'")
    '            TMetaDespKg.Text = 0
    '            TMetaDespSac.Text = 0
    '            If DVarios.RecordCount > 0 AndAlso IsDBNull(DVarios.RecordSet("SPESOMETA")) = False Then
    '                TMetaDespKg.Text = Format(DVarios.RecordSet("SPESOMETA"), "# ##0")
    '                TMetaDespSac.Text = Format(DVarios.RecordSet("SSACOSMETA"), "# ##0")
    '            End If



    '            'Verifica si ya hay sacos empacados de la OP
    '            DVarios.Open("Select SUM(SACOS) AS SSAC, SUM(PESO) AS SPESO from EMPAQUE where PRESET>1 and  OP='" + Trim(TOPs.Text) + "'")
    '            TEmpacadoKg.Text = 0
    '            TEmpacadoSac.Text = 0
    '            TGranel.Text = 0
    '            If DVarios.RecordCount > 0 Then
    '                If IsDBNull(DVarios.RecordSet("SSAC")) = False Then
    '                    TEmpacadoKg.Text = Format(DVarios.RecordSet("SPESO"), "# ##0")
    '                    TEmpacadoSac.Text = Format(DVarios.RecordSet("SSAC"), "# ##0")
    '                End If
    '            End If

    '            'verifica si hay granel para la OP

    '            DVarios.Open("Select SUM(PESO) AS SPESO from EMPAQUE where PRESET=1 and  OP='" + Trim(TOPs.Text) + "'")
    '            If DVarios.RecordCount > 0 And Not IsDBNull(DVarios.RecordSet("SPESO")) Then TGranel.Text = Format(DVarios.RecordSet("SPESO"), "# ##0")

    '            'MsgBox("La OP ingresada no tiene registros de empaque, recuerde que sin sacos empacados de la OP ingresada no puede registrarla", MsgBoxStyle.Critical)
    '            'GoTo limpiar

    '            TDisponibleKg.Text = Format(Eval(TEmpacadoKg.Text) + Eval(TGranel.Text) - Eval(TMetaDespKg.Text), "# ##0")
    '            TDisponibleSac.Text = Format(Eval(TEmpacadoSac.Text) - Eval(TMetaDespSac.Text), "# ##0")

    '            If Eval(TDisponibleSac.Text) <= 0 Then
    '                'MsgBox("La OP ingresada no tiene empaque disponible, recuerde que sin sacos disponibles de la OP ingresada, esta no puede ser registrada", MsgBoxStyle.Critical)
    '                'GoTo limpiar
    '            End If

    '            TCantGranel.Focus()

    '            Exit Sub

    'limpiar:
    '            TOPs.Text = ""
    '            TDisponibleKg.Text = ""
    '            TDisponibleSac.Text = ""
    '            TNomProd.Text = ""
    '            TDosificado.Text = ""
    '            TEmpacadoKg.Text = ""
    '            TEmpacadoSac.Text = ""
    '            TMetaDespKg.Text = ""
    '            TMetaDespSac.Text = ""
    '            TCantGranel.Text = ""
    '            'TLoteProd.Text = ""
    '            TNomProd.Items.Clear()
    '        Catch ex As Exception
    '            MsgError(ex.ToString)
    '        End Try

    '    End Sub


    Private Sub TNomProd_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            TCodProd.Text = ""
            If TNomProd.Text = "" Then Return
            DVarios.Open("select CODEXT,PRESKG,TIPO from ARTICULOS where NOMBRE='" + TNomProd.Text + "'")
            If DVarios.RecordCount Then
                TCodProd.Text = DVarios.RecordSet("CODEXT")
            End If
            If DVarios.RecordCount > 1 Then MsgBox("Hay más de 1 Código con este Nombre", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            MsgBox(Format(Now, "HH:mm:ss   ") + ex.ToString)
        End Try
    End Sub




    Private Sub FODesp_Cell_Click(sender As System.Object, e As System.EventArgs) Handles FODesp_Cell.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            If DGOrdenDesp.RowCount = 0 Then Return
            TOrdDesp.Text = DGOrdenDesp.CurrentRow.Cells("ORDENDESP").Value
            DODesp.Open("Select * from ORDDESPACHO where ORDENDESP=" + Trim(TOrdDesp.Text))
            If DODesp.RecordSet("Granel") <> "S" Then
                OEmpaque.Checked = True
                OGranel.Checked = False
            Else
                OGranel.Checked = True
                OEmpaque.Checked = False
            End If
            TOrdDesp.Text = DODesp.RecordSet("OrdenDesp")
            TCodGranja.Text = DODesp.RecordSet("CodGranja")
            TNomGranja.Text = DODesp.RecordSet("NOMGranja")
            TEdad.Text = DODesp.RecordSet("edad")
            TManifiesto.Text = DODesp.RecordSet("Manifiesto")
            TCodCond.Text = DODesp.RecordSet("CodConductor")
            TNomCond.Text = DODesp.RecordSet("NOMCONDUCTOR")
            TPlaca.Text = DODesp.RecordSet("Placa")
            TMeta.Text = DODesp.RecordSet("PesoMeta")
            If Not IsDBNull(DODesp.RecordSet("ObservModif")) Then
                TObserv.Text = DODesp.RecordSet("ObservModif")
            End If

            TST_JDE.Text = DODesp.RecordSet("SDDOCO")
            TLinea.Text = DODesp.RecordSet("SDLNID")

            TCodProd.Text = DODesp.RecordSet("CodProd")
            TNomProd.Text = DODesp.RecordSet("NomProd")

            If DODesp.RecordSet("Fechaprog") <> "-" Then TFechaDesp.Text = DODesp.RecordSet("Fechaprog")

            If DODesp.RecordSet("granel").trim = "S" Then
                OGranel.Checked = True
            Else
                OEmpaque.Checked = True
            End If

            If Val(TOrdDesp.Text) > 0 Then
                DODespDet.Open("Select PesoMeta as PesoMeta2,* from ORDDESPDET where ORDENDESP=" + TOrdDesp.Text.Trim)

                If DODespDet.RecordCount > 0 Then
                    AsignaDataGrid(GridODDet, DODespDet.DataTable)
                    'TCodProd.Text = DODespDet.RecordSet("CodProd")
                    'TNomProd.Text = DODespDet.RecordSet("NomProd")
                    'TMeta.Text = DODespDet.RecordSet("PesoMeta")
                End If
            End If
            'DGDespDet.Rows.Clear()
            'DODespDet.Open("select * from ORDENDESPDET where ORDENDESP='" + TOrdDesp.Text + "'")
            'AsignaDataGrid(DGDespDet, DODespDet.DataTable, True)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try

    End Sub

    Private Sub TOrdenDesp_LostFocus(sender As Object, e As System.EventArgs) Handles TOrdDesp.LostFocus
        Try
            If Val(TOrdDesp.Text) = 0 Then Return
            DVarios.Open("select * from ORDENDESP where ORDENDESP=" + TOrdDesp.Text)
            If DVarios.RecordCount Then
                MsgBox("El número de Orden ya existe", vbInformation)
                TOrdDesp.Text = ""
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub



    Private Sub TCodCond_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            TNomCond.Text = ""
            If TCodCond.Text = "" Then Return
            DVarios.Open("select * from BASCUSOFT_CONDUCTORES where CODCOND='" + TCodCond.Text + "'")
            If DVarios.RecordCount Then
                TNomCond.Text = DVarios.RecordSet("NOMCOND")
            End If

        Catch ex As Exception
            MsgBox(Format(Now, "HH:mm:ss   ") + ex.ToString)
        End Try

    End Sub

    Private Sub TNomCond_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            TCodCond.Text = ""
            If TNomCond.Text = "" Then Return
            DVarios.Open("select * from BASCUSOFT_CONDUCTORES where NOMCOND='" + TNomCond.Text + "'")
            If DVarios.RecordCount Then
                TCodCond.Text = DVarios.RecordSet("CODCOND")
            End If

        Catch ex As Exception
            MsgBox(Format(Now, "HH:mm:ss   ") + ex.ToString)
        End Try

    End Sub


    Private Sub BMateriales_Click(sender As System.Object, e As System.EventArgs) Handles BMateriales.Click
        Materiales.Show()
    End Sub

    Private Sub BProductos_Click(sender As System.Object, e As System.EventArgs) Handles BProductos.Click
        Productos.Show()
    End Sub

    Private Sub BTraeDatos_Click(sender As Object, e As EventArgs) Handles BTraeDatos.Click
        Try
            If Nuevo = False Then
            Else
                GoTo ODespa
                'Exit Sub
            End If

            TOrdDesp.Text = DODesp.RecordSet("OrdenDesp")
            TCodGranja.Text = DODesp.RecordSet("CodGranja")
            TNomGranja.Text = DODesp.RecordSet("NOMGranja")
            TEdad.Text = DODesp.RecordSet("edad")
            TManifiesto.Text = DODesp.RecordSet("Manifiesto")
            TCodCond.Text = DODesp.RecordSet("CodConductor")
            TNomCond.Text = DODesp.RecordSet("NOMCONDUCTOR")
            TPlaca.Text = DODesp.RecordSet("Placa")
            If Not IsDBNull(DODesp.RecordSet("ObservModif")) Then
                TObserv.Text = DODesp.RecordSet("ObservModif")
            End If
            TST_JDE.Text = DODesp.RecordSet("SDDOCO")
            TLinea.Text = DODesp.RecordSet("SDLNID")

            TCodProd.Text = DODesp.RecordSet("CodProd")
            TNomProd.Text = DODesp.RecordSet("NomProd")

            If DODesp.RecordSet("Fechaprog") <> "-" Then TFechaDesp.Text = DODesp.RecordSet("Fechaprog")

            If DODesp.RecordSet("granel").trim = "S" Then
                OGranel.Checked = True
            Else
                OEmpaque.Checked = True
            End If

ODespa:
            If Val(TOrdDesp.Text) > 0 Then
                DODespDet.Open("Select PesoMeta as PesoMeta2,* from ORDDESPDET where ORDENDESP=" + TOrdDesp.Text.Trim)

                If DODespDet.RecordCount > 0 Then
                    AsignaDataGrid(GridODDet, DODespDet.DataTable)
                    TCodProd.Text = DODespDet.RecordSet("CodProd")
                    TNomProd.Text = DODespDet.RecordSet("NomProd")
                    TMeta.Text = DODespDet.RecordSet("PesoMeta")
                End If
            End If

            Exit Sub

        Catch ex As Exception
            MsgBox(Format(Now, "HH:mm:ss   ") + ex.ToString)
        End Try
    End Sub

    Private Sub BImpODsModif_Click(sender As Object, e As EventArgs) Handles BImpODsModif.Click
        Dim RepSap As CrystalRep
        Try
            DConsultas.Refresh()

            DConsultas.RecordSet("F1") = Format(TFechaVer.Value, "yyyy/MM/dd")
            DConsultas.RecordSet("F2") = Format(DateAdd("d", 1, TFechaVer.Value), "yyyy/MM/dd")
            DConsultas.Update()

            If ReportesSap = True Then

                RepSap = New CrystalRep

                With RepSap
                    .ServerName = ServidorSQL
                    If TipoServer <> "SQLSERVER" Then .ServerName = ServidorSQL
                    .DataBaseName = NomDB2
                    .UserId = UserDB
                    .Password = PWD
                    .Formulas(0) = "PLANTA='" + Planta + "'"
                    .Formulas(1) = "HORA='" + Format(Now, "HH:mm") + "'"
                    .Formulas(2) = "DESDE='" + Format(TFechaVer.Value, "yyyy/MM/dd") + "'"
                    .Formulas(3) = "HASTA='" + Format(DateAdd("d", 1, TFechaVer.Value), "yyyy/MM/dd") + "'"
                    .Destination = CrystalRep.Destinacion.crToWindows
                    .WindowState = FormWindowState.Maximized
                    .ChoosePrint = True
                    .MaximizeBox = True
                    .MinimizeBox = True
                End With

                RepSap.ReportFileName = RutaRep + "rplisObsvODs.rpt"
                RepSap.SelectionFormula = "{CDESPPEND.OBSERV}<>0"

                RepSap.PrintReport()

            Else

            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub BODespDet_Click(sender As Object, e As EventArgs) Handles BODespDet.Click
        Try
            If OGranel.Checked = False And OEmpaque.Checked = False Then
                MsgBox("Debe elegir si la órden de despacho es a granel o empaque", vbCritical)
                Exit Sub
            End If

            'MsgBox "Recuerde que solo podrá adicionar mas de una OP a la órden de despacho si el producto a despachar es alimento para cerdos", vbInformation

            ODespDet.LOrdenDesp.Text = TOrdDesp.Text
            ODespDet.LST_JDE.Text = TST_JDE.Text
            ODespDet.LLinea_JDE.Text = TLinea.Text
            If OGranel.Checked = True Then
                ODespDet.TPesoMeta.Text = TMeta.Text
            ElseIf OEmpaque.Checked = True Then
                ODespDet.TSacos.Text = TMeta.Text
            End If

            ODespDet.ShowDialog()
            BTraeDatos_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub TCodGranja_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodGranja.Enter
        Try
            GridGranjas.Visible = True
            'DGProd.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Private Sub GridGranjas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridGranjas.CellClick
        Try
            If GridGranjas.RowCount = 0 Then Return
            TCodGranja.Text = GridGranjas.CurrentRow.Cells("CodGranja").Value
            TNomGranja.Text = GridGranjas.CurrentRow.Cells("nomGranja2").Value
            GridGranjas.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub TPlaca_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TPlaca.Enter
        Try
            GridVehiculos.Visible = True
            'DGProd.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub GridVehiculos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridVehiculos.CellClick
        Try
            If GridVehiculos.RowCount = 0 Then Return
            TPlaca.Text = GridVehiculos.CurrentRow.Cells("Placa").Value
            GridVehiculos.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub TCodCond_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodCond.Enter
        Try
            GridConductores.Visible = True
            'DGProd.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub GridConductores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridConductores.CellClick
        Try
            If GridConductores.RowCount = 0 Then Return
            TCodCond.Text = GridConductores.CurrentRow.Cells("CodCond").Value
            TNomCond.Text = GridConductores.CurrentRow.Cells("NomCond").Value
            GridConductores.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
    Private Sub TManifiesto_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TManifiesto.Enter
        Try
            GridVehiculos.Visible = False
            GridConductores.Visible = False
            GridVehiculos.Visible = False
            GridGranjas.Visible = False
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
End Class

