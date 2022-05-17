using Dominio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormAgregarExcedente : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario
        DataGridView gridViewAgregarExcedente = FormSalidas.formSalidas.gridViewExcedentes;
        bool yaRegistrado = false;

        DominioMateriales materiales = new DominioMateriales();

        public FormAgregarExcedente()
        {
            InitializeComponent();
        }

        //Mover el formulario
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

        //Agregar excedente
        private void AgregarExcedente()
        {
            int indice = gridViewAgregarExcedente.Rows.Add();

            gridViewAgregarExcedente.Rows[indice].Cells["Codigo"].Value = gridViewExcedentes.CurrentRow.Cells["Código"].Value.ToString();
            gridViewAgregarExcedente.Rows[indice].Cells["Excedente"].Value = gridViewExcedentes.CurrentRow.Cells["Material"].Value.ToString();
            gridViewAgregarExcedente.Rows[indice].Cells["UnidadMedida"].Value = gridViewExcedentes.CurrentRow.Cells["Unidad medida"].Value.ToString();
            gridViewAgregarExcedente.Rows[indice].Cells["Largo"].Value = gridViewExcedentes.CurrentRow.Cells["Largo"].Value.ToString();
            gridViewAgregarExcedente.Rows[indice].Cells["Ancho"].Value = gridViewExcedentes.CurrentRow.Cells["Ancho"].Value.ToString();
            gridViewAgregarExcedente.Rows[indice].Cells["Alto"].Value = gridViewExcedentes.CurrentRow.Cells["Alto"].Value.ToString();
            gridViewAgregarExcedente.Rows[indice].Cells["CantidadExcedente"].Value = txbCantidad.Text;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (gridViewExcedentes.SelectedRows.Count > 0)
            {
                //Verifico que la cantidad ingresa se ha correcta y mayor que cero
                if (int.TryParse(txbCantidad.Text, out int parseCorrecto) && Convert.ToInt32(txbCantidad.Text) > 0)
                {
                    //Verifo que la cantidad no se mayor que existencia disponible
                    if (Convert.ToInt32(txbCantidad.Text) <= Convert.ToInt32(gridViewExcedentes.CurrentRow.Cells["Cantidad"].Value))
                    {
                        FormSalidas.formSalidas.gridViewExcedentes.Visible = true;
                        FormSalidas.formSalidas.gridViewSalidas.Height = 121;

                        if (gridViewAgregarExcedente.RowCount <= 0)
                        {
                            AgregarExcedente();
                        }
                        else
                        {
                            //Valido que no se igrese el mismo excedente otra vez
                            foreach (DataGridViewRow fila in gridViewAgregarExcedente.Rows)
                            {
                                if (fila.Cells["Codigo"].Value.ToString() == gridViewExcedentes.CurrentRow.Cells["Código"].Value.ToString())
                                {
                                    yaRegistrado = true;
                                    break;
                                }
                            }

                            //Si no está repetido, lo agrega. De lo contrario, arroja un mensaje de error
                            if (yaRegistrado != true)
                            {
                                AgregarExcedente();
                            }
                            else
                            {
                                MessageBox.Show("Ya ha utilizado ese excedente");
                                yaRegistrado = false;
                            }
                        }

                        txbCantidad.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente excedente");
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad ingresada no es válida");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila. Haga clic a una de las filas");
            }
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo para abirar formularios 
        private Form formActivo = null;

        private void FormAgregarExcedente_Load(object sender, EventArgs e)
        {
            MostrarExcedentes();
        }

        private void MostrarExcedentes()
        {
            gridViewExcedentes.DataSource = materiales.ShowLeftoverMaterials();
        }

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
