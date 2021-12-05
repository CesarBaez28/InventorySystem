using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosMedidas : ExecuteCommandSql
    {
        //Mostrar unidades de medidas
        public DataTable MostrarMedidas() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT codigo, unidad_medida FROM unidades_medidas");
            return table;
        }
    }
}
