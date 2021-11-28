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
    public partial class FormSalidas : Form
    {
        DominioServicios servicios = new DominioServicios();
        DominioCliente clientes = new DominioCliente();
        DominioSalida salida = new DominioSalida();

        bool yaRegistrado = false; // La uso para validar que no se ingrese un servicio repetido.
        bool primerRegistro = false; //La uso para que, luego de agregar un primer servicio, verificar si este u otros se agregan repetidos.

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

            gridViewSalidas.Rows[indice].Cells["codigoCliente"].Value = comboClientes.SelectedValue.ToString();
            gridViewSalidas.Rows[indice].Cells["Cliente"].Value = comboClientes.Text;
            gridViewSalidas.Rows[indice].Cells["codigoServicio"].Value = comboServicios.SelectedValue.ToString();
            gridViewSalidas.Rows[indice].Cells["Servicio"].Value = comboServicios.Text;
            gridViewSalidas.Rows[indice].Cells["Monto"].Value = txbMonto.Text;
            gridViewSalidas.Rows[indice].Cells["Cantidad"].Value = txbCantidad.Text;
        }

        //Botón agregar salida
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

        //Botón terminar y guardar
        private void btnTerminar_Click(object sender, EventArgs e)
        {
            DominioSalida salida = new DominioSalida();

            //Verifico que el datagridview no esté vacío. 
            if (gridViewSalidas.Rows.Count != 0)
            {
                try
                {
                    //Registro salida 
                    salida.SaleOfService(dateTimeSalida.Value);

                    //Obtengo el último código de la salida. Lo necesito para insertar los detalles de la salida
                    int codigoSalida = Convert.ToInt32(salida.GetCodeSale().Rows[0]["codigo"]);

                    //Creo una lista para guardar cada uno de los detalles de la salida
                    List<DetallesSalida> listaDetalles = new List<DetallesSalida>();

                    //Guardo cada uno de los detalles de la salida en la lista
                    foreach (DataGridViewRow fila in gridViewSalidas.Rows) 
                    {
                        var detalles = new DetallesSalida()
                        {
                        codigo_salida = codigoSalida,
                        codigo_servicio = Convert.ToInt32(fila.Cells["codigoServicio"].Value.ToString()),
                        codigo_cliente = Convert.ToInt32(fila.Cells["codigoCliente"].Value.ToString()),
                        codigo_usuario = UsuarioLoginCache.Codigo_usuario,
                        precio = float.Parse(fila.Cells["Monto"].Value.ToString()),
                        cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value.ToString())
                        };

                        listaDetalles.Add(detalles);
                    }

                    salida.add_MultipleSingleInsert(listaDetalles);
                    MessageBox.Show("Registro exitoso");
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

            //Oculto el botón para agregar excedentes del formulario
            detallesServicio.btnAgregarExcedente.Visible = false;

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
                gridViewSalidas.Rows.Remove(gridViewSalidas.CurrentRow);
            }
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
