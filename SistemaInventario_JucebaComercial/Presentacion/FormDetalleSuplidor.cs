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
    public partial class FormDetalleSuplidor : Form
    {
        int posX, posY;
        public bool actualizar = false;
        public string codigo;
        bool estadoCliente;

        public FormDetalleSuplidor()
        {
            InitializeComponent();
        }

        public delegate void ActualizarDelagate(object sender, UpdateEventArgs args);
        public event ActualizarDelagate UpdateEventHendler;

        public class UpdateEventArgs : EventArgs
        {
            public string Datos { get; set; }
        }

        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHendler.Invoke(this, args);
        }

        // Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            //Insertar cliente
            if (actualizar == false)
            {
                //Valido que por lo menos el campo nombre no esté vacío
                if (txbNombre.Text != "")
                {
                    MessageBox.Show("Se insertó correctamente");
                    VaciarCampos();
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("Ingrese el nombre del cliente");
                }
            }
            //Actualizar cliente
            else 
            {
                if (cbxEstado.Text == "Activo")
                {
                    estadoCliente = true;
                }
                else 
                {
                    estadoCliente = false;
                }

                MessageBox.Show("Se actualizó correctamente");
                VaciarCampos();
                Actualizar();
            }
        }

        public void VaciarCampos() 
        {
            txbNombre.Text = "";
            txbDireccion.Text = "";
            txbTelefono.Text = "";
        }

        //Funcionalidad para mover el formulario
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
    }
}
