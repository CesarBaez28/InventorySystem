------ Procedimientos almacenados relacionados con los usuarios del sistema--------

-- Procedimiento almacenado para el Login de cada usuario
CREATE PROCEDURE p_LoginUsuario
  @nombre_usuario VARCHAR(100),
  @password VARCHAR(100)
AS 
BEGIN
Select usuarios.codigo as 'Código', usuarios.codigo_tipo_usuario as 'Código Tipo Usuario', tipo_usuarios.tipo_usuario as 'Tipo Usuario', usuarios.nombre_usuario as 'Nombre Usuario', 
usuarios.nombre as 'Nombre', usuarios.passwd as 'Contraseña', usuarios.email as'Email', 
CASE WHEN usuarios.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
FROM usuarios join tipo_usuarios on usuarios.codigo_tipo_usuario = tipo_usuarios.codigo 
WHERE usuarios.nombre_usuario = @nombre_usuario and usuarios.passwd = @password and usuarios.estado = 1;
END
GO

EXEC p_LoginUsuario 'Nini', 'jcb123456'

select codigo, tipo_usuario from tipo_usuarios

--Procedimiento alamcenado para mostrarUsuarios
CREATE PROCEDURE p_MostrarUsuarios
AS
BEGIN
  Select usuarios.codigo as 'Código', tipo_usuarios.tipo_usuario as 'Tipo Usuario', usuarios.nombre_usuario as 'Nombre Usuario', 
  usuarios.nombre as 'Nombre', usuarios.passwd as 'Contraseña', usuarios.email as'Email', 
  CASE WHEN usuarios.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM usuarios join tipo_usuarios on usuarios.codigo_tipo_usuario = tipo_usuarios.codigo
END 
GO

Exec p_MostrarUsuarios

--Procedimiento almacenado para buscar usuarios por su codigo
CREATE PROCEDURE p_MostrarUsuariosCodigo
 @codigo INT
AS
BEGIN
 Select usuarios.codigo as 'Código', tipo_usuarios.tipo_usuario as 'Tipo Usuario', usuarios.nombre_usuario as 'Nombre Usuario', 
 usuarios.nombre as 'Nombre', usuarios.passwd as 'Contraseña', usuarios.email as'Email', 
 CASE WHEN usuarios.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
 FROM usuarios join tipo_usuarios on usuarios.codigo_tipo_usuario = tipo_usuarios.codigo 
 WHERE usuarios.codigo = @codigo;
END
GO

EXEC p_MostrarUsuariosCodigo 1

--Buscar usuario por nombre de usuario
CREATE PROCEDURE p_mostrarUsuariosNombre
 @nombreUsuario VARCHAR(50)
AS
BEGIN 
 Select usuarios.codigo as 'Código', tipo_usuarios.tipo_usuario as 'Tipo Usuario', usuarios.nombre_usuario as 'Nombre Usuario', 
 usuarios.nombre as 'Nombre', usuarios.passwd as 'Contraseña', usuarios.email as'Email', 
 CASE WHEN usuarios.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
 FROM usuarios join tipo_usuarios on usuarios.codigo_tipo_usuario = tipo_usuarios.codigo 
 WHERE usuarios.nombre_usuario LIKE '%'+@nombreUsuario + '%'
END 
GO

-- Buscar usuarios por estado (activos o inactivos)
CREATE PROCEDURE p_mostrarUsuarioEstado
 @estado BIT
AS
BEGIN
 Select usuarios.codigo as 'Código', tipo_usuarios.tipo_usuario as 'Tipo Usuario', usuarios.nombre_usuario as 'Nombre Usuario', 
 usuarios.nombre as 'Nombre', usuarios.passwd as 'Contraseña', usuarios.email as'Email', 
 CASE WHEN usuarios.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
 FROM usuarios join tipo_usuarios on usuarios.codigo_tipo_usuario = tipo_usuarios.codigo 
 WHERE usuarios.estado = @estado
END
GO

Exec p_mostrarUsuarioEstado 1

-- Procedimiento almacenado para insertar usuarios
CREATE PROCEDURE p_InsertarUsuario
    @codigo_tipoUsuario INT,
	@nombreUsuario VARCHAR(100),
	@nombre VARCHAR(100),
	@password VARCHAR(100),
	@email VARCHAR(100)
AS
BEGIN 
  INSERT INTO usuarios(codigo_tipo_usuario, nombre_usuario, nombre, passwd, email) 
  VALUES(@codigo_tipoUsuario, @nombreUsuario, @nombre, @password, @email);
END 
GO

