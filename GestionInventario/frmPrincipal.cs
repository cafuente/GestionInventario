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
    public partial class FrmPrincipal : Form
    {
        private Usuario usuarioAutenticado;
        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            usuarioAutenticado = usuario;
            //ConfigurarPermisos();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            btnAdministrador.Visible = false;
            btnAlmacen.Visible = false;
            btnTraslado.Visible = false;
            btnRecibo.Visible = false;
            btnMezclado.Visible = false;
            btnLogistica.Visible = false;

            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            // Configurar la visibilidad de los botones según el perfil y el departamento del usuario
            ConfigurarVisibilidadBotones();
        }
        
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (usuarioAutenticado != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(usuarioAutenticado.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombrePr.Text = $"{usuarioAutenticado.Nombre}";
                lbDepartamentoMu.Text = $"{usuarioAutenticado.Departamento}";
                lbPerfilPr.Text = $"{usuarioAutenticado.PerfilNombre}";
            }
        }
        private void ConfigurarVisibilidadBotones()
        {
            if (usuarioAutenticado.PerfilNombre == "Administrador")
            {
                // El administrador puede ver todos los botones
                btnAdministrador.Visible = true;
                btnAlmacen.Visible=true;
                btnTraslado.Visible=true;                
                btnRecibo.Visible = true;
                btnMezclado.Visible = true;
                btnLogistica.Visible = true;
                btnTrazabilidad.Visible = true; // Para frmTrazabilidad
            }
            else if (usuarioAutenticado.Departamento == "Almacen carnicos")
            {
                btnAlmacen.Visible = true;
                btnRecepcion.Visible = true;
                btnGestion.Visible = true;
            }
            else if (usuarioAutenticado.Departamento == "Limpieza y Formulacion")
            {                
                btnTraslado.Visible = true;
            }
            else if (usuarioAutenticado.Departamento == "Recepcion(mocha)")
            {
                btnRecibo.Visible = true;
            }
            else if (usuarioAutenticado.Departamento == "Mezclado")
            {
                btnMezclado.Visible = true;
                btnLogistica.Visible = true;
            }
            else if (usuarioAutenticado.PerfilNombre == "Supervisor")
            {
                if (usuarioAutenticado.Departamento == "Limpieza y Formulacion")
                {
                    btnTraslado.Visible = true;
                    btnRecibo.Visible = true;
                }
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
        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = true;
            btnGestion.Visible = true;
        }
        private void btnRecepcion_Click(object sender, EventArgs e)
        {
            FrmRecepcionCarne frmRC = new FrmRecepcionCarne();
            frmRC.Show();
            Hide();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            FrmGestionInventario frmGI = new FrmGestionInventario(FrmLogin.UsuarioActual);
            frmGI.Show();
            Hide();
        }

        private void txtAdministrador_Click(object sender, EventArgs e)
        {
            FrmGestionUsuarios frmGu = new FrmGestionUsuarios();
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
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void btnTraslado_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            FrmLyfc frmLyfc = new FrmLyfc(FrmLogin.UsuarioActual);
            frmLyfc.Show();
            this.Hide() ;
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            FrmMocha frmMocha = new FrmMocha(FrmLogin.UsuarioActual);
            frmMocha.Show();
            this.Hide() ;
        }

        private void btnMezclado_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            FrmMezclado frmMezclado = new FrmMezclado(FrmLogin.UsuarioActual);
            frmMezclado.Show();
            this.Hide() ;
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible=false;
            btnGestion.Visible=false;
            FrmLogistica frmLogistica = new FrmLogistica();
            frmLogistica.Show();
            this.Hide() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible=false;
            FrmTrazalibildad frmTrazalibildad = new FrmTrazalibildad();
            frmTrazalibildad.Show();
            this.Hide() ;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            FrmReportes frmReportes = new FrmReportes(FrmLogin.UsuarioActual);
            frmReportes.Show();
            this.Hide() ;
        }
    }
}
