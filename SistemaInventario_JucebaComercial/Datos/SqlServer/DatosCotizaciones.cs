using System;
using System.Data;
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

        //Obter el código de la última cotización
        public DataTable ObtenerCodigoCotizacion() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT MAX(codigo) as 'codigo' FROM cotizaciones");
            return table;
        }

        //Cambiar estado de cotización a aceptado
        public void AprobarCotizacion(int codigo)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo",codigo));

            ExecuteNonQueryText("UPDATE cotizaciones SET estado = 1 WHERE codigo = @codigo");
        }
    }
}
