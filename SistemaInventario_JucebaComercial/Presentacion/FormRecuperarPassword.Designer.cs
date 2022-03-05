
namespace Presentacion
{
    partial class FormRecuperarPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecuperarPassword));
            this.BarrarRecuperarPassword = new System.Windows.Forms.Panel();
            this.btbCerrar = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.lblUsuarioEmail = new System.Windows.Forms.Label();
            this.txbRecuperarPassword = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.BarrarRecuperarPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // BarrarRecuperarPassword
            // 
            this.BarrarRecuperarPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BarrarRecuperarPassword.Controls.Add(this.btbCerrar);
            this.BarrarRecuperarPassword.Controls.Add(this.lblTitulo);
            this.BarrarRecuperarPassword.Controls.Add(this.btnCerrar);
            this.BarrarRecuperarPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarrarRecuperarPassword.Location = new System.Drawing.Point(0, 0);
            this.BarrarRecuperarPassword.Name = "BarrarRecuperarPassword";
            this.BarrarRecuperarPassword.Size = new System.Drawing.Size(593, 34);
            this.BarrarRecuperarPassword.TabIndex = 0;
            this.BarrarRecuperarPassword.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BarrarRecuperarPassword_MouseMove);
            // 
            // btbCerrar
            // 
            this.btbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btbCerrar.Image")));
            this.btbCerrar.Location = new System.Drawing.Point(565, 5);
            this.btbCerrar.Name = "btbCerrar";
            this.btbCerrar.Size = new System.Drawing.Size(23, 23);
            this.btbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btbCerrar.TabIndex = 33;
            this.btbCerrar.TabStop = false;
            this.btbCerrar.Click += new System.EventHandler(this.btbCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(183, 19);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Recuperar Contraseña";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(0, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 50);
            this.btnCerrar.TabIndex = 34;
            this.btnCerrar.TabStop = false;
            // 
            // lblUsuarioEmail
            // 
            this.lblUsuarioEmail.AutoSize = true;
            this.lblUsuarioEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioEmail.Location = new System.Drawing.Point(9, 52);
            this.lblUsuarioEmail.Name = "lblUsuarioEmail";
            this.lblUsuarioEmail.Size = new System.Drawing.Size(332, 17);
            this.lblUsuarioEmail.TabIndex = 30;
            this.lblUsuarioEmail.Text = "Ingrese su nombre de usuario o correo electrónico";
            // 
            // txbRecuperarPassword
            // 
            this.txbRecuperarPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRecuperarPassword.Location = new System.Drawing.Point(12, 72);
            this.txbRecuperarPassword.Name = "txbRecuperarPassword";
            this.txbRecuperarPassword.Size = new System.Drawing.Size(423, 23);
            this.txbRecuperarPassword.TabIndex = 29;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(351, 101);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(84, 28);
            this.btnEnviar.TabIndex = 31;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(9, 159);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(76, 17);
            this.lblResultado.TabIndex = 32;
            this.lblResultado.Text = "Resultado:";
            this.lblResultado.Visible = false;
            // 
            // FormRecuperarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 238);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.lblUsuarioEmail);
            this.Controls.Add(this.txbRecuperarPassword);
            this.Controls.Add(this.BarrarRecuperarPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRecuperarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRecuperarPassword";
            this.BarrarRecuperarPassword.ResumeLayout(false);
            this.BarrarRecuperarPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel BarrarRecuperarPassword;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuarioEmail;
        private System.Windows.Forms.TextBox txbRecuperarPassword;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btbCerrar;
    }
}