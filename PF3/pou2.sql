create database pou

use pou

create table usuarios ( 
	ID int not null primary key identity (1,1) ,
    usuario varchar(50) not null,
    Contraseña varchar(50) not null,
    Nombre varchar(50) not null,
    ap_paterno varchar(50),
    ap_materno varchar(50),
    Correo varchar(50) not null,
	Tipo_usuario varchar(50) not null,
);

INSERT INTO usuarios 
VALUES 
('AntSam', '12345','Diego','Gonzales','Peralta','diego@gmail.com','Administrador'),
('Pepe', 'qwerty','Jose','Perez','NULL','pepe@gmail.com','Usuario');

select * from usuarios

create table multa (
Remision int not null primary key identity(10000,1),
Placa varchar(50) not null,
Modelo varchar(50) not null,
Marca varchar(50) not null,
Color varchar(50) not null,
Fecha varchar(50) not null,
Lugar varchar(50) not null,
Descripcion varchar(50) not null,
Total int not null,
);

select * from multa

INSERT INTO multa 
VALUES 
('5487FGH','Honda Civic','Honda','Azul','15/02/2023','Hotel Sol','Exceso de velocidad', 100),
('8894SWE','Generics','Tesla','Blanco','10/08/2023','Plaza Rios','Estacionaren lugar prohibido', 200);