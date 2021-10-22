using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Dominio
{
    public class DominioUsuario
    {
        DatosUsuarios usuario = new DatosUsuarios();

        //Login Users
        public bool LoginUsuario(string nombreUsuario, string password)
        {
            return usuario.LoginUsuario(nombreUsuario, password);
        }

        //Show all system users
        public DataTable ShowUsers()
        {
            DataTable table = new DataTable();
            table = usuario.ShowUsers();
            return table;
        }

        // Show Type of users 
        public DataTable ShowTypeUsers()
        {
            DataTable table = new DataTable();
            table = usuario.TiposUsuarios();
            return table;
        }

        //Show users by code 
        public DataTable ShowUsersByCode(string codigo)
        {
            DataTable table = new DataTable();
            table = usuario.MostrarUsuarioCodigo(Convert.ToInt32(codigo));
            return table;
        }

        //Show users by name
        public DataTable ShowUsersByName(string nombreUsuario)
        {
            DataTable table = new DataTable();
            table = usuario.MostrarUsuarioNombre(nombreUsuario);
            return table;
        }

        //Show users by status
        public DataTable ShowUsersByStatus(bool estado)
        {
            DataTable table = new DataTable();
            table = usuario.MostrarUsuarioEstado(estado);
            return table;
        }

        //register user
        public void RegisterUser(string codigo_TipoUsuario, string nombre_usuario, string nombre,
            string password, string email)
        {
            usuario.RegistrarUsuario(Convert.ToInt32(codigo_TipoUsuario), nombre_usuario, nombre, password, email);
        }

        // Update users 
        public void UpdateUser(string codigo_tipoUsuario, string nombre_usuario, string nombre,
            string password, string email, bool estado, string codigoUsuario) 
        {
            usuario.ActualizarUsuario(Convert.ToInt32(codigo_tipoUsuario), nombre_usuario, nombre, 
                password, email, estado, Convert.ToInt32(codigoUsuario));
        }
    }
}
