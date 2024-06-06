using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class frmTrazalibildad : Form
    {
        private void frmTrazalibildad_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            //marca de agua busqueda traspasos
            txtIdTarimaBusqueda.ForeColor = Color.LightGray;
            txtIdTarimaBusqueda.Text = "DXXXXXXX";
            txtIdTarimaBusqueda.GotFocus += new EventHandler(txtIdTarimaBusqueda_GotFocus);
            txtIdTarimaBusqueda.LostFocus += new EventHandler(txtIdTarimaBusqueda_LostFocus);
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

        private void txtIdTarimaBusqueda_Click(object sender, EventArgs e)
        {
            txtIdTarimaBusqueda.Text = "";
            txtIdTarimaBusqueda.ForeColor = Color.Black;
        }
        private void txtIdTarimaBusqueda_GotFocus(object sender, EventArgs e)
        {
            if (txtIdTarimaBusqueda.Text.Trim().Length == 0)
            {
                txtIdTarimaBusqueda.Text = "";
            }
        }
        private void txtIdTarimaBusqueda_LostFocus(object sender, EventArgs e)
        {
            if (txtIdTarimaBusqueda.Text.Trim().Length == 0)
            {
                txtIdTarimaBusqueda.Text = "DXXXXXXX";
                txtIdTarimaBusqueda.ForeColor = Color.LightGray;
            }
        }
        private void txtIdTarimaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Regex regex = new Regex(@"^D\d{7}$");
                // Realizar la búsqueda y mostrar la información en los campos del formulario
                txtIdTarimaBusqueda.Text = txtIdTarimaBusqueda.Text.ToUpper();
                Match match = regex.Match(txtIdTarimaBusqueda.Text);
                if (!match.Success)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdTarimaBusqueda.Text = "";
                }
                else
                {
                    string idTarima = txtIdTarimaBusqueda.Text.Trim();
                    if (!string.IsNullOrEmpty(idTarima))
                    {
                        dgvTrazabilidad.DataSource = BusquedaBD.ObtenerTrazabilidad(idTarima);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un ID de Tarima.");
                    }
                    // Prevent the 'ding' sound
                    e.Handled = true;
                    //BuscarYMostrarInformacionTrazabilidad();
                }                
            }            
        }
    }
}
