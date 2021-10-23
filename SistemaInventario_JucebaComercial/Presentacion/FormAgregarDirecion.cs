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


        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
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
