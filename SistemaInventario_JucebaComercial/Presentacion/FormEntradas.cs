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
        float montoTotal; // La uso para guardar el monto total de la compra.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer material, verificar si este u otros se agregan repetidos.
        bool yaRegistrado = false; // La uso para validar que no se ingrese un material repetido.

        DominioEntrada entrada = new DominioEntrada();

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
            DominioMateriales materiales = new DominioMateriales();
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
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

            gridViewEntradas.Rows[indice].Cells["Suplidor"].Value = comboSuplidores.Text;
            gridViewEntradas.Rows[indice].Cells["Material"].Value = comboMaterial.Text;
            gridViewEntradas.Rows[indice].Cells["Cantidad"].Value = txbCantidad.Text;
            gridViewEntradas.Rows[indice].Cells["Monto"].Value = txbMonto.Text;
        }

        //Boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verifico que el monto y la cantidad se han números válidos.
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
                MessageBox.Show("Faltan campos por llenar o ingresó un campo de manera incorrecta");
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
            //Verifico que el datagridview no esté vacío. 
            if (gridViewEntradas.Rows.Count != 0)
            {
                //Registro entrada
                entrada.RegisterEntry(dateTimeEntrada.Value);

                foreach (DataGridViewRow fila in gridViewEntradas.Rows) 
                {
                    //Registro detalles de la entrada
                    entrada.RegisterDetailsEntry(UsuarioLoginCache.Codigo_usuario.ToString(), 
                        fila.Cells["Suplidor"].Value.ToString(), fila.Cells["Material"].Value.ToString(),
                        fila.Cells["Cantidad"].Value.ToString(),fila.Cells["Monto"].Value.ToString());
                }

                MessageBox.Show("Registro exitoso");
                gridViewEntradas.Rows.Clear();
            }
            else 
            {
                MessageBox.Show("No hay entradas agregadas");
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
