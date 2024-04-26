namespace GestionInventario
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPerfilPr = new System.Windows.Forms.Label();
            this.lbNombrePr = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAdministrador = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnMezclado = new System.Windows.Forms.Button();
            this.btnRecibo = new System.Windows.Forms.Button();
            this.btnTraslado = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnRecepcion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDepartamentoMu = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDepartamentoMu);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbPerfilPr);
            this.panel2.Controls.Add(this.lbNombrePr);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 90);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lbPerfilPr
            // 
            this.lbPerfilPr.AutoSize = true;
            this.lbPerfilPr.Location = new System.Drawing.Point(109, 56);
            this.lbPerfilPr.Name = "lbPerfilPr";
            this.lbPerfilPr.Size = new System.Drawing.Size(30, 13);
            this.lbPerfilPr.TabIndex = 1;
            this.lbPerfilPr.Text = "Perfil";
            // 
            // lbNombrePr
            // 
            this.lbNombrePr.AutoSize = true;
            this.lbNombrePr.Location = new System.Drawing.Point(109, 12);
            this.lbNombrePr.Name = "lbNombrePr";
            this.lbNombrePr.Size = new System.Drawing.Size(44, 13);
            this.lbNombrePr.TabIndex = 0;
            this.lbNombrePr.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAdministrador);
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Controls.Add(this.btnMezclado);
            this.panel1.Controls.Add(this.btnRecibo);
            this.panel1.Controls.Add(this.btnTraslado);
            this.panel1.Controls.Add(this.btnAlmacen);
            this.panel1.Location = new System.Drawing.Point(2, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 367);
            this.panel1.TabIndex = 2;
            // 
            // txtAdministrador
            // 
            this.txtAdministrador.Location = new System.Drawing.Point(31, 12);
            this.txtAdministrador.Name = "txtAdministrador";
            this.txtAdministrador.Size = new System.Drawing.Size(131, 45);
            this.txtAdministrador.TabIndex = 5;
            this.txtAdministrador.Text = "Administrador";
            this.txtAdministrador.UseVisualStyleBackColor = true;
            this.txtAdministrador.Click += new System.EventHandler(this.txtAdministrador_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(31, 307);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(131, 45);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnMezclado
            // 
            this.btnMezclado.Location = new System.Drawing.Point(31, 241);
            this.btnMezclado.Name = "btnMezclado";
            this.btnMezclado.Size = new System.Drawing.Size(131, 45);
            this.btnMezclado.TabIndex = 3;
            this.btnMezclado.Text = "Mezclado";
            this.btnMezclado.UseVisualStyleBackColor = true;
            // 
            // btnRecibo
            // 
            this.btnRecibo.Location = new System.Drawing.Point(31, 182);
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Size = new System.Drawing.Size(131, 45);
            this.btnRecibo.TabIndex = 2;
            this.btnRecibo.Text = "Recibo (mocha)";
            this.btnRecibo.UseVisualStyleBackColor = true;
            // 
            // btnTraslado
            // 
            this.btnTraslado.Location = new System.Drawing.Point(31, 123);
            this.btnTraslado.Name = "btnTraslado";
            this.btnTraslado.Size = new System.Drawing.Size(131, 45);
            this.btnTraslado.TabIndex = 1;
            this.btnTraslado.Text = "LyF (traslado)";
            this.btnTraslado.UseVisualStyleBackColor = true;
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.Location = new System.Drawing.Point(31, 68);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(131, 45);
            this.btnAlmacen.TabIndex = 0;
            this.btnAlmacen.Text = "Almacen carnicos";
            this.btnAlmacen.UseVisualStyleBackColor = true;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGestion);
            this.panel3.Controls.Add(this.btnRecepcion);
            this.panel3.Location = new System.Drawing.Point(219, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 367);
            this.panel3.TabIndex = 4;
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(310, 92);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(153, 50);
            this.btnGestion.TabIndex = 1;
            this.btnGestion.Text = "Gestion de inventario";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnRecepcion
            // 
            this.btnRecepcion.Location = new System.Drawing.Point(76, 92);
            this.btnRecepcion.Name = "btnRecepcion";
            this.btnRecepcion.Size = new System.Drawing.Size(153, 50);
            this.btnRecepcion.TabIndex = 0;
            this.btnRecepcion.Text = "Recepcion de carne";
            this.btnRecepcion.UseVisualStyleBackColor = true;
            this.btnRecepcion.Click += new System.EventHandler(this.btnRecepcion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Menu principal";
            // 
            // lbDepartamentoMu
            // 
            this.lbDepartamentoMu.AutoSize = true;
            this.lbDepartamentoMu.Location = new System.Drawing.Point(109, 36);
            this.lbDepartamentoMu.Name = "lbDepartamentoMu";
            this.lbDepartamentoMu.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoMu.TabIndex = 15;
            this.lbDepartamentoMu.Text = "Deptto";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPerfilPr;
        private System.Windows.Forms.Label lbNombrePr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnMezclado;
        private System.Windows.Forms.Button btnRecibo;
        private System.Windows.Forms.Button btnTraslado;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.Button txtAdministrador;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnRecepcion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDepartamentoMu;
    }
}