using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class FrmGestionInventario : Form
    {
        private Usuario usuarioAutenticado;
        private ConexionBD conexion;
        public FrmGestionInventario(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD();
            usuarioAutenticado = usuario;
            CargarDatosInventario();
            CargarDatosInventarioTotal();
            CargarDatosTraspasos();
            CargarDatosDetenidos();
        }

        private void frmGestionInventario_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();            
            // Se define los departamentos para realizar los traspasos
            string[] destino = { "LyFC(traslado)", "Almacen carnicos"};
            // Agrega los departamentos al ComboBox
            cbDestinoGi.Items.AddRange(destino); 
            cbDestinoDv.Items.AddRange(destino);
            btnCancelarGi.Enabled = false;
            btnMarcarDetenido.Enabled = false;
            btnCancelar.Enabled = false;            
            dtpFechaGi.Value = DateTime.Now;
            dtpFechaDevolucion.Value = DateTime.Now;
            txtBusquedaDevoGi.ForeColor = Color.LightGray;
            txtBusquedaDevoGi.Text = "DXXXXXXX";
            txtBusquedaDevoGi.GotFocus += new EventHandler(txtBusquedaDevoGi_GotFocus);
            txtBusquedaDevoGi.LostFocus += new EventHandler(txtBusquedaDevoGi_LostFocus);
            txtCodigoBarrasGi.ForeColor = Color.LightGray;
            txtCodigoBarrasGi.Text = "DXXXXXXX";
            txtCodigoBarrasGi.GotFocus += new EventHandler(txtCodigoBarrasGi_GotFocus);
            txtCodigoBarrasGi.LostFocus += new EventHandler(txtCodigoBarrasGi_LostFocus);
            
        }
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreGi.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoGi.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilGi.Text = $"{nombrePerfil}";

                // Crear instancia de UsuariosDAO
                UsuariosDAO usuariosDAO = new UsuariosDAO();

                // Cargar la imagen del usuario desde la base de datos
                byte[] imagenUsuario = usuariosDAO.ObtenerImagenUsuario(FrmLogin.UsuarioActual.IdUsuario);
                if (imagenUsuario != null && imagenUsuario.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenUsuario))
                    {
                        pbLogoGi.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbLogoGi.Image = Properties.Resources.user_account; // Imagen predeterminada
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

        private void CargarDatosInventarioTotal()
        {
            dgvInventarioTotal.DataSource = BusquedaBD.ObtenerInventarioAgrupado();            
        }

        private void CargarDatosTraspasos()
        {
            dgvTraspasos.DataSource = BusquedaBD.ObtenerTraspasos();
        }

        private void CargarDatosDetenidos()
        {
            dgvDetenidos.DataSource = BusquedaBD.ObtenerTarimasDetenidas();
        }

        private void CargarDatosInventario()
        {
            // llena datagrid de pestaña traspasos
            DataTable dt = BusquedaBD.ObtenerInventario();
            dgvInventario.DataSource = dt;            

            foreach (DataGridViewColumn columna in dgvInventario.Columns)
            {
                //columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void frmGestionInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmPr = new FrmPrincipal(FrmLogin.UsuarioActual);
            frmPr.Show();
        }                

        private void btnRegistrarTraspasoGi_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(txtProductoGi.Text) ||
                string.IsNullOrEmpty(txtLoteGi.Text) ||
                string.IsNullOrEmpty(txtCantidadGi.Text) ||
                cbDestinoGi.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // verificar estado de tarima
            string idTarima = lbIdTarima.Text;

            if (VerificarEstadoTarima(idTarima))
            {
                MessageBox.Show("No se puede traspasar una tarima que está detenida.");
                return;
            }

            //String idTarima = lbIdTarima.Text;
            string producto = txtProductoGi.Text;
            string lote = txtLoteGi.Text;
            float cantidad = float.Parse(txtCantidadGi.Text);
            string tipoOperacion = "Traspaso";
            DateTime fechaOperacion = dtpFechaGi.Value;
            string destino = cbDestinoGi.SelectedItem.ToString();
            string usuario = lbNombreGi.Text;
            string departamento = lbDepartamentoGi.Text;

            RegistrarTraspaso(idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento);
        }

        private void RegistrarTraspaso(string idTarima, string producto, string lote, float cantidad, string tipoOperacion, DateTime fechaOperacion, string destino, string usuario, string departamento)
        {
            using (MySqlConnection con = conexion.ObtenerConexion())
            //using (MySqlConnection conexion = new MySqlConnection("your_connection_string"))
            {
                try
                {
                    con.Open();

                    // Actualizar cantidad disponible en recepcion_carne
                    string updateQuery = "UPDATE recepcion_carne SET cantidad_disponible = cantidad_disponible - @cantidad WHERE id = @idTarima";
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
                    // se inserta la cantidad al inventario de lyfc
                    string insertLyfcQuery = @"
                        INSERT INTO inventario_lyfc 
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
                    CargarDatosInventario(); // Recargar datos del inventario después del traspaso
                    btnCancelarGi.Enabled = false;
                    btnMarcarDetenido.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el traspaso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbIdTarima.Text = "";
                txtProductoGi.Text = null;
                txtLoteGi.Text = null;
                txtCantidadGi.Text = null;
                cbDestinoGi.SelectedIndex = -1;
                dtpFechaGi.Value = DateTime.Now;

                CargarDatosInventarioTotal();
                CargarDatosTraspasos();
            }
        }

        private void btnCancelarGi_Click(object sender, EventArgs e)
        {
            lbIdTarima.Text = "ID Tarima";
            txtProductoGi.Text = null;
            txtLoteGi.Text = null;
            txtCantidadGi.Text = null;
            cbDestinoGi.SelectedIndex = -1;
            dtpFechaGi.Value = DateTime.Now;
            btnCancelarGi.Enabled = false;
            btnMarcarDetenido.Enabled = false;
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvInventario.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    string id = fila.Cells["Id"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    float cantidad_disponible = Convert.ToSingle(fila.Cells["Cantidad_disponible"].Value);
                    
                    // Asignar los valores a los controles correspondientes
                    lbIdTarima.Text = id;
                    txtProductoGi.Text = producto;
                    txtLoteGi.Text = lote;
                    txtCantidadGi.Text = cantidad_disponible.ToString();
                    cbDestinoGi.Text = "LyFC(traslado)";
                    btnCancelarGi.Enabled = true;
                    btnMarcarDetenido.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTarima.Text = "ID Tarima";
                txtProductoGi.Text = null;
                txtLoteGi.Text = null;
                txtCantidadGi.Text = null;
                cbDestinoGi.SelectedIndex = -1;
                dtpFechaGi.Value = DateTime.Now;
                btnCancelarGi.Enabled = false;
                btnMarcarDetenido.Enabled = false;
            }
            
        }

        //DATAGRID DE PESTAÑA DEVOLUCIONES
        private void dgvTraspasos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTraspasos.Rows[e.RowIndex];
                lbIdTraspasoDv.Text = row.Cells["idTraspaso"].Value.ToString();
                lbIdTarimaDv.Text = row.Cells["idTarima"].Value.ToString();
                txtProductoDv.Text = row.Cells["producto"].Value.ToString();
                txtLoteDv.Text = row.Cells["lote"].Value.ToString();
                txtCantidadDv.Text = row.Cells["cantidad"].Value.ToString();
                cbDestinoDv.Text = "Almacen carnicos";
                btnCancelar.Enabled = true;
                btnRegistrarDevolucion.Enabled = true;
            }
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
                    string query = "SELECT cantidad FROM inventario_lyfc WHERE idTarima = @idTarima";
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

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtProductoDv.Text) ||
            //    string.IsNullOrEmpty(txtLoteDv.Text) ||
            //    string.IsNullOrEmpty(txtCantidadDv.Text) ||
            //    cbDestinoDv.SelectedItem == null)
            //{
            //    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            //{
            //    string idTarima = lbIdTarimaDv.Text;
            //    if (VerificarEstadoTarima(idTarima))
            //    {
            //        MessageBox.Show("No se puede devolver una tarima que está detenida.");
            //        return;
            //    }

            //    string producto = txtProductoDv.Text;
            //    string lote = txtLoteDv.Text;
            //    float cantidad = Convert.ToInt32(txtCantidadDv.Text);

            //    // Verificar inventario disponible
            //    int inventarioDisponible = ObtenerInventarioDisponiblePorTarima(idTarima);
            //    if (cantidad > inventarioDisponible)
            //    {
            //        MessageBox.Show("No hay suficiente inventario disponible para realizar la devolución.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    // Obtener idEntradaLyfc correspondiente (aquí debe haber algún mecanismo para obtener el idEntradaLyfc)
            //    int idEntradaLyfc = ObtenerIdEntradaLyfc(producto, lote, cantidad); // Este método debe implementarse

            //    int idTraspaso = Convert.ToInt32(lbIdTraspasoDv.Text);                       
            //    //float cantidad = Convert.ToInt32(txtCantidadDv.Text);
            //    string destino = "Almacen carnicos";
            //    string tipoOperacion = "Devolucion";
            //    DateTime fechaOperacion = DateTime.Now;
            //    //string fechaOperacion = dtpFechaDevolucion.Value.ToString("dd-MM-yyyy");
            //    string usuario = lbNombreGi.Text;
            //    string departamento = lbDepartamentoGi.Text;

            //    // Inserta la devolución en la tabla
            //    using (ConexionBD conexionBD = new ConexionBD())
            //    {
            //        MySqlConnection conexion = conexionBD.ObtenerConexion();
            //        try
            //        {
            //            conexion.Open();
            //            string consultaInsertar = "INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento, estado) VALUES (@idTarima, @producto, @lote, @cantidad, @tipoOperacion, @fechaOperacion, @destino, @usuario, @departamento, 'activo')";
            //            MySqlCommand comandoInsertar = new MySqlCommand(consultaInsertar, conexion);
            //            comandoInsertar.Parameters.AddWithValue("@idTarima", idTarima);
            //            comandoInsertar.Parameters.AddWithValue("@producto", producto);
            //            comandoInsertar.Parameters.AddWithValue("@lote", lote);
            //            comandoInsertar.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoInsertar.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);
            //            comandoInsertar.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);
            //            comandoInsertar.Parameters.AddWithValue("@destino", destino);
            //            comandoInsertar.Parameters.AddWithValue("@usuario", usuario);
            //            comandoInsertar.Parameters.AddWithValue("@departamento", departamento);
            //            comandoInsertar.ExecuteNonQuery();

            //            // Verificar cantidad restante del traspaso original
            //            string consultaCantidadTraspaso = "SELECT cantidad FROM salidas_devoluciones WHERE idTraspaso = @idTraspaso";
            //            MySqlCommand comandoCantidadTraspaso = new MySqlCommand(consultaCantidadTraspaso, conexion);
            //            comandoCantidadTraspaso.Parameters.AddWithValue("@idTraspaso", idTraspaso);
            //            object result = comandoCantidadTraspaso.ExecuteScalar();
            //            float cantidadTraspasoOriginal = Convert.ToSingle(result);

            //            float cantidadRestante = cantidadTraspasoOriginal - cantidad;

            //            // Marca el traspaso original como anulado si la cantidad restante es 0
            //            if (cantidadRestante <= 0)
            //            {
            //                string consultaAnular = "UPDATE salidas_devoluciones SET estado = 'anulado' WHERE idTraspaso = @idTraspaso";
            //                MySqlCommand comandoAnular = new MySqlCommand(consultaAnular, conexion);
            //                comandoAnular.Parameters.AddWithValue("@idTraspaso", idTraspaso);
            //                comandoAnular.ExecuteNonQuery();
            //            }
            //            else
            //            {
            //                // Actualiza la cantidad en el traspaso original
            //                string consultaActualizarTraspaso = "UPDATE salidas_devoluciones SET cantidad = @cantidadRestante WHERE idTraspaso = @idTraspaso";
            //                MySqlCommand comandoActualizarTraspaso = new MySqlCommand(consultaActualizarTraspaso, conexion);
            //                comandoActualizarTraspaso.Parameters.AddWithValue("@cantidadRestante", cantidadRestante);
            //                comandoActualizarTraspaso.Parameters.AddWithValue("@idTraspaso", idTraspaso);
            //                comandoActualizarTraspaso.ExecuteNonQuery();
            //            }
            //            /*
            //            // Obtener cantidad del traspaso original
            //            string consultaCantidadTraspaso = "SELECT cantidad FROM salidas_devoluciones WHERE idTraspaso = @idEntradaLyfc AND estado != 'anulado'";
            //            MySqlCommand comandoCantidadTraspaso = new MySqlCommand(consultaCantidadTraspaso, conexion);
            //            comandoCantidadTraspaso.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //            object result = comandoCantidadTraspaso.ExecuteScalar();
            //            float cantidadTraspasoOriginal = Convert.ToSingle(result);

            //            float cantidadRestante = cantidadTraspasoOriginal - cantidad;

            //            // Marca el traspaso original como anulado si la cantidad restante es 0
            //            if (cantidadRestante <= 0)
            //            {
            //                string consultaAnular = "UPDATE salidas_devoluciones SET estado = 'anulado' WHERE idTraspaso = @idEntradaLyfc";
            //                MySqlCommand comandoAnular = new MySqlCommand(consultaAnular, conexion);
            //                comandoAnular.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //                comandoAnular.ExecuteNonQuery();
            //            }
            //            else
            //            {
            //                // Actualiza la cantidad en el traspaso original
            //                string consultaActualizarTraspaso = "UPDATE salidas_devoluciones SET cantidad = @cantidadRestante WHERE idTraspaso = @idEntradaLyfc AND estado != 'anulado'";
            //                MySqlCommand comandoActualizarTraspaso = new MySqlCommand(consultaActualizarTraspaso, conexion);
            //                comandoActualizarTraspaso.Parameters.AddWithValue("@cantidadRestante", cantidadRestante);
            //                comandoActualizarTraspaso.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //                comandoActualizarTraspaso.ExecuteNonQuery();
            //            }*/

            //            // Actualiza la cantidad disponible en la tabla recepcion_carne
            //            string consultaActualizarInventario = "UPDATE recepcion_carne SET cantidad_disponible = cantidad_disponible + @cantidad WHERE id = @idTarima";
            //            MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
            //            comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
            //            comandoActualizarInventario.ExecuteNonQuery();

            //            //// Actualiza la cantidad en la tabla inventario_lyfc en lugar de eliminar
            //            //string consultaActualizarLyfc = "UPDATE inventario_lyfc SET cantidad = cantidad - @cantidad WHERE idTarima = @idTarima";
            //            //MySqlCommand comandoActualizarLyfc = new MySqlCommand(consultaActualizarLyfc, conexion);
            //            //comandoActualizarLyfc.Parameters.AddWithValue("@cantidad", cantidad);
            //            //comandoActualizarLyfc.Parameters.AddWithValue("@idTarima", idTarima);
            //            //comandoActualizarLyfc.ExecuteNonQuery();

            //            // Actualiza la cantidad en la tabla inventario_lyfc
            //            string consultaActualizarLyfc = "UPDATE inventario_lyfc SET cantidad = cantidad - @cantidad WHERE idEntradaLyfc = @idEntradaLyfc";
            //            MySqlCommand comandoActualizarLyfc = new MySqlCommand(consultaActualizarLyfc, conexion);
            //            comandoActualizarLyfc.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoActualizarLyfc.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //            comandoActualizarLyfc.ExecuteNonQuery();


            //            //// Elimina la entrada de inventario_lyfc
            //            //string consultaEliminarLyfc = "DELETE FROM inventario_lyfc WHERE idTarima = @idTarima AND cantidad = 0";
            //            //MySqlCommand comandoEliminarLyfc = new MySqlCommand(consultaEliminarLyfc, conexion);
            //            //comandoEliminarLyfc.Parameters.AddWithValue("@idTarima", idTarima);
            //            //comandoEliminarLyfc.ExecuteNonQuery();

            //            //MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            // Elimina la entrada de inventario_lyfc si la cantidad restante es cero
            //            /*if (cantidadRestante <= 0)
            //            {
            //                string consultaEliminarLyfc = "DELETE FROM inventario_lyfc WHERE idTarima = @idTarima";
            //                MySqlCommand comandoEliminarLyfc = new MySqlCommand(consultaEliminarLyfc, conexion);
            //                comandoEliminarLyfc.Parameters.AddWithValue("@idTarima", idTarima);
            //                comandoEliminarLyfc.ExecuteNonQuery();
            //            }*/

            //            // Elimina la entrada de inventario_lyfc si la cantidad restante es cero
            //            string consultaCantidadLyfc = "SELECT cantidad FROM inventario_lyfc WHERE idEntradaLyfc = @idEntradaLyfc";
            //            MySqlCommand comandoCantidadLyfc = new MySqlCommand(consultaCantidadLyfc, conexion);
            //            comandoCantidadLyfc.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //            object resultLyfc = comandoCantidadLyfc.ExecuteScalar();
            //            if (Convert.ToInt32(resultLyfc) <= 0)
            //            {
            //                string consultaEliminarLyfc = "DELETE FROM inventario_lyfc WHERE idEntradaLyfc = @idEntradaLyfc";
            //                MySqlCommand comandoEliminarLyfc = new MySqlCommand(consultaEliminarLyfc, conexion);
            //                comandoEliminarLyfc.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //                comandoEliminarLyfc.ExecuteNonQuery();
            //            }

            //            MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error al registrar la devolución: " + ex.Message);
            //        }
            //    }
            //    // LIMPIAR CAMPOS
            //    lbIdTraspasoDv.Text = null;
            //    lbIdTarimaDv.Text = "";
            //    txtProductoDv.Text = null;
            //    txtLoteDv.Text = null;
            //    txtCantidadDv.Text = null;
            //    cbDestinoDv.SelectedIndex = -1;
            //    dtpFechaDevolucion.Value = DateTime.Now;
            //    CargarDatosTraspasos(); // Recargar datos de traspasos después de la devolución
            //    CargarDatosInventario(); // Recargar datos del inventario después de la devolución
            //    CargarDatosInventarioTotal(); // Recargar datos del inventario despues de la devolución
            //}
            //else
            //{
            //    MessageBox.Show("No tienes permiso para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            ////-------------------------- desde aqui funciona todo bien----------------------
            //if (string.IsNullOrEmpty(txtProductoDv.Text) ||
            //    string.IsNullOrEmpty(txtLoteDv.Text) ||
            //    string.IsNullOrEmpty(txtCantidadDv.Text) ||
            //    cbDestinoDv.SelectedItem == null)
            //{
            //    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            //{
            //    string idTarima = lbIdTarimaDv.Text;
            //    if (VerificarEstadoTarima(idTarima))
            //    {
            //        MessageBox.Show("No se puede devolver una tarima que está detenida.");
            //        return;
            //    }

            //    string producto = txtProductoDv.Text;
            //    string lote = txtLoteDv.Text;
            //    float cantidad = Convert.ToInt32(txtCantidadDv.Text);

            //    // Verificar inventario disponible
            //    int inventarioDisponible = ObtenerInventarioDisponible(producto, lote);
            //    if (cantidad > inventarioDisponible)
            //    {
            //        MessageBox.Show("No hay suficiente inventario disponible para realizar la devolución.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    int idTraspaso = Convert.ToInt32(lbIdTraspasoDv.Text);
            //    string destino = "Almacen carnicos";
            //    string tipoOperacion = "Devolucion";
            //    DateTime fechaOperacion = DateTime.Now;
            //    string usuario = lbNombreGi.Text;
            //    string departamento = lbDepartamentoGi.Text;

            //    // Inserta la devolución en la tabla
            //    using (ConexionBD conexionBD = new ConexionBD())
            //    {
            //        MySqlConnection conexion = conexionBD.ObtenerConexion();
            //        try
            //        {
            //            conexion.Open();

            //            // Obtener el idEntradaLyfc correspondiente
            //            int idEntradaLyfc = ObtenerIdEntradaLyfc(producto, lote, cantidad);

            //            string consultaInsertar = "INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento, estado) VALUES (@idTarima, @producto, @lote, @cantidad, @tipoOperacion, @fechaOperacion, @destino, @usuario, @departamento, 'activo')";
            //            MySqlCommand comandoInsertar = new MySqlCommand(consultaInsertar, conexion);
            //            comandoInsertar.Parameters.AddWithValue("@idTarima", idTarima);
            //            comandoInsertar.Parameters.AddWithValue("@producto", producto);
            //            comandoInsertar.Parameters.AddWithValue("@lote", lote);
            //            comandoInsertar.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoInsertar.Parameters.AddWithValue("@tipoOperacion", tipoOperacion);
            //            comandoInsertar.Parameters.AddWithValue("@fechaOperacion", fechaOperacion);
            //            comandoInsertar.Parameters.AddWithValue("@destino", destino);
            //            comandoInsertar.Parameters.AddWithValue("@usuario", usuario);
            //            comandoInsertar.Parameters.AddWithValue("@departamento", departamento);
            //            comandoInsertar.ExecuteNonQuery();

            //            // Actualiza la cantidad en la tabla salidas_devoluciones
            //            string consultaActualizarDevoluciones = "UPDATE salidas_devoluciones SET cantidad = cantidad - @cantidad WHERE idTraspaso = @idTraspaso";
            //            MySqlCommand comandoActualizarDevoluciones = new MySqlCommand(consultaActualizarDevoluciones, conexion);
            //            comandoActualizarDevoluciones.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoActualizarDevoluciones.Parameters.AddWithValue("@idTraspaso", idTraspaso);
            //            comandoActualizarDevoluciones.ExecuteNonQuery();

            //            // Actualiza la cantidad disponible en la tabla recepcion_carne
            //            string consultaActualizarInventario = "UPDATE recepcion_carne SET cantidad_disponible = cantidad_disponible + @cantidad WHERE id = @idTarima";
            //            MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
            //            comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
            //            comandoActualizarInventario.ExecuteNonQuery();

            //            // Actualiza la cantidad en la tabla inventario_lyfc
            //            string consultaActualizarLyfc = "UPDATE inventario_lyfc SET cantidad = cantidad - @cantidad WHERE idEntradaLyfc = @idEntradaLyfc";
            //            MySqlCommand comandoActualizarLyfc = new MySqlCommand(consultaActualizarLyfc, conexion);
            //            comandoActualizarLyfc.Parameters.AddWithValue("@cantidad", cantidad);
            //            comandoActualizarLyfc.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
            //            comandoActualizarLyfc.ExecuteNonQuery();

            //            MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Error al registrar la devolución: " + ex.Message);
            //        }
            //    }
            //    // LIMPIAR CAMPOS
            //    lbIdTraspasoDv.Text = null;
            //    lbIdTarimaDv.Text = "";
            //    txtProductoDv.Text = null;
            //    txtLoteDv.Text = null;
            //    txtCantidadDv.Text = null;
            //    cbDestinoDv.SelectedIndex = -1;
            //    dtpFechaDevolucion.Value = DateTime.Now;
            //    CargarDatosTraspasos(); // Recargar datos de traspasos después de la devolución
            //    CargarDatosInventario(); // Recargar datos del inventario después de la devolución
            //    CargarDatosInventarioTotal(); // Recargar datos del inventario después de la devolución
            //}
            //else
            //{
            //    MessageBox.Show("No tienes permiso para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            ////-----------------hasta aqui funciona todo bien con los metodos marcados con 1 --------------------------

            if (string.IsNullOrEmpty(txtProductoDv.Text) ||
                string.IsNullOrEmpty(txtLoteDv.Text) ||
                string.IsNullOrEmpty(txtCantidadDv.Text) ||
                cbDestinoDv.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                int idTraspaso = Convert.ToInt32(lbIdTraspasoDv.Text);
                var (idTarima, producto, lote, cantidadOriginal) = ObtenerDetallesTraspaso(idTraspaso);

                if (string.IsNullOrEmpty(idTarima)) //podria ser idtraspaso, revisar escenarios
                {
                    MessageBox.Show("Traspaso no encontrado o no está activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                float cantidadDevolver = Convert.ToInt32(txtCantidadDv.Text);

                if (cantidadDevolver > cantidadOriginal)
                {
                    MessageBox.Show("La cantidad a devolver es mayor que la cantidad del traspaso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idEntradaLyfc = ObtenerIdEntradaLyfc(idTarima, producto, lote, cantidadOriginal); //debe de ser cantidad original

                if (idEntradaLyfc == 0)
                {
                    MessageBox.Show("Entrada de inventario no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string destino = "Almacen carnicos";
                string tipoOperacion = "Devolucion";
                DateTime fechaOperacion = DateTime.Now;
                string usuario = lbNombreGi.Text;
                string departamento = lbDepartamentoGi.Text;

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

                        string consultaActualizarInventario = "UPDATE recepcion_carne SET cantidad_disponible = cantidad_disponible + @cantidad WHERE id = @idTarima";
                        MySqlCommand comandoActualizarInventario = new MySqlCommand(consultaActualizarInventario, conexion);
                        comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarInventario.Parameters.AddWithValue("@idTarima", idTarima);
                        comandoActualizarInventario.ExecuteNonQuery();

                        string consultaActualizarLyfc = "UPDATE inventario_lyfc SET cantidad = cantidad - @cantidad WHERE idEntradaLyfc = @idEntradaLyfc";
                        MySqlCommand comandoActualizarLyfc = new MySqlCommand(consultaActualizarLyfc, conexion);
                        comandoActualizarLyfc.Parameters.AddWithValue("@cantidad", cantidadDevolver);
                        comandoActualizarLyfc.Parameters.AddWithValue("@idEntradaLyfc", idEntradaLyfc);
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

                        MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar la devolución: " + ex.Message);
                    }
                }

                // LIMPIAR CAMPOS
                lbIdTraspasoDv.Text = null;
                lbIdTarimaDv.Text = "";
                txtProductoDv.Text = null;
                txtLoteDv.Text = null;
                txtCantidadDv.Text = null;
                cbDestinoDv.SelectedIndex = -1;
                dtpFechaDevolucion.Value = DateTime.Now;
                CargarDatosTraspasos(); // Recargar datos de traspasos después de la devolución
                CargarDatosInventario(); // Recargar datos del inventario después de la devolución
                CargarDatosInventarioTotal(); // Recargar datos del inventario después de la devolución
            }
            else
            {
                MessageBox.Show("No tienes permiso para realizar esta acción.", "Permiso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        ////------------- con este metodo 1 ---------------------------------------------
        //public static int ObtenerInventarioDisponible(string producto, string lote)
        //{
        //    int cantidadDisponible = 0;

        //    using (ConexionBD conexionBD = new ConexionBD())
        //    {
        //        using (MySqlConnection con = conexionBD.ObtenerConexion())
        //        {
        //            con.Open();
        //            string query = "SELECT SUM(cantidad) AS cantidad FROM inventario_lyfc WHERE producto = @producto AND lote = @lote";
        //            using (MySqlCommand cmd = new MySqlCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("@producto", producto);
        //                cmd.Parameters.AddWithValue("@lote", lote);

        //                object result = cmd.ExecuteScalar();
        //                if (result != DBNull.Value)
        //                {
        //                    cantidadDisponible = Convert.ToInt32(result);
        //                }
        //            }
        //        }
        //    }
        //    return cantidadDisponible;
        //}


        //private int ObtenerIdEntradaLyfc(string producto, string lote, float cantidad)
        //{
        //    int idEntradaLyfc = 0;
        //    using (ConexionBD conexionBD = new ConexionBD())
        //    {
        //        using (MySqlConnection con = conexionBD.ObtenerConexion())
        //        {
        //            con.Open();
        //            string query = "SELECT idEntradaLyfc FROM inventario_lyfc WHERE producto = @producto AND lote = @lote AND cantidad >= @cantidad LIMIT 1";
        //            using (MySqlCommand cmd = new MySqlCommand(query, con))
        //            {
        //                cmd.Parameters.AddWithValue("@producto", producto);
        //                cmd.Parameters.AddWithValue("@lote", lote);
        //                cmd.Parameters.AddWithValue("@cantidad", cantidad);
        //                object result = cmd.ExecuteScalar();
        //                if (result != DBNull.Value)
        //                {
        //                    idEntradaLyfc = Convert.ToInt32(result);
        //                }
        //            }
        //        }
        //    }
        //    return idEntradaLyfc;
        //}
        ////------------------------------

        //// ---------------------------- hasta aqui con estos 2 metodos -----------------------

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

        private int ObtenerIdEntradaLyfc(string idTarima, string producto, string lote, float cantidad)
        {
            int idEntradaLyfc = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = @"
                SELECT idEntradaLyfc
                FROM inventario_lyfc
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
                                idEntradaLyfc = reader.GetInt32("idEntradaLyfc");
                            }
                        }
                    }
                }
            }
            return idEntradaLyfc;
        }


        public static int ObtenerInventarioDisponible(string producto, string lote)
        {
            int cantidadDisponible = 0;

            using (ConexionBD conexionBD = new ConexionBD())
            {
                using (MySqlConnection con = conexionBD.ObtenerConexion())
                {
                    con.Open();
                    string query = "SELECT SUM(cantidad) AS cantidad FROM inventario_lyfc WHERE producto = @producto AND lote = @lote";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@producto", producto);
                        cmd.Parameters.AddWithValue("@lote", lote);

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


        //limpiar campos devoluciones
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lbIdTraspasoDv.Text = "ID Traspaso";
            lbIdTarimaDv.Text = "ID Tarima";
            txtProductoDv.Text = null;
            txtLoteDv.Text = null;
            txtCantidadDv.Text = null;
            cbDestinoDv.SelectedIndex = -1;
            dtpFechaDevolucion.Value = DateTime.Now;
            btnCancelar.Enabled= false;            
        }

        private void txtBusquedaDevoGi_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtBusquedaDevoGi.Text = txtBusquedaDevoGi.Text.ToUpper();
                    Match match = regex.Match(txtBusquedaDevoGi.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBusquedaDevoGi.Clear();
                    }
                    else
                    {
                        BuscarYMostrarInformacionDev();
                        txtBusquedaDevoGi.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                lbIdTraspasoDv.Text = "ID Traspaso";
                lbIdTarimaDv.Text = "ID Tarima";
                txtProductoDv.Text = null;
                txtLoteDv.Text = null;
                txtCantidadDv.Text = null;
                cbDestinoDv.SelectedIndex = -1;
                dtpFechaDevolucion.Value = DateTime.Now;
                txtBusquedaDevoGi.Clear();
            }            
        }

        private void BuscarYMostrarInformacionDev()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtBusquedaDevoGi.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasDev(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCampos(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasDev(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvTraspasos.Rows.Count; i++)
            {
                // Obtener el valor de la celda correspondiente a la columna de código de barras
                string valorCelda = dgvTraspasos.Rows[i].Cells["idTarima"].Value.ToString();

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

        private void MostrarInformacionEnCampos(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvTraspasos.Rows[indiceFila];

                // Mostrar la información en los campos del formulario
                lbIdTraspasoDv.Text = fila.Cells["idTraspaso"].Value.ToString();
                lbIdTarimaDv.Text = fila.Cells["idTarima"].Value.ToString();
                dtpFechaDevolucion.Text = fila.Cells["fechaOperacion"].Value.ToString();
                txtProductoDv.Text = fila.Cells["producto"].Value.ToString();
                txtLoteDv.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadDv.Text = fila.Cells["cantidad"].Value.ToString();
                cbDestinoDv.Text = "Almacen carnicos";                
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ningún artículo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void txtBusquedaDevoGi_Click(object sender, EventArgs e)
        {
            txtBusquedaDevoGi.Text = "";
            txtBusquedaDevoGi.ForeColor = Color.Black;
        }

        private void txtBusquedaDevoGi_GotFocus(object sender, EventArgs e)
        {
            if (txtBusquedaDevoGi.Text.Trim().Length == 0)
            {
                txtBusquedaDevoGi.Text = "";
                //txtBusquedaDevoGi.ForeColor = Color.Black;
            }
        }
        private void txtBusquedaDevoGi_LostFocus(object sender, EventArgs e)
        {
            if (txtBusquedaDevoGi.Text.Trim().Length == 0)
            {
                txtBusquedaDevoGi.Text = "DXXXXXXX";
                txtBusquedaDevoGi.ForeColor = Color.LightGray;                
            }
        }

        // busqueda en pestaña traspasos
        private void txtCodigoBarrasGi_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Regex regex = new Regex(@"^D\d{7}$");
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    txtCodigoBarrasGi.Text = txtCodigoBarrasGi.Text.ToUpper();
                    Match match = regex.Match(txtCodigoBarrasGi.Text);
                    if (!match.Success)
                    {
                        // Mostrar mensaje de error
                        MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCodigoBarrasGi.Text = "";
                    }
                    else
                    {
                        BuscarYMostrarInformacionTrasp();
                        txtCodigoBarrasGi.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);                
            }
            lbIdTarima.Text = "ID Tarima";
            txtProductoGi.Text = null;
            txtLoteGi.Text = null;
            txtCantidadGi.Text = null;
            cbDestinoGi.SelectedIndex = -1;
            dtpFechaGi.Value = DateTime.Now;
            txtCodigoBarrasGi.Clear();
        }

        private void BuscarYMostrarInformacionTrasp()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtCodigoBarrasGi.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarrasTrasp(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCamposTrasp(indiceFila);
        }

        private int BuscarFilaPorCodigoBarrasTrasp(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgvInventario.Rows.Count; i++)
            {
                // Obtener el valor de la celda correspondiente a la columna de código de barras
                string valorCelda = dgvInventario.Rows[i].Cells["id"].Value.ToString();

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

        private void MostrarInformacionEnCamposTrasp(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgvInventario.Rows[indiceFila];

                // Mostrar la información en los campos del formulario                
                lbIdTarima.Text = fila.Cells["id"].Value.ToString();
                DateTime dtpFechaGi = DateTime.Now;
                txtProductoGi.Text = fila.Cells["producto"].Value.ToString();
                txtLoteGi.Text = fila.Cells["lote"].Value.ToString();
                txtCantidadGi.Text = fila.Cells["cantidad_disponible"].Value.ToString();
                //cbDestinoDv.Text = "Almacen";
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ningún artículo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoBarrasGi_Click(object sender, EventArgs e)
        {
            txtCodigoBarrasGi.Text = "";
            txtCodigoBarrasGi.ForeColor = Color.Black;
        }

        private void txtCodigoBarrasGi_GotFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasGi.Text.Trim().Length == 0)
            {
                txtCodigoBarrasGi.Text = "";
                //txtBusquedaDevoGi.ForeColor = Color.Black;
            }
        }
        private void txtCodigoBarrasGi_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigoBarrasGi.Text.Trim().Length == 0)
            {
                txtCodigoBarrasGi.Text = "DXXXXXXX";
                txtCodigoBarrasGi.ForeColor = Color.LightGray;
            }
        }

        // detenidos
        private void btnMarcarDetenido_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre=="Administrador")
            {
                if (dgvInventario.SelectedRows.Count > 0)
                {
                    string idTarima = dgvInventario.SelectedRows[0].Cells["id"].Value.ToString();

                    if (EsTarimaDetenida(idTarima))
                    {
                        MessageBox.Show("La tarima ya está marcada como detenida.");
                        return;
                    }

                    MarcarTarimaComoDetenida(idTarima);
                    MessageBox.Show("La tarima ha sido marcada como detenida.");
                    lbIdTarima.Text = "ID Tarima";
                    dtpFechaGi.Value = DateTime.Now;
                    txtProductoGi.Text = "";
                    txtLoteGi.Text = "";
                    txtCantidadGi.Text = "";
                    cbDestinoGi.SelectedIndex = -1;
                    CargarDatosInventario(); // Recargar datos del inventario
                    CargarDatosDetenidos();
                    
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

        private void MarcarTarimaComoDetenida(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE recepcion_carne SET estado = 'detenido' WHERE id = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento en salidas_devoluciones
                    string registrarMovimiento = @"
                INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                SELECT id, producto, lote, cantidad_disponible, 'Detenido', NOW(), 'Almacen', @usuario, @departamento
                FROM recepcion_carne WHERE id = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreGi.Text); // el nombre del usuario de lbNombreGi
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoGi.Text); // el departamento de lbDepartamentoGi
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
                string consulta = "SELECT COUNT(*) FROM recepcion_carne WHERE id = @idTarima AND estado = 'Detenido'";
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

        private void btnDesmarcarDetenido_Click(object sender, EventArgs e)
        {
            if (usuarioAutenticado.PerfilNombre == "Supervisor" || usuarioAutenticado.PerfilNombre == "Administrador")
            {
                try
                {
                    if (dgvDetenidos.SelectedRows.Count > 0)
                    {
                        // Se obtiene el ID de la tarima seleccionada
                        string idTarima = dgvDetenidos.SelectedRows[0].Cells["id"].Value.ToString();
                        // Desmarca la tarima detenida
                        DesmarcarTarimaComoDetenida(idTarima);
                        //Muestra el mensaje de confirmacion
                        MessageBox.Show("La tarima ha sido desmarcada como detenida.");
                        // Recarga los datos del inventario y de tarimas detenidas
                        CargarDatosInventario();
                        CargarDatosDetenidos();
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

        private void DesmarcarTarimaComoDetenida(string idTarima)
        {
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "UPDATE recepcion_carne SET estado = 'activo' WHERE id = @idTarima";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@idTarima", idTarima);
                    comando.ExecuteNonQuery();

                    // Registrar el movimiento de desbloqueo en salidas_devoluciones
                    string registrarMovimiento = @"
                INSERT INTO salidas_devoluciones (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento)
                SELECT id, producto, lote, cantidad_disponible, 'Desbloqueado', NOW(), 'Almacen', @usuario, @departamento
                FROM recepcion_carne WHERE id = @idTarima";
                    MySqlCommand comandoMovimiento = new MySqlCommand(registrarMovimiento, conexion);
                    comandoMovimiento.Parameters.AddWithValue("@idTarima", idTarima);
                    comandoMovimiento.Parameters.AddWithValue("@usuario", lbNombreGi.Text); // Asume que tienes el nombre del usuario en lbNombreGi
                    comandoMovimiento.Parameters.AddWithValue("@departamento", lbDepartamentoGi.Text); // Asume que tienes el departamento en lbDepartamentoGi
                    comandoMovimiento.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desmarcar tarima como detenida: " + ex.Message);
                }
            }
        }
        // detenidos
        private bool VerificarEstadoTarima(string idTarima)
        {
            bool estaDetenida = false;
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    string consulta = "SELECT estado FROM recepcion_carne WHERE id = @idTarima";
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
                
        private void pbCargarImagenGi_Click(object sender, EventArgs e)
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
                        pbLogoGi.Image = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}

