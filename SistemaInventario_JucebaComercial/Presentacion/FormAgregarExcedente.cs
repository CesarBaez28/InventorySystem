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
    public partial class FormAgregarExcedente : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario

        public FormAgregarExcedente()
        {
            InitializeComponent();
        }

        //Mover el formulario
        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //AbrirFormulario(new FormDetallesExcedente());
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo para abirar formularios 
        private Form formActivo = null;

        private void FormAgregarExcedente_Load(object sender, EventArgs e)
        {

        }

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
