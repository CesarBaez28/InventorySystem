﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class FormServicios : Form
    {
        //La uso para actualizar la lista de servicios al ingresar o actualizar uno
        public static FormServicios formServicios;

        DominioServicios servicios = new DominioServicios();

        int parseCorrecto;//La uso para validar que el código del servicio se ha entero

        public FormServicios()
        {
            InitializeComponent();
            FormServicios.formServicios = this;
        }

        private void FormServicios_Load(object sender, EventArgs e)
        {
            MostrarServicios();
        }

        //Mostrar servicios 
        public void MostrarServicios() 
        {
            DominioServicios servicios = new DominioServicios();
            gridViewListaServicios.DataSource = servicios.ShowServices();
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Agregar nuevo servicio
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetallesServicio agregarServicio = new FormDetallesServicio();
            //agregarServicio.btnActualizar.Visible = false;
            //agregarServicio.btnEliminar.Location = new Point(14,389);
            agregarServicio.btnAgregarExcedente.Visible = false;

            AbrirFormulario(agregarServicio);
        }

        //Actualizar servicio
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FormDetallesServicio agregarServicio = new FormDetallesServicio();
            agregarServicio.btnAgregarExcedente.Visible = false;
            agregarServicio.codigoServicio = gridViewListaServicios.CurrentRow.Cells["Código"].Value.ToString();
            agregarServicio.txbNombreServicio.Text = gridViewListaServicios.CurrentRow.Cells["Nombre"].Value.ToString();
            agregarServicio.txbDescripcionServicio.Text = gridViewListaServicios.CurrentRow.Cells["Descripción"].Value.ToString();
            agregarServicio.txbPrecio.Text = gridViewListaServicios.CurrentRow.Cells["Precio"].Value.ToString();
            agregarServicio.cbxEstado.Text = gridViewListaServicios.CurrentRow.Cells["Estado"].Value.ToString();
            agregarServicio.gridViewMateriales.Columns.Clear();
            agregarServicio.actualizar = true;

            AbrirFormulario(agregarServicio);
        }

        //Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewListaServicios.SelectedRows.Count > 0)
            {
                servicios.DeleteService(gridViewListaServicios.CurrentRow.Cells["Código"].Value.ToString());
                MessageBox.Show("Se eliminó correctamente");
                MostrarServicios();
            }
            else 
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        //Ver los detalles del servicio
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            FormDetallesServicio agregarServicio = new FormDetallesServicio();

            agregarServicio.codigoServicio = gridViewListaServicios.CurrentRow.Cells["Código"].Value.ToString();
            agregarServicio.txbNombreServicio.Text = gridViewListaServicios.CurrentRow.Cells["Nombre"].Value.ToString();
            agregarServicio.txbDescripcionServicio.Text = gridViewListaServicios.CurrentRow.Cells["Descripción"].Value.ToString();
            agregarServicio.txbPrecio.Text = gridViewListaServicios.CurrentRow.Cells["Precio"].Value.ToString();
            agregarServicio.cbxEstado.Text = gridViewListaServicios.CurrentRow.Cells["Estado"].Value.ToString();

            agregarServicio.gridViewMateriales.Columns.Clear();
            agregarServicio.actualizar = true;
            agregarServicio.btnAgregarExcedente.Visible = false;

            agregarServicio.gridViewMateriales.Location = new Point(14,49);
            agregarServicio.gridViewMateriales.Size = new Size(687,369);

            agregarServicio.lblMaterial.Visible = false;
            agregarServicio.lblCantidad.Visible = false;
            agregarServicio.comboMaterial.Visible = false;
            agregarServicio.txbCantidad.Visible = false;
            agregarServicio.btnAgregar.Visible = false;
            agregarServicio.btnActualizar.Visible = false;
            agregarServicio.btnEliminar.Visible = false;
            agregarServicio.btnTerminar.Visible = false;
            agregarServicio.lineShape1.Visible = false;
            agregarServicio.btnAgregarMaterial.Visible = false;

            AbrirFormulario(agregarServicio);
        }

        //Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Buscar por código
            if (comboBuscar.SelectedIndex == 0)
            {
                //Valido que el código se ha correcto
                if (int.TryParse(txbBuscar.Text, out parseCorrecto))
                {
                    gridViewListaServicios.DataSource = servicios.SearchServiceCode(txbBuscar.Text);
                    txbBuscar.Text = "";
                }
            }
            //Buscar por nombre
            else if (comboBuscar.SelectedIndex == 1)
            {

            }
            //Buscar servicios activos
            else if (comboBuscar.SelectedIndex == 2)
            {

            }
            //Buscar servicios inactivos
            else if (comboBuscar.SelectedIndex == 3)
            {

            }
            //Buscar todos los servicios (activos e inactivos)
            else if(comboBuscar.SelectedIndex == 4)
            {
            
            }
        }

        //Metodo para abir formulario
        private Form formActivo = null;
        private void AbrirFormulario(Form form)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }
    }
}
