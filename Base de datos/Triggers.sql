------ Triggers relacionados con los materiales---------

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
  UPDATE entradas SET total_entrada = total_entrada + (SELECT costo FROM inserted)
  FROM entradas JOIN detalle_entrada ON (SELECT codigo_entrada FROM inserted) = entradas.codigo
  WHERE entradas.codigo = (SELECT codigo_entrada FROM inserted)

  --Actualizo la existencia en el inventario
  UPDATE materiales SET existencia = existencia + (SELECT cantidad FROM inserted) FROM
  materiales JOIN inserted ON (SELECT codigo_material FROM inserted) = materiales.codigo WHERE
  materiales.codigo = (SELECT codigo_material FROM inserted)
END
GO


SELECT * FROM unidades_medidas
SELECT * FROM tipo_material
SELECT * FROM excedentes_materiales
SELECT* FROM materiales


