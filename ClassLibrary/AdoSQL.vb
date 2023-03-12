Imports System.Data.SqlClient


Public Class AdoSQL

    Private m_Nombre As String
    Private Cont As Long
    Private Filas() As DataRow
    Private Adaptador As SqlDataAdapter
    Private CBuiler As SqlCommandBuilder
    Private Datatabla As DataTable

    Private Reg As DataRow
    Private NewReg As String = ""
    Private Conexion As String
    Public RecordSet, RecordsetAnt As DataRow
    Private UltimaConsulta As String
    Private nModulo As String = ""



#Region "Lista exclusiones del método update clase AdoSQL"
    Private Exclusiones As New List(Of String) From {
        {"UsuariosLog"},
        {"EventoAuditoria"}
}
#End Region


#Region "Funcion para obtener los cambios en un RecordSet"
    Private Sub ArchivarCambios(ByVal nForm As Form, ByVal Registro As DataRow, ByVal Estado As String)

        Dim schemaTabla = New DataTable

        Dim Operacion As Accion
        Dim msgLogDB As String = ""
        Dim detAuditoria As String = ""
        Dim Encabezado As String = ""
        Dim Contenido As String = ""
        Dim ContenidoAnt As String = ""
        Dim nPK As String = ""
        Dim vCampo As String = ""
        Dim nCampo As String
        Dim valCampoActual As String
        Dim valCampoOrig As String = ""
        Dim nModulo As String
        Dim nTabla As String
        Dim contModificados As Int16

        Try
            nModulo = nForm.Name
            If nModulo = "ImportFor" Then Return 'Si es el modulo de importar formulas se omite guardar el archivo CSV por mucha operaciones de OPEN/WRITE seguidas
            'Obtenemos el esquema de la tabla para saber que campos son llave
            Adaptador.FillSchema(schemaTabla, SchemaType.Source)

            nTabla = schemaTabla.TableName

            If nTabla = "DATOSFOR" Then
                nPK = "CodFor-LP"
            ElseIf nTabla = "USUARIOSDETALLE" Then
                nPK = "Usuario-Permiso"
            Else
                For pk = 0 To schemaTabla.PrimaryKey.Length - 1
                    nPK += schemaTabla.PrimaryKey(pk).ColumnName + "-"
                Next
            End If

            For R = 0 To Registro.ItemArray.Length - 1
                nCampo = Datatabla.Columns.Item(R).ToString ' Obtener nombre de la columna
                valCampoActual = Registro.Item(R).ToString ' Obtener valor del campo

                If InStr(nPK, nCampo) > 0 Then ' Obtener valor de las llaves primarias de la tabla
                    vCampo += valCampoActual + "-"
                End If

                If Estado = "Modified" Then 'Si ha modificado un registro

                    If IsDBNull(Registro(R, DataRowVersion.Original)) Then Continue For 'Cuando un registro es nuevo y por defecto en la BD es Null no sebe mirar si se ha modificado

                    valCampoOrig = Registro(R, DataRowVersion.Original)

                    If valCampoOrig <> valCampoActual AndAlso valCampoOrig <> "" Then ' si es un EDIT  se captura solo los cambios
                        detAuditoria += nCampo + ":" + valCampoActual + "(" + valCampoOrig + ");"
                        contModificados += 1
                    End If
                Else ' Si es un CREAR o BORRAR un registro se captura toda la fila
                    ' Estado = "Added" OrElse Estado = "Deleted"
                    detAuditoria += nCampo + ":" + valCampoActual + ";"
                End If

                Encabezado += nCampo + ","
                Contenido += valCampoActual + ","
                ContenidoAnt += valCampoOrig + ","
            Next

            If Estado = "Modified" AndAlso contModificados = 0 Then Exit Sub

            'Captura de datos para guardar en los eventos (tabla "EventosLog" y archivo csv)
            Select Case Estado
                Case "Added"
                    Operacion = Accion.CREAR
                    msgLogDB = Contenido
                Case "Deleted" '"Unchanged"
                    Operacion = Accion.BORRAR
                    msgLogDB = Contenido
                Case "Modified"
                    Operacion = Accion.EDITAR
                    msgLogDB = ContenidoAnt + vbCrLf + Accion.EDITADO.ToString + "," + Contenido
            End Select

            Encabezado = "ACCION" + "," + Encabezado
            msgLogDB = Operacion.ToString + "," + msgLogDB
            LogDB_CSV(Encabezado, msgLogDB, nTabla)
            nPK = nPK.Trim("-")
            vCampo = vCampo.Trim("-")
            EventoAuditoria(detAuditoria, nForm, Operacion, nTabla, nPK, vCampo)

        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try

    End Sub

