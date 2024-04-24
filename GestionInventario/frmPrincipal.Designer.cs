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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPerfilGi = new System.Windows.Forms.Label();
            this.lbNombreGi = new System.Windows.Forms.Label();
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
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbPerfilGi);
            this.panel2.Controls.Add(this.lbNombreGi);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 116);
            this.panel2.TabIndex = 3;
            // 
            // lbPerfilGi
            // 
            this.lbPerfilGi.AutoSize = true;
            this.lbPerfilGi.Location = new System.Drawing.Point(67, 56);
            this.lbPerfilGi.Name = "lbPerfilGi";
            this.lbPerfilGi.Size = new System.Drawing.Size(10, 13);
            this.lbPerfilGi.TabIndex = 1;
            this.lbPerfilGi.Text = ":";
            // 
            // lbNombreGi
            // 
            this.lbNombreGi.AutoSize = true;
            this.lbNombreGi.Location = new System.Drawing.Point(64, 24);
            this.lbNombreGi.Name = "lbNombreGi";
            this.lbNombreGi.Size = new System.Drawing.Size(44, 13);
            this.lbNombreGi.TabIndex = 0;
            this.lbNombreGi.Text = "Nombre";
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
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(31, 307);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(131, 45);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
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
            this.btnRecibo.Text = "Recibo de carne";
            this.btnRecibo.UseVisualStyleBackColor = true;
            // 
            // btnTraslado
            // 
            this.btnTraslado.Location = new System.Drawing.Point(31, 123);
            this.btnTraslado.Name = "btnTraslado";
            this.btnTraslado.Size = new System.Drawing.Size(131, 45);
            this.btnTraslado.TabIndex = 1;
            this.btnTraslado.Text = "Traspaso de carne";
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
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPerfilGi;
        private System.Windows.Forms.Label lbNombreGi;
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
    }
}