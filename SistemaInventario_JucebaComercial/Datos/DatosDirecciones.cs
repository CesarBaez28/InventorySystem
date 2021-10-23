using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class DatosDirecciones : ExecuteCommandSql
    {
        //Mostrar todos las Direcciones de sistema
        public DataTable MostrarDirecciones() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("select codigo, dirrecion from dirreciones");
            return table;
        }
    }
}
