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
    public partial class FormDetalleCliente : Form
    {
        int posX, posY;

        public static FormDetalleCliente detalleCliente;
        
        public FormDetalleCliente(FormCliente formClientes)
        {
            InitializeComponent();
            FormDetalleCliente.detalleCliente = this;
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

        //Actuarlizar la lista de empleados al insertar o actualizar uno.
        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHendler.Invoke(this, args);
        }

        private void FormDetalleCliente_Load(object sender, EventArgs e)
        {
            MostrarDirecciones();
        }

        //Insertar cliente
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DominioCliente cliente = new DominioCliente();

            //Confirmo que los campos esten llenos
            if (txbNombre.Text != "" && txtTelefono.Text != "")
            {
                cliente.RegisterCostumer(txtTelefono.Text, comboBoxDirecciones.SelectedValue.ToString(), 
                    txbNombre.Text);
                Actualizar();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Faltan campos por llenar");
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
            AbrirFormulario(new FormAgregarDirecion());
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
