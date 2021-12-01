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

namespace Presentacion
{
    public partial class FormReportes : Form
    {

        DominioReportes reporte = new DominioReportes();
        DateTime fechaInicial;
        DateTime fechaFinal;

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
            //DominioReportes reporte = new DominioReportes();

             fechaInicial = dateTimeFechaInicio.Value;
             fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.GeneralEntryReport(fechaInicial, 
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23,59,59));
        }

        //Reporte detallado de entradas
        private void ReporteDetalladoEntrada() 
        {
            //DominioReportes reporte = new DominioReportes();

            fechaInicial = dateTimeFechaInicio.Value;
            fechaFinal = dateTimeFechaFin.Value;

            gridViewReportes.DataSource = reporte.DetailedEntryReport(fechaInicial,
                new DateTime(fechaFinal.Year, fechaFinal.Month, fechaFinal.Day, 23, 59, 59));
        }

        //Consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (comboReportes.SelectedIndex == 0 && radioButtonGeneral.Checked)
            {
                ReporteGeneralEntrada();
            }
            else if (comboReportes.SelectedIndex == 0 && radioButtonDetallado.Checked) 
            {
                ReporteDetalladoEntrada();
            }
        }

        //Limpirar consulta
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            gridViewReportes.DataSource = null;
        }
    }
}
