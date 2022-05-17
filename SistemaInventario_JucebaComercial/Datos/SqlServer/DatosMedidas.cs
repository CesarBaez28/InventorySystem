using System.Data;

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
