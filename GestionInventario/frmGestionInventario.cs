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
    public partial class frmGestionInventario : Form
    {
        public frmGestionInventario()
        {
            InitializeComponent();
        }        

        private void frmGestionInventario_Load(object sender, EventArgs e)
        {
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
                lbNombreGi.Text = $"Usuario: {frmLogin.UsuarioActual.Nombre}";
                lbPerfilGi.Text = $"Perfil: {nombrePerfil}";
                
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

        private void frmGestionInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }


    }
}
