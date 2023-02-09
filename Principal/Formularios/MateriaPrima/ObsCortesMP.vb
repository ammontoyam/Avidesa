Option Explicit On

Imports System
Imports System.Data

Public Class ObsCortesMP

    Private DCortes As AdoSQL
    Private DOBsCortes As AdoSQL
    Private DVarios As AdoSQL
    Private Accion As String
    Private Fila As Int32

    Private Sub ObsCortesMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DCortes = New AdoSQL("CORTESMP")
            DOBsCortes = New AdoSQL("OBSERVCORTES")
            DVarios = New AdoSQL("VARIOS")


            DCortes.Open("select * from CORTESLOTE where CONT=" + TCorte.Text.Trim)

            If DCortes.Count = 0 Then Exit Sub

            TCodMat.Text = DCortes.RecordSet("CodMat")
            TNomMat.Text = DCortes.RecordSet("NomMat")
            TLote.Text = DCortes.RecordSet("Lote")


            DOBsCortes.Open("select * from OBSCORTESMP where CORTE=" + TCorte.Text + " order by CONT")

            AsignaDataGrid(DGObsCorte, DOBsCortes.DataTable)
            'TextNum(TCantidad, True)
            TCantidad.ReadOnly = True
            TObservacion.ReadOnly = True
            TTipo.Enabled = False
            BAceptar.Enabled = False
            BCancelar.Enabled = False
            Accion = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGObsCorte_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGObsCorte.CellClick
        Try
            Dim Cont As String

            Cont = DGObsCorte.CurrentRow.Cells("CONT").Value.ToString

            DOBsCortes.Refresh()
            DOBsCortes.Find("CONT=" + Cont)

            If DOBsCortes.EOF = True Then Return

            TObservacion.Text = DOBsCortes.RecordSet("Observacion")
            TCantidad.Text = DGObsCorte.CurrentRow.Cells("CANTIDAD").Value.ToString
            TTipo.SelectedIndex = CInt(DGObsCorte.CurrentRow.Cells("TIPO").Value.ToString) - 1

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            TCantidad.ReadOnly = False
            TObservacion.ReadOnly = False
            TTipo.Enabled = True
            BAceptar.Enabled = True
            BCancelar.Enabled = True

            TTipo.Text = ""
            TCantidad.Text = ""
            TObservacion.Text = ""
            Accion = "NEW"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            TCantidad.ReadOnly = False
            TObservacion.ReadOnly = False
            TTipo.Enabled = True
            BAceptar.Enabled = True
            BCancelar.Enabled = True
            Accion = "EDIT"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            Dim Cont As String

            If TTipo.Text = "" Then
                MsgBox(" Debe seleccionar un Motivo para Crear su Ingreso", vbInformation)
            End If

            If Eval(TCantidad.Text) = 0 Then
                MsgBox(" Debe ingresar una Cantidad Válida para Crear su Ingreso", vbInformation)
            End If


            If Accion = "EDIT" Then
                If DGObsCorte.RowCount = 0 Then Return
                Cont = DGObsCorte.CurrentRow.Cells("CONT").Value.ToString
                DOBsCortes.Find("CONT=" + Cont)
                If DOBsCortes.EOF = True Then Return
            Else
                DOBsCortes.AddNew()
            End If

            DOBsCortes.RecordSet("CORTE") = TCorte.Text
            DOBsCortes.RecordSet("TIPO") = TTipo.SelectedIndex + 1
            DOBsCortes.RecordSet("Cantidad") = Eval(TCantidad.Text)
            DOBsCortes.RecordSet("Observacion") = CLeft(TObservacion.Text, 100)
            DOBsCortes.RecordSet("Fecha") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DOBsCortes.Update(Me)

            Evento("Realiza Ajuste de " + TTipo.Text + " a Corte No " + TCorte.Text + " Cant " + TCantidad.Text)

            ObsCortesMP_Load(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            ObsCortesMP_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            Dim Cont As String = DGObsCorte.CurrentRow.Cells("CONT").Value.ToString

            DOBsCortes.Find("CONT=" + Cont)
            If DOBsCortes.EOF = True Then Return
            RespInput = MsgBox("Esta seguro de eliminar el registro seleccionado?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)

            If RespInput = vbNo Then Return

            DOBsCortes.RecordSet.Delete()
            DOBsCortes.Update(Me)

            ObsCortesMP_Load(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Dim indifila As Integer = 0
        If DGObsCorte.RowCount = 0 Then Return
        indifila = DGObsCorte.RowCount - 1
        Fila += 1
        If Fila > indifila Then Fila = indifila
        mnTCuenta.Text = (Fila + 1).ToString()
        DGObsCorte.Rows(Fila).Selected = True
        DGObsCorte.FirstDisplayedScrollingRowIndex = Fila
        DGObsCorte.CurrentCell = DGObsCorte(0, Fila)
        DGObsCorte_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click
        If DGObsCorte.RowCount = 0 Then Return
        Fila -= 1
        If Fila < 0 Then Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGObsCorte.Rows(Fila).Selected = True
        DGObsCorte.FirstDisplayedScrollingRowIndex = Fila
        DGObsCorte.CurrentCell = DGObsCorte(0, Fila)
        DGObsCorte_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        If DGObsCorte.RowCount = 0 Then Return
        Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGObsCorte.Rows(Fila).Selected = True
        DGObsCorte.FirstDisplayedScrollingRowIndex = Fila
        DGObsCorte.CurrentCell = DGObsCorte(0, Fila)
        DGObsCorte_CellClick(Nothing, Nothing)

    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
          

            DVarios.Open("select * from OBSCORTESMP where CORTE=" + TCorte.Text)

            CortesMP.TAjusteSal.Text = 0
            CortesMP.TAjusteEnt.Text = 0
            CortesMP.TEntInv.Text = 0
            CortesMP.TSalInv.Text = 0

            If DVarios.Count = 0 Then
                Me.Close()
                Me.Dispose()
                Return
            End If

            DVarios.Open(" select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + TCorte.Text + " and TIPO=1")

            If Not IsDBNull(DVarios.RecordSet("Acum")) Then CortesMP.TAjusteSal.Text = -DVarios.RecordSet("Acum")

            DVarios.Open(" select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + TCorte.Text + " and TIPO=2")

            If Not IsDBNull(DVarios.RecordSet("Acum")) Then CortesMP.TAjusteEnt.Text = DVarios.RecordSet("Acum")

            DVarios.Open(" select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + TCorte.Text + " and TIPO=3")

            If Not IsDBNull(DVarios.RecordSet("Acum")) Then CortesMP.TEntInv.Text = DVarios.RecordSet("Acum")

            DVarios.Open(" select SUM(CANTIDAD) as Acum from OBSCORTESMP where CORTE=" + TCorte.Text + " and TIPO=4")

            If Not IsDBNull(DVarios.RecordSet("Acum")) Then CortesMP.TSalInv.Text = -DVarios.RecordSet("Acum")

            Me.Close()
            Me.Dispose()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        If DGObsCorte.RowCount = 0 Then Return
        Fila = DGObsCorte.Rows.Count - 1
        mnTCuenta.Text = (Fila + 1).ToString()
        DGObsCorte.Rows(Fila).Selected = True
        DGObsCorte.FirstDisplayedScrollingRowIndex = Fila
        DGObsCorte.CurrentCell = DGObsCorte(0, Fila)
        DGObsCorte_CellClick(Nothing, Nothing)
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class