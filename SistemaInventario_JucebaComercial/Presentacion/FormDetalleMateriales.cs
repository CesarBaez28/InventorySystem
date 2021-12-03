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
    public partial class FormDetalleMateriales : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario.
        public bool actualizar = false; // la utilizo para insertar o actulizar dependiendo del estado de la variable.
        public string codigo; //Obtener el codigo del datagridView.
        bool estadoMaterial = false; // La utilizo para cambiar el estado a los materiales.
        float parseCorrecto; //La utilizo para indicar que el costo se ha un numero valido.
        public string tipoMaterial; //Guardo el texto del tipo de material seleccionado en el datagridView para mostrarlo en el comobobox tipo de material
        public bool formDetallesServicios; // La uso para saber si el Formulario FormDetallesServicios abrió este formulario.
        public bool formEntrada; // La uso para saber si el FormEntrada abrió este formulario.

        //La utilizo para actualizar el comobobox Tipo de materiales desde el formulario AgregarTipoMateriales
        public static FormDetalleMateriales formDetalleMaterial;

        public FormDetalleMateriales(FormMateriales formMateriales)
        {
            InitializeComponent();
            FormDetalleMateriales.formDetalleMaterial = this;
        }

        //Sobrecarga del constructor
        public FormDetalleMateriales()
        {
            InitializeComponent();
        }

        private void FormDetalleMateriales_Load(object sender, EventArgs e)
        {
            llenarCombobox();

            if (actualizar == true) 
            {
                cbxTiposMateriales.Text = tipoMaterial;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void ActualizarDelagate(object sender, UpdateEventArgs args);
        public event ActualizarDelagate UpdateEventHendler;

        public class UpdateEventArgs : EventArgs
        {
            public string Datos { get; set; }
        }

        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHendler.Invoke(this, args);
        }

        //Funcionalidad del boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DominioMateriales material = new DominioMateriales();

            //confirmo que los campos obligatorios estén llenos
            if (txbNombre.Text != "" && txbExistencia.Text != "" && txbCosto.Text != "")
            {
                //Insertar
                if (actualizar == false)
                {
                    // Valido que el precio se ha un número válido y que se ha mayor o igual que cero
                    if (float.TryParse(txbCosto.Text, out parseCorrecto) && float.Parse(txbCosto.Text) >= 0)
                    {
                        //Verifico que la existencia se ha un número válido y que se ha mayor o igual que cero
                        if (int.TryParse(txbExistencia.Text, out int parseCorrecto) && Convert.ToInt32(txbExistencia.Text) >= 0)
                        {
                            try
                            {
                                //Realizo la insercion
                                material.RegisterMaterial(cbxTiposMateriales.SelectedValue.ToString(), txbNombre.Text,
                                    txbDescripcion.Text, txbCosto.Text, txbExistencia.Text);

                                ///Verifico qué formulario abrió este formulario
                                if (formDetallesServicios != true && formEntrada != true)
                                {
                                    MessageBox.Show("Se insertó correctamente");
                                    VaciarCampos();
                                    Actualizar(); //Actualizo Lista en FormMateriales
                                }
                                else if (formDetallesServicios == true)
                                {
                                    //Actualizo Lista de materiales en FormDetallesServicio
                                    FormDetallesServicio.detallesServicio.MostrarMateriales();
                                    this.Close();
                                }
                                else
                                {
                                    FormEntradas.formEntrada.MostrarMateriales();
                                    this.Close();
                                }
                            }
                            catch 
                            {
                                MessageBox.Show("Ya existe un material con ese nombre");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La existencia ingresada no es válida");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El precio ingresado no es valido");
                    }

                }
                //Actualizar
                else
                {
                    if (float.TryParse(txbCosto.Text, out parseCorrecto) && float.Parse(txbCosto.Text) >= 0)
                    {
                        if (float.TryParse(txbCosto.Text, out parseCorrecto) && float.Parse(txbCosto.Text) >= 0)
                        {
                            try
                            {
                                if (cbxEstado.Text == "Activo")
                                    estadoMaterial = true;
                                else
                                    estadoMaterial = false;

                                material.UpdateMaterial(codigo, cbxTiposMateriales.SelectedValue.ToString(), txbNombre.Text,
                                    txbDescripcion.Text, txbCosto.Text, txbExistencia.Text, estadoMaterial);

                                MessageBox.Show("Se actualizó correctamente");
                                Actualizar();
                                this.Close();
                            }
                            catch 
                            {
                                MessageBox.Show("Ya existe un material con ese nombre");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La existencia ingresada no es válida");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El precio ingresado no es valido");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Llene los campos obligatorios");
            }
        }

        //Funcionalidad boton agregar tipo de material
        private void btnAgregarTipoMaterial_Click(object sender, EventArgs e)
        {
            FormAgregarTipoMaterial agregarTipoMaterial = new FormAgregarTipoMaterial();
            //agregarTipoMaterial.UpdateEventHendler += UpdateEventHendler;

            AbrirAgregarTipoMaterial(agregarTipoMaterial);
        }

        //Llenar combobox con los tipos de materiales
        public void llenarCombobox()
        {
            DominioMateriales material = new DominioMateriales();

            cbxTiposMateriales.ValueMember = "codigo";
            cbxTiposMateriales.DisplayMember = "tipo_material";
            cbxTiposMateriales.DataSource = material.ShowTypeMaterials();
        }

        private void lblTitulo_MouseMove_1(object sender, MouseEventArgs e)
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

        public void VaciarCampos() 
        {
            txbDescripcion.Text = "";
            txbExistencia.Text = "";
            txbNombre.Text = "";
            txbCosto.Text = "";
        }

        //Metodo para abirar el formulario AgregarTipoMaterial
        private Form formActivo = null;
        private void AbrirAgregarTipoMaterial(Form form)
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