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
        private Usuario usuarioAutenticado;
        public frmPrincipal(Usuario usuario)
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
            /*
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {

                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombrePr.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoMu.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilPr.Text = $"{nombrePerfil}";
            }*/
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
            else if (usuarioAutenticado.Departamento == "Limpieza y formulacion")
            {
                if (usuarioAutenticado.usuario == "Mocha")
                {
                    btnRecibo.Visible = true;
                }
                else
                {
                    btnTraslado.Visible = true;
                }
            }
            else if (usuarioAutenticado.Departamento == "Mezclado")
            {
                btnMezclado.Visible = true;
                btnLogistica.Visible = true;
            }
            else if (usuarioAutenticado.PerfilNombre == "Supervisor")
            {
                // Ajustar la visibilidad de los botones para el supervisor
                btnRecepcion.Visible = true;
                btnGestion.Visible = true;
                btnTraslado.Visible = true;
                btnRecibo.Visible = true;
                btnMezclado.Visible = true;
                btnLogistica.Visible = true;
                btnTrazabilidad.Visible = true; // Para frmTrazabilidad
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
        private void ConfigurarPermisos()
        {
            // Configurar permisos basados en el perfil y departamento del usuario autenticado
            switch (usuarioAutenticado.PerfilNombre)
            {
                case "Administrador":
                    // Administrador tiene acceso a todo
                    //btnAdministrador.Visible = true;
                    //btnAlmacen.Visible = true;
                    //btnTraslado.Visible = true;
                    //btnRecibo.Visible = true;
                    //btnMezclado.Visible = true;
                    //btnLogistica.Visible = true;
                    break;
                case "Almacen carnicos":
                    btnRecepcion.Visible = true;
                    btnGestion.Visible = true;
                    break;
                case "Limpieza y formulacion":
                    if (usuarioAutenticado.Departamento == "LyFC")
                    {
                        btnTraslado.Visible = true;
                    }
                    else if (usuarioAutenticado.Departamento == "Mocha")
                    {
                        btnRecibo.Visible = true;
                    }
                    break;
                case "Mezclado":
                    btnMezclado.Visible = true;
                    btnLogistica.Visible = true;
                    break;
            }

            if (usuarioAutenticado.PerfilNombre != "Supervisor")
            {
                // Deshabilitar las funcionalidades de devoluciones y detenidos para no supervisores
                foreach (Form form in Application.OpenForms)
                {
                    if (form is frmGestionInventario inventarioForm)
                    {
                        inventarioForm.DesactivarDevolucionesYDetenidos();
                    }
                    // Repetir para otros formularios si es necesario
                }
            }
        }
        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = true;
            btnGestion.Visible = true;
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

        private void btnTraslado_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            frmLyfc frmLyfc = new frmLyfc();
            frmLyfc.Show();
            this.Hide() ;
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            frmMocha frmMocha = new frmMocha();
            frmMocha.Show();
            this.Hide() ;
        }

        private void btnMezclado_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible = false;
            frmMezclado frmMezclado = new frmMezclado();
            frmMezclado.Show();
            this.Hide() ;
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible=false;
            btnGestion.Visible=false;
            frmLogistica frmLogistica = new frmLogistica();
            frmLogistica.Show();
            this.Hide() ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnRecepcion.Visible = false;
            btnGestion.Visible=false;
            frmTrazalibildad frmTrazalibildad = new frmTrazalibildad();
            frmTrazalibildad.Show();
            this.Hide() ;
        }
    }
}
