Option Explicit On
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices ' Espacio para capturar la traza de errores
Imports System.Data.Common  ' Espacio que permite la conexion bilateral Acces o Sql
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Module VariablesGlobales

#Region "Declaracion de Variables En el módulo"

    Public RutaDB As String
    Public RutaDB_SigCoPro As String
    Public RutaDB_SigCoPro_Engrasadores As String
    Public Ruta As String
    Public Sentencia As String
    Public TipoServer As String
    Public TipoServerNept As String
    Public RutaDB_ControlBascula As String
    Public RutaDB_ChrPremezclas As String

    Public CONN As DbConnection
    Public DbProvedor As DbProviderFactory

    Public Resp As Long
    Public ServidorSQL As String

    Public PWD As String
    Public UserDB As String
    Public NomDB As String
    Public RutaRep As String
    Public Planta As String
    Public DireccionPlanta As String
    Public DRUsuario As DataRow
    Public RespInput As String
    Public NombrePC As String
    Public UsuarioPrincipal As String
    Public Fuentes As Boolean
    Public ServComM As Boolean
    Public ServCHR As Boolean
    Public ServMicros As Boolean
    Public ServComMVisual As Boolean
    Public ServComMBP As Boolean
    Private List As New List(Of TextBox)
    Private ListBool As New List(Of Boolean)
    Public ReportesSap As Boolean = True
    Public RutaCB As String
    Public TolvaMatrizDif As Int32
    Public LoteCortesMP As String
    Public ContCortesMP As String
    Public UbicLoteMP As String
    Public Sesion As String
    Public UltimaOPEng(4) As String
    Public CerrarChr As Boolean = True
    Public solCambClave As Boolean
    Public DireccionIP As String

    'Variables para validacion de funciones
    Public Funcion_BasedeDatosPremExterna As Boolean
    Public Funcion_ManejaTablaProcDosif As Boolean
    Public Funcion_ManejaVehiculo As Boolean
    Public Funcion_ManejaOpticurp As Boolean
    Public Funcion_MaterialesXBandeja As Boolean
    Public Funcion_ManejaToleranciasPorcentaje As Boolean
    Public Funcion_VencimientoPorProducto As Boolean
    Public Funcion_ObligaLineaInvent As Boolean
    Public Funcion_RecibirEmpaqueAlmacen As Boolean
    Public Funcion_RecibirEmpaqueCalidad As Boolean
    Public Funcion_RecibirEmpaqueProduccion As Boolean
    Public Funcion_ManejaEstablecimiento As Boolean
    Public Funcion_FinalizarPlanillaSales As Boolean
    Public Funcion_ManejaCodforBIgualaCodProd As Boolean
    Public Funcion_ManejaFylax As Boolean
    Public Funcion_ManejaFysal As Boolean
    Public Funcion_PlantasExternas As Boolean 'Indica que maneja OPs de otras plantas
    Public Funcion_ManejaFunPremezcla As Boolean 'Maneja fun prmezcla, aplica para plantas cota y funza
    Public Funcion_DestinosPeletizado As Boolean 'Maneja destinos peletizadora para programa Gemba
    Public Funcion_MaterialesBandeja As Boolean 'Si lleva materiales por bandeja---esto es para girardota 
    Public Funcion_AdelantarEmpaquesyEtiquetas As Boolean 'Adelanta empaques y etiquetas en tabla EMPETIQDET
    Public Funcion_FuncionesPlantaPremezclas As Boolean 'Revisa funciones exclusivasx para la planta premezclas
    Public Funcion_ManejaSecuenciaMezcla As Boolean 'Funcionalidad que revisa si se debe alertar por config de secuencia de mezcla
    Public Funcion_ArchivoTraePaquetePrem As Boolean
    Public Funcion_PreguntaPorCodForB As Boolean
    Public Funcion_AprobarFormulaImportada As Boolean
    Public Funcion_ManejaPantallaVaceo As Boolean
    Public Funcion_BachesOpsVentas As Boolean
    Public Funcion_InactividadChronoSoft As Boolean
    Public Funcion_ConexionSigCoPro As Boolean
    Public Funcion_HumedadFormulada As Boolean
    Public Funcion_ManejaDestinoPLC As Boolean
    Public Funcion_ManejaRestriccionLineasNegocio As Boolean
    Public Funcion_ManejaTrasladoMicros As Boolean
    Public Funcion_ManejaPaqueteo As Boolean
    Public Funcion_AlimentaTolvasDesdeCB As Boolean
    Public Funcion_CentralBasculaServicioWEB As Boolean
    Public Funcion_GeneraAlarmaCorteSinAbrir As Boolean
    Public Funcion_DatosEngrasadores As Boolean
    Public Funcion_ManejaDosEstacionesPM As Boolean








#End Region

#Region "Funcion que reemplaza al VAL, no interesa la configuracion decimal 'EVAL'"
    Public Function Eval(ByVal Valor As String) As Double
        Dim Aux As String = ""
        Aux = Replace(Valor, ",", ".")
        Eval = Format(Val(Aux), ".000")
    End Function
