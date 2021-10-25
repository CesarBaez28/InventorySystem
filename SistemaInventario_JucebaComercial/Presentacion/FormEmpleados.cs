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
    public partial class FormEmpleados : Form
    {
        public string codigo; // Me servirá para obtener el codigo de la fila seleccionada en el dataGrid
        public bool actualizar = false; 
        int parseCorrecto; // Lo uso para vereficar que al momento de buscar un usuario el codigo sea un numero entero.
        bool estadoUsuario = true; // Lo utilizo para buscar los empleados por estado(activo o inactivo)
        DominioUsuario usuario = new DominioUsuario();

        public FormEmpleados()
        {
            InitializeComponent();
        }

        //Cerrar ventana
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEmpleados_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        //Mostrar todos los usuarios del sistema (activos o inactivos)
        private void MostrarUsuarios() 
        {
            DominioUsuario D_usuario = new DominioUsuario();
            gridViewListaUsuarios.DataSource = D_usuario.ShowUsersByStatus(estadoUsuario);
        }

        //Refrescar el datagridView desde el formulario FormDetalleUsuario
        private void ActualizarEventHandler(object sender, FormDetalleUsuario.UpdateEventArgs args)
        {
            MostrarUsuarios();
        }

        //Ingresar nuevo usuario
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetalleUsuario formDetalleUsuarioInsertar = new FormDetalleUsuario(this);
            formDetalleUsuarioInsertar.UpdateEventHendler += ActualizarEventHandler;

            //Oculto los controles para cambiar el estado del usuario. Solo son necesarios para actualizar
            formDetalleUsuarioInsertar.cbxEstado.Visible = false;
            formDetalleUsuarioInsertar.lblEstado.Visible = false;

            //cambio la Localizacion de los controles para ajustar el formulario
            formDetalleUsuarioInsertar.lblTipoUsuario.Location = new Point(12, 334);
            formDetalleUsuarioInsertar.cbxTiposUsuarios.Location = new Point(15, 354);
            formDetalleUsuarioInsertar.btnAceptar.Location = new Point(15, 394);
            formDetalleUsuarioInsertar.btnCancelar.Location = new Point(127, 394);

            //cambio el tamaño el formulario para que se ajuste al ocultar los controles
            formDetalleUsuarioInsertar.Size = new Size(263, 476);

            AbrirDetalleUsuario(formDetalleUsuarioInsertar);
        }

        //Actualizar usuario
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gridViewListaUsuarios.SelectedRows.Count > 0)
            {
                FormDetalleUsuario formDetalleUsuarioActualizar = new FormDetalleUsuario(this);
                formDetalleUsuarioActualizar.UpdateEventHendler += ActualizarEventHandler;
                
                actualizar = true;
                formDetalleUsuarioActualizar.actualizar = actualizar;
                formDetalleUsuarioActualizar.codigo = gridViewListaUsuarios.CurrentRow.Cells["Código"].Value.ToString();
                formDetalleUsuarioActualizar.tipoUsuario = gridViewListaUsuarios.CurrentRow.Cells["Tipo Usuario"].Value.ToString();

                formDetalleUsuarioActualizar.txbNombreUsuario.Text = gridViewListaUsuarios.CurrentRow.Cells["Nombre Usuario"].Value.ToString();
                formDetalleUsuarioActualizar.txbNombre.Text = gridViewListaUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
                formDetalleUsuarioActualizar.txbEmail.Text = gridViewListaUsuarios.CurrentRow.Cells["Email"].Value.ToString();
                formDetalleUsuarioActualizar.txbPassword.Text = gridViewListaUsuarios.CurrentRow.Cells["Contraseña"].Value.ToString();
                formDetalleUsuarioActualizar.txbConfirmarPassword.Text = gridViewListaUsuarios.CurrentRow.Cells["Contraseña"].Value.ToString();
                formDetalleUsuarioActualizar.cbxEstado.Text = gridViewListaUsuarios.CurrentRow.Cells["Estado"].Value.ToString();

                AbrirDetalleUsuario(formDetalleUsuarioActualizar);
            }
            else 
            {
                MessageBox.Show("Selecione una fila");     
            }
        }

        //Eliminar usuarios
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewListaUsuarios.SelectedRows.Count >= 0)
            {
                estadoUsuario = true;
                codigo = gridViewListaUsuarios.CurrentRow.Cells["Código"].Value.ToString();
                usuario.DeleteUser(codigo);
                MessageBox.Show("Se eliminó correctamente");
                MostrarUsuarios();
            }
            else 
            {
                MessageBox.Show("Seleccione una fila para poder eliminar");
            }
        }

        //Funcionalidad del boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Buscar por el codigo
            if (comboBuscar.SelectedIndex == 0)
            {
                if (txbBuscar.Text != "")
                {
                    if (int.TryParse(txbBuscar.Text, out parseCorrecto))
                    {
                        gridViewListaUsuarios.DataSource = usuario.ShowUsersByCode(txbBuscar.Text);
                        txbBuscar.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Código no valido");
                    }
                }
                else
                {
                    MessageBox.Show("El campo esta vacío");
                }
            }
            //Buscar por nombre
            else if (comboBuscar.SelectedIndex == 1)
            {
                if (txbBuscar.Text != "")
                {
                    gridViewListaUsuarios.DataSource = usuario.ShowUsersByName(txbBuscar.Text);
                    txbBuscar.Text = "";
                }
                else 
                {
                    MessageBox.Show("Escriba un nombre para la busqueda");
                }
            }
            // Buscar usuarios activos
            else if (comboBuscar.SelectedIndex == 2)
            {
                estadoUsuario = true;
                gridViewListaUsuarios.DataSource = usuario.ShowUsersByStatus(estadoUsuario);
            }
            //Buscar usuarios inactivos
            else if (comboBuscar.SelectedIndex == 3)
            {
                estadoUsuario = false;
                gridViewListaUsuarios.DataSource = usuario.ShowUsersByStatus(estadoUsuario);
            }
            //Todos los usuarios
            else
            {
                gridViewListaUsuarios.DataSource = usuario.ShowUsers();
            }
        }

        //Metodo para abirar el formulario DetalleUsuario
        private Form formActivo = null;
        private void AbrirDetalleUsuario(Form form) 
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
