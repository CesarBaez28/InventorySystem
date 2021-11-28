---- Consultas relacionadas con los servicios-----

--Mostrar todos los servicios
SELECT codigo as'C�digo', nombre_servicio as 'Nombre', descripcion as 'Descripci�n', precio as 'Precio',
CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado FROM servicios

--Mostrar nombre y codigo de materiales
SELECT nombre as 'Material', codigo FROM materiales

-- Mostrar codigo y nombre de proveedores
SELECT codigo, nombre FROM proveedores

--Mostrar nombre y c�digo de los servicio 
SELECT codigo, nombre_servicio FROM servicios

--Mostrar nombre y c�digo de los clientes 
Select codigo, nombre FROM clientes

SELECT * FROM servicios
SELECT * FROM materiales