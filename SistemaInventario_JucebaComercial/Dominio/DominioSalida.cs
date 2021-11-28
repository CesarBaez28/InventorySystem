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

        //register service sale details
        public void ServiceSaleDetails(string codigoUsuario, string cliente, string servicio,
            string cantidad, string precio) 
        {
            salidas.RegistrarDetallesSalida(Convert.ToInt32(codigoUsuario), cliente,
                servicio, Convert.ToInt32(cantidad), float.Parse(precio));
        }

        public void add_MultipleSingleInsert(IEnumerable<DetallesSalida> detallesSalida)
        {
            salidas.MultiplesSalidas(detallesSalida);
        }
    }
}
