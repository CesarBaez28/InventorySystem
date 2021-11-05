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
using Comun;

namespace Presentacion
{
    public partial class FormEditarPerfil : Form
    {
        public FormEditarPerfil()
        {
            InitializeComponent();
        }

        private void FormEditarPerfil_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            InicializarPassEditarControles();

        }

        //LLenar los labels y texboxs con los datos del usuario
        private void CargarDatosUsuario() 
        {
            lblUsuario.Text = UsuarioLoginCache.Nombre_usuario;
            lblNombre.Text = UsuarioLoginCache.Nombre;
            lblCorreo.Text = UsuarioLoginCache.Email;
            lblPosicionUsuario.Text = UsuarioLoginCache.Tipo_usuario;


            txbNombreUsuario.Text = UsuarioLoginCache.Nombre_usuario;
            txbNombre.Text = UsuarioLoginCache.Nombre;
            txbEmail.Text = UsuarioLoginCache.Email;
            txbPassword.Text = UsuarioLoginCache.Password;
            txbConfirmarPassword.Text = UsuarioLoginCache.Password;
            txbPasswordActual.Text = "";

        }

        //Inicarlizar los componentes para editar el password
        private void InicializarPassEditarControles() 
        {
            linkEditarPassword.Text = "Editar";
            txbPassword.Enabled = false;
            txbPassword.UseSystemPasswordChar = true;
            txbConfirmarPassword.Enabled = false;
            txbConfirmarPassword.UseSystemPasswordChar = true;
        }

        //Resetar los datos del usuario
        private void Resetear() 
        {
            CargarDatosUsuario();
            InicializarPassEditarControles();
        }

        //Mostrar el panel donde se editar el perfil de usuario
        private void MiPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEditarPerfil.Visible = true;
            CargarDatosUsuario();
        }

        private void linkEditarPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkEditarPassword.Text == "Editar")
            {
                linkEditarPassword.Text = "Cancelar";
                txbPassword.Enabled = true;
                txbPassword.Text = "";
                txbConfirmarPassword.Enabled = true;
                txbConfirmarPassword.Text = "";
            }
            else if (txbConfirmarPassword.Text == "Cancelar") 
            {
                Resetear();
            }
        }

        //Funcionalidad boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txbNombreUsuario.Text != "" && txbNombre.Text != "" && txbEmail.Text != "")
            {
                if (txbPassword.Text.Length >= 5)
                {
                    if (txbPassword.Text == txbConfirmarPassword.Text)
                    {
                        if (txbPasswordActual.Text == UsuarioLoginCache.Password)
                        {
                            var D_usuario = new DominioUsuario(codigoUsuario: UsuarioLoginCache.Codigo_usuario,
                                codigo_tipoUsuario: UsuarioLoginCache.Codigo_tipo_usuario,
                                tipo_usuario: UsuarioLoginCache.Tipo_usuario,
                                nombreUsuario: txbNombreUsuario.Text,
                                password: txbPassword.Text,
                                nombre: txbNombre.Text,
                                email: txbEmail.Text,
                                estado: UsuarioLoginCache.Estado);

                            var resultado = D_usuario.EditPerfilUsuario();
                            MessageBox.Show(resultado);
                            Resetear();
                            panelEditarPerfil.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("contraseña actual incorrecta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                }
                else
                {
                    MessageBox.Show("La contraseñas debe tener al menos 5 caracteres");
                }
            }
            else 
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }

        //Funcionalidad boton cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelEditarPerfil.Visible = false;
            Resetear();
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
