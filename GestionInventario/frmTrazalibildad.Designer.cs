﻿namespace GestionInventario
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDepartamentoTr = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPerfilTr = new System.Windows.Forms.Label();
            this.lbNombreTr = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // frmTrazalibildad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 626);
            this.Controls.Add(this.panel2);
            this.Name = "frmTrazalibildad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrazalibildad";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTrazalibildad_FormClosed);
            this.Load += new System.EventHandler(this.frmTrazalibildad_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbPerfilTr;
        private System.Windows.Forms.Label lbNombreTr;
        private System.Windows.Forms.Label lbDepartamentoTr;
    }
}