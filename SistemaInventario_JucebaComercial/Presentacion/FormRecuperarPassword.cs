using Dominio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormRecuperarPassword : Form
    {
        int posx;
        int posy;
        public FormRecuperarPassword()
        {
            InitializeComponent();
        }

        //Cerrar el formulario
        private void btbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Botón enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DominioUsuario usuario = new DominioUsuario();
            var resultado = usuario.RecoverPassword(txbRecuperarPassword.Text);
            lblResultado.Text = resultado;
            lblResultado.Visible = true;
        }

        //Mover el formulario
        private void BarrarRecuperarPassword_MouseMove(object sender, MouseEventArgs e)
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
