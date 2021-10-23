using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class DominioCliente
    {
        DatosClientes cliente = new DatosClientes();

        //Show all clients
        public DataTable ShowClients() 
        {
            DataTable table = new DataTable();
            table = cliente.MostrarClientes();
            return table;
        }
    }
}
