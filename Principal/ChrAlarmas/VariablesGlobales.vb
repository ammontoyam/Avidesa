Option Explicit On
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common  ' Espacio que permite la conexion bilateral Acces o Sql
Imports System.IO
Module VariablesGlobales

#Region "Declaracion de Variables En el módulo"

    Public RutaDB As String
    Public Ruta As String
    Public Sentencia As String
    Public TipoServer As String
     Public CONN As DbConnection
   Public DbProvedor As DbProviderFactory
    Public Resp As Long
    Public ServidorSQL As String
    Public PWD As String
    Public UserDB As String
    Public NomDB As String
    Public RutaRep As String
    Public Planta As String
    Public DRUsuario As DataRow
    Public RespInput As String
    Public NombrePC As String
    Public Usuario As String
    Public Fuentes As Boolean
    Public ServComM As Boolean
    Public ServComMVisual As Boolean
    Public ServComMBP As Boolean
    Private List As New List(Of TextBox)
    Private ListBool As New List(Of Boolean)

#End Region

#Region "Funcion que reemplaza al VAL, no interesa la configuracion decimal 'EVAL'"
    Public Function Eval(ByVal Valor As String) As Double
        Dim Aux As String = ""
        Aux = Replace(Valor, ",", ".")
        Eval = Format(Val(Aux), ".000")
    End Function
#End Region

#Region "Evento"
    Public Sub Evento(ByVal Frase As String)
        Dim Archivo As StreamWriter
        Archivo = New StreamWriter(Ruta + "Aplanos\Eventos_" + Format(Now, "yyMMdd") + ".txt", True)
        Archivo.WriteLine(Frase + Space(20) + Space(20) + Usuario + Space(20) + NombrePC + Space(20) + Space(20) + Format(Now, "HH:mm:ss"))
        Archivo.Close()

    End Sub
#End Region

#Region "Leer escribir ConfigVAr"
    Public Function ReadConfigVar(ByVal Campo As String) As String

        Dim DConfigVar As AdoNet

        DConfigVar = New AdoNet("CONFIGVAR", CONN, DbProvedor)
        DConfigVar.Open("select * from CONFIGVAR where CAMPO='" + Campo + "'")

        ReadConfigVar = ""
        If DConfigVar.RecordCount > 0 Then ReadConfigVar = DConfigVar.RecordSet("VALOR").ToString
    End Function
    Public Sub WriteConfigVar(ByVal Campo As String, ByVal Valor As String)

        Dim DConfigVar As AdoNet

        DConfigVar = New AdoNet("CONFIGVAR", CONN, DbProvedor)
        DConfigVar.Open("select * from CONFIGVAR where CAMPO='" + Campo + "'")

        If DConfigVar.RecordCount = 0 Then
            MsgError("Campo no encontrado en la tabla configvar")
            Return
        End If
        DConfigVar.RecordSet("VALOR") = Valor
        DConfigVar.Update()

    End Sub
#End Region

#Region "Asignar Datos de DataTable a DataGridView"
    Public Sub AsignaDataGrid(ByVal DG As DataGridView, ByVal DT As DataTable, Optional ByVal NomDGCol As Boolean = False)
        DG.Rows.Clear()

        For y As Integer = 0 To DT.Rows.Count - 1
            DG.Rows.Add()
            For i As Integer = 0 To DG.Columns.Count - 1
                If NomDGCol = True Then
                    Dim Pos As Integer = InStr(1, DG.Columns(i).Name, "_")
                    Dim Campo As String = CRight(DG.Columns(i).Name, Pos + 1)
                    DG.Rows(y).Cells(DG.Columns(i).Name).Value = DT.Rows(y).Item(Campo).ToString
                Else
                    DG.Rows(y).Cells(DG.Columns(i).Name).Value = DT.Rows(y).Item(DG.Columns(i).Name).ToString
                End If
            Next
        Next
    End Sub
#End Region

#Region "Funcion LEFT"
    Public Function CLeft(ByVal Texto As String, ByVal N As Long) As String
        Dim Dato As String
        Dato = (Texto + New String(" ", N)).Substring(0, N).Trim
        CLeft = Dato
    End Function
#End Region

#Region "Funcion RIGHT"
    Public Function CRight(ByVal Texto As String, ByVal N As Long) As String
        Dim Dato As String
        If Len(Texto) <= 0 OrElse Len(Texto) < N Then
            CRight = ""
            Exit Function
        End If
        Dato = Texto.Substring(N - 1, Len(Texto) - N + 1).Trim
        CRight = Dato
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
            Pos = InStr(1, Dato, "@")
            If Pos = 0 Then
                MsgBox("Debe mandar el caracter @ para distinguir los campos del texto a mostrar ", MsgBoxStyle.Exclamation)
                AsignaItemsCB = Campos
                Exit Function
            End If
            Campos(i) = CLeft(Dato, Pos - 1)
            Texto(i) = CRight(Dato, Pos + 1)
            i += 1
        Next


        For i = 0 To Dimension

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
            MsgError(ex.ToString)
        End Try

    End Sub
    Public Sub BusquedaDG(ByVal DG As DataGridView, ByVal Campo As String, ByVal Valor As String, Optional ByRef Econtrado As Boolean = False, Optional ByVal QuitarFiltro As Boolean = False)
        'Sobre cargamos el metodo de tal forma que permita filtar un datagrid sin que tengamos la tabla

        Try
            For Each Filasel As DataGridViewRow In DG.Rows
                Filasel.Visible = True
            Next
            If QuitarFiltro = True Then Exit Sub

            For Each Filasel As DataGridViewRow In DG.Rows
                If Filasel.Cells(Campo).Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                    Continue For
                End If
                If Filasel.Cells(Campo).Value.ToString <> Valor Then
                    Filasel.Visible = False
                Else
                    Econtrado = True
                End If
            Next

        Catch ex As Exception
            MsgError(ex.ToString)
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

            If (IsNumeric(e.KeyChar)) Or _
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
        SumColumn = 0
        For Each Filasel As DataGridViewRow In DG.Rows
            If Filasel.Cells(Campo).Value Is Nothing _
                OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                Continue For
            End If
            SumColumn += Eval(Filasel.Cells(Campo).Value)
        Next
    End Function
#End Region

#Region "Mensaje de Error"
    Public Sub MsgError(ByVal Msg As String)
        MessageBox.Show(Msg, My.Application.Info.AssemblyName.ToString, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Evento(Msg)
    End Sub
#End Region

#Region "Escritura Archivo"
    Public Sub WriteFile(ByVal Ruta As String, ByVal Msg As String, Optional ByVal SobreEscb As Boolean = True)
        If String.IsNullOrEmpty(Ruta) OrElse String.IsNullOrEmpty(Msg) Then
            Throw New ArgumentException( _
                        "Datos erroneos para la escritura del archivo")
        End If

        If Directory.Exists(Path.GetDirectoryName(Ruta)) = False Then
            MsgError("La ruta No es Válida para la generacion del archivo")
            Return
        End If

        Dim Wrt As StreamWriter
        Wrt = New StreamWriter(Ruta, SobreEscb)
        Wrt.WriteLine(Msg)
        Wrt.Close()
        Wrt.Dispose()
    End Sub
#End Region

End Module

