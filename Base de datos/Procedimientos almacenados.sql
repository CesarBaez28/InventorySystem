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
WHERE usuarios.nombre_usuario = @nombre_usuario and usuarios.passwd = @password
END
GO

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

