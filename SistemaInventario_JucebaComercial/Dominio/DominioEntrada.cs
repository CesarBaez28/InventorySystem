using Datos;
using System;

namespace Dominio
{
    public class DominioEntrada
    {
        DatosEntradas entrada = new DatosEntradas();

        //Register entry to inventory
        public void RegisterEntry(DateTime fechaEntrada)
        {
            entrada.RegistrarEntrada(fechaEntrada);
        }

        //Register detail entry to inventory
        public void RegisterDetailsEntry(string codigoUsuario, string suplidor,
             string material, string cantidad, string costo)
        {
            entrada.RegistrarDetalleEntrada(Convert.ToInt32(codigoUsuario), suplidor,
                 material, Convert.ToInt32(cantidad), float.Parse(costo));
        }
    }
}
