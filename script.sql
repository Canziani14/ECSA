CREATE DATABASE ECSA
USE [ECSA]
GO
/****** Object:  Table [dbo].[Backup]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Coche]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[DVV]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Familia]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Idioma]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Linea]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Patente]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Servicio]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Traduccion]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 4/11/2024 18:29:26 ******/
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
/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 4/11/2024 18:29:26 ******/
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

SET IDENTITY_INSERT [dbo].[Coche] ON 

INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (7, N'YQBzAGQAYQBzAGQA', 1, 1384)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (9, N'YQBjADIANwAxAHgAawA=', 1, 1748)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (10, N'YQBjADIANwAxAHYAZgA=', 1, 1751)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (11, N'YQBzAGQA', 1, 787)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (12, N'YwBzAGEAZgBhAHMAZAA=', 1, 1737)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (13, N'ZwByAA==', 1, 797)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (14, N'YQBzAGQAYQBkAA==', 1, 1385)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (16, N'YQBzAGQAYQBzAGQAYQBzAA==', 5, 2046)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (17, N'YgBtAHcANQA0ADYA', 9, 1395)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (18, N'YQBzAGQAYQBzAGQA', 1, 1434)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (22, N'MgBJAFoAUwBWADgATABYAFIAQgBHAEgAMQA1ADcAMwAxAA==', 7, 3847)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (23, N'WgA2AEsAQgBUADMAVwBEADQATgBRAFcANQA1ADQAOAA3AA==', 8, 3703)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (24, N'QgBNAEYAWgBPAEEANwBQAEsAQgBSAEoANQAzADAANwAyAA==', 1, 3916)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (25, N'QQBOADMARAAwADkAUwBEAEYARQBZADEANgA3ADYAMAA0AA==', 8, 3681)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (26, N'RQBCADYAWQBRAE8ATQA1AFcAOQBWAFIAMgA2ADgANAAxAA==', 1, 3647)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (27, N'TAA4AE4AQQBMAFIAMgBHAEsAOQBXADgAMgAxADgAOQAyAA==', 8, 3767)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (28, N'NwAwADIATQBOAEkAQQA4ADUAUABVAFMANQA1ADMAMgAwAA==', 1, 3728)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (29, N'UQBVAEoAOQAyAEgAUgA3AFIATgBMAFYANgA0ADUAMgAzAA==', 8, 3831)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (30, N'UgBYADMASABKAE4AWABXADcANwBDAE8AOQA5ADYAMgAzAA==', 7, 3685)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (31, N'MwBZAEgAVAA5AFgAUQBRAFAATABFAE4AMgA3ADIANQAyAA==', 1, 3654)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (32, N'OABFADYAUwBXAEQASAA3AEwAQQBHAFUAMgA4ADcAOAAyAA==', 8, 3705)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (33, N'TgBDADUARQBIAEUAMwBUADUATQBQAE8AMgA3ADkAMQA5AA==', 1, 3667)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (34, N'NwBIAEIAVwBHAFgATgBTADAAQQBVAE0AOAA4ADEAMwA2AA==', 8, 3665)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (35, N'QwA3AEsARgBRAFYAMgBEAEYAUwBEAFMAOQAxADMANAAyAA==', 7, 3831)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (36, N'OQBLADcAOAA2AEcAWgAzAFoAQgBKADkAMgA4ADAANAA3AA==', 8, 3706)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (37, N'QgBWAE0AVgBKADgARwBYADEANgBZAEIAOQA1ADEANwA2AA==', 8, 3714)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (38, N'MQBJAFIATwAwADcASQBGADMASgBMAEUAOAA5ADYANwAxAA==', 1, 3783)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (39, N'NwA5ADEARwBPADgAMQBLADUAOQBHAE8AOQA4ADMAOAAxAA==', 1, 3656)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (40, N'SQAwAEEAVQBJADUAMQBHAEoAUABHAFoANAAxADEAMQAwAA==', 8, 3756)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (41, N'UgAyAEYANABDADcAUQBTADQASQBRAFAAOAAyADAANgA5AA==', 7, 3708)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (42, N'RABIAEYAQwA4ADYAWAAyADkATABYAFEAMgA4ADAANwAyAA==', 8, 3747)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (43, N'UABDADcATwBWADUAVAAyAFUANABJAFMANgAzADcAOAA5AA==', 8, 3740)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (44, N'VwBSADcAUwBDAEsAMwAyADkAVwBUADUAOQA3ADQAOQA1AA==', 8, 3870)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (45, N'VABUADgATABaAFoAMgBSAEIAWQBWAE4ANgA4ADYAOAAxAA==', 1, 3719)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (46, N'TgBBADAARwBMADYANgBIAEQAMwBKAE0ANgA5ADMAOAA2AA==', 7, 3643)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (47, N'MgBBAFgAUAA2ADUAOQAwAFYAUQBVAE0ANgA5ADMAMwA2AA==', 1, 3654)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (48, N'RwA5AFkAUABYAFQARgBZAFYAQQBPAFMANQA1ADAAMQAzAA==', 7, 3723)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (49, N'RwA1ADgARABCAEYATwAwADAANABNAEkAMQAxADYANQAxAA==', 7, 3817)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (50, N'RgBBAE4AWQBJADEAMAAzADUATwBTAFUAMwAwADAANAAxAA==', 1, 3766)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (51, N'RQBNADUARABOAFgASwBRAEkARQBJADgANAA5ADkANwAyAA==', 7, 3803)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (52, N'OQBUADgARgBTAFQASgBMAE4ATABIAEcAMwA3ADgANwA1AA==', 7, 3728)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (53, N'MABKAE8ARwA3AEsATABEAFoAMwBXADMAMQAzADQAOAAzAA==', 8, 3756)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (54, N'UwA5AE4AQQBMAEsAVQBCAEcAOQBCAEYANgAwADMANQA5AA==', 8, 3701)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (55, N'WgBKADQANgBNADgAUQBZAFEAVQBBAFYAOAA1ADcANQAyAA==', 8, 3729)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (56, N'VQA1AEsAUABSAFYAVABEAFkAWgBXAFEANQA0ADMAOQA1AA==', 8, 3625)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (57, N'MwBFAEYAUwAwAFMARABGAFoATwBNAFMAOQA2ADUAOQA5AA==', 8, 3756)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (58, N'SQBUAEEAUQBRAFkARwBCAFAAQwBRAFAAOQA4ADIAMAAyAA==', 7, 3708)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (59, N'SwA1AEIAVgBRADAAVQBCAEUANwBXADEANQA2ADUAMQAxAA==', 7, 3707)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (60, N'NgBWADgAWQBXAFoAVQA1AE8ANABaAEoAMwAxADUAMwA5AA==', 8, 3808)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (61, N'TwAzADUAQgBUAFIAVQBUAEMATABCAFgAOQA3ADIAOQAwAA==', 1, 3755)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (62, N'RQAyAFYAUABGADEANQBUADMATwBVAFoANwA4ADIAMAAxAA==', 7, 3766)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (63, N'RwA3AFYANwBTADIATgBCADIASQBGAFIANgAwADMAOQA2AA==', 7, 3716)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (64, N'SgBOAFcAWQAwAE4AUgBNADgAQQBDADcANgA3ADcAMQAwAA==', 8, 3809)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (65, N'WgBHAEoAVQAwAEYARAA0AFAAVQBEAFcANgAwADEAMQAwAA==', 1, 3785)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (66, N'MABEAEgATwBIAFQAQQBHAFIAVABZADMANwAxADEAMQA4AA==', 8, 3697)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (67, N'WQBLADMATABGAFMAQwBMAFoARABUADQAOQA1ADgAOAA5AA==', 7, 3632)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (68, N'WAAyAFQANAAzAE8ATABWAFQARgBTAFQANgAxADIAMgA4AA==', 7, 3754)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (69, N'TwBQAFYAVwBRAEoANgA0AFIASwBNAFIANwA1ADYAMgA5AA==', 7, 3802)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (70, N'RAAzAFgAQwBVAFYASQBQADAAVABBAFoAMwAwADcAMAA3AA==', 1, 3785)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (71, N'UgBPAFYATAA3AFQAWABBAEgAVQBLAEUAMwAxADEAOAAxAA==', 8, 3737)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (72, N'QQA5AE4AQgBZADcASABQAEgARABaAE8AOQA5ADgANAA0AA==', 8, 3578)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (73, N'UAAxAFcAUgBCADIARAAyAE8AVgBPAFcANQAzADIAOQA0AA==', 1, 3745)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (74, N'TAAzAFkARgBOAFAARQBRADYATwBBADAANgAzADQAMgAyAA==', 1, 3855)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (75, N'NgBJAE0ASgBUAFkATABGAFkATgBDADUANAA5ADgANAA5AA==', 1, 3641)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (76, N'SwBTAFMAMQBRAEUAMwBFAEYASgBCAEEANQA5ADgANAAxAA==', 8, 3749)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (77, N'VgA4AFAAQQBIAEIAVgA2ADgAMABDAEoANQA1ADMANAAyAA==', 1, 3623)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (78, N'NABCAEMASAA5ADYANgBEAFcAWgBIADYAOQA0ADAANgA4AA==', 8, 3589)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (79, N'MwAzAEgASgBFAE0ASwBQAFgAVABSADQANAAxADgAOAAwAA==', 7, 3861)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (80, N'SgBSAFgANwBXAFgAOQA0ADcASwBBAEQAOAAwADQAMQAwAA==', 7, 3836)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (81, N'QwBQAFoAQQBFADMAMwA1AEoASwBEAFYANgA0ADQAMQAyAA==', 7, 3806)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (82, N'RABJAFQANQBUAFIAVAA0ADEAMwBIAFoANQA2ADcAMAA2AA==', 8, 3570)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (83, N'VwBYAEkAMABVADEARAA3AFQARABTADkAMwA4ADUANAA1AA==', 7, 3640)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (84, N'NwBEADIAMQBDAFUAUQBPAFEAVQBPADAANwAyADIAOAA1AA==', 1, 3658)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (85, N'TwBXADAARQBLADMAOQBNADEAMwBBAEoAMQAyADcAOQA0AA==', 1, 3733)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (86, N'UABHAEYASwBHAEYAVwBPADEAOABSAE4AMwAxADcANgA0AA==', 1, 3749)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (87, N'NgBPAEgAVQBDADYASgBXAEMAQgBSADcAMgAyADUAOAA4AA==', 7, 3791)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (88, N'QwBZADAAUwBUAEsAWQBBAEYAWgBPADkAMwA2ADUANgA2AA==', 8, 3827)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (89, N'VgBTAFEAVwBWADEARwBDAE0ANgBGAFUANgA1ADgAMwA1AA==', 8, 3745)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (90, N'MwAzAFYAOABBAEIAQgAyADgAVgBWAE8AMwA0ADEAOQAzAA==', 8, 3824)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (91, N'OQBIADkAMwBWAEoAMQBLAEsAUwBJADMAMgAyADkANwA2AA==', 8, 3893)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (92, N'QgBVAEwAWQBZADUANwBCADMAQgBaAFoANwAwADAANQAxAA==', 8, 3927)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (93, N'SwBWADIANwBSAEsAMwA1AFcANABaADIANwA4ADMAMwAwAA==', 7, 3856)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (94, N'SQAzAFcANgA2AEMAUgBEAEEAVgBTADMANwAwADUAOAAwAA==', 8, 3836)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (95, N'RABYADMAVwBWADgAMABQAFAANQBJAEsAOAA5ADEANwAwAA==', 1, 3724)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (96, N'WABIAFoAVgBFAE8AUwAwAEYAVABWAEIAMQAzADUANQA4AA==', 1, 3750)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (97, N'TAA2AEgATgBXADUAUgBaADAAMgBFAEkANQA2ADYAMgA0AA==', 8, 3700)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (98, N'RABSAFQATABHAEsARwBUAFYAVQBTADAAMgAyADUANgA4AA==', 7, 3766)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (99, N'SQA5ADMASwA3AFUANABKAE8ATwBSAFAANAA4ADAAOQAwAA==', 8, 3605)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (100, N'RwBYAE8AVgA1AFoATQBPAFoANwBXAEcANwA0ADUANwA3AA==', 8, 3855)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (101, N'QgBNAFgAVwAwAEQARwBRAFkATQBJAE8ANwAxADQAMQAyAA==', 8, 3975)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (102, N'MwA1AFkAUgA1AEkAQwBZADUAVABXADUANwA2ADgAOQAzAA==', 8, 3867)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (103, N'QQBXAFAAUQA0AEMAOAAxAFEAUgBSADEANQAzADUANwAwAA==', 8, 3804)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (104, N'WQAyAEsARwBCAFMATABVADkAMwBIADcANAA2ADkAOQA3AA==', 7, 3812)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (105, N'SAA0ADEAVgBNAE0ARwAyAFgASwBPAEIANgA1ADkAMwA5AA==', 1, 3783)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (106, N'RQA2ADIAMwAwAE4AWgAzADkARABWAFkAMwAyADMAOAAzAA==', 7, 3915)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (107, N'TQBMAEYAVwBZAFUASwBNAFAAVABLAFUAMwAzADYAMwA5AA==', 8, 3875)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (108, N'NAAwAFcAWgA1AEoARwAyADEANwBFAFIANAA0ADAAMwA1AA==', 7, 3789)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (109, N'VQBPADEATwBEADAARwBCADQATgBKAFIANQA0ADIAMwAxAA==', 8, 3781)
INSERT [dbo].[Coche] ([Interno], [Patente], [ID_Linea], [DVH]) VALUES (110, N'SAA5AFAANgBEADMAWgA5AEcAVgBVAFAAMQAwADEAMQAxAA==', 7, 3739)
GO

INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Bitacora', CAST(12285559 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Coche', CAST(577531 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Empleado', CAST(3235287 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Familia_Patente', CAST(11937 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Linea', CAST(1806 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Servicio', CAST(1779166 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Usuario', CAST(54072 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Usuario_Familia', CAST(314 AS Decimal(38, 0)))
INSERT [dbo].[DVV] ([Tabla], [DVV]) VALUES (N'Usuario_Patente', CAST(9599 AS Decimal(38, 0)))
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

