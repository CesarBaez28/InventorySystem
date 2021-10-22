using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DatosUsuarios : ExecuteCommandSql
    {
        //Login Usuario
        public bool LoginUsuario(string nombre, string password) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre_usuario", nombre));
            parameters.Add(new SqlParameter("@password", password));
            table = ExecuteReader("p_LoginUsuario");

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        //Consultar todos los usuarios del sistema 
        public DataTable ShowUsers() 
        {
            DataTable table = new DataTable();
            table = ExecuteReader("p_MostrarUsuarios");
            return table;
        }

        //Consultar usuarios por codigo
        public DataTable MostrarUsuarioCodigo (int codigo)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            table = ExecuteReader("p_MostrarUsuariosCodigo");
            return table;
        }

        //Consultar usuarios por su nombre de usuario
        public DataTable MostrarUsuarioNombre(string nombreUsuario) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombreUsuario", nombreUsuario));
            table = ExecuteReader("p_mostrarUsuariosNombre");
            return table;
        }

        //Consultar usuarios por estado (activos o inactivos)
        public DataTable MostrarUsuarioEstado(bool estado) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@estado", estado));
            table = ExecuteReader("p_mostrarUsuarioEstado");
            return table;
        }
    }
}
