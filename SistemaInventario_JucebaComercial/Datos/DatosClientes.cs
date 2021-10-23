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

        //Buscar cliente por codigo
        public DataTable MostrarClienteCodigo(int codigoCliente)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
            table = ExecuteReader("p_MostrarClienteCodigo");
            return table;
        }

        //Buscar cliente por nombre
        public DataTable MostrarClienteNombre(string nombreCliente) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombreCliente", nombreCliente));
            table = ExecuteReader("p_MostrarClienteNombre");
            return table;
        }

        //Mostrar clientes por estado (activo o inactivo)
        public DataTable MostrarClienteEstado(bool estado) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@estado", estado));
            table = ExecuteReader("p_MostrarClienteEstado");
            return table;
        }
    }
}