#End Region

    Public Sub New(ByVal elnombre As String, ByVal RutaConn As String)
        MyBase.New()
        Try
            m_Nombre = elnombre
            Conexion = RutaConn
            If String.IsNullOrEmpty(elnombre) Then
                Throw New ArgumentException("El nombre del control no puede ser una cadena vacía")

            End If
        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try
    End Sub

    Public Sub New(ByVal elnombre As String)
        MyBase.New()
        Try
            If String.IsNullOrEmpty(elnombre) Then
                Throw New ArgumentException("El nombre del control no puede ser una cadena vacía")
            End If
            m_Nombre = elnombre
            Conexion = RutaDB
        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try
    End Sub

    Public Sub Open(ByVal Consulta As String)
        Try
            If String.IsNullOrEmpty(Consulta) Then
                Throw New ArgumentException("La Consulta no puede ser una cadena vacía")
            End If

            Adaptador = New SqlDataAdapter(Consulta, Conexion)
            CBuiler = New SqlCommandBuilder(Adaptador)

            Datatabla = New DataTable
            Adaptador.Fill(Datatabla)
            NewReg = ""
            RecordSet = Nothing
            If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)
            UltimaConsulta = Consulta

        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try
    End Sub


    Public Sub Update(Optional nForm As Windows.Forms.Form = Nothing)

        Dim EstadoReg As String

        Try
            ' Obtenemos el objeto del último método llamador.
            Dim stackObj = New StackTrace().GetFrame(1).GetMethod().Name

            If NewReg = "NEW" Then Datatabla.Rows.Add(RecordSet)
            'si el objeto que llama al update es una excepción o un update interno del programa
            'no se guarda ningún Log en los archivos planos ni en la tabla "EventosLog"
            If Exclusiones.Contains(stackObj) OrElse IsNothing(nForm) Then
                Adaptador.Update(Datatabla)
                Datatabla.AcceptChanges()
                NewReg = ""
                RecordSet = Nothing
                If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)
                Exit Sub
            End If

            EstadoReg = RecordSet.RowState.ToString 'Obtener el estado de la fila
            ArchivarCambios(nForm, RecordSet, EstadoReg)

            Adaptador.Update(Datatabla)
            Datatabla.AcceptChanges()
            NewReg = ""
            RecordSet = Nothing
            If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)

        Catch DBexep As DBConcurrencyException

            If Datatabla.GetChanges Is Nothing Then
                RecordSet = Nothing
                NewReg = ""
                Dim MessageError As String
                MessageError = "Concurrency violation" & vbCrLf
                MessageError &= CType(DBexep.Row.Item(0), String) + MessageError + " " + CType(DBexep.Row.Item(1), String)
                'MsgError("Ninguna fila disponible para actualizar " + m_Nombre + " " + MessageError)
                Evento("Ninguna fila disponible para actualizar " + m_Nombre + " " + MessageError)
            Else
                Dim Index As Int16 = Datatabla.Rows.IndexOf(DBexep.Row)
                Datatabla = New DataTable
                Adaptador.Fill(Datatabla)
                NewReg = ""
                RecordSet = Datatabla.Rows(Index)
                For i = 0 To RecordSet.ItemArray.Count - 1
                    RecordSet(i) = DBexep.Row(i)
                Next
                'Actualizamos nuevamente el registro con los datos enviados inicialmente
                Adaptador.Update(Datatabla)
                Datatabla.AcceptChanges()
                NewReg = ""
                RecordSet = Nothing
                If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)
            End If

        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
            RecordSet = Nothing
            NewReg = ""
        End Try

    End Sub


    Public Sub Refresh()
        Try
            If String.IsNullOrEmpty(UltimaConsulta) Then
                Throw New ArgumentException("La Consulta no puede ser una cadena vacía")
            End If

            Datatabla = New DataTable
            Adaptador.Fill(Datatabla)
            NewReg = ""
            RecordSet = Nothing
            If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)

        Catch ex As Exception
            RecordSet = Nothing
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try
    End Sub

    Public Sub Delete(Consulta As String, Optional nForm As Windows.Forms.Form = Nothing)
        Dim EstadoBorrar As String
        Try

            If String.IsNullOrEmpty(Consulta) Then
                Throw New ArgumentException("La Consulta no puede ser una cadena vacía")
            End If

            Consulta = Replace(Consulta.ToUpper, "DELETE", "Select * ")

            Adaptador = New SqlDataAdapter(Consulta, Conexion)
            CBuiler = New SqlCommandBuilder(Adaptador)

            Datatabla = New DataTable
            Adaptador.Fill(Datatabla)

            If Count = 0 Then Exit Sub

            If IsNothing(nForm) Then
                For Each R As DataRow In Datatabla.Rows
                    R.Delete()
                Next
            Else
                For Each R As DataRow In Datatabla.Rows
                    EstadoBorrar = "Deleted" 'Se asigna el estado de la fila en borrar
                    ArchivarCambios(nForm, R, EstadoBorrar)
                    R.Delete()
                Next
            End If

            Update()
            'Opcional por si se necesita
            'If m_Conexion.State <> ConnectionState.Open Then m_Conexion.Open()
            'm_Conexion.CreateCommand.CommandText = Consulta
            'm_Conexion.CreateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try

    End Sub
    Public Function Find(ByVal Filtro As String) As DataRow
        Try
            If String.IsNullOrEmpty(Filtro) Then
                Throw New ArgumentException("El Filtro no puede ser una cadena vacía")
            End If

            If Count = 0 Then
                Find = Nothing
                NewReg = "EDIT"
                RecordSet = Nothing
                Exit Function
            End If

            Filas = DataTable.Select(Filtro)
            If Filas.Length = 0 Then
                Find = Nothing
                NewReg = "EDIT"
                RecordSet = Nothing
            Else
                Find = Filas(0)
                NewReg = "EDIT"
                RecordSet = Filas(0)
            End If
        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
            Find = Nothing
        End Try
    End Function

    Private Function DevuelveCadenaConexion(ByVal Conexion) As String
        DevuelveCadenaConexion = "Error"
        If Conexion = "" Then Return DevuelveCadenaConexion

        Dim Pos As Int16 = InStr(Conexion, "User")
        If Pos > 0 Then
            DevuelveCadenaConexion = CLeft(Conexion, Pos - 1)
        Else
            DevuelveCadenaConexion = "Error"
        End If

        Return DevuelveCadenaConexion

    End Function

    Public Sub AddNew()
        If (UltimaConsulta = "") Then
            Throw New ArgumentException("No se puede crear el registro actual")
        End If
        NewReg = "NEW"
        RecordSet = Datatabla.NewRow
    End Sub


    Public Sub SpSQL(ConsultaSP As String)
        Try
            Dim queryText As String
            If String.IsNullOrEmpty(ConsultaSP) Then
                Throw New ArgumentException("La Consulta no puede ser una cadena vacía")
            End If
            queryText = "execute " + ConsultaSP
            Adaptador = New SqlDataAdapter(queryText, Conexion)
            CBuiler = New SqlCommandBuilder(Adaptador)

            Datatabla = New DataTable
            Adaptador.Fill(Datatabla)
            NewReg = ""
            RecordSet = Nothing
            If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)
            UltimaConsulta = queryText

        Catch ex As Exception
            MsgError(ex, m_Nombre + " " + DevuelveCadenaConexion(Conexion))
        End Try
    End Sub

#Region "Propiedades de la Clase AdoSql"
    Public ReadOnly Property Count() As Long

        Get
            If Not IsNothing(Datatabla) AndAlso Datatabla.Rows.Count > 0 Then
                Cont = Datatabla.Rows.Count
            Else
                Cont = 0
            End If
            Count = Cont
        End Get

    End Property

    Public ReadOnly Property EOF() As Boolean
        Get
            If Not IsNothing(RecordSet) Then
                EOF = False
            Else
                EOF = True
            End If
        End Get
    End Property

    Public ReadOnly Property DataTable() As DataTable
        Get
            DataTable = Datatabla
        End Get
    End Property

    Public ReadOnly Property DataAdapter() As SqlDataAdapter
        Get
            DataAdapter = Adaptador
        End Get
    End Property

    Public ReadOnly Property Rows() As DataRowCollection
        Get
            Rows = Datatabla.Rows
        End Get
    End Property

    Private Property Record() As DataRow
        Get
            Record = Reg
        End Get
        Set(ByVal value As DataRow)
            Reg = value
        End Set
    End Property

#End Region

End Class
