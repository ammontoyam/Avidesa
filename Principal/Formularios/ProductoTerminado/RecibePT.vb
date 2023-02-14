Option Explicit On

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports ClassLibrary

Public Class RecibePT
    Private DEmpaque As AdoSQL
    Private DUsuarios As AdoSQL
    Private DOPs As AdoSQL
    Private Dvarios As AdoSQL
    Private DUbicaciones As AdoSQL
    Private DExcPT As AdoSQL

    Private Sentencia As String
    Private SentenciaSacos As String
    Private SentenciaPeso As String
    Private Fila As Integer
    Private Campos() As String
    Private RBUbicacion As ArrayControles(Of RadioButton)
    Private RBProceso As ArrayControles(Of RadioButton)
    Private Proceso As String
    Private PT_Exc_Calidad As String = ""
    Private PT_Exc_Produccion As String = ""
    Private PT_Exc_Almacen As String = ""

    Private FormLoad As Boolean = False

    Private Sub RecibePT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            DEmpaque = New AdoSQL("Empaque")
            DUsuarios = New AdoSQL("Usuarios")
            DOPs = New AdoSQL("OPS")
            Dvarios = New AdoSQL("VARIOS")
            DExcPT = New AdoSQL("EXCLUSIONESPT")

            DUbicaciones = New AdoSQL("UBICACIONES")

            'Se llena el objeto COMBOBOX Tubicacion con las ubicaciones TIPO UPT (Ubicacion Producto terminado)
            DUbicaciones.Open("Select * from UBICACIONES where TIPO='UPT'")
            LLenaComboBox(TUbicacion, DUbicaciones.DataTable, "CODUBI")

            DUbicaciones.Open("Select * from UBICACIONES where TIPO='PT' and POSICION>0 and HABILITADA=1")
            LLenaComboBox(TBodega, DUbicaciones.DataTable, "CODUBI")

            FiltrosRecEmpaque(Me.GBFiltro, OpVerSolo, 10, 20)

            RBUbicacion = New ArrayControles(Of RadioButton)("RBUbicacion", Me)
            RBProceso = New ArrayControles(Of RadioButton)("RBProceso", Me)

            For Each RB As RadioButton In RBUbicacion.Values
                AddHandler RB.Click, AddressOf RBUbicacion_Click
            Next

            For Each RB As RadioButton In RBProceso.Values
                AddHandler RB.Click, AddressOf RBProceso_Click
            Next

            For i = 1 To 3
                RBProceso(i).Enabled = False
            Next

            SentenciaSacos = "Sacos + SacosAjuste + SacosNC + Reproceso"
            SentenciaPeso = "peso+pesoajuste+residuo+(SacosNC+Reproceso)*PresKg"

            'Valida si en la planta estan habilitadas las funcionalidades

            If Funcion_RecibirEmpaqueAlmacen Then
                RBProceso3.Enabled = True

                'Para Almacen
                DExcPT.Open("Select * from EXCLUSIONESPT where PROCESO='ALMACEN'")
                For Each Fila As DataRow In DExcPT.Rows
                    PT_Exc_Almacen += " CODPROD<>'" + Fila("CODIGO") + "' AND "
                Next

                If PT_Exc_Almacen = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACONFIGURACION, " tabla EXCLUSIONESPT, codigos PT Almacén"), vbCritical)
                    Return
                Else
                    PT_Exc_Almacen = "(" + CLeft(PT_Exc_Almacen, InStrRev(PT_Exc_Almacen, "AND") - 1) + ")"
                End If
            Else
                PT_Exc_Almacen = " CODPROD<>''"
            End If

            If Funcion_RecibirEmpaqueCalidad Then
                RBProceso2.Enabled = True

                'Para calidad
                DExcPT.Open("Select * from EXCLUSIONESPT where PROCESO='CALIDAD'")
                For Each Fila As DataRow In DExcPT.Rows
                    PT_Exc_Calidad += " CODPROD<>'" + Fila("CODIGO") + "' AND "
                Next

                If PT_Exc_Calidad = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACONFIGURACION, " tabla EXCLUSIONESPT, codigos PT Calidad"), vbCritical)
                    Return
                Else
                    PT_Exc_Calidad = "(" + CLeft(PT_Exc_Calidad, InStrRev(PT_Exc_Calidad, "AND") - 1) + ")"
                End If
            Else
                PT_Exc_Calidad = " CODPROD<>''"
            End If

            If Funcion_RecibirEmpaqueProduccion Then
                RBProceso1.Enabled = True
                'Se revisan las excluiones de producto terminado por proceso
                'Para producción
                DExcPT.Open("Select * from EXCLUSIONESPT where PROCESO='PRODUCCION'")
                For Each Fila As DataRow In DExcPT.Rows
                    PT_Exc_Produccion += " CODPROD<>'" + Fila("CODIGO") + "' AND "
                Next

                If PT_Exc_Produccion = "" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACONFIGURACION, " tabla EXCLUSIONESPT, codigos PT Producción"), vbCritical)
                    Return
                Else
                    PT_Exc_Produccion = "(" + CLeft(PT_Exc_Produccion, InStrRev(PT_Exc_Produccion, "AND") - 1) + ")"
                End If
            Else
                PT_Exc_Produccion = " CODPROD<>''"
            End If


            'Abrimos la tabla empaque sin registros
            DEmpaque.Open("Select * from EMPAQUE where CONT=0")

            Campos = {"OP@OP", "codprod@Código Producto", "Nomprod@Nombre de Producto", "Presemp@Presentación Empaque", "sacos@sacos"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DEmpaque.DataTable)

            'Se da prioridad al proceso de Almacen, luego a producción y por ultimo calidad para empezar a mostrar registros

            'RBProceso(1) 'Produccion
            'RBProceso(2) 'Calidad
            'RBProceso(3) 'Almacen

            'Se inicia mostrando los registros de Almacen
            RBProceso(3).Checked = True
            RBProceso_Click(RBProceso(3), Nothing)
            RBUbicacion(1).Checked = True
            RBUbicacion_Click(RBUbicacion(1), Nothing)

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub RBUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim RB As RadioButton = CType(sender, RadioButton)
            Dim Index As Integer = RBUbicacion.Index(RB)
            Dim Ubicacion As String = ""

            DUbicaciones.Find("POSICION=" + Index.ToString)

            If DUbicaciones.EOF Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACONFIGURACION, " Ubicaciones"), MsgBoxStyle.Critical)
                Return
            End If

            Ubicacion = DUbicaciones.RecordSet("CODUBI")

            'Se arma la consulta de acuerdo al proceso y si esta habilitado o no en la planta

            'Si el proceso es producción 
            If Proceso = "PRODUCCION" Then
                If Ubicacion = "ZR" Then
                    Sentencia = "Select (SacosNC+Reproceso)*-1 as SACOSTOT,(SacosNC+Reproceso)*presKg + PESO AS PESOTOT,* from EMPAQUE where RECPROD=0 " +
                        " and MAQUINA<100 and FINALIZADO='S'  and  (DESTINO2='ZR' OR DESTINO='ZR' OR DESTINO='SC' OR DESTINO2='SC') and " + PT_Exc_Produccion + " ORDER BY OP DESC"
                Else
                    Sentencia = "Select " + SentenciaSacos + " AS SACOSTOT," + SentenciaPeso + " AS PESOTOT,* from EMPAQUE where RECPROD=0" +
                           "  and MAQUINA<100  and FINALIZADO='S' and PESOREPROCESO=0 and (" + SentenciaPeso + ")<>0 and " + PT_Exc_Produccion + " and DESTINO='" + Ubicacion + "' ORDER BY OP DESC"
                End If
            End If

            'Si el proceso es calidad 
            If Proceso = "CALIDAD" Then
                'Si hay recepcion de producto en producción se pone un filtro adicional
                Dim CampoRecProd As String = "RecProd="
                If RBProceso1.Enabled Then
                    CampoRecProd += "1"
                Else
                    CampoRecProd += "0"
                End If

                If Ubicacion = "ZR" Then
                    Sentencia = "Select (SacosNC+Reproceso)*-1 as SACOSTOT,(SacosNC+Reproceso)*presKg + PESO AS PESOTOT,* from EMPAQUE where  RECCAL=0 and " + CampoRecProd +
                        " and MAQUINA<100 and FINALIZADO='S'  and (DESTINO2='ZR' OR DESTINO='ZR' OR DESTINO='SC' OR DESTINO2='SC') and " + PT_Exc_Calidad + " ORDER BY OP DESC"
                Else
                    Sentencia = "Select " + SentenciaSacos + " AS SACOSTOT," + SentenciaPeso + " AS PESOTOT,* from EMPAQUE where RECEMP=0 and RECCAL=0 and " + CampoRecProd +
                       " and MAQUINA<100 and FINALIZADO='S' and PESOREPROCESO=0 and (" + SentenciaPeso + ")<>0 and " + PT_Exc_Calidad + " and  DESTINO='" + Ubicacion + "' ORDER BY OP DESC"
                End If
            End If
            'Si el proceso es ALMACEN
            If Proceso = "ALMACEN" Then
                'Si hay recepcion de empaque en calidad se pone un filtro adicional
                Dim CampoRecCal As String = "RecCal="
                If RBProceso2.Enabled Then
                    CampoRecCal += "1"
                Else
                    CampoRecCal += "0"
                End If


                If Ubicacion = "ZR" Then
                    Sentencia = "Select (SacosNC+Reproceso)*-1 as SACOSTOT,(SacosNC+Reproceso)*presKg + PESO AS PESOTOT,* from EMPAQUE where RECREPROCESO=0 and " + CampoRecCal +
                            " and FINALIZADO='S' and MAQUINA<100 and (DESTINO2='ZR' OR DESTINO='ZR')  and " + PT_Exc_Almacen + " ORDER BY OP DESC"
                Else
                    'Sentencia = "Select " + SentenciaSacos + " AS SACOSTOT," + SentenciaPeso + " AS PESOTOT,* from EMPAQUE where RECEMP=1 and " + CampoRecCal +
                    '" and FINALIZADO='S' and MAQUINA<100 and ((" + SentenciaSacos + ")<>0 or PesoReproceso>0) and " + PT_Exc_Almacen + " And DESTINO ='" + Ubicacion + "'  ORDER BY OP DESC"
                    Sentencia = "Select " + SentenciaSacos + " AS SACOSTOT," + SentenciaPeso + " AS PESOTOT,* from EMPAQUE where RECEMP=0 and " + CampoRecCal +
                           " and MAQUINA<100 and FINALIZADO='S' and (" + SentenciaPeso + ")<>0 and " + PT_Exc_Almacen + " and DESTINO ='" + Ubicacion + "'  ORDER BY OP DESC"
                End If

            End If

            DEmpaque.Open(Sentencia)
            AsignaDataGrid(DGEmpaque, DEmpaque.DataTable)

            If DEmpaque.Count > 0 Then
                DGEmpaque_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
                TSumSacos.Text = SumColumn(DGEmpaque, "sacostot")
            Else
                BCancelar_Click(Nothing, Nothing)
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(SCRecibePT.Controls, AccionTextBox.Limpiar)
            TUbicacion.Text=""
            'BAceptar.Enabled = False
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEmpaque_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpaque.CellClick
        Dim Cont As String
        Try

            If DGEmpaque.CurrentRow Is Nothing Then Return
            If DGEmpaque.RowCount = 0 Then Return
            If e Is Nothing Then Return

            If DGEmpaque.Columns(e.ColumnIndex).Name.ToUpper.Contains("COLACEPTAR") Then
                DGEmpaque.ReadOnly = False
            Else
                DGEmpaque.ReadOnly = True
            End If

            Cont = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("CONT").Value.ToString

            DEmpaque.Find("CONT=" + Cont.Trim)

            If DEmpaque.EOF Then Exit Sub

            TOPEmp.Text = DEmpaque.RecordSet("OP")
            TCodProd.Text = DEmpaque.RecordSet("CODPROD")
            TNomProd.Text = DEmpaque.RecordSet("NOMPROD")
            TSacos.Text = DEmpaque.RecordSet("SACOSTOT")
            TFechaUEmp.Text = DEmpaque.RecordSet("FechaFin")
            TPeso.Text = DEmpaque.RecordSet("Pesotot")
            TBodega.Text = DEmpaque.RecordSet("Destino")
            TDetalle.Text = DEmpaque.RecordSet("detalle")
            TFechaRecProd.Text = DEmpaque.RecordSet("FechaRecProd")
            TFechaRecCal.Text = DEmpaque.RecordSet("FechaRecCal")
            TUsuarioRecCal.Text = DEmpaque.RecordSet("UsuarioRecCal")
            TUsuarioRecProd.Text = DEmpaque.RecordSet("UsuarioRecProd")

            DOPs.Open("Select * from OPs where OP=" + TOPEmp.Text.Trim)

            If DOPs.Count > 0 Then
                TObsAlmacen.Text = DOPs.RecordSet("ObservAlmacen")
                TObsCalidad.Text = DOPs.RecordSet("ObservCalidad")
                TObsProduccion.Text = DOPs.RecordSet("ObservProduccion")
            End If



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        Dim Cont As String = ""
        Dim Sacos As String = ""
        Dim CodProd As String = ""
        Dim OP As String = ""
        Dim Ubicacion As String = ""
        Try



            'Realizamos un ciclo para recorrer todos los registros que esten chequeados

            BAceptar.Enabled = False

            For Each Fila As DataGridViewRow In DGEmpaque.Rows

                If Fila.Cells("ColAceptar_NI_").Value = False Then Continue For

                Cont = Fila.Cells("CONT").Value.ToString
                Sacos = Fila.Cells("SACOSTOT").Value.ToString
                OP = Fila.Cells("OP").Value.ToString
                Ubicacion = Fila.Cells("DESTINO").Value.ToString



                DEmpaque.Open("Select * from EMPAQUE where CONT=" + Cont.Trim)

                If DEmpaque.Count > 0 Then

                    'Se valida desde que proceso se esta aceptando el empaque

                    If DEmpaque.RecordSet("DESTINO") = "ZR" Or DEmpaque.RecordSet("DESTINO2") = "ZR" And DEmpaque.RecordSet("RecReproceso") = False Then

                        If Proceso = "PRODUCCION" Then
                            DEmpaque.RecordSet("RecProd") = True
                            DEmpaque.RecordSet("UsuarioRecProd") = UsuarioPrincipal
                            DEmpaque.RecordSet("FechaRecProd") = FechaC()
                        End If

                        If Proceso = "ALMACEN" Then
                            DEmpaque.RecordSet("FECHARECREPROC") = FechaC()
                            DEmpaque.RecordSet("FECHAREC") = FechaC()
                            DEmpaque.RecordSet("RecReproceso") = True
                            DEmpaque.RecordSet("USURECREPROC") = UsuarioPrincipal
                            DEmpaque.RecordSet("FECHAREC") = FechaC()
                            DEmpaque.RecordSet("RecEmp") = True
                            DEmpaque.RecordSet("UsuarioRec") = UsuarioPrincipal
                            DEmpaque.RecordSet("Ubicacion") = TUbicacion.Text
                        End If

                        If Proceso = "CALIDAD" Then
                            DEmpaque.RecordSet("RecCal") = True
                            DEmpaque.RecordSet("UsuarioRecCal") = UsuarioPrincipal
                            DEmpaque.RecordSet("FechaRecCal") = FechaC()
                        End If

                        DEmpaque.Update(Me)
                    Else

                        If Proceso = "PRODUCCION" Then
                            DEmpaque.RecordSet("RecProd") = True
                            DEmpaque.RecordSet("UsuarioRecProd") = UsuarioPrincipal
                            DEmpaque.RecordSet("FechaRecProd") = FechaC()
                        End If

                        If Proceso = "ALMACEN" Then
                            DEmpaque.RecordSet("FECHAREC") = FechaC()
                            DEmpaque.RecordSet("RecEmp") = True
                            DEmpaque.RecordSet("UsuarioRec") = UsuarioPrincipal
                        End If

                        If Proceso = "CALIDAD" Then
                            DEmpaque.RecordSet("RecCal") = True
                            DEmpaque.RecordSet("UsuarioRecCal") = UsuarioPrincipal
                            DEmpaque.RecordSet("FechaRecCal") = FechaC()
                        End If

                        DEmpaque.Update(Me)

                        'Se ingresa al inventario de PT solo si es proceso ALMACEN
                        If Proceso = "ALMACEN" Then
                            CodProd = Fila.Cells("CODPROD").Value.ToString

                            'Se revisa si hay codigo de producto2 en la tabla de empaque para hacer el registro de inventario con este codigo

                            If DEmpaque.RecordSet("CODPROD2") <> "-" Then
                                CodProd = DEmpaque.RecordSet("CODPROD2")
                            End If

                            'Inventario(CodProd, Eval(TSacos.Text), TipoInv.CHRONOS, TOPEmp.Text, DetOperacion.ENPT, TBodega.Text, "-", Eval(TSacos.Text), , , , , Usuario)

                            Dim Invent As New DescInvent

                            With Invent
                                .CodInt = CodProd
                                .Cantidad = Sacos
                                .TipoInv = DescInvent.TipoInvent.CHRONOS
                                .Lote = OP
                                .Detalle = DetOperacion.ENPT
                                .Ubicacion = Ubicacion
                                .Unds = Sacos
                                .Usuario = UsuarioPrincipal
                                .Inventario()
                            End With
                        End If
                    End If

                    DOPs.Open("Select * from OPS where OP='" + OP + "'")

                    If DOPs.Count = 0 Then Return

                    If TObservProceso.Text <> "" Then
                        'variable para almacenar las observaciones que estan en BD y evitar registrar la misma observación si se tienen varios registros de la misma OP
                        'Dim txtObs = DOPs.RecordSet("XXX").ToString
                        Select Case Proceso
                            Case "ALMACEN"
                                Dim txtObs = DOPs.RecordSet("ObservAlmacen").ToString
                                If txtObs.Contains(TObservProceso.Text) Then Continue For
                                DOPs.RecordSet("ObservAlmacen") = CLeft(DOPs.RecordSet("ObservAlmacen") + " - " + LimpiarCadena(TObservProceso.Text), 250)
                            Case "CALIDAD"
                                Dim txtObs = DOPs.RecordSet("ObservCalidad").ToString
                                If txtObs.Contains(TObservProceso.Text) Then Continue For
                                DOPs.RecordSet("ObservCalidad") = CLeft(DOPs.RecordSet("ObservCalidad") + LimpiarCadena(TObservProceso.Text), 250)
                            Case "PRODUCCION"
                                Dim txtObs = DOPs.RecordSet("ObservProduccion").ToString
                                If txtObs.Contains(TObservProceso.Text) Then Continue For
                                DOPs.RecordSet("ObservProduccion") = CLeft(DOPs.RecordSet("ObservProduccion") + LimpiarCadena(TObservProceso.Text), 250)
                        End Select

                        DOPs.Update(Me)

                    End If

                End If

            Next

            BCancelar_Click(Nothing, Nothing)
            FValidaProceso()
            BActualizar_Click(Nothing, Nothing)

            DGEmpaque_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    'Private Sub FRefrescaDG_Click(sender As Object, e As EventArgs) Handles FRefrescaDG.Click
    '    Try
    '        DEmpaque.Open(Sentencia)
    '        AsignaDataGrid(DGEmpaque, DEmpaque.DataTable)
    '        TSumSacos.Text = SumColumn(DGEmpaque, "sacostot")

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                'FRefrescaDG_Click(Nothing, Nothing)
                BActualizar_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            BusquedaDG(DGEmpaque, DEmpaque.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                Exit Sub
            End If

            DGEmpaque_CellClick(Nothing, Nothing)
            TSumSacos.Text = SumColumn(DGEmpaque, "sacostot")
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub



    Private Sub ChAceptados_CheckedChanged(sender As Object, e As EventArgs) Handles ChAceptados.CheckedChanged
        Try
            If ChAceptados.Checked Then

                For Each Fila As DataGridViewRow In DGEmpaque.Rows
                    If Fila.Cells("ColAceptar_NI_").Value Then
                    Else
                        DGEmpaque.Rows(Fila.Index).Visible = False
                    End If
                Next

                TSumSacos.Text = SumColumn(DGEmpaque, "SacosTot")
            Else
                'FRefrescaDG_Click(Nothing, Nothing)
                BActualizar_Click(Nothing, Nothing)
                DGEmpaque_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub RBProceso_Click(sender As Object, e As EventArgs) Handles RBProceso1.Click, RBProceso2.Click, RBProceso3.Click
        Try
            Dim RB As RadioButton = CType(sender, RadioButton)
            Dim Index = RBProceso.Index(RB)

            DGEmpaque.Rows.Clear()

            If Index = 1 Then Proceso = "PRODUCCION"
            If Index = 2 Then Proceso = "CALIDAD"
            If Index = 3 Then Proceso = "ALMACEN"

            BAceptar.Enabled = False

            FValidaProceso()

            RBUbicacion(1).Checked = True
            RBUbicacion_Click(RBUbicacion(1), Nothing)

            Dim ListadoRB As New List(Of RadioButton) 'Todos los checkbox serán considerados como un item de ChkLst
            ListadoRB.AddRange(Me.GBFiltro.Controls.OfType(Of RadioButton)) 'Añadimos todos los checkboxes al ChkLst

            'Si se está en proceso ALMACEN, no se debe recibir GRANEL
            If Index = 3 Then
                For I As Integer = 0 To ListadoRB.Count - 1
                    If ListadoRB(I).Text.Contains("GRANEL") Then ListadoRB(I).Enabled = False
                Next (I)
            Else
                For I As Integer = 0 To ListadoRB.Count - 1
                    ListadoRB(I).Enabled = True
                Next (I)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub ChAceptarSel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChAceptarSel.CheckedChanged
        For Each Fila As DataGridViewRow In DGEmpaque.Rows
            If Not Fila.Selected Then Continue For
            Fila.Cells("ColAceptar_NI_").Value = ChAceptarSel.Checked
        Next
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub


    Private Sub mnModCodProd2Emp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnModCodProd2Emp.Click
        Try

            Dim Cont As Int32
            If DGEmpaque.CurrentRow Is Nothing Then Return
            If DGEmpaque.RowCount = 0 Then Return

            Cont = DGEmpaque.Rows(DGEmpaque.CurrentRow.Index).Cells("CONT").Value.ToString

            DEmpaque.Find("CONT=" + Cont.ToString)

            If DEmpaque.EOF Then Exit Sub


            RespInput = DEmpaque.RecordSet("CODPROD2").ToString
            If InputBox.InputBox("Modificación de registro de empaque", "Ingrese el nuevo Código de producto:", RespInput) = DialogResult.Cancel Then Return

            If RespInput.Trim = "" Then Return

            DEmpaque.RecordSet("CODPROD2") = RespInput
            DEmpaque.Update(Me)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)
            'FRefrescaDG_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub RecibePT_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DEmpaque.Open(Sentencia)
            AsignaDataGrid(DGEmpaque, DEmpaque.DataTable)
            TSumSacos.Text = SumColumn(DGEmpaque, "sacostot")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FValidaProceso()
        Try
            'Se valida si el area seleccionada tiene permiso para aceptar el registro
            Select Case Proceso
                Case "PRODUCCION"
                    If ValidaPermiso("RecibeEmpaqueProduccion") Then BAceptar.Enabled = True
                Case "CALIDAD"
                    If ValidaPermiso("Calidad") Then BAceptar.Enabled = True
                Case "ALMACEN"
                    If ValidaPermiso("RecibeEmpaqueAlmacen") Then BAceptar.Enabled = True
            End Select

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Class