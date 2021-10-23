------ Procedimientos almacenados relacionados con los usuarios del sistema--------

-- Procedimiento almacenado para el Login de cada usuario
CREATE PROCEDURE p_LoginUsuario
  @nombre_usuario VARCHAR(100),
  @password VARCHAR(100)
AS 
BEGIN
Select usuarios.codigo as 'Código', tipo_usuarios.tipo_usuario as 'Tipo Usuario', usuarios.nombre_usuario as 'Nombre Usuario', 
usuarios.nombre as 'Nombre', usuarios.passwd as 'Contraseña', usuarios.email as'Email', 
CASE WHEN usuarios.estado = 1 Then 'Activo' ELSE 'Inactivo' END AS Estado
FROM usuarios join tipo_usuarios on usuarios.codigo_tipo_usuario = tipo_usuarios.codigo 
WHERE usuarios.nombre_usuario = @nombre_usuario and usuarios.passwd = @password and usuarios.estado = 1;
END
GO

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

------- Procedimientos alamcenados relacionados con los clientes del sistema

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

-- IF (SELECT COUNT(*) telefonos FROM TELEFONOS) > 0
--    select * from clientes

select codigo, dirrecion from dirreciones