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
    }
}
