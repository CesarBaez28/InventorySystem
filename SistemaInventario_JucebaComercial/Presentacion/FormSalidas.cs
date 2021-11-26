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
    public partial class FormSalidas : Form
    {
        DominioServicios servicios = new DominioServicios();
        DominioCliente clientes = new DominioCliente();

        public static FormSalidas formSalidas;

        public FormSalidas()
        {
            InitializeComponent();
            FormSalidas.formSalidas = this;
        }

        private void FormSalidas_Load(object sender, EventArgs e)
        {
            MostrarServicios();
            MostrarClientes();
        }

        //Mostrar servicios en el combobox
        public void MostrarServicios() 
        {
            comboServicios.ValueMember = "codigo";
            comboServicios.DisplayMember = "nombre_servicio";
            comboServicios.DataSource = servicios.ShowServicesNameCode();
        }

        //Mostrar Clientes
        public void MostrarClientes() 
        {
            comboClientes.ValueMember = "codigo";
            comboClientes.DisplayMember = "nombre";
            comboClientes.DataSource = clientes.ShowCustumerNameCode();
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Agregar cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormDetalleCliente detalleCliente = new FormDetalleCliente();

            detalleCliente.formSalida = true;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleCliente.lblEstado.Visible = false;
            detalleCliente.cbxEstado.Visible = false;
            detalleCliente.Size = new Size(260, 310);
            detalleCliente.btnAceptar.Location = new Point(15, 232);
            detalleCliente.btnCancelar.Location = new Point(129, 232);

            AbrirFormulario(detalleCliente);
        }

        //Agregar servicio
        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            FormDetallesServicio detallesServicio = new FormDetallesServicio();

            //Oculto el botón para agregar excedentes del formulario
            detallesServicio.btnAgregarExcedente.Visible = false;

            //Indico que este formulario (FormSalidas) abrió el FormDetallesServicio
            detallesServicio.formSalidas = true;

            AbrirFormulario(detallesServicio);
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
