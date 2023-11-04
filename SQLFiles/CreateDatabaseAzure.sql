while(exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE='FOREIGN KEY'))
begin
 declare @sql nvarchar(2000)
 SELECT TOP 1 @sql=('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
 + '] DROP CONSTRAINT [' + CONSTRAINT_NAME + ']')
 FROM information_schema.table_constraints
 WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'
 exec (@sql)
 PRINT @sql
end

while(exists(select 1 from INFORMATION_SCHEMA.TABLES 
             where TABLE_NAME != '__MigrationHistory' 
             AND TABLE_TYPE = 'BASE TABLE'))
begin
 SELECT TOP 1 @sql=('DROP TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
 + ']')
 FROM INFORMATION_SCHEMA.TABLES
 WHERE TABLE_NAME != '__MigrationHistory' AND TABLE_TYPE = 'BASE TABLE'
exec (@sql)
 /* you dont need this line, it just shows what was executed */
 PRINT @sql
end

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[id] [int] PRIMARY KEY,
	[familia] [varchar](100) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Patente]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[id] [int] PRIMARY KEY,
	[detalle] [varchar](50) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[id] [int] PRIMARY KEY,
	[nombre] [varchar](100) NULL,
    [descripcion] [varchar](MAX) NULL,
    [email] [varchar](100) NULL,
    [telefono] [varchar](100) NULL,
    [borrado] [varchar](100) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] PRIMARY KEY,
	[usuario] [varchar](100) NULL,
	[contraseña] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
    [apellido] [varchar](100) NULL,
    [telefono] [varchar](100) NULL,
	[email] [varchar](100) NULL,
    [bloqueado] [int] NULL,
	[borrado] [varchar](100) NULL,
    [id_empresa] [int] NULL,
	FOREIGN KEY (id_empresa) REFERENCES Empresa(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[id] [int] PRIMARY KEY,
	[id_familia] [int] NULL,
	[id_patente] [int] NULL,
	FOREIGN KEY (id_familia) REFERENCES Familia(id) ON DELETE CASCADE,
	FOREIGN KEY (id_patente) REFERENCES Patente(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Familia_Usuario]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Usuario](
	[id] [int] PRIMARY KEY,
	[id_familia] [int] NULL,
	[id_usuario] [int] NULL,
	FOREIGN KEY (id_familia) REFERENCES Familia(id) ON DELETE CASCADE,
	FOREIGN KEY (id_usuario) REFERENCES Usuario(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Dominio]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dominio](
	[id] [int] PRIMARY KEY,
	[sufijo] [varchar](100) NULL,
    [id_empresa] [int] NULL,
    [borrado] [varchar](100) NULL,
	FOREIGN KEY (id_empresa) REFERENCES Empresa(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Especialidad]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidad](
	[id] [int] PRIMARY KEY,
	[nombre] [varchar](100) NULL,
    [descripcion] [varchar](MAX) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Curso]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[id] [int] PRIMARY KEY,
	[nombre] [varchar](100) NULL,
    [descripcion] [varchar](MAX) NULL,
	[id_especialidad] [int] NULL,
	FOREIGN KEY (id_especialidad) REFERENCES Especialidad(id) ON DELETE CASCADE,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Carrera]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[id] [int] PRIMARY KEY,
	[nombre] [varchar](100) NULL,
    [descripcion] [varchar](MAX) NULL,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Curso_Carrera]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso_Carrera](
	[id] [int] PRIMARY KEY,
	[id_curso] int NULL,
    [id_carrera] int NULL,
	FOREIGN KEY (id_curso) REFERENCES Curso(id) ON DELETE CASCADE,
	FOREIGN KEY (id_carrera) REFERENCES Carrera(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Tipo_Dictado]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Dictado](
	[id] [int] PRIMARY KEY,
	[tipo_dictado][varchar](100) NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Dictado]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictado](
	[id] [int] PRIMARY KEY,
	[fecha_inicio] date NULL,
    [fecha_fin] date NULL,
	[enlace] varchar(50) NULL,
	[id_curso] int NULL,
	[cupo] int NULL,
	[id_tipo_dictado] int NULL,
	FOREIGN KEY (id_curso) REFERENCES Curso(id) ON DELETE CASCADE,
	FOREIGN KEY (id_tipo_dictado) REFERENCES Tipo_Dictado(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Horario]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[id] [int] PRIMARY KEY,
	[dia] varchar(50) NULL,
	[hora_inicio] TIME NULL,
    [hora_fin] TIME NULL,
	[id_dictado] int NULL,
	FOREIGN KEY (id_dictado) REFERENCES Dictado(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Usuario_Dictado]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Dictado](
	[id] [int] PRIMARY KEY,
	[id_usuario] int NULL,
	[id_dictado] int NULL,
	FOREIGN KEY (id_dictado) REFERENCES Dictado(id) ON DELETE CASCADE,
	FOREIGN KEY (id_usuario) REFERENCES Usuario(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Inscripcion_Curso]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripcion_Curso](
	[id] [int] PRIMARY KEY,
	[fecha] datetime NULL,
	[id_estudiante] int NULL,
	[id_curso] int NULL,
	[id_dictado] int NULL,
	FOREIGN KEY (id_dictado) REFERENCES Dictado(id) ON DELETE NO ACTION,
	FOREIGN KEY (id_estudiante) REFERENCES Usuario(id) ON DELETE CASCADE,
	FOREIGN KEY (id_curso) REFERENCES Curso(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Inscripcion_Carrera]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripcion_Carrera](
	[id] [int] PRIMARY KEY,
	[fecha] datetime NULL,
	[id_estudiante] int NULL,
	[id_carrera] int NULL,
	FOREIGN KEY (id_carrera) REFERENCES Carrera(id) ON DELETE CASCADE,
	FOREIGN KEY (id_estudiante) REFERENCES Usuario(id) ON DELETE CASCADE
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Material]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[id] [int] PRIMARY KEY,
	[fecha] datetime NULL,
	[nombre] varchar(100) NULL,
	[id_dictado] int NULL,
	[archivo] varbinary(max)
	FOREIGN KEY (id_dictado) REFERENCES Dictado(id) ON DELETE CASCADE,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Actividad]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[id] [int] PRIMARY KEY,
	[fecha] datetime NULL,
	[nombre] varchar(100) NULL,
	[id_dictado] int NULL,
	[archivo] varbinary(max)
	FOREIGN KEY (id_dictado) REFERENCES Dictado(id) ON DELETE CASCADE,
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Entrega]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrega](
	[id] [int] PRIMARY KEY,
	[id_actividad] [int] null,
	[id_estudiante] int NULL,
	[archivo] varbinary(max),
	[fecha] datetime null,
	[comentario] varchar(max)
	FOREIGN KEY (id_actividad) REFERENCES Actividad(id) ON DELETE CASCADE,
	FOREIGN KEY (id_estudiante) REFERENCES Usuario(id) ON DELETE CASCADE,
) ON [PRIMARY]
GO

