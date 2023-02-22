create database proyect
use proyect
go

create table usuario(
id_usuario int not null identity(1,1) primary key,
/*se le crea un id al usuario para que no exista un dato repetido, se utliza la funcion
--de auto-incremento para asi tener un mejor orden.*/
nombres varchar(100),
/*Se crea un campo llamado nombre para que se almacene el nombre del usuario y se le otorga
una medida de 100 caracteres porque son 1 o 2 nombres y posiblemente 3*/
apellidos varchar(100),
/*Al igual que el nombre, usamos una medidad de 100 caracteres por que se almacenan los 2 apellidos*/
fecha_nacimiento datetime,
/*En este caso para la fecha de nacimiento del usuario usamos un tipo de dato "datetime" que nos
aplica un formato de fecha establecido*/
dni varchar(8)
/*Aqui se crea un tipo de dato varchar para almacenar el numero de DNI del usuario, se le da la medida
de 8 caracteres porque esa es la cantidad de digitos que aparecen en el DNI*/

/*imagen varchar(50),
/**/
usuario_crea varchar(100),
/**/
fecha_crea datetime,
/**/
usuario_edita varchar(100),
/**/
fecha_edita datetime*/
);
go

--Procedimiento Listar
/*Se crea el procedimiento para que aparezca la lista de usuarios*/
create proc usuario_listar
as
select id_usuario as ID,nombres as Nombres,apellidos as Apellidos,fecha_nacimiento as Fecha_Nacimiento,
dni as DNI/*, imagen as Imagen, usuario_crea as Usuario_crea, fecha_crea as Fecha_crea, usuario_edita as Usuario_edita,
fecha_edita as Fecha_edita*/
from usuario
order by id_usuario desc /*Esta ordenado de manera descendente*/
go

--Procedimiento insertar
/*Se crea el procedimiento para insertar los datos del usuario*/
create proc usuario_insertar
@nombres varchar(100),
@apellidos varchar(100),
@dni varchar(8),
@fecha_nacimiento datetime
--@imagen varchar(50)
as
insert into usuario(nombres,apellidos,dni,fecha_nacimiento/*,imagen*/) values (@nombres,@apellidos,@dni,@fecha_nacimiento/*,@imagen*/)
go

--Procedimiento Actualizar
/*Se crea el procedimiento para actualizar los datos del usuario*/
create proc usuario_actualizar
@id_usuario int,
@nombres varchar(100),
@apellidos varchar(100),
@dni varchar(8),
@fecha_nacimiento datetime
--@imagen varchar(50)
as
update usuario set nombres=@nombres,apellidos=@apellidos,dni=@dni,fecha_nacimiento=@fecha_nacimiento/*,
imagen=@imagen*/
where id_usuario=@id_usuario
go


--Procedimiento Eliminar
/*Se crea el procedimiento para eliminar los datos del usuario*/
create proc usuario_eliminar
@id_usuario int
as
delete from usuario
where id_usuario=@id_usuario
go





