using System;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Dominio;

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

        public FormReportes()
        {
            InitializeComponent();
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ConsultarCotizaciones() 
        {
            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;
            
            gridViewReportes.DataSource = reporte.consultQuotes(
                new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 00, 00, 00),
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
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
            else if (comboReportes.SelectedIndex == 1 && radioButtonDetallado.Checked)
            {
                ReporteDetalladosSalidas();
                tituloReporte = "Reporte de ventas detallado";
            }
            else if (comboReportes.SelectedIndex == 2) 
            {
                ConsultarCotizaciones();
                tituloReporte = "Cotizaciones";
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
            if (gridViewReportes.Rows.Count != 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "ReporteInventario";
                save.DefaultExt = "pdf";

                if (comboReportes.SelectedIndex != 2) 
                {
                    //Calcular total de reportes
                    foreach (DataGridViewRow fila in gridViewReportes.Rows)
                    {
                        total += float.Parse(fila.Cells[gridViewReportes.Columns.Count - 1].Value.ToString());
                    }
                }
                else
                {
                    //Calcular total de cotizaciones
                    foreach (DataGridViewRow fila in gridViewReportes.Rows)
                    {
                        total += float.Parse(fila.Cells[gridViewReportes.Columns.Count - 2].Value.ToString());
                    }
                }

                if (save.ShowDialog() == DialogResult.OK)
                {
                    exportarPdf.GenerarReporte(gridViewReportes, save.FileName, tituloReporte, total);
                }

                total = 0;
            }
        }
    }
}
