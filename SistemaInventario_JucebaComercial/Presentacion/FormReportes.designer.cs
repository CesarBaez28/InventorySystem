
namespace Presentacion
{
    partial class FormReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes));
            this.panelContedorReporteGeneral = new System.Windows.Forms.Panel();
            this.radioButtonDetallado = new System.Windows.Forms.RadioButton();
            this.radioButtonGeneral = new System.Windows.Forms.RadioButton();
            this.gridViewReportes = new System.Windows.Forms.DataGridView();
            this.btnExportarPdf = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dateTimeFechaFin = new System.Windows.Forms.DateTimePicker();
            this.comboReportes = new System.Windows.Forms.ComboBox();
            this.lblConsultarPor = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dateTimeFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.comboBuscar = new System.Windows.Forms.ComboBox();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.txbBuscar = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.panelContedorReporteGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContedorReporteGeneral
            // 
            this.panelContedorReporteGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContedorReporteGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContedorReporteGeneral.Controls.Add(this.txbBuscar);
            this.panelContedorReporteGeneral.Controls.Add(this.comboBuscar);
            this.panelContedorReporteGeneral.Controls.Add(this.lblBuscarPor);
            this.panelContedorReporteGeneral.Controls.Add(this.btnEliminar);
            this.panelContedorReporteGeneral.Controls.Add(this.btnEditar);
            this.panelContedorReporteGeneral.Controls.Add(this.radioButtonDetallado);
            this.panelContedorReporteGeneral.Controls.Add(this.radioButtonGeneral);
            this.panelContedorReporteGeneral.Controls.Add(this.gridViewReportes);
            this.panelContedorReporteGeneral.Controls.Add(this.btnExportarPdf);
            this.panelContedorReporteGeneral.Controls.Add(this.btnLimpiar);
            this.panelContedorReporteGeneral.Controls.Add(this.lblFechaFin);
            this.panelContedorReporteGeneral.Controls.Add(this.dateTimeFechaFin);
            this.panelContedorReporteGeneral.Controls.Add(this.comboReportes);
            this.panelContedorReporteGeneral.Controls.Add(this.lblConsultarPor);
            this.panelContedorReporteGeneral.Controls.Add(this.btnTerminar);
            this.panelContedorReporteGeneral.Controls.Add(this.lblFechaInicio);
            this.panelContedorReporteGeneral.Controls.Add(this.dateTimeFechaInicio);
            this.panelContedorReporteGeneral.Controls.Add(this.btnConsultar);
            this.panelContedorReporteGeneral.Controls.Add(this.lblTitulo);
            this.panelContedorReporteGeneral.Controls.Add(this.shapeContainer1);
            this.panelContedorReporteGeneral.Location = new System.Drawing.Point(13, 42);
            this.panelContedorReporteGeneral.Name = "panelContedorReporteGeneral";
            this.panelContedorReporteGeneral.Size = new System.Drawing.Size(915, 519);
            this.panelContedorReporteGeneral.TabIndex = 4;
            // 
            // radioButtonDetallado
            // 
            this.radioButtonDetallado.AutoSize = true;
            this.radioButtonDetallado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDetallado.Location = new System.Drawing.Point(398, 82);
            this.radioButtonDetallado.Name = "radioButtonDetallado";
            this.radioButtonDetallado.Size = new System.Drawing.Size(91, 21);
            this.radioButtonDetallado.TabIndex = 29;
            this.radioButtonDetallado.Text = "Detallado";
            this.radioButtonDetallado.UseVisualStyleBackColor = true;
            // 
            // radioButtonGeneral
            // 
            this.radioButtonGeneral.AutoSize = true;
            this.radioButtonGeneral.Checked = true;
            this.radioButtonGeneral.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGeneral.Location = new System.Drawing.Point(398, 55);
            this.radioButtonGeneral.Name = "radioButtonGeneral";
            this.radioButtonGeneral.Size = new System.Drawing.Size(77, 21);
            this.radioButtonGeneral.TabIndex = 28;
            this.radioButtonGeneral.TabStop = true;
            this.radioButtonGeneral.Text = "General";
            this.radioButtonGeneral.UseVisualStyleBackColor = true;
            // 
            // gridViewReportes
            // 
            this.gridViewReportes.AllowUserToAddRows = false;
            this.gridViewReportes.AllowUserToDeleteRows = false;
            this.gridViewReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewReportes.BackgroundColor = System.Drawing.Color.White;
            this.gridViewReportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewReportes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewReportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridViewReportes.ColumnHeadersHeight = 30;
            this.gridViewReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewReportes.EnableHeadersVisualStyles = false;
            this.gridViewReportes.GridColor = System.Drawing.Color.Black;
            this.gridViewReportes.Location = new System.Drawing.Point(14, 138);
            this.gridViewReportes.Name = "gridViewReportes";
            this.gridViewReportes.ReadOnly = true;
            this.gridViewReportes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewReportes.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridViewReportes.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.gridViewReportes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridViewReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewReportes.Size = new System.Drawing.Size(886, 330);
            this.gridViewReportes.TabIndex = 27;
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(40)))), ((int)(((byte)(30)))));
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportarPdf.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarPdf.Image")));
            this.btnExportarPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarPdf.Location = new System.Drawing.Point(747, 474);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(153, 31);
            this.btnExportarPdf.TabIndex = 26;
            this.btnExportarPdf.Text = "Exportar en PDF";
            this.btnExportarPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(617, 73);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 27);
            this.btnLimpiar.TabIndex = 25;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(271, 51);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(80, 20);
            this.lblFechaFin.TabIndex = 24;
            this.lblFechaFin.Text = "Fecha fin:";
            // 
            // dateTimeFechaFin
            // 
            this.dateTimeFechaFin.CalendarFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFechaFin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaFin.Location = new System.Drawing.Point(275, 74);
            this.dateTimeFechaFin.Name = "dateTimeFechaFin";
            this.dateTimeFechaFin.Size = new System.Drawing.Size(105, 26);
            this.dateTimeFechaFin.TabIndex = 23;
            // 
            // comboReportes
            // 
            this.comboReportes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReportes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboReportes.FormattingEnabled = true;
            this.comboReportes.Items.AddRange(new object[] {
            "Entradas",
            "Salidas",
            "Cotizaciones"});
            this.comboReportes.Location = new System.Drawing.Point(14, 74);
            this.comboReportes.Name = "comboReportes";
            this.comboReportes.Size = new System.Drawing.Size(126, 25);
            this.comboReportes.TabIndex = 22;
            this.comboReportes.SelectionChangeCommitted += new System.EventHandler(this.comboReportes_SelectionChangeCommitted);
            // 
            // lblConsultarPor
            // 
            this.lblConsultarPor.AutoSize = true;
            this.lblConsultarPor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultarPor.Location = new System.Drawing.Point(10, 50);
            this.lblConsultarPor.Name = "lblConsultarPor";
            this.lblConsultarPor.Size = new System.Drawing.Size(82, 20);
            this.lblConsultarPor.TabIndex = 21;
            this.lblConsultarPor.Text = "Consultar:";
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTerminar.FlatAppearance.BorderSize = 0;
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.Location = new System.Drawing.Point(572, 474);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(169, 31);
            this.btnTerminar.TabIndex = 20;
            this.btnTerminar.Text = "Exportar en Excel";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(151, 50);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(101, 20);
            this.lblFechaInicio.TabIndex = 19;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // dateTimeFechaInicio
            // 
            this.dateTimeFechaInicio.CalendarFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFechaInicio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFechaInicio.Location = new System.Drawing.Point(155, 73);
            this.dateTimeFechaInicio.Name = "dateTimeFechaInicio";
            this.dateTimeFechaInicio.Size = new System.Drawing.Size(105, 26);
            this.dateTimeFechaInicio.TabIndex = 18;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConsultar.FlatAppearance.BorderSize = 0;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(502, 73);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 27);
            this.btnConsultar.TabIndex = 9;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(913, 33);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Reportes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(913, 517);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 912;
            this.lineShape1.Y1 = 120;
            this.lineShape1.Y2 = 120;
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(13, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 28);
            this.btnCerrar.TabIndex = 17;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // comboBuscar
            // 
            this.comboBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBuscar.FormattingEnabled = true;
            this.comboBuscar.Items.AddRange(new object[] {
            "Código",
            "Descripción ",
            "Cliente",
            "Aceptadas",
            "No aceptadas",
            "Fecha"});
            this.comboBuscar.Location = new System.Drawing.Point(205, 492);
            this.comboBuscar.Name = "comboBuscar";
            this.comboBuscar.Size = new System.Drawing.Size(124, 25);
            this.comboBuscar.TabIndex = 31;
            this.comboBuscar.Visible = false;
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscarPor.Location = new System.Drawing.Point(201, 469);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(91, 20);
            this.lblBuscarPor.TabIndex = 30;
            this.lblBuscarPor.Text = "Buscar por:";
            this.lblBuscarPor.Visible = false;
            // 
            // txbBuscar
            // 
            this.txbBuscar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBuscar.Location = new System.Drawing.Point(335, 491);
            this.txbBuscar.Name = "txbBuscar";
            this.txbBuscar.Size = new System.Drawing.Size(167, 26);
            this.txbBuscar.TabIndex = 32;
            this.txbBuscar.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(104, 474);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 31);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(14, 474);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(84, 31);
            this.btnEditar.TabIndex = 30;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 573);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelContedorReporteGeneral);
            this.Name = "FormReportes";
            this.Text = "Reportes";
            this.panelContedorReporteGeneral.ResumeLayout(false);
            this.panelContedorReporteGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContedorReporteGeneral;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dateTimeFechaInicio;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblTitulo;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label lblConsultarPor;
        private System.Windows.Forms.ComboBox comboReportes;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dateTimeFechaFin;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnExportarPdf;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView gridViewReportes;
        private System.Windows.Forms.RadioButton radioButtonGeneral;
        private System.Windows.Forms.RadioButton radioButtonDetallado;
        private System.Windows.Forms.ComboBox comboBuscar;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.TextBox txbBuscar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
    }
}