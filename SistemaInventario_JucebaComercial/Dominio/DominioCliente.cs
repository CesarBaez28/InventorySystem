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

        //Show all costumers
        public DataTable ShowCostumers() 
        {
            DataTable table = new DataTable();
            table = cliente.MostrarClientes();
            return table;
        }

        //Show costumers by code
        public DataTable ShowCostumerByCode(String codigoCliente) 
        {
            DataTable table = new DataTable();
            table = cliente.MostrarClienteCodigo(Convert.ToInt32(codigoCliente));
            return table; 
        }

        //Show costumers by name
        public DataTable ShowCostumersByName(string nombreCliente) 
        {
            DataTable table = new DataTable();
            table = cliente.MostrarClienteNombre(nombreCliente);
            return table;
        }

        //Show costumers by status
        public DataTable ShowCostumersByStatus(bool estado) 
        {
            DataTable table = new DataTable();
            table = cliente.MostrarClienteEstado(estado);
            return table;
        }

        //Register costumer
        public void RegisterCostumer(string telefono, string codigoDireccion, string nombreCliente) 
        {
            cliente.InsertarCliente(telefono, Convert.ToInt32(codigoDireccion), nombreCliente);
        }
    }
}