-- Actualizar datos de los usuarios
CREATE PROCEDURE p_ActualizarUsuario
    @codigo_tipoUsuario INT,
	@nombreUsuario VARCHAR(100),
	@nombre VARCHAR(100),
	@password VARCHAR(100),
	@email VARCHAR(100),
	@estado BIT,
	@codigo INT
AS
BEGIN
  UPDATE usuarios SET codigo_tipo_usuario = @codigo_tipoUsuario, nombre_usuario = @nombreUsuario, nombre = @nombre, passwd = @password, 
  email = @email, estado = @estado WHERE codigo = @codigo
END
GO

--Eliminar usuario (Cambiar estado a inactivo)
CREATE PROCEDURE p_EliminarUsuario
  @codigoUsuario INT
AS
BEGIN
  UPDATE usuarios SET estado = 0 WHERE codigo = @codigoUsuario;
END
GO

---------- Procedimientos alamcenados relacionados con los clientes del sistema------------------

--Mostrar todos los clientes 
CREATE PROCEDURE p_MostrarClientes
AS
BEGIN
  Select clientes.codigo as 'Código', clientes.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', clientes.fecha_registro as 'Fecha Registro', 
  CASE WHEN clientes.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM clientes join telefonos on clientes.codigo_telefono = telefonos.codigo join dirreciones on clientes.codigo_dirrecion = dirreciones.codigo
END
GO

--Buscar cliente por codigo
CREATE PROCEDURE p_MostrarClienteCodigo
  @codigoCliente INT
AS
BEGIN  
  Select clientes.codigo as 'Código', clientes.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', clientes.fecha_registro as 'Fecha Registro', 
  CASE WHEN clientes.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM clientes join telefonos on clientes.codigo_telefono = telefonos.codigo join dirreciones on clientes.codigo_dirrecion = dirreciones.codigo
  WhERE clientes.codigo = @codigoCliente;
END 
GO

--Buscar cliente por nombre
CREATE PROCEDURE p_MostrarClienteNombre
  @nombreCliente VARCHAR(50)
AS
BEGIN 
  Select clientes.codigo as 'Código', clientes.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', clientes.fecha_registro as 'Fecha Registro', 
  CASE WHEN clientes.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM clientes join telefonos on clientes.codigo_telefono = telefonos.codigo join dirreciones on clientes.codigo_dirrecion = dirreciones.codigo
  WhERE clientes.nombre LIKE '%' + @nombreCliente +'%'
END 
GO

--Buscar clientes por estado (activos o inactivo)
CREATE PROCEDURE p_MostrarClienteEstado
  @estado BIT
AS 
BEGIN
  Select clientes.codigo as 'Código', clientes.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', clientes.fecha_registro as 'Fecha Registro', 
  CASE WHEN clientes.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM clientes join telefonos on clientes.codigo_telefono = telefonos.codigo join dirreciones on clientes.codigo_dirrecion = dirreciones.codigo
  WhERE clientes.estado = @estado
END
GO

--Insertar Cliente 
CREATE PROCEDURE p_InsertarCliente
  @telefono VARCHAR(50),
  @codigoDirrecion INT,
  @nombreCliente VARCHAR(50)
AS
BEGIN
  --Insertar el telefono suministrado en la tabla telefonos
  INSERT INTO telefonos(telefono) Values(@telefono)

  DECLARE @codigoTelefono INT

  --Guardo en el codigo del nuevo telefono registrado
  SELECT @codigoTelefono = telefonos.codigo from telefonos where telefonos.telefono = @telefono;

  INSERT INTO clientes(codigo_telefono, codigo_dirrecion, nombre) VALUES(@codigoTelefono, @codigoDirrecion, @nombreCliente);
END
GO

--Actualizar datos del cliente
CREATE PROCEDURE p_ActualizarCliente
  @telefono VARCHAR(25),
  @telefonoViejo VARCHAR(25),
  @codigoDireccion INT,
  @nombreCliente VARCHAR(100),
  @codigoCliente INT, 
  @estado BIT
AS
BEGIN
  DECLARE @codigoTelefono INT
  --Obtengo el codigo del telefono
  SELECT @codigoTelefono = telefonos.codigo from telefonos where telefonos.telefono = @telefonoViejo;
  --Actualizo el tefono
  UPDATE telefonos SET telefono = @telefono WHERE telefonos.codigo = @codigoTelefono;
  --Actualizo los datos del cliente
  UPDATE clientes SET nombre = @nombreCliente, codigo_dirrecion = @codigoDireccion, estado = @estado where codigo = @codigoCliente
END
GO

--Eliminar cliente (Cambiarle el estado a inactivo)
CREATE PROCEDURE p_EliminarCliente
  @codigoCliente INT
