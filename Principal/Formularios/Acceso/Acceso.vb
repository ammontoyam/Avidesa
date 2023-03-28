
'Imports System.String
'Imports System.Data.SqlClient
'Imports System.Data.OleDb
Imports System.IO
'Imports System.Data.Common
'Imports System.Data
'Imports System.Windows.Forms
'Imports System.Diagnostics
'Imports System
'Imports System.Security
'Imports System.ComponentModel
Imports System.Globalization.CultureInfo
Imports ClassLibrary



Public Class Acceso

    Private IndAces As Integer = 0
    Private ACuUser As String = ""
    Private ACuPass As String = ""
    Private VerifSeg As Boolean
    Private ClaveExpira As String

    Private DUsuariosDetalle As AdoSQL
    Private DUsuarios As AdoSQL
    Private DConexionesExt As AdoSQL
    Private DEventosLog As AdoSQL
    Private FormLoad As Boolean

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        'Si no han ingresado a chronosoft, esta funcion termina el programa, si ya re loguearon (y quieres hacer un cambio de usuario) solo se cierra el formulario
        If DRUsuario Is Nothing Then
            End
        Else
            Me.Close()
            Me.Dispose()
        End If

    End Sub


    Public Sub Acceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Verifica si el usuario ya esta corriendo chronosoft

            Dim Separador As String = ""

            Separador = CurrentCulture.NumberFormat.NumberDecimalSeparator


            If Not FormLoad Then InicializaMensajesEventos()

            Ruta = Application.StartupPath
            If Ruta.Last.ToString <> "\" Then Ruta = Ruta + "\"

            'Verifica si se está corriendo depuración por parte de tecnimatica
            If Directory.Exists(Ruta + "Principal") Then
                Fuentes = True
            End If

            If File.Exists(Ruta + "Ruta.txt") = False Then
                MsgBox("No existe el archivo ruta el cual contiene el nombre del Motor de Base de Datos", MsgBoxStyle.Information)
            Else
                Dim rd As StreamReader = New StreamReader(Ruta + "Ruta.txt", True)
                ServidorSQL = rd.ReadLine.Trim
                NomDB = rd.ReadLine.Trim
                rd.Close()
            End If

            'Se revisa si el archivo a esta puesto, quiere decir que se necesita realizar un cambio de ejecutable
            If File.Exists(Ruta + "a") = True Then
                Evento(DevuelveEvento(CodEvento.SISTEMA_SALIDA) + " por archivo a", Me)
                End
            End If

            'Carpeta donde se encuentran alojados los reportes
            If Fuentes Then
                UserDB = "Admin"
                PWD = "NEP"
            Else
                UserDB = "sa" '"Admin"
                PWD = "v1w8QU@83&M#aiz8TRV2" '"NEP"
            End If
            'Credenciales para acceso a base de base de datos

            RutaRep = Ruta + "DB\"
            'Conexión principal a base de datos de cada planta
            RutaDB = "Data Source=" + ServidorSQL + "; Initial Catalog=" + NomDB + "; User Id=" + UserDB + "; Password=" + PWD
            'RutaDB = "Server=tcp:chronosoft.database.windows.net,1433;Initial Catalog=" + NomDB + ";Persist Security Info=False;User ID=chronosoft;Password=C123456+;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"


            'Variables Globales
            NombrePC = My.Computer.Name.ToUpper
            Sesion = Environment.UserName.ToUpper
            Planta = ConfigParametros("NombrePlanta")
            DireccionIP = GetIP()


            If Not Planta.Contains("YARUMAL") AndAlso Not Planta.Contains("SANTA ROSA") AndAlso Not Planta.Contains("GIRARDOTA PREMEZCLAS") Then
                If Separador <> "." Then
                    MsgBox("Debe configurar apropiadamente el separador de simbolo Decimal, este debe ser punto (.), por favor ponganse en contacto con el administrador del sistema", vbCritical)
                    End
                End If
            End If

            'Instanciamos los objetos de conexión a la base de datos
            DUsuarios = New AdoSQL("Usuarios")
            DUsuarios.Open("Select * from USUARIOS order by USUARIO")

            DUsuariosDetalle = New AdoSQL("UsuariosDetalle")

            DConexionesExt = New AdoSQL("ConexionesExt")
            DConexionesExt.Open("Select * from CONEXIONESEXT")

            'Ruta de conexión a sistema SigCoPro
            DConexionesExt.Find("SISTEMA='SIGCOPRO'")
            If Not DConexionesExt.EOF Then
                RutaDB_SigCoPro = DConexionesExt.RecordSet("CADENACONEXION")
            End If

            'Ruta de conexión a sistema ControlBascula
            DConexionesExt.Find("SISTEMA='CONTROLBASCULA'")
            If Not DConexionesExt.EOF Then
                RutaDB_ControlBascula = DConexionesExt.RecordSet("CADENACONEXION")
            End If

            'Ruta de conexion a sistema ChronoSoft Premezclas
            DConexionesExt.Find("SISTEMA='CHRPREMEZCLAS'")
            If Not DConexionesExt.EOF Then
                RutaDB_ChrPremezclas = DConexionesExt.RecordSet("CADENACONEXION")
            End If

            'Ruta de conexión a sistema SigCoPro Engrasadores
            DConexionesExt.Find("SISTEMA='SIGCOPRO.ENGRASADORES'")
            If Not DConexionesExt.EOF Then
                RutaDB_SigCoPro_Engrasadores = DConexionesExt.RecordSet("CADENACONEXION")
            End If


            'Iniciamos todas las funcionalidades
            If Not FormLoad Then InicializaFuncionalidades()

            ServComM = False
            ServCHR = False

            FormLoad = True

            'Se busca si el PC es servidorComunicaciones
            If ConfigParametros("ServidorComunicaciones").ToUpper = NombrePC Or ConfigParametros("ServidorComunicaciones").ToUpper = Sesion Then
                ServComM = True
            End If
            'Se revisa si ChronoSoft.exe se esta ejecutando en el servidor
            If ConfigParametros("ServidorChronoSoft").ToUpper = NombrePC Or ConfigParametros("ServidorChronoSoft").ToUpper = Sesion Then ServCHR = True

            'Se creo este usuario para que se pueda abrir automaticamente en el servidor 
            If ServCHR Then
                TUsuario.Text = "SERVIDOR"
                TClave.Text = "Servidor123+"
                BOk_Click(Nothing, Nothing)
            End If

            Fondo.TPlanta.Text = Planta

            If Fuentes Then
                TUsuario.Text = "TECNIMATICA"
                BOk_Click(Nothing, Nothing)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try


    End Sub


    Private Sub TUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TUsuario.TextChanged
        TUsuario.CharacterCasing = CharacterCasing.Upper
    End Sub

    Private Sub TClave_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TClave.KeyUp
        If e.KeyCode = Keys.Enter Then BOk_Click(Nothing, Nothing)
    End Sub


    Private Sub TUsuario_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TUsuario.KeyUp
        If e.KeyCode = Keys.Enter Then TClave.Focus()

    End Sub

    Private Sub BOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOk.Click
        Dim ClaveReal As String
        If (TClave.Text = "" AndAlso TUsuario.Text <> "TECNIMATICA") Or TUsuario.Text = "" Then Exit Sub
        Try
            IndAces += 1

            DUsuarios.Find("USUARIO='" + TUsuario.Text.Trim + "'")

            If TUsuario.Text = "TECNIMATICA" Then

                If DUsuarios.EOF Then
                    MsgBox("Falta usuario TECNIMATICA de configuración para simulaciones ChronoSoft", vbCritical)
                    End
                End If
                GoTo UsuarioTecnimatica
            End If

            ' DRUsu = DTUsuarios.Select("USUARIO='" + TUsuario.Text.Trim + "'")

            If DUsuarios.EOF = True Then
                MsgBox("Usuario no registrado en ChronoSoft", MsgBoxStyle.Information)
                If IndAces = 3 Then
                    End
                End If
                TUsuario.Focus()
                Exit Sub
            End If
            ClaveReal = ""
            Clave = TClave.Text.Trim
            For K = 1 To Len(DUsuarios.RecordSet("Clave").ToString)
                ClaveReal = ClaveReal + Chr(Asc(Mid(DUsuarios.RecordSet("Clave").ToString, K, 1)) - (K * 2) - 5)
            Next

            'MsgBox(Clave + "-" + ClaveReal)
            UsuarioPrincipal = TUsuario.Text
            '**********************************************************************************
            If Clave <> ClaveReal Then
                MsgBox("Contraseña Incorrecta. Tenga en cuenta que se diferencian mayúsculas de minúsculas", MsgBoxStyle.Information)
                If IndAces = numIntentos Then
                    MsgBox(" El Usuario " + TUsuario.Text.Trim + " ha sido bloqueado, comuníquese con el Administrador de Sistemas ", MsgBoxStyle.Information)
                    'DUsuarios.RecordSet("Activo") = False
                    'DUsuarios.Update()

                    DUsuariosDetalle.Open("Delete from USUARIOSDETALLE where USUARIO='" + UsuarioPrincipal + "' and PERMISO='ACTIVO'")

                    UsuariosLog("Bloqueado", "Bloqueos", "")
                    Me.Dispose()
                    Me.Close()
                    Fondo.Dispose()
                    Fondo.Close()
                    End
                End If
                TClave.Focus()
                Exit Sub
            End If


            solCambClave = DUsuarios.RecordSet("CAMBIOCLAVE")
            VerifSeg = ValidaSeguridad(ClaveReal)

            If VerifSeg = False Then
                MsgBox("Por políticas de seguridad, desde Octubre de 2019, las contraseñas deben cumplir ciertos requisitos. Por tal motivo deberá cambiarla en este momento", vbExclamation, "Reglas seguridad")
                MsgBox("Debe memorizar o apuntar en un lugar seguro la nueva clave", vbExclamation, "Reglas seguridad")
                MsgBox("Ahora se diferencian mayúsculas de minúsculas", vbExclamation, "Reglas seguridad")

                UsuariosClave.TUsuario.Text = TUsuario.Text
                UsuariosClave.ShowDialog()
                If CerrarChr Then
                    Fondo.Dispose()
                    Fondo.Close()
                    End
                End If
                DUsuarios.Refresh()
                DUsuarios.Find("USUARIO='" + TUsuario.Text.Trim + "'")
                ClaveExpira = DUsuarios.RecordSet("FECHAEXPPASS")
            End If


            '**********************************************************************************

            ClaveExpira = DUsuarios.RecordSet("FECHAEXPPASS")

            If ClaveExpira = "-" OrElse DateDiff(DateInterval.Day, Now, CDate(ClaveExpira)) <= 1 Then
                UsuariosLog("Clave expirada", "Configuración", "")
                RespInput = MsgBox("Su contraseña ha expirado, desea cambiarla ahora?", vbYesNo + vbInformation)
                If RespInput = vbNo Then End
                'Me.Visible = False
                UsuariosClave.TUsuario.Text = TUsuario.Text
                UsuariosClave.ShowDialog()
                If CerrarChr Then
                    Fondo.Dispose()
                    Fondo.Close()
                    End
                End If
            End If

            If solCambClave Then
                UsuariosLog("Solicita cambio Clave", "Configuración", "")
                RespInput = MsgBox("Hay solicitud de cambio de contraseña, desea cambiarla ahora?", vbYesNo + vbInformation)
                If RespInput = vbNo Then End
                'Me.Visible = False
                UsuariosClave.TUsuario.Text = TUsuario.Text
                UsuariosClave.ShowDialog()
                If CerrarChr Then
                    Fondo.Dispose()
                    Fondo.Close()
                    End
                End If
            End If

