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
            PermisosUsuarios();
        }

        //Permisos de usuarios
        public void PermisosUsuarios()
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

        }

        //Funcionalidad boton nuevo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormDetalleMateriales(this));
        }

        //Funcionaliad boton actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gridViewListaMateriales.SelectedRows.Count >= 0)
            {
                FormDetalleMateriales detalleMateriales = new FormDetalleMateriales(this);

                detalleMateriales.lblEstado.Visible = true;
                detalleMateriales.cbxEstado.Visible = true;
                detalleMateriales.lblEstado.Location = new Point(12,327);
                detalleMateriales.cbxEstado.Location = new Point(15,347);
                detalleMateriales.btnAceptar.Location = new Point(15,388);
                detalleMateriales.btnCancelar.Location = new Point(127,388);
                detalleMateriales.Size = new Size(263,464);

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
