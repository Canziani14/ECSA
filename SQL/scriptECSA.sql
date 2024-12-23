CREATE DATABASE ECSA
USE [ECSA]
GO
/****** Object:  User [canziani]    Script Date: 9/11/2024 19:59:57 ******/
CREATE USER [canziani] FOR LOGIN [canziani] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [canziani]
GO
ALTER ROLE [db_datareader] ADD MEMBER [canziani]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [canziani]
GO
/****** Object:  Table [dbo].[Alerta]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alerta](
	[ID_Alerta] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Nivel_Critico] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Alerta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Backup]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Backup](
	[ID_Backup] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Resultado] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Backup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NULL,
	[Descripcion] [varchar](1000) NULL,
	[Criticidad] [int] NULL,
	[ID_Usuario] [int] NULL,
	[NickUsuarioLogin] [nchar](50) NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK__Bitacora__1D88869D00E87099] PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coche]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coche](
	[Interno] [int] IDENTITY(1,1) NOT NULL,
	[Patente] [varchar](50) NULL,
	[ID_Linea] [int] NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK__Coche__61B4766A0A58E85E] PRIMARY KEY CLUSTERED 
(
	[Interno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[Tabla] [nvarchar](50) NOT NULL,
	[DVV] [decimal](38, 0) NULL,
 CONSTRAINT [PK__Digito_V__0FAF64D2682304D0] PRIMARY KEY CLUSTERED 
(
	[Tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Legajo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[DNI] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL,
	[FechaIngreso] [date] NULL,
	[ID_Linea] [int] NULL,
	[DVH] [decimal](38, 0) NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK__Empleado__0E01039BAF72650C] PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[ID_Familia] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[ID_Familia] [int] NOT NULL,
	[ID_Patente] [int] NOT NULL,
	[DVH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC,
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[ID_Idioma] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Linea]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linea](
	[ID_Linea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Linea] [varchar](50) NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK__Linea__8CE1AAB0EE13D1C7] PRIMARY KEY CLUSTERED 
(
	[ID_Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[ID_Patente] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK__Patente__03A881DBCEB172FC] PRIMARY KEY CLUSTERED 
(
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ID_Servicio] [int] IDENTITY(1,1) NOT NULL,
	[Hora_Cabecera_Principal] [datetime] NULL,
	[Hora_Cabecera_Retorno] [datetime] NULL,
	[Legajo] [int] NULL,
	[Interno] [int] NULL,
	[ID_Linea] [int] NULL,
	[DVH] [int] NULL,
 CONSTRAINT [PK__Servicio__1932F584037A1348] PRIMARY KEY CLUSTERED 
(
	[ID_Servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traduccion]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[ID_Traduccion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[ID_Idioma] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Traduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[DNI] [varchar](50) NULL,
	[Nick] [varchar](50) NULL,
	[Mail] [varchar](255) NULL,
	[Contraseña] [varchar](50) NULL,
	[Contador_Int_Fallidos] [int] NULL,
	[DVH] [int] NULL,
	[Estado] [bit] NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK__Usuario__DE4431C55FF61783] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Familia](
	[ID_Usuario] [int] NOT NULL,
	[ID_Familia] [int] NOT NULL,
	[DVH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 9/11/2024 19:59:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Patente](
	[ID_Usuario] [int] NOT NULL,
	[ID_Patente] [int] NOT NULL,
	[DVH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Bitacora', CAST(11789001 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Coche', CAST(577531 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Empleado', CAST(3235287 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Familia_Patente', CAST(11937 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Linea', CAST(1806 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Servicio', CAST(1779166 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Usuario', CAST(54073 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Usuario_Familia', CAST(467 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Usuario_Patente', CAST(9241 AS Decimal(38, 0)))
GO



SET IDENTITY_INSERT [dbo].[Familia] ON 

INSERT [dbo].[Familia] ([ID_Familia], [Descripcion]) VALUES (1, N'Admin')
INSERT [dbo].[Familia] ([ID_Familia], [Descripcion]) VALUES (2, N'DBA')
INSERT [dbo].[Familia] ([ID_Familia], [Descripcion]) VALUES (3, N'RRHH')
INSERT [dbo].[Familia] ([ID_Familia], [Descripcion]) VALUES (4, N'Roles')
INSERT [dbo].[Familia] ([ID_Familia], [Descripcion]) VALUES (5, N'Gerencial')
INSERT [dbo].[Familia] ([ID_Familia], [Descripcion]) VALUES (8, N'Diagramador')
SET IDENTITY_INSERT [dbo].[Familia] OFF
GO
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 1, 98)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 2, 99)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 3, 100)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 6, 103)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 7, 104)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 8, 105)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 9, 106)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 10, 146)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 11, 147)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 12, 148)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 13, 149)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 14, 150)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 15, 151)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 16, 152)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 17, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 18, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 19, 155)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 20, 147)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 21, 148)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 22, 149)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 23, 150)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 24, 151)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 25, 152)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 26, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 27, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 28, 155)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 29, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 30, 148)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 31, 149)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 32, 150)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 33, 151)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 34, 152)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 35, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 36, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 37, 155)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 38, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 39, 157)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 40, 149)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 41, 150)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 42, 151)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 43, 152)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 44, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 45, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (1, 46, 155)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (2, 32, 151)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (2, 33, 152)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (2, 37, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (2, 44, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 1, 100)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 2, 101)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 6, 105)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 7, 106)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 8, 107)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 36, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (3, 39, 159)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 3, 103)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 23, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 24, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 25, 155)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 27, 157)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 29, 159)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 30, 151)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 31, 152)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 35, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 41, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (4, 42, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (5, 43, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (5, 44, 157)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 10, 153)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 11, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 12, 155)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 13, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 14, 157)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 15, 158)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 16, 159)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 17, 160)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 18, 161)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 20, 154)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 22, 156)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 38, 163)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 39, 164)
INSERT [dbo].[Familia_Patente] ([ID_Familia], [ID_Patente], [DVH]) VALUES (8, 40, 156)
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([ID_Idioma], [Descripcion]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([ID_Idioma], [Descripcion]) VALUES (2, N'Inglés')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO

SET IDENTITY_INSERT [dbo].[Patente] ON 

INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (1, N'Permiso para bloquear usuario')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (2, N'Permiso para desbloquear usuario')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (3, N'Permiso para asignar patentes a las familias')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (4, N'Operator')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (5, N'Viewer')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (6, N'Permiso para crear nuevos empleados.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (7, N'Permiso para modificar datos de empleados existentes.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (8, N'Permiso para eliminar empleados.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (9, N'Permiso para ver la información de empleados.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (10, N'Permiso para crear nuevos coches.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (11, N'Permiso para modificar datos de coches existentes.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (12, N'Permiso para eliminar coches.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (13, N'Permiso para ver la información de los coches.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (14, N'Permiso para crear nuevas líneas de transporte.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (15, N'Permiso para modificar líneas de transporte existentes.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (16, N'Permiso para eliminar líneas de transporte.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (17, N'Permiso para ver la información de las líneas de transporte.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (18, N'Permiso para crear nuevos servicios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (19, N'Permiso para modificar servicios existentes.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (20, N'Permiso para eliminar servicios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (21, N'Permiso para ver la información de los servicios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (22, N'Permiso para asignar servicios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (23, N'Permiso para crear nuevos usuarios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (24, N'Permiso para modificar datos de usuarios existentes.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (25, N'Permiso para eliminar usuarios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (26, N'Permiso para ver la información de los usuarios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (27, N'Permiso para crear nuevas familias.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (28, N'Permiso para modificar familias existentes.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (29, N'Permiso para eliminar familias.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (30, N'Permiso para ver la información de las familias.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (31, N'Permiso para consultar la bitácora del sistema.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (32, N'Permiso para realizar respaldos del sistema.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (33, N'Permiso para restaurar respaldos del sistema.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (34, N'Permiso para asignar permisos (patentes) a los usuarios.')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (35, N'Permiso para gestionar usuarios')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (36, N'Permiso para gestionar empleados')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (37, N'Permiso para gestionar BKP')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (38, N'Permiso para gestionar Lineas')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (39, N'Permiso para gestionar Servicios')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (40, N'Permiso para gestionar Coches')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (41, N'Permiso para gestionar Patentes')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (42, N'Permiso para gestionar Familias')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (43, N'Permiso para visualizar reportes')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (44, N'Permiso para visualizar bitacora')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (45, N'Permiso para visualizar alertas')
INSERT [dbo].[Patente] ([ID_Patente], [Descripcion]) VALUES (46, N'Permiso para imprimir planillas de servicio')
SET IDENTITY_INSERT [dbo].[Patente] OFF
GO








SET IDENTITY_INSERT [dbo].[Traduccion] ON 

INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (1, N'Crear', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (2, N'Create', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (3, N'Modificar', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (4, N'Edit', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (5, N'Eliminar', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (6, N'Delete', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (7, N'Bloquear Usuario', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (8, N'Block User', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (9, N'Desbloquear Usuario', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (10, N'Unblock User', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (11, N'Gestionar Empleados', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (12, N'Manage Employees', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (13, N'Gestionar Líneas', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (14, N'Manage Lines', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (15, N'Gestionar Usuarios', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (16, N'Manage Users', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (17, N'Gestionar Backup', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (18, N'Manage Backup', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (19, N'Gestionar Patentes', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (20, N'Manage Licenses', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (21, N'Gestionar Familias', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (22, N'Manage Families', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (23, N'Generar Reportes', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (24, N'Generate Reports', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (25, N'Gestionar Coches', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (26, N'Manage Cars', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (27, N'Gestionar Servicios', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (28, N'Manage Services', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (29, N'Ver Alertas', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (30, N'View Alerts', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (31, N'Consultar Bitácora', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (32, N'View Log', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (33, N'Cerrar Sesión', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (34, N'Log Out', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (35, N'Cambiar Contraseña', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (36, N'Change Password', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (37, N'Ayuda', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (38, N'Help', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (39, N'Buscar', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (40, N'Search', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (41, N'Asignar Servicio', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (42, N'Assign Service', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (43, N'Imprimir Planilla de Servicio', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (44, N'Print Service Sheet', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (45, N'Realizar Backup', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (46, N'Perform Backup', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (47, N'Realizar Restore', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (48, N'Perform Restore', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (49, N'Generar Nueva Contraseña', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (50, N'Generate New Password', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (51, N'Seleccionar Archivo', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (52, N'Select File', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (53, N'Cambiar Contraseña', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (54, N'Change Password', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (55, N'Descargar Bitácora', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (56, N'Download Log', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (57, N'Seleccionar un Reporte', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (58, N'Select a Report', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (59, N'Desde:', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (60, N'From:', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (61, N'Hasta:', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (62, N'To:', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (63, N'Buscar Usuario', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (64, N'Search User', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (65, N'ID_Usuario', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (66, N'User_ID', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (67, N'Nombre', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (68, N'Name', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (69, N'Apellido', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (70, N'Surname', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (71, N'DNI', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (72, N'ID Number', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (73, N'Nick', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (74, N'Nickname', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (75, N'Mail', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (76, N'Email', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (77, N'Gestor de Familias por Usuario', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (78, N'User Family Manager', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (79, N'Asignadas', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (80, N'Assigned', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (81, N'Sin Asignar', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (82, N'Unassigned', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (83, N'ID', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (84, N'ID', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (85, N'Línea', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (86, N'Line', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (87, N'Horario Terminal Principal', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (88, N'Main Terminal Schedule', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (89, N'Horario Terminal Rebote', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (90, N'Bounce Terminal Schedule', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (91, N'Servicio', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (92, N'Service', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (93, N'Despachos', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (94, N'Dispatches', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (95, N'Interno', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (96, N'Internal', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (97, N'Conductor', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (98, N'Driver', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (99, N'Gestor de Patentes', 1)
GO
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (100, N'License Manager', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (101, N'Gestor de Familias', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (102, N'Family Manager', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (103, N'Patentes Actuales', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (104, N'Current Licenses', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (105, N'Patentes Sin Asignar', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (106, N'Unassigned Licenses', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (107, N'Buscar Empleado:', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (108, N'Search Employee:', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (109, N'Dirección', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (110, N'Address', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (111, N'Teléfono', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (112, N'Phone', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (113, N'Fecha de Ingreso', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (114, N'Date of Entry', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (115, N'Legajo', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (116, N'Employee Number', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (117, N'Buscar Interno:', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (118, N'Search Internal:', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (119, N'Gestor de Coches', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (120, N'Car Manager', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (121, N'Patente', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (122, N'License Plate', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (123, N'Línea a Asignar', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (124, N'Line to Assign', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (125, N'Ingrese su Mail', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (126, N'Enter your Email', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (127, N'Ingrese Contraseña Actual', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (128, N'Enter Current Password', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (129, N'Ingrese Contraseña Nueva', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (130, N'Enter New Password', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (131, N'Confirme Contraseña Nueva', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (132, N'Confirm New Password', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (133, N'Fecha Desde', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (134, N'Date From', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (135, N'Fecha Hasta', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (136, N'Date To', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (137, N'Alertas con Alto Nivel de Criticidad', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (138, N'High Criticality Alerts', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (139, N'Familia', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (140, N'Family', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (141, N'Recuperar Usuario', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (142, N'Recover User', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (143, N'Recuperar Empleado', 1)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (144, N'Recover Employee', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (145, N'description', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (146, N'Date', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (147, N'Criticality', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (148, N'State', 2)
INSERT [dbo].[Traduccion] ([ID_Traduccion], [Descripcion], [ID_Idioma]) VALUES (149, N'Removed', 2)
SET IDENTITY_INSERT [dbo].[Traduccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 


INSERT [dbo].[Usuario] ([ID_Usuario], [Nombre], [Apellido], [DNI], [Nick], [Mail], [Contraseña], [Contador_Int_Fallidos], [DVH], [Estado], [Eliminado]) VALUES (56, N'YQBkAG0AaQBuAA==', N'YQBkAG0AaQBuAA==', N'MQAyADMANAA1ADYANwA4AA==', N'YQBkAG0AaQBuAA==', N'YQBkAG0AaQBuAEAAZwBtAGEAaQBsAC4AYwBvAG0A', N'de51da8bca0399fe513a3a069e2c97f3', 0, 11796, 1, 1)

SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO

INSERT [dbo].[Usuario_Familia] ([ID_Usuario], [ID_Familia], [DVH]) VALUES (56, 1, 156)
GO
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 1, 157)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 2, 158)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 3, 159)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 4, 160)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 5, 161)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 6, 162)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 7, 163)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 8, 164)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 9, 165)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 10, 205)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 11, 206)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 12, 207)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 13, 208)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 14, 209)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 15, 210)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 16, 211)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 17, 212)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 18, 213)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 19, 214)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 20, 206)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 21, 207)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 22, 208)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 23, 209)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 24, 210)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 25, 211)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 26, 212)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 27, 213)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 28, 214)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 29, 215)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 30, 207)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 31, 208)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 32, 209)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 33, 210)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 34, 211)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 35, 212)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 36, 213)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 37, 214)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 38, 215)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 39, 216)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 40, 208)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 41, 209)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 42, 210)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 43, 211)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 44, 212)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 45, 213)
INSERT [dbo].[Usuario_Patente] ([ID_Usuario], [ID_Patente], [DVH]) VALUES (57, 46, 214)
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_ID_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_ID_Usuario]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__ID_Lin__3B75D760] FOREIGN KEY([ID_Linea])
REFERENCES [dbo].[Linea] ([ID_Linea])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__ID_Lin__3B75D760]
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK__Familia_P__ID_Pa__4D94879B] FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
GO
ALTER TABLE [dbo].[Familia_Patente] CHECK CONSTRAINT [FK__Familia_P__ID_Pa__4D94879B]
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Patente] FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Familia_Patente] CHECK CONSTRAINT [FK_Familia_Patente]
GO
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD FOREIGN KEY([ID_Idioma])
REFERENCES [dbo].[Idioma] ([ID_Idioma])
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_F__ID_Us__5070F446] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_Familia] CHECK CONSTRAINT [FK__Usuario_F__ID_Us__5070F446]
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Familia] FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_Familia] CHECK CONSTRAINT [FK_Usuario_Familia]
GO
ALTER TABLE [dbo].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_P__ID_Pa__47DBAE45] FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
GO
ALTER TABLE [dbo].[Usuario_Patente] CHECK CONSTRAINT [FK__Usuario_P__ID_Pa__47DBAE45]
GO
ALTER TABLE [dbo].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_P__ID_Us__46E78A0C] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_Patente] CHECK CONSTRAINT [FK__Usuario_P__ID_Us__46E78A0C]
GO
