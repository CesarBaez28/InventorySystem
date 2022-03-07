using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

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
    }
}
