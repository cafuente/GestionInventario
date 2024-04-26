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
            this.lbPerfilGi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNombreGi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgRecepcionCarne = new System.Windows.Forms.DataGridView();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtTara = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.gbFactura = new System.Windows.Forms.GroupBox();
            this.pbCodigoBarras = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.Label();
            this.dpFecha = new System.Windows.Forms.DateTimePicker();
            this.dpEmpaque = new System.Windows.Forms.DateTimePicker();
            this.dpSacrificio = new System.Windows.Forms.DateTimePicker();
            this.IdRegistro = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCajas = new System.Windows.Forms.TextBox();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtOrdenCompra = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtFleje = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtProcedencia = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbRegistro = new System.Windows.Forms.GroupBox();
            this.btnActualizarGi = new System.Windows.Forms.Button();
            this.btnEliminarGi = new System.Windows.Forms.Button();
            this.lbDepartamentoGi = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecepcionCarne)).BeginInit();
            this.gbFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoBarras)).BeginInit();
            this.gbRegistro.SuspendLayout();
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
            this.panel2.Size = new System.Drawing.Size(290, 93);
            this.panel2.TabIndex = 1;
            // 
            // lbPerfilGi
            // 
            this.lbPerfilGi.AutoSize = true;
            this.lbPerfilGi.Location = new System.Drawing.Point(109, 56);
            this.lbPerfilGi.Name = "lbPerfilGi";
            this.lbPerfilGi.Size = new System.Drawing.Size(29, 13);
            this.lbPerfilGi.TabIndex = 1;
            this.lbPerfilGi.Text = "perfil";
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
            // lbNombreGi
            // 
            this.lbNombreGi.AutoSize = true;
            this.lbNombreGi.Location = new System.Drawing.Point(109, 12);
            this.lbNombreGi.Name = "lbNombreGi";
            this.lbNombreGi.Size = new System.Drawing.Size(44, 13);
            this.lbNombreGi.TabIndex = 0;
            this.lbNombreGi.Text = "Nombre";
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
            // dgRecepcionCarne
            // 
            this.dgRecepcionCarne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecepcionCarne.Location = new System.Drawing.Point(3, 461);
            this.dgRecepcionCarne.Name = "dgRecepcionCarne";
            this.dgRecepcionCarne.Size = new System.Drawing.Size(991, 242);
            this.dgRecepcionCarne.TabIndex = 15;
            this.dgRecepcionCarne.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRecepcionCarne_CellClick);
            // 
            // txtPeso
            // 
            this.txtPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeso.Location = new System.Drawing.Point(373, 33);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(121, 22);
            this.txtPeso.TabIndex = 16;
            // 
            // txtTara
            // 
            this.txtTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTara.Location = new System.Drawing.Point(111, 34);
            this.txtTara.Name = "txtTara";
            this.txtTara.Size = new System.Drawing.Size(113, 22);
            this.txtTara.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(294, 33);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 16);
            this.label19.TabIndex = 40;
            this.label19.Text = "Peso real:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(32, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 16);
            this.label18.TabIndex = 39;
            this.label18.Text = "Tara:";
            // 
            // gbFactura
            // 
            this.gbFactura.Controls.Add(this.pbCodigoBarras);
            this.gbFactura.Controls.Add(this.textBox1);
            this.gbFactura.Controls.Add(this.txtId);
            this.gbFactura.Controls.Add(this.dpFecha);
            this.gbFactura.Controls.Add(this.dpEmpaque);
            this.gbFactura.Controls.Add(this.dpSacrificio);
            this.gbFactura.Controls.Add(this.IdRegistro);
            this.gbFactura.Controls.Add(this.label16);
            this.gbFactura.Controls.Add(this.txtCajas);
            this.gbFactura.Controls.Add(this.txtLinea);
            this.gbFactura.Controls.Add(this.label2);
            this.gbFactura.Controls.Add(this.label3);
            this.gbFactura.Controls.Add(this.label5);
            this.gbFactura.Controls.Add(this.txtLote);
            this.gbFactura.Controls.Add(this.txtProducto);
            this.gbFactura.Controls.Add(this.txtOrdenCompra);
            this.gbFactura.Controls.Add(this.label14);
            this.gbFactura.Controls.Add(this.label7);
            this.gbFactura.Controls.Add(this.label12);
            this.gbFactura.Controls.Add(this.label10);
            this.gbFactura.Controls.Add(this.txtMarca);
            this.gbFactura.Controls.Add(this.txtFleje);
            this.gbFactura.Controls.Add(this.txtCantidad);
            this.gbFactura.Controls.Add(this.txtFactura);
            this.gbFactura.Controls.Add(this.txtProcedencia);
            this.gbFactura.Controls.Add(this.label13);
            this.gbFactura.Controls.Add(this.label4);
            this.gbFactura.Controls.Add(this.label11);
            this.gbFactura.Controls.Add(this.cbTurno);
            this.gbFactura.Controls.Add(this.label6);
            this.gbFactura.Controls.Add(this.label9);
            this.gbFactura.Controls.Add(this.label8);
            this.gbFactura.Controls.Add(this.label15);
            this.gbFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFactura.Location = new System.Drawing.Point(6, 105);
            this.gbFactura.Name = "gbFactura";
            this.gbFactura.Size = new System.Drawing.Size(988, 263);
            this.gbFactura.TabIndex = 41;
            this.gbFactura.TabStop = false;
            this.gbFactura.Text = "Datos Factura";
            // 
            // pbCodigoBarras
            // 
            this.pbCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCodigoBarras.Image = global::GestionInventario.Properties.Resources.barcode_scan;
            this.pbCodigoBarras.Location = new System.Drawing.Point(256, 27);
            this.pbCodigoBarras.Name = "pbCodigoBarras";
            this.pbCodigoBarras.Size = new System.Drawing.Size(58, 41);
            this.pbCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCodigoBarras.TabIndex = 41;
            this.pbCodigoBarras.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(340, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(602, 22);
            this.textBox1.TabIndex = 40;
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Location = new System.Drawing.Point(119, 45);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(11, 16);
            this.txtId.TabIndex = 39;
            this.txtId.Text = ":";
            // 
            // dpFecha
            // 
            this.dpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFecha.Location = new System.Drawing.Point(84, 221);
            this.dpFecha.Name = "dpFecha";
            this.dpFecha.Size = new System.Drawing.Size(121, 22);
            this.dpFecha.TabIndex = 14;
            this.dpFecha.Value = new System.DateTime(2024, 4, 26, 0, 0, 0, 0);
            // 
            // dpEmpaque
            // 
            this.dpEmpaque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpEmpaque.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEmpaque.Location = new System.Drawing.Point(842, 90);
            this.dpEmpaque.Name = "dpEmpaque";
            this.dpEmpaque.Size = new System.Drawing.Size(121, 22);
            this.dpEmpaque.TabIndex = 3;
            this.dpEmpaque.Value = new System.DateTime(2024, 4, 26, 10, 23, 24, 0);
            // 
            // dpSacrificio
            // 
            this.dpSacrificio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpSacrificio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpSacrificio.Location = new System.Drawing.Point(580, 87);
            this.dpSacrificio.Name = "dpSacrificio";
            this.dpSacrificio.Size = new System.Drawing.Size(121, 22);
            this.dpSacrificio.TabIndex = 2;
            this.dpSacrificio.Value = new System.DateTime(2024, 4, 26, 0, 0, 0, 0);
            // 
            // IdRegistro
            // 
            this.IdRegistro.AutoSize = true;
            this.IdRegistro.Location = new System.Drawing.Point(116, 45);
            this.IdRegistro.Name = "IdRegistro";
            this.IdRegistro.Size = new System.Drawing.Size(0, 16);
            this.IdRegistro.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 16);
            this.label16.TabIndex = 34;
            this.label16.Text = "Id:";
            // 
            // txtCajas
            // 
            this.txtCajas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCajas.Location = new System.Drawing.Point(84, 138);
            this.txtCajas.Name = "txtCajas";
            this.txtCajas.Size = new System.Drawing.Size(121, 22);
            this.txtCajas.TabIndex = 7;
            // 
            // txtLinea
            // 
            this.txtLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinea.Location = new System.Drawing.Point(84, 91);
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.Size = new System.Drawing.Size(121, 22);
            this.txtLinea.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Linea:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(498, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "F. Sacrificio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fleje:";
            // 
            // txtLote
            // 
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(842, 175);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(121, 22);
            this.txtLote.TabIndex = 12;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(340, 220);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(623, 21);
            this.txtProducto.TabIndex = 13;
            // 
            // txtOrdenCompra
            // 
            this.txtOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenCompra.Location = new System.Drawing.Point(340, 175);
            this.txtOrdenCompra.Name = "txtOrdenCompra";
            this.txtOrdenCompra.Size = new System.Drawing.Size(121, 22);
            this.txtOrdenCompra.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Fecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(749, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cantidad:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(749, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Lote:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(247, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Orden compra:";
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(580, 175);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(121, 22);
            this.txtMarca.TabIndex = 11;
            // 
            // txtFleje
            // 
            this.txtFleje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFleje.Location = new System.Drawing.Point(340, 138);
            this.txtFleje.Name = "txtFleje";
            this.txtFleje.Size = new System.Drawing.Size(121, 22);
            this.txtFleje.TabIndex = 4;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(842, 139);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 22);
            this.txtCantidad.TabIndex = 8;
            // 
            // txtFactura
            // 
            this.txtFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.Location = new System.Drawing.Point(84, 175);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(121, 22);
            this.txtFactura.TabIndex = 9;
            // 
            // txtProcedencia
            // 
            this.txtProcedencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedencia.Location = new System.Drawing.Point(340, 92);
            this.txtProcedencia.Name = "txtProcedencia";
            this.txtProcedencia.Size = new System.Drawing.Size(121, 22);
            this.txtProcedencia.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(247, 223);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Procedencia:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(498, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Marca:";
            // 
            // cbTurno
            // 
            this.cbTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(580, 139);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(121, 24);
            this.cbTurno.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(749, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "F.Empaque:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Factura:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(498, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sup. Turno:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 16);
            this.label15.TabIndex = 9;
            this.label15.Text = "Cajas:";
            // 
            // gbRegistro
            // 
            this.gbRegistro.Controls.Add(this.txtPeso);
            this.gbRegistro.Controls.Add(this.txtTara);
            this.gbRegistro.Controls.Add(this.label19);
            this.gbRegistro.Controls.Add(this.label18);
            this.gbRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRegistro.Location = new System.Drawing.Point(6, 374);
            this.gbRegistro.Name = "gbRegistro";
            this.gbRegistro.Size = new System.Drawing.Size(527, 81);
            this.gbRegistro.TabIndex = 42;
            this.gbRegistro.TabStop = false;
            this.gbRegistro.Text = "Registro de tarima o combo";
            // 
            // btnActualizarGi
            // 
            this.btnActualizarGi.Location = new System.Drawing.Point(584, 402);
            this.btnActualizarGi.Name = "btnActualizarGi";
            this.btnActualizarGi.Size = new System.Drawing.Size(149, 36);
            this.btnActualizarGi.TabIndex = 43;
            this.btnActualizarGi.Text = "Actualizar";
            this.btnActualizarGi.UseVisualStyleBackColor = true;
            // 
            // btnEliminarGi
            // 
            this.btnEliminarGi.Location = new System.Drawing.Point(799, 403);
            this.btnEliminarGi.Name = "btnEliminarGi";
            this.btnEliminarGi.Size = new System.Drawing.Size(149, 36);
            this.btnEliminarGi.TabIndex = 44;
            this.btnEliminarGi.Text = "Eliminar";
            this.btnEliminarGi.UseVisualStyleBackColor = true;
            // 
            // lbDepartamentoGi
            // 
            this.lbDepartamentoGi.AutoSize = true;
            this.lbDepartamentoGi.Location = new System.Drawing.Point(109, 34);
            this.lbDepartamentoGi.Name = "lbDepartamentoGi";
            this.lbDepartamentoGi.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoGi.TabIndex = 14;
            this.lbDepartamentoGi.Text = "Deptto";
            // 
            // frmGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 711);
            this.Controls.Add(this.btnEliminarGi);
            this.Controls.Add(this.btnActualizarGi);
            this.Controls.Add(this.gbRegistro);
            this.Controls.Add(this.gbFactura);
            this.Controls.Add(this.dgRecepcionCarne);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "frmGestionInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGestionInventario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionInventario_FormClosed);
            this.Load += new System.EventHandler(this.frmGestionInventario_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecepcionCarne)).EndInit();
            this.gbFactura.ResumeLayout(false);
            this.gbFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoBarras)).EndInit();
            this.gbRegistro.ResumeLayout(false);
            this.gbRegistro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPerfilGi;
        private System.Windows.Forms.Label lbNombreGi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgRecepcionCarne;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtTara;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbFactura;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.DateTimePicker dpFecha;
        private System.Windows.Forms.DateTimePicker dpEmpaque;
        private System.Windows.Forms.DateTimePicker dpSacrificio;
        private System.Windows.Forms.Label IdRegistro;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCajas;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtOrdenCompra;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtFleje;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtProcedencia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbRegistro;
        private System.Windows.Forms.Button btnActualizarGi;
        private System.Windows.Forms.Button btnEliminarGi;
        private System.Windows.Forms.PictureBox pbCodigoBarras;
        private System.Windows.Forms.Label lbDepartamentoGi;
    }
}