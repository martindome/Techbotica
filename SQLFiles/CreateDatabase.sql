use master;
GO
ALTER DATABASE Techbotica SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
DROP DATABASE Techbotica;
GO
USE [master]
GO
/****** Object:  Database [Techbotica]    Script Date: 24/1/2023 23:23:57 ******/
CREATE DATABASE [Techbotica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Techbotica', FILENAME = N'C:\TECHBOTICASQL\Techbotica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Techbotica_log', FILENAME = N'C:\TECHBOTICASQL\Techbotica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Techbotica] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Techbotica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Techbotica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Techbotica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Techbotica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Techbotica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Techbotica] SET ARITHABORT OFF 
GO
ALTER DATABASE [Techbotica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Techbotica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Techbotica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Techbotica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Techbotica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Techbotica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Techbotica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Techbotica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Techbotica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Techbotica] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Techbotica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Techbotica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Techbotica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Techbotica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Techbotica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Techbotica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Techbotica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Techbotica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Techbotica] SET  MULTI_USER 
GO
ALTER DATABASE [Techbotica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Techbotica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Techbotica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Techbotica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Techbotica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Techbotica] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Techbotica] SET QUERY_STORE = OFF
GO
USE [Techbotica]
GO
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/*******************************************TABLAS***********************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[id] [int] NULL,
	[familia] [varchar](100) NULL,
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[id] [int] NULL,
	[id_familia] [int] NULL,
	[id_patente] [int] NULL,
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Usuario]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Usuario](
	[id] [int] NULL,
	[id_familia] [int] NULL,
	[id_usuario] [int] NULL,
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[id] [int] NULL,
	[detalle] [varchar](50) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] NULL,
	[usuario] [varchar](100) NULL,
	[contraseña] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
    [apellido] [varchar](100) NULL,
    [telefono] [varchar](100) NULL,
	[email] [varchar](100) NULL,
    [bloqueado] [int] NULL,
	[borrado] [varchar](100) NULL,
    [id_especialidad] [int] NULL,
    [id_empresa] [int] NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[id] [int] NULL,
	[nombre] [varchar](100) NULL,
    [descripcion] [varchar](MAX) NULL,
    [email] [varchar](100) NULL,
    [telefono] [varchar](100) NULL,
    [borrado] [varchar](100) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Dominio]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dominio](
	[id] [int] NULL,
	[sufijo] [varchar](100) NULL,
    [id_empresa] [int] NULL,
    [borrado] [varchar](100) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Especialidad]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidad](
	[id] [int] NULL,
	[nombre] [varchar](100) NULL,
    [descripcion] [varchar](MAX) NULL,
) ON [PRIMARY]
GO

/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/*************************************STORED PROCEDURES******************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/****** Object:  StoredProcedure [dbo].[listar_usuarios]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[listar_usuarios]
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email,a.bloqueado, a.borrado, a.telefono, a.apellido, a.id_empresa, a.id_especialidad, b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
inner join Familia c
on c.id = b.id_familia
end 
GO

/****** Object:  StoredProcedure [dbo].[obtener_usuario_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[obtener_usuario_usuario]
@usu varchar(100)
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.borrado, a.bloqueado, a.telefono, a.apellido, a.id_especialidad, a.id_empresa, b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
inner join Familia c
on c.id = b.id_familia
where a.usuario = @usu
end 
GO

/****** Object:  StoredProcedure [dbo].[obtener_usuario_id]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[obtener_usuario_id]
@id int
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.borrado, a.bloqueado, a.telefono, a.apellido, a.id_especialidad, a.id_empresa, b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
inner join Familia c
on c.id = b.id_familia
where a.id = @id
end 
GO

/****** Object:  StoredProcedure [dbo].[verificar_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[verificar_usuario]
@usu varchar(100), @pass varchar(100)
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.borrado, a.bloqueado, a.telefono, a.apellido, a.id_especialidad, a.id_empresa, b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
inner join Familia c
on c.id = b.id_familia
where a.usuario = @usu and a.contraseña = @pass
end 
GO


/****** Object:  StoredProcedure [dbo].[registrar_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[registrar_usuario]
@usu varchar(100),
@pass varchar(100),
@nom varchar(100),
@email varchar(100),
@tipo int,
@borrado varchar(100),
@apellido varchar(100),
@telefono varchar(100),
@empresa int,
@especialidad int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Usuario),0 ) +1
declare @id_fu int
set @id_fu = isnull((Select max(id) from Familia_Usuario),0 ) +1
INSERT INTO Usuario (id, usuario, contraseña, nombre, bloqueado, email, borrado, apellido, telefono, id_empresa, id_especialidad)
VALUES (@id, @usu, @pass, @nom, 0, @email, @borrado, @apellido, @telefono, @empresa, @especialidad);
Insert Into Familia_Usuario (id, id_familia, id_usuario)
VALUES (@id_fu, @tipo, @id);
end
select u.id as id, b.id as id_fu, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email, u.borrado as borrado, u.telefono as telefono, u.apellido as apellido, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad,  b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on b.id_usuario = u.id where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[listar_patentes]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_patentes]
@id_familia varchar(50)
as 
begin
select b.id, b.detalle
from Familia_Patente a 
inner join Patente b 
on a.id_patente= b.id 
where a.id_familia = @id_familia
end 
GO

/****** Object:  StoredProcedure [dbo].[bloquear_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bloquear_usuario]
@usu varchar(100)
as 
begin
UPDATE dbo.Usuario SET bloqueado = bloqueado + 1 where usuario = @usu
end 
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[update_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[update_usuario]
@usu varchar(100),
@email varchar(100),
@nombre varchar(100),
@borrado varchar(100),
@bloqueado int
as 
begin
UPDATE Usuario
SET bloqueado = @bloqueado, email=@email, nombre = @nombre
WHERE usuario = @usu;
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad, u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[verificar_usuario_sinpassword]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[verificar_usuario_sinpassword]
@usu varchar(100)
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.bloqueado, a.borrado, a.apellido, a.telefono, a.id_especialidad, a.id_empresa, b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
Inner join Familia c 
on c.id = b.id_familia
where a.usuario = @usu
end
GO

/****** Object:  StoredProcedure [dbo].[cambiar_familia]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cambiar_familia]
@usu int,
@familia int
as 
begin
UPDATE dbo.Familia_Usuario SET id_familia = @familia where id_usuario = @usu
end 
select u.id as id, b.id as id_fu, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad, u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where u.id = @usu
GO

/****** Object:  StoredProcedure [dbo].[blanquear_password]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[blanquear_password]
@usu varchar(100)
as 
begin
UPDATE dbo.Usuario SET bloqueado = 0 where usuario = @usu
end 
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[listar_usuariosBloqueados]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_usuariosBloqueados]
as 
begin
select *
from Usuario
where bloqueado = 3
end 
GO

/****** Object:  StoredProcedure [dbo].[desbloquear_usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[desbloquear_usuario]
@usu varchar(100)
as 
begin
UPDATE Usuario
SET bloqueado = 0
WHERE usuario = @usu;
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[cambiar_password]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cambiar_password]
@usu varchar(100),
@pass varchar(100)
as 
begin
UPDATE Usuario
SET contraseña = @pass, bloqueado = 0
WHERE usuario = @usu;
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[Restaurar_Usuario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[restaurar_usuario]
@usu varchar(100)
as 
begin
UPDATE Usuario
SET borrado = 'No', bloqueado = 0
WHERE usuario = @usu;
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.id_especialidad as id_especialidad,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
GO

/****** Object:  StoredProcedure [dbo].[validar_usuario_email]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[validar_usuario_email]
@email varchar(100)
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.apellido, a.telefono, a.bloqueado, a.borrado, a.id_especialidad, a.id_empresa, b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
Inner join Familia c 
on c.id = b.id_familia
where a.email = @email
end
GO

/****** Object:  StoredProcedure [dbo].[listar_empresas]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_empresas]
as 
begin
select e.id, e.nombre, e.descripcion, e.telefono, e.email, e.borrado
from Empresa e
end 
GO

/****** Object:  StoredProcedure [dbo].[listar_dominios_empresa]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_dominios_empresa]
@id_empresa varchar(100)
as 
begin
select d.id, d.sufijo, d.id_empresa, d.borrado
from Dominio d
inner join Empresa e on e.id = d.id_empresa
where e.id = @id_empresa
end 
GO

/****** Object:  StoredProcedure [dbo].[nueva_empresa]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nueva_empresa]
@nombre varchar(100),
@descripcion varchar(100),
@telefono varchar(100),
@email varchar(100),
@borrado varchar(100)
as 
begin
declare @id int
set @id = isnull((Select max(id) from Empresa),0 ) +1
INSERT INTO Empresa (id, nombre, descripcion, telefono, email, borrado)
VALUES (@id, @nombre, @descripcion, @telefono, @email, @borrado);
end
select u.id as id, u.nombre as nombre, u.descripcion as descripcion, u.telefono as telefono, u.email as email, u.borrado as borrado From Empresa u WHERE u.id = @id
GO

/****** Object:  StoredProcedure [dbo].[nuevo_dominio]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nuevo_dominio]
@sufijo varchar(100),
@id_empresa int,
@borrado varchar(100)
as 
begin
declare @id int
set @id = isnull((Select max(id) from Dominio),0 ) +1
INSERT INTO Dominio (id, sufijo, id_empresa, borrado)
VALUES (@id, @sufijo, @id_empresa, @borrado);
end
select u.id as id, u.sufijo as sufijo, u.id_empresa as id_empresa, u.borrado as borrado From Dominio u WHERE u.id = @id
GO

/****** Object:  StoredProcedure [dbo].[actualizar_empresa]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[actualizar_empresa]
@nombre varchar(100),
@descripcion varchar(100),
@telefono varchar(100),
@email varchar(100),
@borrado varchar(100),
@id int
as 
BEGIN
    UPDATE Empresa 
    SET nombre = @nombre,
        descripcion = @descripcion,
        telefono = @telefono,
        email = @email,
        borrado = @borrado
    WHERE id = @id;
END
SELECT u.id AS id, u.nombre AS nombre, u.descripcion AS descripcion, u.telefono AS telefono, u.email AS email, u.borrado AS borrado FROM Empresa u WHERE u.id = @id
GO

/****** Object:  StoredProcedure [dbo].[eliminar_dominio]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_dominio
@idDominio INT
AS
BEGIN
    DELETE FROM Dominio WHERE id = @idDominio;

END
GO


/****** Object:  StoredProcedure [dbo].[eliminar_empresa]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_empresa
@id INT
AS
BEGIN
    DELETE FROM Empresa WHERE id = @id;

END
GO


/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/*************************************DATOS******************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
/************************************************************************************************/
GO
INSERT [dbo].[Familia] ([id], [familia]) VALUES (1, N'Webmaster')
INSERT [dbo].[Familia] ([id], [familia]) VALUES (2, N'Estudiante')
INSERT [dbo].[Familia] ([id], [familia]) VALUES (3, N'Tutor')
INSERT [dbo].[Familia] ([id], [familia]) VALUES (4, N'Administrador')
GO
INSERT INTO [dbo].[Usuario] (id, [usuario], [contraseña], [nombre], [apellido], [telefono], [email], [bloqueado], [borrado], [id_empresa], id_especialidad) VALUES 
(1,'juan.perez@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Juan', 'Pérez', '555-1234', 'juan.perez@techbotica.ar', 0, 'No', 0, 0),
(2,'maria.gonzalez@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Maria', 'Gonzalez', '555-5678', 'maria.gonzalez@example.com', 0, 'No', 1, 0),
(3,'carlos.rodriguez@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Carlos', 'Rodriguez', '555-9101', 'carlos.rodriguez@techbotica.ar', 1, 'No', 0, 1 );
GO
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (1, N'MenuAdministracion')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (2, N'MenuTutores')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (3, N'MenuEstudiantes')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (4, N'MenuBusqueda')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (5, N'/Administracion/GestionarEmpresas')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (6, N'/Administracion/GestionarEstudiantes')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (7, N'/Administracion/GestionarTutores')
GO
INSERT [dbo].[Familia_Usuario] ([id], [id_familia], [id_usuario]) VALUES (1, 1, 1)
INSERT [dbo].[Familia_Usuario] ([id], [id_familia], [id_usuario]) VALUES (2, 2, 2)
INSERT [dbo].[Familia_Usuario] ([id], [id_familia], [id_usuario]) VALUES (3, 3, 3)
GO
--permisos web master
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (1, 1, 1)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (2, 1, 2)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (3, 1, 3)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (4, 1, 4)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (5, 1, 5)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (6, 1, 6)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (7, 1, 7)
GO
INSERT INTO [dbo].[Empresa] (id, [nombre], [descripcion], [email], [telefono], [borrado]) VALUES  
(1, 'example', 'Esta es una empresa de ejemplo', 'contacto@example.com', '555-1234', 'No'),
(2, 'example2', 'Esta es una empresa de ejemplo 2', 'contacto@example2.com', '555-1234', 'No')
GO
INSERT INTO  [dbo].[Dominio] (id, sufijo, id_empresa, borrado) VALUES 
(1, 'example.com', 1, 'No'),
(2, 'gmail.com',1, 'No')
INSERT into Especialidad (id, nombre, descripcion) VALUES
(1, 'Robotica', 'Especialista en Robotica'),
(2, 'Matematica', 'Especialista en Matematica')
