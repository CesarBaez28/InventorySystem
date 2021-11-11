﻿using System;
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
    public partial class FormDetallesServicio : Form
    {
        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario
        int parseCorrecto; //La uso para verificar que la cantidad de materiales se ha un numero entero 
        bool estadoServicio;// la uso para indicar el estado del servicio (activo o inactivo)

        //La uso para actualizar la lista de materiales desde el Form FormDetallesMateriales
        public static FormDetallesServicio detallesServicio;

        public FormDetallesServicio()
        {
            InitializeComponent();
            FormDetallesServicio.detallesServicio = this;
        }

        private void FormDetallesServicio_Load(object sender, EventArgs e)
        {
            MostrarMateriales();
        }

        public void MostrarMateriales() 
        {
            DominioMateriales materiales = new DominioMateriales();
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
        }

        //Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cerrar el formulario
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //Actualizar materiales del servicio
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (gridViewMateriales.SelectedRows.Count > 0)
            {
                FormActualizarMaterialesServicio materialesServicio = new FormActualizarMaterialesServicio();

                materialesServicio.txbCantidad.Text = gridViewMateriales.CurrentRow.Cells["Cantidad"].Value.ToString();
                materialesServicio.material = gridViewMateriales.CurrentRow.Cells["Material"].Value.ToString();
                materialesServicio.indiceFila = gridViewMateriales.CurrentCell.RowIndex;

                AbrirFormulario(materialesServicio);
            }
            else 
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        //Boton Terminar
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DominioServicios servicios = new DominioServicios();

            //Verifico que el datagridView tenga valores y que se haya ingresa un nombre al servicio
            if (gridViewMateriales.Rows.Count != 0 && txbNombreServicio.Text != "")
            {
                //Verifico que el precio se ha un numero correcto
                if (float.TryParse(txbPrecio.Text, out float parseCorrecto))
                {
                    if (cbxEstado.Text == "Activo")
                        estadoServicio = true;
                    else
                        estadoServicio = false;

                    //Registro nuevo servicio
                    servicios.RegisterService(txbNombreServicio.Text, txbDescripcionServicio.Text, txbPrecio.Text, estadoServicio);

                    //Registro materiales que incluye el servicio
                    foreach (DataGridViewRow fila in gridViewMateriales.Rows)
                    {
                        servicios.RegisterMaterialService(fila.Cells[0].Value.ToString(), fila.Cells[2].Value.ToString());
                    }

                    MessageBox.Show("Registrado correctamente");
                    BorrarCampos();
                }
            }
        }

        //Agregar Excedente
        private void btnAgregarExcedente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAgregarExcedente());
        }

        //Agregar Material
        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            FormDetalleMateriales detalleMateriales = new FormDetalleMateriales();
            detalleMateriales.formDetallesServicios = true;
            AbrirFormulario(detalleMateriales);
        }

        //boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbCantidad.Text, out parseCorrecto))
            {
                int indice = gridViewMateriales.Rows.Add();

                gridViewMateriales.Rows[indice].Cells[0].Value = comboMaterial.SelectedValue.ToString();
                gridViewMateriales.Rows[indice].Cells[1].Value = comboMaterial.Text;
                gridViewMateriales.Rows[indice].Cells[2].Value = txbCantidad.Text;
            }
            else 
            {
                MessageBox.Show("La cantidad ingresada no es correcta");
            }
        }

        //Boton eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewMateriales.SelectedRows.Count > 0)
            {
                gridViewMateriales.Rows.Remove(gridViewMateriales.CurrentRow);
            }
        }

        //BorrarCampos
        private void BorrarCampos() 
        {
            txbPrecio.Text = "";
            txbDescripcionServicio.Text = "";
            txbNombreServicio.Text = "";
            gridViewMateriales.Rows.Clear();
        }

        //Mover el formulario
        private void label1_MouseMove(object sender, MouseEventArgs e)
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

        //Metodo para abir formulario
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
