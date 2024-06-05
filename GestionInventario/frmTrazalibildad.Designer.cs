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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoTr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPerfilTr = new System.Windows.Forms.Label();
            this.lbNombreTr = new System.Windows.Forms.Label();
            this.dgvTrazabilidad = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtIdTarimaBusqueda = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.dgvTrazabilidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrazabilidad.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTrazabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrazabilidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTrazabilidad.Location = new System.Drawing.Point(12, 210);
            this.dgvTrazabilidad.Name = "dgvTrazabilidad";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrazabilidad.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTrazabilidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrazabilidad.Size = new System.Drawing.Size(808, 404);
            this.dgvTrazabilidad.TabIndex = 76;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::GestionInventario.Properties.Resources.buscar_barcode;
            this.pictureBox2.Location = new System.Drawing.Point(199, 131);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 77;
            this.pictureBox2.TabStop = false;
            // 
            // txtIdTarimaBusqueda
            // 
            this.txtIdTarimaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTarimaBusqueda.Location = new System.Drawing.Point(280, 144);
            this.txtIdTarimaBusqueda.Name = "txtIdTarimaBusqueda";
            this.txtIdTarimaBusqueda.Size = new System.Drawing.Size(248, 23);
            this.txtIdTarimaBusqueda.TabIndex = 78;
            this.txtIdTarimaBusqueda.Click += new System.EventHandler(this.txtIdTarimaBusqueda_Click);
            this.txtIdTarimaBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdTarimaBusqueda_KeyPress);
            // 
            // frmTrazalibildad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 626);
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
    }
}