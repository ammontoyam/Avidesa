Imports System.Windows.Forms
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports ClassLibrary


Public Class Productos
    Private DAProd As DbDataAdapter
    Private CBProd As DbCommandBuilder
    Private CmProd As DbCommand  'consulta
    Private DTProductos As DataTable
    Private DR As DataRow
    Private Sentencia As String
    Private Fila As Integer
    Private DArt As AdoSQL
    Private DCodEmpEtiq As AdoSQL
    Private Campos() As String
    Private Campos2() As String
    Private EmpEtiq As String
    Private TipoEmp As String
    Private DLineasProd As AdoSQL
    Private DEquivalencias As AdoSQL
    Private DVarios As AdoSQL
    Private DEmpaques As AdoSQL
    Private DArtDet As AdoSQL
    Private DArtTextura As AdoSQL
    Private DTamDesc As AdoSQL
    Private FormLoad As Boolean


    Private Sub Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If FormLoad Then
                FRefrescaDG_Click(Nothing, Nothing)
                Return
            End If

            'If Funcion_VencimientoPorProducto Then TVencxProd.Enabled = True
            'If Funcion_ObligaLineaInvent Then GBLinea.Enabled = True

            'If Funcion_ManejaPaqueteo Then
            '    LPesoEquiv.Visible = True
            '    TPresKgEquiv.Visible = True
            'Else
            '    LPesoEquiv.Visible = False
            '    TPresKgEquiv.Visible = False
            'End If

            DArt = New AdoSQL("Articulos")
            DTamDesc = New AdoSQL("TamanoDescarga")
            DArtDet = New AdoSQL("ArticulosDet")

            'DCodEmpEtiq = New AdoSQL("Articulos tipo EM o ET")
            DArtTextura = New AdoSQL("TEXTURA")

            DArt.Open("Select * From Articulos where TIPO='PT' order by Nombre")
            'DArtTextura.Open("Select Distinct(PRESTEXT) From Articulos where TIPO='PT' order by PRESTEXT")
            DArtTextura.Open("select * from TIPOS where TABLA='TEXTURAS' order by NOMBRE")
            LLenaComboBox(CBTextura, DArtTextura.DataTable, "NOMBRE")

            DTamDesc.Open("select * from TAMDESC order by CODDESC")
            LLenaComboBox(CBCodDescarga, DTamDesc.DataTable, "CODDESC")
            'DLineasProd = New AdoSQL("LINEASPROD")
            'DLineasProd.Open("Select * from LINEASPROD where TIPO='PT'")

            'DEquivalencias = New AdoSQL("ProdEquivalentes")
            'DVarios = New AdoSQL("Varios")


            'LLenaComboBox(CLinea, DLineasProd.DataTable, "LINEA")
            'CLinea.Items.Add("-")

            FRefrescaDG_Click(Nothing, Nothing)

            'Busqueda general del formulario
            Campos = {"CodInt@Cód.Prod", "Nombre@Nombre"}
            Campos = AsignaItemsCB(Campos, CBBuscar.ComboBox, DArt.DataTable)

            DEmpaques = New AdoSQL("Articulos")
            DEmpaques.Open("Select * From Articulos where TIPO='EM' order by Nombre")

            'Busqueda codigos de empaque
            Campos2 = {"CodInt@Cód.Emp", "Nombre@Nombre"}
            Campos2 = AsignaItemsCB(Campos2, CBBuscarEmp.ComboBox, DEmpaques.DataTable)

            FRefrescaDGEmp_Click(Nothing, Nothing)
            ' Cambiar solo la altura del formulario a 939x538
            Me.Height = 538
            Panel1.Enabled = False
            FormLoad = True

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub DGProd_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGProd.CellClick
        'Mostrar()
        Try

            If DGProd.CurrentRow Is Nothing Then Return

            DArt.Find("CodInt='" + DGProd.Rows(DGProd.CurrentRow.Index).Cells("CodInt").Value.ToString + "'")
            If DArt.Count = 0 Then Exit Sub

            TCodInt.Text = DArt.RecordSet("CODINT").ToString
            ChActivo.Checked = DArt.RecordSet("ACTIVO")
            ChGranel.Checked = DArt.RecordSet("GRANEL").ToString
            TNombre.Text = DArt.RecordSet("NOMBRE").ToString
            CBTextura.Text = DArt.RecordSet("PRESTEXT").ToString
            'CBEmpaque.Text = DArt.RecordSet("PRESEMP").ToString
            CBPreskg.Text = DArt.RecordSet("PRESKG").ToString
            'TRef.Text = DArt.RecordSet("REF").ToString

            TCodHilo.Text = DArt.RecordSet("CODHILO").ToString
            CBCodDescarga.Text = DArt.RecordSet("CODDESC").ToString
            TCodEmp.Text = DArt.RecordSet("CODEMP").ToString
            TCodEtiq.Text = DArt.RecordSet("CODETIQ").ToString
            TPorcMerma.Text = DArt.RecordSet("PORCENTAJEMERMA")
            'CLinea.Text = DArt.RecordSet("LINEA").ToString
            'TCodMaq.Text = DArt.RecordSet("CODMAQ").ToString

            'TRegIca.Text = DArt.RecordSet("REGICA").ToString
            'TObserv.Text = DArt.RecordSet("OBSERVACIONES").ToString

            'TDensidad.Text = DArt.RecordSet("DENSIDAD")

            'If Funcion_VencimientoPorProducto Then TVencxProd.Text = DArt.RecordSet("MESESVENC").ToString

            ''Parametros de tamizado para los productos terminados
            'TMalla6.Text = DArt.RecordSet("ParmPorcMalla6")
            'TMalla8.Text = DArt.RecordSet("ParmPorcMalla8")
            'TMalla12.Text = DArt.RecordSet("ParmPorcMalla12")
            'TMalla16.Text = DArt.RecordSet("ParmPorcMalla16")
            'TMalla30.Text = DArt.RecordSet("ParmPorcMalla30")
            'TPorcPlato.Text = DArt.RecordSet("ParmPorcPlato")
            'TDurabilidad.Text = DArt.RecordSet("ParmDurabilidad")
            'TDureza.Text = DArt.RecordSet("ParmDureza")

            'If Funcion_ManejaPaqueteo Then
            '    TUdsPaca.Text = DArt.RecordSet("UDSPACA")
            '    TCodEmpBolsa.Text = DArt.RecordSet("CODEMPBOLSA")
            '    TCodEtiqBolsa.Text = DArt.RecordSet("CodEtiqBolsa")
            '    ChPaqueteo.Checked = DArt.RecordSet("PAQUETEO")

            '    'If ChPaqueteo.Checked Then
            '    '    GBPaqueteo.Visible = True
            '    'Else
            '    '    GBPaqueteo.Visible = False
            '    'End If

            'End If

            'LPesoEquiv.Visible = False
            'TPresKgEquiv.Visible = False
            'DEquivalencias.Open("Select * from PRODEQUIVALENTES where CODPROD='" + TCodInt.Text + "'")
            'AsignaDataGrid(DGEquivalencias, DEquivalencias.DataTable, True)

            'If DGEquivalencias.RowCount > 0 Then
            '    DGEquivalencias_CellClick(Nothing, Nothing)
            'Else
            '    TEquivalencia.Text = ""
            '    CBPresent.Items.Add("")
            '    CBPresent.Text = ""
            '    CBPresent.Items.Remove("")
            'End If

            'FRefrescaDGArticulosDet_Click(Nothing, Nothing)
            Panel1.Enabled = False

        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub


    Private Sub BNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BNuevo.Click
        Panel1.Enabled = True
        BCancelar_Click(Nothing, Nothing)
        'Limpiar_Habilitar_TextBox(Me.Controls, AccionTextBox.Habilitar)
        TVencxLinea.ReadOnly = True
        TCodInt.Focus()
        CLinea.Enabled = True
    End Sub

    Private Sub BCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelar.Click
        Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Limpiar)
        'Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Deshabilitar)
        'CBEmpaque.Text = ""
        CBPreskg.Text = ""
        CBTextura.Text = ""
        CBCodDescarga.Text = ""
        'CLinea.Text = ""
        'CLinea.Enabled = False
        ChActivo.Checked = False
        ChGranel.Checked = False

        'CLinea.DropDownStyle = ComboBoxStyle.DropDown
    End Sub

    Private Sub BAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptar.Click
        Try

            If TCodInt.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Código de producto"), vbInformation)
                Return
            End If

            If TNombre.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " Nombre de producto"), vbInformation)
                Return
            End If

            If CBTextura.Text = "" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " Textura del producto"), vbInformation)
                Return
            End If

            If Val(CBPreskg.Text) = 0 Then 'And CBEmpaque.Text = "BULT" Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " peso de producto"), vbInformation)
                Return
            End If

            If Val(CBCodDescarga.Text) = 0 Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_VALORINCORRECTO, " código de descarga"), vbInformation)
                Return
            End If

            If Val(TPorcMerma.Text) < 0 Or Val(TPorcMerma.Text) >= 1 Then
                MsgBox("El Porcentaje de Merma válido para el ingredient debe ser un valor entre 0 y 1", vbCritical)
                Return
            End If



            ''Si maneja vencimiento producto
            'If Funcion_VencimientoPorProducto Then
            '    If Eval(TVencxProd.Text) = 0 Then
            '        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " vencimiento producto"), vbInformation)
            '        Return
            '    End If
            'End If

            'If Funcion_ObligaLineaInvent Then
            '    If CLinea.Text = "" Then
            '        MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " línea inventario"), vbInformation)
            '        Return
            '    End If
            'End If

            ''Se no maneja PLANTAS EXTERNAS se revisa si el código existe como MP, no se debe tener el mismo codigo para PT y MP (excepto Girardota Premezclas)
            'If Funcion_PlantasExternas Or Funcion_FuncionesPlantaPremezclas Then
            'Else
            '    DVarios.Open("Select * from ARTICULOS where TIPO='MP' and CODINT='" + TCodInt.Text + "'")
            '    If DVarios.Count Then
            '        MsgBox(DevuelveEvento(CodEvento.BD_REGYAEXISTE, " como materia prima"), vbCritical)
            '        MsgBox(DevuelveEvento(CodEvento.SISTEMA_OPERACIONNOPERMITIDA), vbCritical)
            '        Return
            '    End If
            'End If

            DArt.Find("CodInt='" + TCodInt.Text.Trim + "' ")
            If Not DArt.EOF Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGYAEXISTE), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            Else
                DArt.AddNew()
            End If

            DArt.RecordSet("CODINT") = TCodInt.Text
            DArt.RecordSet("ACTIVO") = ChActivo.Checked
            DArt.RecordSet("GRANEL") = ChGranel.Checked
            DArt.RecordSet("NOMBRE") = CLeft(TNombre.Text, 30)
            DArt.RecordSet("PRESTEXT") = CLeft(CBTextura.Text, 4)
            DArt.RecordSet("PRESKG") = CBPreskg.Text
            DArt.RecordSet("CODDESC") = CBCodDescarga.Text
            'DArt.RecordSet("REF") = Eval(TRef.Text)
            DArt.RecordSet("TIPO") = "PT"

            If TCodHilo.Text = "" Then
                DArt.RecordSet("CODHILO") = "X"
            Else
                DArt.RecordSet("CODHILO") = TCodHilo.Text
            End If

            If TCodEmp.Text = "" Then
                DArt.RecordSet("CODEMP") = "X"
            Else
                DArt.RecordSet("CODEMP") = CLeft(TCodEmp.Text, 15)
            End If

            If TCodEtiq.Text = "" Then
                DArt.RecordSet("CODETIQ") = "X"
            Else
                DArt.RecordSet("CODETIQ") = CLeft(TCodEtiq.Text, 15)
            End If

            DArt.RecordSet("PORCENTAJEMERMA") = TPorcMerma.Text
            'DArt.RecordSet("CODMAQ") = CLeft(TCodMaq.Text, 15)
            'DArt.RecordSet("LINEA") = CLinea.Text
            'DArt.RecordSet("ParmPorcMalla6") = CLeft(TMalla6.Text, 15)
            'DArt.RecordSet("ParmPorcMalla8") = CLeft(TMalla8.Text, 15)
            'DArt.RecordSet("ParmPorcMalla12") = CLeft(TMalla12.Text, 15)
            'DArt.RecordSet("ParmPorcMalla16") = CLeft(TMalla16.Text, 15)
            'DArt.RecordSet("ParmPorcMalla30") = CLeft(TMalla30.Text, 15)
            'DArt.RecordSet("ParmPorcPlato") = CLeft(TPorcPlato.Text, 15)
            'DArt.RecordSet("ParmDurabilidad") = CLeft(TDurabilidad.Text, 15)
            'DArt.RecordSet("ParmDureza") = CLeft(TDureza.Text, 15)
            'If Funcion_VencimientoPorProducto Then DArt.RecordSet("MESESVENC") = Val(TVencxProd.Text)
            'DArt.RecordSet("REGICA") = CLeft(TRegIca.Text, 30)
            'DArt.RecordSet("OBSERVACIONES") = CLeft(TObserv.Text, 100).Trim
            'DArt.RecordSet("DENSIDAD") = Val(TDensidad.Text)

            'If Funcion_ManejaPaqueteo Then
            '    DArt.RecordSet("PAQUETEO") = ChPaqueteo.Checked
            '    DArt.RecordSet("CODEMPBOLSA") = TCodEmpBolsa.Text
            '    DArt.RecordSet("CODETIQBOLSA") = TCodEtiqBolsa.Text
            '    DArt.RecordSet("UDSPACA") = TUdsPaca.Text
            'End If

            DArt.Update()

            BCancelar_Click(Nothing, Nothing)
            AsignaDataGrid(DGProd, DArt.DataTable)

            FRefrescaDG_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBorrar.Click
        Try
            DArt.Find("TIPO='PT' and CodInt='" + TCodInt.Text.Trim + "'")
            If Not DArt.EOF Then
                Resp = MessageBox.Show(DevuelveEvento(CodEvento.BD_REGELIMINAR), "ChronoSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If Resp = vbNo Then Exit Sub
            End If

            DArt.Delete("Delete from Articulos Where TIPO='PT' and CodInt = '" + TCodInt.Text.Trim + "'", Me)
            BCancelar_Click(Nothing, Nothing)
            FRefrescaDG_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Me.Hide()
    End Sub

    Private Sub BActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BActualizar.Click
        'Productos_Load(Nothing, Nothing)
        FRefrescaDG_Click(Nothing, Nothing)
    End Sub

    Private Sub TNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TNombre.TextChanged
        TNombre.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub BEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditar.Click
        Panel1.Enabled = True
        Limpiar_Habilitar_TextBox(Me.Controls, VariablesGlobales.AccionTextBox.Habilitar)
        CLinea.DropDownStyle = ComboBoxStyle.DropDownList
        CLinea.Enabled = True
        ''ChModificarEmp.Enabled = True
    End Sub


    'Private Sub TCodEmp_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodEmp.Enter
    '    Try
    '        EmpEtiq = "EMPAQUE"
    '        TipoEmp = "SACO"
    '        DCodEmpEtiq.Open("select * from ARTICULOS where TIPO='EM' ORDER BY NOMBRE")
    '        AsignaDataGrid(DGEmpaques, DCodEmpEtiq.DataTable, True)
    '        DGEmpaques.Visible = True
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub

    'Private Sub TCodEtiq_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCodEtiq.Enter
    '    Try
    '        EmpEtiq = "ETIQUETA"
    '        TipoEmp = "SACO"
    '        DCodEmpEtiq.Open("select * from ARTICULOS where TIPO='ET' ORDER BY NOMBRE")
    '        AsignaDataGrid(DGEmpaques, DCodEmpEtiq.DataTable, True)
    '        DGEmpaques.Visible = True
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub

    Private Sub DGEmpaques_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGEmpaques.CellClick
        Try

            If DGEmpaques.Rows.Count = 0 Then Exit Sub

            If EmpEtiq = "EMPAQUE" Then
                TCodEmp.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_CODINT").Value.ToString
            End If

            If EmpEtiq = "ETIQUETA" Then
                TCodEtiq.Text = DGEmpaques.Rows(DGEmpaques.CurrentRow.Index).Cells("DGEMPAQUES_CODINT").Value.ToString
            End If

            DGEmpaques.Visible = False

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


    Private Sub TBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TBuscar.KeyUp
        Try
            If CBBuscar.Text = "" Then
                CBBuscar.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscar.Text = ""
                Exit Sub
            End If

            If TBuscar.Text = "" Then
                FRefrescaDG_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscar.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub

            BusquedaDG(DGProd, DArt.DataTable, TBuscar.Text, Campos(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

            DGProd_CellClick(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FRefrescaDG.Click
        Try
            'Refresca el DataGrid de OPS
            DArt.Open("Select * from ARTICULOS where TIPO='PT' order by NOMBRE")
            AsignaDataGrid(DGProd, DArt.DataTable)
            If DGProd.RowCount > 0 Then DGProd_CellClick(Nothing, Nothing)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    'Private Sub TRef_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DGEmpaques.Visible = False
    'End Sub

    Private Sub TCodInt_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TCodInt.KeyUp
        If e.KeyCode = Keys.Enter Then TNombre.Focus()
    End Sub
    Private Sub DGProd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGProd.KeyDown
        DGProd_CellClick(Nothing, Nothing)
    End Sub

    Private Sub DGProd_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGProd.KeyUp
        DGProd_CellClick(Nothing, Nothing)
    End Sub

    Private Sub BImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BImprimir.Click
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
                .ReportFileName = RutaRep + "rpCatProd.rpt"
                .SelectionFormula = "{Articulos.Tipo}='PT'"
                .PrintReport()
            End With


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    'Private Sub BAceptarEquiv_Click(sender As System.Object, e As System.EventArgs) Handles BAceptarEquiv.Click
    '    Try
    '        If CBPresent.Text = "" Then
    '            MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " presentación"), vbInformation)
    '            Return
    '        End If

    '        If TEquivalencia.Text = "" Then
    '            MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código equivalente de producto"), vbInformation)
    '            Return
    '        End If

    '        If Funcion_ManejaPaqueteo Then
    '            'Si se maneja paqueteo se debe revisar tambien por peso del saco
    '            DEquivalencias.Open("Select * from PRODEQUIVALENTES where CODPROD='" + TCodInt.Text + "' and PRESENT='" + CBPresent.Text + "' and PRESKG=" + Val(TPresKgEquiv.Text).ToString)
    '        Else
    '            DEquivalencias.Open("Select * from PRODEQUIVALENTES where CODPROD='" + TCodInt.Text + "' and PRESENT='" + CBPresent.Text + "'")
    '        End If



    '        If DEquivalencias.Count = 0 Then
    '            DEquivalencias.AddNew()
    '        Else
    '            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGYAEXISTE), vbInformation + vbYesNo)
    '            If Resp = vbNo Then Return
    '        End If


    '        DEquivalencias.RecordSet("CODPROD") = TCodInt.Text
    '        DEquivalencias.RecordSet("NOMBRE") = TNombre.Text
    '        DEquivalencias.RecordSet("PRESENT") = CBPresent.Text
    '        DEquivalencias.RecordSet("CODPRODEQUI") = TEquivalencia.Text
    '        If Funcion_ManejaPaqueteo Then DEquivalencias.RecordSet("PRESKG") = Val(TPresKgEquiv.Text)
    '        DEquivalencias.Update(Me)

    '        'Realizamos una actualización en la tabla empaque del codigo de producto 2 cuando lo modifican o lo crean nuevo para la
    '        'presentación y el código de producto

    '        DVarios.Open("Update EMPAQUE set CODPROD2='" + TEquivalencia.Text + "' where CODPROD='" + TCodInt.Text + "' AND PRESEMP='" + CBPresent.Text + "' and PRESKG=" + CBPreskg.Text)

    '        BCancelar_Click(Nothing, Nothing)

    '        DGProd_CellClick(Nothing, Nothing)

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub BNuevaEquiv_Click(sender As System.Object, e As System.EventArgs) Handles BNuevaEquiv.Click
    '    Try
    '        GBEquivalencias.Enabled = True
    '        TEquivalencia.ReadOnly = False
    '        TEquivalencia.Text = ""
    '        CBPresent.Items.Add("")
    '        CBPresent.Text = ""
    '        CBPresent.Items.Remove("")

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub BCancelarEquiv_Click(sender As System.Object, e As System.EventArgs) Handles BCancelarEquiv.Click
    '    Try
    '        GBEquivalencias.Enabled = False
    '        TEquivalencia.ReadOnly = True
    '        TEquivalencia.Text = ""
    '        CBPresent.Items.Add("")
    '        CBPresent.Text = ""
    '        CBPresent.Items.Remove("")
    '        TPresKgEquiv.Text = ""

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub BBorrarEquiv_Click(sender As System.Object, e As System.EventArgs) Handles BBorrarEquiv.Click
    '    Try
    '        Resp = MsgBox("¿Seguro desea borrar la equivalencia?", vbInformation + vbYesNo)

    '        If Resp = vbNo Then Return

    '        If Funcion_ManejaPaqueteo Then
    '            DEquivalencias.Delete("Delete from PRODEQUIVALENTES where CODPRODEQUI='" + TEquivalencia.Text + "' and PRESENT='" + CBPresent.Text + "' and PRESKG=" + TPresKgEquiv.Text, Me)
    '        Else
    '            DEquivalencias.Delete("Delete from PRODEQUIVALENTES where CODPRODEQUI='" + TEquivalencia.Text + "' and PRESENT='" + CBPresent.Text + "'", Me)
    '        End If


    '        DGProd_CellClick(Nothing, Nothing)

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub BEditarEquiv_Click(sender As System.Object, e As System.EventArgs) Handles BEditarEquiv.Click
    '    Try
    '        GBEquivalencias.Enabled = True
    '        TEquivalencia.ReadOnly = False
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub TCodEmpPaca_Enter(sender As System.Object, e As System.EventArgs)
    '    Try
    '        EmpEtiq = "EMPAQUE"
    '        TipoEmp = "PACA"
    '        DCodEmpEtiq.Open("select * from ARTICULOS where TIPO='EM' ORDER BY NOMBRE")
    '        AsignaDataGrid(DGEmpaques, DCodEmpEtiq.DataTable, True)
    '        DGEmpaques.Visible = True
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub TCodEmpBolsa_Enter(sender As System.Object, e As System.EventArgs)
    '    Try
    '        EmpEtiq = "EMPAQUE"
    '        TipoEmp = "BOLSA"
    '        DCodEmpEtiq.Open("select * from ARTICULOS where TIPO='EM' ORDER BY NOMBRE")
    '        AsignaDataGrid(DGEmpaques, DCodEmpEtiq.DataTable, True)
    '        DGEmpaques.Visible = True
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    'Private Sub BAdicionaEmp_Click(sender As System.Object, e As System.EventArgs) Handles BAdicionaEmp.Click
    '    Try
    '        If DGEmpaques2.CurrentRow Is Nothing Then Return
    '        Dim CodEmp As String = DGEmpaques2.Rows(DGEmpaques2.CurrentRow.Index).Cells("DGEMPAQUES2_CODINT").Value.ToString
    '        Dim NomEmp As String = DGEmpaques2.Rows(DGEmpaques2.CurrentRow.Index).Cells("DGEMPAQUES2_NOMBRE").Value.ToString

    '        DArtDet.Open("Select * from ARTICULOSDET where CODINT='" + TCodInt.Text + "' and CODINTDET='" + CodEmp + "'")

    '        If DArtDet.Count = 0 Then
    '            DArtDet.AddNew()
    '        Else
    '            Resp = MsgBox("El registro ya existe, ¿desea sobreescribirlo?", vbInformation + vbYesNo)
    '            If Resp = vbNo Then Return
    '        End If

    '        DArtDet.RecordSet("CODINT") = CLeft(TCodInt.Text, 15)
    '        DArtDet.RecordSet("CODINTDET") = CodEmp
    '        DArtDet.RecordSet("NOMBREDET") = NomEmp
    '        DArtDet.RecordSet("TIPO") = "PT"

    '        DArtDet.Update()

    '        FRefrescaDGArticulosDet_Click(Nothing, Nothing)

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub


    Private Sub TBuscarEmp_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TBuscarEmp.KeyUp
        Try
            If CBBuscarEmp.Text = "" Then
                CBBuscarEmp.Focus()
                MsgBox("Debe seleccionar el campo a buscar", MsgBoxStyle.Exclamation)
                TBuscarEmp.Text = ""
                Exit Sub
            End If

            If TBuscarEmp.Text = "" Then
                FRefrescaDGEmp_Click(Nothing, Nothing)
                Exit Sub
            End If

            Dim x As Integer
            Dim Hallado As Boolean

            x = CBBuscarEmp.SelectedIndex

            'If TipoCampo(Campos(x), DTMat) <> "String" AndAlso e.KeyCode <> Keys.Enter Then Exit Sub


            BusquedaDG(DGEmpaques2, DEmpaques.DataTable, TBuscarEmp.Text, Campos2(x), Hallado)

            If Hallado = False Then
                'CBBuscar.Focus()
                'MsgBox("Registro no encontrado", MsgBoxStyle.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub FRefrescaDGEmp_Click(sender As System.Object, e As System.EventArgs) Handles FRefrescaDGEmp.Click
        Try
            DEmpaques.Refresh()
            AsignaDataGrid(DGEmpaques2, DEmpaques.DataTable, True)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    'Private Sub FRefrescaDGArticulosDet_Click(sender As System.Object, e As System.EventArgs) Handles FRefrescaDGArticulosDet.Click
    '    Try
    '        'Se trae todos los códigos de empaque asociados al producto
    '        DArtDet.Open("Select * from ARTICULOSDET where CODINT='" + TCodInt.Text + "'")
    '        AsignaDataGrid(DGArticulosDet, DArtDet.DataTable, True)
    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try

    'End Sub

    Private Sub BEliminaEmp_Click(sender As System.Object, e As System.EventArgs) Handles BEliminaEmp.Click
        Try
            If DGEmpaques2.CurrentRow Is Nothing Then Return
            Dim CodEmp As String = DGArticulosDet.Rows(DGArticulosDet.CurrentRow.Index).Cells("DGARTICULOSDET_CODINTDET").Value.ToString
            Dim NomEmp As String = DGArticulosDet.Rows(DGArticulosDet.CurrentRow.Index).Cells("DGARTICULOSDET_NOMBREDET").Value.ToString


            Resp = MsgBox(DevuelveEvento(CodEvento.BD_REGELIMINAR), vbInformation + vbYesNo)
            If Resp = vbNo Then Return

            DArtDet.Delete("delete from ARTICULOSDET where CODINT='" + TCodInt.Text + "' and CODINTDET='" + CodEmp + "'", Me)
            'FRefrescaDGArticulosDet_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    'Private Sub ConfigurarArticulosDetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConfigurarArticulosDetToolStripMenuItem.Click
    '    'Adicionamos todos los códigos de empaques a la tabla ArticulosDET la primera vez,
    '    'para solo usar esta tabla en el empaque
    '    Dim CodProd As String = ""
    '    Dim CodEmp As String = ""
    '    DArt.Refresh()

    '    For Each Fila As DataRow In DArt.Rows
    '        'Buscamos el código de empaque del PT y lo adicionamos a la tabla ARTICULOSDET
    '        CodProd = Fila("CODINT")
    '        CodEmp = Fila("CODEMP")

    '        If CodEmp = "-" Or CodEmp = "" Then Continue For
    '        DArtDet.Open("Select * from ARTICULOSDET where CODINT='" + CodProd + "' and CODINTDET='" + CodEmp + "'")

    '        If DArtDet.Count = 0 Then
    '            DArtDet.AddNew()
    '        Else
    '            Continue For
    '        End If

    '        DArtDet.RecordSet("CODINT") = CodProd
    '        DArtDet.RecordSet("CODINTDET") = CodEmp
    '        DVarios.Open("Select NOMBRE from ARTICULOS where TIPO='EM' and CODINT='" + CodEmp + "'")
    '        If DVarios.Count Then DArtDet.RecordSet("NOMBREDET") = DVarios.RecordSet("NOMBRE")
    '        DArtDet.RecordSet("TIPO") = "PT"

    '        DArtDet.Update()
    '    Next
    'End Sub

    'Private Sub BActEmp_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        If TCodEmp2.Text = "" Then
    '            MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código empaque"), vbInformation)
    '            Return
    '        End If


    '        'Se realiza verificación de que el código si exista en la tabla articulos

    '        DVarios.Open("Select * from ARTICULOS where TIPO='EM' and CODINT='" + TCodEmp2.Text + "'")

    '        If DVarios.Count = 0 Then
    '            MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " código empaque"), MsgBoxStyle.Information)
    '            Return
    '        End If

    '        DVarios.Open("Update ARTICULOS set CODEMP='" + TCodEmp2.Text + "' where TIPO='PT'")

    '        Evento("Actualiza en todos los productos código de empaque: " + TCodEmp2.Text)

    '        TCodEmp2.Text = ""

    '        BCancelar_Click(Nothing, Nothing)
    '        BActualizar_Click(Nothing, Nothing)

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub

    'Private Sub BActEtiq_Click(sender As System.Object, e As System.EventArgs)
    '    Try

    '        If TCodEtiq2.Text = "" Then
    '            MsgBox(DevuelveEvento(CodEvento.SISTEMA_FALTACAMPO, " código etiqueta"), vbInformation)
    '            Return
    '        End If

    '        'Se realiza verificación de que el código si exista en la tabla articulos

    '        DVarios.Open("Select * from ARTICULOS where TIPO='ET' and CODINT='" + TCodEtiq2.Text + "'")

    '        If DVarios.Count = 0 Then
    '            MsgBox(DevuelveEvento(CodEvento.BD_REGNOEXISTE, " código etiqueta"), MsgBoxStyle.Information)
    '            Return
    '        End If

    '        DVarios.Open("Update ARTICULOS set CODETIQ='" + TCodEtiq2.Text + "' where TIPO='PT'")

    '        Evento("Actualiza en todos los productos código de etiqueta: " + TCodEtiq2.Text)

    '        TCodEtiq2.Text = ""

    '        BCancelar_Click(Nothing, Nothing)
    '        BActualizar_Click(Nothing, Nothing)

    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub

    Private Sub mnInterfazArt_Click(sender As Object, e As EventArgs) Handles mnInterfazArt.Click
        Try
            Resp = Shell(Ruta + "ChrInterfazArt.EXE", AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    'Private Sub ChPaqueteo_CheckedChanged(sender As Object, e As EventArgs) Handles ChPaqueteo.CheckedChanged
    '    Try
    '        If Not FormLoad Then Return

    '        If ChPaqueteo.Checked Then
    '            GBPaqueteo.Visible = True
    '            GBPaqueteo.Enabled = True
    '        Else
    '            GBPaqueteo.Visible = False
    '            GBPaqueteo.Enabled = False
    '        End If


    '    Catch ex As Exception
    '        MsgError(ex)
    '    End Try
    'End Sub

    Private Sub CBCodDescarga_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBCodDescarga.SelectedIndexChanged
        Try
            DTamDesc.Find("CODDESC=" + CBCodDescarga.Text)

            If DTamDesc.Count = 0 Then Exit Sub

            TNomDescarga.Text = DTamDesc.RecordSet("NOMBRE").ToString
            TTamDescarga.Text = DTamDesc.RecordSet("TAMDESC").ToString
            TAlimFina.Text = DTamDesc.RecordSet("AFINA").ToString

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TCodEmp_TextChanged(sender As Object, e As EventArgs) Handles TCodEmp.TextChanged
        TCodEmp.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TCodEtiq_TextChanged(sender As Object, e As EventArgs) Handles TCodEtiq.TextChanged
        TCodEtiq.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TCodHilo_TextChanged(sender As Object, e As EventArgs) Handles TCodHilo.TextChanged
        TCodHilo.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub mnSalir_Click(sender As Object, e As EventArgs) Handles mnSalir.Click
        BSalir_Click(Nothing, Nothing)
    End Sub


    'Private Sub DGEquivalencias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGEquivalencias.CellClick
    '    Try


    '        If DGEquivalencias.RowCount = 0 Then Return
    '        Dim CodProdEquiv As String = DGEquivalencias.Rows(DGEquivalencias.CurrentRow.Index).Cells("DGEquivalencias_CodProdEqui").Value

    '        DVarios.Open("Select * from PRODEQUIVALENTES where CODPRODEQUI='" + CodProdEquiv + "'")

    '        If DVarios.Count Then
    '            TEquivalencia.Text = CodProdEquiv
    '            CBPresent.Text = DVarios.RecordSet("Present")

    '            If Funcion_ManejaPaqueteo Then
    '                If InStr(CBPresent.Text, "PK") Then
    '                    LPesoEquiv.Visible = True
    '                    TPresKgEquiv.Visible = True
    '                End If
    '                TPresKgEquiv.Text = DVarios.RecordSet("PresKg")
    '            End If

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex)
    '    End Try
    'End Sub


End Class