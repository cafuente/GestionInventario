namespace GestionInventario
{
    partial class FrmTrazalibildad
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
            this.pbFotoPerfil = new System.Windows.Forms.PictureBox();
            this.lbPerfilTr = new System.Windows.Forms.Label();
            this.lbNombreTr = new System.Windows.Forms.Label();
            this.dgvTrazabilidad = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtIdTarimaBusqueda = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lbFiltro = new System.Windows.Forms.Label();
            this.pbGuardar = new System.Windows.Forms.PictureBox();
            this.pbImpresion = new System.Windows.Forms.PictureBox();
            this.pbVistaPrevia = new System.Windows.Forms.PictureBox();
            this.btnVerTodas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaPrevia)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDepartamentoTr);
            this.panel2.Controls.Add(this.pbFotoPerfil);
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
            // pbFotoPerfil
            // 
            this.pbFotoPerfil.Image = global::GestionInventario.Properties.Resources.user_account;
            this.pbFotoPerfil.Location = new System.Drawing.Point(3, 3);
            this.pbFotoPerfil.Name = "pbFotoPerfil";
            this.pbFotoPerfil.Size = new System.Drawing.Size(75, 85);
            this.pbFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotoPerfil.TabIndex = 14;
            this.pbFotoPerfil.TabStop = false;
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
            this.dgvTrazabilidad.Location = new System.Drawing.Point(12, 274);
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
            this.dgvTrazabilidad.Size = new System.Drawing.Size(1047, 340);
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
            this.txtIdTarimaBusqueda.Size = new System.Drawing.Size(503, 30);
            this.txtIdTarimaBusqueda.TabIndex = 78;
            this.txtIdTarimaBusqueda.Click += new System.EventHandler(this.txtIdTarimaBusqueda_Click);
            this.txtIdTarimaBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdTarimaBusqueda_KeyPress);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(152, 215);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(251, 30);
            this.txtBuscar.TabIndex = 79;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lbFiltro
            // 
            this.lbFiltro.AutoSize = true;
            this.lbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFiltro.Location = new System.Drawing.Point(90, 222);
            this.lbFiltro.Name = "lbFiltro";
            this.lbFiltro.Size = new System.Drawing.Size(48, 20);
            this.lbFiltro.TabIndex = 80;
            this.lbFiltro.Text = "Filtro:";
            // 
            // pbGuardar
            // 
            this.pbGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbGuardar.Image = global::GestionInventario.Properties.Resources.save;
            this.pbGuardar.Location = new System.Drawing.Point(39, 41);
            this.pbGuardar.Name = "pbGuardar";
            this.pbGuardar.Size = new System.Drawing.Size(52, 46);
            this.pbGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGuardar.TabIndex = 81;
            this.pbGuardar.TabStop = false;
            this.pbGuardar.Click += new System.EventHandler(this.pbGuardar_Click);
            // 
            // pbImpresion
            // 
            this.pbImpresion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImpresion.Image = global::GestionInventario.Properties.Resources.printer;
            this.pbImpresion.Location = new System.Drawing.Point(99, 41);
            this.pbImpresion.Name = "pbImpresion";
            this.pbImpresion.Size = new System.Drawing.Size(54, 46);
            this.pbImpresion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImpresion.TabIndex = 82;
            this.pbImpresion.TabStop = false;
            this.pbImpresion.Click += new System.EventHandler(this.pbImpresion_Click);
            // 
            // pbVistaPrevia
            // 
            this.pbVistaPrevia.BackColor = System.Drawing.SystemColors.Control;
            this.pbVistaPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaPrevia.Image = global::GestionInventario.Properties.Resources.vista_de_impresion;
            this.pbVistaPrevia.Location = new System.Drawing.Point(161, 41);
            this.pbVistaPrevia.Name = "pbVistaPrevia";
            this.pbVistaPrevia.Size = new System.Drawing.Size(59, 46);
            this.pbVistaPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVistaPrevia.TabIndex = 83;
            this.pbVistaPrevia.TabStop = false;
            this.pbVistaPrevia.Click += new System.EventHandler(this.pbVistaPrevia_Click);
            // 
            // btnVerTodas
            // 
            this.btnVerTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTodas.Location = new System.Drawing.Point(435, 213);
            this.btnVerTodas.Name = "btnVerTodas";
            this.btnVerTodas.Size = new System.Drawing.Size(220, 38);
            this.btnVerTodas.TabIndex = 84;
            this.btnVerTodas.Text = "Mostrar Trazabilidad completa";
            this.btnVerTodas.UseVisualStyleBackColor = true;
            this.btnVerTodas.Click += new System.EventHandler(this.btnVerTodas_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(437, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "Trazabilidad de Combos y tarimas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbVistaPrevia);
            this.groupBox1.Controls.Add(this.pbImpresion);
            this.groupBox1.Controls.Add(this.pbGuardar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(741, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 109);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guardar e imprimir";
            // 
            // FrmTrazalibildad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 626);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerTodas);
            this.Controls.Add(this.lbFiltro);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.txtIdTarimaBusqueda);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dgvTrazabilidad);
            this.Controls.Add(this.panel2);
            this.Name = "FrmTrazalibildad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrazalibildad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTrazalibildad_FormClosed);
            this.Load += new System.EventHandler(this.frmTrazalibildad_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrazabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImpresion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaPrevia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbFotoPerfil;
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
        private System.Windows.Forms.PictureBox pbVistaPrevia;
        private System.Windows.Forms.Button btnVerTodas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}