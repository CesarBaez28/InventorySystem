using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DataTable InsertarDireccion(string direccion) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@direccion", direccion));
            table = ExecuteReader("p_InsertarDireccion");
            return table;
        }

        
    }
}
