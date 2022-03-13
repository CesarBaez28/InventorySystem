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


        //Registra nuevos detalles de una cotización ya creada
        public void RegistrarNuevosDetallesCotizacion(int codigoCotizacion, int codigoUsuario, string servicio, int codigoCliente,
            int cantidad, float precio)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoCotizacion", codigoCotizacion));
            parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
            parameters.Add(new SqlParameter("@servicio", servicio));
            parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@precio", precio));
            ExecuteNonQuery("p_RegistrarNuevosDetallesCotizacion");
        }

        //Editar cotización
        public void EditarCotizacion(int codigoCotizacion, DateTime fecha, string descripcion) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoCotizacion", codigoCotizacion));
            parameters.Add(new SqlParameter("@fecha", fecha));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            ExecuteNonQuery("p_EditarCotizacion");
        }

        public void EditarDetallesCotizaion(int codigoDetalleCotizacion, string servicio, int codigoCliente, int codigoUsuario, 
            float precio, int cantidad) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoDetalleCotizacion", codigoDetalleCotizacion));
            parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
            parameters.Add(new SqlParameter("@servicio", servicio));
            parameters.Add(new SqlParameter("@codigoCliente", codigoCliente));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@precio", precio));
            ExecuteNonQuery("p_EditarDetallesCotizacion");
        }

        //Obter el código de la última cotización
        public DataTable ObtenerCodigoCotizacion() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT MAX(codigo) as 'codigo' FROM cotizaciones");
            return table;
        }

        //Obtener códigos de los detalles de la cotizacion
        public DataTable ObtenenerDetallesCotizacionCodigos(int codigoCotizacion) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoCotizacion", codigoCotizacion));
            table = ExecuteReaderText("SELECT codigo as 'Código detalle' FROM detallesCotizacion WHERE codigo_cotizacion = @codigoCotizacion");
            return table;
        }
        
        //Cambiar estado de cotización a aceptado
        public void AprobarCotizacion(int codigo)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo",codigo));
            ExecuteNonQueryText("UPDATE cotizaciones SET estado = 1 WHERE codigo = @codigo");
        }

        //Borrar cotización 
        public void EliminarCotizacion(int codigo) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            ExecuteNonQueryText("DELETE FROM cotizaciones WHERE codigo = @codigo");
        }

        //Borrar detalles de la cotización
        public void EliminarDetallesCotizacion(int codigo) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            ExecuteNonQueryText("DELETE FROM detallesCotizacion WHERE codigo_cotizacion = @codigo");
        }

        //Borrar detalles de la cotización por código del detalle
        public void EliminarDetallesCotizacionPorCodigo(int codigo) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            ExecuteNonQueryText("DELETE FROM detallesCotizacion WHERE codigo = @codigo");
        }
    }
}
