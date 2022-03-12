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
    public partial class FormDetalleProveedor : Form
    {
        int posX, posY; // Las uso para capturar las cordenas para mover el formulario
        public bool actualizar = false; // La uso para actualizar o insertar dependiendo de su estado
        public string codigo; // La uso para guardar el codigo del registro seleccionado 
        public string direccion; // Guardo la direccion que se desea Actualizar. La uso para mostrar dicha direccion en el combobox 
        public string telefonoViejo; //La uso para guardar el telefono que se desea actualizar
        bool estadoProveedor; // Lo uso para indicar el estado del proveedor (activo o inactivo)
        public bool formEntrada; // La uso para indicar si el FormEntradas abrió este formulario

        public static FormDetalleProveedor detalleProveedor;

        public FormDetalleProveedor(FormProveedores formProveedores)
        {
            InitializeComponent();
            FormDetalleProveedor.detalleProveedor = this;
        }

        public FormDetalleProveedor() 
        {
            InitializeComponent();
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

        // Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDetalleProveedor_Load(object sender, EventArgs e)
        {
            MostrarDirecciones();

            if (actualizar == true)
                comboBoxDirecciones.Text = direccion;

            txbTelefono.Text = telefonoViejo;
        }

        //Mostrar todas las dirreciones
        public void MostrarDirecciones()
        {
            DominioDirecciones direcciones = new DominioDirecciones();
            comboBoxDirecciones.ValueMember = "codigo";
            comboBoxDirecciones.DisplayMember = "dirrecion";
            comboBoxDirecciones.DataSource = direcciones.ShowAddresses();
        }

        //Agregar una nueva direccion
        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            FormAgregarDirecion agregarDirecion = new FormAgregarDirecion();
            //Indico que este formulario abrio el formulario de direcciones
            agregarDirecion.quienAbrioFormulario = "DetalleProveedor";
            AbrirFormulario(agregarDirecion);
        }

        //Boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DominioProveedores proveedor = new DominioProveedores();

            //Confirmo que los campos esten llenos
            if (txbNombre.Text != "" && txbTelefono.Text != "")
            {
                //Insertar proveedor
                if (actualizar == false)
                {
                    try
                    {
                        proveedor.RegisterSupplier(txbTelefono.Text, comboBoxDirecciones.SelectedValue.ToString(),
                            txbNombre.Text);

                        //Verifico si el FormEntrada abrió este formulario
                        if (formEntrada != true)
                        {
                            Actualizar();
                            MessageBox.Show("Registro insertado");
                        }
                        else
                        {
                            //Actualizo la lista de suplidores en FormEntrada
                            FormEntradas.formEntrada.MostrarProveedores();
                        }

                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ya existe un proveedor con ese nombre o el número de teléfono ya está registrado.");
                    }

                }
                //Actualizar proveedor
                else
                {
                    if (cbxEstado.Text == "Activo")
                        estadoProveedor = true;
                    else
                        estadoProveedor = false;

                    try
                    {
                        proveedor.UpdateSupplier(txbTelefono.Text, telefonoViejo, comboBoxDirecciones.SelectedValue.ToString(), txbNombre.Text, codigo,
                            estadoProveedor);

                        Actualizar();
                        MessageBox.Show("Registro actualizado");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ya existe un proveedor con ese nombre");
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }

        //Metodo para abrir formulario
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
