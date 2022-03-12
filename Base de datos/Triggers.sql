------ Triggers relacionados con los materiales---------

--Este trigger fue eliminado
--Insertar en la tabla excedentes 
--Verifica si existe la cantidad disponible de materiales y actualiza la existencia en la tabla materiales
CREATE TRIGGER t_InsertarExcedenteMaterial
ON excedentes_materiales FOR INSERT 
AS
  DECLARE @existencia INT --Declaro esta variable para obtener la cantidad de materiales disponibles
  SELECT @existencia = existencia FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo 
  WHERE materiales.codigo = inserted.codigo_material

  IF(@existencia >= (SELECT cantidad FROM inserted)) --Verifico si hay la cantidad suficiente
    --Le resto uno a la existencial del material
    UPDATE materiales SET existencia = existencia - 1 
	FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo WHERE materiales.codigo = inserted.codigo_material
  ELSE
  BEGIN 
    RAISERROR ('No hay materiales suficientes',16,1)
	ROLLBACK TRANSACTION 
END
GO

-- Este trigger fue eliminado
--actualizar en la tabla excedentes 
--Verifica si existe la cantidad disponible de materiales y actualiza la existencia en la tabla materiales
CREATE TRIGGER t_ActualizarExcedenteMaterial
ON excedentes_materiales FOR UPDATE
AS
  DECLARE @codigoMaterial INT --Declaro la variable para obtener el codigo del material
  
  --Guardo el codigo del material en la variable
  SELECT @codigoMaterial = excedentes_materiales.codigo_material FROM excedentes_materiales JOIN inserted 
  ON inserted.codigo = excedentes_materiales.codigo
  WHERE excedentes_materiales.codigo = inserted.codigo

  DECLARE @existencia INT -- Declaro esta variable para obtener la cantidad de materiales disponibles
  SELECT @existencia = existencia FROM materiales WHERE codigo = @codigoMaterial

  IF(@existencia >= (SELECT cantidad FROM inserted)) --Verifico si hay la cantidad suficiente
  BEGIN
    IF((SELECT cantidad FROM deleted) < (SELECT cantidad FROM inserted)) --Verifico si la nueva cantidad es mayor que la anterior
    BEGIN
	  --Actualizo la cantidad de materiales disponibles
	  UPDATE materiales SET existencia = existencia - (inserted.cantidad - (SELECT cantidad FROM deleted)) 
	  FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo WHERE materiales.codigo = inserted.codigo_material
    END
	ELSE
	BEGIN  
      --Actualizo la cantidad de materiales disponibles
	  UPDATE materiales SET existencia = existencia + ((SELECT cantidad FROM deleted) - (SELECT cantidad FROM inserted))
	  FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo WHERE materiales.codigo = inserted.codigo_material
	END
  END
  ELSE
  BEGIN 
    RAISERROR ('No hay materiales suficientes',16,1)
	ROLLBACK TRANSACTION 
END
GO

--Este trigger fue eliminado
--Eliminar en la tabla excedente 
-- Actualiza la existencia en la tabla de materiales
CREATE TRIGGER t_EliminarExcedenteMaterial
ON excedentes_materiales FOR DELETE 
AS
BEGIN
  DECLARE @codigoMaterial INT --Declaro la variable para obtener el codigo del material
  
  --Guardo el codigo del material en la variable
  SELECT @codigoMaterial = excedentes_materiales.codigo_material FROM excedentes_materiales JOIN deleted 
  ON deleted.codigo = excedentes_materiales.codigo
  WHERE excedentes_materiales.codigo = deleted.codigo

  --Le sumo uno a la exitencia del material
  UPDATE materiales SET existencia = existencia + 1
  FROM materiales JOIN deleted ON deleted.codigo_material = materiales.codigo WHERE materiales.codigo = deleted.codigo_material
END
GO

------ triggers relacionados con entradas al inventario-----------------
CREATE TRIGGER t_RegistrarEntrada
ON detalle_entrada FOR INSERT
AS
BEGIN
  --Actualizo el total de la entrada
  UPDATE entradas SET total_entrada = total_entrada + ((SELECT costo FROM inserted) * (SELECT cantidad FROM inserted))
  FROM entradas JOIN detalle_entrada ON (SELECT codigo_entrada FROM inserted) = entradas.codigo
  WHERE entradas.codigo = (SELECT codigo_entrada FROM inserted)

  --Actualizo la existencia en el inventario
  UPDATE materiales SET existencia = existencia + (SELECT cantidad FROM inserted) FROM
  materiales JOIN inserted ON (SELECT codigo_material FROM inserted) = materiales.codigo WHERE
  materiales.codigo = (SELECT codigo_material FROM inserted)
