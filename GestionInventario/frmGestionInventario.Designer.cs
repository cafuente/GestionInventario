﻿namespace GestionInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoGi = new System.Windows.Forms.Label();
            this.lbPerfilGi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNombreGi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInventarioTotal = new System.Windows.Forms.TabPage();
            this.dgvInventarioTotal = new System.Windows.Forms.DataGridView();
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
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.tabDevoluciones = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDestinoDv = new System.Windows.Forms.ComboBox();
            this.lbIdTarimaDv = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProductoDv = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoteDv = new System.Windows.Forms.TextBox();
            this.txtCantidadDv = new System.Windows.Forms.TextBox();
            this.btnRegistrarDevolucion = new System.Windows.Forms.Button();
            this.dgvTraspasos = new System.Windows.Forms.DataGridView();
            this.tabDetenidos = new System.Windows.Forms.TabPage();
            this.lbIdTraspasoDv = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInventarioTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotal)).BeginInit();
            this.tabTraspaso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.tabDevoluciones.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraspasos)).BeginInit();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInventarioTotal);
            this.tabControl1.Controls.Add(this.tabTraspaso);
            this.tabControl1.Controls.Add(this.tabDevoluciones);
            this.tabControl1.Controls.Add(this.tabDetenidos);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 129);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(820, 494);
            this.tabControl1.TabIndex = 15;
            // 
            // tabInventarioTotal
            // 
            this.tabInventarioTotal.Controls.Add(this.dgvInventarioTotal);
            this.tabInventarioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInventarioTotal.Location = new System.Drawing.Point(4, 25);
            this.tabInventarioTotal.Name = "tabInventarioTotal";
            this.tabInventarioTotal.Padding = new System.Windows.Forms.Padding(3);
            this.tabInventarioTotal.Size = new System.Drawing.Size(812, 465);
            this.tabInventarioTotal.TabIndex = 0;
            this.tabInventarioTotal.Text = "Inventario Total";
            this.tabInventarioTotal.UseVisualStyleBackColor = true;
            // 
            // dgvInventarioTotal
            // 
            this.dgvInventarioTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventarioTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInventarioTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventarioTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInventarioTotal.Location = new System.Drawing.Point(20, 44);
            this.dgvInventarioTotal.Name = "dgvInventarioTotal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventarioTotal.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvInventarioTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioTotal.Size = new System.Drawing.Size(773, 404);
            this.dgvInventarioTotal.TabIndex = 75;
            // 
            // tabTraspaso
            // 
            this.tabTraspaso.Controls.Add(this.btnCancelarGi);
            this.tabTraspaso.Controls.Add(this.btnRegistrarTraspasoGi);
            this.tabTraspaso.Controls.Add(this.groupBox1);
            this.tabTraspaso.Controls.Add(this.dgvInventario);
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
            this.btnCancelarGi.Click += new System.EventHandler(this.btnCancelarGi_Click);
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
            this.btnRegistrarTraspasoGi.Click += new System.EventHandler(this.btnRegistrarTraspasoGi_Click);
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
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(19, 267);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(773, 195);
            this.dgvInventario.TabIndex = 74;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            // 
            // tabDevoluciones
            // 
            this.tabDevoluciones.Controls.Add(this.groupBox2);
            this.tabDevoluciones.Controls.Add(this.btnRegistrarDevolucion);
            this.tabDevoluciones.Controls.Add(this.dgvTraspasos);
            this.tabDevoluciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDevoluciones.Location = new System.Drawing.Point(4, 25);
            this.tabDevoluciones.Name = "tabDevoluciones";
            this.tabDevoluciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevoluciones.Size = new System.Drawing.Size(812, 465);
            this.tabDevoluciones.TabIndex = 2;
            this.tabDevoluciones.Text = "Devoluciones";
            this.tabDevoluciones.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbIdTraspasoDv);
            this.groupBox2.Controls.Add(this.cbDestinoDv);
            this.groupBox2.Controls.Add(this.lbIdTarimaDv);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox1);
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
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(415, 54);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 23);
            this.dateTimePicker1.TabIndex = 68;
            this.dateTimePicker1.Value = new System.DateTime(2024, 5, 20, 0, 0, 0, 0);
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(157, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 23);
            this.textBox1.TabIndex = 44;
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
            this.btnRegistrarDevolucion.Click += new System.EventHandler(this.btnRegistrarDevolucion_Click);
            // 
            // dgvTraspasos
            // 
            this.dgvTraspasos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTraspasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraspasos.Location = new System.Drawing.Point(6, 255);
            this.dgvTraspasos.Name = "dgvTraspasos";
            this.dgvTraspasos.Size = new System.Drawing.Size(800, 192);
            this.dgvTraspasos.TabIndex = 0;
            this.dgvTraspasos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTraspasos_CellClick);
            // 
            // tabDetenidos
            // 
            this.tabDetenidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetenidos.Location = new System.Drawing.Point(4, 25);
            this.tabDetenidos.Name = "tabDetenidos";
            this.tabDetenidos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetenidos.Size = new System.Drawing.Size(812, 465);
            this.tabDetenidos.TabIndex = 3;
            this.tabDetenidos.Text = "Detenidos";
            this.tabDetenidos.UseVisualStyleBackColor = true;
            // 
            // lbIdTraspasoDv
            // 
            this.lbIdTraspasoDv.AutoSize = true;
            this.lbIdTraspasoDv.Location = new System.Drawing.Point(9, 19);
            this.lbIdTraspasoDv.Name = "lbIdTraspasoDv";
            this.lbIdTraspasoDv.Size = new System.Drawing.Size(96, 17);
            this.lbIdTraspasoDv.TabIndex = 71;
            this.lbIdTraspasoDv.Text = "ID Traspaso";
            // 
            // frmGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 626);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabInventarioTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotal)).EndInit();
            this.tabTraspaso.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.tabDevoluciones.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraspasos)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInventarioTotal;
        private System.Windows.Forms.TabPage tabTraspaso;
        private System.Windows.Forms.Button btnCancelarGi;
        private System.Windows.Forms.Button btnRegistrarTraspasoGi;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.TabPage tabDevoluciones;
        private System.Windows.Forms.TabPage tabDetenidos;
        private System.Windows.Forms.DataGridView dgvInventarioTotal;
        private System.Windows.Forms.Label lbMov;
        private System.Windows.Forms.Button btnRegistrarDevolucion;
        private System.Windows.Forms.DataGridView dgvTraspasos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbDestinoDv;
        private System.Windows.Forms.Label lbIdTarimaDv;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProductoDv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoteDv;
        private System.Windows.Forms.TextBox txtCantidadDv;
        private System.Windows.Forms.Label lbIdTraspasoDv;
    }
}