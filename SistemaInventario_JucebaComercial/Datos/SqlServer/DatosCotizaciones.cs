using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Datos.SqlServer
{
    public class DatosCotizaciones : ExecuteCommandSql
    {

        //Regitrar cotizacion
        public void RegistrarCotizacion(DateTime fechaCotizacion, string descripcion)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechaCotizacion",fechaCotizacion));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            ExecuteNonQuery("p_RegistrarCotizacion");
        }

        //Regitrar detalles Cotización
        public void RegistrarDetallesCotizacion(int codigoUsuario, int codigoServicio, int codigoCliente, 
            int cantidad, float precio) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@precio", precio));
            ExecuteNonQuery("p_RegistrarDetallesCotizacion");
        }
    }
}
