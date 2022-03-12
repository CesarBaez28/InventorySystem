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
    public partial class FormEditarCotizacion : Form
    {
        DominioCliente clientes = new DominioCliente();
        DominioServicios servicios = new DominioServicios();
        DominioReportes reporte = new DominioReportes();

        int posX, posY;
        int elementosAgregados = 0;

        //Se usan para guardar los datos de la cotización y mostrarlos en la interfaz gráfica
        public string nombreCliente;
        public string nombreServicio;
        public string codigoCotizacion;
        public string fecha;
        float totalCotizacion;
        public string descripcion;
        DataTable detallesCotizacion;

        bool primeraModificacion = false; // La uso para que el código del evento CellClick no se ejecute cuando esté cargando los datos desde la base de datos
        bool modificar = true; //La uso para que el código del evento CellClick se ejecute solo una vez al editar los datos del datagrisview.

        //Guardo la cantidad y el monto actual para que, cuando se editen de manera inccorrecta, vuelvan a tener los valores anteriores.
        int cantidadAnterior;
        float montoAnterior;

        public FormEditarCotizacion()
        {
            InitializeComponent();
        }

        //Cerrar
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

        //Evento load del formulario
        private void FormEditarCotizacion_Load(object sender, EventArgs e)
        {
            MostrarServicios(); //Mostrar los servicios
            MostrarClientes(); //Mostrar los clientes
            MostrarDetallesCotizacion(); //Mostras los datalles de la cotización 
            EliminarOrdenamiento(); //Eliminar la funcionalidad de ordenar en el datagridview

            comboClientes.Text = nombreCliente;
            dateTimeCotizacion.Value = Convert.ToDateTime(fecha);
            txbDescripcion.Text = descripcion;
            primeraModificacion = true;
        }

        //Mostrar los servicios
        private void MostrarServicios()
        {
            DataGridViewComboBoxColumn comboBoxColumn =
                gridViewCotizaciones.Columns["Servicio"] as DataGridViewComboBoxColumn;

            comboBoxColumn.ValueMember = "codigo";
            comboBoxColumn.DisplayMember = "nombre_servicio";
            comboBoxColumn.DataSource = servicios.ShowServicesNameCode();
        }

        //Mostrar los clientes
        private void MostrarClientes()
        {
            comboClientes.ValueMember = "codigo";
            comboClientes.DisplayMember = "nombre";
            comboClientes.DataSource = clientes.ShowCustumerNameCode();
        }

        //Mostrar detalles de la cotización 
        private void MostrarDetallesCotizacion()
        {
            //Obtengo los detalles
            detallesCotizacion = reporte.ConsultDatailedQuote(codigoCotizacion);

            //Muestro lo datos en el datagridView
            foreach (DataRow fila in detallesCotizacion.Rows)
            {
                agregarElemento(fila["Servicio"].ToString(),
                                fila["Monto"].ToString(),
                                fila["Cantidad"].ToString(),
                                fila["Total"].ToString());
            }
        }

        //Elimina la funcionalidad de ordamiento del dataGridView
        private void EliminarOrdenamiento()
        {
            foreach (DataGridViewColumn column in gridViewCotizaciones.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //Funcionalidad agregar nuevo elemento
        private void agregarElemento(string servicio, string monto, string cantidad, string total)
        {
            int indice = gridViewCotizaciones.Rows.Add();
            float total_servicio = Convert.ToInt32(cantidad) * float.Parse(monto); //Total del servicio

            gridViewCotizaciones.Rows[indice].Cells["Servicio"].Value = servicio;
            gridViewCotizaciones.Rows[indice].Cells["Monto"].Value = monto;
            gridViewCotizaciones.Rows[indice].Cells["Cantidad"].Value = cantidad;
            gridViewCotizaciones.Rows[indice].Cells["Total_Cotizacion"].Value = total;

            //Total de la salida
            totalCotizacion += total_servicio;
            lblTotalCotizacion.Text = "Total: " + totalCotizacion.ToString();
        }

        //Agrega nuevo elemento vacío
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarElemento("", "0.00", "0", "0.00");
            elementosAgregados += 1;
        }

        //Terminar y guardar los cambios
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DominioCotizaciones cotizacion = new DominioCotizaciones();

            //Obtengo los códigos de los detalles de la cotización 
            DataTable codigosDetalles = cotizacion.GetDetailsQuoteCodes(codigoCotizacion);

            //Editar cotización
            cotizacion.UpdateQuote(codigoCotizacion, dateTimeCotizacion.Value, txbDescripcion.Text);

            int indiceCodigoDetalle = 0;

            //Editar detalles de la cotización
            for (int indice = 0; indice < gridViewCotizaciones.Rows.Count - elementosAgregados; indice++)
            {
                cotizacion.UpdateDetailsQuote(codigosDetalles.Rows[indiceCodigoDetalle]["Código detalle"].ToString(),
                                              gridViewCotizaciones.Rows[indice].Cells["Servicio"].FormattedValue.ToString(),
                                              comboClientes.SelectedValue.ToString(),
                                              UsuarioLoginCache.Codigo_usuario.ToString(),
                                              gridViewCotizaciones.Rows[indice].Cells["Monto"].Value.ToString(),
                                              gridViewCotizaciones.Rows[indice].Cells["Cantidad"].Value.ToString());

                indiceCodigoDetalle++;
            }

            //Registro los nuevos registros que se agregaron
            if (elementosAgregados != 0)
            {
                for (int indice = gridViewCotizaciones.Rows.Count - (elementosAgregados); indice < gridViewCotizaciones.Rows.Count; indice++)
                {
                    cotizacion.RegisterDetailsQuoteNew(codigoCotizacion, UsuarioLoginCache.Codigo_usuario.ToString(),
                                                    gridViewCotizaciones.Rows[indice].Cells["Servicio"].FormattedValue.ToString(),
                                                    comboClientes.SelectedValue.ToString(),
                                                    gridViewCotizaciones.Rows[indice].Cells["Cantidad"].Value.ToString(),
                                                    gridViewCotizaciones.Rows[indice].Cells["Monto"].Value.ToString());
                }
            }

            MessageBox.Show("Datos actualizados");
            elementosAgregados = 0;
        }

        //Eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Me aseguro haya una fila seleccionada
            if (gridViewCotizaciones.SelectedRows.Count > 0)
            {
                const string message = "¿Estar seguro de borrar este registro?";
                const string caption = "Advertencia";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //...
                }
            }
        }

        //Se utiliza este vento para confirmar si los valores del monto y la cantidad son correcctos al editarlos.
        //También, se calculan los nuevos totales al modificarlos correctamente. 
        private void gridViewCotizaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {   //Evito que se ejecute el código de este evento al llenar el datagridview con los datos de la base de datos.         
            if (primeraModificacion != false)
            {   //Uso est condición para que el código del evento se ejecute solo una vez al editar los datos del datagridview
                if (modificar == true)
                {   //Verifico que lo nuevos datos sean correctos. 
                    if (int.TryParse(gridViewCotizaciones.CurrentRow.Cells["Cantidad"].Value.ToString(), out int parseCorrecto) && float.TryParse(gridViewCotizaciones.CurrentRow.Cells["Monto"].Value.ToString(), out float parseCorrecto2))
                    {
                        //Calculo el nuevo total del servicio modificado
                        int cantidad = Convert.ToInt32(gridViewCotizaciones.CurrentRow.Cells["Cantidad"].Value);
                        float monto = float.Parse(gridViewCotizaciones.CurrentRow.Cells["Monto"].Value.ToString());
                        float total = cantidad * monto;
                        float totalAnterior = float.Parse(gridViewCotizaciones.CurrentRow.Cells["Total_Cotizacion"].Value.ToString());
                        modificar = false;

                        if (float.Parse(gridViewCotizaciones.CurrentRow.Cells["Total_Cotizacion"].Value.ToString()) != total)
                        {
                            float diferencia = (totalAnterior - total) * -1; //Calculo la diferencia del total.
                            totalCotizacion += diferencia; //Actualizo el total general de la cotización.
                            lblTotalCotizacion.Text = "Total: " + totalCotizacion.ToString();
                        }

                        gridViewCotizaciones.CurrentRow.Cells["Total_Cotizacion"].Value = total.ToString() + ".00";
                    }
                    else
                    {
                        modificar = false;
                        MessageBox.Show("La cantidad ingresada no es válida");

                        if (e.ColumnIndex == this.gridViewCotizaciones.Columns["Cantidad"].Index)
                        {
                            gridViewCotizaciones.CurrentRow.Cells["Cantidad"].Value = cantidadAnterior.ToString();
                        }
                        else
                        {
                            gridViewCotizaciones.CurrentRow.Cells["Monto"].Value = montoAnterior.ToString() + ".00";
                        }
                    }

                    modificar = true;
                }
            }
        }

        //Se utiliza este evento para guardar el monto y cantidad actual 
        //para cuando se editen dichos valores de manera incorrecta, y vuelvan a tener los valores originales.
        private void gridViewCotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridViewCotizaciones.Columns["Cantidad"].Index)
            {
                cantidadAnterior = Convert.ToInt32(gridViewCotizaciones.CurrentRow.Cells["Cantidad"].Value);
            }
            else if (e.ColumnIndex == this.gridViewCotizaciones.Columns["Monto"].Index)
            {
                montoAnterior = float.Parse(gridViewCotizaciones.CurrentRow.Cells["Monto"].Value.ToString());
            }
        }

        ComboBox combo;
        string opcionAnterior = ""; //Guarda la selección anterior del combobox
        int contadorServicios = 0; //Cuenta cuandas veces aperece un servicio en el combobox
        private void gridViewCotizaciones_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            combo = e.Control as ComboBox;
            if (combo != null) 
            { 
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChanged);
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            }
        }

        string selected; //Guarda el texto del nuevo servicio seleccionado
        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (sender as ComboBox).Text;
            opcionAnterior = gridViewCotizaciones.CurrentRow.Cells["Servicio"].FormattedValue.ToString();
            gridViewCotizaciones.CurrentRow.Cells["Servicio"].Value = selected;

            //Verifico que el servicio no esté repetido 
            //Si se encuentra más de una vez 
            foreach (DataGridViewRow fila in gridViewCotizaciones.Rows)
            {
                if (fila.Cells["Servicio"].FormattedValue.ToString() == selected)
                {
                    contadorServicios += 1;

                    if (contadorServicios > 1) 
                    {
                        break;
                    }
                }
            }
        }

        private void gridViewCotizaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (combo != null) 
            {
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChanged);

                if (contadorServicios > 1)
                {
                    MessageBox.Show("Ya ha seleccionado el servicio " + selected);
                    gridViewCotizaciones.CurrentRow.Cells["Servicio"].Value = opcionAnterior;
                }

                contadorServicios = 0;
            }
        }

        // Este evento se usa para evitar el error de DataGridviewComboboxCell
        private void gridViewCotizaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
