using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public abstract class ConnectionSql
    {
        private readonly string cadenaConexion;

        public ConnectionSql() 
        { 
            cadenaConexion = "server = DESKTOP-AV3UN3B\\SQLEXPRESS; " +
            "database = SistemaInventario_JucebaComercial; integrated security = true";
        }

        protected SqlConnection GetConnection() 
        {
            return new SqlConnection(cadenaConexion);
        }

    }
}
