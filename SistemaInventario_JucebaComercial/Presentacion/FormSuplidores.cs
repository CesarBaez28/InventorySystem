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
    public partial class FormSuplidores : Form
    {
        bool estadoCliente = true;
        bool actualizar = false;
        public string codigo;
        int parseCorrecto;

        FormPrincipal principal = new FormPrincipal();

        public FormSuplidores()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            PermisosUsuarios();
        }

        //Permisos de usuarios
        public void PermisosUsuarios()
        {
            //if (UsuarioLoginCache.Tipo_usuario == Posiciones.Empleado)
            //{
            //    btnActualizar.Enabled = false;
            //    btnEliminar.Enabled = false;
            //}
        }


        //Ingresar nuevo cliente
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetalleSuplidor detalleCliente = new FormDetalleSuplidor();
            //detalleCliente.UpdateEventHendler += ActualizarEventHandler;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleCliente.lblEstado.Visible = false;
            detalleCliente.cbxEstado.Visible = false;
            detalleCliente.Size = new Size(260, 310);
            detalleCliente.btnAceptar.Location = new Point(15, 232);
            detalleCliente.btnCancelar.Location = new Point(129, 232);

            AbrirDetalleCliente(detalleCliente);
        }

        //Actualizar cliente
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gridViewListaSuplidores.SelectedRows.Count > 0)
            {
                FormDetalleSuplidor detalleCliente = new FormDetalleSuplidor();

                //actualizar = true;

                //detalleCliente.UpdateEventHendler += ActualizarEventHandler;
                //detalleCliente.actualizar = actualizar;
                //detalleCliente.codigo = gridViewListaSuplidores.CurrentRow.Cells["Código suplidor"].Value.ToString();
                //detalleCliente.txbNombre.Text = gridViewListaSuplidores.CurrentRow.Cells["Nombre"].Value.ToString();
                //detalleCliente.txbTelefono.Text = gridViewListaSuplidores.CurrentRow.Cells["Teléfono"].Value.ToString();
                //detalleCliente.txbDireccion.Text = gridViewListaSuplidores.CurrentRow.Cells["Dirección"].Value.ToString();
                //detalleCliente.cbxEstado.Text = gridViewListaSuplidores.CurrentRow.Cells["Estado"].Value.ToString();

                AbrirDetalleCliente(detalleCliente);
            }
            else 
            {
                MessageBox.Show("Selecione una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewListaSuplidores.SelectedRows.Count > 0)
            {

            }
            else 
            {
                MessageBox.Show("Seleccione una fila para poder eliminar");
            }

        }

        //Metodo para abirar el formulario DetalleCliente
        private Form formActivo = null;
        private void AbrirDetalleCliente(Form form)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        //Funcionalidad del boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (comboBuscar.Text == "código")
            {
                if (txbBuscar.Text != "")
                {
                    if (int.TryParse(txbBuscar.Text, out parseCorrecto))
                    {

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
            else if (comboBuscar.Text == "nombre")
            {

            }
            else if (comboBuscar.Text == "activos")
            {

            }
            else if (comboBuscar.Text == "inactivos")
            {

            }
            else 
            {
            }
        }
    }
}
