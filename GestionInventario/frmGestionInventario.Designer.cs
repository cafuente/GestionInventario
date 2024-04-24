namespace GestionInventario
{
    partial class frmGestionInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionInventario));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNombreGi = new System.Windows.Forms.Label();
            this.lbPerfilGi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtLoteGI = new System.Windows.Forms.TextBox();
            this.txtProductoGi = new System.Windows.Forms.TextBox();
            this.txtPesoGI = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.idLabelGI = new System.Windows.Forms.Label();
            this.IdRegistro = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pbCodigoBarras = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoBarras)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbPerfilGi);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbNombreGi);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 93);
            this.panel2.TabIndex = 1;
            // 
            // lbNombreGi
            // 
            this.lbNombreGi.AutoSize = true;
            this.lbNombreGi.Location = new System.Drawing.Point(115, 16);
            this.lbNombreGi.Name = "lbNombreGi";
            this.lbNombreGi.Size = new System.Drawing.Size(44, 13);
            this.lbNombreGi.TabIndex = 0;
            this.lbNombreGi.Text = "Nombre";
            // 
            // lbPerfilGi
            // 
            this.lbPerfilGi.AutoSize = true;
            this.lbPerfilGi.Location = new System.Drawing.Point(115, 62);
            this.lbPerfilGi.Name = "lbPerfilGi";
            this.lbPerfilGi.Size = new System.Drawing.Size(29, 13);
            this.lbPerfilGi.TabIndex = 1;
            this.lbPerfilGi.Text = "perfil";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Gestion de inventario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 315);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(782, 157);
            this.dataGridView1.TabIndex = 15;
            // 
            // dpFecha
            // 
            this.dpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(398, 232);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(121, 22);
            this.dpFecha.TabIndex = 46;
            this.dpFecha.Value = new System.DateTime(2024, 4, 22, 7, 53, 14, 0);
            // 
            // txtLoteGI
            // 
            this.txtLoteGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteGI.Location = new System.Drawing.Point(398, 171);
            this.txtLoteGI.Name = "txtLoteGI";
            this.txtLoteGI.Size = new System.Drawing.Size(121, 22);
            this.txtLoteGI.TabIndex = 43;
            // 
            // txtProductoGi
            // 
            this.txtProductoGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoGi.Location = new System.Drawing.Point(109, 168);
            this.txtProductoGi.Name = "txtProductoGi";
            this.txtProductoGi.Size = new System.Drawing.Size(157, 21);
            this.txtProductoGi.TabIndex = 44;
            // 
            // txtPesoGI
            // 
            this.txtPesoGI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoGI.Location = new System.Drawing.Point(109, 226);
            this.txtPesoGI.Name = "txtPesoGI";
            this.txtPesoGI.Size = new System.Drawing.Size(157, 22);
            this.txtPesoGI.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(310, 232);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "Fecha:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(310, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 16);
            this.label12.TabIndex = 45;
            this.label12.Text = "Lote:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(39, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 47;
            this.label13.Text = "Producto:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(39, 229);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 16);
            this.label19.TabIndex = 50;
            this.label19.Text = "Peso real:";
            // 
            // idLabelGI
            // 
            this.idLabelGI.AutoSize = true;
            this.idLabelGI.Location = new System.Drawing.Point(126, 127);
            this.idLabelGI.Name = "idLabelGI";
            this.idLabelGI.Size = new System.Drawing.Size(10, 13);
            this.idLabelGI.TabIndex = 53;
            this.idLabelGI.Text = ":";
            // 
            // IdRegistro
            // 
            this.IdRegistro.AutoSize = true;
            this.IdRegistro.Location = new System.Drawing.Point(123, 127);
            this.IdRegistro.Name = "IdRegistro";
            this.IdRegistro.Size = new System.Drawing.Size(0, 13);
            this.IdRegistro.TabIndex = 52;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(39, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 51;
            this.label16.Text = "Id:";
            // 
            // pbCodigoBarras
            // 
            this.pbCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCodigoBarras.Image = global::GestionInventario.Properties.Resources.barcode_scan;
            this.pbCodigoBarras.Location = new System.Drawing.Point(471, 269);
            this.pbCodigoBarras.Name = "pbCodigoBarras";
            this.pbCodigoBarras.Size = new System.Drawing.Size(48, 30);
            this.pbCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCodigoBarras.TabIndex = 54;
            this.pbCodigoBarras.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Buscar";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 275);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 20);
            this.textBox1.TabIndex = 56;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(592, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "Nuevo registro";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(592, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 23);
            this.button2.TabIndex = 58;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(592, 269);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 23);
            this.button3.TabIndex = 59;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbCodigoBarras);
            this.Controls.Add(this.idLabelGI);
            this.Controls.Add(this.IdRegistro);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dpFecha);
            this.Controls.Add(this.txtLoteGI);
            this.Controls.Add(this.txtProductoGi);
            this.Controls.Add(this.txtPesoGI);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "frmGestionInventario";
            this.Text = "frmGestionInventario";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoBarras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPerfilGi;
        private System.Windows.Forms.Label lbNombreGi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.TextBox txtLoteGI;
        private System.Windows.Forms.TextBox txtProductoGi;
        private System.Windows.Forms.TextBox txtPesoGI;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label idLabelGI;
        private System.Windows.Forms.Label IdRegistro;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pbCodigoBarras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}