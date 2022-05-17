using Datos;
using System;
using System.Data;

namespace Dominio
{
    public class DominioReportes
    {
        DatosReportes reporte = new DatosReportes();

        //General entry report
        public DataTable GeneralEntryReport(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable table = new DataTable();
            table = reporte.ReporteEntradaGeneral(fechaInicial, fechaFinal);
            return table;

        }

        //detailed entry report
        public DataTable DetailedEntryReport(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable table = new DataTable();
            table = reporte.ReporteEntradaDetallado(fechaInicial, fechaFinal);
            return table;
        }

        //Genral sales report
        public DataTable GeneralSalesReport(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable table = new DataTable();
            table = reporte.ReporteSalidasGeneral(fechaInicial, fechaFinal);
            return table;
        }

        //Datailed sales report
        public DataTable DetailedSalesReport(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable table = new DataTable();
            table = reporte.ReporteSalidasDetallado(fechaInicial, fechaFinal);
            return table;
        }

        //consult quotes
        public DataTable consultQuotes(DateTime fechaInicial, DateTime fechaFinal)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarCotizaciones(fechaInicial, fechaFinal);
            return table;
        }

        //Consult quotes by code.
        public DataTable ConsultQuotesByCode(string codigo)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarCotizacionesPorCodigo(Convert.ToInt32(codigo));
            return table;
        }

        //Consult quotes by description.
        public DataTable ConsultQuotesByDescription(string descripcion)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarCotizacionesPorDescripcion(descripcion);
            return table;
        }

        //Consult Quotes by client
        public DataTable ConsultQuotesByClient(string cliente)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarCotizacionesPorCliente(cliente);
            return table;
        }

        //Consult quotes by status
        public DataTable ConsultQuotesByStatus(bool estado)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarCotizacionesPorEstado(estado);
            return table;
        }

        //Consult datailed quote
        public DataTable ConsultDatailedQuote(string codigo)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarCotizacionDetallada(Convert.ToInt32(codigo));
            return table;
        }

        public DataTable ConsultMetadataQuote(string codigo)
        {
            DataTable table = new DataTable();
            table = reporte.ConsultarMetaDatosCotizacion(Convert.ToInt32(codigo));
            return table;
        }
    }
}
