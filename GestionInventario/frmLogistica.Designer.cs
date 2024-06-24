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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogistica));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoLyfc = new System.Windows.Forms.Label();
            this.lbPerfilLyfc = new System.Windows.Forms.Label();
            this.pbLogoLo = new System.Windows.Forms.PictureBox();
            this.lbNombreLyfc = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInventarioTotal = new System.Windows.Forms.TabPage();
            this.dgvInventarioTotalLogistica = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbCargarImagenLogistica = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoLo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInventarioTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotalLogistica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenLogistica)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbCargarImagenLogistica);
            this.panel2.Controls.Add(this.lbDepartamentoLyfc);
            this.panel2.Controls.Add(this.lbPerfilLyfc);
            this.panel2.Controls.Add(this.pbLogoLo);
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
            // FrmLogistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 626);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmLogistica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogistica";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogistica_FormClosed);
            this.Load += new System.EventHandler(this.frmLogistica_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoLo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabInventarioTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventarioTotalLogistica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenLogistica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDepartamentoLyfc;
        private System.Windows.Forms.Label lbPerfilLyfc;
        private System.Windows.Forms.PictureBox pbLogoLo;
        private System.Windows.Forms.Label lbNombreLyfc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInventarioTotal;
        private System.Windows.Forms.DataGridView dgvInventarioTotalLogistica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pbCargarImagenLogistica;
    }
}