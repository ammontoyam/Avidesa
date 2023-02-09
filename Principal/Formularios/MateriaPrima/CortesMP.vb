Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Threading.Thread
Imports System.Data
Imports ChronoSoftNet
Imports System.Text
Imports System.IO

Public Class CortesMP
    Public cancelarCortes = False

    Private DCortesMP As AdoSQL
    Private DArt As AdoSQL
    Private DConsultas As AdoSQL
    Private DVarios As AdoSQL
    Private DClientes As AdoSQL
    Private Fila As Integer
    Private DR As DataRow
    Private DFil() As DataRow
    Private Campos() As String
    Private Rep1 As CrystalRep
    Private DUbic As AdoSQL
    Private DEquipos As AdoSQL
    Private ComImp As Integer
    Private Conx As Connection
    Private FormLoad As Boolean
    Private NombreImpresoraCortes As String

    Private Sub CortesMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FormLoad Then Return

            DCortesMP = New AdoSQL("CortesMP")
            DArt = New AdoSQL("ARTICULOS")
            DConsultas = New AdoSQL("Consultas")
            DVarios = New AdoSQL("VARIOS")
            DUbic = New AdoSQL("UBICACIONES")
            DEquipos = New AdoSQL("EQUIPOS")

            'Se cierran por seguridad todos los cortes que estan finalizados, esto porque hubo un caso en el lote estaba finalizado y 
            'se encontraba en estado activo, por lo cual siempre estaba descontando de un lote equivocado
            DCortesMP.Open("update CORTESLOTE set ESTADO='C' where FINALIZADO='S'")

            If ChTodos.Checked Then
                DCortesMP.Open("select * from CORTESLOTE where FINALIZADO<>'S'")
            Else
                'Selecciona solo los lotes con el campo ubic lote en vacio o las ubicaciones que esten en consumo
                DCortesMP.Open("select * from CORTESLOTE where FINALIZADO<>'S' AND (UBICLOTE='' OR UBICLOTE=ANY(SELECT CODUBI FROM UBICACIONES WHERE TIPO='LT' AND CONSUMO=1))")
            End If

            'Se llena el Objeto TUBICACIONF para filtrado por ubicacion
            DUbic.Open("SELECT CODUBI FROM UBICACIONES WHERE TIPO='LT'")
            LLenaComboBox(TUbicacionF, DUbic.DataTable, "CODUBI")

            DArt.Open("select * from ARTICULOS where TIPO='MP' order by NOMBRE")
            DConsultas.Open("select * from CONSULTAS")
            DUbic.Open("Select * from UBICACIONES WHERE TIPO='MP' order by CODUBI")

            GBEtiqueta.Enabled = False


            'Se revisa si la impresion de etiqueta es por USB o serial
            If ValidaFuncionalidad("Imprimir.Etiqueta.Usb", NombrePC, Me) Then
                NombreImpresoraCortes = ConfigParametros("NomImpCortesMP")
                GBEtiqueta.Enabled = True
            Else
                DEquipos.Open("Select * from EQUIPOS where CODEQUIPO='Zebra.CortesMP'")

                If DEquipos.Count = 0 Then
                    MsgBox("Falta configuración para puerto serial de impresora, tabla equipos", vbCritical)
                    Return
                Else
                    If (DEquipos.RecordSet("PCCONEXION") = Sesion Or DEquipos.RecordSet("PCCONEXION") = NombrePC) And FormLoad = False Then
                        ComImp = DEquipos.RecordSet("COM")

                        If Eval(ComImp) = 0 Then
                            MsgBox("Error en configuración puerto serial", vbCritical)
                            Return
                        End If

                        Conx = New Connection(Connection.TipoConnection.Serial, ComImp.ToString)
                        Conx.Conect()
                        If Conx.State <> Connection.StateConnection.Connected Then
                            BImpEtiq.Enabled = False
                            MsgBox("Error, compruebe la conexión con la impresora", vbCritical)
                        End If

                        GBEtiqueta.Enabled = True

                    End If

                End If
            End If


            'Se revisa si se tiene la funcionalidad de premezclas para habilitar el proveedor

            If Funcion_FuncionesPlantaPremezclas Then
                GBProveedor.Enabled = True
                DClientes = New AdoSQL("CLIENTES")
                DClientes.Open("select * from CLIENTES where TIPO='PROVEEDOR' ORDER BY NOMCLI")
                AsignaDataGrid(DGClientes, DClientes.DataTable)
            Else
                GBProveedor.Enabled = False
            End If


            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGCortes, DCortesMP.DataTable)

            AsignaDataGrid(DGArticulos, DArt.DataTable)


            'Llenamos el combobox ubicaciones
            LLenaComboBox(CUbicacion, DUbic.DataTable, "CODUBI")


            BLimpiar_Click(Nothing, Nothing)


            If DGCortes.RowCount > 0 Then DGCortes_CellClick(Nothing, Nothing)

            Campos = {"CONT@Cont", "CODMAT@Cód.Mat", "NomMat@NomMat", "ESTADO@Abierto/Cerrado", "CONDICION@Condición", "FINALIZADO@Finalizados"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DCortesMP.DataTable)

            BAdicionar.Enabled = False

            'If DRUsuario("CALIDAD") Then
            If ValidaPermiso("Calidad") Then
            Else
                TEstado.Enabled = False
            End If

            FormLoad = True
            FrFiltrar.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGCortes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGCortes.CellClick
        Try

            If DGCortes.CurrentRow Is Nothing Then Return
            If DGCortes.RowCount = 0 Then Exit Sub

            ''BActConsumo_Click(Nothing, Nothing)

            DVarios.Open("Select * from CORTESLOTE WHERE CONT=" + DGCortes.Rows(DGCortes.CurrentRow.Index).Cells("CONT").Value.ToString.Trim)

            If DVarios.Count = 0 Then Exit Sub

            TContCorte.Text = DVarios.RecordSet("Cont")
            TCodMat.Text = DVarios.RecordSet("CODMAT")
            TNomMat.Text = DVarios.RecordSet("NomMat")
            TLote.Text = DVarios.RecordSet("Lote")
            TFechaIni.Text = DVarios.RecordSet("FECHAINI")
            TFechaFin.Text = DVarios.RecordSet("FECHAFIN")
            TFechaEnt.Text = DVarios.RecordSet("FECHAENT")
            TFecha.Value = CDate(TFechaEnt.Text)
            THora.Value = CDate(DVarios.RecordSet("FECHAENT"))
            TEstado.SelectedItem = DVarios.RecordSet("VIGENTE")
            TCondicion.SelectedItem = DVarios.RecordSet("CONDICION")
            TPesoProm.Text = DVarios.RecordSet("PESOPROM")
            TPesoPromEdit.Text = TPesoProm.Text


            TInvIni.Text = DVarios.RecordSet("InvIni")
            TAlarma.Text = DVarios.RecordSet("Alarma")
            TConsumo.Text = DVarios.RecordSet("Consumo")
            TAjusteSal.Text = DVarios.RecordSet("AJUSTE1")
            TAjusteEnt.Text = DVarios.RecordSet("AJUSTE2")
            TEntInv.Text = DVarios.RecordSet("AJUSTE3")
            TSalInv.Text = DVarios.RecordSet("AJUSTE4")
            TFaltaAprox.Text = Format(DevuelveSaldo(), ".00")

            TCeniza.Text = DVarios.RecordSet("CENIZA")
            TGrasa.Text = DVarios.RecordSet("GRASA")
            TProteina.Text = DVarios.RecordSet("PROTEINA")
            THumedad.Text = DVarios.RecordSet("HUMEDAD")
            TObserv.Text = DVarios.RecordSet("OBSERV")
            TPaqporBache.Text = DVarios.RecordSet("PAQPORBACHE")
            TUbicacion.Text = DVarios.RecordSet("UBICLOTE")
            TDescUbicacion.Text = DVarios.RecordSet("DESCUBICLOTE")
            TSecuencia.Text = DVarios.RecordSet("SECUENCIA")
            If DVarios.RecordSet("ESTADO").ToString = "C" Then TFechaFin.Visible = True

            If Funcion_FuncionesPlantaPremezclas Then
                TCodCli.Text = DVarios.RecordSet("CodProveedor")
                TNomCli.Text = DVarios.RecordSet("NomProveedor")
            End If

            Fila = DGCortes.CurrentRow.Index


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub BModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModificar.Click
        Try
            'If DRUsuario("CortesMod") Then
            If ValidaPermiso("CortesMP_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            LMas.Visible = True
            'TCantAdic.Visible = True
            Limpiar_Habilitar_TextBox(TabDatos.Controls, AccionTextBox.Habilitar)
            BNuevo.Enabled = False
            BModificar.Enabled = False
            BFinalizar.Enabled = False
            DGCortes.Enabled = False
            TAjusteSal.ReadOnly = True
            TAjusteEnt.ReadOnly = True
            TEntInv.ReadOnly = True
            TSalInv.ReadOnly = True
            TCondicion.Enabled = True
            TConsumo.ReadOnly = True
            TFaltaAprox.ReadOnly = True
            BAdicionar.Enabled = True
            TInvIni.ReadOnly = True
            ''GBEtiqueta.Enabled = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Dim CantAjuste3, CantAjuste4 As Double
        Try


            If TNomMat.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " nombre material"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If TCodMat.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código material"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If TContCorte.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " contador del corte"), MsgBoxStyle.Information)
                Exit Sub
            End If

            'If Eval(TPesoProm.Text) = 0 Then
            '    MsgBox("Falta el campo PESO PROMEDIO DEL SACO", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            DCortesMP.Open("select * from CORTESLOTE where CONT=" + TContCorte.Text)

            If DCortesMP.Count > 0 Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub

                If DCortesMP.RecordSet("ESTADO").ToString = "A" Then
                    Resp = MsgBox("Desea cerrar este Corte?", vbYesNo + MsgBoxStyle.Information)
                    If Resp = vbYes Then DCortesMP.RecordSet("ESTADO") = "C"
                End If
            Else
                DCortesMP.AddNew()
                DCortesMP.RecordSet("ESTADO") = "C"
                DCortesMP.RecordSet("FINALIZADO") = "N"
                DCortesMP.RecordSet("INVFIN") = 0
                DCortesMP.RecordSet("FECHAENT") = Format(TFecha.Value, "yyyy/MM/dd") + " " + Format(THora.Value, "HH:mm")
                'Se busca la linea para actualizar el porcentaje de merma

                DVarios.Open("Select * from LINEASPROD where TIPO='MP' and LINEA='" + TLinea.Text + "'")

                If DVarios.Count Then
                    DCortesMP.RecordSet("PORCMERMA") = DVarios.RecordSet("PORCMERMA")
                    DCortesMP.RecordSet("LINEA") = DVarios.RecordSet("LINEA")
                End If

                DCortesMP.RecordSet("Cont") = TContCorte.Text
                DCortesMP.RecordSet("CodMat") = TCodMat.Text
                DCortesMP.RecordSet("NomMat") = TNomMat.Text

            End If



            If Eval(TConsumo.Text) = 0 Then
                DCortesMP.RecordSet("Lote") = CLeft(TLote.Text, 15)
            Else
                MsgBox("El código de lote no fue modificado debido a que ya existen consumos reportados con este lote", vbInformation)
            End If

            DCortesMP.RecordSet("FECHAINI") = TFechaIni.Text
            DCortesMP.RecordSet("FECHAFIN") = TFechaFin.Text

            DCortesMP.RecordSet("InvIni") = Eval(TInvIni.Text) + Eval(TCantAdic.Text)
            DCortesMP.RecordSet("Alarma") = Eval(TAlarma.Text)
            DCortesMP.RecordSet("Consumo") = Eval(TConsumo.Text)
            DCortesMP.RecordSet("Condicion") = TCondicion.Text
            DCortesMP.RecordSet("PesoProm") = Eval(TPesoProm.Text)
            DCortesMP.RecordSet("OBSERV") = CLeft(TObserv.Text, 250)
            DCortesMP.RecordSet("UBICLOTE") = CLeft(TUbicacion.Text, 10)
            DCortesMP.RecordSet("DESCUBICLOTE") = CLeft(TDescUbicacion.Text, 30)
            DCortesMP.RecordSet("PAQPORBACHE") = Eval(TPaqporBache.Text)

            If Funcion_FuncionesPlantaPremezclas Then
                DCortesMP.RecordSet("CodProveedor") = TCodCli.Text
                DCortesMP.RecordSet("NomProveedor") = TNomCli.Text
            End If

            CantAjuste3 = 0
            CantAjuste4 = 0

            DVarios.Open("Select * from CORTESLOTE where CONT=" + TContCorte.Text)

            If DVarios.Count > 0 Then
                CantAjuste3 = Eval(TEntInv.Text) - Eval(DVarios.RecordSet("AJUSTE3").ToString)
                CantAjuste4 = Eval(TSalInv.Text) - Eval(DVarios.RecordSet("AJUSTE4").ToString)
            End If

            If CantAjuste3 > 0 Then Inventario(TCodMat.Text, CantAjuste3, TipoInv.CHRONOS, TLote.Text, DetOperacion.ENMP, , , , , , , , UsuarioPrincipal)
            If CantAjuste4 > 0 Then Inventario(TCodMat.Text, CantAjuste4, TipoInv.CHRONOS, TLote.Text, DetOperacion.SLMP, , , , , , , , UsuarioPrincipal)


            DCortesMP.RecordSet("AJUSTE1") = Eval(TAjusteSal.Text)
            DCortesMP.RecordSet("AJUSTE2") = Eval(TAjusteEnt.Text)
            DCortesMP.RecordSet("AJUSTE3") = Eval(TEntInv.Text)
            DCortesMP.RecordSet("AJUSTE4") = Eval(TSalInv.Text)

            If TEstado.Enabled Then DCortesMP.RecordSet("VIGENTE") = TEstado.Text

            DCortesMP.Update(Me)

            Evento("Crea o modifica corte de lote cont: " + TContCorte.Text + " Lote: " + TLote.Text)

            DArt.Open("select * from ARTICULOS where CODINT='" + TCodMat.Text + "'")

            If DArt.Count > 0 Then
                DArt.RecordSet("Lote") = TLote.Text
                DArt.Update(Me)
            End If

            BCancelar_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            'PanDatos.Enabled = False

            BLimpiar_Click(Nothing, Nothing)

            TCodMat.Text = ""
            TNomMat.Text = ""

            BNuevo.Enabled = True
            BModificar.Enabled = True
            BFinalizar.Enabled = True
            PanMat.Enabled = False
            DGCortes.Enabled = True
            LMas.Visible = False
            TCantAdic.Visible = False
            TCondicion.Enabled = False
            DGUbic.Visible = False
            DGClientes.Visible = False
            DGArticulos.Visible = False
            THora.Visible = False
            TFecha.Visible = False
            LFechaIng.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            ' CortesMP_Load(Nothing, Nothing)
            FRefrescaDG_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAbrirCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAbrirCorte.Click
        Try

            If Eval(TContCorte.Text) = 0 Then Exit Sub

            DCortesMP.Find("CONT=" + TContCorte.Text)

            If DCortesMP.EOF = True Then Exit Sub

            If DCortesMP.RecordSet("ESTADO").ToString = "C" Then
                RespInput = MsgBox("Se cerrarán los cortes abiertos de esta materia prima." + vbCrLf + "Está seguro que desea abrir nuevamente el corte " + Trim(TContCorte.Text) + "?", vbYesNo + MsgBoxStyle.Information)
                If RespInput = vbNo Then Exit Sub
            End If

            ' actualizamos la consulta del comand para seleccionar los cortes de material


            DCortesMP.Open("select * from CORTESLOTE where CODMAT='" + Trim(TCodMat.Text) + "' and FINALIZADO<>'S'")

            For Each RecordSet In DCortesMP.DataTable.Rows
                RecordSet("ESTADO") = "C"
                DCortesMP.Update()
            Next

            DCortesMP.Open("select * from CORTESLOTE where CONT=" + TContCorte.Text)
            If DCortesMP.Count = 0 Then Exit Sub

            DCortesMP.RecordSet("ESTADO") = "A"
            'Se asegura que tenga fecha de inicial porque se usa para un tema de inventarios en planta barranquilla
            DCortesMP.RecordSet("FECHAINI") = FechaC()
            DCortesMP.Update(Me)

            Evento("Abre Corte No." + Trim(Eval(TContCorte.Text)))

            If CBBuscar.Text <> "" AndAlso TBuscar.Text <> "" Then
                TBuscar_KeyUp(Nothing, New KeyEventArgs(Keys.K))
            ElseIf TCodMatF.Text <> "" Then
                CBBuscar.SelectedIndex = 1
                TBuscar.Text = TCodMatF.Text
                TBuscar_KeyUp(Nothing, New KeyEventArgs(Keys.K))
            Else
                BActualizar_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try

            'If DRUsuario("CortesMod") Then
            If ValidaPermiso("CortesMP_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            BCancelar_Click(Nothing, Nothing)

            BNuevo.Enabled = False
            BModificar.Enabled = False
            BFinalizar.Enabled = False
            DGCortes.Enabled = False
            'PanDatos.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(TabDatos.Controls, AccionTextBox.Habilitar)
            Limpiar_Habilitar_TextBox(TabDatos.Controls, AccionTextBox.Limpiar)

            PanMat.Enabled = True
            TEstado.SelectedItem = "-"


            Dim ContMax As Long
            ContMax = 0

            DCortesMP.Open("select CONT from CORTESLOTE order by CONT desc")
            If DCortesMP.Count > 0 Then ContMax = CType(DCortesMP.DataTable.Compute("MAX(CONT)", ""), Long)

            TContCorte.Text = (ContMax + 1).ToString

            TCodMat.Focus()

            TFechaIni.Text = Format(Now, "yyyy/MM/dd HH:mm")
            TFechaIni.Visible = False
            TFechaFin.Visible = False
            TFechaFin.Text = Format(DateAdd(DateInterval.Year, 1, Now), "yyyy/MM/dd HH:mm")
            TFechaFin.Enabled = False

            LFechaIng.Visible = True
            TFecha.Visible = True
            THora.Visible = True
            THora.Format = DateTimePickerFormat.Custom
            THora.CustomFormat = "HH:mm:ss"
            TFecha.Value = Now
            THora.Value = Now

            TAjusteSal.ReadOnly = True
            TAjusteEnt.ReadOnly = True
            TEntInv.ReadOnly = True
            TSalInv.ReadOnly = True
            TFaltaAprox.ReadOnly = True
            TConsumo.ReadOnly = True
            TCondicion.Enabled = True


            BAdicionar.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFinalizar.Click
        Try
            'If DRUsuario("CortesMod") Then
            If ValidaPermiso("CortesMP_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Resp = MessageBox.Show("Está seguro que desea finalizar el corte seleccionado", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            Evento("Finaliza corte de lote cont: " + TContCorte.Text + " lote: " + TLote.Text)

            DCortesMP.Open("select * from CORTESLOTE where CONT=" + TContCorte.Text.Trim)
            If DCortesMP.Count = 0 Then Exit Sub

            DCortesMP.RecordSet("FINALIZADO") = "S"
            DCortesMP.RecordSet("FECHAFINALIZADO") = FechaC()
            DCortesMP.RecordSet("ESTADO") = "C"
            DCortesMP.Update(Me)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCerrarCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCerrarCorte.Click
        Try
            If ServComM = False Then
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            RespInput = MsgBox("Está seguro que desea cerrar el corte seleccionado?", vbYesNo + MsgBoxStyle.Information)
            If RespInput = vbNo Then Exit Sub

            If Eval(TContCorte.Text) = 0 Then Exit Sub

            DCortesMP.Find("CONT=" + TContCorte.Text.Trim)
            If DCortesMP.EOF = True Then Exit Sub

            If DCortesMP.RecordSet("ESTADO").ToString = "C" Then
                MsgBox("Este corte ya está cerrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            cancelarCortes = False


            'Se revisa si la MP es aditivo para no pedir que se digite el contador donde salio el corte
            DVarios.Open("Select * from ARTICULOS where A='AD' and TIPO='MP' AND CODINT='" + TCodMat.Text + "'")

            If Funcion_FuncionesPlantaPremezclas = False And DVarios.Count = 0 Then

                'Se busca el ultimo contador registrado en chronosoft para sugerir al usuario
                DVarios.Open("Select top 1 CONT FROM BACHES where BACHEAUTOMATICO=1 order by FECHA desc")
                ObsCortesBaches.TContBache.Items.Clear()
                If DVarios.Count Then
                    ObsCortesBaches.TContBache.Items.Add(DVarios.RecordSet("CONT").ToString)
                End If
                'Muestra los datos del corte para que se digite la observación del corte con el número del contador del bache
                ObsCortesBaches.TCodMat.Text = TCodMat.Text
                ObsCortesBaches.TNomMat.Text = TNomMat.Text
                ObsCortesBaches.TLote.Text = TLote.Text
                ObsCortesBaches.TContCorte.Text = TContCorte.Text
                ObsCortesBaches.TDiferenciaKg.Text = TFaltaAprox.Text
                ObsCortesBaches.ShowDialog()
            End If

            'si en la ventana "ObsCortesBaches" dan cancelar no se realiza el cierre del corte (CortesMP.cancelarCortes = True)
            If cancelarCortes = True Then Return

            DCortesMP.RecordSet("ESTADO") = "C"
            DCortesMP.RecordSet("OBSERV") = DCortesMP.RecordSet("OBSERV") + TObserv.Text

            DCortesMP.Update()

            If CBBuscar.Text <> "" AndAlso TBuscar.Text <> "" Then
                TBuscar_KeyUp(Nothing, New KeyEventArgs(Keys.K))
            ElseIf TCodMatF.Text <> "" Then
                CBBuscar.SelectedIndex = 1
                TBuscar.Text = TCodMatF.Text
                TBuscar_KeyUp(Nothing, New KeyEventArgs(Keys.K))
            Else
                BActualizar_Click(Nothing, Nothing)
            End If



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnAbiertos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAbiertos.Click
        Try
            DCortesMP.Open("select * from CORTESLOTE where ESTADO='A' order BY CONT desc")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGCortes, DCortesMP.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnCerrados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCerrados.Click
        Try
            DCortesMP.Open("select * from CORTESLOTE where ESTADO='C' AND FINALIZADO<>'S' order BY CONT desc")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGCortes, DCortesMP.DataTable)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub mnTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnTodos.Click
        Try
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TInvIni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TInvIni.KeyDown
        Try
            If e.KeyCode <> Keys.Enter Then Exit Sub
            BAdicionar.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TInvIni_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TInvIni.Leave
        Try
            If Eval(TAlarma.Text) = 0 Then TAlarma.Text = Format(Eval(TInvIni.Text) * 0.05, ".00")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub BLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLimpiar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(GBProveedor.Controls, AccionTextBox.Limpiar)
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)
            Limpiar_Habilitar_TextBox(GBProveedor.Controls, AccionTextBox.Deshabilitar)
            TConsumo.ReadOnly = True
            TFaltaAprox.ReadOnly = True
            TCeniza.ReadOnly = True
            TProteina.ReadOnly = True
            THumedad.ReadOnly = True
            TGrasa.ReadOnly = True

            'TCodInt.Items.Clear()
            'TNombre.Items.Clear()

            'LLenaComboBox(TCodInt, DArt.DataTable, "CODINT")
            LLenaComboBox(TNomMat, DArt.DataTable, "NOMBRE")
            LLenaComboBox(CUbicacion, DUbic.DataTable, "CODUBI")

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub



    Private Sub TLote_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TLote.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then TInvIni.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try

            Dim x As Integer
            Dim Hallado As Boolean

            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                ''MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                '' TBuscar.Text = ""
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                FRefrescaDG_Click(Nothing, Nothing)
                Return
            End If

            If TBuscar.Text = "" Then
                FRefrescaDG_Click(Nothing, Nothing)
                Return
            End If

            x = CBBuscar.SelectedIndex
            If TipoCampo(Campos(x), DCortesMP.DataTable) <> "String" And e.KeyCode <> Keys.Enter Then Return

            BusquedaDG(DGCortes, DCortesMP.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGCortes_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRefrescaDG.Click
        Try
            'Refresca el DataGrid de cortes de lote
            If ChTodos.Checked Then
                DCortesMP.Open("select * from CORTESLOTE where FINALIZADO<>'S'")
            Else
                'Selecciona solo los lotes con el campo ubic lote en vacio o las ubicaciones que esten en consumo
                DCortesMP.Open("select * from CORTESLOTE where FINALIZADO<>'S' AND (UBICLOTE='' OR UBICLOTE=ANY(SELECT CODUBI FROM UBICACIONES WHERE TIPO='LT' AND CONSUMO=1))")
            End If
            AsignaDataGrid(DGCortes, DCortesMP.DataTable)

            DArt.Open("select * from ARTICULOS where TIPO='MP' order by NOMBRE")
            AsignaDataGrid(DGArticulos, DArt.DataTable)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMateriales.Click
        Materiales.ShowDialog()
    End Sub


    Private Sub BImportLotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportLotes.Click
        Try
            If Funcion_CentralBasculaServicioWEB Then
                CortesCentralBascula.ShowDialog()
            Else
                CortesContBascula.ShowDialog()
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub BAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdicionar.Click
        Try
            ObsCortesMP.TCorte.Text = TContCorte.Text
            ObsCortesMP.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpCorteAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpCorteAct.Click
        Try
            BCDate_Click(Nothing, Nothing)
            Rep1.ReportFileName = RutaRep + "rpcorte.rpt"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub mnImpAbiertos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpAbiertos.Click
        Try
            BCDate_Click(Nothing, Nothing)
            Rep1.ReportFileName = RutaRep + "rpcorteabierto.rpt"
            Rep1.SelectionFormula = "{CORTESLOTE.ESTADO}='A'"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCDate.Click
        Try


            Dim RepSap As CrystalRep

            DConsultas.Refresh()
            DConsultas.RecordSet("I6") = Eval(TContCorte.Text)
            DConsultas.Update()
            Sleep(200)

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

            Rep1 = RepSap

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnFormulación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnFormulación.Click
        Formulacion.ShowDialog()
    End Sub

    Private Sub mnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnReportes.Click
        Reportes.ShowDialog()
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub


    Private Sub BImpEtiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImpEtiq.Click
        Try

            'Validaciones

            If TNomMat.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " nombre material"), vbInformation)
                Return
            End If

            If TCodMat.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código material"), vbInformation)
                Return
            End If

            If CUbicacion.Text = "" And Not Funcion_FuncionesPlantaPremezclas Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " ubicación"), vbInformation)
                Return
            End If


            If OpMP.Checked Then
                If Eval(TContCorte.Text) = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " contador corte"), vbInformation)
                    Return
                End If

                If TLote.Text = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " lote"), vbInformation)
                    Return
                End If

                If TCondicion.Text = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " condición"), vbInformation)
                    Return
                End If


                If TPesoProm.Text = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " peso promedio"), vbInformation)
                    Return
                End If

            End If

            If TNoCopias.Value = 0 Then Return

            If ValidaFuncionalidad("Imprimir.Etiqueta.Usb", NombrePC, Me) Then
                ImprimirUSB()
            Else
                ImprimirSerial()
            End If

            If OpMP.Checked Then BAceptar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TPesoPromEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TPesoPromEdit.TextChanged
        Try
            TPesoProm.Text = TPesoPromEdit.Text
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGCortes_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGCortes.CellFormatting
        Try
            If DGCortes.Columns(e.ColumnIndex).Name = "VIGENTE" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor <> "-") Then
                        DGCortes.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        ' DGSoliCargue.RowsDefaultCellStyle.BackColor = Color.Yellow
                        ' e.CellStyle.BackColor = Color.Yellow
                    End If
                End If
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGCortes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGCortes.KeyDown
        DGCortes_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGCortes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGCortes.KeyUp
        DGCortes_CellClick(Nothing, Nothing)
    End Sub


    Private Sub BDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDescartar.Click

        Try
            'If DRUsuario("CortesMod") Then
            If ValidaPermiso("CortesMP_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Resp = MessageBox.Show("Desea finalizar el corte seleccionado como descartado?", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub



            DCortesMP.Open("select * from CORTESLOTE where CONT=" + TContCorte.Text.Trim)
            If DCortesMP.Count = 0 Then Exit Sub

            DCortesMP.RecordSet("FINALIZADO") = "S"
            DCortesMP.RecordSet("DESCARTADO") = 1
            DCortesMP.RecordSet("FECHAFINALIZADO") = FechaC()
            DCortesMP.RecordSet("ESTADO") = "C"
            DCortesMP.Update(Me)

            Evento("Descarta corte de lote cont: " + TContCorte.Text + " lote: " + TLote.Text)

            BActualizar_Click(Nothing, Nothing)


            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnVerFinalizados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnVerFinalizados.Click
        Try
            DCortesMP.Open("select * from CORTESLOTE where FINALIZADO='S' order BY CONT desc")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGCortes, DCortesMP.DataTable)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnObservCortes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnObservCortes.Click
        Try
            BCDate_Click(Nothing, Nothing)
            Rep1.ReportFileName = RutaRep + "RpCorteSinConsumo.rpt"
            Rep1.Formulas(2) = "TITULO='Corte de Materia Prima'"
            Rep1.SelectionFormula = "{CCORTELOTESINCONSUMO.CONT}=" + Trim(TContCorte.Text)
            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BOKFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOKFiltrar.Click
        Dim Consulta As String = ""
        Try
            Consulta = "select * from CORTESLOTE "
            If Eval(TCodMatF.Text) > 0 And Trim(TLoteF.Text) <> "" Then
                Consulta = "select * from CORTESLOTE where CODMAT='" + TCodMatF.Text + "' and LOTE='" + TLoteF.Text + "'"
            End If

            If Eval(TCodMatF.Text) > 0 And Trim(TLoteF.Text) = "" Then
                Consulta = "select * from CORTESLOTE where CODMAT='" + TCodMatF.Text + "'"
            End If
            If Eval(TCodMatF.Text) = 0 And Trim(TLoteF.Text) <> "" Then
                Consulta = "select * from CORTESLOTE where LOTE='" + TLoteF.Text + "'"
            End If

            If OPFinalizados.Checked = False Then
                If InStr(1, Consulta, "where") <> 0 Then
                    Consulta += " and FINALIZADO<>'S'"
                Else
                    Consulta += " where FINALIZADO<>'S'"
                End If
            End If

            If TUbicacionF.Text.Length > 1 Then
                If InStr(1, Consulta, "where") <> 0 Then
                    Consulta += " and UBICLOTE='" + TUbicacionF.Text + "'"
                Else
                    Consulta += " where UBICLOTE='" + TUbicacionF.Text + "'"
                End If
            End If

            Consulta += "  order by CONT desc"

            DCortesMP.Open(Consulta)
            AsignaDataGrid(DGCortes, DCortesMP.DataTable)

            FrFiltrar.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelarFiltrar.Click
        FrFiltrar.Visible = False
    End Sub

    Private Sub BBusquedaAvanz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBusquedaAvanz.Click
        Try
            TCodMatF.ReadOnly = False
            TNomMatF.ReadOnly = False
            TLoteF.ReadOnly = False
            FrFiltrar.Visible = True
            TCodMatF.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TCodInt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodMat.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso DGArticulos.Rows.Count = 1 Then
                DGArticulos_CellClick(Nothing, Nothing)
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomMat.Text = ""
            End If

            If TCodMat.Text = "" Then
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGArticulos, DArt.DataTable)
                Exit Sub
            End If

            Dim Hallado As Boolean

            BusquedaDG(DGArticulos, DArt.DataTable, TCodMat.Text, "CODINT", Hallado)

            If Hallado = False Then
                TCodMat.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TNombre_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TNomMat.KeyUp
        Try
            If TNomMat.Text = "" Then Exit Sub
            DArt.Find("NOMBRE='" + TNomMat.Text.Trim + "'")

            If DArt.EOF Then
                'MsgBox("El Ingrediente ingresado no existe", MsgBoxStyle.Information)
                Exit Sub
            End If

            TCodMat.Text = DArt.RecordSet("CODINT").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TCodInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodMat.Click
        Try
            Dim Tipo As String = ""

            If OpMP.Checked Then
                Tipo = "MP"
            ElseIf OPEmp.Checked Then
                Tipo = "EM"
            Else
                Tipo = "ET"
            End If
            DArt.Open("Select * from ARTICULOS where TIPO='" + Tipo + "' order BY CODINT")
            AsignaDataGrid(DGArticulos, DArt.DataTable)
            DGArticulos.Visible = True
            DGArticulos.Height = 334


            DArt.Open("select * from ARTICULOS where TIPO='" + Tipo + "' order by NOMBRE")
            LLenaComboBox(TNomMat, DArt.DataTable, "NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGArticulos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGArticulos.CellClick
        Try
            If DGArticulos.Rows.Count = 0 Then Exit Sub

            TCodMat.Text = ""
            TNomMat.Text = ""

            TCodMat.Text = DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("CodInt").Value.ToString.Trim
            TNomMat.Text = DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("Nombre").Value.ToString.Trim
            TLinea.Text = DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("Linea").Value.ToString.Trim

            DGArticulos.Visible = False

            If DArt.EOF Then Exit Sub
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodInt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodMat.Enter
        TCodInt_Click(Nothing, Nothing)
    End Sub

    Private Sub OPEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPEmp.Click
        TCodInt_Click(Nothing, Nothing)
    End Sub

    Private Sub OPEtiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPEtiq.Click
        TCodInt_Click(Nothing, Nothing)
    End Sub



    Private Sub TUbicacion_Enter(sender As System.Object, e As System.EventArgs) Handles TUbicacion.Enter
        Try
            DUbic.Open("Select * from UBICACIONES WHERE TIPO='LT' order by CODUBI")
            AsignaDataGrid(DGUbic, DUbic.DataTable, True)
            DGUbic.Visible = True
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGUbic_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGUbic.CellClick
        Try
            If Not IsNothing(DGUbic.CurrentRow) Then
                TUbicacion.Text = DGUbic.Rows(DGUbic.CurrentRow.Index).Cells("CODUBI").Value.ToString
                TDescUbicacion.Text = DGUbic.Rows(DGUbic.CurrentRow.Index).Cells("DESCRIPCION").Value.ToString
            End If
            DGUbic.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BExportar_Click(sender As System.Object, e As System.EventArgs) Handles BExportar.Click
        Try

            BExportCortes_Click(Nothing, Nothing)
            BExportArt_Click(Nothing, Nothing)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BExportCortes_Click(sender As System.Object, e As System.EventArgs) Handles BExportCortes.Click
        Try
            Dim Cadena As String = ""
            Dim Separador As String = ";"
            Dim Archivo As FileStream
            Dim byteData() As Byte
            Dim RutaArchivo As String = ""

            RutaArchivo = ConfigParametros("RutaInventario")

            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo += "\CortesMP.chr"

            File.Delete(RutaArchivo)

            Archivo = New FileStream(RutaArchivo, FileMode.Append)


            DVarios.Open("Select * from CORTESLOTE WHERE FINALIZADO<>'S'")

            'Función para exportar a un archivo plano CSV los registros de los cortes, de los cuales se va a hacer inventario

            For Each Fila As DataRow In DVarios.Rows

                Cadena += Fila("CONT").ToString + Separador
                Cadena += Fila("CODMAT").ToString + Separador
                Cadena += Fila("NOMMAT").ToString + Separador
                Cadena += Fila("LOTE").ToString + Separador
                Cadena += Fila("CONDICION").ToString + Separador
                Cadena += Fila("PESOPROM").ToString
                Cadena += vbCrLf
            Next

            byteData = Encoding.Default.GetBytes(Cadena)
            Archivo.Write(byteData, 0, byteData.Length)

            Archivo.Close()

            ''File.Encrypt(RutaArchivo)

            Evento("Genera archivo con cortes de materia prima para inventarios")
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BExportArt_Click(sender As System.Object, e As System.EventArgs) Handles BExportArt.Click
        Try
            Dim Cadena As String = ""
            Dim Separador As String = ";"
            Dim Archivo As FileStream
            Dim byteData() As Byte
            Dim RutaArchivo As String = ""

            RutaArchivo = ConfigParametros("RutaInventario")

            If Not Directory.Exists(RutaArchivo) Then
                Directory.CreateDirectory(RutaArchivo)
            End If

            RutaArchivo += "\Articulos.art"

            File.Delete(RutaArchivo)

            Archivo = New FileStream(RutaArchivo, FileMode.Append)


            DVarios.Open("Select CODINT,NOMBRE,TIPO,LINEA from ARTICULOS WHERE TIPO='MP' ORDER BY TIPO,NOMBRE")

            'Función para exportar a un archivo plano CSV los registros de los cortes, de los cuales se va a hacer inventario

            For Each Fila As DataRow In DVarios.Rows

                Cadena += Fila("CODINT").ToString + Separador
                Cadena += Fila("NOMBRE").ToString + Separador
                Cadena += Fila("TIPO").ToString + Separador
                Cadena += Fila("LINEA").ToString
                Cadena += vbCrLf
            Next

            byteData = Encoding.Default.GetBytes(Cadena)
            Archivo.Write(byteData, 0, byteData.Length)

            Archivo.Close()

            Evento("Genera archivo actualizado de catalogo de articulos")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActConsumo_Click(sender As Object, e As EventArgs) Handles BActConsumo.Click
        Try
            If Eval(TContCorte.Text) = 0 Then Return

            DVarios.Open("Select sum(PESOREAL) as PESOTOT from CONSUMOS where CORTELOTE=" + TContCorte.Text)

            If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOTOT")) Then

                DCortesMP.Find("CONT=" + TContCorte.Text)

                If DCortesMP.EOF Then Return

                DCortesMP.RecordSet("CONSUMO") = Math.Round(DVarios.RecordSet("PESOTOT"), 3)
                DCortesMP.Update()

            End If

            Sleep(100)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnCortesPrem_Click(sender As System.Object, e As System.EventArgs) Handles mnCortesPrem.Click
        Try
            BCDate_Click(Nothing, Nothing)
            Rep1.ReportFileName = RutaRep + "rpcortesprem.rpt"
            Rep1.SelectionFormula = "{CORTESLOTE.PESOPROM}>0 and {CORTESLOTE.PAQPORBACHE}>0"
            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodCli_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodCli.Enter
        Try
            DGClientes.Height = 248
            DGClientes.Location = New Point(481, 457)
            DGClientes.Visible = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGClientes.CellClick

        Try
            If Not IsNothing(DGClientes.CurrentRow) Then
                TCodCli.Text = DGClientes.Rows(DGClientes.CurrentRow.Index).Cells("CODCLI").Value.ToString
                TNomCli.Text = DGClientes.Rows(DGClientes.CurrentRow.Index).Cells("NOMCLI").Value.ToString
            End If

            DGClientes.Visible = False

            DGClientes.CurrentCell = Nothing

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMatF_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TCodMatF.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BOKFiltrar_Click(Nothing, Nothing)
    End Sub

    Private Sub ImprimirUSB()
        Try
            Dim Secuencia As Integer = Val(TSecuencia.Text)
            Dim j As Integer
            Dim Rellenar As Char = "0"
            Dim CodigoBarras As New BarCode
            Dim RepSap As CrystalRep
            Dim Separador As String = "K"
            Dim Fecha As String = ""
            'RepSap = New CrystalRep


            DVarios.Open("Select secuencia from CORTESLOTE where CONT=" + TContCorte.Text)

            If DVarios.Count Then
                Secuencia = DVarios.RecordSet("SECUENCIA")
            End If


            For j = 0 To TNoCopias.Value - 1
                Dim Bm As Bitmap
                'Application.DoEvents()
                Secuencia += 1
                'Codigo de barras del Codigo DE Material
                CodigoBarras.DescCarpeta = "MP"
                CodigoBarras.NombreArchivoBMP = "CodBarMP.bmp"

                If Funcion_FuncionesPlantaPremezclas Or Planta.Contains("GIRARDOTA") Then
                    Bm = CodigoBarras.Code128(TCodMat.Text.PadLeft(8, Rellenar) + TContCorte.Text.PadLeft(8, Rellenar) + Secuencia.ToString.PadLeft(4, Rellenar), BarCode.Code128SubTypes.CODE128, True, 70)
                Else
                    Bm = CodigoBarras.Code128(TContCorte.Text.PadLeft(8, Rellenar) + CUbicacion.Text.PadLeft(2, Rellenar) + Format(Val(TPesoProm.Text), "##.00").PadRight(5, Rellenar), BarCode.Code128SubTypes.CODE128, True, 70)
                End If

                CodigoBarras.Guardar(Bm)



                RepSap = New CrystalRep
                With RepSap
                    .ServerName = ServidorSQL
                    .DataBaseName = NomDB
                    .UserId = UserDB
                    .Password = PWD
                    .Formulas(0) = "NOMMAT='" + TNomMat.Text + "'"

                    Fecha = TFechaEnt.Text

                    If Fecha = "-" Then Fecha = FechaC()

                    .Formulas(1) = "FECHA='" + Fecha + "'"
                    .Formulas(2) = "PLANTA='" + Planta + "'"
                    .Formulas(3) = "CODMAT='" + TCodMat.Text + "'"
                    .Formulas(4) = "LOTE='" + TLote.Text + "'"
                    .Formulas(5) = "UBICACION='" + CUbicacion.Text + "'"


                    If Funcion_FuncionesPlantaPremezclas Then
                        .Formulas(6) = "PESOPROMEDIO='" + TPesoPromEdit.Text + " Kg'"
                        .Formulas(7) = "PROVEEDOR='" + TNomCli.Text + "'"
                    Else
                        .Formulas(6) = "PESOPROMEDIO='" + TPesoProm.Text + " Kg'"
                        .Formulas(7) = "CONDICION='" + TCondicion.Text + "'"
                    End If
                    .Destination = CrystalRep.Destinacion.crToPrinter
                    .WindowState = FormWindowState.Maximized
                    '.ChoosePrint = True
                    .MaximizeBox = True
                    .MinimizeBox = True
                    .Copias = 1

                End With

                RepSap.ReportFileName = RutaRep + "rpEtiqLote.rpt"
                'Se envian el nombre de la impresora, el  ancho en centesimas de pulgada, el alto en centesimas de pulgada
                '1 mm = 3.93701 centesimas de pulgada, las dimensiones de la etiqueta son Ancho=100 mm, alto=50 mm

                ''RepSap.PrintReport(NombreImpresoraCortes, 393.701, 196.8505)
                If Funcion_FuncionesPlantaPremezclas OrElse Funcion_PlantasExternas Then
                    RepSap.PrintReport(NombreImpresoraCortes, 393.701, 196.8505)
                Else
                    RepSap.PrintReport(NombreImpresoraCortes)
                End If

                If Secuencia Mod 5 = 0 Then 'Actualizamos en la base de datos cada 
                    'Se actualiza el número de secuencia para el contador, para evitar imprimir etiquetas con mismo numero de secuencia
                    DVarios.Open("Select * from CORTESLOTE where CONT=" + TContCorte.Text)
                    If DVarios.Count > 0 Then
                        DVarios.RecordSet("SECUENCIA") = Secuencia
                        DVarios.Update()
                    End If
                End If

            Next

            'Se actualiza el´ultimo número de secuencia
            DVarios.Open("Select * from CORTESLOTE where CONT=" + TContCorte.Text)
            If DVarios.Count > 0 Then
                DVarios.RecordSet("SECUENCIA") = Secuencia
                DVarios.Update()
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ImprimirSerial()
        Try
            Dim i As Integer
            Dim j As Integer
            Dim TramaImpresion As String
            Dim Renglon() As String
            Dim Tipo As String = ""

            TramaImpresion = ""

            If OPEmp.Checked Then
                Tipo = "EM"
            ElseIf OPEtiq.Checked Then
                Tipo = "ET"
            End If

            If OpMP.Checked Then
                TramaImpresion = TramaEtiquetaMP(TContCorte.Text, TCodMat.Text, TNomMat.Text, TLote.Text, TCondicion.Text, CUbicacion.Text, TPesoPromEdit.Text)
            Else
                TramaImpresion = TramaEtiquetaEMET(TCodMat.Text, TNomMat.Text, CUbicacion.Text, Tipo)
            End If

            Renglon = Split(TramaImpresion, vbNewLine)

            For j = 0 To TNoCopias.Value - 1
                For i = 0 To UBound(Renglon)
                    Conx.SendData(Renglon(i) + vbNewLine)
                    Sleep(50)
                Next
                Sleep(300)
            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEliminar_Click(sender As Object, e As EventArgs) Handles BEliminar.Click

        Try
            'If DRUsuario("CortesMod") Then
            If ValidaPermiso("CortesMP_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            Evento("Eliminar corte de lote cont: " + TContCorte.Text + " lote: " + TLote.Text)

            DCortesMP.Delete("delete from CORTESLOTE where CONT=" + TContCorte.Text.Trim, Me)

            FRefrescaDG_Click(Nothing, Nothing)

            If TCodMatF.Text <> "" Then
                BOKFiltrar_Click(Nothing, Nothing)
                If DGCortes.RowCount = 0 Then FRefrescaDG_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TNombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TNomMat.SelectedIndexChanged
        'Try
        '    If TNomMat.Text = "" Then Exit Sub
        '    DArt.Find("NOMBRE='" + TNomMat.Text.Trim + "'")

        '    If DArt.EOF Then
        '        'MsgBox("El Ingrediente ingresado no existe", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    TCodMat.Text = DArt.RecordSet("CODINT").ToString
        '    TLinea.Text = DArt.RecordSet("LINEA")

        'Catch ex As Exception
        '    MsgError(ex)
        'End Try
    End Sub

    Private Sub ChTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChTodos.CheckedChanged
        Try
            FRefrescaDG_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Function DevuelveSaldo() As Double
        Try
            DevuelveSaldo = 0

            DevuelveSaldo = Eval(TInvIni.Text) + Eval(TEntInv.Text) + Eval(AjustesInv.Text) + Eval(TAjusteSal.Text) + Eval(TSalInv.Text) - Eval(TConsumo.Text)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Function

    Private Sub TCodCli_Leave(sender As Object, e As EventArgs) Handles TCodCli.Leave
        'DGClientes.Visible = False
    End Sub
End Class