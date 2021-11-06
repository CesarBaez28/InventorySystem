using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Dominio
{
    public class DominioMateriales
    {
        DatosMateriales materiales = new DatosMateriales();

        //Show all materials
        public DataTable ShowMaterials() 
        {
            DataTable table = new DataTable();
            table = materiales.MostrarMateriales();
            return table;
        }
    }
}
