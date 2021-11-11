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
    public partial class FormDetallesExcedente : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario
        int parseCorrecto; // La uso para verificar si la cantidad ingresada es una numero entero
        public string codigoMaterial; //Guardo el codigo del material
        public string codigoTipoMaterial; //Guardo el codigo tipo de material
        public string codigoExcedente; // Guardo el codigo del excedente
        public string existencia; //La uso para verificar si hay suficientes materiales 
        public string unidadMedida; //La uso para guardar el texto de la unidad de medida
        public bool actualizar = false; // La uso para indicar si se va a insertar o actualizar

        DominioMateriales materiales = new DominioMateriales();

        public FormDetallesExcedente()
        {
            InitializeComponent();
        }

        //Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAgregarExcedente_Load(object sender, EventArgs e)
        {
            MostrarUnidades();

            if (actualizar == true)
                cbxMedidas.Text = unidadMedida;
        }

        //Actualiza la lista de materiales excedentes
        private void ActualizarListaExcedentes() 
        {
            FormMateriales.formMateriales.gridViewListaMateriales.DataSource = materiales.ShowLeftoverMaterials();
        }

        //Mostrar unidades de medida
        private void MostrarUnidades() 
        {
            DominioMedidas medida = new DominioMedidas();
            cbxMedidas.ValueMember = "codigo";
            cbxMedidas.DisplayMember = "unidad_medida";
            cbxMedidas.DataSource = medida.ShowMeasurement();
        }

        //Boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DominioMateriales material = new DominioMateriales();

            //Verifico que los campos obligatorios tengan un valor
            if (txbCantidad.Text != "" && txbAncho.Text != "" && txbAlto.Text != "" && txbLargo.Text != "")
            {
                //Verifico que se haya ingresado una cantidad correcta y que se ha mayor que cero
                if (int.TryParse(txbCantidad.Text, out parseCorrecto) && Convert.ToInt32(txbCantidad.Text) >= 1)
                {
                    //Insertar
                    if (actualizar == false)
                    {
                        //Verifico que haya materiales disponibles 
                        if (Convert.ToInt32(existencia) >= Convert.ToInt32(txbCantidad.Text))
                        {
                            material.RegisterLeftoverMaterial(codigoTipoMaterial, codigoMaterial,
                                cbxMedidas.SelectedValue.ToString(), txbLargo.Text, txbAncho.Text,
                                txbAlto.Text, txbCantidad.Text, txbDescripcion.Text);

                            MessageBox.Show("Se registró correctamente");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No hay suficientes materiales");
                        }
                    }
                    //Actualizar
                    else 
                    {
                        try
                        {
                            material.UpdateLeftoverMaterial(codigoExcedente, cbxMedidas.SelectedValue.ToString(),
                                txbLargo.Text, txbAncho.Text, txbAlto.Text, txbCantidad.Text, txbDescripcion.Text);
                            MessageBox.Show("Se actualizó correctamente");
                            ActualizarListaExcedentes();
                            this.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No hay materiales suficientes");
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("La cantidad ingresada no es correcta");
                }
            }
            else 
            {
                MessageBox.Show("LLene los campos obligatorios");
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
