---- Consultas relacionadas con los servicios-----

--Mostrar todos los servicios
SELECT codigo as'C�digo', nombre_servicio as 'Nombre', descripcion as 'Descripci�n', precio as 'Precio',
CASE WHEN estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado FROM servicios

