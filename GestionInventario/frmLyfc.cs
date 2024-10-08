﻿using MySql.Data.MySqlClient;
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
    public partial class FrmLyfc : Form
    {
        private Usuario usuarioAutenticado;
        private ConexionBD conexion; //obtener conexion
        public FrmLyfc(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            usuarioAutenticado = usuario;
            CargarDatosInventarioTotalLyfc();
            CargarDatosTraspasosLyfc();
            CargarDatosDevolucionesLyfc();
            CargarDatosDetenidosLyfc();
            CargarDatosPendientesConfirmacion();
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
            btnCancelarLyfcDv.Enabled = false;
            dtpFechaLyfcTraspaso.Value = DateTime.Now;
            dtpFechaLyfcDv.Value = DateTime.Now;
            //marca de agua busqueda traspasos
            txtCodigoBarrasLyfcTraspaso.ForeColor = Color.LightGray;
            txtCodigoBarrasLyfcTraspaso.Text = "DXXXXXXX";
            txtCodigoBarrasLyfcTraspaso.GotFocus += new EventHandler(txtCodigoBarrasLyfcTraspaso_GotFocus);
            txtCodigoBarrasLyfcTraspaso.LostFocus += new EventHandler(txtCodigoBarrasLyfcTraspaso_LostFocus);
            // marca de agua busqueda devolucion
            txtBusquedaLyfcDv.ForeColor = Color.LightGray;
            txtBusquedaLyfcDv.Text = "DXXXXXXX";
            txtBusquedaLyfcDv.GotFocus += new EventHandler(txtBusquedaLyfcDv_GotFocus);
            txtBusquedaLyfcDv.LostFocus += new EventHandler(txtBusquedaLyfcDv_LostFocus);
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreLyfc.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoLyfc.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilLyfc.Text = $"{nombrePerfil}";

                // Crear instancia de UsuariosDAO
                UsuariosDAO usuariosDAO = new UsuariosDAO();

                // Cargar la imagen del usuario desde la base de datos
                byte[] imagenUsuario = usuariosDAO.ObtenerImagenUsuario(FrmLogin.UsuarioActual.IdUsuario);
                if (imagenUsuario != null && imagenUsuario.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenUsuario))
                    {
                        pbLogoLyfc.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbLogoLyfc.Image = Properties.Resources.user_account; // Imagen predeterminada
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

        private void frmLyfc_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmPr = new FrmPrincipal(FrmLogin.UsuarioActual);
            frmPr.Show();
        }

       //---- cargar datos de los datagrid inventario total
        private void CargarDatosInventarioTotalLyfc()
        {            
            dgvInventarioTotalLyfc.DataSource = BusquedaBD.ObtenerInventarioAgrupadoLyfc();                       
        }

        //datadrig de la pestaña traspasos
        private void CargarDatosTraspasosLyfc()
        {            
            dgvInventarioLyfc.DataSource = BusquedaBD.ObtenerInventarioLyfc();
        }

        //datagrid de la pestaña devoluciones
        private void CargarDatosDevolucionesLyfc()
        {
            dgvTraspasosLyfc.DataSource = BusquedaBD.ObtenerTraspasosLyfc();
        }

        //datagrid de la pestaña deteidos
        private void CargarDatosDetenidosLyfc()
        {
            dgvDetenidosLyfc.DataSource = BusquedaBD.ObtenerDetenidosLyfc();
        }

        // datagrid de la pestaña conciliacion
        private void CargarDatosPendientesConfirmacion()
        {            
            dgvPendientesConfirmacionLyfc.DataSource = BusquedaBD.ObtenerPendientesConfirmacionLyfc();
        }

        // ------- confirmar recepcion de tarima o combo
        private void btnConfirmarRecepcion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPendientesConfirmacionLyfc.SelectedRows.Count > 0)
                {
                    string idTarima = dgvPendientesConfirmacionLyfc.SelectedRows[0].Cells["idTarima"].Value.ToString();
                    ConfirmarRecepcionTarimaLyfc(idTarima);
                    MessageBox.Show("La recepción de la tarima ha sido confirmada de recibido.");
                    CargarDatosPendientesConfirmacion();
                    //CargarDatosInventarioLyfc(); // Actualizar la lista de tarimas confirmadas
                    CargarDatosInventarioTotalLyfc();
                    CargarDatosTraspasosLyfc();
                    CargarDatosDevolucionesLyfc();
                    CargarDatosDetenidosLyfc();
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

        private void ConfirmarRecepcionTarimaLyfc(string idTarima)
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            string usuario = lbNombreLyfc.Text;
            string departamento = lbDepartamentoLyfc.Text;
            try
            {
                conexion.Open();
                string consulta = "UPDATE inventario_lyfc SET estado_confirmacion = 'Recibido' WHERE idTarima = @idTarima";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idTarima", idTarima);
                comando.ExecuteNonQuery();

                // Obtener detalles de la tarima
                consulta = "SELECT producto, lote, cantidad FROM inventario_lyfc WHERE idTarima = @idTarima";
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
                    comando.Parameters.AddWithValue("@destino", "LyFC(traslado)");  // Asume que el destino es LyFC
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
        //-------------Codigo pestaña traspasos------------------------------------------------------------------------------------

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
                txtCodigoBarrasLyfcTraspaso.Text = "DXXXXXXX";
                txtCodigoBarrasLyfcTraspaso.ForeColor = Color.LightGray;
            }
        }

        private void txtCodigoBarrasLyfcTraspaso_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
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
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
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
                try
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
                catch (Exception)
                {
                    return -1;
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
                MessageBox.Show("No se encontró ningún combo o tarima con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-----------------------------------------------------------------------

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

            // Verificar cantidad disponible
            float cantidadDisponible = ObtenerCantidadDisponible(idTarima);

            if (cantidad > cantidadDisponible)
            {
                MessageBox.Show("No hay suficiente inventario disponible para realizar el traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                CargarDatosDevolucionesLyfc();
            }
        }

        private float ObtenerCantidadDisponible(string idTarima)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT cantidad FROM inventario_lyfc WHERE idTarima = @idTarima";
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

        //--------------Movimientos pestaña devoluciones------------------------------------------------------------------------------------

        //--------datagrid devoluciones
        private void dgvTraspasosLyfc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvTraspasosLyfc.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    int idTrasp = Convert.ToInt16(fila.Cells["idTraspaso"].Value);
                    string id = fila.Cells["idTarima"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                    // Asignar los valores a los controles correspondientes
                    lbIdTraspasoLyfcDv.Text = idTrasp.ToString();
                    lbIdTarimaLyfcDv.Text = id;
                    txtProductoLyfcDv.Text = producto;
                    txtLoteLyfcDv.Text = lote;
                    txtCantidadLyfcDv.Text = cantidad.ToString();
                    btnCancelarLyfcDv.Enabled = true;                    
                    cbDestinoLyfcDv.Text = "LyFC(traslado)";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTraspasoLyfcDv.Text = "ID Traspaso";
                lbIdTarimaLyfcDv.Text = "ID Tarima";
                txtProductoLyfcDv.Text = null;
                txtLoteLyfcDv.Text = null;
                txtCantidadLyfcDv.Text = null;
                cbDestinoLyfcDv.SelectedIndex = -1;
                dtpFechaLyfcDv.Value = DateTime.Now;
                btnCancelarLyfcDv.Enabled = false;                
            }
        }

        private void btnCancelarLyfcDv_Click(object sender, EventArgs e)
        {
            lbIdTraspasoLyfcDv.Text = "ID Traspaso";
            lbIdTarimaLyfcDv.Text = "ID Tarima";
            txtProductoLyfcDv.Text = null;
            txtLoteLyfcDv.Text = null;
            txtCantidadLyfcDv.Text = null;
            cbDestinoLyfcDv.SelectedIndex = -1;
            dtpFechaLyfcDv.Value = DateTime.Now;
            cbDestinoLyfcDv.Text = "";
            btnCancelarLyfcDv.Enabled = false;
        }

        //---- metodo para devoluciones
        public static int ObtenerInventarioDisponiblePorTarima(string idTarima)
        {
            int cantidadDisponible = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = "SELECT cantidad FROM inventario_mocha WHERE idTarima = @idTarima";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idTarima", idTarima);

                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            cantidadDisponible = Convert.ToInt32(result);
                        }
                    }
                }
            }
            return cantidadDisponible;
        }

        private void btnRegistrarLyfcDv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoLyfcDv.Text) ||
                string.IsNullOrEmpty(txtLoteLyfcDv.Text) ||
                string.IsNullOrEmpty(txtCantidadLyfcDv.Text) ||
                cbDestinoLyfcDv.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                int idTraspaso = Convert.ToInt32(lbIdTraspasoLyfcDv.Text);
                var (idTarima, producto, lote, cantidadOriginal) = ObtenerDetallesTraspaso(idTraspaso);

                if (string.IsNullOrEmpty(idTarima)) //podria ser idtraspaso, revisar escenarios
                {
                    MessageBox.Show("Traspaso no encontrado o no está activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                float cantidadDevolver = Convert.ToInt32(txtCantidadLyfcDv.Text);

                if (cantidadDevolver > cantidadOriginal)
                {
                    MessageBox.Show("La cantidad a devolver es mayor que la cantidad del traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idEntradaMocha = ObtenerIdEntradaMocha(idTarima, producto, lote, cantidadOriginal); //debe de ser cantidad original

                if (idEntradaMocha == 0)
                {
                    MessageBox.Show("Entrada de inventario no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string destino = "LyFC(traslado)";
                string tipoOperacion = "Devolucion";
                DateTime fechaOperacion = DateTime.Now;
                string usuario = lbNombreLyfc.Text;
                string departamento = lbDepartamentoLyfc.Text;

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

                        string consultaActualizarInventario = "UPDATE inventario_lyfc SET cantidad = cantidad + @cantidad WHERE idTarima = @idTarima";
                        MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
                        comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoActualizarInventario.ExecuteNonQuery();

                        string consultaActualizarLyfc = "UPDATE inventario_mocha SET cantidad = cantidad - @cantidad WHERE idEntradaMocha = @idEntradaMocha";
                        MySqlCommand comandoActualizarLyfc = new MySqlCommand(consultaActualizarLyfc, conexion);
                        comandoActualizarLyfc.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarLyfc.Parameters.AddWithValue("@idEntradaMocha", idEntradaMocha);
                        comandoActualizarLyfc.ExecuteNonQuery();

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
                        string consultaEliminarLyfc = "DELETE FROM inventario_mocha WHERE idTarima = @idTarima AND cantidad = 0";
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
                lbIdTraspasoLyfcDv.Text = null;
                lbIdTarimaLyfcDv.Text = "";
                txtProductoLyfcDv.Text = null;
                txtLoteLyfcDv.Text = null;
                txtCantidadLyfcDv.Text = null;
                cbDestinoLyfcDv.SelectedIndex = -1;
                dtpFechaLyfcDv.Value = DateTime.Now;
                CargarDatosDevolucionesLyfc(); // Recargar datos de traspasos después de la devolución
                CargarDatosTraspasosLyfc(); // Recargar datos del inventario después de la devolución
                CargarDatosInventarioTotalLyfc();
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

        private int ObtenerIdEntradaMocha(string idTarima, string producto, string lote, float cantidad)
        {
            int idEntradaMocha = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                SELECT idEntradaMocha
                FROM inventario_mocha
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
                                idEntradaMocha = reader.GetInt32("idEntradaMocha");
                            }
                        }
                    }
                }
            }
            return idEntradaMocha;
        }

        //------ busqueda devoluciones------------------
        private void txtBusquedaLyfcDv_Click(object sender, EventArgs e)
        {
            txtBusquedaLyfcDv.Text = "";
            txtBusquedaLyfcDv.ForeColor = Color.Black;
        }
        private void txtBusquedaLyfcDv_GotFocus(object sender, EventArgs e)
        {
            if (txtBusquedaLyfcDv.Text.Trim().Length == 0)
            {
                txtBusquedaLyfcDv.Text = "";
                //txtBusquedaDevoGi.ForeColor = Color.Black;
            }
        }
        private void txtBusquedaLyfcDv_LostFocus(object sender, EventArgs e)
        {
            if (txtBusquedaLyfcDv.Text.Trim().Length == 0)
            {
                txtBusquedaLyfcDv.Text = "DXXXXXXX";
                txtBusquedaLyfcDv.ForeColor = Color.LightGray;
            }
        }

        private void BuscarYMostrarInformacionTraspDv()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtBusquedaLyfcDv.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspDv(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspDv(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspDv(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvTraspasosLyfc.Rows.Count; i++)
            {
                try
                {
                    // Obtener el valor de la celda correspondiente a la columna de código de barras
                    string valorCelda = dgvTraspasosLyfc.Rows[i].Cells["idTarima"].Value.ToString();

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
                DataGridViewRow fila = dgvInventarioLyfc.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaLyfcDv.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaLyfcDv = DateTime.Now;
                txtProductoLyfcDv.Text = fila.Cells["producto"].Value.ToString();
                txtLoteLyfcDv.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadLyfcDv.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusquedaLyfcDv_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtBusquedaLyfcDv.Text = txtBusquedaLyfcDv.Text.ToUpper();
                    Match match = regex.Match(txtBusquedaLyfcDv.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBusquedaLyfcDv.Text = "";
                    }
                    else
                    {
                        BuscarYMostrarInformacionTraspDv();
                        txtBusquedaLyfcDv.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }            
        }

        //-----------------------------------------------

        //--------------Movimientos pestaña detenidos------------------------------------------------------------------------------------
        
        private void btnMarcarDetenidoLyfc_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                if (dgvInventarioLyfc.SelectedRows.Count > 0)
                {
                    string idTarima = dgvInventarioLyfc.SelectedRows[0].Cells["idTarima"].Value.ToString();

                    if (EsTarimaDetenida(idTarima))
                    {
                        MessageBox.Show("La tarima ya está marcada como detenida.");
                        return;
                    }

                    MarcarTarimaComoDetenidaLyfc(idTarima);
                    MessageBox.Show("La tarima ha sido marcada como detenida.");
                    lbIdTarimaLyfcTraspaso.Text = "ID Tarima";
                    dtpFechaLyfcTraspaso.Value = DateTime.Now;
                    txtProductoLyfcTraspaso.Text = "";
                    txtLoteLyfcTraspaso.Text = "";
                    txtCantidadLyfcTraspaso.Text = "";
                    cbDestinoLyfcTraspaso.SelectedIndex = -1;
                    CargarDatosTraspasosLyfc(); // Recargar datos del inventario
                    CargarDatosDetenidosLyfc();
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

        private void MarcarTarimaComoDetenidaLyfc(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE inventario_lyfc SET estado = 'detenido' WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento en salidas_devoluciones
                    string registrarMovimiento = @"
                    INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                    SELECT idTarima, producto, lote, cantidad, 'detenido', NOW(), 'LyFC(traslado)', @usuario, @departamento
                    FROM inventario_lyfc WHERE idTarima = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreLyfc.Text); // el nombre del usuario con inicio de sesion
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoLyfc.Text); // el departamento de inicio de sesion
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
                string consulta = "SELECT COUNT(*) FROM inventario_lyfc WHERE idTarima = @idTarima AND estado = 'Detenido'";
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

        private void btnDesmarcarDetenidoLyfc_Click(object sender, EventArgs e)
        {            
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                try
                {
                    if (dgvDetenidosLyfc.SelectedRows.Count > 0)
                {
                    // Se obtiene el ID de la tarima seleccionada
                    string idTarima = dgvDetenidosLyfc.SelectedRows[0].Cells["idTarima"].Value.ToString();
                    // Desmarca la tarima detenida
                    DesmarcarTarimaComoDetenidaLyfc(idTarima);
                    //Muestra el mensaje de confirmacion
                    MessageBox.Show("La tarima ha sido desmarcada como detenida.");
                    // Recarga los datos del inventario y de tarimas detenidas
                    CargarDatosTraspasosLyfc();
                    CargarDatosDetenidosLyfc();
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

        private void DesmarcarTarimaComoDetenidaLyfc(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE inventario_lyfc SET estado = 'activo' WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento de desbloqueo en salidas_devoluciones
                    string registrarMovimiento = @"
                INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                SELECT idTarima, producto, lote, cantidad, 'Desbloqueado', NOW(), 'LyFC(traslado)', @usuario, @departamento
                FROM inventario_lyfc WHERE idTarima = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreLyfc.Text); // Asume que tienes el nombre del usuario en lbNombreGi
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoLyfc.Text); // Asume que tienes el departamento en lbDepartamentoGi
                    comandoMovimiento.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desmarcar tarima como detenida: " + ex.Message);
                }
            }
        }

        private void pbCargarImagenLyfc_Click(object sender, EventArgs e)
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
                        pbLogoLyfc.Image = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}
