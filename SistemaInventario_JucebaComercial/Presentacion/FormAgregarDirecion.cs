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
    public partial class FormAgregarDirecion : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario
        bool Actualizar = false; //La uso para indicar si se va a actualizar o insertar
        string direccionActualizar; //Lo uso para guardar el nombre de la direccion que se desea actualizar

        DominioDirecciones direcciones = new DominioDirecciones();

        public FormAgregarDirecion()
        {
            InitializeComponent();
        }

        private void FormAgregarDirecion_Load(object sender, EventArgs e)
        {
            MostrarDirecciones();
        }


        //Mostrar todas las direcciones
        public void MostrarDirecciones() 
        {
            DataTable table = new DataTable();
            table = direcciones.ShowAddresses();

            foreach (DataRow fila in table.Rows) 
            {
                int indice = gridViewDirecciones.Rows.Add();
                gridViewDirecciones.Rows[indice].Cells[1].Value = fila["dirrecion"].ToString();
            }
        }

        //Boton Aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txbNombre.Text != "")
            {

                //Insertar
                if (Actualizar == false)
                {
                    direcciones.RegisterAddress(txbNombre.Text);
                    MessageBox.Show("Registro insertado");
                    txbNombre.Text = "";
                }
                //Actualizar
                else
                {

                    Actualizar = false;
                    txbNombre.Text = "";
                    MessageBox.Show("Registro actualizado");
                }

                gridViewDirecciones.DataSource = null;
                gridViewDirecciones.Rows.Clear();
                FormDetalleCliente.detalleCliente.MostrarDirecciones();
                MostrarDirecciones();
            }
            else
            {
                MessageBox.Show("El campo está vacío");
            }

        }

        private void gridViewDirecciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Primer columna
            if (e.ColumnIndex == 0) 
            {
                //Verifico que se haya seleccionado una fila
                if (gridViewDirecciones.SelectedCells.Count > 0)
                {
                    Actualizar = true;
                    txbNombre.Text = gridViewDirecciones.CurrentRow.Cells[1].Value.ToString();
                    direccionActualizar = gridViewDirecciones.CurrentRow.Cells[1].Value.ToString();
                }
                else 
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