-- /****** Object:  Table [dbo].[Horario_Dictado]    Script Date: 24/1/2023 23:23:57 ******/
-- SET ANSI_NULLS ON
-- GO
-- SET QUOTED_IDENTIFIER ON
-- GO
-- CREATE TABLE [dbo].[Horario_Dictado](
-- 	[id] [int] PRIMARY KEY,
-- 	[id_horario] int NULL,
-- 	[id_dictado] int NULL,
-- 	FOREIGN KEY (id_horario) REFERENCES Horario(id) ON DELETE CASCADE,
-- 	FOREIGN KEY (id_dictado) REFERENCES Dictado(id) ON DELETE CASCADE
-- ) ON [PRIMARY]
-- GO

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
select a.id, a.nombre, a.usuario, a.contraseña, a.email,a.bloqueado, a.borrado, a.telefono, a.apellido, a.id_empresa,  b.id_familia as familia, c.familia as detalle
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
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.borrado, a.bloqueado, a.telefono, a.apellido,  a.id_empresa, b.id_familia as familia, c.familia as detalle
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
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.borrado, a.bloqueado, a.telefono, a.apellido,  a.id_empresa, b.id_familia as familia, c.familia as detalle
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
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.borrado, a.bloqueado, a.telefono, a.apellido,  a.id_empresa, b.id_familia as familia, c.familia as detalle
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
@empresa int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Usuario),0 ) +1
declare @id_fu int
set @id_fu = isnull((Select max(id) from Familia_Usuario),0 ) +1
INSERT INTO Usuario (id, usuario, contraseña, nombre, bloqueado, email, borrado, apellido, telefono, id_empresa)
VALUES (@id, @usu, @pass, @nom, 0, @email, @borrado, @apellido, @telefono, @empresa);
Insert Into Familia_Usuario (id, id_familia, id_usuario)
VALUES (@id_fu, @tipo, @id);
end
select u.id as id, b.id as id_fu, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email, u.borrado as borrado, u.telefono as telefono, u.apellido as apellido, u.id_empresa as id_empresa,   b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on b.id_usuario = u.id where usuario = @usu
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
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa, u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
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
@apellido varchar(100),
@telefono varchar(100),
@bloqueado int,
@empresa int
as 
begin
UPDATE Usuario
SET bloqueado = @bloqueado, email=@email, nombre = @nombre, apellido=@apellido, telefono=@telefono, borrado = @borrado, id_empresa = @empresa
WHERE usuario = @usu;
end
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
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
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.bloqueado, a.borrado, a.apellido, a.telefono,  a.id_empresa, b.id_familia as familia, c.familia as detalle
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
select u.id as id, b.id as id_fu, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.id_empresa as id_empresa,  u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where u.id = @usu
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
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa,   u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
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
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa,   u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
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
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa,   u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
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
select u.id as id, u.usuario as usuario, u.contraseña as contraseña, u.nombre as nombre, u.bloqueado as bloqueado, u.email as email, u.apellido as apellido, u.telefono as telefono, u.id_empresa as id_empresa,   u.borrado as borrado, b.id_familia as familia From Usuario u INNER JOIN Familia_Usuario b on u.id = b.id_usuario where usuario = @usu
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
select a.id, a.nombre, a.usuario, a.contraseña, a.email, a.apellido, a.telefono, a.bloqueado, a.borrado,  a.id_empresa, b.id_familia as familia, c.familia as detalle
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


