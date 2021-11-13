---- Consultas relacionadas con los servicios-----

--Mostrar todos los servicios
SELECT codigo as'Código', nombre_servicio as 'Nombre', descripcion as 'Descripción', precio as 'Precio',
CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado FROM servicios

--Mostrar nombre y codigo de materiales
SELECT nombre as 'Material', codigo FROM materiales

-- Mostrar codigo y nombre de proveedores
SELECT codigo, nombre FROM proveedores