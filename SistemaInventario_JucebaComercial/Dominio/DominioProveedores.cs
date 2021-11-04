using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class DominioProveedores
    {
        DatosProveedores proveedor = new DatosProveedores();

        //Show suppliers
        public DataTable ShowSuppliers() 
        {
            DataTable table = new DataTable();
            table = proveedor.MostrarProveedores();
            return table;
        }

        //Search suppliers by code
        public DataTable SearchSupplierByCode(string codigo) 
        {
            DataTable table = new DataTable();
            table = proveedor.BuscarProveedorCodigo(Convert.ToInt32(codigo));
            return table;
        }

        //Search suppliers by name
        public DataTable SearchSupplierByName(string nombre) 
        {
            DataTable table = new DataTable();
            table = proveedor.BuscarProveedorNombre(nombre);
            return table;
        }

        //Search suppliers by status
        public DataTable SearchSupplierbyStatus(bool estado) 
        {
            DataTable table = new DataTable();
            table = proveedor.BuscarProveedorEstado(estado);
            return table;
        }

        // Reegister supplier
        public void RegisterSupplier(string telefono, string codigoDireccion, string nombreProveedor) 
        {
            proveedor.RegistrarProveedor(telefono, Convert.ToInt32(codigoDireccion), nombreProveedor);
        }
    }
}
