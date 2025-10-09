CREATE DATABASE supermercado_db;
USE supermercado_db;

CREATE TABLE productos(
	id int auto_increment primary key,
    nombre varchar(50) not null,
    precio int not null,
    unidad_medida varchar(20) not null
);

CREATE TABLE bodegas(
	id int auto_increment primary key,
    nombre varchar(50) not null
);

CREATE TABLE producto_bodega(
	id_producto int not null,
    id_bodega int not null,
    cantidad int not null,
    primary key (id_producto,id_bodega),
    foreign key  (id_producto) references productos(id),
    foreign key (id_bodega) references bodegas(id)
);

CREATE TABLE venta(
	id int auto_increment primary key,
    fecha date not null,
    hora time not null,
    caja int not null
);s

CREATE TABLE venta_producto(
	id int auto_increment primary key,
    id_venta int not null,
    id_producto int not null,
    precio_unitario int not null,
    cantidad int not null,
    foreign key (id_venta) references venta(id),
    foreign key (id_producto) references productos(id)
);

create user 'webapp'@'%' identified by 'pass123';
grant all on supermercado_db.* to 'webapp'@'%';

