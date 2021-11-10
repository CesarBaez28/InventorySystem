------ Triggers relacionados con los materiales---------

--Insertar en la tabla excedentes 
--Verifica si existe la cantidad disponible de materiales y actualiza la existencia en la tabla materiales
CREATE TRIGGER t_InsertarExecenteMaterial
ON excedentes_materiales FOR INSERT 
AS
  DECLARE @existencia INT --Declaro esta variable para obtener la cantidad de materiales disponibles
  SELECT @existencia = existencia FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo 
  WHERE materiales.codigo = inserted.codigo_material

  IF(@existencia >= (SELECT cantidad FROM excedentes_materiales)) --Verifico si hay la cantidad suficiente
    UPDATE materiales SET existencia = existencia - inserted.cantidad 
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

  IF(@existencia >= (SELECT cantidad FROM excedentes_materiales)) --Verifico si hay la cantidad suficiente
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

SELECT * FROM unidades_medidas
SELECT * FROM tipo_material
SELECT * FROM excedentes_materiales
SELECT* FROM materiales


Select codigo_material FROM excedentes_materiales WHERE excedentes_materiales.codigo = 3