using System.Collections.Generic;
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
            parameters.Add(new SqlParameter("@descripcion", descripcion));
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
        public void ActualizarMaterialServicio(int codigoServicio,
            int codigoMaterial, int materialAnterior, int cantidad)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            parameters.Add(new SqlParameter("@materialAnterior", materialAnterior));
            parameters.Add(new SqlParameter("@cantidad", cantidad));
            ExecuteNonQuery("p_ActualizarMaterialesServicio");
        }

        //Eliminar materiales que incluye o necesita el servicio
        public void EliminarMaterialServicio(int codigoServicio, int codigoMaterial)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            parameters.Add(new SqlParameter("@codigoMaterial", codigoMaterial));
            ExecuteNonQuery("p_EliminarMaterialesServicio");
        }

        //Eliminar Servicio
        public void EliminarServicio(int codigoServicio)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            ExecuteNonQuery("p_EliminarServicio");
        }

        //Eliminar servicio por estado (cambia de activo a inactivo)
        public void EliminarServicioEstado(int codigoServicio)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            ExecuteNonQuery("p_EliminarServicioEstado");
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

        //Mostrar nombre y código de los servicios
        public DataTable MostrarNombreCodigoServicios()
        {
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT codigo, nombre_servicio FROM servicios WHERE estado = 1");
            return table;
        }

        //Buscar precio de un servicio por su código
        public DataTable BuscarPrecioServicio(int codigoServicio)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigoServicio", codigoServicio));
            DataTable table = new DataTable();
            table = ExecuteReaderText("SELECT precio FROM servicios WHERE codigo = @codigoServicio");
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

        //Buscar servicio por codigo
        public DataTable BuscarServicioCodigo(int codigoServicio)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@codigo", codigoServicio));
            table = ExecuteReader("p_BuscarServicioCodigo");
            return table;
        }

        //Buscar servicio por nombre 
        public DataTable BuscarServicioNombre(string nombreServicio)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@nombreServicio", nombreServicio));
            table = ExecuteReader("p_BuscarServicioNombre");
            return table;
        }

        //Buscar servicio por estado
        public DataTable BuscarServicioEstado(bool estado)
        {
            DataTable table = new DataTable();
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@estado", estado));
            table = ExecuteReader("p_BuscarServicioEstado");
            return table;
        }
    }
}
