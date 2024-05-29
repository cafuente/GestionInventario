using MySql.Data.MySqlClient;
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
    public partial class frmLyfc : Form
    {
        private ConexionBD conexion; //obtener conexion
        public frmLyfc()
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
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
            dtpFechaLyfcTraspaso.Value = DateTime.Now;
            dtpFechaLyfcDv.Value = DateTime.Now;
            //marca de agua busqueda traspasos
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

        // datagrid de la pestaña traspaso
        private void dgvInventarioLyfc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                    cbDestinoLyfcTraspaso.Text = "Recibo(Mocha)";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTarimaLyfcTraspaso.Text = "ID Tarima";
                txtProductoLyfcTraspaso.Text = null;
                txtLoteLyfcTraspaso.Text = null;
                txtCantidadLyfcTraspaso.Text = null;
                cbDestinoLyfcTraspaso.SelectedIndex = -1;
                dtpFechaLyfcTraspaso.Value = DateTime.Now;
                btnCancelarLyfcTraspaso.Enabled = false;
                btnMarcarDetenidoLyfc.Enabled = false;
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

        // busqueda lector codigo barras Traspasos ---------------------------
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

        private void txtCodigoBarrasLyfcTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Regex regex = new Regex(@"^D\d{6}$");
                // Realizar la búsqueda y mostrar la información en los campos del formulario
                txtCodigoBarrasLyfcTraspaso.Text = txtCodigoBarrasLyfcTraspaso.Text.ToUpper();
                Match match = regex.Match(txtCodigoBarrasLyfcTraspaso.Text);
                if (!match.Success)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoBarrasLyfcTraspaso.Text = "";
                }
                else
                {
                    BuscarYMostrarInformacionTraspLyfc();
                    txtCodigoBarrasLyfcTraspaso.Clear();
                }
            }
        }

        private void BuscarYMostrarInformacionTraspLyfc()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtCodigoBarrasLyfcTraspaso.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspLyfc(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspLyfc(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspLyfc(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvInventarioLyfc.Rows.Count; i++)
            {
                // Obtener el valor de la celda correspondiente a la columna de código de barras
                string valorCelda = dgvInventarioLyfc.Rows[i].Cells["idTarima"].Value.ToString();

                // Comparar el valor de la celda con el código de barras buscado
                if (valorCelda == codigoBarras)
                {
                    // Si se encuentra el código de barras, devolver el índice de la fila
                    return i;
                }
            }

            // Si no se encuentra el código de barras, devolver -1 para indicar que no se encontró
            return -1;
        }

        private void MostrarInformacionEnCamposTraspLyfc(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvInventarioLyfc.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaLyfcTraspaso.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaLyfcTraspaso = DateTime.Now;
                txtProductoLyfcTraspaso.Text = fila.Cells["producto"].Value.ToString();
                txtLoteLyfcTraspaso.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadLyfcTraspaso.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ningún artículo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------------------------

        // ---traspasos-------------
        private void btnRegistrarTraspasoLyfc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoLyfcTraspaso.Text) ||
                string.IsNullOrEmpty(txtLoteLyfcTraspaso.Text) ||
                string.IsNullOrEmpty(txtCantidadLyfcTraspaso.Text) ||
                cbDestinoLyfcTraspaso  .SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // verificar estado de tarima
            string idTarima = lbIdTarimaLyfcTraspaso.Text;

            if (VerificarEstadoTarimaLyfc(idTarima))
            {
                MessageBox.Show("No se puede traspasar una tarima que está detenida.");
                return;
            }

            //String idTarima = lbIdTarima.Text;
            string producto = txtProductoLyfcTraspaso.Text;
            string lote = txtLoteLyfcTraspaso.Text;
            float cantidad = float.Parse(txtCantidadLyfcTraspaso.Text);
            string tipoOperacion = "Traspaso";
            DateTime fechaOperacion = dtpFechaLyfcTraspaso.Value;
            string destino = cbDestinoLyfcTraspaso.SelectedItem.ToString();
            string usuario = lbNombreLyfc.Text;
            string departamento = lbDepartamentoLyfc.Text;

            RegistrarTraspasoLyfc(idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento);
        }

        private void RegistrarTraspasoLyfc(string idTarima, string producto, string lote, float cantidad, string tipoOperacion, DateTime fechaOperacion, string destino, string usuario, string departamento)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            //using (MySqlConnection conexion = new MySqlConnection("your_connection_string"))
            {
                try
                {
                    con.Open();

                    // Actualizar cantidad disponible en recepcion_carne
                    string updateQuery = "UPDATE inventario_lyfc SET cantidad = cantidad - @cantidad WHERE idTarima = @idTarima";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, con))
                    {
                        updateCmd.Parameters.AddWithValue("@cantidad", cantidad);
                        updateCmd.Parameters.AddWithValue("@idTarima", idTarima);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Insertar el traspaso en salidas_devoluciones
                    string insertQuery = @"
                        INSERT INTO salidas_devoluciones 
                        (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento) 
                        VALUES (@idTarima, @producto, @lote, @cantidad, @tipoOperacion, @fechaOperacion, @destino, @usuario, @departamento)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@idTarima", idTarima);
                        insertCmd.Parameters.AddWithValue("@producto", producto);
                        insertCmd.Parameters.AddWithValue("@lote", lote);
                        insertCmd.Parameters.AddWithValue("@cantidad", cantidad);
                        insertCmd.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);
                        insertCmd.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);
                        insertCmd.Parameters.AddWithValue("@destino", destino);
                        insertCmd.Parameters.AddWithValue("@usuario", usuario);
                        insertCmd.Parameters.AddWithValue("@departamento", departamento);
                        insertCmd.ExecuteNonQuery();
                    }
                    // se inserta la cantidad al inventario de Recibo (mocha)
                    string insertLyfcQuery = @"
                        INSERT INTO inventario_mocha 
                        (idTarima, producto, lote, cantidad, fechaOperacion, usuario, departamento) 
                        VALUES (@idTarima, @producto, @lote, @cantidad, @fechaOperacion, @usuario, @departamento)";
                    using (MySqlCommand insertLyfcCmd = new MySqlCommand(insertLyfcQuery, con))
                    {
                        insertLyfcCmd.Parameters.AddWithValue("@idTarima", idTarima);
                        insertLyfcCmd.Parameters.AddWithValue("@producto", producto);
                        insertLyfcCmd.Parameters.AddWithValue("@lote", lote);
                        insertLyfcCmd.Parameters.AddWithValue("@cantidad", cantidad);
                        insertLyfcCmd.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);
                        insertLyfcCmd.Parameters.AddWithValue("@usuario", usuario);
                        insertLyfcCmd.Parameters.AddWithValue("@departamento", departamento);
                        insertLyfcCmd.ExecuteNonQuery();
                    }


                    MessageBox.Show("Traspaso registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosTraspasosLyfc(); // Recargar datos del inventario después del traspaso
                    btnCancelarLyfcTraspaso.Enabled = false;
                    btnMarcarDetenidoLyfc.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el traspaso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbIdTarimaLyfcTraspaso.Text = "";
                txtProductoLyfcTraspaso.Text = null;
                txtLoteLyfcTraspaso.Text = null;
                txtCantidadLyfcTraspaso.Text = null;
                cbDestinoLyfcTraspaso.SelectedIndex = -1;
                dtpFechaLyfcTraspaso.Value = DateTime.Now;

                CargarDatosInventarioTotalLyfc();
                CargarDatosTraspasosLyfc();
            }
        }

        private bool VerificarEstadoTarimaLyfc(string idTarima)
        {
            bool estaDetenida = false;
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "SELECT estado FROM inventario_lyfc WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    MySqlDataReader lector = comando.ExecuteReader();
                    if (lector.Read())
                    {
                        estaDetenida = lector["estado"].ToString() == "detenido";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar el estado de la tarima: " + ex.Message);
                }
            }
            return estaDetenida;
        }
        //-------------termina traspasos-------------------------

    }
}
