namespace GestionInventario
{
    partial class FrmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCargarImagenRep = new System.Windows.Forms.PictureBox();
            this.lbDepartamentoRep = new System.Windows.Forms.Label();
            this.lbPerfilRep = new System.Windows.Forms.Label();
            this.lbNombreRep = new System.Windows.Forms.Label();
            this.pbLogoRep = new System.Windows.Forms.PictureBox();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chartTendencia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartConsumo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.cbDepartamentosTen = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVarios = new System.Windows.Forms.TabPage();
            this.lbUmbral = new System.Windows.Forms.Label();
            this.txtUmbral = new System.Windows.Forms.TextBox();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbImprimirReporte = new System.Windows.Forms.PictureBox();
            this.pbGuardarReporte = new System.Windows.Forms.PictureBox();
            this.cbDepartamentosRep = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerarReporteRep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbReportes = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicioRep = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaFinRep = new System.Windows.Forms.DateTimePicker();
            this.tabTendencia = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImprimirTendencia = new System.Windows.Forms.PictureBox();
            this.btnExportarTendencia = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTendencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConsumo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabVarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImprimirReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardarReporte)).BeginInit();
            this.tabTendencia.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimirTendencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarTendencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbCargarImagenRep);
            this.panel1.Controls.Add(this.lbDepartamentoRep);
            this.panel1.Controls.Add(this.lbPerfilRep);
            this.panel1.Controls.Add(this.lbNombreRep);
            this.panel1.Controls.Add(this.pbLogoRep);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 85);
            this.panel1.TabIndex = 44;
            // 
            // pbCargarImagenRep
            // 
            this.pbCargarImagenRep.Image = ((System.Drawing.Image)(resources.GetObject("pbCargarImagenRep.Image")));
            this.pbCargarImagenRep.Location = new System.Drawing.Point(53, 63);
            this.pbCargarImagenRep.Name = "pbCargarImagenRep";
            this.pbCargarImagenRep.Size = new System.Drawing.Size(20, 16);
            this.pbCargarImagenRep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCargarImagenRep.TabIndex = 73;
            this.pbCargarImagenRep.TabStop = false;
            this.pbCargarImagenRep.Click += new System.EventHandler(this.pbCargarImagenRep_Click);
            // 
            // lbDepartamentoRep
            // 
            this.lbDepartamentoRep.AutoSize = true;
            this.lbDepartamentoRep.Location = new System.Drawing.Point(87, 35);
            this.lbDepartamentoRep.Name = "lbDepartamentoRep";
            this.lbDepartamentoRep.Size = new System.Drawing.Size(74, 13);
            this.lbDepartamentoRep.TabIndex = 33;
            this.lbDepartamentoRep.Text = "Departamento";
            // 
            // lbPerfilRep
            // 
            this.lbPerfilRep.AutoSize = true;
            this.lbPerfilRep.Location = new System.Drawing.Point(87, 57);
            this.lbPerfilRep.Name = "lbPerfilRep";
            this.lbPerfilRep.Size = new System.Drawing.Size(30, 13);
            this.lbPerfilRep.TabIndex = 32;
            this.lbPerfilRep.Text = "Perfil";
            // 
            // lbNombreRep
            // 
            this.lbNombreRep.AutoSize = true;
            this.lbNombreRep.Location = new System.Drawing.Point(87, 13);
            this.lbNombreRep.Name = "lbNombreRep";
            this.lbNombreRep.Size = new System.Drawing.Size(44, 13);
            this.lbNombreRep.TabIndex = 31;
            this.lbNombreRep.Text = "Nombre";
            // 
            // pbLogoRep
            // 
            this.pbLogoRep.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pbLogoRep.Location = new System.Drawing.Point(3, 3);
            this.pbLogoRep.Name = "pbLogoRep";
            this.pbLogoRep.Size = new System.Drawing.Size(75, 85);
            this.pbLogoRep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogoRep.TabIndex = 30;
            this.pbLogoRep.TabStop = false;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.Location = new System.Drawing.Point(830, 36);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(169, 50);
            this.btnGenerarReporte.TabIndex = 45;
            this.btnGenerarReporte.Text = "Generar reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 53;
            this.label3.Text = "F. inicial:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(504, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Departamento:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(280, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "F. Final:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(567, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 25);
            this.label7.TabIndex = 58;
            this.label7.Text = "Reportes y Tendencia";
            // 
            // chartTendencia
            // 
            this.chartTendencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            chartArea1.Name = "ChartArea1";
            this.chartTendencia.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTendencia.Legends.Add(legend1);
            this.chartTendencia.Location = new System.Drawing.Point(9, 172);
            this.chartTendencia.Name = "chartTendencia";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTendencia.Series.Add(series1);
            this.chartTendencia.Size = new System.Drawing.Size(566, 387);
            this.chartTendencia.TabIndex = 59;
            this.chartTendencia.Text = "chart1";
            // 
            // chartConsumo
            // 
            this.chartConsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            chartArea2.Name = "ChartArea1";
            this.chartConsumo.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartConsumo.Legends.Add(legend2);
            this.chartConsumo.Location = new System.Drawing.Point(653, 172);
            this.chartConsumo.Name = "chartConsumo";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartConsumo.Series.Add(series2);
            this.chartConsumo.Size = new System.Drawing.Size(526, 387);
            this.chartConsumo.TabIndex = 61;
            this.chartConsumo.Text = "chart1";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(141, 52);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(104, 23);
            this.dtpFechaInicio.TabIndex = 63;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(343, 54);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(116, 23);
            this.dtpFechaFin.TabIndex = 64;
            // 
            // cbDepartamentosTen
            // 
            this.cbDepartamentosTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDepartamentosTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamentosTen.FormattingEnabled = true;
            this.cbDepartamentosTen.Location = new System.Drawing.Point(614, 51);
            this.cbDepartamentosTen.Name = "cbDepartamentosTen";
            this.cbDepartamentosTen.Size = new System.Drawing.Size(168, 24);
            this.cbDepartamentosTen.TabIndex = 65;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabVarios);
            this.tabControl1.Controls.Add(this.tabTendencia);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(14, 136);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1215, 601);
            this.tabControl1.TabIndex = 66;
            // 
            // tabVarios
            // 
            this.tabVarios.Controls.Add(this.lbUmbral);
            this.tabVarios.Controls.Add(this.txtUmbral);
            this.tabVarios.Controls.Add(this.dgvReporte);
            this.tabVarios.Controls.Add(this.groupBox2);
            this.tabVarios.Location = new System.Drawing.Point(4, 34);
            this.tabVarios.Name = "tabVarios";
            this.tabVarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabVarios.Size = new System.Drawing.Size(1207, 563);
            this.tabVarios.TabIndex = 1;
            this.tabVarios.Text = "Varios reportes";
            this.tabVarios.UseVisualStyleBackColor = true;
            // 
            // lbUmbral
            // 
            this.lbUmbral.AutoSize = true;
            this.lbUmbral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUmbral.Location = new System.Drawing.Point(300, 162);
            this.lbUmbral.Name = "lbUmbral";
            this.lbUmbral.Size = new System.Drawing.Size(57, 17);
            this.lbUmbral.TabIndex = 70;
            this.lbUmbral.Text = "Umbral:";
            // 
            // txtUmbral
            // 
            this.txtUmbral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUmbral.Location = new System.Drawing.Point(407, 159);
            this.txtUmbral.Name = "txtUmbral";
            this.txtUmbral.Size = new System.Drawing.Size(100, 23);
            this.txtUmbral.TabIndex = 69;
            this.txtUmbral.Text = "1000";
            // 
            // dgvReporte
            // 
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(23, 191);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(1160, 353);
            this.dgvReporte.TabIndex = 68;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pbImprimirReporte);
            this.groupBox2.Controls.Add(this.pbGuardarReporte);
            this.groupBox2.Controls.Add(this.cbDepartamentosRep);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnGenerarReporteRep);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbReportes);
            this.groupBox2.Controls.Add(this.dtpFechaInicioRep);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpFechaFinRep);
            this.groupBox2.Location = new System.Drawing.Point(23, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1160, 118);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos";
            // 
            // pbImprimirReporte
            // 
            this.pbImprimirReporte.Image = global::GestionInventario.Properties.Resources.printer;
            this.pbImprimirReporte.Location = new System.Drawing.Point(996, 47);
            this.pbImprimirReporte.Name = "pbImprimirReporte";
            this.pbImprimirReporte.Size = new System.Drawing.Size(56, 50);
            this.pbImprimirReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImprimirReporte.TabIndex = 69;
            this.pbImprimirReporte.TabStop = false;
            this.pbImprimirReporte.Click += new System.EventHandler(this.pbImprimirReporte_Click);
            // 
            // pbGuardarReporte
            // 
            this.pbGuardarReporte.Image = global::GestionInventario.Properties.Resources.save;
            this.pbGuardarReporte.Location = new System.Drawing.Point(925, 47);
            this.pbGuardarReporte.Name = "pbGuardarReporte";
            this.pbGuardarReporte.Size = new System.Drawing.Size(56, 50);
            this.pbGuardarReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGuardarReporte.TabIndex = 68;
            this.pbGuardarReporte.TabStop = false;
            this.pbGuardarReporte.Click += new System.EventHandler(this.pbGuardarReporte_Click);
            // 
            // cbDepartamentosRep
            // 
            this.cbDepartamentosRep.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDepartamentosRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamentosRep.FormattingEnabled = true;
            this.cbDepartamentosRep.Location = new System.Drawing.Point(384, 40);
            this.cbDepartamentosRep.Name = "cbDepartamentosRep";
            this.cbDepartamentosRep.Size = new System.Drawing.Size(258, 24);
            this.cbDepartamentosRep.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(274, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "Departamento:";
            // 
            // btnGenerarReporteRep
            // 
            this.btnGenerarReporteRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporteRep.Location = new System.Drawing.Point(712, 47);
            this.btnGenerarReporteRep.Name = "btnGenerarReporteRep";
            this.btnGenerarReporteRep.Size = new System.Drawing.Size(169, 50);
            this.btnGenerarReporteRep.TabIndex = 45;
            this.btnGenerarReporteRep.Text = "Generar reporte";
            this.btnGenerarReporteRep.UseVisualStyleBackColor = true;
            this.btnGenerarReporteRep.Click += new System.EventHandler(this.btnGenerarReporteRep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "F. inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "F. Final:";
            // 
            // cbReportes
            // 
            this.cbReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReportes.FormattingEnabled = true;
            this.cbReportes.Location = new System.Drawing.Point(384, 80);
            this.cbReportes.Name = "cbReportes";
            this.cbReportes.Size = new System.Drawing.Size(258, 24);
            this.cbReportes.TabIndex = 65;
            this.cbReportes.SelectedIndexChanged += new System.EventHandler(this.cbReportes_SelectedIndexChanged);
            // 
            // dtpFechaInicioRep
            // 
            this.dtpFechaInicioRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicioRep.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicioRep.Location = new System.Drawing.Point(88, 39);
            this.dtpFechaInicioRep.Name = "dtpFechaInicioRep";
            this.dtpFechaInicioRep.Size = new System.Drawing.Size(104, 23);
            this.dtpFechaInicioRep.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(274, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 54;
            this.label5.Text = "Reporte:";
            // 
            // dtpFechaFinRep
            // 
            this.dtpFechaFinRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinRep.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinRep.Location = new System.Drawing.Point(88, 81);
            this.dtpFechaFinRep.Name = "dtpFechaFinRep";
            this.dtpFechaFinRep.Size = new System.Drawing.Size(104, 23);
            this.dtpFechaFinRep.TabIndex = 64;
            // 
            // tabTendencia
            // 
            this.tabTendencia.Controls.Add(this.groupBox1);
            this.tabTendencia.Controls.Add(this.chartConsumo);
            this.tabTendencia.Controls.Add(this.chartTendencia);
            this.tabTendencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTendencia.Location = new System.Drawing.Point(4, 34);
            this.tabTendencia.Name = "tabTendencia";
            this.tabTendencia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTendencia.Size = new System.Drawing.Size(1207, 563);
            this.tabTendencia.TabIndex = 0;
            this.tabTendencia.Text = "Tendencia";
            this.tabTendencia.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnGenerarReporte);
            this.groupBox1.Controls.Add(this.btnImprimirTendencia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnExportarTendencia);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbDepartamentosTen);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Location = new System.Drawing.Point(23, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1160, 107);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // btnImprimirTendencia
            // 
            this.btnImprimirTendencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnImprimirTendencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirTendencia.Image = global::GestionInventario.Properties.Resources.printer;
            this.btnImprimirTendencia.Location = new System.Drawing.Point(1090, 36);
            this.btnImprimirTendencia.Name = "btnImprimirTendencia";
            this.btnImprimirTendencia.Size = new System.Drawing.Size(64, 50);
            this.btnImprimirTendencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnImprimirTendencia.TabIndex = 68;
            this.btnImprimirTendencia.TabStop = false;
            this.btnImprimirTendencia.Click += new System.EventHandler(this.btnImprimirTendencia_Click);
            // 
            // btnExportarTendencia
            // 
            this.btnExportarTendencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnExportarTendencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarTendencia.Image = global::GestionInventario.Properties.Resources.save;
            this.btnExportarTendencia.Location = new System.Drawing.Point(1025, 36);
            this.btnExportarTendencia.Name = "btnExportarTendencia";
            this.btnExportarTendencia.Size = new System.Drawing.Size(57, 50);
            this.btnExportarTendencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExportarTendencia.TabIndex = 67;
            this.btnExportarTendencia.TabStop = false;
            this.btnExportarTendencia.Click += new System.EventHandler(this.btnExportarTendencia_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1132, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(101, 74);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 749);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes carnicos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReportes_FormClosed);
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTendencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConsumo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabVarios.ResumeLayout(false);
            this.tabVarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImprimirReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardarReporte)).EndInit();
            this.tabTendencia.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimirTendencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportarTendencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDepartamentoRep;
        private System.Windows.Forms.Label lbPerfilRep;
        private System.Windows.Forms.Label lbNombreRep;
        private System.Windows.Forms.PictureBox pbLogoRep;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTendencia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConsumo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.ComboBox cbDepartamentosTen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTendencia;
        private System.Windows.Forms.TabPage tabVarios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerarReporteRep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbReportes;
        private System.Windows.Forms.DateTimePicker dtpFechaInicioRep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaFinRep;
        private System.Windows.Forms.PictureBox btnImprimirTendencia;
        private System.Windows.Forms.PictureBox btnExportarTendencia;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.ComboBox cbDepartamentosRep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbUmbral;
        private System.Windows.Forms.TextBox txtUmbral;
        private System.Windows.Forms.PictureBox pbImprimirReporte;
        private System.Windows.Forms.PictureBox pbGuardarReporte;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pbCargarImagenRep;
    }
}