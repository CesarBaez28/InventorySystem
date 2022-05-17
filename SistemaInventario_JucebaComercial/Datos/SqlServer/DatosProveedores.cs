using System.Collections.Generic;
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

        //MostrarNombreCodigoProveedores
        public DataTable NombreCodigoProveedores()
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT codigo, nombre FROM proveedores WHERE estado = 1");
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
            parameters.Add(new SqlParameter("@telefono", telefono));
            parameters.Add(new SqlParameter("@codigoDirrecion", codigoDireccion));
            parameters.Add(new SqlParameter("@nombreProveedor", nombreProveedor));
            ExecuteNonQuery("p_InsertarProveedor");
        }

        //Actualizar datos del proveedor
        public void ActualizarProveedor(string telefono, string telefonoViejo, int codigoDireccion, string nombreProveedor,
            int codigoProveedor, bool estado)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@telefono", telefono));
            parameters.Add(new SqlParameter("@telefonoViejo", telefonoViejo));
            parameters.Add(new SqlParameter("@codigoDireccion", codigoDireccion));
            parameters.Add(new SqlParameter("@nombreProveedor", nombreProveedor));
            parameters.Add(new SqlParameter("@codigoProveedor", codigoProveedor));
            parameters.Add(new SqlParameter("@estado", estado));
            ExecuteNonQuery("p_ActualizarProveedor");
        }

        //Eliminar Proveedor (Cambierle el estado a inactivo)
        public void EliminarProveedor(int codigoProveedor)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoProveedor", codigoProveedor));
            ExecuteNonQuery("p_EliminarProveedor");
        }
    }
}
