Imports ClassLibrary

Public Class ProgEmpaque

    Private DOPs As AdoSQL
    Private DBaches As AdoSQL
    Private DEmpaque As AdoSQL
    Private DArt As AdoSQL
    Private DProgEmpaque As AdoSQL
    Private DTolvas As AdoSQL
    Private DVarios As AdoSQL
    Private VerificarContCruzada As ContCruzadaClase


    Private BSubirSec As ArrayControles(Of Button)
    Private BBajarSec As ArrayControles(Of Button)
    Private BEliminarSec As ArrayControles(Of Button)
    Private BModificarSec As ArrayControles(Of Button)
    Private FRefrescaDG As ArrayControles(Of Button)
    Private BImprimir As ArrayControles(Of Button)
    Private DGProgEmp As ArrayControles(Of DataGridView)




    Private Sub ProgEmpaque_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            DOPs = New AdoSQL("OPs")
            DBaches = New AdoSQL("Baches")
            DEmpaque = New AdoSQL("Empaque")
            DArt = New AdoSQL("Articulos")
            DProgEmpaque = New AdoSQL("ProgEmpaque")
            DTolvas = New AdoSQL("Tolvas")
            DVarios = New AdoSQL("Varios")

            BSubirSec = New ArrayControles(Of Button)("BSubirSec", Me)
            BBajarSec = New ArrayControles(Of Button)("BBajarSec", Me)
            BEliminarSec = New ArrayControles(Of Button)("BEliminarSec", Me)
            BModificarSec = New ArrayControles(Of Button)("BModificarSec", Me)
            BImprimir = New ArrayControles(Of Button)("BImprimir", Me)
            FRefrescaDG = New ArrayControles(Of Button)("FRefrescaDG", Me)
            DGProgEmp = New ArrayControles(Of DataGridView)("DGProgEmp", Me)



            VerificarContCruzada = New ContCruzadaClase

            'Si el campo META>300 quiere decir que la op la programaron para empacar una MP pero necesitamos
            'que aparezca en la planilla para porder quitar el control del sackoff

            DOPs.Open("select * from OPS where FINPLANILLA<>'S' or (META>300 and FINPLANILLA<>'S')  order by OP")

            DGOPs.AutoGenerateColumns = False
            DGOPs.DataSource = DOPs.DataTable

            If DGOPs.RowCount > 0 Then DGOPs_CellClick(Nothing, Nothing)

            For i = 1 To 3
                FRefrescaDG_Click(FRefrescaDG(i), Nothing)
            Next


            DVarios.Open("Update PROGEMPAQUE SET FINALIZADO='S' where FECHACREACION<'" + Format(DateAdd(DateInterval.Day, -1, Now), "yyyy/MM/dd 00:00") + "'")



        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGOPs_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGOPs.CellClick
        Try

            Dim OP As String = ""
            If DGOPs.CurrentRow Is Nothing Then Return
            If DGOPs.RowCount = 0 Then Return
            If e Is Nothing Then Return

            OP = DGOPs.Rows(DGOPs.CurrentRow.Index).DataBoundItem("OP").ToString
            FTraeDatosOP(OP)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(sender As System.Object, e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BIncluirProg_Click(sender As System.Object, e As System.EventArgs) Handles BIncluirProg.Click
        Try

            Dim Maquina As Int16 = (CBMaquina.Text)

            If Val(TOPs.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "OP no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If


            If Val(CBMaquina.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Máquina no válida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            DOPs.Open("Select * from OPS where OP='" + TOPs.Text + "'")

            If DOPs.Count = 0 Then Return

            If Not DOPs.RecordSet("SinControlSackOff") Then
                If Val(TMetaParcial.Text) + Val(TSacosProg.Text) > Val(TMetaTotal.Text) * 1.015 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Cantidad sacos meta supera disponibilidad de sacos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            End If

            Dim FilaActual As Int16 = 0
            Dim IDAct As Int16 = 0
            Dim AuxIDAct As Int16 = 0
            Dim AuxIDAnt As Int16 = 0
            Dim IDAnt As Int16 = 0
            Dim SecActual As Int16 = 0
            Dim SecDestino As Int16 = 0
            Dim IDDestino As Int16 = 0
            Dim NomProdAct As String = ""
            Dim NomProdAnt As String = ""


            If DGProgEmp(Maquina).Rows.Count = 0 Then GoTo CrearRegistro

            'If DGProgEmp(Maquina).CurrentRow Is Nothing Then Return

            'Se guardan la secuencia actual y la de destino

            Dim DRActual As DataRow = CType(DGProgEmp(Maquina).Rows(DGProgEmp(Maquina).Rows.Count - 1).DataBoundItem, DataRowView).Row
            FilaActual = DGProgEmp(Maquina).Rows.Count - 1



            AuxIDAct = DRActual("ID")
            SecActual = DRActual("SECUENCIA")

            'Se tienen que hacer 2 validaciones o etapas

            'Primera Etapa

            'evaluar fila actual es la ID Anterior
            'y la fila actual - 1 es la ID Actual

            IDAnt = DGProgEmp(Maquina).Rows(FilaActual).DataBoundItem("ID").ToString
            IDAct = 0
            NomProdAnt = DGProgEmp(Maquina).Rows(FilaActual).DataBoundItem("NOMPROD").ToString
            NomProdAct = TNomProd.Text

            If EvaluaContCruzada(IDAct, IDAnt) = "S" And NomProdAct <> NomProdAnt Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                Return
            Else

                If FilaActual = DGProgEmp(Maquina).Rows.Count - 1 Then GoTo CrearRegistro

                'Segunta etapa

                'evaluar fila actual - 1 posiciones es la ID Anterior
                'y la fila actual + 1 es la ID Actual

                IDAnt = 0
                IDAct = DGProgEmp(Maquina).Rows(FilaActual + 1).DataBoundItem("ID").ToString
                NomProdAnt = TNomProd.Text
                NomProdAct = DGProgEmp(Maquina).Rows(FilaActual + 1).DataBoundItem("NOMPROD").ToString

                If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ' MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                    Return
                End If
            End If

CrearRegistro:

            Dim Lote As String = ""

            'Se arma un lote automatico con la op de dosificación
            'El lote seria numero dia semana-numero semana año - OP Mayores

            Lote += Weekday(Now).ToString
            ' Lote += "-"
            Lote += DatePart(DateInterval.WeekOfYear, Now).ToString
            Lote += "-"
            Lote += TOPs.Text

            DProgEmpaque.Open("Select * from PROGEMPAQUE where ID=0")

            DProgEmpaque.AddNew()

            DProgEmpaque.RecordSet("OP") = TOPs.Text
            DProgEmpaque.RecordSet("CODPROD") = TCodProd.Text
            DProgEmpaque.RecordSet("NOMPROD") = TNomProd.Text
            DProgEmpaque.RecordSet("METATOT") = Val(TMetaTotal.Text)
            DProgEmpaque.RecordSet("SACOSEMP") = Val(TSacosEmp.Text)
            DProgEmpaque.RecordSet("SACOSDISP") = Val(TSacosDisp.Text)
            DProgEmpaque.RecordSet("METAPARC") = Val(TMetaParcial.Text)
            DProgEmpaque.RecordSet("FECHACREACION") = FechaC()
            DProgEmpaque.RecordSet("MAQUINA") = Maquina
            'DProgEmpaque.RecordSet("TOLVA") = Val(CBOrigen.Text)
            DProgEmpaque.RecordSet("NOMTOLVA") = CBOrigen.Text
            DProgEmpaque.RecordSet("LOTE") = Lote
            DProgEmpaque.RecordSet("SECUENCIA") = SecActual + 1

            DProgEmpaque.Update(Me)

            BCancelar_Click(Nothing, Nothing)


            FRefrescaDG_Click(FRefrescaDG(Maquina), Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDG_Click(sender As System.Object, e As System.EventArgs) Handles FRefrescaDG1.Click, FRefrescaDG2.Click, FRefrescaDG3.Click
        Try

            If FRefrescaDG1 Is Nothing Then Return
            Dim Index As Int32 = FRefrescaDG.Index(CType(sender, Button))

            DProgEmpaque.Open("Select * from PROGEMPAQUE where FINALIZADO<>'S' and MAQUINA=" + Index.ToString + " AND FECHACREACION>'" + Format(DateAdd(DateInterval.Day, -1, Now), "yyyy/MM/dd 00:00") + "' order by secuencia")

            'Actualizamos la secuencia 
            Dim Sec As Int16 = 1
            For Each Fila As DataRow In DProgEmpaque.Rows
                Fila("SECUENCIA") = Sec
                Sec += 1
                DProgEmpaque.Update(Me)
            Next

            DProgEmpaque.Refresh()


            DGProgEmp(Index).AutoGenerateColumns = False
            DGProgEmp(Index).DataSource = DProgEmpaque.DataTable


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FTraeDatosOP(ByVal OP As String)
        Try
            Dim PresKg As Single = 0
            Dim PesoTotal As Single = 0

            DOPs.Open("Select * from OPS where OP='" + OP + "' AND FINPLANILLA<>'S'")

            If DOPs.Count = 0 Then Return

            TOPs.Text = OP
            TCodProd.Text = DOPs.RecordSet("CODPROD")
            TNomProd.Text = DOPs.RecordSet("NOMPROD")

            DArt.Open("Select PRESKG FROM ARTICULOS where TIPO='PT' and CODINT='" + TCodProd.Text + "'")

            If DArt.Count > 0 Then PresKg = DArt.RecordSet("PRESKG")

            If PresKg = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, "Presentación de saco"), vbInformation)
                Return
            End If

            DBaches.Open("select sum(PESOREAL) as PESOREAL from BACHES where OP='" + OP + "'")
            TMetaTotal.Text = 0
            If DBaches.Count AndAlso Not IsDBNull(DBaches.RecordSet("PESOREAL")) And PresKg > 0 Then
                TMetaTotal.Text = CInt(DBaches.RecordSet("PESOREAL") / PresKg)
            End If

            DEmpaque.Open("select sum(Peso+PesoAjuste+Residuo+(Reproceso+SacosNC)*PresKg) as PesoTot from EMPAQUE where MAQUINA<100 and OP='" + OP + "'")
            TSacosEmp.Text = 0
            If DEmpaque.Count AndAlso Not IsDBNull(DEmpaque.RecordSet("PESOTOT")) And PresKg > 0 Then
                TSacosEmp.Text = CInt(DEmpaque.RecordSet("PESOTOT") / PresKg)
            End If

            'Se revisa el meta programado de la OP para realizar una validación de los sacos ya programados

            DVarios.Open("Select sum(METAPARC) as METAPARC from PROGEMPAQUE where FINALIZADO<>'S' and OP='" + TOPs.Text + "'")

            TSacosProg.Text = 0
            If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("METAPARC")) Then
                TSacosProg.Text = DVarios.RecordSet("METAPARC")
            End If

            TSacosDisp.Text = Val(TMetaTotal.Text) - Val(TSacosEmp.Text) - Val(TSacosProg.Text)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TOPs_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TOPs.KeyUp
        Try

            If e.KeyCode = Keys.Back Then
                TNomProd.Text = ""
                TCodProd.Text = ""
                TSacosDisp.Text = 0
                TMetaParcial.Text = 0
                TSacosEmp.Text = 0
                LimpiarCB()
            End If

            If Val(TOPs.Text) = 0 Then
                BCancelar_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode <> Keys.Enter Then Return

            FTraeDatosOP(TOPs.Text)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BCancelar.Click
        Try
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
            LimpiarCB()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub LimpiarCB()
        CBMaquina.Items.Add("")
        CBMaquina.Text = ""
        CBMaquina.Items.Remove("")
        CBOrigen.Items.Add("")
        CBOrigen.Text = ""
        CBOrigen.Items.Remove("")
    End Sub

    Private Function EvaluaContCruzada(ByVal IDAct As Int32, ByVal IDAnt As Int32)

        Try
            Dim OPAct As String = ""
            Dim OPAnt As String = ""

            EvaluaContCruzada = "S"

            'Si el ID>0 quiere decir que se esta reorganizando la secuencia
            If IDAct > 0 Then
                DProgEmpaque.Open("Select * from PROGEMPAQUE where ID=" + IDAct.ToString)
                If DProgEmpaque.Count Then
                    OPAct = DProgEmpaque.RecordSet("OP")
                End If
            Else
                'Se toma la OP del TOPs
                OPAct = TOPs.Text
            End If

            If IDAnt > 0 Then
                DProgEmpaque.Open("Select * from PROGEMPAQUE where ID=" + IDAnt.ToString)
                If DProgEmpaque.Count Then
                    OPAnt = DProgEmpaque.RecordSet("OP")
                End If
            Else
                OPAnt = TOPs.Text
            End If

            VerificarContCruzada.OP = OPAct
            VerificarContCruzada.OPAnt = OPAnt

            EvaluaContCruzada = VerificarContCruzada.ContCruzada()

            Return EvaluaContCruzada

        Catch ex As Exception
            EvaluaContCruzada = "S"
            Return EvaluaContCruzada
        End Try

    End Function

    Private Sub BSubirSec_Click(sender As System.Object, e As System.EventArgs) Handles BSubirSec1.Click, BSubirSec2.Click, BSubirSec3.Click
        Try
            If BSubirSec Is Nothing Then Return
            Dim Index As Int32 = BSubirSec.Index(CType(sender, Button))

            Dim FilaActual As Int16 = 0
            Dim IDAct As Int16 = 0
            Dim AuxIDAct As Int16 = 0
            Dim AuxIDAnt As Int16 = 0
            Dim IDAnt As Int16 = 0
            Dim SecActual As Int16 = 0
            Dim SecDestino As Int16 = 0
            Dim IDDestino As Int16 = 0
            Dim NomProdAct As String = ""
            Dim NomProdAnt As String = ""



            'Se guardan la secuencia actual y la de destino

            Dim DRActual As DataRow = CType(DGProgEmp(Index).CurrentRow.DataBoundItem, DataRowView).Row
            FilaActual = DGProgEmp(Index).CurrentRow.Index

            Dim DRDestino As DataRow = CType(DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem, DataRowView).Row

            AuxIDAct = DRActual("ID")
            SecActual = DRActual("SECUENCIA")
            SecDestino = DRDestino("SECUENCIA")
            IDDestino = DRDestino("ID")

            'Si es la primera fila no hace nada
            If FilaActual - 1 < 0 Then Return

            'Se tienen que hacer 3 validaciones o etapas

            'Primera Etapa

            'evaluar fila actual es la ID Anterior
            'y la fila actual - 1 es la ID Actual

            IDAnt = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("ID").ToString
            IDAct = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("ID").ToString
            NomProdAnt = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("NOMPROD").ToString
            NomProdAct = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("NOMPROD").ToString

            If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ' MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                Return
            Else
                'Segunta etapa

                'evaluar fila actual - 1 posiciones es la ID Anterior
                'y la fila actual + 1 es la ID Actual

                If FilaActual + 1 > DGProgEmp(Index).Rows.Count - 1 Then GoTo TerceraEtapa

                IDAnt = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("ID").ToString
                IDAct = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("ID").ToString
                NomProdAnt = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("NOMPROD").ToString
                NomProdAct = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("NOMPROD").ToString

                If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'sgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                    Return
                Else
TerceraEtapa:
                    'Si se cumple esta condicion no se evalua la tercera etapa
                    If FilaActual - 2 < 0 Then
                    Else
                        'Se pasa a la tercera etapa de validación
                        'evaluar fila actual - 2 posiciones es la ID Anterior
                        'y la fila actual es la ID Actual

                        IDAnt = DGProgEmp(Index).Rows(FilaActual - 2).DataBoundItem("ID").ToString
                        IDAct = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("ID").ToString
                        NomProdAnt = DGProgEmp(Index).Rows(FilaActual - 2).DataBoundItem("NOMPROD").ToString
                        NomProdAct = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("NOMPROD").ToString

                        If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                            MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            'MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                            Return
                        End If
                    End If
                End If
            End If

            DVarios.Open("select * from PROGEMPAQUE where ID=" + AuxIDAct.ToString)

            If DVarios.Count > 0 Then
                DVarios.RecordSet("SECUENCIA") = SecDestino
                DVarios.Update(Me)
            End If


            DVarios.Open("select * from PROGEMPAQUE where ID=" + (IDDestino).ToString)

            If DVarios.Count > 0 Then
                DVarios.RecordSet("SECUENCIA") = SecActual
                DVarios.Update(Me)
            End If

            FRefrescaDG_Click(FRefrescaDG(Index), Nothing)

            'FSubeBajaSec_Click(-1)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBajarSec_Click(sender As System.Object, e As System.EventArgs) Handles BBajarSec1.Click, BBajarSec2.Click, BBajarSec3.Click

        If BBajarSec Is Nothing Then Return
        Dim Index As Int32 = BBajarSec.Index(CType(sender, Button))

        Dim FilaActual As Int16 = 0
        Dim IDAct As Int16 = 0
        Dim AuxIDAct As Int16 = 0
        Dim AuxIDAnt As Int16 = 0
        Dim IDAnt As Int16 = 0
        Dim SecActual As Int16 = 0
        Dim SecDestino As Int16 = 0
        Dim IDDestino As Int16 = 0
        Dim NomProdAct As String = ""
        Dim NomProdAnt As String = ""



        'Se guardan la secuencia actual y la de destino

        Dim DRActual As DataRow = CType(DGProgEmp(Index).CurrentRow.DataBoundItem, DataRowView).Row
        FilaActual = DGProgEmp(Index).CurrentRow.Index

        Dim DRDestino As DataRow = CType(DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem, DataRowView).Row

        AuxIDAct = DRActual("ID")
        SecActual = DRActual("SECUENCIA")
        SecDestino = DRDestino("SECUENCIA")
        IDDestino = DRDestino("ID")

        'Si es la ultima fila no hace nada
        If FilaActual + 1 > DGProgEmp(Index).RowCount - 1 Then Return

        'Se tienen que hacer 3 validaciones o etapas

        'Primera Etapa
        'evaluar fila actual + 1  es la ID Anterior
        'y la fila actual es la ID Actual

        IDAnt = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("ID").ToString
        IDAct = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("ID").ToString
        NomProdAnt = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("NOMPROD").ToString
        NomProdAct = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("NOMPROD").ToString

        If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
            MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
            Return
        Else
            'Se pasa a la segunda etapa de validación
            'evaluar fila actual - 1 posiciones es la ID Anterior
            'y la fila actual + 1 es la ID Actual

            IDAnt = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("ID").ToString
            IDAct = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("ID").ToString
            NomProdAnt = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("NOMPROD").ToString
            NomProdAct = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("NOMPROD").ToString

            If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                Return
            Else
                'Se pasa a la tercera etapa de validación
                'evaluar fila actual  es la ID Anterior
                'y la fila actual + 2 es la ID Actual

                'Si esta condición se cumple es porque llega al final de la tabla
                'entonces no se debe evaluar contaminacion cruzada
                If FilaActual + 2 > DGProgEmp(Index).Rows.Count - 1 Then
                Else
                    IDAnt = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("ID").ToString
                    IDAct = DGProgEmp(Index).Rows(FilaActual + 2).DataBoundItem("ID").ToString
                    NomProdAnt = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("NOMPROD").ToString
                    NomProdAct = DGProgEmp(Index).Rows(FilaActual + 2).DataBoundItem("NOMPROD").ToString

                    If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                        Return
                    End If
                End If
            End If
        End If

        DVarios.Open("select * from PROGEMPAQUE where ID=" + AuxIDAct.ToString)

        If DVarios.Count > 0 Then
            DVarios.RecordSet("SECUENCIA") = SecDestino
            DVarios.Update(Me)
        End If


        DVarios.Open("select * from PROGEMPAQUE where ID=" + (IDDestino).ToString)

        If DVarios.Count > 0 Then
            DVarios.RecordSet("SECUENCIA") = SecActual
            DVarios.Update(Me)
        End If

        FRefrescaDG_Click(FRefrescaDG(Index), Nothing)


        'FSubeBajaSec_Click(1)
    End Sub

    Private Sub BEliminarSec_Click(sender As System.Object, e As System.EventArgs) Handles BEliminarSec1.Click, BEliminarSec2.Click, BEliminarSec3.Click
        Try

            If BEliminarSec Is Nothing Then Return
            Dim Index As Int32 = BEliminarSec.Index(CType(sender, Button))

            Dim FilaActual As Int16 = 0
            Dim IDAct As Int16 = 0
            Dim AuxIDAct As Int16 = 0
            Dim AuxIDAnt As Int16 = 0
            Dim IDAnt As Int16 = 0
            Dim SecActual As Int16 = 0
            Dim SecDestino As Int16 = 0
            Dim IDDestino As Int16 = 0
            Dim NomProdAct As String = ""
            Dim NomProdAnt As String = ""

            If DGProgEmp(Index).Rows.Count = 0 Then Return

            'Se guardan la secuencia actual y la de destino

            Dim DRActual As DataRow = CType(DGProgEmp(Index).CurrentRow.DataBoundItem, DataRowView).Row
            FilaActual = DGProgEmp(Index).CurrentRow.Index



            AuxIDAct = DRActual("ID")
            SecActual = DRActual("SECUENCIA")


            If FilaActual = 0 Or FilaActual = DGProgEmp(Index).Rows.Count - 1 Then
                GoTo EliminarFila
            Else
                'Se revisa la contaminacion cruzada de la filaactual -1 y la filaactual +1

                IDAnt = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("ID").ToString
                IDAct = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("ID").ToString
                NomProdAnt = DGProgEmp(Index).Rows(FilaActual - 1).DataBoundItem("NOMPROD").ToString
                NomProdAct = DGProgEmp(Index).Rows(FilaActual + 1).DataBoundItem("NOMPROD").ToString

                If EvaluaContCruzada(IDAct, IDAnt) = "S" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'MsgBox("Contaminación Cruzada " + NomProdAnt + " restringe a " + NomProdAct, vbCritical)
                    Return
                End If
            End If

EliminarFila:

            DProgEmpaque.Open("update PROGEMPAQUE set FINALIZADO='S' where ID=" + AuxIDAct.ToString)
            FRefrescaDG_Click(FRefrescaDG(Index), Nothing)

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
            If ValidaPermiso("Reportes_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Reportes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BModificarSec_Click(sender As System.Object, e As System.EventArgs) Handles BModificarSec1.Click, BModificarSec2.Click, BModificarSec3.Click
        Try

            If BModificarSec Is Nothing Then Return
            Dim Index As Int32 = BModificarSec.Index(CType(sender, Button))

            If DGProgEmp(Index).CurrentRow Is Nothing Then Return

            Dim FilaActual As Int16 = DGProgEmp(Index).CurrentRow.Index

            Dim SecuenciaActual As Int16 = DGProgEmp(Index).Rows(FilaActual).DataBoundItem("SECUENCIA").ToString

            RespInput = ""
            InputBox.InputBox("Modificar Secuencia", "Ingrese el número de secuencia al que desea llevar el producto", RespInput)

            If Val(RespInput) = 0 Then Return

            Dim NuevaSecuencia As Int16 = Val(RespInput)
            Dim FilaNuevaSecuencia As Int16 = 0
            'Se ubica el index del datagrid donde la secuencia sea igual a la ingresada por el usuario

            For Each Fila As DataGridViewRow In DGProgEmp(Index).Rows
                If Fila.DataBoundItem("SECUENCIA") = NuevaSecuencia Then
                    FilaNuevaSecuencia = Fila.Index
                    Exit For
                End If
            Next

            'Cuando se tenga la fila, se guarda la secuencia 


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BImprimirProg_Click(sender As System.Object, e As System.EventArgs) Handles BImprimirProg.Click
        Try
            Dim RepSap As CrystalRep

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + FechaC() + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpProgEmp.rpt"
                .SelectionFormula = "{ProgEmpaque.Finalizado}<>'S' and {ProgEmpaque.Maquina}<>3"

                .PrintReport()
            End With

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir1_Click(sender As System.Object, e As System.EventArgs) Handles BImprimir1.Click, BImprimir2.Click, BImprimir3.Click
        Try

            If BImprimir Is Nothing Then Return
            Dim Index As Int32 = BImprimir.Index(CType(sender, Button))

            Dim RepSap As CrystalRep

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + FechaC() + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpProgEmp.rpt"
                .SelectionFormula = "{ProgEmpaque.Finalizado}<>'S' and {ProgEmpaque.MAQUINA}=" + Index.ToString

                .PrintReport()
            End With

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BIncluirProg_KeyUp(sender As Object, e As KeyEventArgs) Handles BIncluirProg.KeyUp
        If e.KeyCode <> Keys.Enter Then Return
        BIncluirProg_Click(Nothing, Nothing)
    End Sub

    Private Sub CBMaquina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBMaquina.SelectedIndexChanged
        Try
            If Val(CBMaquina.Text) = 0 Then Return
            DTolvas.Open("Select * from TOLVAS where PROCESO='EMPAQUE' and MAQUINA='E" + CBMaquina.Text + "'")
            LLenaComboBox(CBOrigen, DTolvas.DataTable, "NOMTOLVA")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class