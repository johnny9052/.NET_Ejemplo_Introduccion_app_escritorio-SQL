CREATE TABLE [dbo].[estudiante](
	[codigo] [nvarchar](20) primary key,
	[nombre] [nvarchar](20) NULL,
	[apellido] [nvarchar](20) NULL,
	[edad] [int] NULL,
	[carrera] [nvarchar](20) NULL,
	[semestre] [nvarchar](20) NULL
);


go

CREATE PROCEDURE [dbo].[guardarEstudiante]
@codigo nvarchar(20),
@nombre nvarchar(30),
@apellido nvarchar(30),
@edad integer,
@carrera varchar(20),
@semestre integer

as

begin
	insert into estudiante values(@codigo,@nombre,@apellido,@edad,@carrera,@semestre);
end

go

exec guardarEstudiante '4348237','juan','sepulveda',24,'mecatronica',4;
 
 
go


CREATE PROCEDURE [dbo].[modificarEstudiante]
@codigo nvarchar(20),
@nombre nvarchar(30),
@apellido nvarchar(30),
@edad integer,
@carrera varchar(20),
@semestre integer

as

begin
	update estudiante set nombre= @nombre, apellido = @apellido, edad= @edad,
	carrera = @carrera, semestre= @semestre where codigo = @codigo;
end

go

exec modificarEstudiante '4348237','juan','sepulveda',24,'mecatronica',4;


go

CREATE PROCEDURE [dbo].[eliminarEstudiante]
@codigo nvarchar(20)

as

begin
	delete from estudiante where codigo = @codigo;
end

go

exec eliminarEstudiante '4348237';


go 

CREATE PROCEDURE [dbo].[buscarEstudiante]
@codigo nvarchar(20)

as

begin
	select codigo,nombre,apellido, edad, carrera, semestre
	from estudiante 
	where codigo = @codigo;
end

go

exec buscarEstudiante '4348237';

