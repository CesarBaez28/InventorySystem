using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Comun;

namespace Datos
{
    public class DatosSalidas : ExecuteCommandSql
    {
        //Obtengo el código de la última salida ingresada
        public DataTable ObtenerCodigoSalida() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT MAX(codigo) as 'codigo' FROM salidas");
            return table;
        }
         
        //Registrar salida del inventario 
        public void RegistrarSalida(DateTime fecha) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@fechaSalida", fecha));
            ExecuteNonQuery("p_RegistrarSalida");
        }

        //Elimina la última salida insertada
        public void EliminarSalida() 
        {
            ExecuteNonQuery("p_EliminarUltimaSalida");
        }

        //Registrar multiples salidas 
        public void MultiplesSalidas(IEnumerable<DetallesSalida> detallesSalida) 
        {
            var table = new DataTable();
            table.Columns.Add("codigo_salida", typeof(int));
            table.Columns.Add("codigo_cliente", typeof(int));
            table.Columns.Add("codigo_usuario", typeof(int));
            table.Columns.Add("codigo_servicio", typeof(int));
            table.Columns.Add("precio", typeof(float));
            table.Columns.Add("cantidad", typeof(int));

            foreach (var itemDetalle in detallesSalida) 
            {
                table.Rows.Add(new object[]
                {
                    itemDetalle.codigo_salida,
                    itemDetalle.codigo_cliente,
                    itemDetalle.codigo_usuario,
                    itemDetalle.codigo_servicio,
                    itemDetalle.precio,
                    itemDetalle.cantidad
                });
            }

            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoSalida", SqlDbType.Int));
            parameters.Add(new SqlParameter("@codigoCliente", SqlDbType.Int));
            parameters.Add(new SqlParameter("@codigoUsuario", SqlDbType.Int));
            parameters.Add(new SqlParameter("@codigoServicio", SqlDbType.Int));
            parameters.Add(new SqlParameter("@precio", SqlDbType.Float));
            parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int));

            try
            {
                ExecuteMultipleNonQuery("INSERT INTO detalles_salida(codigo_salida, " +
                    "codigo_cliente, codigo_usuario, codigo_servicio, precio, cantidad)" +
                    "VALUES(@codigoSalida, @codigoCliente, @codigoUsuario, @codigoServicio, " +
                    "@precio, @cantidad)", table);
            }
            catch 
            {
                EliminarSalida();
                throw;
            }
        }
    }
}
