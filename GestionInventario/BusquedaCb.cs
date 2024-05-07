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
        public void ProcesarCodigoBarras(TextBox txtCodigoBarrasRc, Label idLabel, TextBox txtLinea, TextBox txtProcedencia, DateTimePicker dpSacrificio)
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
