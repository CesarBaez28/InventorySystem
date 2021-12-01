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
    }
}
