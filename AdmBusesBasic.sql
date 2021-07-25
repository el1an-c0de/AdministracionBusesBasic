USE [master]
GO
/****** Object:  Database [ProyectoBD]    Script Date: 25/07/2021 10:27:49 ******/
CREATE DATABASE [ProyectoBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProyectoPA', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProyectoPA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProyectoPA_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProyectoPA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProyectoBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProyectoBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProyectoBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProyectoBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProyectoBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProyectoBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProyectoBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProyectoBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProyectoBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProyectoBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProyectoBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProyectoBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProyectoBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProyectoBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProyectoBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProyectoBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProyectoBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProyectoBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProyectoBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProyectoBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProyectoBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProyectoBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProyectoBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProyectoBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProyectoBD] SET RECOVERY FULL 
GO
ALTER DATABASE [ProyectoBD] SET  MULTI_USER 
GO
ALTER DATABASE [ProyectoBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProyectoBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProyectoBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProyectoBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProyectoBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProyectoBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProyectoBD', N'ON'
GO
ALTER DATABASE [ProyectoBD] SET QUERY_STORE = OFF
GO
USE [ProyectoBD]
GO
/****** Object:  Table [dbo].[Buses]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buses](
	[IDBus] [int] NOT NULL,
	[Placa] [varchar](10) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Dueno] [varchar](50) NOT NULL,
	[NoBus] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[IDCarrera] [int] NOT NULL,
	[Tiempo] [datetime] NOT NULL,
	[HoraLlegada] [datetime] NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[IDBus] [int] NULL,
	[IDRuta] [int] NULL,
	[IDChofer] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chofer]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chofer](
	[IDChofer] [int] NOT NULL,
	[Nombres] [varchar](10) NOT NULL,
	[Apellidos] [varchar](10) NOT NULL,
	[TipoLicencia] [varchar](10) NOT NULL,
	[Cedula] [varchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ruta]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruta](
	[IDRuta] [int] NOT NULL,
	[NombreRuta] [varchar](50) NOT NULL,
	[Tarifa] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[IDSesion] [int] NOT NULL,
	[Usuario] [varchar](10) NOT NULL,
	[Contrasena] [varchar](10) NOT NULL,
	[Tipo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Sesion] PRIMARY KEY CLUSTERED 
(
	[IDSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (1, N'ABO123', N'Nissan', N'Julio', 10)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (2, N'FGH456', N'Mavessa', N'Angela', 32)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (3, N'ABO789', N'Hino', N'Juan flores', 23)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (4, N'AFG159', N'Hyundai', N'Antonio Gonzales', 47)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (5, N'AFG159', N'Hyundai', N'Beatriz Quezada', 573)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (6, N'ABO146', N'Volkswagen', N'Wilson Balda', 78)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (7, N'QWE326', N'Mitsubishi', N'Ramiro Lopez', 102)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (8, N'LOP023', N'JAC', N'Lupe Farias', 46)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (9, N'ALK456', N'Joylong', N'Teresa Diaz', 23)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (10, N'MNB035', N'Zhongtong', N'Jordi Correra', 1)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (11, N'OFG789', N'Hyundai', N'Manuel Salazar', 78)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (12, N'POL001', N'Golden Dragon', N'Hugo Perez', 12)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (13, N'DGT712', N'Mitsubishi', N'Keyla Zambrano', 145)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (14, N'MBF452', N'Scania', N'Elias torres', 328)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (15, N'AST706', N'Fighter', N'Alejando Velez', 12)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (16, N'IOH456', N'Zhongtong', N'Danilo Yunda', 75)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (17, N'QWE032', N'Volkswagen', N'Anibal Romero', 15)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (18, N'DTA456', N'Hyundai', N'Daniela Carrion', 233)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (19, N'PHT102', N'Mercedes-Benz', N'Bolivar Quiroz', 444)
GO
INSERT [dbo].[Buses] ([IDBus], [Placa], [Modelo], [Dueno], [NoBus]) VALUES (20, N'VG6176', N'Fighter', N'Ximena Dominguez', 19)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (1, CAST(N'2021-04-17T09:30:00.000' AS DateTime), CAST(N'2021-04-17T10:30:00.000' AS DateTime), N'Salida', 1, 2, 2)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (2, CAST(N'2021-04-17T22:43:27.000' AS DateTime), CAST(N'2021-04-17T22:13:27.000' AS DateTime), N'Salida', 2, 1, 3)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (3, CAST(N'2021-04-18T12:03:13.000' AS DateTime), CAST(N'2021-04-18T11:53:13.000' AS DateTime), N'Salida', 2, 2, 2)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (4, CAST(N'2021-04-18T11:55:27.000' AS DateTime), CAST(N'2021-04-18T12:05:27.000' AS DateTime), N'Esperando', 2, 1, 2)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (5, CAST(N'2021-04-19T19:00:32.000' AS DateTime), CAST(N'2021-04-19T19:30:32.000' AS DateTime), N'Salida', 2, 1, 3)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (6, CAST(N'2001-04-17T13:00:00.000' AS DateTime), CAST(N'2001-04-17T13:30:00.000' AS DateTime), N'Llegando', 9, 8, 20)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (7, CAST(N'2021-04-17T14:00:00.000' AS DateTime), CAST(N'2021-04-17T14:30:00.000' AS DateTime), N'Estacionad', 9, 8, 15)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (8, CAST(N'2021-04-17T15:00:00.000' AS DateTime), CAST(N'2021-04-17T15:30:00.000' AS DateTime), N'Salida', 9, 8, 18)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (9, CAST(N'2021-04-17T16:00:00.000' AS DateTime), CAST(N'2021-04-17T16:30:00.000' AS DateTime), N'Estacionad', 9, 8, 4)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (10, CAST(N'2021-04-17T17:00:00.000' AS DateTime), CAST(N'2021-04-17T17:30:00.000' AS DateTime), N'Llegando', 9, 7, 4)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (11, CAST(N'2021-04-17T18:00:00.000' AS DateTime), CAST(N'2021-04-17T18:30:00.000' AS DateTime), N'Estacionad', 9, 7, 2)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (12, CAST(N'2021-04-17T19:00:00.000' AS DateTime), CAST(N'2021-04-17T19:30:00.000' AS DateTime), N'Esperando', 9, 7, 16)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (13, CAST(N'2021-04-17T20:00:00.000' AS DateTime), CAST(N'2021-04-17T20:30:00.000' AS DateTime), N'Estacionad', 9, 7, 1)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (14, CAST(N'2021-04-18T06:00:00.000' AS DateTime), CAST(N'2021-04-18T06:30:00.000' AS DateTime), N'Salida', 9, 6, 19)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (15, CAST(N'2021-04-18T07:00:00.000' AS DateTime), CAST(N'2021-04-18T07:30:00.000' AS DateTime), N'Estacionad', 9, 6, 5)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (16, CAST(N'2021-04-18T08:00:00.000' AS DateTime), CAST(N'2021-04-18T08:30:00.000' AS DateTime), N'Llegando', 9, 6, 12)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (17, CAST(N'2021-04-18T09:00:00.000' AS DateTime), CAST(N'2021-04-18T09:30:00.000' AS DateTime), N'Salida', 9, 6, 18)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (18, CAST(N'2021-04-18T10:00:00.000' AS DateTime), CAST(N'2021-04-18T10:30:00.000' AS DateTime), N'Estacionad', 9, 8, 7)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (19, CAST(N'2021-04-18T11:30:00.000' AS DateTime), CAST(N'2021-04-18T11:00:00.000' AS DateTime), N'Salida', 1, 5, 1)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (20, CAST(N'2021-04-18T12:00:00.000' AS DateTime), CAST(N'2021-04-18T12:30:00.000' AS DateTime), N'Esperando', 9, 20, 2)
GO
INSERT [dbo].[Carrera] ([IDCarrera], [Tiempo], [HoraLlegada], [Estado], [IDBus], [IDRuta], [IDChofer]) VALUES (34, CAST(N'2021-04-20T09:23:28.000' AS DateTime), CAST(N'2021-04-20T09:23:28.000' AS DateTime), N'Salida', 1, 1, 1)
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (1, N'Carlos', N'Quezada', N'TIPO B', N'0778456321')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (2, N'Diana', N'Flores', N'TIPO B', N'0721536548')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (3, N'Helen', N'Solano', N'TIPO B', N'0745698712')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (5, N'Daniela', N'Santana', N'TIPO B', N'0778945612')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (6, N'Juan', N'Benitez', N'TIPO B', N'0701234567')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (8, N'Emilia', N'Guevara', N'TIPO B', N'0701234568')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (9, N'Carlos', N'Solano', N'TIPO B', N'0701234569')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (10, N'Lucho', N'Gomez', N'TIPO B', N'0701234578')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (11, N'Xoila', N'Wong', N'TIPO B', N'0701234579')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (12, N'Ester', N'Cuenca', N'TIPO B', N'0701234589')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (13, N'Jordi', N'Camacho', N'TIPO B', N'0701234678')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (14, N'Jessica', N'Mejia', N'TIPO B', N'0701234679')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (15, N'Yulio', N'Porres', N'TIPO B', N'0701234689')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (16, N'Victor', N'Julio', N'TIPO B', N'0701234789')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (17, N'Jose', N'Caicedo', N'TIPO B', N'0701235678')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (18, N'Eugenio', N'Astudillo', N'TIPO B', N'0701235679')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (19, N'Norma', N'Macas', N'TIPO B', N'0701235689')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (20, N'Veronica', N'Hidalgo', N'TIPO B', N'0701235789')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (4, N'Wilson', N'Quito', N'TIPO B', N'0765123648')
GO
INSERT [dbo].[Chofer] ([IDChofer], [Nombres], [Apellidos], [TipoLicencia], [Cedula]) VALUES (7, N'Juanita', N'Encarnacio', N'TIPO B', N'0734567890')
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (1, N'PtoBolivar', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (2, N'AVPalmeras', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (3, N'Boyaca', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (4, N'25 de Junio', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (5, N'Buena Vista', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (6, N'10 de Agosto', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (7, N'Arizaga', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (8, N'Marcel Laniado', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (9, N'Gral. Thelmo Sadoval', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (10, N'Ambrosi Gumal', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (11, N'9 de Mayo', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (12, N'Manuel Estomba', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (13, N'Vela', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (14, N'Guabo', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (15, N'Guayas', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (16, N'Av. Ferroviaria', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (17, N'Dr. Nicolas Benites', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (18, N'Bolivar', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (19, N'Av. Las Palmera', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (20, N'Pichincha', 0.3000)
GO
INSERT [dbo].[Ruta] ([IDRuta], [NombreRuta], [Tarifa]) VALUES (34, N'Huaquillas', 0.6000)
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (0, N'Lucia1', N'123', N'Admin')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (1, N'0778456321', N'0778456321', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (2, N'0721536548', N'0721536548', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (3, N'0745698712', N'0745698712', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (4, N'0765123648', N'0765123648', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (5, N'0778945612', N'0778945612', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (6, N'0701234567', N'0701234567', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (7, N'0734567890', N'0734567890', N'Chofer;')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (8, N'0701234568', N'0701234568', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (9, N'0701234569', N'0701234569', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (10, N'0701234578', N'0701234578', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (11, N'0701234579', N'0701234579', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (12, N'0701234589', N'0701234589', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (13, N'0701234678', N'0701234678', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (14, N'0701234679', N'0701234679', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (15, N'0701234689', N'0701234689', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (16, N'0701234789', N'0701234789', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (17, N'0701235678', N'0701235678', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (18, N'0701235679', N'0701235679', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (19, N'0701235689', N'0701235689', N'Chofer')
GO
INSERT [dbo].[Sesion] ([IDSesion], [Usuario], [Contrasena], [Tipo]) VALUES (20, N'0701235789', N'0701235789', N'Chofer')
GO
/****** Object:  Index [PK1]    Script Date: 25/07/2021 10:27:50 ******/
ALTER TABLE [dbo].[Buses] ADD  CONSTRAINT [PK1] PRIMARY KEY NONCLUSTERED 
(
	[IDBus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK6]    Script Date: 25/07/2021 10:27:50 ******/
ALTER TABLE [dbo].[Carrera] ADD  CONSTRAINT [PK6] PRIMARY KEY NONCLUSTERED 
(
	[IDCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK2]    Script Date: 25/07/2021 10:27:50 ******/
ALTER TABLE [dbo].[Chofer] ADD  CONSTRAINT [PK2] PRIMARY KEY NONCLUSTERED 
(
	[IDChofer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK3]    Script Date: 25/07/2021 10:27:50 ******/
ALTER TABLE [dbo].[Ruta] ADD  CONSTRAINT [PK3] PRIMARY KEY NONCLUSTERED 
(
	[IDRuta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD  CONSTRAINT [RefBuses1] FOREIGN KEY([IDBus])
REFERENCES [dbo].[Buses] ([IDBus])
GO
ALTER TABLE [dbo].[Carrera] CHECK CONSTRAINT [RefBuses1]
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD  CONSTRAINT [RefChofer3] FOREIGN KEY([IDChofer])
REFERENCES [dbo].[Chofer] ([IDChofer])
GO
ALTER TABLE [dbo].[Carrera] CHECK CONSTRAINT [RefChofer3]
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD  CONSTRAINT [RefRuta2] FOREIGN KEY([IDRuta])
REFERENCES [dbo].[Ruta] ([IDRuta])
GO
ALTER TABLE [dbo].[Carrera] CHECK CONSTRAINT [RefRuta2]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarBuses]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarBuses]
@IdBus int,
@Placa varchar(10),
@Modelo varchar(50),
@Dueno varchar(50),
@NoBus int

AS
	Update Buses set IDBus=@IdBus, Placa=@Placa, Modelo=@Modelo, Dueno=@Dueno, NoBus=@NoBus
	where IDBus=@IdBus

GO
/****** Object:  StoredProcedure [dbo].[ActualizarCarrera]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCarrera]
@IdCarrera int,
@IdBus int,
@IdRuta int,
@IdChofer int,
@HoraSalida datetime,
@HoraLlegada datetime,
@Estado varchar(10)
AS
BEGIN
	Update Carrera set IDCarrera=@IdCarrera, IDBus=@IdBus, IDRuta=@IdRuta, IDChofer=@IdChofer, Tiempo=@HoraSalida, HoraLlegada=@HoraLlegada, Estado=@Estado
	where IDCarrera=@IdCarrera

END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarChofer]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarChofer]
@IdChofer int,
@Nombres varchar(10),
@Apellidos varchar(10),
@TipoLicencia varchar(10),
@Cedula  varchar(10)

AS
BEGIN
	Update Chofer set IDChofer=@IdChofer, Nombres=@Nombres, Apellidos=@Apellidos, TipoLicencia=@TipoLicencia, Cedula=@Cedula
	where IDChofer=@IdChofer

END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarRuta]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarRuta]
@IdRuta int,
@NombreRuta varchar(50),
@Tarifa money

AS
BEGIN
	Update Ruta set IDRuta=@IdRuta, NombreRuta=@NombreRuta, Tarifa=@Tarifa
	where IDRuta=@IdRuta

END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarSesion]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarSesion]
@IdSesion int,
@Usuario varchar(10),
@Contrasena varchar(10),
@Tipo varchar(10)

AS
BEGIN
	Update Sesion set IDSesion=@IdSesion ,Usuario=@Usuario, Contrasena=@Contrasena, Tipo=@Tipo
	where IDSesion=@IdSesion

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarBuses]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarBuses]
@IdBus int,
@Placa varchar(10),
@Modelo varchar(50),
@Dueno varchar(50),
@NoBus int

AS
BEGIN
	delete from Buses 
	where @IdBus=IDBus and @Placa=Placa and @Modelo=Modelo and @Dueno=Dueno and @NoBus=NoBus

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarChofer]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarChofer]
@IdChofer int,
@Nombres varchar(10),
@Apellidos varchar(10),
@TipoLicencia varchar(10),
@Cedula  varchar(10)

AS
BEGIN
	delete from Chofer 
	where @IdChofer=IDChofer and  @Nombres=Nombres and @Apellidos=Apellidos and @TipoLicencia=TipoLicencia and @Cedula=Cedula

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarRuta]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarRuta]
@IdRuta int,
@NombreRuta varchar(50),
@Tarifa money

AS
BEGIN
	delete from Ruta 
	where @IdRuta=IDRuta and @NombreRuta=NombreRuta and @Tarifa=Tarifa

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarSesion]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarSesion]
@IdSesion int,
@Usuario varchar(10),
@Contrasena varchar(10),
@Tipo varchar(10)

AS
BEGIN
	delete from Sesion 
	where @IdSesion=IDSesion and @Usuario=Usuario and @Contrasena=Contrasena and @Tipo=Tipo 

END
GO
/****** Object:  StoredProcedure [dbo].[EliminarSesionEliminar]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[EliminarSesionEliminar]
@IdSesion int

AS
BEGIN
	delete from Sesion 
	where @IdSesion=IDSesion

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarBuses]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarBuses]
@IdBus int,
@Placa varchar(10),
@Modelo varchar(50),
@Dueno varchar(50),
@NoBus int

AS
BEGIN
	Insert into Buses(IDBus, Placa, Modelo, Dueno, NoBus) 
	values (@IdBus, @Placa, @Modelo, @Dueno, @NoBus)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCarrera]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCarrera]
@IdCarrera int,
@IdBus int,
@IdRuta int,
@IdChofer int,
@HoraSalida datetime,
@HoraLlegada datetime,
@Estado varchar(10)


AS
BEGIN
	Insert into Carrera(IDCarrera, IDBus, IDRuta, IDChofer ,Tiempo, HoraLlegada, Estado) 
	values (@IdCarrera,@IdBus,@IdRuta,@IdChofer, @HoraSalida, @HoraLlegada, @Estado)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarChofer]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarChofer]
@IdChofer int,
@Nombres varchar(10),
@Apellidos varchar(10),
@TipoLicencia varchar(10),
@Cedula  varchar(10)

AS
BEGIN
	Insert into Chofer(IDChofer, Nombres, Apellidos, TipoLicencia, Cedula) 
	values (@IdChofer, @Nombres, @Apellidos, @TipoLicencia, @Cedula)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarRuta]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarRuta]
@IdRuta int,
@NombreRuta varchar(50),
@Tarifa money

AS
BEGIN
	Insert into Ruta(IDRuta, NombreRuta, Tarifa) 
	values (@IdRuta, @NombreRuta, @Tarifa)

END
GO
/****** Object:  StoredProcedure [dbo].[InsertarSesion]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarSesion]
@IdSesion int,
@Usuario varchar(10),
@Contrasena varchar(10),
@Tipo varchar(10)


AS
BEGIN
	Insert into Sesion( IDSesion, Usuario, Contrasena, Tipo) 
	values ( @IdSesion, @Usuario, @Contrasena, @Tipo)

END
GO
/****** Object:  StoredProcedure [dbo].[ListarBuses]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarBuses]

AS
BEGIN
select * from Buses

END
GO
/****** Object:  StoredProcedure [dbo].[ListarBusFiltrar]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarBusFiltrar]
@valor varchar(25)

AS
BEGIN
	select @valor = RTRIM(@valor) + '%'
	select * from Buses where IDBus like @valor or Placa like @valor

END
GO
/****** Object:  StoredProcedure [dbo].[ListarCarrera]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCarrera]

AS
BEGIN
select * from Carrera

END
GO
/****** Object:  StoredProcedure [dbo].[ListarCarreraFiltrar]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCarreraFiltrar]
@valor varchar(25)

AS
BEGIN
	select @valor = RTRIM(@valor) + '%'
	select * from Carrera where IDCarrera like @valor or IDChofer like @valor or IDRuta like @valor

END
GO
/****** Object:  StoredProcedure [dbo].[ListarChofer]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarChofer]

AS
BEGIN
select * from Chofer

END
GO
/****** Object:  StoredProcedure [dbo].[ListarChoferFiltrar]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarChoferFiltrar]
@valor varchar(25)

AS
BEGIN
	select @valor = RTRIM(@valor) + '%'
	select * from Chofer where IDChofer like @valor or Cedula like @valor

END
GO
/****** Object:  StoredProcedure [dbo].[ListarRuta]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRuta]

AS
BEGIN
select * from Ruta

END
GO
/****** Object:  StoredProcedure [dbo].[ListarRutaFiltrar]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRutaFiltrar]
@valor varchar(25)

AS
BEGIN
	select @valor = RTRIM(@valor) + '%'
	select * from Ruta where IDRuta like @valor or NombreRuta like @valor

END
GO
/****** Object:  StoredProcedure [dbo].[ListarSesion]    Script Date: 25/07/2021 10:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarSesion]

AS
BEGIN
select * from Sesion

END
GO
USE [master]
GO
ALTER DATABASE [ProyectoBD] SET  READ_WRITE 
GO
