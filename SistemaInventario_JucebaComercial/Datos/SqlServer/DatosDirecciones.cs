using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosDirecciones : ExecuteCommandSql
    {
        //Mostrar todos las Direcciones de sistema
        public DataTable MostrarDirecciones()
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("select codigo, dirrecion from dirreciones");
            return table;
        }

        //Insertar nueva direccion
        public void InsertarDireccion(string direccion)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@direccion", direccion));
            ExecuteNonQuery("p_InsertarDireccion");
        }

        //Actualizar direccion
        public void ActualizaDireccion(string direccion, string direccionActualizar)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@direccion", direccion));
            parameters.Add(new SqlParameter("@direccionActualizar", direccionActualizar));
            ExecuteNonQuery("p_ActualizarDireccion");
        }
    }
}