#End Region





    Public Sub APlanoEng(ByVal Frase As String)
        Try
            Dim Archivo As FileStream
            Dim Frase2 As String = ""
            Frase2 = vbNewLine + Now.ToString("HH:mm:ss") + "  " + Frase
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase2)
            Archivo = New FileStream(Ruta + "Aplanos\Eng_" + Now.ToString("yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception

        End Try
    End Sub

#Region "Leer escribir ConfigVAr"
    Public Function ReadConfigVar(ByVal Campo As String) As String

        Dim DConfigVar As AdoSQL

        DConfigVar = New AdoSQL("CONFIGVAR")
        DConfigVar.Open("select * from CONFIGVAR where CAMPO='" + Campo + "'")

        ReadConfigVar = ""
        If DConfigVar.Count > 0 Then ReadConfigVar = DConfigVar.RecordSet("VALOR").ToString
    End Function
    Public Sub WriteConfigVar(ByVal Campo As String, ByVal Valor As String)

        Dim DConfigVar As AdoSQL

        DConfigVar = New AdoSQL("CONFIGVAR")
        DConfigVar.Open("select * from CONFIGVAR where CAMPO='" + Campo + "'")

        If DConfigVar.Count = 0 Then
            MsgBox("Campo no encontrado en la tabla configvar", vbCritical)
            Return
        End If
        DConfigVar.RecordSet("VALOR") = Valor
        DConfigVar.Update()

    End Sub
#End Region

#Region "Leer escribir FechasCierre"

    'Public Enum Tipo As Integer
    '    MP = 0      'Materia Prima
    '    PT = 1      'Producto Terminado
    '    AD = 2      'Adictivos
    '    PR = 3      'Premezclas
    '    EM = 4      'Empaques
    '    ET = 5      'Etiquetas
    'End Enum

    Public Enum ClaseFecha As Integer
        FISICO = 0      'Fecha de cierre inventario Fisico
        UNO = 1       'Fecha de cierre sistema uno
        COMPARATIVOINV = 2      'Fecha cierre modulo COMPARATIVOINV (Resumen Inventarios)
        ULTRESET = 3      'Ultima fecha de reset 
    End Enum


    Public Function ReadFechasCierre(ByVal Campo As String, ByVal ClaseFecha As ClaseFecha) As String

        Dim DFechasCierre As AdoSQL

        DFechasCierre = New AdoSQL("FECHASCIERRE")
        DFechasCierre.Open("select * from FECHASCIERRE where TIPO='" + Campo + "'")

        ReadFechasCierre = ""
        If DFechasCierre.Count > 0 Then ReadFechasCierre = DFechasCierre.RecordSet(ClaseFecha.ToString).ToString
    End Function
    Public Sub WriteFechasCierre(ByVal Campo As String, ByVal Valor As String, ByVal ClaseFecha As ClaseFecha)

        Dim DFechasCierre As AdoSQL

        DFechasCierre = New AdoSQL("FECHASCIERRE")
        DFechasCierre.Open("select * from FECHASCIERRE where TIPO='" + Campo.ToString + "'")

        If DFechasCierre.Count = 0 Then
            MsgBox("Campo no encontrado en la tabla configvar", vbCritical)
            Return
        End If
        DFechasCierre.RecordSet(ClaseFecha.ToString) = Valor
        DFechasCierre.Update()

    End Sub
#End Region


#Region "Asignar Datos de DataTable a DataGridView"
    Public Sub AsignaDataGrid(ByVal DG As DataGridView, ByVal DT As DataTable, Optional ByVal NomDGCol As Boolean = False)
        Try


            If DG Is Nothing Then _
            Throw New ArgumentException("Asignación no valida para el datagridview")

            DG.Rows.Clear()

            If DT Is Nothing Then Return

            For y As Integer = 0 To DT.Rows.Count - 1
                DG.Rows.Add()
                For i As Integer = 0 To DG.Columns.Count - 1
                    If DG.Columns(i).Name.Contains("_NI_") Then Continue For
                    If NomDGCol = True Then
                        Dim Pos As Integer = DG.Columns(i).Name.IndexOf("_")
                        Dim Campo As String = DG.Columns(i).Name.Substring(Pos + 1)
                        DG.Rows(y).Cells(DG.Columns(i).Name).Value = DT.Rows(y).Item(Campo)
                    Else
                        DG.Rows(y).Cells(DG.Columns(i).Name).Value = DT.Rows(y).Item(DG.Columns(i).Name)
                    End If
                Next
            Next
        Catch ex As System.ArgumentException
            Evento(ex.ToString)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
#End Region

#Region "Funcion LEFT"
    Public Function CLeft(ByVal Texto As String, ByVal N As Long) As String
        Try
            CLeft = ""
            If Texto.Length <= 0 Then Return CLeft
            Dim Dato As String
            Dato = Microsoft.VisualBasic.Left(Texto, N)
            CLeft = Dato
        Catch ex As Exception
            MsgError(ex)
            CLeft = ""
        End Try

    End Function
#End Region

#Region "Funcion RIGHT"
    Public Function CRight(ByVal Texto As String, ByVal N As Long) As String
        Try
            CRight = ""
            If Texto.Length <= 0 OrElse Texto.Length < N Then Return CRight
            Dim Dato As String
            Dato = Microsoft.VisualBasic.Right(Texto, N)
            CRight = Dato
        Catch ex As Exception
            MsgError(ex)
            CRight = ""
        End Try

    End Function
#End Region

#Region "Busqueda de datos en Módulos empleando ComboBox"
    Public Function AsignaItemsCB(ByVal ArrayCampos() As String, ByVal CB As ComboBox, ByVal DT As DataTable) As String()

        Dim Campos() As String = {"", ""}
        Dim Texto() As String = {"", ""}
        Dim Pos As Long
        Dim i As Integer
        Dim Dimension As Integer

        CB.Items.Clear()

        Dimension = ArrayCampos.Length - 1
        ReDim Campos(Dimension)
        ReDim Texto(Dimension)

        For Each Dato As String In ArrayCampos
            Pos = Dato.IndexOf("@")
            If Pos = 0 Then
                MsgBox("Debe mandar el caracter @ para distinguir los campos del texto a mostrar ", MsgBoxStyle.Exclamation)
                AsignaItemsCB = Campos
                Exit Function
            End If
            Campos(i) = CLeft(Dato, Pos)
            Texto(i) = Dato.Substring(Pos + 1)
            i += 1
        Next


        For i = 0 To Dimension
            'Se busca si el campo puede contener varios campos para incluirlo en la lista y hacer una busqueda especial
            If InStr(Campos(i), "-") Then
                CB.Items.Add(Texto(i))
                Continue For
            End If
            For Each DC As DataColumn In DT.Columns
                If DC.ColumnName.ToString.ToUpper = Campos(i).ToUpper Then
                    CB.Items.Add(Texto(i))
                    Exit For
                Else
                    'MsgBox("Algún campo de la lista enviada no existe en la tabla, favor verificar", MsgBoxStyle.Critical)
                End If
            Next
        Next
        AsignaItemsCB = Campos

    End Function
    Public Sub BusquedaDG(ByVal DG As DataGridView, ByVal DT As DataTable, ByVal Valor As String,
     ByVal Campo As String, Optional ByRef Encontrado As Boolean = False)
        Try
            Dim DFil() As DataRow
            Dim Tipo As String, Consulta As String
            Dim DTAux As New DataTable

            If DT.Rows.Count = 0 OrElse DG.Rows.Count = 0 OrElse Valor = "" OrElse Campo = "" Then Exit Sub

            'Tipo = DT.Columns.Item(Campo).GetType.Name
            Tipo = DT.Rows(0).Item(Campo).GetType.Name
            Consulta = Campo + "=" + Valor.ToUpper.Trim
            If Tipo = "String" Then
                Consulta = Campo + " LIKE '%" + Valor + "%'"
                DFil = DT.Select(Consulta)
                If DFil.Length <= 0 Then
                    Encontrado = False
                    Exit Sub
                End If
                Encontrado = True
                For Each C As DataColumn In DT.Columns
                    DTAux.Columns.Add(C.ColumnName)
                Next

                For Each R As DataRow In DFil
                    DTAux.ImportRow(R)
                Next

                If InStr(1, DG.Columns(0).Name, "_") > 0 Then
                    AsignaDataGrid(DG, DTAux, True)
                Else
                    AsignaDataGrid(DG, DTAux)
                End If

                DG.Rows(0).Selected = True
                DG.FirstDisplayedScrollingRowIndex = 0
                DG.CurrentCell = DG(0, 0)
            Else
                DFil = DT.Select(Consulta)
                If DFil.Length <= 0 Then
                    Encontrado = False
                    Exit Sub
                End If

                For Each Filasel As DataGridViewRow In DG.Rows
                    If Filasel.Cells(Campo).Value Is Nothing _
                        OrElse Filasel.Cells Is Nothing Then
                        Continue For
                    End If
                    If Valor.ToUpper = Filasel.Cells(Campo).Value.ToString.ToUpper.Trim Then

                        DG.Rows(Filasel.Index).Selected = True
                        DG.FirstDisplayedScrollingRowIndex = Filasel.Index
                        DG.CurrentCell = DG(0, Filasel.Index)

                        Encontrado = True
                        Exit For
                    End If
                Next
            End If


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub
    Public Sub BusquedaDGContains(ByVal DG As DataGridView, ByVal Campo As String, ByVal Valor As String, Optional ByRef Encontrado As Boolean = False)
        'Sobre cargamos el metodo de tal forma que permita filtar un datagrid sin que tengamos la tabla
        Dim Cont As Integer = 0
        Try
            For Each Filasel As DataGridViewRow In DG.Rows
                Filasel.Visible = True
            Next
            'If QuitarFiltro = True And Fila = 0 Then Exit Sub

            For Each Filasel As DataGridViewRow In DG.Rows
                Cont += 1
                If Filasel.Cells(Campo).Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                    Continue For
                End If
                If Filasel.Cells(Campo).Value.ToString.Contains(Valor) = False Then
                    Filasel.Visible = False
                Else
                    Encontrado = True
                End If
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BusquedaDGCond(ByVal DG As DataGridView, ByVal Campo As String, ByVal Valor As String, ByVal Condicion As String, Optional ByRef Encontrado As Boolean = False)
        'Sobre cargamos el metodo de tal forma que permita filtar un datagrid sin que tengamos la tabla
        Dim Cont As Integer = 0
        Try
            If Condicion = "" Then Return
            For Each Filasel As DataGridViewRow In DG.Rows
                Filasel.Visible = True
            Next
            'If QuitarFiltro = True And Fila = 0 Then Exit Sub

            For Each Filasel As DataGridViewRow In DG.Rows
                Cont += 1
                If Filasel.Cells(Campo).Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                    Continue For
                End If
                Select Case Condicion
                    Case "<>"
                        If Filasel.Cells(Campo).Value.ToString = Valor Then
                            Filasel.Visible = False
                        Else
                            Encontrado = True
                        End If
                    Case ">"
                        If Filasel.Cells(Campo).Value.ToString <= Valor Then
                            Filasel.Visible = False
                        Else
                            Encontrado = True
                        End If
                    Case "<"
                        If Filasel.Cells(Campo).Value.ToString >= Valor Then
                            Filasel.Visible = False
                        Else
                            Encontrado = True
                        End If
                    Case ">="
                        If Filasel.Cells(Campo).Value.ToString < Valor Then
                            Filasel.Visible = False
                        Else
                            Encontrado = True
                        End If
                    Case "<="
                        If Filasel.Cells(Campo).Value.ToString > Valor Then
                            Filasel.Visible = False
                        Else
                            Encontrado = True
                        End If
                    Case Else
                        Return
                End Select
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BusquedaDG(ByVal DG As DataGridView, ByVal Campo As String, ByVal Valor As String, Optional ByRef Encontrado As Boolean = False, Optional ByVal QuitarFiltro As Boolean = False, Optional ByRef Fila As Integer = 0)
        'Sobre cargamos el metodo de tal forma que permita filtar un datagrid sin que tengamos la tabla
        Dim Cont As Integer = 0
        Try
            For Each Filasel As DataGridViewRow In DG.Rows
                Filasel.Visible = True
            Next
            If QuitarFiltro = True And Fila = 0 Then Exit Sub

            For Each Filasel As DataGridViewRow In DG.Rows
                Cont += 1
                If Filasel.Cells(Campo).Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                    Continue For
                End If
                If Filasel.Cells(Campo).Value.ToString <> Valor Then
                    If Fila = 0 Then Filasel.Visible = False
                Else
                    Encontrado = True
                    If Fila <> 0 Then Exit For
                End If
            Next
            Fila = Cont - 1

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub BusquedaDGVariosCampos(ByVal DG As DataGridView, ByVal Campo As String, ByVal Valor As String, Optional ByRef Encontrado As Boolean = False)
        'Sobre cargamos el metodo de tal forma que permita filtar un datagrid sin que tengamos la tabla
        Dim Cont As Integer = 0
        Try
            For Each Filasel As DataGridViewRow In DG.Rows
                'Filasel.Visible = True
            Next
            'If QuitarFiltro = True And Fila = 0 Then Exit Sub

            If InStr(Campo, "-") = 0 Then
                Encontrado = False
                Return
            End If

            If InStr(Valor, "-") = 0 Then
                Encontrado = False
                Return
            End If

            Dim Campos() As String
            Dim Valores() As String

            Campos = Split(Campo, "-")
            Valores = Split(Valor, "-")
            Dim i As Integer

            For i = 0 To UBound(Campos)
                For Each Filasel As DataGridViewRow In DG.Rows

                    If Filasel.Cells(Campos(i)).Value Is Nothing _
                        OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                        Continue For
                    End If
                    If Filasel.Cells(Campos(i)).Value.ToString.Contains(Valores(i)) = False Then
                        Filasel.Visible = False
                    Else
                        Encontrado = True
                    End If
                Next

            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Public Function TipoCampo(ByVal Campo As String, ByVal DT As DataTable) As String
        TipoCampo = DT.Rows(0).Item(Campo).GetType.Name
    End Function
#End Region




#Region "Asignar Datos de un DATATABLE a un ComboBox"
    Public Sub LLenaComboBox(ByVal CB As ComboBox, ByVal DT As DataTable, ByVal Campo As String, Optional ByVal No As Integer = 0)
        CB.Items.Clear()

        For i As Integer = 0 To DT.Rows.Count - 1
            CB.Items.Add(DT.Rows(i).Item(Campo).ToString)
            If No > 0 AndAlso i = No - 1 Then Exit For
        Next
    End Sub
#End Region

#Region "Restringir el ingreso de datos a un TextBox de solo Números"

    Public Sub TextNum(ByVal Text As TextBox, Optional ByVal PuntoDec As Boolean = False)
        ' Si en la caja de texto se perimite el ingreseo de decimales
        ListBool.Add(PuntoDec)
        List.Add(Text)
        For i As Integer = 0 To List.Count - 1 ' Voy desde el 1 hasta el count -1
            AddHandler List(i).KeyPress, AddressOf TextSolo_Numeros
        Next

    End Sub
    Private Sub TextSolo_Numeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            Dim Index As Integer = List.IndexOf(txt)
            Dim Deci As Boolean = ListBool(Index)

            If Deci Then
                If (IsNumeric(e.KeyChar)) OrElse (e.KeyChar = ChrW(Keys.Back)) Or (e.KeyChar = ".") And (txt.Text.Contains(".") = False) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
                Exit Sub
            End If

            If (IsNumeric(e.KeyChar)) Or
               (e.KeyChar = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region

#Region "Limpiar todos los TextBox de un Formulario"

    Public Enum AccionTextBox As Integer
        Habilitar = 1
        Deshabilitar = 2
        Limpiar = 3
    End Enum


    Public Sub Limpiar_Habilitar_TextBox(ByVal Ctrls As Control.ControlCollection, ByVal Limpiar_Habilitar As AccionTextBox)
        'hace un chequeo por todos los textbox del formulario
        For Each oControl As Control In Ctrls
            If Ctrls.Count > 0 AndAlso (TypeOf oControl Is Panel OrElse TypeOf oControl Is GroupBox) Then
                Limpiar_Habilitar_TextBox(oControl.Controls, Limpiar_Habilitar)
            End If
            If TypeOf oControl Is TextBox Then
                If Limpiar_Habilitar = 3 Then
                    oControl.Text = ""
                ElseIf Limpiar_Habilitar = 1 Then 'Habilita para escritura las cajas de texto
                    CType(oControl, TextBox).ReadOnly = False
                ElseIf Limpiar_Habilitar = 2 Then 'Pone readonly las cajas de texto
                    CType(oControl, TextBox).ReadOnly = True
                End If

                'CType(oControl, TextBox).BackColor = Color.White
            End If
        Next
    End Sub
#End Region

#Region "Sumar Columna de un DataGridView"
    Public Function SumColumn(ByVal DG As DataGridView, ByVal Campo As String) As Double
        Try
            SumColumn = 0
            For Each Filasel As DataGridViewRow In DG.Rows

                If DG.DataSource Is Nothing = False Then
                    If Filasel.DataBoundItem(Campo) Is Nothing OrElse Filasel.Cells Is Nothing OrElse
                    Filasel.Visible = False Then
                        Continue For
                    End If
                    SumColumn += Eval(Filasel.DataBoundItem(Campo))
                Else
                    If Filasel.Cells(Campo).Value Is Nothing _
                        OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                        Continue For
                    End If
                    SumColumn += Eval(Filasel.Cells(Campo).Value)
                End If

            Next
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Function
#End Region

#Region "Mensaje de Error"
    'Public Sub MsgError(ByVal Msg As Exception, Optional ByVal Entidad As String = "")
    '    MessageBox.Show(Msg.Message, My.Application.Info.AssemblyName.ToString, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Evento(Msg.ToString + " " + Entidad)
    'End Sub
    Public Sub MsgError(ByVal Msg As Exception, Optional ByVal Entidad As String = "", <CallerFilePath> Optional sourceFilePath As String = Nothing)

        Dim traza = New StackTrace()
        Dim linea As String = ""

        Dim Formulario As String = sourceFilePath.Substring(sourceFilePath.LastIndexOf("\") + 1).TrimEnd(".", "v", "b")

        If Msg.StackTrace.LastIndexOf("línea") > 0 Then
            linea = Msg.StackTrace.Substring(Msg.StackTrace.LastIndexOf("línea"))
            linea = Mid(linea, 6)
        End If

        Dim message As String = String.Format("Mensaje : {0} " & vbLf &
                                              "Modulo : {1} " & vbLf &
                                              "Linea: {2}",
                                              Msg.Message, Formulario, linea)
        MessageBox.Show(message + Entidad, My.Application.Info.AssemblyName.ToString, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Evento(Msg.ToString + " " + Entidad)
    End Sub

#End Region

#Region "Escritura Archivo"
    Public Sub WriteFile(ByVal Ruta As String, ByVal Msg As String, Optional ByVal SobreEscb As Boolean = True)
        If String.IsNullOrEmpty(Ruta) OrElse String.IsNullOrEmpty(Msg) Then
            Throw New ArgumentException(
                        "Datos erroneos para la escritura del archivo")
        End If

        If Directory.Exists(Path.GetDirectoryName(Ruta)) = False Then
            MsgBox("La ruta No es Válida para la generación del archivo", vbCritical)
            Return
        End If

        Dim Wrt As StreamWriter
        Wrt = New StreamWriter(Ruta, SobreEscb)
        Wrt.WriteLine(Msg)
        Wrt.Close()
        Wrt.Dispose()
    End Sub
#End Region
#Region "Alarma"
    Public Sub Alarma(ByVal Mensaje As String, Optional ByVal Estilo As AppWinStyle = AppWinStyle.NormalFocus)
        Try
            Dim DAlArmas As AdoSQL

            DAlArmas = New AdoSQL("Alarmas")
            DAlArmas.Open("Select * from ALARMAS WHERE ID=0")
            If String.IsNullOrEmpty(Mensaje) Then Return

            DAlArmas.AddNew()
            DAlArmas.RecordSet("ALARMA") = CLeft(Mensaje, 100)
            DAlArmas.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DAlArmas.Update()

            Evento(Mensaje)

            If File.Exists(Ruta + "Alarmas.exe") = False Then Return

            Resp = Shell(Ruta + "Alarmas.exe", AppWinStyle.NormalFocus)
            ' Process.Start(Ruta + "Alarmas.exe")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
#End Region

#Region "Totaliza o finaliza baches"

    Public Sub TotFinBache(ByVal Recordset As DataRow)

        Dim DConsumos As New AdoSQL("CONSUMOS")
        Dim DBaches As New AdoSQL("Baches")
        Try
            If Recordset Is Nothing Then _
            Throw New ArgumentException("Faltan datos en el bache a procesar")

            DBaches.Open("Select * from BACHES where CONT=" + Recordset("CONT").ToString)

            If DBaches.Count = 0 Then Return

            DConsumos.Open("Select sum(PESOMETA) AS PESOMETA, sum(PESOREAL) AS PESOREAL  from COSNUMOS where CONT=" + Recordset("CONT").ToString)

            If IsDBNull(DConsumos.RecordSet("PESOMETA")) OrElse IsDBNull(DConsumos.RecordSet("PESOREAL")) Then Return

            DBaches.RecordSet("PESOREAL") = DConsumos.RecordSet("PESOREAL")

            If Math.Abs(DBaches.RecordSet("PESOMETA") - DConsumos.RecordSet("PESOMETA")) < Eval(0.05) Then
                DBaches.RecordSet("ESTADO") = 10 'El bache está completo
            End If

            DBaches.Update()


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

#End Region

#Region "Clave Dinamica"

    Public Function ValidaClave(ByVal Clave As String) As Boolean
        Dim ClaveReal As String
        If String.IsNullOrEmpty(Clave) Then _
            Throw New ArgumentException("Clave no válida")
        ClaveReal = Today.Day.ToString + Today.Month.ToString + Now.Hour.ToString
        ValidaClave = False
        If Clave = ClaveReal Then ValidaClave = True
        Return ValidaClave
    End Function

#End Region

#Region "Exportar Consumos"
    Public Sub ExportAr()
        Dim SumaForm As Single
        Dim ExportOk As Boolean
        Dim DOPs As AdoSQL
        Dim DCExportArConsumos As AdoSQL
        Dim DEmpaque As AdoSQL
        Dim DFor As AdoSQL
        Dim DBaches As AdoSQL
        Dim DExportAr As AdoSQL
        Dim SumaReal() As Single
        Dim CodMatB() As String
        Dim j As Integer
        Dim Sentencia As String
        Dim RutaSave As String

        Try
            DOPs = New AdoSQL("OPS")
            DCExportArConsumos = New AdoSQL("Export")
            DBaches = New AdoSQL("BACHES")
            DExportAr = New AdoSQL("ExportArc")
            DFor = New AdoSQL("FORMULAS")
            DEmpaque = New AdoSQL("EMPAQUE")

            DOPs.Open("select * from OPS where FINALIZADO='S' and FINOPEMP='S' and EXPORT=0")

            If DOPs.Count = 0 Then Exit Sub

            For Each Recordset As DataRow In DOPs.Rows

                DBaches.Open("select * from BACHES where OP=" + Recordset("OP").ToString + " order by CONT")

                If DBaches.Count = 0 Or DBaches.Count <> Recordset("Meta") Then GoTo SigOP 'Verificamos que el numero de baches sea igual a los programados

                ReDim SumaReal(Recordset("CantMatFor"))

                For Each BachesRecordset As DataRow In DBaches.Rows

                    DCExportArConsumos.Open(" select * from CEXPORTARCONSUMOS where OP=" + Recordset("OP").ToString + " and CONT=" + BachesRecordset("Cont").ToString)
                    If DCExportArConsumos.Count = 0 Then GoTo SigOP
                    If DCExportArConsumos.Count <> Recordset("CantMatFor") Then GoTo SigOP 'Exit Sub
                Next

                DCExportArConsumos.Open(" select CODMAT,CODMATB, sum(PESOREAL)as PESOTOTINGRE from CEXPORTARCONSUMOS where OP=" + Recordset("OP").ToString + " group by CODMAT,CODMATB")
                j = 0
                If Recordset("CantMatFor") < DCExportArConsumos.Count Then
                    ReDim SumaReal(DCExportArConsumos.Count)
                End If

                ReDim CodMatB(SumaReal.Length - 1)

                For Each RecordCExp As DataRow In DCExportArConsumos.Rows
                    SumaReal(j) = RecordCExp("PESOTOTINGRE")
                    CodMatB(j) = RecordCExp("CODMATB")
                    j = j + 1
                Next

                SumaForm = 0
                For j = 0 To UBound(SumaReal) - 1  ' Creamos los resgistros que vamos a exportar

                    DExportAr.Open("select * from EXPORTAR where CODLOTE='0'")
                    DExportAr.AddNew()
                    DExportAr.RecordSet("CodLote") = Recordset("LoteProd")
                    DExportAr.RecordSet("CodProd") = CodMatB(j)
                    DExportAr.RecordSet("FechaC") = Recordset("FechaC")
                    DExportAr.RecordSet("FechaCr") = Recordset("FechaCr")
                    DExportAr.RecordSet("FhVence") = Recordset("FechaVenc")
                    'DExportAr!cantprod = DOPs!Porc * DOPs!Meta * DDatosFor!Valor * 0.01
                    DExportAr.RecordSet("CantProd") = Format(SumaReal(j), ".00")
                    DExportAr.Update()
                    SumaForm = SumaForm + Format(SumaReal(j), ".00")
                Next

                DEmpaque.Open("Select CODEMP, SUM(SACOS) as SUMSACOS FROM EMPAQUE where OP='" + Recordset("OP").ToString + "' GROUP BY CODEMP")

                For Each RECEMP As DataRow In DEmpaque.Rows
                    DExportAr.Open("select * from EXPORTAR where CODLOTE='0'")
                    DExportAr.AddNew()
                    DExportAr.RecordSet("CodLote") = Recordset("LoteProd")
                    DExportAr.RecordSet("CodProd") = RECEMP("CODEMP").ToString
                    DExportAr.RecordSet("FechaC") = Recordset("FechaC")
                    DExportAr.RecordSet("FechaCr") = Recordset("FechaCr")
                    DExportAr.RecordSet("FhVence") = Recordset("FechaVenc")
                    'DExportAr!cantprod = DOPs!Porc * DOPs!Meta * DDatosFor!Valor * 0.01
                    DExportAr.RecordSet("CantProd") = Format(RECEMP("SUMSACOS"), ".00")
                    DExportAr.Update()
                Next

                Sentencia = "select * from EXPORTAR where CODLOTE='" + Recordset("LoteProd").ToString + "'"
                'RutaSave = Ruta + "Ofimatica\ChrOP_" + Recordset("OP").ToString + ".xlsx"
                RutaSave = Ruta + "Ofimatica\ChrOP_" + Recordset("OP").ToString + ".csv"
                Dim CodF As String
                DFor.Open("select * from FORMULAS where CODFOR='" + Recordset("CodFor").ToString + "' and LP='" + Recordset("LP").ToString + "'")
                CodF = 0
                If DFor.Count > 0 Then CodF = DFor.RecordSet("CODFORB")
                ' ExportOk = ExporExcel(Sentencia, RutaSave, CodF, SumaForm) 'Enviamos parametros a la Funcion que exporta a Excel lo Consumos
                ExportOk = ExportArText(Sentencia, RutaSave, CodF, SumaForm) 'Enviamos parametros a la Funcion que exporta a Excel lo Consumos

                If ExportOk Then
                    Evento("Se realizó la exportación a Ofimática con éxito OP:" + Recordset("OP").ToString)
                    DExportAr.Delete("delete from EXPORTAR where CODLOTE='" + Recordset("LoteProd").ToString + "'")
                    Recordset("Export") = True
                    DOPs.Update()
                End If



SigOP:
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try


    End Sub

    Private Function ExportArText(ByVal Sentencia As String, ByVal RutaSave As String, ByVal Formula As String, ByVal SumaForm As Single) As Boolean
        Dim DVarios As AdoSQL
        Dim Contenido As String = ""
        Dim Caracter As Char = ","


        Try
            DVarios = New AdoSQL("Varios")
            DVarios.Open(Sentencia)

            If DVarios.Count = 0 Then
                ExportArText = False
                Exit Function
            End If

            For Each Col As DataColumn In DVarios.DataTable.Columns
                Contenido += Col.ColumnName + Caracter
            Next

            Contenido = Mid(Contenido, 1, InStrRev(Contenido, Caracter) - 1)
            Contenido += vbNewLine

            ' Escribimos el registro de los datos del la Fórmula

            Contenido += DVarios.RecordSet("CODLOTE").ToString + Caracter
            Contenido += Formula + Caracter + DVarios.RecordSet("FECHAC").ToString + Caracter
            Contenido += DVarios.RecordSet("FECHACR").ToString + Caracter
            Contenido += DVarios.RecordSet("FHVENCE").ToString + Caracter
            Contenido += Format(SumaForm, ".00") + vbNewLine

            For Each Recordset As DataRow In DVarios.Rows
                Dim Col() As Object
                Col = Recordset.ItemArray
                For Each item As Object In Col
                    Contenido += item.ToString + Caracter
                Next
                Contenido = Mid(Contenido, 1, InStrRev(Contenido, Caracter) - 1)
                Contenido += vbNewLine
            Next

            WriteFile(RutaSave, Contenido, False)
            ExportArText = True

        Catch ex As Exception
            MsgError(ex)
            ExportArText = False
        End Try

    End Function




#End Region

#Region "Historicos"

    Public Function MakeHist(Optional ByVal Intervalo As Long = 3) As Boolean

        Dim CONNH As DbConnection
        Dim RutaDBH As String
        Dim DVarios As New AdoSQL("VARIOS")
        Dim DVarios1 As New AdoSQL("VARIOS1")
        Dim DVariosH As AdoSQL
        Dim DCopyH As AdoSQL
        Dim FechaLim As String


        Try

            If Intervalo <= 0 Then _
            Throw New ArgumentException("El intervalo de traslado de información no puede ser menor o igual a cero")

            If TipoServer = "SQLSERVER" Then
                RutaDBH = "Data Source=" + ServidorSQL + "; Initial Catalog=" + NomDB + "H " + "; User Id=" + UserDB + "; Password=" + PWD
            Else
                RutaDBH = Ruta + "ChronoSoftH.mdb"
                RutaDBH = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + RutaDB.Trim + ";Jet OLEDB:Database Password=NEP;"
            End If


            CONNH = DbProvedor.CreateConnection
            CONNH.ConnectionString = RutaDBH
            FechaLim = Format(DateAdd("m", -Intervalo, Now), "yyyy/MM/dd")

            DVariosH = New AdoSQL("VARIOSH")
            DCopyH = New AdoSQL("COPYH")


            '------------------------------Traslada los baches y consumos a los historicos ----------------------------------
            If TipoServer = "SQLSERVER" Then
                DVarios.Open("Select COUNT(*) as DB from sys.databases where NAME='" + NomDB + "H'")
                If DVarios.RecordSet("DB") = 0 Then _
                    Throw New ArgumentException("La base de datos de históricos no existe")

                CompareTable("Baches", CONNH)
                CompareTable("Consumos", CONNH)
            End If


            DVariosH.Open("select * from BACHES where Cont=0")
            DCopyH.Open("select * from CONSUMOS where Cont=0")
            DVarios.Open("select * from BACHES where Fecha<'" + FechaLim + "'")

            For Each RecordSet As DataRow In DVarios.Rows

                DVarios1.Open("select * from CONSUMOS where CONT=" + RecordSet("CONT").ToString)

                For Each RecordC As DataRow In DVarios1.Rows
                    DCopyH.AddNew()
                    For i As Integer = 0 To DVarios1.DataTable.Columns.Count - 1
                        DCopyH.RecordSet(i) = RecordC(i)
                    Next
                    DCopyH.Update()
                    Application.DoEvents()
                Next

                DVarios1.Delete("delete from CONSUMOS where CONT=" + RecordSet("CONT").ToString)

                DVariosH.AddNew()
                For i As Integer = 0 To DVarios.DataTable.Columns.Count - 1
                    DVariosH.RecordSet(i) = RecordSet(i)
                Next
                DVariosH.Update()
                Application.DoEvents()
            Next

            DVarios.Delete("delete from BACHES where Fecha<'" + FechaLim + "'")


            '------------------------------Copia la tabla de EMPAQUE a los historicos ----------------------------------
            If TipoServer = "SQLSERVER" Then
                CompareTable("Empaque", CONNH)
            End If
            DVarios.Open("select * from EMPAQUE where Fechaini<'" + FechaLim + "'")

            For Each RecordSet As DataRow In DVarios.Rows

                DVariosH.Open("select * from EMPAQUE where Cont=" + RecordSet("CONT").ToString)

                If DVariosH.Count = 0 Then
                    DVariosH.AddNew()
                End If
                For i As Integer = 0 To DVarios.DataTable.Columns.Count - 1
                    DVariosH.RecordSet(i) = RecordSet(i)
                Next
                DVariosH.Update()
                Application.DoEvents()
            Next
            DVarios.Delete(". EMPAQUE where Fechaini<'" + FechaLim + "'")

            Return True
        Catch ex As Exception
            MsgError(ex)
            Return False
        End Try
    End Function
    Private Sub CompareTable(ByVal Tabla As String, ByVal CONNH As DbConnection)
        Dim DVarios As New AdoSQL("VARIOS")
        Dim DVariosH As New AdoSQL("VARIOSH")
        Dim CampoExist As Boolean
        Try
            DVarios.Open("select * from " + Tabla)
            DVariosH.Open("select * from " + Tabla)

            For Each Column As DataColumn In DVarios.DataTable.Columns
                CampoExist = True
                For Each Col As DataColumn In DVariosH.DataTable.Columns
                    CampoExist = False
                    If Col.ColumnName = Column.ColumnName Then
                        CampoExist = True
                        Exit For
                    End If
                Next
                If CampoExist = False Then
                    CreaCampo(Tabla, Column, CONNH)
                End If
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Private Sub CreaCampo(ByVal Tabla As String, ByVal Campo As DataColumn, ByVal CONNH As DbConnection)
        Dim Tipo As String
        Dim Comand As Common.DbCommand

        Try
            Comand = DbProvedor.CreateCommand

            If CONNH.State <> ConnectionState.Connecting Then CONNH.Open()

            Tipo = Campo.DataType.Name

            If Tipo = "Byte" OrElse Tipo = "Single" OrElse Tipo = "Int32" OrElse Tipo = "Short" OrElse Tipo = "Long" OrElse Tipo = "Double" Then
                Tipo = "REAL"
            ElseIf Tipo = "String" Then
                Tipo = "NVARCHAR(50)"
            ElseIf Tipo = "Boolean" Then
                Tipo = "Bit"
            End If

            Comand.Connection = CONNH
            Comand.CommandText = "alter Table " + Tabla + " ADD " + Campo.ColumnName + " " + Tipo + " NULL "

            Comand.ExecuteNonQuery()
            CONNH.Close()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

#End Region

#Region "Verificar el Servidor SQLSERVER"
    Public Function VerificaServSQL(ByVal ServidorSQL As String) As Boolean
        Dim SqlServer As DataTable
        Dim Servidores As DbDataSourceEnumerator
        Dim Ip() As Net.IPAddress
        Dim Host As String
        Dim ServExist As Boolean
        Try

            Servidores = DbProvedor.CreateDataSourceEnumerator
            SqlServer = Servidores.GetDataSources

            For Each servSQL As DataRow In SqlServer.Rows
                ServExist = False
                If Eval(ServidorSQL) = 127 OrElse ServidorSQL.ToUpper.Contains("HOST") Then
                    If ServidorSQL.Contains("\") Then
                        ServidorSQL = My.Computer.Name + Mid(ServidorSQL, InStr(ServidorSQL, "\"))
                    Else
                        ServidorSQL = My.Computer.Name
                    End If
                End If

                If Eval(ServidorSQL) > 0 Then
                    Ip = Net.Dns.GetHostAddresses(servSQL("ServerName"))
                    Host = Ip(0).ToString

                    If ServidorSQL.Contains("\") Then
                        'Ip = CLeft(ServidorSQL, InStr(ServidorSQL, "\") - 1)
                        'Host = Net.Dns.GetHostEntry(Ip).HostName.ToUpper + Mid(ServidorSQL, InStr(ServidorSQL, "\"))

                        If ServidorSQL.ToUpper = Host.ToUpper & "\" & servSQL("InstanceName").ToString.ToUpper Then
                            ServExist = True
                            Exit For
                        End If
                    Else

                        If ServidorSQL = Host Then
                            ServExist = True
                            Exit For
                        End If
                    End If

                    'Ip = Net.Dns.GetHostAddresses(servSQL("ServerName"))
                Else
                    If ServidorSQL.Contains("\") Then
                        If ServidorSQL.ToString.ToUpper = servSQL("ServerName").ToString.ToUpper & "\" & servSQL("InstanceName").ToString.ToUpper Then
                            ServExist = True
                            Exit For
                        End If
                        'servSQL("ServerName") & "\" & servSQL("InstanceName")
                    Else
                        If ServidorSQL.ToString.ToUpper = servSQL("ServerName").ToString.ToUpper Then
                            ServExist = True
                            Exit For
                        End If
                    End If
                End If
            Next

            Return ServExist

        Catch ex As Exception
            Return False
            MsgError(ex)
        End Try
    End Function
#End Region

#Region "Verificar si hay conexion al motor de base de datos"
    Public Function VerificarConexionDB(CadenaConexion) As Boolean
        Try
            Using conn As New SqlConnection(CadenaConexion)
                conn.Open()
                Return True
            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function
#End Region

#Region "Inventarios"

    Public Enum TipoInv As Integer
        CHRONOS = 1
        FISICO = 2
        UNO = 3
    End Enum

    Public Enum DetOperacion As Integer
        NINGUNO = 0
        ENMP = 1         'Entrada MP desde el módulo cortes
        CONSUMO = 2      'Consumos ChronoSoft
        SLPT = 3      'Despacho de  producto terminado
        INGMANUAL = 4  'Ingreso Manual(Det bache), entra consmos, entra bache
        LEEINVENTARIO = 5 'Lee inventario de sistema UNO
        SLMP = 6          'Salidas de MP en los cortes de lote
        ENPT = 7         'Entrada Producto terminado a bodega
        AJUSTEINVENTARIO = 8 'Ajuste de inventario
    End Enum



    Public Function Inventario(ByVal CodInt As String, ByVal Cantidad As Double, ByVal TipoInv As TipoInv,
                              ByVal Lote As String, Optional ByVal Detalle As DetOperacion = 0,
                              Optional ByVal Ubicacion As String = "-", Optional ByVal Condicion As String = "-",
                              Optional ByVal Unds As Int32 = 0, Optional ByVal PromSac As Double = 0,
                              Optional ByVal FacturaNro As String = "-", Optional ByVal Observaciones As String = "-",
                              Optional ByVal Maquila As String = "-", Optional ByVal Usuario As String = "") As Boolean
        Try
            Dim DArt As AdoSQL
            Dim DMovInv As AdoSQL
            Dim DTipo As AdoSQL
            Dim SaldoIni As Double

            Inventario = False


            DArt = New AdoSQL("ARTICULOS")
            DMovInv = New AdoSQL("MovInv")
            DTipo = New AdoSQL("TIPOSMAT")

            DArt.Open("Select * from ARTICULOS where CODINT='" + CodInt + "'")
            DTipo.Open("Select * from TIPOSMAT")

            If DArt.Count = 0 Then
                'Throw New ArgumentException( _
                '           "El código a no se encuentra registrado en tabla Artículos")
                MsgBox("El código " + CodInt + " no se encuentra registrado en tabla Artículos", MsgBoxStyle.Critical)
                Return Inventario
            End If

            If Cantidad = 0 Then Return Inventario


            'Abrimos el recordset con el codint y lote para buscar el saldo anterior
            ' Si es mov de PT no se tiene encuenta el LOTE
            If Detalle = DetOperacion.AJUSTEINVENTARIO OrElse Detalle = DetOperacion.SLPT OrElse Detalle = DetOperacion.ENPT Then

                DMovInv.Open("Select top 1 * from MovInv where CODINT='" + CodInt +
                                     "' and TIPOMOV='" + TipoInv.ToString + "' order by ID desc")
            Else

                DMovInv.Open("Select * from MovInv where CODINT='" + CodInt + "' and LOTE='" +
                                    Lote + "' and TIPOMOV='" + TipoInv.ToString + "' order by ID desc")
            End If


            SaldoIni = DArt.RecordSet("INVCHRONOS")
            If DMovInv.Count > 0 Then
                SaldoIni = DMovInv.RecordSet("SALDOFIN")
            End If

            'Creamos un registro en la tabla DetInventarios para tener historico de movimientos


            DMovInv.AddNew()
            DMovInv.RecordSet("TIPOMOV") = TipoInv.ToString
            DMovInv.RecordSet("DETALLE") = Detalle.ToString.Trim
            DMovInv.RecordSet("CODINT") = DArt.RecordSet("CODINT")
            DMovInv.RecordSet("NOMBRE") = DArt.RecordSet("NOMBRE")
            DMovInv.RecordSet("SALDOINI") = SaldoIni
            DMovInv.RecordSet("SALDOFIN") = DMovInv.RecordSet("SALDOINI") + Cantidad

            'Buscamos en la tabla TIPOSMAT el tipo para almacenarlo en la tabla MOVINV
            DTipo.Find("TIPOMAT=" + DArt.RecordSet("TIPOMAT").ToString)
            If Not DTipo.EOF Then
                DMovInv.RecordSet("TIPO") = DTipo.RecordSet("TIPO")
            Else
                DMovInv.RecordSet("TIPO") = DArt.RecordSet("TIPO")
            End If

            'Si el saldofin es negativo para el los articulos<> de materia prima no se puede registrar el
            'movimiento del inventario

            If DMovInv.RecordSet("TIPO") <> "MP" And DMovInv.RecordSet("DETALLE") = "SLPT" Then
                If DMovInv.RecordSet("SALDOFIN") < 0 Then
                    MsgBox("No se puede realizar el movimiento, se crearían saldos negativos para el artículo", MsgBoxStyle.Critical)
                    Return Inventario
                End If
            End If


            Select Case TipoInv
                Case 1 'Inventario ChronoSoft
                    DArt.RecordSet("INVCHRONOS") = DMovInv.RecordSet("SALDOFIN")
                Case 2

                    DMovInv.RecordSet("UNDS") = Unds
                    'Solo si se hace un ajuste físico se pueden ajustar los kilos en la tabla de articulos
                    If Detalle = DetOperacion.AJUSTEINVENTARIO Then
                        DArt.RecordSet("INVFISICO") += Cantidad
                    End If
                Case 3
                    DArt.RecordSet("INVUNO") = Cantidad
                    DMovInv.RecordSet("SALDOFIN") = Cantidad
            End Select

            ' DMovInv.RecordSet("CANTIDAD") = Cantidad

            If Cantidad > 0 Then
                DMovInv.RecordSet("ENTRA") = Cantidad
            Else
                DMovInv.RecordSet("SALE") = Cantidad
            End If

            DMovInv.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DMovInv.RecordSet("LOTE") = Lote
            DMovInv.RecordSet("CODUBI") = Ubicacion
            DMovInv.RecordSet("PROMSAC") = PromSac


            DMovInv.RecordSet("UNDS") = Unds
            DMovInv.RecordSet("FACTURANRO") = FacturaNro
            DMovInv.RecordSet("OBSERVACIONES") = CLeft(Observaciones, 50)
            DMovInv.RecordSet("CODMAQ") = Maquila
            DMovInv.RecordSet("USUARIO") = Usuario
            DMovInv.RecordSet("LINEA") = DArt.RecordSet("LINEA")

            ' If DArt.RecordSet("TIPO") = "PT" Then DMovInv.RecordSet("UNDS") = Cantidad \ DArt.RecordSet("PRESKG")

            DMovInv.Update()

            DArt.Update()

            Inventario = True
            Evento("Actualiza Inventario " + TipoInv.ToString + " Cantidad " + Cantidad.ToString + " Articulo " + CodInt.ToString)
            Return Inventario

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Function



    Public Function TramaEtiquetaMP(ByVal Corte As String, ByVal CodInt As String, ByVal Nombre As String, Optional ByVal Lote As String = "", Optional ByVal Condicion As String = "-", Optional ByVal Ubicacion As String = "-", Optional ByVal PesoProm As String = "0") As String

        Dim Sentencia As String = ""
        Dim Separador As String = "K"

        TramaEtiquetaMP = ""
        Sentencia = "^XA" + vbNewLine
        Sentencia += "^FO50,5^ADN,10,10" + vbNewLine  'Ubicación Planta
        Sentencia += "^FD" + Planta + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO560,5^ADN,10,10" + vbNewLine 'Fecha Impresion
        Sentencia += "^FDFECHA IMP." + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO680,5^ADN,10,10^FD" + Now.ToString("yy/MM/dd") + vbNewLine
        Sentencia += "^FS" + vbNewLine

        'Parte de impresion de texto en la etiqueta


        Sentencia += "^FO50,180^ADN,15,15" + vbNewLine
        Sentencia += "^FDCODIGO: " + CLeft(CodInt, 10) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO400,180^ADN,15,15" + vbNewLine
        Sentencia += "^FDUBICACION: " + CLeft(Ubicacion, 3) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,220^ADN,15,15" + vbNewLine
        Sentencia += "^FD" + CLeft(Nombre, 25) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,260^ADN,15,15" + vbNewLine
        Sentencia += "^FDLOTE: " + CLeft(Lote, 15) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,300^ADN,15,15" + vbNewLine
        Sentencia += "^FDPESO PROMEDIO: " + CLeft(PesoProm, 5) + " Kg" + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,340^ADN,15,15" + vbNewLine
        Sentencia += "^FDCONDICION: " + CLeft(Condicion, 10) + vbNewLine
        Sentencia += "^FS" + vbNewLine

        'Parte para impresion del codigo de barras

        Sentencia += "^FO100,40^BY1.5,2" + vbNewLine
        Sentencia += "^B3N,N,100,Y,N" + vbNewLine
        Sentencia += "^FDINIMP" + Separador    '  INIXXX#  indica el inicio de trama
        Sentencia += Ubicacion + Separador  'Condición
        Sentencia += Replace(PesoProm, ",", ".") + Separador       'Peso promedio saco
        Sentencia += Corte + Separador 'Codigo corte
        Sentencia += "FIN" + vbNewLine  'Fin de trama 
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^XZ" + vbNewLine  'Fin de trama para impresion
        TramaEtiquetaMP = Sentencia

    End Function

    Public Function TramaEtiquetaPT(ByVal CodInt As String, ByVal Present As String, ByVal Nombre As String, Optional ByVal Lote As String = "", Optional ByVal Condicion As String = "-", Optional ByVal Ubicacion As String = "-", Optional ByVal Sacos As String = "0", Optional ByVal BachesMeta As String = "0", Optional ByVal Observ As String = "") As String

        Dim Sentencia As String = ""

        Dim Separador As String = "K"

        TramaEtiquetaPT = ""
        Sentencia = "^XA" + vbNewLine
        Sentencia += "^FO50,5^ADN,10,10" + vbNewLine  'Planta
        Sentencia += "^FD" + Planta + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO560,5^ADN,10,10" + vbNewLine 'Fecha Impresion
        Sentencia += "^FDFECHA IMP." + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO680,5^ADN,10,10^FD" + Now.ToString("yy/MM/dd") + vbNewLine
        Sentencia += "^FS" + vbNewLine



        'Parte para impresion del codigo de barras
        Sentencia += "^FO100,40^BY1.5,2" + vbNewLine
        Sentencia += "^B3N,N,100,Y,N" + vbNewLine
        Sentencia += "^FDINIPT" + Separador   '  INI  indica el inicio de trama
        Sentencia += Condicion + Separador  'Condición
        Sentencia += Ubicacion + Separador       'Campo Destino de la tabla empaque
        Sentencia += Present + Separador       'Presentacion
        Sentencia += Lote + Separador       'Como lote se maneja el numero de la OP
        'Sentencia += CodInt + Separador 'Codigo Producto
        Sentencia += "FIN" + vbNewLine  'Fin de trama 
        Sentencia += "^FS" + vbNewLine



        'Parte de impresion de texto en la etiqueta
        If Condicion = "NC" Then
            Condicion = "NO CONFORME"
        Else
            Condicion = "CONFORME"
        End If

        Sentencia += "^FO50,180^ADN,15,15" + vbNewLine
        Sentencia += "^FDCODIGO: " + CLeft(CodInt, 10) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO400,180^ADN,15,15" + vbNewLine
        Sentencia += "^FDUBICACION: " + CLeft(Ubicacion, 3) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,210^ADN,15,15" + vbNewLine
        Sentencia += "^FD" + CLeft(Nombre, 25) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,240^ADN,15,15" + vbNewLine
        Sentencia += "^FDLOTE: " + CLeft(Lote, 15) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO500,240^ADN,15,15" + vbNewLine
        Sentencia += "^FDSACOS: " + Sacos + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,270^ADN,12,12" + vbNewLine
        Sentencia += "^FD" + Condicion + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO300,270^ADN,12,12" + vbNewLine
        Sentencia += "^FDPRESENT: " + Present + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO500,270^ADN,12,12" + vbNewLine
        Sentencia += "^FDBACHES: " + BachesMeta + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,310^ADN,10,10" + vbNewLine
        Sentencia += "^FD" + CLeft(Observ, 58) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^XZ" + vbNewLine  'Fin de trama para impresion
        TramaEtiquetaPT = Sentencia

    End Function

    Public Function TramaEtiquetaEMET(ByVal CodInt As String, ByVal Nombre As String, ByVal Ubicacion As String, ByVal Tipo As String) As String

        Dim Sentencia As String = ""

        Dim Separador As String = "K"

        TramaEtiquetaEMET = ""
        Sentencia = "^XA" + vbNewLine
        Sentencia += "^FO50,5^ADN,10,10" + vbNewLine  'Planta
        Sentencia += "^FD" + Planta + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO560,5^ADN,10,10" + vbNewLine 'Fecha Impresion
        Sentencia += "^FDFECHA IMP." + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO680,5^ADN,10,10^FD" + Now.ToString("yy/MM/dd") + vbNewLine
        Sentencia += "^FS" + vbNewLine


        'Parte para impresion del codigo de barras
        Sentencia += "^FO100,40^BY1.5,2" + vbNewLine
        Sentencia += "^B3N,N,100,Y,N" + vbNewLine
        Sentencia += "^FDINI" + Tipo + Separador   '  INI  indica el inicio de trama
        Sentencia += CodInt + Separador  'Codigo
        Sentencia += Ubicacion + Separador       'Ubicacion
        Sentencia += "FIN" + vbNewLine  'Fin de trama 
        Sentencia += "^FS" + vbNewLine


        Sentencia += "^FO50,180^ADN,15,15" + vbNewLine
        Sentencia += "^FDCODIGO: " + CLeft(CodInt, 10) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,210^ADN,15,15" + vbNewLine
        Sentencia += "^FD" + CLeft(Nombre, 25) + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO50,240^ADN,15,15" + vbNewLine
        Sentencia += "^FDUBICACION: " + Ubicacion + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^XZ" + vbNewLine  'Fin de trama para impresion
        TramaEtiquetaEMET = Sentencia

    End Function

    Public Function TramaEtiquetaPR(ByVal OP As String, Cont As String)
        Dim CodInt As String = ""
        Dim Sentencia As String = ""
        Dim Separador As String = "K"
        Dim Peso As String
        Dim DDatosFor As New AdoSQL("DATOSFOR")
        Dim DOPs As New AdoSQL("OPs")

        DOPs.Open("select * from OPS where OP='" + OP + "'")

        DDatosFor.Open("select * from DATOSFOR where CODFOR='" + DOPs.RecordSet("CODFOR") + "' and LP='" + DOPs.RecordSet("LP") + "' and TIPOMAT=7")

        If DDatosFor.Count = 0 Then
            MsgBox("La fórmula " + DOPs.RecordSet("CODFOR") + " versión " + DOPs.RecordSet("LP") + " no se encuentra o no contiene ingredientes tipo PR", MsgBoxStyle.Critical)
            Return Nothing
        End If

        Peso = DDatosFor.RecordSet("PESOMETA").ToString
        CodInt = DDatosFor.RecordSet("CODMAT").ToString

        Sentencia = "^XA" + vbNewLine
        Sentencia += "^FO50,7^ADN,10,10" + vbNewLine  'Planta
        Sentencia += "^FD" + Planta + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO560,7^ADN,10,10" + vbNewLine 'Fecha Impresion
        Sentencia += "^FDFECHA IMP." + vbNewLine
        Sentencia += "^FS" + vbNewLine
        Sentencia += "^FO680,7^ADN,10,10^FD" + Now.ToString("yy/MM/dd") + vbNewLine
        Sentencia += "^FS" + vbNewLine

        'Parte para impresion del codigo de barras
        Sentencia += "^FO50,40^BY1.5,2" + vbCrLf
        Sentencia += "^B3N,N,100,Y,N" + vbCrLf
        Sentencia += "^FD"
        Sentencia += OP + Separador + Cont + vbNewLine
        'Sentencia += "FIN" + vbNewLine  'Fin de trama 
        Sentencia += "^FS" + vbCrLf

        Sentencia += "^FO50,168^ADN,30,30" + vbCrLf
        Sentencia += "^FDOP:" + OP + vbCrLf
        Sentencia += "^FS" + vbCrLf
        Sentencia += "^FO400,174^ADN,15,15" + vbCrLf
        Sentencia += "^FDCODIGO:" + CodInt + vbCrLf
        Sentencia += "^FS" + vbCrLf
        Sentencia += "^FO50,208^ADN,30,30" + vbCrLf
        Sentencia += "^FDPESO:" + Peso + " Kg" + vbCrLf
        Sentencia += "^FS" + vbCrLf
        Sentencia += "^FO50,248^ADN,30,30" + vbCrLf
        Sentencia += "^FDFORM:" + DDatosFor.RecordSet("CODFORB").ToString + vbCrLf
        Sentencia += "^FS" + vbCrLf
        Sentencia += "^FO400,254^ADN,15,15" + vbCrLf
        Sentencia += "^FDNO.ORDEN:" + DOPs.RecordSet("LP").ToString + vbCrLf
        Sentencia += "^FS" + vbCrLf
        Sentencia += "^FO50,304^ADN,25,25" + vbCrLf
        Sentencia += "^FD" + vbCrLf
        Sentencia += DOPs.RecordSet("NOMFOR").ToString + vbCrLf
        Sentencia += "^FS" + vbCrLf
        Sentencia += "^FO50,344^ADN,10,10" + vbNewLine
        Sentencia += "^FD" + DOPs.RecordSet("OBSERVOP").ToString + vbNewLine
        Sentencia += "^FS" + vbNewLine


        Sentencia += "^XZ" + vbCrLf
        TramaEtiquetaPR = Sentencia
    End Function


#End Region

#Region "Metodo para el descuento de los cortes de Materia prima"
    Public Sub CortesLote(ByVal CodMat As String, ByVal Cantidad As Single, ByRef Lote As String, ByRef Corte As String, ByRef UbicLote As String)
        Try
            Dim DCortesMP As AdoSQL
            Dim DObsCortesMP As AdoSQL
            Dim EntInventario As Double = 0
            Dim SalidaInventario As Double = 0


            If CodMat = "" Or Cantidad <= 0 Then
                ' Throw New ArgumentException( _
                '       "Parametros no válidos para el metodo de cortes MP")
                Evento("Parametros no válidos para el metodo de cortes MP CodMat " + CodMat.ToString + " Cant. " + Cantidad.ToString)
                Return
            End If

            Lote = ""
            Corte = ""
            UbicLote = "BODEGA"

            DCortesMP = New AdoSQL("CORTESLOTE")
            DObsCortesMP = New AdoSQL("OBSCORTESMP")

            DCortesMP.Open("select * from CORTESLOTE where CODMAT='" + CodMat + "' and ESTADO='A'")

            If DCortesMP.Count = 0 Then Return

            'Se buscan las entradas de inventario en la tabla OBSCORTES donde tipo=3
            DObsCortesMP.Open("select SUM(CANTIDAD) as ENTINVENTARIO from OBSCORTESMP where CORTE=" + DCortesMP.RecordSet("CONT").ToString + " and TIPO=3")

            If DObsCortesMP.Count AndAlso Not IsDBNull(DObsCortesMP.RecordSet("ENTINVENTARIO")) Then
                EntInventario = DObsCortesMP.RecordSet("ENTINVENTARIO")
            End If

            'Se buscan las salidas de inventario en la tabla OBSCORTES donde tipo=4
            DObsCortesMP.Open("select SUM(CANTIDAD) as SALINVENTARIO from OBSCORTESMP where CORTE=" + DCortesMP.RecordSet("CONT").ToString + " and TIPO=4")

            If DObsCortesMP.Count AndAlso Not IsDBNull(DObsCortesMP.RecordSet("SALINVENTARIO")) Then
                SalidaInventario = DObsCortesMP.RecordSet("SALINVENTARIO")
            End If

            DCortesMP.RecordSet("CONSUMO") += Cantidad

            If (DCortesMP.RecordSet("INVINI") + EntInventario - (DCortesMP.RecordSet("CONSUMO") + SalidaInventario)) < DCortesMP.RecordSet("Alarma") Then
                Evento("Alarma de CORTE DE LOTE " + DCortesMP.RecordSet("NOMMAT").ToString)
                Alarma("Alarma de CORTE DE LOTE " + DCortesMP.RecordSet("NOMMAT").ToString)
            End If
            If Eval(DCortesMP.RecordSet("FECHAINI").ToString) = 0 Then DCortesMP.RecordSet("FECHAINI") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DCortesMP.RecordSet("FECHAFIN") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            Corte = DCortesMP.RecordSet("CONT")
            Lote = DCortesMP.RecordSet("Lote")
            If DCortesMP.RecordSet("UbicLote") <> "-" Then UbicLote = DCortesMP.RecordSet("UbicLote")
            DCortesMP.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
#End Region

#Region "Metodo para el Manejo de las Tolvas"

    Public Enum ProcesoPlanta As Integer
        DOSIFICACION = 1
        EMPAQUE = 2
        PELETIZADO = 3
    End Enum

    Public Sub DescTolvas(ByVal Tolva As String, ByVal Cantidad As Single, ByVal CodMat As String, ByVal Proceso As ProcesoPlanta, Optional ByVal OP As String = "-")
        Try
            Dim DTolvas As AdoSQL
            Dim DArt As AdoSQL
            Dim DTolvasHist As AdoSQL
            Dim DRetaque As AdoSQL
            Dim DCortesMP As AdoSQL
            If Eval(Tolva) = 0 OrElse Cantidad = 0 Then
                Return
            End If

            DTolvas = New AdoSQL("TOLVAS")
            DArt = New AdoSQL("Articulos")
            DTolvasHist = New AdoSQL("TOLVASHIST")
            DRetaque = New AdoSQL("RETAQUE")
            DCortesMP = New AdoSQL("CORTESLOTE")



            DTolvasHist.Open("select * from TolvasHist where CONT=0")
            DRetaque.Open("select * from Retaque where CONT=0")

            DTolvas.Open("select * from TOLVAS where TOLVA=" + Tolva + " and PROCESO='" + Proceso.ToString + "'")
            If DTolvas.Count = 0 Then Return

            DTolvas.RecordSet("TOTAL") += Cantidad
            DTolvas.RecordSet("OP") = OP
            If DTolvas.RecordSet("ALARMA") > 0 And DTolvas.RecordSet("TOTAL") < DTolvas.RecordSet("ALARMA") Then
                Alarma("Nivel mínimo de " + Trim(DTolvas.RecordSet("Nombre")) + " Tolva " + Tolva.ToString)
            End If
            'If DTolvas.RecordSet("TOTAL") < -10000 Then DTolvas.RecordSet("TOTAL") = 0
            If DTolvas.RecordSet("CODINT") <> CodMat Then
                '                                Evento "CAMBIO EN TOLVA " + Trim(Tolva) + " de cód:" + Trim(DTolvas.Recordset("CODMAT")) + " a cód: " + Trim(CodMatTolva)
                DTolvas.RecordSet("CODINT") = CodMat
                DArt.Open("select * from ARTICULOS where CODINT='" + CodMat.ToString + "'")
                If DArt.Count > 0 Then
                    DTolvas.RecordSet("NOMBRE") = CLeft(DArt.RecordSet("NOMBRE"), 30)
                Else
                    DTolvas.RecordSet("NOMBRE") = "-"
                End If
            End If


            DTolvasHist.AddNew()
            DTolvasHist.RecordSet("TOLVA") = DTolvas.RecordSet("TOLVA")
            DTolvasHist.RecordSet("FECHA") = Now.ToString("yyyy/MM/dd HH:mm:ss")
            DTolvasHist.RecordSet("ACTIVA") = DTolvas.RecordSet("ACTIVA")
            DTolvasHist.RecordSet("CODINT") = DTolvas.RecordSet("CODINT")
            DTolvasHist.RecordSet("NOMBRE") = DTolvas.RecordSet("NOMBRE")
            DTolvasHist.RecordSet("TOTAL") = DTolvas.RecordSet("TOTAL")
            DTolvasHist.RecordSet("OP") = DTolvas.RecordSet("OP")
            DTolvasHist.RecordSet("PROCESO") = Proceso.ToString

            DTolvasHist.Update()

            DTolvas.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

#End Region

#Region "Suma Paquete Premezclas"

    Public Function SumPaqPrem(ByVal DG As DataGridView, ByVal ManejaPx As Boolean, Optional NomDG As Boolean = False) As Double
        Try
            Dim CampoBuscar As String
            Dim PesoMeta As String

            If NomDG = False Then
                CampoBuscar = "A"
                PesoMeta = "PesoMeta"
            Else
                CampoBuscar = DG.Name + "_A"
                PesoMeta = DG.Name + "_PesoMeta"
            End If

            SumPaqPrem = 0

            If ManejaPx = False Then Return SumPaqPrem
            'Se saca el valor de la suma de los aditivos
            For Each Fila As DataGridViewRow In DG.Rows
                If Fila.Cells(CampoBuscar).Value = "AD" Or Fila.Cells(CampoBuscar).Value = "MD" Then
                    SumPaqPrem += Fila.Cells(PesoMeta).Value
                End If
            Next
            Return SumPaqPrem
        Catch ex As Exception
            MsgError(ex)
            SumPaqPrem = 0
            Return SumPaqPrem
        End Try
    End Function


#End Region

#Region "Valida baches por tanda de premezclas"

    Public Function FValidaCapacidadMezcMicros(ByVal Codfor As String, ByVal LP As String, ByVal Tandas As Int16, ByVal Porc As Int32)
        Try


            Dim DDatosFor As AdoSQL
            Dim DBasculas As AdoSQL
            Dim Capac As Double

            FValidaCapacidadMezcMicros = True
            DDatosFor = New AdoSQL("DATOSFOR")
            DBasculas = New AdoSQL("basculas")

            DBasculas.Open("Select * from BASCULAS where TIPOMAT=6")
            If DBasculas.Count > 0 Then
                Capac = DBasculas.RecordSet("CAPAC")
            Else
                FValidaCapacidadMezcMicros = False
                Exit Function
            End If

            DDatosFor.Open("Select * from DATOSFOR where TIPOMAT=6 and CODFOR='" + Codfor + "' and LP='" + LP + "'")

            For Each Recordset As DataRow In DDatosFor.Rows

                If Recordset("PESOMETA") * Porc / 100 * Tandas > Capac Then
                    FValidaCapacidadMezcMicros = False
                    Exit Function
                End If
            Next

        Catch ex As Exception
            FValidaCapacidadMezcMicros = False
            MsgError(ex)
        End Try

    End Function

    Public Function FValidaTandas(ByVal Codfor As String, ByVal LP As String, ByVal Baches As Int16, ByVal Porc As Int32)
        Dim DDatosFor As AdoSQL


        DDatosFor = New AdoSQL("DATOSFOR")


        FValidaTandas = True
        '   
        DDatosFor.Open("Select sum(PESOMETA) AS PESOMETA from DATOSFOR where TIPOMAT=6 and CODFOR='" + Codfor + "' and LP='" + LP + "'")

        For Each Recordset As DataRow In DDatosFor.Rows
            If IsDBNull(Recordset("PESOMETA")) Then Exit For
            If Recordset("PESOMETA") * Porc / 100 * Baches < Val(ReadConfigVar("MaxKgTanda")) Then
                FValidaTandas = False
                Exit Function
            End If
        Next

    End Function





    'DDatosFor.Open("Select  SUM(PESOMETA) AS TOTMICROS from DATOSFOR where TIPOMAT=6 and CODFOR='" + Codfor + "' and LP='" + LP + "'")
    'If Not DBNull.Value.Equals(DDatosFor.RecordSet("TOTMICROS")) Then
    '    If (Tandas * DDatosFor.RecordSet("TOTMICROS") * Porc / 100) < Val(ConfigParametros("MaxKgTanda")) Then
    '        FValidaTandas = False
    '        Exit Function
    '    End If
    'End If





#End Region

#Region "Claculo SackOff"

    Enum Valor
        Kilogramos = 1
        Porcentaje = 2
    End Enum


    Public Function CalcSackOff(ByVal OP As String, ByVal Modo As Valor) As Double
        Try
            'Abrimos la tabla consulta de baches para calcular el sackOff para cada OP, ya que por consulta se demora mucho

            Dim DVarios As AdoSQL
            DVarios = New AdoSQL("varios")

            Dim GrasaExt As Double = 0
            Dim PesoReproceso As Double = 0
            Dim PesoDosif As Double = 0
            Dim PesoEmp As Double = 0
            Dim DifHumedad As Double = 0
            Dim SackOffkg As Double = 0
            Dim SackOffPorc As Double = 0
            Dim SacosAdelantoOP As Integer = 0


            'Sacamos las variables necesarias para el calculo 

            'GrasaExterna

            DVarios.Open("Select * from OPS where OP='" + OP + "'")

            If DVarios.Count = 0 Then Return 0

            GrasaExt = DVarios.RecordSet("GRASAEXT")
            DifHumedad = DVarios.RecordSet("DIFHUMEDAD")

            DVarios.Open("Select SUM(PESOREAL) as PESODOSIF from BACHES where OP='" + OP + "'")

            If DVarios.Count > 0 Then
                PesoDosif = DVarios.RecordSet("PESODOSIF")
            End If

            DVarios.Open("Select sum(Peso+PesoAjuste+Residuo+PesoReproceso+(Reproceso+SacosNC)*PresKg) as PesoEmp from EMPAQUE where MAQUINA<100 and OP='" + OP + "'")

            If DVarios.Count > 0 AndAlso Not IsDBNull(DVarios.RecordSet("PESOEMP")) Then
                PesoEmp = DVarios.RecordSet("PESOEMP")
            End If


            SackOffkg = Math.Round(PesoEmp - PesoDosif - GrasaExt - DifHumedad, 2)
            SackOffPorc = Math.Round(SackOffkg * 100 / (PesoDosif + GrasaExt), 2)

            If Modo = Valor.Kilogramos Then
                Return SackOffkg
            Else
                Return SackOffPorc
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Function

#End Region

#Region "Filtros Formulación"

    'Función que crea los radiobutton necesarios para aplicar filtros en los formularios de formulación y fórmulas
    'Máximo hasta 12 filtros. El OPTodos se deja fijo en el formulario porque eses filtro siempre va.

    Public Sub FiltrosFormulacion(ByVal GB As GroupBox, ByVal OPFiltro As RadioButton, ByVal PosIniX As Int16, ByVal PosIniY As Int16, ByVal Formulario As Form)


        Dim DFormFiltros As AdoSQL
        DFormFiltros = New AdoSQL("FormFiltros")
        DFormFiltros.Open("Select * from FORMFILTROS where habilitado=1 order by POSICION")

        Dim Y As Integer = 1
        Dim X As Integer = 0
        Dim Count As Integer = 1
        Dim Multiplicador As Integer = 1

        If Formulario.Name.ToUpper = "FORMULACION" Then
            Multiplicador = 6
        Else
            Multiplicador = 4
        End If

        For Each Recordset As DataRow In DFormFiltros.Rows

            If Count > 12 Then Exit For
            Dim RB As RadioButton = New RadioButton()
            With OPFiltro
                RB.Name = "RBFiltro" + Count.ToString
                RB.Location = New Point(PosIniX + X, PosIniY * Y)
                RB.Size = .Size
            End With
            RB.Text = CLeft(Recordset("NOMFILTRO"), 12)
            'OP.BackColor = Color.SteelBlue
            RB.Parent = GB
            RB.AutoSize = True
            If Count = Multiplicador * 1 Then 'Segunda çolumna
                Y = 1
                X = 100
            ElseIf Count = Multiplicador * 2 Then ' Tercera Columna
                Y = 1
                X = 200
            ElseIf Count = Multiplicador * 3 Then ' CUARTA Columna
                Y = 1
                X = 300
            Else
                Y += 1
            End If
            Count += 1
        Next

        'Posicionamos el filtro OPTodos despues de la posicion del ultimo filtro
        If Formulario.Name.ToUpper = "FORMULACION" Then
            Formulacion.OPTodos.Location = New Point(PosIniX + X, PosIniY * Y)
        Else
            FormulacionDet.OPTodos.Location = New Point(PosIniX + X, PosIniY * Y)
        End If


    End Sub


#End Region

#Region "Filtros Recepción Empaque"

    'Función que crea los radiobutton necesarios para aplicar filtros en los formularios de recepción de empaque y recepción de empaque costos
    'Máximo hasta 15 filtros.

    Public Sub FiltrosRecEmpaque(ByVal GB As GroupBox, ByVal OPFiltro As RadioButton, ByVal PosIniX As Int16, ByVal PosIniY As Int16)


        Dim DUbicaciones As AdoSQL
        DUbicaciones = New AdoSQL("UBICACIONES")
        DUbicaciones.Open("Select * from UBICACIONES where TIPO='PT' and POSICION>0 and HABILITADA=1 order by posicion")

        Dim Y As Integer = 20
        Dim X As Integer = 150
        Dim Count As Integer = 1
        Dim Fila As Integer = 0
        Dim Columna As Integer = 0

        For Each Recordset As DataRow In DUbicaciones.Rows

            If Count > 15 Then Exit For
            Dim RB As RadioButton = New RadioButton()
            With OPFiltro
                RB.Name = "RBUbicacion" + Count.ToString
                RB.Location = New Point(PosIniX + Columna * X, PosIniY + Fila * Y)
                RB.Size = .Size
                RB.Font = .Font
            End With
            RB.Text = CLeft(Recordset("DESCRIPCION"), 20)
            'OP.BackColor = Color.SteelBlue
            RB.Parent = GB
            RB.AutoSize = True
            RB.Visible = True
            If Count Mod 5 = 0 Then
                Columna = 0
                Fila += 1
            Else
                Columna += 1
            End If
            Count += 1
        Next
    End Sub


#End Region



#Region "Despachos de PT y MP automaticos"
    Private DControlBasc As AdoSQL
    Private DFacturas As AdoSQL
    Private DArticulos As AdoSQL
    Private DMovInv As AdoSQL
    Private DVarios As AdoSQL

    Private Fecha As String
    Private CodProd, Sacos, Bodega, Tiquete, Tercero, Conductor, Peso, Factura, IDItemTiq, Placa, Tipo, NIT, PresKg, CodMaq As String

    Public Sub DespachosAuto()
        Try
            DControlBasc = New AdoSQL("TIQUETES")
            DFacturas = New AdoSQL("Facturas")
            DArticulos = New AdoSQL("Articulos")
            DMovInv = New AdoSQL("MovInv")
            DVarios = New AdoSQL("VARIOSCB")

            Fecha = Now.ToString("yyyy-MM-dd")

            DControlBasc.Open("SELECT dbo.tqte.cnsctvo, dbo.tqte.trcro, dbo.tqte.cndctor, dbo.tqte.fchaentrda, dbo.tqte.fchaslda, dbo.tqte.psoentrda, dbo.tqte.psoslda, dbo.tqte.nto, dbo.tqte_dtlle.plca," +
                 "dbo.tqte_dtlle.cntdad, dbo.tqte_dtlle.klos, dbo.tqte_dtlle.dcmnto, dbo.tqte_dtlle.cncpto, dbo.tqte_dtlle.bdga, dbo.tqte_dtlle.artclo, dbo.tqte_dtlle.td_rowid,  dbo.trcro.nit, dbo.tqte_dtlle.obsrvcnesdtlle " +
                 " FROM dbo.tqte INNER JOIN  dbo.tqte_dtlle ON dbo.tqte.cnsctvo = dbo.tqte_dtlle.cnsctvo  LEFT OUTER JOIN " +
                 " dbo.trcro ON dbo.tqte_dtlle.trcro = dbo.trcro.cdgo " +
                 " WHERE (dbo.tqte_dtlle.obsrvcnesdtlle<>'X') AND (dbo.tqte.fchaslda > convert(datetime,'" + Fecha + " 00:00',121)) AND (dbo.tqte.fchaslda < convert(datetime,'" + Fecha + " 23:59',121)) AND (dbo.tqte.fchaslda > dbo.tqte.fchaentrda) AND (dbo.tqte.nto > 0)" +
                 " AND (dbo.tqte_dtlle.cncpto='OV' or dbo.tqte_dtlle.cncpto='FG' or dbo.tqte_dtlle.cncpto='NP' or dbo.tqte_dtlle.cncpto='RM' or dbo.tqte_dtlle.cncpto='CM')")


            'MP  OV
            'PT  MP,GM,FV,SC,SG,CI, EM

            If DControlBasc.Count = 0 Then Return

            For Each RecordControlBasc As DataRow In DControlBasc.Rows


                CodProd = RecordControlBasc("artclo")
                Tiquete = RecordControlBasc("cnsctvo")
                Tercero = RecordControlBasc("trcro")
                Conductor = RecordControlBasc("cndctor")
                Peso = RecordControlBasc("klos")
                Bodega = RecordControlBasc("bdga")
                Sacos = RecordControlBasc("cntdad")
                Tipo = RecordControlBasc("cncpto")
                Factura = RecordControlBasc("dcmnto")

                Placa = RecordControlBasc("plca")
                IDItemTiq = RecordControlBasc("td_rowid")
                Fecha = Format(RecordControlBasc("fchaentrda"), "yyyy/MM/dd HH:mm:ss")
                NIT = RecordControlBasc("nit").ToString
                If NIT = "" Then NIT = "Sin NIT"

                CodMaq = "-"
                DArticulos.Open("Select * from ARTICULOS where CODINT='" + CodProd + "'")
                If DArticulos.Count = 0 Then

                    'Si no encuentra el código de producto, busca si está registrado como maquila

                    DArticulos.Open("Select * from ARTICULOS where CODMAQ='" + CodProd + "'")
                    If DArticulos.Count = 0 Then
                        Evento("No se encuentra Articulo No " + CodProd + " Tiquete No " + Tiquete)

                        GoTo DescartaFra
                    End If
                    CodMaq = CodProd
                    CodProd = DArticulos.RecordSet("CODINT")

                End If

                DFacturas.Open("Select * from FACTURAS where CODPROD='" + CodProd + "' and FACTURANRO='" + Factura + "'")

                If DFacturas.Count = 0 Then

                    DFacturas.AddNew()

                    DFacturas.RecordSet("FACTURANRO") = Factura
                    DFacturas.RecordSet("CODPROD") = CodProd
                    DFacturas.RecordSet("NOMPROD") = "NO EXISTE"
                    DFacturas.RecordSet("PRESKG") = 40

                    If DArticulos.Count > 0 Then
                        DFacturas.RecordSet("NOMPROD") = DArticulos.RecordSet("NOMBRE")
                        DFacturas.RecordSet("PRESKG") = DArticulos.RecordSet("PRESKg")
                    End If
                    DFacturas.RecordSet("SACOS") = 0
                    If Val(Sacos) < 20000 Then DFacturas.RecordSet("SACOS") = Val(Sacos)
                    DFacturas.RecordSet("PESO") = Math.Round(Eval(Peso), 1)
                    DFacturas.RecordSet("FECHA") = Fecha
                    DFacturas.RecordSet("NIT") = NIT
                    DFacturas.RecordSet("TERCERO") = CLeft(Tercero, 80)
                    DFacturas.RecordSet("DESPACHADA") = 10    'Numero que indica que ya se despachó el producto
                    DFacturas.RecordSet("FECHADESP") = Now.ToString("yyyy/MM/dd HH:mm:ss")
                    DFacturas.RecordSet("CODUBI") = Bodega
                    DFacturas.Update()
                Else
                    DFacturas.RecordSet("DESPACHADA") = 10    'Numero que indica que ya se despachó el producto
                    DFacturas.Update()
                End If

                'Se emplea el campo Lote para almacenar el valor del ID del registro de detalle de tique de control bascula
                'Se busca el Id del registro de control bascula para ver si ya esta creado

                DMovInv.Open("select * from MOVINV where LOTE='" + IDItemTiq + "'")
                If DMovInv.Count > 0 Then
                    GoTo DescartaFra
                End If


                If Tipo = "EM" Then
                    Sacos = Sacos * -1
                End If


                Tipo = "PT"


                'Si el producto es granel 
                If InStr(DArticulos.RecordSet("CODMAQ"), "MK") > 0 Then
                    Sacos = Eval(Peso) * -1
                End If

                PresKg = DArticulos.RecordSet("PresKg")

                Dim Tip As Int32 = 0

                If DArticulos.RecordSet("TIPO") = "PT" Then
                    Tip = DetOperacion.SLPT
                ElseIf DArticulos.RecordSet("TIPO") = "MP" Then
                    Tip = DetOperacion.SLMP
                    ' AjusteCorte(TOPs.Text, TCodProd.Text, Unidades * -1, "Factura No " + TNumFactura.Text + " Placa " + TPlaca.Text + " Usuario " + Usuario)
                End If

                'Objeto usado para realizar el descuento del inventario
                Dim Invent As New DescInvent

                With Invent
                    .CodInt = CodProd
                    .Cantidad = Sacos * -1
                    .TipoInv = DescInvent.TipoInvent.CHRONOS
                    .Lote = IDItemTiq
                    .Detalle = Tip
                    .Ubicacion = Bodega
                    .Unds = Sacos
                    .PromSac = PresKg
                    .FacturaNro = Factura
                    .Lote = IDItemTiq
                    .Observaciones = Tiquete + " - " + Placa
                    .Usuario = UsuarioPrincipal
                    .Maquila = CodMaq
                    'Si la función no pudo crear el registro de inventario no genera el despacho de la factura
                    If .Inventario() = False Then
                        Evento("Se descarta fra. id: " + IDItemTiq.ToString + " codprod: " + CodProd + " por inventario negativo")
                        GoTo DescartaFra
                    End If

                End With
DescartaFra:
                DVarios.Open("Update tqte_dtlle set obsrvcnesdtlle='X' where td_ROWID=" + IDItemTiq.ToString)

            Next


        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
#End Region


#Region "FechaC"
    Public Function FechaC() As String
        FechaC = Now.Year.ToString("0000") + "/" + Now.Month.ToString("00") + "/" + Now.Day.ToString("00") + " " +
           Now.Hour.ToString("00") + ":" + Now.Minute.ToString("00") + ":" + Now.Second.ToString("00")
    End Function
#End Region
#Region "CheckRulePassword"
    Public Clave As String
    Public ParamClave(7) As String
    Public vigPass As Integer = 30
    Public numIntentos As Integer = 3

    Private _minLength As Integer = 8
    Private _numUpper As Integer = 1
    Private _numLower As Integer = 1
    Private _numNumbers As Integer = 1
    Private _numSpecial As Integer = 1
    Public Function GetIP() As String
        GetIP = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)
        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIP = ipheal.ToString()
            End If
        Next
    End Function
    Public Function ValidaSeguridad(ByVal pwd As String) As Boolean

        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' caracteres especiales es ninguno de los casos anteriores
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        If Split(ReadConfigVar("PARAMETROSCLAVE"), ",").Length = 8 Then
            ParamClave = Split(ReadConfigVar("PARAMETROSCLAVE"), ",")
            vigPass = ParamClave(0)
            _minLength = ParamClave(1)
            numIntentos = ParamClave(2)
            _numUpper = ParamClave(3)
            _numLower = ParamClave(4)
            _numNumbers = ParamClave(5)
            _numSpecial = ParamClave(6)
        End If

        ' Check longitud
        If Len(pwd) < _minLength Then Return False
        ' Check minimo numero de ocurrencias
        If upper.Matches(pwd).Count < _numUpper Then Return False
        If lower.Matches(pwd).Count < _numLower Then Return False
        If number.Matches(pwd).Count < _numNumbers Then Return False
        If special.Matches(pwd).Count < _numSpecial Then Return False
        'si cumple todas las condiciones
        Return True
    End Function

#End Region

#Region "Log de eventos de login"
    Public Sub UsuariosLog(ByVal Evento As String, ByVal Tipo As String, ByVal Datos As String)

        Try


            Dim DUsuariosLog As AdoSQL
            DUsuariosLog = New AdoSQL("USUARIOSLOG")

            DUsuariosLog.Open("select * from USUARIOSLOG where ID=0")       'Abre la tabla vacia
            DUsuariosLog.AddNew()
            DUsuariosLog.RecordSet("USUARIO") = UsuarioPrincipal
            DUsuariosLog.RecordSet("PC") = NombrePC
            DUsuariosLog.RecordSet("FECHA") = FechaC()
            DUsuariosLog.RecordSet("DIRIP") = DireccionIP
            DUsuariosLog.RecordSet("EVENTO") = Mid(Evento, 1, 100)
            DUsuariosLog.RecordSet("TIPO") = Tipo
            DUsuariosLog.RecordSet("DATOS") = Datos
            DUsuariosLog.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
#End Region

#Region "Verifica claves anteriores"
    Public Function VerifClaveHist(ByVal Usuario As String, ByVal ClaveEncrip As String) As Boolean
        'Se verifica que la nueva clave no sea igual a las ultimas 10 usadas
        Try
            Dim DUsuariosHist As AdoSQL
            DUsuariosHist = New AdoSQL("USUARIOSHIS")

            DUsuariosHist.Open("select TOP " + ParamClave(7).ToString + " * from USUARIOSHIST where USUARIO='" + Usuario.Trim + "' and APLICACION='CHR'")
            For Each RUsu As DataRow In DUsuariosHist.Rows
                If RUsu("CLAVE") = ClaveEncrip Then
                    Return False
                    Exit For
                End If
            Next

            DUsuariosHist.AddNew()
            DUsuariosHist.RecordSet("USUARIO") = Usuario
            DUsuariosHist.RecordSet("CLAVE") = ClaveEncrip
            DUsuariosHist.RecordSet("FECHA") = Mid(FechaC, 1, 10)
            DUsuariosHist.RecordSet("APLICACION") = "CHR"
            DUsuariosHist.Update()

            Return True

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Function
#End Region

#Region "Funcionalidades y Parametros ChronoSoft"


    Public Function ValidaFuncionalidad(ByVal NombreFuncion As String, Optional Sesion_NombrePC As String = "", Optional Formulario As Form = Nothing) As Boolean
        Try
            'Funcion encargada de revisar en la tabla configfuncionalidades si hay una funcionalidad activa o no
            ValidaFuncionalidad = False
            If NombreFuncion = "" Then Return ValidaFuncionalidad

            Dim Sentencia As String = "Select * from CONFIGFUNCIONALIDADES where ACTIVA=1 and FUNCION='" + NombreFuncion + "' "

            If Sesion_NombrePC <> "" Then
                Sentencia = Sentencia + " and SESIONONOMBREPC='" + Sesion_NombrePC + "'"
            End If

            If Not Formulario Is Nothing Then
                Sentencia = Sentencia + " and FORMULARIO='" + Formulario.Name + "'"
            End If

            Dim DConfigFuncionalidades As AdoSQL = New AdoSQL("CONFIGFUNCIONALIDADES")
            DConfigFuncionalidades.Open(Sentencia)

            If DConfigFuncionalidades.Count = 0 Then Return ValidaFuncionalidad

            ValidaFuncionalidad = True

            Return ValidaFuncionalidad

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Function

    Public Function ConfigParametros(ByVal NombreParametro As String) As String
        Try
            'Funcion encargada de revisar en la tabla configfuncionalidades si hay una funcionalidad activa o no
            ConfigParametros = ""
            If NombreParametro = "" Then Return ConfigParametros

            Dim Sentencia As String = "Select * from CONFIGPARAMETROS where PARAMETRO='" + NombreParametro + "'"

            Dim DConfigParametros As AdoSQL = New AdoSQL("CONFIGPARAMETROS")
            DConfigParametros.Open(Sentencia)

            If DConfigParametros.Count = 0 Then Return ConfigParametros

            ConfigParametros = DConfigParametros.RecordSet("VALOR")

            Return ConfigParametros

        Catch ex As Exception
            MsgError(ex)
            ConfigParametros = ""
            Return ConfigParametros
        End Try
    End Function


    Public Sub WriteConfigParametros(ByVal NombreParametro As String, ByVal Valor As String)
        Try
            Dim Sentencia As String = "update CONFIGPARAMETROS set VALOR ='" + Valor + "' where PARAMETRO ='" + NombreParametro + "'"
            Dim DConfigParametros As AdoSQL = New AdoSQL("CONFIGPARAMETROS")

            DConfigParametros.Open(Sentencia)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Public Sub AbreProgramaSatelite(ByVal NombrePrograma As String)
        Try
            If NombrePrograma = "" Then Return


            Dim DProgSatelite As AdoSQL
            DProgSatelite = New AdoSQL("PROGRAMASSATELITE")
            DProgSatelite.Open("Select * from PROGRAMASSATELITE where PROGRAMA='" + NombrePrograma + "'")

            If DProgSatelite.Count Then
                If DProgSatelite.RecordSet("SESIONONOMBREPC").ToString.ToUpper = NombrePC OrElse DProgSatelite.RecordSet("SESIONONOMBREPC").ToString.ToUpper = Sesion Then
                    Resp = Shell(Ruta + NombrePrograma + " " + UsuarioPrincipal, AppWinStyle.MinimizedNoFocus)
                End If
            End If

        Catch ex As System.IO.FileNotFoundException
            MsgBox("Archivo " + NombrePrograma + " no hencontrado, favor contactar a soporte", vbCritical)
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
    Public Function LimpiarCadena(ByVal cadena As String)
        Try
            Return Regex.Replace(cadena, "[^\w\. ]", "-",
                                RegexOptions.None, TimeSpan.FromSeconds(1.5))
        Catch ex As RegexMatchTimeoutException
            Return String.Empty
        End Try
    End Function
#End Region


#Region "verificar Permisos de usuario"
    'Diccionario (llave, valor) para ver los permisos activos del usuario logueado
    'llave := Permiso
    'valor := Estado del permiso. El diccionario se llena en tiempo de ejecución en el formulario "Acceso"
    Public DicPermisoUsuario As New Dictionary(Of String, Boolean)
    ''' <summary>
    ''' Validar si un permiso está activo
    ''' </summary>
    ''' <param name="NombreParametro">Puede ingresar un string o una cadena separada por comas</param>
    ''' <returns></returns>
    Public Function ValidaPermiso(ByVal NombreParametro As String) As Boolean

        Dim EstadoPermiso As Boolean = False
        Dim strPermisos As String()
        NombreParametro = NombreParametro.ToUpper

        If UsuarioPrincipal = "TECNIMATICA" And NombreParametro <> "ACTIVO" Then
            EstadoPermiso = True
            Return EstadoPermiso
        End If

        If NombreParametro.Contains(",") Then
            strPermisos = NombreParametro.Split(",")
        Else
            strPermisos = New String() {NombreParametro}
        End If

        For Each Permiso As String In strPermisos
            Permiso = Permiso.Trim
            If DicPermisoUsuario.ContainsKey(Permiso) Then
                EstadoPermiso = DicPermisoUsuario.Item(Permiso)
                If EstadoPermiso = True Then Return EstadoPermiso
            End If
        Next

        'En caso de que no haya ningun permiso activado
        Return EstadoPermiso

    End Function

#End Region

    Public Sub ActualizaEstadoBache(ByVal Contador As Int64)
        Try

            If Contador = 0 Then Return
            'Actualiza el esta
            Dim DCons As AdoSQL = New AdoSQL("CONSUMOS")
            Dim DBaches As AdoSQL = New AdoSQL("BACHES")

            DCons.Open("Select SUM(PESOMETA) as PESOMETA, SUM(PESOREAL) as PESOREAL from CONSUMOS where CONT=" + Contador.ToString)

            If DCons.Count AndAlso Not IsDBNull(DCons.RecordSet("PESOMETA")) Then

                DBaches.Open("Select * FROM BACHES where CONT=" + Contador.ToString)

                If DBaches.Count Then
                    DBaches.RecordSet("PESOREAL") = DCons.RecordSet("PESOREAL")
                End If

                'Si la suma del peso meta de los consumos es igual al peso meta del bache se cambia el estado del bache a 10
                If Math.Abs(DBaches.RecordSet("PESOMETA") - DCons.RecordSet("PESOMETA")) < DBaches.RecordSet("PESOMETA") * 0.00005 Then
                    DBaches.RecordSet("ESTADO") = 10
                End If
                DBaches.Update()
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Sub InicializaFuncionalidades()
        Try
            'Trae las configuraciones de funcionalidades
            'Usadas en Formulacion
            Funcion_BasedeDatosPremExterna = ValidaFuncionalidad("Conexion.BD.Premezclas.Ext")
            Funcion_ManejaTablaProcDosif = ValidaFuncionalidad("Tabla.ProcesoDosif")
            'Usada en importfor
            Funcion_ManejaEstablecimiento = ValidaFuncionalidad("Maneja.Establecimiento")
            Funcion_ManejaCodforBIgualaCodProd = ValidaFuncionalidad("Maneja.CodForB=CodProd")
            Funcion_ManejaFylax = ValidaFuncionalidad("Maneja.Fylax")
            Funcion_ManejaFysal = ValidaFuncionalidad("Maneja.Fysal")
            Funcion_ArchivoTraePaquetePrem = ValidaFuncionalidad("Archivo.Trae.PaquetePrem")
            Funcion_PreguntaPorCodForB = ValidaFuncionalidad("Pregunta.Por.CodForB")
            Funcion_AprobarFormulaImportada = ValidaFuncionalidad("Aprobar.Formula.Importada")
            Funcion_HumedadFormulada = ValidaFuncionalidad("Trae.Humedad.Formulada")
            'Usadas en formulas
            Funcion_MaterialesXBandeja = ValidaFuncionalidad("Materiales.Bandeja")
            Funcion_ManejaOpticurp = ValidaFuncionalidad("Maneja.Opticurb")
            Funcion_ManejaVehiculo = ValidaFuncionalidad("Maneja.Vehiculo")
            Funcion_ManejaToleranciasPorcentaje = ValidaFuncionalidad("Maneja.Tolerancias.Porcentaje")
            'Usadas en productos
            Funcion_VencimientoPorProducto = ValidaFuncionalidad("Venc.Por.Producto")
            Funcion_ObligaLineaInvent = ValidaFuncionalidad("Obliga.LineaInvent")
            'Usadas en RecibePT
            Funcion_RecibirEmpaqueAlmacen = ValidaFuncionalidad("Recibir.Empaque.Almacen")
            Funcion_RecibirEmpaqueCalidad = ValidaFuncionalidad("Recibir.Empaque.Calidad")
            Funcion_RecibirEmpaqueProduccion = ValidaFuncionalidad("Recibir.Empaque.Produccion")
            'Empaqueman
            Funcion_FinalizarPlanillaSales = ValidaFuncionalidad("Finalizar.Planilla.Sales")
            Funcion_ManejaPaqueteo = ValidaFuncionalidad("Manejar.Paqueteo")
            'NuevaOP
            Funcion_PlantasExternas = ValidaFuncionalidad("Plantas.Externas")
            Funcion_ManejaFunPremezcla = ValidaFuncionalidad("Fun.Premezcla")
            Funcion_DestinosPeletizado = ValidaFuncionalidad("Destinos.Peletizado")
            Funcion_MaterialesBandeja = ValidaFuncionalidad("Materiales.Bandeja")
            Funcion_AdelantarEmpaquesyEtiquetas = ValidaFuncionalidad("Adelantar.EmpaquesyEtiquetas")
            Funcion_FuncionesPlantaPremezclas = ValidaFuncionalidad("Funciones.Planta.Premezclas")
            Funcion_ManejaSecuenciaMezcla = ValidaFuncionalidad("Maneja.Secuencia.Mezcla")
            Funcion_ManejaDestinoPLC = ValidaFuncionalidad("Maneja.Destino.PLC")
            Funcion_ManejaDosEstacionesPM = ValidaFuncionalidad("Maneja.Dos.Estaciones.PM")

            'Fondo
            Funcion_BachesOpsVentas = ValidaFuncionalidad("Baches.OPs.Ventas")
            Funcion_DatosEngrasadores = ValidaFuncionalidad("SigCoPro.DatosEngrasadores")

            'Vaceo
            Funcion_ManejaPantallaVaceo = ValidaFuncionalidad("Maneja.Pantalla.Vaceo")
            Funcion_ConexionSigCoPro = ValidaFuncionalidad("Conexion.SigCoPro")

            'General
            Funcion_ManejaRestriccionLineasNegocio = ValidaFuncionalidad("Maneja.Restriccion.LineasNegocio")

            'NuevaOP-Traslado de micros
            Funcion_ManejaTrasladoMicros = ValidaFuncionalidad("Maneja.Traslado.Micros")

            'CortesContBascula
            Funcion_AlimentaTolvasDesdeCB = ValidaFuncionalidad("Alimenta.Inventario.Tolvas.DesdeCB")
            Funcion_CentralBasculaServicioWEB = ValidaFuncionalidad("CentralBascula.ServicioWEB")

            'MateriasPrimas
            Funcion_GeneraAlarmaCorteSinAbrir = ValidaFuncionalidad("Alarma.CorteMP.SinAbrir")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


End Module

