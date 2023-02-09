Imports System.Data
Imports System.String
Imports System.IO
Imports System.Data.Common
Imports System.Windows.Forms
Imports ChronoSoftNet
Public Class BasedeDatos
    Private Tipo As String
    Private Consulta As String = ""
    Private Delete As DbCommand
    Private DVarios As AdoSQL
    Private WithEvents BindSourc As New BindingSource

    Private FormLoad As Boolean

    Private Sub OpSeleccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpSeleccion.CheckedChanged
        If FormLoad = False Then Return

        PanSel.Visible = True
        PanBorrar.Visible = False
        Seleccion.Text = "Selección"
        PanBorrar.Show()
        BTraeTablas_Click(Nothing, Nothing)

    End Sub

    Private Sub OpBorrado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpBorrado.CheckedChanged
        PanSel.Visible = False
        PanBorrar.Visible = True
        Seleccion.Text = "Otras"
        PanSel.Select()
    End Sub


    Private Sub BTraeTablas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTraeTablas.Click


        Dim i As Integer
        Dim Tablas As DataTable
        Try


            If CONN.State = ConnectionState.Closed Then CONN.Open()

            Tablas = CONN.GetSchema("Tables")
            i = Tablas.Rows.Count - 1
            TTabla.Items.Clear()
            If i > -1 Then

                For i = 0 To Tablas.Rows.Count - 1
                    TTabla.Items.Add(Tablas.Rows(i)(Tablas.Columns(2).ColumnName).ToString)
                Next

            End If

            With TTabla
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BConsultar.Click
        Try
            If TTabla.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "de la Tabla no puede estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MessageBox.Show("El campo de la Tabla no puede estar vacío, seleccione una tabla del listado", "ChronoSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            TTabla.Enabled = False

            If TCampos.Text = "" Then TCampos.Text = "*"

            Consulta = "select " + TCampos.Text.Trim + " from " + TTabla.Text

            If TCondicion.Text <> "" Then
                Consulta += " where " + TCondicion.Text.Trim
            End If

            If TOrden.Text <> "" Then
                Consulta += " order by " + TOrden.Text.Trim
            End If

            DVarios = New AdoSQL("Varios")

            DVarios.Open(Consulta)
            DGDataBase.DataSource = BindSourc

            BindSourc.DataSource = DVarios.DataTable
            TNoRegistros.Text = DVarios.Count.ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEditar.Click
        Try
            If TCampos.Text <> "*" Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE) + "que para poder editar La tabla " + TTabla.Text + " debe seleccionar todos sus campos.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MessageBox.Show("Para poder editar La tabla " + TTabla.Text + " debe seleccionar todos sus campos.", "ChronoSoft", MessageBoxButtons.OK)
                Exit Sub
            End If

            If DGDataBase.RowCount <= 0 Then Exit Sub
            DGDataBase.ReadOnly = False

            DGDataBase.MultiSelect = False

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MnBGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBGuardar.Click
        Try
            DGDataBase.ReadOnly = True
            DGDataBase.AllowUserToAddRows = False
            DVarios.DataAdapter.Update(CType(BindSourc.DataSource, DataTable))

            BConsultar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub MnBBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBBorrar.Click
        Try

            BindSourc.RemoveCurrent()
            DVarios.DataAdapter.Update(CType(BindSourc.DataSource, DataTable))

            BConsultar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub OpNuevaConsulta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpNuevaConsulta.CheckedChanged
        Try
            If OpNuevaConsulta.CheckState = CheckState.Indeterminate Then Exit Sub
            TTabla.Enabled = True
            OpNuevaConsulta.CheckState = CheckState.Indeterminate
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Borrar(ByVal Sentencia As String)
        Try
            If CONN.State <> ConnectionState.Open Then CONN.Open()

            Delete.CommandText = Sentencia
            Delete.Connection = CONN
            Delete.ExecuteNonQuery()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnNuevo.Click
        Try

            DGDataBase.ReadOnly = False
            DGDataBase.MultiSelect = False
            DGDataBase.AllowUserToAddRows = True

            'DGDataBase.Rows.Add()
            'DGDataBase.Rows(DGDataBase.RowCount - 1).Selected = True
            'DGDataBase.FirstDisplayedScrollingRowIndex = DGDataBase.RowCount - 1
            'DGDataBase.CurrentCell = DGDataBase(0, DGDataBase.RowCount - 1)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub



    Private Sub BEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEjecutar.Click
        Try
            Borrar(TSentencia.Text.Trim)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub



    Private Sub MnBCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBCancelar.Click
        Try
            DGDataBase.ReadOnly = True

            BConsultar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub MnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DGDataBase_CellValidating(ByVal sender As Object,
    ByVal e As DataGridViewCellValidatingEventArgs) _
    Handles DGDataBase.CellValidating
        Try
            Tipo = DVarios.Rows(0).Item(e.ColumnIndex).GetType.Name

            If (Tipo = "Byte" OrElse Tipo = "Single" OrElse Tipo = "Int32" OrElse Tipo = "Short" OrElse Tipo = "Long" OrElse Tipo = "Double") _
           AndAlso (e.FormattedValue.ToString() = Nothing _
           OrElse Not IsNumeric(e.FormattedValue.ToString())) Then
                DGDataBase.Rows(e.RowIndex).ErrorText =
                    "Debe ingresar un dato valido para este campo"
                e.Cancel = True
            ElseIf (Tipo = "String" OrElse Tipo = "Boolean") AndAlso (String.IsNullOrEmpty(e.FormattedValue.ToString())) Then
                DGDataBase.Rows(e.RowIndex).ErrorText =
                    "Debe ingresar un dato valido para este campo"
                e.Cancel = True
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGDataBase_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGDataBase.CellEndEdit
        Try
            ' Tipo = DTConsulta.Rows(0).Item(e.ColumnIndex).GetType.Name

            ' If (Tipo = "Byte" OrElse Tipo = "Single" OrElse Tipo = "Int32" OrElse Tipo = "Short" OrElse Tipo = "Long" OrElse Tipo = "Double") _
            'AndAlso (DGDataBase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing _
            'OrElse IsNumeric(DGDataBase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) = False) Then
            '     MsgBox("Debe ingresar un dato valido para este campo")

            ' ElseIf (Tipo = "String" OrElse Tipo = "Boolean") AndAlso (DGDataBase.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing) Then
            '     MsgBox("Debe ingresar un dato valido para este campo")
            ' End If
            ' Clear the row error in case the user presses ESC.   
            DGDataBase.Rows(e.RowIndex).ErrorText = String.Empty

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BasedeDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DbProvedor = DbProviderFactories.GetFactory("System.Data.SqlClient")
            'Toma los parametros del Provedor segun el caso
            CONN = DbProvedor.CreateConnection
            CONN.ConnectionString = RutaDB

            DVarios = New AdoSQL("Varios")

            Delete = DbProvedor.CreateCommand

            FormLoad = True

            Evento("Ingresa a modificar base de datos")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MnAcercaD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaD.Click
        AcercaD.ShowDialog()
    End Sub
End Class