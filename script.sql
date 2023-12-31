USE [master]
GO
/****** Object:  Database [ChePlay]    Script Date: 31/08/2023 12:00:07 p. m. ******/
CREATE DATABASE [ChePlay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChePlay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ChePlay.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChePlay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ChePlay_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ChePlay] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChePlay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChePlay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChePlay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChePlay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChePlay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChePlay] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChePlay] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ChePlay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChePlay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChePlay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChePlay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChePlay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChePlay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChePlay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChePlay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChePlay] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ChePlay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChePlay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChePlay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChePlay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChePlay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChePlay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChePlay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChePlay] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ChePlay] SET  MULTI_USER 
GO
ALTER DATABASE [ChePlay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChePlay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChePlay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChePlay] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChePlay] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChePlay] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ChePlay] SET QUERY_STORE = ON
GO
ALTER DATABASE [ChePlay] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ChePlay]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 31/08/2023 12:00:07 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CodCategoria_CT] [char](5) NOT NULL,
	[NombreDeCategoria_CT] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[CodCategoria_CT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriasxJuegos]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriasxJuegos](
	[CodCategoria_CT_CXJ] [char](5) NOT NULL,
	[CodJuego_JU_CXJ] [char](5) NOT NULL,
 CONSTRAINT [PK_CategoriasxJuegos] PRIMARY KEY CLUSTERED 
(
	[CodCategoria_CT_CXJ] ASC,
	[CodJuego_JU_CXJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVentas]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVentas](
	[CodVenta_VN_DV] [int] NOT NULL,
	[CodJuego_PXJ_DV] [char](5) NOT NULL,
	[CodPlataforma_PXJ_DV] [char](5) NOT NULL,
	[Cantidad_DV] [int] NOT NULL,
	[PrecioUnitario_DV] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_DetalleVentas] PRIMARY KEY CLUSTERED 
(
	[CodVenta_VN_DV] ASC,
	[CodJuego_PXJ_DV] ASC,
	[CodPlataforma_PXJ_DV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juegos]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juegos](
	[CodJuego_JU] [char](5) NOT NULL,
	[CodProveedor_PR_JU] [char](5) NOT NULL,
	[Nombre_JU] [varchar](100) NOT NULL,
	[Descripcion_JU] [varchar](200) NOT NULL,
	[FechaDeLanzamiento_JU] [date] NOT NULL,
	[URLportada_JU] [varchar](35) NOT NULL,
	[Activo_JU] [bit] NOT NULL,
 CONSTRAINT [PK_Juegos] PRIMARY KEY CLUSTERED 
(
	[CodJuego_JU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModosDeJuego]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModosDeJuego](
	[CodModoDeJuego_MDJ] [char](5) NOT NULL,
	[NombreModo_MDJ] [varchar](30) NOT NULL,
 CONSTRAINT [PK_ModosDeJuego] PRIMARY KEY CLUSTERED 
(
	[CodModoDeJuego_MDJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModosxJuegos]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModosxJuegos](
	[CodJuego_JU_MXJ] [char](5) NOT NULL,
	[CodModoDeJuego_MDJ_MXJ] [char](5) NOT NULL,
 CONSTRAINT [PK_ModosxJuegos] PRIMARY KEY CLUSTERED 
(
	[CodJuego_JU_MXJ] ASC,
	[CodModoDeJuego_MDJ_MXJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plataformas]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plataformas](
	[CodPlataforma_PL] [char](5) NOT NULL,
	[NombreDePlataforma_PL] [char](20) NOT NULL,
 CONSTRAINT [PK_Plataformas] PRIMARY KEY CLUSTERED 
(
	[CodPlataforma_PL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlataformasxJuegos]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlataformasxJuegos](
	[CodJuego_JU_PXJ] [char](5) NOT NULL,
	[CodPlataforma_PL_PXJ] [char](5) NOT NULL,
	[Stock_PXJ] [int] NOT NULL,
	[PrecioUnitario_PXJ] [decimal](8, 2) NOT NULL,
	[Activo_PXJ] [bit] NOT NULL,
 CONSTRAINT [PK_PlataformasxJuegos] PRIMARY KEY CLUSTERED 
(
	[CodJuego_JU_PXJ] ASC,
	[CodPlataforma_PL_PXJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[CodProveedor_PR] [char](5) NOT NULL,
	[Direccion_PR] [varchar](30) NOT NULL,
	[Provincia_PR] [varchar](25) NOT NULL,
	[Telefono_PR] [varchar](20) NOT NULL,
	[Email_PR] [varchar](40) NOT NULL,
	[Activo_PR] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[CodProveedor_PR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[DniUsuario_US] [char](8) NOT NULL,
	[NombreDeUsuario_US] [varchar](20) NOT NULL,
	[Nombre_US] [varchar](20) NOT NULL,
	[Apellido_US] [varchar](25) NOT NULL,
	[Telefono_US] [varchar](20) NOT NULL,
	[Direccion_US] [varchar](35) NOT NULL,
	[Contraseña_US] [varchar](30) NOT NULL,
	[Activo_US] [bit] NOT NULL,
	[Admin_US] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[DniUsuario_US] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NombreDeUsuario_US] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[CodVenta_VN] [int] IDENTITY(1,1) NOT NULL,
	[DniUsuario_US_VN] [char](8) NOT NULL,
	[TotalVenta_VN] [decimal](8, 2) NOT NULL,
	[FechaVenta_VN] [date] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[CodVenta_VN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleVentas] ADD  DEFAULT ((0)) FOR [Cantidad_DV]
GO
ALTER TABLE [dbo].[DetalleVentas] ADD  DEFAULT ((0)) FOR [PrecioUnitario_DV]
GO
ALTER TABLE [dbo].[Juegos] ADD  DEFAULT ((1)) FOR [Activo_JU]
GO
ALTER TABLE [dbo].[PlataformasxJuegos] ADD  DEFAULT ((0)) FOR [Stock_PXJ]
GO
ALTER TABLE [dbo].[PlataformasxJuegos] ADD  DEFAULT ((0)) FOR [PrecioUnitario_PXJ]
GO
ALTER TABLE [dbo].[PlataformasxJuegos] ADD  DEFAULT ((1)) FOR [Activo_PXJ]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((1)) FOR [Activo_PR]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [Activo_US]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [Admin_US]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT ((0)) FOR [TotalVenta_VN]
GO
ALTER TABLE [dbo].[Ventas] ADD  DEFAULT (CONVERT([varchar](10),getdate(),(104))) FOR [FechaVenta_VN]
GO
ALTER TABLE [dbo].[CategoriasxJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Categorias_CategoriasxJuegos] FOREIGN KEY([CodCategoria_CT_CXJ])
REFERENCES [dbo].[Categorias] ([CodCategoria_CT])
GO
ALTER TABLE [dbo].[CategoriasxJuegos] CHECK CONSTRAINT [FK_Categorias_CategoriasxJuegos]
GO
ALTER TABLE [dbo].[CategoriasxJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Juegos_CategoriasxJuegos] FOREIGN KEY([CodJuego_JU_CXJ])
REFERENCES [dbo].[Juegos] ([CodJuego_JU])
GO
ALTER TABLE [dbo].[CategoriasxJuegos] CHECK CONSTRAINT [FK_Juegos_CategoriasxJuegos]
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD  CONSTRAINT [FK_PlataformasxJuegos_DetalleVentas] FOREIGN KEY([CodJuego_PXJ_DV], [CodPlataforma_PXJ_DV])
REFERENCES [dbo].[PlataformasxJuegos] ([CodJuego_JU_PXJ], [CodPlataforma_PL_PXJ])
GO
ALTER TABLE [dbo].[DetalleVentas] CHECK CONSTRAINT [FK_PlataformasxJuegos_DetalleVentas]
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_DetalleVentas] FOREIGN KEY([CodVenta_VN_DV])
REFERENCES [dbo].[Ventas] ([CodVenta_VN])
GO
ALTER TABLE [dbo].[DetalleVentas] CHECK CONSTRAINT [FK_Ventas_DetalleVentas]
GO
ALTER TABLE [dbo].[Juegos]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Juegos] FOREIGN KEY([CodProveedor_PR_JU])
REFERENCES [dbo].[Proveedores] ([CodProveedor_PR])
GO
ALTER TABLE [dbo].[Juegos] CHECK CONSTRAINT [FK_Proveedores_Juegos]
GO
ALTER TABLE [dbo].[ModosxJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Juegos_ModosxJuegos] FOREIGN KEY([CodJuego_JU_MXJ])
REFERENCES [dbo].[Juegos] ([CodJuego_JU])
GO
ALTER TABLE [dbo].[ModosxJuegos] CHECK CONSTRAINT [FK_Juegos_ModosxJuegos]
GO
ALTER TABLE [dbo].[ModosxJuegos]  WITH CHECK ADD  CONSTRAINT [FK_ModosDeJuego_ModosxJuegos] FOREIGN KEY([CodModoDeJuego_MDJ_MXJ])
REFERENCES [dbo].[ModosDeJuego] ([CodModoDeJuego_MDJ])
GO
ALTER TABLE [dbo].[ModosxJuegos] CHECK CONSTRAINT [FK_ModosDeJuego_ModosxJuegos]
GO
ALTER TABLE [dbo].[PlataformasxJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Juegos_PlataformasxJuegos] FOREIGN KEY([CodJuego_JU_PXJ])
REFERENCES [dbo].[Juegos] ([CodJuego_JU])
GO
ALTER TABLE [dbo].[PlataformasxJuegos] CHECK CONSTRAINT [FK_Juegos_PlataformasxJuegos]
GO
ALTER TABLE [dbo].[PlataformasxJuegos]  WITH CHECK ADD  CONSTRAINT [FK_Plataformas_PlataformasxJuegos] FOREIGN KEY([CodPlataforma_PL_PXJ])
REFERENCES [dbo].[Plataformas] ([CodPlataforma_PL])
GO
ALTER TABLE [dbo].[PlataformasxJuegos] CHECK CONSTRAINT [FK_Plataformas_PlataformasxJuegos]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Ventas] FOREIGN KEY([DniUsuario_US_VN])
REFERENCES [dbo].[Usuarios] ([DniUsuario_US])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Usuarios_Ventas]
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD CHECK  (([Cantidad_DV]>=(0)))
GO
ALTER TABLE [dbo].[DetalleVentas]  WITH CHECK ADD CHECK  (([PrecioUnitario_DV]>=(0)))
GO
ALTER TABLE [dbo].[PlataformasxJuegos]  WITH CHECK ADD CHECK  (([PrecioUnitario_PXJ]>=(0)))
GO
ALTER TABLE [dbo].[PlataformasxJuegos]  WITH CHECK ADD CHECK  (([Stock_PXJ]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[spEditarPrecio]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*Edita el precio de un juego en especifico*/
CREATE PROCEDURE [dbo].[spEditarPrecio]
	(
		@CODJUEGO char(5),
		@CODPLATAFORMA char(5),
		@PRECIOUNITARIO int
	)
	AS
		BEGIN
			UPDATE PlataformasxJuegos SET PrecioUnitario_PXJ = @PRECIOUNITARIO 
			WHERE CodJuego_JU_PXJ = @CODJUEGO AND CodPlataforma_PL_PXJ = @CODPLATAFORMA
		END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarCategoria]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertarCategoria]
	(
		@CODCATEGORIA char(5),
		@NOMBRECATEGORIA char(20)
	)
	AS
		BEGIN
			INSERT INTO Categorias(CodCategoria_CT,NombreDeCategoria_CT)
			SELECT @CODCATEGORIA, @NOMBRECATEGORIA
		END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarModoDeJuego]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertarModoDeJuego]
	(
		@CODMODOJUEGO char(5),
		@NOMBREMODO varchar(30)
	)
	AS
		BEGIN
			INSERT INTO ModosDeJuego(CodModoDeJuego_MDJ,NombreModo_MDJ)
			SELECT @CODMODOJUEGO, @NOMBREMODO
		END
GO
/****** Object:  StoredProcedure [dbo].[spInsertarPlataforma]    Script Date: 31/08/2023 12:00:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertarPlataforma]
	(
		@CODPLATAFORMA char(5),
		@NOMBREPLATAFORMA char(20)
	)
	AS
		BEGIN
			INSERT INTO Plataformas(CodPlataforma_PL,NombreDePlataforma_PL)
			SELECT @CODPLATAFORMA, @NOMBREPLATAFORMA
		END
GO
USE [master]
GO
ALTER DATABASE [ChePlay] SET  READ_WRITE 
GO
