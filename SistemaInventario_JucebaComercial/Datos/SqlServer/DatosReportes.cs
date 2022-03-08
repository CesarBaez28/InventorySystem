using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosReportes : ExecuteCommandSql
    {
        //Reporte de entradas general
        public DataTable ReporteEntradaGeneral(DateTime fechaInicial, DateTime fechaFinal) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechainicial", fechaInicial));
            parameters.Add(new SqlParameter("@fechaFinal", fechaFinal));
            table = ExecuteReader("p_reporteEntradasGeneral");
            return table;
        }

        //Reporte de entradas detallado
        public DataTable ReporteEntradaDetallado(DateTime fechaInicial, DateTime fechaFinal) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechainicial", fechaInicial));
            parameters.Add(new SqlParameter("@fechaFinal", fechaFinal));
            table = ExecuteReader("p_reporteEntradasDetallado");
            return table;
        }

        //Reporte de salidas general
        public DataTable ReporteSalidasGeneral(DateTime fechaInicial, DateTime fechaFinal) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechainicial", fechaInicial));
            parameters.Add(new SqlParameter("@fechaFinal", fechaFinal));
            table = ExecuteReader("p_reporteGeneralSalidas");
            return table;
        }

        //Reporte de salidas detallado
        public DataTable ReporteSalidasDetallado(DateTime fechaInicial, DateTime fechaFinal) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechainicial", fechaInicial));
            parameters.Add(new SqlParameter("@fechaFinal", fechaFinal));
            table = ExecuteReader("p_reporteDetalladoSalidas");
            return table;
        }

        //Consultar cotizaciones
        public DataTable ConsultarCotizaciones(DateTime fechaInicial, DateTime fechaFinal) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechainicial", fechaInicial));
            parameters.Add(new SqlParameter("@fechaFinal", fechaFinal));
            table = ExecuteReader("p_consultarCotizaciones");
            return table;
        }

        //Consultar cotizaciones por código
        public DataTable ConsultarCotizacionesPorCodigo(int codigo) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            table = ExecuteReader("p_consultarCotizacionesCodigo");
            return table;
        }

        //Consultar cotizaciones por descripción
        public DataTable ConsultarCotizacionesPorDescripcion(string descripcion) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            table = ExecuteReader("p_consultarCotizacionesDescripcion");
            return table;
        }

        //Consultar cotizaciones por cliente
        public DataTable ConsultarCotizacionesPorCliente(string cliente) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@cliente", cliente));
            table = ExecuteReader("p_consultarCotizacionesCliente");
            return table;
        }

        //Consultar cotizaciones por estado (aceptadas o no aceptadas)
        public DataTable ConsultarCotizacionesPorEstado(bool estado) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@estado", estado));
            table = ExecuteReader("p_consultarCotizacionesEstado");
            return table;
        }

        //Consultar cotización detallada (código, servicios, monto, cantidad, precio, total)
        public DataTable ConsultarCotizacionDetallada(int codigo) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            table = ExecuteReader("p_consultarCotizacionDetallada");
            return table;
        }

        //Consultar metadatos de una cotización (Usuario, cliente, fecha)
        public DataTable ConsultarMetaDatosCotizacion(int codigo) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigo));
            table = ExecuteReader("p_consultarMetadatosCotizacion");
            return table;
        }
    }
}
