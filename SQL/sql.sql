USE [master]
GO
/****** Object:  Database [SistemaVenta]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[Bitacora]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[HistorialUsuario]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[Producto_Categoria]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 16/4/2025 13:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](75) NOT NULL,
	[EsRol] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Rol]    Script Date: 16/4/2025 13:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PadreId] [int] NOT NULL,
	[HijoId] [int] NOT NULL,
 CONSTRAINT [PK_Rol_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  Table [dbo].[Usuario_Rol]    Script Date: 16/4/2025 13:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[RolId] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_Rol] PRIMARY KEY CLUSTERED 
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
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (1, N'Rol 1', 1)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (2, N'acccion 1', 0)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (3, N'Rol 2', 1)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (4, N'accion 2', 0)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (5, N'accion 4', 0)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (6, N'rol 4', 1)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (7, N'rol 3', 1)
INSERT [dbo].[Rol] ([Id], [Nombre], [EsRol]) VALUES (8, N'accion 3', 0)
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [DNI], [Clave], [Correo], [Telefono], [Estado]) VALUES (1, N'admin', N'admin', 123456, N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'admin@admin.com', 123456, 1)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [DNI], [Clave], [Correo], [Telefono], [Estado]) VALUES (4, N'juan', N'carlos', 9876, N'dbff5341acad5e2a58db4efd5e72e2d9a0a843a28e02b1183c68162d0a3a3de6', N'juan@carlos.com', 10100101, 0)
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [DNI], [Clave], [Correo], [Telefono], [Estado]) VALUES (5, N'pepe', N'pepe', 123, N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', N'pepe@pepe.com', 100000, 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario_Rol] ON 

INSERT [dbo].[Usuario_Rol] ([Id], [UsuarioId], [RolId]) VALUES (13, 4, 7)
INSERT [dbo].[Usuario_Rol] ([Id], [UsuarioId], [RolId]) VALUES (14, 4, 4)
INSERT [dbo].[Usuario_Rol] ([Id], [UsuarioId], [RolId]) VALUES (15, 4, 6)
INSERT [dbo].[Usuario_Rol] ([Id], [UsuarioId], [RolId]) VALUES (16, 5, 2)
SET IDENTITY_INSERT [dbo].[Usuario_Rol] OFF
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
ALTER TABLE [dbo].[Rol_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Rol_Rol] FOREIGN KEY([PadreId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Rol_Rol] CHECK CONSTRAINT [FK_Rol_Rol_Rol]
GO
ALTER TABLE [dbo].[Rol_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Rol_Rol_Rol1] FOREIGN KEY([HijoId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Rol_Rol] CHECK CONSTRAINT [FK_Rol_Rol_Rol1]
GO
ALTER TABLE [dbo].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Rol] FOREIGN KEY([RolId])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Rol]
GO
ALTER TABLE [dbo].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Usuario_Rol] CHECK CONSTRAINT [FK_Usuario_Rol_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[AgregarBitacora]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AgregarProducto]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AgregarRelacionProductoCategoria]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 16/4/2025 13:35:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarUsuario]
@Nombre nvarchar(50),
@Apellido nvarchar(50),
@DNI int,
@Clave nvarchar(75),
@Correo nvarchar(100),
@Telefono nvarchar(100),
@Estado bit
AS
BEGIN
	INSERT INTO Usuario (Nombre,Apellido,DNI,Clave,Correo,Telefono,Estado)
	VALUES(@Nombre,@Apellido,@DNI,@Clave,@Correo,@Telefono,@Estado)
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarUsuarioXId]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ListadoBitacora]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ListadoEmpleado]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ListarProducto]    Script Date: 16/4/2025 13:35:08 ******/
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
/****** Object:  StoredProcedure [dbo].[ObtenerUserPass]    Script Date: 16/4/2025 13:35:08 ******/
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
