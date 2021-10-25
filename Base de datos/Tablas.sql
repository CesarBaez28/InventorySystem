--Crear la base de datos
--CREATE DATABASE SistemaInventario_JucebaComercial

--Borrar la base de datos
--DROP DATABASE SistemaInventario_JucebaComercial;

--Tabla tipo de materiales
--Tabla materiales 
--Proveedores
--Clientes
--Tabla teléfono
--Tabla dirrecciones
--Tabla de unidades de medida
--Tabla entradas al inventario
--Tabla detalle entradas al inventario
--Tabla salidas al inventario
--Tabla detalles entradas al inventario

--Tabla servicios 
--Tabla materiales que incluye cada servicio (tabla vs entre servicios y materiales)
--Tabla de excedentes de los materiales


--Tabla de teléfonos
CREATE TABLE telefonos(
    codigo INT IDENTITY PRIMARY KEY,
    telefono VARCHAR(25) NOT NULL UNIQUE,
    descripcion TEXT DEFAULT '',
    estado BIT DEFAULT 1
)

--Dirreciones 
CREATE TABLE dirreciones (
    codigo INT IDENTITY PRIMARY KEY,
    dirrecion VARCHAR(250) NOT NULL UNIQUE,
    descripcion text DEFAULT '',
    estado BIT DEFAULT 1
)

---Tabla de unidades de medida (pulgadas, pies, centímetros...)
CREATE TABLE unidades_medidas(
    codigo INT IDENTITY PRIMARY KEY,
    unidad_medida VARCHAR(20) NOT NULL UNIQUE,
    descripcion TEXT DEFAULT '',
    estado BIT DEFAULT 1
)

--Tipo de materiales
CREATE TABLE tipo_material(
    codigo INT IDENTITY PRIMARY KEY,
    tipo_material VARCHAR(100) UNIQUE,
    descripcion text DEFAULT '',
    estado BIT DEFAULT 1
)

--Materiales (Inventario de materiales y artículos)
CREATE TABLE materiales(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_tipo_material INT NOT NULL,
    CONSTRAINT fk_codigo_tipo_material_material FOREIGN KEY(codigo_tipo_material) REFERENCES tipo_material(codigo),
    --codigo_unidad_medida INT NOT NULL,
    --CONSTRAINT fk_codigo_unidad_medida_materiales FOREIGN KEY(codigo_unidad_medida) REFERENCES unidades_medidas(codigo),
    nombre VARCHAR(100) UNIQUE,
    costo DECIMAL (20,2),
	punto_reorden INT DEFAULT 0,
    existencia INT,
    --largo NUMERIC(8,2),
    descripcion TEXT DEFAULT '',
    fecha_registro DATETIME DEFAULT GETDATE(),
    estado BIT DEFAULT 1
)

--Excedente de los materiales que se utilizan
CREATE TABLE excedentes_materiales(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_tipo_material INT NOT NULL,
    CONSTRAINT fk_codigo_tipo_material_excedente FOREIGN KEY(codigo_tipo_material) REFERENCES tipo_material(codigo),
    codigo_material INT NOT NULL,
    CONSTRAINT fk_codigo_material_excedente FOREIGN KEY(codigo_material) REFERENCES materiales(codigo),
    codigo_unidad_medida INT NOT NULL,
    CONSTRAINT fk_codigo_unidad_medida_excedente FOREIGN KEY(codigo_unidad_medida) REFERENCES unidades_medidas(codigo),
    largo VARCHAR(50) NOT NULL,
	ancho VARCHAR(50) NOT NULL,
	alto VARCHAR(50) NOT NULL,
    cantidad INT,
    descripcion TEXT DEFAULT '',
    estado BIT DEFAULT 1
)



--Tabla de servicios
CREATE TABLE servicios (
    codigo INT IDENTITY PRIMARY KEY,
    nombre_servicio VARCHAR(100) UNIQUE,
    descripcion TEXT DEFAULT '',
    precio NUMERIC(20,2),
    estado BIT DEFAULT 1
)

--Los materiales que incluye cada servicio o trabajo
CREATE TABLE servicios_materiales(
    codigo_material INT NOT NULL,
    CONSTRAINT fk_codigo_material_serviciosMateriales FOREIGN KEY(codigo_material) REFERENCES materiales(codigo),
    codigo_servicio INT NOT NULL,
    CONSTRAINT fk_codigo_servicio_serviciosMateriales FOREIGN KEY(codigo_servicio) REFERENCES servicios(codigo),
    CONSTRAINT pk_servicios_materiales PRIMARY KEY(codigo_material, codigo_servicio),
    cantidad INT 
);

