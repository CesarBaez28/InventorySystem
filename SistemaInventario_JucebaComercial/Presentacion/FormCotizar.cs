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
    public partial class FormCotizar : Form
    {
        DominioCliente clientes = new DominioCliente();
        DominioServicios servicios = new DominioServicios();

        string precioServicio = ""; //Guardo el precio de los servicios para mostrarlos autimaticamente.

        public static FormCotizar formCotizar;

        public FormCotizar()
        {
            InitializeComponent();
            FormCotizar.formCotizar = this; 
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCotizar_Load(object sender, EventArgs e)
        {
            MostrarClientes();
            MostrarServicios();
        }

        //Mostrar clientes en el combobox
        public void MostrarClientes() 
        {
            comboClientes.ValueMember = "codigo";
            comboClientes.DisplayMember = "nombre";
            comboClientes.DataSource = clientes.ShowCustumerNameCode();
            comboClientes.SelectedIndex = -1;
        }

        //Mostrar servicios en el combobox
        public void MostrarServicios()
        {
            comboServicios.ValueMember = "codigo";
            comboServicios.DisplayMember = "nombre_servicio";
            comboServicios.DataSource = servicios.ShowServicesNameCode();
            comboServicios.SelectedIndex = -1;
        }

        //Muestra el valor del precio del servicio al seleccionar uno.
        private void comboServicios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            precioServicio = servicios.SearchServicePrice(comboServicios.SelectedValue.ToString()).Rows[0]["Precio"].ToString();
            txbMonto.Text = precioServicio;
        }

        //Agregar nuevo cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormDetalleCliente detalleCliente = new FormDetalleCliente();

            detalleCliente.formCotizar = true;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleCliente.lblEstado.Visible = false;
            detalleCliente.cbxEstado.Visible = false;
            detalleCliente.Size = new Size(260, 310);
            detalleCliente.btnAceptar.Location = new Point(15, 232);
            detalleCliente.btnCancelar.Location = new Point(129, 232);

            AbrirFormulario(detalleCliente);
        }

        //Metodo para abirar formularios
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
