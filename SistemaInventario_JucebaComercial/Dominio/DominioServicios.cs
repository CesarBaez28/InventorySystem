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
            servicios.ActualizarMaterialesServicio(Convert.ToInt32(codigoServicio), 
                Convert.ToInt32(codigoMaterial), Convert.ToInt32(materialAnterior), 
                Convert.ToInt32(cantidad));
        }

        //Show all services 
        public DataTable ShowServices() 
        {
            DataTable table = new DataTable();
            table = servicios.MostrarServicios();
            return table;
        }

        //Show materials services 
        public DataTable ShowMaterialsServices(string codigoServicio) 
        {
            DataTable table = new DataTable();
            table = servicios.MostrarMaterialesServicios(Convert.ToInt32(codigoServicio));
            return table;
        }
    }
}
