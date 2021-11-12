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
    public partial class FormActualizarMaterialesServicio : Form
    {
        DominioServicios servicios = new DominioServicios();

        int posX, posY;//La uso para guardar las coordenar y poder mover el formulario
        public int indiceFila; //Lo uso para guarda el indice de la fila para actualizar datos para inserción
        public string material; //La uso para guar el texto del material y mostrarlo en el comboBox
        public bool actualizar = false;//La uso para indicar si el formulario se abrió para insertar o actualizar
        int parseCorrecto; //La uso para validar que la cantidad se ha un numero entero.
        public string codigoServicio; //Guardo el codigo del servicio para actualizar los materiales cuando se han insertado DB
        public string materialAnterior;//Guardo el código del material anterior que se actualizó

        public FormActualizarMaterialesServicio()
        {
            InitializeComponent();
        }

        private void FormActualizarMaterialesServicio_Load(object sender, EventArgs e)
        {
            MostrarMateriales();
            comboMaterial.Text = material;
            materialAnterior = comboMaterial.SelectedValue.ToString();
        }

        private void MostrarMateriales() 
        {
            DominioMateriales materiales = new DominioMateriales();
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
        }

        //Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Valido que la cantidad se ha un numero entero
            if (int.TryParse(txbCantidad.Text, out parseCorrecto))
            {
                if (actualizar == false)
                {
                    FormDetallesServicio.detallesServicio.gridViewMateriales.Rows[indiceFila].Cells[0].Value = comboMaterial.SelectedValue.ToString();
                    FormDetallesServicio.detallesServicio.gridViewMateriales.Rows[indiceFila].Cells[1].Value = comboMaterial.Text;
                    FormDetallesServicio.detallesServicio.gridViewMateriales.Rows[indiceFila].Cells[2].Value = txbCantidad.Text;
                }
                else
                {
                    try
                    {
                        servicios.UpdateMaterialService(codigoServicio,
                            comboMaterial.SelectedValue.ToString(), materialAnterior, txbCantidad.Text);
                        FormDetallesServicio.detallesServicio.MostrarMaterialesServicio();
                    }
                    catch 
                    {
                        MessageBox.Show("Ya ese material está  incluido en el servicio");
                    
                    }
                }

                this.Close();
            }
            else 
            {
                MessageBox.Show("La cantidad no es validá");
            }
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
    }
}
