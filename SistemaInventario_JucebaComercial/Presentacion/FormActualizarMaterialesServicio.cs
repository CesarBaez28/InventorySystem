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
    public partial class FormActualizarMaterialesServicio : Form
    {
        int posX, posY;
        public int indiceFila; //Lo uso para guarda el indice de la fila para actualizar los datos
        public string material; //La uso para guar el texto del material y mostrarlo en el comboBox

        public FormActualizarMaterialesServicio()
        {
            InitializeComponent();
        }

        private void FormActualizarMaterialesServicio_Load(object sender, EventArgs e)
        {
            MostrarMateriales();
            comboMaterial.Text = material;
        }

        private void MostrarMateriales() 
        {
            DominioMateriales materiales = new DominioMateriales();
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
        }

        //Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FormDetallesServicio.detallesServicio.gridViewMateriales.Rows[indiceFila].Cells[0].Value = comboMaterial.SelectedValue.ToString();
            FormDetallesServicio.detallesServicio.gridViewMateriales.Rows[indiceFila].Cells[1].Value = comboMaterial.Text;
            FormDetallesServicio.detallesServicio.gridViewMateriales.Rows[indiceFila].Cells[2].Value = txbCantidad.Text;
            this.Close();
        }

        //Mover le formulario
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
