using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class FrmLogistica : Form
    {
        private Usuario usuarioAutenticado;
        private ConexionBD conexion; //obtener conexion
        public FrmLogistica(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            usuarioAutenticado = usuario;            
            CargarDatosTraspasosLogistica();            
            CargarDatosInventarioTotalLogistica();
        }

        private void frmLogistica_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            // Define los departamentos para realizar los traspasos
            string[] destino = { "Mezclado", "Logística" };
            // Agrega los departamentos al ComboBox
            cbDestinoLogisticaTraspaso.Items.AddRange(destino);            
            btnCancelarLogisticaTraspaso.Enabled = false;           
            dtpFechaLogisticaTraspaso.Value = DateTime.Now;            
            //marca de agua busqueda traspasos
            txtCodigoBarrasLogisticaTraspaso.ForeColor = Color.LightGray;
            txtCodigoBarrasLogisticaTraspaso.Text = "DXXXXXXX";
            txtCodigoBarrasLogisticaTraspaso.GotFocus += new EventHandler(txtCodigoBarrasLogisticaTraspaso_GotFocus);
            txtCodigoBarrasLogisticaTraspaso.LostFocus += new EventHandler(txtCodigoBarrasLogisticaTraspaso_LostFocus);            
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreLogistica.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoLogistica.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilLogistica.Text = $"{nombrePerfil}";

                // Crear instancia de UsuariosDAO
                UsuariosDAO usuariosDAO = new UsuariosDAO();

                // Cargar la imagen del usuario desde la base de datos
                byte[] imagenUsuario = usuariosDAO.ObtenerImagenUsuario(FrmLogin.UsuarioActual.IdUsuario);
                if (imagenUsuario != null && imagenUsuario.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenUsuario))
                    {
                        pbLogoLo.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbLogoLo.Image = Properties.Resources.user_account; // Imagen predeterminada
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

        private void frmLogistica_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmPr = new FrmPrincipal(FrmLogin.UsuarioActual);
            frmPr.Show();
        }

        //---- cargar datos de los datagrid inventario total
        private void CargarDatosInventarioTotalLogistica()
        {
            dgvInventarioTotalLogistica.DataSource = BusquedaBD.ObtenerInventarioAgrupadoLogistica();
        }

        private void CargarDatosTraspasosLogistica()
        {
            dgvInventarioLogistica.DataSource = BusquedaBD.ObtenerInventarioLogistica();
        }

        private void pbCargarImagenLogistica_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes = File.ReadAllBytes(filePath);

                    // Crear instancia de UsuariosDAO
                    UsuariosDAO usuariosDAO = new UsuariosDAO();

                    // Guardar la imagen en la base de datos
                    usuariosDAO.GuardarImagenUsuario(FrmLogin.UsuarioActual.IdUsuario, imageBytes);

                    // Mostrar la imagen en el PictureBox
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbLogoLo.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private void dgvInventarioLogistica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvInventarioLogistica.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    string id = fila.Cells["idTarima"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad_disponible = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                    // Asignar los valores a los controles correspondientes
                    lbIdTarimaLogisticaTraspaso.Text = id;
                    txtProductoLogisticaTraspaso.Text = producto;
                    txtLoteLogisticaTraspaso.Text = lote;
                    txtCantidadLogisticaTraspaso.Text = cantidad_disponible.ToString();
                    btnCancelarLogisticaTraspaso.Enabled = true;                    
                    cbDestinoLogisticaTraspaso.Text = "Logística";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTarimaLogisticaTraspaso.Text = "ID Tarima";
                txtProductoLogisticaTraspaso.Text = null;
                txtLoteLogisticaTraspaso.Text = null;
                txtCantidadLogisticaTraspaso.Text = null;
                cbDestinoLogisticaTraspaso.SelectedIndex = -1;
                dtpFechaLogisticaTraspaso.Value = DateTime.Now;
                btnCancelarLogisticaTraspaso.Enabled = false;                
            }
        }

        private void btnCancelarLogisticaTraspaso_Click(object sender, EventArgs e)
        {
            lbIdTarimaLogisticaTraspaso.Text = "ID Tarima";
            txtProductoLogisticaTraspaso.Text = null;
            txtLoteLogisticaTraspaso.Text = null;
            txtCantidadLogisticaTraspaso.Text = null;
            cbDestinoLogisticaTraspaso.SelectedIndex = -1;
            dtpFechaLogisticaTraspaso.Value = DateTime.Now;
            btnCancelarLogisticaTraspaso.Enabled = false;
        }

        // busqueda lector codigo barras Traspasos ---------------------------
        private void txtCodigoBarrasLogisticaTraspaso_Click(object sender, EventArgs e)
        {
            txtCodigoBarrasLogisticaTraspaso.Text = "";
            txtCodigoBarrasLogisticaTraspaso.ForeColor = Color.Black;
        }

        private void txtCodigoBarrasLogisticaTraspaso_GotFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasLogisticaTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasLogisticaTraspaso.Text = "";
            }
        }
        private void txtCodigoBarrasLogisticaTraspaso_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasLogisticaTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasLogisticaTraspaso.Text = "DXXXXXXX";
                txtCodigoBarrasLogisticaTraspaso.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoBarrasLogisticaTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtCodigoBarrasLogisticaTraspaso.Text = txtCodigoBarrasLogisticaTraspaso.Text.ToUpper();
                    Match match = regex.Match(txtCodigoBarrasLogisticaTraspaso.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCodigoBarrasLogisticaTraspaso.Text = "";
                    }
                    else
                    {
                        BuscarYMostrarInformacionTraspLogistica();
                        txtCodigoBarrasLogisticaTraspaso.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
        }

        private void BuscarYMostrarInformacionTraspLogistica()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtCodigoBarrasLogisticaTraspaso.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspLogistica(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspLogistica(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspLogistica(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvInventarioLogistica.Rows.Count; i++)
            {
                try
                {
                    // Obtener el valor de la celda correspondiente a la columna de código de barras
                    string valorCelda = dgvInventarioLogistica.Rows[i].Cells["idTarima"].Value.ToString();

                    // Comparar el valor de la celda con el código de barras buscado
                    if (valorCelda == codigoBarras)
                    {
                        // Si se encuentra el código de barras, devolver el índice de la fila
                        return i;
                    }
                }
                catch (Exception)
                {
                    return -1;
                }
            }

            // Si no se encuentra el código de barras, devolver -1 para indicar que no se encontró
            return -1;
        }

        private void MostrarInformacionEnCamposTraspLogistica(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvInventarioLogistica.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaLogisticaTraspaso.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaMochaTraspaso = DateTime.Now;
                txtProductoLogisticaTraspaso.Text = fila.Cells["producto"].Value.ToString();
                txtLoteLogisticaTraspaso.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadLogisticaTraspaso.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ningún combo o tarima con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
