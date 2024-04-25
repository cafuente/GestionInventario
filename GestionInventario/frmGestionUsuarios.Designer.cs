namespace GestionInventario
{
    partial class frmGestionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionUsuarios));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbUsuario = new System.Windows.Forms.GroupBox();
            this.chbDepartamento = new System.Windows.Forms.CheckBox();
            this.cbDepartamento = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbPerfil = new System.Windows.Forms.CheckBox();
            this.chbNombre = new System.Windows.Forms.CheckBox();
            this.chbUsuario = new System.Windows.Forms.CheckBox();
            this.chbId = new System.Windows.Forms.CheckBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cbPerfil = new System.Windows.Forms.ComboBox();
            this.dgGestionUsuarios = new System.Windows.Forms.DataGridView();
            this.IdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPerfilGu = new System.Windows.Forms.Label();
            this.lbNombreGu = new System.Windows.Forms.Label();
            this.gbUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGestionUsuarios)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Perfil:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(291, 45);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(212, 40);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(147, 42);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(111, 22);
            this.txtUsuario.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(115, 84);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(143, 22);
            this.txtPassword.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(115, 126);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(143, 22);
            this.txtNombre.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Control de Acceso";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(291, 118);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(212, 40);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(291, 191);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(212, 40);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // gbUsuario
            // 
            this.gbUsuario.Controls.Add(this.chbDepartamento);
            this.gbUsuario.Controls.Add(this.cbDepartamento);
            this.gbUsuario.Controls.Add(this.label6);
            this.gbUsuario.Controls.Add(this.chbPerfil);
            this.gbUsuario.Controls.Add(this.chbNombre);
            this.gbUsuario.Controls.Add(this.chbUsuario);
            this.gbUsuario.Controls.Add(this.chbId);
            this.gbUsuario.Controls.Add(this.lblId);
            this.gbUsuario.Controls.Add(this.lblBuscar);
            this.gbUsuario.Controls.Add(this.txtBuscar);
            this.gbUsuario.Controls.Add(this.cbPerfil);
            this.gbUsuario.Controls.Add(this.label2);
            this.gbUsuario.Controls.Add(this.btnEliminar);
            this.gbUsuario.Controls.Add(this.label3);
            this.gbUsuario.Controls.Add(this.btnActualizar);
            this.gbUsuario.Controls.Add(this.label4);
            this.gbUsuario.Controls.Add(this.label5);
            this.gbUsuario.Controls.Add(this.btnAgregar);
            this.gbUsuario.Controls.Add(this.txtUsuario);
            this.gbUsuario.Controls.Add(this.txtNombre);
            this.gbUsuario.Controls.Add(this.txtPassword);
            this.gbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUsuario.Location = new System.Drawing.Point(12, 95);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(509, 323);
            this.gbUsuario.TabIndex = 15;
            this.gbUsuario.TabStop = false;
            this.gbUsuario.Text = "Datos de usuario";
            // 
            // chbDepartamento
            // 
            this.chbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDepartamento.Location = new System.Drawing.Point(405, 297);
            this.chbDepartamento.Name = "chbDepartamento";
            this.chbDepartamento.Size = new System.Drawing.Size(67, 20);
            this.chbDepartamento.TabIndex = 0;
            this.chbDepartamento.Text = "Deptto";
            this.chbDepartamento.UseVisualStyleBackColor = true;
            // 
            // cbDepartamento
            // 
            this.cbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartamento.FormattingEnabled = true;
            this.cbDepartamento.Location = new System.Drawing.Point(115, 168);
            this.cbDepartamento.Name = "cbDepartamento";
            this.cbDepartamento.Size = new System.Drawing.Size(143, 23);
            this.cbDepartamento.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Deptto:";
            // 
            // chbPerfil
            // 
            this.chbPerfil.AutoSize = true;
            this.chbPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbPerfil.Location = new System.Drawing.Point(318, 299);
            this.chbPerfil.Name = "chbPerfil";
            this.chbPerfil.Size = new System.Drawing.Size(49, 17);
            this.chbPerfil.TabIndex = 22;
            this.chbPerfil.Text = "Perfil";
            this.chbPerfil.UseVisualStyleBackColor = true;
            // 
            // chbNombre
            // 
            this.chbNombre.AutoSize = true;
            this.chbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbNombre.Location = new System.Drawing.Point(217, 299);
            this.chbNombre.Name = "chbNombre";
            this.chbNombre.Size = new System.Drawing.Size(63, 17);
            this.chbNombre.TabIndex = 21;
            this.chbNombre.Text = "Nombre";
            this.chbNombre.UseVisualStyleBackColor = true;
            // 
            // chbUsuario
            // 
            this.chbUsuario.AutoSize = true;
            this.chbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUsuario.Location = new System.Drawing.Point(117, 299);
            this.chbUsuario.Name = "chbUsuario";
            this.chbUsuario.Size = new System.Drawing.Size(62, 17);
            this.chbUsuario.TabIndex = 20;
            this.chbUsuario.Text = "Usuario";
            this.chbUsuario.UseVisualStyleBackColor = true;
            // 
            // chbId
            // 
            this.chbId.AutoSize = true;
            this.chbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbId.Location = new System.Drawing.Point(44, 299);
            this.chbId.Name = "chbId";
            this.chbId.Size = new System.Drawing.Size(35, 17);
            this.chbId.TabIndex = 19;
            this.chbId.Text = "Id";
            this.chbId.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(115, 46);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 16);
            this.lblId.TabIndex = 18;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(30, 257);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(49, 16);
            this.lblBuscar.TabIndex = 17;
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(115, 253);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(388, 22);
            this.txtBuscar.TabIndex = 16;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cbPerfil
            // 
            this.cbPerfil.FormattingEnabled = true;
            this.cbPerfil.Location = new System.Drawing.Point(115, 212);
            this.cbPerfil.Name = "cbPerfil";
            this.cbPerfil.Size = new System.Drawing.Size(143, 24);
            this.cbPerfil.TabIndex = 11;
            // 
            // dgGestionUsuarios
            // 
            this.dgGestionUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGestionUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdUsuario,
            this.NombreUsuario,
            this.Password,
            this.Nombre,
            this.Departamento,
            this.Perfil});
            this.dgGestionUsuarios.Location = new System.Drawing.Point(12, 424);
            this.dgGestionUsuarios.Name = "dgGestionUsuarios";
            this.dgGestionUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgGestionUsuarios.Size = new System.Drawing.Size(509, 168);
            this.dgGestionUsuarios.TabIndex = 16;
            this.dgGestionUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGestionUsuarios_CellClick);
            // 
            // IdUsuario
            // 
            this.IdUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdUsuario.HeaderText = "Id";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.Width = 41;
            // 
            // NombreUsuario
            // 
            this.NombreUsuario.HeaderText = "Usuario";
            this.NombreUsuario.Name = "NombreUsuario";
            // 
            // Password
            // 
            this.Password.HeaderText = "Contraseña";
            this.Password.Name = "Password";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Departamento
            // 
            this.Departamento.HeaderText = "Departamento";
            this.Departamento.Name = "Departamento";
            // 
            // Perfil
            // 
            this.Perfil.HeaderText = "Perfil";
            this.Perfil.Name = "Perfil";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lbPerfilGu);
            this.panel2.Controls.Add(this.lbNombreGu);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 83);
            this.panel2.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lbPerfilGu
            // 
            this.lbPerfilGu.AutoSize = true;
            this.lbPerfilGu.Location = new System.Drawing.Point(109, 47);
            this.lbPerfilGu.Name = "lbPerfilGu";
            this.lbPerfilGu.Size = new System.Drawing.Size(30, 13);
            this.lbPerfilGu.TabIndex = 1;
            this.lbPerfilGu.Text = "Perfil";
            // 
            // lbNombreGu
            // 
            this.lbNombreGu.AutoSize = true;
            this.lbNombreGu.Location = new System.Drawing.Point(109, 19);
            this.lbNombreGu.Name = "lbNombreGu";
            this.lbNombreGu.Size = new System.Drawing.Size(44, 13);
            this.lbNombreGu.TabIndex = 0;
            this.lbNombreGu.Text = "Nombre";
            // 
            // frmGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgGestionUsuarios);
            this.Controls.Add(this.gbUsuario);
            this.Controls.Add(this.label1);
            this.Name = "frmGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGestionUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbUsuario.ResumeLayout(false);
            this.gbUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGestionUsuarios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox gbUsuario;
        private System.Windows.Forms.DataGridView dgGestionUsuarios;
        private System.Windows.Forms.ComboBox cbPerfil;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.CheckBox chbPerfil;
        private System.Windows.Forms.CheckBox chbNombre;
        private System.Windows.Forms.CheckBox chbUsuario;
        private System.Windows.Forms.CheckBox chbId;
        private System.Windows.Forms.ComboBox cbDepartamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perfil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbPerfilGu;
        private System.Windows.Forms.Label lbNombreGu;
    }
}

