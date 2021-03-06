using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosMateriales : ExecuteCommandSql
    {
        //Mostrar todos los datos de los materiales del sistema
        public DataTable MostrarMateriales()
        {
            DataTable table = new DataTable();
            table = ExecuteReader("p_MostrarMateriales");
            return table;
        }

        //Mostrar nombre y codigo de los materiales
        public DataTable NombreCodigoMateriales()
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT nombre as 'Material', codigo FROM materiales WHERE estado = 1");
            return table;
        }

        //Buscar costo de un material por su código.
        public DataTable BuscarCostoMaterial(int codigoMaterial)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            table = ExecuteReaderText("SELECT costo FROM materiales WHERE codigo = @codigoMaterial");
            return table;
        }

        //Obtener punto de reorden de los materiales
        public DataTable PuntoReorden()
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("Select punto_reorden FROM materiales GROUP BY punto_reorden");
            return table;
        }

        //Buscar materiales por codigo
        public DataTable BuscarMaterialesCodigo(int codigo)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            table = ExecuteReader("p_BuscarMaterialesCodigo");
            return table;
        }

        //Buscar materiales por nombre
        public DataTable BuscarMaterialesNombre(string nombre)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre", nombre));
            table = ExecuteReader("p_BuscarMaterialesNombre");
            return table;
        }

        //Buscar materiales por estado
        public DataTable BuscarMaterialesEstado(bool estado)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@estado", estado));
            table = ExecuteReader("p_BuscarMaterialesEstado");
            return table;
        }

        //Mostrar tipos de materiales
        public DataTable MostrarTipoMateriales()
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT codigo, tipo_material FROM tipo_material");
            return table;
        }

        //Mostrar materiales excedentes 
        public DataTable MostrarExcedentesMateriales()
        {
            DataTable table = new DataTable();
            table = ExecuteReader("P_MostrarMaterialesExcedentes");
            return table;
        }

        //Registrar nuevo material
        public void RegistrarMaterial(int codigo_tipoMaterial, string nombre, string descripcion,
            float costo, int existencia)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo_tipoMaterial", codigo_tipoMaterial));
            parameters.Add(new SqlParameter("@nombre", nombre));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            parameters.Add(new SqlParameter("@costo", costo));
            parameters.Add(new SqlParameter("@existencia", existencia));
            ExecuteNonQuery("p_InsertarMaterial");
        }

        //Actualiar material
        public void ActualizarMaterial(int codigoMaterial, int codigo_tipoMaterial, string nombre, string descripcion,
            float costo, int existencia, bool estado)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            parameters.Add(new SqlParameter("@codigo_TipoMaterial", codigo_tipoMaterial));
            parameters.Add(new SqlParameter("@nombre", nombre));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            parameters.Add(new SqlParameter("@costo", costo));
            parameters.Add(new SqlParameter("@existencia", existencia));
            parameters.Add(new SqlParameter("@estado", estado));
            ExecuteNonQuery("p_ActualizarMaterial");
        }

        //Elminar material (cambiar estado a inactivo)
        public void EliminarMaterial(int codigo)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            ExecuteNonQuery("p_EliminarMaterial");
        }

        //Registrar tipo de material
        public void RegistrarTipoMaterial(string nombre)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre", nombre));
            ExecuteNonQuery("p_InsertarTipoMaterial");
        }

        //Actualizar tipo de material
        public void ActualizarTipoMaterial(string nombre, string nombreNuevo)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre", nombre));
            parameters.Add(new SqlParameter("@tipoMaterialNuevo", nombreNuevo));
            ExecuteNonQuery("p_ActualizarTipoMaterial");
        }

        //Registrar excedente de material
        public void RegistrarExcenteMaterial(string tipoMaterial, int codigoMaterial,
            int codigoMedida, string largo, string ancho, string alto, int cantidad, string descripcion)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@tipoMaterial", tipoMaterial));
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            parameters.Add(new SqlParameter("@codigoMedida", codigoMedida));
            parameters.Add(new SqlParameter("@largo", largo));
            parameters.Add(new SqlParameter("@ancho", ancho));
            parameters.Add(new SqlParameter("@alto", alto));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            ExecuteNonQuery("p_InsertarExcedenteMaterial");
        }

        //Actualilzar cantidad del excedente
        public void ActualizarCantidadExcedente(int codigo, int cantidad)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@codigo", codigo));
            ExecuteNonQueryText("UPDATE excedentes_materiales SET cantidad = " +
                "cantidad - @cantidad FROM excedentes_materiales WHERE codigo = @codigo");
        }

        //Actualizar excedente de material
        public void ActualizarExcedenteMaterial(int codigoExcedente, int codigoMedida,
            string largo, string ancho, string alto, int cantidad, string descripcion)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo_excedente", codigoExcedente));
            parameters.Add(new SqlParameter("@codigoMedida", codigoMedida));
            parameters.Add(new SqlParameter("@largo", largo));
            parameters.Add(new SqlParameter("@ancho", ancho));
            parameters.Add(new SqlParameter("@alto", alto));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            ExecuteNonQuery("p_ActualizarExcedenteMaterial");
        }

        //Eliminar excedente de material
        public void EliminarExcedenteMaterial(int codigoExcedente)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoExcedente", codigoExcedente));
            ExecuteNonQuery("p_EliminarExcedenteMaterial");
        }
    }
}
