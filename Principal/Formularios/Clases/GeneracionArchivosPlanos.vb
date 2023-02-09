Option Explicit On

Imports System.Data.Common  ' Espacio que permite la conexion bilateral Acces o Sql
Imports System.IO
Imports System.Text


Module GeneracionArchivosPlanos



#Region "Generación de archivo plano de eventos general"
    Public Sub Evento(ByVal Frase As String, Optional Modulo As Windows.Forms.Form = Nothing)
        Try
            Dim NombreForm As String = ""
            If Modulo Is Nothing = False Then
                NombreForm = Modulo.Name
            End If
            Dim Archivo As FileStream
            Frase = UCase(Frase)
            Dim byteData() As Byte
            byteData = Encoding.Default.GetBytes(Frase.PadRight(85, Chr(32)) + vbTab + NombreForm.PadRight(30, Chr(32)) + vbTab + UsuarioPrincipal.PadRight(20, Chr(32)) + vbTab + NombrePC.PadRight(20, Chr(32)) + vbTab + Format(Now, "HH:mm:ss") + vbNewLine)
            'Frase + Space(20) + Space(20) + Usuario + Space(20) + NombrePC + Space(20) + Space(20) + Format(Now, "HH:mm:ss")
            Archivo = New FileStream(Ruta + "Aplanos\Eventos_" + Format(Now, "yyMMdd") + ".txt", FileMode.Append)
            Archivo.Write(byteData, 0, byteData.Length)
            Archivo.Close()
        Catch ex As IOException
            Return
        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub
#End Region

#Region "Logs operaciones en la base de datos"
    ''' <summary>
    ''' Procedimiento que guarda en un archivo ".csv" una operación sobre la DB 
    ''' </summary>
    ''' <param name="Encab"></param>
    ''' <param name="MensLogDB"></param>
    ''' <param name="TablaDB"></param>
    ''' <remarks></remarks>
    Public Sub LogDB_CSV(ByVal Encab As String, ByVal MensLogDB As String, ByVal TablaDB As String)

        Dim Directorio As String = Ruta + "Logs\" + TablaDB + "\" + Now.ToString("yyMMdd") + ".txt"
        Dim txtEncab As String
        Dim txtMensDB As String

        Try
            'Si es la tabla de eventoslog se sale para no duplicar la info
            If TablaDB = "EVENTOSLOG" Then Return

            If String.IsNullOrEmpty(Ruta) OrElse String.IsNullOrEmpty(MensLogDB) Then
                Throw New ArgumentException("Datos erroneos para la escritura del archivo")
            End If

            If Not Directory.Exists(Ruta + "\Logs") Then Return 'Se verifica si se tiene acceso al directorio

            txtEncab = Encab + "EQUIPO,IP,USUARIO,HORA"
            txtMensDB = MensLogDB + NombrePC + "," + DireccionIP + "," + UsuarioPrincipal + "," + Now.ToString("HH:mm:ss")

            Using Wrt As New FileStream(Directorio, FileMode.Append)
                Dim byteTexto() As Byte
                Dim archivo As New FileInfo(Directorio)

                If archivo.Length > 0 Then  'Se verifica si el archivo ya existe para escribir el encabezado
                    byteTexto = Encoding.Default.GetBytes(txtMensDB + vbNewLine)
                    Wrt.Write(byteTexto, 0, byteTexto.Length)
                Else
                    byteTexto = Encoding.Default.GetBytes(txtEncab + vbNewLine + txtMensDB + vbNewLine)
                    Wrt.Write(byteTexto, 0, byteTexto.Length)
                End If

                Wrt.Close()

            End Using

        Catch ex As IOException
            If Not Directory.Exists(Ruta + "\Logs") Then Return 'Se verifica si se tiene acceso al directorio
            If File.Exists(Directorio) Then Return ' si existe el archivo pero no se puede tener acceso ( abrieron el archivo con otro programa)
            Dim fi As System.IO.FileInfo = New System.IO.FileInfo(Directorio)
            System.IO.Directory.CreateDirectory(fi.DirectoryName)
            LogDB_CSV(Encab, MensLogDB, TablaDB)
        Catch ex As UnauthorizedAccessException
            MsgError(ex)
            Return
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub
#End Region


End Module
