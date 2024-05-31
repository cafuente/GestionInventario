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
    public partial class frmMocha : Form
    {
        private ConexionBD conexion; //obtener conexion
        public frmMocha()
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            CargarDatosInventarioTotalMocha();
            CargarDatosTraspasosMocha();
            CargarDatosDevolucionesMocha();
            CargarDatosDetenidosMocha();
        }

        private void frmMocha_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            // Define los departamentos para realizar los traspasos
            string[] destino = { "Mezclado", "Recibo(Mocha" };
            // Agrega los departamentos al ComboBox
            cbDestinoMochaTraspaso.Items.AddRange(destino);
            cbDestinoMochaDv.Items.AddRange(destino);            
            btnCancelarMochaTraspaso.Enabled = false;
            btnMarcarDetenidoMocha.Enabled = false;
            btnCancelarMochaDv.Enabled = false;
            dtpFechaMochaTraspaso.Value = DateTime.Now;
            dtpFechaMochaDv.Value = DateTime.Now;
            //marca de agua busqueda traspasos
            txtCodigoBarrasMochaTraspaso.ForeColor = Color.LightGray;
            txtCodigoBarrasMochaTraspaso.Text = "DXXXXXX";
            txtCodigoBarrasMochaTraspaso.GotFocus += new EventHandler(txtCodigoBarrasMochaTraspaso_GotFocus);
            txtCodigoBarrasMochaTraspaso.LostFocus += new EventHandler(txtCodigoBarrasMochaTraspaso_LostFocus);
            // marca de agua busqueda devolucion
            txtBusquedaMochaDv.ForeColor = Color.LightGray;
            txtBusquedaMochaDv.Text = "DXXXXXX";
            //txtBusquedaMochaDv.GotFocus += new EventHandler(txtBusquedaMochaDv_GotFocus);
            //txtBusquedaMochaDv.LostFocus += new EventHandler(txtBusquedaMochaDv_LostFocus);
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreMocha.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoMocha.Text = $"{frmLogin.UsuarioActual.Departamento}";
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

        private void frmMocha_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }

        //---- cargar datos de los datagrid inventario total
        private void CargarDatosInventarioTotalMocha()
        {
            dgvInventarioTotalMocha.DataSource = BusquedaBD.ObtenerInventarioAgrupadoMocha();
        }

        //datadrig de la pestaña traspasos
        private void CargarDatosTraspasosMocha()
        {
            dgvInventarioMocha.DataSource = BusquedaBD.ObtenerInventarioMocha();
        }

        //datagrid de la pestaña devoluciones
        private void CargarDatosDevolucionesMocha()
        {
            dgvTraspasosMocha.DataSource = BusquedaBD.ObtenerTraspasosMocha();
        }

        //datagrid de la pestaña deteidos
        private void CargarDatosDetenidosMocha()
        {
            dgvDetenidosMocha.DataSource = BusquedaBD.ObtenerDetenidosMocha();
        }

        //-------------Codigo pestaña traspasos------------------------------------------------------------------------------------
        private void dgvInventarioMocha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvInventarioMocha.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    string id = fila.Cells["idTarima"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad_disponible = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                    // Asignar los valores a los controles correspondientes
                    lbIdTarimaMochaTraspaso.Text = id;
                    txtProductoMochaTraspaso.Text = producto;
                    txtLoteMochaTraspaso.Text = lote;
                    txtCantidadMochaTraspaso.Text = cantidad_disponible.ToString();
                    btnCancelarMochaTraspaso.Enabled = true;
                    btnMarcarDetenidoMocha.Enabled = true;
                    cbDestinoMochaTraspaso.Text = "Mezclado";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTarimaMochaTraspaso.Text = "ID Tarima";
                txtProductoMochaTraspaso.Text = null;
                txtLoteMochaTraspaso.Text = null;
                txtCantidadMochaTraspaso.Text = null;
                cbDestinoMochaTraspaso.SelectedIndex = -1;
                dtpFechaMochaTraspaso.Value = DateTime.Now;
                btnCancelarMochaTraspaso.Enabled = false;
                btnMarcarDetenidoMocha.Enabled = false;
            }
        }

        private void btnCancelarMochaTraspaso_Click(object sender, EventArgs e)
        {
            lbIdTarimaMochaTraspaso.Text = "ID Tarima";
            txtProductoMochaTraspaso.Text = null;
            txtLoteMochaTraspaso.Text = null;
            txtCantidadMochaTraspaso.Text = null;
            cbDestinoMochaTraspaso.SelectedIndex = -1;
            dtpFechaMochaTraspaso.Value = DateTime.Now;
            btnCancelarMochaTraspaso.Enabled = false;
            btnMarcarDetenidoMocha.Enabled = false;
        }

        // busqueda lector codigo barras Traspasos ---------------------------
        private void txtCodigoBarrasMochaTraspaso_Click(object sender, EventArgs e)
        {
            txtCodigoBarrasMochaTraspaso.Text = "";
            txtCodigoBarrasMochaTraspaso.ForeColor = Color.Black;
        }

        private void txtCodigoBarrasMochaTraspaso_GotFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasMochaTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasMochaTraspaso.Text = "";                
            }
        }
        private void txtCodigoBarrasMochaTraspaso_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasMochaTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasMochaTraspaso.Text = "DXXXXXX";
                txtCodigoBarrasMochaTraspaso.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoBarrasMochaTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Regex regex = new Regex(@"^D\d{6}$");
                // Realizar la búsqueda y mostrar la información en los campos del formulario
                txtCodigoBarrasMochaTraspaso.Text = txtCodigoBarrasMochaTraspaso.Text.ToUpper();
                Match match = regex.Match(txtCodigoBarrasMochaTraspaso.Text);
                if (!match.Success)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoBarrasMochaTraspaso.Text = "";
                }
                else
                {
                    BuscarYMostrarInformacionTraspMocha();
                    txtCodigoBarrasMochaTraspaso.Clear();
                }
            }
        }

        private void BuscarYMostrarInformacionTraspMocha()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtCodigoBarrasMochaTraspaso.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspMocha(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspMocha(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspMocha(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvInventarioMocha.Rows.Count; i++)
            {
                try
                {
                    // Obtener el valor de la celda correspondiente a la columna de código de barras
                    string valorCelda = dgvInventarioMocha.Rows[i].Cells["idTarima"].Value.ToString();

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

        private void MostrarInformacionEnCamposTraspMocha(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvInventarioMocha.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaMochaTraspaso.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaMochaTraspaso = DateTime.Now;
                txtProductoMochaTraspaso.Text = fila.Cells["producto"].Value.ToString();
                txtLoteMochaTraspaso.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadMochaTraspaso.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ningún combo o tarima con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-----------------------------------------------------------------------
        private void btnRegistrarTraspasoMocha_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoMochaTraspaso.Text) ||
                string.IsNullOrEmpty(txtLoteMochaTraspaso.Text) ||
                string.IsNullOrEmpty(txtCantidadMochaTraspaso.Text) ||
                cbDestinoMochaTraspaso.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // verificar estado de tarima
            string idTarima = lbIdTarimaMochaTraspaso.Text;

            if (VerificarEstadoTarimaMocha(idTarima))
            {
                MessageBox.Show("No se puede traspasar una tarima que está detenida.");
                return;
            }

            //String idTarima = lbIdTarima.Text;
            string producto = txtProductoMochaTraspaso.Text;
            string lote = txtLoteMochaTraspaso.Text;
            float cantidad = float.Parse(txtCantidadMochaTraspaso.Text);
            string tipoOperacion = "Traspaso";
            DateTime fechaOperacion = dtpFechaMochaTraspaso.Value;
            string destino = cbDestinoMochaTraspaso.SelectedItem.ToString();
            string usuario = lbNombreMocha.Text;
            string departamento = lbDepartamentoMocha.Text;

            RegistrarTraspasoMocha (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento);
        }

        private void RegistrarTraspasoMocha(string idTarima, string producto, string lote, float cantidad, string tipoOperacion, DateTime fechaOperacion, string destino, string usuario, string departamento)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            //using (MySqlConnection conexion = new MySqlConnection("your_connection_string"))
            {
                try
                {
                    con.Open();

                    // Actualizar cantidad disponible en recepcion_carne
                    string updateQuery = "UPDATE inventario_mocha SET cantidad = cantidad - @cantidad WHERE idTarima = @idTarima";
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
                        INSERT INTO inventario_mezclado 
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
                    CargarDatosTraspasosMocha(); // Recargar datos del inventario después del traspaso
                    btnCancelarMochaTraspaso.Enabled = false;
                    btnMarcarDetenidoMocha.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el traspaso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbIdTarimaMochaTraspaso.Text = "";
                txtProductoMochaTraspaso.Text = null;
                txtLoteMochaTraspaso.Text = null;
                txtCantidadMochaTraspaso.Text = null;
                cbDestinoMochaTraspaso.SelectedIndex = -1;
                dtpFechaMochaTraspaso.Value = DateTime.Now;

                CargarDatosInventarioTotalMocha();
                //CargarDatosTraspasosMocha();
                CargarDatosDevolucionesMocha();
            }
        }

        private bool VerificarEstadoTarimaMocha(string idTarima)
        {
            bool estaDetenida = false;
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "SELECT estado FROM inventario_mocha WHERE idTarima = @idTarima";
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

        //-----------------------------------------------------------------------
    }
}
