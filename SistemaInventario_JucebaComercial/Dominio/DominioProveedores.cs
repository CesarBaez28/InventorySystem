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
    }
}
