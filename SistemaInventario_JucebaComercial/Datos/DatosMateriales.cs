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
    }
}
