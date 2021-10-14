﻿using System;
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
            table = ExcuteReader("p_LoginUsuario");

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
            table = ExcuteReader("p_MostrarUsuarios");
            return table;
        }
    }
}
