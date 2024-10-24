USE [ECSA]
GO
/****** Object:  Table [dbo].[Alerta]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[Backup]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[ID_Bitacora] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NULL,
	[Descripcion] [varchar](50) NULL,
	[ID_Usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Bitacora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coche]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[DVV]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[Legajo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[DNI] [varchar](150) NULL,
	[Direccion] [varchar](150) NULL,
	[Telefono] [varchar](150) NULL,
	[FechaIngreso] [date] NULL,
	[ID_Linea] [int] NULL,
	[ID_Servicio] [int] NULL,
	[DVH] [decimal](38, 0) NULL,
 CONSTRAINT [PK__Empleado__0E01039BAF72650C] PRIMARY KEY CLUSTERED 
(
	[Legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[ID_Familia] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[DVV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[ID_Familia] [int] NOT NULL,
	[ID_Patente] [int] NOT NULL,
	[DVV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Familia] ASC,
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[Linea]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linea](
	[ID_Linea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Linea] [varchar](50) NULL,
	[DVH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Linea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[ID_Patente] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[DVV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[Traduccion]    Script Date: 14/7/2024 11:08:48 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/7/2024 11:08:48 ******/
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
	[DVH] [decimal](38, 0) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK__Usuario__DE4431C55FF61783] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Familia](
	[ID_Usuario] [int] NOT NULL,
	[ID_Familia] [int] NOT NULL,
	[DVV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Familia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 14/7/2024 11:08:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Patente](
	[ID_Usuario] [int] NOT NULL,
	[ID_Patente] [int] NOT NULL,
	[DVV] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Patente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK__Bitacora__ID_Usu__59063A47] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK__Bitacora__ID_Usu__59063A47]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__ID_Lin__3B75D760] FOREIGN KEY([ID_Linea])
REFERENCES [dbo].[Linea] ([ID_Linea])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__ID_Lin__3B75D760]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK__Empleado__ID_Ser__3C69FB99] FOREIGN KEY([ID_Servicio])
REFERENCES [dbo].[Servicio] ([ID_Servicio])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK__Empleado__ID_Ser__3C69FB99]
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_Empleado] FOREIGN KEY([Legajo])
REFERENCES [dbo].[Empleado] ([Legajo])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_Empleado]
GO
ALTER TABLE [dbo].[Traduccion]  WITH CHECK ADD FOREIGN KEY([ID_Idioma])
REFERENCES [dbo].[Idioma] ([ID_Idioma])
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD FOREIGN KEY([ID_Familia])
REFERENCES [dbo].[Familia] ([ID_Familia])
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_F__ID_Us__5070F446] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Usuario_Familia] CHECK CONSTRAINT [FK__Usuario_F__ID_Us__5070F446]
GO
ALTER TABLE [dbo].[Usuario_Patente]  WITH CHECK ADD FOREIGN KEY([ID_Patente])
REFERENCES [dbo].[Patente] ([ID_Patente])
GO
ALTER TABLE [dbo].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_P__ID_Us__46E78A0C] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Usuario_Patente] CHECK CONSTRAINT [FK__Usuario_P__ID_Us__46E78A0C]
GO
