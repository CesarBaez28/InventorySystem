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

        //Search materials by code 
        public DataTable SearchMaterialByCode(string codigo) 
        {
            DataTable table = new DataTable();
            table = materiales.BuscarMaterialesCodigo(Convert.ToInt32(codigo));
            return table;
        }

        //Search material by name
        public DataTable SearchMaterialByName(string nombre) 
        {
            DataTable table = new DataTable();
            table = materiales.BuscarMaterialesNombre(nombre);
            return table;
        }

        //Search material by status
        public DataTable SearchMaterialByStatus(bool estado) 
        {
            DataTable table = new DataTable();
            table = materiales.BuscarMaterialesEstado(estado);
            return table;
        }

        //Show type materials
        public DataTable ShowTypeMaterials() 
        {
            DataTable table = new DataTable();
            table = materiales.MostrarTipoMateriales();
            return table;
        }

        //Register material 
        public void RegisterMaterial(string codigo_tipoMaterial, string nombre, string descripcion,
            string costo, string existencia) 
        {
            materiales.RegistrarMaterial(Convert.ToInt32(codigo_tipoMaterial), nombre, 
                descripcion, float.Parse(costo), Convert.ToInt32(existencia));
        }

        //Update Material
        public void UpdateMaterial(string codigoMaterial, string codigo_tipoMaterial, string nombre, string descripcion,
            string costo, string existencia, bool estado) 
        {
            materiales.ActualizarMaterial(Convert.ToInt32(codigoMaterial), 
                Convert.ToInt32(codigo_tipoMaterial), nombre, descripcion, float.Parse(costo), 
                Convert.ToInt32(existencia), estado);
        }

        //Register type material
        public void RegisterTypeMaterial(string nombre) 
        {
            materiales.RegistrarTipoMaterial(nombre);
        }

        //Update type material
        public void UpdateTypeMaterial(string nombre, string nombreNuevo) 
        {
            materiales.ActualizarTipoMaterial(nombre, nombreNuevo);
        }

        //Delete type material (change status to inactive)
        public void DeleteTypeMaterial(string codigo) 
        {
            materiales.EliminarTipoMaterial(Convert.ToInt32(codigo));
        }

        //Register leftover material
        public void RegisterLeftoverMarerial(string tipoMaterial, string codigoMaterial,
            string codigoMedida, string largo, string ancho, string alto, string cantidad, string descripcion) 
        {
            materiales.RegistrarExcenteMaterial(tipoMaterial, Convert.ToInt32(codigoMaterial), 
                Convert.ToInt32(codigoMedida), largo, ancho, alto, Convert.ToInt32(cantidad), 
                descripcion);
        }
    }
}
