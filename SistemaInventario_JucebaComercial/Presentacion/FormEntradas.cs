using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public partial class FormEntradas : Form
    {
        float parseCorrecto;
        int codigo_tipoRegistro = 1; //Este codigo indica que, en la base de datos, el registro ingresado sera de tipo ingreso.

        public FormEntradas()
        {
            InitializeComponent();
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //if (float.TryParse(txbMonto.Text, out parseCorrecto))
            //{
            //    int indice = gridViewEntradas.Rows.Add();

            //    gridViewIngresos.Rows[indice].Cells[0].Value = txbCliente.Text;
            //    gridViewIngresos.Rows[indice].Cells[1].Value = txbServicio.Text;
            //    gridViewIngresos.Rows[indice].Cells[2].Value = txbComentario.Text;
            //    gridViewIngresos.Rows[indice].Cells[3].Value = dateTimeIngreso.Text;
            //    gridViewIngresos.Rows[indice].Cells[4].Value = txbMonto.Text;

            //    BorrarCampos();
            //}
            //else
            //{
            //    MessageBox.Show("El monto ingrsado no es válido");

            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewEntradas.SelectedRows.Count > 0) 
            {
                //gridViewEntradas.Rows.Remove(gridViewEntradas.CurrentRow);
            }
        }

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
        }

        private void btnAgregarSuplidor_Click(object sender, EventArgs e)
        {
            //FormDetalleProveedor detalleSuplidor = new FormDetalleProveedor();
            //detalleCliente.UpdateEventHendler += ActualizarEventHandler;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            //detalleSuplidor.lblEstado.Visible = false;
            //detalleSuplidor.cbxEstado.Visible = false;
            //detalleSuplidor.Size = new Size(260, 310);
            //detalleSuplidor.btnAceptar.Location = new Point(15, 232);
            //detalleSuplidor.btnCancelar.Location = new Point(129, 232);

            //AbrirFormulario(detalleSuplidor);
        }

        private void btnAgregarTipoMaterial_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAgregarTipoMaterial());
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
