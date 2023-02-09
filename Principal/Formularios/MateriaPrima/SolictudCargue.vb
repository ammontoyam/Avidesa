Option Explicit On

Imports System
Imports System.Data

Public Class SolictudCargue

    Private DRet As AdoSQL
    Private DTolvas As AdoSQL
    Private Fila As Integer
    Private DProgVaceo As AdoSQL
    Private DCortesMP As AdoSQL
    Private DConsultas As AdoSQL
    Private DArt As AdoSQL
    Private ContVaceo As Int32


    Private FormLoad As Boolean

    Private Sub SolictudCargue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            DRet = New AdoSQL("RETAQUE")
            DTolvas = New AdoSQL("TOLVAS")
            DProgVaceo = New AdoSQL("VACEO")
            DCortesMP = New AdoSQL("CORTESMP")
            DConsultas = New AdoSQL("CONSULTAS")
            DArt = New AdoSQL("ARTICULOS")




            TextNum(TTolva)
            TTolva.ReadOnly = True
            TLote.ReadOnly = True
            TCantidad.ReadOnly = True
            BAceptar.Enabled = False
            BCancelar.Enabled = False

            FormLoad = True
            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGSoliCargue_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSoliCargue.CellClick
        Try
            If DGSoliCargue.RowCount = 0 Then Return

            Dim Cont As String

            Cont = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

            DRet.Find("CONT=" + Cont)
            If DRet.EOF = True Then Return

            TTolva.Text = DRet.RecordSet("TOLVA")
            TCodMat.Text = DRet.RecordSet("CODMAT")
            TNomMat.Text = DRet.RecordSet("NOMMAT")
            TLote.Text = DRet.RecordSet("LOTE")
            TCantidad.Text = DRet.RecordSet("PESOMETA")


            Fila = DGSoliCargue.CurrentRow.Index



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            SolictudCargue_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TTolva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTolva.TextChanged
        Try
            If Eval(TTolva.Text) = 0 Then
                TLote.Text = ""
                Return
            End If

            DTolvas.Find("TOLVA=" + TTolva.Text)

            If DTolvas.EOF = True Then Return

            TCodMat.Text = DTolvas.RecordSet("CODINT")
            TNomMat.Text = DTolvas.RecordSet("NOMBRE")
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If Eval(TCodMat.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código de material"), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Trim(TNomMat.Text) = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " nombre de material"), MsgBoxStyle.Information)
                Exit Sub
            End If

            'If Trim(TLote.Text) = "" Then
            '    MsgBox("LOTE no válido", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            If Eval(TCantidad.Text) = 0 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " cantidad"), MsgBoxStyle.Information), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Eval(TCantidad.Text) > 32000 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " cantidad debe ser menor a 32000"), MsgBoxStyle.Information), MsgBoxStyle.Information)
                Exit Sub
            End If



            DRet.AddNew()

            If Funcion_ManejaPantallaVaceo Then
                ContVaceo = Val(ReadConfigVar("CONTVACEO")) + 1
                If ContVaceo > 65530 Then ContVaceo = 1
                DRet.RecordSet("CONTVACEO") = ContVaceo
            End If

            DRet.RecordSet("TOLVA") = Eval(TTolva.Text)
            DRet.RecordSet("CODMAT") = TCodMat.Text
            DRet.RecordSet("NOMMAT") = TNomMat.Text
            DRet.RecordSet("PESOMETA") = Eval(TCantidad.Text)
            DRet.RecordSet("LINEA") = 10

            DCortesMP.Open("select * from CORTESLOTE where ESTADO='A' and CODMAT='" + TCodMat.Text + "' and FINALIZADO<>'S'")
            If DCortesMP.Count > 0 Then
                DRet.RecordSet("LOTE") = DCortesMP.RecordSet("LOTE")
                DRet.RecordSet("PROMBULTOS") = DCortesMP.RecordSet("PesoProm")
            End If

            DRet.RecordSet("PRIORIDAD") = 1000

            DArt.Open("Select * from ARTICULOS where TIPO='MP' and CODINT='" + TCodMat.Text + "'")

            If DArt.Count > 0 Then
                DRet.RecordSet("LINEAINVENT") = DArt.RecordSet("LINEA")
            End If


            DRet.Update()

            WriteConfigVar("CONTVACEO", ContVaceo.ToString)

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            If DGSoliCargue.RowCount = 0 Then Return

            Dim Cont As String

            Cont = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

            RespInput = MsgBox(DevuelveEvento(CodEvento.BD_REGFINALIZAR), MsgBoxStyle.Information + vbYesNo)
            If RespInput = vbNo Then Exit Sub


            DRet.Find("CONT=" + Cont)
            If DRet.EOF = True Then Return

            DRet.RecordSet("STATUS") = 2
            DRet.Update()

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            TTolva.ReadOnly = False
            TLote.ReadOnly = False
            TCantidad.ReadOnly = False
            BAceptar.Enabled = True
            BCancelar.Enabled = True
            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Limpiar)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            DRet.Open("select * from RETAQUE where STATUS=0 order by PRIORIDAD ")

            DTolvas.Open("select * from TOLVAS WHERE PROCESO='DOSIFICACION' order by TOLVA")

            Dim Prioridad As Int32 = 1
            For Each RecordSet In DRet.Rows
                RecordSet("PRIORIDAD") = Prioridad
                Prioridad += 1
            Next
            DRet.Update()

            AsignaDataGrid(DGSoliCargue, DRet.DataTable)
            ' If DRet.Count > 0 Then DGSoliCargue_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBajar.Click
        Try

            Dim ContActual As String = ""
            Dim PrioActual As String = ""
            Dim ContDest As String = ""
            Dim PrioDest As String = ""
            Dim FilaActualCont As Integer
            Dim FilaDest As Integer = 0
            Dim indifila As Integer = 0
           
            If DGSoliCargue.Rows.Count = 0 Then Exit Sub
            FilaActualCont = DGSoliCargue.CurrentRow.Index

            indifila = DGSoliCargue.RowCount - 1
            If FilaActualCont + 1 > indifila Then Return

            ContActual = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString
           
            DRet.Find("CONT=" + ContActual)

            If Not DRet.EOF Then
                PrioActual = DRet.RecordSet("PRIORIDAD")
            End If

            DRet.Refresh()

            ContDest = DGSoliCargue.Rows(FilaActualCont + 1).Cells("CONT").Value.ToString
            DRet.Find("CONT=" + ContDest)
            If Not DRet.EOF Then
                PrioDest = DRet.RecordSet("PRIORIDAD")
            End If

            DRet.Refresh()
            DRet.Find("CONT=" + ContActual)

            If Not DRet.EOF Then
                DRet.RecordSet("PRIORIDAD") = PrioDest
                DRet.Update()
            End If

            DRet.Refresh()
            DRet.Find("CONT=" + ContDest)

            If Not DRet.EOF Then
                DRet.RecordSet("PRIORIDAD") = PrioActual
                DRet.Update()
            End If

            DRet.Open("select * from RETAQUE where STATUS=0 order by PRIORIDAD ")
            Dim Prioridad As Int32 = 1
            For Each RecordSet In DRet.Rows
                RecordSet("PRIORIDAD") = Prioridad
                Prioridad += 1
            Next
            DRet.Update()

            FilaDest = FilaActualCont + 1
            AsignaDataGrid(DGSoliCargue, DRet.DataTable)

            DGSoliCargue.Rows(FilaDest).Selected = True
            DGSoliCargue.FirstDisplayedScrollingRowIndex = FilaDest
            DGSoliCargue.CurrentCell = DGSoliCargue(0, FilaDest)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSubir.Click
        Try

            Dim ContActual As String = ""
            Dim PrioActual As String = ""
            Dim ContDest As String = ""
            Dim PrioDest As String = ""
            Dim FilaActualCont As Integer = 0
            Dim FilaDest As Integer = 0
            Dim indifila As Integer = 0

            If DGSoliCargue.Rows.Count = 0 Then Exit Sub
            FilaActualCont = DGSoliCargue.CurrentRow.Index


            If FilaActualCont - 1 < 0 Then Return

            ContActual = DGSoliCargue.Rows(DGSoliCargue.CurrentRow.Index).Cells("CONT").Value.ToString

            DRet.Find("CONT=" + ContActual)

            If Not DRet.EOF Then
                PrioActual = DRet.RecordSet("PRIORIDAD")
            End If

            DRet.Refresh()

            ContDest = DGSoliCargue.Rows(FilaActualCont - 1).Cells("CONT").Value.ToString
            DRet.Find("CONT=" + ContDest)
            If Not DRet.EOF Then
                PrioDest = DRet.RecordSet("PRIORIDAD")
            End If

            DRet.Refresh()
            DRet.Find("CONT=" + ContActual)

            If Not DRet.EOF Then
                DRet.RecordSet("PRIORIDAD") = PrioDest
                DRet.Update()
            End If

            DRet.Refresh()
            DRet.Find("CONT=" + ContDest)

            If Not DRet.EOF Then
                DRet.RecordSet("PRIORIDAD") = PrioActual
                DRet.Update()
            End If

            DRet.Open("select * from RETAQUE where STATUS=0 order by PRIORIDAD ")
            Dim Prioridad As Int32 = 1
            For Each RecordSet In DRet.Rows
                RecordSet("PRIORIDAD") = Prioridad
                Prioridad += 1
            Next
            DRet.Update()

            FilaDest = FilaActualCont - 1
            AsignaDataGrid(DGSoliCargue, DRet.DataTable)

            DGSoliCargue.Rows(FilaDest).Selected = True
            DGSoliCargue.FirstDisplayedScrollingRowIndex = FilaDest
            DGSoliCargue.CurrentCell = DGSoliCargue(0, FilaDest)


            ''SolictudCargue_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Me.Hide()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportar.Click
        Dim Lote As String = ""
        Dim PromSac As Single = 0
        Dim ValorAnt As Double = 0
        Dim Prioridad As Int16 = 0
        Try
            DRet.Open("select * from RETAQUE where STATUS=0 AND HABILITADO=0")

            If DRet.Count > 0 Then
                Resp = MsgBox("Se eliminarán todas las solicitudes de cargue inhabilitadas, desea continuar?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                If Resp = vbNo Then Return
            End If

            DProgVaceo.Open("Update RETAQUE set STATUS=2 where STATUS=0 and HABILITADO=0")


            DProgVaceo.Open("select * from CPROGVACEO order by FALTA desc")

            If DProgVaceo.Count = 0 Then Return

            For Each RecordVaceo As DataRow In DProgVaceo.Rows

                If RecordVaceo("FALTA") = 0 Then Continue For


                Lote = "-"
                PromSac = 0
                DCortesMP.Open("select * from CORTESLOTE where ESTADO='A' and CODMAT='" + RecordVaceo("CODMAT") + "' and FINALIZADO<>'S'")
                If DCortesMP.Count > 0 Then
                    Lote = DCortesMP.RecordSet("LOTE")
                    PromSac = DCortesMP.RecordSet("PesoProm")
                End If

                If ValorAnt = RecordVaceo("TOTAL") Then Continue For

                Prioridad += 1

                DRet.AddNew()
                DRet.RecordSet("TOLVA") = RecordVaceo("TOLVA")
                DRet.RecordSet("CODMAT") = RecordVaceo("CODMAT")
                DRet.RecordSet("NOMMAT") = RecordVaceo("NOMMAT")
                DRet.RecordSet("PESOMETA") = Format(RecordVaceo("TOTAL"), ".00")
                DRet.RecordSet("LOTE") = Lote
                DRet.RecordSet("PRIORIDAD") = Prioridad
                DRet.RecordSet("STATUS") = 0
                DRet.RecordSet("PROGRAMA") = Now.ToString("yyMMdd")
                DRet.RecordSet("PROMBULTOS") = PromSac
                DRet.RecordSet("TOTALTOLVA") = RecordVaceo("TOTALTOLVA")
                DRet.RecordSet("FALTA") = RecordVaceo("FALTA")
                If Funcion_ManejaPantallaVaceo Then
                    ContVaceo = Val(ReadConfigVar("CONTVACEO")) + 1
                    If ContVaceo > 65530 Then ContVaceo = 1
                    DRet.RecordSet("CONTVACEO") = ContVaceo
                    DRet.RecordSet("LINEA") = 10
                    WriteConfigVar("CONTVACEO", ContVaceo.ToString)
                End If

                DRet.Update()
                ValorAnt = RecordVaceo("TOTAL")
                Threading.Thread.Sleep(100)
            Next

            SolictudCargue_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGSoliCargue_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGSoliCargue.CellContentClick
        Try
            Dim Campo As String = _
             DGSoliCargue.Columns(e.ColumnIndex).Name
            Dim Cont As String = DGSoliCargue.Rows(e.RowIndex).Cells("CONT").Value.ToString

            ' Abort validation if cell is not VALOR column.
            If Not Campo.ToUpper.Equals("HABILITADO") Then Return
            If Convert.ToBoolean(DGSoliCargue.Rows(e.RowIndex).Cells("HABILITADO").Value) Then
                DGSoliCargue.Rows(e.RowIndex).Cells("HABILITADO").Value = False
            Else
                DGSoliCargue.Rows(e.RowIndex).Cells("HABILITADO").Value = True
            End If
            DRet.Find("CONT='" + Cont + "'")
            If DRet.EOF Then Return
            DRet.RecordSet(Campo) = DGSoliCargue.Rows(e.RowIndex).Cells("HABILITADO").Value
            DRet.Update()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BHabCargue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHabCargue.Click
        Try
            DRet.Refresh()

            For Each Record As DataRow In DRet.Rows
                Record("HABILITADO") = True
                DRet.Update()
            Next

            SolictudCargue_Load(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGSoliCargue_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGSoliCargue.CellFormatting
        Try
            DGSoliCargue.Rows(e.RowIndex).Cells("PESOMETA").Value = Format(Convert.ToDecimal(DGSoliCargue.Rows(e.RowIndex).Cells("PESOMETA").Value), "#,###.00")
            '    dataGridView2.Rows[e.RowIndex].Cells[2].Value=Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[2].Value)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BInhabilitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BInhabilitar.Click
        Try
            DRet.Refresh()

            For Each Record As DataRow In DRet.Rows
                Record("HABILITADO") = False
                DRet.Update()
            Next

            SolictudCargue_Load(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            TTolva.ReadOnly = True
            TLote.ReadOnly = False
            TCantidad.ReadOnly = False
            BAceptar.Enabled = True
            BCancelar.Enabled = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BImprimir.Click
        Dim RepSap As CrystalRep

        Try

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
                .ReportFileName = RutaRep + "rpprogvaceo.rpt"
                .PrintReport()
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodMat_TextChanged(sender As System.Object, e As System.EventArgs) Handles TCodMat.TextChanged
        Try

            If Val(TCodMat.Text) = 0 Or TLote.Text.Length > 0 Then Return

            DCortesMP.Open("select * from CORTESLOTE where ESTADO='A' and CODMAT='" + TCodMat.Text + "' and FINALIZADO<>'S'")
            If DCortesMP.Count > 0 Then
                TLote.Text = DCortesMP.RecordSet("LOTE")
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class