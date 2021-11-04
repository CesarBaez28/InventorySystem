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

        //Buscar proveedor por Estado
        public DataTable BuscarProveedorEstado(bool estado) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@estado", estado));
            table = ExecuteReader("p_BuscarProveedorEstado");
            return table;
        }

        //Ingresar nuevo proveedor
        public void RegistrarProveedor(string telefono, int codigoDireccion, string nombreProveedor) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@telefono",telefono));
            parameters.Add(new SqlParameter("@codigoDirrecion", codigoDireccion));
            parameters.Add(new SqlParameter("@nombreProveedor", nombreProveedor));
            ExecuteNonQuery("p_InsertarProveedor");
        }
    }
}
