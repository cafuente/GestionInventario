namespace GestionInventario
{
    partial class frmTrazalibildad
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoTr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPerfilTr = new System.Windows.Forms.Label();
            this.lbNombreTr = new System.Windows.Forms.Label();
            this.dgvTrazabilidad = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtIdTarimaBusqueda = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.pbGuardar = new System.Windows.Forms.PictureBox();
            this.pbImpresion = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDepartamentoTr);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbPerfilTr);
            this.panel2.Controls.Add(this.lbNombreTr);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 85);
            this.panel2.TabIndex = 4;
            // 
            // lbDepartamentoTr
            // 
            this.lbDepartamentoTr.AutoSize = true;
            this.lbDepartamentoTr.Location = new System.Drawing.Point(89, 34);
            this.lbDepartamentoTr.Name = "lbDepartamentoTr";
            this.lbDepartamentoTr.Size = new System.Drawing.Size(39, 13);
            this.lbDepartamentoTr.TabIndex = 15;
            this.lbDepartamentoTr.Text = "Deptto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lbPerfilTr
            // 
            this.lbPerfilTr.AutoSize = true;
            this.lbPerfilTr.Location = new System.Drawing.Point(89, 56);
            this.lbPerfilTr.Name = "lbPerfilTr";
            this.lbPerfilTr.Size = new System.Drawing.Size(30, 13);
            this.lbPerfilTr.TabIndex = 1;
            this.lbPerfilTr.Text = "Perfil";
            // 
            // lbNombreTr
            // 
            this.lbNombreTr.AutoSize = true;
            this.lbNombreTr.Location = new System.Drawing.Point(89, 12);
            this.lbNombreTr.Name = "lbNombreTr";
            this.lbNombreTr.Size = new System.Drawing.Size(44, 13);
            this.lbNombreTr.TabIndex = 0;
            this.lbNombreTr.Text = "Nombre";
            // 
            // dgvTrazabilidad
            // 
            this.dgvTrazabilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTrazabilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrazabilidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTrazabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrazabilidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTrazabilidad.Location = new System.Drawing.Point(12, 252);
            this.dgvTrazabilidad.Name = "dgvTrazabilidad";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrazabilidad.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTrazabilidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrazabilidad.Size = new System.Drawing.Size(1060, 362);
            this.dgvTrazabilidad.TabIndex = 76;
            this.dgvTrazabilidad.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTrazabilidad_CellFormatting);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::GestionInventario.Properties.Resources.buscar_barcode;
            this.pictureBox2.Location = new System.Drawing.Point(71, 142);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 77;
            this.pictureBox2.TabStop = false;
            // 
            // txtIdTarimaBusqueda
            // 
            this.txtIdTarimaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTarimaBusqueda.Location = new System.Drawing.Point(152, 155);
            this.txtIdTarimaBusqueda.Name = "txtIdTarimaBusqueda";
            this.txtIdTarimaBusqueda.Size = new System.Drawing.Size(369, 30);
            this.txtIdTarimaBusqueda.TabIndex = 78;
            this.txtIdTarimaBusqueda.Click += new System.EventHandler(this.txtIdTarimaBusqueda_Click);
            this.txtIdTarimaBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdTarimaBusqueda_KeyPress);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(625, 155);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(272, 30);
            this.txtBuscar.TabIndex = 79;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lbFiltro
            // 
            this.lbFiltro.AutoSize = true;
            this.lbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltro.Location = new System.Drawing.Point(563, 162);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(48, 20);
            this.lbFiltro.TabIndex = 80;
            this.lbFiltro.Text = "Filtro:";
            // 
            // pbGuardar
            // 
            this.pbGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGuardar.Image = global::GestionInventario.Properties.Resources.save;
            this.pbGuardar.Location = new System.Drawing.Point(928, 142);
            this.pbGuardar.Name = "pbGuardar";
            this.pbGuardar.Size = new System.Drawing.Size(57, 50);
            this.pbGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGuardar.TabIndex = 81;
            this.pbGuardar.TabStop = false;
            this.pbGuardar.Click += new System.EventHandler(this.pbGuardar_Click);
            // 
            // pbImpresion
            // 
            this.pbImpresion.Image = global::GestionInventario.Properties.Resources.printer;
            this.pbImpresion.Location = new System.Drawing.Point(991, 142);
            this.pbImpresion.Name = "pbImpresion";
            this.pbImpresion.Size = new System.Drawing.Size(54, 50);
            this.pbImpresion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImpresion.TabIndex = 82;
            this.pbImpresion.TabStop = false;
            this.pbImpresion.Click += new System.EventHandler(this.pbImpresion_Click);
            // 
            // frmTrazalibildad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 626);
            this.Controls.Add(this.pbImpresion);
            this.Controls.Add(this.pbGuardar);
            this.Controls.Add(this.lbFiltro);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.txtIdTarimaBusqueda);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dgvTrazabilidad);
            this.Controls.Add(this.panel2);
            this.Name = "frmTrazalibildad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrazalibildad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTrazalibildad_FormClosed);
            this.Load += new System.EventHandler(this.frmTrazalibildad_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbPerfilTr;
        private System.Windows.Forms.Label lbNombreTr;
        private System.Windows.Forms.Label lbDepartamentoTr;
        private System.Windows.Forms.DataGridView dgvTrazabilidad;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtIdTarimaBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lbFiltro;
        private System.Windows.Forms.PictureBox pbGuardar;
        private System.Windows.Forms.PictureBox pbImpresion;
    }
}