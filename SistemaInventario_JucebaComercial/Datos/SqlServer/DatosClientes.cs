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

        //Mostrar nombre y código de los clientes 
        public DataTable MostrarNombreCodigoClientes() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("Select codigo, nombre FROM clientes WHERE estado = 1");
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

        //Insertar nuevo cliente
        public void InsertarCliente(string telefono, int codigoDireccion, string nombreCliente) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@telefono", telefono));
            parameters.Add(new SqlParameter("@codigoDirrecion", codigoDireccion));
            parameters.Add(new SqlParameter("@nombreCliente", nombreCliente));
            ExecuteNonQuery("p_InsertarCliente");
        }

        //Actualizar datos del cliente
        public void ActualizarCliente(string telefono, string telefonoViejo, int codigoDireccion, string nombreCliente, 
            int codigoCliente,  bool estado) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@telefono", telefono));
            parameters.Add(new SqlParameter("@telefonoViejo", telefonoViejo));
            parameters.Add(new SqlParameter("@codigoDireccion", codigoDireccion));
            parameters.Add(new SqlParameter("@nombreCliente", nombreCliente));
            parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
            parameters.Add(new SqlParameter("@estado", estado));
            ExecuteNonQuery("p_ActualizarCliente");
        }

        //Eliminar cliente (cambiarle el estado a inactivo)
        public void EliminarCliente(int codigoCliente) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
            ExecuteNonQuery("p_EliminarCliente");
        }
    }
}
