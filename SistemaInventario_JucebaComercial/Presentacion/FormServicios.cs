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
    public partial class FormServicios : Form
    {
        public FormServicios()
        {
            InitializeComponent();
        }

        private void FormServicios_Load(object sender, EventArgs e)
        {

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
            AbrirFormulario(agregarServicio);
        }

        //Ver los detalles del servicio
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            FormDetallesServicio agregarServicio = new FormDetallesServicio();

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

            AbrirFormulario(agregarServicio);
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