/****** Object:  StoredProcedure [dbo].[listar_especialidades]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_especialidades]
as 
begin
select e.id, e.nombre, e.descripcion
from Especialidad e
end 
GO


/****** Object:  StoredProcedure [dbo].[listar_familias]    Script Date: 24/1/2023 23:23:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_familias]
as 
begin
select *
from Familia
end
GO

/****** Object:  StoredProcedure [dbo].[listar_cursos]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_cursos]
as 
begin
select e.id, e.nombre, e.descripcion, e.id_especialidad from Curso e
end 
GO

/****** Object:  StoredProcedure [dbo].[nuevo_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nuevo_curso]
@nombre varchar(100),
@descripcion varchar(100),
@especialidad int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Curso),0 ) +1
INSERT INTO Curso (id, nombre, descripcion, id_especialidad)
VALUES (@id, @nombre, @descripcion, @especialidad);
end
select e.id, e.nombre, e.descripcion, e.id_especialidad from Curso e WHERE e.id = @id
GO


/****** Object:  StoredProcedure [dbo].[actualizar_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[actualizar_curso]
@nombre varchar(100),
@descripcion varchar(100),
@id int,
@especialidad int
as 
BEGIN
    UPDATE Curso 
    SET nombre = @nombre,
        descripcion = @descripcion,
		id_especialidad = @especialidad
    WHERE id = @id;
END
select e.id, e.nombre, e.descripcion, e.id_especialidad from Curso e WHERE e.id = @id
GO

/****** Object:  StoredProcedure [dbo].[eliminar_curso]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_curso
@id INT
AS
BEGIN
    DELETE FROM Curso WHERE id = @id;

END
GO


/****** Object:  StoredProcedure [dbo].[listar_cursos_carrera]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_cursos_carrera]
@id int
as 
begin
select e.id, e.nombre, e.descripcion, e.id_especialidad from Curso e inner join Curso_Carrera cc on cc.id_curso = e.id where cc.id_carrera = @id
end 
GO

/****** Object:  StoredProcedure [dbo].[listar_carreras]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_carreras]
as 
begin
select e.id, e.nombre, e.descripcion from Carrera e
end 
GO

/****** Object:  StoredProcedure [dbo].[nueva_carrera]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nueva_carrera]
@nombre varchar(100),
@descripcion varchar(100)
as 
begin
declare @id int
set @id = isnull((Select max(id) from Carrera),0 ) +1
INSERT INTO Carrera (id, nombre, descripcion)
VALUES (@id, @nombre, @descripcion);
end
select e.id, e.nombre, e.descripcion from Carrera e WHERE e.id = @id
GO

/****** Object:  StoredProcedure [dbo].[actualizar_carrera]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[actualizar_carrera]
@nombre varchar(100),
@descripcion varchar(100),
@id int
as 
BEGIN
    UPDATE Carrera 
    SET nombre = @nombre,
        descripcion = @descripcion
    WHERE id = @id;
END
select e.id, e.nombre, e.descripcion from Carrera e WHERE e.id = @id
GO

/****** Object:  StoredProcedure [dbo].[eliminar_carrera]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_carrera
@id INT
AS
BEGIN
    DELETE FROM Carrera WHERE id = @id;
END
GO

/****** Object:  StoredProcedure [dbo].[nuevo_curso_carrera]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nuevo_curso_carrera]
@id_carrera int,
@id_curso int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Curso_Carrera),0 ) +1
INSERT INTO Curso_Carrera (id, id_carrera, id_curso)
VALUES (@id, @id_carrera, @id_curso);
end
select e.id, e.nombre, e.descripcion from Carrera e WHERE e.id = @id_carrera
GO

/****** Object:  StoredProcedure [dbo].[eliminar_curso_carrera]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_curso_carrera
@id_carrera INT,
@id_curso INT
AS
BEGIN
    DELETE FROM Curso_Carrera WHERE id_carrera = @id_carrera AND id_curso = @id_curso;
END
GO

/****** Object:  StoredProcedure [dbo].[listar_dictados]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_dictados]
as 
begin
select d.id, d.fecha_inicio, d.fecha_fin, d.enlace, t.tipo_dictado, d.id_curso, d.cupo from Dictado d inner join Tipo_Dictado t on t.id = d.id_tipo_dictado
end 
GO

/****** Object:  StoredProcedure [dbo].[nuevo_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nuevo_dictado]
@fecha_inicio Date,
@fecha_fin Date,
@enlace varchar(100),
@tipo_dictado int,
@curso int,
@cupo int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Dictado),0 ) +1
INSERT INTO Dictado (id, fecha_inicio, fecha_fin, enlace, id_tipo_dictado, id_curso, cupo)
VALUES (@id, @fecha_inicio, @fecha_fin, @enlace, @tipo_dictado, @curso, @cupo);
end
select d.id, d.fecha_inicio, d.fecha_fin, d.enlace, t.tipo_dictado, d.id_curso, d.cupo from Dictado d inner join Tipo_Dictado t on t.id = d.id_tipo_dictado where d.id = @id
GO

/****** Object:  StoredProcedure [dbo].[actualizar_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[actualizar_dictado]
@fecha_inicio Date,
@fecha_fin Date,
@enlace varchar(100),
@tipo_dictado int,
@id int,
@cupo int
as 
BEGIN
    UPDATE Dictado 
    SET fecha_fin = @fecha_fin,
		fecha_inicio = @fecha_inicio,
		enlace = @enlace,
		id_tipo_dictado = @tipo_dictado,
		cupo = @cupo
    WHERE id = @id;
END
select d.id, d.fecha_inicio, d.fecha_fin, d.enlace, t.tipo_dictado, d.id_curso, d.cupo from Dictado d inner join Tipo_Dictado t on t.id = d.id_tipo_dictado where d.id = @id
GO

/****** Object:  StoredProcedure [dbo].[eliminar_dictado]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_dictado
@id INT
AS
BEGIN
    DELETE FROM Dictado WHERE id = @id;

END
GO


/****** Object:  StoredProcedure [dbo].[nuevo_horario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nuevo_horario]
@hora_inicio TIME,
@hora_fin TIME,
@dia varchar(100),
@dictado int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Horario),0 ) +1
INSERT INTO Horario (id, hora_inicio, hora_fin, dia, id_dictado)
VALUES (@id, @hora_inicio, @hora_fin, @dia, @dictado);
end
select h.id, h.hora_inicio, h.hora_fin, h.dia, h.id_dictado from Horario h where h.id = @id
GO

/****** Object:  StoredProcedure [dbo].[actualizar_horario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[actualizar_horario]
@hora_inicio TIME,
@hora_fin TIME,
@dia varchar(100),
@id int
as 
BEGIN
    UPDATE Horario 
    SET hora_fin = @hora_fin,
		hora_inicio = @hora_inicio,
		dia = @dia
    WHERE id = @id;
END
select h.id, h.hora_inicio, h.hora_fin, h.dia, h.id_dictado from Horario h where h.id = @id
GO


/****** Object:  StoredProcedure [dbo].[eliminar_horario]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_horario
@id INT
AS
BEGIN
    DELETE FROM Horario WHERE id = @id;
END
GO

/****** Object:  StoredProcedure [dbo].[listar_horarios_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_horarios_dictado]
@id_curso int
as 
begin
select h.id, h.hora_inicio, h.hora_fin, h.dia, h.id_dictado from Horario h where h.id_dictado = @id_curso
end 
GO

/****** Object:  StoredProcedure [dbo].[listar_dictados_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_dictados_curso]
@id int
as 
begin
select d.id, d.fecha_inicio, d.fecha_fin, d.enlace, t.tipo_dictado, d.id_curso, d.cupo from Dictado d inner join Tipo_Dictado t on t.id = d.id_tipo_dictado Where d.id_curso = @id
end 
GO

/****** Object:  StoredProcedure [dbo].[nuevo_usuario_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[nuevo_usuario_dictado]
@id_usuario int,
@id_dictado int
as 
begin
declare @id int
set @id = isnull((Select max(id) from Usuario_Dictado),0 ) +1
INSERT INTO Usuario_Dictado (id, id_usuario, id_dictado)
VALUES (@id, @id_usuario, @id_dictado);
end
select d.id, d.fecha_inicio, d.fecha_fin, d.enlace, t.tipo_dictado, d.id_curso, d.cupo from Dictado d inner join Tipo_Dictado t on t.id = d.id_tipo_dictado Where d.id = @id_dictado
GO

/****** Object:  StoredProcedure [dbo].[eliminar_usuario_dictado]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_usuario_dictado
@id_usuario int,
@id_dictado int
AS
BEGIN
    DELETE FROM Usuario_Dictado WHERE id_usuario = @id_usuario AND id_dictado = @id_dictado;
END
GO

/****** Object:  StoredProcedure [dbo].[listar_usuarios_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_usuarios_dictado]
@id_dictado int
as 
begin
select a.id, a.nombre, a.usuario, a.contraseña, a.email,a.bloqueado, a.borrado, a.telefono, a.apellido, a.id_empresa,  b.id_familia as familia, c.familia as detalle
from Usuario a 
inner join Familia_Usuario b 
on a.id = b.id_usuario
inner join Familia c
on c.id = b.id_familia
inner JOIN Usuario_Dictado ud on ud.id_dictado = @id_dictado and ud.id_usuario = a.id
end 
GO



/****** Object:  StoredProcedure [dbo].[listar_inscripciones_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_inscripciones_curso]
as 
begin
select a.id, a.fecha, a.id_estudiante, a.id_dictado, a.id_curso
from Inscripcion_Curso a
end
GO


/****** Object:  StoredProcedure [dbo].[listar_inscripciones_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_inscripciones_curso_estudiante]
@id_usuario int
as 
begin
select a.id, a.fecha, a.id_estudiante, a.id_dictado, a.id_curso
from Inscripcion_Curso a
where id_estudiante = @id_usuario
end
GO

/****** Object:  StoredProcedure [dbo].[listar_inscripciones_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_inscripciones_curso_dictado]
@id_dictado int
as 
begin
select a.id, a.fecha, a.id_estudiante, a.id_dictado, a.id_curso
from Inscripcion_Curso a
where id_dictado = @id_dictado
end
GO



/****** Object:  StoredProcedure [dbo].[nueva_inscripcion_curso]    Script Date: 5/7/2022 03:16:57 ******/
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[nueva_inscripcion_curso]
    @id_usuario INT,
    @id_dictado INT,
	@id_curso INT
