Option Explicit On

Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Threading.Thread
Imports System.Data
Imports ClassLibrary

Public Class SecuenciaMezcla
    Private DEspecies As AdoSQL
    Private DEspRest As AdoSQL
    Private DGrpFor As AdoSQL
    Private DGrpForRest As AdoSQL
    Private DGrpMat As AdoSQL
    Private DGrpMatRest As AdoSQL
    Private DVarios As AdoSQL
    Private Codigo As String
    Private CodigoRest() As String
    Private i As Integer = 0
    Private Sentencia As String
    Private Fila As Integer

    Private Sub ContCruzada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DEspecies = New AdoSQL("ESPECIES")
            DEspRest = New AdoSQL("ESPREST")
            DGrpFor = New AdoSQL("GrpFor")
            DGrpForRest = New AdoSQL("GrpForRest")
            DGrpMat = New AdoSQL("GrpMat")
            DGrpMatRest = New AdoSQL("GrpMatRest")
            DVarios = New AdoSQL("VARIOS")
            DEspecies.Open("select * from ESPECIES order by CODESPECIE")
            DGrpFor.Open("select * from GRPFORMULAS order by CODGRPFOR")
            LLenaComboBox(CEspecies, DEspecies.DataTable, "CODESPECIE")
            LLenaComboBox(CFormulas, DGrpFor.DataTable, "CODGRPFOR")

            TabContCruz_Selecting(TabContCruz, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGEspecies_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEspecies.CellClick

        Try
            If DGEspecies.RowCount = 0 Then Return

            Codigo = DGEspecies.Rows(DGEspecies.CurrentRow.Index).Cells("CODESPECIE").Value.ToString
            DGEspeciesRest.Rows.Clear()
            DEspRest.Open("select * from CONTCRUZADA where CODESPECIE='" + Codigo + "' and CODESPECIERESTRINGIDA<>'0'")
            If DEspRest.Count = 0 Then Return

            ReDim CodigoRest(DEspRest.Count)
            Array.Clear(CodigoRest, CodigoRest.GetLowerBound(0), CodigoRest.GetUpperBound(0))
            'Erase CodigoRest


            i = 0
            For Each RecordSet As DataRow In DEspRest.Rows
                CodigoRest(i) = RecordSet("CODESPECIERESTRINGIDA").ToString
                i = i + 1
            Next
            Sentencia = ""
            For j As Integer = CodigoRest.GetLowerBound(0) To CodigoRest.GetUpperBound(0) - 1
                Sentencia = Sentencia + CodigoRest(j) + "' or CODESPECIE='"
            Next

            Sentencia = CLeft(Sentencia, InStrRev(Sentencia, "or ") - 1)
            DEspRest.Open("select * from ESPECIES where CODESPECIE='" + Sentencia)
            If DEspRest.Count = 0 Then Return

            AsignaDataGrid(DGEspeciesRest, DEspRest.DataTable, True)
            DGEspeciesRest_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CEspecies_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CEspecies.SelectedIndexChanged
        Try
            If CEspecies.Text = "" Then Exit Sub

            DEspecies.Find("CODESPECIE='" + CEspecies.Text.Trim + "'")

            If DEspecies.EOF Then
                MsgBox(DevuelveEvento(CodEvento.ARCHIVO_NOEXISTE) + " La especie no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TNomEsp.Text = DEspecies.RecordSet("NOMESPECIE").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdEspRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdEspRes.Click
        Try

            If ValidaPermiso("SecuenciaMezcla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Codigo = CEspecies.Text Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " La especie no puede restringir la misma especie", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            DEspRest.Open("select * from CONTCRUZADA where CODESPECIE='" + Codigo + "' and CODESPECIERESTRINGIDA='" + CEspecies.Text + "'")
            If DEspRest.Count > 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "la restricción ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            DEspRest.AddNew()
            DEspRest.RecordSet("CodEspecie") = Codigo
            DEspRest.RecordSet("CODESPECIERESTRINGIDA") = CEspecies.Text
            DEspRest.Update(Me)

            DGEspecies_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEspeciesRest_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEspeciesRest.CellLeave
        Try
            If DGEspeciesRest.RowCount = 0 Then Return
            DGEspeciesRest.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEspeciesRest_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGEspeciesRest.KeyUp
        Dim CodEspecieRest As String
        Try
            If e.KeyCode <> Keys.Delete Then Return

            If ValidaPermiso("SecuenciaMezcla_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If DGEspeciesRest.RowCount = 0 Then Return

            If DGEspeciesRest.SelectedRows.Count = 0 Then Return

            CodEspecieRest = DGEspeciesRest.Rows(DGEspeciesRest.CurrentRow.Index).Cells("DGEsp_CodEspecie").Value.ToString
            DEspRest.Delete("delete from CONTCRUZADA where CODESPECIE='" + Codigo + "' and CODESPECIERESTRINGIDA='" + CodEspecieRest + "'", Me)

            DGEspecies_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGEspeciesRest_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEspeciesRest.CellClick
        Try
            If DGEspeciesRest.RowCount = 0 Then Return
            DGEspeciesRest.Rows(e.RowIndex).ErrorText =
                    "Presione Suprimir para Quitar restricción"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpFor_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrpFor.CellClick

        Try
            If DGGrpFor.RowCount = 0 Then Return

            Codigo = DGGrpFor.Rows(DGGrpFor.CurrentRow.Index).Cells("CodGrpFor").Value.ToString

            DGGrpForRest.Rows.Clear()

            DGrpForRest.Open("select * from CONTCRUZADA where CodGrpFor='" + Codigo + "' and CodGrpForRestringida<>'0'")

            If DGrpForRest.Count = 0 Then Return


            ReDim CodigoRest(DGrpForRest.Count)
            Array.Clear(CodigoRest, CodigoRest.GetLowerBound(0), CodigoRest.GetUpperBound(0))
            'Erase CodigoRest

            i = 0
            For Each RecordSet As DataRow In DGrpForRest.Rows
                CodigoRest(i) = RecordSet("CodGrpForRestringida").ToString
                i = i + 1
            Next
            Sentencia = ""
            For j As Integer = CodigoRest.GetLowerBound(0) To CodigoRest.GetUpperBound(0) - 1
                Sentencia = Sentencia + CodigoRest(j) + "' or CodGrpFor='"
            Next

            Sentencia = CLeft(Sentencia, InStrRev(Sentencia, "or ") - 1)
            DGrpForRest.Open("select * from GRPFORMULAS where CodGrpFor='" + Sentencia)
            If DGrpForRest.Count = 0 Then Return

            AsignaDataGrid(DGGrpForRest, DGrpForRest.DataTable, True)
            DGGrpForRest_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub CFormulas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CFormulas.SelectedIndexChanged
        Try
            If CFormulas.Text = "" Then Exit Sub

            DGrpFor.Find("CodGrpFor='" + CFormulas.Text.Trim + "'")

            If DGrpFor.EOF Then
                MsgBox(DevuelveEvento(CodEvento.ARCHIVO_NOEXISTE) + "el Código de la fórmula no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            TNomGrpFor.Text = DGrpFor.RecordSet("NomGrpFor").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdGrpForRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdGrpForRes.Click
        Try
            If Codigo = CFormulas.Text Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el Grupo de Fórmulas no puede restringir el mismo Grupo de Fórmulas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            DGrpForRest.Open("select * from CONTCRUZADA where CodGrpFor='" + Codigo + "' and CodGrpForRestringida='" + CFormulas.Text + "'")
            If DGrpForRest.Count > 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "la restricción ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            DGrpForRest.AddNew()
            DGrpForRest.RecordSet("CodGrpFor") = Codigo
            DGrpForRest.RecordSet("CodGrpForRestringida") = CFormulas.Text
            DGrpForRest.Update(Me)

            DGGrpFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpForRest_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrpForRest.CellLeave
        Try
            If DGGrpForRest.RowCount = 0 Then Return
            DGGrpForRest.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpForRest_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGGrpForRest.KeyUp
        Dim CodGrpForRest As String
        Try
            If e.KeyCode <> Keys.Delete Then Return

            If DGGrpForRest.RowCount = 0 Then Return

            If DGGrpForRest.SelectedRows.Count = 0 Then Return

            CodGrpForRest = DGGrpForRest.Rows(DGGrpForRest.CurrentRow.Index).Cells("DGGrpFor_CodGrpFor").Value.ToString
            DGrpForRest.Delete("delete from CONTCRUZADA where CodGrpFor='" + Codigo + "' and CodGrpForRestringida='" + CodGrpForRest + "'", Me)

            DGGrpFor_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpForRest_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrpForRest.CellClick
        Try
            If DGGrpForRest.RowCount = 0 Then Return
            DGGrpForRest.Rows(e.RowIndex).ErrorText =
                    "Presione Suprimir para Quitar restricción"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGGrpMat_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrpMat.CellClick
        Try
            If DGGrpMat.RowCount = 0 Then Return

            Codigo = DGGrpMat.Rows(DGGrpMat.CurrentRow.Index).Cells("CodGrpMat").Value.ToString

            DGGrpSelRes.DataSource = Nothing
            DGGrpSelRes.Rows.Clear()
            DGGrpSelRes.Columns.Clear()
            CCodigo.Items.Clear()
            TNombre.Text = ""

            If OpGrpMat.Checked Then

                LSel.Text = "Grupo de Materiales Restringidos"

                DVarios.Open("select * from GRPMATERIALES order by CodGrpMat")
                LLenaComboBox(CCodigo, DVarios.DataTable, "CodGrpMat")

                DGrpMatRest.Open("select * from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodGrpMatRestringido<>'0'")
                If DGrpMatRest.Count = 0 Then Return

                ReDim CodigoRest(DGrpMatRest.Count)
                Array.Clear(CodigoRest, CodigoRest.GetLowerBound(0), CodigoRest.GetUpperBound(0))

                i = 0
                For Each RecordSet As DataRow In DGrpMatRest.Rows
                    CodigoRest(i) = RecordSet("CodGrpMatRestringido").ToString
                    i = i + 1
                Next
                Sentencia = ""
                For j As Integer = CodigoRest.GetLowerBound(0) To CodigoRest.GetUpperBound(0) - 1
                    Sentencia = Sentencia + CodigoRest(j) + "' or CodGrpMat='"
                Next

                Sentencia = CLeft(Sentencia, InStrRev(Sentencia, "or ") - 1)
                DGrpMatRest.Open("select * from GRPMATERIALES where CodGrpMat='" + Sentencia)
                DGGrpSelRes.DataSource = DGrpMatRest.DataTable

            ElseIf OpGrpFor.Checked Then
                LSel.Text = "Grupo de Fórmulas Restringidas"

                DVarios.Open("select * from GRPFORMULAS order by CodGrpFor")
                LLenaComboBox(CCodigo, DVarios.DataTable, "CodGrpFor")

                DGrpMatRest.Open("select * from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodGrpForRestringida<>'0'")
                If DGrpMatRest.Count = 0 Then Return
                ReDim CodigoRest(DGrpMatRest.Count)
                Array.Clear(CodigoRest, CodigoRest.GetLowerBound(0), CodigoRest.GetUpperBound(0))

                i = 0
                For Each RecordSet As DataRow In DGrpMatRest.Rows
                    CodigoRest(i) = RecordSet("CodGrpForRestringida").ToString
                    i = i + 1
                Next
                Sentencia = ""
                For j As Integer = CodigoRest.GetLowerBound(0) To CodigoRest.GetUpperBound(0) - 1
                    Sentencia = Sentencia + CodigoRest(j) + "' or CodGrpFor='"
                Next

                Sentencia = CLeft(Sentencia, InStrRev(Sentencia, "or ") - 1)
                DGrpMatRest.Open("select * from GRPFORMULAS where CodGrpFor='" + Sentencia)
                DGGrpSelRes.DataSource = DGrpMatRest.DataTable

            ElseIf OpEsp.Checked Then

                LSel.Text = "Especies Restringidas"

                DVarios.Open("select * from ESPECIES order by CodEspecie")
                LLenaComboBox(CCodigo, DVarios.DataTable, "CodEspecie")

                DGrpMatRest.Open("select * from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodEspecieRestringida<>'0'")
                If DGrpMatRest.Count = 0 Then Return
                ReDim CodigoRest(DGrpMatRest.Count)
                Array.Clear(CodigoRest, CodigoRest.GetLowerBound(0), CodigoRest.GetUpperBound(0))

                i = 0
                For Each RecordSet As DataRow In DGrpMatRest.Rows
                    CodigoRest(i) = RecordSet("CodEspecieRestringida").ToString
                    i = i + 1
                Next
                Sentencia = ""
                For j As Integer = CodigoRest.GetLowerBound(0) To CodigoRest.GetUpperBound(0) - 1
                    Sentencia = Sentencia + CodigoRest(j) + "' or CodEspecie='"
                Next

                Sentencia = CLeft(Sentencia, InStrRev(Sentencia, "or ") - 1)
                DGrpMatRest.Open("select * from ESPECIES where CodEspecie='" + Sentencia)
                DGGrpSelRes.DataSource = DGrpMatRest.DataTable

            End If

            DGGrpSelRes_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub CCodigo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CCodigo.SelectedIndexChanged
        Try
            If CCodigo.Text = "" Then Exit Sub

            If OpGrpMat.Checked Then
                DVarios.Find("CodGrpMat='" + CCodigo.Text.Trim + "'")

                If DVarios.EOF Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el Código del Grupo de Material ingresado no existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                TNombre.Text = DVarios.RecordSet("NomGrpMat").ToString
            ElseIf OpGrpFor.Checked Then
                DVarios.Find("CodGrpFor='" + CCodigo.Text.Trim + "'")

                If DVarios.EOF Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el Código del Grupo de la Fórmula ingresado no existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                TNombre.Text = DVarios.RecordSet("NomGrpFor").ToString

            ElseIf OpEsp.Checked Then
                DVarios.Find("CodEspecie='" + CCodigo.Text.Trim + "'")

                If DVarios.EOF Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el Código de la Especie ingresada no existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                TNombre.Text = DVarios.RecordSet("NomEspecie").ToString

            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub BAdSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdSel.Click
        Try
            If OpGrpMat.Checked Then
                If Codigo = CCodigo.Text Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el Grupo de Material no puede restringir el mismo Grupo de Material", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                DGrpMatRest.Open("select * from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodGrpMatRestringido='" + CCodigo.Text + "'")
                If DGrpMatRest.Count > 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "la restricción ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                DGrpMatRest.AddNew()
                DGrpMatRest.RecordSet("CodGrpMat") = Codigo
                DGrpMatRest.RecordSet("CodGrpMatRestringido") = CCodigo.Text
                DGrpMatRest.Update(Me)

            ElseIf OpGrpFor.Checked Then

                DGrpMatRest.Open("select * from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodGrpForRestringida='" + CCodigo.Text + "'")
                If DGrpMatRest.Count > 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "la restricción ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                DGrpMatRest.AddNew()
                DGrpMatRest.RecordSet("CodGrpMat") = Codigo
                DGrpMatRest.RecordSet("CodGrpForRestringida") = CCodigo.Text
                DGrpMatRest.Update(Me)

            ElseIf OpEsp.Checked Then

                DGrpMatRest.Open("select * from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodEspecieRestringida='" + CCodigo.Text + "'")
                If DGrpMatRest.Count > 0 Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "la restricción ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                DGrpMatRest.AddNew()
                DGrpMatRest.RecordSet("CodGrpMat") = Codigo
                DGrpMatRest.RecordSet("CodEspecieRestringida") = CCodigo.Text
                DGrpMatRest.Update(Me)

            End If

            DGGrpMat_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpSelRes_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrpSelRes.CellLeave
        Try
            If DGGrpSelRes.RowCount = 0 Then Return
            DGGrpSelRes.Rows(e.RowIndex).ErrorText = String.Empty
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpSelRes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGGrpSelRes.KeyUp
        Dim CodGrpSelRes As String
        Try
            If e.KeyCode <> Keys.Delete Then Return

            If DGGrpSelRes.RowCount = 0 Then Return

            If DGGrpSelRes.SelectedRows.Count = 0 Then Return

            If OpGrpMat.Checked Then
                CodGrpSelRes = DGGrpSelRes.Rows(DGGrpSelRes.CurrentRow.Index).Cells("CodGrpMat").Value.ToString
                DGrpForRest.Delete("delete from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodGrpMatRestringido='" + CodGrpSelRes + "'", Me)
            ElseIf OpGrpFor.Checked Then
                CodGrpSelRes = DGGrpSelRes.Rows(DGGrpSelRes.CurrentRow.Index).Cells("CodGrpFor").Value.ToString
                DGrpForRest.Delete("delete from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodGrpForRestringida='" + CodGrpSelRes + "'", Me)
            ElseIf OpEsp.Checked Then
                CodGrpSelRes = DGGrpSelRes.Rows(DGGrpSelRes.CurrentRow.Index).Cells("CodEspecie").Value.ToString
                DGrpForRest.Delete("delete from CONTCRUZADA where CodGrpMat='" + Codigo + "' and CodEspecieRestringida='" + CodGrpSelRes + "'", Me)
            End If

            DGGrpMat_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGGrpSelRes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGGrpSelRes.CellClick
        Try
            If DGGrpSelRes.RowCount = 0 Then Return
            DGGrpSelRes.Rows(e.RowIndex).ErrorText =
                    "Presione Suprimir para Quitar restricción"
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OpGrpMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpGrpMat.Click
        Try
            DGGrpMat_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OpGrpFor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpGrpFor.Click
        Try
            DGGrpMat_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OpEsp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpEsp.Click
        Try
            DGGrpMat_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TabContCruz_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabContCruz.Selected

        Try
            If CType(sender, TabControl).SelectedTab Is TabEspecie Then
                DEspecies.Open("select * from ESPECIES order by CODESPECIE")
                If DEspecies.Count = 0 Then Return

                AsignaDataGrid(DGEspecies, DEspecies.DataTable)
                DGEspecies.CurrentCell = DGEspecies(0, 0)
                DGEspecies_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))

            ElseIf CType(sender, TabControl).SelectedTab Is TabGrpFor Then
                DGrpFor.Open("select * from GRPFORMULAS order by CODGRPFOR")
                If DGrpFor.Count = 0 Then Return

                AsignaDataGrid(DGGrpFor, DGrpFor.DataTable)
                DGGrpFor.CurrentCell = DGGrpFor(0, 0)
                DGGrpFor_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
            ElseIf CType(sender, TabControl).SelectedTab Is TabGrpMat Then
                DGrpMat.Open("select * from GRPMATERIALES order by CODGRPMAT")
                If DGrpMat.Count = 0 Then Return

                AsignaDataGrid(DGGrpMat, DGrpMat.DataTable)
                DGGrpMat.CurrentCell = DGGrpMat(0, 0)
                DGGrpMat_CellClick(Nothing, New DataGridViewCellEventArgs(0, 0))
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BVerEspGrpForMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BVerEspGrpForMat.Click
        Try
            TablasSecuenciaMezcla.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub mnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnMateriales.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub mnAcercaD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaD.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub mnFormulación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnFormulación.Click
        Formulacion.ShowDialog()
    End Sub

    Private Sub mnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnReportes.Click
        Reportes.ShowDialog()
    End Sub

    Private Sub BAdEspRes_KeyUp(sender As Object, e As KeyEventArgs) Handles BAdEspRes.KeyUp
        If e.KeyCode = Keys.Enter Then BAdEspRes_Click(Nothing, Nothing)
    End Sub
End Class