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
    public partial class FrmMocha : Form
    {
        private Usuario usuarioAutenticado;
        private ConexionBD conexion; //obtener conexion
        public FrmMocha(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD(); //obtener conexion
            usuarioAutenticado = usuario;
            CargarDatosInventarioTotalMocha();
            CargarDatosTraspasosMocha();
            CargarDatosDevolucionesMocha();
            CargarDatosDetenidosMocha();
            CargarDatosPendientesConfirmacionMocha();
        }

        private void frmMocha_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            // Define los departamentos para realizar los traspasos
            string[] destino = { "Mezclado", "Recibo(Mocha)" };
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
            txtCodigoBarrasMochaTraspaso.Text = "DXXXXXXX";
            txtCodigoBarrasMochaTraspaso.GotFocus += new EventHandler(txtCodigoBarrasMochaTraspaso_GotFocus);
            txtCodigoBarrasMochaTraspaso.LostFocus += new EventHandler(txtCodigoBarrasMochaTraspaso_LostFocus);
            // marca de agua busqueda devolucion
            txtBusquedaMochaDv.ForeColor = Color.LightGray;
            txtBusquedaMochaDv.Text = "DXXXXXXX";
            txtBusquedaMochaDv.GotFocus += new EventHandler(txtBusquedaMochaDv_GotFocus);
            txtBusquedaMochaDv.LostFocus += new EventHandler(txtBusquedaMochaDv_LostFocus);
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreMocha.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoMocha.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilLyfc.Text = $"{nombrePerfil}";

                // Crear instancia de UsuariosDAO
                UsuariosDAO usuariosDAO = new UsuariosDAO();

                // Cargar la imagen del usuario desde la base de datos
                byte[] imagenUsuario = usuariosDAO.ObtenerImagenUsuario(FrmLogin.UsuarioActual.IdUsuario);
                if (imagenUsuario != null && imagenUsuario.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenUsuario))
                    {
                        pbLogoMocha.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbLogoMocha.Image = Properties.Resources.user_account; // Imagen predeterminada
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

        private void frmMocha_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmPr = new FrmPrincipal(FrmLogin.UsuarioActual);
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

        // datagrid de la pestaña conciliacion
        private void CargarDatosPendientesConfirmacionMocha()
        {
            dgvPendientesConfirmacionMocha.DataSource = BusquedaBD.ObtenerPendientesConfirmacionMocha();
        }

        // ------- confirmar recepcion de tarima o combo-------------------------------------
        private void btnConfirmarRecepcionMocha_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPendientesConfirmacionMocha.SelectedRows.Count > 0)
                {
                    string idTarima = dgvPendientesConfirmacionMocha.SelectedRows[0].Cells["idTarima"].Value.ToString();
                    ConfirmarRecepcionTarimaMocha(idTarima);
                    MessageBox.Show("La recepción de la tarima ha sido confirmada de recibido.");
                    CargarDatosPendientesConfirmacionMocha();
                    //CargarDatosInventarioLyfc(); // Actualizar la lista de tarimas confirmadas
                    CargarDatosInventarioTotalMocha();
                    CargarDatosTraspasosMocha();
                    CargarDatosDevolucionesMocha();
                    CargarDatosDetenidosMocha();
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

        private void ConfirmarRecepcionTarimaMocha(string idTarima)
        {
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            string usuario = lbNombreMocha.Text;
            string departamento = lbDepartamentoMocha.Text;
            try
            {
                conexion.Open();
                string consulta = "UPDATE inventario_mocha SET estado_confirmacion = 'Recibido' WHERE idTarima = @idTarima";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idTarima", idTarima);
                comando.ExecuteNonQuery();

                // Obtener detalles de la tarima
                consulta = "SELECT producto, lote, cantidad FROM inventario_mocha WHERE idTarima = @idTarima";
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
                    comando.Parameters.AddWithValue("@destino", "Recibo(Mocha)");  
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
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
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
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
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

        //-----------------Registro traspaso------------------------------------------------------
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

            // Verificar cantidad disponible
            float cantidadDisponible = ObtenerCantidadDisponible(idTarima);

            if (cantidad > cantidadDisponible)
            {
                MessageBox.Show("No hay suficiente inventario disponible para realizar el traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

        private float ObtenerCantidadDisponible(string idTarima)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();

                string query = "SELECT cantidad FROM inventario_mocha WHERE idTarima = @idTarima";
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
        
        //---------------Movimientos pestaña devoluciones--------------------------------------------------------------------------------------
        private void dgvTraspasosMocha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvTraspasosMocha.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    int idTrasp = Convert.ToInt16(fila.Cells["idTraspaso"].Value);
                    string id = fila.Cells["idTarima"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad = Convert.ToSingle(fila.Cells["Cantidad"].Value);

                    // Asignar los valores a los controles correspondientes
                    lbIdTraspasoMochaDv.Text = idTrasp.ToString();
                    lbIdTarimaMochaDv.Text = id;
                    txtProductoMochaDv.Text = producto;
                    txtLoteMochaDv.Text = lote;
                    txtCantidadMochaDv.Text = cantidad.ToString();
                    btnCancelarMochaDv.Enabled = true;
                    cbDestinoMochaDv.Text = "Recibo(Mocha)";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTraspasoMochaDv.Text = "ID Traspaso";
                lbIdTarimaMochaDv.Text = "ID Tarima";
                txtProductoMochaDv.Text = null;
                txtLoteMochaDv.Text = null;
                txtCantidadMochaDv.Text = null;
                //cbDestinoMochaDv.SelectedIndex = -1;
                dtpFechaMochaDv.Value = DateTime.Now;
                btnCancelarMochaDv.Enabled = false;
                cbDestinoMochaDv.Text = "";
            }
        }

        private void btnCancelarMochaDv_Click(object sender, EventArgs e)
        {
            lbIdTraspasoMochaDv.Text = "ID Traspaso";
            lbIdTarimaMochaDv.Text = "ID Tarima";
            txtProductoMochaDv.Text = null;
            txtLoteMochaDv.Text = null;
            txtCantidadMochaDv.Text = null;
            cbDestinoMochaDv.SelectedIndex = -1;
            dtpFechaMochaDv.Value = DateTime.Now;
            cbDestinoMochaDv.Text = "";
            btnCancelarMochaDv.Enabled = false;
        }

        private void btnRegistrarMochaDv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductoMochaDv.Text) ||
                string.IsNullOrEmpty(txtLoteMochaDv.Text) ||
                string.IsNullOrEmpty(txtCantidadMochaDv.Text) ||
                cbDestinoMochaDv.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                int idTraspaso = Convert.ToInt32(lbIdTraspasoMochaDv.Text);
                var (idTarima, producto, lote, cantidadOriginal) = ObtenerDetallesTraspaso(idTraspaso);

                if (string.IsNullOrEmpty(idTarima)) //podria ser idtraspaso, revisar escenarios
                {
                    MessageBox.Show("Traspaso no encontrado o no está activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                float cantidadDevolver = Convert.ToInt32(txtCantidadMochaDv.Text);

                if (cantidadDevolver > cantidadOriginal)
                {
                    MessageBox.Show("La cantidad a devolver es mayor que la cantidad del traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idEntradaMezclado = ObtenerIdEntradaMezclado(idTarima, producto, lote, cantidadOriginal); //debe de ser cantidad original

                if (idEntradaMezclado == 0)
                {
                    MessageBox.Show("Entrada de inventario no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string destino = "Recibo(mocha)";
                string tipoOperacion = "Devolucion";
                DateTime fechaOperacion = DateTime.Now;
                string usuario = lbNombreMocha.Text;
                string departamento = lbDepartamentoMocha.Text;

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

                        string consultaActualizarInventario = "UPDATE inventario_mocha SET cantidad = cantidad + @cantidad WHERE idTarima = @idTarima";
                        MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
                        comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoActualizarInventario.ExecuteNonQuery();

                        string consultaActualizarMocha = "UPDATE inventario_mezclado SET cantidad = cantidad - @cantidad WHERE idEntradaMezclado = @idEntradaMezclado";
                        MySqlCommand comandoActualizarMocha = new MySqlCommand(consultaActualizarMocha, conexion);
                        comandoActualizarMocha.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarMocha.Parameters.AddWithValue("@idEntradaMezclado", idEntradaMezclado);
                        comandoActualizarMocha.ExecuteNonQuery();

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
                        string consultaEliminarMocha = "DELETE FROM inventario_mezclado WHERE idTarima = @idTarima AND cantidad = 0";
                        MySqlCommand comandoEliminarMocha = new MySqlCommand(consultaEliminarMocha, conexion);
                        comandoEliminarMocha.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoEliminarMocha.ExecuteNonQuery();

                        MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar la devolución: " + ex.Message);
                    }
                }

                // LIMPIAR CAMPOS
                lbIdTraspasoMochaDv.Text = null;
                lbIdTarimaMochaDv.Text = "";
                txtProductoMochaDv.Text = null;
                txtLoteMochaDv.Text = null;
                txtCantidadMochaDv.Text = null;
                cbDestinoMochaDv.SelectedIndex = -1;
                dtpFechaMochaDv.Value = DateTime.Now;
                CargarDatosDevolucionesMocha(); // Recargar datos de traspasos después de la devolución
                CargarDatosTraspasosMocha(); // Recargar datos del inventario después de la devolución
                CargarDatosInventarioTotalMocha();
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

        private int ObtenerIdEntradaMezclado(string idTarima, string producto, string lote, float cantidad)
        {
            int idEntradaMezclado = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                SELECT idEntradaMezclado
                FROM inventario_mezclado
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
                                idEntradaMezclado = reader.GetInt32("idEntradaMezclado");
                            }
                        }
                    }
                }
            }
            return idEntradaMezclado;
        }

        //------ busqueda devoluciones------------------
        private void txtBusquedaMochaDv_Click(object sender, EventArgs e)
        {
            txtBusquedaMochaDv.Text = "";
            txtBusquedaMochaDv.ForeColor = Color.Black;
        }

        private void txtBusquedaMochaDv_GotFocus(object sender, EventArgs e)
        {
            if (txtBusquedaMochaDv.Text.Trim().Length == 0)
            {
                txtBusquedaMochaDv.Text = "";
                //txtBusquedaDevoGi.ForeColor = Color.Black;
            }
        }
        private void txtBusquedaMochaDv_LostFocus(object sender, EventArgs e)
        {
            if (txtBusquedaMochaDv.Text.Trim().Length == 0)
            {
                txtBusquedaMochaDv.Text = "DXXXXXXX";
                txtBusquedaMochaDv.ForeColor = Color.LightGray;
            }
        }

        private void BuscarYMostrarInformacionTraspDv()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtBusquedaMochaDv.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTraspDv(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTraspDv(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTraspDv(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvTraspasosMocha.Rows.Count; i++)
            {
                try
                {
                    // Obtener el valor de la celda correspondiente a la columna de código de barras
                    string valorCelda = dgvTraspasosMocha.Rows[i].Cells["idTarima"].Value.ToString();

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
                DataGridViewRow fila = dgvInventarioMocha.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarimaMochaDv.Text = fila.Cells["idTarima"].Value.ToString();
                DateTime dtpFechaLyfcDv = DateTime.Now;
                txtProductoMochaDv.Text = fila.Cells["producto"].Value.ToString();
                txtLoteMochaDv.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadMochaDv.Text = fila.Cells["cantidad"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusquedaMochaDv_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtBusquedaMochaDv.Text = txtBusquedaMochaDv.Text.ToUpper();
                    Match match = regex.Match(txtBusquedaMochaDv.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBusquedaMochaDv.Text = "";
                    }
                    else
                    {
                        BuscarYMostrarInformacionTraspDv();
                        txtBusquedaMochaDv.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            
        }

        //-----------------------detenidos-----------------------------------------------------------
        private void btnMarcarDetenidoMocha_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                if (dgvInventarioMocha.SelectedRows.Count > 0)
                {
                    string idTarima = dgvInventarioMocha.SelectedRows[0].Cells["idTarima"].Value.ToString();

                    if (EsTarimaDetenida(idTarima))
                    {
                        MessageBox.Show("La tarima ya está marcada como detenida.");
                        return;
                    }

                    MarcarTarimaComoDetenidaMocha(idTarima);
                    MessageBox.Show("La tarima ha sido marcada como detenida.");
                    lbIdTarimaMochaTraspaso.Text = "ID Tarima";
                    dtpFechaMochaTraspaso.Value = DateTime.Now;
                    txtProductoMochaTraspaso.Text = "";
                    txtLoteMochaTraspaso.Text = "";
                    txtCantidadMochaTraspaso.Text = "";
                    cbDestinoMochaTraspaso.SelectedIndex = -1;
                    CargarDatosTraspasosMocha(); // Recargar datos del inventario
                    CargarDatosDetenidosMocha();
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

        private void MarcarTarimaComoDetenidaMocha(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE inventario_mocha SET estado = 'detenido' WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento en salidas_devoluciones
                    string registrarMovimiento = @"
                    INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                    SELECT idTarima, producto, lote, cantidad, 'detenido', NOW(), 'Recibo(Mocha)', @usuario, @departamento
                    FROM inventario_mocha WHERE idTarima = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreMocha.Text); // el nombre del usuario con inicio de sesion
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoMocha.Text); // el departamento de inicio de sesion
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
                string consulta = "SELECT COUNT(*) FROM inventario_mocha WHERE idTarima = @idTarima AND estado = 'Detenido'";
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

        private void btnDesmarcarDetenidoMocha_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Usuario" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                try
                {
                    if (dgvDetenidosMocha.SelectedRows.Count > 0)
                    {
                        // Se obtiene el ID de la tarima seleccionada
                        string idTarima = dgvDetenidosMocha.SelectedRows[0].Cells["idTarima"].Value.ToString();
                        // Desmarca la tarima detenida
                        DesmarcarTarimaComoDetenidaMocha(idTarima);
                        //Muestra el mensaje de confirmacion
                        MessageBox.Show("La tarima ha sido desmarcada como detenida.");
                        // Recarga los datos del inventario y de tarimas detenidas
                        CargarDatosTraspasosMocha();
                        CargarDatosDetenidosMocha();
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

        private void DesmarcarTarimaComoDetenidaMocha(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE inventario_mocha SET estado = 'activo' WHERE idTarima = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento de desbloqueo en salidas_devoluciones
                    string registrarMovimiento = @"
                INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                SELECT idTarima, producto, lote, cantidad, 'Desbloqueado', NOW(), 'Recibo(Mocha)', @usuario, @departamento
                FROM inventario_mocha WHERE idTarima = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreMocha.Text); // Asume que tienes el nombre del usuario en lbNombreGi
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoMocha.Text); // Asume que tienes el departamento en lbDepartamentoGi
                    comandoMovimiento.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desmarcar tarima como detenida: " + ex.Message);
                }
            }
        }

        private void pbCargarImagenMocha_Click(object sender, EventArgs e)
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
                        pbLogoMocha.Image = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}
