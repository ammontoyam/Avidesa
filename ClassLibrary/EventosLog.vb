Option Explicit On
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.Common  ' Espacio que permite la conexion bilateral Acces o Sql
Imports System.IO
Imports System.Threading.Thread
Imports System.Text
Imports System.Collections.Generic

Public Module EventosLog
    'Tabla para manejo de eventos
    Public TablaEventos As Dictionary(Of String, String)


    Public Enum CodEvento As Integer
        BD_CREAR = 1000
        BD_BORRAR = 1001
        BD_MODIFICAR = 1002
        BD_REGYAEXISTE = 1003
        BD_REGELIMINAR = 1004
        BD_REGNOEXISTE = 1005
        BD_REGNOSELECCIONADO = 1006
        BD_REGFINALIZAR = 1007

        SISTEMA_INGRESO = 2000
        SISTEMA_SALIDA = 2001
        SISTEMA_BACKUP = 2002
        SISTEMA_PROCESOFINALIZADO = 2003
        SISTEMA_FALTACAMPO = 2004
        SISTEMA_ERROR = 2005
        SISTEMA_PROCESOCANCELADO = 2006
        SISTEMA_VALORINCORRECTO = 2007
        SISTEMA_FECHA = 2008
        SISTEMA_PROCESOCONFIRMACION = 2009
        SISTEMA_GUARDARCAMBIOS = 2010
        SISTEMA_CODIGORESERVADO = 2011
        SISTEMA_OPERACIONNOPERMITIDA = 2012
        SISTEMA_ALTERDATOS = 2013
        SISTEMA_FALTACONFIGURACION = 2014


        FUNCION_IMPORTAR = 3000
        FUNCION_TRASLADAR = 3001
        FUNCION_AJUSTES = 3002

        ARCHIVO_CREAR = 4000
        ARCHIVO_BORRAR = 4001
        ARCHIVO_MODIFICAR = 4002
        ARCHIVO_NOEXISTE = 4003

        USUARIO_PERMISODENEGADO = 5000
        USUARIO_EXISTENTE = 5001
        USUARIO_SEGURIDADCONTRASEÑA = 5002
        USUARIO_CLAVESNOCOINCIDEN = 5003
        USUARIO_CLAVEUSADA = 5004
        USUARIO_CLAVEMODIFICADA = 5005
        USUARIO_MODIFICARCLAVE = 5006
        USUARIO_MODIFICARPARAMETROSCLAVE = 5007

        INVENTARIO_CIERRE = 6000

        OP_FINALIZADA = 7000
        OP_FINPLANILLA = 7001
        OP_UMBRALSACKOFF = 7002
        OP_SINCONSUMOS = 7003
        OP_BACHESCOMPLETOS = 7004
        OP_BACHEREPORTADO = 7005
        OP_NOEXISTEPENDIENTE = 7006
        OP_VENTAS = 7007

        EMPAQUE_REGISTROAUTO = 8000
        EMPAQUE_REGPROCESADOCOSTOS = 8001
        EMPAQUE_REGAJUSTADO = 8002

        FORMULA_SELECCIONAROP = 9000
        FORMULA_NOELIMINAR = 9001
        FORMULA_DUPLICAR = 9002
        FORMULA_GUARDARERROR = 9003
        FORMULA_ERRORCODPREMEZCLA = 9004
        FORMULA_NOAPROBADA = 9005

        REPORTES_SELECCIONAROP = 10000
        REPORTES_OPFINPLANILLA = 10001





    End Enum





    Public Sub InicializaMensajesEventos()
        Try

            TablaEventos = New Dictionary(Of String, String)

            'LLenamos los mensajes de eventos que queremos almacenar en la tabla
            'Eventos base de datos
            TablaEventos.Add(CodEvento.BD_CREAR, "El registro ha sido creado ")
            TablaEventos.Add(CodEvento.BD_BORRAR, "El registro ha sido eliminado ")
            TablaEventos.Add(CodEvento.BD_MODIFICAR, "El registro ha sido modificado ")
            TablaEventos.Add(CodEvento.BD_REGYAEXISTE, "El registro ya existe, ¿desea modificarlo? ")
            TablaEventos.Add(CodEvento.BD_REGELIMINAR, "¿Seguro desea eliminar el registro? ")
            TablaEventos.Add(CodEvento.BD_REGNOEXISTE, "Registro no encontrado ")
            TablaEventos.Add(CodEvento.BD_REGNOSELECCIONADO, "No hay ningún registro seleccionado ")
            TablaEventos.Add(CodEvento.BD_REGFINALIZAR, "¿Seguro desea finalizar el registro? ")




            'Eventos de ingreso al sistema o formularios
            TablaEventos.Add(CodEvento.SISTEMA_INGRESO, "Ingreso al sistema ")
            TablaEventos.Add(CodEvento.SISTEMA_SALIDA, "Salida del sistema ")
            TablaEventos.Add(CodEvento.SISTEMA_BACKUP, "Se realiza copia de seguridad ")
            TablaEventos.Add(CodEvento.SISTEMA_PROCESOFINALIZADO, "Proceso finalizado ")
            TablaEventos.Add(CodEvento.SISTEMA_FALTACAMPO, "Falta diligenciar el campo ")
            TablaEventos.Add(CodEvento.SISTEMA_ERROR, "Error producido por ")
            TablaEventos.Add(CodEvento.SISTEMA_PROCESOCANCELADO, "Proceso cancelado por el usuario ")
            TablaEventos.Add(CodEvento.SISTEMA_VALORINCORRECTO, " Valor incorrecto para el campo ")
            TablaEventos.Add(CodEvento.SISTEMA_FECHA, "La Fecha Inicial no puede ser Superior o Igual a la Fecha Final")
            TablaEventos.Add(CodEvento.SISTEMA_PROCESOCONFIRMACION, "¿Seguro desea realizar la operación solicitada?")
            TablaEventos.Add(CodEvento.SISTEMA_GUARDARCAMBIOS, "¿ Desea guardar los cambios ?")
            TablaEventos.Add(CodEvento.SISTEMA_CODIGORESERVADO, " Código reservado para el sistema")
            TablaEventos.Add(CodEvento.SISTEMA_OPERACIONNOPERMITIDA, " No se puede realizar la operación solicitada")
            TablaEventos.Add(CodEvento.SISTEMA_ALTERDATOS, " Seguro desea alterar los datos ")
            TablaEventos.Add(CodEvento.SISTEMA_FALTACONFIGURACION, " Falta configuración ")

            'Funciones
            'Eventos de ingreso al sistema o formularios
            TablaEventos.Add(CodEvento.FUNCION_IMPORTAR, "Se ha realizado la importacion correctamente ")
            TablaEventos.Add(CodEvento.FUNCION_TRASLADAR, "Se ha realizado el traslado correctamente ")
            TablaEventos.Add(CodEvento.FUNCION_AJUSTES, "¿Está seguro de realizar un ajuste en ")

            'Eventos de archivos
            'Eventos de ingreso al sistema o formularios
            TablaEventos.Add(CodEvento.ARCHIVO_CREAR, "El archivo ha sido creado correctamente ")
            TablaEventos.Add(CodEvento.ARCHIVO_BORRAR, "El archivo ha sido borrado correctamente ")
            TablaEventos.Add(CodEvento.ARCHIVO_MODIFICAR, "El archivo ha sido modificado correctamente ")
            TablaEventos.Add(CodEvento.ARCHIVO_NOEXISTE, "El archivo no existe ")

            'Eventos de USUARIOS, PERMISOS
            TablaEventos.Add(CodEvento.USUARIO_PERMISODENEGADO, "No tiene permiso para ejecutar la acción solicitada")
            TablaEventos.Add(CodEvento.USUARIO_EXISTENTE, "El Usuario ya existe, desea sobrescribirlo")
            TablaEventos.Add(CodEvento.USUARIO_SEGURIDADCONTRASEÑA, "La contraseña no cumple con las condiciones de seguridad")
            TablaEventos.Add(CodEvento.USUARIO_CLAVESNOCOINCIDEN, "Claves no coinciden verifíquela e intentelo de nuevo")
            TablaEventos.Add(CodEvento.USUARIO_CLAVEUSADA, "La clave ya fue usada recientemente, debe cambiarla")
            TablaEventos.Add(CodEvento.USUARIO_CLAVEMODIFICADA, "La clave ha sido modificada satisfactoriamente")
            TablaEventos.Add(CodEvento.USUARIO_MODIFICARCLAVE, "Desea modificar la contraseña?")
            TablaEventos.Add(CodEvento.USUARIO_MODIFICARPARAMETROSCLAVE, "Seguro desea configurar los parametros de contraseñas?*")

            'Eventos de MANEJO DE INVENTARIO
            TablaEventos.Add(CodEvento.INVENTARIO_CIERRE, "Cierra inventario ")

            'Eventos de procesos especificos que se usan con frecuencia
            TablaEventos.Add(CodEvento.OP_FINALIZADA, " La OP está finalizada en producción ")
            TablaEventos.Add(CodEvento.OP_FINPLANILLA, " La OP está finalizada en planilla ")
            TablaEventos.Add(CodEvento.OP_UMBRALSACKOFF, " La OP supera el umbral de sack off ")
            TablaEventos.Add(CodEvento.OP_SINCONSUMOS, " La OP no registra consumos ")
            TablaEventos.Add(CodEvento.OP_BACHESCOMPLETOS, " Los baches a realizar no pueden superar la meta de la OP ")
            TablaEventos.Add(CodEvento.OP_BACHEREPORTADO, " El bache ya está completo o ya fue procesado, no se podrá realizar ninguna modificación ")
            TablaEventos.Add(CodEvento.OP_NOEXISTEPENDIENTE, " No existen OPs pendientes ")
            TablaEventos.Add(CodEvento.OP_VENTAS, " La OP es de ventas, no podrá ser habilitada para dosificar ")

            TablaEventos.Add(CodEvento.EMPAQUE_REGISTROAUTO, " Debe seleccionar un registro automático para realizar la operación ")
            TablaEventos.Add(CodEvento.EMPAQUE_REGPROCESADOCOSTOS, " Registro de empaque procesado por costos ")
            TablaEventos.Add(CodEvento.EMPAQUE_REGAJUSTADO, " El Registro de empaque ya ha sido ajustado, solo se debe hacer un ajuste por registro ")

            'Formulacion
            TablaEventos.Add(CodEvento.FORMULA_SELECCIONAROP, " Debe seleccionar una OP para imprimir el reporte específico ")
            TablaEventos.Add(CodEvento.FORMULA_NOELIMINAR, " La fórmula no se puede eliminar ya que se encuentra en proceso de producción, finalicela en el fórmulario de OPs o en Planilla y vuelva a intentar la eliminación ") 'Se encuentra sin finalizar o en producción o en planilla
            TablaEventos.Add(CodEvento.FORMULA_DUPLICAR, " Duplica fórmula ")
            TablaEventos.Add(CodEvento.FORMULA_GUARDARERROR, " La fórmula no puede ser almacenada,  por favor revise y vuelva a intentar guardarla")
            TablaEventos.Add(CodEvento.FORMULA_ERRORCODPREMEZCLA, " Falta parametrizar código de pre mezcla o no se encuentrá matriculado en la tabla de materiales ")
            TablaEventos.Add(CodEvento.FORMULA_NOAPROBADA, " La fórmula no se encuentra aprobada por calidad ")

            'Reportes
            TablaEventos.Add(CodEvento.REPORTES_SELECCIONAROP, " Debe seleccionar una OP para imprimir el reporte")
            TablaEventos.Add(CodEvento.REPORTES_OPFINPLANILLA, " La OP debe estar finalizada por planilla para la poder generar este reporte")

        Catch ex As Exception
            MsgError(ex)
        End Try
    End Sub

    Public Function DevuelveEvento(ByVal CodEvento As CodEvento, Optional ByVal Campo As String = "") As String
        Try
            DevuelveEvento = ""
            If CodEvento = 0 Then Return DevuelveEvento
            DevuelveEvento = TablaEventos(CodEvento).ToString + Campo
        Catch ex As Exception
            DevuelveEvento = ""
            Return DevuelveEvento
            MsgError(ex)
        End Try
    End Function

