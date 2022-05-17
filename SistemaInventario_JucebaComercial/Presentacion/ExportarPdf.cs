using Comun;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Presentacion
{
    public class ExportarPdf
    {
        //Funcionalidad generar reportes de entradas y salidas en pdf
        public void GenerarReporte(DataGridView dataGridView, string pdfRuta, string header, float total)
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
            PdfPTable table = new PdfPTable(dataGridView.Columns.Count);
            table.WidthPercentage = 100; //La tabla ocupa el 100 porciento del documento

            //Cabecera de la tabla
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            table.HorizontalAlignment = Element.ALIGN_CENTER;

            //Escribir cabecera
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dataGridView.Columns[i].HeaderText.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //Ingresar datos a la tabla
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    table.AddCell(dataGridView.Rows[i].Cells[j].Value.ToString());
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

        //Crear cotización
        public void GenerarCotizacion(DataGridView dataGridView, string pdfRuta, string header, string cliente, string usuario, int numeroCotizacion, float total, DateTime fecha)
        {
            System.IO.FileStream fileStream = new FileStream(pdfRuta, FileMode.Create, FileAccess.Write, FileShare.None);
            Document factura = new Document();
            factura.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(factura, fileStream);
            factura.Open();

            //Cabecera del reporte
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 12, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(header.ToUpper(), fntHead));
            factura.Add(prgHeading);

            //Dirección
            BaseFont bfnAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAdress = new iTextSharp.text.Font(bfnAdress, 10, 1, BaseColor.GRAY);
            Paragraph prgAdress = new Paragraph();
            prgAdress.Alignment = Element.ALIGN_CENTER;
            prgAdress.Add(new Chunk("Jánico, Santiago RD", fntAdress));
            prgAdress.Add(new Chunk("\nFederico Pichardo #90", fntAdress));
            factura.Add(prgAdress);

            //añadir linea de separación 
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            factura.Add(p);

            //Factura de venta
            BaseFont bfnFacturaVenta = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntFacturaVenta = new iTextSharp.text.Font(bfnFacturaVenta, 10, 1, BaseColor.GRAY);
            Paragraph prgFacturaVenta = new Paragraph();
            prgFacturaVenta.Alignment = Element.ALIGN_CENTER;
            prgFacturaVenta.Add(new Chunk("COTIZACIÓN", fntFacturaVenta));
            factura.Add(prgFacturaVenta);

            //Empleado, fecha, cliente, número de factura
            Paragraph prgAuthorDateAdress = new Paragraph();
            BaseFont btnAuthorDateAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthorDateAdress = new iTextSharp.text.Font(btnAuthorDateAdress, 10, 2, BaseColor.GRAY);
            prgAuthorDateAdress.Alignment = Element.ALIGN_LEFT;
            prgAuthorDateAdress.Add(new Chunk("Empleado : " + usuario, fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nNúmero de cotización : " + numeroCotizacion.ToString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nFecha : " + fecha.ToShortDateString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nCliente : " + cliente, fntAuthorDateAdress));
            factura.Add(prgAuthorDateAdress);

            //añadir nueva linea de separación 
            Paragraph p2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            factura.Add(p2);

            //añadir espacio
            factura.Add(new Chunk("\n", fntHead));

            //Escribir la tabla
            PdfPTable table = new PdfPTable(dataGridView.Columns.Count - 1);
            table.WidthPercentage = 100; //La tabla ocupa el 100 porciento del documento

            //Cabecera de la tabla
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            table.HorizontalAlignment = Element.ALIGN_CENTER;

            //Escribir cabecera
            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dataGridView.Columns[i].HeaderText.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //Ingresar datos a la tabla
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView.Columns.Count; j++)
                {
                    table.AddCell(dataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }

            factura.Add(table);

            //Total del reporte
            Paragraph prgTotal = new Paragraph();
            BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntTotal = new iTextSharp.text.Font(btnTotal, 12, 1, BaseColor.BLACK);
            prgTotal.Alignment = Element.ALIGN_RIGHT;
            prgTotal.Add(new Chunk("Total a pagar: " + total.ToString(), fntTotal));
            factura.Add(prgTotal);

            factura.Close();
            writer.Close();
            fileStream.Close();
        }

        //Sobre carga para crear cotización usando DataTable
        public void GenerarCotizacion(DataTable dataTable, string pdfRuta, string header, string cliente, string usuario, int numeroCotizacion, float total, DateTime fecha)
        {
            System.IO.FileStream fileStream = new FileStream(pdfRuta, FileMode.Create, FileAccess.Write, FileShare.None);
            Document factura = new Document();
            factura.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(factura, fileStream);
            factura.Open();

            //Cabecera del reporte
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 12, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(header.ToUpper(), fntHead));
            factura.Add(prgHeading);

            //Dirección
            BaseFont bfnAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAdress = new iTextSharp.text.Font(bfnAdress, 10, 1, BaseColor.GRAY);
            Paragraph prgAdress = new Paragraph();
            prgAdress.Alignment = Element.ALIGN_CENTER;
            prgAdress.Add(new Chunk("Jánico, Santiago RD", fntAdress));
            prgAdress.Add(new Chunk("\nFederico Pichardo #90", fntAdress));
            factura.Add(prgAdress);

            //añadir linea de separación 
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            factura.Add(p);

            //Factura de venta
            BaseFont bfnFacturaVenta = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntFacturaVenta = new iTextSharp.text.Font(bfnFacturaVenta, 10, 1, BaseColor.GRAY);
            Paragraph prgFacturaVenta = new Paragraph();
            prgFacturaVenta.Alignment = Element.ALIGN_CENTER;
            prgFacturaVenta.Add(new Chunk("COTIZACIÓN", fntFacturaVenta));
            factura.Add(prgFacturaVenta);

            //Empleado, fecha, cliente, número de factura
            Paragraph prgAuthorDateAdress = new Paragraph();
            BaseFont btnAuthorDateAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthorDateAdress = new iTextSharp.text.Font(btnAuthorDateAdress, 10, 2, BaseColor.GRAY);
            prgAuthorDateAdress.Alignment = Element.ALIGN_LEFT;
            prgAuthorDateAdress.Add(new Chunk("Empleado : " + usuario, fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nNúmero de cotización : " + numeroCotizacion.ToString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nFecha : " + fecha.ToShortDateString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nCliente : " + cliente, fntAuthorDateAdress));
            factura.Add(prgAuthorDateAdress);

            //añadir nueva linea de separación 
            Paragraph p2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            factura.Add(p2);

            //añadir espacio
            factura.Add(new Chunk("\n", fntHead));

            //Escribir la tabla
            PdfPTable table = new PdfPTable(dataTable.Columns.Count - 1);
            table.WidthPercentage = 100; //La tabla ocupa el 100 porciento del documento

            //Cabecera de la tabla
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            table.HorizontalAlignment = Element.ALIGN_CENTER;

            //Escribir cabecera
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dataTable.Columns[i].ToString().ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //Ingresar datos a la tabla
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    table.AddCell(dataTable.Rows[i][j].ToString());
                }
            }

            factura.Add(table);

            //Total del reporte
            Paragraph prgTotal = new Paragraph();
            BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntTotal = new iTextSharp.text.Font(btnTotal, 12, 1, BaseColor.BLACK);
            prgTotal.Alignment = Element.ALIGN_RIGHT;
            prgTotal.Add(new Chunk("Total a pagar: " + total.ToString(), fntTotal));
            factura.Add(prgTotal);

            factura.Close();
            writer.Close();
            fileStream.Close();
        }

        //Crear factura de la salida
        public void GenerarFactura(DataGridView dataGridView, string pdfRuta, string header, string cliente, int numeroFactura, float total)
        {
            System.IO.FileStream fileStream = new FileStream(pdfRuta, FileMode.Create, FileAccess.Write, FileShare.None);
            Document factura = new Document();
            factura.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(factura, fileStream);
            factura.Open();

            //Cabecera del reporte
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 12, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(header.ToUpper(), fntHead));
            factura.Add(prgHeading);

            //Dirección
            BaseFont bfnAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAdress = new iTextSharp.text.Font(bfnAdress, 10, 1, BaseColor.GRAY);
            Paragraph prgAdress = new Paragraph();
            prgAdress.Alignment = Element.ALIGN_CENTER;
            prgAdress.Add(new Chunk("Jánico, Santiago RD", fntAdress));
            prgAdress.Add(new Chunk("\nFederico Pichardo #90", fntAdress));
            factura.Add(prgAdress);

            //añadir linea de separación 
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            factura.Add(p);

            //Factura de venta
            BaseFont bfnFacturaVenta = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntFacturaVenta = new iTextSharp.text.Font(bfnFacturaVenta, 10, 1, BaseColor.GRAY);
            Paragraph prgFacturaVenta = new Paragraph();
            prgFacturaVenta.Alignment = Element.ALIGN_CENTER;
            prgFacturaVenta.Add(new Chunk("FACTURA DE VENTA", fntFacturaVenta));
            factura.Add(prgFacturaVenta);

            //Empleado, fecha, cliente, número de factura
            Paragraph prgAuthorDateAdress = new Paragraph();
            BaseFont btnAuthorDateAdress = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthorDateAdress = new iTextSharp.text.Font(btnAuthorDateAdress, 10, 2, BaseColor.GRAY);
            prgAuthorDateAdress.Alignment = Element.ALIGN_LEFT;
            prgAuthorDateAdress.Add(new Chunk("Empleado : " + UsuarioLoginCache.Nombre, fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nNúmero de factura : " + numeroFactura.ToString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nCliente : " + cliente, fntAuthorDateAdress));
            factura.Add(prgAuthorDateAdress);

            //añadir nueva linea de separación 
            Paragraph p2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            factura.Add(p2);

            //añadir espacio
            factura.Add(new Chunk("\n", fntHead));

            //Escribir la tabla
            PdfPTable table = new PdfPTable(dataGridView.Columns.Count - 1);
            table.WidthPercentage = 100; //La tabla ocupa el 100 porciento del documento

            //Cabecera de la tabla
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            table.HorizontalAlignment = Element.ALIGN_CENTER;

            //Escribir cabecera
            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dataGridView.Columns[i].HeaderText.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //Ingresar datos a la tabla
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 1; j < dataGridView.Columns.Count; j++)
                {
                    table.AddCell(dataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }

            factura.Add(table);

            //Total del reporte
            Paragraph prgTotal = new Paragraph();
            BaseFont btnTotal = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntTotal = new iTextSharp.text.Font(btnTotal, 12, 1, BaseColor.BLACK);
            prgTotal.Alignment = Element.ALIGN_RIGHT;
            prgTotal.Add(new Chunk("Total pagado: " + total.ToString(), fntTotal));
            factura.Add(prgTotal);

            factura.Close();
            writer.Close();
            fileStream.Close();
        }
    }
}
