Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary
Public Class Clientes

    Private DClientes as AdoSQL
    Private Fila As Integer
    Private DFil() As DataRow
    Private DR As DataRow
    Private Cliente_tipo As Boolean = False

    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            DClientes = New AdoSQL("Clientes")
            DClientes.Open("select * from CLIENTES")

            'llamamos el metodo que asigna los valores a la grilla
            AsignaDataGrid(DGClientes, DClientes.Datatable)
            'vlida funcionalidad tipo cliente
            If ValidaFuncionalidad("Clientes.Tipo") Then
                Cliente_tipo = True
            End If
            If DGClientes.Rows.Count > 0 Then DGClientes_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub DGClientes_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGClientes.CellClick
        Try
            If DGClientes.RowCount = 0 Then Exit Sub
            TCodClient.Text = DGClientes.Rows(DGClientes.CurrentRow.Index).Cells("CodCli").Value.ToString.Trim
            TNomClient.Text = DGClientes.Rows(DGClientes.CurrentRow.Index).Cells("NomCli").Value.ToString.Trim
            Fila = DGClientes.CurrentRow.Index

            mnTCuenta.Text = (Fila + 1).ToString
            mnLCuenta.Text = DGClientes.RowCount.ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Fila = DGClientes.RowCount - 1
        mnTCuenta.Text = (Fila + 1).ToString()
        DGClientes.Rows(Fila).Selected = True
        DGClientes.FirstDisplayedScrollingRowIndex = Fila
        DGClientes.CurrentCell = DGClientes(0, Fila)

        DGClientes_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Dim indifila As Integer = 0
        indifila = DGClientes.RowCount - 1
        Fila += 1
        If Fila > indifila Then Fila = indifila
        mnTCuenta.Text = (Fila + 1).ToString()
        DGClientes.Rows(Fila).Selected = True
        DGClientes.FirstDisplayedScrollingRowIndex = Fila
        DGClientes.CurrentCell = DGClientes(0, Fila)
        DGClientes_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click
        Fila -= 1
        If Fila < 0 Then Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGClientes.Rows(Fila).Selected = True
        DGClientes.FirstDisplayedScrollingRowIndex = Fila
        DGClientes.CurrentCell = DGClientes(0, Fila)
        DGClientes_CellClick(Nothing, Nothing)

    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Fila = 0
        mnTCuenta.Text = (Fila + 1).ToString()
        DGClientes.Rows(Fila).Selected = True
        DGClientes.FirstDisplayedScrollingRowIndex = Fila
        DGClientes.CurrentCell = DGClientes(0, Fila)
        DGClientes_CellClick(Nothing, Nothing)

    End Sub


    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            'If DRUsuario("ModClientes") Then
            If ValidaPermiso("Clientes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            TCodClient.ReadOnly = False
            TNomClient.ReadOnly = False
            TCodClient.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try


            If TNomClient.Text.Trim = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Nombre"), vbInformation), vbInformation)
                Exit Sub
            End If

            If TCodClient.Text.Trim = "" Then
                MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "Código"), vbInformation), vbInformation)
                Exit Sub
            End If
            If Cliente_tipo = True Then
                If CTipo.Text = "" Then
                    MsgBox(MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, "definición de cliente o proveedor"), vbInformation), vbInformation)
                    Return
                End If
            End If
            DClientes.Open("select * from CLIENTES where CodCli='" + TCodClient.Text.Trim + "'")
            If DClientes.Count > 0 Then
                Resp = MessageBox.Show("El Cliente ya existe desea Sobre escribirlo", "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DClientes.AddNew()
            End If


            DClientes.RecordSet("CodCli") = CLeft(TCodClient.Text.ToUpper, 15)
            DClientes.RecordSet("NomCli") = CLeft(TNomClient.Text.ToUpper, 30)
            If Cliente_tipo = True Then
                DClientes.RecordSet("Tipo") = CTipo.Text
            End If
            DClientes.Update(Me)

            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Clientes_Load(Nothing, Nothing)
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        TCodClient.ReadOnly = True
        TNomClient.ReadOnly = True
        BActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            'If DRUsuario("ModClientes") Then
            If ValidaPermiso("Clientes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            TCodClient.ReadOnly = False
            TNomClient.ReadOnly = False
            TCodClient.Text = ""
            TNomClient.Text = ""
            TCodClient.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            'If DRUsuario("ModClientes") Then
            If ValidaPermiso("Clientes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Resp = vbNo Then Exit Sub

            DClientes.Delete("delete from Clientes where CodCli='" + TCodClient.Text.Trim + "'", Me)

            BActualizar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub mnAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaDe.Click
        AcercaD.ShowDialog()
    End Sub

    
    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Try
            BSalir_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnReportes.Click
        Reportes.ShowDialog()
    End Sub

    Private Sub mnProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnProductos.Click
        Productos.ShowDialog()
    End Sub
End Class