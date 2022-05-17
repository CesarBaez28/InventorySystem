using Datos;
using System;
using System.Data;

namespace Dominio
{
    public class DominioUsuario
    {
        DatosUsuarios usuario = new DatosUsuarios();

        //AtributosUsuario
        private int codigoUsuario;
        private int codigo_tipoUsuario;
        private string tipo_usuario;
        private string nombreUsuario;
        private string password;
        private string nombre;
        private string email;
        private bool estado;

        //Constructor DominioUsuario
        public DominioUsuario(int codigoUsuario, int codigo_tipoUsuario, string tipo_usuario, string nombreUsuario,
            string password, string nombre, string email, bool estado)
        {
            this.codigoUsuario = codigoUsuario;
            this.codigo_tipoUsuario = codigo_tipoUsuario;
            this.tipo_usuario = tipo_usuario;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.nombre = nombre;
            this.email = email;
            this.estado = estado;
        }

        //Creo otro constructor sin parametros
        public DominioUsuario() { }

        //edit user profile
        public string EditUserProfile()
        {
            try
            {
                usuario.ActualizarUsuario(codigo_tipoUsuario, nombreUsuario, nombre, password,
                    email, estado, codigoUsuario);

                usuario.LoginUsuario(nombreUsuario, password);

                return "Tu perfil se ha actualizado correctamente";

            }
            catch
            {
                return "El nombre de usuario ya está registrado";
            }
        }

        //Login Users
        public bool LoginUsuario(string nombreUsuario, string password)
        {
            return usuario.LoginUsuario(nombreUsuario, password);
        }

        //RecoverPassword
        public string RecoverPassword(string usuarioSolicitante)
        {
            return usuario.RecuperarPassword(usuarioSolicitante);
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

        //Delete users (Actually, change the status to false)
        public void DeleteUser(string codigoUsuario)
        {
            usuario.EliminarUsuario(Convert.ToInt32(codigoUsuario));
        }
    }
}
