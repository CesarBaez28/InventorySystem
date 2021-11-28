using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Comun;

namespace Datos
{
    public abstract class ExecuteCommandSql : ConnectionSql
    {
        protected List<SqlParameter> parameters;

        //Ejecutar comando de no consultas con procedimiento almacenado
        protected int ExecuteNonQuery(string commandSql) 
         {
            using (var conexion = GetConnection()) 
            {
                conexion.Open();

                using (var comando = new SqlCommand(commandSql, conexion)) 
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    //Verifico si se utilizaron parametros para la consulta
                    if (parameters != null) 
                    {
                        foreach (SqlParameter item in parameters)
                        {
                            comando.Parameters.Add(item);
                        }
                    }

                    int result = comando.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        }

        //Ejecutar multiples comandos de no consulta
        protected void ExecuteMultipleNonQuery(string commandSql, DataTable table) 
        {
            using (var conexion = GetConnection()) 
            {
                conexion.Open();

                using (SqlTransaction transaction = conexion.BeginTransaction()) 
                {
                    using (var comando = new SqlCommand(commandSql, conexion)) 
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Transaction = transaction;

                        foreach (SqlParameter item in parameters)
                        {
                            comando.Parameters.Add(item);
                        }
                        
                        try
                        {
                            for (int fila = 0; fila < table.Rows.Count; fila++)
                            {
                                for (int columna = 0; columna < table.Columns.Count; columna++)
                                {
                                    parameters[columna].Value = table.Rows[fila][columna];
                                }

                                comando.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            parameters.Clear();
                        }
                        catch(Exception) 
                        {
                            transaction.Rollback();
                            parameters.Clear();
                            throw;
                        }
                    }
                }
            }
        }

        //Ejecutar comando para consultas
        protected DataTable ExecuteReader(string commandSql) 
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

        //Ejecutar comando para consultas sin procedimiento alamacenado
        protected DataTable ExecuteReaderText(string commandSql)
        {
            DataTable table = new DataTable();

            using (var conexion = GetConnection())
            {
                conexion.Open();

                using (var comando = new SqlCommand(commandSql, conexion))
                {
                    comando.CommandType = CommandType.Text;

                    //Verifico si se utilizaron parametros para la consulta
                    if (parameters != null)
                        foreach (SqlParameter item in parameters)
                            comando.Parameters.Add(item);

                    using (var Reader = comando.ExecuteReader())
                    {
                        table.Load(Reader);
                        if (parameters != null)
                            parameters.Clear();
                        return table;
                    }
                }
            }
        }
    }
}
