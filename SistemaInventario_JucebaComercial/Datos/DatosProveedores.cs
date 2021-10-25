using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProveedores : ExecuteCommandSql
    {
        //Mostrar todos los proveedores
        public DataTable MostrarProveedores() 
        {
            DataTable table = new DataTable();
            table = ExecuteReader("p_MostrarProveedores");
            return table;
        }

        //Buscar proveedores por codigo
        public DataTable BuscarProveedorCodigo(int codigo) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            table = ExecuteReader("p_BuscarProveedorCodigo");
            return table;
        }

        //Buscar proveedor por nombre 
        public DataTable BuscarProveedorNombre(string nombre) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre", nombre));
            table = ExecuteReader("p_BuscarProveedorNombre");
            return table;
        }
    }
}
