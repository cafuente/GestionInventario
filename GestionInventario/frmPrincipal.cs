using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();            
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = true;
            btnGestion.Visible = true;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;

            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombrePr.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoMu.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilPr.Text = $"{nombrePerfil}";

            }
        }
        private string ObtenerNombrePerfil(int idPerfil)
        {
            switch (idPerfil)
            {
                case 1:
                    return "Administrador";
                case 2:
                    return "Usuario";
                default:
                    return "Desconocido";
            }
        }

        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            frmRecepcionCarne frmRC = new frmRecepcionCarne();
            frmRC.Show();
            Hide();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            frmGestionInventario frmGI = new frmGestionInventario();
            frmGI.Show();
            Hide();
        }

        private void txtAdministrador_Click(object sender, EventArgs e)
        {
            frmGestionUsuarios frmGu = new frmGestionUsuarios();
            frmGu.Show();
            Hide() ;
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //private bool cerrarSesion = false;
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación antes de cerrar sesión
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Mostrar el formulario de inicio de sesión y cerrar el formulario actual
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!cerrarSesion)
            //{
            //    // Mostrar un mensaje de confirmación antes de cerrar la aplicación
            //    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir de la aplicación?", "Cerrar aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //    if (resultado != DialogResult.Yes)
            //    {
            //        // Cancelar el cierre del formulario si el usuario elige No
            //        e.Cancel = true;
            //    }
                
            //}
        }
    }
}
