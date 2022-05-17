using Comun;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormReportes : Form
    {
        DominioReportes reporte = new DominioReportes();
        ExportarPdf exportarPdf = new ExportarPdf();
        DateTime fechaInicial;
        DateTime fechaFinal;

        float total; //Guardo aquí el total de los reportes
        string tituloReporte; //Guarda el título que tendrá el repote 
        bool diseñoCotizaciones = false;
        bool estadoCotizacion = false;
        string codigoCotizacion;

        public static FormReportes formReportes;

        public FormReportes()
        {
            InitializeComponent();
            FormReportes.formReportes = this;
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Ajusta los controles al diseño original
        private void designOriginal()
        {
            //Oculto los componentes no necesarios
            comboBuscar.Visible = false;
            lblBuscarPor.Visible = false;
            txbBuscar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnAprobar.Visible = false;

            //Muestro los componentes necesarios
            radioButtonDetallado.Visible = true;
            radioButtonGeneral.Visible = true;

            //Cambio localización de los componentes
            lblFechaInicio.Location = new Point(151, 50);
            dateTimeFechaInicio.Location = new Point(155, 74);

            lblFechaFin.Location = new Point(271, 50);
            dateTimeFechaFin.Location = new Point(275, 74);

            btnConsultar.Location = new Point(502, 74);
            btnLimpiar.Location = new Point(617, 74);
        }

        //Ajusta los controles al dieseño para consultar cotizaciones
        private void designQuote()
        {
            //Muestro los componentes necesarios
            comboBuscar.Visible = true;
            lblBuscarPor.Visible = true;
            txbBuscar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnAprobar.Visible = true;

            //Oculto los componentes no necesarios
            radioButtonDetallado.Visible = false;
            radioButtonGeneral.Visible = false;

            //Cambio localización de los componentes
            lblBuscarPor.Location = new Point(142, 50);
            comboBuscar.Location = new Point(146, 74);
            txbBuscar.Location = new Point(276, 74);

            lblFechaInicio.Location = new Point(445, 50);
            dateTimeFechaInicio.Location = new Point(449, 74);

            lblFechaFin.Location = new Point(556, 50);
            dateTimeFechaFin.Location = new Point(560, 74);

            btnConsultar.Location = new Point(688, 74);
            btnLimpiar.Location = new Point(794, 74);
        }

        private void comboReportes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Cambio el diseño al seleccionar la opción de cotizaciones
            if (comboReportes.SelectedIndex == 2)
            {
                designQuote();
                gridViewReportes.DataSource = null;
                diseñoCotizaciones = true;
            }
            else //Diseño original
            {
                if (diseñoCotizaciones == true)
                {
                    designOriginal();
                    diseñoCotizaciones = false;
                }

                gridViewReportes.DataSource = null;
            }
        }

        //Reporte General de entradas
        private void ReporteGeneralEntrada()
        {
            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.GeneralEntryReport(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00, 00, 00),
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
        }

        //Reporte detallado de entradas
        private void ReporteDetalladoEntrada()
        {
            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.DetailedEntryReport(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00, 00, 00),
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
        }

        //Reporte general de salidas
        private void ReporteGeneralSalidas()
        {
            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.GeneralSalesReport(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00, 00, 00),
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
        }

        //Reporte detallada de salidas
        private void ReporteDetalladosSalidas()
        {
            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.DetailedSalesReport(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00, 00, 00),
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
        }

        //Consultar cotizaciones 
        private void ConsultarCotizaciones()
        {
            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.consultQuotes(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00, 00, 00),
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
        }

        //Consultar cotizaciones por código
        private void ConsultarCotizacionesPorCodigo()
        {
            gridViewReportes.DataSource = reporte.ConsultQuotesByCode(txbBuscar.Text);
        }

        //Consular cotizaciones por descripción
        private void ConsultarCotizacionesPorDescripcion()
        {
            gridViewReportes.DataSource = reporte.ConsultQuotesByDescription(txbBuscar.Text);
        }

        //Consular cotizaciones por cliente
        private void ConsultarCotizacionesPorCliente()
        {
            gridViewReportes.DataSource = reporte.ConsultQuotesByClient(txbBuscar.Text);
        }

        //Consultar cotizaciones por estado
        public void ConsultarCotizacionesPorEstado()
        {
            gridViewReportes.DataSource = reporte.ConsultQuotesByStatus(estadoCotizacion);
        }

        //Manda un mensaje de error al no encontrar la información de una búsqueda
        private void BusquedaNoEncontrada()
        {
            //Si la buscqueda no tuvo éxito manda un mensaje de error.
            if (gridViewReportes.Rows.Count == 0)
            {
                gridViewReportes.DataSource = null;
                MessageBox.Show("No se ha encontrado la información solicitada.\n" +
                                "Verique lo datos suministrados sean correctos");
            }
        }

        //Consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Verifico si ya se ha realizado una consulta para limpiar los datos
            if (gridViewReportes.DataSource != null)
            {
                gridViewReportes.DataSource = null;
            }

            //Reporte entradas general
            if (comboReportes.SelectedIndex == 0 && radioButtonGeneral.Checked)
            {
                ReporteGeneralEntrada();
                BusquedaNoEncontrada();
                tituloReporte = "Reporte de compras general";
            }
            //Reporte entradas detalllado
            else if (comboReportes.SelectedIndex == 0 && radioButtonDetallado.Checked)
            {
                ReporteDetalladoEntrada();
                BusquedaNoEncontrada();
                tituloReporte = "Reporte de compras detallado";
            }
            //Reporte salidas general
            else if (comboReportes.SelectedIndex == 1 && radioButtonGeneral.Checked)
            {
                ReporteGeneralSalidas();
                BusquedaNoEncontrada();
                tituloReporte = "Reporte de ventas general";
            }
            //Reporte salida detallado
            else if (comboReportes.SelectedIndex == 1 && radioButtonDetallado.Checked)
            {
                ReporteDetalladosSalidas();
                BusquedaNoEncontrada();
                tituloReporte = "Reporte de ventas detallado";
            }
            //Cotizaciones
            else if (comboReportes.SelectedIndex == 2)
            {
                //Verifico haya una opción seleccionada 
                if (comboBuscar.SelectedIndex != -1)
                {
                    //Buscar por código
                    if (comboBuscar.SelectedIndex == 0)
                    {
                        //Verifico que el código se ha un número entero
                        //y que no esté vacío.
                        if (int.TryParse(txbBuscar.Text, out int parceCorrecto) && txbBuscar.Text != "")
                        {
                            ConsultarCotizacionesPorCodigo();
                            BusquedaNoEncontrada();
                        }
                        else
                        {
                            MessageBox.Show("El campo esta vacío o el código no es correcto");
                        }
                    }
                    //Consultar por descripción
                    else if (comboBuscar.SelectedIndex == 1)
                    {
                        if (txbBuscar.Text != "") //Verifico el campo no esté vacío
                        {
                            ConsultarCotizacionesPorDescripcion();
                            BusquedaNoEncontrada();
                        }
                        else
                        {
                            MessageBox.Show("El campo esta vacío");
                        }
                    }
                    //Buscar por cliente
                    else if (comboBuscar.SelectedIndex == 2)
                    {
                        if (txbBuscar.Text != "") //Verifico el campo no esté vacío
                        {
                            ConsultarCotizacionesPorCliente();
                            BusquedaNoEncontrada();
                        }
                        else
                        {
                            MessageBox.Show("El campo esta vacío");
                        }
                    }
                    //Buscar las aceptadas
                    else if (comboBuscar.SelectedIndex == 3)
                    {
                        estadoCotizacion = true;
                        ConsultarCotizacionesPorEstado();
                    }
                    //Buscar las no aceptadas
                    else if (comboBuscar.SelectedIndex == 4)
                    {
                        estadoCotizacion = false;
                        ConsultarCotizacionesPorEstado();
                    }
                    //Buscar cotizaciones por fecha
                    else if (comboBuscar.SelectedIndex == 5)
                    {
                        ConsultarCotizaciones();
                    }
                }
                else
                {
                    MessageBox.Show("Seleecione una opción");
                }

                tituloReporte = "Cotizaciones";
                txbBuscar.Text = "";
            }
        }

        //Limpirar consulta
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gridViewReportes.DataSource = null;
        }

        //Botón Exportar en Excel
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (gridViewReportes.Rows.Count != 0)
                ExportarDatosExcel(gridViewReportes);
        }

        //Funcionalidad para exportar datos en excel
        public void ExportarDatosExcel(DataGridView reporte)
        {
            Microsoft.Office.Interop.Excel.Application ExportarExcel = new Microsoft.Office.Interop.Excel.Application();

            ExportarExcel.Application.Workbooks.Add(true);

            int indiceColumna = 0;

            foreach (DataGridViewColumn columna in reporte.Columns)
            {
                indiceColumna++;

                ExportarExcel.Cells[1, indiceColumna] = columna.Name;
            }

            int indiceFila = 0;

            foreach (DataGridViewRow fila in reporte.Rows)
            {
                indiceFila++;
                indiceColumna = 0;

                foreach (DataGridViewColumn columna in reporte.Columns)
                {
                    indiceColumna++;
                    ExportarExcel.Cells[indiceFila + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }

            ExportarExcel.Visible = true;
        }

        //Botón Exportar en pdf
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            //Verifico que se haya realizado una consulta.
            if (gridViewReportes.Rows.Count != 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "pdf";

                //Entradas y salidas
                if (comboReportes.SelectedIndex != 2)
                {
                    save.FileName = "ReporteInventario";

                    //Calcular total de reportes
                    foreach (DataGridViewRow fila in gridViewReportes.Rows)
                    {
                        total += float.Parse(fila.Cells[gridViewReportes.Columns.Count - 1].Value.ToString());
                    }

                    //Generar reporte
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        exportarPdf.GenerarReporte(gridViewReportes, save.FileName, tituloReporte, total);
                    }
                }
                //Cotizaciones
                else
                {
                    codigoCotizacion = gridViewReportes.CurrentRow.Cells["Código"].Value.ToString();

                    save.FileName = "Cotización" + codigoCotizacion;

                    //Obtengo los datos para crear la cotización
                    DataTable detallesCotizacion = reporte.ConsultDatailedQuote(codigoCotizacion);
                    DataTable metadatosCotizacion = reporte.ConsultMetadataQuote(codigoCotizacion);

                    //Establezco los datos de la cotización
                    string nombreEmpresa = "Juceba Comercial";
                    string nombreUsuario = metadatosCotizacion.Rows[0]["Usuario"].ToString();
                    string cliente = metadatosCotizacion.Rows[0]["Cliente"].ToString();
                    DateTime fecha = Convert.ToDateTime(metadatosCotizacion.Rows[0]["Fecha"]);
                    total = Convert.ToInt32(metadatosCotizacion.Rows[0]["Total"]);

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        exportarPdf.GenerarCotizacion(detallesCotizacion, save.FileName, nombreEmpresa, cliente,
                        nombreUsuario, Convert.ToInt32(codigoCotizacion), total, fecha);
                    }
                }

                total = 0;
            }
        }

        //Aprobar una cotización 
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            //Me aseguro haya una fila seleccionada
            if (gridViewReportes.SelectedRows.Count > 0)
            {
                //Verifico que la cotización seleccionada no esté aprobada
                if (gridViewReportes.CurrentRow.Cells["Estado"].Value.ToString() != "Aceptado")
                {
                    const string message = "¿Estar seguro de aprobar esta cotización?";
                    const string caption = "Advertencia";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DominioCotizaciones cotizaciones = new DominioCotizaciones();

                        //Obtengo todos los datos de la cotización
                        codigoCotizacion = gridViewReportes.CurrentRow.Cells["Código"].Value.ToString();
                        DataTable detallesCotizacion = reporte.ConsultDatailedQuote(codigoCotizacion);
                        DataTable metadatosCotizacion = reporte.ConsultMetadataQuote(codigoCotizacion);

                        DominioSalida salida = new DominioSalida(); //Creo objeto DominioSalida para aprobar la cotización

                        //Registro la salida
                        salida.SaleOfService(DateTime.Now);

                        //Obtengo el último código de la salida. Lo necesito para insertar los detalles de la salida
                        int codigoSalida = Convert.ToInt32(salida.GetCodeSale().Rows[0]["codigo"]);

                        //Creo una lista para guardar cada uno de los detalles de la salida
                        List<DetallesSalida> listaDetalles = new List<DetallesSalida>();

                        //Guardo cada uno de los detalles de la salida en la lista
                        foreach (DataRow fila in detallesCotizacion.Rows)
                        {
                            var detalles = new DetallesSalida()
                            {
                                codigo_salida = codigoSalida,
                                codigo_servicio = Convert.ToInt32(fila["Código Servicio"]),
                                codigo_cliente = Convert.ToInt32(metadatosCotizacion.Rows[0]["Código cliente"]),
                                codigo_usuario = UsuarioLoginCache.Codigo_usuario,
                                precio = float.Parse(fila["Monto"].ToString()),
                                cantidad = Convert.ToInt32(fila["Cantidad"])
                            };

                            listaDetalles.Add(detalles);
                        }

                        try
                        {
                            //Registrar detalles de la salida
                            salida.add_MultipleSingleInsert(listaDetalles);

                            //Cambiar estado de cotización a aceptado
                            cotizaciones.ApproveQuote(codigoCotizacion, true);

                            MessageBox.Show("Cotizacón aprobada");

                            estadoCotizacion = false;
                            ConsultarCotizacionesPorEstado();
                        }
                        catch
                        {
                            //Si no hay materiales suficiente para aprobar la cotización, vuelvo a cambiar el estado de la cotización a no aceptado (Es decir, false)
                            cotizaciones.ApproveQuote(codigoCotizacion, false);
                            MessageBox.Show("No hay suficiente material para registrar uno de los servicios");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Esa cotización ya fue aprobada");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        //Eliminar una cotización 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Me aseguro haya una fila seleccionada
            if (gridViewReportes.SelectedRows.Count > 0)
            {
                const string message = "¿Estar seguro de borrar este registro?";
                const string caption = "Advertencia";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DominioCotizaciones cotizaciones = new DominioCotizaciones();
                    codigoCotizacion = gridViewReportes.CurrentRow.Cells["Código"].Value.ToString();

                    cotizaciones.DeleteDetailsQuote(codigoCotizacion);//Borro los detalles de la cotización
                    cotizaciones.DeleteQuote(codigoCotizacion);//Borro la cotización 

                    estadoCotizacion = false;
                    ConsultarCotizacionesPorEstado();
                }
            }
        }

        //Editar una cotización
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Me aseguro que haya una fila seleccionada
            if (gridViewReportes.SelectedRows.Count > 0)
            {
                FormEditarCotizacion editarCotizacion = new FormEditarCotizacion();

                editarCotizacion.nombreCliente = gridViewReportes.CurrentRow.Cells["Cliente"].Value.ToString();
                editarCotizacion.codigoCotizacion = gridViewReportes.CurrentRow.Cells["Código"].Value.ToString();
                editarCotizacion.fecha = gridViewReportes.CurrentRow.Cells["Fecha"].Value.ToString();
                //editarCotizacion.lblTotalCotizacion.Text = "Total: "+ gridViewReportes.CurrentRow.Cells["Total"].Value.ToString();
                //editarCotizacion.total = gridViewReportes.CurrentRow.Cells["Total"].Value.ToString();
                editarCotizacion.descripcion = gridViewReportes.CurrentRow.Cells["Descripción"].Value.ToString();

                if (gridViewReportes.CurrentRow.Cells["Estado"].Value.ToString() == "Aceptado")
                {
                    editarCotizacion.estadoCotizacion = true;
                }
                else
                {
                    editarCotizacion.estadoCotizacion = false;
                }

                AbrirFormulario(editarCotizacion);
            }
        }


        //Metodo para abrir fomulario
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
