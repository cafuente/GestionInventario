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
    public partial class frmLogistica : Form
    {
        private ConexionBD conexion; //obtener conexion
        public frmLogistica()
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            CargarDatosInventarioTotalLogistica();
        }

        private void frmLogistica_Load(object sender, EventArgs e)
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
                lbNombreLyfc.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoLyfc.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilLyfc.Text = $"{nombrePerfil}";
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

        private void frmLogistica_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal(frmLogin.UsuarioActual);
            frmPr.Show();
        }

        //---- cargar datos de los datagrid inventario total
        private void CargarDatosInventarioTotalLogistica()
        {
            dgvInventarioTotalLogistica.DataSource = BusquedaBD.ObtenerInventarioAgrupadoLogistica();
        }

    }
}
