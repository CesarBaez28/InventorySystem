﻿using System;
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
    }
}
