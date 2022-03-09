using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos.SqlServer;

namespace Dominio
{
    public class DominioCotizaciones
    {
        DatosCotizaciones cotizar = new DatosCotizaciones();

        //Register Quote
        public void RegisterQuote(DateTime fechaCotizacion, string descripcion) 
        { 
            cotizar.RegistrarCotizacion(fechaCotizacion, descripcion);
        }

        //Register Details Quote
        public void RegisterDetailsQuote(string codigoUsuario, string codigoServicio, string codigoCliente,
            string cantidad, string precio) 
        {
            cotizar.RegistrarDetallesCotizacion(Convert.ToInt32(codigoUsuario), 
                Convert.ToInt32(codigoServicio), Convert.ToInt32(codigoCliente), 
                Convert.ToInt32(cantidad), float.Parse(precio));
        }

        //Get quote code 
        public DataTable GetQuoteCode() 
        {
            DataTable table = new DataTable();
            table = cotizar.ObtenerCodigoCotizacion();
            return table;
        }

        //Update status Quote 
        public void ApproveQuote(string codigo) 
        {
            cotizar.AprobarCotizacion(Convert.ToInt32(codigo));
        }

        //Delete quote 
        public void DeleteQuote(string codigo) 
        {
            cotizar.EliminarCotizacion(Convert.ToInt32(codigo));
        }

        //Delete details quote 
        public void DeleteDetailsQuote(string codigo) 
        {
            cotizar.EliminarDetallesCotización(Convert.ToInt32(codigo));
        }
    }
}
