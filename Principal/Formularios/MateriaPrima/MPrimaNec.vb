Option Explicit On

Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data

Public Class MPrimaNec

    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DMPrimaNec As AdoSQL
    Private DVarios As AdoSQL
    Private DOps As AdoSQL
    Private Rep1 As CrystalRep

    'Objetos para la conexión a la base de datos de Premezclas

    Private DForPrem As AdoSQL
    Private DDatosForPrem As AdoSQL
    Private DMPrimaNecPrem As AdoSQL
    Private BusquedaPrimero As String = ""



    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub MPrimaNec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DFor = New AdoSQL("Formulas")
            DDatosFor = New AdoSQL("DatosFor")
            DMPrimaNec = New AdoSQL("MPrimaNec")
            DVarios = New AdoSQL("VARIOS")
            DOps = New AdoSQL("OPS")

            DFor.Open("select * from FORMULAS order by NomFor")
            DMPrimaNec.Open("select * from MPrimaNec order by PRIORIDAD")
            DVarios.Open("select CodFor,NomFor from FORMULAS group by CodFor,NomFor order by NomFor")

            'Objetos conexión base de datos premezclas
            DForPrem = New AdoSQL("Formulas")
            DDatosForPrem = New AdoSQL("DatosFor", RutaDB_ChrPremezclas)
            DMPrimaNecPrem = New AdoSQL("DatosFor", RutaDB_ChrPremezclas)

            'Valida funcionalidad exportar materia prima necesaria
            If ValidaFuncionalidad("Conexion.BD.Premezclas.Ext") Then
                BExportMpNec.Enabled = True
            End If

            If DMPrimaNec.Count > 0 Then AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)

            LLenaComboBox(TNomFor, DVarios.DataTable, "NomFor")
            LLenaComboBox(TCodFor, DVarios.DataTable, "CodFor")

            With TCodFor
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With

            With TNomFor
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TNomFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TNomFor.SelectedIndexChanged
        Try
            If BusquedaPrimero.Length > 0 Then Return

            DFor.Find("NOMFOR='" + TNomFor.Text + "'")

            If DFor.EOF Then
                Exit Sub
            End If
            BusquedaPrimero = "NOMFOR"
            TCodFor.Text = DFor.RecordSet("CODFOR").ToString
            TCodForB.Text = DFor.RecordSet("CODFORB").ToString

            DVarios.Open("select * from FORMULAS where ESTADO='APROBADO' and CODFOR='" + TCodFor.Text + "'")


            If DVarios.Count > 0 Then LLenaComboBox(TLP, DVarios.DataTable, "LP")
            TLP.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodFor.SelectedIndexChanged
        Try
            If BusquedaPrimero.Length > 0 Then Return
            DFor.Find("CODFOR='" + TCodFor.Text + "'")
            If DFor.EOF Then
                Exit Sub
            End If
            BusquedaPrimero = "CODFOR"
            TNomFor.Text = DFor.RecordSet("NOMFOR").ToString
            TCodForB.Text = DFor.RecordSet("CODFORB").ToString

            DVarios.Open("select * from FORMULAS where ESTADO='APROBADO' and CODFOR='" + TCodFor.Text + "'")

            If DVarios.Count > 0 Then LLenaComboBox(TLP, DVarios.DataTable, "LP")
            TLP.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try
            If TNomFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + ",debe seleccionar una fórmula del listado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Debe seleccionar una fórmula del listado", MsgBoxStyle.Information)
                Exit Sub
            End If

            If TCodFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + ",debe seleccionar una fórmula del listado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Debe seleccionar una fórmula del listado", MsgBoxStyle.Information)
                Exit Sub
            End If

            If TCodFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + ",debe seleccionar una Versión de fórmula del listado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Debe seleccionar una Versión de fórmula del listado", MsgBoxStyle.Information)
                Exit Sub
            End If
            If TBaches.Value = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "número de baches", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' MsgBox("Falta el número de baches", MsgBoxStyle.Information)
                Exit Sub
            End If

            DMPrimaNec.AddNew()

            DMPrimaNec.RecordSet("CODFOR") = CLeft(TCodFor.Text, 15)
            DMPrimaNec.RecordSet("NOMFOR") = CLeft(TNomFor.Text, 30)
            DMPrimaNec.RecordSet("BACHES") = TBaches.Value.ToString
            DMPrimaNec.RecordSet("PORC") = Eval(TPorc.Text)
            DMPrimaNec.RecordSet("PRIORIDAD") = Eval(TPrioridad.Text)
            DMPrimaNec.RecordSet("LP") = CLeft(TLP.Text, 15)
            DMPrimaNec.RecordSet("PESOPAQPREM") = Eval(TPesoPaqPrem.Text)
            DMPrimaNec.Update(Me)

            AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)
            BCancelar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            TNomFor.Text = ""
            TCodForB.Text = ""
            TCodFor.Text = ""
            TBaches.Text = ""
            TPrioridad.Text = ""
            BusquedaPrimero = ""
            TLP.Items.Clear()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            If DGPrimaNec.RowCount = 0 Then Exit Sub
            Dim CodF As String, LP As String

            CodF = DGPrimaNec.Rows(DGPrimaNec.CurrentRow.Index).Cells("CODFOR").Value.ToString
            LP = DGPrimaNec.Rows(DGPrimaNec.CurrentRow.Index).Cells("LP").Value.ToString

            'DMPrimaNec.Find("CodFor='" + CodF + "' and LP='" + LP + "'")

            'If DMPrimaNec.EOF Then Exit Sub
            'DMPrimaNec.RecordSet.Delete()          
            'DMPrimaNec.Update(Me)   

            DMPrimaNec.Delete("delete from MPrimaNec where  CodFor='" + CodF + "' and LP='" + LP + "'", Me)
            DMPrimaNec.Open("select * from MPrimaNec order by PRIORIDAD")
            AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            RespInput = MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOCONFIRMACION), vbInformation + vbYesNo, "cálcular materia prima necesaria")
            'Resp = MsgBox("Desea incializar los cálculos de materia prima necesaria ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
            If RespInput = vbNo Then Exit Sub
            DMPrimaNec.Delete("delete from MPrimaNec")

            AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    
    
    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialesToolStripMenuItem.Click
        Materiales.ShowDialog()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BCDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCDate.Click
        Dim RepSap As CrystalRep
        Try

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                'If TipoServer <> "SQLSERVER" Then .ServerName = NomDB
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
            End With

            Rep1 = RepSap

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpProg.Click
        Try
            BCDate_Click(Nothing, Nothing)

            Rep1.ReportFileName = RutaRep + "rpmpnecFor.rpt"
            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpNecMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpNecMP.Click
        Try

            BCDate_Click(Nothing, Nothing)
            Rep1.Formulas(2) = "TITULO1='REQUERIMIENTO MATERIA PRIMA'"
            Rep1.SelectionFormula = "{CMPrimaNec.A}<>'PR'"
            Rep1.ReportFileName = RutaRep + "rpmpnec.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpPrem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpPrem.Click
        Try

            BCDate_Click(Nothing, Nothing)
            Rep1.Formulas(2) = "TITULO1='INVENTARIO DE ADITIVOS'"
            Rep1.SelectionFormula = "{CMPrimaNec.A}='AD'"
            Rep1.ReportFileName = RutaRep + "rpmpnec.rpt"

            Rep1.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportar.Click
        Try


            DMPrimaNec.Open("delete from MPrimaNEC")

            DMPrimaNec.Open("select * from MPrimaNec order by PRIORIDAD")

            AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)

            If Planta.Contains("FUNZA") Then
                DOps.Open("Select * from OPS where ESTADO=10 and FINALIZADO='N' order by SECUENCIA")
            Else
                DOps.Open("select * from OPs where FINALIZADO='N'")

            End If


            If DOps.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO) + "para asignar al Requerimiento de Materia Prima.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MsgBox("No existen OPs pendientes para asignar al Requerimiento de Materia Prima.")
                Return
            End If

            For Each Recordset In DOps.Rows
                DMPrimaNec.AddNew()
                DMPrimaNec.RecordSet("CODFOR") = Recordset("CODFOR")
                DMPrimaNec.RecordSet("NOMFOR") = Recordset("NOMFOR")
                DMPrimaNec.RecordSet("BACHES") = Recordset("META") - Recordset("REAL")
                DMPrimaNec.RecordSet("LP") = Recordset("LP")
                DMPrimaNec.RecordSet("PRIORIDAD") = 0
                DMPrimaNec.RecordSet("PORC") = Recordset("PORC")
                DMPrimaNec.Update(Me)
            Next


            DMPrimaNec.Open("select * from MPrimaNec order by PRIORIDAD")

            AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)


        Catch ex As Exception
            MsgError(ex)
        End Try


    End Sub

   
    Private Sub BElimTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BElimTodo.Click
        Try
            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGELIMINAR) + "eliminará todo el programa de requerimiento de materia prima", vbInformation + vbYesNo)
            'RespInput = MsgBox("¿Seguro desea eliminar todo el programa de requrimiento de materia prima?", vbInformation)
            If Resp = vbNo Then Return

            DMPrimaNec.Open("Delete from MPRIMANEC")

            DMPrimaNec.Open("select * from MPrimaNec order by PRIORIDAD")

            AsignaDataGrid(DGPrimaNec, DMPrimaNec.DataTable)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TLP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TLP.SelectedIndexChanged
        Try
            BSumAditivos_Click(Nothing, Nothing)
            TBaches.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TBaches_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBaches.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return
            TPorc.Focus()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TPorc_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPorc.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return
            TPrioridad.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TPrioridad_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TPrioridad.KeyUp
        Try
            If e.KeyCode <> Keys.Enter Then Return
            BAceptar_Click(Nothing, Nothing)
            TNomFor.Focus()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGPrimaNec_CellValidating(ByVal sender As Object, _
ByVal e As DataGridViewCellValidatingEventArgs) Handles DGPrimaNec.CellValidating
        If DGPrimaNec.Rows(e.RowIndex).Cells("ID").Value Is Nothing Then Return
        Try
            Dim Campo As String = _
            DGPrimaNec.Columns(e.ColumnIndex).Name
            Dim ID As String = DGPrimaNec.Rows(e.RowIndex).Cells("ID").Value.ToString

            If DGPrimaNec.Columns(e.ColumnIndex).Name.ToUpper <> "BACHES" Then
                Return
            End If

            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            DMPrimaNec.Find("ID=" + ID)
            If DMPrimaNec.EOF Then Return

            DMPrimaNec.RecordSet(Campo) = e.FormattedValue.ToString
            DMPrimaNec.Update(Me)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub DGPrimaNec_CellEndEdit(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGPrimaNec.CellEndEdit

        Try
            ' Clear the row error in case the user presses ESC.   
            DGPrimaNec.Rows(e.RowIndex).ErrorText = String.Empty

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        MPrimaNec_Load(Nothing, Nothing)
    End Sub

    Private Sub BSumAditivos_Click(sender As System.Object, e As System.EventArgs) Handles BSumAditivos.Click
        Try

            If TLP.Text = "" Then Return

            DDatosFor.Open("Select sum(PESOMETA) as SumPesoMeta from DATOSFOR where A='AD' and CODFOR='" + TCodFor.Text + "' and LP='" + TLP.Text + "'")

            If DDatosFor.Count > 0 And Not IsDBNull(DDatosFor.RecordSet("SUMPESOMETA")) Then
                TPesoPaqPrem.Text = Eval(DDatosFor.RecordSet("SUMPESOMETA"))
            Else
                TPesoPaqPrem.Text = 0
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BExportMpNec_Click(sender As System.Object, e As System.EventArgs) Handles BExportMpNec.Click
        Try

            Resp = MsgBox("Desea exportar el requerimiento de materia prima al ChronoSoft de premezclas?", vbInformation + vbYesNo)
            If Resp = vbNo Then Return

            DMPrimaNec.Open("Select * from MPRIMANEC order BY PRIORIDAD")

            'Borramos el programa de necesidad de materias primas de micros
            DMPrimaNecPrem.Open("Delete from MPRIMANEC")

            DMPrimaNecPrem.Open("Select * from MPRIMANEC")



            For Each Fila As DataRow In DMPrimaNec.Rows

                DMPrimaNecPrem.AddNew()

                DMPrimaNecPrem.RecordSet("CODFOR") = Fila("CODFOR")
                DMPrimaNecPrem.RecordSet("NOMFOR") = Fila("NOMFOR")
                DMPrimaNecPrem.RecordSet("BACHES") = Fila("BACHES")
                DMPrimaNecPrem.RecordSet("PORC") = Fila("PORC")
                DMPrimaNecPrem.RecordSet("PRIORIDAD") = Fila("PRIORIDAD")
                DMPrimaNecPrem.RecordSet("LP") = Fila("LP")
                DMPrimaNecPrem.RecordSet("PESOPAQPREM") = Fila("PESOPAQPREM")
                DMPrimaNecPrem.Update(Me)

            Next

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TNomFor_Click(sender As Object, e As EventArgs) Handles TNomFor.Click
        Try
            BusquedaPrimero = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCodFor_Click(sender As Object, e As EventArgs) Handles TCodFor.Click
        BusquedaPrimero = ""
    End Sub
End Class