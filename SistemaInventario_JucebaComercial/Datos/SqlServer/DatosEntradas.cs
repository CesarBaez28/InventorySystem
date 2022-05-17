using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosEntradas : ExecuteCommandSql
    {
        public void RegistrarEntrada(DateTime fechaEntrada)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechaEntrada", fechaEntrada));
            ExecuteNonQuery("p_RegistrarEntrada");
        }

        //Registrar entrada al inventario
        public void RegistrarDetalleEntrada(int codigoUsuario, string suplidor,
             string material, int cantidad, float costo)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
            parameters.Add(new SqlParameter("@suplidor", suplidor));
            parameters.Add(new SqlParameter("@material", material));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@costo", costo));
            ExecuteNonQuery("p_RegistrarDetalleEntrada");
        }
    }
}