UsuarioTecnimatica:

            If Not Fuentes And TUsuario.Text = "TECNIMATICA" Then
                'If ValidaClave(TClave.Text) = False Then
                '    MsgBox("Clave de acceso no válida para usuario TECNIMATICA", MsgBoxStyle.Information)
                '    Return
                'End If
                If TClave.Text <> "T3cn1m4t1c@" Then
                    MsgBox("Clave de acceso no válida para usuario TECNIMATICA", MsgBoxStyle.Information)
                    Return
                End If
            End If

            NombrePC = My.Computer.Name
            UsuarioPrincipal = TUsuario.Text
            'Se llena un diccionario con los permisos que tenga asignados el usuario
            '--------------------------------------------------------------------------------------------------------

            DUsuariosDetalle.Open("select * from USUARIOSDETALLE where USUARIO = '" + UsuarioPrincipal + "' order by USUARIO")

            DicPermisoUsuario.Clear()
            For Each Reg As DataRow In DUsuariosDetalle.Rows
                DicPermisoUsuario.Add(Reg("PERMISO").ToString.ToUpper, True)
            Next
            '--------------------------------------------------------------------------------------------------------

            '**********************************************************************************
            'Se revisa si el ussuario está activo

            If Not Fuentes And ValidaPermiso("Activo") = False Then
                MsgBox(" El Usuario " + TUsuario.Text.Trim + " Se encuentra desactivado Comuníquese con el Administrador de Sistemas ", MsgBoxStyle.Information)
                TUsuario.Text = ""
                TClave.Text = ""
                TUsuario.Focus()
                Me.Dispose()
                Me.Close()
                Fondo.Dispose()
                Fondo.Close()
                End
            End If


            DRUsuario = DUsuarios.RecordSet


            'Se buscan las funcionalidades que estan definidas para la planta
            'en este caso abrir los formularios que trabajan automaticamente por debajo 

            'Se busca si hay que cargar el formulario CortesContBascula
            If ValidaFuncionalidad("Importacion.Lotes.ControlBascula", NombrePC) Then

                If Funcion_CentralBasculaServicioWEB Then
                    CortesCentralBascula.CortesControlBascula_Load(Nothing, Nothing)
                Else
                    'Verificar si hay conexión al motor de BD externo
                    If VerificarConexionDB(RutaDB_ControlBascula) = False Then
                        MsgBox(DevuelveEvento(CodEvento.SISTEMA_ERROR) + " conexión con base de datos Control Báscula. No se importará los cortes de materia prima", vbCritical)
                    Else
                        CortesContBascula.CortesControlBascula_Load(Nothing, Nothing)
                    End If
                End If
            End If

            If ServComM = True Then
                'Llenamos el campo USUARIODOSIF de la tabla CONFIGVAR para registrar el usuario actual para los tiempos muertos
                'En caso de que cambien de usuario en ChronoSoft se actualiza en los programasa de comunicaciones
                If InStr(DRUsuario("CARGO").ToString, "DOSIF") > 0 Or InStr(DRUsuario("CARGO").ToString, "SUPERV") > 0 Then
                    WriteConfigVar("USUARIODOSIF", UsuarioPrincipal)
                    WriteConfigParametros("UsuarioDosificacion", UsuarioPrincipal)
                End If

                If Funcion_DatosEngrasadores Then
                    DatosEngrasadores.DatosEngrasadores_Load(Nothing, Nothing)
                End If
            End If


            If ValidaFuncionalidad("DatosHora.SCP", NombrePC) Then
                DatosHora.DatosHora_Load(Nothing, Nothing)
            End If

            Fondo.Text = "ServSQL: " + ServidorSQL + " Sesión: " + Sesion + " UsuarioChr: " + UsuarioPrincipal + " Planta: " + Planta

            UsuariosLog("Entra a ChronoSoft", "Ingresos", "")


            Evento(DevuelveEvento(CodEvento.SISTEMA_INGRESO), Me)
            EventoAuditoria(DevuelveEvento(CodEvento.SISTEMA_INGRESO), Me, Accion.ENTRAR)

            Fondo.TimSeg.Enabled = True
            LCambTurno.Visible = False

            'Se realiza depuración de la tabla eventoslog 
            DEventosLog = New AdoSQL("EventosLog")
            DEventosLog.Open("Delete from EVENTOSLOG where FECHA<'" + Format(DateAdd(DateInterval.Year, -1, Now), "yyyy/MM/dd") + "'")


            Me.Close()
            Me.Dispose()


        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub


End Class



