using System.Configuration;
using System.Data.SqlClient;

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
