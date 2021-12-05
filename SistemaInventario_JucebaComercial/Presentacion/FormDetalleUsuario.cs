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
    public partial class FormDetalleUsuario : Form
    {
        int posX, posY;//Las uso para obtener la posicion del formulario.
        public bool actualizar = false; // La uso para actualizar o insertar dependiendo de su estado.
        public string codigo; // La uso para guardar el codigo del registro seleccionado.
        bool estadoUsuario; // Lo uso para indicar el estado del usuario (activo o inactivo).
        public string tipoUsuario; ///La utilizo para guardar el texto del tipo de usuario seleccionado en el datagridView.
        DominioUsuario usuario = new DominioUsuario();

        public FormDetalleUsuario(FormEmpleados formEmpleados)
        {
            InitializeComponent();
        }

        // Cierra el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void ActualizarDelagate(object sender, UpdateEventArgs args);
        public event ActualizarDelagate UpdateEventHendler;

        public class UpdateEventArgs : EventArgs 
        {
            public string Datos { get; set; }
        }

        //Actuarlizar la lista de empleados al insertar o actualizar.
        protected void Actualizar() 
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHendler.Invoke(this, args);
        }

        private void FormDetalleUsuario_Load(object sender, EventArgs e)
        {
            //Llleno el combobox con los tipos de usuarios del sistema.
            llenarCombobox();

            if (actualizar == true) 
            {
                cbxTiposUsuarios.Text = tipoUsuario;
            }
        }

        //Funcionalidad boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DominioUsuario usuario = new DominioUsuario();

            //confirmo que los campos obligatorios estén llenos
            if (txbNombre.Text != "" && txbNombreUsuario.Text != "" && txbPassword.Text != "" &&
                    txbConfirmarPassword.Text != "")
            {
                // confirmo que las contraseñas estén correctas
                if (txbConfirmarPassword.Text == txbPassword.Text)
                {
                    //Confirmo que las contraseñas tenga al menos 5 caracteres
                    if (txbPassword.Text.Length >= 5)
                    {
                        //Insertar
                        if (actualizar == false)
                        {
                            try
                            {
                                usuario.RegisterUser(cbxTiposUsuarios.SelectedValue.ToString(),
                                    txbNombreUsuario.Text, txbNombre.Text, txbPassword.Text, txbEmail.Text);
                                MessageBox.Show("Se insertó correctamente.");
                                //vaciarTexboxs();
                                Actualizar();
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Ya existe un usuario con ese nombre.");
                            }
                        }
                        //Actualizar
                        else
                        {
                            try
                            {
                                //Activo
                                if (cbxEstado.SelectedIndex == 0)
                                {
                                    estadoUsuario = true;
                                    usuario.UpdateUser(cbxTiposUsuarios.SelectedValue.ToString(),
                                        txbNombreUsuario.Text, txbNombre.Text, txbPassword.Text, txbEmail.Text,
                                        estadoUsuario, codigo);
                                }
                                //Inactivo
                                else
                                {
                                    estadoUsuario = false;
                                    usuario.UpdateUser(cbxTiposUsuarios.SelectedValue.ToString(),
                                        txbNombreUsuario.Text, txbNombre.Text, txbPassword.Text, txbEmail.Text,
                                        estadoUsuario, codigo);
                                }

                                MessageBox.Show("Se actualizó correctamente.");
                                // vaciarTexboxs();
                                Actualizar();
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Ya existe un usuario con ese nombre.");
                            }
                        }
                    }
                    else 
                    {
                        MessageBox.Show("La contraseña debe tener al menos 5 caracteres.");
                    }
                }
                else 
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                }
            }
            else 
            {
                MessageBox.Show("Faltan campos por llenar.");
            }
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

        //llenar el combobox con los tipos de usuarios
        private void llenarCombobox()
        {
            cbxTiposUsuarios.ValueMember = "codigo";
            cbxTiposUsuarios.DisplayMember = "tipo_usuario";
            cbxTiposUsuarios.DataSource = usuario.ShowTypeUsers();
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
