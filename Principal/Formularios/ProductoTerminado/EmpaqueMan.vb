Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class EmpaqueMan
    Private DEmpaque As AdoSQL
    Private DOPs As AdoSQL
    Private DArt As AdoSQL
    Private DVarios As AdoSQL
    Private Fila As Integer
    Private DFil() As DataRow
    Private DR As DataRow
    Private SentenciaSacos As String
    Private SentenciaPeso As String
    Private DTolvas As AdoSQL
    Private DUbicaciones As AdoSQL
    Private DArtDet As AdoSQL
    Private EstadoEmp As Boolean = False
    Private editnuevo As Boolean = False

    Private Sub EmpaqueMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            DEmpaque = New AdoSQL("Empaque")
            DOPs = New AdoSQL("OPs")
            DArt = New AdoSQL("ARTICULOS")
            DVarios = New AdoSQL("Empaque")
            DTolvas = New AdoSQL("Tolvas")
            DUbicaciones = New AdoSQL("Ubicaciones")
            DArtDet = New AdoSQL("ArticulosDet")

            BAceptar.Enabled = False
            DArt.Open("Select * From ARTICULOS where TIPO='PT'")

            'LLenamos el objeto origen
            DTolvas.Open("Select * from TOLVAS where PROCESO='EMPAQUE' and MAQUINA='GR'")
            LLenaComboBox(CBOrigen, DTolvas.DataTable, "TOLVA")

            LLenaDestino()

            GBPaqueteo.Visible = False
            ''Se valida la funcionalidad manejar paqueteo, es algo que se empezó a desarrollar pero no se terminó
            'If ValidaFuncionalidad("Manejar.Paqueteo") Then GBPaqueteo.Visible = True



        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    
    Private Sub TOPs_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPs.KeyUp
        Try

            If e.KeyCode <> Keys.Enter Then Return

            If TOPs.Text = "" Then Exit Sub

            DOPs.Open("Select * from OPs where OP='" + TOPs.Text.ToString + "' and FINPLANILLA<>'S'")

            If DOPs.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE), MsgBoxStyle.Critical)
                BCancelar_Click(Nothing, Nothing)
                Return
            End If

            'Buscamos el producto en la tabla para traer datos
            DArt.Refresh()
            DArt.Find("CodInt = '" + DOPs.RecordSet("CodProd").ToString + "'")
            If DArt.EOF Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE), ", código de producto", MsgBoxStyle.Critical)
                Return
            End If

            'Buscamos si hay dosificación para esta OP, si no existe la dosificación entonces no deja realizar el
            'empaque
            DVarios.Open("Select * from BACHES where OP='" + TOPs.Text + "'")

            If DVarios.Count = 0 AndAlso DOPs.RecordSet("SinControlSackOff") = False Then
                MsgBox(DevuelveEvento(CodEvento.OP_SINCONSUMOS), MsgBoxStyle.Critical)
                BCancelar_Click(Nothing, Nothing)
                Return
            End If


            TCodInt.Text = DArt.RecordSet("CodInt").ToString
            TNombre.Text = DArt.RecordSet("Nombre").ToString
            TNomFor.Text = DOPs.RecordSet("NomFor").ToString
            TCodFor.Text = DOPs.RecordSet("CodFor").ToString
            TPesoSaco.Text = DArt.RecordSet("Preskg").ToString
            'TCodEmp.Text = DArt.RecordSet("CodEmp").ToString
            TCodEtiq.Text = DArt.RecordSet("CodEtiq").ToString
            TObservOP.Text = DOPs.RecordSet("ObservOP").ToString

            'Se buscan los códigos de empaque disponibles para ese producto
            DArtDet.Open("Select * from ARTICULOSDET where CODINT='" + TCodInt.Text + "'")
            If DArtDet.Count > 0 Then
                LLenaComboBox(TCodEmp, DArtDet.DataTable, "CODINTDET")
                TCodEmp.Text = DArt.RecordSet("CodEmp").ToString
            Else
                TCodEmp.Text = DOPs.RecordSet("CodEmp").ToString
            End If

            If Funcion_FuncionesPlantaPremezclas Then TPesoSaco.Text = DOPs.RecordSet("Preskg").ToString

            'Si hay paqueteo, ojo que todavia no se ha terminado de desarrollar
            If GBPaqueteo.Visible Then
                TCodEmpBolsa.Text = DArt.RecordSet("CODEMPBOLSA").ToString
                TCodEmpPaca.Text = DArt.RecordSet("CODEMPPACA").ToString
                TCodEtiqBolsa.Text = DArt.RecordSet("CODETIQBOLSA").ToString
                TCodEtiqPaca.Text = DArt.RecordSet("CODETIQPACA").ToString
                CBPresKgPaca.Text = DArt.RecordSet("PRESKGPACA").ToString
                CBPresKgBolsa.Text = DArt.RecordSet("PRESKGBOLSA").ToString
            End If

            SentenciaSacos = "Sacos+Reproceso+SacosAjuste+SacosNC as SACOSTOT"
            SentenciaPeso = "Peso+Residuo+PesoAjuste+(Reproceso+SacosNC)*PresKg as PESOTOT"

            FRefrescaDG_Click(Nothing, Nothing)

            If DGEmpaque.Rows.Count > 0 And RBAjuste.Checked = True Then DGEmpaque_CellClick(Nothing, Nothing)

            SendKeys.Send("{TAB}")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub TSacos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TSacos.KeyUp
        Try
            If TSacos.Text = "" OrElse TPesoSaco.Text = "" Then Exit Sub

            TPeso.Text = (Eval(TSacos.Text) * Eval(TPesoSaco.Text)).ToString

            If GBPaqueteo.Visible And Eval(CBPresKgBolsa.Text) > 0 Then
                TNroBolsas.Text = (Eval(TSacos.Text) * (Eval(TPesoSaco.Text) / Eval(CBPresKgBolsa.Text))).ToString
            End If

            If Keys.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            'validaciones para poder guardar los datos
            Dim PesoDosif As Double = 0
            Dim PesoEmp As Double = 0
            Dim LineaInvent As String = ""

            BAceptar.Enabled = False

            If Eval(TOPs.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " OP"), MsgBoxStyle.Critical)
                Return
            End If

            If TCodFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " fórmula"), MsgBoxStyle.Critical)
                Return
            End If

            If TNomFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " nombre fórmula"), MsgBoxStyle.Critical)
                Return
            End If


            If DOPs.RecordSet("FINPLANILLA") = "S" Then
                MsgBox(DevuelveEvento(CodEvento.OP_FINPLANILLA), vbInformation)
                Return
            End If

            If Len(CBDestino.Text) > 2 Or CBDestino.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " destino"), vbInformation)
                Return
            End If

            If (Eval(TMaquina.Text) = 0) Or (Eval(TMaquina.Text) > 10) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " máquina"), vbInformation)
                Return
            End If

            If Val(TPeso.Text) = 0 And (InStr(1, CBTipo.Text, "NC KILOS") Or InStr(1, CBTipo.Text, "COLA") Or InStr(1, CBTipo.Text, "GRANEL")) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " peso"), vbInformation)
                Return
            End If

            If Val(TPeso.Text) = 0 And InStr(1, CBTipo.Text, "MANUAL") Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " peso"), vbInformation)
                Return
            End If

            If TCodInt.Text = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código producto"), vbInformation), vbInformation)
                Return
            End If
            If Trim(CBPresent.Text) = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " presentación"), vbInformation)
                Return
            End If

            If InStr(1, CBTipo.Text, "NC ") Or InStr(1, CBTipo.Text, "REEMP") Then
                If Eval(TDetalle.Text) = 0 Then
                    MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " número NC"), vbInformation), vbInformation)
                    Return
                End If
            End If

            If InStr(1, CBTipo.Text, "AJUSTE") AndAlso Math.Abs(Val(TSacosAjuste.Text)) > Eval(ConfigParametros("MAXSACOSAJUSTE")) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " sacos ajuste mayor o menor a " + Eval(ConfigParametros("MAXSACOSAJUSTE")).ToString), vbInformation)
                Return
            End If

            If InStr(1, CBTipo.Text, "COLA") Then
                If Eval(TPeso.Text) >= Eval(ConfigParametros("MAXTAMCOLAS")) Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " cola >= " + Eval(ConfigParametros("MAXTAMCOLAS")).ToString), vbInformation)
                    Return
                End If
            End If

            If InStr(1, TSacos.Text, ".") Or InStr(1, TSacos.Text, ",") Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " sacos"), vbInformation)
                Return
            End If

            If InStr(1, CBDestino.Text, "GR") And Eval(CBOrigen.Text) = 0 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " origen"), vbInformation), vbInformation)
                Return
            End If


            If DOPs.RecordSet("SINCONTROLSACKOFF") = False And (CBTipo.Text.Contains("MANUAL") Or CBTipo.Text.Contains("GRANEL")) Then
                'Realizamos la validación para saber si la OP no supera el embral del sackoff

                SentenciaPeso = "Peso+Residuo+PesoAjuste+(Reproceso+SacosNC)*PresKg"

                DVarios.Open("select OP, Sum(" + SentenciaPeso + ") AS PESOTOT  From EMPAQUE where MAQUINA<100 group by OP HAVING OP='" + TOPs.Text + "'")
                If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("PESOTOT")) Then
                    PesoEmp = DVarios.RecordSet("PESOTOT")
                End If

                DVarios.Open("select Sum(PESOREAL) AS TOTALKG From CONSUMOS where cont=" +
                             "any(select cont from BACHES where OP='" + TOPs.Text + "')")

                If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("TOTALKG")) Then
                    PesoDosif = DVarios.RecordSet("TOTALKG")
                End If

                If PesoEmp + Eval(TPeso.Text) >= PesoDosif * Eval(ConfigParametros("UMBRALSACKOFF")) Then
                    MsgBox(DevuelveEvento(CodEvento.OP_UMBRALSACKOFF, ConfigParametros("UMBRALSACKOFF")), vbInformation)
                    Return
                End If

            End If

            If RBAjuste.Checked Then



                If DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("TIPO").Value.ToString.Trim.ToUpper <> "AUTOMATICO" Then
                    MsgBox(DevuelveEvento(CodEvento.EMPAQUE_REGISTROAUTO), vbInformation)
                    Return
                End If

                If InStr(1, CBTipo.Text, "NC ") And CBDestino.Text <> "ZR" Then
                    MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR, " Si el empaque es NC, debe elegir destino ZR"), vbInformation), vbInformation)
                    Return
                End If

                DEmpaque.Open("Select * from EMPAQUE where CONT=" + DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("CONT").Value.ToString)

                If DEmpaque.Count > 0 Then

                    'Se revisa si el registro ya fue ajustado por reempaque o sacosNC, si es así no se deja realizar ninguna otra operacion

                    If DEmpaque.RecordSet("REGAJUSTADO") Then
                        MsgBox(DevuelveEvento(CodEvento.EMPAQUE_REGAJUSTADO), vbInformation)
                        Return
                    End If

                    Dim SacosAjuste As Integer = 0
                    Dim PesoReproceso As Single = 0

                    If Eval(TSacosAjuste.Text) > 0 Then
                        SacosAjuste = Eval(TSacosAjuste.Text) * -1
                    Else
                        SacosAjuste = Eval(TSacosAjuste.Text)
                    End If

                    Select Case CBTipo.Text
                        Case "NC SACOS"
                            DEmpaque.RecordSet("SacosNC") = SacosAjuste
                            PesoReproceso = DEmpaque.RecordSet("SacosNC") * Eval(TPesoSaco.Text) * -1
                            DEmpaque.RecordSet("PesoReproceso") = PesoReproceso
                        Case "REEMPAQUE"
                            DEmpaque.RecordSet("Reproceso") = SacosAjuste
                        Case "AJUSTE"
                            DEmpaque.RecordSet("SacosAjuste") = Eval(TSacosAjuste.Text)
                            DEmpaque.RecordSet("PesoAjuste") = Eval(TSacosAjuste.Text) * Eval(TPesoSaco.Text)
                    End Select

                    DEmpaque.RecordSet("Destino2") = CLeft(CBDestino.Text, 2)
                    DEmpaque.RecordSet("detalle") = CLeft(TDetalle.Text, 10)
                    DEmpaque.RecordSet("NumFinPlanilla") = DOPs.RecordSet("NumFinPlanilla")
                    DEmpaque.RecordSet("RegAjustado") = 1

                    DEmpaque.Update(Me)

                End If

            ElseIf RBManual.Checked Then

                If InStr(1, CBDestino.Text, "ZR") And InStr(1, CBTipo.Text, "NC KILOS") = False Then
                    MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR, " Debe elegir NC Kilos para enviar empaque a zona reproceso"), vbInformation), vbInformation)
                    Return
                End If


                DEmpaque.Open("Select * from Empaque Where OP = '0'")

                DEmpaque.AddNew()
                DEmpaque.RecordSet("OP") = CLeft(TOPs.Text, 15)
                DEmpaque.RecordSet("CODPROD") = CLeft(TCodInt.Text, 15)
                DEmpaque.RecordSet("NOMPROD") = CLeft(TNombre.Text, 30)
                DEmpaque.RecordSet("MAQUINA") = Eval(TMaquina.Text)
                DEmpaque.RecordSet("CONTBASC") = 0
                DEmpaque.RecordSet("TIPO") = CLeft(CBTipo.Text, 30)
                DEmpaque.RecordSet("FECHAINI") = FechaC()
                DEmpaque.RecordSet("FECHAFIN") = FechaC()
                DEmpaque.RecordSet("CODEMP") = CLeft(TCodEmp.Text, 15)
                DEmpaque.RecordSet("CODETIQ") = CLeft(TCodEtiq.Text, 15)
                DEmpaque.RecordSet("DESTINO") = CLeft(CBDestino.Text, 2)
                DEmpaque.RecordSet("PRESEMP") = CLeft(CBPresent.Text, 2)
                DEmpaque.RecordSet("USUARIO") = CLeft(UsuarioPrincipal, 20)
                DEmpaque.RecordSet("DETALLE") = CLeft(TDetalle.Text, 10)
                DEmpaque.RecordSet("PRESKG") = Eval(TPesoSaco.Text)
                DEmpaque.RecordSet("FINALIZADO") = "S"
                DEmpaque.RecordSet("NumFinPlanilla") = DOPs.RecordSet("NumFinPlanilla")
                DEmpaque.RecordSet("SACOS") = Eval(TSacos.Text)
                DEmpaque.RecordSet("PESO") = Eval(TPeso.Text)

                If (CBDestino.Text = "ZR") And InStr(1, CBTipo.Text, "NC KILOS") Then
                    DEmpaque.RecordSet("PESOREPROCESO") = Eval(TPeso.Text)
                    DEmpaque.RecordSet("PESO") = 0
                    DEmpaque.RecordSet("SACOS") = 0
                End If


                DVarios.Open("Select * from ARTICULOS where TIPO='PT' and CODINT='" + TCodInt.Text + "'")

                If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("LINEA")) Then
                    DEmpaque.RecordSet("LINEAINVENT") = DVarios.RecordSet("LINEA")
                    DEmpaque.RecordSet("GRPBASE") = DVarios.RecordSet("GRPBASE")
                End If

                If CBPresent.Text <> "NC" Then
                    DVarios.Open("Select * from PRODEQUIVALENTES where PRESENT='" + CBPresent.Text +
                             "' and CODPROD='" + TCodInt.Text + "'")
                    If DVarios.Count > 0 Then
                        DEmpaque.RecordSet("CODPROD2") = DVarios.RecordSet("CODPRODEQUI")
                    End If
                End If

                If CBDestino.Text = "GR" Then
                    DVarios.Open("Select * from PRODEQUIVALENTES where PRESENT='" + CBDestino.Text +
                             "' and CODPROD='" + TCodInt.Text + "'")
                    If DVarios.Count > 0 Then
                        DEmpaque.RecordSet("CODPROD2") = DVarios.RecordSet("CODPRODEQUI")
                    End If
                    'Manejo de inventario de tolvas
                    DescTolvas(Eval(CBOrigen.Text), -Eval(TPeso.Text), TCodInt.Text, ProcesoPlanta.EMPAQUE, TOPs.Text)
                End If
                If GBPaqueteo.Visible Then
                    DEmpaque.RecordSet("CODEMPBOLSA") = TCodEmpBolsa.Text
                    DEmpaque.RecordSet("CODEMP") = TCodEmpPaca.Text
                    DEmpaque.RecordSet("CODSTICKER") = TCodEtiqPaca.Text
                    DEmpaque.RecordSet("CODETIQ") = TCodEtiqPaca.Text
                    DEmpaque.RecordSet("BOLSASINTERNAS") = Eval(TNroBolsas.Text)
                End If

                DEmpaque.Update()

                DOPs.RecordSet("ObservOP") = CLeft(TObservOP.Text, 100)
                DOPs.Update(Me)



                If Funcion_FinalizarPlanillaSales Then
                    'Se evalua si con el nuevo empaque se puede finalizar automaticamente la OP de sales por planilla
                    If LineaInvent.Contains("SALES") And PesoEmp + Eval(TPeso.Text) >= PesoDosif And CBTipo.Text.Contains("MANUAL") Then
                        DOPs.RecordSet("FINPLANILLA") = "S"
                        DOPs.RecordSet("FECHAFINPLANILLA") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                        DVarios.Open("Update BACHES set FECHAFINPLANILLA='" + DOPs.RecordSet("FECHAFINPLANILLA") + "' where OP='" + TOPs.Text + "'")
                        DVarios.Open("Update EMPAQUE set FECHAFINPLANILLA='" + DOPs.RecordSet("FECHAFINPLANILLA") + "' where OP='" + TOPs.Text + "'")
                    End If
                End If
            End If

            BCancelar_Click(Nothing, Nothing)
            FRefrescaDG_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            DGEmpaque.Rows.Clear()
            CBTipo.Text = ""
            CBPresent.Text = ""
            CBDestino.Text = ""
            CBOrigen.Text = ""
            TMaquina.Text = 10
            BAceptar.Enabled = False
            editnuevo = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click, BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub DGEmpaque_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpaque.CellClick
        Try
            If DGEmpaque.RowCount = 0 Then Exit Sub

            Fila = DGEmpaque.CurrentRow.Index

            If Not DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("TIPO").Value.ToString.ToUpper.Contains("AUTOM") Then Return

            TPeso.Text = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("PESOTOT").Value.ToString
            TSacos.Text = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("SACOSTOT").Value.ToString
            TPesoSaco.Text = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("PRESKG").Value.ToString
            TDetalle.Text = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("DETALLE").Value.ToString
            TMaquina.Text = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("MAQUINA").Value.ToString


            If Not CBTipo.Text.Contains("NC") Then
                DVarios.Open("select * from EMPAQUE where OP='" + TOPs.Text + "' and MAQUINA=" + TMaquina.Text)
                If DVarios.Count > 0 Then
                    CBDestino.Text = DVarios.RecordSet("DESTINO").ToString
                    CBPresent.Text = DVarios.RecordSet("PRESEMP").ToString
                End If
            End If

            BAceptar.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcercaD.ShowDialog()
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        BCancelar_Click(Nothing, Nothing)
        PDatos.Enabled = True
        BAceptar.Enabled = True
        editnuevo = True
        BHabilComboBox_Click(Nothing, Nothing)
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            If RBAjuste.Checked AndAlso Not TDetalle.Text.ToUpper.Contains("AUTOM") Then
                BAceptar.Enabled = False
                Return
            End If
            BAceptar.Enabled = True
            editnuevo = True
            BHabilComboBox_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OpManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBManual.CheckedChanged
        Try
            If RBManual.Checked = True Then
                DGEmpaque.Enabled = False
                CBTipo.Items.Clear()
                CBTipo.Items.Add("EMP.MANUAL")
                CBTipo.Items.Add("GRANEL")
                CBTipo.Items.Add("COLA")
                CBTipo.Items.Add("NC KILOS")
                CBTipo.Items.Add("")
                Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
                TMaquina.Text = "10"
                TSacosAjuste.Enabled = False
                AsignaDataGrid(DGEmpaque, Nothing)
                BAceptar.Enabled = True
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OpAjuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAjuste.CheckedChanged
        If RBAjuste.Checked = True Then
            DGEmpaque.Enabled = True
            CBTipo.Items.Clear()
            CBTipo.Items.Add("NC SACOS")
            CBTipo.Items.Add("AJUSTE")
            CBTipo.Items.Add("REEMPAQUE")
            CBTipo.Items.Add("")
            TSacosAjuste.Enabled = True
            BAceptar.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            AsignaDataGrid(DGEmpaque, Nothing)
        End If
    End Sub

    Private Sub CBTipo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTipo.TextChanged
        Try
            If Eval(TOPs.Text) = 0 Then Return

            If CBTipo.Text = "" Or CBTipo.Text = "NO VALIDO" Then Return

            If TCodInt.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " OP"), vbInformation)
                CBTipo.Items.Clear()
                RBAjuste.Checked = False
                RBManual.Checked = False
                Return
            End If

            LLenaDestino()

            TDetalle.Text = ""
            CBPresent.Text = ""
            TNumNc.Visible = False
            CBDestino.Enabled = True

            If InStr(1, CBTipo.Text, "MANUAL") Then
                CBPresent.Enabled = True
                TSacos.Enabled = True
                TPeso.Enabled = False
                TSacosAjuste.Enabled = False
                TPesoSaco.Text = DArt.RecordSet("PRESKG")
                TDetalle.Enabled = False
                TDetalle.Text = "MANUAL"
                CBDestino.Text = ""
                CBDestino.Items.Remove("ZR")
                CBOrigen.Enabled = True
                AsignaDataGrid(DGEmpaque, Nothing)
            End If

            If InStr(1, CBTipo.Text, "PAQUET") Then
                CBPresent.Enabled = True
                TSacos.Enabled = True
                TPeso.Enabled = False
                TSacosAjuste.Enabled = False
                TPesoSaco.Text = DArt.RecordSet("PRESKGPACA")
                TDetalle.Enabled = False
                TDetalle.Text = "PAQUET"
                CBDestino.Items.Remove("ZR")
                GBPaqueteo.Visible = True
                AsignaDataGrid(DGEmpaque, Nothing)
            End If


            If InStr(1, CBTipo.Text, "GRANEL") Then
                TSacos.Enabled = False
                TSacos.Text = ""
                TPeso.Enabled = True
                CBPresent.Enabled = True
                TDetalle.Enabled = False
                TSacosAjuste.Enabled = False
                CBDestino.Items.Clear()
                CBDestino.Items.Add("TV")
                CBDestino.Items.Add("GR")
                TDetalle.Text = "GRANEL"
                AsignaDataGrid(DGEmpaque, Nothing)
            ElseIf InStr(1, CBTipo.Text, "NC SACOS") Then
                TPeso.Enabled = False
                CBPresent.Text = "NC"
                TPesoSaco.Text = DArt.RecordSet("PRESKG")
                TSacos.Enabled = False
                TDetalle.Enabled = True
                TDetalle.Focus()
                TNumNc.Visible = True
                TSacosAjuste.Enabled = True
                CBDestino.Items.Add("ZR")
                CBDestino.SelectedItem = "ZR"
                CBDestino.Enabled = False
                ''FRefrescaDG_Click(Nothing, Nothing)
            ElseIf InStr(1, CBTipo.Text, "NC KILOS") Then
                TPeso.Enabled = True
                CBPresent.Enabled = False
                CBPresent.Text = "NC"
                TSacos.Enabled = False
                TSacosAjuste.Enabled = False
                TDetalle.Enabled = True
                TDetalle.Focus()
                TNumNc.Visible = True
                AsignaDataGrid(DGEmpaque, Nothing)
                CBDestino.Items.Add("ZR")
                CBDestino.SelectedItem = "ZR"
                CBDestino.Enabled = False
            End If

            If InStr(1, CBTipo.Text, "REEMPAQUE") Then
                CBPresent.Enabled = False
                CBPresent.Text = "NC"
                TPesoSaco.Text = DArt.RecordSet("PRESKG")
                TSacos.Enabled = True
                TPeso.Enabled = False
                TDetalle.Enabled = True
                TDetalle.Focus()
                TNumNc.Visible = True
                TSacosAjuste.Enabled = True
                TSacos.Enabled = False
                CBDestino.Items.Remove("ZR")
                ''FRefrescaDG_Click(Nothing, Nothing)
            End If

            If InStr(1, CBTipo.Text, "AJUSTE") Then
                CBPresent.Enabled = False
                CBPresent.Text = "NC"
                TPesoSaco.Text = DArt.RecordSet("PRESKG")
                TSacos.Enabled = True
                TPeso.Enabled = False
                TDetalle.Enabled = True
                TDetalle.Focus()
                TNumNc.Visible = True
                TSacosAjuste.Enabled = True
                TSacos.Enabled = False
                CBDestino.Items.Remove("ZR")
                ''FRefrescaDG_Click(Nothing, Nothing)
            End If

            If InStr(1, CBTipo.Text, "COLA") Then
                TSacos.Enabled = False
                TPeso.Enabled = True
                CBPresent.Enabled = True
                TDetalle.Enabled = False
                TSacosAjuste.Enabled = False
                CBDestino.Items.Remove("ZR")
                TDetalle.Text = "COLA"
                AsignaDataGrid(DGEmpaque, Nothing)
            End If

            SendKeys.Send("{TAB}")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub CBTipo_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTipo.SelectionChangeCommitted
        CBPresent.Focus()
    End Sub

    Private Sub TDetalle_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TDetalle.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return

            If TSacosAjuste.Enabled Then
                TSacosAjuste.Focus()
            ElseIf TPeso.Enabled Then
                TPeso.Focus()
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CBTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBTipo.SelectedIndexChanged
        If CBTipo.Text = "GRANEL" Then
            CBOrigen.Enabled = True
        Else
            CBOrigen.Enabled = False
        End If
    End Sub

    Private Sub CBDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBDestino.SelectedIndexChanged
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub BActualizar_Click(sender As System.Object, e As System.EventArgs) Handles BActualizar.Click
        EmpaqueMan_Load(Nothing, Nothing)
    End Sub


    Private Sub BHabilComboBox_Click(sender As System.Object, e As System.EventArgs) Handles BHabilComboBox.Click
        Try
            If editnuevo = True Then
                CBTipo.Enabled = True
                CBDestino.Enabled = True
                CBOrigen.Enabled = True
                CBPresent.Enabled = True
            Else
                CBTipo.Enabled = False
                CBDestino.Enabled = False
                CBOrigen.Enabled = False
                CBPresent.Enabled = False
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDG_Click(sender As Object, e As EventArgs) Handles FRefrescaDG.Click
        Try
            DEmpaque.Open("Select " + SentenciaPeso + "," + SentenciaSacos + ",* from EMPAQUE where " +
                        "MAQUINA<100 and ESTADO=0 and RECEMP=0 AND OP='" + TOPs.Text + "' order by FECHAINI")
            AsignaDataGrid(DGEmpaque, DEmpaque.DataTable)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub LLenaDestino()
        'LLenamos el destino
        CBDestino.Items.Clear()
        DUbicaciones.Open("Select * from UBICACIONES where TIPO='PT' and HABILITADA=1")
        LLenaComboBox(CBDestino, DUbicaciones.DataTable, "CODUBI")
        'aDICIONAMOS UN ESPACIO para cuando se cancele la operacion
        CBDestino.Items.Add("")
    End Sub

    Private Sub CBPresent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPresent.SelectedIndexChanged
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub TSacosAjuste_KeyUp(sender As Object, e As KeyEventArgs) Handles TSacosAjuste.KeyUp
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub TPeso_KeyUp(sender As Object, e As KeyEventArgs) Handles TPeso.KeyUp
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub CBOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOrigen.SelectedIndexChanged
        SendKeys.Send("{TAB}")
    End Sub

    Private Sub BAceptar_KeyUp(sender As Object, e As KeyEventArgs) Handles BAceptar.KeyUp
        If e.KeyCode = Keys.Enter Then BAceptar_Click(Nothing, Nothing)
    End Sub
End Class