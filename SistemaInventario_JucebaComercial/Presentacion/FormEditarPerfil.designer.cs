
namespace Presentacion
{
    partial class FormEditarPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarPerfil));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panelEditarPerfil = new System.Windows.Forms.Panel();
            this.linkEditarPassword = new System.Windows.Forms.LinkLabel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txbPasswordActual = new System.Windows.Forms.TextBox();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            this.txbConfirmarPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.lblIngrsarNombre = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.lblIngrsarNombreUsuario = new System.Windows.Forms.Label();
            this.lblEditarPerfil = new System.Windows.Forms.Label();
            this.txbNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreTitulo = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblEmailTitulo = new System.Windows.Forms.Label();
            this.lblPosicionUsuario = new System.Windows.Forms.Label();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.MiPerfil = new System.Windows.Forms.LinkLabel();
            this.panelEditarPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(14, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 28);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelEditarPerfil
            // 
            this.panelEditarPerfil.BackColor = System.Drawing.Color.Maroon;
            this.panelEditarPerfil.Controls.Add(this.linkEditarPassword);
            this.panelEditarPerfil.Controls.Add(this.btnAceptar);
            this.panelEditarPerfil.Controls.Add(this.btnCancelar);
            this.panelEditarPerfil.Controls.Add(this.label8);
            this.panelEditarPerfil.Controls.Add(this.txbPasswordActual);
            this.panelEditarPerfil.Controls.Add(this.lblConfirmarPassword);
            this.panelEditarPerfil.Controls.Add(this.txbConfirmarPassword);
            this.panelEditarPerfil.Controls.Add(this.lblPassword);
            this.panelEditarPerfil.Controls.Add(this.txbPassword);
            this.panelEditarPerfil.Controls.Add(this.label6);
            this.panelEditarPerfil.Controls.Add(this.txbEmail);
            this.panelEditarPerfil.Controls.Add(this.lblIngrsarNombre);
            this.panelEditarPerfil.Controls.Add(this.txbNombre);
            this.panelEditarPerfil.Controls.Add(this.lblIngrsarNombreUsuario);
            this.panelEditarPerfil.Controls.Add(this.lblEditarPerfil);
            this.panelEditarPerfil.Controls.Add(this.txbNombreUsuario);
            this.panelEditarPerfil.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEditarPerfil.Location = new System.Drawing.Point(550, 0);
            this.panelEditarPerfil.Name = "panelEditarPerfil";
            this.panelEditarPerfil.Size = new System.Drawing.Size(389, 573);
            this.panelEditarPerfil.TabIndex = 3;
            this.panelEditarPerfil.Visible = false;
            // 
            // linkEditarPassword
            // 
            this.linkEditarPassword.AutoSize = true;
            this.linkEditarPassword.BackColor = System.Drawing.Color.Maroon;
            this.linkEditarPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkEditarPassword.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkEditarPassword.Location = new System.Drawing.Point(123, 259);
            this.linkEditarPassword.Name = "linkEditarPassword";
            this.linkEditarPassword.Size = new System.Drawing.Size(46, 16);
            this.linkEditarPassword.TabIndex = 16;
            this.linkEditarPassword.TabStop = true;
            this.linkEditarPassword.Text = "Editar";
            this.linkEditarPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditarPassword_LinkClicked);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(201, 463);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(165, 42);
            this.btnAceptar.TabIndex = 26;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(30, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 42);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(26, 390);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Contraseña actual:";
            // 
            // txbPasswordActual
            // 
            this.txbPasswordActual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPasswordActual.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPasswordActual.Location = new System.Drawing.Point(30, 413);
            this.txbPasswordActual.Name = "txbPasswordActual";
            this.txbPasswordActual.Size = new System.Drawing.Size(336, 26);
            this.txbPasswordActual.TabIndex = 24;
            this.txbPasswordActual.UseSystemPasswordChar = true;
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarPassword.ForeColor = System.Drawing.Color.White;
            this.lblConfirmarPassword.Location = new System.Drawing.Point(26, 323);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(169, 20);
            this.lblConfirmarPassword.TabIndex = 21;
            this.lblConfirmarPassword.Text = "Confirmar Contraseña:";
            // 
            // txbConfirmarPassword
            // 
            this.txbConfirmarPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbConfirmarPassword.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbConfirmarPassword.Location = new System.Drawing.Point(30, 346);
            this.txbConfirmarPassword.Name = "txbConfirmarPassword";
            this.txbConfirmarPassword.Size = new System.Drawing.Size(336, 26);
            this.txbConfirmarPassword.TabIndex = 22;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(26, 256);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(96, 20);
            this.lblPassword.TabIndex = 19;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txbPassword
            // 
            this.txbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPassword.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(30, 279);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(336, 26);
            this.txbPassword.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Correro electrónico:";
            // 
            // txbEmail
            // 
            this.txbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbEmail.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEmail.Location = new System.Drawing.Point(30, 215);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(336, 26);
            this.txbEmail.TabIndex = 18;
            // 
            // lblIngrsarNombre
            // 
            this.lblIngrsarNombre.AutoSize = true;
            this.lblIngrsarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrsarNombre.ForeColor = System.Drawing.Color.White;
            this.lblIngrsarNombre.Location = new System.Drawing.Point(26, 127);
            this.lblIngrsarNombre.Name = "lblIngrsarNombre";
            this.lblIngrsarNombre.Size = new System.Drawing.Size(69, 20);
            this.lblIngrsarNombre.TabIndex = 15;
            this.lblIngrsarNombre.Text = "Nombre:";
            // 
            // txbNombre
            // 
            this.txbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNombre.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombre.Location = new System.Drawing.Point(30, 150);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(336, 26);
            this.txbNombre.TabIndex = 16;
            // 
            // lblIngrsarNombreUsuario
            // 
            this.lblIngrsarNombreUsuario.AutoSize = true;
            this.lblIngrsarNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngrsarNombreUsuario.ForeColor = System.Drawing.Color.White;
            this.lblIngrsarNombreUsuario.Location = new System.Drawing.Point(26, 64);
            this.lblIngrsarNombreUsuario.Name = "lblIngrsarNombreUsuario";
            this.lblIngrsarNombreUsuario.Size = new System.Drawing.Size(147, 20);
            this.lblIngrsarNombreUsuario.TabIndex = 14;
            this.lblIngrsarNombreUsuario.Text = "Nombre de usuario:";
            // 
            // lblEditarPerfil
            // 
            this.lblEditarPerfil.BackColor = System.Drawing.Color.Maroon;
            this.lblEditarPerfil.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditarPerfil.ForeColor = System.Drawing.Color.White;
            this.lblEditarPerfil.Location = new System.Drawing.Point(25, 9);
            this.lblEditarPerfil.Name = "lblEditarPerfil";
            this.lblEditarPerfil.Size = new System.Drawing.Size(184, 31);
            this.lblEditarPerfil.TabIndex = 14;
            this.lblEditarPerfil.Text = "Editar mi perfil";
            this.lblEditarPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNombreUsuario
            // 
            this.txbNombreUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombreUsuario.Location = new System.Drawing.Point(30, 87);
            this.txbNombreUsuario.Name = "txbNombreUsuario";
            this.txbNombreUsuario.Size = new System.Drawing.Size(336, 26);
            this.txbNombreUsuario.TabIndex = 14;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(55, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(113, 31);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Mi perfil";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(60, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(273, 77);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(147, 20);
            this.lblNombreUsuario.TabIndex = 6;
            this.lblNombreUsuario.Text = "Nombre de usuario:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(274, 106);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(55, 16);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(274, 160);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(57, 16);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre";
            // 
            // lblNombreTitulo
            // 
            this.lblNombreTitulo.AutoSize = true;
            this.lblNombreTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreTitulo.Location = new System.Drawing.Point(273, 131);
            this.lblNombreTitulo.Name = "lblNombreTitulo";
            this.lblNombreTitulo.Size = new System.Drawing.Size(69, 20);
            this.lblNombreTitulo.TabIndex = 8;
            this.lblNombreTitulo.Text = "Nombre:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(274, 215);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(49, 16);
            this.lblCorreo.TabIndex = 11;
            this.lblCorreo.Text = "Correo";
            // 
            // lblEmailTitulo
            // 
            this.lblEmailTitulo.AutoSize = true;
            this.lblEmailTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailTitulo.Location = new System.Drawing.Point(273, 186);
            this.lblEmailTitulo.Name = "lblEmailTitulo";
            this.lblEmailTitulo.Size = new System.Drawing.Size(147, 20);
            this.lblEmailTitulo.TabIndex = 10;
            this.lblEmailTitulo.Text = "Correro electrónico:";
            // 
            // lblPosicionUsuario
            // 
            this.lblPosicionUsuario.AutoSize = true;
            this.lblPosicionUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosicionUsuario.Location = new System.Drawing.Point(274, 269);
            this.lblPosicionUsuario.Name = "lblPosicionUsuario";
            this.lblPosicionUsuario.Size = new System.Drawing.Size(60, 16);
            this.lblPosicionUsuario.TabIndex = 13;
            this.lblPosicionUsuario.Text = "Posición";
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosicion.Location = new System.Drawing.Point(273, 240);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(68, 20);
            this.lblPosicion.TabIndex = 12;
            this.lblPosicion.Text = "Posición";
            // 
            // MiPerfil
            // 
            this.MiPerfil.AutoSize = true;
            this.MiPerfil.BackColor = System.Drawing.Color.White;
            this.MiPerfil.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiPerfil.LinkColor = System.Drawing.Color.Blue;
            this.MiPerfil.Location = new System.Drawing.Point(274, 298);
            this.MiPerfil.Name = "MiPerfil";
            this.MiPerfil.Size = new System.Drawing.Size(80, 17);
            this.MiPerfil.TabIndex = 15;
            this.MiPerfil.TabStop = true;
            this.MiPerfil.Text = "Editar perfil";
            this.MiPerfil.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MiPerfil_LinkClicked);
            // 
            // FormEditarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 573);
            this.Controls.Add(this.MiPerfil);
            this.Controls.Add(this.lblPosicionUsuario);
            this.Controls.Add(this.lblPosicion);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblEmailTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblNombreTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelEditarPerfil);
            this.Controls.Add(this.btnCerrar);
            this.Name = "FormEditarPerfil";
            this.Text = "FormEditarPerfil";
            this.Load += new System.EventHandler(this.FormEditarPerfil_Load);
            this.panelEditarPerfil.ResumeLayout(false);
            this.panelEditarPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel panelEditarPerfil;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblEmailTitulo;
        private System.Windows.Forms.Label lblPosicionUsuario;
        private System.Windows.Forms.Label lblPosicion;
        private System.Windows.Forms.TextBox txbNombreUsuario;
        private System.Windows.Forms.Label lblEditarPerfil;
        private System.Windows.Forms.Label lblIngrsarNombreUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label lblIngrsarNombre;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label lblConfirmarPassword;
        private System.Windows.Forms.TextBox txbConfirmarPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbPasswordActual;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.LinkLabel linkEditarPassword;
        private System.Windows.Forms.LinkLabel MiPerfil;
    }
}