namespace GestionInventario
{
    partial class frmRecepcionCarne
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
            System.Windows.Forms.DateTimePicker dpSacrificio;
            System.Windows.Forms.DateTimePicker dpFecha;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionCarne));
            this.dpEmpaque = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.txtProcedencia = new System.Windows.Forms.TextBox();
            this.txtFleje = new System.Windows.Forms.TextBox();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cbContenedor = new System.Windows.Forms.ComboBox();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtOrdenCompra = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gbRomaneo = new System.Windows.Forms.GroupBox();
            this.btnAgregarCarne = new System.Windows.Forms.Button();
            this.pbCodigoBarras = new System.Windows.Forms.PictureBox();
            this.btnGenerarCodigoBarras = new System.Windows.Forms.Button();
            this.btnModificarDatosCarne = new System.Windows.Forms.Button();
            this.pbImpresionCb = new System.Windows.Forms.PictureBox();
            this.pbGuardarCb = new System.Windows.Forms.PictureBox();
            dpSacrificio = new System.Windows.Forms.DateTimePicker();
            dpFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbRomaneo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresionCb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardarCb)).BeginInit();
            this.SuspendLayout();
            // 
            // dpSacrificio
            // 
            dpSacrificio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dpSacrificio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dpSacrificio.Location = new System.Drawing.Point(117, 94);
            dpSacrificio.Name = "dpSacrificio";
            dpSacrificio.Size = new System.Drawing.Size(112, 23);
            dpSacrificio.TabIndex = 30;
            dpSacrificio.Value = new System.DateTime(2024, 4, 19, 6, 29, 5, 0);
            // 
            // dpEmpaque
            // 
            this.dpEmpaque.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpEmpaque.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpEmpaque.Location = new System.Drawing.Point(367, 94);
            this.dpEmpaque.Name = "dpEmpaque";
            this.dpEmpaque.Size = new System.Drawing.Size(121, 23);
            this.dpEmpaque.TabIndex = 31;
            this.dpEmpaque.Value = new System.DateTime(2024, 4, 19, 6, 29, 5, 0);
            // 
            // dpFecha
            // 
            dpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dpFecha.Location = new System.Drawing.Point(367, 311);
            dpFecha.Name = "dpFecha";
            dpFecha.Size = new System.Drawing.Size(121, 23);
            dpFecha.TabIndex = 32;
            dpFecha.Value = new System.DateTime(2024, 4, 19, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linea:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Procedencia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "F. Sacrificio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "F.Empaque:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fleje:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sup. Turno:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cantidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(269, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Contenedor:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Factura:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(269, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "Orden compra:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(29, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Marca:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(269, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Lote:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 314);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 14;
            this.label13.Text = "Producto:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(269, 314);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Fecha:";
            // 
            // txtLinea
            // 
            this.txtLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinea.Location = new System.Drawing.Point(116, 53);
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.Size = new System.Drawing.Size(113, 22);
            this.txtLinea.TabIndex = 16;
            // 
            // txtProcedencia
            // 
            this.txtProcedencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedencia.Location = new System.Drawing.Point(367, 53);
            this.txtProcedencia.Name = "txtProcedencia";
            this.txtProcedencia.Size = new System.Drawing.Size(121, 22);
            this.txtProcedencia.TabIndex = 17;
            // 
            // txtFleje
            // 
            this.txtFleje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFleje.Location = new System.Drawing.Point(116, 139);
            this.txtFleje.Name = "txtFleje";
            this.txtFleje.Size = new System.Drawing.Size(113, 22);
            this.txtFleje.TabIndex = 20;
            // 
            // cbTurno
            // 
            this.cbTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Location = new System.Drawing.Point(367, 139);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(121, 24);
            this.cbTurno.TabIndex = 21;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(116, 182);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(113, 22);
            this.txtCantidad.TabIndex = 22;
            // 
            // cbContenedor
            // 
            this.cbContenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContenedor.FormattingEnabled = true;
            this.cbContenedor.Location = new System.Drawing.Point(367, 182);
            this.cbContenedor.Name = "cbContenedor";
            this.cbContenedor.Size = new System.Drawing.Size(121, 24);
            this.cbContenedor.TabIndex = 23;
            // 
            // txtFactura
            // 
            this.txtFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.Location = new System.Drawing.Point(116, 225);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(113, 22);
            this.txtFactura.TabIndex = 24;
            // 
            // txtOrdenCompra
            // 
            this.txtOrdenCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdenCompra.Location = new System.Drawing.Point(367, 225);
            this.txtOrdenCompra.Name = "txtOrdenCompra";
            this.txtOrdenCompra.Size = new System.Drawing.Size(121, 22);
            this.txtOrdenCompra.TabIndex = 25;
            // 
            // txtMarca
            // 
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarca.Location = new System.Drawing.Point(116, 268);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(113, 22);
            this.txtMarca.TabIndex = 26;
            // 
            // txtLote
            // 
            this.txtLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(367, 268);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(121, 22);
            this.txtLote.TabIndex = 27;
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(116, 311);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(113, 22);
            this.txtProducto.TabIndex = 28;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(3, 6);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(97, 72);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 30;
            this.pbLogo.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(299, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(215, 30);
            this.label15.TabIndex = 31;
            this.label15.Text = "Registro cárnico";
            // 
            // gbRomaneo
            // 
            this.gbRomaneo.Controls.Add(dpFecha);
            this.gbRomaneo.Controls.Add(this.dpEmpaque);
            this.gbRomaneo.Controls.Add(dpSacrificio);
            this.gbRomaneo.Controls.Add(this.txtLinea);
            this.gbRomaneo.Controls.Add(this.label1);
            this.gbRomaneo.Controls.Add(this.label3);
            this.gbRomaneo.Controls.Add(this.label5);
            this.gbRomaneo.Controls.Add(this.txtLote);
            this.gbRomaneo.Controls.Add(this.txtProducto);
            this.gbRomaneo.Controls.Add(this.txtOrdenCompra);
            this.gbRomaneo.Controls.Add(this.label14);
            this.gbRomaneo.Controls.Add(this.label7);
            this.gbRomaneo.Controls.Add(this.label12);
            this.gbRomaneo.Controls.Add(this.label10);
            this.gbRomaneo.Controls.Add(this.txtMarca);
            this.gbRomaneo.Controls.Add(this.txtFleje);
            this.gbRomaneo.Controls.Add(this.txtCantidad);
            this.gbRomaneo.Controls.Add(this.txtFactura);
            this.gbRomaneo.Controls.Add(this.txtProcedencia);
            this.gbRomaneo.Controls.Add(this.label13);
            this.gbRomaneo.Controls.Add(this.cbContenedor);
            this.gbRomaneo.Controls.Add(this.label2);
            this.gbRomaneo.Controls.Add(this.label11);
            this.gbRomaneo.Controls.Add(this.cbTurno);
            this.gbRomaneo.Controls.Add(this.label4);
            this.gbRomaneo.Controls.Add(this.label9);
            this.gbRomaneo.Controls.Add(this.label6);
            this.gbRomaneo.Controls.Add(this.label8);
            this.gbRomaneo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRomaneo.Location = new System.Drawing.Point(12, 97);
            this.gbRomaneo.Name = "gbRomaneo";
            this.gbRomaneo.Size = new System.Drawing.Size(523, 354);
            this.gbRomaneo.TabIndex = 32;
            this.gbRomaneo.TabStop = false;
            this.gbRomaneo.Text = "Registro de Tarimas y combos";
            // 
            // btnAgregarCarne
            // 
            this.btnAgregarCarne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCarne.Location = new System.Drawing.Point(89, 467);
            this.btnAgregarCarne.Name = "btnAgregarCarne";
            this.btnAgregarCarne.Size = new System.Drawing.Size(394, 34);
            this.btnAgregarCarne.TabIndex = 33;
            this.btnAgregarCarne.Text = "Agregar";
            this.btnAgregarCarne.UseVisualStyleBackColor = true;
            this.btnAgregarCarne.Click += new System.EventHandler(this.btnAgregarCarne_Click);
            // 
            // pbCodigoBarras
            // 
            this.pbCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCodigoBarras.Image = ((System.Drawing.Image)(resources.GetObject("pbCodigoBarras.Image")));
            this.pbCodigoBarras.Location = new System.Drawing.Point(551, 106);
            this.pbCodigoBarras.Name = "pbCodigoBarras";
            this.pbCodigoBarras.Size = new System.Drawing.Size(228, 154);
            this.pbCodigoBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCodigoBarras.TabIndex = 34;
            this.pbCodigoBarras.TabStop = false;
            // 
            // btnGenerarCodigoBarras
            // 
            this.btnGenerarCodigoBarras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarCodigoBarras.Location = new System.Drawing.Point(551, 359);
            this.btnGenerarCodigoBarras.Name = "btnGenerarCodigoBarras";
            this.btnGenerarCodigoBarras.Size = new System.Drawing.Size(228, 34);
            this.btnGenerarCodigoBarras.TabIndex = 35;
            this.btnGenerarCodigoBarras.Text = "Generar codigo de barras";
            this.btnGenerarCodigoBarras.UseVisualStyleBackColor = true;
            this.btnGenerarCodigoBarras.Click += new System.EventHandler(this.btnGenerarCodigoBarras_Click);
            // 
            // btnModificarDatosCarne
            // 
            this.btnModificarDatosCarne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDatosCarne.Location = new System.Drawing.Point(551, 411);
            this.btnModificarDatosCarne.Name = "btnModificarDatosCarne";
            this.btnModificarDatosCarne.Size = new System.Drawing.Size(228, 34);
            this.btnModificarDatosCarne.TabIndex = 36;
            this.btnModificarDatosCarne.Text = "Modificar Datos";
            this.btnModificarDatosCarne.UseVisualStyleBackColor = true;
            this.btnModificarDatosCarne.Click += new System.EventHandler(this.btnModificarDatosCarne_Click);
            // 
            // pbImpresionCb
            // 
            this.pbImpresionCb.Image = ((System.Drawing.Image)(resources.GetObject("pbImpresionCb.Image")));
            this.pbImpresionCb.Location = new System.Drawing.Point(592, 283);
            this.pbImpresionCb.Name = "pbImpresionCb";
            this.pbImpresionCb.Size = new System.Drawing.Size(50, 46);
            this.pbImpresionCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImpresionCb.TabIndex = 37;
            this.pbImpresionCb.TabStop = false;
            this.pbImpresionCb.Click += new System.EventHandler(this.pbImpresionCb_Click);
            // 
            // pbGuardarCb
            // 
            this.pbGuardarCb.Image = ((System.Drawing.Image)(resources.GetObject("pbGuardarCb.Image")));
            this.pbGuardarCb.Location = new System.Drawing.Point(686, 283);
            this.pbGuardarCb.Name = "pbGuardarCb";
            this.pbGuardarCb.Size = new System.Drawing.Size(50, 47);
            this.pbGuardarCb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGuardarCb.TabIndex = 38;
            this.pbGuardarCb.TabStop = false;
            this.pbGuardarCb.Click += new System.EventHandler(this.pbGuardarCb_Click);
            // 
            // frmRecepcionCarne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 513);
            this.Controls.Add(this.pbGuardarCb);
            this.Controls.Add(this.pbImpresionCb);
            this.Controls.Add(this.btnModificarDatosCarne);
            this.Controls.Add(this.btnGenerarCodigoBarras);
            this.Controls.Add(this.pbCodigoBarras);
            this.Controls.Add(this.btnAgregarCarne);
            this.Controls.Add(this.gbRomaneo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pbLogo);
            this.Name = "frmRecepcionCarne";
            this.Text = "Recepcion de Carne";
            this.Load += new System.EventHandler(this.frmRecepcionCarne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbRomaneo.ResumeLayout(false);
            this.gbRomaneo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCodigoBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresionCb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardarCb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.TextBox txtProcedencia;
        private System.Windows.Forms.TextBox txtFleje;
        private System.Windows.Forms.ComboBox cbTurno;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cbContenedor;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtOrdenCompra;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbRomaneo;
        private System.Windows.Forms.Button btnAgregarCarne;
        private System.Windows.Forms.PictureBox pbCodigoBarras;
        private System.Windows.Forms.Button btnGenerarCodigoBarras;
        private System.Windows.Forms.Button btnModificarDatosCarne;
        private System.Windows.Forms.PictureBox pbImpresionCb;
        private System.Windows.Forms.PictureBox pbGuardarCb;
        private System.Windows.Forms.DateTimePicker dpEmpaque;
    }
}