AS 
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Inscripcion_Curso),0 ) +1
    
    -- Insertando la fecha actual en la columna 'fecha'
    INSERT INTO Inscripcion_Curso (id, fecha, id_dictado, id_estudiante, id_curso)
    VALUES (@id, GETDATE(), @id_dictado, @id_usuario, @id_curso);
    
    
END
SELECT a.id, a.id_estudiante, a.id_dictado, a.fecha , a.id_curso
    FROM Inscripcion_Curso a
GO

/****** Object:  StoredProcedure [dbo].[eliminar_inscripcion]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_inscripcion_curso
@id int
AS
BEGIN
    DELETE FROM Inscripcion_Curso WHERE id = @id;
END
GO



/****** Object:  StoredProcedure [dbo].[listar_inscripciones_carrera]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_inscripciones_carrera]
as 
begin
select a.id, a.fecha, a.id_estudiante, a.id_carrera
from Inscripcion_Carrera a
end
GO


/****** Object:  StoredProcedure [dbo].[listar_inscripciones_carrera_estudiante]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_inscripciones_carrera_estudiante]
@id_usuario int
as 
begin
select a.id, a.fecha, a.id_estudiante, a.id_carrera
from Inscripcion_Carrera a
where id_estudiante = @id_usuario
end
GO

/****** Object:  StoredProcedure [dbo].[nueva_inscripcion_carrera]    Script Date: 5/7/2022 03:16:57 ******/
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[nueva_inscripcion_carrera]
    @id_usuario INT,
    @id_carrera INT
