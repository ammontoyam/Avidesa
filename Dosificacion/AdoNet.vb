Imports System.Data.Common
Imports System.Data
Public Class AdoNet

    Private m_Nombre As String
    Private m_Proveedor As DbProviderFactory
    Private m_Conexion As DbConnection
    Private Cont As Long
    Private Filas() As DataRow
    Private Adaptador As DbDataAdapter
    Private CBuiler As DbCommandBuilder
    Private Comand As DbCommand
    Private Datatabla As DataTable

    Private Reg As DataRow
    Private NewReg As String = ""
    Public RecordSet As DataRow

    Public Sub New(ByVal elnombre As String, ByVal Conexion As DbConnection, ByVal Provedor As DbProviderFactory, Optional ByVal Consulta As String = "")
        MyBase.New()
        If String.IsNullOrEmpty(elnombre) Then
            Throw New ArgumentException( _
                        "El nombre del control no puede ser una cadena vacía")
        End If
        If IsNothing(Conexion) Then
            Throw New ArgumentException( _
                        "La Conexión no puede ser una cadena vacía")
        End If
        If IsNothing(Provedor) Then
            Throw New ArgumentException( _
                        "El Proveedor  no puede ser una cadena vacía")
        End If
        Me.m_Nombre = elnombre
        Me.m_Proveedor = Provedor
        Me.m_Conexion = Conexion
        AsignarObj(Consulta)
    End Sub
#Region "Metodos de la Clase AdoNet"
    Private Sub AsignarObj(Optional ByVal Cadena As String = "")
        Try

            Adaptador = m_Proveedor.CreateDataAdapter
            CBuiler = m_Proveedor.CreateCommandBuilder
            Comand = m_Proveedor.CreateCommand

            Comand.CommandText = ""
            If Cadena <> "" Then Comand.CommandText = Cadena
            Comand.Connection = m_Conexion
            Adaptador.SelectCommand = Comand
            CBuiler.DataAdapter = Adaptador
            Datatabla = New DataTable

            If Cadena <> "" Then
                Adaptador.Fill(DataTable)
            End If
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Public Sub Open(ByVal Consulta As String)
        Try
            If String.IsNullOrEmpty(Consulta) Then
                Throw New ArgumentException( _
                            "La Consulta no puede ser una cadena vacía")
            End If
            AsignarObj()
            Comand.CommandText = Consulta
            Datatabla = New DataTable
            Adaptador.Fill(DataTable)
            NewReg = ""
            RecordSet = Nothing
            If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)

        Catch ex As Exception
            MsgError(ex.ToString + vbCrLf + "  " + Consulta)
        End Try
    End Sub
    Public Sub Update(ByVal Rastreo As String)
        Try
            If NewReg = "NEW" Then DataTable.Rows.Add(Me.RecordSet)
            Adaptador.Update(DataTable)
            DataTable.AcceptChanges()
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
                'MsgError("Ninguna fila disponible para actualizar " + Me.m_Nombre + " " + MessageError)
                Evento("Ninguna fila disponible para actualizar " + Me.m_Nombre + " " + MessageError)
            Else
                Dim Index As Int16 = Datatabla.Rows.IndexOf(DBexep.Row)
                Datatabla = New DataTable
                Adaptador.Fill(DataTable)
                NewReg = ""
                RecordSet = Datatabla.Rows(Index)
                For i = 0 To RecordSet.ItemArray.Count - 1
                    RecordSet(i) = DBexep.Row(i)
                Next
                'Actualizamos nuevamente el registro con los datos enviados inicialmente
                Adaptador.Update(DataTable)
                DataTable.AcceptChanges()
                NewReg = ""
                RecordSet = Nothing
                If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)
            End If

        Catch ex As Exception
            EvError(Rastreo + "  " + (ex.ToString))
            MsgError(Rastreo + "  " + ex.ToString + "  " + Me.m_Nombre)
            RecordSet = Nothing
            NewReg = ""
        End Try
    End Sub

    Public Sub Refresh()
        Try
            If String.IsNullOrEmpty(Comand.CommandText) Then
                Throw New ArgumentException( _
                            "La Consulta no puede ser una cadena vacía")
            End If
            Datatabla = New DataTable
            Adaptador.Fill(DataTable)
            NewReg = ""
            RecordSet = Nothing
            If Datatabla.Rows.Count > 0 Then RecordSet = Datatabla.Rows(0)

        Catch ex As Exception
            RecordSet = Nothing
            MsgError(ex.ToString)
        End Try
    End Sub

    Public Sub Delete(ByVal Consulta As String)
        Try


            If String.IsNullOrEmpty(Consulta) Then
                Throw New ArgumentException( _
                            "La Consulta no puede ser una cadena vacía")
            End If

            Consulta = Replace(Consulta.ToUpper, "DELETE", "Select * ")


            Comand.CommandText = Consulta
            Datatabla = New DataTable
            Adaptador.Fill(DataTable)

            If Me.RecordCount = 0 Then Return

            For Each R As DataRow In DataTable.Rows
                R.Delete()
            Next
            Update(Consulta)
            'Opcional por si se necesita
            'If m_Conexion.State <> ConnectionState.Open Then m_Conexion.Open()
            'm_Conexion.CreateCommand.CommandText = Consulta
            'm_Conexion.CreateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgError(ex.ToString)
        End Try
    End Sub

    Public Function Find(ByVal Filtro As String) As DataRow

        If String.IsNullOrEmpty(Filtro) Then
            Throw New ArgumentException( _
                        "El Filtro no puede ser una cadena vacía")
        End If

        If Me.RecordCount = 0 Then
            Find = Nothing
            NewReg = "EDIT"
            RecordSet = Nothing
            Exit Function
        End If

        Filas = Me.DataTable.Select(Filtro)
        If Filas.Length = 0 Then
            Find = Nothing
            NewReg = "EDIT"
            RecordSet = Nothing
        Else
            Find = Filas(0)
            NewReg = "EDIT"
            RecordSet = Filas(0)
        End If

    End Function

    'Public Function RecordSet() As DataRow
    '    If (NewReg = "" AndAlso IsNothing(DataTable.Rows(0))) Then
    '        Throw New ArgumentException( _
    '                    "No se puede recuperar el registro actual")
    '    End If

    '    If (NewReg = "NEW" OrElse NewReg = "EDIT") Then
    '        RecordSet = Record
    '    Else
    '        RecordSet = DataTable.Rows(0)
    '    End If
    'End Function

    Public Sub AddNew()
        If (Me.Comand.CommandText = "") Then
            Throw New ArgumentException( _
                        "No se puede crear el registro actual")
        End If
        NewReg = "NEW"
        RecordSet = DataTable.NewRow
    End Sub

#End Region

#Region "Propiedades de la Clase AdoNet"
    Public ReadOnly Property RecordCount() As Long

        Get
            If Not IsNothing(DataTable) AndAlso DataTable.Rows.Count > 0 Then
                Cont = DataTable.Rows.Count
            Else
                Cont = 0
            End If
            RecordCount = Cont
        End Get

    End Property

    Public ReadOnly Property EOF() As Boolean
        Get
            If Not IsNothing(Me.RecordSet) Then
                EOF = False
            Else
                EOF = True
            End If
        End Get
    End Property
    Public ReadOnly Property DataTable() As DataTable
        Get
            DataTable = Me.Datatabla
        End Get
    End Property
    Public ReadOnly Property DataAdapter() As DbDataAdapter
        Get
            DataAdapter = Me.Adaptador
        End Get
    End Property
    Public ReadOnly Property Rows() As DataRowCollection
        Get
            Rows = Me.Datatabla.Rows
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
