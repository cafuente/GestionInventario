using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class frmGestionInventario : Form
    {
        private ConexionBD conexion;
        public frmGestionInventario()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            CargarDatosInventario();
            CargarDatosInventarioTotal();
            CargarDatosTraspasos();

        }

        private void frmGestionInventario_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            //dtpFechaGi.Value = DateTime.Now;
            // Define los departamentos para realizar los traspasos
            string[] destino = { "LyFC(traslado)" };
            // Agrega los departamentos al ComboBox
            cbDestinoGi.Items.AddRange(destino); 
            cbDestinoDv.Items.AddRange(destino);
        }
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreGi.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoGi.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilGi.Text = $"{nombrePerfil}";

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

        private void frmGestionInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }

        private void CargarDatosInventario()
        {
            DataTable dt = BusquedaBD.ObtenerInventario();
            dgvInventario.DataSource = dt;

            foreach (DataGridViewColumn columna in dgvInventario.Columns)
            {
                //columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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

            String idTarima = lbIdTarima.Text;
            string producto = txtProductoGi.Text;
            string lote = txtLoteGi.Text;
            int cantidad = int.Parse(txtCantidadGi.Text);
            string tipoOperacion = "Traspaso";
            DateTime fechaOperacion = dtpFechaGi.Value;
            string destino = cbDestinoGi.SelectedItem.ToString();
            string usuario = lbNombreGi.Text;
            string departamento = lbDepartamentoGi.Text;

            RegistrarTraspaso(idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento);
        }

        private void RegistrarTraspaso(string idTarima, string producto, string lote, int cantidad, string tipoOperacion, DateTime fechaOperacion, string destino, string usuario, string departamento)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el traspaso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lbIdTarima.Text = "";
                txtProductoGi = null;
                txtLoteGi = null;
                txtCantidadGi = null;
                cbDestinoGi.SelectedIndex = -1;
                dtpFechaGi.Value = DateTime.Now;

                CargarDatosInventarioTotal();
            }
        }





        private void btnCancelarGi_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
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

            }
        }

        private void dgvTraspasos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTraspasos.Rows[e.RowIndex];
                lbIdTraspasoDv.Text = row.Cells["idSalidas"].Value.ToString();
                txtProductoDv.Text = row.Cells["producto"].Value.ToString();
                txtLoteDv.Text = row.Cells["lote"].Value.ToString();
                txtCantidadDv.Text = row.Cells["cantidad"].Value.ToString();
                cbDestinoDv.SelectedItem = row.Cells["destino"].Value.ToString();
            }
        }

        private void btnRegistrarDevolucion_Click(object sender, EventArgs e)
        {
            int idTraspaso = int.Parse(lbIdTraspasoDv.Text);
            int idTarima = int.Parse(dgvTraspasos.SelectedRows[0].Cells["idTarima"].Value.ToString());
            string producto = txtProductoDv.Text;
            string lote = txtLoteDv.Text;
            int cantidad = int.Parse(txtCantidadDv.Text);
            string tipoOperacion = "Devolución";
            DateTime fechaOperacion = DateTime.Now;
            string destino = cbDestinoDv.SelectedItem.ToString();
            //string destino = cbDestinoDv.Text.ToString();
            string usuario = lbNombreGi.Text;
            string departamento = lbDepartamentoGi.Text;

            RegistrarDevolucion(idTraspaso, idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento);
        }

        private void RegistrarDevolucion(int idTraspaso, int idTarima, string producto, string lote, int cantidad, string tipoOperacion, DateTime fechaOperacion, string destino, string usuario, string departamento)
        {
            using (MySqlConnection conexion = new MySqlConnection("your_connection_string"))
            {
                try
                {
                    conexion.Open();

                    // Actualizar cantidad disponible en recepcion_carne
                    string updateQuery = "UPDATE recepcion_carne SET cantidad_disponible = cantidad_disponible + @cantidad WHERE id = @idTarima";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conexion))
                    {
                        updateCmd.Parameters.AddWithValue("@cantidad", cantidad);
                        updateCmd.Parameters.AddWithValue("@idTarima", idTarima);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Insertar la devolución en salidas_devoluciones
                    string insertQuery = @"
                INSERT INTO salidas_devoluciones 
                (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento) 
                VALUES (@idTarima, @producto, @lote, @cantidad, @tipoOperacion, @fechaOperacion, @destino, @usuario, @departamento)";
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conexion))
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

                    // Eliminar el traspaso original si es necesario
                    string deleteQuery = "DELETE FROM salidas_devoluciones WHERE id = @idTraspaso";
                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conexion))
                    {
                        deleteCmd.Parameters.AddWithValue("@idTraspaso", idTraspaso);
                        deleteCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Devolución registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosTraspasos(); // Recargar datos de traspasos después de la devolución
                    CargarDatosInventario(); // Recargar datos del inventario después de la devolución
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la devolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

