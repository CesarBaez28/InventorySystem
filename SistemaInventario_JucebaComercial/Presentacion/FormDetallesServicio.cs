using Dominio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormDetallesServicio : Form
    {
        DominioServicios servicios = new DominioServicios();

        int posX, posY; //Las uso para obtener las cordenadas y poder mover el formulario.
        int parseCorrecto; //La uso para verificar que la cantidad de materiales se ha un número entero.
        bool estadoServicio; // la uso para indicar el estado del servicio (activo o inactivo).
        public bool actualizar = false; // La uso para indicar cúando se va a insertar o actualizar.
        public string codigoServicio; //Guardo el código del servicio para actualizar y mostrar datos del mismo.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer material, verificar si este u otros se agregan repetidos.
        bool yaIncluido = false; //La uso para validar que no se ingrese un material repetido.
        public bool formSalidas; //La uso para indicar si el FormSalidas abrió este formulario.
        public bool formCotizar; //La uso para indicar si el FormSalidas abrió este formulario.
        public int indiceFila; // La uso para guardar la posición de la fila seleccionada del datagridView del FormSalidas para poder actualizar los datos.
        public float precioAnterior; // Guardo el precio anterior para actualizar el total de la salida o de la cotización.
        public float nuevoTotal; //Guardo el nuevo total general si se actualiza el precio de un servicio.
        public int cantidad; // Guardo la cantidad para actualizar el total si se actualiza el precio de un servicio.
        float total_individual; // Guardo el total indivual si se actualiza el precio de un servicio.


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

            if (actualizar == true)
                MostrarMaterialesServicio();
        }

        //Mostrar materiales en el comboboxMateriales
        public void MostrarMateriales()
        {
            DominioMateriales materiales = new DominioMateriales();
            comboMaterial.ValueMember = "codigo";
            comboMaterial.DisplayMember = "Material";
            comboMaterial.DataSource = materiales.NamesCodesMaterials();
        }

        //Mostrar materiales en el datagridview
        public void MostrarMaterialesServicio()
        {
            DominioServicios servicios = new DominioServicios();
            gridViewMateriales.DataSource = servicios.ShowMaterialsServices(codigoServicio);
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

                if (actualizar == true)
                {
                    materialesServicio.actualizar = true;
                    materialesServicio.codigoServicio = codigoServicio;
                }

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

                    //Insertar
                    if (actualizar == false)
                    {
                        //Registro nuevo servicio
                        try
                        {
                            servicios.RegisterService(txbNombreServicio.Text, txbDescripcionServicio.Text, txbPrecio.Text, estadoServicio);

                            //Registro materiales que incluye el servicio
                            foreach (DataGridViewRow fila in gridViewMateriales.Rows)
                            {
                                servicios.RegisterMaterialService(fila.Cells[0].Value.ToString(), fila.Cells[2].Value.ToString());
                            }

                            if (formSalidas == true) //Verifico si el FormSalidas abrió este formulario.
                            {
                                //Actualizo la lista de servicio en FormSalidas
                                FormSalidas.formSalidas.MostrarServicios();
                            }
                            else if (formCotizar == true) //Verifico si el FormCotizar abrió este formulario.
                            {
                                //Actualizo la lista de servicios en FormCotizar
                                FormCotizar.formCotizar.MostrarServicios();
                            }
                            else
                            {   //Actualizo lista servicios en FormServicios
                                FormServicios.formServicios.MostrarServicios();
                            }

                            MessageBox.Show("Registrado correctamente");
                            BorrarCampos();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe un servicio con ese nombre");
                        }
                    }
                    //Actualizar
                    else
                    {
                        //Actualizo datos generales del servicio
                        try
                        {
                            servicios.UpdateService(codigoServicio, txbNombreServicio.Text, txbPrecio.Text,
                                txbDescripcionServicio.Text, estadoServicio);

                            float nuevo_precio = float.Parse(txbPrecio.Text);

                            //Calculo el nuevo total general e individual si se cambió el precio de un servicio
                            if (precioAnterior != nuevo_precio)
                            {
                                total_individual = cantidad * nuevo_precio; //Calculo el nuevo total individual.
                                float total_indivual_anterior = cantidad * precioAnterior; //Calculo el total individual anterior
                                float diferencia = (total_indivual_anterior - total_individual) * -1; //Calculo la diferencia del precio.
                                nuevoTotal += diferencia; //Nuevo total general.
                            }

                            if (formSalidas == true) //Verifico si el FormSalidas abrió este formulario.
                            {
                                //Actualizó los datos en el dataGridView y de la lista de servicios del FormSalida.
                                FormSalidas.formSalidas.MostrarServicios();
                                FormSalidas.formSalidas.gridViewSalidas.Rows[indiceFila].Cells["Servicio"].Value = txbNombreServicio.Text;
                                FormSalidas.formSalidas.gridViewSalidas.Rows[indiceFila].Cells["Monto"].Value = txbPrecio.Text;
                                FormSalidas.formSalidas.gridViewSalidas.Rows[indiceFila].Cells["Total_Salida"].Value = total_individual.ToString();
                                FormSalidas.formSalidas.total = nuevoTotal;
                                FormSalidas.formSalidas.lblTotalSalida.Text = "Total: " + nuevoTotal.ToString();
                                MessageBox.Show("Se actualizó correctamente");
                            }
                            else if (formCotizar == true) // Verifico si el FormCotizar abrió este formulario.
                            {
                                //Actualizó los datos en el dataGridView y de la lista de servicios del FormCotizar.
                                FormCotizar.formCotizar.MostrarServicios();
                                FormCotizar.formCotizar.gridViewCotizaciones.Rows[indiceFila].Cells["Servicio"].Value = txbNombreServicio.Text;
                                FormCotizar.formCotizar.gridViewCotizaciones.Rows[indiceFila].Cells["Monto"].Value = txbPrecio.Text;
                                FormCotizar.formCotizar.gridViewCotizaciones.Rows[indiceFila].Cells["Total_Salida"].Value = total_individual.ToString();
                                FormCotizar.formCotizar.total = nuevoTotal;
                                FormCotizar.formCotizar.lblTotalCotizacion.Text = "Total: " + nuevoTotal.ToString();
                                MessageBox.Show("Se actualizó correctamente");
                            }
                            else
                            {
                                // Actualizo lista servicios en FormServicios.
                                MessageBox.Show("Se actualizó correctamente");
                                FormServicios.formServicios.MostrarServicios();
                            }
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe un servicio con ese nombre");
                        }
                    }
                }
            }
        }

        //Agregar Material
        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            FormDetalleMateriales detalleMateriales = new FormDetalleMateriales();
            detalleMateriales.formDetallesServicios = true;
            AbrirFormulario(detalleMateriales);
        }

        //Agrega los materiales seleccionados al datagridView
        private void AgregarMaterial()
        {
            int indice = gridViewMateriales.Rows.Add();

            gridViewMateriales.Rows[indice].Cells[0].Value = comboMaterial.SelectedValue.ToString();
            gridViewMateriales.Rows[indice].Cells[1].Value = comboMaterial.Text;
            gridViewMateriales.Rows[indice].Cells[2].Value = txbCantidad.Text;
        }

        //boton Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txbCantidad.Text, out parseCorrecto))
            {
                if (actualizar == false)
                {
                    //Verifico si ya se ha ingresado un material
                    if (primerRegistro == false)
                    {
                        AgregarMaterial();
                        primerRegistro = true;
                        txbCantidad.Text = "";
                    }
                    else
                    {
                        //Verifico si el material agregado está repetido
                        foreach (DataGridViewRow fila in gridViewMateriales.Rows)
                        {
                            if (fila.Cells[0].Value.ToString() == comboMaterial.SelectedValue.ToString())
                            {
                                yaIncluido = true;
                                break;
                            }
                        }

                        //Si no está repetido, agrega el material. De lo contrario, arroja un mensaje de error.
                        if (yaIncluido != true)
                        {
                            AgregarMaterial();
                            txbCantidad.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ya ingresó ese material");
                            yaIncluido = false;
                        }
                    }
                }
                else
                {
                    try
                    {
                        servicios.RegisterNewMaterialService(codigoServicio,
                            comboMaterial.SelectedValue.ToString(), txbCantidad.Text);

                        txbCantidad.Text = "";
                        MostrarMaterialesServicio();
                    }
                    catch
                    {
                        MessageBox.Show("Ya ese material está  incluido en el servicio");
                    }
                }
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
                if (actualizar == false)
                {
                    gridViewMateriales.Rows.Remove(gridViewMateriales.CurrentRow);
                }
                else
                {
                    servicios.DeleteMaterialService(codigoServicio,
                        gridViewMateriales.CurrentRow.Cells["Código"].Value.ToString());

                    MostrarMaterialesServicio();
                }
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
