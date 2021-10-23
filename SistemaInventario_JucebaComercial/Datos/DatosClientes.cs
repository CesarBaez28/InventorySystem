using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosClientes : ExecuteCommandSql
    {
        //Mostrar todos los clientes del sistema
        public DataTable MostrarClientes() 
        {
            DataTable table = new DataTable();
            table = ExecuteReader("p_MostrarClientes");
            return table;
        }

    }
}
