  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class FrmLogin : Form
    {
        public static Usuario UsuarioActual { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtPassword.Text;

            // Verificar si los campos de nombre de usuario y contraseña están vacíos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Ingrese nombre de usuario y contraseña";
                lblError.Visible = true;

                // Se Crea un temporizador para ocultar la etiqueta de error
                Timer timer = new Timer();
                timer.Interval = 3000; // 3000 milisegundos = 3 segundos
                timer.Tick += (senderTimer, eTimer) =>
                {
                    lblError.Visible = false;
                    timer.Stop(); // Detener el temporizador después de ocultar la etiqueta de error
                };
                timer.Start(); // Iniciar el temporizador
                //MessageBox.Show("Por favor, ingrese nombre de usuario y contraseña.");
                return;
            }

            UsuariosDAO usuariosDAO = new UsuariosDAO();
            if (usuariosDAO.VerificarCredenciales(username, password, out Usuario usuarioAutenticado))
            {
                MessageBox.Show($"Inicio de sesión exitoso. \n\n¡Bienvenido {usuarioAutenticado.Nombre}!");

                // Almacenar la información del usuario en la variable estática UsuarioActual
                UsuarioActual = usuarioAutenticado;

                // Abrir la siguiente ventana de tu aplicación
                FrmPrincipal frm = new FrmPrincipal(UsuarioActual);
                frm.Show();
                Hide();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
                lblError.Visible = true;

                // Crear un temporizador para ocultar la etiqueta de error después de 3 segundos
                Timer timer = new Timer();
                timer.Interval = 3000; // 3000 milisegundos = 3 segundos
                timer.Tick += (senderTimer, eTimer) =>
                {
                    lblError.Visible = false;
                    timer.Stop(); // Detener el temporizador después de ocultar la etiqueta de error
                };
                timer.Start(); // Iniciar el temporizador
                txtUsuario.Text = "";
                txtPassword.Text = "";
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
