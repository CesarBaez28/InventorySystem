using Datos;
using System.Data;

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
