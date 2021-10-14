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
    public partial class FormDetallesServicio : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario

        public FormDetallesServicio()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cerrar el formulario
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //Actualizar materiales del servicio
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormActualizarMaterialesServicio());
        }

        //Agregar Excedente
        private void btnAgregarExcedente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAgregarExcedente());
        }

        //Mover el formulario
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
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
