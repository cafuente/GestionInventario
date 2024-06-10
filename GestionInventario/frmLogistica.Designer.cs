namespace GestionInventario
{
    partial class FrmLogistica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoLyfc = new System.Windows.Forms.Label();
            this.lbPerfilLyfc = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNombreLyfc = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInventarioTotal = new System.Windows.Forms.TabPage();
            this.dgvInventarioTotalLogistica = new System.Windows.Forms.DataGridView();
            this.tabTraspaso = new System.Windows.Forms.TabPage();
            this.btnCancelarGi = new System.Windows.Forms.Button();
            this.btnRegistrarTraspasoGi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMov = new System.Windows.Forms.Label();
            this.cbDestinoGi = new System.Windows.Forms.ComboBox();
            this.lbIdTarima = new System.Windows.Forms.Label();
            this.dtpFechaGi = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFechaGi = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodigoBarrasGi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductoGi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLoteGi = new System.Windows.Forms.TextBox();
            this.txtCantidadGi = new System.Windows.Forms.TextBox();
            this.dgvInventarioLyfc = new System.Windows.Forms.DataGridView();
            this.tabDevoluciones = new System.Windows.Forms.TabPage();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbIdTraspasoDv = new System.Windows.Forms.Label();
            this.cbDestinoDv = new System.Windows.Forms.ComboBox();
            this.lbIdTarimaDv = new System.Windows.Forms.Label();
            this.dtpFechaDevolucion = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBusquedaDevoGi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProductoDv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoteDv = new System.Windows.Forms.TextBox();
            this.txtCantidadDv = new System.Windows.Forms.TextBox();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.dgvTraspasosLyfc = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInventarioTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotalLogistica)).BeginInit();
            this.tabTraspaso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioLyfc)).BeginInit();
            this.tabDevoluciones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraspasosLyfc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDepartamentoLyfc);
            this.panel2.Controls.Add(this.lbPerfilLyfc);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbNombreLyfc);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 85);
            this.panel2.TabIndex = 20;
            // 
            // lbDepartamentoLyfc
            // 
            this.lbDepartamentoLyfc.AutoSize = true;
            this.lbDepartamentoLyfc.Location = new System.Drawing.Point(90, 34);
            this.lbDepartamentoLyfc.Name = "lbDepartamentoLyfc";
            this.lbDepartamentoLyfc.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoLyfc.TabIndex = 14;
            this.lbDepartamentoLyfc.Text = "Deptto";
            // 
            // lbPerfilLyfc
            // 
            this.lbPerfilLyfc.AutoSize = true;
            this.lbPerfilLyfc.Location = new System.Drawing.Point(90, 56);
            this.lbPerfilLyfc.Name = "lbPerfilLyfc";
            this.lbPerfilLyfc.Size = new System.Drawing.Size(29, 13);
            this.lbPerfilLyfc.TabIndex = 1;
            this.lbPerfilLyfc.Text = "perfil";
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
            // lbNombreLyfc
            // 
            this.lbNombreLyfc.AutoSize = true;
            this.lbNombreLyfc.Location = new System.Drawing.Point(90, 12);
            this.lbNombreLyfc.Name = "lbNombreLyfc";
            this.lbNombreLyfc.Size = new System.Drawing.Size(44, 13);
            this.lbNombreLyfc.TabIndex = 0;
            this.lbNombreLyfc.Text = "Nombre";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInventarioTotal);
            this.tabControl1.Controls.Add(this.tabTraspaso);
            this.tabControl1.Controls.Add(this.tabDevoluciones);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 136);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 494);
            this.tabControl1.TabIndex = 21;
            // 
            // tabInventarioTotal
            // 
            this.tabInventarioTotal.Controls.Add(this.dgvInventarioTotalLogistica);
            this.tabInventarioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInventarioTotal.Location = new System.Drawing.Point(4, 25);
            this.tabInventarioTotal.Name = "tabInventarioTotal";
            this.tabInventarioTotal.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventarioTotal.Size = new System.Drawing.Size(812, 465);
            this.tabInventarioTotal.TabIndex = 0;
            this.tabInventarioTotal.Text = "Inventario Total";
            this.tabInventarioTotal.UseVisualStyleBackColor = true;
            // 
            // dgvInventarioTotalLogistica
            // 
            this.dgvInventarioTotalLogistica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventarioTotalLogistica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventarioTotalLogistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventarioTotalLogistica.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventarioTotalLogistica.Location = new System.Drawing.Point(20, 44);
            this.dgvInventarioTotalLogistica.Name = "dgvInventarioTotalLogistica";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventarioTotalLogistica.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInventarioTotalLogistica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioTotalLogistica.Size = new System.Drawing.Size(773, 404);
            this.dgvInventarioTotalLogistica.TabIndex = 75;
            // 
            // tabTraspaso
            // 
            this.tabTraspaso.Controls.Add(this.btnCancelarGi);
            this.tabTraspaso.Controls.Add(this.btnRegistrarTraspasoGi);
            this.tabTraspaso.Controls.Add(this.groupBox1);
            this.tabTraspaso.Controls.Add(this.dgvInventarioLyfc);
            this.tabTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTraspaso.Location = new System.Drawing.Point(4, 25);
            this.tabTraspaso.Name = "tabTraspaso";
            this.tabTraspaso.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraspaso.Size = new System.Drawing.Size(812, 465);
            this.tabTraspaso.TabIndex = 1;
            this.tabTraspaso.Text = "Traspasos";
            this.tabTraspaso.UseVisualStyleBackColor = true;
            // 
            // btnCancelarGi
            // 
            this.btnCancelarGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarGi.Location = new System.Drawing.Point(649, 135);
            this.btnCancelarGi.Name = "btnCancelarGi";
            this.btnCancelarGi.Size = new System.Drawing.Size(127, 35);
            this.btnCancelarGi.TabIndex = 78;
            this.btnCancelarGi.Text = "Cancelar";
            this.btnCancelarGi.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarTraspasoGi
            // 
            this.btnRegistrarTraspasoGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarTraspasoGi.Location = new System.Drawing.Point(649, 67);
            this.btnRegistrarTraspasoGi.Name = "btnRegistrarTraspasoGi";
            this.btnRegistrarTraspasoGi.Size = new System.Drawing.Size(127, 35);
            this.btnRegistrarTraspasoGi.TabIndex = 16;
            this.btnRegistrarTraspasoGi.Text = "Realizar traspaso";
            this.btnRegistrarTraspasoGi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMov);
            this.groupBox1.Controls.Add(this.cbDestinoGi);
            this.groupBox1.Controls.Add(this.lbIdTarima);
            this.groupBox1.Controls.Add(this.dtpFechaGi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtFechaGi);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasGi);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtProductoGi);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtLoteGi);
            this.groupBox1.Controls.Add(this.txtCantidadGi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 218);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traspaso a otros almacenes";
            // 
            // lbMov
            // 
            this.lbMov.AutoSize = true;
            this.lbMov.Location = new System.Drawing.Point(9, 199);
            this.lbMov.Name = "lbMov";
            this.lbMov.Size = new System.Drawing.Size(71, 17);
            this.lbMov.TabIndex = 70;
            this.lbMov.Text = "traspaso";
            this.lbMov.Visible = false;
            // 
            // cbDestinoGi
            // 
            this.cbDestinoGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestinoGi.FormattingEnabled = true;
            this.cbDestinoGi.Location = new System.Drawing.Point(415, 169);
            this.cbDestinoGi.Name = "cbDestinoGi";
            this.cbDestinoGi.Size = new System.Drawing.Size(121, 24);
            this.cbDestinoGi.TabIndex = 69;
            // 
            // lbIdTarima
            // 
            this.lbIdTarima.AutoSize = true;
            this.lbIdTarima.Location = new System.Drawing.Point(6, 54);
            this.lbIdTarima.Name = "lbIdTarima";
            this.lbIdTarima.Size = new System.Drawing.Size(78, 17);
            this.lbIdTarima.TabIndex = 62;
            this.lbIdTarima.Text = "ID Tarima";
            // 
            // dtpFechaGi
            // 
            this.dtpFechaGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaGi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaGi.Location = new System.Drawing.Point(415, 54);
            this.dtpFechaGi.Name = "dtpFechaGi";
            this.dtpFechaGi.Size = new System.Drawing.Size(121, 23);
            this.dtpFechaGi.TabIndex = 68;
            this.dtpFechaGi.Value = new System.DateTime(2024, 5, 20, 0, 0, 0, 0);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 65;
            this.label12.Text = "Cantidad:";
            // 
            // txtCodigoBarrasGi
            // 
            this.txtCodigoBarrasGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarrasGi.Location = new System.Drawing.Point(157, 54);
            this.txtCodigoBarrasGi.Name = "txtCodigoBarrasGi";
            this.txtCodigoBarrasGi.Size = new System.Drawing.Size(125, 23);
            this.txtCodigoBarrasGi.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(359, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 64;
            this.label11.Text = "Lote:";
            // 
            // txtProductoGi
            // 
            this.txtProductoGi.Location = new System.Drawing.Point(98, 109);
            this.txtProductoGi.Name = "txtProductoGi";
            this.txtProductoGi.Size = new System.Drawing.Size(184, 23);
            this.txtProductoGi.TabIndex = 57;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 63;
            this.label10.Text = "Producto:";
            // 
            // txtLoteGi
            // 
            this.txtLoteGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteGi.Location = new System.Drawing.Point(415, 109);
            this.txtLoteGi.Name = "txtLoteGi";
            this.txtLoteGi.Size = new System.Drawing.Size(121, 23);
            this.txtLoteGi.TabIndex = 58;
            // 
            // txtCantidadGi
            // 
            this.txtCantidadGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadGi.Location = new System.Drawing.Point(120, 169);
            this.txtCantidadGi.Name = "txtCantidadGi";
            this.txtCantidadGi.Size = new System.Drawing.Size(162, 23);
            this.txtCantidadGi.TabIndex = 59;
            // 
            // dgvInventarioLyfc
            // 
            this.dgvInventarioLyfc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventarioLyfc.Location = new System.Drawing.Point(19, 267);
            this.dgvInventarioLyfc.Name = "dgvInventarioLyfc";
            this.dgvInventarioLyfc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioLyfc.Size = new System.Drawing.Size(773, 195);
            this.dgvInventarioLyfc.TabIndex = 74;
            // 
            // tabDevoluciones
            // 
            this.tabDevoluciones.Controls.Add(this.btnCancelar);
            this.tabDevoluciones.Controls.Add(this.groupBox2);
            this.tabDevoluciones.Controls.Add(this.btnRegistrarDevolucion);
            this.tabDevoluciones.Controls.Add(this.dgvTraspasosLyfc);
            this.tabDevoluciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDevoluciones.Location = new System.Drawing.Point(4, 25);
            this.tabDevoluciones.Name = "tabDevoluciones";
            this.tabDevoluciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevoluciones.Size = new System.Drawing.Size(812, 465);
            this.tabDevoluciones.TabIndex = 2;
            this.tabDevoluciones.Text = "Devoluciones";
            this.tabDevoluciones.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(663, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 43);
            this.btnCancelar.TabIndex = 77;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbIdTraspasoDv);
            this.groupBox2.Controls.Add(this.cbDestinoDv);
            this.groupBox2.Controls.Add(this.lbIdTarimaDv);
            this.groupBox2.Controls.Add(this.dtpFechaDevolucion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtBusquedaDevoGi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtProductoDv);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtLoteDv);
            this.groupBox2.Controls.Add(this.txtCantidadDv);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 218);
            this.groupBox2.TabIndex = 76;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Devoluciones";
            // 
            // lbIdTraspasoDv
            // 
            this.lbIdTraspasoDv.AutoSize = true;
            this.lbIdTraspasoDv.Location = new System.Drawing.Point(5, 20);
            this.lbIdTraspasoDv.Name = "lbIdTraspasoDv";
            this.lbIdTraspasoDv.Size = new System.Drawing.Size(96, 17);
            this.lbIdTraspasoDv.TabIndex = 71;
            this.lbIdTraspasoDv.Text = "ID Traspaso";
            // 
            // cbDestinoDv
            // 
            this.cbDestinoDv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestinoDv.FormattingEnabled = true;
            this.cbDestinoDv.Location = new System.Drawing.Point(415, 169);
            this.cbDestinoDv.Name = "cbDestinoDv";
            this.cbDestinoDv.Size = new System.Drawing.Size(121, 24);
            this.cbDestinoDv.TabIndex = 69;
            // 
            // lbIdTarimaDv
            // 
            this.lbIdTarimaDv.AutoSize = true;
            this.lbIdTarimaDv.Location = new System.Drawing.Point(6, 54);
            this.lbIdTarimaDv.Name = "lbIdTarimaDv";
            this.lbIdTarimaDv.Size = new System.Drawing.Size(78, 17);
            this.lbIdTarimaDv.TabIndex = 62;
            this.lbIdTarimaDv.Text = "ID Tarima";
            // 
            // dtpFechaDevolucion
            // 
            this.dtpFechaDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDevolucion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDevolucion.Location = new System.Drawing.Point(415, 54);
            this.dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            this.dtpFechaDevolucion.Size = new System.Drawing.Size(121, 23);
            this.dtpFechaDevolucion.TabIndex = 68;
            this.dtpFechaDevolucion.Value = new System.DateTime(2024, 5, 20, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(311, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 67;
            this.label4.Text = "Deptto destino:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 66;
            this.label5.Text = "Fecha:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::GestionInventario.Properties.Resources.buscar_barcode;
            this.pictureBox3.Location = new System.Drawing.Point(116, 44);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 65;
            this.label7.Text = "Cantidad:";
            // 
            // txtBusquedaDevoGi
            // 
            this.txtBusquedaDevoGi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusquedaDevoGi.Location = new System.Drawing.Point(157, 54);
            this.txtBusquedaDevoGi.Name = "txtBusquedaDevoGi";
            this.txtBusquedaDevoGi.Size = new System.Drawing.Size(125, 23);
            this.txtBusquedaDevoGi.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 64;
            this.label8.Text = "Lote:";
            // 
            // txtProductoDv
            // 
            this.txtProductoDv.Location = new System.Drawing.Point(98, 109);
            this.txtProductoDv.Name = "txtProductoDv";
            this.txtProductoDv.Size = new System.Drawing.Size(184, 23);
            this.txtProductoDv.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 63;
            this.label9.Text = "Producto:";
            // 
            // txtLoteDv
            // 
            this.txtLoteDv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteDv.Location = new System.Drawing.Point(415, 109);
            this.txtLoteDv.Name = "txtLoteDv";
            this.txtLoteDv.Size = new System.Drawing.Size(121, 23);
            this.txtLoteDv.TabIndex = 58;
            // 
            // txtCantidadDv
            // 
            this.txtCantidadDv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadDv.Location = new System.Drawing.Point(120, 169);
            this.txtCantidadDv.Name = "txtCantidadDv";
            this.txtCantidadDv.Size = new System.Drawing.Size(162, 23);
            this.txtCantidadDv.TabIndex = 59;
            // 
            // btnRegistrarDevolucion
            // 
            this.btnRegistrarDevolucion.Location = new System.Drawing.Point(663, 51);
            this.btnRegistrarDevolucion.Name = "btnRegistrarDevolucion";
            this.btnRegistrarDevolucion.Size = new System.Drawing.Size(126, 43);
            this.btnRegistrarDevolucion.TabIndex = 1;
            this.btnRegistrarDevolucion.Text = "Aceptar";
            this.btnRegistrarDevolucion.UseVisualStyleBackColor = true;
            // 
            // dgvTraspasosLyfc
            // 
            this.dgvTraspasosLyfc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTraspasosLyfc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraspasosLyfc.Location = new System.Drawing.Point(6, 255);
            this.dgvTraspasosLyfc.Name = "dgvTraspasosLyfc";
            this.dgvTraspasosLyfc.Size = new System.Drawing.Size(800, 192);
            this.dgvTraspasosLyfc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(425, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Logistica";
            // 
            // frmLogistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Name = "frmLogistica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogistica";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogistica_FormClosed);
            this.Load += new System.EventHandler(this.frmLogistica_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabInventarioTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotalLogistica)).EndInit();
            this.tabTraspaso.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioLyfc)).EndInit();
            this.tabDevoluciones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraspasosLyfc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDepartamentoLyfc;
        private System.Windows.Forms.Label lbPerfilLyfc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNombreLyfc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInventarioTotal;
        private System.Windows.Forms.DataGridView dgvInventarioTotalLogistica;
        private System.Windows.Forms.TabPage tabTraspaso;
        private System.Windows.Forms.Button btnCancelarGi;
        private System.Windows.Forms.Button btnRegistrarTraspasoGi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMov;
        private System.Windows.Forms.ComboBox cbDestinoGi;
        private System.Windows.Forms.Label lbIdTarima;
        private System.Windows.Forms.DateTimePicker dtpFechaGi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dtFechaGi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodigoBarrasGi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductoGi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLoteGi;
        private System.Windows.Forms.TextBox txtCantidadGi;
        private System.Windows.Forms.DataGridView dgvInventarioLyfc;
        private System.Windows.Forms.TabPage tabDevoluciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbIdTraspasoDv;
        private System.Windows.Forms.ComboBox cbDestinoDv;
        private System.Windows.Forms.Label lbIdTarimaDv;
        private System.Windows.Forms.DateTimePicker dtpFechaDevolucion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBusquedaDevoGi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProductoDv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoteDv;
        private System.Windows.Forms.TextBox txtCantidadDv;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
        private System.Windows.Forms.DataGridView dgvTraspasosLyfc;
        private System.Windows.Forms.Label label1;
    }
}