Imports System.IO
Imports ClassLibrary

Public Class ProgramaProd
    Private DProgProd As AdoSQL
    Private DConsultas As AdoSQL
    Private DArt As AdoSQL
    Private DVarios As AdoSQL
    Private DCEmpSacKoff As AdoSQL
    Private DCConsumosTot As AdoSQL
    Private DProds As AdoSQL
    Private DEmpSinRec As AdoSQL
    Private DConfigPantallas As AdoSQL
    Private Fila As Integer
    Private Campos() As String
    Private ActSec As String
    Private ActPedidos As Int16

    Private FormLoad As Boolean

    Private Sub ProgramaProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If FormLoad = True Then
                BActualizar_Click(Nothing, Nothing)
                Return
            End If

            DProgProd = New AdoSQL("PROGPROD")
            DConsultas = New AdoSQL("CONSULTAS")
            DArt = New AdoSQL("Articulos")
            DVarios = New AdoSQL("VARIOS")
            DCEmpSacKoff = New AdoSQL("CEMPA")
            DCConsumosTot = New AdoSQL("CCONS")
            DProds = New AdoSQL("PRODS")
            DEmpSinRec = New AdoSQL("EmpSinRec")
            DConfigPantallas = New AdoSQL("CONFIGPANTALLAS")

            DVarios.Open("select * from LINEASPROD where TIPO='LN'")
            LLenaComboBox(CLinea, DVarios.DataTable, "LINEA")
            DVarios.Open("select * from ESPECIES")
            LLenaComboBox(CEspecies.ComboBox, DVarios.DataTable, "NomEspecie")

            THoras.Text = 0
            TExist.Text = 0
            TEnProc.Text = 0
            TEmpSinRec.Text = 0
            TTotal.Text = 0

            DGProgProd.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGreen            'DGProgProd.EnableHeadersVisualStyles = True
            DGProgProd.EnableHeadersVisualStyles = False


            BActualizar_Click(Nothing, Nothing)

            Campos = {"CodInt@Cód.Int.", "Nombre@Nombre", "INCLUIRPROG@Incluir", "INVMIN@Negativos", "Linea@Máquina", "linea-incluirprog@Máq-Incluir"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DProgProd.DataTable)

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BLlenarDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLlenarDG.Click
        Try
            Dim i As Int32 = 0

            DProgProd.Refresh()
            DGProgProd.Rows.Clear()
            For Each RecorDProgProd As DataRow In DProgProd.Rows
                DGProgProd.Rows.Add()
                RefreshDG(DGProgProd, DGProgProd.Rows.Count - 1, RecorDProgProd)
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGProgProd_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGProgProd.CellContentClick
        ' Ojo este codigo debe ir para que te funcione al hacer click en el checkbox de la grilla
        If e.RowIndex < 0 Then Return
        Dim Campo As String = DGProgProd.Columns(e.ColumnIndex).Name
        Dim Cod As String = DGProgProd.Rows(e.RowIndex).Cells("CODINT").Value.ToString
        Dim Id As String = DGProgProd.Rows(e.RowIndex).Cells("ID").Value.ToString
        ' Abort validation if cell is not VALOR column.
        If Not Campo.ToUpper.Equals("INCLUIRPROG") Then Return
        If Convert.ToBoolean(DGProgProd.Rows(e.RowIndex).Cells("INCLUIRPROG").Value) Then
            DGProgProd.Rows(e.RowIndex).Cells("INCLUIRPROG").Value = False
        Else
            DGProgProd.Rows(e.RowIndex).Cells("INCLUIRPROG").Value = True
        End If
        DProgProd.Find("ID=" + Id)
        If DProgProd.EOF Then Return
        DProgProd.RecordSet(Campo) = DGProgProd.Rows(e.RowIndex).Cells("INCLUIRPROG").Value
        DProgProd.Update(Me)
    End Sub

    Private Sub DGProgProd_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGProgProd.CurrentCellChanged
        Try
            If DGProgProd.CurrentCell Is Nothing Then Return
            Dim Campo As String = DGProgProd.Columns(DGProgProd.CurrentCell.ColumnIndex).Name

            If CLinea.Visible = True Then CLinea.Visible = False
            If CTurno.Visible = True Then CTurno.Visible = False

            If Not Campo.ToUpper.Equals("LINEA") AndAlso Not Campo.ToUpper.Equals("TURNO") Then Return

            If Campo.ToUpper.Equals("LINEA") Then
                Dim a As Rectangle
                a = DGProgProd.GetCellDisplayRectangle(DGProgProd.CurrentCell.ColumnIndex, DGProgProd.CurrentCell.RowIndex, False)

                CLinea.Left = a.Location.X + DGProgProd.Location.X
                CLinea.Top = a.Location.Y + DGProgProd.Location.Y
                CLinea.Height = DGProgProd.CurrentCell.Size.Height
                CLinea.Width = DGProgProd.CurrentCell.Size.Width
                CLinea.Visible = True
                CLinea.DroppedDown = True
                Return
            End If
            If Campo.ToUpper.Equals("TURNO") Then
                'If DG.CurrentCellAddress.X <> DG.Columns("Cliente").Index Then Exit Sub
                Dim a As Rectangle
                a = DGProgProd.GetCellDisplayRectangle(DGProgProd.CurrentCell.ColumnIndex, DGProgProd.CurrentCell.RowIndex, False)

                CTurno.Left = a.Location.X + DGProgProd.Location.X
                CTurno.Top = a.Location.Y + DGProgProd.Location.Y
                CTurno.Height = DGProgProd.CurrentCell.Size.Height
                CTurno.Width = DGProgProd.CurrentCell.Size.Width
                CTurno.Visible = True
                CTurno.DroppedDown = True
                Return
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub CLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLinea.SelectedIndexChanged
        Try
            If DGProgProd.Columns(DGProgProd.CurrentCell.ColumnIndex).Name.ToUpper <> "LINEA" Then Exit Sub
            DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells(DGProgProd.CurrentCell.ColumnIndex).Value = CLinea.SelectedItem.ToString
            Dim Campo As String = "LINEA"
            Dim Cod As String = DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells("CODINT").Value.ToString
            Dim ID As String = DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells("ID").Value.ToString
            Dim Linea As String = DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells("LINEA").Value.ToString
            Dim TH As Single = 0
            Dim Maquina As String = ""
            Dim Proceso As String = ""

            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return

            DProds.Find("CODPROD='" + Cod + "'")
            If DProds.EOF = False Then DProgProd.RecordSet("TONBACHE") = DProds.RecordSet("TN")

            DProgProd.RecordSet(Campo) = CLinea.SelectedItem.ToString
            DProgProd.RecordSet("SECUENCIA") = DGProgProd.CurrentRow.Index + 1
            Select Case UCase(Linea)
                Case "PELET1"
                    Proceso = "PELETIZADO"
                    Maquina = 1
                Case "PELET2"
                    Proceso = "PELETIZADO"
                    Maquina = 2
                Case "PELET3"
                    Proceso = "PELETIZADO"
                    Maquina = 3
                Case "EXTRUDER1"
                    Proceso = "EXTRUDER"
                    Maquina = 1
                Case "EXTRUDER2"
                    Proceso = "EXTRUDER"
                    Maquina = 2
                Case "SALES"
                    Proceso = "SALES"
                    Maquina = 1
            End Select

            If Proceso <> "" Then
                DConfigPantallas.Find("PROCESO='" + Proceso + "'" + " and MAQUINA=" + Maquina)
                If Not DConfigPantallas.EOF Then TH = DConfigPantallas.RecordSet("PROMTONHORASPAGAS")
            End If

            DProgProd.RecordSet("TH") = TH
            DProgProd.Update(Me)
            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return
            RefreshDG(DGProgProd, DGProgProd.CurrentRow.Index, DProgProd.RecordSet)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CTurno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTurno.SelectedIndexChanged
        Try
            If DGProgProd.Columns(DGProgProd.CurrentCell.ColumnIndex).Name.ToUpper <> "TURNO" Then Exit Sub
            DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells(DGProgProd.CurrentCell.ColumnIndex).Value = CTurno.SelectedItem.ToString
            Dim Campo As String = "TURNO"
            Dim Cod As String = DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells("CODINT").Value.ToString
            Dim ID As String = DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells("ID").Value.ToString

            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return

            DProds.Find("CODPROD='" + Cod + "'")
            If DProds.EOF = False Then DProgProd.RecordSet("TONBACHE") = DProds.RecordSet("TN")

            DProgProd.RecordSet(Campo) = CTurno.SelectedItem.ToString
            DProgProd.RecordSet("SECUENCIA") = DGProgProd.CurrentRow.Index + 1
            DProgProd.Update(Me)
            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return
            RefreshDG(DGProgProd, DGProgProd.CurrentRow.Index, DProgProd.RecordSet)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGProgProd_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DGProgProd.CellValidating

        If DGProgProd.Rows(e.RowIndex).Cells("ID").Value Is Nothing Then Return

        Try
            Dim Campo As String =
            DGProgProd.Columns(e.ColumnIndex).Name
            Dim Cod As String = DGProgProd.Rows(e.RowIndex).Cells("CODINT").Value.ToString
            Dim ID As String = DGProgProd.Rows(e.RowIndex).Cells("ID").Value.ToString

            If DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "INVMIN" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "LINEA" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "LINEA" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "BACHES" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "TH" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "TURNO" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "OBSERVPROG" AndAlso
                DGProgProd.Columns(e.ColumnIndex).Name.ToUpper <> "ORDEN" Then
                Return
            End If

            ' e.ColumnIndex <> 11 AndAlso e.ColumnIndex <> 12 AndAlso e.ColumnIndex <> 13 AndAlso e.ColumnIndex <> 14 AndAlso e.ColumnIndex <> 17 Then Return
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return

            DProds.Find("CODPROD='" + Cod + "'")
            If DProds.EOF = False Then DProgProd.RecordSet("TONBACHE") = DProds.RecordSet("TN")

            DProgProd.RecordSet(Campo) = e.FormattedValue.ToString
            DProgProd.RecordSet("SECUENCIA") = e.RowIndex + 1
            DProgProd.Update()
            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return
            RefreshDG(DGProgProd, e.RowIndex, DProgProd.RecordSet)
            'BLlenarDG_Click(Nothing, Nothing)
            ' Abort validation if cell is not VALOR column.
            'If Not Campo.ToUpper.Equals("INVMIN") Then Return

            ' Confirm that the cell is not empty.
            'If (String.IsNullOrEmpty(e.FormattedValue.ToString())) Then
            '    DGProgProd.Rows(e.RowIndex).ErrorText = _
            '        "La cantidad del Material no puede estar vacia"
            '    e.Cancel = True
            'End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGProgProd_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGProgProd.CellEndEdit

        Try
            ' Clear the row error in case the user presses ESC.   
            DGProgProd.Rows(e.RowIndex).ErrorText = String.Empty

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Function ExistenciaTolvas(ByVal CodInt As String) As Double
        ' Dim DCEmpSacKoff As New AdoSQL("CEMPA")
        Dim Exist1, Exist2 As Double
        Dim SacosSinRec As Double = 0
        ExistenciaTolvas = 0

        DCEmpSacKoff.Find("CODPROD='" + CodInt.Trim + "'")
        If DCEmpSacKoff.EOF Then Exit Function
        If DCEmpSacKoff.Count AndAlso Not IsDBNull(DCEmpSacKoff.RecordSet("EXIST")) Then Exist1 = DCEmpSacKoff.RecordSet("EXIST")
        DCConsumosTot.Find("CODPROD='" + CodInt.Trim + "'")
        If DCConsumosTot.EOF Then Exit Function
        If DCConsumosTot.Count AndAlso Not IsDBNull(DCConsumosTot.RecordSet("EXIST")) Then Exist2 = DCConsumosTot.RecordSet("EXIST")
        'DEmpSinRec.Find("CODPROD='" + CodInt.Trim + "'")
        'If DEmpSinRec.Count AndAlso Not IsDBNull(DEmpSinRec.RecordSet("EXIST")) Then SacosSinRec = DEmpSinRec.RecordSet("EXIST")

        ExistenciaTolvas = Exist2 - Exist1 '+ SacosSinRec

    End Function

    Private Sub DGProgProd_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGProgProd.CellFormatting
        If e.RowIndex < 0 Then Return
        If DGProgProd.Rows(e.RowIndex).Cells("ID").Value Is Nothing Then Return
        Dim ID As String = DGProgProd.Rows(e.RowIndex).Cells("ID").Value.ToString
        Try
            ''If e.ColumnIndex > 1 AndAlso e.ColumnIndex < 8 Then
            ''    e.CellStyle.BackColor = Color.Honeydew
            ''End If
            'If e.ColumnIndex > 7 AndAlso e.ColumnIndex < 10 Then
            '    e.CellStyle.BackColor = Color.Lavender
            'End If
            'If e.ColumnIndex > 9 AndAlso e.ColumnIndex < 18 Then
            '    e.CellStyle.BackColor = Color.Cornsilk
            'End If

            If DGProgProd.Columns(e.ColumnIndex).Name.ToUpper = "FALTA" AndAlso
                Eval(DGProgProd.Rows(e.RowIndex).Cells("FALTA").Value.ToString) < 0 Then
                e.CellStyle.BackColor = Color.OrangeRed
            End If

            DProgProd.Find("ID='" + ID + "'")
            If DProgProd.EOF Then Return
            DProgProd.RecordSet("SECUENCIA") = e.RowIndex + 1
            DProgProd.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub RefreshDG(ByVal DG As DataGridView, ByVal Fila As Int32, ByVal RecorDProgProd As DataRow)

        Try
            With DG
                .Rows(Fila).Cells("ID").Value = RecorDProgProd("ID")
                .Rows(Fila).Cells("CODINT").Value = RecorDProgProd("CODINT")
                .Rows(Fila).Cells("NOMBRE").Value = RecorDProgProd("NOMBRE")
                .Rows(Fila).Cells("INVMIN").Value = RecorDProgProd("INVMIN")
                .Rows(Fila).Cells("UNO").Value = RecorDProgProd("UNO")
                .Rows(Fila).Cells("PEDIDOS").Value = RecorDProgProd("PEDIDOS")
                .Rows(Fila).Cells("EXIST").Value = 0
                DArt.Find("CODINT='" + RecorDProgProd("CODINT") + "'")
                If DArt.EOF = False Then .Rows(Fila).Cells("EXIST").Value = DArt.RecordSet("INVCHRONOS")
                .Rows(Fila).Cells("ENPROC").Value = ExistenciaTolvas(RecorDProgProd("CODINT"))
                .Rows(Fila).Cells("EMPSINREC").Value = 0
                DEmpSinRec.Find("CODPROD='" + RecorDProgProd("CODINT") + "'")
                If DEmpSinRec.EOF = False AndAlso Not IsDBNull(DEmpSinRec.RecordSet("EXIST")) Then .Rows(Fila).Cells("EMPSINREC").Value = DEmpSinRec.RecordSet("EXIST")
                .Rows(Fila).Cells("TOTAL").Value = Eval(.Rows(Fila).Cells("EXIST").Value) + Eval(.Rows(Fila).Cells("ENPROC").Value) + Eval(.Rows(Fila).Cells("EMPSINREC").Value)
                .Rows(Fila).Cells("FALTA").Value = 0
                If RecorDProgProd("INVMIN") > 0 Then .Rows(Fila).Cells("FALTA").Value = .Rows(Fila).Cells("TOTAL").Value - .Rows(Fila).Cells("INVMIN").Value
                .Rows(Fila).Cells("DIASINV").Value = 0
                If RecorDProgProd("INVMIN") > 0 Then .Rows(Fila).Cells("DIASINV").Value = .Rows(Fila).Cells("TOTAL").Value \ .Rows(Fila).Cells("INVMIN").Value
                .Rows(Fila).Cells("BMETA").Value = 0
                .Rows(Fila).Cells("BREAL").Value = 0
                DVarios.Open("select * from OPS where CODPROD='" + RecorDProgProd("CODINT").ToString + "' and FINALIZADO<>'S'")
                For Each Record As DataRow In DVarios.Rows
                    .Rows(Fila).Cells("BMETA").Value += Record("META")
                    .Rows(Fila).Cells("BREAL").Value += Record("REAL")
                Next
                .Rows(Fila).Cells("TH").Value = RecorDProgProd("TH")
                .Rows(Fila).Cells("INCLUIRPROG").Value = RecorDProgProd("INCLUIRPROG")
                .Rows(Fila).Cells("ORDEN").Value = RecorDProgProd("ORDEN")
                .Rows(Fila).Cells("LINEA").Value = RecorDProgProd("LINEA")
                .Rows(Fila).Cells("BACHES").Value = RecorDProgProd("BACHES")
                .Rows(Fila).Cells("TON").Value = 0

                DProds.Find("CODPROD='" + RecorDProgProd("CODINT") + "'")
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------
                'Se calculan los baches cuando se importa la informacion de los pedidos.
                If ActPedidos = 10 AndAlso DArt.EOF = False AndAlso DProds.EOF = False AndAlso DProds.RecordSet("TN") > 0 Then
                    .Rows(Fila).Cells("BACHES").Value = Math.Abs(Math.Round(.Rows(Fila).Cells("FALTA").Value * DArt.RecordSet("PRESKG") / (DProds.RecordSet("TN") * 1000), 0))

                    DProgProd.Refresh()
                    DProgProd.Find("CODINT='" + RecorDProgProd("CODINT") + "'")
                    If DProgProd.EOF = False Then
                        DProgProd.RecordSet("BACHES") = .Rows(Fila).Cells("BACHES").Value
                        DProgProd.Update()
                    End If
                End If
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------
                If DProds.EOF = False Then .Rows(Fila).Cells("TON").Value = DProds.RecordSet("TN") * RecorDProgProd("BACHES")
                .Rows(Fila).Cells("HORAS").Value = 0
                If RecorDProgProd("TH") > 0 Then .Rows(Fila).Cells("HORAS").Value = .Rows(Fila).Cells("TON").Value / RecorDProgProd("TH")
                'If RecorDProgProd("TH") < 1 Then
                '    If RecorDProgProd("TH") > 0 Then .Rows(Fila).Cells("HORAS").Value = .Rows(Fila).Cells("TON").Value * RecorDProgProd("TH")
                'Else
                '    If RecorDProgProd("TH") > 0 Then .Rows(Fila).Cells("HORAS").Value = .Rows(Fila).Cells("TON").Value / RecorDProgProd("TH")
                'End If

                .Rows(Fila).Cells("TURNO").Value = RecorDProgProd("TURNO")
                .Rows(Fila).Cells("OBSERVPROG").Value = RecorDProgProd("OBSERVPROG")

                If Eval(.Rows(Fila).Cells("CODINT").Value.ToString) = 0 Then
                    .Rows(Fila).ReadOnly = True
                    .Rows(Fila).Cells("NOMBRE").Style.BackColor = Color.Orange
                End If
            End With

            BSumCol_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSumCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSumCol.Click
        Try
            THoras.Text = 0
            TExist.Text = SumColumn(DGProgProd, "EXIST")
            TEnProc.Text = SumColumn(DGProgProd, "ENPROC")
            TEmpSinRec.Text = SumColumn(DGProgProd, "EmpSinRec")
            TTotal.Text = SumColumn(DGProgProd, "TOTAL")
            TPedidos.Text = SumColumn(DGProgProd, "PEDIDOS")

            For Each FilDg As DataGridViewRow In DGProgProd.Rows
                If FilDg.Cells("INCLUIRPROG").Value = True Then
                    THoras.Text = Eval(THoras.Text) + FilDg.Cells("HORAS").Value
                End If
            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBajarProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBajarProg.Click
        Dim Ran() As String
        Dim Rac() As String
        Dim i As Integer
        Dim DCell As DataGridViewCell

        i = DGProgProd.CurrentRow.Index
        If i = DGProgProd.RowCount - 1 Then Exit Sub
        ReDim Ran(DGProgProd.ColumnCount)
        ReDim Rac(DGProgProd.ColumnCount)

        DCell = DGProgProd.Rows(i).Cells("NOMBRE")

        For t As Integer = 0 To Me.DGProgProd.ColumnCount - 1
            Rac(t) = Me.DGProgProd.Rows(i).Cells(t).Value.ToString
            Ran(t) = Me.DGProgProd.Rows(i + 1).Cells(t).Value.ToString
            Me.DGProgProd(t, i).Value = Ran(t).ToString
            Me.DGProgProd(t, i).Style = DCell.Style
            Me.DGProgProd(t, i + 1).Value = Rac(t).ToString
        Next
        DGProgProd.Rows(i + 1).Selected = True
        DGProgProd.FirstDisplayedScrollingRowIndex = i + 1
        DGProgProd.CurrentCell = DGProgProd(0, i + 1)

        DGProgProd.Rows(i).Cells("NOMBRE").Style.BackColor = Color.White
        DGProgProd.Rows(i + 1).Cells("NOMBRE").Style.BackColor = Color.White
        If Eval(DGProgProd.Rows(i).Cells("CODINT").Value) = 0 Then
            DGProgProd.Rows(i).Cells("NOMBRE").Style.BackColor = Color.Orange
        End If
        If Eval(DGProgProd.Rows(i + 1).Cells("CODINT").Value) = 0 Then
            DGProgProd.Rows(i + 1).Cells("NOMBRE").Style.BackColor = Color.Orange
        End If

        If ActSec <> "ACT" Then BActSec_Click(Nothing, Nothing)

        mnLCuenta.Text = DGProgProd.Rows.Count.ToString
        Fila = DGProgProd.CurrentRow.Index
        mnTCuenta.Text = (Fila + 1).ToString()
    End Sub

    Private Sub BSubirProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSubirProg.Click
        Dim Ran() As String
        Dim Rac() As String
        Dim i As Integer

        i = DGProgProd.CurrentRow.Index
        If i = 0 Then Exit Sub
        ReDim Ran(DGProgProd.ColumnCount)
        ReDim Rac(DGProgProd.ColumnCount)


        For t As Integer = 0 To Me.DGProgProd.ColumnCount - 1
            Rac(t) = Me.DGProgProd.Rows(i).Cells(t).Value.ToString
            Ran(t) = Me.DGProgProd.Rows(i - 1).Cells(t).Value.ToString
            Me.DGProgProd(t, i).Value = Ran(t).ToString
            Me.DGProgProd(t, i).Style.BackColor = Color.White
            Me.DGProgProd(t, i - 1).Value = Rac(t).ToString
        Next
        DGProgProd.Rows(i - 1).Selected = True
        DGProgProd.FirstDisplayedScrollingRowIndex = i - 1
        DGProgProd.CurrentCell = DGProgProd(0, i - 1)

        DGProgProd.Rows(i).Cells("NOMBRE").Style.BackColor = Color.White
        DGProgProd.Rows(i - 1).Cells("NOMBRE").Style.BackColor = Color.White
        If Eval(DGProgProd.Rows(i).Cells("CODINT").Value) = 0 Then
            DGProgProd.Rows(i).Cells("NOMBRE").Style.BackColor = Color.Orange
        End If
        If Eval(DGProgProd.Rows(i - 1).Cells("CODINT").Value) = 0 Then
            DGProgProd.Rows(i - 1).Cells("NOMBRE").Style.BackColor = Color.Orange
        End If
        If ActSec <> "ACT" Then BActSec_Click(Nothing, Nothing)

        mnLCuenta.Text = DGProgProd.Rows.Count.ToString
        Fila = DGProgProd.CurrentRow.Index
        mnTCuenta.Text = (Fila + 1).ToString()

    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()

    End Sub

    Private Sub DGProgProd_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGProgProd.CellClick
        Try
            If DGProgProd.RowCount = 0 Then Return

            mnLCuenta.Text = DGProgProd.Rows.Count.ToString
            Fila = DGProgProd.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGProgProd.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGProgProd.Rows(Fila).Selected = True
            DGProgProd.FirstDisplayedScrollingRowIndex = Fila
            DGProgProd.CurrentCell = DGProgProd(0, Fila)
            DGProgProd_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGProgProd.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGProgProd.Rows(Fila).Selected = True
            DGProgProd.FirstDisplayedScrollingRowIndex = Fila
            DGProgProd.CurrentCell = DGProgProd(0, Fila)
            DGProgProd_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGProgProd.Rows.Count = 0 Then Exit Sub
            Fila = DGProgProd.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGProgProd.Rows(Fila).Selected = True
            DGProgProd.FirstDisplayedScrollingRowIndex = Fila
            DGProgProd.CurrentCell = DGProgProd(0, Fila)
            DGProgProd_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGProgProd.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGProgProd.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGProgProd.Rows(Fila).Selected = True
            DGProgProd.FirstDisplayedScrollingRowIndex = Fila
            DGProgProd.CurrentCell = DGProgProd(0, Fila)
            DGProgProd_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            DConsultas.Open("select * from CONSULTAS")
            DConsultas.RecordSet("F1") = Format(DateAdd(DateInterval.Day, -30, Now), "yyyy/MM/dd")
            DConsultas.RecordSet("F2") = Format(DateAdd(DateInterval.Day, 30, Now), "yyyy/MM/dd")

            DProgProd.Open("select * from PROGPROD order by SECUENCIA ")
            DArt.Open("select * from ARTICULOS where ISNUMERIC(CodInt)=1 AND TIPO='PT' ")
            DConfigPantallas.Open("Select * from CONFIGPANTALLAS")


            'DConsultas.RecordSet("T12") = Now.ToString("yyMMdd")
            DConsultas.Update()

            'DCEmpSacKoff.Open("select Sum(SACOS) AS Exist ,CodProd from CEmpaqueOPTot where FinPlanilla<>'S' group by CODPROD")

            DCEmpSacKoff.Open("select CEmpaqueOPTot.CodProd, CASE WHEN Articulos.PresKg = 0 THEN 0 " +
                                "ELSE ROUND(SUM(CEmpaqueOPTot.Peso)  / Articulos.PresKg, 0) END AS Exist," +
                                "dbo.Articulos.PresKg FROM  dbo.CEmpaqueOPTot INNER JOIN " +
                                "Articulos ON CEmpaqueOPTot.CodProd = Articulos.CodInt  " +
                                "where FinPlanilla<>'S' group by CodProd, Articulos.PresKg")

            DCConsumosTot.Open("SELECT CConsumosOPTot.CodProd, CASE WHEN Articulos.PresKg = 0 THEN 0 ELSE ROUND(SUM(CConsumosOPTot.PesoReal) " +
                     " / Articulos.PresKg, 0) END AS EXIST, dbo.Articulos.PresKg FROM  dbo.CConsumosOPTot INNER JOIN " +
                     " Articulos ON CConsumosOPTot.CodProd = Articulos.CodInt  WHERE (CConsumosOPTot.FinPlanilla <> 'S')  GROUP BY CConsumosOPTot.CodProd, Articulos.PresKg")

            DEmpSinRec.Open("SELECT SUM(dbo.Empaque.Sacos + dbo.Empaque.SacosAjuste + dbo.Empaque.SacosNC + dbo.Empaque.Reproceso) AS EXIST, dbo.Empaque.CodProd " +
                            "FROM dbo.Empaque INNER JOIN " +
                            "dbo.Consultas ON dbo.Empaque.FechaIni >= dbo.Consultas.F1 AND dbo.Empaque.FechaFin < dbo.Consultas.F2 " +
                            "WHERE     (dbo.Empaque.RecEmp = 0) and recreproceso<>1 and destino<>'GR' and destino<>'0' " +
                            "GROUP BY dbo.Empaque.CodProd")

            DProds.Open("SELECT dbo.ProgProd.CodInt as CODPROD, Min(CONVERT(decimal(10, 1), dbo.Baches.PesoMeta / 1000)) AS TN " +
                        "FROM dbo.Baches INNER JOIN " +
                      "dbo.ProgProd ON dbo.Baches.Producto = dbo.ProgProd.CodInt " +
                     "GROUP BY dbo.ProgProd.CodInt, dbo.Baches.PesoMeta")

            'DEmpSinRec.Open("SELECT SUM(dbo.Empaque.Sacos + dbo.Empaque.SacosAjuste + dbo.Empaque.SacosNC + dbo.Empaque.Reproceso) AS EXIST, dbo.Empaque.CodProd " +
            '                "FROM dbo.Empaque INNER JOIN " +
            '                "dbo.Consultas ON dbo.Empaque.FechaIni >= dbo.Consultas.F1 AND dbo.Empaque.FechaFin < dbo.Consultas.F2 " +
            '                "WHERE  Empaque.OP<>0 and Empaque.RECEMP=0 and Empaque.MAQUINA<>100 and (Empaque.CODPROD<>'303035' AND Empaque.CODPROD<>'300004') and recreproceso<>1 and destino<>'GR' and destino<>'0' " +
            '                "GROUP BY dbo.Empaque.CodProd")


            DGProgProd.Columns(DGProgProd.ColumnCount - 1).Visible = False
            BLlenarDG_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImprimir.Click
        Dim RepSap As CrystalRep

        Try

            RepSap = New CrystalRep

            DConsultas.Refresh()
            DConsultas.RecordSet("F1") = Format(Now, "yyyy/MM/dd 06:00")
            DConsultas.Update()

            With RepSap
                .ServerName = ServidorSQL

                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                .Formulas(1) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "RpProgProduccion.rpt"
                .PrintReport()
            End With

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDuplicar.Click
        Try
            Dim PosInsert As Int32 = 0

            If DGProgProd.RowCount = 0 Then
                PosInsert = 0
                DGProgProd.Rows.Add()
            Else
                PosInsert = DGProgProd.CurrentRow.Index + 1
                DGProgProd.Rows.Insert(PosInsert)
            End If

            For Ndx = 0 To DGProgProd.ColumnCount - 1
                DGProgProd.Rows(PosInsert).Cells(Ndx).Value = DGProgProd.Rows(PosInsert - 1).Cells(Ndx).Value
            Next

            DProgProd.AddNew()
            DProgProd.RecordSet("CODINT") = DGProgProd.Rows(PosInsert).Cells("CODINT").Value
            DProgProd.RecordSet("NOMBRE") = DGProgProd.Rows(PosInsert).Cells("NOMBRE").Value
            DProgProd.RecordSet("INVMIN") = DGProgProd.Rows(PosInsert).Cells("INVMIN").Value
            DProgProd.RecordSet("INCLUIRPROG") = DGProgProd.Rows(PosInsert).Cells("INCLUIRPROG").Value
            DProgProd.RecordSet("LINEA") = DGProgProd.Rows(PosInsert).Cells("LINEA").Value
            DProgProd.RecordSet("BACHES") = DGProgProd.Rows(PosInsert).Cells("BACHES").Value
            DProgProd.RecordSet("TH") = DGProgProd.Rows(PosInsert).Cells("TH").Value
            DProgProd.RecordSet("TURNO") = DGProgProd.Rows(PosInsert).Cells("TURNO").Value
            DProgProd.RecordSet("OBSERVPROG") = DGProgProd.Rows(PosInsert).Cells("OBSERVPROG").Value
            DProgProd.RecordSet("SECUENCIA") = PosInsert
            DProgProd.Update(Me)

            BActSec_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActSec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActSec.Click
        Try
            Dim i As Int32 = 1
            For Each FilDg As DataGridViewRow In DGProgProd.Rows
                DProgProd.Find("ID=" + FilDg.Cells("ID").Value.ToString)
                If DProgProd.EOF Then Continue For
                DProgProd.RecordSet("SECUENCIA") = i
                i += 1
            Next
            ' BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BModSec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModSec.Click
        Dim SecAct As Int32 = 0
        Dim SecDest As Int32 = 0
        Try

            SecDest = 0
            If InputBox.InputBox("Modificar secuencia", "Digite el número de línea de la grilla destino", SecDest) = DialogResult.Cancel Then Return

            SecAct = DGProgProd.CurrentRow.Index + 1
            If SecDest = 0 Then Return
            If SecAct = SecDest Then Return
            If SecDest > DGProgProd.RowCount Then Return

            If SecAct > SecDest Then
                For i = 1 To SecAct - SecDest
                    ActSec = "ACT"
                    BSubirProg_Click(Nothing, Nothing)
                Next
            End If

            If SecAct < SecDest Then
                For i = 1 To SecDest - SecAct
                    ActSec = "ACT"
                    BBajarProg_Click(Nothing, Nothing)
                Next
            End If
            ActSec = ""

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            If DGProgProd.RowCount = 0 OrElse DGProgProd.CurrentRow Is Nothing Then Return
            Dim ID As String = DGProgProd.Rows(DGProgProd.CurrentRow.Index).Cells("ID").Value.ToString
            DProgProd.Find("ID=" + ID)
            DGProgProd.Rows.RemoveAt(DGProgProd.CurrentRow.Index)

            If DProgProd.EOF Then Return
            DProgProd.RecordSet.Delete()
            DProgProd.Update()

            BActSec_Click(Nothing, Nothing)
            ProgramaProd_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

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
                ProgramaProd_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'Si el campo contiene el separador - es porque la busqueda se va a realizar por varios campos por lo cual se agrega el separador al
            'campo y la palabra true para que filtre incluir
            If Campos(x).Contains("-") Then
                BusquedaDGVariosCampos(DGProgProd, Campos(x), TBuscar.Text + "-True", Hallado)
            Else
                BusquedaDGContains(DGProgProd, Campos(x), TBuscar.Text, Hallado)
            End If

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            BSumCol_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGProgProd_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DGProgProd.CellPainting

        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
        If DGProgProd.Rows(e.RowIndex).Cells("ID").Value Is Nothing Then Return
        Dim ID As String = DGProgProd.Rows(e.RowIndex).Cells("ID").Value.ToString
        Dim Campo As String = DGProgProd.Columns(e.ColumnIndex).Name

        Try
            If Campo.ToUpper <> "NOMBRE" AndAlso Eval(DGProgProd.Rows(e.RowIndex).Cells("CODINT").Value) = 0 Then

                Dim newRect As New Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1,
                     e.CellBounds.Width - 4, e.CellBounds.Height - 4)
                Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
                Dim gridBrush As New SolidBrush(Me.DGProgProd.GridColor)
                Dim gridLinePen As New Pen(gridBrush)

                'e.Graphics.DrawLine(Pens.White, New Point(e.CellBounds.X), New Point(e.CellBounds.Y))
                ' Erase the cell.
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                ' e.Graphics.DrawLine(Pens.Red, New Point(e.CellBounds.Location.X), New Point(e.CellBounds.Location.Y))
                ' Draw the grid lines (only the right and bottom lines;
                ' DataGridView takes care of the others).
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                    e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                   e.CellBounds.Bottom - 1)
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                    e.CellBounds.Top, e.CellBounds.Right - 1,
                    e.CellBounds.Bottom)

                '' Draw the inset highlight box.
                e.Graphics.DrawRectangle(Pens.Orange, newRect)

                e.Handled = True
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub CEspecies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEspecies.SelectedIndexChanged
        Try
            If DGProgProd.RowCount = 0 OrElse DGProgProd.CurrentRow Is Nothing Then Return

            Dim F As Int32 = DGProgProd.CurrentRow.Index + 1

            DProgProd.AddNew()
            DProgProd.RecordSet("CODINT") = CLeft(CEspecies.Text, 15)
            DProgProd.RecordSet("NOMBRE") = CLeft(CEspecies.Text, 30)
            DProgProd.RecordSet("INVMIN") = 0
            DProgProd.RecordSet("INCLUIRPROG") = 0
            DProgProd.RecordSet("LINEA") = "-"
            DProgProd.RecordSet("BACHES") = 0
            DProgProd.RecordSet("TH") = 0
            DProgProd.RecordSet("TURNO") = "-"
            DProgProd.RecordSet("OBSERVPROG") = "-"
            DProgProd.RecordSet("SECUENCIA") = DGProgProd.CurrentRow.Index + 1
            DProgProd.Update()

            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    
    Private Sub mnAdicionarProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAdicionarProd.Click
        Try

            Dim CodInt As String = ""
            If InputBox.InputBox("Adicionar Producto Terminado", "Ingrese el Producto a adicionar", CodInt) = DialogResult.Cancel Then Return

            If CodInt = "" Then
                MsgBox("El código de Producto ingresado no es válido", MsgBoxStyle.Information)
                Return
            End If

            DArt.Open("select * from ARTICULOS where CODINT='" + CodInt + "' and TIPO='PT'")
            If DArt.Count = 0 Then
                MsgBox("El Producto ingresado no existe en la tabla artículos", MsgBoxStyle.Information)
                Return
            End If

            DProgProd.AddNew()
            DProgProd.RecordSet("CODINT") = DArt.RecordSet("CODINT")
            DProgProd.RecordSet("NOMBRE") = DArt.RecordSet("NOMBRE")
            DProgProd.RecordSet("INVMIN") = 0
            DProgProd.RecordSet("INCLUIRPROG") = 0
            DProgProd.RecordSet("LINEA") = "-"
            DProgProd.RecordSet("BACHES") = 0
            DProgProd.RecordSet("TH") = 0
            DProgProd.RecordSet("TURNO") = "-"
            DProgProd.RecordSet("OBSERVPROG") = "-"
            DProgProd.RecordSet("SECUENCIA") = DGProgProd.RowCount
            DProgProd.Update(Me)

            BActualizar_Click(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub CBBuscar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBBuscar.SelectedIndexChanged
        Dim Hallado As Boolean
        Try
            If CBBuscar.Text.ToUpper = "INCLUIR" Then
                BusquedaDGContains(DGProgProd, "INCLUIRPROG", True, Hallado)
                BSumCol_Click(Nothing, Nothing)
            End If
            If CBBuscar.Text.ToUpper = "NEGATIVOS" Then
                BusquedaDGCond(DGProgProd, "FALTA", "0", "<", Hallado)

                BSumCol_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub mnInhabilitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnInhabilitar.Click
        Try
            DProgProd.Refresh()
            For Each Fila As DataGridViewRow In DGProgProd.Rows

                Fila.Cells("INCLUIRPROG").Value = False
                DProgProd.Find("CODINT='" + Fila.Cells("CODINT").Value.ToString + "'")
                If DProgProd.EOF Then Return
                DProgProd.RecordSet("INCLUIRPROG") = Fila.Cells("INCLUIRPROG").Value
                DProgProd.Update(Me)
            Next
            'DProds.Update()
            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub TDiasInv_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TDiasInv.KeyUp
        Try

            If TDiasInv.Text = "" Then
                ProgramaProd_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = 0 ' CBBuscar.SelectedIndex

            'Si el campo contiene el separador - es porque la busqueda se va a realizar por varios campos por lo cual se agrega el separador al
            'campo y la palabra true para que filtre incluir
            BusquedaDG(DGProgProd, "DIASINV", TDiasInv.Text, Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            BSumCol_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BImportarSaldoSisUno_Click(sender As Object, e As EventArgs) Handles BImportarSaldoSisUno.Click
        Try
            Dim RutaArchUno As String = ""
            Dim Item As String
            Dim Descripcion As String
            Dim Cantidad As String
            Dim UnidadMed As String
            Dim ValUnitario As String
            Dim ValTotal As String
            Dim Ubicacion As String
            Dim LecArch As StreamReader
            Dim Contenido As String
            Dim Renglon As String, Renglones() As String
            Dim Pos As Int32
            Dim Invent As New DescInvent

            OpenFile.InitialDirectory = "C:\"
            OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                RutaArchUno = OpenFile.FileName
            End If

            If File.Exists(RutaArchUno) = False Then
                MessageBox.Show("No se encontro el archivo seleccionado", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            LecArch = File.OpenText(RutaArchUno)
            Contenido = LecArch.ReadToEnd
            LecArch.Close()

            Renglones = Contenido.Split(ControlChars.NewLine)

            If Not Contenido.Contains("EXISTENCIA") AndAlso Not Contenido.Contains("ITALCOL") AndAlso Not Contenido.Contains("12 PALMASECA") Then
                MessageBox.Show("El archivo no tiene el formato de Importación", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            For i As Integer = 0 To Renglones.Length
                Renglon = Renglones(i)

                If InStr(Renglon, "FIN LISTADO") > 0 Then
                    MsgBox("Fin de Archivo OK", MsgBoxStyle.Information)
                    Exit For
                End If

                If Eval(CLeft(Renglon, 10)) = 0 OrElse (Val(CLeft(Renglon, 10)) > 0 AndAlso InStr(1, CLeft(Renglon, 10), ".") > 0) Then Continue For

                Item = CLeft(Renglon, 10)
                Renglon = Mid(Renglon, 12).Trim
                Pos = InStr(Renglon, "BULTOS")
                If Pos = 0 Then Continue For
                Descripcion = CLeft(Renglon, Pos - 1)
                Renglon = Mid(Renglon, Pos + 7).Trim
                Pos = InStr(Renglon, New String(" "))
                If Pos = 0 Then Continue For
                Cantidad = Eval(Replace(CLeft(Renglon, Pos - 1), ",", ""))
                Renglon = Mid(Renglon, Pos + 1).Trim
                Pos = InStr(Renglon, New String("  "))
                If Pos = 0 Then Continue For
                UnidadMed = CLeft(Renglon, Pos)
                Renglon = Mid(Renglon, Pos).Trim
                Pos = InStr(Renglon, New String("  "))
                If Pos = 0 Then Continue For
                ValUnitario = Eval(Replace(CLeft(Renglon, Pos), ",", ""))
                Renglon = Mid(Renglon, Pos).Trim
                ValTotal = Eval(Replace(Renglon, ",", ""))
                Ubicacion = ""

                'Inventario(Item, Cantidad, TipoInv.UNO, "-", DetOperacion.LEEINVENTARIO, , , , , , , , Usuario)
                DProgProd.Refresh()
                DProgProd.Find("CODINT='" + Item + "'")
                If DProgProd.EOF = False Then
                    DProgProd.RecordSet("UNO") = Cantidad
                    DProgProd.Update()
                End If

            Next
            BActualizar_Click(Nothing, Nothing)
            'ProgramaProd_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BImporPedSisUno_Click(sender As Object, e As EventArgs) Handles BImporPedSisUno.Click
        Try
            Dim RutaArchUno As String = ""
            Dim Item As String
            Dim Descripcion As String
            Dim Cantidad As String
            Dim UnidadMed As String
            Dim ValUnitario As String
            Dim ValTotal As String
            Dim Ubicacion As String
            Dim LecArch As StreamReader
            Dim Contenido As String
            Dim Renglon As String, Renglones() As String
            Dim Pos As Int32
            Dim Invent As New DescInvent

            OpenFile.InitialDirectory = "C:\"
            OpenFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            OpenFile.FilterIndex = 0
            OpenFile.RestoreDirectory = True

            If (OpenFile.ShowDialog() = DialogResult.OK) Then
                RutaArchUno = OpenFile.FileName
            End If

            If File.Exists(RutaArchUno) = False Then
                MessageBox.Show("No se encontro el archivo seleccionado", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            LecArch = File.OpenText(RutaArchUno)
            Contenido = LecArch.ReadToEnd
            LecArch.Close()

            Renglones = Contenido.Split(ControlChars.NewLine)

            If Not Contenido.Contains("ORDENES DE VENTA") AndAlso Not Contenido.Contains("ITALCOL") AndAlso Not Contenido.Contains("PENDIENTE") Then
                MessageBox.Show("El archivo no tiene el formato de Importación", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            For i As Integer = 0 To Renglones.Length
                Renglon = Renglones(i)

                If InStr(Renglon, "FIN LISTADO") > 0 Then
                    MsgBox("Fin de Archivo Pedidos OK", MsgBoxStyle.Information)
                    Exit For
                End If

                If Eval(CLeft(Renglon, 10)) = 0 OrElse (Val(CLeft(Renglon, 10)) > 0 AndAlso InStr(1, CLeft(Renglon, 10), ".") > 0) Then Continue For

                Item = CLeft(Renglon, 10)
                Renglon = Mid(Renglon, 12).Trim
                Pos = InStr(Renglon, "BULTOS")
                If Pos = 0 Then Continue For
                Descripcion = CLeft(Renglon, Pos - 1)
                Renglon = Mid(Renglon, Pos + 7).Trim
                Pos = InStr(Renglon, New String(" "))
                If Pos = 0 Then Continue For
                Cantidad = Eval(Replace(CLeft(Renglon, Pos - 1), ",", ""))
                Renglon = Mid(Renglon, Pos + 1).Trim
                Pos = InStr(Renglon, New String("  "))
                If Pos = 0 Then Continue For
                UnidadMed = CLeft(Renglon, Pos)
                Renglon = Mid(Renglon, Pos).Trim
                Pos = InStr(Renglon, New String("  "))
                If Pos = 0 Then Continue For
                ValUnitario = Eval(Replace(CLeft(Renglon, Pos), ",", ""))
                Renglon = Mid(Renglon, Pos).Trim
                ValTotal = Eval(Replace(Renglon, ",", ""))
                Ubicacion = ""

                'Inventario(Item, Cantidad, TipoInv.UNO, "-", DetOperacion.LEEINVENTARIO, , , , , , , , Usuario)
                DProgProd.Refresh()
                DProgProd.Find("CODINT='" + Item + "'")
                If DProgProd.EOF = False Then
                    DProgProd.RecordSet("Pedidos") = Cantidad
                    DProgProd.Update()
                End If

            Next
            ActPedidos = 10
            BLlenarDG_Click(Nothing, Nothing)
            'Quita Pedidos
            If ActPedidos = 10 Then ActPedidos = 0

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

End Class