using System;
using System.Drawing;
using System.Windows.Forms;
using Dominio;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        int posx;
        int posy;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        // Funcionalidad boton Acceder
        private void btnAcceder_Click(object sender, EventArgs e)
        {

            if (txtUser.Text != "USUARIO" && txtPassword.Text != "PASSWORD")
            {
                DominioUsuario usuario = new DominioUsuario();
                bool validarLogin = usuario.LoginUsuario(txtUser.Text, txtPassword.Text);

                if (validarLogin)
                {
                    FormPrincipal MenuPrincipal = new FormPrincipal();
                    MenuPrincipal.Show();
                    MenuPrincipal.FormClosed += CerrarSesion;
                    this.Hide();
                }
                else 
                {
                    MensageError("Nombre de usuario o constraseña incorrecta. \n Inténtelo de nuevo");
                    txtPassword.Text = "PASSWORD";
                    txtUser.Text = "USUARIO";
                    txtPassword.UseSystemPasswordChar = false;
                    txtUser.Focus();
                }
            }
            else 
            {
                MensageError("LLene todos los campos");
            }

        }

        private void CerrarSesion(object sender, FormClosedEventArgs e) 
        {
            txtPassword.Text = "PASSWORD";
            txtUser.Text = "USUARIO";
            txtPassword.UseSystemPasswordChar = false;
            lblMensgeError.Visible = false;
            this.Show();
            txtUser.Focus();
        }

        //Mensaje de error
        private void MensageError(string mensajeError) 
        {
            lblMensgeError.Text = mensajeError;
            lblMensgeError.Visible = true;
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO") 
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "") 
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;

            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        // Metodo para cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Metodo para minimizar el formulario
        private void btbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Metodo para mover el formulario
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
 
            if (e.Button != MouseButtons.Left)
            {
                posx = e.X;
                posy = e.Y;
            }
            else
            {
                Left = Left + (e.X - posx);
                Top = Top + (e.Y - posy);
            }
        }

        //Recuperar contraseña
        private void linkLabelPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recuperarPassword = new FormRecuperarPassword();
            recuperarPassword.ShowDialog();
        }

        //Metodo para mover el panel
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                posx = e.X;
                posy = e.Y;
            }
            else
            {
                Left = Left + (e.X - posx);
                Top = Top + (e.Y - posy);
            }
        }
    }
}
