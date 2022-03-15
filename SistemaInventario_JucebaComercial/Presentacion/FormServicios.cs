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
    public partial class FormServicios : Form
    {
        //La uso para actualizar la lista de servicios al ingresar o actualizar uno.
        public static FormServicios formServicios;
        int parseCorrecto;//La uso para validar que el código del servicio se ha entero.
        bool estadoServicio = true; //La uso para buscar servicios por estado (activo o inactivo).
        bool Buscarinactivos;//La uso para indicar se van eliminar permanentemente los materiales inactivos cuando se buscan dichos materiales.


        DominioServicios servicios = new DominioServicios();

        public FormServicios()
        {
            InitializeComponent();
            FormServicios.formServicios = this;
        }

        private void FormServicios_Load(object sender, EventArgs e)
        {
            MostrarServicios();
            PermisosUsuarios();
        }

        //Permisos de usuarios
        private void PermisosUsuarios()
        {
            if (UsuarioLoginCache.Tipo_usuario == Posiciones.Empleado)
            {
                btnEliminar.Enabled = false;
                btnActualizar.Enabled = false;
            }
        }

        //Mostrar servicios 
        public void MostrarServicios() 
        {
            DominioServicios servicios = new DominioServicios();
            gridViewListaServicios.DataSource = servicios.SearchServiceStatus(estadoServicio);
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Agregar nuevo servicio
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetallesServicio agregarServicio = new FormDetallesServicio();
            AbrirFormulario(agregarServicio);
        }

        //Actualizar servicio
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            FormDetallesServicio agregarServicio = new FormDetallesServicio();

            agregarServicio.codigoServicio = gridViewListaServicios.CurrentRow.Cells["Código"].Value.ToString();
            agregarServicio.txbNombreServicio.Text = gridViewListaServicios.CurrentRow.Cells["Nombre"].Value.ToString();
            agregarServicio.txbDescripcionServicio.Text = gridViewListaServicios.CurrentRow.Cells["Descripción"].Value.ToString();
            agregarServicio.txbPrecio.Text = gridViewListaServicios.CurrentRow.Cells["Precio"].Value.ToString();
            agregarServicio.cbxEstado.Text = gridViewListaServicios.CurrentRow.Cells["Estado"].Value.ToString();
            agregarServicio.gridViewMateriales.Columns.Clear();
            agregarServicio.actualizar = true;

            AbrirFormulario(agregarServicio);
        }

        //Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewListaServicios.SelectedRows.Count > 0)
            {
                estadoServicio = true;

                //Eliminar por estado (cambiar de activo a inactivo)
                if (Buscarinactivos == false)
                {
                    servicios.DeleteServiceStatus(gridViewListaServicios.CurrentRow.Cells["Código"].Value.ToString());
                    MostrarServicios();
                }
                //Eliminar definitivamente
                else 
                {
                    estadoServicio = false;
                    servicios.DeleteService(gridViewListaServicios.CurrentRow.Cells["Código"].Value.ToString());
                    MostrarServicios();
                    estadoServicio = true;
                }

                MessageBox.Show("Se eliminó correctamente");
            }
            else 
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        //Manda un mensaje de error al no encontrar la información de una búsqueda
        private void BusquedaNoEncontrada()
        {
            //Si la buscqueda no tuvo éxito manda un mensaje de error.
            if (gridViewListaServicios.Rows.Count == 0)
            {
                gridViewListaServicios.DataSource = null;
                MessageBox.Show("No se han encontrado resultados.");
            }
        }

        //Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscarinactivos = false;

            //Buscar por código
            if (comboBuscar.SelectedIndex == 0)
            {
                //Valido que el código se ha correcto
                if (int.TryParse(txbBuscar.Text, out parseCorrecto))
                {
                    gridViewListaServicios.DataSource = servicios.SearchServiceCode(txbBuscar.Text);
                    txbBuscar.Text = "";
                    BusquedaNoEncontrada();
                }
            }
            //Buscar por nombre
            else if (comboBuscar.SelectedIndex == 1)
            {
                gridViewListaServicios.DataSource = servicios.SearchServiceName(txbBuscar.Text);
                txbBuscar.Text = "";
                BusquedaNoEncontrada();
            }
            //Buscar servicios activos
            else if (comboBuscar.SelectedIndex == 2)
            {
                estadoServicio = true;
                MostrarServicios();
                BusquedaNoEncontrada();
            }
            //Buscar servicios inactivos
            else if (comboBuscar.SelectedIndex == 3)
            {
                estadoServicio = false;
                Buscarinactivos = true;
                MostrarServicios();
                BusquedaNoEncontrada();
            }
            //Buscar todos los servicios (activos e inactivos)
            else if(comboBuscar.SelectedIndex == 4)
            {
                gridViewListaServicios.DataSource = servicios.ShowServices();
                BusquedaNoEncontrada();
            }
        }

        //Metodo para abir formulario
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

        private void ocultarTexBox()
        {
            txbBuscar.Visible = false;
            comboBuscar.Location = new Point(667, 112);
            lblBuscarPor.Location = new Point(570, 115);
        }

        private void MostrarTexbox()
        {
            txbBuscar.Visible = true;
            comboBuscar.Location = new Point(460, 112);
            lblBuscarPor.Location = new Point(363, 115);
        }

        //Limpia el campo de búsqueda al cambiar de opción
        //Y muestra o oculta el campo texbox dependiendo de la opción que lo requiera.
        private void comboBuscar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBuscar.Text == "código" || comboBuscar.Text == "nombre")
            {
                MostrarTexbox();
            }
            else
            {
                ocultarTexBox();
            }

            txbBuscar.Text = "";
        }
    }
}
