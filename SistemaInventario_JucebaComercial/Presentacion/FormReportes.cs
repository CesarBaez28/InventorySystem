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
            else if(comboReportes.SelectedIndex == 1 && radioButtonDetallado.Checked)
            {
                ReporteDetalladosSalidas();
                tituloReporte = "Reporte de ventas detallado";
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

        //Funcionalidad exportar a PDF
        private void ExportarDatosPDF(DataGridView dataGridView, string pdfRuta, string header, float total) 
        {
            System.IO.FileStream fileStream = new FileStream(pdfRuta, FileMode.Create, FileAccess.Write, FileShare.None);
            Document reporte = new Document();
            reporte.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(reporte, fileStream);
            reporte.Open();

            //Cabecera del reporte
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(header.ToUpper(), fntHead));
            reporte.Add(prgHeading);

            //Autor, fecha, dirección
            Paragraph prgAuthorDateAdress = new Paragraph();
            BaseFont btnAuthorDateAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthorDateAdress = new iTextSharp.text.Font(btnAuthorDateAdress, 8, 2, BaseColor.GRAY);
            prgAuthorDateAdress.Alignment = Element.ALIGN_RIGHT;
            prgAuthorDateAdress.Add(new Chunk("Autor : Julio César Báez", fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nJánico, Santiago RD", fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nFederico Pichardo #90", fntAuthorDateAdress));
            reporte.Add(prgAuthorDateAdress);

            //añadir linea de separación 
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            reporte.Add(p);

            //añadir espacio
            reporte.Add(new Chunk("\n", fntHead));

            //Escribir la tabla
            PdfPTable table = new PdfPTable(gridViewReportes.Columns.Count);
            table.WidthPercentage = 100; //La tabla ocupa el 100 porciento del documento

            //Cabecera de la tabla
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            table.HorizontalAlignment = Element.ALIGN_CENTER;

            //Escribir cabecera
            for (int i = 0; i < gridViewReportes.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(gridViewReportes.Columns[i].HeaderText.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //Ingresar datos a la tabla
            for (int i = 0; i < gridViewReportes.Rows.Count; i++)
            {
                for (int j = 0; j < gridViewReportes.Columns.Count; j++)
                {
                    table.AddCell(gridViewReportes.Rows[i].Cells[j].Value.ToString());
                }
            }
            reporte.Add(table);

            //Total del reporte
            Paragraph prgTotal = new Paragraph();
            BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntTotal = new iTextSharp.text.Font(btnTotal, 12, 1, BaseColor.BLACK);
            prgTotal.Alignment = Element.ALIGN_RIGHT;
            prgTotal.Add(new Chunk("Total: " + total.ToString(), fntTotal));
            reporte.Add(prgTotal);

            reporte.Close();
            writer.Close();
            fileStream.Close();
        }

        //Botón Exportar en pdf
        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (gridViewReportes.Rows.Count != 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "ReporteInventario";
                save.DefaultExt = "pdf";

                foreach (DataGridViewRow fila in gridViewReportes.Rows)
                {
                    total += float.Parse(fila.Cells[gridViewReportes.Columns.Count - 1].Value.ToString());
                }

                if (save.ShowDialog() == DialogResult.OK)
                {
                    ExportarDatosPDF(gridViewReportes, save.FileName, tituloReporte, total);
                }

                total = 0;
            }
        }
    }
}
