------ Triggers relacionados con los materiales---------
CREATE TRIGGER t_InsertarExecenteMaterial
ON excedentes_materiales FOR INSERT 
AS
  DECLARE @existencia INT --Declaro esta variable para obtener la cantidad de materiales disponibles
  SELECT @existencia = existencia FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo 
  WHERE materiales.codigo = inserted.codigo_material

  IF(@existencia >= (SELECT cantidad FROM excedentes_materiales)) --Verifico si hay la cantidad
    UPDATE materiales SET existencia = existencia - inserted.cantidad 
	FROM materiales JOIN inserted ON inserted.codigo_material = materiales.codigo WHERE materiales.codigo = inserted.codigo_material
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
