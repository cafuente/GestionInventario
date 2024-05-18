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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoGi = new System.Windows.Forms.Label();
            this.lbPerfilGi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNombreGi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.txtCodigoBarrasGi = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFechaGi = new System.Windows.Forms.Label();
            this.txtCantidadGi = new System.Windows.Forms.Label();
            this.txtLoteGi = new System.Windows.Forms.Label();
            this.txtProductoGi = new System.Windows.Forms.Label();
            this.idTarima = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpFechaGi = new System.Windows.Forms.DateTimePicker();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.btnCacelarGi = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDepartamentoGi);
            this.panel2.Controls.Add(this.lbPerfilGi);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbNombreGi);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 85);
            this.panel2.TabIndex = 1;
            // 
            // lbDepartamentoGi
            // 
            this.lbDepartamentoGi.AutoSize = true;
            this.lbDepartamentoGi.Location = new System.Drawing.Point(90, 34);
            this.lbDepartamentoGi.Name = "lbDepartamentoGi";
            this.lbDepartamentoGi.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoGi.TabIndex = 14;
            this.lbDepartamentoGi.Text = "Deptto";
            // 
            // lbPerfilGi
            // 
            this.lbPerfilGi.AutoSize = true;
            this.lbPerfilGi.Location = new System.Drawing.Point(90, 56);
            this.lbPerfilGi.Name = "lbPerfilGi";
            this.lbPerfilGi.Size = new System.Drawing.Size(29, 13);
            this.lbPerfilGi.TabIndex = 1;
            this.lbPerfilGi.Text = "perfil";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lbNombreGi
            // 
            this.lbNombreGi.AutoSize = true;
            this.lbNombreGi.Location = new System.Drawing.Point(90, 12);
            this.lbNombreGi.Name = "lbNombreGi";
            this.lbNombreGi.Size = new System.Drawing.Size(44, 13);
            this.lbNombreGi.TabIndex = 0;
            this.lbNombreGi.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Gestion de inventario";
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(12, 374);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(773, 157);
            this.dgvInventario.TabIndex = 15;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // btnSalida
            // 
            this.btnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.Location = new System.Drawing.Point(37, 46);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(127, 27);
            this.btnSalida.TabIndex = 16;
            this.btnSalida.Text = "Traspaso";
            this.btnSalida.UseVisualStyleBackColor = true;
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolucion.Location = new System.Drawing.Point(37, 89);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(127, 27);
            this.btnDevolucion.TabIndex = 17;
            this.btnDevolucion.Text = "Devolución";
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // txtCodigoBarrasGi
            // 
            this.txtCodigoBarrasGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarrasGi.Location = new System.Drawing.Point(157, 54);
            this.txtCodigoBarrasGi.Name = "txtCodigoBarrasGi";
            this.txtCodigoBarrasGi.Size = new System.Drawing.Size(125, 23);
            this.txtCodigoBarrasGi.TabIndex = 44;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::GestionInventario.Properties.Resources.buscar_barcode;
            this.pictureBox2.Location = new System.Drawing.Point(116, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(311, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 67;
            this.label6.Text = "Deptto destino:";
            // 
            // dtFechaGi
            // 
            this.dtFechaGi.AutoSize = true;
            this.dtFechaGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaGi.Location = new System.Drawing.Point(340, 62);
            this.dtFechaGi.Name = "dtFechaGi";
            this.dtFechaGi.Size = new System.Drawing.Size(51, 17);
            this.dtFechaGi.TabIndex = 66;
            this.dtFechaGi.Text = "Fecha:";
            // 
            // txtCantidadGi
            // 
            this.txtCantidadGi.AutoSize = true;
            this.txtCantidadGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadGi.Location = new System.Drawing.Point(20, 172);
            this.txtCantidadGi.Name = "txtCantidadGi";
            this.txtCantidadGi.Size = new System.Drawing.Size(68, 17);
            this.txtCantidadGi.TabIndex = 65;
            this.txtCantidadGi.Text = "Cantidad:";
            // 
            // txtLoteGi
            // 
            this.txtLoteGi.AutoSize = true;
            this.txtLoteGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteGi.Location = new System.Drawing.Point(359, 112);
            this.txtLoteGi.Name = "txtLoteGi";
            this.txtLoteGi.Size = new System.Drawing.Size(40, 17);
            this.txtLoteGi.TabIndex = 64;
            this.txtLoteGi.Text = "Lote:";
            // 
            // txtProductoGi
            // 
            this.txtProductoGi.AutoSize = true;
            this.txtProductoGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoGi.Location = new System.Drawing.Point(6, 116);
            this.txtProductoGi.Name = "txtProductoGi";
            this.txtProductoGi.Size = new System.Drawing.Size(69, 17);
            this.txtProductoGi.TabIndex = 63;
            this.txtProductoGi.Text = "Producto:";
            // 
            // idTarima
            // 
            this.idTarima.AutoSize = true;
            this.idTarima.Location = new System.Drawing.Point(6, 54);
            this.idTarima.Name = "idTarima";
            this.idTarima.Size = new System.Drawing.Size(78, 17);
            this.idTarima.TabIndex = 62;
            this.idTarima.Text = "ID Tarima";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(120, 169);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(162, 23);
            this.textBox3.TabIndex = 59;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(415, 109);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 23);
            this.textBox2.TabIndex = 58;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 23);
            this.textBox1.TabIndex = 57;
            // 
            // dtpFechaGi
            // 
            this.dtpFechaGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaGi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaGi.Location = new System.Drawing.Point(415, 54);
            this.dtpFechaGi.Name = "dtpFechaGi";
            this.dtpFechaGi.Size = new System.Drawing.Size(121, 23);
            this.dtpFechaGi.TabIndex = 68;
            this.dtpFechaGi.Value = new System.DateTime(2024, 5, 18, 7, 45, 34, 0);
            // 
            // cbDestino
            // 
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(415, 169);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(121, 24);
            this.cbDestino.TabIndex = 69;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDestino);
            this.groupBox1.Controls.Add(this.idTarima);
            this.groupBox1.Controls.Add(this.dtpFechaGi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtFechaGi);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.txtCantidadGi);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasGi);
            this.groupBox1.Controls.Add(this.txtLoteGi);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtProductoGi);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 218);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traspaso a otros almacenes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDevolucion);
            this.groupBox2.Controls.Add(this.btnSalida);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(582, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 218);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de movimiento";
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.Location = new System.Drawing.Point(95, 327);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(185, 35);
            this.btnRegistrarSalida.TabIndex = 72;
            this.btnRegistrarSalida.Text = "Aceptar";
            this.btnRegistrarSalida.UseVisualStyleBackColor = true;
            // 
            // btnCacelarGi
            // 
            this.btnCacelarGi.Location = new System.Drawing.Point(361, 327);
            this.btnCacelarGi.Name = "btnCacelarGi";
            this.btnCacelarGi.Size = new System.Drawing.Size(185, 35);
            this.btnCacelarGi.TabIndex = 73;
            this.btnCacelarGi.Text = "Cancelar";
            this.btnCacelarGi.UseVisualStyleBackColor = true;
            // 
            // frmGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 538);
            this.Controls.Add(this.btnCacelarGi);
            this.Controls.Add(this.btnRegistrarSalida);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "frmGestionInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestionInventario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionInventario_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionInventario_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPerfilGi;
        private System.Windows.Forms.Label lbNombreGi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbDepartamentoGi;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.TextBox txtCodigoBarrasGi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dtFechaGi;
        private System.Windows.Forms.Label txtCantidadGi;
        private System.Windows.Forms.Label txtLoteGi;
        private System.Windows.Forms.Label txtProductoGi;
        private System.Windows.Forms.Label idTarima;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaGi;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.Button btnCacelarGi;
    }
}