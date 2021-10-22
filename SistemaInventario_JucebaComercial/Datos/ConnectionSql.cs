using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Datos
{
    public abstract class ConnectionSql
    {
        private readonly string cadenaConexion;

        public ConnectionSql() 
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["SistemaInventario_JucebaComercial"].ToString();
        }

        protected SqlConnection GetConnection() 
        {
            return new SqlConnection(cadenaConexion);
        }

    }
}
