using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosEntradas : ExecuteCommandSql
    {
        //Registrar entrada al inventario
        public void RegistrarEntrada(DateTime fechaEntada, int codigoUsuario, string suplidor, 
            string tipoMaterial, string material, int cantidad, float costo) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechaEntrada", fechaEntada));
            parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
            parameters.Add(new SqlParameter("@suplidor", suplidor));
            parameters.Add(new SqlParameter("@tipoMaterial", tipoMaterial));
            parameters.Add(new SqlParameter("@material", material));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            parameters.Add(new SqlParameter("@costo", costo));
            ExecuteNonQuery("p_RegistrarEntrada");
        }
    }
}
