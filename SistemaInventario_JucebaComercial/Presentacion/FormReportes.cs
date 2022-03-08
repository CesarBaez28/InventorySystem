using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using Dominio;
using System.Drawing;

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

        public FormReportes()
        {
            InitializeComponent();
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
                diseñoCotizaciones = true;
            }
            else //Diseño original
            {
                if (diseñoCotizaciones == true) 
                {
                    designOriginal();
                    gridViewReportes.DataSource = "";
                    diseñoCotizaciones = false;
                }
            }
        }

        //Reporte General de entradas
        private void ReporteGeneralEntrada() 
        {
             fechaInicial = dateTimeFechaInicio.Value;
             fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.GeneralEntryReport(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00,00,00),
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
        private void ConsultarCotizacionesPorEstado() 
        {
            gridViewReportes.DataSource = reporte.ConsultQuotesByStatus(estadoCotizacion);
        }

        //Consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //Reporte entradas general
            if (comboReportes.SelectedIndex == 0 && radioButtonGeneral.Checked)
            {
                ReporteGeneralEntrada();
                tituloReporte = "Reporte de compras general";
            }
            //Reporte entradas detalllado
            else if (comboReportes.SelectedIndex == 0 && radioButtonDetallado.Checked)
            {
                ReporteDetalladoEntrada();
                tituloReporte = "Reporte de compras detallado";
            }
            //Reporte salidas general
            else if (comboReportes.SelectedIndex == 1 && radioButtonGeneral.Checked)
            {
                ReporteGeneralSalidas();
                tituloReporte = "Reporte de ventas general";
            }
            //Reporte salida detallado
            else if (comboReportes.SelectedIndex == 1 && radioButtonDetallado.Checked)
            {
                ReporteDetalladosSalidas();
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
                        if (int.TryParse(txbBuscar.Text, out int parceCorrecto))
                        {
                            ConsultarCotizacionesPorCodigo();
                        }
                    }
                    //Consultar por descripción
                    else if (comboBuscar.SelectedIndex == 1)
                    {
                        ConsultarCotizacionesPorDescripcion();
                    }
                    //Buscar por cliente
                    else if (comboBuscar.SelectedIndex == 2)
                    {
                        ConsultarCotizacionesPorCliente();
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
            if(gridViewReportes.Rows.Count != 0)
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

                    save.FileName = "Cotización"+codigoCotizacion;

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

        private void gridViewReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (gridViewReportes.SelectedCells.Count > 0)
                {
                     
                }
                else
                {
                    MessageBox.Show("Selecione una celda");
                }
            }
        }
    }
}
