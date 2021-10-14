using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public abstract class ExecuteCommandSql : ConnectionSql
    {
        protected List<SqlParameter> parameters;

        //Ejecutar comando de no consultas
        protected int ExecuteNonQuery(string commandSql) 
        {
            using (var conexion = GetConnection()) 
            {
                conexion.Open();

                using (var comando = new SqlCommand(commandSql, conexion)) 
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter item in parameters) 
                    {
                        comando.Parameters.Add(item);
                    }

                    int result = comando.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }

        //Ejecutar comando para consultas
        protected DataTable ExcuteReader(string commandSql) 
        {
            DataTable table = new DataTable();

            using (var conexion = GetConnection()) 
            {
                conexion.Open();

                using (var comando = new SqlCommand(commandSql, conexion)) 
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    //Verifico si se utilizaron parametros para la consulta
                    if (parameters != null) 
                        foreach (SqlParameter item in parameters)
                            comando.Parameters.Add(item);
                        
                    using (var Reader = comando.ExecuteReader()) 
                    {
                        table.Load(Reader);
                        if (parameters !=  null)
                          parameters.Clear();
                        return table;
                    }
                }
            }
        }
    }
}
