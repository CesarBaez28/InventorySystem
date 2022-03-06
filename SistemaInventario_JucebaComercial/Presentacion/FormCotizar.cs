using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Dominio;
using Comun;

namespace Presentacion
{
    public partial class FormCotizar : Form
    {
        DominioCliente clientes = new DominioCliente();
        DominioServicios servicios = new DominioServicios();
        DominioCotizaciones cotizar = new DominioCotizaciones();

        string precioServicio = ""; //Guardo el precio de los servicios para mostrarlos autimaticamente.
        public float total = 0; //Guardo el total de la cotización.
        bool yaRegistrado = false; // La uso para validar que no se ingrese un servicio repetido.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer servicio, verificar si este u otros se agregan repetidos.

        public static FormCotizar formCotizar;

        public FormCotizar()
        {
            InitializeComponent();
            FormCotizar.formCotizar = this; 
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCotizar_Load(object sender, EventArgs e)
        {
            MostrarClientes();
            MostrarServicios();
        }

        //Mostrar clientes en el combobox
        public void MostrarClientes() 
        {
            comboClientes.ValueMember = "codigo";
            comboClientes.DisplayMember = "nombre";
            comboClientes.DataSource = clientes.ShowCustumerNameCode();
            comboClientes.SelectedIndex = -1;
        }

        //Mostrar servicios en el combobox
        public void MostrarServicios()
        {
            comboServicios.ValueMember = "codigo";
            comboServicios.DisplayMember = "nombre_servicio";
            comboServicios.DataSource = servicios.ShowServicesNameCode();
            comboServicios.SelectedIndex = -1;
        }

        //Muestra el valor del precio del servicio al seleccionar uno.
        private void comboServicios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            precioServicio = servicios.SearchServicePrice(comboServicios.SelectedValue.ToString()).Rows[0]["Precio"].ToString();
            txbMonto.Text = precioServicio;
        }

        //Agregar nuevo cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormDetalleCliente detalleCliente = new FormDetalleCliente();

            detalleCliente.formCotizar = true;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleCliente.lblEstado.Visible = false;
            detalleCliente.cbxEstado.Visible = false;
            detalleCliente.Size = new Size(260, 310);
            detalleCliente.btnAceptar.Location = new Point(15, 232);
            detalleCliente.btnCancelar.Location = new Point(129, 232);

            AbrirFormulario(detalleCliente);
        }

        //Registrar nuevo servicio
        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            FormDetallesServicio detallesServicio = new FormDetallesServicio();

            //Indico que este formulario (FormSalidas) abrió el FormDetallesServicio
            detallesServicio.formCotizar = true;

