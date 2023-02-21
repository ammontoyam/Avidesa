Option Explicit On
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common  ' Espacio que permite la conexion bilateral Acces o Sql
Imports System.IO
Imports System.Text

Module VariablesGlobales

#Region "Declaracion de Variables En el módulo"

    Public RutaDB As String
    Public Ruta As String
    Public Sentencia As String
    Public TipoServer As String
    Public TipoServerNept As String
    Public RutaDBNept As String
    Public CONN As DbConnection
    Public CONNNept As DbConnection
    Public DbProvedor As DbProviderFactory
    Public DbProvedorNept As DbProviderFactory
    Public Resp As Long
    Public ServidorSQL As String
    Public PWD As String
    Public PWDNept As String
    Public UserDBNept As String
    Public UserDB As String
    Public NomDB As String
    Public NomDBNept As String
    Public RutaRep As String
    Public Planta As String
    Public DRUsuario As DataRow
    Public RespInput As String
    Public NombrePC As String
    Public Sesion As String
    Public Usuario As String
    Public Fuentes As Boolean
    Public ServComM As Boolean
    Public ServComMVisual As Boolean
    Public ServComMBP As Boolean
    Private List As New List(Of TextBox)
    Private ListBool As New List(Of Boolean)
    Public ReportesSap As Boolean = True
    Public RutaNeptuno As String
    Public TolvaMatrizDif As Int32
    Public LoteCortesMP As String
    Public ContCortesMP As String
    Public UsuarioDosificacion As String
    Public PrecioKgLote As Single

 
    Public InclusionMin(10) As Single
    Public LimTara(10) As Single
    Public BitsPLCDos(150) As Int16
    Public BitsPLCRec(150) As Int16
    Public Estado(10) As String
    Public EstadoNum(10) As String
    Public Estable(10) As String
    Public EstadoGen(10) As String
    Public Neto(10) As Single
    Public Bruto(10) As Single
    Public DatosOKB1 As Boolean
    Public DatosOKB2 As Boolean
    Public NetoRep(10) As Single
    Public BascVacia(10) As Boolean

    Public EstableAnt(10) As Int16
    Public NetoAntA(10) As Single
    Public NetoAntB(10) As Single
    Public NetoAntC(10) As Single
    Public CompensacionB(10) As Single
    Public PesoParcial(10) As Boolean


    Public CicloSostenido As Boolean
  
    Public NuevaTolva As String
    Public NuevaBascula As String
    Public CambioTolvaBasc As Int16

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
        Try
            Dim Archivo As FileStream
            Frase = UCase(Frase)
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase + vbTab + Usuario.PadRight(20, Chr(32)) + vbTab + NombrePC.PadRight(20, Chr(32)) + vbTab + Format(Now, "HH:mm:ss") + vbNewLine)
            'Frase + Space(20) + Space(20) + Usuario + Space(20) + NombrePC + Space(20) + Space(20) + Format(Now, "HH:mm:ss")
            Archivo = New FileStream(Ruta + "Aplanos\Eventos_" + Format(Now, "yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
#Region "EvError"
    Public Sub EvError(ByVal Frase As String)
        Try
            Dim Archivo As FileStream
            Frase = UCase(Frase)
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase + vbTab + Usuario.PadRight(20, Chr(32)) + vbTab + NombrePC.PadRight(20, Chr(32)) + vbTab + Format(Now, "HH:mm:ss") + vbNewLine)
            'Frase + Space(20) + Space(20) + Usuario + Space(20) + NombrePC + Space(20) + Space(20) + Format(Now, "HH:mm:ss")
            Archivo = New FileStream(Ruta + "Aplanos\EvErr_" + Format(Now, "yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

    Public Sub APlanoPLC(ByVal PLCNo As String, ByVal Frase As String)
        Try
            Dim Archivo As FileStream
            Dim Frase2 As String = ""
            Frase2 = vbNewLine + Now.ToString("HH:mm:ss") + vbTab + Frase
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase2)
            Archivo = New FileStream(Ruta + "Aplanos\PLC_" + PLCNo.ToString + "_" + Now.ToString("yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub APlanoBasc(ByVal Basc As Integer)
        'Genera un archivo cada hor para eveluar el comportamiento de las básculas, cada 10 seg aprox

        'Try
        '    Dim Archivo As StreamWriter
        '    Dim IOs As String
        '    IOs = ""
        '    Archivo = New StreamWriter(Ruta + "Aplanos\Basculas\B" + Basc.ToString + "_" + Format(Now, "yyMMdd") + ".txt", True)
        '    Archivo.Write(Format(Now, "HH:mm:ss") + vbTab)
        '    Archivo.Write("B: " + Bruto(Basc).ToString + vbTab + " N: " + Neto(Basc).ToString + vbCrLf)
        '    Archivo.Close()
        'Catch ex As Exception
        '    Debug.Print(ex.ToString)
        '    EvError(ex.ToString)

        'End Try

    End Sub
    Public Sub APlanoBascProc(ByVal Basc As Integer)
        Try
            Dim Archivo As StreamWriter
            Dim Msg As String = ""


            'Genera un archivo resumido para evaluar el comportamiento de las básculas, más despacio que el anterior
            Archivo = New StreamWriter(Ruta + "Aplanos\Basculas\Basc_Proc_" + Basc.ToString + "_" + Format(Now, "yyMMdd") + ".txt", True)
            Archivo.Write(Format(Now, "HH:mm:ss") + "  ")
            Msg = Mid(Estado(Basc) + "                   ", 1, 15) + vbTab
            Msg += "OP " + PDosifica.TOPB(1).Text + vbTab
            Msg += "Bch " + PDosifica.TBacheNo(1).Text + vbTab
            Msg += "Cod " + PDosifica.TCodMat(Basc).Text + vbTab
            Msg += "PB " + PDosifica.TBruto(Basc).Text + vbTab
            Msg += "PN " + PDosifica.TNeto(Basc).Text + vbTab
            Msg += "Rep " + NetoRep(Basc).ToString
            Msg += vbCrLf
            Archivo.Write(Msg)

            Archivo.Close()

        Catch ex As Exception
            Debug.Print(ex.ToString)
            EvError(ex.ToString)

        End Try

    End Sub

#Region "Genera el archivo plano del escaner de Micros sobre la mezcladora"
    Public Sub APlanoEscan(ByVal Frase As String)
        Try
            Dim Archivo As FileStream
            Dim Frase2 As String = ""
            Frase2 = UCase(vbNewLine + Format(Now, "HH:mm:ss") + "  " + Frase)
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase2)
            Archivo = New FileStream(Ruta + "Aplanos\Escan_" + Format(Now, "yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Saldo de Lote"
    Public Function SaldoLote(ByVal CodMat As String, ByVal Lote As String) As Single
        Dim DLotes As AdoNet
        DLotes = New AdoNet("-", CONN, DbProvedor)

        DLotes.Open("Select SUM(ENTRA)-SUM(SALE) as TOTAL from ARTICULOSINVMOV where CODINT='" + CodMat + "' and LOTE='" + Lote + "' and CERRADO=0")
        If Not IsDBNull(DLotes.RecordSet("TOTAL")) Then
            Return Math.Round(DLotes.RecordSet("TOTAL"), 3)
        Else
            Return 0
        End If
    End Function
#End Region

#Region "MovInv"
    Public Function MovInv(ByVal CodMat As String, ByVal Lote As String, OP As String, Entra As Single, Sale As Single) As Single

        Dim DArtInvMov As AdoNet
        Dim DArt As AdoNet
        Dim DCortes As AdoNet
        Dim SaldoAct As Single

        DArtInvMov = New AdoNet("-", CONN, DbProvedor)
        DArt = New AdoNet("-", CONN, DbProvedor)
        DCortes = New AdoNet("-", CONN, DbProvedor)

        DArtInvMov.Open("select * from  ARTICULOSINVMOV where ID=0")
        DArtInvMov.AddNew()
        DArtInvMov.RecordSet("FECHA") = FechaC()
        DArtInvMov.RecordSet("LOTE") = Lote
        DArtInvMov.RecordSet("CODINT") = CodMat
        DArtInvMov.RecordSet("SALE") = Sale
        DArtInvMov.RecordSet("ENTRA") = Entra
        DArtInvMov.RecordSet("OP") = Val(OP)
        DArtInvMov.RecordSet("CERRADO") = 0  'Por ahora
        DArtInvMov.RecordSet("NOMMAT") = "-" 'Por ahora

        DArt.Open("select NOMBRE from ARTICULOS where CODINT='" + CodMat + "'")
        If DArt.RecordCount Then
            DArtInvMov.RecordSet("NOMMAT") = Mid(DArt.RecordSet("NOMBRE"), 1, 5)
        End If

        SaldoAct = SaldoLote(CodMat, Lote)
        DArtInvMov.RecordSet("SALDO") = SaldoAct + Entra - Sale


        DCortes.Open("select * from CORTESLOTE where CODMAT='" + CodMat + "' and LOTE='" + Lote + "'")
        If DCortes.RecordCount Then
            DCortes.RecordSet("INVFIN") = DArtInvMov.RecordSet("SALDO")
            DCortes.Update("Cortes MovINv")
        End If

        DArtInvMov.Update("ArtInvMov MovInv")
    End Function
#End Region

#Region "Funcion Int16toFloat"
    'Esta función convierte un INt16 A Float. No confundir con el Float IEEE
    Public Function Int16toFloat(ByVal ByteH As Byte, ByVal ByteL As Byte) As Int32
        Int16toFloat = ByteH * 256 + ByteL
        'Si el MSB es 1 es porque es negativo
        If Int16toFloat > 32768 Then
            Int16toFloat = Int16toFloat - 65536
        End If
    End Function
#End Region

#Region "Tirilla"
    'Gsenera el archivo de impresion e reportes o tirilla
    Public Sub ImpTirilla(ByVal Frase As String)
        Try
            Dim Archivo As FileStream
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase)
            Archivo = New FileStream(Ruta + "Aplanos\Tirilla_" + Format(Now, "yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region

#Region "FechaC"
    Public Function FechaC() As String
        FechaC = Format(Now, "yyyy/MM/dd HH:mm:ss")
    End Function
#End Region
#Region "Leer escribir ConfigVAr"
    Public Function ReadConfigVar(ByVal Campo As String) As String

        Dim DConfigVar As AdoNet

        DConfigVar = New AdoNet("CONFIGVAR", CONN, DbProvedor)
        DConfigVar.Open("select * from CONFIGVAR where CAMPO='" + Campo + "'")

        ReadConfigVar = ""
        If DConfigVar.RecordCount > 0 Then
            ReadConfigVar = DConfigVar.RecordSet("VALOR").ToString.ToUpper
        Else
            MsgBox("Falta el en CONFIGVAR: " + Campo, vbInformation)
        End If
    End Function
    Public Sub WriteConfigVar(ByVal Campo As String, ByVal Valor As String)

        Dim DConfigVar As AdoNet

        DConfigVar = New AdoNet("CONFIGVAR", CONN, DbProvedor)
        DConfigVar.Open("select * from CONFIGVAR where CAMPO='" + Campo + "'")

        If DConfigVar.RecordCount = 0 Then
            MsgError("Campo no encontrado en la tabla configvar " + Campo + ".")
            Return
        End If
        DConfigVar.RecordSet("VALOR") = Valor
        DConfigVar.Update("ConfigVar WriteConfigVar")

    End Sub
#End Region

#Region "Asignar Datos de DataTable a DataGridView"
    Public Sub AsignaDataGrid(ByVal DG As DataGridView, ByVal DT As DataTable, Optional ByVal NomDGCol As Boolean = False)

        If DG Is Nothing Then _
            Throw New ArgumentException("Asignación no valida para el datagridview")

        DG.Rows.Clear()

        If DT Is Nothing Then Return

        For y As Integer = 0 To DT.Rows.Count - 1
            DG.Rows.Add()
            For i As Integer = 0 To DG.Columns.Count - 1
                If NomDGCol = True Then
                    Dim Pos As Integer = DG.Columns(i).Name.IndexOf("_")
                    Dim Campo As String = DG.Columns(i).Name.Substring(Pos + 1)
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
        CLeft = Microsoft.VisualBasic.Left(Texto, N)
    End Function
#End Region

#Region "Funcion RIGHT"
    Public Function CRight(ByVal Texto As String, ByVal N As Long) As String
        CRight = Microsoft.VisualBasic.Right(Texto, N)
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
        Try
            SumColumn = 0
            For Each Filasel As DataGridViewRow In DG.Rows
                If Filasel.Cells(Campo).Value Is Nothing _
                    OrElse Filasel.Cells Is Nothing OrElse Filasel.Visible = False Then
                    Continue For
                End If
                SumColumn += Eval(Filasel.Cells(Campo).Value)
            Next
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Function
#End Region

#Region "Mensaje de Error"
    Public Sub MsgError(ByVal Msg As String)
        MsgEvError.TError.Text = Right(FechaC, 8) + " " + Msg
        MsgEvError.Show()
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
            MsgError("La ruta No es Válida para la generación del archivo")
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
    Public Sub Alarma(ByVal Mensaje As String, Optional ByVal State As AppWinStyle = AppWinStyle.MinimizedNoFocus)
        Try
            Dim DAlArmas As AdoNet

            DAlArmas = New AdoNet("Alarmas", CONN, DbProvedor)
            DAlArmas.Open("Select * from ALARMAS WHERE ID=0")
            If String.IsNullOrEmpty(Mensaje) Then Return

            DAlArmas.AddNew()
            DAlArmas.RecordSet("ALARMA") = CLeft(Mensaje, 100)
            DAlArmas.RecordSet("FECHA") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DAlArmas.Update("Alarmas Alarma")

            Evento(Mensaje)

            If File.Exists(Ruta + "Alarmas.exe") = False Then Return

            Resp = Shell(Ruta + "Alarmas.exe", State)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Totaliza o finaliza baches"

    Public Sub TotFinBache(ByVal Recordset As DataRow)

        Dim DConsumos As New AdoNet("CONSUMOS", CONN, DbProvedor)
        Dim DBaches As New AdoNet("Baches", CONN, DbProvedor)
        Try
            If Recordset Is Nothing Then _
            Throw New ArgumentException("Faltan datos en el bache a procesar")

            DBaches.Open("Select * from BACHES where CONT=" + Recordset("CONT").ToString)

            If DBaches.RecordCount = 0 Then Return

            DConsumos.Open("Select sum(PESOMETA) AS PESOMETA, sum(PESOREAL) AS PESOREAL  from COSNUMOS where CONT=" + Recordset("CONT").ToString)

            If IsDBNull(DConsumos.RecordSet("PESOMETA")) OrElse IsDBNull(DConsumos.RecordSet("PESOREAL")) Then Return

            DBaches.RecordSet("PESOREAL") = DConsumos.RecordSet("PESOREAL")

            If Math.Abs(DBaches.RecordSet("PESOMETA") - DConsumos.RecordSet("PESOMETA")) < Eval(0.05) Then
                DBaches.RecordSet("ESTADO") = 10 'El bache está completo
            End If

            DBaches.Update("Baches TotFinBache")


        Catch ex As Exception
            MsgError(ex.ToString)
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


#Region "Historicos"

    Public Function MakeHist(Optional ByVal Intervalo As Long = 3) As Boolean

        Dim CONNH As DbConnection
        Dim RutaDBH As String
        Dim DVarios As New AdoNet("VARIOS", CONN, DbProvedor)
        Dim DVarios1 As New AdoNet("VARIOS1", CONN, DbProvedor)
        Dim DVariosH As AdoNet
        Dim DCopyH As AdoNet
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

            DVariosH = New AdoNet("VARIOSH", CONNH, DbProvedor)
            DCopyH = New AdoNet("COPYH", CONNH, DbProvedor)


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
                    DCopyH.Update("Consumos MakeHist")
                    Application.DoEvents()
                Next

                DVarios1.Delete("delete from CONSUMOS where CONT=" + RecordSet("CONT").ToString)

                DVariosH.AddNew()
                For i As Integer = 0 To DVarios.DataTable.Columns.Count - 1
                    DVariosH.RecordSet(i) = RecordSet(i)
                Next
                DVariosH.Update("Baches MakeHist")
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

                If DVariosH.RecordCount = 0 Then
                    DVariosH.AddNew()
                End If
                For i As Integer = 0 To DVarios.DataTable.Columns.Count - 1
                    DVariosH.RecordSet(i) = RecordSet(i)
                Next
                DVariosH.Update("Empaque MakeHist")
                Application.DoEvents()
            Next
            DVarios.Delete("delete from EMPAQUE where Fechaini<'" + FechaLim + "'")

            Return True
        Catch ex As Exception
            MsgError(ex.ToString)
            Return False
        End Try
    End Function
    Private Sub CompareTable(ByVal Tabla As String, ByVal CONNH As DbConnection)
        Dim DVarios As New AdoNet("VARIOS", CONN, DbProvedor)
        Dim DVariosH As New AdoNet("VARIOSH", CONNH, DbProvedor)
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
            MsgError(ex.ToString)
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
            MsgError(ex.ToString)
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
            MsgError(ex.ToString)
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
        ENMP = 1
        VACEO = 2
        CONSUMO = 3
        SLPT = 4
        INGMANUAL = 5
        LEEINVENTARIO = 6
        SLMP = 7
        AJUSTEINVENTARIO = 8 'Ajuste de inventario
    End Enum


    Public Sub Inventario(ByVal CodInt As String, ByVal Cantidad As Double, ByVal TipoInvt As TipoInv, ByVal Lote As String, Optional ByVal Detalle As DetOperacion = 0,
                              Optional ByVal Ubicacion As String = "-", Optional ByVal Condicion As String = "-",
                              Optional ByVal Unds As Int32 = 0, Optional ByVal PromSac As Double = 0,
                              Optional ByVal FacturaNro As String = "-", Optional ByVal Observaciones As String = "-",
                              Optional ByVal Maquila As String = "-", Optional ByVal Usuario As String = "")
        Try
            Dim DArt As AdoNet
            Dim DMovInv As AdoNet
            Dim DTipo As AdoNet
            Dim SaldoIni As Double


            DArt = New AdoNet("ARTICULOS", CONN, DbProvedor)
            DMovInv = New AdoNet("MovInv", CONN, DbProvedor)
            DTipo = New AdoNet("TIPOSMAT", CONN, DbProvedor)

            DArt.Open("Select * from ARTICULOS where CODINT='" + CodInt + "'")
            DTipo.Open("Select * from TIPOSMAT")

            If DArt.RecordCount = 0 Then
                'Throw New ArgumentException( _
                '           "El código a no se encuentra registrado en tabla Artículos")
                MsgBox("El código " + CodInt + " no se encuentra registrado en tabla Artículos", MsgBoxStyle.Critical)
                Return
            End If

            If Cantidad = 0 Then Return

            If Detalle <> DetOperacion.AJUSTEINVENTARIO Then
                'Abrimos el recordset con el codint y lote para buscar el saldo anterior
                DMovInv.Open("Select * from MovInv where CODINT='" + CodInt + "' and LOTE='" + _
                                    Lote + "' and TIPOMOV='" + TipoInvt.ToString + "' order by ID desc")

                SaldoIni = 0
                If DMovInv.RecordCount > 0 Then
                    SaldoIni = DMovInv.RecordSet("SALDOFIN")
                End If

            Else
                SaldoIni = DArt.RecordSet("INVCHRONOS")

                DMovInv.Open("Select * from MOVINV where ID=1")
            End If

            'Creamos un registro en la tabla DetInventarios para tener historico de movimientos

            DMovInv.AddNew()
            DMovInv.RecordSet("TIPOMOV") = TipoInvt.ToString
            DMovInv.RecordSet("CODINT") = DArt.RecordSet("CODINT")
            DMovInv.RecordSet("NOMBRE") = DArt.RecordSet("NOMBRE")
            DMovInv.RecordSet("SALDOINI") = SaldoIni
            DMovInv.RecordSet("SALDOFIN") = DMovInv.RecordSet("SALDOINI") + Cantidad

            Select Case TipoInvt
                Case 1 'Inventario ChronoSoft
                    DArt.RecordSet("INVCHRONOS") += Cantidad
                Case 2
                    'Solo si se hace un ajuste físico se pueden ajustar los kilos en la tabla de articulos
                    If Detalle = DetOperacion.AJUSTEINVENTARIO Then
                        DArt.RecordSet("INVFISICO") += Cantidad
                    End If
                    DMovInv.RecordSet("UNDS") = Unds
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
            DMovInv.RecordSet("DETALLE") = Detalle.ToString.Trim

            DMovInv.RecordSet("CODUBI") = Ubicacion
            DMovInv.RecordSet("PROMSAC") = PromSac

            'Buscamos en la tabla TIPOSMAT el tipo para almacenarlo en la tabla MOVINV
            DTipo.Find("TIPOMAT=" + DArt.RecordSet("TIPOMAT").ToString)
            If Not DTipo.EOF Then
                DMovInv.RecordSet("TIPO") = DTipo.RecordSet("TIPO")
            Else
                DMovInv.RecordSet("TIPO") = DArt.RecordSet("TIPO")
            End If

            DMovInv.RecordSet("UNDS") = Unds
            DMovInv.RecordSet("FACTURANRO") = FacturaNro
            DMovInv.RecordSet("OBSERVACIONES") = CLeft(Observaciones, 50)
            DMovInv.RecordSet("USUARIO") = Usuario
            DMovInv.RecordSet("LINEA") = DArt.RecordSet("LINEA")

            DMovInv.Update("MovInv Inventario")
            DArt.Update("Articulos Inventario")

            Evento("Actualiza Inventario " + TipoInvt.ToString + " Cantidad " + Cantidad.ToString + " Articulo " + CodInt.ToString)

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Metodo para el descuento de los cortes de Materia prima"
    Public Sub CortesLote(ByVal CodMat As String, ByVal Cantidad As Single)
        Try
            Dim DCortesMP As AdoNet
            DCortesMP = New AdoNet("CORTESLOTE", CONN, DbProvedor)

            ContCortesMP = 0
            LoteCortesMP = "-"
            PrecioKgLote = 0
            If CodMat = "" Or Cantidad <= 0 Then
                Evento("Parametros no válidos para el metodo de cortes MP CodMat " + CodMat.ToString + " Cant. " + Cantidad.ToString)
                Return
            End If

            DCortesMP.Open("select * from CORTESLOTE where CODMAT='" + CodMat + "' and ESTADO='A'")
            If DCortesMP.RecordCount = 0 Then Return

            ContCortesMP = DCortesMP.RecordSet("CONT")
            LoteCortesMP = DCortesMP.RecordSet("LOTE")
            PrecioKgLote = DCortesMP.RecordSet("PRECIOKG")
            DCortesMP.RecordSet("CONSUMO") += Cantidad

            If DCortesMP.RecordSet("INVFIN") - Cantidad < DCortesMP.RecordSet("Alarma") Then
                Alarma("Alarma DE LOTE " + DCortesMP.RecordSet("NOMMAT") + " Lote: " + DCortesMP.RecordSet("LOTE"))
            End If
            If DCortesMP.RecordSet("INVFIN") - Cantidad < 0 Then
                Alarma("Saldo Negativo en" + DCortesMP.RecordSet("NOMMAT") + " Lote: " + DCortesMP.RecordSet("LOTE"))
            End If

            If Eval(DCortesMP.RecordSet("FECHAINI").ToString) = 0 Then DCortesMP.RecordSet("FECHAINI") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DCortesMP.RecordSet("FECHAFIN") = Format(Now, "yyyy/MM/dd HH:mm:ss")
            DCortesMP.Update("Cortes CortesLote")

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Metodo para el Manejo de las Tolvas"

    Public Enum ProcesoPlanta As Integer
        DOSIFICACION = 1
        EMPAQUE = 2
        PELETIZADO = 3
    End Enum


#End Region

End Module

