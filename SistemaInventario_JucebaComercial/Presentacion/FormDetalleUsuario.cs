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
    public partial class FormDetalleUsuario : Form
    {
        int posX, posY;//Las uso para obtener la posicion del formulario
        public bool actualizar = false; // La uso para actualizar o insertar dependiendo de su estado
        public string codigo; // La uso para guardar el codigo del registro seleccionado 
        bool estadoUsuario; // Lo uso para indicar el estado del usuario (activo o inactivo)
        public string tipoUsuario; ///La utilizo para guardar el texto del tipo de usuario seleccionado en el datagridView


        public FormDetalleUsuario(FormEmpleados formEmpleados)
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

        // Cierra el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDetalleUsuario_Load(object sender, EventArgs e)
        {
            llenarCombobox();

            if (actualizar == true) 
            {
                cbxTiposUsuarios.Text = tipoUsuario;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Insertar
            if (actualizar == false)
            {
                //confirmo que los campos obligatorios estén llenos
                if (txbNombre.Text != "" && txbNombreUsuario.Text != "" && txbPassword.Text != "" &&
                    txbConfirmarPassword.Text != "")
                {
                    // confirmo que las contraseñas estén correctas
                    if (txbConfirmarPassword.Text == txbPassword.Text)
                    {

                        //MessageBox.Show("Se insertó correctamente");
                        vaciarTexboxs();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan campos obligatorios por llenar.");
                }
            }

            //Actualizar
            else 
            {
                // confirmo que las contraseñas estén correctas
                if (txbConfirmarPassword.Text == txbPassword.Text && txbPassword.Text != "")
                {

                    if (cbxEstado.Text == "Activo")
                    {
                        estadoUsuario = true;


                    }
                    else 
                    {
                        estadoUsuario = false;

                    }

                    MessageBox.Show("Se actualizó correctamente");
                    vaciarTexboxs();
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden o faltan campos por llenar");
                }
            }
        }

        //llenar el combobox con los tipos de usuarios
        public void llenarCombobox()
        {
            cbxTiposUsuarios.ValueMember = "codigo";
            cbxTiposUsuarios.DisplayMember = "tipoUsuario";
            //cbxTiposUsuarios.DataSource = usuario.llenarCombobox();
        }

        // vaciar los campos
        public void vaciarTexboxs() 
        {
            txbConfirmarPassword.Text = "";
            txbEmail.Text = "";
            txbNombre.Text = "";
            txbNombreUsuario.Text = "";
            txbPassword.Text = "";
        }
    }
}
