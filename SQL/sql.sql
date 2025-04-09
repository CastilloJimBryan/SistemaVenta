USE [master]
GO
/****** Object:  Database [SistemaVenta]    Script Date: 9/4/2025 14:01:51 ******/
CREATE DATABASE [SistemaVenta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaVenta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SistemaVenta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaVenta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SistemaVenta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SistemaVenta] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaVenta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaVenta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaVenta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaVenta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaVenta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaVenta] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaVenta] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SistemaVenta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaVenta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaVenta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaVenta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaVenta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaVenta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaVenta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaVenta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaVenta] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SistemaVenta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaVenta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaVenta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaVenta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaVenta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaVenta] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaVenta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaVenta] SET RECOVERY FULL 
GO
ALTER DATABASE [SistemaVenta] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaVenta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaVenta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaVenta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaVenta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaVenta] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaVenta] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaVenta', N'ON'
GO
ALTER DATABASE [SistemaVenta] SET QUERY_STORE = ON
GO
ALTER DATABASE [SistemaVenta] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SistemaVenta]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Actividad] [nvarchar](150) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialUsuario]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdOriginal] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[Telefono] [int] NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_HistorialUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[PrecioCompra] [float] NOT NULL,
	[PrecioVenta] [float] NOT NULL,
	[CantidadMinima] [int] NOT NULL,
	[CantidadMaxima] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto_Categoria]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[CategoriaId] [int] NOT NULL,
 CONSTRAINT [PK_Producto_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[Clave] [nvarchar](75) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([Id], [Actividad], [Fecha], [UsuarioId]) VALUES (1, N'Inicio Sesion', CAST(N'2025-04-03T13:39:40.547' AS DateTime), 3)
INSERT [dbo].[Bitacora] ([Id], [Actividad], [Fecha], [UsuarioId]) VALUES (2, N'Inicio Sesion', CAST(N'2025-04-03T13:40:08.497' AS DateTime), 1)
INSERT [dbo].[Bitacora] ([Id], [Actividad], [Fecha], [UsuarioId]) VALUES (3, N'Inicio Sesion', CAST(N'2025-04-04T09:30:23.560' AS DateTime), 3)
INSERT [dbo].[Bitacora] ([Id], [Actividad], [Fecha], [UsuarioId]) VALUES (4, N'Inicio Sesion', CAST(N'2025-04-04T09:31:00.437' AS DateTime), 2)
INSERT [dbo].[Bitacora] ([Id], [Actividad], [Fecha], [UsuarioId]) VALUES (5, N'Inicio Sesion', CAST(N'2025-04-04T09:35:10.813' AS DateTime), 2)
INSERT [dbo].[Bitacora] ([Id], [Actividad], [Fecha], [UsuarioId]) VALUES (6, N'Inicio Sesion', CAST(N'2025-04-04T09:45:30.657' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'categoria 3')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'categoria 7')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[HistorialUsuario] ON 

INSERT [dbo].[HistorialUsuario] ([Id], [IdOriginal], [Nombre], [Apellido], [DNI], [Telefono], [Correo], [Estado], [Fecha]) VALUES (1, 2, N'lucas ', N'perez', 111222, 1123412344, N'lucas.perez@gmail.com', 1, CAST(N'2025-04-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[HistorialUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([Id], [Codigo], [Nombre], [Descripcion], [CategoriaId], [PrecioCompra], [PrecioVenta], [CantidadMinima], [CantidadMaxima]) VALUES (2, 1234, N'nombre', N'aaddd', 1, 11, 21, 31, 41)
INSERT [dbo].[Producto] ([Id], [Codigo], [Nombre], [Descripcion], [CategoriaId], [PrecioCompra], [PrecioVenta], [CantidadMinima], [CantidadMaxima]) VALUES (3, 5678, N'producto2', N'retiew', 2, 10, 11, 12, 13)
INSERT [dbo].[Producto] ([Id], [Codigo], [Nombre], [Descripcion], [CategoriaId], [PrecioCompra], [PrecioVenta], [CantidadMinima], [CantidadMaxima]) VALUES (5, 3333, N'popo', N'descri', 2, 10, 20, 30, 40)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto_Categoria] ON 

INSERT [dbo].[Producto_Categoria] ([Id], [ProductoId], [CategoriaId]) VALUES (1, 2, 1)
INSERT [dbo].[Producto_Categoria] ([Id], [ProductoId], [CategoriaId]) VALUES (2, 3, 2)
INSERT [dbo].[Producto_Categoria] ([Id], [ProductoId], [CategoriaId]) VALUES (4, 5, 2)
SET IDENTITY_INSERT [dbo].[Producto_Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [DNI], [Clave], [Correo], [Telefono], [Estado]) VALUES (1, N'admin', N'admin', 123456, N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'admin@admin.com', 123456, 1)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [DNI], [Clave], [Correo], [Telefono], [Estado]) VALUES (2, N'lucas', N'perez', 123456, N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'lucas.perez@gmail.com', 1123412344, 0)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [DNI], [Clave], [Correo], [Telefono], [Estado]) VALUES (3, N'jim', N'padilla', 94667, N'af6272afb0dc7c9ef4b4dfc686040f9d6eab6eeff3a74714bfe933289b8fe726', N'byan@castilloscom', 1123124, 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Producto_Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria_Categoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto_Categoria] CHECK CONSTRAINT [FK_Producto_Categoria_Categoria]
GO
ALTER TABLE [dbo].[Producto_Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[Producto_Categoria] CHECK CONSTRAINT [FK_Producto_Categoria_Producto]
GO
/****** Object:  StoredProcedure [dbo].[AgregarBitacora]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarBitacora]
	@UsuarioId int,
	@Actividad nvarchar(150),
	@Fecha DateTime
AS
BEGIN
	INSERT INTO Bitacora (UsuarioId,Actividad,Fecha) VALUES (@UsuarioId,@Actividad,@Fecha)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarProducto]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgregarProducto]
	@Codigo int,
	@Nombre nvarchar (50),
	@Descripcion nvarchar(100),
	@CategoriaId int,
	@PrecioCompra float,
	@PrecioVenta float,
	@CantidadMinima int,
	@CantidadMaxima int
AS
BEGIN
	INSERT INTO Producto(Codigo,Nombre,Descripcion,CategoriaId,PrecioCompra,PrecioVenta,CantidadMinima,CantidadMaxima)
	VALUES (@Codigo,@Nombre,@Descripcion,@CategoriaId,@PrecioCompra,@PrecioVenta,@CantidadMinima,@CantidadMaxima);SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarRelacionProductoCategoria]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgregarRelacionProductoCategoria]
@ProductoId int,
@CategoriaId int
AS
BEGIN
	INSERT INTO Producto_Categoria (ProductoId,CategoriaId) VALUES (@ProductoId,@CategoriaId)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarUsuario]
@Id int,
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@DNI int,
@Clave nvarchar(75),
@Correo nvarchar(100),
@Telefono nvarchar(100),
@Estado bit
AS
BEGIN
	INSERT INTO Usuario (Id,Nombre,Apellido,DNI,Clave,Correo,Telefono,Estado)
	VALUES(@Id,@Nombre,@Apellido,@DNI,@Clave,@Correo,@Telefono,@Estado)
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarUsuarioXId]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarUsuarioXId]
@Id int
AS
BEGIN
	select * from Usuario WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarUsuario]
@Id int,
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@DNI int,
@Clave nvarchar(75),
@Correo nvarchar(100),
@Telefono nvarchar(100)
AS
BEGIN
	UPDATE Usuario SET Nombre=@Nombre,Apellido=@Apellido,DNI=@DNI,Clave=@Clave,Correo=@Correo,Telefono=@Telefono
	WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario]
@Id int
AS
BEGIN
	DELETE FROM Usuario WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ListadoBitacora]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListadoBitacora]
	
AS
BEGIN
	SELECT Bitacora.Id,Actividad,Fecha,Usuario.Id as UsuarioId,Usuario.Nombre as Usuario
                        FROM Bitacora
                        INNER JOIN Usuario ON Bitacora.UsuarioId=Usuario.Id 
                         ORDER BY Fecha desc
END
GO
/****** Object:  StoredProcedure [dbo].[ListadoEmpleado]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListadoEmpleado]

AS
BEGIN
	select * from Usuario 
END
GO
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarProducto]
AS
BEGIN
	SELECT Producto.Id,Codigo,Producto.Nombre,Descripcion,Categoria.Nombre as Categoria,PrecioCompra,PrecioVenta,CantidadMinima,CantidadMaxima
	FROM Producto
	INNER JOIN Categoria ON Producto.CategoriaId=Categoria.Id
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUserPass]    Script Date: 9/4/2025 14:01:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUserPass]
	@Nombre nvarchar(50),
	@Clave nvarchar(75)
AS
BEGIN
	select * from Usuario Where Nombre=@Nombre and Clave=@Clave
END
GO
USE [master]
GO
ALTER DATABASE [SistemaVenta] SET  READ_WRITE 
GO
