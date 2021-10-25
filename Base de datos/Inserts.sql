-- Numero de telefono
INSERT INTO telefonos(telefono) VALUES('8498679962');
INSERT INTO telefonos(telefono) VALUES('8290937654');
INSERT INTO telefonos(telefono) VALUES('8091236742');
INSERT INTO telefonos(telefono) VALUES('8095746598');
INSERT INTO telefonos(telefono) VALUES('8094537654');




--Dirrecion
Insert INTO dirreciones(dirrecion, descripcion) Values('Jánico', 'Federico Pichardo #90');
Insert INTO dirreciones(dirrecion) Values('Don juan');

--Tipo de usuarios
Insert INTO tipo_usuarios(tipo_usuario) VALUES('Administrador');
Insert INTO tipo_usuarios(tipo_usuario) VALUES('Empleado');

-- Usuarios
INSERT INTO usuarios(codigo_tipo_usuario, nombre_usuario, nombre, passwd, email) 
VALUES(1, 'Nini', 'Julio Cesar Báez', 'jcb123456', 'juceba71@gmail.com');

INSERT INTO usuarios(codigo_tipo_usuario, nombre_usuario, nombre, passwd, email) 
VALUES(2, 'Andy', 'Andy', '123456', 'Andy@gmail.com');

INSERT INTO clientes(codigo_telefono, codigo_dirrecion, nombre) VALUES(1,1,'Hilario Fernandez');
INSERT INTO clientes(codigo_telefono, codigo_dirrecion, nombre) VALUES(2,2,'Samuel');

--Proveedores
INSERT INTO proveedores(codigo_dirrecion, codigo_telefono, nombre) VALUES (1, 5, 'Ferreteria Lolo') 
INSERT INTO proveedores(codigo_dirrecion, codigo_telefono, nombre) VALUES (1, 6, 'Colmado Espinal') 
INSERT INTO proveedores(codigo_dirrecion, codigo_telefono, nombre) VALUES (1, 7, 'Colmado Duran') 


select * from telefonos
