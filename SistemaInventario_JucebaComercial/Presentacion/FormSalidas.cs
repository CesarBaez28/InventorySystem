using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormSalidas : Form
    {
        public FormSalidas()
        {
            InitializeComponent();
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelContedorIngresos_Paint(object sender, PaintEventArgs e)
        {

        }

        //Agregar cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
           // FormDetalleCliente detalleCliente = new FormDetalleCliente();
            //detalleCliente.UpdateEventHendler += ActualizarEventHandler;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            //detalleCliente.lblEstado.Visible = false;
            //detalleCliente.cbxEstado.Visible = false;
            //detalleCliente.Size = new Size(260, 310);
            //detalleCliente.btnAceptar.Location = new Point(15, 232);
            //detalleCliente.btnCancelar.Location = new Point(129, 232);

            //AbrirFormulario(detalleCliente);
        }

        //Ver detalles del servicio
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            FormDetallesServicio detallesServicio = new FormDetallesServicio();
            AbrirFormulario(detallesServicio);
        }

        //Metodo para abirar el formulario DetalleSuplidor
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
