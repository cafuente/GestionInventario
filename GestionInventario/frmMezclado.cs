using MySql.Data.MySqlClient;
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
    public partial class FrmMezclado : Form
    {
        private Usuario usuarioAutenticado;
        private ConexionBD conexion; //obtener conexion
        public FrmMezclado(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            usuarioAutenticado = usuario;
            CargarDatosInventarioTotalMezclado();
            CargarDatosTraspasosMezclado();
            CargarDatosDevolucionesMezclado();
            CargarDatosDetenidosMezclado();
            CargarDatosPendientesConfirmacionMezclado();
        }

        private void frmMezclado_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            // Define los departamentos para realizar los traspasos
            string[] destino = { "Mezclado", "Logística" };
            // Agrega los departamentos al ComboBox
            cbDestinoMezcladoTraspaso.Items.AddRange(destino);
            cbDestinoMezcladoDv.Items.AddRange(destino);
            btnCancelarMezcladoTraspaso.Enabled = false;
            btnMarcarDetenidoMezclado.Enabled = false;
            btnCancelarMezcladoDv.Enabled = false;
            dtpFechaMezcladoTraspaso.Value = DateTime.Now;
            dtpFechaMezcladoDv.Value = DateTime.Now;
            //marca de agua busqueda traspasos
            txtCodigoBarrasMezcladoTraspaso.ForeColor = Color.LightGray;
            txtCodigoBarrasMezcladoTraspaso.Text = "DXXXXXXX";
            txtCodigoBarrasMezcladoTraspaso.GotFocus += new EventHandler(txtCodigoBarrasMezcladoTraspaso_GotFocus);
            txtCodigoBarrasMezcladoTraspaso.LostFocus += new EventHandler(txtCodigoBarrasMezcladoTraspaso_LostFocus);
            // marca de agua busqueda devolucion
            txtBusquedaMezcladoDv.ForeColor = Color.LightGray;
            txtBusquedaMezcladoDv.Text = "DXXXXXXX";
            txtBusquedaMezcladoDv.GotFocus += new EventHandler(txtBusquedaMezcladoDv_GotFocus);
            txtBusquedaMezcladoDv.LostFocus += new EventHandler(txtBusquedaMezcladoDv_LostFocus);
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreMezclado.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoMezclado.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilMezclado.Text = $"{nombrePerfil}";

                // Crear instancia de UsuariosDAO
                UsuariosDAO usuariosDAO = new UsuariosDAO();

                // Cargar la imagen del usuario desde la base de datos
                byte[] imagenUsuario = usuariosDAO.ObtenerImagenUsuario(FrmLogin.UsuarioActual.IdUsuario);
                if (imagenUsuario != null && imagenUsuario.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenUsuario))
                    {
                        pbLogoMezclado.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbLogoMezclado.Image = Properties.Resources.user_account; // Imagen predeterminada
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

        private void frmMezclado_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmPr = new FrmPrincipal(FrmLogin.UsuarioActual);
            frmPr.Show();
        }

        //---- cargar datos de los datagrid inventario total
        private void CargarDatosInventarioTotalMezclado()
        {
            dgvInventarioTotalMezclado.DataSource = BusquedaBD.ObtenerInventarioAgrupadoMezclado();
        }

        //datadrig de la pestaña traspasos
        private void CargarDatosTraspasosMezclado()
        {
            dgvInventarioMezclado.DataSource = BusquedaBD.ObtenerInventarioMezclado();
        }

        //datagrid de la pestaña devoluciones
        private void CargarDatosDevolucionesMezclado()
        {
            dgvTraspasosMezclado.DataSource = BusquedaBD.ObtenerTraspasosMezclado();
        }

        //datagrid de la pestaña deteidos
        private void CargarDatosDetenidosMezclado()
        {
            dgvDetenidosMezclado.DataSource = BusquedaBD.ObtenerDetenidosMezclado();
        }

        // datagrid de la pestaña conciliacion
        private void CargarDatosPendientesConfirmacionMezclado()
        {
            dgvPendientesConfirmacionMezclado.DataSource = BusquedaBD.ObtenerPendientesConfirmacionMezclado();
        }

        // ------- confirmar recepcion de tarima o combo
        private void btnConfirmarRecepcionMezclado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPendientesConfirmacionMezclado.SelectedRows.Count > 0)
                {
                    string idTarima = dgvPendientesConfirmacionMezclado.SelectedRows[0].Cells["idTarima"].Value.ToString();
                    ConfirmarRecepcionTarimaMezclado(idTarima);
                    MessageBox.Show("La recepción de la tarima ha sido confirmada de recibido.");
                    CargarDatosPendientesConfirmacionMezclado();
                    //CargarDatosInventarioLyfc(); // Actualizar la lista de tarimas confirmadas
                    CargarDatosInventarioTotalMezclado();
                    CargarDatosTraspasosMezclado();
                    CargarDatosDevolucionesMezclado();
                    CargarDatosDetenidosMezclado();
                }
                else
                {
                    MessageBox.Show("Seleccione una tarima para confirmar su recepción.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una tarima para confirmar su recepción.");
            }
            
        }

        private void ConfirmarRecepcionTarimaMezclado(string idTarima)
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            string usuario = lbNombreMezclado.Text;
            string departamento = lbDepartamentoMezclado.Text;
            try
            {
                conexion.Open();
                string consulta = "UPDATE inventario_mezclado SET estado_confirmacion = 'Recibido' WHERE idTarima = @idTarima";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idTarima", idTarima);
                comando.ExecuteNonQuery();

                // Obtener detalles de la tarima
                consulta = "SELECT producto, lote, cantidad FROM inventario_mezclado WHERE idTarima = @idTarima";
                comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idTarima", idTarima);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    string producto = reader["producto"].ToString();
                    string lote = reader["lote"].ToString();
                    int cantidad = Convert.ToInt32(reader["cantidad"]);
                    reader.Close();

                    // Registrar el movimiento en salidas_devoluciones
                    consulta = "INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento) " +
                               "VALUES (@idTarima, @producto, @lote, @cantidad, 'Confirmacion Recepcion', @fechaOperacion, @destino, @usuario, @departamento)";
                    comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.Parameters.AddWithValue("@producto", producto);
                    comando.Parameters.AddWithValue("@lote", lote);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@fechaOperacion", DateTime.Now);
                    comando.Parameters.AddWithValue("@destino", "Mezclado");
                    comando.Parameters.AddWithValue("@usuario", usuario); // Reemplazar con el nombre del usuario actual
                    comando.Parameters.AddWithValue("@departamento", departamento); // Reemplazar con el departamento actual
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al confirmar la recepción de la tarima: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        //-------------Codigo pestaña traspasos-------------------------------------------------------------------------------
        private void dgvInventarioMezclado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvInventarioMezclado.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    string id = fila.Cells["idTarima"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad_disponible = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                    // Asignar los valores a los controles correspondientes
                    lbIdTarimaMezcladoTraspaso.Text = id;
                    txtProductoMezcladoTraspaso.Text = producto;
                    txtLoteMezcladoTraspaso.Text = lote;
                    txtCantidadMezcladoTraspaso.Text = cantidad_disponible.ToString();
                    btnCancelarMezcladoTraspaso.Enabled = true;
                    btnMarcarDetenidoMezclado.Enabled = true;
                    cbDestinoMezcladoTraspaso.Text = "Logística";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTarimaMezcladoTraspaso.Text = "ID Tarima";
                txtProductoMezcladoTraspaso.Text = null;
                txtLoteMezcladoTraspaso.Text = null;
                txtCantidadMezcladoTraspaso.Text = null;
                cbDestinoMezcladoTraspaso.SelectedIndex = -1;
                dtpFechaMezcladoTraspaso.Value = DateTime.Now;
                btnCancelarMezcladoTraspaso.Enabled = false;
                btnMarcarDetenidoMezclado.Enabled = false;
            }
        }

        private void btnCancelarMezcladoTraspaso_Click(object sender, EventArgs e)
        {
            lbIdTarimaMezcladoTraspaso.Text = "ID Tarima";
            txtProductoMezcladoTraspaso.Text = null;
            txtLoteMezcladoTraspaso.Text = null;
            txtCantidadMezcladoTraspaso.Text = null;
            cbDestinoMezcladoTraspaso.SelectedIndex = -1;
            dtpFechaMezcladoTraspaso.Value = DateTime.Now;
            btnCancelarMezcladoTraspaso.Enabled = false;
            btnMarcarDetenidoMezclado.Enabled = false;
        }

        // busqueda lector codigo barras Traspasos ---------------------------
        private void txtCodigoBarrasMezcladoTraspaso_Click(object sender, EventArgs e)
        {
            txtCodigoBarrasMezcladoTraspaso.Text = "";
            txtCodigoBarrasMezcladoTraspaso.ForeColor = Color.Black;
        }

        private void txtCodigoBarrasMezcladoTraspaso_GotFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasMezcladoTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasMezcladoTraspaso.Text = "";
            }
        }
        private void txtCodigoBarrasMezcladoTraspaso_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasMezcladoTraspaso.Text.Trim().Length == 0)
            {
                txtCodigoBarrasMezcladoTraspaso.Text = "DXXXXXXX";
                txtCodigoBarrasMezcladoTraspaso.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoBarrasMezcladoTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtCodigoBarrasMezcladoTraspaso.Text = txtCodigoBarrasMezcladoTraspaso.Text.ToUpper();
                    Match match = regex.Match(txtCodigoBarrasMezcladoTraspaso.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCodigoBarrasMezcladoTraspaso.Text = "";
                    }
                    else
                    {
                        BuscarYMostrarInformacionTraspMezclado();
                        txtCodigoBarrasMezcladoTraspaso.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            
        }
        private void BuscarYMostrarInformacionTraspMezclado()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtCodigoBarrasMezcladoTraspaso.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspMezclado(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspMezclado(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspMezclado(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvInventarioMezclado.Rows.Count; i++)
            {
                try
                {
                    // Obtener el valor de la celda correspondiente a la columna de código de barras
                    string valorCelda = dgvInventarioMezclado.Rows[i].Cells["idTarima"].Value.ToString();

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

        private void MostrarInformacionEnCamposTraspMezclado(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvInventarioMezclado.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaMezcladoTraspaso.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaMochaTraspaso = DateTime.Now;
                txtProductoMezcladoTraspaso.Text = fila.Cells["producto"].Value.ToString();
                txtLoteMezcladoTraspaso.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadMezcladoTraspaso.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ningún combo o tarima con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------registro traspasos-----------------------------------------------------------------------------------
        private void btnRegistrarTraspasoMezclado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoMezcladoTraspaso.Text) ||
                string.IsNullOrEmpty(txtLoteMezcladoTraspaso.Text) ||
                string.IsNullOrEmpty(txtCantidadMezcladoTraspaso.Text) ||
                cbDestinoMezcladoTraspaso.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // verificar estado de tarima
            string idTarima = lbIdTarimaMezcladoTraspaso.Text;

            if (VerificarEstadoTarimaMezclado(idTarima))
            {
                MessageBox.Show("No se puede traspasar una tarima que está detenida.");
                return;
            }

            //String idTarima = lbIdTarima.Text;
            string producto = txtProductoMezcladoTraspaso.Text;
            string lote = txtLoteMezcladoTraspaso.Text;
            float cantidad = float.Parse(txtCantidadMezcladoTraspaso.Text);
            string tipoOperacion = "Traspaso";
            DateTime fechaOperacion = dtpFechaMezcladoTraspaso.Value;
            string destino = cbDestinoMezcladoTraspaso.SelectedItem.ToString();
            string usuario = lbNombreMezclado.Text;
            string departamento = lbDepartamentoMezclado.Text;

            // Verificar cantidad disponible
            float cantidadDisponible = ObtenerCantidadDisponible(idTarima);

            if (cantidad > cantidadDisponible)
            {
                MessageBox.Show("No hay suficiente inventario disponible para realizar el traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RegistrarTraspasoMezclado(idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento);
        }

        private void RegistrarTraspasoMezclado(string idTarima, string producto, string lote, float cantidad, string tipoOperacion, DateTime fechaOperacion, string destino, string usuario, string departamento)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            //using (MySqlConnection conexion = new MySqlConnection("your_connection_string"))
            {
                try
                {
                    con.Open();

                    // Actualizar cantidad disponible en recepcion_carne
                    string updateQuery = "UPDATE inventario_mezclado SET cantidad = cantidad - @cantidad WHERE idTarima = @idTarima";
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
                        INSERT INTO inventario_logistica 
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
                    CargarDatosTraspasosMezclado(); // Recargar datos del inventario después del traspaso
                    btnCancelarMezcladoTraspaso.Enabled = false;
                    btnMarcarDetenidoMezclado.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el traspaso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbIdTarimaMezcladoTraspaso.Text = "";
                txtProductoMezcladoTraspaso.Text = null;
                txtLoteMezcladoTraspaso.Text = null;
                txtCantidadMezcladoTraspaso.Text = null;
                cbDestinoMezcladoTraspaso.SelectedIndex = -1;
                dtpFechaMezcladoTraspaso.Value = DateTime.Now;

                CargarDatosInventarioTotalMezclado();
                //CargarDatosTraspasosMocha();
                CargarDatosDevolucionesMezclado();
            }
        }

        private float ObtenerCantidadDisponible(string idTarima)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT cantidad FROM inventario_mezclado WHERE idTarima = @idTarima";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idTarima", idTarima);

                    object result = cmd.ExecuteScalar();
                    if (result != null && float.TryParse(result.ToString(), out float cantidadDisponible))
                    {
                        return cantidadDisponible;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        private bool VerificarEstadoTarimaMezclado(string idTarima)
        {
            bool estaDetenida = false;
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "SELECT estado FROM inventario_mezclado WHERE idTarima = @idTarima";
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

        //---------------Movimientos pestaña devoluciones------------------------------------------------------------------------------------
        private void dgvTraspasosMezclado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvTraspasosMezclado.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    int idTrasp = Convert.ToInt16(fila.Cells["idTraspaso"].Value);
                    string id = fila.Cells["idTarima"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                    // Asignar los valores a los controles correspondientes
                    lbIdTraspasoMezcladoDv.Text = idTrasp.ToString();
                    lbIdTarimaMezcladoDv.Text = id;
                    txtProductoMezcladoDv.Text = producto;
                    txtLoteMezcladoDv.Text = lote;
                    txtCantidadMezcladoDv.Text = cantidad.ToString();
                    btnCancelarMezcladoDv.Enabled = true;
                    cbDestinoMezcladoDv.Text = "Mezclado";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTraspasoMezcladoDv.Text = "ID Traspaso";
                lbIdTarimaMezcladoDv.Text = "ID Tarima";
                txtProductoMezcladoDv.Text = null;
                txtLoteMezcladoDv.Text = null;
                txtCantidadMezcladoDv.Text = null;
                //cbDestinoMochaDv.SelectedIndex = -1;
                dtpFechaMezcladoDv.Value = DateTime.Now;
                btnCancelarMezcladoDv.Enabled = false;
                cbDestinoMezcladoDv.Text = "";
            }
        }

        private void btnCancelarMezcladoDv_Click(object sender, EventArgs e)
        {
            lbIdTraspasoMezcladoDv.Text = "ID Traspaso";
            lbIdTarimaMezcladoDv.Text = "ID Tarima";
            txtProductoMezcladoDv.Text = null;
            txtLoteMezcladoDv.Text = null;
            txtCantidadMezcladoDv.Text = null;
            cbDestinoMezcladoDv.SelectedIndex = -1;
            dtpFechaMezcladoDv.Value = DateTime.Now;
            cbDestinoMezcladoDv.Text = "";
            btnCancelarMezcladoDv.Enabled = false;
        }

        private void btnRegistrarMezcladoDv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoMezcladoDv.Text) ||
                string.IsNullOrEmpty(txtLoteMezcladoDv.Text) ||
                string.IsNullOrEmpty(txtCantidadMezcladoDv.Text) ||
                cbDestinoMezcladoDv.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                int idTraspaso = Convert.ToInt32(lbIdTraspasoMezcladoDv.Text);
                var (idTarima, producto, lote, cantidadOriginal) = ObtenerDetallesTraspaso(idTraspaso);

                if (string.IsNullOrEmpty(idTarima)) //podria ser idtraspaso, revisar escenarios
                {
                    MessageBox.Show("Traspaso no encontrado o no está activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                float cantidadDevolver = Convert.ToInt32(txtCantidadMezcladoDv.Text);

                if (cantidadDevolver > cantidadOriginal)
                {
                    MessageBox.Show("La cantidad a devolver es mayor que la cantidad del traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idEntradaLogistica = ObtenerIdEntradaLogistica(idTarima, producto, lote, cantidadOriginal); //debe de ser cantidad original

                if (idEntradaLogistica == 0)
                {
                    MessageBox.Show("Entrada de inventario no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string destino = "Mezclado";
                string tipoOperacion = "Devolucion";
                DateTime fechaOperacion = DateTime.Now;
                string usuario = lbNombreMezclado.Text;
                string departamento = lbDepartamentoMezclado.Text;

                using (ConexionBD conexionBD = new ConexionBD())
                {
                    MySqlConnection conexion = conexionBD.ObtenerConexion();
                    try
                    {
                        conexion.Open();

                        string consultaInsertar = "INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento, estado) VALUES (@idTarima, @producto, @lote, @cantidad, @tipoOperacion, @fechaOperacion, @destino, @usuario, @departamento, 'activo')";
                        MySqlCommand comandoInsertar = new MySqlCommand(consultaInsertar, conexion);
                        comandoInsertar.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoInsertar.Parameters.AddWithValue("@producto", producto);
                        comandoInsertar.Parameters.AddWithValue("@lote", lote);
                        comandoInsertar.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoInsertar.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);
                        comandoInsertar.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);
                        comandoInsertar.Parameters.AddWithValue("@destino", destino);
                        comandoInsertar.Parameters.AddWithValue("@usuario", usuario);
                        comandoInsertar.Parameters.AddWithValue("@departamento", departamento);
                        comandoInsertar.ExecuteNonQuery();

                        string consultaActualizarDevoluciones = "UPDATE salidas_devoluciones SET cantidad = cantidad - @cantidad WHERE idTraspaso = @idTraspaso";
                        MySqlCommand comandoActualizarDevoluciones = new MySqlCommand(consultaActualizarDevoluciones, conexion);
                        comandoActualizarDevoluciones.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarDevoluciones.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                        comandoActualizarDevoluciones.ExecuteNonQuery();

                        string consultaActualizarInventario = "UPDATE inventario_mezclado SET cantidad = cantidad + @cantidad WHERE idTarima = @idTarima";
                        MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
                        comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoActualizarInventario.ExecuteNonQuery();

                        string consultaActualizarMezclado = "UPDATE inventario_logistica SET cantidad = cantidad - @cantidad WHERE idEntradaLogistica = @idEntradaLogistica";
                        MySqlCommand comandoActualizarMezclado = new MySqlCommand(consultaActualizarMezclado, conexion);
                        comandoActualizarMezclado.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarMezclado.Parameters.AddWithValue("@idEntradaLogistica", idEntradaLogistica);
                        comandoActualizarMezclado.ExecuteNonQuery();
                        
                        // Verifica si la cantidad en el traspaso es igual a cero y anula el traspaso si es necesario
                        string consultaVerificarCantidad = "SELECT cantidad FROM salidas_devoluciones WHERE idTraspaso = @idTraspaso";
                        MySqlCommand comandoVerificarCantidad = new MySqlCommand(consultaVerificarCantidad, conexion);
                        comandoVerificarCantidad.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                        float cantidadRestante = Convert.ToSingle(comandoVerificarCantidad.ExecuteScalar());

                        if (cantidadRestante == 0)
                        {
                            string consultaAnular = "UPDATE salidas_devoluciones SET estado = 'anulado' WHERE idTraspaso = @idTraspaso";
                            MySqlCommand comandoAnular = new MySqlCommand(consultaAnular, conexion);
                            comandoAnular.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                            comandoAnular.ExecuteNonQuery();
                        }

                        // Elimina la entrada de inventario_mocha
                        string consultaEliminarMezclado = "DELETE FROM inventario_logistica WHERE idTarima = @idTarima AND cantidad = 0";
                        MySqlCommand comandoEliminarMezclado = new MySqlCommand(consultaEliminarMezclado, conexion);
                        comandoEliminarMezclado.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoEliminarMezclado.ExecuteNonQuery();

                        MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar la devolución: " + ex.Message);
                    }
                }

                // LIMPIAR CAMPOS
                lbIdTraspasoMezcladoDv.Text = null;
                lbIdTarimaMezcladoDv.Text = "";
                txtProductoMezcladoDv.Text = null;
                txtLoteMezcladoDv.Text = null;
                txtCantidadMezcladoDv.Text = null;
                cbDestinoMezcladoDv.SelectedIndex = -1;
                dtpFechaMezcladoDv.Value = DateTime.Now;
                CargarDatosDevolucionesMezclado(); // Recargar datos de traspasos después de la devolución
                CargarDatosTraspasosMezclado(); // Recargar datos del inventario después de la devolución
                CargarDatosInventarioTotalMezclado();
            }
            else
            {
                MessageBox.Show("No tienes permiso para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private (string idTarima, string producto, string lote, float cantidad) ObtenerDetallesTraspaso(int idTraspaso)
        {
            string idTarima = "";
            string producto = "";
            string lote = "";
            float cantidad = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                    SELECT idTarima, producto, lote, cantidad
                    FROM salidas_devoluciones
                    WHERE idTraspaso = @idTraspaso AND estado = 'activo' LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idTarima = reader.GetString("idTarima");
                                producto = reader.GetString("producto");
                                lote = reader.GetString("lote");
                                cantidad = reader.GetFloat("cantidad");
                            }
                        }
                    }
                }
            }
            return (idTarima, producto, lote, cantidad);
        }

        private int ObtenerIdEntradaLogistica(string idTarima, string producto, string lote, float cantidad)
        {
            int idEntradaLogistica = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                SELECT idEntradaLogistica
                FROM inventario_logistica
                WHERE idTarima = @idTarima AND producto = @producto AND lote = @lote AND cantidad = @cantidad LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idTarima", idTarima);
                        cmd.Parameters.AddWithValue("@producto", producto);
                        cmd.Parameters.AddWithValue("@lote", lote);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idEntradaLogistica = reader.GetInt32("idEntradaLogistica");
                            }
                        }
                    }
                }
            }
            return idEntradaLogistica;
        }

        //------ busqueda devoluciones------------------
        private void txtBusquedaMezcladoDv_Click(object sender, EventArgs e)
        {
            txtBusquedaMezcladoDv.Text = "";
            txtBusquedaMezcladoDv.ForeColor = Color.Black;
        }

        private void txtBusquedaMezcladoDv_GotFocus(object sender, EventArgs e)
        {
            if (txtBusquedaMezcladoDv.Text.Trim().Length == 0)
            {
                txtBusquedaMezcladoDv.Text = "";
                //txtBusquedaDevoGi.ForeColor = Color.Black;
            }
        }
        private void txtBusquedaMezcladoDv_LostFocus(object sender, EventArgs e)
        {
            if (txtBusquedaMezcladoDv.Text.Trim().Length == 0)
            {
                txtBusquedaMezcladoDv.Text = "DXXXXXXX";
                txtBusquedaMezcladoDv.ForeColor = Color.LightGray;
            }
        }

        private void BuscarYMostrarInformacionTraspDv()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtBusquedaMezcladoDv.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspDv(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspDv(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspDv(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvTraspasosMezclado.Rows.Count; i++)
            {
                try
                {
                    // Obtener el valor de la celda correspondiente a la columna de código de barras
                    string valorCelda = dgvTraspasosMezclado.Rows[i].Cells["idTarima"].Value.ToString();

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
            //MessageBox.Show("No se encontró codigo de barras");
        }

        private void MostrarInformacionEnCamposTraspDv(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvInventarioMezclado.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaMezcladoDv.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaLyfcDv = DateTime.Now;
                txtProductoMezcladoDv.Text = fila.Cells["producto"].Value.ToString();
                txtLoteMezcladoDv.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadMezcladoDv.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusquedaMezcladoDv_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtBusquedaMezcladoDv.Text = txtBusquedaMezcladoDv.Text.ToUpper();
                    Match match = regex.Match(txtBusquedaMezcladoDv.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBusquedaMezcladoDv.Text = "";
                    }
                    else
                    {
                        BuscarYMostrarInformacionTraspDv();
                        txtBusquedaMezcladoDv.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            
        }

        //--------------------------Detenidos--------------------------------------------------------
        private void btnMarcarDetenidoMezclado_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                if (dgvInventarioMezclado.SelectedRows.Count > 0)
                {
                    string idTarima = dgvInventarioMezclado.SelectedRows[0].Cells["idTarima"].Value.ToString();

                    if (EsTarimaDetenida(idTarima))
                    {
                        MessageBox.Show("La tarima ya está marcada como detenida.");
                        return;
                    }

                    MarcarTarimaComoDetenidaMezclado(idTarima);
                    MessageBox.Show("La tarima ha sido marcada como detenida.");
                    lbIdTarimaMezcladoTraspaso.Text = "ID Tarima";
                    dtpFechaMezcladoTraspaso.Value = DateTime.Now;
                    txtProductoMezcladoTraspaso.Text = "";
                    txtLoteMezcladoTraspaso.Text = "";
                    txtCantidadMezcladoTraspaso.Text = "";
                    cbDestinoMezcladoTraspaso.SelectedIndex = -1;
                    CargarDatosTraspasosMezclado(); // Recargar datos del inventario
                    CargarDatosDetenidosMezclado();
                }
                else
                {
                    MessageBox.Show("Seleccione una tarima para marcarla como detenida.");
                }
            }

            else
            {
                MessageBox.Show("No tienes permiso para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MarcarTarimaComoDetenidaMezclado(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE inventario_mezclado SET estado = 'detenido' WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento en salidas_devoluciones
                    string registrarMovimiento = @"
                    INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                    SELECT idTarima, producto, lote, cantidad, 'Detenido', NOW(), 'Mezclado', @usuario, @departamento
                    FROM inventario_mezclado WHERE idTarima = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreMezclado.Text); // el nombre del usuario con inicio de sesion
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoMezclado.Text); // el departamento de inicio de sesion
                    comandoMovimiento.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al marcar tarima como detenida: " + ex.Message);
                }
            }
        }

        private bool EsTarimaDetenida(string idTarima)
        {
            bool esDetenida = false;
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            try
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM inventario_mezclado WHERE idTarima = @idTarima AND estado = 'Detenido'";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idTarima", idTarima);
                esDetenida = Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar si la tarima está detenida: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            return esDetenida;
        }

        private void btnDesmarcarDetenidoMezclado_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                try
                {
                    if (dgvDetenidosMezclado.SelectedRows.Count > 0)
                    {
                        // Se obtiene el ID de la tarima seleccionada
                        string idTarima = dgvDetenidosMezclado.SelectedRows[0].Cells["idTarima"].Value.ToString();
                        // Desmarca la tarima detenida
                        DesmarcarTarimaComoDetenidaMezclado(idTarima);
                        //Muestra el mensaje de confirmacion
                        MessageBox.Show("La tarima ha sido desmarcada como detenida.");
                        // Recarga los datos del inventario y de tarimas detenidas
                        CargarDatosTraspasosMezclado();
                        CargarDatosDetenidosMezclado();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una tarima para desmarcarla como detenida.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Seleccione una tarima para desmarcarla como detenida.");
                }                
            }
            else
            {
                MessageBox.Show("No tienes permiso para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DesmarcarTarimaComoDetenidaMezclado(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE inventario_mezclado SET estado = 'activo' WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento de desbloqueo en salidas_devoluciones
                    string registrarMovimiento = @"
                INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                SELECT idTarima, producto, lote, cantidad, 'Desbloqueado', NOW(), 'Mezclado', @usuario, @departamento
                FROM inventario_mezclado WHERE idTarima = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreMezclado.Text); // Asume que tienes el nombre del usuario en lbNombreGi
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoMezclado.Text); // Asume que tienes el departamento en lbDepartamentoGi
                    comandoMovimiento.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desmarcar tarima como detenida: " + ex.Message);
                }
            }
        }

        private void pbCargarImagenMezclado_Click(object sender, EventArgs e)
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
                        pbLogoMezclado.Image = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}
