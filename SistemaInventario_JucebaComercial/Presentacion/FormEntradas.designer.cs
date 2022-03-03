
namespace Presentacion
{
    partial class FormEntradas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntradas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContedorIngresos = new System.Windows.Forms.Panel();
            this.lblTotalEntrada = new System.Windows.Forms.Label();
            this.btnAgregarMaterial = new System.Windows.Forms.Button();
            this.btnAgregarSuplidor = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txbCantidad = new System.Windows.Forms.TextBox();
            this.comboMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.comboSuplidores = new System.Windows.Forms.ComboBox();
            this.gridViewEntradas = new System.Windows.Forms.DataGridView();
            this.Suplidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dateTimeEntrada = new System.Windows.Forms.DateTimePicker();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txbMonto = new System.Windows.Forms.TextBox();
            this.lblSuplidor = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelContedorIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContedorIngresos
            // 
            this.panelContedorIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContedorIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContedorIngresos.Controls.Add(this.lblTotalEntrada);
            this.panelContedorIngresos.Controls.Add(this.btnAgregarMaterial);
            this.panelContedorIngresos.Controls.Add(this.btnAgregarSuplidor);
            this.panelContedorIngresos.Controls.Add(this.lblCantidad);
            this.panelContedorIngresos.Controls.Add(this.txbCantidad);
            this.panelContedorIngresos.Controls.Add(this.comboMaterial);
            this.panelContedorIngresos.Controls.Add(this.lblMaterial);
            this.panelContedorIngresos.Controls.Add(this.comboSuplidores);
            this.panelContedorIngresos.Controls.Add(this.gridViewEntradas);
            this.panelContedorIngresos.Controls.Add(this.btnTerminar);
            this.panelContedorIngresos.Controls.Add(this.lblFecha);
            this.panelContedorIngresos.Controls.Add(this.dateTimeEntrada);
            this.panelContedorIngresos.Controls.Add(this.lblMonto);
            this.panelContedorIngresos.Controls.Add(this.txbMonto);
            this.panelContedorIngresos.Controls.Add(this.lblSuplidor);
            this.panelContedorIngresos.Controls.Add(this.btnAgregar);
            this.panelContedorIngresos.Controls.Add(this.btnEliminar);
            this.panelContedorIngresos.Controls.Add(this.lblTitulo);
            this.panelContedorIngresos.Controls.Add(this.shapeContainer1);
            this.panelContedorIngresos.Location = new System.Drawing.Point(13, 42);
            this.panelContedorIngresos.Name = "panelContedorIngresos";
            this.panelContedorIngresos.Size = new System.Drawing.Size(915, 519);
            this.panelContedorIngresos.TabIndex = 3;
            // 
            // lblTotalEntrada
            // 
            this.lblTotalEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalEntrada.AutoSize = true;
            this.lblTotalEntrada.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEntrada.Location = new System.Drawing.Point(714, 168);
            this.lblTotalEntrada.Name = "lblTotalEntrada";
            this.lblTotalEntrada.Size = new System.Drawing.Size(46, 18);
            this.lblTotalEntrada.TabIndex = 42;
            this.lblTotalEntrada.Text = "Total:";
            // 
            // btnAgregarMaterial
            // 
            this.btnAgregarMaterial.BackColor = System.Drawing.Color.Gray;
            this.btnAgregarMaterial.FlatAppearance.BorderSize = 0;
            this.btnAgregarMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMaterial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMaterial.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarMaterial.Image")));
            this.btnAgregarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMaterial.Location = new System.Drawing.Point(246, 116);
            this.btnAgregarMaterial.Name = "btnAgregarMaterial";
            this.btnAgregarMaterial.Size = new System.Drawing.Size(33, 28);
            this.btnAgregarMaterial.TabIndex = 40;
            this.btnAgregarMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarMaterial.UseVisualStyleBackColor = false;
            this.btnAgregarMaterial.Click += new System.EventHandler(this.btnAgregarMaterial_Click);
            // 
            // btnAgregarSuplidor
            // 
            this.btnAgregarSuplidor.BackColor = System.Drawing.Color.Gray;
            this.btnAgregarSuplidor.FlatAppearance.BorderSize = 0;
            this.btnAgregarSuplidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSuplidor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarSuplidor.ForeColor = System.Drawing.Color.White;
            this.btnAgregarSuplidor.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarSuplidor.Image")));
            this.btnAgregarSuplidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarSuplidor.Location = new System.Drawing.Point(246, 60);
            this.btnAgregarSuplidor.Name = "btnAgregarSuplidor";
            this.btnAgregarSuplidor.Size = new System.Drawing.Size(33, 28);
            this.btnAgregarSuplidor.TabIndex = 29;
            this.btnAgregarSuplidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarSuplidor.UseVisualStyleBackColor = false;
            this.btnAgregarSuplidor.Click += new System.EventHandler(this.btnAgregarSuplidor_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(307, 96);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(75, 17);
            this.lblCantidad.TabIndex = 28;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txbCantidad
            // 
            this.txbCantidad.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCantidad.Location = new System.Drawing.Point(306, 116);
            this.txbCantidad.Name = "txbCantidad";
            this.txbCantidad.Size = new System.Drawing.Size(133, 23);
            this.txbCantidad.TabIndex = 27;
            // 
            // comboMaterial
            // 
            this.comboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMaterial.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMaterial.FormattingEnabled = true;
            this.comboMaterial.Location = new System.Drawing.Point(14, 116);
            this.comboMaterial.Name = "comboMaterial";
            this.comboMaterial.Size = new System.Drawing.Size(226, 28);
            this.comboMaterial.TabIndex = 26;
            this.comboMaterial.SelectionChangeCommitted += new System.EventHandler(this.comboMaterial_SelectionChangeCommitted);
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(15, 96);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(60, 17);
            this.lblMaterial.TabIndex = 25;
            this.lblMaterial.Text = "Material";
            // 
            // comboSuplidores
            // 
            this.comboSuplidores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSuplidores.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSuplidores.FormattingEnabled = true;
            this.comboSuplidores.Location = new System.Drawing.Point(14, 60);
            this.comboSuplidores.Name = "comboSuplidores";
            this.comboSuplidores.Size = new System.Drawing.Size(226, 28);
            this.comboSuplidores.TabIndex = 22;
            // 
            // gridViewEntradas
            // 
            this.gridViewEntradas.AllowUserToAddRows = false;
            this.gridViewEntradas.AllowUserToDeleteRows = false;
            this.gridViewEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridViewEntradas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewEntradas.BackgroundColor = System.Drawing.Color.White;
            this.gridViewEntradas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewEntradas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewEntradas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewEntradas.ColumnHeadersHeight = 30;
            this.gridViewEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewEntradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Suplidor,
            this.Material,
            this.Cantidad,
            this.Monto,
            this.Total_entrada});
            this.gridViewEntradas.EnableHeadersVisualStyles = false;
            this.gridViewEntradas.GridColor = System.Drawing.Color.Black;
            this.gridViewEntradas.Location = new System.Drawing.Point(14, 205);
            this.gridViewEntradas.Name = "gridViewEntradas";
            this.gridViewEntradas.ReadOnly = true;
            this.gridViewEntradas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewEntradas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewEntradas.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.gridViewEntradas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewEntradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewEntradas.Size = new System.Drawing.Size(886, 263);
            this.gridViewEntradas.TabIndex = 21;
            // 
            // Suplidor
            // 
            this.Suplidor.HeaderText = "Suplidor";
            this.Suplidor.Name = "Suplidor";
            this.Suplidor.ReadOnly = true;
            // 
            // Material
            // 
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // Total_entrada
            // 
            this.Total_entrada.HeaderText = "Total";
            this.Total_entrada.Name = "Total_entrada";
            this.Total_entrada.ReadOnly = true;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTerminar.FlatAppearance.BorderSize = 0;
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.Color.White;
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.Location = new System.Drawing.Point(717, 474);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(183, 31);
            this.btnTerminar.TabIndex = 20;
            this.btnTerminar.Text = "Terminar y guardar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(307, 40);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(51, 17);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha:";
            // 
            // dateTimeEntrada
            // 
            this.dateTimeEntrada.CalendarFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeEntrada.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEntrada.Location = new System.Drawing.Point(306, 60);
            this.dateTimeEntrada.Name = "dateTimeEntrada";
            this.dateTimeEntrada.Size = new System.Drawing.Size(133, 23);
            this.dateTimeEntrada.TabIndex = 18;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(450, 96);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(54, 17);
            this.lblMonto.TabIndex = 17;
            this.lblMonto.Text = "Monto:";
            // 
            // txbMonto
            // 
            this.txbMonto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMonto.Location = new System.Drawing.Point(449, 116);
            this.txbMonto.Name = "txbMonto";
            this.txbMonto.Size = new System.Drawing.Size(133, 23);
            this.txbMonto.TabIndex = 16;
            // 
            // lblSuplidor
            // 
            this.lblSuplidor.AutoSize = true;
            this.lblSuplidor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuplidor.Location = new System.Drawing.Point(15, 40);
            this.lblSuplidor.Name = "lblSuplidor";
            this.lblSuplidor.Size = new System.Drawing.Size(59, 17);
            this.lblSuplidor.TabIndex = 11;
            this.lblSuplidor.Text = "Suplidor";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(14, 152);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 34);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(18, 474);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 31);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.lblTitulo.Text = "Registro de entradas";
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
            this.lineShape1.Y1 = 195;
            this.lineShape1.Y2 = 195;
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
            this.btnCerrar.TabIndex = 16;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 573);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelContedorIngresos);
            this.Name = "FormEntradas";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormEntradas_Load);
            this.panelContedorIngresos.ResumeLayout(false);
            this.panelContedorIngresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEntradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContedorIngresos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTitulo;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label lblSuplidor;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txbMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.DataGridView gridViewEntradas;
        public System.Windows.Forms.DateTimePicker dateTimeEntrada;
        private System.Windows.Forms.ComboBox comboSuplidores;
        private System.Windows.Forms.ComboBox comboMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txbCantidad;
        private System.Windows.Forms.Button btnAgregarSuplidor;
        public System.Windows.Forms.Button btnAgregarMaterial;
        private System.Windows.Forms.Label lblTotalEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suplidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_entrada;
    }
}