AS
BEGIN
  UPDATE clientes SET estado = 0 WHERE codigo = @codigoCliente
END
GO


-- IF (SELECT CUNT(*) telefonos FROM TELEFONOS) > 0
--    select * from clientes


----- Procedimientos alamacenados relacionados a los proveedores -----------

--Mostrar todos los proveedores
CREATE PROCEDURE p_MostrarProveedores
AS
BEGIN 
  Select proveedores.codigo as 'Código', proveedores.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', 
  CASE WHEN proveedores.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM proveedores join telefonos on proveedores.codigo_telefono = telefonos.codigo join dirreciones on proveedores.codigo_dirrecion = dirreciones.codigo
END
GO

--Buscar proveedores por codigo
CREATE PROCEDURE p_BuscarProveedorCodigo
  @codigo INT
AS
BEGIN
  Select proveedores.codigo as 'Código', proveedores.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', 
  CASE WHEN proveedores.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM proveedores join telefonos on proveedores.codigo_telefono = telefonos.codigo join dirreciones on proveedores.codigo_dirrecion = dirreciones.codigo
  WHERE proveedores.codigo = @codigo
END 
GO

--Buscar proveedores por nombre
CREATE PROCEDURE p_BuscarProveedorNombre
  @nombre VARCHAR(100)
AS
BEGIN 
  Select proveedores.codigo as 'Código', proveedores.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', 
  CASE WHEN proveedores.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM proveedores join telefonos on proveedores.codigo_telefono = telefonos.codigo join dirreciones on proveedores.codigo_dirrecion = dirreciones.codigo
  WHERE proveedores.nombre LIKE '%' +  @nombre + '%'
END
 GO

 --Buscar proveedores por Estado (activo o inactivo)
 CREATE PROCEDURE p_BuscarProveedorEstado
   @estado BIT
 AS
 BEGIN
   Select proveedores.codigo as 'Código', proveedores.nombre as 'Nombre', telefonos.telefono as 'Teléfono', dirreciones.dirrecion as 'Dirección', 
  CASE WHEN proveedores.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
  FROM proveedores join telefonos on proveedores.codigo_telefono = telefonos.codigo join dirreciones on proveedores.codigo_dirrecion = dirreciones.codigo
  WHERE proveedores.estado = @estado
 END
 GO

 --Insertar Proveedor
 CREATE PROCEDURE p_InsertarProveedor
  @telefono VARCHAR(50),
  @codigoDirrecion INT,
  @nombreProveedor VARCHAR(100)
 AS
 BEGIN 
  INSERT INTO telefonos(telefono) Values(@telefono)   --Insertar el telefono suministrado en la tabla telefonos

  DECLARE @codigoTelefono INT

  --Guardo en el codigo del nuevo telefono registrado
  SELECT @codigoTelefono = telefonos.codigo from telefonos where telefonos.telefono = @telefono;

  INSERT INTO proveedores(codigo_dirrecion, codigo_telefono, nombre) VALUES(@codigoDirrecion, @codigoTelefono, @nombreProveedor);
 END
 GO

 --Actualizar datos del proveedor
CREATE PROCEDURE p_ActualizarProveedor
  @telefono VARCHAR(25),
  @telefonoViejo VARCHAR(25),
  @codigoDireccion INT,
  @nombreProveedor VARCHAR(100),
  @codigoProveedor INT, 
  @estado BIT
AS
BEGIN
   DECLARE @codigoTelefono INT
  --Obtengo el codigo del telefono
  SELECT @codigoTelefono = telefonos.codigo from telefonos where telefonos.telefono = @telefonoViejo;
  --Actualizo el tefono
  UPDATE telefonos SET telefono = @telefono WHERE telefonos.codigo = @codigoTelefono;
  --Actualizo los datos del cliente
  UPDATE proveedores SET nombre = @nombreProveedor, codigo_dirrecion = @codigoDireccion, estado = @estado where codigo = @codigoProveedor
END
GO

--Eliminar proveedor (Cambia estado a Inactivo)
CREATE PROCEDURE p_EliminarProveedor
  @codigoProveedor INT
AS
BEGIN
  UPDATE proveedores SET estado = 0 WHERE codigo = @codigoProveedor
END
GO

-------- Procedimientos almacenados relacionados con los materiales---------------

--Insertar tipo de material
CREATE PROCEDURE p_InsertarTipoMaterial
  @nombre VARCHAR(75)
AS
BEGIN
  INSERT INTO tipo_material(tipo_material) VALUES (@nombre)
END
GO

--Actualizar tipo de material
CREATE PROCEDURE p_ActualizarTipoMaterial
  @nombre VARCHAR(75),
  @tipoMaterialNuevo VARCHAR(75)
