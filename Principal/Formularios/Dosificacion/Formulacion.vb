Option Explicit On

Imports System.Windows.Forms
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports System.Threading.Thread
Imports ClassLibrary


Public Class Formulacion
    Private DNutFor As AdoSQL
    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DVarios As AdoSQL
    Private DConsultas As AdoSQL
    Private DFormFiltros As AdoSQL
    Private DBorrarForm As AdoSQL
    Private DModosImprimir As AdoSQL
    Private DBasc As AdoSQL
    Private DRestricciones As AdoSQL
    Private Campos() As String
    Private Fila As Integer
    Private Rep1 As CrystalRep
    Private Rep2 As CrystalRep
    Private BBascula As ArrayControles(Of Button)
    Private RBFiltro As ArrayControles(Of RadioButton)
    Private TTotalBasc As ArrayControles(Of TextBox)
    Private FormLoad As Boolean
    Private CapBasc(100) As Double
    Private NumMaxBasc As Integer
    Private cadenaAgrupacionPM As String
    Private RestriccionEstablecimiento As String

    Public TablaEspecies As Dictionary(Of String, String)
    Public TablaGrpFor As Dictionary(Of String, String)

    'Objetos para la conexión a la base de datos de Premezclas

    Private DForPrem As AdoSQL
    Private DDatosForPrem As AdoSQL

    Public Sub InicializacionTablasContCruzada()
        Try
            TablaEspecies = New Dictionary(Of String, String)
            TablaGrpFor = New Dictionary(Of String, String)

            DVarios.Open("select * from ESPECIES ORDER BY CODESPECIE")

            'Llenamos la tabla de especies
            For Each FilaEsp As DataRow In DVarios.Rows
                TablaEspecies.Add(Mid(FilaEsp("CODESPECIE") + Space(5), 1, 5) + FilaEsp("NOMESPECIE"), FilaEsp("NOMESPECIE"))
                TCodEspecie.Items.Add(Mid(FilaEsp("CODESPECIE") + Space(5), 1, 5) + FilaEsp("NOMESPECIE"))
                FormulacionDet.TCodEspecie.Items.Add(Mid(FilaEsp("CODESPECIE") + Space(5), 1, 5) + FilaEsp("NOMESPECIE"))
            Next

            DVarios.Open("select * from GRPFORMULAS order by CODGRPFOR")
            'Llenamos la tabla de grupos de formulas
            For Each FilaGrpForm As DataRow In DVarios.Rows
                TablaGrpFor.Add(Mid(FilaGrpForm("CODGRPFOR") + Space(5), 1, 5) + FilaGrpForm("NOMGRPFOR"), FilaGrpForm("NOMGRPFOR"))
                TCodGrpFor.Items.Add(Mid(FilaGrpForm("CODGRPFOR") + Space(5), 1, 5) + FilaGrpForm("NOMGRPFOR"))
                FormulacionDet.TCodGrpFor.Items.Add(Mid(FilaGrpForm("CODGRPFOR") + Space(5), 1, 5) + FilaGrpForm("NOMGRPFOR"))
            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Function Devuelve_NombreEspecie(ByVal Codigo As String)
        Try
            Devuelve_NombreEspecie = ""

            If Codigo = "" Then Return Devuelve_NombreEspecie
            Devuelve_NombreEspecie = TablaEspecies(Codigo).ToString
            Return Devuelve_NombreEspecie
        Catch ex As Exception
            MsgError(ex)
            Devuelve_NombreEspecie = ""
        End Try
    End Function

    Public Function Devuelve_NombreGrpFor(ByVal Codigo As String)
        Try
            Devuelve_NombreGrpFor = ""

            If Codigo = "" Then Return Devuelve_NombreGrpFor
            Devuelve_NombreGrpFor = TablaGrpFor(Codigo).ToString
            Return Devuelve_NombreGrpFor
        Catch ex As Exception
            MsgError(ex)
            Devuelve_NombreGrpFor = ""
        End Try
    End Function

    Public Sub Formulacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cadenaAgrupacionPM = ConfigParametros("rpEspecialAgrupado")
            'Si el formulario ya está cargado no lo vuelve a cargar
            If FormLoad = True Then
                BActualizar_Click(Nothing, Nothing)
                BBuscaForm_Click(Nothing, Nothing, NuevaOP.TCodFor.Text, NuevaOP.TLP.Text)
                Return
            End If

            DFor = New AdoSQL("Formulas")
            DDatosFor = New AdoSQL("DatosFor")
            DVarios = New AdoSQL("Varios")
            DConsultas = New AdoSQL("Consultas")
            DFormFiltros = New AdoSQL("FormFiltros")
            DBorrarForm = New AdoSQL("Formulas,datosfor")
            DBasc = New AdoSQL("Basculas")
            DModosImprimir = New AdoSQL("Basculas")
            DRestricciones = New AdoSQL("Restricciones")
            DNutFor = New AdoSQL("NUTFOR")

            'Se abre este objeto para imprimir solo los modos seleccionados 
            DModosImprimir.Open("Select * from BASCULAS where IMPRIMIR=1")


            TTotalBasc = New ArrayControles(Of TextBox)("TTotalBasc", Me)


            If Funcion_BasedeDatosPremExterna Then
                'Objetos conexión base de datos premezclas
                DForPrem = New AdoSQL("Formulas", RutaDB_ChrPremezclas)
                DDatosForPrem = New AdoSQL("DatosFor", RutaDB_ChrPremezclas)
            End If

            For i = 1 To 8
                CapBasc(i) = 0
                TTotalBasc(i).BackColor = Color.LightGray
            Next

            'Se trae la capcidad de la báscula desde la tabla blasculas
            DBasc.Open("Select * from BASCULAS where A='A' order by BASCULA")

            For Each Fila As DataRow In DBasc.Rows
                CapBasc(Fila("BASCULA")) = Fila("CAPAC")
            Next


            DConsultas.Open("select * from CONSULTAS")

            DFor.Open("Select * from FORMULAS where CODFOR='0'")

            If Funcion_ManejaRestriccionLineasNegocio Then
                'Se revisa en la tabla restricciones si hay restriccion para esa linea de negocio
                'En el campo restriccion se encuentra la sentencia de filtro
                DRestricciones.Open("SELECT * FROM RESTRICCIONES WHERE LINEANEGOCIO='" + DRUsuario("LINEANEGOCIO") + "'")
                If DRestricciones.Count Then
                    RestriccionEstablecimiento = DRestricciones.RecordSet("RESTRICCION")
                End If
            End If


            DFormFiltros.Open("Select * from FORMFILTROS where HABILITADO=1 order by POSICION")


            Campos = {"CodFor@Cód.Int.", "CodForB@Cód.Ext.", "NomFor@Nombre", "LP@Orden"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DFor.DataTable)

            CBBuscar.Text = "CodFor"

            FiltrosFormulacion(Me.GBFiltro, OPFiltro, 8, 16, Me)
            RBFiltro = New ArrayControles(Of RadioButton)("RBFiltro", Me)

            For Each RB As RadioButton In RBFiltro.Values
                AddHandler RB.Click, AddressOf RBFiltro_Click
            Next

            BActualizarPesoPrem.Enabled = False
            If Funcion_BasedeDatosPremExterna Then BActualizarPesoPrem.Enabled = True

            'Se carga el formulario formulas
            FormulacionDet.Formulas_Load(Nothing, Nothing)

            'Se cargan las tablas de diccionarios de datos de especies y codgrpform
            InicializacionTablasContCruzada()

            ' Asignamos los datos al datagrid y luego seleccionamos la primera fila para mostrar
            ' DatosFor
            BActualizar_Click(Nothing, Nothing)

            OPTodos_Click(Nothing, Nothing)
            FormLoad = True
            NuevaOP.NuevaOP_Load(Nothing, Nothing)



        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub DGFor_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGFor.CellClick
        Try
            Dim CFor As String
            Dim CLP As String
            Dim ManejaPx As Boolean
            Dim CodGrpFor As String = ""
            Dim CodEspecie As String = ""


            If DGFor.RowCount = 0 Then Return


            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim
            ManejaPx = DGFor.Rows(DGFor.CurrentRow.Index).Cells("MANEJAPX").Value


            DDatosFor.Open("select * from DATOSFOR where TIPOMAT<40 and CODFOR='" + CFor + "' and LP='" + CLP + "' order by PASO")
            AsignaDataGrid(DGDatosFor, DDatosFor.DataTable, True)


            If OPFiltro.Checked Then
                TSumaIng.Text = Eval(SumColumn(DGDatosFor, "DGDatosFor_PesoMeta").ToString) - SumPaqPrem(DGDatosFor, ManejaPx, True)
            Else
                TSumaIng.Text = SumColumn(DGDatosFor, "DGDatosFor_PesoMeta").ToString
            End If

            DVarios.Open("select * from FORMULAS where CODFOR='" + CFor + "' and LP='" + CLP + "'")

            CodEspecie = DVarios.RecordSet("CODESPECIE")
            CodGrpFor = DVarios.RecordSet("CODGRPFOR")

            TObservaciones.Text = "-"
            If DVarios.Count > 0 Then

                TObservaciones.Text = DVarios.RecordSet("OBSERV").ToString
                TCodPremezclas.Text = DVarios.RecordSet("CODPREMEZCLA").ToString
                TMSeca.Text = DVarios.RecordSet("TMSECA").ToString
                TMHumeda.Text = DVarios.RecordSet("TMHUMEDA").ToString
                TUsuarioImp.Text = DVarios.RecordSet("USUARIOIMPFOR").ToString

                DVarios.Open("Select * FROM ESPECIES where CODESPECIE='" + CodEspecie + "'")
                If DVarios.Count Then TCodEspecie.Text = Mid(DVarios.RecordSet("CODESPECIE") + Space(5), 1, 5) + DVarios.RecordSet("NOMESPECIE")

                DVarios.Open("Select * FROM GRPFORMULAS where CODGRPFOR='" + CodGrpFor + "'")
                If DVarios.Count Then TCodGrpFor.Text = Mid(DVarios.RecordSet("CODGRPFOR") + Space(5), 1, 5) + DVarios.RecordSet("NOMGRPFOR")


            End If

            TNomEspecie.Text = "-"
            TNomGrpFor.Text = "-"

            TNomEspecie.Text = Devuelve_NombreEspecie(TCodEspecie.Text)
            TNomGrpFor.Text = Devuelve_NombreGrpFor(TCodGrpFor.Text)

            mnLCuenta.Text = DGFor.Rows.Count.ToString

            Fila = DGFor.CurrentRow.Index
            mnTCuenta.Text = (Fila + 1).ToString

            For i = 1 To 8
                If CapBasc(i) = 0 Then Continue For
                DVarios.Open("Select SUM(PESOMETA) AS TOTALBASC" + i.ToString + " FROM DATOSFOR WHERE TIPOMAT<40 AND CODFOR='" + CFor + "' and LP='" + CLP + "' AND BASCULA=" + i.ToString)
                TTotalBasc(i).Text = 0
                If DVarios.Count AndAlso Not IsDBNull(DVarios.RecordSet("TOTALBASC" + i.ToString)) Then
                    TTotalBasc(i).Text = Format(DVarios.RecordSet("TOTALBASC" + i.ToString), ".000")
                End If
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub OPTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTodos.Click
        Try
            AsignaDataGrid(DGDatosFor, DDatosFor.DataTable, True)

            Dim CFor As String = ""
            Dim CLP As String
            Dim ManejaPx As Boolean = False
            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim
            ManejaPx = DGFor.Rows(DGFor.CurrentRow.Index).Cells("ManejaPx").Value

            TSumaIng.Text = Eval(SumColumn(DGDatosFor, "DGDatosFor_PesoMeta").ToString) - SumPaqPrem(DGDatosFor, ManejaPx, True)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click, mnSalir.Click
        Try
            Me.Hide()
            ''Me.Dispose()
            ''Me.Close()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Try
            'If DRUsuario("FormMod") Or DRUsuario("FormModDosif") Then
            If ValidaPermiso("Formulas_Editar, Formulas_EditarBasculas ") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Dim CFor As String
            Dim CLP As String
            Dim CodEstablecimiento As String
            Dim DBaches As New AdoSQL("BACHES")
            Dim DBachesAux As New AdoSQL("BACHES")

            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim
            CodEstablecimiento = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODESTABLECIMIENTO").Value.ToString.Trim


            'Revisa que los ultimos baches no sean de la fórmula a editar
            'DBaches.Open("select TOP 5 * from BACHES WHERE LINEAINVENT<>'SALES' and NOMFOR NOT LIKE '%LIMPIEZA%' AND ESTADO<10 ORDER by FECHA desc")
            DBaches.Open("select TOP 5 * from BACHES ORDER by FECHA desc")

            For Each RSBaches As DataRow In DBaches.Rows
                If (RSBaches("CODFOR") = CFor AndAlso RSBaches("LP") = CLP) Then
                    Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula ya que se " +
                            " encuentra en proceso de dosificación y alteraría los Reportes", MsgBoxStyle.Critical)
                    Return
                End If
            Next

            If Funcion_ManejaTablaProcDosif Then
                'Si se está produciendo una formula en cualquier bascula de la tabla ProcesoDosif
                DVarios.Open("select * from PROCDOSIF WHERE CODFOR='" + CFor + "' AND LP='" + CLP + "'")
                If DVarios.Count Then
                    Resp = MsgBox("No debe alterar ni agregar códigos de materia prima a esta fórmula ya que se " +
                            " encuentra en proceso de dosificación y alteraría los Reportes", MsgBoxStyle.Critical)
                    Return
                End If
            End If
            FormulacionDet.TCodFor.Text = CFor
            FormulacionDet.TLP.Text = CLP
            FormulacionDet.TNuevoEditar.Text = "EDITAR"
            FormulacionDet.OPTodos.Checked = True
            FormulacionDet.FCargaDatosFor_Click(Nothing, Nothing)
            FormulacionDet.ShowDialog()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            'Si oprimen la tecla suprimir
            If e.KeyCode = Keys.Delete Then
                BEliminar_Click(Nothing, Nothing)
                Return
            End If


            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                Formulacion_Load(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            BusquedaDG(DGFor, DFor.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                Exit Sub
            End If

            DGFor_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub ChModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChModificarForm.Click
        Try
            'If DRUsuario("CALIDAD") Then
            If ValidaPermiso("Calidad") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If ChModificarForm.Checked <> True Then
                BAceptar.Visible = False
                BCancelar.Visible = False
                Exit Sub
            Else
                BAceptar.Visible = True
                BCancelar.Visible = True
            End If

            TCodEspecie.Enabled = True
            TCodGrpFor.Enabled = True

            TMSeca.ReadOnly = False
            TMHumeda.ReadOnly = False

            TCodPremezclas.ReadOnly = False

        Catch ex As Exception
            MsgError(ex)

        End Try
    End Sub


    Private Sub TCodEspecie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodEspecie.SelectedIndexChanged
        Try
            TNomEspecie.Text = "-"
            TNomEspecie.Text = Devuelve_NombreEspecie(TCodEspecie.Text)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodGrpFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodGrpFor.SelectedIndexChanged
        Try
            TNomGrpFor.Text = "-"
            TNomGrpFor.Text = Devuelve_NombreGrpFor(TCodGrpFor.Text)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TObservaciones.TextChanged
        Try
            TObservaciones.CharacterCasing = CharacterCasing.Upper
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            If TCodEspecie.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Especie"), MsgBoxStyle.Information)
                Return
            End If

            If TCodGrpFor.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Grupo Fórmula"), MsgBoxStyle.Information)
                Return
            End If

            Dim CFor As String
            Dim CLP As String

            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim

            DFor.Open("select * from FORMULAS where CODFOR='" + CFor + "' and LP='" + CLP + "'")

            If DFor.Count = 0 Then Exit Sub

            DFor.RecordSet("CODESPECIE") = Mid(TCodEspecie.Text.Trim.ToUpper, 1, 5).Trim
            DFor.RecordSet("CODGRPFOR") = Mid(TCodGrpFor.Text.Trim.ToUpper, 1, 5).Trim
            DFor.RecordSet("OBSERV") = CLeft(TObservaciones.Text, 100)
            DFor.RecordSet("CODPREMEZCLA") = TCodPremezclas.Text
            DFor.RecordSet("TMSECA") = Val(TMSeca.Text)
            DFor.RecordSet("TMHUMEDA") = Val(TMHumeda.Text)
            DFor.RecordSet("MEZCEXT") = ChMezcExt.Checked
            DFor.Update(Me)

            ChModificarForm.Checked = False
            TMSeca.ReadOnly = True
            TMHumeda.ReadOnly = True
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Try
            TCodEspecie.Enabled = False
            TCodGrpFor.Enabled = False
            TCodPremezclas.ReadOnly = True
            ChModificarForm.Checked = False
            TMSeca.Enabled = False
            TMHumeda.Enabled = False
            DGFor_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            FormulacionDet.TNuevoEditar.Text = "NUEVA"
            FormulacionDet.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEliminar.Click
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            FBorraForm_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        Try
            'DGFor.DataSource = ""


            If Funcion_ManejaRestriccionLineasNegocio And ServComM = False Then
                'Se revisa en la tabla restricciones si hay restriccion para esa linea de negocio
                'En el campo restriccion se encuentra la sentencia de filtro
                DFor.Open("select * from FORMULAS WHERE " + RestriccionEstablecimiento + " order by NOMFOR")
            Else
                DFor.Open("select * from FORMULAS order by NOMFOR")
            End If
            AsignaDataGrid(DGFor, DFor.DataTable)
            If DFor.Count = 0 Then
                'DDatosFor.Open("select * from DATOSFOR where TIPOMAT<40 and CODFOR='0' and LP='0' order by PASO")
                'AsignaDataGrid(DGDatosFor, DDatosFor.DataTable, True)
                DGDatosFor.Rows.Clear() 'Si no hay fórmulas no debe haber ingredientes en el DataGrid
                Return
            End If
            DGFor.Rows(0).Selected = True
            DGFor.CurrentCell = DGFor(0, 0)
            DGFor.FirstDisplayedScrollingRowIndex = 0
            DGFor_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub CBEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBEliminar.Click
        BEliminar_Click(Nothing, Nothing)
    End Sub

    Private Sub CBNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNuevo.Click
        BNuevo_Click(Nothing, Nothing)
    End Sub

    Private Sub CBActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBActualizar.Click
        BActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub CBEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBEditar.Click
        BEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub BAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnterior.Click

        Try
            If DGFor.Rows.Count = 0 Then Exit Sub

            Fila -= 1

            If Fila < 0 Then Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGFor.Rows(Fila).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = Fila
            DGFor.CurrentCell = DGFor(0, Fila)
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrimero.Click
        Try
            If DGFor.Rows.Count = 0 Then Exit Sub

            Fila = 0
            mnTCuenta.Text = (Fila + 1).ToString()

            DGFor.Rows(Fila).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = Fila
            DGFor.CurrentCell = DGFor(0, Fila)
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUltimo.Click
        Try

            If DGFor.Rows.Count = 0 Then Exit Sub
            Fila = DGFor.Rows.Count - 1
            mnTCuenta.Text = (Fila + 1).ToString()
            DGFor.Rows(Fila).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = Fila
            DGFor.CurrentCell = DGFor(0, Fila)
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub
    Private Sub BSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSiguiente.Click
        Try

            If DGFor.Rows.Count = 0 Then Exit Sub
            Dim indifila As Integer = 0
            indifila = DGFor.RowCount - 1
            Fila += 1
            If Fila > indifila Then Fila = indifila
            mnTCuenta.Text = (Fila + 1).ToString()

            DGFor.Rows(Fila).Selected = True
            DGFor.FirstDisplayedScrollingRowIndex = Fila
            DGFor.CurrentCell = DGFor(0, Fila)
            DGFor_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BTablasSecuenciaMezc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTablasSecuenciaMezc.Click
        Try
            If ValidaPermiso("SecuenciaMezcla_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            TablasSecuenciaMezcla.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BOPs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOPs.Click
        'If DRUsuario("OPsVer") Or DRUsuario("OPsMod") Then
        If ValidaPermiso("OPs_Ver, OPs_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        NuevaOP.ShowDialog()
    End Sub

    Private Sub TOPs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim CFor As String = ""
            Dim CLP As String = ""

            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim
            TCantProducir.Text = (Eval(TPorc.Text) * Eval(TBaches.Text) * Eval(TSumaIng.Text) / 100).ToString
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BBuscaForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal CodFor As String = "", Optional ByVal LP As String = "") Handles BBuscaForm.Click
        Try
            For Each Filasel As DataGridViewRow In DGFor.Rows
                If Filasel.Cells("CODFOR").Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing Then
                    Continue For
                End If
                'MsgBox(filas("NOMMAT").ToString)
                If CodFor = Filasel.Cells("CODFOR").Value.ToString And LP = Filasel.Cells("LP").Value.ToString Then
                    DGFor.Rows(Filasel.Index).Selected = True
                    DGFor.CurrentCell = DGFor(0, Filasel.Index)
                    DGFor.FirstDisplayedScrollingRowIndex = Filasel.Index
                    DGFor_CellClick(Nothing, Nothing)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGFor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        DGFor_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGFor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        DGFor_CellClick(Nothing, Nothing)
    End Sub

    Private Sub BImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImportar.Click
        ImportFor.ShowDialog()
    End Sub

    Private Sub BDuplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDuplicar.Click
        Dim LPAct As String = "", CodForAct As String = "", CodExtAct As String = "", NomForAct As String = ""
        Dim LPNew As String = "", CodForNew As String = "", CodForBNew As String = "", NomForNew As String = ""
        Try
            'If DRUsuario("FormMod") Then
            If ValidaPermiso("Formulas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            CodForAct = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            LPAct = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim
            CodExtAct = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFORB").Value.ToString.Trim
            NomForAct = DGFor.Rows(DGFor.CurrentRow.Index).Cells("NOMFOR").Value.ToString.Trim

            RespInput = CodForAct
            If InputBox.InputBox("Duplicar Fórmula", "Ingrese el Código Interno de la fórmula destino", RespInput) = DialogResult.Cancel Then
                Exit Sub
            End If

            CodForNew = Eval(RespInput)
            RespInput = CodExtAct
            If InputBox.InputBox("Duplicar Fórmula", "Ingrese el Código Externo de la fórmula destino", RespInput) = DialogResult.Cancel Then
                Exit Sub
            End If
            CodForBNew = RespInput

            RespInput = NomForAct
            If InputBox.InputBox("Duplicar Fórmula", "Ingrese el Nombre de la fórmula destino", RespInput) = DialogResult.Cancel Then
                Exit Sub
            End If

            NomForNew = RespInput

            RespInput = ""
            If InputBox.InputBox("Duplicar Fórmula", "Ingrese la versión de la fórmula destino", RespInput) = DialogResult.Cancel Then
                Exit Sub
            End If
            LPNew = RespInput

            If LPAct = LPNew And CodForAct = CodForNew Then
                MsgBox("La Fórmula a Duplicar no puede tener el mismo Código interno ni la misma versión de Fórmula", MsgBoxStyle.Critical)
                Return
            End If

            DFor.Open("select * from FORMULAS where CODFOR='" + CodForNew + "' and LP='" + LPNew + "'")
            If DFor.Count > 0 Then
                Resp = MsgBox("Va a reemplazar la Fórmula " + DFor.RecordSet("NOMFOR").ToString + " con Versión " + LPNew + vbCrLf + "Desea continuar?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "COPIANDO FORMULA")
                If Resp = vbNo Then Exit Sub
            End If
            DFor.Delete("delete from FORMULAS where CODFOR='" + CodForNew + "' and LP='" + LPNew + "'", Me)

            DVarios.Open("select * from FORMULAS where CODFOR='" + CodForAct + "' and LP='" + LPAct + "'")

            If DVarios.Count = 0 Then Return

            DFor.AddNew()
            DFor.RecordSet("CODFOR") = CLeft(CodForNew, 15)
            DFor.RecordSet("CODFORB") = CLeft(CodForBNew, 15)
            DFor.RecordSet("NOMFOR") = CLeft(NomForNew.ToUpper, 30)
            DFor.RecordSet("TOTALFOR") = Eval(TSumaIng.Text)
            DFor.RecordSet("CODESPECIE") = DVarios.RecordSet("CODESPECIE")
            DFor.RecordSet("CODGRPFOR") = DVarios.RecordSet("CODGRPFOR")
            DFor.RecordSet("TMSECA") = DVarios.RecordSet("TMSECA")
            DFor.RecordSet("TMHUMEDA") = DVarios.RecordSet("TMHUMEDA")
            DFor.RecordSet("MANEJAPX") = DVarios.RecordSet("MANEJAPX")
            DFor.RecordSet("CODPREMEZCLA") = DVarios.RecordSet("CODPREMEZCLA")
            DFor.RecordSet("FECHAFOR") = Now.ToString("dd/MM/yyyy")
            DFor.RecordSet("USUARIOIMPFOR") = UsuarioPrincipal
            DFor.RecordSet("CODESTABLECIMIENTO") = DVarios.RecordSet("CODESTABLECIMIENTO")
            DFor.RecordSet("LP") = LPNew

            'If Funcion_ManejaFylax Then
            '    DFor.RecordSet("PORCADICFILAX") = DVarios.RecordSet("PORCADICFILAX")
            '    DFor.RecordSet("TIPOALIMENTO") = DVarios.RecordSet("TIPOALIMENTO")
            '    DFor.RecordSet("HABCORRHUM") = DVarios.RecordSet("HABCORRHUM")
            '    DFor.RecordSet("NUMRECETA") = DVarios.RecordSet("NUMRECETA")
            '    DFor.RecordSet("SPHUMEDAD") = DVarios.RecordSet("SPHUMEDAD")
            '    DFor.RecordSet("PORCADICAGUA") = DVarios.RecordSet("PORCADICAGUA")
            'End If

            DFor.RecordSet("HUMEDADFOR") = DVarios.RecordSet("HUMEDADFOR")

            DFor.Update(Me)

            DDatosFor.Delete("delete from DATOSFOR where CODFOR='" + CodForNew + "' and LP='" + LPNew + "'", Me)

            DVarios.Open("select * from DATOSFOR where CODFOR='" + CodForAct + "' and LP='" + LPAct + "'")

            For Each RecordSet In DVarios.Rows
                DDatosFor.AddNew()
                DDatosFor.RecordSet("CODMAT") = RecordSet("CODMAT")
                DDatosFor.RecordSet("CODMATB") = RecordSet("CODMATB")
                DDatosFor.RecordSet("NOMMAT") = RecordSet("NOMMAT")
                DDatosFor.RecordSet("PESOMETA") = RecordSet("PESOMETA")
                DDatosFor.RecordSet("BASCULA") = RecordSet("BASCULA")
                DDatosFor.RecordSet("PASO") = RecordSet("PASO")
                DDatosFor.RecordSet("A") = RecordSet("A")
                DDatosFor.RecordSet("TIPOMAT") = RecordSet("TIPOMAT")
                DDatosFor.RecordSet("CODFOR") = CodForNew
                DDatosFor.RecordSet("CODFORB") = CodForBNew
                DDatosFor.RecordSet("LP") = LPNew
                DDatosFor.RecordSet("TOLVA") = RecordSet("TOLVA")
                DDatosFor.RecordSet("NOMTOLVA") = RecordSet("NOMTOLVA")
                DDatosFor.RecordSet("TOLINF") = RecordSet("TOLINF")
                DDatosFor.RecordSet("TOLSUP") = RecordSet("TOLSUP")

                DDatosFor.Update(Me)
            Next

            DVarios.Open("select * from NUTFOR where CODFOR='" + CodForAct + "' and LP='" + LPAct + "'")
            DNutFor.Open("select * from NUTFOR where CODFOR='" + CodForNew + "' and LP='" + LPNew + "'")

            For Each RecordSet In DVarios.Rows
                DNutFor.AddNew()
                DNutFor.RecordSet("CODFOR") = CodForNew
                DNutFor.RecordSet("LP") = LPNew
                DNutFor.RecordSet("ITEM") = RecordSet("ITEM")
                DNutFor.RecordSet("NOMNUT") = RecordSet("NOMNUT")
                DNutFor.RecordSet("CANTIDAD") = RecordSet("CANTIDAD")
                DNutFor.RecordSet("UNDS") = RecordSet("UNDS")
                DNutFor.Update()

            Next

            EventoAuditoria(DevuelveEvento(CodEvento.FORMULA_DUPLICAR), Me, Accion.DUPLICAR, "Formulas", "CodFor", CodForAct)

            BActualizar_Click(Nothing, Nothing)
            BBuscaForm_Click(Nothing, Nothing, CodForNew, LPNew)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCDate.Click
        Dim RepSap As CrystalRep
        Try
            If DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim = Nothing Then Return
            DConsultas.Refresh()
            DConsultas.RecordSet("F1") = Format(Now, "yyyy/MM/dd")
            DConsultas.RecordSet("H1") = Format(Now, "HH:mm")
            DConsultas.RecordSet("T6") = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            DConsultas.RecordSet("T7") = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim

            DConsultas.Update()

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                'If TipoServer <> "SQLSERVER" Then .ServerName = NomDB
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                '.ReportFileName = RutaRep + "rpespec.rpt" '"RpEspec.rpt"
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
                '.Formulas(0) = "Lote='-'"
                '.Formulas(2) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "'"
                '.Formulas(3) = "Baches=' " + TBaches.Text + "'"
                '.Formulas(4) = "OP=' " + TOPs.Text + " '"
                '.Formulas(5) = "ACUMPRS=' 0'"
                '.Formulas(6) = "TamBP=' " + Trim(Eval(TPorc.Text)) + " '"
                '.Formulas(7) = "Planta='  " + Planta + " ' "
            End With

            Rep1 = RepSap

        Catch ex As Exception

        End Try
    End Sub



    Private Sub mnImpFormAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpFormAct.Click
        Dim RepSap As CrystalRep
        Try

            DConsultas.Refresh()
            DConsultas.RecordSet("F1") = Format(Now, "yyyy/MM/dd")
            DConsultas.RecordSet("H1") = Format(Now, "HH:MM")
            DConsultas.RecordSet("T6") = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            DConsultas.RecordSet("T7") = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim

            DConsultas.Update()

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD

                .Formulas(0) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm") + "'"
                .Formulas(1) = "PLANTA='" + Planta + "'"
                .Formulas(2) = "OP='" + TOPs.Text + "'"
                .SelectionFormula = "{CFormula.TipoMat}<>7 and {CFormula.TipoMat}<20"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With

            RepSap.ReportFileName = RutaRep + "rpformula.rpt"
            RepSap.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpEsp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            If Eval(TOPs.Text) = 0 Then
                MsgBox("Debe seleccionar una OP para imprimir todas las secciones de la formulación ", MsgBoxStyle.Information)
                NuevaOP.ShowDialog()
            End If

            Dim BachesPend As Int16
            Dim CFor As String
            Dim CLP As String

            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim

            Resp = MsgBox("Desea imprimir los materiales PESADA MANUAL?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo)
            If Resp = vbYes Then

                BCDate_Click(Nothing, Nothing)

                Rep1.Formulas(0) = "BACHES='" + Trim(BachesPend) + "'"
                Rep1.Formulas(1) = "OP='" + TOPs.Text + "'"
                Rep1.Formulas(2) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "'"
                Rep1.Formulas(3) = "SECCION='PESADA MANUAL'"

                RespInput = 0

                Rep1.SelectionFormula = "({CFormula.TipoMat}=8 or {CFormula.TipoMat}=6 or {CFormula.TipoMat}=7 or {CFormula.A}='MD') and ({CFormula.A}<>'FL' and {CFormula.A}<>'PE')"
                Rep1.ReportFileName = RutaRep + "rpespec.rpt"
                Rep1.PrintReport()

            End If



            If InStr(Planta, "FUNZA") > 0 Then

                Resp = MsgBox("¿Desea imprimir los materiales de Rejilla y paquete de micros?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo)
                If Resp = vbYes Then

                    BCDate_Click(Nothing, Nothing)
                    Rep1.ReportFileName = RutaRep + "RpEspec.rpt"
                    Rep1.Formulas(0) = "BACHES='" + BachesPend.ToString.Trim + "'"
                    Rep1.Formulas(1) = "OP='" + TOPs.Text + "'"
                    Rep1.Formulas(2) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "'"
                    Rep1.Formulas(3) = "SECCION='REJILLA'"
                    Rep1.Formulas(5) = ""
                    Rep1.Formulas(7) = ""

                    DVarios.Open("Select SUM(PESOMETA) AS PESOMETA from DATOSFOR where A='AD' and CODFOR='" + CFor + "' and LP='" + CLP + "'")

                    If Not IsDBNull(DVarios.RecordSet("PESOMETA")) And DVarios.Count > 0 Then
                        RespInput = DVarios.RecordSet("PESOMETA")
                    Else
                        InputBox.InputBox("PREMEZCLA", "Indique el peso de la Premezcla", RespInput)
                    End If

                    Rep1.Formulas(5) = "PREMEZCLA='" + Format(Eval(RespInput), "#.00") + "'"

                    RespInput = ""

                    DVarios.Open("Select * from OPS where OP='" + TOPs.Text + "'")

                    Rep1.Formulas(7) = "LOTEPREM='" + DVarios.RecordSet("LOTEPREM") + "'"

                    InputBox.InputBox("ADITIVOS", "Digite si tiene observaciones:", RespInput)
                    Rep1.Formulas(6) = "observacion='" + RespInput.ToString + "'"
                    Rep1.SelectionFormula = "{CFormula.A}='R' or {CFormula.A}='F'"
                    Rep1.ReportFileName = RutaRep + "rpespec.rpt"
                    Rep1.PrintReport()


                    '**********************************************************************************************************

                    Resp = MsgBox("Desea imprimir los materiales de Báscula de Piso ?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo)
                    If Resp = vbYes Then

                        BCDate_Click(Nothing, Nothing)
                        Rep1.ReportFileName = RutaRep + "RpEspec.rpt"
                        Rep1.Formulas(0) = "BACHES='" + BachesPend.ToString.Trim + "'"
                        Rep1.Formulas(1) = "OP='" + TOPs.Text + "'"
                        Rep1.Formulas(2) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "'"
                        Rep1.Formulas(3) = "SECCION='BASCULA DE PISO'"
                        Rep1.Formulas(5) = ""
                        Rep1.SelectionFormula = "{CFormula.A}='BP'"
                        Rep1.ReportFileName = RutaRep + "rpespec.rpt"
                        Rep1.PrintReport()

                    End If

                End If

            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpTodas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnImpTodas.Click
        Dim RepSap As CrystalRep
        Try

            RepSap = New CrystalRep

            With RepSap
                .ServerName = ServidorSQL
                .DataBaseName = NomDB
                .UserId = UserDB
                .Password = PWD
                .Formulas(1) = "PLANTA='" + Planta + "'"
                .Destination = CrystalRep.Destinacion.crToWindows
                .WindowState = FormWindowState.Maximized
                .ChoosePrint = True
                .MaximizeBox = True
                .MinimizeBox = True
            End With

            RepSap.ReportFileName = RutaRep + "rpcatfor.rpt"
            RepSap.PrintReport()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSecuenciaMezc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSecuenciaMezc.Click
        If ValidaPermiso("SecuenciaMezcla_Ver,SecuenciaMezcla_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Return
        End If
        SecuenciaMezcla.ShowDialog()
    End Sub

    Private Sub DGFor_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGFor.CellFormatting
        Try
            If DGFor.Columns(e.ColumnIndex).Name = "Estado" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (valor <> "-") Then
                        DGFor.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
                        ' DGSoliCargue.RowsDefaultCellStyle.BackColor = Color.Yellow
                        ' e.CellStyle.BackColor = Color.Yellow
                    End If
                End If
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub mnCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCambiarEstado.Click
        Try
            Dim CFor As String
            Dim CLP As String

            'If DRUsuario("CALIDAD") Then
            If ValidaPermiso("Calidad") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Return
            End If



            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim


            DFor.Open("select * from FORMULAS where CODFOR='" + CFor + "' and LP='" + CLP + "'")

            If DFor.Count > 0 Then
                Resp = MessageBox.Show(" Desea cambiar estado de la Fórmula " + DFor.RecordSet("CODFOR").ToString.Trim + " " + DFor.RecordSet("NomFor").ToString.Trim, "ChronoSoft Net", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then
                    Exit Sub
                End If

                If DFor.RecordSet("ESTADO") <> "-" Then
                    DFor.RecordSet("ESTADO") = "-"
                Else
                    DFor.RecordSet("ESTADO") = "APROBADO"
                End If

                DFor.Update(Me)

                BActualizar_Click(Nothing, Nothing)
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub RBFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim Hallado As Boolean

            Dim RB As RadioButton = CType(sender, RadioButton)
            Dim Index As Integer = RBFiltro.Index(RB)


            DFormFiltros.Find("POSICION=" + Index.ToString)

            If Not DFormFiltros.EOF Then

                If DFormFiltros.RecordSet("CAMPO") = "TIPOMAT" Then
                    BusquedaDG(DGDatosFor, "DGDatosFor_TipoMat", DFormFiltros.RecordSet("VALOR"), Hallado)
                ElseIf DFormFiltros.RecordSet("CAMPO") = "BASCULA" Then
                    BusquedaDG(DGDatosFor, "DGDatosFor_Bascula", DFormFiltros.RecordSet("VALOR"), Hallado)
                ElseIf DFormFiltros.RecordSet("CAMPO") = "A" Then
                    BusquedaDG(DGDatosFor, "DGDatosFor_A", DFormFiltros.RecordSet("VALOR"), Hallado)
                End If

            End If
            If Hallado = False Then
                Exit Sub
            End If

            TSumaIng.Text = SumColumn(DGDatosFor, "DGDatosFor_PesoMeta").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub MaterialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialesToolStripMenuItem.Click
        Try
            'If DRUsuario("MatPVer") Or DRUsuario("MatPMod") Then
            If ValidaPermiso("Materiales_Ver, Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Materiales.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        Try
            'If DRUsuario("ProdVer") Or DRUsuario("ProdMod") Then
            If ValidaPermiso("Productos_Ver, Productos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Productos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TolvasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TolvasToolStripMenuItem.Click
        Try
            If ValidaPermiso("Tolvas_Ver,Tolvas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), vbInformation)
                Return
            End If
            Tolvas.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesToolStripMenuItem.Click
        Try
            'If DRUsuario("RepVer") Then
            If ValidaPermiso("Reportes_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Reportes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DGFor_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGFor.KeyUp
        Try
            If e.KeyCode <> Keys.Delete Then Return
            FBorraForm_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub FBorraForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FBorraForm.Click
        Try

            If DGFor.SelectedRows.Count = 0 Then Return

            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGELIMINAR), MsgBoxStyle.YesNo)
            If Resp = vbNo Then Return

            Dim CodForBorrar As String = ""
            Dim LPBorrar As String = ""

            For j As Integer = DGFor.SelectedRows.Count - 1 To 0 Step -1
                CodForBorrar = DGFor.SelectedRows(j).Cells("CodFor").Value.ToString
                LPBorrar = DGFor.SelectedRows(j).Cells("Lp").Value.ToString

                'Se verifica si se puede liminar o no una fórmula
                DVarios.Open("SELECT * FROM OPS WHERE REAL>0 and CODFOR='" + CodForBorrar + "' AND LP='" + LPBorrar + "' AND FINPLANILLA<>'S' and FINALIZADO<>'S'")

                If DVarios.Count Then
                    MsgBox(DevuelveEvento(CodEvento.FORMULA_NOELIMINAR, "Fórmula: " + CodForBorrar + " No.Orden: " + LPBorrar), vbCritical)
                    Continue For
                End If

                DBorrarForm.Delete("Delete from DATOSFOR where CODFOR='" + CodForBorrar + "' and LP='" + LPBorrar + "'", Me)
                DBorrarForm.Delete("Delete from FORMULAS where CODFOR='" + CodForBorrar + "' and LP='" + LPBorrar + "'", Me)
                DBorrarForm.Delete("Delete from NUTFOR where CODFOR='" + CodForBorrar + "' and LP='" + LPBorrar + "'", Me)

                Sleep(100)
            Next

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)
            BActualizar_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub DGDatosFor_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGDatosFor.CellFormatting
        Try
            If DGDatosFor.Columns(e.ColumnIndex).Name = "DGDatosFor_PesoMeta" Then
                If e.Value IsNot Nothing Then
                    Dim valor As String = CType(e.Value, String)
                    If (Eval(valor) = 0) Then
                        DGDatosFor.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If
            End If
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub




    Private Sub TTotalBasc1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TTotalBasc1.TextChanged, TTotalBasc2.TextChanged, TTotalBasc3.TextChanged, TTotalBasc4.TextChanged, TTotalBasc5.TextChanged, TTotalBasc6.TextChanged, TTotalBasc7.TextChanged, TTotalBasc8.TextChanged
        Try
            Dim TB As TextBox = CType(sender, TextBox)
            Dim Index As Integer = TTotalBasc.Index(TB)

            'Evalua la capacidad de la báscula para poner en rojo o verde según la capacidad de la báscula

            If Eval(TTotalBasc(Index).Text) <= CapBasc(Index) Then
                TTotalBasc(Index).BackColor = Color.Green
            Else
                TTotalBasc(Index).BackColor = Color.Red
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BActualizarPesoPrem_Click(sender As Object, e As EventArgs) Handles BActualizarPesoPrem.Click
        Try

            Resp = MsgBox("Seguro desea actualizar el peso de la premezcla en toda la formulación?", vbYesNo + vbInformation)
            If Resp = vbNo Then Return

            Dim CodPremezcla As String = ""
            Dim CodFor As String = ""
            Dim LP As String = ""
            Dim PesoPremActual As Single = 0
            Dim PesoPrem_ChrPrem As Single = 0
            Dim PesoTotalFor As Single = 0
            Dim DifPesoPrem As Single = 0
            Dim NomFormula As String = ""

            'Abrimos toda la tabla de formulas aprobadas

            DFor.Open("Select * from FORMULAS where ESTADO='APROBADO' and MANEJAPX=1 order by CODFOR")

            For Each DRFor As DataRow In DFor.Rows
                CodPremezcla = DRFor("CODPREMEZCLA")
                CodFor = DRFor("CODFOR")
                LP = DRFor("LP")
                NomFormula = DRFor("NOMFOR")
                PesoTotalFor = Math.Round(DRFor("TOTALFOR"), 3)
                PesoPrem_ChrPrem = 0
                PesoPremActual = 0

                'Abrimos la tabla datosfor para averiguar el peso de la premezcla actual
                DDatosFor.Open("Select PESOMETA from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and CODMAT='" + CodPremezcla + "'")

                If DDatosFor.Count Then
                    PesoPremActual = DDatosFor.RecordSet("PESOMETA")
                End If

                'Abrimos la tabla datosforprem para averiguar el peso de la premezcla en el chorosoft de premezclas

                DDatosForPrem.Open("Select PESOMETA from DATOSFOR where CODFOR='" + CodFor + "' and LP='" + LP + "' and CODMAT='" + CodPremezcla + "'")
                'Si no se encuentra la formula en el chronosoft de premezclas se continua con la siguiente formula
                If DDatosForPrem.Count = 0 OrElse IsDBNull(DDatosForPrem.RecordSet("PESOMETA")) Then Continue For

                PesoPrem_ChrPrem = DDatosForPrem.RecordSet("PESOMETA")

                'Si el peso de la premezcla no ha cambiado, se continua con la siguiente formula
                If PesoPrem_ChrPrem = PesoPremActual Then Continue For

                DifPesoPrem = PesoPrem_ChrPrem - PesoPremActual

                'Se actualiza la premezcla en la tabla datosfor con el peso actualizado del choronsoft de premezclas
                'Se actualiza el totalfor

                Resp = MsgBox("Se actualizará la fórmula " + NomFormula + " con código de premezcla: " + CodPremezcla + " Peso en macros: " + PesoPremActual.ToString + " Peso en premezclas: " + PesoPrem_ChrPrem.ToString + ", Desea continuar?", vbInformation + vbYesNo)
                If Resp = vbNo Then Continue For

                DDatosFor.Open("Update DATOSFOR set PESOMETA=" + PesoPrem_ChrPrem.ToString + " where CODFOR='" + CodFor + "' and LP='" + LP + "' and CODMAT='" + CodPremezcla + "'")

                DRFor("TOTALFOR") += DifPesoPrem

                DFor.Update()

                Evento(" Actualiza peso premezcla codfor= " + CodFor + " LP= " + LP + " CodPremezcla= " + CodPremezcla + " PesoMeta Kg=" + PesoPremActual.ToString + " Diferencia Kg: " + DifPesoPrem.ToString)

            Next

            MsgBox("Proceso Finalizado", vbInformation)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ImprimirEspeciales(ByVal Seccion As String, ByVal Filtro As String)
        Try

            If Eval(TOPs.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.FORMULA_SELECCIONAROP), MsgBoxStyle.Information)
                NuevaOP.ShowDialog()
            End If

            Dim BachesPend As Int16
            Dim CFor As String
            Dim CLP As String
            'Dim FecImp As String
            Dim ObservOP As String
            Dim TotFor As Single = 0
            Dim Porc As Single = 0

            CFor = DGFor.Rows(DGFor.CurrentRow.Index).Cells("CODFOR").Value.ToString.Trim
            CLP = DGFor.Rows(DGFor.CurrentRow.Index).Cells("LP").Value.ToString.Trim

            DVarios.Open("Select * from OPS where OP='" + TOPs.Text + "'")

            If DVarios.Count = 0 Then
                MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, "OP"), MsgBoxStyle.Information)
                Return
            End If

            BachesPend = DVarios.RecordSet("META") - DVarios.RecordSet("REAL")
            ObservOP = DVarios.RecordSet("OBSERVOP")
            Porc = DVarios.RecordSet("PORC")

            BCDate_Click(Nothing, Nothing)

            Rep1.Formulas(0) = "BACHES='" + BachesPend.ToString + "'"
            Rep1.Formulas(1) = "OP='" + TOPs.Text + "'"
            Rep1.Formulas(2) = "FECHA='" + Format(Now, "yyyy/MM/dd HH:mm:ss") + "'"
            Rep1.Formulas(3) = "SECCION='" + Seccion + "'"
            Rep1.Formulas(4) = "MEZCLA=''"

            If Funcion_FuncionesPlantaPremezclas = False Then
                Rep1.ReportFileName = RutaRep + "RpEspec.rpt"
                Rep1.SelectionFormula = Filtro

                Rep1.Formulas(9) = "PORC='" + Porc.ToString + "'"

                If DVarios.RecordSet("BACHESTANDA") > 1 Then
                    Rep1.Formulas(5) = "BACHESTANDA='" + DVarios.RecordSet("BachesTanda").ToString + "'"
                End If

                If Seccion = "ADITIVOS" Then
                    RespInput = ""
                    If DVarios.RecordSet("OBSERVOP").ToString.Length > 1 Then
                        RespInput = DVarios.RecordSet("OBSERVOP")
                    End If

                    InputBox.InputBox("ADITIVOS", "Digite si tiene observaciones:", RespInput)
                    Rep1.Formulas(6) = "observacion='" + RespInput.ToString.Trim + "'"

                    DVarios.Open("Select PESOMETA,CODMAT from DATOSFOR where A='PR' and CODFOR='" + CFor + "' and LP='" + CLP + "'")
                    If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOMETA")) Then
                        Rep1.Formulas(7) = "CODPREMEZCLA='" + DVarios.RecordSet("CODMAT") + "'"
                    End If
                End If

                If Seccion = "PESADA MENOR" OrElse Seccion = "PESADA MENOR 2" Then
                    'RespInput = ""
                    'InputBox.InputBox("PESADA MENOR", "Digite si tiene observaciones:", RespInput)
                    'Rep1.Formulas(6) = "observacion='" + RespInput.ToString.Trim + "'"

                    DVarios.Open("Select * from OPS where OP='" + Trim(TOPs.Text) + "'")
                    Rep1.Formulas(6) = "observacion='" + DVarios.RecordSet("OBSERVOP") + "'"

                    'Traemos el peso de la premezcla de la fórmula
                    RespInput = 0

                    DVarios.Open("Select SUM(PESOMETA) AS PESOMETA from DATOSFOR where A='AD' and CODFOR='" + CFor + "' and LP='" + CLP + "'")
                    If DVarios.Count > 0 And Not IsDBNull(DVarios.RecordSet("PESOMETA")) Then
                        RespInput = DVarios.RecordSet("PESOMETA")
                    Else
                        InputBox.InputBox("PREMEZCLA", "Indique el peso de la Premezcla", RespInput)
                    End If

                    Rep1.Formulas(5) = "PREMEZCLA='" + Format(Eval(RespInput), "#.00") + "'"

                    DVarios.Open("Select PESOMETA,CODMAT from DATOSFOR where A='AD' and CODFOR='" + CFor + "' and LP='" + CLP + "'")
                    If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOMETA")) Then
                        Rep1.Formulas(7) = "CODPREMEZCLA='" + DVarios.RecordSet("CODMAT") + "'"
                    End If
                End If

                If Seccion = "FUN PREMEZCLA" Or Seccion = "BÁSCULA DE PISO" Then

                    DVarios.Open("Select * from OPS where OP='" + Trim(TOPs.Text) + "'")
                    Rep1.Formulas(6) = "observacion='" + DVarios.RecordSet("OBSERVOP") + "'"
                    Rep1.Formulas(7) = "CODPREMEZCLA='" + DVarios.RecordSet("CODPREM") + "'"
                    Rep1.Formulas(8) = "LOTEPREM='" + DVarios.RecordSet("LOTEPREM") + "'"

                End If


            Else
                Rep1.ReportFileName = RutaRep + "rpmenores.rpt"
                Rep1.Formulas(9) = "BODDESTINO='" + DVarios.RecordSet("BODDESTINO") + "'"
                Rep1.SelectionFormula = ""

                DVarios.Open("Select SUM(PESOMETA) AS PESOMETA from DATOSFOR where TIPOMAT<>10 and CODFOR='" + CFor + "' and LP='" + CLP + "'")
                If DVarios.Count Then TotFor = DVarios.RecordSet("PESOMETA")


                InputBox.InputBox("PESADA MENOR", "Digite si tiene observaciones:", RespInput)
                If DVarios.Count Then
                    RespInput += ObservOP
                    Rep1.Formulas(7) = "PORCBACHE='" + Porc.ToString + "'"

                    Rep1.Formulas(8) = "TotSinEmp='" + (TotFor * Porc / 100).ToString + "'"


                End If
                Rep1.Formulas(6) = "observacion='" + RespInput.ToString.Trim + "'"

                DVarios.Open("Select PesoPaq from FORMULAS where CODFOR='" + CFor + "' and LP='" + CLP + "'")

                If DVarios.Count Then Rep1.Formulas(10) = "PesoPaq='" + DVarios.RecordSet("PESOPAQ").ToString + "'"


            End If

            Rep1.PrintReport()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpMayores_Click(sender As Object, e As EventArgs) Handles mnImpMayores.Click
        Try

            Dim Filtro As String = "{CFormula.A}='A'"
            ImprimirEspeciales("MAYORES", Filtro)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpAditivos_Click(sender As Object, e As EventArgs) Handles mnImpAditivos.Click
        Try
            Dim Filtro As String = "{CFormula.A}='AD' or  {CFormula.A}='MD'"
            ImprimirEspeciales("ADITIVOS", Filtro)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpFueraProceso_Click(sender As Object, e As EventArgs) Handles mnImpFueraProceso.Click
        Try
            Dim Filtro As String = "{CFormula.A}='PF'"
            ImprimirEspeciales("FUERA DE PROCESO", Filtro)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpRejilla_Click(sender As Object, e As EventArgs) Handles mnImpRejilla.Click
        Try
            Dim Filtro As String = "{CFormula.A}='R'"
            ImprimirEspeciales("REJILLA", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpPesadaMenor_Click(sender As Object, e As EventArgs) Handles mnImpPesadaMenor.Click
        Try
            Dim Filtro As String = "{CFormula.A}='PM' or {CFormula.A}='PM1'"
            ImprimirEspeciales("PESADA MENOR", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpPesadaMenor2_Click(sender As Object, e As EventArgs) Handles mnImpPesadaMenor2.Click
        Try
            Dim Filtro As String = "{CFormula.A}='PM2'"
            ImprimirEspeciales("PESADA MENOR 2", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpMolinos_Click(sender As Object, e As EventArgs) Handles mnImpMolinos.Click
        Try
            Dim Filtro As String = "{CFormula.A}='ML'"
            ImprimirEspeciales("MOLINOS", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnImpPostEngrase_Click(sender As Object, e As EventArgs) Handles mnImpPostEngrase.Click
        Try
            Dim Filtro As String = "{CFormula.A}='PE'"
            ImprimirEspeciales("POST ENGRASE", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub ContexMenuFor_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContexMenuFor.Opening
        'If DRUsuario("FormMod") Then
        If ValidaPermiso("Formulas_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            e.Cancel = True
        End If
    End Sub

    Private Sub mnBasculaPiso_Click(sender As Object, e As EventArgs) Handles mnBasculaPiso.Click
        Try
            Dim Filtro As String = "{CFormula.A}='BP' or {CFormula.A}='F'"
            ImprimirEspeciales("BÁSCULA DE PISO", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnBasculaPiso2_Click(sender As Object, e As EventArgs) Handles mnBasculaPiso2.Click
        Try
            Dim Filtro As String = "{CFormula.A}='BP2'"
            ImprimirEspeciales("BÁSCULA DE PISO 2", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnVerFormAfectadas_Click(sender As Object, e As EventArgs) Handles mnVerFormAfectadas.Click
        Try
            If ValidaPermiso("Formulas_Editar, Reportes_Ver ") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Return
            End If
            CamCodMat.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnTodos_Click(sender As Object, e As EventArgs) Handles mnTodos.Click
        Try
            If Funcion_FuncionesPlantaPremezclas Then
                Dim Filtro As String = "{CFormula.A}='A'"
                ImprimirEspeciales("PESADA MENOR", Filtro)
            Else
                For Each Fila As DataRow In DModosImprimir.Rows
                    Dim Filtro As String = "{CFormula.A}='" + Fila("A") + "'"
                    ImprimirEspeciales(Fila("NOMBRESECCION"), Filtro)
                    Sleep(1000)
                Next
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnAgrupado_Click(sender As Object, e As EventArgs) Handles mnAgrupado.Click

        Try
            Dim Filtro As String = cadenaAgrupacionPM

            If Filtro = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACONFIGURACION, "Agrupación tipos materiales para impresion"), vbInformation)
                Return
            End If
            ImprimirEspeciales("PESADA MANUAL", Filtro)
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub
End Class