            AbrirFormulario(detallesServicio);
        }

        // Ver detalles del servicio
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            //Me aseguro que haya una fila selccionada
            if (gridViewCotizaciones.SelectedRows.Count > 0)
            {
                FormDetallesServicio detallesServicio = new FormDetallesServicio();
                DataTable table = new DataTable();

                //Indico que este formulario (FormCotizar) abrió el FormDetallesServicio
                detallesServicio.formCotizar = true;

                string codigoServicio = gridViewCotizaciones.CurrentRow.Cells["codigoServicio"].Value.ToString();
                int fila = gridViewCotizaciones.CurrentRow.Index; //Guardo el índice de la fila para luego poder hacer modificaiones si es necesario

                table = servicios.SearchServiceCode(codigoServicio);
                detallesServicio.codigoServicio = codigoServicio;
                detallesServicio.indiceFila = fila;
                detallesServicio.actualizar = true;
                detallesServicio.precioAnterior = float.Parse(gridViewCotizaciones.CurrentRow.Cells["Monto"].Value.ToString());
                detallesServicio.gridViewMateriales.Columns.Clear();
                detallesServicio.nuevoTotal = total;
                detallesServicio.cantidad = Convert.ToInt32(gridViewCotizaciones.CurrentRow.Cells["Cantidad"].Value.ToString());
                detallesServicio.txbNombreServicio.Text = gridViewCotizaciones.CurrentRow.Cells["Servicio"].Value.ToString();
                detallesServicio.txbDescripcionServicio.Text = table.Rows[0]["Descripción"].ToString();
                detallesServicio.txbPrecio.Text = gridViewCotizaciones.CurrentRow.Cells["Monto"].Value.ToString();

                AbrirFormulario(detallesServicio);
            }
        }

        //Agregar salida a la lista
        private void AgregarSalida()
        {
            int indice = gridViewCotizaciones.Rows.Add();
            float total_servicio = Convert.ToInt32(txbCantidad.Text) * float.Parse(txbMonto.Text); //Total del servicio

            gridViewCotizaciones.Rows[indice].Cells["codigoServicio"].Value = comboServicios.SelectedValue.ToString();
            gridViewCotizaciones.Rows[indice].Cells["Servicio"].Value = comboServicios.Text;
            gridViewCotizaciones.Rows[indice].Cells["Monto"].Value = txbMonto.Text;
            gridViewCotizaciones.Rows[indice].Cells["Cantidad"].Value = txbCantidad.Text;
            gridViewCotizaciones.Rows[indice].Cells["Total_Salida"].Value = total_servicio.ToString();

            //Total de la salida
            total += total_servicio;
            lblTotalCotizacion.Text = "Total: " + total.ToString();
        }

        // Botón agregar salida a la lista.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verifico que el monto y la cantidad se han números válidos.
            //Y que el combobox de servicios tenga un elemento seleccionado.
            if (float.TryParse(txbMonto.Text, out float parseCorrecto) && int.TryParse(txbCantidad.Text, out int parse) && comboServicios.SelectedIndex != -1)
            {
                if (primerRegistro == false)
                {
                    AgregarSalida();
                    primerRegistro = true;
                }
                else
                {
                    //Verifico que el servicio no esté repetido 
                    foreach (DataGridViewRow fila in gridViewCotizaciones.Rows)
                    {
                        if (fila.Cells["Servicio"].Value.ToString() == comboServicios.Text)
                        {
                            yaRegistrado = true;
                            break;
                        }
                    }

                    //Si no está repetido, agrega la salida. De lo contrario, arroja un mensaje de error.
                    if (yaRegistrado != true)
                    {
                        AgregarSalida();
                    }
                    else
                    {
                        MessageBox.Show("Ya ingresó ese servicio");
                        yaRegistrado = false;
                    }
                }

                txbMonto.Text = "";
                txbCantidad.Text = "";
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar o ingresó un valor de manera incorrecta");
            }
        }

        //Terminar y regitrar la cotización
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            //Verifico que el gridViewCotizaciones no esté vacío. 
            //Y que los combobox tengan un elemento seleccionado.
            if (gridViewCotizaciones.Rows.Count != 0 && comboClientes.SelectedIndex != -1 && comboServicios.SelectedIndex != -1)
            {
                //Registro la cotización
                cotizar.RegisterQuote(dateTimeCotizacion.Value, txbDescripcion.Text);

                //Registrar detalles de la cotización
                foreach (DataGridViewRow fila in gridViewCotizaciones.Rows)
                {
                    cotizar.RegisterDetailsQuote(UsuarioLoginCache.Codigo_usuario.ToString(),
                        fila.Cells["codigoServicio"].Value.ToString(),
                        comboClientes.SelectedValue.ToString(),
                        fila.Cells["Cantidad"].Value.ToString(),
                        fila.Cells["Total_Salida"].Value.ToString());
                }

                MessageBox.Show("Cotización registrada");
                GenerarCotizacion(); //Generar la cotización
                gridViewCotizaciones.Rows.Clear();
                total = 0;
                lblTotalCotizacion.Text = "Total: ";
            }
            else 
            {
                MessageBox.Show("No hay servicios agregados o faltan campos por llenar");
            }
        }

        //Generar cotización
        private void GenerarCotizacion()
        {
            string nombreEmpresa = "Juceba Comercial";
            int codigoCotizacion = Convert.ToInt32(cotizar.GetQuoteCode().Rows[0]["codigo"]); //Código de la cotización
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Cotización" + codigoCotizacion.ToString();
            save.DefaultExt = "pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                CrearCotizacion(gridViewCotizaciones, save.FileName, nombreEmpresa, comboClientes.Text,
                    codigoCotizacion, total);
            }
        }

        //Crear cotización
        private void CrearCotizacion(DataGridView dataGridView, string pdfRuta, string header, string cliente, int numeroCotizacion, float total) 
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
            prgAuthorDateAdress.Add(new Chunk("Empleado : " + UsuarioLoginCache.Nombre, fntAuthorDateAdress));
            prgAuthorDateAdress.Add(new Chunk("\nNúmero de cotización : " + numeroCotizacion.ToString(), fntAuthorDateAdress));
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
            prgTotal.Add(new Chunk("Total a pagar: " + total.ToString(), fntTotal));
            factura.Add(prgTotal);

            factura.Close();
            writer.Close();
            fileStream.Close();
        }

        //Eliminar servicio de la lista
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridViewCotizaciones.SelectedRows.Count > 0)
            {
                //Actualizo el total de la salida
                total = total - (float.Parse(gridViewCotizaciones.CurrentRow.Cells["Total_Salida"].Value.ToString()));
                lblTotalCotizacion.Text = "Total: " + total.ToString();

                gridViewCotizaciones.Rows.Remove(gridViewCotizaciones.CurrentRow);
            }
        }

        //Metodo para abirar formularios
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