--Proveedores
CREATE TABLE proveedores(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_telefono INT NOT NULL,
    CONSTRAINT fk_codigo_telefono_proveedor FOREIGN KEY(codigo_telefono) REFERENCES telefonos(codigo),
    codigo_dirrecion INT NOT NULL,
    CONSTRAINT fk_codigo_dirrecion_proveedor FOREIGN KEY(codigo_dirrecion) REFERENCES dirreciones(codigo),
    nombre VARCHAR(100),
    descripcion TEXT DEFAULT '',
    estado BIT DEFAULT 1
)

--Clientes 
CREATE TABLE clientes(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_telefono INT NOT NULL,
    CONSTRAINT fk_codigo_telefono_cliente FOREIGN KEY(codigo_telefono) REFERENCES telefonos(codigo),
    codigo_dirrecion INT NOT NULL,
    CONSTRAINT fk_codigo_dirrecion_cliente FOREIGN KEY(codigo_dirrecion) REFERENCES dirreciones(codigo),
    nombre VARCHAR(100),
    descripcion TEXT DEFAULT '',
    fecha_registro DATETIME DEFAULT GETDATE(),
    estado BIT DEFAULT 1
)

--tipos de usuarios
CREATE TABLE tipo_usuarios(
  codigo INT IDENTITY PRIMARY KEY NOT NULL,
  tipo_usuario VARCHAR(100) NOT NULL UNIQUE,
  descripcion TEXT DEFAULT '',
  estado BIT DEFAULT 1
)

--usuarios
CREATE TABLE usuarios (
  codigo INT IDENTITY PRIMARY KEY,
  codigo_tipo_usuario INT NOT NULL,
  CONSTRAINT fk_codigo_tipo_usuario FOREIGN KEY(codigo_tipo_usuario) REFERENCES tipo_usuarios(codigo),
  nombre_usuario VARCHAR(100) UNIQUE,
  nombre VARCHAR (100), --nombre de la persona
  passwd VARCHAR(100)	NOT NULL, --Password
  fecha_ingreso DATETIME DEFAULT GETDATE(),
  email VARCHAR(100) NOT NULL DEFAULT '',
  descripcion TEXT DEFAULT '',
  estado BIT DEFAULT 1
)

--Entradas al inventario
CREATE TABLE entradas(
    codigo INT IDENTITY PRIMARY KEY,
    fecha_entrada DATETIME DEFAULT GETDATE(),
    total_entrada DECIMAL(20,2),
    estado BIT DEFAULT 1
)

--Detalle entrada al inventario
CREATE TABLE detalle_entrada(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_entrada INT NOT NULL,
    CONSTRAINT fk_codigo_entrada FOREIGN KEY(codigo_entrada) REFERENCES entradas(codigo),
    codigo_tipo_material INT NOT NULL,
    CONSTRAINT fk_codigo_tipo_material_entrada FOREIGN KEY(codigo_tipo_material) REFERENCES tipo_material(codigo),
    codigo_material INT NOT NULL,
    CONSTRAINT fk_codigo_material_entrada FOREIGN KEY(codigo_material) REFERENCES materiales(codigo),
	codigo_suplidor INT NOT NULL,
	CONSTRAINT fk_codigo_suplidor_entrada FOREIGN KEY(codigo_suplidor) REFERENCES proveedores(codigo),
	codigo_usuario INT NOT NULL,
	CONSTRAINT fk_codigo_usuario_entrada FOREIGN KEY(codigo_usuario) REFERENCES usuarios(codigo),
    costo DECIMAL(20,2),
    cantidad INT, 
    estado BIT DEFAULT 1
)

--Salidas del inventario
CREATE TABLE salidas(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_servicio INT NOT NULL,
    CONSTRAINT fk_codigo_servicio_salida FOREIGN KEY(codigo_servicio) REFERENCES servicios(codigo),
    fecha_salida DATETIME DEFAULT GETDATE(),
    total_salida DECIMAL(20,2),
    estado BIT DEFAULT 1
)

--Detalles de la salida
CREATE TABLE detalles_salida(
    codigo INT IDENTITY PRIMARY KEY,
    codigo_salida INT NOT NULL,
    CONSTRAINT fk_codigo_salida FOREIGN KEY(codigo_salida) REFERENCES salidas(codigo),
    codigo_cliente INT NOT NULL,
    CONSTRAINT fk_codigo_cliente_salida FOREIGN KEY(codigo_cliente) REFERENCES clientes(codigo),
    --codigo_tipo_material INT NOT NULL,
    --CONSTRAINT fk_codigo_tipo_material_salidas FOREIGN KEY(codigo_tipo_material) REFERENCES tipo_material(codigo),
    codigo_material INT NOT NULL,
    CONSTRAINT fk_codigo_material_salidas FOREIGN KEY(codigo_material) REFERENCES materiales(codigo),
    codigo_usuario INT NOT NULL,
	CONSTRAINT fk_codigo_usuario_salida FOREIGN KEY(codigo_usuario) REFERENCES usuarios(codigo),
    precio DECIMAL(20,2),
    cantidad INT,
    estado BIT DEFAULT 1
)

Select * from dirreciones