AS 
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Inscripcion_Carrera),0 ) +1
    
    -- Insertando la fecha actual en la columna 'fecha'
    INSERT INTO Inscripcion_Carrera (id, fecha, id_carrera, id_estudiante)
    VALUES (@id, GETDATE(), @id_carrera, @id_usuario);
    
    
END
SELECT a.id, a.id_estudiante, a.id_carrera, a.fecha
    FROM Inscripcion_Carrera a
GO

/****** Object:  StoredProcedure [dbo].[eliminar_inscripcion_carrera]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_inscripcion_carrera
@id int
AS
BEGIN
    DELETE FROM Inscripcion_Carrera WHERE id = @id;
END
GO


/****** Object:  StoredProcedure [dbo].[nuevo_material]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE nuevo_material
@id_dictado INT,
@nombre varchar(100),
@fecha datetime,
@archivo varbinary(max)
AS
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Material),0 ) +1
    INSERT INTO Material (id, nombre, fecha, archivo, id_dictado)
    VALUES (@id, @nombre, @fecha, @archivo, @id_dictado);
END
GO


/****** Object:  StoredProcedure [dbo].[listar_materiales_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_materiales_dictado]
@id_dictado int
as 
begin
select a.id, a.fecha, a.id_dictado, a.archivo, a.nombre
from Material a
where id_dictado = @id_dictado
end
GO

/****** Object:  StoredProcedure [dbo].[eliminar_material]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_material
@id int
AS
BEGIN
    DELETE FROM Material WHERE id = @id;
END
GO

/****** Object:  StoredProcedure [dbo].[editar_material]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editar_material]
@id_dictado INT,
@nombre varchar(100),
@fecha datetime,
@archivo varbinary(max),
@id INT
as 
BEGIN
    UPDATE Material 
    SET nombre = @nombre,
		fecha = @fecha,
		archivo = @archivo,
		id_dictado = @id_dictado
    WHERE id = @id;
END
GO


/****** Object:  StoredProcedure [dbo].[nueva_actividad]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE nueva_actividad
@id_dictado INT,
@nombre varchar(100),
@fecha datetime,
@archivo varbinary(max)
AS
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Actividad),0 ) +1
    INSERT INTO Actividad (id, nombre, fecha, archivo, id_dictado)
    VALUES (@id, @nombre, @fecha, @archivo, @id_dictado);
END
GO


/****** Object:  StoredProcedure [dbo].[listar_actividades_dictado]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_actividades_dictado]
@id_dictado int
as 
begin
select a.id, a.fecha, a.id_dictado, a.archivo, a.nombre
from Actividad a
where id_dictado = @id_dictado
end
GO

/****** Object:  StoredProcedure [dbo].[eliminar_actividad]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_actividad
@id int
AS
BEGIN
    DELETE FROM Actividad WHERE id = @id;
END
GO

/****** Object:  StoredProcedure [dbo].[editar_actividad]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editar_actividad]
@id_dictado INT,
@nombre varchar(100),
@fecha datetime,
@archivo varbinary(max),
@id INT
as 
BEGIN
    UPDATE Actividad 
    SET nombre = @nombre,
		fecha = @fecha,
		archivo = @archivo,
		id_dictado = @id_dictado
    WHERE id = @id;
END
GO

/****** Object:  StoredProcedure [dbo].[listar_actividades]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_actividades]
as 
begin
select a.id, a.fecha, a.id_dictado, a.archivo, a.nombre
from Actividad a
end
GO


/****** Object:  StoredProcedure [dbo].[nueva_entrega]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE nueva_entrega
@id_actividad INT,
@id_estudiante INT,
@fecha datetime,
@archivo varbinary(max),
@comentario varchar (MAX)
AS
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Entrega),0 ) +1
    INSERT INTO Entrega (id, comentario, fecha, archivo, id_actividad, id_estudiante)
    VALUES (@id, @comentario, @fecha, @archivo, @id_actividad, @id_estudiante);
END
GO


/****** Object:  StoredProcedure [dbo].[listar_entregas_actividad]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[listar_entregas_actividad]
@id_actividad int
as 
begin
select a.id, a.fecha, a.id_actividad, a.id_estudiante, a.archivo, a.comentario
from Entrega a
where id_actividad = @id_actividad
end
GO

/****** Object:  StoredProcedure [dbo].[eliminar_entrega]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_entrega
@id int
AS
BEGIN
    DELETE FROM Entrega WHERE id = @id;
END
GO


/****** Object:  StoredProcedure [dbo].[editar_comentario]    Script Date: 5/7/2022 03:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[editar_comentario]
@id_entrega INT,
@comentario varchar(max)
as 
BEGIN
    UPDATE Entrega 
    SET comentario = @comentario
    WHERE id = @id_entrega;
END
GO

/****** Object:  StoredProcedure [dbo].[agregar_familia]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE agregar_familia
@detalle varchar(max)
AS
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Familia),0 ) +1
    INSERT INTO Familia (id, familia)
    VALUES (@id, @detalle);
END
GO

/****** Object:  StoredProcedure [dbo].[eliminar_familia]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_familia
@id int
AS
BEGIN
    DELETE FROM Familia WHERE id = @id;
END
GO

/****** Object:  StoredProcedure [dbo].[agregar_familia_patente]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE agregar_familia_patente
@familia int,
@patente int
AS
BEGIN
    DECLARE @id INT
    SET @id = ISNULL((SELECT MAX(id) FROM Familia_Patente),0 ) +1
    INSERT INTO Familia_Patente (id, id_familia, id_patente)
    VALUES (@id, @familia, @patente);
END
GO

/****** Object:  StoredProcedure [dbo].[eliminar_familia_patente]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE eliminar_familia_patente
@familia int,
@patente int
AS
BEGIN
    DELETE FROM Familia_Patente WHERE id_familia = @familia AND id_patente = @patente;
END
GO

/****** Object:  StoredProcedure [dbo].[listar_patentes_todas]    Script Date: 5/7/2022 03:16:57 ******/
CREATE PROCEDURE listar_patentes_todas
AS
BEGIN
    SELECT * FROM Patente
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
INSERT INTO [dbo].[Empresa] (id, [nombre], [descripcion], [email], [telefono], [borrado]) VALUES  
(1, 'TECHBOTICA', 'Empresa TECHBOTICA', 'contacto@techbotica.com', '555-1234', 'No'),
(2, 'Metalurgica de peuba', 'Esta es una empresa de ejemplo 2', 'contacto@example2.com', '555-1234', 'No')
GO
INSERT INTO [dbo].[Usuario] (id, [usuario], [contraseña], [nombre], [apellido], [telefono], [email], [bloqueado], [borrado], [id_empresa]) VALUES 
(1,'web.master@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Web', 'Master', '555-1234', 'web.master@techbotica.ar', 0, 'No', 1),
(2,'maria.gonzalez@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Maria', 'Gonzalez', '555-5678', 'maria.gonzalez@example.com', 0, 'No', 2),
(3,'carlos.rodriguez@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Carlos', 'Rodriguez', '555-9101', 'martindome96@gmail.com', 0, 'No', 1);
GO
--Administracion
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (1, N'MenuAdministracion')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (5, N'/Administracion/GestionarEmpresas')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (6, N'/Administracion/GestionarUsuarios')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (7, N'/Administracion/GestionarTutores')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (8, N'/Administracion/GestionarInscripciones')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (16, N'/Administracion/GestionarPermisos')
--Tutores
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (2, N'MenuTutores')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (9, N'/Tutores/GestionarCarreras')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (10, N'/Tutores/GestionarCursos')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (11, N'/Tutores/GestionarDictados')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (12, N'/Tutores/MisDictados')
--Estudiantes
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (3, N'MenuEstudiantes')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (4, N'MenuBusqueda')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (13, N'/Estudiante/Inscripciones')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (14, N'/Estudiante/Consultas')
INSERT [dbo].[Patente] ([id], [detalle]) VALUES (15, N'/Estudiante/Dictados')
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
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (8, 1, 8)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (9, 1, 9)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (10, 1, 10)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (11, 1, 11)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (12, 1, 12)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (13, 1, 13)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (14, 1, 14)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (15, 1, 15)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (16, 1, 16)
--permisos tutor
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (17, 3, 2)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (18, 3, 9)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (19, 3, 10)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (20, 3, 11)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (21, 3, 12)
--permisos estudiante
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (23, 2, 3)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (24, 2, 4)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (25, 2, 13)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (26, 2, 14)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (27, 2, 15)
--permisos administrador
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (28, 4, 1)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (29, 4, 5)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (30, 4, 6)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (31, 4, 7)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (32, 4, 8)
INSERT [dbo].[Familia_Patente] ([id], [id_familia], [id_patente]) VALUES (33, 4, 16)
GO
INSERT INTO  [dbo].[Dominio] (id, sufijo, id_empresa, borrado) VALUES 
(1, 'techbotica.ar', 1, 'No'),
(2, 'gmail.com', 1, 'No'),
(3, 'example.com', 2, 'No'),
(4, 'alumnos.uai.edu.ar', 2, 'No')
INSERT into Especialidad (id, nombre, descripcion) VALUES
(1, 'Robotica', 'Especialista en Robotica'),
(2, 'Matematica', 'Especialista en Matematica')
INSERT into Carrera (id, nombre, descripcion) VALUES
(1, 'Carrera en Robotica', 'Tecnico robotico'),
(2, 'Carrera en Matematica', 'Tecnico matematico')
INSERT into Curso (id, nombre, descripcion, id_especialidad) VALUES
(1, 'Robotica-01', 'Curso de robotica inicial', 1),
(2, 'Matematica-01', 'Curso de matematica inicial', 2)
INSERT into Curso_Carrera (id, id_carrera, id_curso) VALUES
(1, 1, 1),
(2, 2, 2)

