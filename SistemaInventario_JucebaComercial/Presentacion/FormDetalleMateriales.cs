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
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario
        public bool actualizar = false; // la utilizo para insertar o actulizar dependiendo del estado de la variable
        public string codigo; //Obtener el codigo del datagridView
        bool estadoMaterial = false;
        float parseCorrecto;
        public string tipoMaterial; //Guardo el texto del tipo de material seleccionado en el datagridView para mostrarlo en el comobobox tipo de material

        //La utilizo para actualizar el comobobox Tipo de materiales desde el formulario AgregarTipoMateriales
        public static FormDetalleMateriales formDetalleMaterial;

        public FormDetalleMateriales(FormMateriales formMateriales)
        {
            InitializeComponent();
            FormDetalleMateriales.formDetalleMaterial = this;
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

            //Insertar
            if (actualizar == false)
            {
                //confirmo que los campos obligatorios estén llenos
                if (txbNombre.Text != "" && txbExistencia.Text != "" && txbCosto.Text != "")
                {
                    // Valido que el precio sea un numero valido
                    if (float.TryParse(txbCosto.Text, out parseCorrecto))
                    {
                        material.RegisterMaterial(cbxTiposMateriales.SelectedValue.ToString(), txbNombre.Text, 
                            txbDescripcion.Text, txbCosto.Text, txbExistencia.Text);

                        MessageBox.Show("Se insertó correctamente");
                        VaciarCampos();
                        Actualizar();
                    }
                    else
                    {
                        MessageBox.Show("El precio ingresado no es valido");
                    }
                }
                else 
                {
                    MessageBox.Show("Llene los campos obligatorios");
                }
            }
            //Actualizar
            else 
            {
                if (float.TryParse(txbCosto.Text, out parseCorrecto))
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
                else 
                {
                    MessageBox.Show("El precio ingresado no es valido");
                }
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

