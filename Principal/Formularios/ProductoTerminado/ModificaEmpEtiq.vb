Public Class ModificaEmpEtiq
    Private DEmpEtiqDet As AdoSQL
    Private DEmp As AdoSQL
    Private DEtiq As AdoSQL
    Private DVarios As AdoSQL

    Public Sub ModificaEmpEtiq_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            DEmpEtiqDet = New AdoSQL("EmpEtiqDet")
            DEmp = New AdoSQL("Articulos-Emp")
            DEtiq = New AdoSQL("Articulos-Etiq")
            DVarios = New AdoSQL("Varios")

            'BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BSalir_Click(sender As System.Object, e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DGEmp_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmp.CellClick
        Try
            TCodEmp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_CODINT").Value.ToString
            TNomEmp.Text = DGEmp.Rows(DGEmp.CurrentRow.Index).Cells("DGEMP_NOMBRE").Value.ToString
            'TTipo.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_TIPO").Value.ToString
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEtiq_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEtiq.CellClick
        Try
            TCodEtiq.Text = DGEtiq.Rows(DGEtiq.CurrentRow.Index).Cells("DGETIQ_CODINT").Value.ToString
            TNomEtiq.Text = DGEtiq.Rows(DGEtiq.CurrentRow.Index).Cells("DGETIQ_NOMBRE").Value.ToString
            'TTipo.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_TIPO").Value.ToString
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BAceptar.Click
        Try
            Try
                'Recorre el DG del listado de empaques y etiquetas para almacenarlo en la tabla EmpEtiqDet

                Dim CodInt As String = ""
                Dim OP As String = ""
                Dim FechaIni As String = ""

                'Se guarda la fecha de empaque por si se va a modificar una OP que ya se empaco
                DVarios.Open("Select * FROM EMPETIQDET WHERE CONT=" + TCont.Text)

                If DVarios.Count Then FechaIni = DVarios.RecordSet("FECHAINI")

                DEmpEtiqDet.Open("Delete from EMPETIQDET WHERE CONT=" + TCont.Text)

                For Each Fila As DataGridViewRow In DGListEmp.Rows
                    CodInt = Fila.Cells("DGListEmp_CodInt").Value
                    OP = Fila.Cells("DGListEmp_OP").Value 'DGListEmp_OP

                    DEmpEtiqDet.Open("Select * from EMPETIQDET where CONT=0")

                    DEmpEtiqDet.AddNew()

                    DEmpEtiqDet.RecordSet("OP") = OP
                    DEmpEtiqDet.RecordSet("CODINT") = CodInt
                    DEmpEtiqDet.RecordSet("NOMBRE") = Fila.Cells("DGListEmp_Nombre").Value
                    DEmpEtiqDet.RecordSet("TIPO") = Fila.Cells("DGListEmp_Tipo").Value
                    DEmpEtiqDet.RecordSet("CANTTOTAL") = Fila.Cells("DGListEmp_CantTotal").Value
                    DEmpEtiqDet.RecordSet("CONT") = Fila.Cells("DGListEmp_Cont").Value
                    'DEmpEtiqDet.RecordSet("CANTBACHE") = Fila.Cells("DGListEmp_CantBache").Value
                    DEmpEtiqDet.RecordSet("FECHAINI") = FechaC()

                    DEmpEtiqDet.Update(Me)

                Next

                MsgBox("Datos almacenados correctamente", vbInformation)
            Catch ex As Exception
                MsgError(ex)
            End Try
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGListEmp_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGListEmp.CellClick
        Try
            If DGListEmp.RowCount = 0 Then Return
            DGListEmp.Rows(e.RowIndex).ErrorText =
                    "Presione suprimir para quitar empaque o etiqueta"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGListEmp_CellLeave(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGListEmp.CellLeave
        If DGListEmp.RowCount = 0 Then Return
        DGListEmp.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub DGListEmp_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles DGListEmp.KeyUp
        Try
            Dim Fila As DataGridViewRow

            If e.KeyCode <> Keys.Delete Then Return

            If DGListEmp.RowCount = 0 Then Return

            If DGListEmp.SelectedRows.Count = 0 Then Return

            Fila = DGListEmp.CurrentRow

            DGListEmp.Rows.Remove(Fila)



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FAdicEmpEtiq(ByVal CodInt As String, ByVal Nombre As String, ByVal Tipo As String, ByVal Cant As Int16, ByVal OP As String, ByVal CantxBache As Int16, ByRef Creado As Boolean, ByVal Cont As String)
        Try
            Creado = False
            If CodInt = "" Then Return
            If Nombre = "" Then Return
            If Tipo = "" Then Return
            If Cant = 0 Then
                MsgBox("La cantidad no puede ser un campo vacio", vbCritical)
                Return
            End If
            If OP = "" Then Return

            Dim Fila As Int16 = 1
            DGListEmp.Rows.Add()
            Fila = DGListEmp.Rows.Count - 1
            DGListEmp.Rows(Fila).Cells("DGListEmp_OP").Value = OP
            DGListEmp.Rows(Fila).Cells("DGListEmp_CodInt").Value = CodInt
            DGListEmp.Rows(Fila).Cells("DGListEmp_Nombre").Value = Nombre
            DGListEmp.Rows(Fila).Cells("DGListEmp_Tipo").Value = Tipo
            DGListEmp.Rows(Fila).Cells("DGListEmp_CantTotal").Value = Cant
            DGListEmp.Rows(Fila).Cells("DGListEmp_Cont").Value = Cont
            'DGListEmp.Rows(Fila).Cells("DGListEmp_CantBache").Value = CantxBache

            Creado = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdicionarEmp_Click(sender As System.Object, e As System.EventArgs) Handles BAdicionarEmp.Click
        Try
            Dim CreaReg As Boolean
            FAdicEmpEtiq(TCodEmp.Text, TNomEmp.Text, "EM", Val(TCantEmp.Text), TOPs.Text, 0, CreaReg, TCont.Text)
            If CreaReg = False Then Return
            BCancelarEmp_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BAdicionarEtiq_Click(sender As System.Object, e As System.EventArgs) Handles BAdicionarEtiq.Click
        Try
            Dim CreaReg As Boolean
            FAdicEmpEtiq(TCodEtiq.Text, TNomEtiq.Text, "ET", Val(TCantEtiq.Text), TOPs.Text, 0, CreaReg, TCont.Text)
            If CreaReg = False Then Return
            BCancelarEtiq_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarEmp_Click(sender As System.Object, e As System.EventArgs) Handles BCancelarEmp.Click
        Try
            'TCodEmp.Text = ""
            'TNomEmp.Text = ""
            TCantEmp.Text = ""
            'DEmp.Open("Select CODINT,NOMBRE from ARTICULOS where TIPO='EM'")
            'AsignaDataGrid(DGEmp, DEmp.DataTable, True)
            'BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelarEtiq_Click(sender As System.Object, e As System.EventArgs) Handles BCancelarEtiq.Click
        Try
            'TCodEtiq.Text = ""
            'TNomEtiq.Text = ""
            TCantEtiq.Text = ""
            'DEtiq.Open("Select CODINT,NOMBRE from ARTICULOS where TIPO='ET'")
            'AsignaDataGrid(DGEtiq, DEtiq.DataTable, True)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEmp_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TCodEmp.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso DGEmp.Rows.Count = 1 Then
                DGEmp_CellClick(Nothing, Nothing)
                TCantEmp.Focus()
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomEmp.Text = ""
                'TNomForB.Text = ""
            End If

            If TCodEmp.Text = "" Then
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGEmp, DEmp.DataTable, True)
                Exit Sub
            End If

            Dim Hallado As Boolean

            BusquedaDG(DGEmp, DEmp.DataTable, TCodEmp.Text, "CODINT", Hallado)

            If Hallado = False Then
                ''TCodForB.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub TCodEtiq_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TCodEtiq.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso DGEtiq.Rows.Count = 1 Then
                DGEtiq_CellClick(Nothing, Nothing)
                TCantEtiq.Focus()
                Exit Sub
            End If

            If e.KeyCode = Keys.Back Then
                TNomEtiq.Text = ""
                'TNomForB.Text = ""
            End If

            If TCodEtiq.Text = "" Then
                'Vuelve a asignar al datagrid todas las formulas de la tabla
                AsignaDataGrid(DGEtiq, DEtiq.DataTable, True)
                Exit Sub
            End If

            Dim Hallado As Boolean

            BusquedaDG(DGEtiq, DEtiq.DataTable, TCodEtiq.Text, "CODINT", Hallado)

            If Hallado = False Then
                ''TCodForB.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Public Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DEmpEtiqDet.Open("Select * from EMPETIQDET where CONT=" + TCont.Text)
            AsignaDataGrid(DGListEmp, DEmpEtiqDet.DataTable, True)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Try
            DGListEmp.Rows.Clear()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCont_TextChanged(sender As Object, e As EventArgs) Handles TCont.TextChanged
        Try
            If Val(TCont.Text) = 0 Then Return
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEmp_TextChanged(sender As Object, e As EventArgs) Handles TCodEmp.TextChanged
        Try
            If TCodEmp.Text = "" Then Return

            DEmp.Open("Select * FROM ARTICULOS where TIPO='EM' and CODINT='" + TCodEmp.Text + "'")
            If DEmp.Count Then TNomEmp.Text = DEmp.RecordSet("NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEtiq_TextChanged(sender As Object, e As EventArgs) Handles TCodEtiq.TextChanged
        Try
            If TCodEtiq.Text = "" Then Return

            DEtiq.Open("Select * FROM ARTICULOS where TIPO='ET' and CODINT='" + TCodEtiq.Text + "'")
            If DEtiq.Count Then TNomEtiq.Text = DEtiq.RecordSet("NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class