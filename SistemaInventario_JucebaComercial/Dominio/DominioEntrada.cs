using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Dominio
{
    public class DominioEntrada
    {
        DatosEntradas entrada = new DatosEntradas();

        //Register entry to inventory
        public void RegisterEntry(DateTime fechaEntada, string codigoUsuario, string suplidor,
            string tipoMaterial, string material, string cantidad, string costo) 
        {
            entrada.RegistrarEntrada(fechaEntada, Convert.ToInt32(codigoUsuario), suplidor,
                tipoMaterial, material, Convert.ToInt32(cantidad), float.Parse(costo));
        }
    }
}
