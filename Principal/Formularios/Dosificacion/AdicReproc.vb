Option Explicit On

Imports System
Imports System.Data
Imports ClassLibrary

Public Class AdicReproc
    Private DArt As AdoSQL
    Private Campos() As String
    Private DBaches As AdoSQL
    Private DConsumos As AdoSQL
    Private DVarios As AdoSQL

    Private Sub AdicReproc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DBaches = New AdoSQL("BACHES")
            DConsumos = New AdoSQL("CONSUMOS")
            DVarios = New AdoSQL("VARIOS")

            DArt = New AdoSQL("ARTICULOS")
            DArt.Open("Select * from ARTICULOS where REPROCESO=1")

            If DArt.Count > 0 Then AsignaDataGrid(DGArticulos, DArt.DataTable)

            Campos = {"CodInt@Cód.Int.", "CodExt@Cód.Ext.", "NOMBRE@Nombre"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DArt.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGArticulos_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGArticulos.CellClick
        Try
            If DGArticulos.Rows.Count = 0 Then Return

            TCodInt.Text = DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("CODINT").Value.ToString.Trim
            TNombre.Text = DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("NOMBRE").Value.ToString.Trim
            TCodExt.Text = DGArticulos.Rows(DGArticulos.CurrentRow.Index).Cells("CODEXT").Value.ToString.Trim
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            BSalir_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalir.Click
        Try
            BSalir_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If Eval(TCodInt.Text) = 0 Then Exit Sub

            If TNombre.Text = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Ingrediente de la lista"), vbInformation), vbInformation)
                Return
            End If

            If Eval(TCantidad.Text) <= 0 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "una cantidad válida a adicionar"), vbInformation), vbInformation)
                Return
            End If

            If Eval(TBacheNo.Text) <= 0 Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "bache"), vbInformation), vbInformation)
                Return
            End If

            RespInput = MsgBox("¿Seguro desea registrar esta adición?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
            If RespInput = vbNo Then Return

            DVarios.Open("select * from OPS where OP='" + TOPs.Text + "'")
            If DVarios.Count = 0 Then Return

            DBaches.Open("select * from BACHES where OP='" + TOPs.Text + "' and BACHE=" + TBacheNo.Text)

            If DBaches.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "el número del bache no existe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If DBaches.RecordSet("ESTADO") >= "40" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el bache ya fue exportado o está en proceso de exportación.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                ElseIf DBaches.RecordSet("ESTADO") = "30" Then
                    MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + "el bache ya fue descartado del proceso de producción.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            DConsumos.Open("select * from CONSUMOS where CONT=" + DBaches.RecordSet("CONT").ToString)

            DConsumos.AddNew()
            DConsumos.RecordSet("CONT") = DBaches.RecordSet("CONT")
            DConsumos.RecordSet("CODFOR") = DBaches.RecordSet("CODFOR")
            DConsumos.RecordSet("CODFORB") = DBaches.RecordSet("CODFORB")
            DConsumos.RecordSet("CODMATB") = TCodExt.Text
            DConsumos.RecordSet("NOMMAT") = TNombre.Text
            DConsumos.RecordSet("CODMAT") = TCodInt.Text
            DConsumos.RecordSet("PESOMETA") = Eval(TCantidad.Text)
            DConsumos.RecordSet("PESOREAL") = Eval(TCantidad.Text)
            DConsumos.RecordSet("ALARMAS") = 122
            DConsumos.RecordSet("TIPOMAT") = 25

            CortesLote(DConsumos.RecordSet("CODMAT").ToString, DConsumos.RecordSet("PESOREAL"), LoteCortesMP, ContCortesMP, UbicLoteMP)
            If LoteCortesMP <> "" AndAlso ContCortesMP <> "" Then
                DConsumos.RecordSet("CORTELOTE") = ContCortesMP
                DConsumos.RecordSet("Lote") = LoteCortesMP
                DConsumos.RecordSet("UbicLote") = UbicLoteMP
            End If

            ' Actualiza el inventario de tolvas
            DVarios.Open("select * from TOLVAS where CODINT='" + DConsumos.RecordSet("CODMAT").ToString + "'")
            If DVarios.Count > 0 Then
                DescTolvas(DVarios.RecordSet("TOLVA"), -DConsumos.RecordSet("PESOREAL"), DConsumos.RecordSet("CODMAT").ToString, ProcesoPlanta.DOSIFICACION)
            End If
            DConsumos.Update(Me)

            If Not IsDBNull(DConsumos.RecordSet("LOTE")) Then
                Inventario(TCodInt.Text, -Eval(TCantidad.Text), TipoInv.CHRONOS, DConsumos.RecordSet("LOTE"), DetOperacion.INGMANUAL, , , , , , , , UsuarioPrincipal)
            End If



            DBaches.RecordSet("PESOREAL") += Eval(TCantidad.Text)
            DBaches.Update(Me)

            DVarios.Open("select * from OPS where OP='" + TOPs.Text + "'")
            DVarios.RecordSet("REPROCESO") += Eval(TCantidad.Text)
            DVarios.Update(Me)

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)

            BSalir_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp, CBBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "a buscar"), vbInformation), vbInformation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                AdicReproc_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub

            BusquedaDG(DGArticulos, DArt.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGArticulos_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaDe.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub TCodInt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyUp
        Try

            DArt.Find("CODINT='" + TCodInt.Text + "'")

            If DArt.EOF Then Return

            TCodExt.Text = DArt.RecordSet("CODEXT")
            TNombre.Text = DArt.RecordSet("NOMBRE")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
End Class