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
    public partial class Devoluciones : Form
    {
        private ConexionBD conexion;
        private InsercionDatosDAO insercionDatosDAO;
        public Devoluciones()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            insercionDatosDAO = new InsercionDatosDAO();
            
        }
        private void frmDevoluciones_Load(object sender, EventArgs e)
        {
            MostrarInformacionUsuario();
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreDev.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoDev.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilDev.Text = $"{nombrePerfil}";

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

        private void frmDevoluciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmGestionInventario frmGi = new FrmGestionInventario(FrmLogin.UsuarioActual);
            frmGi.Show();
        }

        
    }
}