AS
BEGIN
  DECLARE @codigoTipoMaterial INT --Declaro una variable para obtener el codigo del tipo de material

  SELECT @codigoTipoMaterial = tipo_material.codigo FROM tipo_material WHERE tipo_material.tipo_material = @nombre -- Obtengo el codigo

  UPDATE tipo_material SET tipo_material = @tipoMaterialNuevo WHERE tipo_material.codigo = @codigoTipoMaterial;
END
GO

--Mostrar todos los materiales del sistema
CREATE PROCEDURE p_MostrarMateriales
AS
BEGIN
  SELECT materiales.codigo as 'Código', tipo_material.tipo_material as 'Tipo material', materiales.nombre as 'Nombre', materiales.descripcion as 'Descripción', materiales.costo as 'Costo', materiales.existencia as 'Existencia', 
  CASE WHEN materiales.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
  FROM materiales JOIN tipo_material ON materiales.codigo_tipo_material = tipo_material.codigo
END
GO

--Buscar materiales por codigo
CREATE PROCEDURE p_BuscarMaterialesCodigo
  @codigo INT
AS
BEGIN
  SELECT materiales.codigo as 'Código', tipo_material.tipo_material as 'Tipo material', materiales.nombre as 'Nombre', materiales.descripcion as 'Descripción', materiales.costo as 'Costo', materiales.existencia as 'Existencia', 
  CASE WHEN materiales.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
  FROM materiales JOIN tipo_material ON materiales.codigo_tipo_material = tipo_material.codigo WHERE materiales.codigo = @codigo;
END
GO

--Buscar materiales por nombre
CREATE PROCEDURE p_BuscarMaterialesNombre
  @nombre VARCHAR(75)
AS
BEGIN
  SELECT materiales.codigo as 'Código', tipo_material.tipo_material as 'Tipo material', materiales.nombre as 'Nombre', materiales.descripcion as 'Descripción', materiales.costo as 'Costo', materiales.existencia as 'Existencia', 
  CASE WHEN materiales.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
  FROM materiales JOIN tipo_material ON materiales.codigo_tipo_material = tipo_material.codigo WHERE materiales.nombre LIKE '%'+ @nombre +'%'
END
GO

--Buscar materiales por estado
CREATE PROCEDURE p_BuscarMaterialesEstado
  @estado BIT
AS
BEGIN
  SELECT materiales.codigo as 'Código', tipo_material.tipo_material as 'Tipo material', materiales.nombre as 'Nombre', materiales.descripcion as 'Descripción', materiales.costo as 'Costo', materiales.existencia as 'Existencia', 
  CASE WHEN materiales.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado
  FROM materiales JOIN tipo_material ON materiales.codigo_tipo_material = tipo_material.codigo WHERE materiales.estado = @estado
END
GO

--Insertar nuevo material
CREATE PROCEDURE p_InsertarMaterial
  @codigo_tipoMaterial INT,
  @nombre VARCHAR(75),
  @descripcion TEXT,
  @costo NUMERIC(20,2),
  @existencia INT
AS
BEGIN
  INSERT INTO materiales(codigo_tipo_material, nombre, descripcion, costo, existencia) 
  VALUES(@codigo_tipoMaterial, @nombre, @descripcion, @costo, @existencia)
END
GO

--Actualizar material
CREATE PROCEDURE p_ActualizarMaterial
  @codigoMaterial INT,
  @codigo_TipoMaterial INT,
  @nombre VARCHAR(75),
  @descripcion TEXT,
  @costo NUMERIC(20,2),
  @existencia INT,
  @estado BIT 
AS
BEGIN
  UPDATE materiales SET codigo_tipo_material = @codigo_TipoMaterial, nombre = @nombre, costo = @costo, existencia = @existencia, 
  descripcion = @descripcion , estado = @estado WHERE codigo = @codigoMaterial
END
GO

--Eliminar materia (cambiar estado a inactivo)
CREATE PROCEDURE p_EliminarMaterial
  @codigo INT
AS
BEGIN
  UPDATE materiales SET estado = 0  WHERE codigo = @codigo
END
GO

