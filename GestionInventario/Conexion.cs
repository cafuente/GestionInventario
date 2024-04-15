using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    internal class Conexion
    {
        private bool VerificarCredenciales(string usuario, string password)
        {
            string connectionString = "Server=localhost;Database=trazabilidad;Uid=root;Pwd=123456;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM usuarios WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", usuario);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar las credenciales: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
