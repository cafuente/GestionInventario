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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogistica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbCargarImagenLogistica = new System.Windows.Forms.PictureBox();
            this.lbDepartamentoLogistica = new System.Windows.Forms.Label();
            this.lbPerfilLogistica = new System.Windows.Forms.Label();
            this.pbLogoLo = new System.Windows.Forms.PictureBox();
            this.lbNombreLogistica = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabMezclado = new System.Windows.Forms.TabControl();
            this.tabInventarioTotal = new System.Windows.Forms.TabPage();
            this.dgvInventarioTotalLogistica = new System.Windows.Forms.DataGridView();
            this.tabTraspaso = new System.Windows.Forms.TabPage();
            this.btnCancelarLogisticaTraspaso = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMov = new System.Windows.Forms.Label();
            this.cbDestinoLogisticaTraspaso = new System.Windows.Forms.ComboBox();
            this.lbIdTarimaLogisticaTraspaso = new System.Windows.Forms.Label();
            this.dtpFechaLogisticaTraspaso = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtFechaGi = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCodigoBarrasLogisticaTraspaso = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductoLogisticaTraspaso = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLoteLogisticaTraspaso = new System.Windows.Forms.TextBox();
            this.txtCantidadLogisticaTraspaso = new System.Windows.Forms.TextBox();
            this.dgvInventarioLogistica = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenLogistica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoLo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabMezclado.SuspendLayout();
            this.tabInventarioTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotalLogistica)).BeginInit();
            this.tabTraspaso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioLogistica)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbCargarImagenLogistica);
            this.panel2.Controls.Add(this.lbDepartamentoLogistica);
            this.panel2.Controls.Add(this.lbPerfilLogistica);
            this.panel2.Controls.Add(this.pbLogoLo);
            this.panel2.Controls.Add(this.lbNombreLogistica);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 85);
            this.panel2.TabIndex = 20;
            // 
            // pbCargarImagenLogistica
            // 
            this.pbCargarImagenLogistica.Image = ((System.Drawing.Image)(resources.GetObject("pbCargarImagenLogistica.Image")));
            this.pbCargarImagenLogistica.Location = new System.Drawing.Point(53, 63);
            this.pbCargarImagenLogistica.Name = "pbCargarImagenLogistica";
            this.pbCargarImagenLogistica.Size = new System.Drawing.Size(20, 16);
            this.pbCargarImagenLogistica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargarImagenLogistica.TabIndex = 74;
            this.pbCargarImagenLogistica.TabStop = false;
            this.pbCargarImagenLogistica.Click += new System.EventHandler(this.pbCargarImagenLogistica_Click);
            // 
            // lbDepartamentoLogistica
            // 
            this.lbDepartamentoLogistica.AutoSize = true;
            this.lbDepartamentoLogistica.Location = new System.Drawing.Point(90, 34);
            this.lbDepartamentoLogistica.Name = "lbDepartamentoLogistica";
            this.lbDepartamentoLogistica.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoLogistica.TabIndex = 14;
            this.lbDepartamentoLogistica.Text = "Deptto";
            // 
            // lbPerfilLogistica
            // 
            this.lbPerfilLogistica.AutoSize = true;
            this.lbPerfilLogistica.Location = new System.Drawing.Point(90, 56);
            this.lbPerfilLogistica.Name = "lbPerfilLogistica";
            this.lbPerfilLogistica.Size = new System.Drawing.Size(29, 13);
            this.lbPerfilLogistica.TabIndex = 1;
            this.lbPerfilLogistica.Text = "perfil";
            // 
            // pbLogoLo
            // 
            this.pbLogoLo.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pbLogoLo.Location = new System.Drawing.Point(3, 3);
            this.pbLogoLo.Name = "pbLogoLo";
            this.pbLogoLo.Size = new System.Drawing.Size(75, 85);
            this.pbLogoLo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoLo.TabIndex = 13;
            this.pbLogoLo.TabStop = false;
            // 
            // lbNombreLogistica
            // 
            this.lbNombreLogistica.AutoSize = true;
            this.lbNombreLogistica.Location = new System.Drawing.Point(90, 12);
            this.lbNombreLogistica.Name = "lbNombreLogistica";
            this.lbNombreLogistica.Size = new System.Drawing.Size(44, 13);
            this.lbNombreLogistica.TabIndex = 0;
            this.lbNombreLogistica.Text = "Nombre";
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
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(721, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(101, 74);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 68;
            this.pictureBox3.TabStop = false;
            // 
            // tabMezclado
            // 
            this.tabMezclado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMezclado.Controls.Add(this.tabInventarioTotal);
            this.tabMezclado.Controls.Add(this.tabTraspaso);
            this.tabMezclado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMezclado.Location = new System.Drawing.Point(6, 136);
            this.tabMezclado.Name = "tabMezclado";
            this.tabMezclado.SelectedIndex = 0;
            this.tabMezclado.Size = new System.Drawing.Size(820, 494);
            this.tabMezclado.TabIndex = 69;
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
            this.dgvInventarioTotalLogistica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventarioTotalLogistica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventarioTotalLogistica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvInventarioTotalLogistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventarioTotalLogistica.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvInventarioTotalLogistica.Location = new System.Drawing.Point(20, 44);
            this.dgvInventarioTotalLogistica.Name = "dgvInventarioTotalLogistica";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventarioTotalLogistica.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvInventarioTotalLogistica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioTotalLogistica.Size = new System.Drawing.Size(773, 404);
            this.dgvInventarioTotalLogistica.TabIndex = 75;
            // 
            // tabTraspaso
            // 
            this.tabTraspaso.Controls.Add(this.btnCancelarLogisticaTraspaso);
            this.tabTraspaso.Controls.Add(this.groupBox1);
            this.tabTraspaso.Controls.Add(this.dgvInventarioLogistica);
            this.tabTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTraspaso.Location = new System.Drawing.Point(4, 25);
            this.tabTraspaso.Name = "tabTraspaso";
            this.tabTraspaso.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraspaso.Size = new System.Drawing.Size(812, 465);
            this.tabTraspaso.TabIndex = 1;
            this.tabTraspaso.Text = "Traspasos";
            this.tabTraspaso.UseVisualStyleBackColor = true;
            // 
            // btnCancelarLogisticaTraspaso
            // 
            this.btnCancelarLogisticaTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarLogisticaTraspaso.Location = new System.Drawing.Point(649, 59);
            this.btnCancelarLogisticaTraspaso.Name = "btnCancelarLogisticaTraspaso";
            this.btnCancelarLogisticaTraspaso.Size = new System.Drawing.Size(127, 35);
            this.btnCancelarLogisticaTraspaso.TabIndex = 78;
            this.btnCancelarLogisticaTraspaso.Text = "Cancelar";
            this.btnCancelarLogisticaTraspaso.UseVisualStyleBackColor = true;
            this.btnCancelarLogisticaTraspaso.Click += new System.EventHandler(this.btnCancelarLogisticaTraspaso_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMov);
            this.groupBox1.Controls.Add(this.cbDestinoLogisticaTraspaso);
            this.groupBox1.Controls.Add(this.lbIdTarimaLogisticaTraspaso);
            this.groupBox1.Controls.Add(this.dtpFechaLogisticaTraspaso);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtFechaGi);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasLogisticaTraspaso);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtProductoLogisticaTraspaso);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtLoteLogisticaTraspaso);
            this.groupBox1.Controls.Add(this.txtCantidadLogisticaTraspaso);
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
            // cbDestinoLogisticaTraspaso
            // 
            this.cbDestinoLogisticaTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestinoLogisticaTraspaso.FormattingEnabled = true;
            this.cbDestinoLogisticaTraspaso.Location = new System.Drawing.Point(415, 169);
            this.cbDestinoLogisticaTraspaso.Name = "cbDestinoLogisticaTraspaso";
            this.cbDestinoLogisticaTraspaso.Size = new System.Drawing.Size(121, 24);
            this.cbDestinoLogisticaTraspaso.TabIndex = 69;
            // 
            // lbIdTarimaLogisticaTraspaso
            // 
            this.lbIdTarimaLogisticaTraspaso.AutoSize = true;
            this.lbIdTarimaLogisticaTraspaso.Location = new System.Drawing.Point(6, 54);
            this.lbIdTarimaLogisticaTraspaso.Name = "lbIdTarimaLogisticaTraspaso";
            this.lbIdTarimaLogisticaTraspaso.Size = new System.Drawing.Size(78, 17);
            this.lbIdTarimaLogisticaTraspaso.TabIndex = 62;
            this.lbIdTarimaLogisticaTraspaso.Text = "ID Tarima";
            // 
            // dtpFechaLogisticaTraspaso
            // 
            this.dtpFechaLogisticaTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaLogisticaTraspaso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLogisticaTraspaso.Location = new System.Drawing.Point(415, 54);
            this.dtpFechaLogisticaTraspaso.Name = "dtpFechaLogisticaTraspaso";
            this.dtpFechaLogisticaTraspaso.Size = new System.Drawing.Size(121, 23);
            this.dtpFechaLogisticaTraspaso.TabIndex = 68;
            this.dtpFechaLogisticaTraspaso.Value = new System.DateTime(2024, 5, 20, 0, 0, 0, 0);
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
            // txtCodigoBarrasLogisticaTraspaso
            // 
            this.txtCodigoBarrasLogisticaTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoBarrasLogisticaTraspaso.Location = new System.Drawing.Point(157, 54);
            this.txtCodigoBarrasLogisticaTraspaso.Name = "txtCodigoBarrasLogisticaTraspaso";
            this.txtCodigoBarrasLogisticaTraspaso.Size = new System.Drawing.Size(125, 23);
            this.txtCodigoBarrasLogisticaTraspaso.TabIndex = 44;
            this.txtCodigoBarrasLogisticaTraspaso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasLogisticaTraspaso_KeyPress);
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
            // txtProductoLogisticaTraspaso
            // 
            this.txtProductoLogisticaTraspaso.Location = new System.Drawing.Point(98, 109);
            this.txtProductoLogisticaTraspaso.Name = "txtProductoLogisticaTraspaso";
            this.txtProductoLogisticaTraspaso.Size = new System.Drawing.Size(184, 23);
            this.txtProductoLogisticaTraspaso.TabIndex = 57;
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
            // txtLoteLogisticaTraspaso
            // 
            this.txtLoteLogisticaTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteLogisticaTraspaso.Location = new System.Drawing.Point(415, 109);
            this.txtLoteLogisticaTraspaso.Name = "txtLoteLogisticaTraspaso";
            this.txtLoteLogisticaTraspaso.Size = new System.Drawing.Size(121, 23);
            this.txtLoteLogisticaTraspaso.TabIndex = 58;
            // 
            // txtCantidadLogisticaTraspaso
            // 
            this.txtCantidadLogisticaTraspaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadLogisticaTraspaso.Location = new System.Drawing.Point(120, 169);
            this.txtCantidadLogisticaTraspaso.Name = "txtCantidadLogisticaTraspaso";
            this.txtCantidadLogisticaTraspaso.Size = new System.Drawing.Size(162, 23);
            this.txtCantidadLogisticaTraspaso.TabIndex = 59;
            // 
            // dgvInventarioLogistica
            // 
            this.dgvInventarioLogistica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventarioLogistica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventarioLogistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventarioLogistica.Location = new System.Drawing.Point(19, 267);
            this.dgvInventarioLogistica.Name = "dgvInventarioLogistica";
            this.dgvInventarioLogistica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventarioLogistica.Size = new System.Drawing.Size(773, 195);
            this.dgvInventarioLogistica.TabIndex = 74;
            this.dgvInventarioLogistica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventarioLogistica_CellClick);
            // 
            // FrmLogistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 626);
            this.Controls.Add(this.tabMezclado);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmLogistica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogistica";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogistica_FormClosed);
            this.Load += new System.EventHandler(this.frmLogistica_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenLogistica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoLo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabMezclado.ResumeLayout(false);
            this.tabInventarioTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotalLogistica)).EndInit();
            this.tabTraspaso.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioLogistica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDepartamentoLogistica;
        private System.Windows.Forms.Label lbPerfilLogistica;
        private System.Windows.Forms.PictureBox pbLogoLo;
        private System.Windows.Forms.Label lbNombreLogistica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pbCargarImagenLogistica;
        private System.Windows.Forms.TabControl tabMezclado;
        private System.Windows.Forms.TabPage tabInventarioTotal;
        private System.Windows.Forms.DataGridView dgvInventarioTotalLogistica;
        private System.Windows.Forms.TabPage tabTraspaso;
        private System.Windows.Forms.Button btnCancelarLogisticaTraspaso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMov;
        private System.Windows.Forms.ComboBox cbDestinoLogisticaTraspaso;
        private System.Windows.Forms.Label lbIdTarimaLogisticaTraspaso;
        private System.Windows.Forms.DateTimePicker dtpFechaLogisticaTraspaso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dtFechaGi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCodigoBarrasLogisticaTraspaso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductoLogisticaTraspaso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLoteLogisticaTraspaso;
        private System.Windows.Forms.TextBox txtCantidadLogisticaTraspaso;
        private System.Windows.Forms.DataGridView dgvInventarioLogistica;
    }
}