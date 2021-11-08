using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class DominioMedidas
    {
        DatosMedidas medida = new DatosMedidas();

        //Show measurement units
        public DataTable ShowMeasurement() 
        {
            DataTable table = new DataTable();
            table = medida.MostrarMedidas();
            return table;
        }
    }
}
