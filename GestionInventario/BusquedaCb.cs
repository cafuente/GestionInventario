using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    internal class BusquedaCb
    {
        private ConexionBD conexion;
        public BusquedaCb()
        {
            conexion = new ConexionBD();
        }
        public void ProcesarCodigoBarras(TextBox txtCodigoBarrasRc, Label idLabel, TextBox txtLinea, TextBox txtProcedencia, DateTimePicker dpSacrificio, DateTimePicker dpEmpaque, TextBox txtFleje,ComboBox cbTurno, TextBox txtCantidad, TextBox txtCajas, TextBox txtFactura, TextBox txtOrdenCompra, TextBox txtMarca, TextBox txtLote, TextBox txtProducto, DateTimePicker dpFecha, TextBox txtTara, TextBox txtPeso)
        {
            string sql = "select linea, procedencia, fecha_sacrificio from trazabilidad.recepcion_carne where id ='" + txtCodigoBarrasRc.Text + "'";
            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        //idLabel.Text = rdr[0].ToString();
                        txtLinea.Text = rdr[0].ToString();
                        txtProcedencia.Text = rdr[1].ToString();
                        dpSacrificio.Text = rdr[2].ToString();
                        dpEmpaque.Text = rdr[3].ToString();
                        txtFleje.Text = rdr[4].ToString();
                        cbTurno.Text = rdr[5].ToString();
                        txtCantidad.Text = rdr[6].ToString();
                        txtCajas.Text = rdr[7].ToString();
                        txtFactura.Text = rdr[8].ToString();
                        txtOrdenCompra.Text = rdr[9].ToString();
                        txtMarca.Text = rdr[10].ToString();
                        txtLote.Text = rdr[11].ToString();
                        txtProducto.Text = rdr[12].ToString();
                        dpFecha.Text = rdr[13].ToString();
                        txtTara.Text = rdr[14].ToString();
                        txtPeso.Text = rdr[15].ToString();
                    }
                }
                idLabel.Text = txtCodigoBarrasRc.Text;
                txtCodigoBarrasRc.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se logro realizar la busqueda, error: " + e.ToString());
            }
        }
    }
}
