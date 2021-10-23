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
    public partial class FormClientes : Form
    {
        DominioCliente cliente = new DominioCliente();
        int parseCorrecto; // La uso para vereficar que al momento de buscar un usuario el codigo sea un numero entero.
        bool estadoCliente = true; // La uso para mostrar los cleintes por estado (activos o inactivos)

        public FormClientes()
        {
            InitializeComponent();
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento cargar del formulario
        private void FormClientes_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        //Mostrar clientes 
        public void MostrarClientes() 
        {
            DominioCliente cliente = new DominioCliente();
            gridViewListaClientes.DataSource = cliente.ShowCostumersByStatus(estadoCliente);
        }

        //Agregar cliente
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetalleCliente detalleCliente = new FormDetalleCliente();
            //detalleCliente.UpdateEventHendler += ActualizarEventHandler;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleCliente.lblEstado.Visible = false;
            detalleCliente.cbxEstado.Visible = false;
            detalleCliente.Size = new Size(260, 310);
            detalleCliente.btnAceptar.Location = new Point(15, 232);
            detalleCliente.btnCancelar.Location = new Point(129, 232);

            AbrirDetalleCliente(detalleCliente);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FormDetalleCliente detalleCliente = new FormDetalleCliente();
            AbrirDetalleCliente(detalleCliente);
        }

        //Funcionalidad del bonton Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DominioCliente cliente = new DominioCliente();

            //Buscar por codigo
            if (comboBuscar.SelectedIndex == 0)
            {
                if (txbBuscar.Text != "")
                {
                    if (int.TryParse(txbBuscar.Text, out parseCorrecto))
                    {
                        gridViewListaClientes.DataSource = cliente.ShowCostumerByCode(txbBuscar.Text);
                        txbBuscar.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Código no valido");
                    }
                }
                else
                {
                    MessageBox.Show("El campo esta vacío");
                }
            }
            ///Buscar por el nombre del cliente
            else if (comboBuscar.SelectedIndex == 1)
            {
                if (txbBuscar.Text != "")
                {
                    gridViewListaClientes.DataSource = cliente.ShowCostumersByName(txbBuscar.Text);
                    txbBuscar.Text = "";
                }
                else
                {
                    MessageBox.Show("El campo esta vacío");
                }
            }
            //Buscar clientes activos
            else if (comboBuscar.SelectedIndex == 2)
            {
                estadoCliente = true;
                gridViewListaClientes.DataSource = cliente.ShowCostumersByStatus(estadoCliente);
            }
            //Buscar clientes inactivos
            else if (comboBuscar.SelectedIndex == 3)
            {
                estadoCliente = false;
                gridViewListaClientes.DataSource = cliente.ShowCostumersByStatus(estadoCliente);
            }
            //Mostrar todos los clientes
            else 
            {
                gridViewListaClientes.DataSource = cliente.ShowCostumers();
            }
        }

        //Metodo para abirar el formulario DetalleCliente
        private Form formActivo = null;
        private void AbrirDetalleCliente(Form form)
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
