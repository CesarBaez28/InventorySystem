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
    public partial class FormEntradas : Form
    {
        float parseCorrecto;
        float montoToal; // La uso para guardar el monto total de la compra.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer material, verificar si este u otros se agregan repetidos.
        bool yaRegistrado = false; // La uso para validar que no se ingrese un material repetido.

        //La uso para actualizar datos desde otro formulario
        public static FormEntradas formEntrada;

        public FormEntradas()
        {
            InitializeComponent();
            FormEntradas.formEntrada = this;
        }

        private void codigoMaterial() 
        {
            string codigoMaterial;

            for (int i = 0; i <= comboMaterial.DisplayMember[0]; i++) { }

        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEntradas_Load(object sender, EventArgs e)
        {
            MostrarMateriales();
            MostrarTipoMateriales();
            MostrarProveedores();
        }

        //Mostrar materiales
        public void MostrarMateriales() 
        {
            DominioMateriales materiales = new DominioMateriales();
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
        }

        //Mostrar tipo de materiales
        public void MostrarTipoMateriales() 
        {
            DominioMateriales materiales = new DominioMateriales();
            comboTipoMaterial.ValueMember = "codigo";
            comboTipoMaterial.DisplayMember = "tipo_material";
            comboTipoMaterial.DataSource = materiales.ShowTypeMaterials();
        }

        //Mostrar Proveedores
        public void MostrarProveedores() 
        {
            DominioProveedores proveedores = new DominioProveedores();
            comboSuplidores.ValueMember = "codigo";
            comboSuplidores.DisplayMember = "nombre";
            comboSuplidores.DataSource = proveedores.NameCodeSupplier();
        }

        //Agregar entrada a la lista
        private void AgregarEntrada() 
        {
            int indice = gridViewEntradas.Rows.Add();

            gridViewEntradas.Rows[indice].Cells[0].Value = comboSuplidores.Text;
            gridViewEntradas.Rows[indice].Cells[1].Value = comboTipoMaterial.Text;
            gridViewEntradas.Rows[indice].Cells[2].Value = comboMaterial.Text;
            gridViewEntradas.Rows[indice].Cells[3].Value = dateTimeEntrada.Text;
            gridViewEntradas.Rows[indice].Cells[4].Value = txbCantidad.Text;
            gridViewEntradas.Rows[indice].Cells[5].Value = txbMonto.Text;
        }

        //Boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txbMonto.Text, out parseCorrecto) && int.TryParse(txbCantidad.Text, out int parse))
            {
                if (primerRegistro == false) //Verifico si ya se ha ingresado un material
                {
                    AgregarEntrada();
                    primerRegistro = true;
                }
                else 
                {
                    //Verifico si el material agregado está repetido
                    foreach (DataGridViewRow fila in gridViewEntradas.Rows) 
                    {
                        if (fila.Cells[2].Value.ToString() == comboMaterial.Text)
                        {
                            yaRegistrado = true;
                            break;
                        }
                    }

                    //Si no está repetido, agrega la entrada. De lo contrario, arroja un mensaje de error.
                    if (yaRegistrado != true)
                    {
                        AgregarEntrada();
                    }
                    else 
                    {
                        MessageBox.Show("Ya ingresó ese material");
                        yaRegistrado = false;
                    }
                }

                BorrarCampos();
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }

        //Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewEntradas.SelectedRows.Count > 0) 
            {
                gridViewEntradas.Rows.Remove(gridViewEntradas.CurrentRow);
            }
        }

        //Terminar y registrar la entrada
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (gridViewEntradas.Rows.Count != 0)
            {
                foreach (DataGridViewRow fila in gridViewEntradas.Rows) 
                {

                }

                MessageBox.Show("Registro exitoso");
                gridViewEntradas.Rows.Clear();
            }
            else 
            {
                MessageBox.Show("Registre un ingreso");
            }
        }

        public void BorrarCampos() 
        {
            txbMonto.Text = "";
            txbCantidad.Text = "";
        }

        //Agregar suplidor
        private void btnAgregarSuplidor_Click(object sender, EventArgs e)
        {
            FormDetalleProveedor detalleSuplidor = new FormDetalleProveedor();

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleSuplidor.lblEstado.Visible = false;
            detalleSuplidor.cbxEstado.Visible = false;
            detalleSuplidor.Size = new Size(260, 310);
            detalleSuplidor.btnAceptar.Location = new Point(15, 232);
            detalleSuplidor.btnCancelar.Location = new Point(129, 232);

            detalleSuplidor.formEntrada = true;

            AbrirFormulario(detalleSuplidor);
        }

        //Agregar tipo material
        private void btnAgregarTipoMaterial_Click(object sender, EventArgs e)
        {
            FormAgregarTipoMaterial agregarTipoMaterial = new FormAgregarTipoMaterial();
            agregarTipoMaterial.formEntrada = true;
            AbrirFormulario(agregarTipoMaterial);
        }

        //Agregar material
        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            FormDetalleMateriales detalleMateriales = new FormDetalleMateriales();
            detalleMateriales.formEntrada = true;
            AbrirFormulario(detalleMateriales);
        }

        //Metodo para abirar el formulario DetalleSuplidor
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
