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
        float total = 0; //Guardo el total de la cotización.
        bool yaRegistrado = false; // La uso para validar que no se ingrese un servicio repetido.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer servicio, verificar si este u otros se agregan repetidos.

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

        //Registrar nuevo servicio
        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            FormDetallesServicio detallesServicio = new FormDetallesServicio();

            //Indico que este formulario (FormSalidas) abrió el FormDetallesServicio
            detallesServicio.formCotizar = true;

            AbrirFormulario(detallesServicio);
        }

        //Agregar salida a la lista
        private void AgregarSalida()
        {
            int indice = gridViewCotizaciones.Rows.Add();
            float total_servicio = Convert.ToInt32(txbCantidad.Text) * float.Parse(txbMonto.Text); //Total del servicio

            //Agrego los datos a la lista
            //gridViewSalidas.Rows[indice].Cells["codigoCliente"].Value = comboClientes.SelectedValue.ToString();
            //gridViewSalidas.Rows[indice].Cells["Cliente"].Value = comboClientes.Text;
            gridViewCotizaciones.Rows[indice].Cells["codigoServicio"].Value = comboServicios.SelectedValue.ToString();
            gridViewCotizaciones.Rows[indice].Cells["Servicio"].Value = comboServicios.Text;
            gridViewCotizaciones.Rows[indice].Cells["Monto"].Value = txbMonto.Text;
            gridViewCotizaciones.Rows[indice].Cells["Cantidad"].Value = txbCantidad.Text;
            gridViewCotizaciones.Rows[indice].Cells["Total_Salida"].Value = total_servicio.ToString();

            //Total de la salida
            total += total_servicio;
            lblTotalSalida.Text = "Total: " + total.ToString();
        }

        // Botón agregar salida a la lista.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verifico que el monto y la cantidad se han números válidos.
            //Y que el combobox de servicios tenga un elemento seleccionado.
            if (float.TryParse(txbMonto.Text, out float parseCorrecto) && int.TryParse(txbCantidad.Text, out int parse) && comboServicios.SelectedIndex != -1)
            {
                if (primerRegistro == false)
                {
                    AgregarSalida();
                    primerRegistro = true;
                }
                else
                {
                    //Verifico que el servicio no esté repetido 
                    foreach (DataGridViewRow fila in gridViewCotizaciones.Rows)
                    {
                        if (fila.Cells["Servicio"].Value.ToString() == comboServicios.Text)
                        {
                            yaRegistrado = true;
                            break;
                        }
                    }

                    //Si no está repetido, agrega la salida. De lo contrario, arroja un mensaje de error.
                    if (yaRegistrado != true)
                    {
                        AgregarSalida();
                    }
                    else
                    {
                        MessageBox.Show("Ya ingresó ese servicio");
                        yaRegistrado = false;
                    }
                }

                txbMonto.Text = "";
                txbCantidad.Text = "";
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar o ingresó un valor de manera incorrecta");
            }
        }

        //Eliminar servicio de la lista
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewCotizaciones.SelectedRows.Count > 0)
            {
                //Actualizo el total de la salida
                total = total - (float.Parse(gridViewCotizaciones.CurrentRow.Cells["Total_Salida"].Value.ToString()));
                lblTotalSalida.Text = "Total: " + total.ToString();

                gridViewCotizaciones.Rows.Remove(gridViewCotizaciones.CurrentRow);
            }
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
