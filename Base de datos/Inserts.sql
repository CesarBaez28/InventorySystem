-- Numero de telefono
INSERT INTO telefonos(telefono) VALUES('8498679962');

--Dirrecion
Insert INTO dirreciones(dirrecion, descripcion) Values('Jánico', 'Federico Pichardo #90');

--Tipo de usuarios
Insert INTO tipo_usuarios(tipo_usuario) VALUES('Administrador');
Insert INTO tipo_usuarios(tipo_usuario) VALUES('Empleado');

-- Usuarios
INSERT INTO usuarios(codigo_tipo_usuario, nombre_usuario, nombre, passwd, email) 
VALUES(1, 'Nini', 'Julio Cesar Báez', 'jcb123456', 'juceba71@gmail.com');

INSERT INTO usuarios(codigo_tipo_usuario, nombre_usuario, nombre, passwd, email) 
VALUES(2, 'Andy', 'Andy', '123456', 'Andy@gmail.com');