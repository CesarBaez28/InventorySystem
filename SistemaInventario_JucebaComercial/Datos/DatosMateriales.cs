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
    }
}
