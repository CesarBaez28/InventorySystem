using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Dominio
{
    public class DominioDirecciones
    {
        DatosDirecciones direcciones = new DatosDirecciones();

        //Show addresses
        public DataTable ShowAddresses()
        {
            DataTable table = new DataTable();
            table = direcciones.MostrarDirecciones();
            return table;        
        }

        //Register addres 
        public DataTable RegisterAddress(string direccion) 
        {
            DataTable table = new DataTable();
            table = direcciones.InsertarDireccion(direccion);
            return table;
        }

    }
}
