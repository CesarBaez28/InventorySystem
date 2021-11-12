using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosServicios : ExecuteCommandSql
    {
        //Registrar nuevo servicio
        public void RegistrarServicio(string nombreServicio, string descripcion, float precio, bool estado) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombre_servicio", nombreServicio));
            parameters.Add(new SqlParameter("@descripcion",descripcion));
            parameters.Add(new SqlParameter("@precio", precio));
            parameters.Add(new SqlParameter("@estado", estado));
            ExecuteNonQuery("p_InsertarServicio");
        }

        //Registrar material que incluye o necesita el servicio
        public void RegistrarMaterialServicio(int codigoMaterial, float cantidad) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            ExecuteNonQuery("p_InsertarServiciosMateriales");
        }

        //Registrar nuevo material que incluye o necesita el servicio
        public void RegistrarNuevoMaterialServicio(int codigoServicio, int codigoMaterial, float cantidad) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            ExecuteNonQuery("p_InsertarNuevoServiciosMateriales");
        }

        //Actualizar servicio 
        public void ActualizarServicio(int codigoServicio, string nombreServicio, 
            float precio, string descripcion, bool estado) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            parameters.Add(new SqlParameter("@nombreServicio", nombreServicio));
            parameters.Add(new SqlParameter("@precio", precio));
            parameters.Add(new SqlParameter("@descripcion", descripcion));
            parameters.Add(new SqlParameter("@estado", estado));
            ExecuteNonQuery("p_ActualizarServicio");
        }

        //Actualizar materiales que incluye o necesita el servicio
        public void ActualizarMaterialesServicio(int codigoServicio, 
            int codigoMaterial, int materialAnterior, int cantidad) 
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            parameters.Add(new SqlParameter("@materialAnterior", materialAnterior));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            ExecuteNonQuery("p_ActualizarMaterialesServicio");
        }

        //Mostrar todos los datos de los servicios
        public DataTable MostrarServicios() 
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT codigo as'Código', nombre_servicio as 'Nombre', " +
                "descripcion as 'Descripción', precio as 'Precio',CASE WHEN estado = 1 THEN 'Activo' " +
                "ELSE 'Inactivo' END AS Estado FROM servicios");
            return table;
        }

        //Mostrar materiales que incluye un servicio
        public DataTable MostrarMaterialesServicios(int codigoServicio) 
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            table = ExecuteReader("p_MostrarMaterialesServicios");
            return table;
        }
    }
}
