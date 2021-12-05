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
