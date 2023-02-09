
--Tablas Nuevas
--CONFIGPARAMETROS

CREATE TABLE [dbo].[ConfigParametros](
 [ID] [smallint] IDENTITY(1,1) NOT NULL,
 [Formulario] [varchar](30) NOT NULL,
 [Parametro] [varchar](30) NOT NULL,
 [Valor] [varchar](50) NOT NULL,
 [Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ConfigParametros] PRIMARY KEY CLUSTERED 
(
 [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConfigParametros] ADD  CONSTRAINT [DF_ConfigParametros_Formulario]  DEFAULT ('-') FOR [Formulario]
GO

ALTER TABLE [dbo].[ConfigParametros] ADD  CONSTRAINT [DF_ConfigParametros_Parametro]  DEFAULT ('-') FOR [Parametro]
GO

ALTER TABLE [dbo].[ConfigParametros] ADD  CONSTRAINT [DF_ConfigParametros_Valor]  DEFAULT ('-') FOR [Valor]
GO

ALTER TABLE [dbo].[ConfigParametros] ADD  CONSTRAINT [DF_ConfigParametros_Descripcion]  DEFAULT ('-') FOR [Descripcion]
GO

--CONEXIONESEXT
CREATE TABLE [dbo].[ConexionesExt](
 [ID] [smallint] IDENTITY(1,1) NOT NULL,
 [Sistema] [varchar](30) NOT NULL,
 [CadenaConexion] [varchar](200) NOT NULL,
 [Servidor] [varchar](30) NOT NULL,
 [Tipo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ConexionesExt] PRIMARY KEY CLUSTERED 
(
 [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConexionesExt] ADD  CONSTRAINT [DF_ConexionesExt_Sistema]  DEFAULT ('-') FOR [Sistema]
GO

ALTER TABLE [dbo].[ConexionesExt] ADD  CONSTRAINT [DF_ConexionesExt_CadenaConexion]  DEFAULT ('-') FOR [CadenaConexion]
GO

ALTER TABLE [dbo].[ConexionesExt] ADD  CONSTRAINT [DF_ConexionesExt_Servidor]  DEFAULT ('-') FOR [Servidor]
GO

ALTER TABLE [dbo].[ConexionesExt] ADD  CONSTRAINT [DF_ConexionesExt_Tipo]  DEFAULT ('SQL') FOR [Tipo]
GO

--CONFIGFUNCIONALIDADES

CREATE TABLE [dbo].[ConfigFuncionalidades](
 [ID] [int] IDENTITY(1,1) NOT NULL,
 [Formulario] [varchar](30) NOT NULL,
 [Funcion] [varchar](100) NOT NULL,
 [Descripcion] [varchar](100) NOT NULL,
 [Activa] [bit] NOT NULL,
 [SesionoNombrePC] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ConfigFuncionalidades] PRIMARY KEY CLUSTERED 
(
 [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConfigFuncionalidades] ADD  CONSTRAINT [DF_ConfigFuncionalidades_Formulario]  DEFAULT ('-') FOR [Formulario]
GO

ALTER TABLE [dbo].[ConfigFuncionalidades] ADD  CONSTRAINT [DF_ConfigFuncionalidades_Funcion]  DEFAULT ('-') FOR [Funcion]
GO

ALTER TABLE [dbo].[ConfigFuncionalidades] ADD  CONSTRAINT [DF_ConfigFuncionalidades_Descripcion]  DEFAULT ('-') FOR [Descripcion]
GO

ALTER TABLE [dbo].[ConfigFuncionalidades] ADD  CONSTRAINT [DF_ConfigFuncionalidades_Activa]  DEFAULT ((0)) FOR [Activa]
GO

ALTER TABLE [dbo].[ConfigFuncionalidades] ADD  CONSTRAINT [DF_ConfigFuncionalidades_SesionoNombrePC]  DEFAULT ('-') FOR [SesionoNombrePC]
GO


--EVENTOSLOG

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_IP]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Factura1]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Detalle]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Factura]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_OP]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Accion]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Modulo]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Usuario]
GO

ALTER TABLE [dbo].[EventosLog] DROP CONSTRAINT [DF_EventosLog_Fecha]
GO

/****** Object:  Table [dbo].[EventosLog]    Script Date: 02/06/2020 16:50:38 ******/
DROP TABLE [dbo].[EventosLog]
GO

/****** Object:  Table [dbo].[EventosLog]    Script Date: 02/06/2020 16:50:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventosLog](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Fecha] [varchar](20) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Modulo] [varchar](30) NOT NULL,
	[Accion] [varchar](15) NOT NULL,
	[Tabla] [varchar](50) NOT NULL,
	[Campo] [varchar](50) NOT NULL,
	[Valor] [varchar](50) NOT NULL,
	[Detalle] [varchar](1000) NOT NULL,
	[Evento] [varchar](100) NOT NULL,
	[NombrePC] [varchar](30) NOT NULL,
	[IP] [varchar](15) NOT NULL,
 CONSTRAINT [PK_EventosLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Fecha]  DEFAULT ('-') FOR [Fecha]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Usuario]  DEFAULT ('-') FOR [Usuario]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Modulo]  DEFAULT ('-') FOR [Modulo]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Accion]  DEFAULT ('-') FOR [Accion]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_OP]  DEFAULT ('-') FOR [Campo]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Factura]  DEFAULT ('-') FOR [Detalle]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Detalle]  DEFAULT ('-') FOR [Evento]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_Factura1]  DEFAULT ('-') FOR [NombrePC]
GO

ALTER TABLE [dbo].[EventosLog] ADD  CONSTRAINT [DF_EventosLog_IP]  DEFAULT ('-') FOR [IP]
GO


--------PROGRAMAS SATELITE--------------------------------------------------------------------

CREATE TABLE [dbo].[ProgramasSatelite](
 [ID] [smallint] IDENTITY(1,1) NOT NULL,
 [Programa] [varchar](30) NOT NULL,
 [SesionONombrePC] [varchar](30) NOT NULL,
 [Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ProgramasSatelite] PRIMARY KEY CLUSTERED 
(
 [ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProgramasSatelite] ADD  CONSTRAINT [DF_ProgramasSatelite_Aplicacion]  DEFAULT ('-') FOR [Programa]
GO

ALTER TABLE [dbo].[ProgramasSatelite] ADD  CONSTRAINT [DF_ProgramasSatelite_PC]  DEFAULT ('-') FOR [SesionONombrePC]
GO

ALTER TABLE [dbo].[ProgramasSatelite] ADD  CONSTRAINT [DF_ProgramasSatelite_Descripcion]  DEFAULT ('-') FOR [Descripcion]
GO

---------------------------ARTICULOSDET

CREATE TABLE [dbo].[ArticulosDet](
	[CodIntDet] [varchar](15) NOT NULL CONSTRAINT [DF_ArticulosDet_CodEmp]  DEFAULT ('-'),
	[CodInt] [varchar](15) NOT NULL CONSTRAINT [DF_ArticulosDet_CodProd]  DEFAULT ('-'),
	[NombreDet] [varchar](30) NOT NULL CONSTRAINT [DF_ArticulosDet_NomEmp]  DEFAULT ('-'),
	[Tipo] [varchar](5) NOT NULL CONSTRAINT [DF_ArticulosDet_Tipo]  DEFAULT ('-'),
 CONSTRAINT [PK_ArticulosDet] PRIMARY KEY CLUSTERED 
(
	[CodIntDet] ASC,
	[CodInt] ASC,
	[Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-------------------------------------------EXCLUSIONESPT------------------------------------------------------------------------------


CREATE TABLE [dbo].[ExclusionesPT](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Proceso] [varchar](30) NOT NULL,
	[Codigo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ExclusionesPT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExclusionesPT] ADD  CONSTRAINT [DF_ExclusionesPT_Proceso]  DEFAULT ('-') FOR [Proceso]
GO

ALTER TABLE [dbo].[ExclusionesPT] ADD  CONSTRAINT [DF_ExclusionesPT_Codigo]  DEFAULT ('-') FOR [Codigo]
GO

--EQUIVFORMPROD-----------------------------

CREATE TABLE [dbo].[EquivFormProd](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CodFor] [varchar](15) NOT NULL,
	[CodProd] [varchar](15) NOT NULL,
	[NomProd] [varchar](30) NOT NULL,
 CONSTRAINT [PK_EquivFormProd] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EquivFormProd] ADD  CONSTRAINT [DF_EquivFormProd_CodFor]  DEFAULT ('-') FOR [CodFor]
GO

ALTER TABLE [dbo].[EquivFormProd] ADD  CONSTRAINT [DF_EquivFormProd_CodProd]  DEFAULT ('-') FOR [CodProd]
GO

ALTER TABLE [dbo].[EquivFormProd] ADD  CONSTRAINT [DF_EquivFormProd_NomProd]  DEFAULT ('-') FOR [NomProd]
GO




-----USUARIOSDETALLE-------------------------
ALTER TABLE Usuarios DROP CONSTRAINT PK_Usuarios
ALTER TABLE Usuarios ALTER COLUMN Usuario Varchar(20) NOT NULL
ALTER TABLE Usuarios ADD CONSTRAINT PK_Usuarios PRIMARY KEY (Usuario)


ALTER TABLE [dbo].[UsuariosDetalle] DROP CONSTRAINT [FK_UsuariosDetalle_Usuarios]
GO

ALTER TABLE [dbo].[UsuariosDetalle] DROP CONSTRAINT [DF_UsuariosDetalle_Permiso]
GO

ALTER TABLE [dbo].[UsuariosDetalle] DROP CONSTRAINT [DF_Table_1_UsaurioID]
GO

/****** Object:  Table [dbo].[UsuariosDetalle]    Script Date: 02/06/2020 16:52:33 ******/
DROP TABLE [dbo].[UsuariosDetalle]
GO

/****** Object:  Table [dbo].[UsuariosDetalle]    Script Date: 02/06/2020 16:52:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsuariosDetalle](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Permiso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UsuariosDetalle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsuariosDetalle] ADD  CONSTRAINT [DF_Table_1_UsaurioID]  DEFAULT ('') FOR [Usuario]
GO

ALTER TABLE [dbo].[UsuariosDetalle] ADD  CONSTRAINT [DF_UsuariosDetalle_Permiso]  DEFAULT ('-') FOR [Permiso]
GO

ALTER TABLE [dbo].[UsuariosDetalle]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosDetalle_Usuarios] FOREIGN KEY([Usuario])
REFERENCES [dbo].[Usuarios] ([Usuario])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[UsuariosDetalle] CHECK CONSTRAINT [FK_UsuariosDetalle_Usuarios]
GO


-------USUARIOSPERMISO------------------------------------

ALTER TABLE [dbo].[UsuariosPermisos] DROP CONSTRAINT [DF_UsuariosPermisos_Descripcion]
GO

ALTER TABLE [dbo].[UsuariosPermisos] DROP CONSTRAINT [DF_UsuariosPermisos_TextoBoton]
GO

ALTER TABLE [dbo].[UsuariosPermisos] DROP CONSTRAINT [DF_UsuariosPermisos_PermisoAnterior]
GO

ALTER TABLE [dbo].[UsuariosPermisos] DROP CONSTRAINT [DF_UsuariosPermisos_Permiso]
GO

/****** Object:  Table [dbo].[UsuariosPermisos]    Script Date: 02/06/2020 10:43:40 ******/
DROP TABLE [dbo].[UsuariosPermisos]
GO

