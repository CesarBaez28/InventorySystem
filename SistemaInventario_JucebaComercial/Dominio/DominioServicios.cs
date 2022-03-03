using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class DominioServicios
    {
        DatosServicios servicios = new DatosServicios();

        //Register Service
        public void RegisterService(string nombreServicio, string descripcion, string precio, bool estado) 
        {
            servicios.RegistrarServicio(nombreServicio, descripcion, float.Parse(precio), estado);
        }

        //Register materials services
        public void RegisterMaterialService(string codigoMaterial, string cantidad) 
        {
            servicios.RegistrarMaterialServicio(Convert.ToInt32(codigoMaterial), float.Parse(cantidad));
        }

        //Register new materials services
        public void RegisterNewMaterialService(string codigoServicio, string codigoMaterial, string cantidad) 
        {
            servicios.RegistrarNuevoMaterialServicio(Convert.ToInt32(codigoServicio),
                Convert.ToInt32(codigoMaterial), Convert.ToInt32(cantidad));
        }

        //Update service
        public void UpdateService(string codigoServicio, string nombreServicio,
            string precio, string descripcion, bool estado) 
        {
            servicios.ActualizarServicio(Convert.ToInt32(codigoServicio), nombreServicio, 
                float.Parse(precio), descripcion, estado);
        }

        //Update materials services
        public void UpdateMaterialService(string codigoServicio,
            string codigoMaterial, string materialAnterior, string cantidad) 
        {
            servicios.ActualizarMaterialServicio(Convert.ToInt32(codigoServicio), 
                Convert.ToInt32(codigoMaterial), Convert.ToInt32(materialAnterior), 
                Convert.ToInt32(cantidad));
        }

        //Delete materials services
        public void DeleteMaterialService(string codigoServicio, string codigoMaterial) 
        {
            servicios.EliminarMaterialServicio(Convert.ToInt32(codigoServicio), Convert.ToInt32(codigoMaterial));
        }

        //Delete service
        public void DeleteService(string codigoServicio) 
        {
            servicios.EliminarServicio(Convert.ToInt32(codigoServicio));
        }

        //Delete service by status
        public void DeleteServiceStatus(string codigoServicio) 
        {
            servicios.EliminarServicioEstado(Convert.ToInt32(codigoServicio));
        }

        //Show all services 
        public DataTable ShowServices() 
        {
            DataTable table = new DataTable();
            table = servicios.MostrarServicios();
            return table;
        }

        //Show services name and code
        public DataTable ShowServicesNameCode() 
        {
            DataTable table = new DataTable();
            table = servicios.MostrarNombreCodigoServicios();
            return table;
        }

        //Search service price
        public DataTable SearchServicePrice(string codigoServicio) 
        {
            DataTable table = new DataTable();
            table = servicios.BuscarPrecioServicio(Convert.ToInt32(codigoServicio));
            return table;
        }

        //Show materials services 
        public DataTable ShowMaterialsServices(string codigoServicio) 
        {
            DataTable table = new DataTable();
            table = servicios.MostrarMaterialesServicios(Convert.ToInt32(codigoServicio));
            return table;
        }

        //Search service by code
        public DataTable SearchServiceCode(string codigoServicio) 
        {
            DataTable table = new DataTable();
            table = servicios.BuscarServicioCodigo(Convert.ToInt32(codigoServicio));
            return table;
        }

        //Search service by name
        public DataTable SearchServiceName(string nombreServicio) 
        {
            DataTable table = new DataTable();
            table = servicios.BuscarServicioNombre(nombreServicio);
            return table;
        }

        //Search service by status
        public DataTable SearchServiceStatus(bool estado) 
        {
            DataTable table = new DataTable();
            table = servicios.BuscarServicioEstado(estado);
            return table;
        }
    }
}
