using Dominio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormAgregarTipoMaterial : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario
        bool Actualizar = false; //La uso para indicar si se va a actualizar o insertar;
        string materialActualizar; //Lo uso para guardar el nombre del tipo de material que se desea actualizar.

        DominioMateriales materiales = new DominioMateriales();

        public FormAgregarTipoMaterial()
        {
            InitializeComponent();
        }

        private void FormAgregarTipoMaterial_Load(object sender, EventArgs e)
        {
            MostrarTipoMateriales();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Mostrar los tipos de materiales en el datagridViews
        public void MostrarTipoMateriales()
        {
            DataTable table = new DataTable();
            table = materiales.ShowTypeMaterials();

            foreach (DataRow fila in table.Rows)
            {
                // Obtengo el indice del DaragridView
                int indice = gridViewTipoMateriales.Rows.Add();
                gridViewTipoMateriales.Rows[indice].Cells[1].Value = fila["tipo_material"].ToString();
            }
        }

        private void gridViewTipoMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (gridViewTipoMateriales.SelectedCells.Count > 0)
                {
                    Actualizar = true;
                    txbNombre.Text = gridViewTipoMateriales.CurrentRow.Cells[1].Value.ToString();
                    materialActualizar = gridViewTipoMateriales.CurrentRow.Cells[1].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Selecione una celda");
                }
            }
        }

        //Funcionalidad boton Agregar tipo de material
        private void btnAgregarTipoMaterial_Click(object sender, EventArgs e)
        {
            if (txbNombre.Text != "")
            {
                //Insertar
                if (Actualizar == false)
                {
                    //Inserto el tipo de material
                    materiales.RegisterTypeMaterial(txbNombre.Text);
                    MessageBox.Show("Registro insertado");
                    txbNombre.Text = "";
                }
                //Actualizar
                else
                {
                    materiales.UpdateTypeMaterial(materialActualizar, txbNombre.Text);
                    Actualizar = false;
                    txbNombre.Text = "";
                    MessageBox.Show("Registro actualizado");
                }

                gridViewTipoMateriales.DataSource = null;
                gridViewTipoMateriales.Rows.Clear();
                MostrarTipoMateriales();
                FormDetalleMateriales.formDetalleMaterial.llenarCombobox();
            }
            else
            {
                MessageBox.Show("El campo está vacío");
            }
        }

        //Funcionalidad para mover el formulario
        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
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
    }
}
