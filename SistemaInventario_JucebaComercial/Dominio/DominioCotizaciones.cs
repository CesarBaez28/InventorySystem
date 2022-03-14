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

        //Register Details Quote new
        public void RegisterDetailsQuoteNew(string codigoCotizacion, string codigoUsuario, string servicio, string codigoCliente,
            string cantidad, string precio)
        {
            cotizar.RegistrarNuevosDetallesCotizacion(Convert.ToInt32(codigoCotizacion), 
                Convert.ToInt32(codigoUsuario), servicio, 
                Convert.ToInt32(codigoCliente),Convert.ToInt32(cantidad), float.Parse(precio));
        }

        //Update Quote
        public void UpdateQuote(string codigoCotizacion, DateTime fecha, string descripcion) 
        {
            cotizar.EditarCotizacion(Convert.ToInt32(codigoCotizacion), fecha, descripcion);
        }

        //Update details Quote 
        public void UpdateDetailsQuote(string codigoDetalleCotizacion, string servicio, string codigoCliente, string codigoUsuario, string precio, string cantidad) 
        {
            cotizar.EditarDetallesCotizaion(Convert.ToInt32(codigoDetalleCotizacion), 
                                            servicio, 
                                            Convert.ToInt32(codigoCliente), 
                                            Convert.ToInt32(codigoUsuario), 
                                            float.Parse(precio),
                                            Convert.ToInt32(cantidad));
        }

        //Get quote code 
        public DataTable GetQuoteCode() 
        {
            DataTable table = new DataTable();
            table = cotizar.ObtenerCodigoCotizacion();
            return table;
        }

        //Get details quote codes
        public DataTable GetDetailsQuoteCodes(string codigoCotizacion) 
        {
            DataTable table = new DataTable();
            table = cotizar.ObtenenerDetallesCotizacionCodigos(Convert.ToInt32(codigoCotizacion));
            return table;
        }

        //Update status Quote 
        public void ApproveQuote(string codigo, bool estado) 
        {
            cotizar.AprobarCotizacion(Convert.ToInt32(codigo), estado);
        }

        //Delete quote 
        public void DeleteQuote(string codigo) 
        {
            cotizar.EliminarCotizacion(Convert.ToInt32(codigo));
        }

        //Delete details quote 
        public void DeleteDetailsQuote(string codigo) 
        {
            cotizar.EliminarDetallesCotizacion(Convert.ToInt32(codigo));
        }

        //Delete details quote by code
        public void DeleteDetailsQuoteByCode(string codigo)
        {
            cotizar.EliminarDetallesCotizacionPorCodigo(Convert.ToInt32(codigo));
        }
    }
}
