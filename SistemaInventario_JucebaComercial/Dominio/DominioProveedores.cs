using Datos;
using System;
using System.Data;

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

        //Show names and codes about suppliers
        public DataTable NameCodeSupplier()
        {
            DataTable table = new DataTable();
            table = proveedor.NombreCodigoProveedores();
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

        //Update supllier
        public void UpdateSupplier(string telefono, string telefonoViejo, string codigoDireccion, string nombreProveedor,
            string codigoProveedor, bool estado)
        {
            proveedor.ActualizarProveedor(telefono, telefonoViejo, Convert.ToInt32(codigoDireccion),
                nombreProveedor, Convert.ToInt32(codigoProveedor), estado);
        }

        //Delete suplier (Change status to inactive)
        public void DeleteSupplier(string codigoSuplidor)
        {
            proveedor.EliminarProveedor(Convert.ToInt32(codigoSuplidor));
        }
    }
}
