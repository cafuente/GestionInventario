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
    public partial class frmLyfc : Form
    {
        public frmLyfc()
        {
            InitializeComponent();
            CargarDatosInventarioTotalLyfc();
            CargarDatosTraspasosLyfc();
            CargarDatosDevolucionesLyfc();
            CargarDatosDetenidosLyfc();
        }

        private void frmLyfc_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            // Define los departamentos para realizar los traspasos
            string[] destino = { "Recibo(Mocha)", "LyFC(traslado)" };
            // Agrega los departamentos al ComboBox
            cbDestinoLyfcTraspaso.Items.AddRange(destino);
            cbDestinoLyfcDv.Items.AddRange(destino);
            btnCancelarLyfcTraspaso.Enabled = false;
            btnMarcarDetenidoLyfc.Enabled = false;
            txtCodigoBarrasLyfcTraspaso.ForeColor = Color.LightGray;
            txtCodigoBarrasLyfcTraspaso.Text = "DXXXXXX";
            txtCodigoBarrasLyfcTraspaso.GotFocus += new EventHandler(txtCodigoBarrasLyfcTraspaso_GotFocus);
            txtCodigoBarrasLyfcTraspaso.LostFocus += new EventHandler(txtCodigoBarrasLyfcTraspaso_LostFocus);


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
                default:
                    return "Desconocido";
            }
        }

        private void CargarDatosInventarioTotalLyfc()
        {            
            dgvInventarioTotalLyfc.DataSource = BusquedaBD.ObtenerInventarioAgrupadoLyfc();                       
        }

        private void CargarDatosTraspasosLyfc()
        {
            //DataTable dtTraspasos = BusquedaBD.ObtenerTraspasosLyfc();
            //dgvTraspasosLyfc.DataSource = dtTraspasos;
            //otra opcion
            dgvInventarioLyfc.DataSource = BusquedaBD.ObtenerInventarioLyfc();
        }

        private void CargarDatosDevolucionesLyfc()
        {
            dgvTraspasosLyfc.DataSource = BusquedaBD.ObtenerDevolucionesLyfc();
        }

        private void CargarDatosDetenidosLyfc()
        {
            dgvDetenidosLyfc.DataSource = BusquedaBD.ObtenerDetenidosLyfc();
        }

        private void frmLyfc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }

        private void dgvInventarioLyfc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInventarioLyfc.Rows[e.RowIndex];

                // Obtener los valores de la fila seleccionada
                string id = fila.Cells["idTarima"].Value.ToString();
                string producto = fila.Cells["Producto"].Value.ToString();
                string lote = fila.Cells["Lote"].Value.ToString();
                float cantidad_disponible = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                // Asignar los valores a los controles correspondientes
                lbIdTarimaLyfcTraspaso.Text = id;
                txtProductoLyfcTraspaso.Text = producto;
                txtLoteLyfcTraspaso.Text = lote;
                txtCantidadLyfcTraspaso.Text = cantidad_disponible.ToString();
                btnCancelarLyfcTraspaso.Enabled = true;
                btnMarcarDetenidoLyfc.Enabled = true;
            }
        }

        private void btnCancelarLyfcTraspaso_Click(object sender, EventArgs e)
        {
            lbIdTarimaLyfcTraspaso.Text = "ID Tarima";
            txtProductoLyfcTraspaso.Text = null;
            txtLoteLyfcTraspaso.Text = null;
            txtCantidadLyfcTraspaso.Text = null;
            cbDestinoLyfcTraspaso.SelectedIndex = -1;
            dtpFechaLyfcTraspaso.Value = DateTime.Now;
            btnCancelarLyfcTraspaso.Enabled = false;
            btnMarcarDetenidoLyfc.Enabled = false;
        }

        private void txtCodigoBarrasLyfcTraspaso_Click(object sender, EventArgs e)
        {
            txtCodigoBarrasLyfcTraspaso.Text = "";
            txtCodigoBarrasLyfcTraspaso.ForeColor = Color.Black;
        }
        private void txtCodigoBarrasLyfcTraspaso_GotFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasLyfcTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasLyfcTraspaso.Text = "";
                //txtBusquedaDevoGi.ForeColor = Color.Black;
            }
        }
        private void txtCodigoBarrasLyfcTraspaso_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasLyfcTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasLyfcTraspaso.Text = "DXXXXXX";
                txtCodigoBarrasLyfcTraspaso.ForeColor = Color.LightGray;
            }
        }
    }
}
