using Dominio;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormDetalleCliente : Form
    {
        int posX, posY;
        public bool actualizar = false; // La uso para actualizar o insertar dependiendo de su estado
        public string codigo; // La uso para guardar el codigo del registro seleccionado 
        public string direccion; // Guardo la direccion que se desea Actualizar. La uso para mostrar dicha direccion en el combobox 
        public string telefonoViejo; //La uso para guardar el telefono que se desea actualizar
        bool estadoCliente; // Lo uso para indicar el estado del cliente (activo o inactivo)
        public bool formSalida; // La uso para indicar si el FormSalidas abrió este formulario.
        public bool formCotizar; // La uso para indicar si el FormCotizar abrió este formulario.

        public static FormDetalleCliente detalleCliente;

        public FormDetalleCliente(FormCliente formClientes)
        {
            InitializeComponent();
            FormDetalleCliente.detalleCliente = this;
        }

        //Sobre cargo el constructor
        public FormDetalleCliente()
        {
            InitializeComponent();
        }

        //Cerrar el formulario
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

        //Actuarlizar la lista de clientes al insertar o actualizar uno.
        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHendler.Invoke(this, args);
        }

        private void FormDetalleCliente_Load(object sender, EventArgs e)
        {
            MostrarDirecciones();

            if (actualizar == true)
                comboBoxDirecciones.Text = direccion;

            txtTelefono.Text = telefonoViejo;
        }

        //Insertar cliente
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DominioCliente cliente = new DominioCliente();

            //Confirmo que los campos esten llenos
            if (txbNombre.Text != "" && txtTelefono.Text != "")
            {
                //Quito los posibles espacios que se hayan podido insertar al ingresar el número de teléfono
                string telefono = Regex.Replace(txtTelefono.Text, @"\s", "");

                //Agregar nuevo cliente
                if (actualizar == false)
                {
                    try
                    {
                        cliente.RegisterCostumer(telefono, comboBoxDirecciones.SelectedValue.ToString(),
                            txbNombre.Text);

                        if (formSalida == true) //Verifico si el FormSalidad abrió este formulario
                        {
                            //Actualizo la lista de servicio en el FormSalidas
                            FormSalidas.formSalidas.MostrarClientes();
                        }
                        else if (formCotizar == true) //Verifico si el FormCotizar abrió este formulario
                        {
                            FormCotizar.formCotizar.MostrarClientes();
                        }
                        else
                        {
                            Actualizar();
                        }
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ya existe un cliente con ese nombre.");
                    }
                }
                //Actualizar datos del cliente
                else
                {
                    if (cbxEstado.Text == "Activo")
                        estadoCliente = true;
                    else
                        estadoCliente = false;

                    try
                    {
                        cliente.UpdateCostumer(telefono, telefonoViejo,
                            comboBoxDirecciones.SelectedValue.ToString(), txbNombre.Text, codigo,
                            estadoCliente);

                        Actualizar();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ya existe un cliente con ese nombre o el número de telefóno ya está registrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar.");

            }
        }

        //Mostrar Direcciones
        public void MostrarDirecciones()
        {
            DominioDirecciones direcciones = new DominioDirecciones();
            comboBoxDirecciones.ValueMember = "codigo";
            comboBoxDirecciones.DisplayMember = "dirrecion";
            comboBoxDirecciones.DataSource = direcciones.ShowAddresses();
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

        //Agregar direccion
        private void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            FormAgregarDirecion agregarDirecion = new FormAgregarDirecion();
            //Indico que este formulario abrio el formulario de direcciones
            agregarDirecion.quienAbrioFormulario = "DetalleCliente";
            AbrirFormulario(agregarDirecion);
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
    }
}