END
GO

----- Triggers relacionados con las salidas del inventario-------

--Insertar en la tabla detalles_salida
CREATE TRIGGER t_registrarSalida
ON detalles_salida FOR INSERT
AS
BEGIN 
  --Actualizo el total de la salida
  UPDATE salidas SET total_salida = total_salida + ((SELECT precio FROM inserted) * (SELECT cantidad FROM inserted))
  FROM salidas JOIN detalles_salida ON (SELECT codigo_salida FROM inserted) = salidas.codigo 
  WHERE salidas.codigo = (SELECT codigo_salida FROM inserted)

  -- Creo una tabla virtual de servicios_materiales para verificar si está disponible la cantidad suficiente de material para registrar el servicio
  DECLARE @servicios_materiales TABLE (codigo_mateterial INT, codigo_servicio INT, cantidad INT)

  --Inserto en la tabla virtual los detalles del servicio que se registró
  INSERT INTO @servicios_materiales(codigo_mateterial, codigo_servicio, cantidad) 
  SELECT codigo_material, codigo_servicio, cantidad FROM servicios_materiales WHERE codigo_servicio = (SELECT codigo_servicio FROM inserted)

  --Declaro una variable @count para ir verificando si están disponibles cada uno de los materiales necesarios del servicio.
  DECLARE @count int  = (SELECT COUNT(*) FROM @servicios_materiales)

  WHILE @count > 0
  BEGIN
    --Declaro las variables cantidad y existencia para verificar si se cuentan con los materiales suficientes.
    DECLARE @cantidad INT = (SELECT TOP(1) cantidad FROM @servicios_materiales)
	DECLARE @existencia INT = (SELECT existencia FROM materiales WHERE materiales.codigo = (SELECT TOP(1) codigo_mateterial FROM @servicios_materiales))
	
	--Verifico si está disponible la cantidad de material y actualizo en la existencia en la tabla materiales. De lo contrario, envía un error.
	IF(@existencia >= @cantidad * (SELECT cantidad FROM inserted))
	  UPDATE materiales SET materiales.existencia  = materiales.existencia - (@cantidad * (SELECT cantidad FROM inserted))
	  FROM materiales WHERE materiales.codigo = (SELECT TOP(1) codigo_mateterial FROM @servicios_materiales)
	ELSE
    BEGIN 
      RAISERROR ('No hay materiales suficientes',16,1)
	END

	DELETE TOP(1) FROM @servicios_materiales 
	SET @count = (SELECT COUNT(*) FROM @servicios_materiales)
  END
END
GO

------- Triger relacionado con la tabla excedentes_materiales ---------

--Si la existencia de un excedente es igual cero, se elimina.
CREATE TRIGGER t_actualizarExcedente
ON excedentes_materiales FOR UPDATE
AS
BEGIN
  IF (SELECT cantidad FROM inserted) = 0
    BEGIN 
	  DELETE FROM excedentes_materiales WHERE codigo = (SELECT codigo from inserted)
	END
END
GO

------ Trigger relacionado con las tablas de cotizaciones------------

--Actualiza el total de la cotización
CREATE TRIGGER t_RegistrarCotizacion 
ON detallesCotizacion FOR INSERT
AS
BEGIN
  --Actualizo el total de la cotización 
  UPDATE cotizaciones SET total_cotizacion = total_cotizacion + ((SELECT precio FROM inserted) * (SELECT cantidad FROM inserted))
  FROM cotizaciones JOIN detallesCotizacion ON (SELECT codigo_cotizacion FROM inserted) = cotizaciones.codigo
  WHERE cotizaciones.codigo = (SELECT codigo_cotizacion FROM inserted)
END 
GO

--Actualiza el total de la cotización
CREATE TRIGGER t_EditarCotizacion 
ON detallesCotizacion FOR UPDATE
AS
BEGIN 
  IF((SELECT precio FROM deleted) <> (SELECT precio FROM inserted) OR (SELECT cantidad FROM deleted) <> (SELECT cantidad FROM inserted))
  BEGIN
    DECLARE @diferencia FLOAT = ((SELECT precio FROM deleted) * (SELECT cantidad FROM deleted) - (SELECT precio FROM inserted) * (SELECT cantidad FROM inserted)) * -1
	UPDATE cotizaciones SET total_cotizacion = total_cotizacion + @diferencia
  END
END 
GO
