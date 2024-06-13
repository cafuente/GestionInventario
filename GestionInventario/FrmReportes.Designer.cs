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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDepartamentoRep = new System.Windows.Forms.Label();
            this.lbPerfilRep = new System.Windows.Forms.Label();
            this.lbNombreRep = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chartTendencia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartConsumo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.cbDepartamentos = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTendencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbDepartamentoRep);
            this.panel1.Controls.Add(this.lbPerfilRep);
            this.panel1.Controls.Add(this.lbNombreRep);
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 85);
            this.panel1.TabIndex = 44;
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
            // pbLogo
            // 
            this.pbLogo.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(75, 85);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 30;
            this.pbLogo.TabStop = false;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.Location = new System.Drawing.Point(887, 172);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(135, 41);
            this.btnGenerarReporte.TabIndex = 45;
            this.btnGenerarReporte.Text = "Generar reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // txtMes
            // 
            this.txtMes.Location = new System.Drawing.Point(77, 641);
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(100, 20);
            this.txtMes.TabIndex = 46;
            this.txtMes.Text = "6";
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(272, 642);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 49;
            this.txtAnio.Text = "2024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 642);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 52;
            this.label2.Text = "Mes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 53;
            this.label3.Text = "F. inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(468, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "Departamento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(227, 645);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 55;
            this.label5.Text = "Año:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(233, 194);
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
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 58;
            this.label7.Text = "Reportes";
            // 
            // chartTendencia
            // 
            chartArea3.Name = "ChartArea1";
            this.chartTendencia.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartTendencia.Legends.Add(legend3);
            this.chartTendencia.Location = new System.Drawing.Point(32, 240);
            this.chartTendencia.Name = "chartTendencia";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartTendencia.Series.Add(series3);
            this.chartTendencia.Size = new System.Drawing.Size(536, 333);
            this.chartTendencia.TabIndex = 59;
            this.chartTendencia.Text = "chart1";
            // 
            // chartConsumo
            // 
            chartArea4.Name = "ChartArea1";
            this.chartConsumo.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartConsumo.Legends.Add(legend4);
            this.chartConsumo.Location = new System.Drawing.Point(604, 240);
            this.chartConsumo.Name = "chartConsumo";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartConsumo.Series.Add(series4);
            this.chartConsumo.Size = new System.Drawing.Size(536, 333);
            this.chartConsumo.TabIndex = 61;
            this.chartConsumo.Text = "chart1";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(93, 191);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(104, 23);
            this.dtpFechaInicio.TabIndex = 63;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(292, 193);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(116, 23);
            this.dtpFechaFin.TabIndex = 64;
            // 
            // cbDepartamentos
            // 
            this.cbDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamentos.FormattingEnabled = true;
            this.cbDepartamentos.Location = new System.Drawing.Point(572, 187);
            this.cbDepartamentos.Name = "cbDepartamentos";
            this.cbDepartamentos.Size = new System.Drawing.Size(168, 24);
            this.cbDepartamentos.TabIndex = 65;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 622);
            this.Controls.Add(this.cbDepartamentos);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.chartConsumo);
            this.Controls.Add(this.chartTendencia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes carnicos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReportes_FormClosed);
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTendencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartConsumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDepartamentoRep;
        private System.Windows.Forms.Label lbPerfilRep;
        private System.Windows.Forms.Label lbNombreRep;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTendencia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConsumo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.ComboBox cbDepartamentos;
    }
}