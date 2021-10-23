using System;
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

        public void MostrarClientes() 
        {
            DominioCliente cliente = new DominioCliente();
            gridViewListaClientes.DataSource = cliente.ShowClients();
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
