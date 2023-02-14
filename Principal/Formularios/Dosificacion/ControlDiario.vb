Option Explicit On
Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary

Public Class ControlDiario

    Private DuracionTot As Double
    Private DuracionTotHoras As Double
    'Private Productividad As Double
    'Private ProductividadReal As Double
    'Private RetornoFinosTon As Double
    'Private RetornoFinosPorc As Double
    Private DOps As AdoSQL
    Private DVarios As AdoSQL
    Private DTolvas As AdoSQL
    Private DPresent As AdoSQL
    Private DControlDiario As AdoSQL
    Private DControlDiario2 As AdoSQL
    Private DHumedades As AdoSQL
    Private DHumedades2 As AdoSQL
    Private DTamizados As AdoSQL
    Private DTamizados2 As AdoSQL
    Private DMotivos As AdoSQL
    Private ParteDec As String
    Private DArticulos As AdoSQL

    Private Index As Integer

    Private TFechaIni As ArrayControles(Of DateTimePicker)
    Private TFechaFin As ArrayControles(Of DateTimePicker)
    Private BBuscar As ArrayControles(Of Button)


    Private Sub Peletizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            Cursor = System.Windows.Forms.Cursors.WaitCursor
            THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd HH:00"))
            THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd HH:00"))

            DOps = New AdoSQL("OPs")
            DVarios = New AdoSQL("OPs")
            DTolvas = New AdoSQL("Tolvas")
            DPresent = New AdoSQL("Presentacion")
            DControlDiario = New AdoSQL("CONTROLDIARIOPELETIZADO")
            DControlDiario2 = New AdoSQL("CONTROLDIARIOPELETIZADO")
            DHumedades = New AdoSQL("HUMEDADES")
            DHumedades2 = New AdoSQL("HUMEDADES")
            DTamizados = New AdoSQL("TAMIZADOS")
            DTamizados2 = New AdoSQL("TAMIZADOS")
            DArticulos = New AdoSQL("ARTICULOS")

            DOps.Open("Select * from OPs where FINPLANILLA <>'S' and REAL>0")
            DTolvas.Open("Select * from TOLVAS where PROCESO='PELETIZADO' order by TOLVA")
            LLenaComboBox(COrigen, DTolvas.DataTable, "TOLVA")
            DPresent.Open("Select * from PRESENTACIONES")

            TPesoMalla6.Enabled = True
            TPorcMalla6.Enabled = True
            TParmPorcM6.Enabled = True
            TParmPorcM12.Enabled = True
            TParmPorcM30.Enabled = True
            TPorcMalla30.Enabled = True
            TPesoMalla30.Enabled = True


            TGrasa.Enabled = True


            'COrigen.Items(COrigen.Items.Count - 1).Add("Todos")
            COrigen.Items.Add("TODOS")


            DTolvas.Open("Select * from TOLVAS where PROCESO='EMPAQUE' order by TOLVA")
            LLenaComboBox(CDestino, DTolvas.DataTable, "TOLVA")
            LLenaComboBox(CPresent, DPresent.DataTable, "PRESENTACION")
            LLenaComboBox(CPresentT, DPresent.DataTable, "PRESENTACION")

            'SStab.SelectedTab = TabControlDiario
            'SStab_SelectedIndexChanged(SStab, Nothing)

            DArticulos.Open("select * from ARTICULOS where TIPO='PT'")

            TFechaIni = New ArrayControles(Of DateTimePicker)("TFechaIni", Me)
            TFechaFin = New ArrayControles(Of DateTimePicker)("TFechaFin", Me)
            BBuscar = New ArrayControles(Of Button)("BBuscar", Me)

            For Each DT As DateTimePicker In TFechaIni.Values
                DT.Value = CDate(Format(Now, "yyyy/MM/dd HH:mm"))
            Next
            For Each DT As DateTimePicker In TFechaFin.Values
                DT.Value = CDate(Format(Now, "yyyy/MM/dd HH:mm"))
            Next

            For Each Boton As Button In BBuscar.Values
                AddHandler Boton.Click, AddressOf BBuscar_Click
            Next

            TFechaHoraIni.Value = CDate(Format(Now, "yyyy/MM/dd HH:mm"))
            TFechaHoraFin.Value = CDate(Format(Now, "yyyy/MM/dd HH:mm"))
            TFechaFiltro.Value = CDate(Format(Now, "yyyy/MM/dd HH:mm"))

            BBuscar_Click(BBuscar(1), Nothing)

            'ToolTip1.Show("Máquinas P1 a P5 Peletizadoras, Máquinas E1 a E3 Extruder", CMaquina)
            'ToolTip1.Show("Máquinas P1 a P5 Peletizadoras, Máquinas E1 a E3 Extruder", CMaquinaH)
            'ToolTip1.Show("Máquinas P1 a P5 Peletizadoras, Máquinas E1 a E3 Extruder", CMaquinaT)
            Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub




    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            Dim FechaIniPelAux As String
            Dim FechaFinPelAux As String
            Dim Duracion As String = ""
            Dim DuracionHoraPaga As Single = 0

            If TOps.Text = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "OP"), vbInformation), vbInformation)
                Return
            End If

            If CMaquina.Text = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Peletizadora"), vbInformation), vbInformation)
                Return
            End If

            If Eval(CTurno.Text) = 0 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Turno"), vbInformation), vbInformation)
                Return
            End If

            'If CDate(THoraFin.Text) < CDate(THoraIni.Text) Then
            '    MsgBox("La hora inicial no puede ser superior o igual a la hora final", MsgBoxStyle.Exclamation, "Error en Fechas")
            '    Return
            'End If

            'If Eval(THorometroFin.Text) < Eval(THorometroIni.Text) Then
            '    MsgBox("Datos erroneos para los campos de horometro, favor revisar", MsgBoxStyle.Exclamation)
            '    Return
            'End If

            BAceptar.Enabled = False

            DOps.Open("Select * from OPS where OP='" + TOps.Text + "'")

            DControlDiario.Open("Select * from CONTROLDIARIO where ID=" + Eval(TId.Text).ToString)

            If DControlDiario.Count = 0 Then

                DHumedades.Open("Select * from HUMEDADES where ID=" + Eval(TIdH.Text).ToString)
                DHumedades.AddNew()
                DHumedades.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
                DHumedades.RecordSet("USUARIO") = UsuarioPrincipal
                DHumedades.RecordSet("NOMPROD") = CLeft(TNomProd.Text, 30)
                DHumedades.RecordSet("OP") = TOps.Text
                DHumedades.RecordSet("MAQUINA") = CMaquina.Text
                DHumedades.RecordSet("CODFOR") = DOps.RecordSet("CODFOR")
                DHumedades.RecordSet("TEMPERATURA") = Eval(TTempAcond.Text)
                DHumedades.RecordSet("PRESION") = Eval(TPresionPeletEnt.Text)
                DHumedades.RecordSet("CARGA") = Eval(TCarga.Text)

                'Buscamos la formula para sacar la humedad fórmulada
                DVarios.Open("Select * from FORMULAS where CODFOR='" + DOps.RecordSet("CODFOR") + "' and LP='" + DOps.RecordSet("LP") + "'")

                If DVarios.Count > 0 Then
                    DHumedades.RecordSet("PORCFORMULADA") = DVarios.RecordSet("HUMEDADFOR") / 100
                End If

                DHumedades.RecordSet("LP") = DOps.RecordSet("LP")
                DHumedades.Update(Me)

                DTamizados.Open("Select * from TAMIZADOS where ID=" + Eval(TIdT.Text).ToString)
                DTamizados.AddNew()
                DTamizados.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
                DTamizados.RecordSet("USUARIO") = UsuarioPrincipal
                DTamizados.RecordSet("NOMPROD") = CLeft(TNomProd.Text, 30)
                DTamizados.RecordSet("OP") = TOps.Text
                DTamizados.RecordSet("PRESENT") = CPresent.Text
                DTamizados.RecordSet("MAQUINA") = CMaquina.Text
                DTamizados.Update(Me)

                DControlDiario.AddNew()

            Else
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                ' Resp = MsgBox("Modificará el registro actual, ¿desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                If Resp = vbNo Then Return
            End If

            If Eval(DControlDiario.RecordSet("FECHA").ToString) = 0 Then DControlDiario.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DControlDiario.RecordSet("TURNO") = Eval(CTurno.Text)
            DControlDiario.RecordSet("USUARIO") = UsuarioPrincipal
            DControlDiario.RecordSet("NOMPROD") = CLeft(TNomProd.Text, 30)
            DControlDiario.RecordSet("OP") = TOps.Text
            DControlDiario.RecordSet("PRESENT") = CPresent.Text
            DControlDiario.RecordSet("MAQUINA") = CMaquina.Text
            DControlDiario.RecordSet("ORIGEN") = COrigen.Text

            DControlDiario.RecordSet("DESTINO") = CDestino.Text

            Dim CodProd As String = ""

            'Se actualiza el producto con la tolva de destino 
            If Val(CDestino.Text) > 0 Then
                DOps.Open("Select * from OPs where OP='" + TOps.Text + "'")
                If DOps.Count Then
                    CodProd = DOps.RecordSet("CODPROD")
                End If
                DVarios.Open("Select * from TOLVAS where PROCESO='EMPAQUE' and TOLVA=" + CDestino.Text)

                If DVarios.Count Then
                    DVarios.Open("Update TOLVAS SET CODINT='" + CodProd + "',NOMBRE='" + TNomProd.Text + "' WHERE TOLVA=" + CDestino.Text + " AND PROCESO='EMPAQUE'")
                    Evento("Actualiza de control proceso, Update TOLVAS SET CODINT='" + CodProd + "',NOMBRE='" + TNomProd.Text + "' WHERE TOLVA=" + CDestino.Text + " AND PROCESO='EMPAQUE'")
                End If
            End If



            DControlDiario.RecordSet("HORAINI") = THoraIni.Text
            DControlDiario.RecordSet("HORAFIN") = THoraFin.Text

            FechaIniPelAux = Format(TFechaHoraIni.Value, "yyyy/MM/dd ") + Format(THoraIni.Value, "HH:mm")
            FechaFinPelAux = Format(TFechaHoraFin.Value, "yyyy/MM/dd ") + Format(THoraFin.Value, "HH:mm")

            DControlDiario.RecordSet("FECHAINI") = FechaIniPelAux

            THoraIni.Value = CDate(FechaIniPelAux)
            THoraFin.Value = CDate(FechaFinPelAux)

            DuracionHoraPaga = Math.Round(DateDiff(DateInterval.Minute, CDate(FechaIniPelAux), CDate(FechaFinPelAux)) / 60, 2)
            DControlDiario.RecordSet("DURACION") = DuracionHoraPaga
            DuracionTotHoras = Eval(THorometroFin.Text) - Eval(THorometroIni.Text)
            DControlDiario.RecordSet("HOROMETROINI") = Eval(THorometroIni.Text)
            DControlDiario.RecordSet("HOROMETROFIN") = Eval(THorometroFin.Text)
            DControlDiario.RecordSet("DURACIONHORAS") = DuracionTotHoras
            DControlDiario.RecordSet("ENERGIAINI") = Eval(TEnergiaIni.Text)
            DControlDiario.RecordSet("ENERGIAFIN") = Eval(TEnergiaFin.Text)
            DControlDiario.RecordSet("CONSUMOENER") = Eval(TEnergiaFin.Text) - Eval(TEnergiaIni.Text)
            DControlDiario.RecordSet("TIEMPOMTO") = Eval(TTiempoImp.Text)
            'DControlDiario.RecordSet("CAUSA") = TCausa.Text
            DControlDiario.RecordSet("OBSERVACIONES") = CLeft(TObservaciones.Text, 50)
            DControlDiario.RecordSet("PRODUCTIVIDAD") = 0
            If DuracionTotHoras > 0 Then DControlDiario.RecordSet("PRODUCTIVIDAD") = Eval(TTonPeletizadas.Text) / DuracionTotHoras
            DControlDiario.RecordSet("TONMETA") = Eval(TTonPeletizar.Text)
            DControlDiario.RecordSet("TONREAL") = Eval(TTonPeletizadas.Text)
            DControlDiario.RecordSet("TEMPACOND") = Eval(TTempAcond.Text)
            DControlDiario.RecordSet("PRESIONENT") = Eval(TPresionPeletEnt.Text)
            DControlDiario.RecordSet("CARGA") = Eval(TCarga.Text)
            DControlDiario.RecordSet("CORTE") = Eval(TCorte.Text)
            DControlDiario.RecordSet("TIEMPOMUESTRA") = Eval(TTiempoMuest.Text)
            DControlDiario.RecordSet("PESOMUESTRA") = Eval(TPesoMuest.Text)
            DControlDiario.RecordSet("RETORNOFINOSTON") = 0

            If Eval(TTiempoMuest.Text) > 0 Then DControlDiario.RecordSet("RETORNOFINOSTON") = Math.Round((Eval(TPesoMuest.Text) / Eval(TTiempoMuest.Text)) * 3.6, 3)


            DControlDiario.RecordSet("PRODUCTIVIDADREAL") = Math.Round(Eval(TTonPeletizadas.Text) / (DuracionHoraPaga + 0.0000001), 3) ' Math.Round(DControlDiario.RecordSet("PRODUCTIVIDAD") + DControlDiario.RecordSet("RETORNOFINOSTON"), 3)

            If Not IsDBNull(DControlDiario.RecordSet("PRODUCTIVIDADREAL")) Then
                DControlDiario.RecordSet("RETORNOFINOSPORC") = DControlDiario.RecordSet("RETORNOFINOSTON") / (DControlDiario.RecordSet("PRODUCTIVIDADREAL") + 0.0001)
            End If


            DControlDiario.Update(Me)

            SStab_SelectedIndexChanged(SStab, Nothing)
            BAceptar.Enabled = True


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOPH.TextChanged
        Try

            If TOPH.Text = "" Then Return

            DVarios.Open("Select * from OPs where OP='" + TOPH.Text + "'")
            If DVarios.Count = 0 Then Return

            TNomProdH.Text = DVarios.RecordSet("NOMPROD")
            TLp.Text = DVarios.RecordSet("LP")
            TCodFor.Text = DVarios.RecordSet("CODFOR")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarH.Click
        Try

            If CMaquinaH.Text = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Peletizadora no válida"), vbInformation), vbInformation)
                Return
            End If

            BAceptarH.Enabled = False

            DHumedades.Open("Select * from HUMEDADES where ID=" + Eval(TIdH.Text).ToString)

            If DHumedades.Count = 0 Then
                DHumedades.AddNew()
            Else
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Return
            End If

            DHumedades.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DHumedades.RecordSet("USUARIO") = UsuarioPrincipal
            DHumedades.RecordSet("NOMPROD") = CLeft(TNomProdH.Text, 30)
            DHumedades.RecordSet("OP") = TOPH.Text
            DHumedades.RecordSet("OBSERVACIONES") = CLeft(TObservacionesH.Text, 30)
            DHumedades.RecordSet("MAQUINA") = CMaquinaH.Text
            DHumedades.RecordSet("CARGA") = Eval(TCargaH.Text)
            DHumedades.RecordSet("TEMPERATURA") = Eval(TTemperaturaH.Text)
            DHumedades.RecordSet("PRESION") = Eval(TPresionH.Text)
            DHumedades.RecordSet("PORCHARINA") = Eval(TPorcHarina.Text)
            DHumedades.RecordSet("PORCACOND") = Eval(TPorcAcond.Text)
            DHumedades.RecordSet("PORCGANANCIA") = Eval(TPorcAcond.Text) - Eval(TPorcHarina.Text)
            DHumedades.RecordSet("PORCEMPAQUE") = Eval(TPorcEmp.Text)
            DHumedades.RecordSet("PORCFORMULADA") = Eval(TPorcForm.Text)
            DHumedades.RecordSet("PORCDIFFORMULADA") = Eval(TPorcEmp.Text) - Eval(TPorcForm.Text)
            DHumedades.RecordSet("PORCDIFHARINA") = Eval(TPorcEmp.Text) - Eval(TPorcHarina.Text)
            DHumedades.RecordSet("TEMPSALENFRIADOR") = Eval(TTempSalEnf.Text)
            DHumedades.RecordSet("TEMPEMPAQUE") = Eval(TTempEmp.Text)

            DHumedades.Update(Me)

            SStab_SelectedIndexChanged(SStab, Nothing)
            BAceptarH.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPsT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOPsT.TextChanged
        Try

            If TOPsT.Text = "" Then Return

            DVarios.Open("Select * from OPs where OP='" + TOPsT.Text + "'")
            If DVarios.Count = 0 Then Return

            TNomProdT.Text = DVarios.RecordSet("NOMPROD")

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub CPresentT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPresentT.SelectedIndexChanged
        Try
            GBMalla8.Enabled = False
            GBMalla12.Enabled = True
            GBMalla16.Enabled = True
            GBTamizado.Enabled = True
            GBMalla30.Enabled = False
            TPorcMalla12.Enabled = False

            If CPresentT.Text = "HARINA" Then
                GBMalla16.Enabled = False
                TPesoMalla16.Text = ""
                GBTamizado.Enabled = False
                TPorcMalla12.Enabled = True

                GBMalla30.Enabled = True
                TPesoMalla30.Text = ""

            Else
                GBMalla8.Enabled = True
                TPesoMalla8.Text = ""
                GBMalla16.Enabled = True
                TPesoMalla16.Text = ""
                GBTamizado.Enabled = True
                GBMalla12.Enabled = False
                TPesoMalla12.Text = ""
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarT.Click
        Try
            If CMaquinaT.Text = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Peletizadora no válida"), vbInformation), vbInformation)
                Return
            End If

            BAceptarT.Enabled = False

            DTamizados.Open("Select * from TAMIZADOS where ID=" + Eval(TIdT.Text).ToString)

            'ValidaFuncionMalla6 = ValidaFuncionalidad("Malla.6")
            If DTamizados.Count = 0 Then
                DTamizados.AddNew()
            Else
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Return
            End If

            DTamizados.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DTamizados.RecordSet("USUARIO") = UsuarioPrincipal
            DTamizados.RecordSet("NOMPROD") = CLeft(TNomProdT.Text, 30)
            DTamizados.RecordSet("OP") = TOPsT.Text
            DTamizados.RecordSet("PRESENT") = CPresentT.Text
            DTamizados.RecordSet("MAQUINA") = CMaquinaT.Text
            DTamizados.RecordSet("TEMPERATURA") = Eval(TTemperaturaT.Text)
            DTamizados.RecordSet("TOTALMUESTRA") = Eval(TPesoMalla6.Text) + Eval(TPesoMalla8.Text) + Eval(TPesoMalla12.Text) + Eval(TPesoMalla16.Text) + Eval(TPesoMalla30.Text) + Eval(TPesoPlato.Text)
            DTamizados.RecordSet("PESOMALLA6") = Eval(TPesoMalla6.Text)
            DTamizados.RecordSet("PESOMALLA8") = Eval(TPesoMalla8.Text)
            DTamizados.RecordSet("PESOMALLA12") = Eval(TPesoMalla12.Text)
            DTamizados.RecordSet("PESOMALLA16") = Eval(TPesoMalla16.Text)
            DTamizados.RecordSet("PESOMALLA30") = Eval(TPesoMalla30.Text)
            DTamizados.RecordSet("PESOPLATO") = Eval(TPesoPlato.Text)

            DTamizados.RecordSet("PORCMALLA6") = 0
            DTamizados.RecordSet("PORCMALLA8") = 0
            DTamizados.RecordSet("PORCMALLA12") = 0
            DTamizados.RecordSet("PORCMALLA16") = 0
            DTamizados.RecordSet("PORCMALLA30") = 0
            DTamizados.RecordSet("PORCPLATO") = 0

            If DTamizados.RecordSet("TOTALMUESTRA") > 0 Then
                DTamizados.RecordSet("PORCMALLA6") = (DTamizados.RecordSet("PESOMALLA6") / DTamizados.RecordSet("TOTALMUESTRA")) * 100
                DTamizados.RecordSet("PORCMALLA8") = (DTamizados.RecordSet("PESOMALLA8") / DTamizados.RecordSet("TOTALMUESTRA")) * 100
                DTamizados.RecordSet("PORCMALLA12") = (DTamizados.RecordSet("PESOMALLA12") / DTamizados.RecordSet("TOTALMUESTRA")) * 100
                DTamizados.RecordSet("PORCMALLA16") = (DTamizados.RecordSet("PESOMALLA16") / DTamizados.RecordSet("TOTALMUESTRA")) * 100
                DTamizados.RecordSet("PORCMALLA30") = (DTamizados.RecordSet("PESOMALLA30") / DTamizados.RecordSet("TOTALMUESTRA")) * 100
                DTamizados.RecordSet("PORCPLATO") = (DTamizados.RecordSet("PESOPLATO") / DTamizados.RecordSet("TOTALMUESTRA")) * 100
            End If

            DTamizados.RecordSet("PORCDURABILIDAD") = Eval(TPorcDurabilidad.Text)
            DTamizados.RecordSet("DUREZA") = Eval(TDureza.Text)
            DTamizados.RecordSet("SITIOMUESTRA") = CSitioMuestra.Text
            DTamizados.Update(Me)

            SStab_SelectedIndexChanged(SStab, Nothing)
            BAceptarT.Enabled = True
            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SStab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SStab.Click

    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            Dim AuxOP As String = ""
            Dim AuxNomProd As String = ""
            Dim AuxCodFor As String = ""
            Dim AuxOrden As String = ""
            Dim AuxPresent As String = ""

            DOps.Refresh()

            Limpiar_Habilitar_TextBox(SStab.Controls, AccionTextBox.Habilitar)

            If SStab.SelectedTab.Text.ToUpper = "HUMEDADES" Then
                AuxOP = TOPH.Text
                AuxNomProd = TNomProdH.Text
                AuxCodFor = TCodFor.Text
                AuxOrden = TLp.Text
            ElseIf SStab.SelectedTab.Text.ToUpper = "TAMIZADOS" Then
                AuxOP = TOPsT.Text
                AuxNomProd = TNomProdT.Text
                AuxPresent = CPresentT.Text
            End If


            Limpiar_Habilitar_TextBox(SStab.Controls, AccionTextBox.Limpiar)

            CTurno.Text = ""
            CPresent.Text = ""
            CPresentT.Text = ""
            COrigen.Text = ""
            CDestino.Text = ""
            CMaquina.Text = ""
            CMaquinaH.Text = ""
            CMaquinaT.Text = ""

            CTurno.Enabled = True
            CPresent.Enabled = True
            CPresentT.Enabled = True
            COrigen.Enabled = True
            CDestino.Enabled = True
            CMaquina.Enabled = True
            CMaquinaH.Enabled = True
            CMaquinaT.Enabled = True

            If SStab.SelectedTab.Text.ToUpper = "HUMEDADES" Then
                TOPH.Text = AuxOP
                TNomProdH.Text = AuxNomProd
                TCodFor.Text = AuxCodFor
                TLp.Text = AuxOrden
            ElseIf SStab.SelectedTab.Text.ToUpper = "TAMIZADOS" Then
                TOPsT.Text = AuxOP
                TNomProdT.Text = AuxNomProd
                CPresentT.Text = AuxPresent

                DOps.Find("OP='" + TOPsT.Text + "'")
                If DOps.EOF Then Return
                DArticulos.Find(" CODINT='" + DOps.RecordSet("CodProd").ToString + "'")
                If DArticulos.EOF Then Return

                TParmPorcM6.Text = DArticulos.RecordSet("ParmPorcMalla6")
                TParmPorcM8.Text = DArticulos.RecordSet("ParmPorcMalla8")
                TParmPorcM12.Text = DArticulos.RecordSet("ParmPorcMalla12")
                TParmPorcM30.Text = DArticulos.RecordSet("ParmPorcMalla30")

                TParmPorcM16.Text = DArticulos.RecordSet("ParmPorcMalla16")
                TParmPorcPlato.Text = DArticulos.RecordSet("ParmPorcPlato")
                TParmDurabilidad.Text = DArticulos.RecordSet("ParmDurabilidad")
                TParmDureza.Text = DArticulos.RecordSet("ParmDureza")
            End If

            BAceptar.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGControlDiario_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGControlDiario.CellClick
        Try
            If DGControlDiario.RowCount = 0 Then Return

            DControlDiario2.Open("Select * from CONTROLDIARIO where ID=" + DGControlDiario.Rows(DGControlDiario.CurrentRow.Index).Cells("ID").Value.ToString)

            If DControlDiario2.Count = 0 Then Return

            Limpiar_Habilitar_TextBox(TabControlDiario.Controls, AccionTextBox.Deshabilitar)
            COrigen.Enabled = False
            CDestino.Enabled = False
            CMaquina.Enabled = False
            CPresent.Enabled = False
            CTurno.Enabled = False


            TId.Text = DControlDiario2.RecordSet("ID")
            TOps.Text = DControlDiario2.RecordSet("OP")
            TNomProd.Text = DControlDiario2.RecordSet("NOMPROD")
            CTurno.Text = DControlDiario2.RecordSet("TURNO")
            CMaquina.Text = DControlDiario2.RecordSet("MAQUINA")
            COrigen.Text = DControlDiario2.RecordSet("ORIGEN")
            CDestino.Text = DControlDiario2.RecordSet("DESTINO")
            CPresent.Text = DControlDiario2.RecordSet("PRESENT")
            THoraIni.Text = DControlDiario2.RecordSet("HORAINI")
            THoraFin.Text = DControlDiario2.RecordSet("HORAFIN")
            THorometroIni.Text = DControlDiario2.RecordSet("HOROMETROINI")
            THorometroFin.Text = DControlDiario2.RecordSet("HOROMETROFIN")
            TEnergiaIni.Text = DControlDiario2.RecordSet("ENERGIAINI")
            TEnergiaFin.Text = DControlDiario2.RecordSet("ENERGIAFIN")
            TTiempoImp.Text = DControlDiario2.RecordSet("TIEMPOMTO")
            'TCausa.Text = DControlDiario2.RecordSet("CAUSA")
            TTonPeletizar.Text = DControlDiario2.RecordSet("TONMETA")
            TTonPeletizadas.Text = DControlDiario2.RecordSet("TONREAL")
            TTempAcond.Text = DControlDiario2.RecordSet("TEMPACOND")
            TPresionPeletEnt.Text = DControlDiario2.RecordSet("PRESIONENT")
            TCarga.Text = DControlDiario2.RecordSet("CARGA")
            TCorte.Text = DControlDiario2.RecordSet("CORTE")
            TObservaciones.Text = DControlDiario2.RecordSet("OBSERVACIONES")
            TTiempoMuest.Text = DControlDiario2.RecordSet("TIEMPOMUESTRA")
            TPesoMuest.Text = DControlDiario2.RecordSet("PESOMUESTRA")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub SStab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SStab.SelectedIndexChanged
        Try
            Dim Tabla As String = ""
            Dim DG As New DataGridView
            Dim NomDGCol As Boolean = False
            Dim Consulta As String = ""

            Select Case SStab.SelectedIndex

                Case 0
                    Tabla = "CONTROLDIARIO"
                    DG = DGControlDiario
                    Consulta = "Select * from " + Tabla + " where FECHA>='" + Format(CDate(TFechaIni(SStab.SelectedIndex + 1).Text), "yyyy/MM/dd 00:00") + "' and FECHA<'" + Format(CDate(TFechaFin(SStab.SelectedIndex + 1).Text), "yyyy/MM/dd 23:59") + "'"
                Case 1
                    Tabla = "HUMEDADES"
                    DG = DGHumedades
                    NomDGCol = True
                    Consulta = "select distinct OP,NomProd,Maquina from HUMEDADES where FINALIZADO='N' and FECHA>='" + Format(CDate(TFechaIni(SStab.SelectedIndex + 1).Text), "yyyy/MM/dd 00:00") + "' and FECHA<'" + Format(CDate(TFechaFin(SStab.SelectedIndex + 1).Text), "yyyy/MM/dd 23:59") + "'"
                Case 2
                    Tabla = "TAMIZADOS"
                    DG = DGTamizados
                    NomDGCol = True
                    Consulta = "select distinct OP,NomProd,Maquina from TAMIZADOS where FINALIZADO='N' and FECHA>='" + Format(CDate(TFechaIni(SStab.SelectedIndex + 1).Text), "yyyy/MM/dd 00:00") + "' and FECHA<'" + Format(CDate(TFechaFin(SStab.SelectedIndex + 1).Text), "yyyy/MM/dd 23:59") + "'"
            End Select

            DVarios.Open(Consulta)
            AsignaDataGrid(DG, DVarios.DataTable, NomDGCol)

            If Tabla = "HUMEDADES" AndAlso DG.Rows.Count > 0 Then DGHumedades_CellClick(Nothing, Nothing)
            If Tabla = "TAMIZADOS" AndAlso DG.Rows.Count > 0 Then DGTamizados_CellClick(Nothing, Nothing)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Boton As Button = CType(sender, Button)
            Index = BBuscar.Index(Boton)


            If CDate(TFechaFin(Index).Text) < CDate(TFechaIni(Index).Text) Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FECHA))
                Return
            End If
            SStab_SelectedIndexChanged(SStab, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGDetHumedades_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetHumedades.CellClick
        Try
            If DGDetHumedades.RowCount = 0 Then Return

            DHumedades2.Open("Select * from HUMEDADES where ID=" + DGDetHumedades.Rows(DGDetHumedades.CurrentRow.Index).Cells("DGDetHumedades_ID").Value.ToString)

            If DHumedades2.Count = 0 Then Return

            Limpiar_Habilitar_TextBox(TabHumedades.Controls, AccionTextBox.Deshabilitar)
            CMaquinaH.Enabled = False

            TCodFor.Text = DHumedades2.RecordSet("CODFOR")
            TLp.Text = DHumedades2.RecordSet("LP")
            TIdH.Text = DHumedades2.RecordSet("ID")
            TOPH.Text = DHumedades2.RecordSet("OP")
            TNomProdH.Text = DHumedades2.RecordSet("NOMPROD")
            CMaquinaH.Text = DHumedades2.RecordSet("MAQUINA")
            TTemperaturaH.Text = DHumedades2.RecordSet("TEMPERATURA")
            TCargaH.Text = DHumedades2.RecordSet("CARGA")
            TPresionH.Text = DHumedades2.RecordSet("PRESION")

            TPorcHarina.Text = DHumedades2.RecordSet("PORCHARINA")
            TPorcAcond.Text = DHumedades2.RecordSet("PORCACOND")
            TPorcEmp.Text = DHumedades2.RecordSet("PORCEMPAQUE")
            TPorcForm.Text = DHumedades2.RecordSet("PORCFORMULADA")
            'TPorcGanancia.Text = DHumedades2.RecordSet("PORCGANANCIA")

            TTempSalEnf.Text = DHumedades2.RecordSet("TEMPSALENFRIADOR")
            TTempEmp.Text = DHumedades2.RecordSet("TEMPEMPAQUE")

            TObservacionesH.Text = DHumedades2.RecordSet("OBSERVACIONES")

            'If ValidaFuncionalidad("ID.ControlDiario") Then
            '    DVarios.Open("select * from controldiario WHERE ID=" + DHumedades2.RecordSet("IDControlDiario").ToString)

            '    If DVarios.Count > 0 Then
            '        TTemperaturaH.Text = DVarios.RecordSet("TEMPACOND")
            '        TCargaH.Text = DVarios.RecordSet("CARGA")
            '        TPresionH.Text = DVarios.RecordSet("PRESIONENT")
            '    End If

            '    If TOPH.Text <> "" Then TOPH_KeyUp(Nothing, New KeyEventArgs(Keys.Enter))
            'End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGDetTamizados_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDetTamizados.CellClick
        Try


            If DGDetTamizados.RowCount = 0 Then Return

            DTamizados2.Open("Select * from TAMIZADOS where ID=" + DGDetTamizados.Rows(DGDetTamizados.CurrentRow.Index).Cells("DGDetTamizados_ID").Value.ToString)

            If DTamizados2.Count = 0 Then Return

            Limpiar_Habilitar_TextBox(TabTamizados.Controls, AccionTextBox.Deshabilitar)
            CMaquinaT.Enabled = False
            CPresentT.Enabled = False
            CSitioMuestra.Enabled = False

            TIdT.Text = DTamizados2.RecordSet("ID")
            TOPsT.Text = DTamizados2.RecordSet("OP")
            TNomProdT.Text = DTamizados2.RecordSet("NOMPROD")
            CMaquinaT.Text = DTamizados2.RecordSet("MAQUINA")
            TTemperaturaT.Text = DTamizados2.RecordSet("TEMPERATURA")
            CPresentT.Text = DTamizados2.RecordSet("PRESENT")
            TPesoMalla6.Text = DTamizados2.RecordSet("PESOMALLA6")
            TPorcMalla6.Text = DTamizados2.RecordSet("PORCMALLA6")
            TPesoMalla8.Text = DTamizados2.RecordSet("PESOMALLA8")
            TPorcMalla8.Text = DTamizados2.RecordSet("PORCMALLA8")
            TPesoMalla12.Text = DTamizados2.RecordSet("PESOMALLA12")
            TPorcMalla12.Text = DTamizados2.RecordSet("PORCMALLA12")
            TPesoMalla16.Text = DTamizados2.RecordSet("PESOMALLA16")
            TPorcMalla16.Text = DTamizados2.RecordSet("PORCMALLA16")
            TPesoMalla30.Text = DTamizados2.RecordSet("PESOMALLA30")
            TPorcMalla30.Text = DTamizados2.RecordSet("PORCMALLA30")
            TPesoPlato.Text = DTamizados2.RecordSet("PESOPLATO")
            TPorcPlato.Text = DTamizados2.RecordSet("PORCPLATO")
            TPorcDurabilidad.Text = DTamizados2.RecordSet("PORCDURABILIDAD")
            TDureza.Text = DTamizados2.RecordSet("DUREZA")
            TDensidad.Text = DTamizados2.RecordSet("DENSIDAD")
            CSitioMuestra.Text = DTamizados2.RecordSet("SITIOMUESTRA")

            DOps.Find("OP='" + TOPsT.Text + "'")
            If DOps.EOF Then Return
            DArticulos.Find(" CODINT='" + DOps.RecordSet("CodProd").ToString + "'")
            If DArticulos.EOF Then Return

            TParmPorcM8.Text = DArticulos.RecordSet("ParmPorcMalla8")
            TParmPorcM12.Text = DArticulos.RecordSet("ParmPorcMalla12")
            TParmPorcM16.Text = DArticulos.RecordSet("ParmPorcMalla16")
            TParmPorcM30.Text = DArticulos.RecordSet("ParmPorcMalla30")
            TParmPorcPlato.Text = DArticulos.RecordSet("ParmPorcPlato")
            TParmDurabilidad.Text = DArticulos.RecordSet("ParmDurabilidad")
            TParmDureza.Text = DArticulos.RecordSet("ParmDureza")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try

            Limpiar_Habilitar_TextBox(SStab.Controls, AccionTextBox.Habilitar)
            TNomProd.Enabled = False
            TNomProdH.Enabled = False
            TNomProdT.Enabled = False
            TCodFor.Enabled = False
            TPorcForm.Enabled = False
            TLp.Enabled = False
            CTurno.Enabled = True
            CPresent.Enabled = True
            CPresentT.Enabled = True
            COrigen.Enabled = True
            CDestino.Enabled = True
            CMaquina.Enabled = True
            CMaquinaH.Enabled = True
            CMaquinaT.Enabled = True
            CSitioMuestra.Enabled = True

            TParmPorcM8.ReadOnly = True
            TParmPorcM12.ReadOnly = True
            TParmPorcM30.ReadOnly = True
            TParmPorcM16.ReadOnly = True
            TParmPorcPlato.ReadOnly = True
            TParmDurabilidad.ReadOnly = True
            TParmDureza.ReadOnly = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTurno.SelectedIndexChanged
        CMaquinaT.Focus()
    End Sub

    Private Sub THorometroIni_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles THorometroIni.KeyUp
        If e.KeyCode = Keys.Enter Then THorometroFin.Focus()
    End Sub

    Private Sub THorometroFin_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles THorometroFin.KeyUp
        If e.KeyCode = Keys.Enter Then TEnergiaIni.Focus()
    End Sub

    Private Sub TEnergiaIni_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEnergiaIni.KeyUp
        If e.KeyCode = Keys.Enter Then TEnergiaFin.Focus()
    End Sub

    Private Sub TEnergiaFin_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEnergiaFin.KeyUp
        If e.KeyCode = Keys.Enter Then TTiempoImp.Focus()
    End Sub

    Private Sub TTiempoImp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTiempoImp.KeyUp
        If e.KeyCode = Keys.Enter Then TObservaciones.Focus()
    End Sub

    Private Sub TObservaciones_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TObservaciones.KeyUp
        If e.KeyCode = Keys.Enter Then TTonPeletizar.Focus()
    End Sub

    Private Sub TTonPeletizar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTonPeletizar.KeyUp
        If e.KeyCode = Keys.Enter Then TTonPeletizadas.Focus()
    End Sub

    Private Sub TTonPeletizadas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTonPeletizadas.KeyUp
        If e.KeyCode = Keys.Enter Then TTempAcond.Focus()
    End Sub

    Private Sub TTempAcond_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTempAcond.KeyUp
        If e.KeyCode = Keys.Enter Then TPresionPeletEnt.Focus()
    End Sub

    Private Sub TPresionPeletEnt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPresionPeletEnt.KeyUp
        If e.KeyCode = Keys.Enter Then TCarga.Focus()
    End Sub

    Private Sub TCarga_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCarga.KeyUp
        If e.KeyCode = Keys.Enter Then TCorte.Focus()
    End Sub

    Private Sub TCorte_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCorte.KeyUp
        If e.KeyCode = Keys.Enter Then TTiempoMuest.Focus()
    End Sub

    Private Sub TTiempoMuest_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTiempoMuest.KeyUp
        If e.KeyCode = Keys.Enter Then TPesoMuest.Focus()
    End Sub

    Private Sub TPesoMuest_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPesoMuest.KeyUp
        If e.KeyCode = Keys.Enter Then BAceptar.Focus()
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Peletizado_Load(Nothing, Nothing)
    End Sub

    Private Sub TOPH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPH.KeyUp

        Try

            If e.KeyCode <> Keys.Enter Then Return

            If Val(TOPH.Text) = 0 Then Return

            DOps.Refresh()

            DOps.Find("OP='" + TOPH.Text + "'")

            If DOps.EOF Then Return
            DVarios.Open("Select * from ARTICULOS where CODINT='" + DOps.RecordSet("CODPROD") + "'")

            If DVarios.EOF Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " en base de datos"), MsgBoxStyle.Critical)
                Return
            End If

            TNomProdH.Text = DVarios.RecordSet("NOMBRE")
            TLp.Text = DOps.RecordSet("LP")
            TCodFor.Text = DOps.RecordSet("CODFOR")
            CMaquinaH.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    'Private Sub CMaquinaH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMaquinaH.Click
    '    ToolTip1.ToolTipTitle = "Descripción Máquinas"
    '    ToolTip1.Show("Máquinas P1 a P5 Peletizadoras, Máquinas E1 a E3 Extruder", CMaquinaH)
    'End Sub

    Private Sub CPeletH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMaquinaH.SelectedIndexChanged
        TCargaH.Focus()
    End Sub

    Private Sub TCargaH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCargaH.KeyUp
        If e.KeyCode = Keys.Enter Then TTemperaturaH.Focus()
    End Sub

    Private Sub TTemperaturaH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTemperaturaH.KeyUp
        If e.KeyCode = Keys.Enter Then TPresionH.Focus()
    End Sub

    Private Sub TPresionH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPresionH.KeyUp
        If e.KeyCode = Keys.Enter Then TObservacionesH.Focus()
    End Sub

    Private Sub TObservacionesH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TObservacionesH.KeyUp
        If e.KeyCode = Keys.Enter Then TPorcHarina.Focus()
    End Sub

    Private Sub TPorcHarina_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPorcHarina.KeyUp
        If e.KeyCode = Keys.Enter Then TPorcAcond.Focus()
    End Sub

    Private Sub TPorcAcond_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPorcAcond.KeyUp
        If e.KeyCode = Keys.Enter Then TPorcEmp.Focus()
    End Sub

    Private Sub TPorcEmp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPorcEmp.KeyUp
        If e.KeyCode = Keys.Enter Then TPorcForm.Focus()
    End Sub

    Private Sub TPorcForm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPorcForm.KeyUp
        If e.KeyCode = Keys.Enter Then TTempSalEnf.Focus()
    End Sub

    Private Sub TTempSalEnf_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTempSalEnf.KeyUp
        If e.KeyCode = Keys.Enter Then TTempEmp.Focus()
    End Sub

    Private Sub TTempEmp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTempEmp.KeyUp
        If e.KeyCode = Keys.Enter Then BAceptarH.Focus()
    End Sub

    Private Sub TOPsT_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPsT.KeyUp

        Try
            If e.KeyCode <> Keys.Enter Then Return
            If Val(TOPsT.Text) = 0 Then Return

            DOps.Refresh()

            DOps.Find("OP='" + TOPsT.Text + "'")

            If DOps.EOF Then Return

            DVarios.Open("Select * from ARTICULOS where CODINT='" + DOps.RecordSet("CODPROD") + "'")

            If DVarios.EOF Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " en base de datos"), MsgBoxStyle.Critical)
                Return
            End If

            TNomProdT.Text = DVarios.RecordSet("NOMBRE")
            TPesoMalla8.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try


    End Sub

    Private Sub TPesoMalla8_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPesoMalla8.KeyUp
        If e.KeyCode = Keys.Enter Then
            If GBMalla12.Enabled Then TPesoMalla12.Focus()
            If GBMalla16.Enabled Then TPesoMalla16.Focus()
        End If
    End Sub

    Private Sub TPesoMalla12_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPesoMalla12.KeyUp
        If e.KeyCode = Keys.Enter Then TPesoPlato.Focus()
    End Sub

    Private Sub TPesoPlato_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPesoPlato.KeyUp
        If e.KeyCode = Keys.Enter Then TPorcDurabilidad.Focus()
    End Sub

    Private Sub TPorcDurabilidad_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPorcDurabilidad.KeyUp
        If e.KeyCode = Keys.Enter Then TDureza.Focus()
    End Sub

    Private Sub TDureza_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TDureza.KeyUp
        If e.KeyCode = Keys.Enter Then TTemperaturaT.Focus()
    End Sub

    Private Sub TTemperaturaT_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TTemperaturaT.KeyUp
        If e.KeyCode = Keys.Enter Then TDensidad.Focus()
    End Sub

    Private Sub TDensidad_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TDensidad.KeyUp
        If e.KeyCode = Keys.Enter Then CSitioMuestra.Focus()
    End Sub

    Private Sub BCancelarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelarH.Click
        Try
            Limpiar_Habilitar_TextBox(SStab.Controls, AccionTextBox.Limpiar)

            CTurno.Text = ""
            CPresent.Text = ""
            CPresentT.Text = ""
            COrigen.Text = ""
            CDestino.Text = ""
            CMaquina.Text = ""
            CMaquinaH.Text = ""
            CMaquinaT.Text = ""

            CTurno.Enabled = True
            CPresent.Enabled = True
            CPresentT.Enabled = True
            COrigen.Enabled = True
            CDestino.Enabled = True
            CMaquina.Enabled = True
            CMaquinaH.Enabled = True
            CMaquinaT.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(SStab.Controls, AccionTextBox.Limpiar)

            CTurno.Text = ""
            CPresent.Text = ""
            CPresentT.Text = ""
            COrigen.Text = ""
            CDestino.Text = ""
            CMaquina.Text = ""
            CMaquinaH.Text = ""
            CMaquinaT.Text = ""

            CTurno.Enabled = True
            CPresent.Enabled = True
            CPresentT.Enabled = True
            COrigen.Enabled = True
            CDestino.Enabled = True
            CMaquina.Enabled = True
            CMaquinaH.Enabled = True
            CMaquinaT.Enabled = True
            BAceptar.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelarT.Click
        Try
            Limpiar_Habilitar_TextBox(SStab.Controls, AccionTextBox.Limpiar)

            CTurno.Text = ""
            CPresent.Text = ""
            CPresentT.Text = ""
            COrigen.Text = ""
            CDestino.Text = ""
            CMaquina.Text = ""
            CMaquinaH.Text = ""
            CMaquinaT.Text = ""

            CTurno.Enabled = True
            CPresent.Enabled = True
            CPresentT.Enabled = True
            COrigen.Enabled = True
            CDestino.Enabled = True
            CMaquina.Enabled = True
            CMaquinaH.Enabled = True
            CMaquinaT.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    'Private Sub CMaquina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMaquina.Click
    '    Try
    '        ToolTip1.ToolTipTitle = "Descripción Máquinas"
    '        ToolTip1.Show("Máquinas P1 a P5 Peletizadoras, Máquinas E1 a E3 Extruder", CMaquina)
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub CMaquinaT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMaquinaT.Click
    '    ToolTip1.ToolTipTitle = "Descripción Máquinas"
    '    ToolTip1.Show("Máquinas P1 a P5 Peletizadoras, Máquina E1 a E3 Extruder", CMaquinaT)
    'End Sub


    Private Sub BFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFiltrar.Click
        Try
            Dim DTurnos As New AdoSQL("TURNOS")
            Dim Consulta As String
            If Eval(TTurnoFiltro.Text) = 0 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, ", seleccione un turno válido"), vbInformation), vbInformation)
                Return
            End If

            DTurnos.Open("select * from TURNOS where TURNO=" + TTurnoFiltro.Text)

            If DTurnos.Count = 0 Then Return

            Consulta = "select * from CONTROLDIARIO where FECHA>='" + Format(TFechaFiltro.Value, "yyyy/MM/dd ") + DTurnos.RecordSet("HORAINI").ToString + "'" + _
                " and FECHA<'" + Format(TFechaFiltro.Value, "yyyy/MM/dd ") + DTurnos.RecordSet("HORAFIN").ToString + "'"

            If Val(DTurnos.RecordSet("HORAINI")) > Val(DTurnos.RecordSet("HORAFIN")) Then  'Turno 3
                Consulta = "select * from CONTROLDIARIO where FECHA>='" + Format(TFechaFiltro.Value, "yyyy/MM/dd ") + DTurnos.RecordSet("HORAINI").ToString + "'" +
             " and FECHA<'" + Format(DateAdd(DateInterval.Day, 1, TFechaFiltro.Value), "yyyy/MM/dd ") + DTurnos.RecordSet("HORAFIN").ToString + "'"
            End If

            If TMaquinaFiltro.Text.Length > 0 Then Consulta += " and  MAQUINA='" + TMaquinaFiltro.Text + "'"

            DVarios.Open(Consulta)
            AsignaDataGrid(DGControlDiario, DVarios.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGHumedades_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGHumedades.CellClick
        Try
            If DGHumedades.RowCount = 0 Then Return

            Dim OP, Maquina As String

            OP = DGHumedades.Rows(DGHumedades.CurrentRow.Index).Cells("DGHumedades_OP").Value.ToString
            Maquina = DGHumedades.Rows(DGHumedades.CurrentRow.Index).Cells("DGHumedades_Maquina").Value.ToString

            DHumedades.Open("select * from HUMEDADES where OP='" + OP + "' and MAQUINA='" + Maquina + "' and FINALIZADO='N'")

            AsignaDataGrid(DGDetHumedades, DHumedades.DataTable, True)

            If DGDetHumedades.RowCount > 0 Then DGDetHumedades_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGTamizados_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGTamizados.CellClick
        Try
            If DGTamizados.RowCount = 0 Then Return

            Dim OP, Maquina As String

            OP = DGTamizados.Rows(DGTamizados.CurrentRow.Index).Cells("DGTamizados_OP").Value.ToString
            Maquina = DGTamizados.Rows(DGTamizados.CurrentRow.Index).Cells("DGTamizados_Maquina").Value.ToString

            DTamizados.Open("select * from TAMIZADOS where OP='" + OP + "' and MAQUINA='" + Maquina + "' and FINALIZADO='N'")

            AsignaDataGrid(DGDetTamizados, DTamizados.DataTable, True)

            If DGDetTamizados.RowCount > 0 Then DGDetTamizados_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BFinalizarH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFinalizarH.Click
        Try
            If DGHumedades.CurrentRow Is Nothing OrElse DGHumedades.RowCount = 0 Then Return

            Dim OP, Maquina As String

            OP = DGHumedades.Rows(DGHumedades.CurrentRow.Index).Cells("DGHumedades_OP").Value.ToString
            Maquina = DGHumedades.Rows(DGHumedades.CurrentRow.Index).Cells("DGHumedades_Maquina").Value.ToString

            DVarios.Open("update HUMEDADES set FINALIZADO='S' where OP='" + OP + "' and MAQUINA=" + Maquina + " and FINALIZADO='N'")

            SStab_SelectedIndexChanged(SStab.SelectedIndex, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BFinalizarT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFinalizarT.Click
        Try
            If DGTamizados.CurrentRow Is Nothing OrElse DGTamizados.RowCount = 0 Then Return

            Dim OP, Maquina As String

            OP = DGTamizados.Rows(DGTamizados.CurrentRow.Index).Cells("DGTamizados_OP").Value.ToString
            Maquina = DGTamizados.Rows(DGTamizados.CurrentRow.Index).Cells("DGTamizados_Maquina").Value.ToString

            DVarios.Open("update TAMIZADOS set FINALIZADO='S' where OP='" + OP + "' and MAQUINA=" + Maquina + " and FINALIZADO='N'")

            SStab_SelectedIndexChanged(SStab.SelectedIndex, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOps_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOps.TextChanged
        Try
            If Val(TOps.Text) = 0 Then Return


            DVarios.Open("Select * from OPs where OP='" + TOps.Text + "'")
            If DVarios.Count = 0 Then Return

            TNomProd.Text = DVarios.RecordSet("NOMPROD")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOps_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOps.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then CTurno.Focus()
            If e.KeyCode = Keys.Back Then TNomProd.Text = ""
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

End Class
