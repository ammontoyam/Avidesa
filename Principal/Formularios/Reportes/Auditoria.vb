Imports Microsoft.Reporting.WinForms
Imports System.Reflection
Imports ClassLibrary

Public Class Auditoria

    Private DEventosLog As AdoSQL
    Private DConsultas As AdoSQL
    Private DUsuarios As AdoSQL
    Private Fuente As New ReportDataSource
    Private Parametros As New List(Of ReportParameter)

    Private FechaIni As String
    Private FechaFin As String

    'Diccionario (llave, valor) para manejo de texto a mostrar en combobox (CCampo) y texto real de busqueda
    'llave := texto que se muestra al usuario
    'valor := texto que se usa para la busqueda del campo en BD
    Private DicCampoDB As New Dictionary(Of String, String) From {
        {"CODFORMULA", "CODFOR"},
        {"NO.ORDEN", "LP"},
        {"CODFORMULA-NO.ORDEN", "CODFOR-LP"},
        {"CÓDIGO ARTICULO", "CODINT"},
        {"CÓDIGO INGREDIENTE EN FORMULA", "CODMAT"},
        {"CÓDIGO DE PRODUCTO TERMINADO", "CODPROD"},
        {"OP", "OP"},
        {"CONTADOR CORTE", "CONTCORTE"},
        {"CONTADOR BACHE", "CONT"},
        {"TOLVA", "TOLVA"}
    }

    'Diccionario (llave, valor) para manejo de texto a mostrar en combobox (CModulo) y texto real de busqueda
    'llave := texto que se muestra al usuario
    'valor := texto que se usa para la busqueda del campo en BD
    Private DicModuloDB As New Dictionary(Of String, String) From {
        {"TOLVAS", "TOLVAS"},
        {"USUARIOS", "USUARIOS"},
        {"FORMULAS", "FORMULACION"},
        {"EDITAR FORMULAS", "FORMULACIONDET"},
        {"CLIENTES", "CLIENTES"},
        {"MATERIALES", "MATERIALES"},
        {"PRODUCTOS", "PRODUCTOS"},
        {"EMPAQUE MANUAL", "EMPMAN"},
        {"REPORTAR BACHE MANUAL", "ENTRABACHE"},
        {"REPORTAR CONSUMOS MANUAL", "ENTRACONSUMOS"},
        {"OPs", "NUEVAOP"},
        {"IMPORTAR FORMULAS", "IMPORTFOR"},
        {"AJUSTE DE INVENTARIO", "AJUSTEINV"},
        {"CARGUE MANUAL", "CARGUEMAN"},
        {"PLANILLA", "PLANILLA"},
        {"DESPACHOS", "DESPACHOS"},
        {"ACEPTA EMPAQUE", "RECIBEPT"},
        {"MATERIA PRIMA NECESARIA", "MPRIMANEC"},
        {"CONTROL DIARIO", "CONTROLDIARIO"},
        {"DETALLES DE BACHE", "DETBACHE"},
        {"OBSERVACIONES CORTES BACHE", "OBSCORTESBACHES"},
        {"OBSERVACIONES CORTES MP", "OBSCORTESMP"}
    }

    Private Sub FrmRpEventosLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DEventosLog = New AdoSQL("EVENTOSLOG")
            DConsultas = New AdoSQL("CONSULTAS")
            DUsuarios = New AdoSQL("USUARIOS")

            DConsultas.Open("Select * from CONSULTAS")

            TFechaIni.Value = Now
            TFechaFin.Value = DateAdd(DateInterval.Day, 1, Now)
            THoraIni.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))
            THoraFin.Value = CDate(Format(Now, "yyyy/MM/dd 00:00"))

            FechaIni = TFechaIni.Value.ToString("yyyy/MM/dd 00:00")
            FechaFin = TFechaFin.Value.ToString("yyyy/MM/dd 00:00")

            DEventosLog.Open("select * from EVENTOSLOG where FECHA between '" + FechaIni + "' and '" + FechaFin + "'")

            AsignaDataGrid(DGIntFazEventos, DEventosLog.DataTable)

            For Each Acc In ([Enum].GetValues(GetType(Accion))) 'Se llena el combobox con el enum "Accion" de la clase "EventosLog"
                CAccion.Items.Add(Acc.ToString)
            Next

            For Each ky In DicModuloDB  ' Se llena el combobox con la lista de llaves(texto que se muestra al usuario) del diccionario de módulos
                CModulo.Items.Add(ky.Key)
            Next

            For Each ky In DicCampoDB ' Se llena el combobox con la lista de llaves(texto que se muestra al usuario) del diccionario de campos
                CCampo.Items.Add(ky.Key)
            Next

            DUsuarios.Open("Select USUARIO from USUARIOS order by USUARIO")

            LLenaComboBox(CUsuario, DUsuarios.DataTable, "USUARIO")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFiltrar.Click
        Try

            FechaIni = Format(TFechaIni.Value, "yyyy/MM/dd ") + Format(THoraIni.Value, "HH:mm")
            FechaFin = Format(TFechaFin.Value, "yyyy/MM/dd ") + Format(THoraFin.Value, "HH:mm")

            Dim Consulta As String

            Consulta = "Select * from EVENTOSLOG where FECHA between '" + FechaIni + "' and '" + FechaFin + "' "

            If CUsuario.Text <> "" Then
                Consulta += "and USUARIO='" + CUsuario.Text + "' "
            End If

            If CModulo.Text <> "" Then
                If DicModuloDB.ContainsKey(CModulo.Text) Then
                    Consulta += "and MODULO='" + DicModuloDB.Item(CModulo.Text) + "' "
                End If
            End If

            If CAccion.Text <> "" Then
                Consulta += "and ACCION='" + CAccion.Text + "' "
            End If

            If CCampo.Text <> "" Then
                If DicCampoDB.ContainsKey(CCampo.Text) Then
                    Consulta += "and CAMPO='" + DicCampoDB.Item(CCampo.Text) + "' "
                End If
            End If

            If TValor.Text <> "" Then
                Consulta += "and VALOR like '%" + TValor.Text + "%' "
            End If

            If TDetalle.Text <> "" Then
                Consulta += "and DETALLE like '%" + TDetalle.Text + "%' "
            End If

            DEventosLog.Open(Consulta)
            AsignaDataGrid(DGIntFazEventos, DEventosLog.DataTable)
            TcLogEventos.SelectedIndex = 0 'Mostrar en el TabPage "TpDatos"

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub mnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub BNuevaConsulta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevaConsulta.Click
        Try
            CUsuario.Text = ""
            CCampo.Text = ""
            CModulo.Text = ""
            CAccion.Text = ""
            TValor.Text = ""
            TDetalle.Text = ""

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BReporte_Click(sender As Object, e As EventArgs) Handles BReporte.Click

        Parametros.Add(New ReportParameter("FechaInicial", FechaIni))
        Parametros.Add(New ReportParameter("FechaFinal", FechaFin))

        Fuente.Name = "DataSetEventos" 'Nombre identico al dataset del "rpEventosLog.rdlc" en tiempo de diseño
        Fuente.Value = DEventosLog.DataTable

        rpLogEventos.LocalReport.DataSources.Clear()
        rpLogEventos.LocalReport.DataSources.Add(Fuente)
        rpLogEventos.LocalReport.SetParameters(Parametros)
        rpLogEventos.RefreshReport()

        TcLogEventos.SelectedIndex = 1 'Mostrar en el TabPage "TpReportes"

    End Sub
End Class