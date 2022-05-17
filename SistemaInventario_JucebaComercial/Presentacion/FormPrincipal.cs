using Comun;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        int posX, posY; //Las uso para obtener las cordenas y poder mover el formulario
        bool estaDesplejado = false; // La uso para indicar cuando desplejar el menu lateral.

        public FormPrincipal()
        {
            InitializeComponent();
        }

        //Cerrar aplicacion
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Cerrar sesion
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int LX, LY; //Se usan para capturar la posicion actual de la pantalla al momento de maximizar
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            LX = this.Location.X;
            LY = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        //Restaurar
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1068, 679);
            this.Location = new Point(LX, LY);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        //Minimizar pantalla
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Perfil del usuario
        private void PerfilUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormEditarPerfil());
        }

        //Funcionalidad para mover el fomulario
        private void BarraTitulo_MouseMove(object sender, MouseEventArgs e)
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

        // Funcionalidad de los botones del Menú

        //Boton empleados
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormEmpleados());
        }

        //Boton clientes
        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            AbrirFormularios(new FormCliente());
        }

        //Boton suplidores
        private void btnSuplidores_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormProveedores());
        }

        //Servicios 
        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormServicios());
        }

        //Boton entradas
        private void btnEntradas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormEntradas());
        }

        //Botón cotizar
        private void btnCotizar_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormCotizar());
        }

        //Boton salidas
        private void btnSalidas_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormSalidas());
        }

        //Boton materiales catalogo
        private void btnMaterialesCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormMateriales());
        }

        //Boton reportes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new FormReportes());
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            PermisosUsuarios();
        }

        //Permisos de usuarios
        public void PermisosUsuarios()
        {
            if (UsuarioLoginCache.Tipo_usuario == Posiciones.Empleado)
            {
                btnEmpleados.Enabled = false;
            }
        }

        //Botón Menu lateral
        private void btnMenuLateral_Click(object sender, EventArgs e)
        {
            if (estaDesplejado == false)
            {
                MenuDesplejado();
                estaDesplejado = true;
            }
            else
            {
                MenuSinDesplejar();
                estaDesplejado = false;
            }
        }

        //Menu desplejado
        private void MenuDesplejado()
        {
            int ancho = 180, alto = 40;

            Menu.Size = new Size(ancho, 644); // Tamaño de la barra lateral

            //Botones de la barra lateral
            foreach (Button buttonMenu in Menu.Controls.OfType<Button>())
            {
                buttonMenu.Text = "              " + buttonMenu.Tag.ToString();
                buttonMenu.ImageAlign = ContentAlignment.MiddleLeft;
                buttonMenu.Size = new Size(ancho, alto);
                buttonMenu.Padding = new Padding(10, 0, 0, 0);
            }
        }

        //Menu sin desplejar 
        private void MenuSinDesplejar()
        {
            int ancho = 70, alto = 40;

            Menu.Size = new Size(ancho, 644); // Tamaño de la barra lateral

            //Botones de la barra lateral
            foreach (Button buttonMenu in Menu.Controls.OfType<Button>())
            {
                buttonMenu.Text = "";
                buttonMenu.ImageAlign = ContentAlignment.MiddleCenter;
                buttonMenu.Size = new Size(ancho, alto);
                buttonMenu.Padding = new Padding(0);
            }
        }

        //Metodo para abrir los formularios
        private Form formActivo = null;
        public void AbrirFormularios(Form formulario)
        {
            // Si existe un formulario activo se cierra
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formulario);
            panelContenedor.Tag = formulario;
            formulario.BringToFront();
            formulario.Show();

            //lblTitulo.Text = formulario.Text;
        }
    }
}
