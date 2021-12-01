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
    }
}
