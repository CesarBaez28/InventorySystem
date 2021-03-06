using Datos;
using System;
using System.Data;

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

        //show customer name and code
        public DataTable ShowCustumerNameCode()
        {
            DataTable table = new DataTable();
            table = cliente.MostrarNombreCodigoClientes();
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

        //Update costumer 
        public void UpdateCostumer(string telefono, string telefonoViejo, string codigoDireccion, string nombreCliente,
            string codigoCliente, bool estado)
        {
            cliente.ActualizarCliente(telefono, telefonoViejo, Convert.ToInt32(codigoDireccion), nombreCliente, Convert.ToInt32(codigoCliente), estado);
        }

        //Delete Costumer (change status to inactive)
        public void DeleteCostumer(string codigo)
        {
            cliente.EliminarCliente(Convert.ToInt32(codigo));
        }
    }
}
