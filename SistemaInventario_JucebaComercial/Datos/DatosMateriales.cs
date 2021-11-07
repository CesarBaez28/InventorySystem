using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosMateriales : ExecuteCommandSql
    {
        //Mostrar todos lo materiales del sistema
        public DataTable MostrarMateriales() 
        {
            DataTable table = new DataTable();
            table = ExecuteReader("p_MostrarMateriales");
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
    }
}
