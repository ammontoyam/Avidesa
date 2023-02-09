Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports System.Threading.Thread

Public Class Planilla
    Private DOPs As AdoSQL
    Private DBaches As AdoSQL
    Private DEmpaque As AdoSQL
    Private DArt As AdoSQL
    Private DConsultas As AdoSQL
    Property DCons As AdoSQL
    Private DVarios As AdoSQL
    Private DEquipos As AdoSQL
    Private DHumedades As AdoSQL
    Private DOpsFinPlanilla As AdoSQL
    Private DLineasProd As AdoSQL
    Private DClientes As AdoSQL
    Private TDifHumedad As ArrayControles(Of TextBox)
    Private THumEmp As ArrayControles(Of TextBox)
    Private THumHar As ArrayControles(Of TextBox)
    Private Conx As Connection
    Private ComImp As Integer
    Private FormLoad As Boolean
    Private Cont As Long

    Private AjusteManual As Boolean
    Private PromMalla8 As Double
    Private PromMalla16 As Double
    Private PromPlato As Double
    Private PromDureza As Double
    Private PromDbilidad As Double

    Private NombreImpresoraPlanilla As String = ""
    Private NombreImpresoraPlanillaSacos As String = ""
    Private PrefijoLotePlanta As String = ""

    Private DiasVenc As Integer = 0

    Private Sub Planilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FormLoad Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            DOPs = New AdoSQL("OPs")
            DBaches = New AdoSQL("Baches")
            DEmpaque = New AdoSQL("Empaque")
            DArt = New AdoSQL("ARTICULOS")
            DCons = New AdoSQL("Consumos")
            DVarios = New AdoSQL("Varios")
            DEquipos = New AdoSQL("Equipos")
            DHumedades = New AdoSQL("Humedades")
            DOpsFinPlanilla = New AdoSQL("OPs")
            DConsultas = New AdoSQL("Consultas")
            DLineasProd = New AdoSQL("LineasProd")
            DClientes = New AdoSQL("Clientes")

            DClientes.Open("Select * from CLIENTES")
            LLenaComboBox(TNuevoCliente, DClientes.DataTable, "NOMCLI")

            TDifHumedad = New ArrayControles(Of TextBox)("TDifHumedad", Me)
            THumEmp = New ArrayControles(Of TextBox)("THumEmp", Me)
            THumHar = New ArrayControles(Of TextBox)("THumHar", Me)

            CBCondicion.Text = ""
            TDestino.Text = ""
            TPresent.Text = ""
            TSacosImp.Text = ""

            CEquipo.Items.Clear()

            If Funcion_FuncionesPlantaPremezclas Then
                DLineasProd.Open("Select * from LINEASPROD where TIPO='LN'")
                LLenaComboBox(CEquipo, DLineasProd.DataTable, "LINEA")
            Else
                CEquipo.Items.Add("H")
                CEquipo.Items.Add("E")
                CEquipo.Items.Add("P1")
                CEquipo.Items.Add("P2")
                CEquipo.Items.Add("P3")
                CEquipo.Items.Add("P4")
                CEquipo.Items.Add("P5")
            End If

            TabAdicionesOP.Enabled = False

            DEquipos.Open("Select * from EQUIPOS where CODEQUIPO='Zebra.Planilla'")

            If DEquipos.Count = 0 Then
                MsgBox("Falta configuración para puerto serial de impresora 'Zebra.Planilla', tabla equipos", vbCritical)
                Return
            Else
                If (DEquipos.RecordSet("PCCONEXION") = Sesion Or DEquipos.RecordSet("PCCONEXION") = NombrePC) And FormLoad = False Then
                    Imprimir.Enabled = True
                    NombreImpresoraPlanilla = ConfigParametros("NomImpPlanilla")
                    RBEstibas.Enabled = True
                    RBEstibas.Checked = True
                    'Else
                    '    SplitContainer1.SplitterDistance = 1
                    '    SplitContainer1.Panel1.Hide()
                    '    Me.Width = 1150
                End If

            End If

            DEquipos.Open("Select * from EQUIPOS where CODEQUIPO='Zebra.PlanillaSacos'")

            If DEquipos.Count = 0 Then
                MsgBox("Falta configuración para puerto serial de impresora 'Zebra.PlanillaSacos', tabla equipos", vbCritical)
                Return
            Else
                If (DEquipos.RecordSet("PCCONEXION") = Sesion Or DEquipos.RecordSet("PCCONEXION") = NombrePC) And FormLoad = False Then
                    Imprimir.Enabled = True
                    NombreImpresoraPlanillaSacos = ConfigParametros("NomImpPlanillaSacos")
                    RBSacos.Enabled = True
                    RBSacos.Checked = True

                    'Revisamos si la base de datos tiene la tabla Plantas, para sacar información del prefijo del lote 

                    DVarios.Open("select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='Plantas' ")
                    If DVarios.Count Then
                        DVarios.Open("Select * from PLANTAS where NOMBRE='" + Planta + "'")
                        If DVarios.Count Then
                            PrefijoLotePlanta = DVarios.RecordSet("LETRA")
                        Else
                            MsgBox("Falta configuración para el prefijo del lote, tabla plantas, favor contactar a soporte")
                        End If
                    Else
                        MsgBox("Falta configuración para el prefijo del lote, tabla plantas, favor contactar a soporte")
                    End If

                End If

            End If

            If Imprimir.Enabled = False Then
                SplitContainer1.SplitterDistance = 1
                SplitContainer1.Panel1.Hide()
                Me.Width = 1150
            End If

            AjusteManual = False
            BActualizar_Click(Nothing, Nothing)
            FormLoad = True

            DireccionPlanta = ConfigParametros("DireccionPlanta")





        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGOPs_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOPs.CellClick
        Dim OP As String
        Try
            If DGOPs.CurrentRow Is Nothing Then Return
            If DGOPs.RowCount = 0 Then Return

            Dim PromHumEmp As Single = 0
            Dim PromHumHar As Single = 0
            Dim PromDifHum As Single = 0
            Dim PromHumAcond As Single = 0
            Dim Reproceso As Double = 0
            Dim FechaVenc As String = ""
            'Dim DiasVenc As Integer = 0

            TPesoDosif.Text = 0
            TPesoEmp.Text = 0
            TGrasaExt.Text = 0
            TDifKg.Text = 0
            TSackoff.Text = 0
            TDifHumedad(0).Text = 0
            TGananciaHum.Text = 0
            TPerdidaHum.Text = 0
            ChControlSackOff.Checked = False
            TObservFinPlanilla.Text = ""
            TObservFinPlanilla2.Text = ""

            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString

            'Se revisa si hay datos de humedades para esta OP y actualizar los datos en la tabla OPs

            'DHumedades.Open("Select AVG(PORCDIFHARINA) AS DIFHUMEDAD,AVG(PORCHARINA) AS PROMHUMHAR," +
            '                "AVG(PORCEMPAQUE) AS PROMHUMEMP,AVG(PORCACOND) AS PROMHUMACOND  from HUMEDADES WHERE OP='" + OP + "'")


            'If DHumedades.Count > 0 Then
            '    If Not IsDBNull(DHumedades.RecordSet("DIFHUMEDAD")) Then PromDifHum = DHumedades.RecordSet("DIFHUMEDAD")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMHAR")) Then PromHumHar = DHumedades.RecordSet("PROMHUMHAR")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMEMP")) Then PromHumEmp = DHumedades.RecordSet("PROMHUMEMP")
            '    If Not IsDBNull(DHumedades.RecordSet("PROMHUMACOND")) Then PromHumAcond = DHumedades.RecordSet("PROMHUMACOND")
            'End If

            'Actualizamos los datos de las humedades en la tabla OPs

            'DVarios.Open("Update OPS set DIFHUMEDAD=" + PromDifHum.ToString + ",PROMHUMHAR=" + PromHumHar.ToString +
            '             ",PROMHUMEMP=" + PromHumEmp.ToString + ",PROMHUMACOND=" + PromHumAcond.ToString + " where OP='" + OP + "'")

            DBaches.Open("select * from BACHES where OP='" + OP.Trim + "' order by FECHA")
            DEmpaque.Open("select Peso+PesoAjuste+Residuo+(Reproceso+SacosNC)*PresKg as PesoTot,Sacos+Reproceso as sacosTot,* from EMPAQUE where MAQUINA<100 and OP='" + OP + "' order by FECHAINI")

            AsignaDataGrid(DGBaches, DBaches.DataTable)
            AsignaDataGrid(DGEmp, DEmpaque.DataTable, True)


            DVarios.Open("Select sum(PESOREAL) as PESOREAL from CONSUMOS where CONT=ANY(Select cont FROM BACHES where OP='" + OP + "')")


            If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOREAL")) Then
                TPesoDosif.Text = Format(DVarios.RecordSet("PESOREAL"), "# ##0.00")
            End If


            DVarios.Open("select SUM(PesoReproceso+Peso+PesoAjuste+Residuo+(Reproceso+SacosNC)*PresKg) as PesoTot,SUM(Sacos+Reproceso) as sacosTot from EMPAQUE where MAQUINA<100 and OP='" + OP + "' group by op ")
            If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PesoTot")) Then
                TPesoEmp.Text = Format(DVarios.RecordSet("PesoTot"), "# ##0.00")
            End If

            DOPs.Open("select * from OPS where OP='" + OP.Trim + "'")

            If DOPs.Count = 0 Then Return


            TOPImp.Text = DOPs.RecordSet("OP").ToString
            TCodProdImp.Text = DOPs.RecordSet("CODPROD").ToString
            TFechaEmp.Text = Now.ToString("yyyy/MM/dd HH:mm:ss")

            ChControlSackOff.Checked = DOPs.RecordSet("SINCONTROLSACKOFF")
            Reproceso = DOPs.RecordSet("Reproceso")

            DVarios.Open("Select * from ARTICULOS where CODINT='" + TCodProdImp.Text + "'")

            If DVarios.Count > 0 Then TNomProdImp.Text = DVarios.RecordSet("NOMBRE")


            TGrasaExt.Text = Format(DOPs.RecordSet("GrasaExt"), "# ##0.00")
            TFechaVenc.Text = DOPs.RecordSet("FechaVenc")

            'Traemos el consumo de grasa externa desde la tabla consumoseng

            DVarios.Open("Select SUM(PESOREAL) as PESOREAL from CONSUMOSENG where OP='" + OP.Trim + "'")
            '            TGrasaExt.Text = 0

            If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOREAL")) Then
                TGrasaExt.Text = Format(DVarios.RecordSet("PESOREAL"), "# ##0.00")
            End If


            TDifHumedad(0).Text = DOPs.RecordSet("DIFHUMEDAD")
            TDifHumedad(1).Text = DOPs.RecordSet("DIFHUMEDAD")
            TPromHumHar.Text = DOPs.RecordSet("PROMHUMHAR")
            TPromHumEmp.Text = DOPs.RecordSet("PROMHUMEMP")
            CEquipo.Text = DOPs.RecordSet("EQUIPO")


            TObservFinPlanilla.Text = DOPs.RecordSet("ObservFinPlanilla")

            TPerdidaHum.Text = (PromHumEmp - PromHumHar).ToString
            TGananciaHum.Text = (PromHumAcond - PromHumHar).ToString


            TDifHumedad(0).Text = Format(DOPs.RecordSet("DIFHUMEDAD"), "# ##0.00")
            TDifHumedad(1).Text = Format(DOPs.RecordSet("DIFHUMEDAD"), "# ##0.00")
            TPromHumHar.Text = Format(DOPs.RecordSet("PROMHUMHAR"), "# ##0.00")
            TPromHumEmp.Text = Format(DOPs.RecordSet("PROMHUMEMP"), "# ##0.00")


            If Eval(TDifHumedad(0).Text) < 0 Then LDifHumedad.Text = "Per.Humedad:"
            If Eval(TDifHumedad(0).Text) > 0 Then LDifHumedad.Text = "Gan.Humedad:"
            If Eval(TDifHumedad(0).Text) = 0 Then LDifHumedad.Text = "Dif.Humedad:"

            TDifKg.Text = Format(Eval(TPesoEmp.Text) - Eval(TPesoDosif.Text) - DOPs.RecordSet("GrasaExt") - Eval(TDifHumedad(0).Text) + Reproceso, "# ##0.00")
            TSackoff.Text = Format(Eval(TDifKg.Text) * 100 / (Eval(TPesoDosif.Text) + DOPs.RecordSet("GrasaExt") + 1.0E-18), "#0.00")

            'Se calcula la fecha de vencimiento del producto, respecto a la linea de producción 

            'Se revisa si el campo de la OP FechaVencProd esta lleno, si no esta lleno se actualiza con los datos

            If DOPs.RecordSet("LINEAINVENT") <> "" Then
                'sE buscan los dias de vencimiento del producto de acuerdo a la linea de producción
                DVarios.Open("Select DIASVENC from LINEASPROD where TIPO='PT' and LINEA='" + DOPs.RecordSet("LINEAINVENT") + "'")
                If DVarios.Count Then
                    DiasVenc = DVarios.RecordSet("DIASVENC")
                End If
                'Se busca el primer registro de empaque para calcular la fecha de vencimiento del producto
                DVarios.Open("Select top 1 FechaIni from EMPAQUE where MAQUINA<100 and OP='" + OP + "' order by fechaini")
                If DVarios.Count And DiasVenc > 0 Then
                    FechaVenc = DateAdd(DateInterval.Day, DiasVenc, CDate(DVarios.RecordSet("FECHAINI"))).ToString("yyyy/MM/dd")
                ElseIf DiasVenc > 0 Then
                    FechaVenc = DateAdd(DateInterval.Day, DiasVenc, Now).ToString("yyyy/MM/dd")
                End If

                'Se actualiza la fecha de vencimiento en la tabla OPs

                If FechaVenc <> TFechaVenc.Text Then
                    DOPs.RecordSet("FECHAVENC") = TFechaVenc.Text
                    DOPs.Update()
                    TFechaVenc.Text = FechaVenc
                End If

            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdicGrasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdicGrasa.Click
        Dim OP As String
        Try
            'If DRUsuario("EmpMod") Then
            If ValidaPermiso("Planilla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If DGOPs.RowCount = 0 Then Return

            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")
            If DOPs.EOF = True Then Return

            DArt.Open("Select * from ARTICULOS where TIPO='MP' and LIQUIDOEXT=1")

            If DArt.Count > 0 Then
                LLenaComboBox(TCodInt, DArt.DataTable, "CodInt")
            End If

            TNombre.Text = ""
            TConsActual.Text = ""
            TCantReal.Text = ""
            TAjuste.Text = DOPs.RecordSet("GrasaExt")

            TOPAdicion.Text = OP
            TabAdicionesOP.Enabled = True
            TabAdicionesOP.SelectedTab = TabAdicionesOP.TabPages("TabGrasaExt")
            TCodInt.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDifHumedad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDifHumedad.Click
        Dim OP As String
        Try
            'If DRUsuario("EmpMod") Then
            If ValidaPermiso("Planilla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")
            If DOPs.EOF = True Then Return

            TOPDifHum.Text = OP

            TDifHumedad(1).Text = DOPs.RecordSet("DIFHUMEDAD")
            THumHar(0).Text = DOPs.RecordSet("PROMHUMHAR")
            THumEmp(0).Text = DOPs.RecordSet("PROMHUMEMP")

            TabAdicionesOP.Enabled = True
            TabAdicionesOP.SelectedTab = TabAdicionesOP.TabPages("TabHumedades")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BFinPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFinPlanilla.Click
        Dim OP As String
        Try
            'If DRUsuario("EmpMod") Then
            If ValidaPermiso("Planilla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Open("select * from OPS where OP='" + OP.Trim + "'")

            If DOPs.Count = 0 Then Return

            If DOPs.RecordSet("FINALIZADO") <> "S" Then
                MsgBox("La OP se encuentra abierta en dosificación, debe cerrarla antes de finalizar planilla", MsgBoxStyle.Information)
                Exit Sub
            End If


            If CEquipo.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " máquina"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If TObservFinPlanilla.Text = "-" Or TObservFinPlanilla2.Text = "" Then
                RespInput = MsgBox("¿Desea finalizar la OP sin observaciones de producción?", MsgBoxStyle.Information + vbYesNo)
                If RespInput = vbNo Then Exit Sub
            End If



            RespInput = MsgBox("Seguro desea finalizar la planilla de esta OP ?", MsgBoxStyle.Information + vbYesNo)
            If RespInput = vbNo Then Exit Sub

            Evento("Cierra Planilla  OP " + OP)

            DOPs.RecordSet("FINPLANILLA") = "S"
            DOPs.RecordSet("ObservFinPlanilla") = CLeft(DOPs.RecordSet("ObservFinPlanilla") + TObservFinPlanilla2.Text, 250)
            DOPs.RecordSet("Equipo") = CEquipo.Text
            DOPs.RecordSet("FechaFinPlanilla") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DOPs.RecordSet("SackOffKg") = Eval(TDifKg.Text)
            DOPs.RecordSet("SackOffPorc") = Eval(TSackoff.Text)

            'Actualizamos la fechafinplanilla de la tabla baches y empaque para visualización del sackoff en las pantallas de monitoreo
            DVarios.Open("Update BACHES set FECHAFINPLANILLA='" + DOPs.RecordSet("FECHAFINPLANILLA") + "' where OP='" + OP + "'")
            DVarios.Open("Update EMPAQUE set FECHAFINPLANILLA='" + DOPs.RecordSet("FECHAFINPLANILLA") + "' where OP='" + OP + "'")

            DOPs.Update(Me)

            BGuardaOPFin_Click(Nothing, Nothing)

            CEquipo.Text = ""
            TObservFinPlanilla.Text = ""
            DGEmp.Rows.Clear()
            DBaches.Rows.Clear()


            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCalcDiffHumedad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCalcDiffHumedad.Click
        Try
            Dim SackOff As Double
            Dim TotalDosif As Double
            Dim DiffPromHum As Double
            Dim DivisorHar As Integer
            Dim DivisorEmp As Int32


            TotalDosif = Eval(TPesoDosif.Text)
            SackOff = Eval(TPesoEmp.Text) - TotalDosif

            If Eval(THumHar(0).Text) > 0 And Eval(THumHar(1).Text) > 0 And Eval(THumHar(2).Text) > 0 Then
                DivisorHar = 3
                GoTo SigCalculo
            End If

            If Eval(THumHar(0).Text) > 0 And Eval(THumHar(1).Text) > 0 Then
                DivisorHar = 2
                GoTo SigCalculo
            End If

            If Eval(THumHar(0).Text) > 0 Then DivisorHar = 1

SigCalculo:

            If Eval(THumEmp(0).Text) > 0 And Eval(THumEmp(1).Text) > 0 And Eval(THumEmp(2).Text) > 0 Then
                DivisorEmp = 3
                GoTo promedio
            End If

            If Eval(THumEmp(0).Text) > 0 And Eval(THumEmp(1).Text) > 0 Then
                DivisorEmp = 2
                GoTo promedio
            End If

            If Eval(THumEmp(0).Text) > 0 Then DivisorEmp = 1

promedio:

            TPromHumHar.Text = Format((Eval(THumHar(0).Text) + Eval(THumHar(1).Text) + Eval(THumHar(2).Text)) / DivisorHar, "###.00")
            TPromHumEmp.Text = Format((Eval(THumEmp(0).Text) + Eval(THumEmp(1).Text) + Eval(THumEmp(2).Text)) / DivisorEmp, "###.00")

            DiffPromHum = Eval(TPromHumEmp.Text) - Eval(TPromHumHar.Text)

            If SackOff > 0 And DiffPromHum > 0 Then
                GoTo calcular
            ElseIf SackOff < 0 And DiffPromHum < 0 Then
                GoTo calcular
            Else
                MsgBox("No se aplica diferencia de humedad", vbInformation)
                Exit Sub
            End If

calcular:
            TDifHumedad(1).Text = Format((TotalDosif * DiffPromHum) / 100, "###.00")

            If TDifHumedad(1).Text > 0 Then MsgBox("Ganancia de humedad en Kg " + Trim(TDifHumedad(1).Text), MsgBoxStyle.Information)
            If TDifHumedad(1).Text < 0 Then MsgBox("Pérdida de humedad en Kg " + Trim((TDifHumedad(1).Text) * -1), MsgBoxStyle.Information)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarHum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarHum.Click
        Dim OP As String
        Try
            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")
            If DOPs.EOF = True Then Return


            If Eval(TOPDifHum.Text) = 0 Then Exit Sub
            If Eval(TPromHumHar.Text) = 0 Then Exit Sub
            If Eval(TPromHumEmp.Text) = 0 Then Exit Sub


            DBaches.Open("select * from BACHES where OP='" + TOPDifHum.Text + "'")
            If DBaches.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.OP_SINCONSUMOS), MsgBoxStyle.Information)
                Exit Sub
            End If


            Evento("Planilla. Ajuste por diferencia de humedad  " + Trim(TDifHumedad(1).Text) + " en OP = " + TOPDifHum.Text)


            DOPs.RecordSet("DIFHUMEDAD") = Eval(TDifHumedad(1).Text)
            DOPs.RecordSet("PROMHUMHAR") = Eval(TPromHumHar.Text)
            DOPs.RecordSet("PROMHUMEMP") = Eval(TPromHumEmp.Text)


            DOPs.Update(Me)
            DGOPs_CellClick(Nothing, Nothing)

            Limpiar_Habilitar_TextBox(TabAdicionesOP.Controls, AccionTextBox.Limpiar)
            TabAdicionesOP.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarHum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelarHum.Click
        Try
            If Eval(TDifHumedad(1).Text) <> 0 Then
                MsgBox("Debe guardar el valor de diferencia por humedad, o realizar un nuevo cálculo", MsgBoxStyle.Information)
                Exit Sub
            End If
            Limpiar_Habilitar_TextBox(TabAdicionesOP.Controls, AccionTextBox.Limpiar)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarAdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarAdicion.Click
        Try
            If TCodInt.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código material"), vbInformation)
                Exit Sub
            End If


            If TNombre.Text.Length < 3 Then Exit Sub

            If Eval(TAjuste.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " ajuste"), vbInformation)
                Exit Sub
            End If

            AjusteManual = True

            DBaches.Open("select * from BACHES where OP=" + TOPAdicion.Text)
            If DBaches.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.OP_SINCONSUMOS), MsgBoxStyle.Information)
                Exit Sub
            End If


            Evento("Planilla. Ajuste de  " + TCodInt.Text + ":" + TAjuste.Text + " OP " + TOPAdicion.Text)
            'DCons.Update
            DOPs.RecordSet("GrasaExt") = Eval(TAjuste.Text)
            DOPs.RecordSet("LIQEXT") = CLeft(TNombre.Text, 20)
            DOPs.Update(Me)

            DBaches.RecordSet("PesoReal") += Eval(TAjuste.Text)
            DBaches.Update()

            DGOPs_CellClick(Nothing, Nothing)
            Limpiar_Habilitar_TextBox(TabAdicionesOP.Controls, AccionTextBox.Limpiar)
            TabAdicionesOP.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BCancelarAdicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelarAdicion.Click
        Try
            Limpiar_Habilitar_TextBox(TabAdicionesOP.Controls, AccionTextBox.Limpiar)
            TabAdicionesOP.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodInt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodInt.SelectedIndexChanged
        Dim OP As String
        Try
            If Eval(TCodInt.Text) = 0 Then Return
            If DGOPs.RowCount = 0 Then Return

            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")
            If DOPs.EOF = True Then Return

            TNombre.Text = ""
            TAjuste.Text = ""
            TConsActual.Text = 0
            TCantReal.Text = 0

            DArt.Open("select * from ARTICULOS where CodInt='" + TCodInt.Text + "'")

            If DArt.Count = 0 Then Exit Sub


            TNombre.Text = DArt.RecordSet("Nombre")

            DVarios.Open("SELECT Baches.OP, Consumos.CodMat, Sum(Consumos.PesoReal) AS Total FROM Baches RIGHT JOIN " +
                                    "Consumos ON Baches.Cont = Consumos.Cont GROUP BY Baches.OP, Consumos.CodMat " +
                                    "HAVING (Baches.OP='" + TOPAdicion.Text + "' AND Consumos.CodMat like '%" + TCodInt.Text + "%')")

            If DVarios.Count Then TConsActual.Text = Format(DVarios.RecordSet("TOTAL"), "# ###.00")

            If Val(TGrasaExt.Text) > 0 Then TCantReal.Text = TGrasaExt.Text

            ''TAjuste.Text = DOPs.RecordSet("GrasaExt")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TObservFinPlanilla2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TObservFinPlanilla2.Leave
        Dim OP As String
        Try
            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP + "'")
            If DOPs.EOF = True Then Return

            DOPs.RecordSet("ObservFinPlanilla") = CLeft(LimpiarCadena(TObservFinPlanilla.Text) + "-" + LimpiarCadena(TObservFinPlanilla2.Text), 250)
            DOPs.Update(Me)

            DOPs.Refresh()
            TObservFinPlanilla.Enabled = True

            TObservFinPlanilla2.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, SaliToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try


            If Planta.Contains("CARTAGENA") Then
                DOPs.Open("select * from OPS where FINPLANILLA<>'S' and (REALMAN1>0 or REALMAN2>0 or REALMAN3>0) order by OP")
            Else
                DOPs.Open("select * from OPS where FINPLANILLA<>'S' and META<501 and (REAL>0 or VENTAS=10) order by OP")
            End If

            AsignaDataGrid(DGOPs, DOPs.DataTable)
            If DGOPs.RowCount > 0 Then DGOPs_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEmpMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEmpMan.Click
        'If DRUsuario("EmpMod") Then
        If ValidaPermiso("Empaque_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        EmpaqueMan.ShowDialog()
    End Sub

    Private Sub BReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReportes.Click
        Try
            'If DRUsuario("RepVer") Then
            If ValidaPermiso("Empaque_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Reportes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCantReal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCantReal.TextChanged
        Try
            TAjuste.Text = Format(Eval(TCantReal.Text) - Eval(TConsActual.Text), "# ###.00")
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGEmp_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmp.CellClick
        Try
            If DGEmp.RowCount = 0 Then Return

            TOPImp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_OP").Value.ToString
            TSacosImp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_SACOSTOT").Value.ToString
            TPresent.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_PRESEMP").Value.ToString
            TDestino.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_DESTINO").Value.ToString
            TContImp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_CONT").Value.ToString
            TFechaEmp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_FECHAINI").Value.ToString
            TCodProdImp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_CODPROD").Value

            If DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_CODPROD2").Value <> "-" Then
                TCodProdImp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_CODPROD2").Value
            End If


            If TPresent.Text = "NC" Then
                CBCondicion.Text = "NC"
            Else
                CBCondicion.Text = "C"
            End If



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPImp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TOPImp.KeyUp
        Try

            If e.KeyCode = Keys.Back Then
                TCodProdImp.Text = ""
                TNomProdImp.Text = ""
                CBCondicion.Text = ""
                TDestino.Text = ""
                TPresent.Text = ""
                TSacosImp.Text = ""

            End If
            If Eval(TOPImp.Text) = 0 Then Return


            DOPs.Open("Select * from OPS WHERE OP='" + TOPImp.Text + "'")

            If DOPs.Count = 0 Then
                'MsgBox("OP no creada", MsgBoxStyle.Information)
                Return
            End If

            DGBaches.Rows.Clear()
            DGEmp.Rows.Clear()

            AsignaDataGrid(DGOPs, DOPs.DataTable)

            If DGOPs.RowCount > 0 Then DGOPs_CellClick(Nothing, Nothing)

            Panel1.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImpEtiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImpEtiq.Click
        Try
            Dim RepSap As CrystalRep

            If RBSacos.Checked Then
                Dim Lote As String = ""

                If Val(TOPImp.Text) = 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "campo contador empaque"), vbInformation)
                    Return
                End If

                If TFechaVenc.Text.Length < 2 Then
                    'MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "fecha vencimiento producto"), vbInformation)
                    'Return
                    DOPs.Open("Select * from OPS WHERE OP='" + TOPImp.Text + "'")
                    If DOPs.RecordSet("LINEAINVENT") <> "" Then
                        Dim FechaPrimerBache As String

                        DVarios.Open("Select DIASVENC from LINEASPROD where TIPO='PT' and LINEA='" + DOPs.RecordSet("LINEAINVENT") + "'")
                        If DVarios.Count Then

                            DiasVenc = DVarios.RecordSet("DIASVENC")

                            If DiasVenc = 0 Then
                                MsgBox("Días de vencimiento para la linea de: " + DOPs.RecordSet("LINEAINVENT") + " en cero", MsgBoxStyle.Information)
                                Exit Sub
                            End If

                            DVarios.Open("select top (1) * from BACHES where OP=" + TOPImp.Text + "order by FECHA desc")
                            FechaPrimerBache = DVarios.RecordSet("FECHA")

                            TFechaVenc.Text = DateAdd(DateInterval.Day, DiasVenc, CDate(FechaPrimerBache)).ToString("yyyy/MM/dd")
                        End If

                    End If
                End If


                Lote += PrefijoLotePlanta + Weekday(Now).ToString
                Lote += DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFullWeek).ToString
                Lote += TOPImp.Text

                For j = 0 To TNoCopias.Value - 1
                    RepSap = New CrystalRep

                    Application.DoEvents()

                    With RepSap
                        .ServerName = ServidorSQL
                        .DataBaseName = NomDB
                        .UserId = UserDB
                        .Password = PWD

                        .Formulas(0) = "PLANTA='" + Planta + "'"
                        .Formulas(1) = "CODPROD='" + "CODIGO: " + TCodProdImp.Text + "'"
                        .Formulas(2) = "NOMPROD='" + DOPs.RecordSet("NOMPROD") + "'"
                        .Formulas(3) = "LOTE='" + "LOTE: " + Lote + "'"
                        .Formulas(4) = "FECHAVENC='" + "VENCE: " + Format(CDate(TFechaVenc.Text), "dd/MM/yy") + " '"
                        .Formulas(5) = "MEDICADO='" + DOPs.RecordSet("OBSERVOP") + "'"
                        .Formulas(6) = "DIRECCION='" + DireccionPlanta + "'"
                        '.Destination = CrystalRep.Destinacion.crToWindows
                        .Destination = CrystalRep.Destinacion.crToPrinter
                        .ChoosePrint = True
                        .MaximizeBox = True
                        .MinimizeBox = True
                        .Copias = 1

                    End With

                    RepSap.ReportFileName = RutaRep + "rpEtiqSacos.rpt"

                    'Se envian el nombre de la impresora, el  ancho en centesimas de pulgada, el alto en centesimas de pulgada
                    '1 mm = 3.93701 centesimas de pulgada, las dimensiones de la etiqueta son Ancho=100 mm, alto=78 mm
                    '1 mm = 3.93701 centesimas de pulgada, las dimensiones de la etiqueta son Ancho=11.5 mm, alto=10 mm
                    'RepSap.PrintReport(NombreImpresoraPlanillaSacos)                    
                    'RepSap.PrintReport(NombreImpresoraPlanillaSacos, 393.701, 275.59)
                    RepSap.PrintReport(NombreImpresoraPlanillaSacos, 452.756, 393.7)
                    'RepSap.PrintReport(NombreImpresoraPlanillaSacos)

                Next
                MsgBox("Envío a imprimir finalizado", vbInformation)
                Exit Sub
            End If


            Dim Condicion As String
            Dim CodigoBarras As New BarCode
            'Dim RepSap As CrystalRep

            If Val(TContImp.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "campo contador empaque"), vbInformation)
                Return
            End If

            If TFechaVenc.Text.Length < 2 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "fecha vencimiento producto"), vbInformation)
                Return
            End If

            If CBCondicion.Text = "NC" Then
                Condicion = "NC"
            Else
                Condicion = "CO"
            End If

            Dim Dia As String = DatePart(DateInterval.Day, CDate(TFechaEmp.Text)).ToString
            Dim Semana As String = DatePart(DateInterval.WeekOfYear, CDate(TFechaEmp.Text)).ToString

            If TNoCopias.Value = 0 Then Return

            '' TramaImpresion = TramaEtiquetaPT(DOPs.RecordSet("CODPROD"), TPresent.Text, TNomProdImp.Text, DOPs.RecordSet("OP"), Condicion, TDestino.Text, TSacosImp.Text, DOPs.RecordSet("META"), DOPs.RecordSet("OBSERVOP"))


            For j = 0 To TNoCopias.Value - 1
                RepSap = New CrystalRep
                Dim Bm As Bitmap
                Application.DoEvents()
                'Codigo de barras del Codigo DE Material
                CodigoBarras.DescCarpeta = "PT"
                CodigoBarras.NombreArchivoBMP = "CodBarPT.bmp"
                ''Bm = CodigoBarras.Code128("INIPT" + Separador + Condicion + Separador + TDestino.Text + Separador + TPresent.Text + Separador + DOPs.RecordSet("OP") + Separador + "FIN", BarCode.Code128SubTypes.CODE128, True, 70)
                Bm = CodigoBarras.Code128(TContImp.Text, BarCode.Code128SubTypes.CODE128, True, 70)
                CodigoBarras.Guardar(Bm)

                With RepSap
                    .ServerName = ServidorSQL
                    .DataBaseName = NomDB
                    .UserId = UserDB
                    .Password = PWD
                    .Formulas(0) = "NOMPROD='" + DOPs.RecordSet("NOMPROD") + "'"
                    .Formulas(1) = "DIA='" + Dia + "'"
                    .Formulas(2) = "PLANTA='" + Planta + "'"
                    .Formulas(3) = "SEMANA='" + Semana + "'"
                    .Formulas(4) = "OP='" + DOPs.RecordSet("OP") + "'"
                    .Formulas(5) = "UBICACION='" + TDestino.Text + "'"
                    .Formulas(6) = "OBSERVACION='" + DOPs.RecordSet("OBSERVFINPLANILLA") + "'"
                    .Formulas(7) = "CODPROD='" + TCodProdImp.Text + "'"
                    .Formulas(8) = "FECHAVENC='" + Format(CDate(TFechaVenc.Text), "dd.MM.yy") + "'"

                    '.Destination = CrystalRep.Destinacion.crToWindows
                    .Destination = CrystalRep.Destinacion.crToPrinter
                    .WindowState = FormWindowState.Maximized
                    '.ChoosePrint = True
                    .MaximizeBox = True
                    .MinimizeBox = True
                    .Copias = 1

                End With

                RepSap.ReportFileName = RutaRep + "rpEtiqPT.rpt"

                'Se envian el nombre de la impresora, el  ancho en centesimas de pulgada, el alto en centesimas de pulgada
                '1 mm = 3.93701 centesimas de pulgada, las dimensiones de la etiqueta son Ancho=100 mm, alto=150 mm
                RepSap.PrintReport(NombreImpresoraPlanilla)

            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnBuscarOPFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBuscarOPFin.Click
        Try

            'If DRUsuario("AbrirPlanilla") Then
            If ValidaPermiso("Planilla_Abrir") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), vbInformation)
                Exit Sub
            End If

            RespInput = ""

            InputBox.InputBox("OPs", "Ingrese el número de OP a buscar", RespInput)

            If RespInput = "" Or Eval(RespInput) = 0 Then Return

            DOPs.Open("Select * from OPS where OP='" + RespInput + "'")

            If DOPs.Count = 0 Then
                MsgBox("OP no encontrada en base de datos", vbInformation)
                Planilla_Load(Nothing, Nothing)
                Return
            End If

            If DOPs.RecordSet("FINPLANILLA") <> "S" Then
                MsgBox("La OP no está finalizada por planilla", vbInformation)
                Return
            End If

            Resp = MsgBox("¿Seguro desea traer nuevamente la OP a la planilla?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)

            If Resp = vbNo Then Return

            DOPs.RecordSet("NUMFINPLANILLA") += 1
            DOPs.RecordSet("FINPLANILLA") = "-"
            DOPs.Update(Me)

            AsignaDataGrid(DGOPs, DOPs.DataTable)

            If DGOPs.RowCount > 0 Then DGOPs_CellClick(Nothing, Nothing)

            TObservFinPlanilla2.Text = "RELIQUIDACION PLANILLA"

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGuardar.Click
        Try

            'If DRUsuario("ControlSackOff") Then
            If ValidaPermiso("Control_SackOff") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Resp = MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOCONFIRMACION), vbInformation + vbYesNo)
            If Resp = vbNo Then Return

            Dim OP As String
            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")

            If DOPs.EOF Then Return

            DOPs.RecordSet("SINCONTROLSACKOFF") = ChControlSackOff.Checked
            DOPs.Update(Me)

            Evento("Restricción de sackoff=" + ChControlSackOff.Checked.ToString + " en OP: " + OP)

            BActualizar_Click(Nothing, Nothing)


        Catch ex As Exception

        End Try
    End Sub


    Private Sub BFinPlanillaAuto_Click(sender As System.Object, e As System.EventArgs) Handles BFinPlanillaAuto.Click
        Try
            'Finaliza las ops de mascotas ya que no se empacan por la planta de concetrados en palmira
            DVarios.Open("update OPS set FINPLANILLA='S' where FINALIZADO='S' and LINEAINVENT='MASCOTAS'")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TimSeg_Tick(sender As System.Object, e As System.EventArgs) Handles TimSeg.Tick
        Try
            Cont = Cont + 1
            If Cont > 100000 Then Cont = 1
            If Cont Mod 600 = 0 Then
                'BFinPlanillaAuto_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCambiarEstOP_Click(sender As System.Object, e As System.EventArgs) Handles BCambiarEstOP.Click
        Try
            If ValidaPermiso("Planilla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Dim OP As String

            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Open("select * from OPS where OP='" + OP.Trim + "'")

            If DOPs.Count = 0 Then Return

            If DOPs.RecordSet("VENTAS") = 0 Then
                MsgBox("La OP no es una producción de ventas", vbCritical)
                Return
            End If

            If DOPs.RecordSet("VENTAS") = 15 Then
                MsgBox("Los consumos para esta OP ya fueron trasladados, debe finalizar la planilla", vbCritical)
                Return
            End If

            RespInput = MsgBox("¿Seguro desea cambiar el estado de esta OP  de ventas?, recuerde que se trasladarán los registros de empaque al consumo de la OP", MsgBoxStyle.Information + vbYesNo)
            If RespInput = vbNo Then Exit Sub

            Evento("Cambia estado (15) OP de ventas  OP " + OP)

            DOPs.RecordSet("VENTAS") = 15
            DOPs.Update(Me)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BGuardaOPFin_Click(sender As Object, e As EventArgs) Handles BGuardaOPFin.Click
        Try
            'Se buscan todos los datos de control proceso

            PromDbilidad = 0
            PromDureza = 0
            PromMalla16 = 0
            PromMalla8 = 0
            PromPlato = 0

            Dim OP As String = ""

            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString

            DConsultas.Open("Select * from CONSULTAS")

            DConsultas.RecordSet("T8") = "PELET"
            DConsultas.Update()

            'Abrimos la consulta para sacar promedio por presentacion Pelet
            DVarios.Open("Select * from CAVGTAMIZADOS where OP='" + OP + "'")

            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM8")) Then PromMalla8 = DVarios.RecordSet("PROMPORCM8")
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM16")) Then PromMalla16 = DVarios.RecordSet("PROMPORCM16")
                If Not IsDBNull(DVarios.RecordSet("PROMPORCPLATO")) Then PromPlato = DVarios.RecordSet("PROMPORCPLATO")
                If Not IsDBNull(DVarios.RecordSet("PROMPORCDURABILIDAD")) Then PromDbilidad = DVarios.RecordSet("PROMPORCDURABILIDAD")
                If Not IsDBNull(DVarios.RecordSet("PROMDUREZA")) Then PromDureza = DVarios.RecordSet("PROMDUREZA")
            End If


            'Se van almacenando los datos requeridos
            DOpsFinPlanilla.Open("Select * from OPSFINPLANILLA where OP='" + OP + "'")
            If DOpsFinPlanilla.Count = 0 Then DOpsFinPlanilla.AddNew()

            DOpsFinPlanilla.RecordSet("OP") = OP
            DOpsFinPlanilla.RecordSet("FECHAFINPLANILLA") = FechaC()
            DOpsFinPlanilla.RecordSet("DOSIFICADOKG") = Eval(TPesoDosif.Text)
            DOpsFinPlanilla.RecordSet("EMPACADOKG") = Eval(TPesoEmp.Text)
            DOpsFinPlanilla.RecordSet("DIFERENCIAKG") = Eval(TDifKg.Text)
            DOpsFinPlanilla.RecordSet("SACKOFFPORC") = Eval(TSackoff.Text)
            DOpsFinPlanilla.RecordSet("MALLA8P") = PromMalla8
            DOpsFinPlanilla.RecordSet("MALLA16P") = PromMalla16
            DOpsFinPlanilla.RecordSet("PLATOP") = PromPlato
            DOpsFinPlanilla.RecordSet("DUREZAP") = PromDureza
            DOpsFinPlanilla.RecordSet("DURABILIDADP") = PromDbilidad

            PromDbilidad = 0
            PromDureza = 0
            PromMalla16 = 0
            PromMalla8 = 0
            PromPlato = 0

            'Abrimos la consulta para sacar promedio por presentacion Quebrantado
            DConsultas.Open("Select * from CONSULTAS")

            DConsultas.RecordSet("T8") = "QUEB"
            DConsultas.Update()


            DVarios.Open("Select * from CAVGTAMIZADOS where OP='" + OP + "'")

            If DVarios.Count > 0 Then
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM8")) Then PromMalla8 = DVarios.RecordSet("PROMPORCM8")
                If Not IsDBNull(DVarios.RecordSet("PROMPORCM16")) Then PromMalla16 = DVarios.RecordSet("PROMPORCM16")
                If Not IsDBNull(DVarios.RecordSet("PROMPORCPLATO")) Then PromPlato = DVarios.RecordSet("PROMPORCPLATO")
                If Not IsDBNull(DVarios.RecordSet("PROMPORCDURABILIDAD")) Then PromDbilidad = DVarios.RecordSet("PROMPORCDURABILIDAD")
                If Not IsDBNull(DVarios.RecordSet("PROMDUREZA")) Then PromDureza = DVarios.RecordSet("PROMDUREZA")
            End If


            ''Terminamos de llenar los datos de quebrantado
            DOpsFinPlanilla.RecordSet("MALLA8Q") = PromMalla8
            DOpsFinPlanilla.RecordSet("MALLA16Q") = PromMalla16
            DOpsFinPlanilla.RecordSet("PLATOQ") = PromPlato
            DOpsFinPlanilla.RecordSet("DUREZAQ") = PromDureza
            DOpsFinPlanilla.RecordSet("DURABILIDADQ") = PromDbilidad

            DOpsFinPlanilla.Update()

            Evento("Almacena datos fin planilla OP: " + OP)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnEditarEmpEtiq_Click_1(sender As Object, e As EventArgs) Handles mnEditarEmpEtiq.Click
        Try
            If DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value Is Nothing Then Return
            If Val(TContImp.Text) = 0 Then
                MsgBox("Debe seleccionar un registro de empaque", vbInformation)
                Return
            End If
            'Se evalua si el registro ya fueprocesado por costos, si es así no se mostrará el cuadro de ajuste de empaques y etiquetas adicionales
            DVarios.Open("Select * from EMPAQUE where ESTADO=0 and CONT=" + TContImp.Text)
            If DVarios.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.EMPAQUE_REGPROCESADOCOSTOS), vbCritical)
                Return
            End If

            ModificaEmpEtiq.ModificaEmpEtiq_Load(Nothing, Nothing)
            ModificaEmpEtiq.TOPs.Text = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value
            ModificaEmpEtiq.TCont.Text = TContImp.Text
            ModificaEmpEtiq.TCodEmp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEmp_CodEmp").Value
            ModificaEmpEtiq.TCodEtiq.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEmp_CodEtiq").Value
            'ModificaEmpEtiq.BActualizar_Click(Nothing, Nothing)
            ModificaEmpEtiq.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ChEditarObserv_CheckedChanged(sender As Object, e As EventArgs) Handles ChEditarObserv.CheckedChanged
        Try

            If ChEditarObserv.Checked = False Then Return

            If DRUsuario("EmpMod") Then
            Else
                MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If

            TObservFinPlanilla.ReadOnly = False
            TObservFinPlanilla.Enabled = True
            TObservFinPlanilla2.Enabled = False
            DGOPs.Enabled = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CPelet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CEquipo.SelectedIndexChanged
        Try
            'If DRUsuario("EmpMod") Then
            If ValidaPermiso("Empaque_Editar") Then
            Else
                MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If

            If CEquipo.Text = "" Or CEquipo.Text = "-" Then Return
            Dim OP As String = ""
            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")
            If DOPs.EOF = True Then Return

            If DOPs.RecordSet("Equipo") = "-" Then
                Resp = MsgBox("Desea guardar el dato de la máquina para la OP: " + OP + "?", vbYesNo + vbInformation)
                If Resp = vbNo Then Return

                DOPs.RecordSet("Equipo") = CEquipo.Text
                DOPs.Update()
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TObservFinPlanilla_Leave(sender As Object, e As EventArgs) Handles TObservFinPlanilla.Leave
        Try
            Dim OP As String = ""
            If DGOPs.RowCount = 0 Then Return
            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value.ToString
            DOPs.Find("OP='" + OP.Trim + "'")
            If DOPs.EOF = True Then Return

            DOPs.RecordSet("ObservFinPlanilla") = CLeft(TObservFinPlanilla.Text + "-" + TObservFinPlanilla2.Text, 250)
            DOPs.Update()

            TObservFinPlanilla.ReadOnly = True
            TObservFinPlanilla.Enabled = False
            TObservFinPlanilla2.Enabled = True
            ChEditarObserv.Checked = False
            DGOPs.Enabled = True
            DOPs.Refresh()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnCambiarClienteOP_Click(sender As Object, e As EventArgs) Handles mnCambiarClienteOP.Click
        Try
            If DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value Is Nothing Then Return

            If ValidaPermiso("OPs_EditarCliente") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            TOPsCambioCliente.Text = DGOPs.Rows(DGOPs.CurrentRow.Index).Cells("OP").Value
            DVarios.Open("Select NOMCLI from OPS where OP='" + TOPsCambioCliente.Text + "'")
            If DVarios.Count Then
                TCliente.Text = DOPs.RecordSet("NOMCLI")
            End If

            PCambioCliente.Visible = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarCambioClienteOP_Click(sender As Object, e As EventArgs) Handles BCancelarCambioClienteOP.Click
        Try
            PCambioCliente.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptarCambioClienteOP_Click(sender As Object, e As EventArgs) Handles BAceptarCambioClienteOP.Click
        Try

            If TNuevoCliente.Text = "" Then Return

            Resp = MsgBox("¿Seguro desea cambiar el código del cliente para la OP seleccionada?", vbYesNo + vbCritical)
            If Resp = vbNo Then
                BCancelarCambioClienteOP_Click(Nothing, Nothing)
                Return
            End If

            DClientes.Find("NOMCLI='" + TNuevoCliente.Text + "'")
            If Not DClientes.EOF Then

                DOPs.Open("Select * from OPS where OP='" + TOPsCambioCliente.Text + "'")
                If DOPs.Count Then
                    DOPs.RecordSet("CODCLI") = DClientes.RecordSet("CODCLI")
                    DOPs.RecordSet("NOMCLI") = DClientes.RecordSet("NOMCLI")
                    DOPs.Update(Me)
                End If

                Evento("Modifica cliente OP: " + TOPsCambioCliente.Text + " Cliente Ant: " + TCliente.Text + " Cliente Nuevo: " + TNuevoCliente.Text)
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)
            End If

            PCambioCliente.Visible = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Class