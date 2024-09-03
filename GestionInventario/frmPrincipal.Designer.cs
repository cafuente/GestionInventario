namespace GestionInventario
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbDepartamentoMu = new System.Windows.Forms.Label();
            this.lbPerfilPr = new System.Windows.Forms.Label();
            this.lbNombrePr = new System.Windows.Forms.Label();
            this.panelVertical = new System.Windows.Forms.Panel();
            this.pbCargarImagenMenu = new System.Windows.Forms.PictureBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnTrazabilidad = new System.Windows.Forms.Button();
            this.btnLogistica = new System.Windows.Forms.Button();
            this.pbLogoMenu = new System.Windows.Forms.PictureBox();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnMezclado = new System.Windows.Forms.Button();
            this.btnRecibo = new System.Windows.Forms.Button();
            this.btnTraslado = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnRecepcion = new System.Windows.Forms.Button();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoMenu)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.White;
            this.panelTitulo.Controls.Add(this.label1);
            this.panelTitulo.Controls.Add(this.pictureBox1);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(245, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(702, 90);
            this.panelTitulo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Menu principal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(593, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lbDepartamentoMu
            // 
            this.lbDepartamentoMu.AutoSize = true;
            this.lbDepartamentoMu.Location = new System.Drawing.Point(82, 42);
            this.lbDepartamentoMu.Name = "lbDepartamentoMu";
            this.lbDepartamentoMu.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoMu.TabIndex = 15;
            this.lbDepartamentoMu.Text = "Deptto";
            // 
            // lbPerfilPr
            // 
            this.lbPerfilPr.AutoSize = true;
            this.lbPerfilPr.Location = new System.Drawing.Point(82, 66);
            this.lbPerfilPr.Name = "lbPerfilPr";
            this.lbPerfilPr.Size = new System.Drawing.Size(30, 13);
            this.lbPerfilPr.TabIndex = 1;
            this.lbPerfilPr.Text = "Perfil";
            // 
            // lbNombrePr
            // 
            this.lbNombrePr.AutoSize = true;
            this.lbNombrePr.Location = new System.Drawing.Point(82, 18);
            this.lbNombrePr.Name = "lbNombrePr";
            this.lbNombrePr.Size = new System.Drawing.Size(44, 13);
            this.lbNombrePr.TabIndex = 0;
            this.lbNombrePr.Text = "Nombre";
            // 
            // panelVertical
            // 
            this.panelVertical.Controls.Add(this.pbCargarImagenMenu);
            this.panelVertical.Controls.Add(this.btnReporte);
            this.panelVertical.Controls.Add(this.btnTrazabilidad);
            this.panelVertical.Controls.Add(this.btnLogistica);
            this.panelVertical.Controls.Add(this.pbLogoMenu);
            this.panelVertical.Controls.Add(this.lbDepartamentoMu);
            this.panelVertical.Controls.Add(this.btnAdministrador);
            this.panelVertical.Controls.Add(this.btnCerrarSesion);
            this.panelVertical.Controls.Add(this.btnMezclado);
            this.panelVertical.Controls.Add(this.lbNombrePr);
            this.panelVertical.Controls.Add(this.btnRecibo);
            this.panelVertical.Controls.Add(this.lbPerfilPr);
            this.panelVertical.Controls.Add(this.btnTraslado);
            this.panelVertical.Controls.Add(this.btnAlmacen);
            this.panelVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelVertical.Location = new System.Drawing.Point(0, 0);
            this.panelVertical.Name = "panelVertical";
            this.panelVertical.Size = new System.Drawing.Size(245, 664);
            this.panelVertical.TabIndex = 2;
            // 
            // pbCargarImagenMenu
            // 
            this.pbCargarImagenMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbCargarImagenMenu.Image")));
            this.pbCargarImagenMenu.Location = new System.Drawing.Point(54, 63);
            this.pbCargarImagenMenu.Name = "pbCargarImagenMenu";
            this.pbCargarImagenMenu.Size = new System.Drawing.Size(20, 16);
            this.pbCargarImagenMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargarImagenMenu.TabIndex = 73;
            this.pbCargarImagenMenu.TabStop = false;
            this.pbCargarImagenMenu.Click += new System.EventHandler(this.pbCargarImagenMenu_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Location = new System.Drawing.Point(0, 531);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(245, 57);
            this.btnReporte.TabIndex = 18;
            this.btnReporte.Text = "Reportes";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnTrazabilidad
            // 
            this.btnTrazabilidad.FlatAppearance.BorderSize = 0;
            this.btnTrazabilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrazabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrazabilidad.Location = new System.Drawing.Point(0, 472);
            this.btnTrazabilidad.Name = "btnTrazabilidad";
            this.btnTrazabilidad.Size = new System.Drawing.Size(245, 57);
            this.btnTrazabilidad.TabIndex = 17;
            this.btnTrazabilidad.Text = "Trazabilidad";
            this.btnTrazabilidad.UseVisualStyleBackColor = true;
            this.btnTrazabilidad.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogistica
            // 
            this.btnLogistica.FlatAppearance.BorderSize = 0;
            this.btnLogistica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogistica.Location = new System.Drawing.Point(0, 414);
            this.btnLogistica.Name = "btnLogistica";
            this.btnLogistica.Size = new System.Drawing.Size(245, 57);
            this.btnLogistica.TabIndex = 16;
            this.btnLogistica.Text = "Logistica";
            this.btnLogistica.UseVisualStyleBackColor = true;
            this.btnLogistica.Click += new System.EventHandler(this.btnLogistica_Click);
            // 
            // pbLogoMenu
            // 
            this.pbLogoMenu.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pbLogoMenu.Location = new System.Drawing.Point(4, 4);
            this.pbLogoMenu.Name = "pbLogoMenu";
            this.pbLogoMenu.Size = new System.Drawing.Size(75, 85);
            this.pbLogoMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoMenu.TabIndex = 2;
            this.pbLogoMenu.TabStop = false;
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.FlatAppearance.BorderSize = 0;
            this.btnAdministrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrador.Location = new System.Drawing.Point(0, 124);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(245, 57);
            this.btnAdministrador.TabIndex = 1;
            this.btnAdministrador.Text = "Gestion  de usuarios";
            this.btnAdministrador.UseVisualStyleBackColor = true;
            this.btnAdministrador.Click += new System.EventHandler(this.txtAdministrador_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 598);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(245, 45);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnMezclado
            // 
            this.btnMezclado.FlatAppearance.BorderSize = 0;
            this.btnMezclado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMezclado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMezclado.Location = new System.Drawing.Point(0, 356);
            this.btnMezclado.Name = "btnMezclado";
            this.btnMezclado.Size = new System.Drawing.Size(245, 57);
            this.btnMezclado.TabIndex = 4;
            this.btnMezclado.Text = "Mezclado";
            this.btnMezclado.UseVisualStyleBackColor = true;
            this.btnMezclado.Click += new System.EventHandler(this.btnMezclado_Click);
            // 
            // btnRecibo
            // 
            this.btnRecibo.FlatAppearance.BorderSize = 0;
            this.btnRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecibo.Location = new System.Drawing.Point(0, 298);
            this.btnRecibo.Name = "btnRecibo";
            this.btnRecibo.Size = new System.Drawing.Size(245, 57);
            this.btnRecibo.TabIndex = 4;
            this.btnRecibo.Text = "Recibo";
            this.btnRecibo.UseVisualStyleBackColor = true;
            this.btnRecibo.Click += new System.EventHandler(this.btnRecibo_Click);
            // 
            // btnTraslado
            // 
            this.btnTraslado.FlatAppearance.BorderSize = 0;
            this.btnTraslado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraslado.Location = new System.Drawing.Point(0, 240);
            this.btnTraslado.Name = "btnTraslado";
            this.btnTraslado.Size = new System.Drawing.Size(245, 57);
            this.btnTraslado.TabIndex = 3;
            this.btnTraslado.Text = "Traslado";
            this.btnTraslado.UseVisualStyleBackColor = true;
            this.btnTraslado.Click += new System.EventHandler(this.btnTraslado_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.FlatAppearance.BorderSize = 0;
            this.btnAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlmacen.Location = new System.Drawing.Point(0, 182);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(245, 57);
            this.btnAlmacen.TabIndex = 2;
            this.btnAlmacen.Text = "Almacen carnicos";
            this.btnAlmacen.UseVisualStyleBackColor = true;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.btnGestion);
            this.panel3.Controls.Add(this.btnRecepcion);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(245, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 574);
            this.panel3.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 216);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(702, 358);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // btnGestion
            // 
            this.btnGestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGestion.BackColor = System.Drawing.Color.LightGray;
            this.btnGestion.Location = new System.Drawing.Point(386, 85);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(153, 50);
            this.btnGestion.TabIndex = 1;
            this.btnGestion.Text = "Gestion de inventario";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnRecepcion
            // 
            this.btnRecepcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecepcion.BackColor = System.Drawing.Color.LightGray;
            this.btnRecepcion.Location = new System.Drawing.Point(152, 85);
            this.btnRecepcion.Name = "btnRecepcion";
            this.btnRecepcion.Size = new System.Drawing.Size(153, 50);
            this.btnRecepcion.TabIndex = 0;
            this.btnRecepcion.Text = "Recepcion de carne";
            this.btnRecepcion.UseVisualStyleBackColor = true;
            this.btnRecepcion.Click += new System.EventHandler(this.btnRecepcion_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 664);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.panelVertical);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelVertical.ResumeLayout(false);
            this.panelVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoMenu)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lbPerfilPr;
        private System.Windows.Forms.Label lbNombrePr;
        private System.Windows.Forms.Panel panelVertical;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnMezclado;
        private System.Windows.Forms.Button btnRecibo;
        private System.Windows.Forms.Button btnTraslado;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnRecepcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDepartamentoMu;
        private System.Windows.Forms.PictureBox pbLogoMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnLogistica;
        private System.Windows.Forms.Button btnTrazabilidad;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.PictureBox pbCargarImagenMenu;
    }
}