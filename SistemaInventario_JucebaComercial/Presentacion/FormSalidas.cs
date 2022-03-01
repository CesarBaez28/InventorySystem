using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Dominio;
using Comun;
using System.IO;

namespace Presentacion
{
    public partial class FormSalidas : Form
    {
        DominioServicios servicios = new DominioServicios();
        DominioCliente clientes = new DominioCliente();
        DominioSalida salida = new DominioSalida();

        bool yaRegistrado = false; // La uso para validar que no se ingrese un servicio repetido.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer servicio, verificar si este u otros se agregan repetidos.
        float total = 0; //Guardo el total de la salida.
        int codigoSalida = 0; //Guardo el código de la salida registrada. 

        public static FormSalidas formSalidas;

        public FormSalidas()
        {
            InitializeComponent();
            FormSalidas.formSalidas = this;
        }

        //Cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSalidas_Load(object sender, EventArgs e)
        {
            MostrarServicios();
            MostrarClientes();
        }

        //Mostrar servicios en el combobox
        public void MostrarServicios() 
        {
            comboServicios.ValueMember = "codigo";
            comboServicios.DisplayMember = "nombre_servicio";
            comboServicios.DataSource = servicios.ShowServicesNameCode();
        }

        //Mostrar Clientes
        public void MostrarClientes() 
        {
            comboClientes.ValueMember = "codigo";
            comboClientes.DisplayMember = "nombre";
            comboClientes.DataSource = clientes.ShowCustumerNameCode();
        }

        //Agregar salida a la lista
        private void AgregarSalida() 
        {
            int indice = gridViewSalidas.Rows.Add();
            float total_servicio = Convert.ToInt32(txbCantidad.Text) * float.Parse(txbMonto.Text); //Total del servicio

            //Agrego los datos a la lista
            //gridViewSalidas.Rows[indice].Cells["codigoCliente"].Value = comboClientes.SelectedValue.ToString();
            //gridViewSalidas.Rows[indice].Cells["Cliente"].Value = comboClientes.Text;
            gridViewSalidas.Rows[indice].Cells["codigoServicio"].Value = comboServicios.SelectedValue.ToString();
            gridViewSalidas.Rows[indice].Cells["Servicio"].Value = comboServicios.Text;
            gridViewSalidas.Rows[indice].Cells["Monto"].Value = txbMonto.Text;
            gridViewSalidas.Rows[indice].Cells["Cantidad"].Value = txbCantidad.Text;
            gridViewSalidas.Rows[indice].Cells["Total_Salida"].Value = total_servicio.ToString();

            //Total de la salida
            total += total_servicio;
            lblTotalSalida.Text = "Total: " + total.ToString();
        }

        //Botón agregar salida a la lista
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Verifico que el monto y la cantidad se han números válidos.
            if (float.TryParse(txbMonto.Text, out float parseCorrecto) && int.TryParse(txbCantidad.Text, out int parse))
            {
                if (primerRegistro == false)
                {
                    AgregarSalida();
                    primerRegistro = true;
                }
                else
                {
                    //Verifico que el servicio no esté repetido 
                    foreach (DataGridViewRow fila in gridViewSalidas.Rows)
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
                MessageBox.Show("Faltan campos por llenar o ingresó un campo de manera incorrecta");
            }
        }

        //Botón terminar y guardar la salida
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DominioSalida salida = new DominioSalida();
            DominioMateriales materiales = new DominioMateriales();

            //Verifico que el datagridviewSalidas no esté vacío. 
            if (gridViewSalidas.Rows.Count != 0)
            {
                try
                {
                    //Verifico si se utilizaron excedentes
                    if (gridViewExcedentes.RowCount > 0)
                    {
                        //Actualizo la cantidad de existencia de los excedentes
                        foreach (DataGridViewRow fila in gridViewExcedentes.Rows)
                        {
                            materiales.UpdateAmountLeftover(fila.Cells["Codigo"].Value.ToString(),
                                fila.Cells["CantidadExcedente"].Value.ToString());
                        }

                        gridViewExcedentes.Rows.Clear();
                        gridViewExcedentes.Visible = false;
                        gridViewSalidas.Height = 256;
                    }

                    //Registro salida 
                    salida.SaleOfService(dateTimeSalida.Value);

                    //Obtengo el último código de la salida. Lo necesito para insertar los detalles de la salida
                    codigoSalida = Convert.ToInt32(salida.GetCodeSale().Rows[0]["codigo"]);

                    //Creo una lista para guardar cada uno de los detalles de la salida
                    List<DetallesSalida> listaDetalles = new List<DetallesSalida>();

                    //Guardo cada uno de los detalles de la salida en la lista
                    foreach (DataGridViewRow fila in gridViewSalidas.Rows) 
                    {
                        var detalles = new DetallesSalida()
                        {
                        codigo_salida = codigoSalida,
                        codigo_servicio = Convert.ToInt32(fila.Cells["codigoServicio"].Value.ToString()),
                        codigo_cliente = Convert.ToInt32(comboClientes.SelectedValue),
                        codigo_usuario = UsuarioLoginCache.Codigo_usuario,
                        precio = float.Parse(fila.Cells["Total_Salida"].Value.ToString()),
                        cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value.ToString())
                        };

                        listaDetalles.Add(detalles);
                    }

                    salida.add_MultipleSingleInsert(listaDetalles);
                    GenerarFactura();
                }
                catch (Exception)
                {
                    MessageBox.Show("No hay suficiente material para registrar uno de los servicios");
                }

