Public Class EquivFormProd

    Private DEquivFormProd As AdoSQL
    Private DFor As AdoSQL
    Private DVarios As AdoSQL
    Private DArt As AdoSQL
    Private NuevaFor As Boolean
    Private Campos() As String
    Private Campos2() As String
    Private FormLoad As Boolean
    Private CodForEquivalencia As String


    Public Sub EquivFormProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then Return
            DVarios = New AdoSQL("VARIOS")
            DFor = New AdoSQL("FORMULAS")
            DArt = New AdoSQL("ARTICULOS")
            DEquivFormProd = New AdoSQL("EQUIVFORMPROD")

            FRefrescaDGProd_Click(Nothing, Nothing)
            BActualizar_Click(Nothing, Nothing)

            'Busqueda codigos de producto
            Campos2 = {"CodInt@Cód.Prod", "Nombre@Nombre"}
            Campos2 = AsignaItemsCB(Campos2, CBBuscarProd.ComboBox, DArt.DataTable)
            CBBuscarProd.Text = "Nombre"


            Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Deshabilitar)

            Campos = {"CodFor@Cód.For.", "NomFor@Nombre"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DFor.DataTable)
            CBBuscar.Text = "Nombre"

            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub






    Private Sub BActualizar_Click(sender As Object, e As EventArgs) Handles BActualizar.Click
        Try
            DFor.Open("Select CODFOR,MIN(NOMFOR) as NOMFOR from FORMULAS GROUP BY CODFOR order BY NOMFOR")
            AsignaDataGrid(DGFor, DFor.DataTable, True)

            DGFor.Rows(0).Selected = True
            DGFor.CurrentCell = DGFor(0, 0)
            DGFor.FirstDisplayedScrollingRowIndex = 0
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub TBuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                ''MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                ''TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                BActualizar_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGFor, DFor.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGFor_CellClick(Nothing, Nothing)


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BImprimir_Click(sender As Object, e As EventArgs)
        Dim RepSap As CrystalRep

        Try

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(0) = "PLANTA='" + Planta + "'"
                '.Formulas(1) = "HORA='" + Format(Now, "HH:mm") + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                .ReportFileName = RutaRep + "rpEquivalencias.rpt"

                .PrintReport()
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGFor_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGFor.CellClick
        Try
            If DGFor.Rows.Count = 0 Then Return

            CodForEquivalencia = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim

            'Se revisan los códigos equivalentes de productos que hay para este codigo de formula

            DEquivFormProd.Open("Select * from EQUIVFORMPROD where CODFOR='" + CodForEquivalencia + "'")
            AsignaDataGrid(DGEquivFormProd, DEquivFormProd.DataTable, True)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TBuscarProd_KeyUp(sender As Object, e As KeyEventArgs) Handles TBuscarProd.KeyUp
        Try
            If CBBuscarProd.Text = "" Then
                CBBuscarProd.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscarProd.Text = ""
                Exit Sub
            End If

            If TBuscarProd.Text = "" Then
                FRefrescaDGProd_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscarProd.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGProd, DArt.DataTable, TBuscarProd.Text, Campos2(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDGProd_Click(sender As Object, e As EventArgs) Handles FRefrescaDGProd.Click
        Try
            DArt.Open("Select * from ARTICULOS where TIPO='PT'")
            AsignaDataGrid(DGProd, DArt.DataTable, True)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAdicionaProd_Click(sender As Object, e As EventArgs) Handles BAdicionaProd.Click
        Try
            If DGProd.CurrentRow Is Nothing Then Return
            Dim CodProd As String = DGProd.Rows(DGProd.CurrentRow.Index).Cells("DGPROD_CODINT").Value.ToString
            Dim NomProd As String = DGProd.Rows(DGProd.CurrentRow.Index).Cells("DGPROD_NOMBRE").Value.ToString

            DEquivFormProd.Open("Select * from EQUIVFORMPROD where CODFOR='" + CodForEquivalencia + "' and CODPROD='" + CodProd + "'")

            If DEquivFormProd.Count = 0 Then
                DEquivFormProd.AddNew()
            Else
                Resp = MsgBox("El registro ya existe, ¿desea sobreescribirlo?", vbInformation + vbYesNo)
                If Resp = vbNo Then Return
            End If

            DEquivFormProd.RecordSet("CODFOR") = CodForEquivalencia
            DEquivFormProd.RecordSet("CODPROD") = CodProd
            DEquivFormProd.RecordSet("NOMPROD") = NomProd
            DEquivFormProd.Update()

            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BEliminaProd_Click(sender As Object, e As EventArgs) Handles BEliminaProd.Click
        Try
            If DGProd.CurrentRow Is Nothing Then Return
            Dim CodProd As String = DGEquivFormProd.Rows(DGEquivFormProd.CurrentRow.Index).Cells("DGEQUIVFORMPROD_CODPROD").Value.ToString

            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGELIMINAR), vbInformation + vbYesNo)
            If Resp = vbNo Then Return

            DEquivFormProd.Delete("delete from EQUIVFORMPROD where CODFOR='" + CodForEquivalencia + "' and CODPROD='" + CodProd + "'", Me)
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class