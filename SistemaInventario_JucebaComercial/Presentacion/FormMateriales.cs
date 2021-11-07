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
    public partial class FormMateriales : Form
    {

        public string codigo; // Me servirá para obtener el codigo de la fila seleccionada en el dataGrid
        int parseCorrecto; // Lo uso para vereficar que al momento de buscar un material el codigo sea un numero entero.
        public bool estadoMaterial = true; // Lo utilizo para buscar los materiales por estado (activo o inactivo)
        public bool actualizar = false; //La utilizo para indicar si se va a actualizar o a insertar
        public string tipoMaterial; //La utilizo para guardar el texto del tipo de material seleccionado en el datagridView

        public FormMateriales()
        {
            InitializeComponent();
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMateriales_Load(object sender, EventArgs e)
        {
            //PermisosUsuarios();
            MostrarMateriales();
        }

        //Mostrar materiales (los activos)
        private void MostrarMateriales() 
        {
            DominioMateriales materiales = new DominioMateriales();
            gridViewListaMateriales.DataSource = materiales.SearchMaterialByStatus(estadoMaterial);
        }

        private void ActualizarEventHandler(object sender, FormDetalleMateriales.UpdateEventArgs args)
        {
            MostrarMateriales();
        }

        //Permisos de usuarios
        private void PermisosUsuarios()
        {
            //if (UsuarioLoginCache.Tipo_usuario == Posiciones.Empleado)
            //{
            //    btnEliminar.Enabled = false;
            //    btnActualizar.Enabled = false;
            //}
        }

        //Buscar materiales
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DominioMateriales materiales = new DominioMateriales();

            //Por codigo
            if (comboBuscar.SelectedIndex == 0)
            {
                //Verifico se haya ingresado un codigo y que se ha correcto
                if (comboBuscar.Text != "" && int.TryParse(txbBuscar.Text, out parseCorrecto))
                {
                    gridViewListaMateriales.DataSource = materiales.SearchMaterialByCode(txbBuscar.Text);
                }
                else
                {
                    MessageBox.Show("Código incorrecto");
                }

                txbBuscar.Text = "";
            }
            //Por nombre
            else if (comboBuscar.SelectedIndex == 1)
            {
                //Verifico que el campo este lleno
                if (txbBuscar.Text != "")
                {
                    gridViewListaMateriales.DataSource = materiales.SearchMaterialByName(txbBuscar.Text);
                }

                txbBuscar.Text = "";
            }
            //Por materiales activos
            else if (comboBuscar.SelectedIndex == 3)
            {
                estadoMaterial = true;
                gridViewListaMateriales.DataSource = materiales.SearchMaterialByStatus(estadoMaterial);
            }
            //Por materiales inactivos
            else if (comboBuscar.SelectedIndex == 4)
            {
                estadoMaterial = false;
                gridViewListaMateriales.DataSource = materiales.SearchMaterialByStatus(estadoMaterial);
            }
            else 
            {
                gridViewListaMateriales.DataSource = materiales.ShowMaterials();
            }
        }

        //Funcionalidad boton nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDetalleMateriales formDetalleMateriales = new FormDetalleMateriales(this);
            formDetalleMateriales.UpdateEventHendler += ActualizarEventHandler;
            AbrirFormulario(formDetalleMateriales);
        }

        //Funcionaliad boton actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gridViewListaMateriales.SelectedRows.Count >= 0)
            {
                FormDetalleMateriales detalleMateriales = new FormDetalleMateriales(this);
                detalleMateriales.UpdateEventHendler += ActualizarEventHandler;

                actualizar = true;

                //Mustros los controles para cambiar el estado del material y organizo los otros componentes
                detalleMateriales.lblEstado.Visible = true;
                detalleMateriales.cbxEstado.Visible = true;
                detalleMateriales.lblEstado.Location = new Point(12,327);
                detalleMateriales.cbxEstado.Location = new Point(15,347);
                detalleMateriales.btnAceptar.Location = new Point(15,388);
                detalleMateriales.btnCancelar.Location = new Point(127,388);
                detalleMateriales.Size = new Size(263,464);

                //Obtengo los datos del datagridview para actualizarlos
                detalleMateriales.actualizar = actualizar;
                detalleMateriales.codigo = gridViewListaMateriales.CurrentRow.Cells["Código"].Value.ToString();
                detalleMateriales.tipoMaterial = gridViewListaMateriales.CurrentRow.Cells["Tipo material"].Value.ToString();
                detalleMateriales.txbNombre.Text = gridViewListaMateriales.CurrentRow.Cells["Nombre"].Value.ToString();
                detalleMateriales.txbDescripcion.Text = gridViewListaMateriales.CurrentRow.Cells["Descripción"].Value.ToString();
                detalleMateriales.txbCosto.Text = gridViewListaMateriales.CurrentRow.Cells["Costo"].Value.ToString();
                detalleMateriales.txbExistencia.Text = gridViewListaMateriales.CurrentRow.Cells["Existencia"].Value.ToString();
                detalleMateriales.cbxEstado.Text = gridViewListaMateriales.CurrentRow.Cells["Estado"].Value.ToString();

                AbrirFormulario(detalleMateriales);
            }
            else 
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        //Funcionalidad del boton eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewListaMateriales.SelectedRows.Count >= 0) 
            {

            }
            else
            {
                MessageBox.Show("Seleccione una fila para poder eliminar");
            }
        }

        //Agregar excedente
        private void btnAgregarExcdente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormDetallesExcedente());
        }

        //Funcionalidad boton exportar en Excel
        private void btnEportarExcel_Click(object sender, EventArgs e)
        {
            ExportarDatos(gridViewListaMateriales);
        }

        //Funcionalidad para exportar datos en excel
        public void ExportarDatos(DataGridView listaMateriales) 
        {
            //Microsoft.Office.Interop.Excel.Application ExportarExcel = new Microsoft.Office.Interop.Excel.Application();

            //ExportarExcel.Application.Workbooks.Add(true);

            //int indiceColumna = 0;

            //foreach (DataGridViewColumn columna in listaMateriales.Columns) 
            //{
            //    indiceColumna++;

            //    ExportarExcel.Cells[1, indiceColumna] = columna.Name;
            //}

            //int indiceFila = 0;

            //foreach (DataGridViewRow fila in listaMateriales.Rows)
            //{
            //    indiceFila++;
            //    indiceColumna = 0;

            //    foreach (DataGridViewColumn columna in listaMateriales.Columns) 
            //    {
            //        indiceColumna++;
            //        ExportarExcel.Cells[indiceFila + 1, indiceColumna] = fila.Cells[columna.Name].Value;   
            //    }
            //}

            //ExportarExcel.Visible = true;
        }

        //Metodo para abirar el formulario DetalleMaterial
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
    }
}
