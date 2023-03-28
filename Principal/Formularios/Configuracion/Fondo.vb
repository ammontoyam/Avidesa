Imports System.Windows.Forms
Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading.Thread
Imports System.IO
Imports System.Data.Common
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports ClassLibrary

Public Class Fondo
    Protected currentGradientShift As Integer = 10
    Protected gradiantStep As Integer = 5
    Private Cont As Double
    Private DTmuertos As AdoSQL
    Private DVarios As AdoSQL

    Private DOPs As AdoSQL
    Private DBaches As AdoSQL
    Private DConsumos As AdoSQL
    Private DEmpaque As AdoSQL
    Private DFor As AdoSQL
    Private DDatosFor As AdoSQL
    Private DTurnos As AdoSQL
    Private DProgSatelite As AdoSQL
    Private DConexWS As AdoSQL

    Private PedirUsuario As Boolean
    Private Hora As String
    Private HoraIniTurno(3) As String


    Private SentenciaPeso As String

    Private Sub Inactividad()
        Try
            'Set currentForm variable to the current instance of the Form class.

            Dim ActiveControl As Control = Nothing
            'Set currentForm variable to the current instance of the Form class.
            Static PrevControlName As String
            Static PrevFormName As String
            Static ExpiredTime As Int32
            Const IDLEMINUTES = 20

            ' MsgBox(ActiveForm.Name)
            Dim ExpiredMinutes As Int32

            If Application.OpenForms.Count = 0 Then Return

            Dim ActiveForm As Form = Application.OpenForms.Item(Application.OpenForms.Count - 1)

            ActiveControl = ActiveForm.ActiveControl
            If Not ActiveForm Is Nothing AndAlso ActiveControl Is Nothing Then
                ExpiredTime = ExpiredTime + 10
            ElseIf (PrevControlName = "") Or (PrevFormName = "") Or (ActiveForm.Name <> PrevFormName) _
            Or (ActiveControl.Name <> PrevControlName) Then
                PrevControlName = ActiveControl.Name
                PrevFormName = ActiveForm.Name
                ExpiredTime = 0
            Else
                ' ...otherwise the user was idle during the time interval, so
                ' increment the total expired time.
                ExpiredTime = ExpiredTime + 10
            End If

            'Does the total expired time exceed the IDLEMINUTES?
            ExpiredMinutes = ExpiredTime / 60
            If ExpiredMinutes >= IDLEMINUTES Then
                ' ...if so, then reset the expired time to zero...
                ExpiredTime = 0

                For Each AF As Form In Application.OpenForms
                    If UCase(AF.Name) = "FONDO1" Or (InStr(AF.Name, "Form")) Then Continue For
                    AF.Close()
                Next

                If Acceso.Visible = False Then Acceso.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub mnMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMateriales.Click
        Try
            'If DRUsuario("MatPVer") Then 'Or DRUsuario("MatPMod") Then
            If ValidaPermiso("Materiales_Ver, Materiales_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Materiales.ShowDialog()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub Fondo1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        UsuariosLog("Sale de ChronoSoft", "Ingresos", "")
        End
    End Sub

    Private Sub Fondo1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Acceso.ShowDialog()
        DTmuertos = New AdoSQL("TMUERTOS")
        DVarios = New AdoSQL("VARIOS")
        DOPs = New AdoSQL("OPS")
        DBaches = New AdoSQL("BACHES")
        DConsumos = New AdoSQL("CONSUMOS")
        DEmpaque = New AdoSQL("EMPAQUE")
        DFor = New AdoSQL("FORMULAS")
        DDatosFor = New AdoSQL("DATOSFOR")
        DTurnos = New AdoSQL("TURNOS")
        DConexWS = New AdoSQL("CONEXIONWSARTIC")
        DProgSatelite = New AdoSQL("PROGRAMASSATELITE")
        DProgSatelite.Open("Select * from PROGRAMASSATELITE")

        DTurnos.Open("Select * from TURNOS")

        'Hacemos un recorrido por 3 turnos, deben haber 3 en la base de datos
        For i = 1 To 3
            DTurnos.Find("TURNO=" + i.ToString)
            If Not DTurnos.EOF Then HoraIniTurno(i) = DTurnos.RecordSet("HORAINI")
        Next

        'Revisa para la primera vez que se corre la interfaz de consumos si existen estos campos, sino los crea.



    End Sub

    Private Sub BSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSalir.Click
        Try
            Evento(DevuelveEvento(CodEvento.SISTEMA_SALIDA, " ChronoSoft"))
            EventoAuditoria(DevuelveEvento(CodEvento.SISTEMA_SALIDA), Me, Accion.SALIR)
            End
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUsuarios.Click
        Try
            'If DRUsuario("UsuaMod") Then
            If ValidaPermiso("Usuarios_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Usuarios.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnBaseDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBaseDatos.Click
        Try
            'If DRUsuario("Config") Then
            If ValidaPermiso("Configuracion") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            RespInput = ""
            If InputBox.InputBox("Acceso", "Dígite la clave de acceso", RespInput, False) <> DialogResult.OK Then Return
            If ValidaClave(RespInput) = False Then
                MsgBox("Clave de acceso no válida", MsgBoxStyle.Information)
                Return
            End If
            BasedeDatos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnClientes.Click
        Try
            If ValidaPermiso("Clientes_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Clientes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCortesMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCortesMP.Click
        Try
            'If DRUsuario("CortesMP") Then
            If ValidaPermiso("CortesMP_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            CortesMP.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDetalleBache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDetalleBache.Click
        Try
            'If DRUsuario("RepMod") Then
            If ValidaPermiso("Reportes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            DetBache.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnRepBacManu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepBacManu.Click
        Try
            'If DRUsuario("RepBacheMan") Or DRUsuario("RepPremezclas") Then
            If ValidaPermiso("ReportarBacheManual, ReportarPremezclas") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            EntraBache.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnRepIngManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepIngManual.Click
        Try
            'If DRUsuario("RepMod") Then
            If ValidaPermiso("Reportes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            EntraConsumos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub BFormulación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFormulación.Click
        Try
            'If DRUsuario("FormMod") Or DRUsuario("FormModDosif") Or DRUsuario("Calidad") Then
            If ValidaPermiso("Formulas_Ver, Formulas_EditarBasculas, Calidad") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Formulacion.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BMateriaPrimNec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMateriaPrimNec.Click
        Try
            'If DRUsuario("CalcMPNec") Then
            If ValidaPermiso("MPNecesaria_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            MPrimaNec.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnProgramasSatelite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnProgramasSatelite.Click
        Try
            For Each Fila As DataRow In DProgSatelite.Rows

                If ProgramaEjecutandose(Fila("PROGRAMA")) = False Then AbreProgramaSatelite(Fila("PROGRAMA"))
                ''Sleep(30)
            Next

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReportes.Click
        Try
            'If DRUsuario("RepVer") Then
            If ValidaPermiso("Reportes_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Reportes.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOP.Click
        Try
            If ValidaPermiso("OPs_Ver, OPs_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            NuevaOP.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub TimSeg_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimSeg.Tick
        Try
            Cont = Cont + 1
            If Cont > 100000 Then Cont = 1
            If Cont Mod 10 = 0 Then
                If File.Exists(Ruta + "a") = True Then
                    Evento(DevuelveEvento(CodEvento.SISTEMA_SALIDA) + " por archivo a", Me)
                    BSalir_Click(Nothing, Nothing)
                End If
                If Not ServComM And Funcion_InactividadChronoSoft Then Inactividad()
            End If
            Application.DoEvents()

            'Se abren los programas satelites cada 10 minutos para no esta revisando la base de datos con mucha frecuencia
            'o cuando recien se ingresó al programa
            If Cont Mod 600 = 0 Or Cont = 2 Then
                mnProgramasSatelite_Click(Nothing, Nothing)
            End If

            If ServComM = True AndAlso Cont Mod 60 = 0 Then
                DTmuertos.Open("Select * from TMUERTOS where CODMOTIVO='0'")
                If DTmuertos.Count > 0 Then
                    If TMuertos.Visible = False Then TMuertos.Show()
                End If
                'Si se hacen baches de ventas
                If Funcion_BachesOpsVentas Then BBachesVentas_Click(Nothing, Nothing)
            End If

            If ServCHR = True AndAlso Cont Mod 60 = 0 Then
                'Se realiza el reset de la tabla COMPARATIVOINV, campor InvFisio e InvUno
                'Para los tipos AD,MP,EM,ET,PR se reinicia a las 0 horas
                If Now.Hour = 0 Then
                    If ReadFechasCierre("MP", ClaseFecha.ULTRESET) <> Format(Now, "yyyy/MM/dd") Then
                        DVarios.Open("Update COMPARATIVOINV set INVFISICO=0,INVUNO=0 WHERE TIPO IN('MP','AD','EM','ET','PR')")
                        WriteFechasCierre("MP", Format(Now, "yyyy/MM/dd"), ClaseFecha.ULTRESET)
                    End If
                End If
            End If



            'Pedido de usuario por cambio de turno
            If ServComM = True Then

                Hora = Format(Now, "HH:mm")

                For i = 1 To 3
                    If Hora = HoraIniTurno(i) And (Minute(Now) < 5 Or Minute(Now) > 0) Then
                        If PedirUsuario Then
                            PedirUsuario = False
                            Acceso.LCambTurno.Visible = True
                            Acceso.ShowDialog()
                        ElseIf Acceso.Visible = False Then
                            PedirUsuario = True
                        End If
                    End If
                Next

                Hora = Format(Now, "HH:mm:ss")

                'Ejecuta el programa de Interfaz de Matriales que descarga los códigos desde el ERP a la tabla de Articulos de Chr

                DConexWS.Open("select * from ConexionWSArtic where CAMPO='HoraAuto'")
                If DConexWS.Count Then

                    If Hora = DConexWS.RecordSet("VALOR") Then
                        If File.Exists(Ruta + "ChrInterfazArt.EXE") Then
                            Resp = Shell(Ruta + "ChrInterfazArt.EXE", AppWinStyle.MinimizedFocus)
                        End If
                    End If
                End If
            End If


        Catch Ex As FileNotFoundException
            Evento("Programa " + Ex.FileName + " no encontrado")
        Catch ex As Exception
            MsgError(ex)
        End Try
        'AnimacionChr()
    End Sub

    Private Sub mnCambioUsua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCambioUsua.Click
        Acceso.ShowDialog()
    End Sub

    Private Sub mnFormulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnFormulacion.Click
        BFormulación_Click(Nothing, Nothing)
    End Sub

    Private Sub mnCortesMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCortesMP.Click
        BCortesMP_Click(Nothing, Nothing)
    End Sub

    Private Sub mnSalirApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSalirApp.Click
        BSalir_Click(Nothing, Nothing)
    End Sub

    Private Sub mnAcercaD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnAcercaD.Click
        AcercaD.ShowDialog()
    End Sub

    Private Sub BProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BProductos.Click
        Try
            'If DRUsuario("ProdVer") Or DRUsuario("ProdMod") Then
            If ValidaPermiso("Productos_Ver, Productos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Productos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnOrdeProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnOrdeProd.Click
        BOP_Click(Nothing, Nothing)
    End Sub


    Private Sub BAlarma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAlarma.Click
        Try
            Process.Start(Ruta + "Alarmas.exe")
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Sub CódigosEmpaqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCodEmpEt.Click
        TablaEmpaques.ShowDialog()
    End Sub

    Private Sub mnBackupDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBackupDB.Click
        Dim Sentencia As String = ""
        Dim RutaBackup As String

        If ServComM Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If

        Try

            RutaBackup = ReadConfigVar("RUTABACKUPSQL")
            If RutaBackup <> "" Then


                RutaBackup += NomDB + ".bak"



                Sentencia += "BACKUP DATABASE [" + NomDB.Trim + "]" + vbNewLine
                Sentencia += "TO  DISK = N'" + RutaRep + "Backup\" + NomDB + ".bak '" + vbNewLine
                Sentencia += "WITH NOFORMAT, NOINIT," + vbNewLine
                Sentencia += "Name = N'Backup " + NomDB.Trim + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10" + vbNewLine
                Sentencia += "GO" + vbNewLine



                WriteFile(Ruta + "Backup.txt", Sentencia, False)

                'Generamos el script del Backup.bat

                Sentencia = ""

                If File.Exists(RutaBackup) Then File.Delete(RutaBackup)
                If File.Exists(RutaRep + "Backup\" + NomDB + ".bak") Then File.Delete(RutaRep + "Backup\" + NomDB + ".bak")


                Sentencia = Sentencia + "SqlCmd -S " + ServidorSQL.Trim + " -U " + UserDB + " -P " + PWD + " -i " + Ruta + "Backup.txt" + vbCrLf
                Sentencia = Sentencia + "copy " + RutaRep + "Backup\" + NomDB + ".bak" + " " + RutaBackup

                WriteFile(Ruta + "Backup.bat", Sentencia, False)

                Dim ProcesoBackup As New ProcessStartInfo(Ruta + "Backup.bat")

                ProcesoBackup.WindowStyle = ProcessWindowStyle.Minimized
                Process.Start(ProcesoBackup)
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BEmpMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEmpMan.Click
        'If DRUsuario("EmpMod") Then
        If ValidaPermiso("Empaque_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        EmpaqueMan.ShowDialog()
    End Sub


    Private Sub mnRepor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepor.Click
        BReportes_Click(Nothing, Nothing)
    End Sub
    Private Sub mnBasculas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBasculas.Click
        TablaBasculas.ShowDialog()
    End Sub

    Private Sub BAceptarEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAceptarEmp.Click
        'If DRUsuario("RecEmp") = True Then
        If ValidaPermiso("RecibeEmpaqueAlmacen,Calidad,RecibeEmpaqueProduccion") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        RecibePT.ShowDialog()
    End Sub

    Private Sub BRetaque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRetaque.Click
        'If DRUsuario("RETAQUE") Then
        If ValidaPermiso("Retaque") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), vbInformation)
            Return
        End If
        Retaque.ShowDialog()
    End Sub

    Private Sub BTolvas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTolvas.Click
        Try
            If ValidaPermiso("Tolvas_Ver,Tolvas_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), vbInformation)
                Return
            End If
            Tolvas.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BSolictudCargue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSolictudCargue.Click
        Try
            'If DRUsuario("SolicVaceo") Then
            If ValidaPermiso("SolicitudVaceo") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            SolictudCargue.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BCargueMan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCargueMan.Click
        Try
            'If DRUsuario("CargueTolvas") Then
            If ValidaPermiso("Tolvas_Cargue") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            If Funcion_ConexionSigCoPro Then
                Resp = Shell(Ruta + "CHRRETAQUEMANUAL.EXE" + " " + UsuarioPrincipal)
            Else
                CargueMan.ShowDialog()
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BInventarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BInventarios.Click
        Try
            'If DRUsuario("VerRepInv") Then
            If ValidaPermiso("ReportesInventario_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Inventarios.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnUbicaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnUbicaciones.Click
        Try
            Ubicaciones.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnCambNombreServ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCambNombreServ.Click
        Try
            'If DRUsuario("CONFIG") Then
            If ValidaPermiso("Configuracion") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), vbInformation)
                Return
            End If

            RespInput = ConfigParametros("ServidorComunicaciones")

            InputBox.InputBox("Cambiar nombre Servidor Comunicaciones ChronoSoft", "Ingrese el nombre del servidor, tal como aparece el nombre del equipo", RespInput)

            If RespInput = "" Then
                MsgBox("Cadena no válida, no se realizó ningún cambio", MsgBoxStyle.Critical)
                Return
            End If

            WriteConfigParametros("ServidorComunicaciones", RespInput.ToUpper)

            If ConfigParametros("ServidorComunicaciones") = RespInput.ToUpper Then
                MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BPlanillla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPlanillla.Click
        Try
            'If DRUsuario("EmpMod") Or DRUsuario("OPsVer") Or DRUsuario("OPsMod") Then
            If ValidaPermiso("Planilla_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Planilla.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub mnProduc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnProduc.Click
        Productos.ShowDialog()
    End Sub


    Private Sub mnRestaurarCopiaDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRestaurarCopiaDB.Click
        Try

            If ServComM Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim DVarios As AdoSQL
            Dim Sentencia As String
            Dim RutaBackup As String
            Dim ServBackup As String

            DVarios = New AdoSQL("VARIOS")

            If File.Exists(Ruta + "Restore.txt") Then File.Delete(Ruta + "Restore.txt")
            If File.Exists(Ruta + "Restore.bat") Then File.Delete(Ruta + "Restore.bat")

            RutaBackup = ReadConfigVar("RUTABACKUPSQL")

            If RutaBackup = "" Then
                MsgBox("Configuración de destino no válida, favor llamar a soporte", vbInformation)
                Return
            End If

            'Generamos el archivo Restore.txt

            Sentencia = ""

            Sentencia = "USE MASTER" + vbCrLf
            Sentencia = Sentencia + "RESTORE DATABASE [" + NomDB + "]" + vbCrLf
            Sentencia = Sentencia + "FROM  DISK = N'" + RutaBackup + NomDB + ".bak'" + vbCrLf
            '        Sentencia = Sentencia + "TO  DISK = N'" + RutaBackup + NomBD + ".bak'" + vbCrLf
            Sentencia = Sentencia + "WITH  FILE = 1,  NOUNLOAD, STATS = 10" + vbCrLf
            Sentencia = Sentencia + "GO" + vbCrLf

            WriteFile(Ruta + "Restore.txt", Sentencia, False)

            'Generamos el archivo Restore.bat


            Sentencia = ""


            ServBackup = ReadConfigVar("SERVBACKUPSQL")


            If ServBackup = "" Then
                MsgBox("Configuración de servidor destino no válida, favor llamar a soporte", vbInformation)
                Return
            End If

            Sentencia = "SqlCmd -S " + ServBackup + " -U " + UserDB + " -P " + PWD + " -i " + Ruta + "Restore.txt"

            WriteFile(Ruta + "Restore.bat", Sentencia, False)

            RespInput = Shell(Ruta + "Restore.bat", vbNormalFocus)

            Evento("Restaura copia de seguridad base de datos SQL en PC Contingencia")

            MsgBox("La restauración de la BD se ha realizado con éxito", vbInformation)

            Exit Sub

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BDespachos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDespachos.Click

        Try
            'If DRUsuario("Despachos") Then
            If ValidaPermiso("Despachos") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Despachos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BProgProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BProgProd.Click
        Try
            'If DRUsuario("ProgProduccion") Then
            If ValidaPermiso("ProgramaProduccion") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            ProgramaProd.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnRepInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRepInv.Click
        Try
            'If DRUsuario("VerRepInv") Then
            If ValidaPermiso("ReportesInventario_Ver") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            ReportesInv.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BReportesInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReportesInv.Click
        'If DRUsuario("VerRepInv") Then
        If ValidaPermiso("ReportesInventario_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        DetalleInv.ShowDialog()
    End Sub

    Private Sub BControlDiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BControlDiario.Click
        Try
            'If DRUsuario("ModControlDiario") Then
            If ValidaPermiso("ControlDiario_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            ControlDiario.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnLineasPlanta_Click(sender As System.Object, e As System.EventArgs) Handles mnLineasPlanta.Click
        TablaLineasProd.ShowDialog()
    End Sub

    Private Sub BResInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BResInv.Click
        'If DRUsuario("VerInvMP") OrElse DRUsuario("VerInvPT") OrElse DRUsuario("VerInvAD") OrElse DRUsuario("VerInvPR") _
        '    OrElse DRUsuario("VerInvEM") OrElse DRUsuario("VerInvET") Then
        If ValidaPermiso("InventarioMP_Ver, InventarioPT_Ver, InventarioAD_Ver, InventarioPR_Ver, InventarioEM_Ver, InventarioET_Ver") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        ComparativoInv.ShowDialog()
    End Sub

    Private Sub BDetBacheMic_Click(sender As System.Object, e As System.EventArgs) Handles BDetBacheMic.Click
        Try
            'If DRUsuario("RepMod") Then
            If ValidaPermiso("Reportes_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            DetBacheMic.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub


    Private Sub BBachesVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBachesVentas.Click
        Try
            'Función que revisa las ops de ventas y les crea consumos tericos para que el sackoff=0

            SentenciaPeso = "Peso+Residuo+PesoAjuste+(Reproceso+SacosNC)*PresKg"
            Dim Cont As Int64 = 0
            Dim PesoTot As Double = 0


            'Primero se abren todas las ops que se estan empacando

            DOPs.Open("Select * from OPs where FINPLANILLA<>'S' and VENTAS=15 order by OP")

            For Each RsOPs As DataRow In DOPs.Rows

                DEmpaque.Open("Select sum(" + SentenciaPeso + ") as PESOTOT, min(FECHAINI) as FECHA FROM EMPAQUE where MAQUINA<100 and OP='" + RsOPs("OP") + "'")

                If IsDBNull(DEmpaque.RecordSet("PESOTOT")) Then Continue For
                If IsDBNull(DEmpaque.RecordSet("FECHA")) Or DEmpaque.RecordSet("FECHA").ToString.Length < 4 Then Continue For
                PesoTot = DEmpaque.RecordSet("PESOTOT")
                'Creamos el bache si no existe

                Cont = Val(ReadConfigVar("ConsecBacheVentas")) + 1

                DBaches.Open("Select * from BACHES where CONT=" + Cont.ToString)

                Do While DBaches.Count > 0
                    Cont += 1
                    DBaches.Open("Select * from BACHES where CONT=" + Cont.ToString)
                Loop

                DBaches.Open("Select * from BACHES where BACHE=1 and OP='" + RsOPs("OP") + "'")

                If DBaches.Count = 0 Then
                    Evento("CREA BACHE VENTAS CONT: " + Cont.ToString)

                    DBaches.AddNew()

                    DBaches.RecordSet("OP") = RsOPs("OP")
                    DBaches.RecordSet("CONT") = Cont
                    DBaches.RecordSet("CODFOR") = RsOPs("CODFOR")
                    DBaches.RecordSet("NOMFOR") = RsOPs("NOMFOR")
                    DBaches.RecordSet("FECHA") = DEmpaque.RecordSet("FECHA")
                    DBaches.RecordSet("BACHEAUTOMATICO") = 0


                    'DFor.Open("Select * from FORMULAS where CODFOR='" + RsOPs("CODFOR") + "' and LP='" + RsOPs("LP") + "'")

                    'If DFor.Count > 0 Then
                    '    DBaches.RecordSet("PESOMETA") = DFor.RecordSet("TOTALFOR")
                    '    DBaches.RecordSet("PESOREAL") = DFor.RecordSet("TOTALFOR")
                    'End If

                    DBaches.RecordSet("PRODUCTO") = RsOPs("CODPROD")
                    DBaches.RecordSet("BACHESMETA") = RsOPs("META")
                    DBaches.RecordSet("FACTOR") = RsOPs("PORC")
                    DBaches.RecordSet("USUARIO") = CLeft(UsuarioPrincipal, 20)
                    DBaches.RecordSet("LP") = RsOPs("LP")
                    DBaches.RecordSet("LINEA") = RsOPs("LINEA")
                    DBaches.RecordSet("LINEAINVENT") = RsOPs("LINEAINVENT")
                    DBaches.RecordSet("BACHE") = 1
                    DBaches.RecordSet("ESTADO") = 10
                    DBaches.RecordSet("PESOMETA") = PesoTot
                    DBaches.RecordSet("PESOREAL") = PesoTot
                    DBaches.Update()

                    WriteConfigVar("ConsecBacheVentas", Cont.ToString)

                    DVarios.Open("Update OPS set FINALIZADO='S',REAL=" + RsOPs("META").ToString + " where OP='" + RsOPs("OP") + "'")
                End If

                DBaches.Refresh()

                'Se actualiza el consumo

                DConsumos.Open("Select * from CONSUMOS where CONT=" + DBaches.RecordSet("CONT").ToString)

                If DConsumos.Count = 0 Then

                    DConsumos.AddNew()

                    DConsumos.RecordSet("CONT") = DBaches.RecordSet("CONT")
                    DConsumos.RecordSet("ALARMAS") = 500
                    DConsumos.RecordSet("CodFor") = RsOPs("CODFOR")


                    DDatosFor.Open("Select * from DATOSFOR where CODFOR='" + RsOPs("CODFOR") + "' AND LP='" + RsOPs("LP") + "'")

                    If DDatosFor.Count = 1 Then
                        DConsumos.RecordSet("CodForB") = DDatosFor.RecordSet("CODFORB")
                        DConsumos.RecordSet("CodMat") = DDatosFor.RecordSet("CODMAT")
                        DConsumos.RecordSet("CodMatB") = DDatosFor.RecordSet("CODMATB")
                        DConsumos.RecordSet("NOMMAT") = DDatosFor.RecordSet("NOMMAT")
                        DConsumos.RecordSet("PESOREAL") = PesoTot
                        'DConsumos.RecordSet("PesoMeta") = DDatosFor.RecordSet("PESOMETA") * RsOPs("META")
                        DConsumos.RecordSet("PESOMETA") = PesoTot
                        DConsumos.RecordSet("TIPOMAT") = DDatosFor.RecordSet("TIPOMAT")
                    End If

                    DConsumos.Update()

                Else

                    If DConsumos.RecordSet("PESOREAL") < PesoTot Then
                        DConsumos.RecordSet("PESOREAL") = PesoTot
                        DConsumos.RecordSet("PESOMETA") = PesoTot

                        DConsumos.Update()

                        DVarios.Open("Update BACHES set PESOMETA=" + PesoTot.ToString + ",PESOREAL=" + PesoTot.ToString + " where CONT=" + DBaches.RecordSet("CONT").ToString)
                    End If
                End If

            Next RsOPs


            'Se busca el consumo total cuando la OP este vacia para actualizar el corte de MP si está abierto
            DOPs.Open("Select * from OPs where VENTAS=15 and FINPLANILLA='S' order by OP ")

            For Each RsOPFinPlanilla As DataRow In DOPs.Rows

                DBaches.Open("Select * from BACHES where BACHE=1 and OP='" + RsOPFinPlanilla("OP") + "'")

                If DBaches.Count Then

                    DConsumos.Open("Select * from CONSUMOS where CONT=" + DBaches.RecordSet("CONT").ToString)

                    'Descontamos al corte de MP
                    If DConsumos.Count Then
                        CortesLote(DConsumos.RecordSet("CODMATB").ToString, DConsumos.RecordSet("PESOREAL"), LoteCortesMP, ContCortesMP, UbicLoteMP)
                        If LoteCortesMP <> "" AndAlso ContCortesMP <> "" Then
                            DConsumos.RecordSet("CORTELOTE") = ContCortesMP
                            DConsumos.RecordSet("Lote") = LoteCortesMP
                            Evento("Actualiza corte MP por OP ventas codmat:" + DConsumos.RecordSet("CODMATB").ToString + " cont: " + ContCortesMP)
                        End If

                        DConsumos.Update()

                    End If

                End If

                DVarios.Open("UPDATE OPS set VENTAS=20 where OP='" + RsOPFinPlanilla("OP") + "'")

            Next RsOPFinPlanilla
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub BProgEmpaque_Click(sender As System.Object, e As System.EventArgs) Handles BProgEmpaque.Click
        'If DRUsuario("EmpMod") Or DRUsuario("OPsVer") Or DRUsuario("OPsMod") Then
        If ValidaPermiso("Empaque_Editar, OPs_Ver, OPs_Editar") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        ProgEmpaque.ShowDialog()
    End Sub


    Private Sub mnCambiarClave_Click(sender As System.Object, e As System.EventArgs) Handles mnCambiarClave.Click
        Acceso.ShowDialog()
        UsuariosClave.TUsuario.Text = UsuarioPrincipal
        UsuariosClave.ShowDialog()
    End Sub

    Private Sub BSilos_Click(sender As Object, e As EventArgs) Handles BSilos.Click
        Try
            'If DRUsuario("SilosMod") Or DRUsuario("SilosVer") Then
            If ValidaPermiso("Silos_Ver, Silos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            Silos.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BAuditoria_Click(sender As Object, e As EventArgs) Handles BAuditoria.Click
        Try
            'If DRUsuario("AditoriaLogs") Then
            If ValidaPermiso("Auditoria_Ver") Then
            Else
                MsgBox("No tiene permiso para ejecutar la acción solicitada", MsgBoxStyle.Information)
                Exit Sub
            End If
            'EventoAuditoria(Usuario, IntFaz_Proceso.AUDITORIA, IntFaz_Accion.INGRESO)
            Auditoria.ShowDialog()

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub BRecPremezclas_Click(sender As Object, e As EventArgs) Handles BRecPremezclas.Click
        'If DRUsuario("RecEmp") = True Then
        If ValidaPermiso("RecibeEmpaqueAlmacen") Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        RecPremezclas.ShowDialog()
    End Sub
    Private Sub mnEquivFormProd_Click(sender As Object, e As EventArgs) Handles mnEquivFormProd.Click
        Try
            If ValidaPermiso("Formulas_Editar, Calidad, Productos_Editar") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If
            EquivFormProd.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

    Private Function ProgramaEjecutandose(ByVal NombrePrograma As String) As Boolean
        Dim Procesos As Process()
        Dim myprocess As Process
        Try

            NombrePrograma = NombrePrograma.ToUpper
            'Se quita la extension .exe
            NombrePrograma = CLeft(NombrePrograma, InStr(1, NombrePrograma, ".EXE") - 1).ToUpper
            ProgramaEjecutandose = False
            Procesos = Process.GetProcesses()
            Dim proclength As Integer
            For proclength = 0 To Procesos.Length - 1
                myprocess = Procesos(proclength)
                If NombrePrograma = myprocess.ProcessName.ToUpper Then
                    ProgramaEjecutandose = True
                    Return ProgramaEjecutandose
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Sub ImportarUsuariosPrimeraVezToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarUsuariosPrimeraVezToolStripMenuItem.Click
        Try

            RespInput = ""
            If InputBox.InputBox("Acceso", "Dígite la clave de acceso", RespInput, False) <> DialogResult.OK Then Return
            If ValidaClave(RespInput) = False Then
                MsgBox("Clave de acceso no válida", MsgBoxStyle.Information)
                Return
            End If

            Dim DUsuariosDetalle As AdoSQL
            Dim DUsuariosPermisos As AdoSQL

            DUsuariosDetalle = New AdoSQL("USUARIOSDETALLE")
            DUsuariosPermisos = New AdoSQL("USUARIOSDETALLE")


            DUsuariosDetalle.Open("select * from USUARIOSDETALLE ")
            DUsuariosPermisos.Open("select * from USUARIOSPERMISOS")

            For Each regPermiso As DataRow In DUsuariosPermisos.Rows
                If regPermiso("PERMISOANTERIOR") = "-" Or regPermiso("PERMISOANTERIOR") = "" Then Continue For

                DVarios.Open("select USUARIO," + regPermiso("PERMISOANTERIOR") + " from USUARIOS")

                For Each regDvarios As DataRow In DVarios.Rows
                    If regDvarios(regPermiso("PERMISOANTERIOR")) = False Then Continue For
                    DUsuariosDetalle.AddNew()
                    DUsuariosDetalle.RecordSet("USUARIO") = regDvarios("USUARIO")
                    DUsuariosDetalle.RecordSet("PERMISO") = regPermiso("PERMISO")
                    'DUsuariosDetalle.RecordSet("ACTIVO") = regDvarios(regPermiso("PERMISOANTERIOR"))
                    DUsuariosDetalle.Update()

                Next
            Next

            MsgBox(DevuelveEvento(CodEvento.SISTEMA_PROCESOFINALIZADO), vbInformation)

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub mnConfigCentralBascula_Click(sender As Object, e As EventArgs) Handles mnConfigCentralBascula.Click
        Try
            If ValidaPermiso("Configuracion") Then
            Else
                MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
                Exit Sub
            End If

            ConfigCentralBascula.ShowDialog()
        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Private Sub DatosHoraHoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosHoraHoraToolStripMenuItem.Click
        If ValidaFuncionalidad("DatosHora.SCP", NombrePC) Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        If ServComM = False And Fuentes = False Then
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If
        DatosHora.ShowDialog()
    End Sub

    Private Sub mnDatosEngrasadores_Click(sender As Object, e As EventArgs) Handles mnDatosEngrasadores.Click
        If ServComM And Funcion_DatosEngrasadores Then
        Else
            MsgBox(DevuelveEvento(CodEvento.USUARIO_PERMISODENEGADO), MsgBoxStyle.Information)
            Exit Sub
        End If

        DatosEngrasadores.ShowDialog()

    End Sub
End Class
