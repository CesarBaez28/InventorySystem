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
    public partial class FormProveedores : Form
    {
        DominioProveedores proveedor = new DominioProveedores();
        bool estadoProveedor = true;
        bool actualizar = false;
        public string codigo;
        int parseCorrecto;

        //FormPrincipal principal = new FormPrincipal();
        public FormProveedores()
        {
            InitializeComponent();
        }

        //Cerrar el fomulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            PermisosUsuarios();
        }

        //Mostrar proveedores
        private void MostrarProveedores() 
        {
            DominioProveedores proveedor = new DominioProveedores();
            gridViewListaSuplidores.DataSource = proveedor.SearchSupplierbyStatus(estadoProveedor);
        }

        //Refrescar el datagridView desde el formulario FormDetalleProveedor
        private void ActualizarEventHandler(object sender, FormDetalleProveedor.UpdateEventArgs args)
        {
            MostrarProveedores();
        }

        //Permisos de usuarios
        public void PermisosUsuarios()
        {
            if (UsuarioLoginCache.Tipo_usuario == Posiciones.Empleado)
            {
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }


        //Ingresar nuevo Proveedor
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetalleProveedor detalleProveedor = new FormDetalleProveedor(this);
            detalleProveedor.UpdateEventHendler += ActualizarEventHandler;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleProveedor.lblEstado.Visible = false;
            detalleProveedor.cbxEstado.Visible = false;
            detalleProveedor.Size = new Size(260, 310);
            detalleProveedor.btnAceptar.Location = new Point(15, 232);
            detalleProveedor.btnCancelar.Location = new Point(129, 232);

            AbrirFormulario(detalleProveedor);
        }

        //Actualizar Proveedor
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Verifico que haya una fila seleccionada
            if (gridViewListaSuplidores.SelectedRows.Count > 0)
            {
                FormDetalleProveedor detalleProveedor = new FormDetalleProveedor(this);
                detalleProveedor.UpdateEventHendler += ActualizarEventHandler;
                actualizar = true;

                //Obtengo los datos del dataGridView para poder actualizarlos
                detalleProveedor.actualizar = actualizar;
                detalleProveedor.codigo = gridViewListaSuplidores.CurrentRow.Cells["Código"].Value.ToString();
                detalleProveedor.txbNombre.Text = gridViewListaSuplidores.CurrentRow.Cells["Nombre"].Value.ToString();
                detalleProveedor.telefonoViejo = gridViewListaSuplidores.CurrentRow.Cells["Teléfono"].Value.ToString();
                detalleProveedor.direccion = gridViewListaSuplidores.CurrentRow.Cells["Dirección"].Value.ToString();
                detalleProveedor.cbxEstado.Text = gridViewListaSuplidores.CurrentRow.Cells["Estado"].Value.ToString();

                AbrirFormulario(detalleProveedor);
            }
            else 
            {
                MessageBox.Show("Selecione una fila");
            }
        }

        //Eliminar proveedor
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewListaSuplidores.SelectedRows.Count > 0)
            {
                estadoProveedor = true;
                codigo = gridViewListaSuplidores.CurrentRow.Cells["Código"].Value.ToString();
                MessageBox.Show("Se eliminó correctamente");
                proveedor.DeleteSupplier(codigo);
                MostrarProveedores();
            }
            else 
            {
                MessageBox.Show("Seleccione una fila para poder eliminar");
            }
        }

        //Metodo para abirar el formulario DetalleProveedor
        private Form formActivo = null;
        private void AbrirFormulario(Form form)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        //Manda un mensaje de error al no encontrar la información de una búsqueda
        private void BusquedaNoEncontrada()
        {
            //Si la buscqueda no tuvo éxito manda un mensaje de error.
            if (gridViewListaSuplidores.Rows.Count == 0)
            {
                gridViewListaSuplidores.DataSource = null;
                MessageBox.Show("No se han encontrado resultados.");
            }
        }

        //Buscar proveedores o proveedor
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DominioProveedores proveedor = new DominioProveedores();

            //Buscar por código
            if (comboBuscar.SelectedIndex == 0)
            {
                //Verifico se haya ingresado un código
                if (txbBuscar.Text != "")
                {
                    //Verifico el código se ha correcto
                    if (int.TryParse(txbBuscar.Text, out parseCorrecto))
                    {
                        txbBuscar.Text = "";
                        gridViewListaSuplidores.DataSource = proveedor.SearchSupplierByCode(txbBuscar.Text);
                        BusquedaNoEncontrada();
                    }
                    else
                    {
                        MessageBox.Show("El Código no correcto");
                    }
                }
                else
                {
                    MessageBox.Show("El campo esta vacío");
                }
            }
            //Buscar por nombre
            else if (comboBuscar.SelectedIndex ==1 )
            {
                txbBuscar.Text = "";
                gridViewListaSuplidores.DataSource = proveedor.SearchSupplierByName(txbBuscar.Text);
                BusquedaNoEncontrada();
            }
            //Buscar proveedores activos
            else if (comboBuscar.Text == "activos")
            {
                estadoProveedor = true;
                gridViewListaSuplidores.DataSource = proveedor.SearchSupplierbyStatus(estadoProveedor);
                BusquedaNoEncontrada();
            }
            //Buscar proveedores inactivos
            else if (comboBuscar.Text == "inactivos")
            {
                estadoProveedor = false;
                gridViewListaSuplidores.DataSource = proveedor.SearchSupplierbyStatus(estadoProveedor);
                BusquedaNoEncontrada();
            }
            //Mostrar todos los proveedores del sistema
            else 
            {
                gridViewListaSuplidores.DataSource = proveedor.ShowSuppliers();    
                BusquedaNoEncontrada();
            }
        }

        //Limpia el campo de búsqueda al cambiar de opción
        private void comboBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txbBuscar.Text = "";
        }
    }
}