--Mostrar materiales excedentes
CREATE PROCEDURE P_MostrarMaterialesExcedentes
AS
BEGIN
  SELECT excedentes_materiales.codigo as 'Código', tipo_material.tipo_material as 'Tipo material', materiales.nombre as 'Material', 
  excedentes_materiales.descripcion as 'Descripción', unidades_medidas.unidad_medida as 'Unidad medida',
  excedentes_materiales.largo as 'Largo', excedentes_materiales.ancho as 'Ancho', excedentes_materiales.alto as 'Alto', 
  excedentes_materiales.cantidad as 'Cantidad'
  FROM excedentes_materiales JOIN tipo_material ON excedentes_materiales.codigo_tipo_material = tipo_material.codigo 
  JOIN materiales ON excedentes_materiales.codigo_material = materiales.codigo 
  JOIN unidades_medidas ON excedentes_materiales.codigo_unidad_medida = unidades_medidas.codigo
END 
GO

--Registrar excedente de material
CREATE PROCEDURE p_InsertarExcedenteMaterial
  @tipoMaterial VARCHAR(30),
  @codigoMaterial INT,
  @codigoMedida INT,
  @largo VARCHAR(50),
  @ancho VARCHAR(50),
  @alto Varchar(50),
  @cantidad INT,
  @descripcion TEXT
AS
BEGIN
  DECLARE @codigo_tipoMaterial INT --La uso para guardar el codigo del tipo de material
  SELECT @codigo_tipoMaterial = tipo_material.codigo FROM tipo_material WHERE tipo_material = @tipoMaterial -- guardo el codigo en la variable

  INSERT INTO excedentes_materiales(codigo_tipo_material, codigo_material, codigo_unidad_medida, largo, ancho, alto, cantidad, descripcion)
  VALUES(@codigo_tipoMaterial, @codigoMaterial, @codigoMedida, @largo, @ancho, @alto, @cantidad, @descripcion)
END
GO

--Actualizar excedente material
CREATE PROCEDURE p_ActualizarExcedenteMaterial
  @codigo_excedente INT,
  @codigoMedida INT,
  @largo VARCHAR(50),
  @ancho VARCHAR(50),
  @alto Varchar(50),
  @cantidad INT,
  @descripcion TEXT
AS
BEGIN
  UPDATE excedentes_materiales SET codigo_unidad_medida = @codigoMedida,  largo = @largo, ancho = @ancho, alto = @alto, 
  cantidad = @cantidad, descripcion = @descripcion WHERE codigo = @codigo_excedente
END
GO

--Eliminar material excedente
CREATE PROCEDURE p_EliminarExcedenteMaterial
  @codigoExcedente INT
AS
BEGIN 
  DELETE FROM excedentes_materiales WHERE codigo = @codigoExcedente
END 
GO


-----Procedimientos almacenados relacionados con los servicios----------

--Insertar servicio
CREATE PROCEDURE p_InsertarServicio 
  @nombre_servicio VARCHAR(100),
  @descripcion TEXT,
  @precio NUMERIC(20,2),
  @estado bit 
AS
BEGIN
  INSERT INTO servicios(nombre_servicio, descripcion, precio, estado) 
  VALUES(@nombre_servicio, @descripcion, @precio, @estado)
END
GO

--Insertar Material que incluye el servicio (tabla servicios_materiales)
CREATE PROCEDURE p_InsertarServiciosMateriales
  @codigoMaterial INT,
  @cantidad INT
AS
BEGIN
  DECLARE @codigoServicio INT --La declaro para obtener el codigo del ultimo servicio insertado
  SELECT @codigoServicio = MAX(codigo) FROM servicios -- Guardo el codigo

  INSERT INTO servicios_materiales(codigo_material, codigo_servicio, cantidad)
  VALUES(@codigoMaterial, @codigoServicio, @cantidad)
END
GO

--Mostrar los materiales que incluye un servicio
CREATE PROCEDURE p_MostrarMaterialesServicios
  @codigoServicio INT
AS
BEGIN 
  SELECT materiales.codigo as 'Código', materiales.nombre as 'Material', servicios_materiales.cantidad as 'Cantidad' FROM materiales
  JOIN servicios_materiales ON servicios_materiales.codigo_material = materiales.codigo
  WHERE servicios_materiales.codigo_servicio = @codigoServicio
END
GO

SELECT * FROM servicios
SELECT * FROM servicios_materiales

------ Procedimientos alamacenados relacionados con la tabla de direcciones--------

--Insertar  nueva Direccion
CREATE PROCEDURE p_InsertarDireccion 
  @direccion VARCHAR(100)
AS
BEGIN 
  INSERT INTO dirreciones(dirrecion) VALUES (@direccion)
END 
GO

--Actualizar direccion 
CREATE PROCEDURE p_ActualizarDireccion
  @direccion VARCHAR(100),
  @direccionActualizar VARCHAR(100)
AS
BEGIN 
  UPDATE dirreciones SET dirrecion = @direccion WHERE dirrecion = @direccionActualizar
END
GO

SELECT nombre as 'Material', codigo FROM materiales