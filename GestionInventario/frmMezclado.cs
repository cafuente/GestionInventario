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
    public partial class frmMezclado : Form
    {
        private ConexionBD conexion; //obtener conexion
        public frmMezclado()
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            CargarDatosInventarioTotalMezclado();
            CargarDatosTraspasosMezclado();
            CargarDatosDevolucionesMezclado();
            CargarDatosDetenidosMezclado();
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
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreMezclado.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoMezclado.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilMezclado.Text = $"{nombrePerfil}";

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
            frmPrincipal frmPr = new frmPrincipal();
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
                txtCodigoBarrasMezcladoTraspaso.Text = "DXXXXXX";
                txtCodigoBarrasMezcladoTraspaso.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoBarrasMezcladoTraspaso_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoBarrasMezcladoTraspaso.Text = "";
                }
                else
                {
                    BuscarYMostrarInformacionTraspMezclado();
                    txtCodigoBarrasMezcladoTraspaso.Clear();
                }
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

            string idTarima = lbIdTarimaMezcladoDv.Text;
            if (VerificarEstadoTarimaMezclado(idTarima))
            {
                MessageBox.Show("No se puede devolver una tarima que está detenida.");
                return;
            }

            int idTraspaso = Convert.ToInt32(lbIdTraspasoMezcladoDv.Text);
            //String idTarima = lbIdTarimaDv.Text;
            string producto = txtProductoMezcladoDv.Text;
            string lote = txtLoteMezcladoDv.Text;
            float cantidad = Convert.ToInt32(txtCantidadMezcladoDv.Text);
            string destino = "Mezclado";
            string tipoOperacion = "Devolucion";
            DateTime fechaOperacion = DateTime.Now;
            //string fechaOperacion = dtpFechaDevolucion.Value.ToString("dd-MM-yyyy");
            string usuario = lbNombreMezclado.Text;
            string departamento = lbDepartamentoMezclado.Text;

            // Inserta la devolución en la tabla
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
                    comandoInsertar.Parameters.AddWithValue("@cantidad", cantidad);
                    comandoInsertar.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);
                    comandoInsertar.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);
                    comandoInsertar.Parameters.AddWithValue("@destino", destino);
                    comandoInsertar.Parameters.AddWithValue("@usuario", usuario);
                    comandoInsertar.Parameters.AddWithValue("@departamento", departamento);
                    comandoInsertar.ExecuteNonQuery();

                    // Marca el traspaso original como anulado
                    string consultaAnular = "UPDATE salidas_devoluciones SET estado = 'anulado' WHERE idTraspaso = @idTraspaso";
                    MySqlCommand comandoAnular = new MySqlCommand(consultaAnular, conexion);
                    comandoAnular.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                    comandoAnular.ExecuteNonQuery();

                    // Actualiza la cantidad disponible en la tabla inventario_mocha
                    string consultaActualizarInventario = "UPDATE inventario_mezclado SET cantidad = cantidad + @cantidad WHERE idTarima = @idTarima";
                    MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
                    comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidad);
                    comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoActualizarInventario.ExecuteNonQuery();

                    // Elimina la entrada de inventario_mezclado
                    string consultaEliminarLyfc = "DELETE FROM inventario_logistica WHERE idTarima = @idTarima";
                    MySqlCommand comandoEliminarLyfc = new MySqlCommand(consultaEliminarLyfc, conexion);
                    comandoEliminarLyfc.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoEliminarLyfc.ExecuteNonQuery();

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

        //--------------------------Detenidos--------------------------------------------------------
        private void btnMarcarDetenidoMezclado_Click(object sender, EventArgs e)
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
                    SELECT id, producto, lote, cantidad_disponible, 'Detenido', NOW(), 'Mezclado', @usuario, @departamento
                    FROM recepcion_carne WHERE id = @idTarima";
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
                SELECT id, producto, lote, cantidad_disponible, 'Desbloqueado', NOW(), 'Mezclado', @usuario, @departamento
                FROM recepcion_carne WHERE id = @idTarima";
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
    }
}