                gridViewSalidas.Rows.Clear();
            }
            else
            {
                MessageBox.Show("No hay servicios agregados");
            }

            lblTotalSalida.Text = "Total: ";
            total = 0;
        }

        //Agregar cliente
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            FormDetalleCliente detalleCliente = new FormDetalleCliente();

            detalleCliente.formSalida = true;

            //Oculto los controles para cambiar el estado del cliente.Solo son necesarios para actualizar
            detalleCliente.lblEstado.Visible = false;
            detalleCliente.cbxEstado.Visible = false;
            detalleCliente.Size = new Size(260, 310);
            detalleCliente.btnAceptar.Location = new Point(15, 232);
            detalleCliente.btnCancelar.Location = new Point(129, 232);

            AbrirFormulario(detalleCliente);
        }

        //Agregar servicio
        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            FormDetallesServicio detallesServicio = new FormDetallesServicio();

            //Indico que este formulario (FormSalidas) abrió el FormDetallesServicio
            detallesServicio.formSalidas = true;

            AbrirFormulario(detallesServicio);
        }

        //Ver detalles del servicio
        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            //Me aseguro que haya una fila selccionada
            if (gridViewSalidas.SelectedRows.Count > 0) 
            {
                FormDetallesServicio detallesServicio = new FormDetallesServicio();
                DominioServicios servicios = new DominioServicios();
                DataTable table = new DataTable();

                //Indico que este formulario (FormSalidas) abrió el FormDetallesServicio
                detallesServicio.formSalidas = true;

                string codigoServicio = gridViewSalidas.CurrentRow.Cells["codigoServicio"].Value.ToString();
                int fila = gridViewSalidas.CurrentRow.Index; //Guardo el índice de la fila para luego poder hacer modificaiones si es necesario

                table = servicios.SearchServiceCode(codigoServicio);
                detallesServicio.codigoServicio = codigoServicio;
                detallesServicio.indiceFila = fila;
                detallesServicio.actualizar = true;
                detallesServicio.gridViewMateriales.Columns.Clear();
                detallesServicio.txbNombreServicio.Text = gridViewSalidas.CurrentRow.Cells["Servicio"].Value.ToString();
                detallesServicio.txbDescripcionServicio.Text = table.Rows[0]["Descripción"].ToString();
                detallesServicio.txbPrecio.Text = gridViewSalidas.CurrentRow.Cells["Monto"].Value.ToString();

                AbrirFormulario(detallesServicio);
            }
        }

        //Botón eliminar
         private void btnEliminar_Click(object sender, EventArgs e)
         {
            if (gridViewSalidas.SelectedRows.Count > 0)
            {
                //Actualizo el total de la salida
                total = total - (float.Parse(gridViewSalidas.CurrentRow.Cells["Total_Salida"].Value.ToString()));
                lblTotalSalida.Text = "Total: " + total.ToString();

                gridViewSalidas.Rows.Remove(gridViewSalidas.CurrentRow);
            }
         }

        //Agregar excedente de material
        private void btnAgregarExcedente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormAgregarExcedente());
        }

        //Borrar excedente
        private void gridViewExcedentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) 
            {
                if (gridViewExcedentes.SelectedCells.Count > 0)
                {
                    gridViewExcedentes.Rows.Remove(gridViewExcedentes.CurrentRow);
                }
                else 
                {
                    MessageBox.Show("Selecione una celda");
                }

                if (gridViewExcedentes.RowCount <= 0) 
                {
                    gridViewExcedentes.Visible = false;
                    gridViewSalidas.Height = 256;
                }
            }
        }

        //Generar la factura
        private void GenerarFactura() 
        {
            string nombreEmpresa = "Juceba Comercial";
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Factura" + codigoSalida.ToString();
            save.DefaultExt = "pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                CrearFactura(gridViewSalidas, save.FileName, nombreEmpresa, comboClientes.Text, 
                    codigoSalida, total);
            }
        }

        //Crear factura de la salida
        private void CrearFactura(DataGridView dataGridView, string pdfRuta, string header, string cliente, int numeroFactura, float total) 
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
            PdfPTable table = new PdfPTable(gridViewSalidas.Columns.Count - 1);
            table.WidthPercentage = 100; //La tabla ocupa el 100 porciento del documento

            //Cabecera de la tabla
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);

            table.HorizontalAlignment = Element.ALIGN_CENTER;

            //Escribir cabecera
            for (int i = 1; i < gridViewSalidas.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(gridViewSalidas.Columns[i].HeaderText.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            //Ingresar datos a la tabla
            for (int i = 0; i < gridViewSalidas.Rows.Count; i++)
            {
                for (int j = 1; j < gridViewSalidas.Columns.Count; j++)
                {
                    table.AddCell(gridViewSalidas.Rows[i].Cells[j].Value.ToString());
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

        //Metodo para abirar el formulario DetalleSuplidor
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
