using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Comun;

namespace Dominio
{
    public class DominioSalida
    {
        DatosSalidas salidas = new DatosSalidas();

        public DataTable GetCodeSale() 
        {
            DataTable table = new DataTable();
            table = salidas.ObtenerCodigoSalida();
            return table;
        }

        //register sale of service
        public void SaleOfService(DateTime fecha) 
        {
            salidas.RegistrarSalida(fecha);
        }

        //Register service sale details
        public void add_MultipleSingleInsert(IEnumerable<DetallesSalida> detallesSalida)
        {
            salidas.MultiplesSalidas(detallesSalida);
        }
    }
}
