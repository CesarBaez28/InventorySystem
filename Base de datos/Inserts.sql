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

--Materiales
INSERT INTO materiales(codigo_tipo_material, nombre, costo, existencia) VALUES (1, 'Barra 1/2', 100, 10)
INSERT INTO materiales(codigo_tipo_material, nombre, costo, existencia) VALUES (2, 'Perfil 2x2', 500, 10)
INSERT INTO materiales(codigo_tipo_material, nombre, costo, existencia) VALUES (3, 'planchuela 1/2', 150, 10)
INSERT INTO materiales(codigo_tipo_material, nombre, costo, existencia) VALUES (4, 'Angular 1/2', 200, 10)


--Unidades de medida 
INSERT INTO unidades_medidas(unidad_medida) VALUES('Pulgadas')
INSERT INTO unidades_medidas(unidad_medida) VALUES('Pies')
INSERT INTO unidades_medidas(unidad_medida) VALUES('Metros')
INSERT INTO unidades_medidas(unidad_medida) VALUES('Centímetros')

SELECT codigo, unidad_medida FROM unidades_medidas

SELECT * FROM tipo_material
SELECT * FROM materiales

