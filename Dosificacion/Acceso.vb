Option Strict On
Imports System.String
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Data.Common
Imports System.Data
Imports System.Windows.Forms


Public Class Acceso

    Private IndAces As Integer = 0
    Private ACuUser As String = ""
    Private ACuPass As String = ""

    Public DUsuarios As AdoNet

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub


    Public Sub Acceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Ruta = Application.StartupPath
            If Ruta.Last.ToString <> "\" Then Ruta = Ruta + "\"

            If InStr(UCase(Ruta), "AVID") > 0 Then
                Fuentes = True
            End If

            If File.Exists(Ruta + "Ruta.txt") = False Then
                MsgBox("No existe el archivo ruta el cual contiene el nombre del Motor de Base de Datos", MsgBoxStyle.Information)
                End
            Else
                Dim rd As StreamReader = New StreamReader(Ruta + "Ruta.txt", True)
                ServidorSQL = rd.ReadLine.Trim
                rd.Close()
            End If

            NomDB = "ChronoSoft"
            UserDB = "Admin1"
            PWD = "canaveral"

            If File.Exists(Ruta + "a") = True Then
                Evento(" Se cierra ChronoSoft por archivo a " + Me.Name)
                End
            End If

            RutaRep = Ruta + "DB\"

            DbProvedor = DbProviderFactories.GetFactory("System.Data.SqlClient")
            RutaDB = "Data Source=" + ServidorSQL + "; Initial Catalog=" + NomDB + "; User Id=" + UserDB + "; Password=" + PWD


            'Toma los parametros del Provedor segun el caso
            CONN = DbProvedor.CreateConnection
            CONN.ConnectionString = RutaDB

            DUsuarios = New AdoNet("-", CONN, DbProvedor)
            DUsuarios.Open("select * from USUARIOS order by USUARIO")
    
            NombrePC = My.Computer.Name.ToUpper
            Sesion = Environment.UserName.ToUpper

            NombrePC = My.Computer.Name
            Usuario = "Dosificación"



            If ReadConfigVar("PCDOSIF").ToUpper = Sesion Or ReadConfigVar("PCDOSIF").ToUpper = NombrePC Then ServComM = True
            If ServComM = False And Fuentes = False Then
                MsgBox("Este programa maneja las comunicaciones de ChronoSoft y solo puede abrirse en el PC:" + ReadConfigVar("PCDOSIF"), vbInformation)
                End
            End If

            Evento("Entra a ChrDosifica")
            PDosifica.Show()
            'Equipos.Show()
            Planta = "AVIDESA BUCARAMANGA"


            Me.Close()
            Me.Dispose()
     

        Catch ex As Exception
            MsgError(ex.ToString)
        End Try


    End Sub

    'Private Sub BOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ClaveReal As String
    '    If TClave.Text = "" Or TUsuario.Text = "" Then Exit Sub
    '    Try
    '        IndAces += 1

    '        DUsuarios.Find("USUARIO='" + TUsuario.Text.Trim + "'")

    '        ' DRUsu = DTUsuarios.Select("USUARIO='" + TUsuario.Text.Trim + "'")

    '        If DUsuarios.EOF = True Then
    '            MsgBox("El Usuario No se a Encontrado", MsgBoxStyle.Information)
    '            If IndAces = 3 Then
    '                End
    '            End If
    '            TUsuario.Focus()
    '            Exit Sub
    '        End If
    '        ClaveReal = ""
    '        For K = 1 To Len(DUsuarios.RecordSet("Clave").ToString)
    '            ClaveReal = ClaveReal + Chr(Asc(Mid(DUsuarios.RecordSet("Clave").ToString, K, 1)) - (K * 2) - 5)
    '        Next

    '        If TClave.Text.Trim <> ClaveReal Then
    '            MsgBox("Contraseña Incorrecta", MsgBoxStyle.Information)
    '            If IndAces = 3 Then
    '                End
    '            End If
    '            TClave.Focus()
    '            Exit Sub
    '        End If

    '        If Convert.ToBoolean(DUsuarios.RecordSet("Activo")) = False Then
    '            MsgBox(" El Usuario " + TUsuario.Text.Trim + " Se encuentra desactivado Comuníquese con el Administrador de Sistemas ", MsgBoxStyle.Information)
    '            TUsuario.Text = ""
    '            TClave.Text = ""
    '            TUsuario.Focus()
    '            Exit Sub

    '        End If

    '        If Convert.ToBoolean(DUsuarios.RecordSet("EMPMOD")) = False Then
    '            MsgBox(" El Usuario " + TUsuario.Text.Trim + " no tiene permiso de supervisor ", MsgBoxStyle.Information)
    '            TUsuario.Text = ""
    '            TClave.Text = ""
    '            TUsuario.Focus()
    '            Exit Sub
    '        End If
    '        NombrePC = My.Computer.Name
    '        Usuario = TUsuario.Text

    '        DRUsuario = DUsuarios.RecordSet

    '        Me.Close()
    '        Me.Dispose()

    '        Evento("Entra a ChrDosifica")
    '        PDosifica.ShowDialog()


    '        Me.Close()
    '        Me.Dispose()

    '    Catch ex As Exception
    '        MsgBox(ex.ToString())
    '        Evento(ex.ToString)
    '    End Try

    'End Sub

    
End Class