/****** Object:  Table [dbo].[UsuariosPermisos]    Script Date: 02/06/2020 10:43:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsuariosPermisos](
	[Permiso] [varchar](50) NOT NULL,
	[PermisoAnterior] [varchar](30) NOT NULL,
	[TextoBoton] [varchar](50) NOT NULL,
	[Descripcion] [varchar](300) NOT NULL,
 CONSTRAINT [PK_UsuariosPermisos] PRIMARY KEY CLUSTERED 
(
	[Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsuariosPermisos] ADD  CONSTRAINT [DF_UsuariosPermisos_Permiso]  DEFAULT ('') FOR [Permiso]
GO

ALTER TABLE [dbo].[UsuariosPermisos] ADD  CONSTRAINT [DF_UsuariosPermisos_PermisoAnterior]  DEFAULT ('-') FOR [PermisoAnterior]
GO

ALTER TABLE [dbo].[UsuariosPermisos] ADD  CONSTRAINT [DF_UsuariosPermisos_TextoBoton]  DEFAULT ('') FOR [TextoBoton]
GO

ALTER TABLE [dbo].[UsuariosPermisos] ADD  CONSTRAINT [DF_UsuariosPermisos_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO

-------------------------CONGIGREPORTES ----------------------------------------

CREATE TABLE [dbo].[ConfigReportes](
	[NombreBoton] [varchar](50) NOT NULL,
	[TextoBoton] [varchar](100) NOT NULL,
	[Contenedor] [varchar](50) NOT NULL,
	[ReporteAsociado] [varchar](30) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_ConfigReportes] PRIMARY KEY CLUSTERED 
(
	[NombreBoton] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConfigReportes] ADD  CONSTRAINT [DF_Table_1_Nombre]  DEFAULT ('-') FOR [NombreBoton]
GO

ALTER TABLE [dbo].[ConfigReportes] ADD  CONSTRAINT [DF_ConfigReportes_TextoBoton]  DEFAULT ('-') FOR [TextoBoton]
GO

ALTER TABLE [dbo].[ConfigReportes] ADD  CONSTRAINT [DF_ConfigReportes_Contenedor]  DEFAULT ('-') FOR [Contenedor]
GO

ALTER TABLE [dbo].[ConfigReportes] ADD  CONSTRAINT [DF_ConfigReportes_ReporteAsociado]  DEFAULT ('-') FOR [ReporteAsociado]
GO

ALTER TABLE [dbo].[ConfigReportes] ADD  CONSTRAINT [DF_ConfigReportes_Activo]  DEFAULT ((0)) FOR [Activo]
GO

------OpsFinPlanilla ----------------------------------------------------

CREATE TABLE [dbo].[OPsFinPlanilla](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OP] [varchar](30) NOT NULL,
	[DosificadoKG] [real] NOT NULL,
	[Malla8P] [real] NOT NULL,
	[Malla16P] [real] NOT NULL,
	[PlatoP] [real] NOT NULL,
	[DurezaP] [real] NOT NULL,
	[DurabilidadP] [real] NOT NULL,
	[Malla8Q] [real] NOT NULL,
	[Malla16Q] [real] NOT NULL,
	[PlatoQ] [real] NOT NULL,
	[DurezaQ] [real] NOT NULL,
	[DurabilidadQ] [real] NOT NULL,
	[SackOffPorc] [real] NOT NULL,
	[FechaFinPlanilla] [varchar](20) NOT NULL,
 CONSTRAINT [PK_OPsFinPlanilla] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_OP]  DEFAULT ('-') FOR [OP]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_DosificadoKG]  DEFAULT ((0)) FOR [DosificadoKG]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_Malla8]  DEFAULT ((0)) FOR [Malla8P]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_Table_1_Malla81]  DEFAULT ((0)) FOR [Malla16P]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_Plato]  DEFAULT ((0)) FOR [PlatoP]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_Dureza]  DEFAULT ((0)) FOR [DurezaP]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_Durabilidad]  DEFAULT ((0)) FOR [DurabilidadP]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_Malla8P1]  DEFAULT ((0)) FOR [Malla8Q]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_Malla16P1]  DEFAULT ((0)) FOR [Malla16Q]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_PlatoP1]  DEFAULT ((0)) FOR [PlatoQ]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_DurezaP1]  DEFAULT ((0)) FOR [DurezaQ]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_DurabilidadP1]  DEFAULT ((0)) FOR [DurabilidadQ]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_SackOffPorc]  DEFAULT ((0)) FOR [SackOffPorc]
GO

ALTER TABLE [dbo].[OPsFinPlanilla] ADD  CONSTRAINT [DF_OPsFinPlanilla_FechaFinPlanilla]  DEFAULT ('-') FOR [FechaFinPlanilla]
GO


--CONSUMOSENG--------------------------------

CREATE TABLE [dbo].[ConsumosEng](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cont] [bigint] NOT NULL,
	[Cont2] [bigint] NOT NULL,
	[Maquina] [smallint] NOT NULL,
	[Fecha] [nvarchar](20) NOT NULL,
	[Rata] [decimal](5, 3) NOT NULL,
	[CodProd] [nvarchar](15) NOT NULL,
	[CodMat] [nvarchar](15) NOT NULL,
	[CodMatB] [nvarchar](15) NOT NULL,
	[NomMat] [nvarchar](30) NOT NULL,
	[NomProd] [nvarchar](30) NOT NULL,
	[TipoMat] [smallint] NOT NULL,
	[PesoMeta] [decimal](18, 3) NOT NULL,
	[PesoReal] [decimal](18, 3) NOT NULL,
	[Lote] [nvarchar](15) NOT NULL,
	[Alarmas] [smallint] NOT NULL,
	[CorteLote] [int] NOT NULL,
	[Reportado] [bit] NOT NULL,
	[Tolva] [real] NOT NULL,
	[OP] [nvarchar](15) NOT NULL,
	[Bascula] [smallint] NOT NULL,
	[Bache] [smallint] NOT NULL,
	[Estado] [smallint] NOT NULL,
 CONSTRAINT [aaaaaConsumosEng_PK] PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosEn__Cont__6383C8BA]  DEFAULT ((0)) FOR [Cont]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF_ConsumosEng_Cont1]  DEFAULT ((0)) FOR [Cont2]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosEn__Paso__6477ECF3]  DEFAULT ((0)) FOR [Maquina]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF_ConsumosEng_Fecha]  DEFAULT ('-') FOR [Fecha]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF_ConsumosEng_Factor]  DEFAULT ((0)) FOR [Rata]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF_ConsumosEng_CodProd]  DEFAULT ((0)) FOR [CodProd]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__CodMa__6754599E]  DEFAULT ((0)) FOR [CodMat]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__NomMa__68487DD7]  DEFAULT (' ') FOR [NomMat]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF_ConsumosEng_NomFor]  DEFAULT ('-') FOR [NomProd]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__TipoM__693CA210]  DEFAULT ((0)) FOR [TipoMat]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__PesoM__6A30C649]  DEFAULT ((0)) FOR [PesoMeta]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__PesoR__6B24EA82]  DEFAULT ((0)) FOR [PesoReal]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosEn__Lote__6C190EBB]  DEFAULT ('-') FOR [Lote]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__Alarm__6D0D32F4]  DEFAULT ((0)) FOR [Alarmas]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__Corte__6E01572D]  DEFAULT ((0)) FOR [CorteLote]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__Repor__6EF57B66]  DEFAULT ((0)) FOR [Reportado]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__Tolva__6FE99F9F]  DEFAULT ((0)) FOR [Tolva]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosEng__OP__70DDC3D8]  DEFAULT ((0)) FOR [OP]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__Bascu__71D1E811]  DEFAULT ((0)) FOR [Bascula]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF__ConsumosE__Bache__72C60C4A]  DEFAULT ((0)) FOR [Bache]
GO

ALTER TABLE [dbo].[ConsumosEng] ADD  CONSTRAINT [DF_ConsumosEng_Estado]  DEFAULT ((0)) FOR [Estado]
GO

---PROGEMPAQUE------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[ProgEmpaque](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OP] [varchar](15) NOT NULL,
	[CodProd] [varchar](15) NOT NULL,
	[NomProd] [varchar](30) NOT NULL,
	[MetaTot] [smallint] NOT NULL,
	[SacosEmp] [smallint] NOT NULL,
	[SacosDisp] [smallint] NOT NULL,
	[MetaParc] [smallint] NOT NULL,
	[FechaCreacion] [varchar](20) NOT NULL,
	[FechaProg] [varchar](20) NOT NULL,
	[FechaReal] [varchar](20) NOT NULL,
	[Maquina] [tinyint] NOT NULL,
	[Tolva] [tinyint] NOT NULL,
	[Lote] [varchar](30) NOT NULL,
	[Finalizado] [varchar](2) NOT NULL,
	[Completo] [varchar](2) NOT NULL,
	[Secuencia] [smallint] NOT NULL,
 CONSTRAINT [PK_ProgEmpaque] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_OP]  DEFAULT ('-') FOR [OP]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_CodProd]  DEFAULT ('-') FOR [CodProd]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_NomProd]  DEFAULT ('-') FOR [NomProd]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_MetaTot]  DEFAULT ((0)) FOR [MetaTot]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_SacosTot]  DEFAULT ((0)) FOR [SacosEmp]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_SacosDisp]  DEFAULT ((0)) FOR [SacosDisp]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_MetaParc]  DEFAULT ((0)) FOR [MetaParc]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_FechaCreacion]  DEFAULT ('-') FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Fecha]  DEFAULT ('-') FOR [FechaProg]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_FechaReal]  DEFAULT ('-') FOR [FechaReal]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Maquina]  DEFAULT ((0)) FOR [Maquina]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Tolva]  DEFAULT ((0)) FOR [Tolva]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Lote]  DEFAULT ('-') FOR [Lote]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Finalizado]  DEFAULT ('-') FOR [Finalizado]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Completo]  DEFAULT ('-') FOR [Completo]
GO

ALTER TABLE [dbo].[ProgEmpaque] ADD  CONSTRAINT [DF_ProgEmpaque_Secuencia]  DEFAULT ((0)) FOR [Secuencia]
GO


--CONCEPTOS CONTROL BASCULA------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ConceptosContBasc](
	[Concepto] [varchar](30) NOT NULL,
	[TipoMov] [varchar](30) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[TipoLote] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ConceptosContBasc] PRIMARY KEY CLUSTERED 
(
	[Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConceptosContBasc] ADD  CONSTRAINT [DF_ConceptosContBasc_Concepto]  DEFAULT ('-') FOR [Concepto]
GO

ALTER TABLE [dbo].[ConceptosContBasc] ADD  CONSTRAINT [DF_ConceptosContBasc_Operacion]  DEFAULT ('-') FOR [TipoMov]
GO

ALTER TABLE [dbo].[ConceptosContBasc] ADD  CONSTRAINT [DF_ConceptosContBasc_Detalle]  DEFAULT ('-') FOR [Descripcion]
GO

ALTER TABLE [dbo].[ConceptosContBasc] ADD  CONSTRAINT [DF_ConceptosContBasc_TipoLote]  DEFAULT ('-') FOR [TipoLote]
GO

---------------------------------------------------------------------------------------------------------------------------------------------
--EmpEtiqDet
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmpEtiqDet](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OP] [varchar](15) NOT NULL,
	[CodInt] [varchar](15) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Tipo] [varchar](5) NOT NULL,
	[CantBache] [smallint] NOT NULL,
	[CantTotal] [smallint] NOT NULL,
	[FechaIni] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EmpEtiqDet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_EmpEtiqDet_OP]  DEFAULT ('-') FOR [OP]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_Table_1_OP1]  DEFAULT ('-') FOR [CodInt]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_Table_1_CodInt1]  DEFAULT ('-') FOR [Nombre]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_EmpEtiqDet_Tipo]  DEFAULT ('-') FOR [Tipo]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_EmpEtiqDet_Cant]  DEFAULT ((0)) FOR [CantBache]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_EmpEtiqDet_CantBache]  DEFAULT ((0)) FOR [CantTotal]
GO

ALTER TABLE [dbo].[EmpEtiqDet] ADD  CONSTRAINT [DF_EmpEtiqDet_FechaIni]  DEFAULT ('-') FOR [FechaIni]
GO

-----------------------------------------------------CAMPOS NUEVOS EN TABLAS EXISTENTES----------------------------------------------------------------------------

--ARTICULOS
alter table Articulos add Reproceso bit not null default (0)
alter table Articulos add TipoVehiculo bit not null default (0)
alter table Articulos add TaraEmp real not null default (0)
alter table Articulos add ManejaCorteLote bit not null default (0)
alter table Articulos add Activo bit not null default (1)
ALTER TABLE Articulos ADD ParmPorcMalla6 VARCHAR(15) not NULL default('-')
ALTER TABLE Articulos ADD ParmPorcMalla12 VARCHAR(15) not NULL default('-')
ALTER TABLE Articulos ADD ParmPorcMalla30 VARCHAR(15) not NULL default('-')
ALTER TABLE Articulos ADD RegIca VARCHAR(30) not NULL default('-')
ALTER TABLE Articulos ADD Observaciones VARCHAR(100) not NULL default('-')
alter table Articulos add Densidad real not null default (0)
alter table Articulos add LiquidoExt bit not null default (0)

--BASCULAS
alter table Basculas add Imprimir bit not null default (0)
ALTER TABLE Basculas ADD NombreSeccion VARCHAR(100) not NULL default('-')


--CORTESLOTE
alter table CortesLote add PaqPorBache tinyint not null default (0)
alter table CortesLote add Secuencia int not null default (0)
ALTER TABLE CortesLote ADD UbicLote VARCHAR(10) not NULL default('')
ALTER TABLE CortesLote ADD DescUbicLote VARCHAR(30) not NULL default('-')
alter table CortesLote add PorcMerma decimal(18,3) not null default (0)
ALTER TABLE CortesLote ADD Linea VARCHAR(30) not NULL default('-')
ALTER TABLE CortesLote ADD Descartado bit not NULL default(0)
ALTER TABLE CortesLote ADD FechaEnt VARCHAR(20) not NULL default('-')
ALTER TABLE CortesLote ADD FechaFinalizado VARCHAR(20) not NULL default('-')
------solo para  giron planta 2---Realizar cambio tambien en chrcomunicaciones, cuando se abre el corte de lote automaticamente de acuerdo a la fecha de entrada
EXEC sp_rename 'CortesMP.FechaIng', 'FechaEnt', 'COLUMN'

--CONSUMOS
ALTER TABLE dbo.Consumos ADD UbicLote VARCHAR(30) not NULL default('-')
ALTER TABLE dbo.Consumos ADD NomTolva VARCHAR(15) not NULL default('-')
ALTER TABLE dbo.Consumos ADD A VARCHAR(5) not NULL default('-')

--CONSUMOSMED

ALTER TABLE dbo.ConsumosMed ADD LP VARCHAR(15) not NULL default('-')

--DATOSFOR
ALTER TABLE dbo.DatosFor ADD NomTolva VARCHAR(15) not NULL default('-')
ALTER TABLE dbo.DatosFor ADD A2 VARCHAR(5) not NULL default('-')

--EMPAQUE
ALTER TABLE dbo.Empaque ADD FechaRecProd VARCHAR(20) not NULL default('-')
ALTER TABLE dbo.Empaque ADD UsuarioRecProd VARCHAR(20) not NULL default('-')
alter table Empaque add RecProd bit not null default (0)
alter table Empaque add RecCal bit not null default (0)
ALTER TABLE dbo.Empaque ADD Finalizado VARCHAR(5) not NULL default('-')  --Poner en valor por defecto ='S' si la planta nop maneja el campo finalizado
-- Correr la siguiente actulizacion si la planta no maneja el campo finalizado en el empaque
UPDATE EMPAQUE SET FINALIZADO='S'
ALTER TABLE dbo.Empaque ADD NumFinPlanilla smallint not NULL default('0')
ALTER TABLE dbo.Empaque ADD FechaRecCal VARCHAR(20) not NULL default('-')
ALTER TABLE dbo.Empaque ADD UsuarioRecCal VARCHAR(20) not NULL default('-')

--HUMEDADES
ALTER TABLE dbo.Humedades ADD CodFor nvarchar(15) not NULL default('-')
ALTER TABLE dbo.Humedades ADD LP nvarchar(15) not NULL default('-')


--EQUIPOS
alter table Equipos add CodEquipo varchar(50) not null default ('-')

--OBsCortesMP
ALTER TABLE dbo.OBsCortesMP ADD TdRowIdCB bigint NOT NULL DEFAULT (0)
ALTER TABLE dbo.OBsCortesMP ADD UbicLote varchar(10) NOT NULL DEFAULT ('-')

--MovInv
ALTER TABLE dbo.MovInv ADD ContadorCB INT NOT NULL  DEFAULT ((0)) 
ALTER TABLE dbo.MovInv ADD IDRowCB INT NOT NULL  DEFAULT ((0))
ALTER TABLE dbo.MovInv ADD Placa varchar(15) NOT NULL DEFAULT ('-')


--FORMULAS

ALTER TABLE dbo.Formulas ADD HumedadFor decimal(18,3) not NULL default(0)
ALTER TABLE dbo.Formulas ADD NumIngFor smallint not NULL default(0)
ALTER TABLE dbo.Formulas ADD UsuarioImpFor VARCHAR(20) not NULL default('-')
ALTER TABLE dbo.Formulas ADD PorcAdicFilax decimal(18,3) not NULL default(0)
ALTER TABLE Formulas ADD MezcExt bit not null default(0)
ALTER TABLE Formulas ADD FechaImpFor VARCHAR(20) not NULL default('-')
ALTER TABLE Formulas ADD GrasaFor real not NULL default(0)

---OJO REVISAR PRIMERO SI LA PLANTA MANEJA O NO PX Y SI YA TIENE EL CAMPO
alter table Formulas add ManejaPx bit not null  default (1)

--CORRER LA SIGUIENTE ACTUALIZACION SI LA PLANTA NO MANEJA PX
Update FORMULAS set MANEJAPX=0 


--LINEASPROD

ALTER TABLE LineasProd ADD LineaExterna bit not NULL default(0)   --Dice si la linea es externa ejemplo sales, maiza venta
ALTER TABLE LineasProd ADD PorcMerma real not NULL default(0)
ALTER TABLE LineasProd ADD DiasVenc smallint not NULL default(0)
ALTER TABLE LineasProd ADD ManejaPx bit not NULL default(0)

--OPS
--EXEC sp_rename 'OPs.ObservEmp', 'ObservBodega', 'COLUMN'
ALTER TABLE dbo.OPs ADD ObservAlmacen VARCHAR(250) not NULL default ('-')  --pasar las observaciones de ObservEmp a ObservAlmacen
update Ops Set ObservAlmacen=ObservEmp
ALTER TABLE dbo.OPs ADD ObservProduccion VARCHAR(250) not NULL default ('-')
ALTER TABLE dbo.OPs ADD ObservCalidad VARCHAR(250) not NULL default ('-')
ALTER TABLE dbo.OPs ADD BAhoraBPiso smallint not NULL default (0)
ALTER TABLE dbo.OPs ADD RealMan smallint not NULL default (0)
ALTER TABLE dbo.OPs ADD MicHab bit not NULL default (0)
ALTER TABLE dbo.OPs ADD PromHumAcond real not NULL default (0)
ALTER TABLE dbo.OPs ADD LineaExterna bit not NULL default (0)
ALTER TABLE dbo.OPs ADD NomCli VARCHAR(40) not NULL default ('-')

---RETAQUE
ALTER TABLE dbo.Retaque ADD ContVaceo int not NULL default (0)
ALTER TABLE dbo.Retaque ADD TotalTolva real not NULL default (0)
ALTER TABLE dbo.Retaque ADD Falta real not NULL default (0)
ALTER TABLE dbo.Retaque ADD LineaInvent varchar(30) not NULL default ('-')   --sOLO ESTABA EN PALMIRA, SE DEBE PONER EN TODAS LAS DEMAS
ALTER TABLE dbo.Retaque ADD Tiquete VARCHAR(30) not NULL default ('-')

--TAMIZADOS
--tamizados (Toca revisar que mallas hay y que no, deben estar la 6,8,12,16,30)
ALTER TABLE dbo.Tamizados ADD PesoMalla6 decimal(18, 3) not NULL default(0)
ALTER TABLE dbo.Tamizados ADD PorcMalla6 decimal(18, 3) not NULL default(0)

ALTER TABLE dbo.Tamizados ADD PesoMalla8 decimal(18, 3) not NULL default(0)
ALTER TABLE dbo.Tamizados ADD PorcMalla8 decimal(18, 3) not NULL default(0)

ALTER TABLE dbo.Tamizados ADD PesoMalla12 decimal(18, 3) not NULL default(0)
ALTER TABLE dbo.Tamizados ADD PorcMalla12 decimal(18, 3) not NULL default(0)

ALTER TABLE dbo.Tamizados ADD PesoMalla16 decimal(18, 3) not NULL default(0)
ALTER TABLE dbo.Tamizados ADD PorcMalla16 decimal(18, 3) not NULL default(0)

ALTER TABLE dbo.Tamizados ADD PesoMalla30 decimal(18, 3) not NULL default(0)
ALTER TABLE dbo.Tamizados ADD PorcMalla30 decimal(18, 3) not NULL default(0)

--TOLVAS
ALTER TABLE dbo.Tolvas ADD NomTolva VARCHAR(15) not NULL default('-')

--UBICACIONES
alter table Ubicaciones add Consumo bit not null default (0)
alter table Ubicaciones add VerEnModDesp bit not null default (0)

--USUARIOS
alter table Usuarios add Codigo int not null default (0)


--PROGPROD
ALTER TABLE dbo.ProgProd ADD Uno real NOT NULL DEFAULT (0)
ALTER TABLE dbo.ProgProd ADD Pedidos real NOT NULL DEFAULT (0)

--------LLENAR TABLACONFIGFUNCIONALIDADES-----------------------------

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)   --Importacion de lotes
VALUES ('Acceso','Importacion.Lotes.ControlBascula','Revisa si se debe cargar el form CortesContBascula',0,'-');


INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)   --MODULO ENTRA BACHE
VALUES ('EntraBache','Imprimir.Etiqueta.Micros','Valida si hay funcionalidad de impresion etiqueta',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)   --COMPARATIVOINVENTARIOS
VALUES ('ComparativoInv','Act.Inv.Físico','Si se debe actualizar el inventario fisico',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --MANEJAR PAQUETEO
VALUES ('EMPAQUEMAN','Manejar.Paqueteo','Si se maneja paqueteo en planta',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --RECIBIR EMPAQUE ALMACEN
VALUES ('RECIBEPT','Recibir.Empaque.Almacen','Si se recibe producto en bodega o almacen',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)   --RECIBIR EMPAQUE PRODUCCION
VALUES ('RECIBEPT','Recibir.Empaque.Produccion','Si se recibe empaque en produccion',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)   --RECIBIR EMPAQUE CALIDAD
VALUES ('RECIBEPT','Recibir.Empaque.Calidad','Si se recibe empaque en calidad',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --FINALIZAR PLANILLA SALES
VALUES ('EMPAQUEMAN','Finalizar.Planilla.Sales','Si se finaliza la planilla en sales cuando cumple sackoff',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --CONEXION BD PREMEZCLAS EXTERNA- APLICA PARA GIRARDOTA 
VALUES ('FORMULACION','Conexion.BD.Premezclas.Ext','Si hay bd externa de premezclas',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --VERIFICA SI SE USA LA TABLA PROCESODOSIF
VALUES ('DOSIFICACION','Tabla.ProcesoDosif','Si se usa la tabla procesodosif en planta',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --SI SE DOSIFICA POR BANDEJA
VALUES ('FORMULAS','Materiales.Bandeja','Si hay materiales por bandeja',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --DOSIFICACION OPTICURB
VALUES ('FORMULAS','Maneja.Opticurb','Si hay dosificacion de Opticurb',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)  --Para planta premezclas poner activa=1
VALUES ('FORMULAS','Maneja.Vehiculo','Usado para planta premezclas',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('OPS','Plantas.Externas','Maneja OPs para platas externas - Aplica para Girardota Premezclas',0,'-');  --Lleva OPs de plantas externas

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('OPS','Destinos.Peletizado','Maneja destinos de peletizado para Gemba - Aplica para Giron',0,'-');  --Destinos Peletizado

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('OPS','Fun.Premezcla','Codigo de premezcla en funza y cota',0,'-');  --Fun Premezcla

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('OPS','Adelantar.EmpaquesyEtiquetas','Guarda cantidad teorica de empaques y etiquetas',0,'-');  --Habilitar para planta Girardota

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('OPS','Funciones.Planta.Premezclas','Manejos exclusivos de planta premezclas',0,'-');  --Habilitar para planta premezclas

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('OPS','Maneja.Secuencia.Mezcla','Para saber si se deben revisar parametros de secuencia de mezcla en la formula',1,'-'); -- Inhabilitar para girardota premezclas

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('MATERIALES','Maneja.Tolerancias.Porcentaje','Manejo tolerancias en porcentaje',0,'-'); -- manejo de tolerancias en porcentaje

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('PRODUCTOS','Venc.Por.Producto','Revisa si maneja vencimiento x producto',0,'-'); -- Habilitar inicialmente en premezclas

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('PRODUCTOS','Obliga.LineaInvent','determina si debe exigir linea',0,'-'); -- Determina si exige linea

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('IMPORTFOR','Maneja.Establecimiento','determina si la formula maneja incluye el codigo del establecimiento',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('IMPORTFOR','Maneja.Fylax','determina si la planta maneja el componente Fylax',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('IMPORTFOR','Archivo.Trae.PaquetePrem','determina si el archivo trae el componente del paquete px',0,'-');  --habilitar para GIRARDOTA,YARUMAL,STAROSA,GIRARDOTA PREMEZCLAS

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('IMPORTFOR','Pregunta.Por.CodForB','determina si la planta no se pregunta por CodForB',0,'-');  --habilitar para COTA,FUNZA,gironp1,gironp2,panama,

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('IMPORTFOR','Aprobar.Formula.Importada','Pregunta si se debe aprobar la formula importada',0,'-');  ---Habilitar para palmira y palermo

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('CLIENTES','Clientes.Tipo','Revisa si la tabla clientes maneja tipo(cliente o proveedor)',0,'-');  ---Habilitar para funza premezclas

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)             --Impresion etiquetas en modulo cortes por USB
VALUES ('CORTESMP','Imprimir.Etiqueta.Usb','Valida si hay funcionalidad de impresion etiqueta',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)           --Aplica para planta funza y palmira
VALUES ('SOLICITUDCARGUE','Maneja.Pantalla.Vaceo','Valida si hay pantalla de vaceo',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)           --Aplica para planta funza
VALUES ('FONDO','Inactividad.ChronoSoft','Valida si maneja pedido de usuario por inactividad',0,'-');

INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)           --Aplica para planta funza
VALUES ('FONDO','Baches.OPs.Ventas','Valida si la planta maneja Ops de ventas',0,'-');



--------LLENAR TABLACONFIGPARAMETROS-----------------------------

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('EMPAQUE','UmbralSackoff','1.015','Maximo sackoff permitido en planta');     --SACKOFF DE PLANTA

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('EMPAQUE','MaxTamColas','40','Maximo tamaño de la cola de empaque');   --TAMAÑO DE COLAS

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('EMPAQUE','MaxSacosAjuste','3','Maximo valor de ajuste de sacos');   --Maximo valos para ajuste de sacos

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULAS','TiempoMezclaSeca','60','Valor por defecto tiempo mezcla seca');  --valor tiempo mezcla seca por defecto

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULAS','TiempoMezclaHumeda','60','Valor por defecto tiempo mezcla humeda');  --valor tiempo mezcla humeda por defecto

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULAS','CodigoAguaHC','9997','Valor de codigo de agua por opticurp en las plantas'); --valor codig agua

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULAS','ValorMaxSalCurp','7','Valor maximo para el ingrediente salcurb');

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULAS','ValorMaxMycoCurp','7','Valor maximo para el ingrediente mycocurb');

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULAS','PorcOpticurpAdicionar','0.05','La suma de SalCurp + Myco Curp no puede ser menor al 5% del agua a adicionar'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('OPS','MaxKgTanda','0','Seguridad de KG en dosificacion micros');   ---OJO CONFIGURAR EL VALOR CORRECTO EN PLANTA PALMIRA, REVISAR TABLA CONFIGVAR

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('DESPACHOS','NOMIMPTIRILLACARGUEPT','POS-80C','Nombre impresora tirilla cargue PT'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('MATERIALES','TolMinKgMP','0.002','tolerancia minima en kg'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('MATERIALES','TolMaxKgMP','20','tolerancia maxima en kg'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('MATERIALES','TolMinPorcMP','0.2','tolerancia minima en porcentaje'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('MATERIALES','TolMaxPorcMP','5','tolerancia maxima en porcentaje'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('IMPORTFOR','CodigoFylax','1958','Valor de codigo de Fylax  en las plantas'); --valor codig agua

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('IMPORTFOR','ImportForCodForB','Establecimiento','Puede tomar los valores Establecimiento, LP, CodFor'); --valor de codforB en importfor
---GIRARDOTA, GIRARDOTA PREMEZCLAS, YARUMAL, SANTA ROSA el valor para este parametro es Establecimiento
---BARRANQUILLA,PALERMO,PALMIRA,PEREIRA                                         el valor para este parametro es CodFor

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CORTESMP','NomImpCortesMP','Sato','Nombre impresora USB en formulario de cortes MP'); 
 
INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CORTESMP','RutaInventario','ruta','Ruta donde se exportan los archivos para toma de inventario'); 

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CARGUEMAN','PcVaceoL1','AMM','Nombre del PC donde se abre el vaceo para L1'); --Aplica por el momento solo para Bqlla

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CARGUEMAN','PcVaceoL2','AMM','Nombre del PC donde se abre el vaceo para L1'); --Aplica por el momento solo para Bqlla

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FONDO','ServidorComunicaciones','AMM','Nombre del PC de comunicaciones'); --Indica que el PC va a cer el de comunicaciones

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FONDO','ServidorChronoSoft','AMM','Nombre del PC servidor ChronoSoft'); --Indica que el PC va a ser servidor Chr

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('ACCESO','NombrePlanta','-','Nombre de la sucursal de la planta'); --Nombre de la planta
 
 INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CORTESCONTBASCULA','UltContadorCB','0','Ultimo valor del RowId de la tabla de importacion CB');
 
 INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CONTROLDIARIO','MaquinaExtruder1','0','Numero de maquina Extruder 1'); 

 INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('CONTROLDIARIO','MaquinaExtruder2','0','Numero de maquina Extruder 2');  

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('ACCESO','UsuarioDosificacion','AMM','Indica el usuario dosificador, para usarlo en el de comunicaciones'); --Indica que el PC va a cer el de comunicaciones

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('PLANILLA','NomImpPlanilla','-','Nombre impresora PT'); --Indica que el PC va a cer el de comunicaciones




---------------------------------------------------------VISTAS---------------------------------------------------------------------------------------------------------

--CSILOS

CREATE VIEW [dbo].[CSilos]
AS
SELECT     CodSilo, NomSilo, Linea, CodMat, NomMat, Lote, InvIni, Consumo, Activo, InvIni - Consumo AS Total
FROM         dbo.Silos

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Silos"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CSilos'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CSilos'
GO


--CPERMISOSUSUARIOS

CREATE VIEW [dbo].[CPermisosUsuarios]
AS
SELECT        dbo.UsuariosDetalle.Usuario, dbo.Usuarios.Cargo, dbo.Usuarios.Codigo, dbo.UsuariosDetalle.Permiso, dbo.UsuariosPermisos.TextoBoton, dbo.UsuariosPermisos.Descripcion
FROM            dbo.Usuarios INNER JOIN
                         dbo.UsuariosDetalle ON dbo.Usuarios.Usuario = dbo.UsuariosDetalle.Usuario INNER JOIN
                         dbo.UsuariosPermisos ON dbo.UsuariosDetalle.Permiso = dbo.UsuariosPermisos.Permiso

GO

--CCONSUMOSMED

DROP VIEW [dbo].[CConsumosMed]
GO

/****** Object:  View [dbo].[CConsumosMed]    Script Date: 13/11/2020 8:12:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CConsumosMed]
AS
SELECT     dbo.OPs.OP, dbo.ConsumosMed.CodFor, dbo.OPs.NomFor, dbo.ConsumosMed.Cont, dbo.ConsumosMed.CodMat, dbo.ConsumosMed.NomMat, 
                      SUM(dbo.ConsumosMed.PesoMeta) AS PesoMeta, SUM(dbo.ConsumosMed.PesoReal) AS PesoReal, MIN(dbo.ConsumosMed.Fecha) AS Fechaini, 
                      MAX(dbo.ConsumosMed.Fecha) AS FechaFin, dbo.OPs.LP, dbo.ConsumosMed.Bache, dbo.ConsumosMed.Usuario, dbo.OPs.RealMed, dbo.OPs.LineaInvent, 
                      dbo.ConsumosMed.Cont2, dbo.OPs.LineaExterna, dbo.ConsumosMed.CodMatB, dbo.ConsumosMed.CodForB, dbo.ConsumosMed.Paso, dbo.ConsumosMed.Fecha, 
                      dbo.ConsumosMed.TipoMat, dbo.ConsumosMed.Lote
FROM         dbo.Consultas INNER JOIN
                      dbo.OPs INNER JOIN
                      dbo.ConsumosMed ON dbo.OPs.OP = dbo.ConsumosMed.OP ON dbo.Consultas.F1 <= dbo.ConsumosMed.Fecha AND 
                      dbo.Consultas.F2 > dbo.ConsumosMed.Fecha
GROUP BY dbo.OPs.OP, dbo.ConsumosMed.CodFor, dbo.OPs.NomFor, dbo.ConsumosMed.Cont, dbo.ConsumosMed.CodMat, dbo.ConsumosMed.NomMat, dbo.OPs.LP, 
                      dbo.ConsumosMed.Bache, dbo.ConsumosMed.Usuario, dbo.OPs.RealMed, dbo.OPs.LineaInvent, dbo.ConsumosMed.Cont2, dbo.OPs.LineaExterna, 
                      dbo.ConsumosMed.CodMatB, dbo.ConsumosMed.CodForB, dbo.ConsumosMed.Paso, dbo.ConsumosMed.Fecha, dbo.ConsumosMed.TipoMat, dbo.ConsumosMed.Lote
GO





--*********************************CAMBIOS HABILITACIÓN TRASLADO MICROS*****************************************************************

ALTER TABLE dbo.ConsumosMed ADD Traslado bit not NULL default(0)
ALTER TABLE dbo.ConsumosMed ADD OPOrigen varchar(15) not NULL default('-')
ALTER TABLE dbo.ConsumosMed ADD FechaFabricacion varchar(20) not NULL default('-')

--CAMBIOS REPORTE UBICACIONES***********************************************************************************************************


ALTER TABLE dbo.CortesLote ADD FechaFinUbic varchar(20) not NULL default('-')
update CortesLote set FechaFinUbic='2020/11/01'

--Agregar el reporte en la base de datos tabla configreportes

INSERT INTO ConfigReportes (NombreBoton, TextoBoton,Contenedor,ReporteAsociado,Activo)
VALUES ('Cortes_Ubicacion','Listado cortes agrupado por ubicación','Dosificacion Mayores','rpcortesubicacion',1); 

--Consulta CCORTESLOTEUBIC

CREATE VIEW [dbo].[CCortesLoteUbic]
AS
SELECT        dbo.CortesLote.Cont, dbo.CortesLote.CodMat, dbo.CortesLote.Lote, dbo.CortesLote.Consumo AS Real, dbo.CortesLote.InvIni, dbo.CortesLote.Ajuste1 AS AjusteSal, dbo.CortesLote.Ajuste2 AS AjusteEnt, 
                         dbo.CortesLote.Ajuste3 AS EntradaInv, dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni AS TotalEnt, dbo.CortesLote.Ajuste4 AS SalidaInv, dbo.CortesLote.InvFin, 
                         (dbo.CortesLote.Ajuste4 + dbo.CortesLote.Ajuste1 - dbo.CortesLote.Consumo) * - 1 AS TotalSal, dbo.CortesLote.Consumo, dbo.CortesLote.Estado, dbo.CortesLote.Finalizado, dbo.CortesLote.Vigente, dbo.CortesLote.Observ, 
                         dbo.CortesLote.PorcMerma, dbo.CortesLote.FechaIni, dbo.CortesLote.FechaFin, CASE WHEN len(dbo.CortesLote.FechaFin) >= 16 THEN DATEDIFF(d, CONVERT(datetime, dbo.CortesLote.FechaIni, 120), CONVERT(datetime, 
                         dbo.CortesLote.FechaFin, 120)) ELSE '0' END AS DiasConsumo, (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni) 
                         AS Diferencia, CASE WHEN (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) <> 0 THEN ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) 
                         - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) / ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo)) * 100 ELSE '0' END AS Porcentaje, 
                         CASE WHEN abs(((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) 
                         / ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000000000000001)) * 100) > dbo.corteslote.PorcMerma THEN 'NO' ELSE 'SI' END AS Cumple, 
                         CASE WHEN ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) 
                         / (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000001) > 0 THEN ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) 
                         - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) / (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000001) 
                         * 100 - dbo.CortesLote.PorcMerma ELSE ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) 
                         / (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000001) * 100 + dbo.CortesLote.PorcMerma END AS VariacionVsParametro, dbo.CortesLote.Linea, dbo.CortesLote.NomMat, 
                         dbo.CortesLote.Descartado, dbo.CortesLote.FechaFinalizado, dbo.CortesLote.FechaFinUbic, dbo.CortesLote.UbicLote, dbo.CortesLote.DescUbicLote
FROM            dbo.CortesLote INNER JOIN
                         dbo.Consultas ON dbo.CortesLote.FechaIni >= dbo.Consultas.F1 AND dbo.CortesLote.FechaIni < dbo.Consultas.F2
GROUP BY dbo.CortesLote.Cont, dbo.CortesLote.Lote, dbo.CortesLote.InvIni, dbo.CortesLote.Ajuste1, dbo.CortesLote.Ajuste2, dbo.CortesLote.Ajuste3, dbo.CortesLote.Ajuste4, dbo.CortesLote.InvFin, dbo.CortesLote.Consumo, 
                         dbo.CortesLote.Estado, dbo.CortesLote.Finalizado, dbo.CortesLote.Vigente, dbo.CortesLote.Condicion, dbo.CortesLote.PesoProm, dbo.CortesLote.NomMat, dbo.CortesLote.Observ, dbo.CortesLote.PorcMerma, 
                         dbo.CortesLote.FechaIni, dbo.CortesLote.FechaFin, dbo.CortesLote.Linea, dbo.CortesLote.Consumo, dbo.CortesLote.CodMat, dbo.CortesLote.Descartado, dbo.CortesLote.FechaFinalizado, dbo.CortesLote.FechaFinUbic, 
                         dbo.CortesLote.UbicLote, dbo.CortesLote.DescUbicLote
HAVING        (dbo.CortesLote.Consumo > 0)


--**********************************************CAMBIOS RESTRICCIONES FORMULACION LINEA DE NEGOCIOS************************************************************

ALTER TABLE dbo.Usuarios ADD LineaNegocio varchar(30) not NULL default('PRINCIPAL')
ALTER TABLE dbo.Formulas ADD CodEstablecimiento varchar(15) not NULL default('-')
update FORMULAS SET CODESTABLECIMIENTO=SUBSTRING(CODFOR,1,2)

--Funcionalidad manejo lineas de negocio 
INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)          
VALUES ('USUARIOS','Maneja.Restriccion.LineasNegocio','Valida si la planta tiene distintas lineas de negocio para revisar restricciones',0,'-');

--tabla Restricciones 

CREATE TABLE [dbo].[Restricciones](
	[ID] [tinyint] IDENTITY(1,1) NOT NULL,
	[Proceso] [varchar](30) NOT NULL,
	[LineaNegocio] [varchar](30) NOT NULL,
	[Restriccion] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Restricciones] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Restricciones] ADD  CONSTRAINT [DF_Restricciones_Proceso]  DEFAULT ('-') FOR [Proceso]
GO

ALTER TABLE [dbo].[Restricciones] ADD  CONSTRAINT [DF_Table_1_Linea]  DEFAULT ('-') FOR [LineaNegocio]
GO

ALTER TABLE [dbo].[Restricciones] ADD  CONSTRAINT [DF_Restricciones_Restriccion]  DEFAULT ('-') FOR [Restriccion]
GO

ALTER TABLE [dbo].[Restricciones] ADD  CONSTRAINT [DF_Restricciones_Descripcion]  DEFAULT ('-') FOR [Descripcion]
GO

--****************************CAMBIOS ADICION DE PARAMETROS FYLAX TABLA DE FORMULACION********************************************************

ALTER TABLE dbo.Formulas ADD HabCorrHum tinyint not NULL default(0)
ALTER TABLE dbo.Formulas ADD TipoAlimento tinyint not NULL default(0)
ALTER TABLE dbo.Formulas ADD NumReceta tinyint not NULL default(0)
ALTER TABLE dbo.Formulas ADD SpHumedad real not NULL default(0)

--Tabla nueva donde se guardan los parametros del fylax

CREATE TABLE [dbo].[BachesFylax](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cont] [bigint] NOT NULL,
	[H20_CalibFactor] [real] NOT NULL,
	[H2O_Dosed] [real] NOT NULL,
	[H2O_Overshoot] [real] NOT NULL,
	[H2O_SetpointCorr] [real] NOT NULL,
	[Index_Dos] [int] NOT NULL,
	[LogType] [int] NOT NULL,
	[Product_CalibFactor] [real] NOT NULL,
	[Product_Dosed] [real] NOT NULL,
	[Product_Overshoot] [real] NOT NULL,
	[Product_SetpointCorr] [real] NOT NULL,
	[RecipeBatchsize] [real] NOT NULL,
	[RecipeCorrEnable] [tinyint] NOT NULL,
	[RecipeFeedtype] [tinyint] NOT NULL,
	[RecipeH2O] [real] NOT NULL,
	[RecipeNr] [int] NOT NULL,
	[RecipeProduct] [real] NOT NULL,
	[MoistureMeasured] [real] NOT NULL,
 CONSTRAINT [PK_BachesFylax] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_Cont]  DEFAULT ((0)) FOR [Cont]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_H20_CalibFactor]  DEFAULT ((0)) FOR [H20_CalibFactor]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_H2O_Dosed]  DEFAULT ((0)) FOR [H2O_Dosed]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_H2O_Overshoot]  DEFAULT ((0)) FOR [H2O_Overshoot]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_H2O_SetpointCorr]  DEFAULT ((0)) FOR [H2O_SetpointCorr]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_Index_Dos]  DEFAULT ((0)) FOR [Index_Dos]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_LogType]  DEFAULT ((0)) FOR [LogType]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_Product_CalibFactor]  DEFAULT ((0)) FOR [Product_CalibFactor]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_Product_Dosed]  DEFAULT ((0)) FOR [Product_Dosed]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_Product_Overshoot]  DEFAULT ((0)) FOR [Product_Overshoot]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_Product_SetpointCorr]  DEFAULT ((0)) FOR [Product_SetpointCorr]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_RecipeBatchsize]  DEFAULT ((0)) FOR [RecipeBatchsize]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_RecipeCorrEnable]  DEFAULT ((0)) FOR [RecipeCorrEnable]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_RecipeFeedtype]  DEFAULT ((0)) FOR [RecipeFeedtype]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_RecipeH2O]  DEFAULT ((0)) FOR [RecipeH2O]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_RecipeNr]  DEFAULT ((0)) FOR [RecipeNr]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_RecipeProduct]  DEFAULT ((0)) FOR [RecipeProduct]
GO

ALTER TABLE [dbo].[BachesFylax] ADD  CONSTRAINT [DF_BachesFylax_MoistureMeasured]  DEFAULT ((0)) FOR [MoistureMeasured]
GO

--Vista CBachesFylax

CREATE VIEW [dbo].[CBachesFylax]
AS
SELECT        dbo.BachesFylax.ID, dbo.BachesFylax.Cont, dbo.BachesFylax.H20_CalibFactor, dbo.BachesFylax.H2O_Dosed, dbo.BachesFylax.H2O_Overshoot, dbo.BachesFylax.H2O_SetpointCorr, dbo.BachesFylax.Index_Dos, 
                         dbo.BachesFylax.LogType, dbo.BachesFylax.Product_CalibFactor, dbo.BachesFylax.Product_Dosed, dbo.BachesFylax.Product_Overshoot, dbo.BachesFylax.Product_SetpointCorr, dbo.BachesFylax.RecipeBatchsize, 
                         dbo.BachesFylax.RecipeCorrEnable, dbo.BachesFylax.RecipeFeedtype, dbo.BachesFylax.RecipeH2O, dbo.BachesFylax.RecipeNr, dbo.BachesFylax.RecipeProduct, dbo.Baches.Fecha, dbo.Baches.CodFor, dbo.Baches.OP, 
                         dbo.Baches.Bache, dbo.Baches.LP, dbo.Baches.LineaInvent, dbo.Baches.NomFor, dbo.BachesFylax.MoistureMeasured
FROM            dbo.BachesFylax INNER JOIN
                         dbo.Baches ON dbo.BachesFylax.Cont = dbo.Baches.Cont INNER JOIN
                         dbo.Consultas ON dbo.Baches.Fecha >= dbo.Consultas.F1 AND dbo.Baches.Fecha < dbo.Consultas.F2
GO

--********************************MODIFICACIONES 21-04-06 PROGRAMA EMPAQUE********************************************************************

ALTER TABLE dbo.ProgEmpaque ADD NomTolva varchar(5) not NULL default('-')


--*******************************MODIFICACIONES DESARROLLOS LUISA COCA 21-05-19***************************************************************

ALTER TABLE dbo.EmpEtiqDet ADD Cont int not null default(0)
ALTER TABLE dbo.Empaque ADD Ubicacion varchar(15) not null default('-')
ALTER TABLE dbo.Interfaz_Export ADD Observ varchar(100) not null default('-')

CREATE VIEW [dbo].[CEmpEtiqDet]
AS
SELECT dbo.EmpEtiqDet.OP, dbo.EmpEtiqDet.CodInt, dbo.EmpEtiqDet.Nombre, dbo.EmpEtiqDet.Tipo, dbo.EmpEtiqDet.CantBache, dbo.EmpEtiqDet.CantTotal, dbo.EmpEtiqDet.FechaIni, dbo.OPs.CodFor, dbo.OPs.NomFor, 
                  dbo.OPs.LP, dbo.OPs.CodProd, dbo.OPs.NomProd, dbo.OPs.LoteProd
FROM     dbo.EmpEtiqDet INNER JOIN
                  dbo.Consultas ON dbo.EmpEtiqDet.FechaIni >= dbo.Consultas.F1 AND dbo.EmpEtiqDet.FechaIni < dbo.Consultas.F2 INNER JOIN
                  dbo.OPs ON dbo.EmpEtiqDet.OP = dbo.OPs.OP

GO




--*********************************MODIFICACIONES PLANTA PREMEZCLAS, PRESENTACIONES POR CLIENTES**********************************************

ALTER TABLE dbo.EmpEtiqDet ADD NomCli varchar(30) not null default('-')
ALTER TABLE dbo.EmpEtiqDet ADD PresKg real not null default(0)


--*******************************MODIFICACIONES RECIBIRPT 21-06-03***************************************************************

ALTER TABLE dbo.Empaque ADD RegAjustado bit not null default(0)

--*********************************CORRECCION TABLA SECUENCIA DE MEZCLA ********************************************************

sp_helpconstraint CONTCRUZADA
alter table CONTCRUZADA drop constraint DF_ContCruzada_CodEspecie
alter table ContCruzada add default 'SA' for CodEspecie
alter table CONTCRUZADA drop constraint DF_ContCruzada_CodEspecieRestringida
alter table ContCruzada add default 'SA' for CodEspecieRestringida
alter table CONTCRUZADA drop constraint DF_ContCruzada_CodGrpFor
alter table ContCruzada add default 'SA' for CodGrpFor
alter table CONTCRUZADA drop constraint DF_ContCruzada_CodGrpForRestringida
alter table ContCruzada add default 'SA' for CodGrpForRestringida
alter table CONTCRUZADA drop constraint DF_ContCruzada_CodGrpMat
alter table ContCruzada add default 'SA' for CodGrpMat
alter table CONTCRUZADA drop constraint DF_ContCruzada_CodGrpMatRestringido
alter table ContCruzada add default 'SA' for CodGrpMatRestringido

update ContCruzada set CodEspecie='SA' where CodEspecie IN('-','','0')
update ContCruzada set CodEspecieRestringida='SA' where CodEspecieRestringida IN('-','','0')
update ContCruzada set CodGrpMat='SA' where CodGrpMat IN('-','','0')
update ContCruzada set CodGrpMatRestringido='SA' where CodGrpMatRestringido IN('-','','0')
update ContCruzada set CodGrpFor='SA' where CodGrpFor IN('-','','0')
update ContCruzada set CodGrpForRestringida='SA' where CodGrpForRestringida IN('-','','0')



--***********************************CAMBIOS PARA CONEXION PROCESO PAQUETEO********************************************************************

ALTER TABLE dbo.ProdEquivalentes ADD PresKg real not NULL default(0)
ALTER TABLE dbo.Config ADD FrecRepesoPk tinyint not NULL default(0)
ALTER TABLE dbo.Config ADD REPTOLINFPK real not NULL default(0)
ALTER TABLE dbo.Config ADD REPTOLSUPPK real not NULL default(0)

--***********************************CAMBIOS PARA MANEJO TABLA CONSUMOSTEMP*******************************************************************

ALTER TABLE dbo.Consumos ADD OP varchar(15) not NULL default('-')
ALTER TABLE dbo.Consumos ADD Compens varchar(15) not NULL default('-')

---TABLA CONSUMOSTEMP-----------------------------------------------
CREATE TABLE [dbo].[ConsumosTemp](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cont] [bigint] NOT NULL,
	[Paso] [smallint] NOT NULL,
	[CodForB] [nvarchar](15) NOT NULL,
	[CodFor] [nvarchar](15) NOT NULL,
	[CodMat] [nvarchar](15) NOT NULL,
	[CodMatB] [nvarchar](15) NOT NULL,
	[NomMat] [nvarchar](30) NOT NULL,
	[TipoMat] [smallint] NOT NULL,
	[PesoMeta] [decimal](18, 3) NOT NULL,
	[PesoReal] [decimal](18, 3) NOT NULL,
	[Lote] [nvarchar](15) NOT NULL,
	[Alarmas] [varchar](50) NOT NULL,
	[CorteLote] [int] NOT NULL,
	[Reportado] [bit] NOT NULL,
	[ProcesoMer] [int] NOT NULL,
	[Tolva] [real] NOT NULL,
	[ObservCostos] [nvarchar](250) NOT NULL,
	[Estado] [smallint] NOT NULL,
	[FechaExc] [nvarchar](20) NOT NULL,
	[UsuarioExc] [nvarchar](20) NOT NULL,
	[FechaExport] [nvarchar](20) NOT NULL,
	[UsuarioExport] [nvarchar](20) NOT NULL,
	[Costo] [real] NOT NULL,
	[Bascula] [tinyint] NOT NULL,
	[UbicLote] [nvarchar](30) NOT NULL,
	[Tipo] [varchar](5) NOT NULL,
	[NomTolva] [varchar](15) NOT NULL,
	[A] [varchar](5) NOT NULL,
	[OP] [varchar](15) NOT NULL,
	[Compens] [real] NOT NULL,
	[Fecha] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ConsumosTemp] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----TRIGGER para pasar consumostemp a consumos

CREATE TRIGGER [dbo].[CopiarRegistro] ON [dbo].[ConsumosTemp]
FOR    INSERT
AS
DECLARE 
@Cont		int,
@OP varchar(15),
@Paso smallint,
@CodForB varchar(15),
@CodFor varchar(15),
@CodMat varchar(15),
@CodMatB varchar(15),
@NomMat varchar(30),
@TipoMat smallint,
@PesoMeta decimal(18,3),
@PesoReal decimal(18,3),
@Lote varchar(15),
@Alarmas varchar(15),
@CorteLote		int,
@Tolva		smallint,
@Bascula		smallint,
@UbicLote		varchar(15),
@Tipo		varchar(5),
@NomTolva		varchar(15),
@A		varchar(5),
@Compens real

BEGIN
IF UPDATE(Cont)
	BEGIN
	
		SELECT @Cont=Cont FROM INSERTED
		SELECT @OP=OP FROM INSERTED
		SELECT @Paso=Paso FROM INSERTED
		SELECT @CodForB=CodForB FROM INSERTED
		SELECT @CodFor=CodFor FROM INSERTED
		SELECT @CodMat=CodMat FROM INSERTED
		SELECT @CodMatB=CodMatB FROM INSERTED
		SELECT @NomMat=NomMat FROM INSERTED
		SELECT @TipoMat=TipoMat FROM INSERTED
		SELECT @Lote=Lote FROM INSERTED
		SELECT @Alarmas=Alarmas FROM INSERTED
		SELECT @CorteLote=CorteLote FROM INSERTED
		SELECT @Tolva=Tolva FROM INSERTED
		SELECT @Bascula=Bascula FROM INSERTED
		SELECT @UbicLote=UbicLote FROM INSERTED
		SELECT @Tipo=Tipo FROM INSERTED
		SELECT @NomTolva=NomTolva FROM INSERTED
		SELECT @A=A FROM INSERTED
		SELECT @Compens=Compens FROM INSERTED
		SELECT @PesoMeta=PesoMeta FROM INSERTED
		SELECT @PesoReal=PesoReal FROM INSERTED

		INSERT INTO [dbo].[Consumos](Cont, OP,CodForB,CodFor,CodMat,CodMatB,NomMat,TipoMat,Lote,Alarmas,CorteLote,Tolva,Bascula,UbicLote,Tipo,NomTolva,A,Compens,Paso,PesoMeta,PesoReal)
		VALUES (@Cont, @OP,@CodForB,@CodFor,@CodMat,@CodMatB,@NomMat,@TipoMat,@Lote,@Alarmas,@CorteLote,@Tolva,@Bascula,@UbicLote,@Tipo,@NomTolva,@A,@Compens,@Paso,@PesoMeta,@PesoReal);
	END
END

---------------CAMBIOS UNIFICACION DE VERSIONES PARA MANEJO SERVICIO WEB CENTRAL BASCULA


INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('CortesCentralBascula','CentralBascula.ServicioWEB','Ya tiene actualizado el manejo de Servicio WEB',0,'-'); 



--------------CONSULTAS PARA REPORTE TRAZABILIDAD ---------------------------------------------------V.22.3.23.M

ALTER TABLE dbo.OPsFinPlanilla ADD EmpacadoKg real not NULL default(0)
ALTER TABLE dbo.OPsFinPlanilla ADD DiferenciaKg real not NULL default(0)

INSERT INTO ConfigReportes(nombreboton, TextoBoton,Contenedor,ReporteAsociado,Activo)
VALUES ('Empaque_Trazabilidad','Trazabilidad OP (Planilla Finalizada)','Empaque','rpTrazab01.rpt',1); 

CREATE TABLE [dbo].[TrazabSec](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FechaIni] [varchar](20) NOT NULL,
	[FechaFin] [varchar](20) NOT NULL,
	[Proceso] [varchar](30) NOT NULL,
	[ContIni] [bigint] NOT NULL,
	[ContFin] [bigint] NOT NULL,
	[OPAnt] [varchar](15) NOT NULL,
	[OPDesp] [varchar](15) NOT NULL,
	[ProdAnt] [varchar](30) NOT NULL,
	[ProdDesp] [varchar](30) NOT NULL,
	[Maquina] [tinyint] NOT NULL,
 CONSTRAINT [PK_TrazabSecuencia] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSecuencia_Fecha]  DEFAULT ('-') FOR [FechaIni]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSec_FechaIni1]  DEFAULT ('-') FOR [FechaFin]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSecuencia_Proceso]  DEFAULT ('-') FOR [Proceso]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSecuencia_OP]  DEFAULT ((0)) FOR [ContIni]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSec_ContIni1]  DEFAULT ((0)) FOR [ContFin]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSecuencia_OPAnt]  DEFAULT ('-') FOR [OPAnt]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_Table_1_OPAnt1]  DEFAULT ('-') FOR [OPDesp]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSecuencia_NomForAnt]  DEFAULT ('-') FOR [ProdAnt]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_Table_1_NomForAnt1]  DEFAULT ('-') FOR [ProdDesp]
GO

ALTER TABLE [dbo].[TrazabSec] ADD  CONSTRAINT [DF_TrazabSec_Maquina]  DEFAULT ((0)) FOR [Maquina]
GO





CREATE VIEW [dbo].[CTrazab01]
AS
SELECT        dbo.OPs.OP, dbo.Articulos.PresText, dbo.Tamizados.Maquina, dbo.Tamizados.PesoMalla6, dbo.Tamizados.PorcMalla6, dbo.Tamizados.PesoMalla8, dbo.Tamizados.PorcMalla8, dbo.Tamizados.PorcMalla16, 
                         dbo.Tamizados.PorcDurabilidad, dbo.Tamizados.Dureza, dbo.Tamizados.SitioMuestra, dbo.OPs.CodFor, dbo.OPs.LP, dbo.OPs.FechaIni, dbo.Tamizados.PesoMalla16, dbo.Articulos.PresEmp, dbo.Tamizados.PesoPlato, 
                         dbo.Tamizados.PorcPlato, dbo.Tamizados.Usuario, dbo.Articulos.ParmPorcMalla8, dbo.Articulos.ParmPorcMalla16, dbo.Articulos.ParmPorcPlato, dbo.Articulos.ParmDurabilidad, dbo.Articulos.ParmDureza, 
                         dbo.Articulos.ParmPorcMalla6, dbo.Articulos.ParmPorcMalla12, dbo.Articulos.ParmPorcMalla30, dbo.OPs.NomProd
FROM            dbo.OPs INNER JOIN
                         dbo.Consultas ON dbo.OPs.OP = dbo.Consultas.I2 LEFT OUTER JOIN
                         dbo.Articulos ON dbo.OPs.CodProd = dbo.Articulos.CodInt LEFT OUTER JOIN
                         dbo.Tamizados ON dbo.OPs.OP = dbo.Tamizados.OP
GO

CREATE VIEW [dbo].[CTrazab02]
AS
SELECT        SUM(dbo.Baches.PesoReal) AS DosifKg, SUM(dbo.Empaque.Peso) AS EmpKg, MIN(dbo.Empaque.FechaIni) AS FechaIniEmp, MIN(dbo.Empaque.Maquina) AS MaquinaEmp, SUM(dbo.Empaque.PesoReproceso) 
                         AS PesoReproceso, COUNT(DISTINCT dbo.Baches.Cont) AS Baches, dbo.Empaque.Maquina
FROM            dbo.Empaque RIGHT OUTER JOIN
                         dbo.Consultas ON dbo.Empaque.OP = dbo.Consultas.I2 LEFT OUTER JOIN
                         dbo.Baches ON dbo.Consultas.I2 = dbo.Baches.OP
GROUP BY dbo.Empaque.Maquina
HAVING        (dbo.Empaque.Maquina < 100)
GO


CREATE VIEW [dbo].[CTrazab03]
AS
SELECT        dbo.Baches.OP, dbo.Consumos.CodMat, dbo.Consumos.NomMat, dbo.Consumos.Lote, SUM(dbo.Consumos.PesoMeta) AS PesoMeta, SUM(dbo.Consumos.PesoReal) AS PesoReal, SUM(dbo.Consumos.PesoReal) 
                         - SUM(dbo.Consumos.PesoMeta) AS PesoDif
FROM            dbo.Consumos INNER JOIN
                         dbo.Baches ON dbo.Consumos.Cont = dbo.Baches.Cont INNER JOIN
                         dbo.Consultas ON dbo.Baches.OP = dbo.Consultas.I2
GROUP BY dbo.Baches.OP, dbo.Consumos.CodMat, dbo.Consumos.NomMat, dbo.Consumos.Lote
GO


-------------------------TABLAS PARA REPORTE HORA A HORA CON SISTEMA SIGCOPRO y ALARMA PORCENTAJE GRASA V.22.3.31.M------------------------------------

--Para estos datos hora, no olvidar poner en la tabla baches, cuando se captura el reporte el campo LINEAPRESENT, este dato viene de la OP

INSERT INTO ConfigParametros (Formulario, Parametro,Valor,Descripcion)
VALUES ('FORMULASDET','CODIGOMELAZA','513','Código melaza planta'); 


INSERT INTO ConfigFuncionalidades (Formulario, Funcion,Descripcion,Activa,SesionoNombrePC)
VALUES ('DatosHora','DatosHora.SCP','Traslado Info toneladas/Hora SCP',0,'-'); 

ALTER TABLE dbo.OPs ADD LineaPresent varchar(15) not NULL default('-')
ALTER TABLE dbo.Baches ADD LineaPresent varchar(15) not NULL default('-')
ALTER TABLE dbo.LineasProd ADD Present varchar(15) not NULL default('-')
ALTER TABLE dbo.Consumos ADD Fecha varchar(20) not NULL default('-')

CREATE TABLE [dbo].[DatosHora](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Hora] [tinyint] NOT NULL,
	[Fecha] [varchar](20) NOT NULL,
	[Baches] [smallint] NOT NULL,
	[TonHora] [real] NOT NULL,
	[Proceso] [varchar](30) NOT NULL,
	[Linea] [varchar](30) NOT NULL,
	[Maquina] [tinyint] NOT NULL,
	[TmpoMto] [real] NOT NULL,
	[Porc] [real] NOT NULL,
	[NumPesajes] [smallint] NOT NULL,
	[NumPesajesError] [smallint] NOT NULL,
	[CodTMuerto] [smallint] NOT NULL,
 CONSTRAINT [PK_DatosHora] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_Fecha]  DEFAULT ('-') FOR [Fecha]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_Baches]  DEFAULT ((0)) FOR [Baches]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_TonHora]  DEFAULT ((0)) FOR [TonHora]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_Linea]  DEFAULT ('-') FOR [Linea]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_Maquina]  DEFAULT ((0)) FOR [Maquina]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_TmpoMto]  DEFAULT ((0)) FOR [TmpoMto]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_Porc]  DEFAULT ((0)) FOR [Porc]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_NumPesajes]  DEFAULT ((0)) FOR [NumPesajes]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_NumPesajesError]  DEFAULT ((0)) FOR [NumPesajesError]
GO

ALTER TABLE [dbo].[DatosHora] ADD  CONSTRAINT [DF_DatosHora_CodTMuerto]  DEFAULT ((0)) FOR [CodTMuerto]
GO




CREATE VIEW [dbo].[CSCP_DatosHora]
AS
SELECT        TOP (100) PERCENT dbo.DatosHora.ID, dbo.DatosHora.Hora, dbo.DatosHora.Fecha, dbo.DatosHora.Baches, dbo.DatosHora.TonHora, dbo.DatosHora.Proceso, dbo.DatosHora.Linea, dbo.DatosHora.Maquina, 
                         dbo.DatosHora.Porc, dbo.DatosHora.TmpoMto, dbo.DatosHora.NumPesajes, dbo.DatosHora.NumPesajesError, dbo.DatosHora.CodTMuerto, dbo.TMuertosCat.Motivo
FROM            dbo.DatosHora INNER JOIN
                         dbo.Consultas ON dbo.DatosHora.Fecha >= dbo.Consultas.T9 LEFT OUTER JOIN
                         dbo.TMuertosCat ON dbo.DatosHora.CodTMuerto = dbo.TMuertosCat.CodMotivo
ORDER BY dbo.DatosHora.Fecha DESC
GO


---------------------------PERMISO PARA MODIFICAR EL CLIENTE DE LA OP V.22.4.21.M---------------------------------------------------------------

INSERT INTO UsuariosPermisos (Permiso, PermisoAnterior,TextoBoton,Descripcion)  --Permiso para modificar cliente en la op
VALUES ('OPs_EditarCliente','-','Modificar Cliente de una OP','Permite modificar el cliente a una OP ya lanzada a producción');

--------------ADICIÓN DE POCENTAJE DE AGUA EN FORMULAS PARA SISTEMA FYLAX ---------------------------------------------------V.22.5.25.M

ALTER TABLE dbo.Formulas ADD PorcAdicAgua real not NULL default(0.92)


-------------CONSULTAS TRASLADO PARAMETROS DE CALIDAD A SIGCOPRO  V.22.6.25.M -----------------------------------------------------------

ALTER TABLE dbo.Consultas ADD FIniTurno varchar(20) not NULL default('-')
ALTER TABLE dbo.Consultas ADD FIniHora varchar(20) not NULL default('-')
ALTER TABLE dbo.Consultas ADD FIniProdProceso varchar(20) not NULL default('-')
ALTER TABLE dbo.Tolvas ADD EsTolvaLiquidos bit not NULL default(0)

CREATE VIEW [dbo].[CSCP_ConsGrasa]
AS
SELECT        dbo.ConsumosEng.CodMat, dbo.ConsumosEng.PesoMeta * dbo.OPs.Real AS PesoMeta, SUM(dbo.ConsumosEng.PesoReal) AS PesoReal, dbo.ConsumosEng.OP, MIN(dbo.ConsumosEng.Fecha) AS FechaIni, 
                         ((SUM(dbo.ConsumosEng.PesoReal) - dbo.ConsumosEng.PesoMeta * dbo.OPs.Real) * 100) / (dbo.ConsumosEng.PesoMeta * dbo.OPs.Real + 0.0000000000000001) AS ErrorPorc
FROM            dbo.OPs INNER JOIN
                         dbo.Consultas INNER JOIN
                         dbo.ConsumosEng ON dbo.Consultas.FIniTurno <= dbo.ConsumosEng.Fecha ON dbo.OPs.OP = dbo.ConsumosEng.OP
GROUP BY dbo.ConsumosEng.OP, dbo.ConsumosEng.CodMat, dbo.ConsumosEng.NomMat, dbo.OPs.CodFor, dbo.OPs.CodProd, dbo.OPs.NomProd, dbo.OPs.NomFor, dbo.OPs.LP, dbo.ConsumosEng.Tolva, 
                         dbo.OPs.Real, dbo.ConsumosEng.PesoMeta
GO

CREATE VIEW [dbo].[CSCP_ConsGrasaNoCumple]
AS
SELECT        COUNT(OP) AS NumNoCumplen
FROM            dbo.CSCP_ConsGrasa
WHERE        (ABS(ErrorPorc) > 5)
GO

CREATE VIEW [dbo].[CSCP_CortesMP]
AS
SELECT        dbo.CortesLote.Cont, dbo.CortesLote.CodMat, dbo.CortesLote.Lote, dbo.CortesLote.Consumo AS Real, dbo.CortesLote.InvIni, dbo.CortesLote.Ajuste1 AS AjusteSal, dbo.CortesLote.Ajuste2 AS AjusteEnt, 
                         dbo.CortesLote.Ajuste3 AS EntradaInv, dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni AS TotalEnt, dbo.CortesLote.Ajuste4 AS SalidaInv, dbo.CortesLote.InvFin, 
                         (dbo.CortesLote.Ajuste4 + dbo.CortesLote.Ajuste1 - dbo.CortesLote.Consumo) * - 1 AS TotalSal, dbo.CortesLote.Consumo, dbo.CortesLote.Estado, dbo.CortesLote.Finalizado, dbo.CortesLote.Vigente, dbo.CortesLote.Observ, 
                         dbo.CortesLote.PorcMerma, dbo.CortesLote.FechaIni, dbo.CortesLote.FechaFin, CASE WHEN len(dbo.CortesLote.FechaFin) >= 16 THEN DATEDIFF(d, CONVERT(datetime, dbo.CortesLote.FechaIni, 120), CONVERT(datetime, 
                         dbo.CortesLote.FechaFin, 120)) ELSE '0' END AS DiasConsumo, (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni) 
                         AS Diferencia, CASE WHEN (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) <> 0 THEN ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) 
                         - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) / ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo)) * 100 ELSE '0' END AS Porcentaje, 
                         CASE WHEN abs(((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) 
                         / ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000000000000001)) * 100) > dbo.corteslote.PorcMerma THEN 'NO' ELSE 'SI' END AS Cumple, 
                         CASE WHEN ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) 
                         / (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000001) > 0 THEN ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) 
                         - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) / (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000001) 
                         * 100 - dbo.CortesLote.PorcMerma ELSE ((- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo) - (dbo.CortesLote.Ajuste3 + dbo.CortesLote.Ajuste2 + dbo.CortesLote.InvIni)) 
                         / (- dbo.CortesLote.Ajuste4 - dbo.CortesLote.Ajuste1 + dbo.CortesLote.Consumo + 0.000000000001) * 100 + dbo.CortesLote.PorcMerma END AS VariacionVsParametro, dbo.CortesLote.Linea, dbo.CortesLote.NomMat, 
                         dbo.CortesLote.Descartado
FROM            dbo.CortesLote INNER JOIN
                         dbo.Consultas ON dbo.CortesLote.FechaFinalizado >= dbo.Consultas.FIniTurno
GROUP BY dbo.CortesLote.Cont, dbo.CortesLote.Lote, dbo.CortesLote.InvIni, dbo.CortesLote.Ajuste1, dbo.CortesLote.Ajuste2, dbo.CortesLote.Ajuste3, dbo.CortesLote.Ajuste4, dbo.CortesLote.InvFin, dbo.CortesLote.Consumo, 
                         dbo.CortesLote.Estado, dbo.CortesLote.Finalizado, dbo.CortesLote.Vigente, dbo.CortesLote.Condicion, dbo.CortesLote.PesoProm, dbo.CortesLote.NomMat, dbo.CortesLote.Observ, dbo.CortesLote.PorcMerma, 
                         dbo.CortesLote.FechaIni, dbo.CortesLote.FechaFin, dbo.CortesLote.Linea, dbo.CortesLote.Consumo, dbo.CortesLote.CodMat, dbo.CortesLote.Descartado
HAVING        (dbo.CortesLote.Finalizado = N'S') AND (dbo.CortesLote.Consumo > 0)
GO

CREATE VIEW [dbo].[CSCP_CortesMP_NoCumplen]
AS
SELECT        COUNT(Cont) AS NumNoCumplen, Linea
FROM            dbo.CSCP_CortesMP
WHERE        (Cumple = 'NO')
GROUP BY Linea
GO

CREATE VIEW [dbo].[CSCP_ErrorTolvas]
AS
SELECT        COUNT((dbo.Consumos.PesoReal - dbo.Consumos.PesoMeta) * 100 / dbo.Consumos.PesoMeta) AS NumError
FROM            dbo.Consumos INNER JOIN
                         dbo.Tolvas ON dbo.Consumos.Tolva = dbo.Tolvas.Tolva RIGHT OUTER JOIN
                         dbo.Baches ON dbo.Consumos.Cont = dbo.Baches.Cont LEFT OUTER JOIN
                         dbo.Consultas ON dbo.Baches.Enlace = dbo.Consultas.Enlace
WHERE        (dbo.Baches.Fecha >= dbo.Consultas.FIniHora) AND (dbo.Consumos.TipoMat >= 1) AND (dbo.Tolvas.Proceso = 'DOSIFICACION') AND (dbo.Consumos.TipoMat <= 2) AND (dbo.Consumos.PesoMeta > 0) AND 
                         (ABS((dbo.Consumos.PesoReal - dbo.Consumos.PesoMeta) * 100 / dbo.Consumos.PesoMeta) >= 2) AND (dbo.Tolvas.EsTolvaLiquidos = 0)
GO

CREATE VIEW [dbo].[CSCP_Humedades]
AS
SELECT        dbo.Humedades.OP, MAX(dbo.Humedades.PorcGanancia) AS PorcGanancia, dbo.Humedades.Maquina
FROM            dbo.Humedades INNER JOIN
                         dbo.OPs ON dbo.Humedades.OP = dbo.OPs.OP
WHERE        (dbo.OPs.FinPlanilla <> N'S')
GROUP BY dbo.Humedades.OP, dbo.Humedades.Maquina
GO

CREATE VIEW [dbo].[CSCP_ConsumosOPTot]
AS
SELECT        CONVERT(int, dbo.Baches.OP) AS OP, MAX(dbo.OPs.CodProd) AS CodProd, MAX(dbo.Baches.CodFor) AS CodFor, MAX(dbo.Baches.CodForB) AS CodForB, MAX(dbo.Baches.NomFor) AS NomFor, SUM(dbo.Consumos.PesoReal) 
                         AS PesoReal, SUM(dbo.Consumos.PesoMeta) AS PesoMeta, MIN(dbo.Baches.Fecha) AS FechaIni, MAX(dbo.Baches.Fecha) AS FechaFin, dbo.OPs.GrasaExt, dbo.OPs.FinPlanilla, dbo.OPs.Meta, dbo.OPs.Real, 
                         dbo.OPs.Reproceso, dbo.OPs.DifHumedad, dbo.OPs.ObservFinPlanilla, dbo.OPs.Equipo, dbo.OPs.LineaInvent, dbo.OPs.LP, dbo.OPs.Ventas, dbo.OPs.LineaExterna
FROM            dbo.Consultas INNER JOIN
                         dbo.OPs INNER JOIN
                         dbo.Baches INNER JOIN
                         dbo.Consumos ON dbo.Baches.Cont = dbo.Consumos.Cont ON dbo.OPs.OP = dbo.Baches.OP ON dbo.Consultas.FIniProdProceso <= dbo.Baches.Fecha
GROUP BY dbo.Baches.OP, dbo.OPs.GrasaExt, dbo.OPs.FinPlanilla, dbo.OPs.Meta, dbo.OPs.Real, dbo.OPs.Reproceso, dbo.OPs.DifHumedad, dbo.OPs.ObservFinPlanilla, dbo.OPs.Equipo, dbo.OPs.LineaInvent, dbo.OPs.LP, 
                         dbo.OPs.Ventas, dbo.OPs.LineaExterna
GO


CREATE VIEW [dbo].[CSCP_ProdProceso]
AS
SELECT        OP, CONVERT(decimal(10, 1), DATEDIFF(HOUR, MIN(FechaIni), GETDATE()) / 24.0) AS Dias
FROM            dbo.CSCP_ConsumosOPTot
WHERE        (FinPlanilla <> N'S')
GROUP BY OP
GO

CREATE VIEW [dbo].[CSCP_NumOPsProdProceso]
AS
SELECT        COUNT(OP) AS NumOPs
FROM            dbo.CSCP_ProdProceso
WHERE        (Dias > 2)
GO

CREATE VIEW [dbo].[CSCP_OpsFueraNorma_Extruido]
AS
SELECT        COUNT(dbo.OPs.OP) AS NumOPsFueraNorma, MIN(dbo.OPs.LineaPresent) AS Linea
FROM            dbo.OPsFinPlanilla INNER JOIN
                         dbo.OPs ON dbo.OPsFinPlanilla.OP = dbo.OPs.OP INNER JOIN
                         dbo.Consultas ON dbo.OPs.FechaFinPlanilla >= dbo.Consultas.FIniTurno
WHERE        (ABS(dbo.OPsFinPlanilla.SackOffPorc) > 2) AND (dbo.OPs.LineaPresent = 'EXTRUIDO')
GROUP BY dbo.OPs.LineaPresent
GO

CREATE VIEW [dbo].[CSCP_OPsFueraNorma_Pelet]
AS
SELECT        COUNT(dbo.OPs.OP) AS NumOPsFueraNorma, MIN(dbo.OPs.LineaPresent) AS Linea
FROM            dbo.OPsFinPlanilla INNER JOIN
                         dbo.OPs ON dbo.OPsFinPlanilla.OP = dbo.OPs.OP INNER JOIN
                         dbo.Consultas ON dbo.OPs.FechaFinPlanilla >= dbo.Consultas.FIniTurno
WHERE        (ABS(dbo.OPsFinPlanilla.SackOffPorc) > 1.5) AND (dbo.OPs.LineaPresent = 'PELETIZADO')
GROUP BY dbo.OPs.LineaPresent
GO

CREATE VIEW [dbo].[CSCP_Tamizados]
AS
SELECT        dbo.Tamizados.OP, AVG(dbo.Tamizados.PorcMalla8) AS PorcMalla8, AVG(dbo.Tamizados.PorcMalla12) AS PorcMalla12, AVG(dbo.Tamizados.PorcMalla16) AS PorcMalla16, AVG(dbo.Tamizados.PorcPlato) AS PorcPlato, 
                         AVG(dbo.Tamizados.PorcDurabilidad) AS PorcDurabilidad, AVG(dbo.Tamizados.Dureza) AS Dureza, dbo.Tamizados.Maquina, dbo.Tamizados.SitioMuestra, MIN(dbo.Articulos.ParmPorcMalla8) AS ParmPorcMalla8, 
                         MIN(dbo.Articulos.ParmPorcMalla16) AS ParmPorcMalla16, MIN(dbo.Articulos.ParmPorcPlato) AS ParmPorcPlato, MIN(dbo.Articulos.ParmDurabilidad) AS ParmDurabilidad, MIN(dbo.Articulos.ParmDureza) AS ParmDureza
FROM            dbo.OPs INNER JOIN
                         dbo.Articulos ON dbo.OPs.CodProd = dbo.Articulos.CodInt RIGHT OUTER JOIN
                         dbo.Tamizados ON dbo.OPs.OP = dbo.Tamizados.OP
WHERE        (dbo.OPs.FinPlanilla <> N'S') AND (dbo.Tamizados.SitioMuestra <> '-')
GROUP BY dbo.Tamizados.OP, dbo.Tamizados.Maquina, dbo.Tamizados.SitioMuestra, dbo.Articulos.ParmPorcMalla16, dbo.Articulos.ParmPorcPlato, dbo.Articulos.ParmDurabilidad, dbo.Articulos.ParmDureza
GO

CREATE VIEW [dbo].[CSCP_TiemposMuertos]
AS
SELECT        dbo.TMuertos.Proceso, MAX(dbo.TMuertos.Tiempo) AS MaxTiempo, MAX(dbo.TMuertos.CodMotivo) AS CodMotivo, MAX(dbo.TMuertosCat.Motivo) AS Motivo, MAX(dbo.TMuertos.Observacion) AS Observacion
FROM            dbo.Consultas INNER JOIN
                         dbo.TMuertos INNER JOIN
                         dbo.TMuertosCat ON dbo.TMuertos.CodMotivo = dbo.TMuertosCat.CodMotivo ON dbo.Consultas.FIniTurno <= dbo.TMuertos.Fecha
GROUP BY dbo.TMuertosCat.CodMotivo, dbo.TMuertos.Proceso
GO
