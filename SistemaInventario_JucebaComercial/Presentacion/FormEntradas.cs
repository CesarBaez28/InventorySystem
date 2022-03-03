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
    public partial class FormEntradas : Form
    {
        float parseCorrecto; // La uso para verificar si el monto ingresado es correcto
        float total; // La uso para guardar el monto total de la compra.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer material, verificar si este u otros se agregan repetidos.
        bool yaRegistrado = false; // La uso para validar que no se ingrese un material repetido.
        string costoMaterial = ""; //Guardo el costo de un material para mostrarlo automáticamente.

        DominioEntrada entrada = new DominioEntrada();
        DominioMateriales materiales = new DominioMateriales();


        //La uso para actualizar datos desde otro formulario
        public static FormEntradas formEntrada;

        public FormEntradas()
        {
            InitializeComponent();
            FormEntradas.formEntrada = this;
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEntradas_Load(object sender, EventArgs e)
        {
            MostrarMateriales();
            MostrarProveedores();
        }

        //Mostrar materiales
        public void MostrarMateriales() 
        {
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
            comboMaterial.SelectedIndex = -1;
        }

        //Mostrar Proveedores
        public void MostrarProveedores() 
        {
            DominioProveedores proveedores = new DominioProveedores();
            comboSuplidores.ValueMember = "codigo";
            comboSuplidores.DisplayMember = "nombre";
            comboSuplidores.DataSource = proveedores.NameCodeSupplier();
            comboSuplidores.SelectedIndex = -1;
        }

        //Muestra el precio del material automáticamente al seleccionar uno.
        private void comboMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            costoMaterial = materiales.SearchCostMaterial(comboMaterial.SelectedValue.ToString()).Rows[0]["costo"].ToString();
            txbMonto.Text = costoMaterial;
        }

        //Agregar entrada a la lista
        private void AgregarEntrada() 
        {
            int indice = gridViewEntradas.Rows.Add();
            float total_entrada = Convert.ToInt32(txbCantidad.Text) * float.Parse(txbMonto.Text); //Total de una compra

            gridViewEntradas.Rows[indice].Cells["Suplidor"].Value = comboSuplidores.Text;
            gridViewEntradas.Rows[indice].Cells["Material"].Value = comboMaterial.Text;
            gridViewEntradas.Rows[indice].Cells["Cantidad"].Value = txbCantidad.Text;
            gridViewEntradas.Rows[indice].Cells["Monto"].Value = txbMonto.Text;
            gridViewEntradas.Rows[indice].Cells["Total_entrada"].Value = total_entrada.ToString();

            //Total de la entrada en general
            total += total_entrada;
            lblTotalEntrada.Text = "Total: " + total.ToString();
        }

        //Boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verifico que el monto y la cantidad se han números válidos.
            //Y que los combobox de los materiales y suplidores tengan un elemento seleccionado
            if (float.TryParse(txbMonto.Text, out parseCorrecto) && int.TryParse(txbCantidad.Text, out int parse) 
                && comboMaterial.SelectedIndex != -1 && comboSuplidores.SelectedIndex != -1)
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
                MessageBox.Show("Faltan campos por llenar o ingresó un campo de manera incorrecta");
            }
        }

        //Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewEntradas.SelectedRows.Count > 0) 
            {
                //Actualizo el total 
                total = total - (float.Parse(gridViewEntradas.CurrentRow.Cells["Monto"].Value.ToString()));
                gridViewEntradas.Rows.Remove(gridViewEntradas.CurrentRow);
            }
        }

        //Terminar y registrar la entrada
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            //Verifico que el datagridview no esté vacío. 
            //Y que los combobox tengan un elemento seleccionado.
            if (gridViewEntradas.Rows.Count != 0 && comboMaterial.SelectedIndex != -1 && comboSuplidores.SelectedIndex != -1)
            {
                //Registro entrada
                entrada.RegisterEntry(dateTimeEntrada.Value);

                foreach (DataGridViewRow fila in gridViewEntradas.Rows) 
                {
                    //Registro detalles de la entrada
                    entrada.RegisterDetailsEntry(UsuarioLoginCache.Codigo_usuario.ToString(), 
                        fila.Cells["Suplidor"].Value.ToString(), fila.Cells["Material"].Value.ToString(),
                        fila.Cells["Cantidad"].Value.ToString(),fila.Cells["Total_entrada"].Value.ToString());
                }

                MessageBox.Show("Registro exitoso");
            }
            else 
            {
                MessageBox.Show("No hay entradas agregadas");
            }

            total = 0;
            lblTotalEntrada.Text = "Total: ";
            gridViewEntradas.Rows.Clear();
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