INSERT INTO [dbo].[Tipo_Dictado] (id, tipo_dictado)
VALUES (1, 'Autodirigido'),
       (2, 'Interactivo');

INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES (1, '2023-09-05', '2023-09-10', 'http://enlace1.com', 1, 1, 20), --formato de la fecha aca es anio-mes-dia
       (2, '2023-09-05', '2023-09-10', 'http://enlace2.com', 1, 2, 12);

INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES (1, 'Lunes', '08:00:00', '10:00:00',2),
       (2, 'Martes', '10:00:00', '12:00:00',2); --debe tener al menos un horario cada dictado interactivo

INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES (1,1,3),
       (2,2,3); --debe tener al menos un horario cada dictado interactivo

-- INSERT INTO [dbo].[Horario_Dictado] (id, id_horario, id_dictado)
-- VALUES (1, 1, 1),
--        (2, 2, 2);


-- Insertando tutores
INSERT INTO [dbo].[Usuario] (id, [usuario], [contraseña], [nombre], [apellido], [telefono], [email], [bloqueado], [borrado], [id_empresa]) VALUES 
(4,'tutor1@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Tutor1', 'Apellido', '555-0001', 'tutor1@techbotica.ar', 0, 'No', 1),
(5,'tutor2@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Tutor2', 'Apellido', '555-0002', 'tutor2@techbotica.ar', 0, 'No', 1),
(6,'tutor3@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Tutor3', 'Apellido', '555-0003', 'tutor3@techbotica.ar', 0, 'No', 1),
(7,'tutor4@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Tutor4', 'Apellido', '555-0004', 'tutor4@techbotica.ar', 0, 'No', 1),
(8,'tutor5@techbotica.ar', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Tutor5', 'Apellido', '555-0005', 'tutor5@techbotica.ar', 0, 'No', 1);

-- Asignando la familia de tutores a los usuarios nuevos
INSERT INTO [dbo].[Familia_Usuario] ([id], [id_familia], [id_usuario]) VALUES 
(4, 3, 4),
(5, 3, 5),
(6, 3, 6),
(7, 3, 7),
(8, 3, 8);

-- Insertando estudiantes
INSERT INTO [dbo].[Usuario] (id, [usuario], [contraseña], [nombre], [apellido], [telefono], [email], [bloqueado], [borrado], [id_empresa]) VALUES 
(9, 'estudiante1@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante1', 'Apellido', '555-1001', 'estudiante1@example.com', 0, 'No', 2),
(10, 'estudiante2@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante2', 'Apellido', '555-1002', 'estudiante2@example.com', 0, 'No', 2),
(11, 'estudiante3@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante3', 'Apellido', '555-1003', 'estudiante3@example.com', 0, 'No', 2),
(12, 'estudiante4@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante4', 'Apellido', '555-1004', 'estudiante4@example.com', 0, 'No', 2),
(13, 'estudiante5@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante5', 'Apellido', '555-1005', 'estudiante5@example.com', 0, 'No', 2),
(14, 'estudiante6@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante6', 'Apellido', '555-1006', 'estudiante6@example.com', 0, 'No', 2),
(15, 'estudiante7@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante7', 'Apellido', '555-1007', 'estudiante7@example.com', 0, 'No', 2),
(16, 'estudiante8@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante8', 'Apellido', '555-1008', 'estudiante8@example.com', 0, 'No', 2),
(17, 'estudiante9@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante9', 'Apellido', '555-1009', 'estudiante9@example.com', 0, 'No', 2),
(18, 'estudiante10@example.com', '13004D8331D779808A2336D46B3553D1594229E2BB696A8E9E14554D82A648DA', 'Estudiante10', 'Apellido', '555-1010', 'estudiante10@example.com', 0, 'No', 2);

-- Asignando la familia de estudiantes a los usuarios nuevos
INSERT INTO [dbo].[Familia_Usuario] ([id], [id_familia], [id_usuario]) VALUES 
(9, 2, 9),
(10, 2, 10),
(11, 2, 11),
(12, 2, 12),
(13, 2, 13),
(14, 2, 14),
(15, 2, 15),
(16, 2, 16),
(17, 2, 17),
(18, 2, 18);


-- Creación de Dictados de Octubre 2023 a Enero 2024
-- Asumiendo que los cursos y los tipos de dictado ya están definidos como en tus ejemplos.

-- Octubre 2023
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(3, '2023-10-01', '2023-10-31', 'http://enlaceDictadoOctubre.com', 1, 1, 20), -- Autodirigido, Curso 1
(4, '2023-10-01', '2023-10-31', 'http://enlaceDictadoInteractivoOctubre.com', 1, 2, 12); -- Interactivo, Curso 1

-- Horario para el Dictado Interactivo de Octubre
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(3, 'Lunes', '09:00:00', '11:00:00', 4),
(4, 'Miércoles', '09:00:00', '11:00:00', 4);

-- Vinculación de tutores a los Dictados (asumiendo que el tutor con id_usuario 3 está disponible)
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(3, 3, 3),
(4, 4, 3);

-- Noviembre 2023
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(5, '2023-11-01', '2023-11-30', 'http://enlaceDictadoNoviembre.com', 1, 1, 20), -- Autodirigido, Curso 1
(6, '2023-11-01', '2023-11-30', 'http://enlaceDictadoInteractivoNoviembre.com', 1, 2, 12); -- Interactivo, Curso 1

-- Horario para el Dictado Interactivo de Noviembre
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(5, 'Martes', '09:00:00', '11:00:00', 6),
(6, 'Jueves', '09:00:00', '11:00:00', 6);

-- Vinculación de tutores a los Dictados
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(5, 5, 3),
(6, 6, 3);

-- Diciembre 2023
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(7, '2023-12-01', '2023-12-31', 'http://enlaceDictadoDiciembre.com', 1, 1, 20), -- Autodirigido, Curso 1
(8, '2023-12-01', '2023-12-31', 'http://enlaceDictadoInteractivoDiciembre.com', 1, 2, 12); -- Interactivo, Curso 1

-- Horario para el Dictado Interactivo de Diciembre
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(7, 'Lunes', '14:00:00', '16:00:00', 8),
(8, 'Miércoles', '14:00:00', '16:00:00', 8);

-- Vinculación de tutores a los Dictados
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(7, 7, 3),
(8, 8, 3);

-- Enero 2024
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(9, '2024-01-01', '2024-01-31', 'http://enlaceDictadoEnero.com', 1, 1, 20), -- Autodirigido, Curso 1
(10, '2024-01-01', '2024-01-31', 'http://enlaceDictadoInteractivoEnero.com', 1, 2, 12); -- Interactivo, Curso 1

-- Horario para el Dictado Interactivo de Enero
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(9, 'Martes', '14:00:00', '16:00:00', 10),
(10, 'Jueves', '14:00:00', '16:00:00', 10);

-- Vinculación de tutores a los Dictados
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(9, 9, 3),
(10, 10, 3);


INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(11, '2023-10-01', '2023-10-31', 'http://enlaceMatematicaAutodirigido.com', 2, 1, 20), -- Autodirigido, Curso 2
(12, '2023-10-01', '2023-10-31', 'http://enlaceMatematicaInteractivo.com', 2, 2, 12); -- Interactivo, Curso 2

-- Horario para el Dictado Interactivo de Matemática de Octubre
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(11, 'Martes', '14:00:00', '16:00:00', 12),
(12, 'Jueves', '14:00:00', '16:00:00', 12);

-- Vinculación de tutores a los Dictados (considerando que el tutor con id_usuario 4 está disponible)
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(11, 11, 4), -- Este tutor está disponible y no tiene conflictos de horario.
(12, 12, 4); -- Este tutor está disponible y no tiene conflictos de horario.

-- Insertando dictados para Noviembre
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(13, '2023-11-01', '2023-11-30', 'http://enlaceMatematicaAutodirigidoNov.com', 2, 1, 20), -- Autodirigido, Curso 2
(14, '2023-11-01', '2023-11-30', 'http://enlaceMatematicaInteractivoNov.com', 2, 2, 12); -- Interactivo, Curso 2

-- Horarios para el dictado interactivo de Noviembre
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(13, 'Martes', '14:00:00', '16:00:00', 14),
(14, 'Jueves', '14:00:00', '16:00:00', 14);

-- Vinculación de tutores a los dictados
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(13, 13, 4),
(14, 14, 4);

-- Insertando dictados para Diciembre
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(15, '2023-12-01', '2023-12-31', 'http://enlaceMatematicaAutodirigidoDic.com', 2, 1, 20), -- Autodirigido, Curso 2
(16, '2023-12-01', '2023-12-31', 'http://enlaceMatematicaInteractivoDic.com', 2, 2, 12); -- Interactivo, Curso 2

-- Horarios para el dictado interactivo de Diciembre
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(15, 'Martes', '14:00:00', '16:00:00', 16),
(16, 'Jueves', '14:00:00', '16:00:00', 16);

-- Vinculación de tutores a los dictados
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(15, 15, 4),
(16, 16, 4);


-- Insertando dictados para Enero
INSERT INTO [dbo].[Dictado] (id, fecha_inicio, fecha_fin, enlace, id_curso, id_tipo_dictado, cupo)
VALUES 
(17, '2024-01-01', '2024-01-31', 'http://enlaceMatematicaAutodirigidoEne.com', 2, 1, 20), -- Autodirigido, Curso 2
(18, '2024-01-01', '2024-01-31', 'http://enlaceMatematicaInteractivoEne.com', 2, 2, 12); -- Interactivo, Curso 2

-- Horarios para el dictado interactivo de Enero
INSERT INTO [dbo].[Horario] (id, dia, hora_inicio, hora_fin, id_dictado)
VALUES 
(17, 'Martes', '14:00:00', '16:00:00', 18),
(18, 'Jueves', '14:00:00', '16:00:00', 18);

-- Vinculación de tutores a los dictados
INSERT INTO [dbo].[Usuario_Dictado] (id, id_dictado, id_usuario)
VALUES 
(17, 17, 4),
(18, 18, 4);

INSERT INTO Inscripcion_Curso(id, id_curso, id_dictado, id_estudiante, fecha)
VALUES
(1,1,2,1, '2023-09-05');



