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
    }
}
