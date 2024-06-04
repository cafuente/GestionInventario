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
    public partial class frmTrazalibildad : Form
    {
        private ConexionBD conexion; //obtener conexion
        public frmTrazalibildad()
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            
        }

        private void frmTrazalibildad_Load(object sender, EventArgs e)
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
                lbNombreTr.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoTr.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilTr.Text = $"{nombrePerfil}";

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
                case 3:
                    return "Supervisor";
                default:
                    return "Desconocido";
            }
        }

        private void frmTrazalibildad_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }

        
    }
}