#Region "Logs de auditoría"

    Public Enum Accion As Integer
        CREAR = 1
        BORRAR = 2
        EDITAR = 3
        EDITADO = 4
        ENTRAR = 5
        DUPLICAR = 6
        SALIR = 7
    End Enum


    Public Sub EventoAuditoria(ByVal EventoAuditoria As String, Optional ByVal Modulo As Windows.Forms.Form = Nothing, Optional ByVal Accion As Accion = 5,
                                Optional ByVal Tabla As String = "-", Optional ByVal Campo As String = "-", Optional ByVal Valor As String = "-")

        Try

            Dim DEventosLog As AdoSQL
            DEventosLog = New AdoSQL("EVENTOSLOG")

            DEventosLog.Open("Select * from EVENTOSLOG where ID=0")

            DEventosLog.AddNew()
            DEventosLog.RecordSet("FECHA") = FechaC()
            DEventosLog.RecordSet("USUARIO") = UsuarioPrincipal
            If Modulo Is Nothing = False Then
                DEventosLog.RecordSet("MODULO") = Modulo.Name
            End If

            DEventosLog.RecordSet("ACCION") = Accion.ToString
            DEventosLog.RecordSet("TABLA") = Tabla
            DEventosLog.RecordSet("CAMPO") = Campo
            DEventosLog.RecordSet("VALOR") = Valor
            DEventosLog.RecordSet("NOMBREPC") = NombrePC
            DEventosLog.RecordSet("IP") = DireccionIP
            DEventosLog.RecordSet("DETALLE") = CLeft(EventoAuditoria, 1000)

            DEventosLog.Update()

        Catch ex As Exception
            MsgError(ex)
        End Try

    End Sub

#End Region


End Module

