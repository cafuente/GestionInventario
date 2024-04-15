using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class UsuariosDAO
    {
        private ConexionBD conexion;

        public UsuariosDAO()
        {
            conexion = new ConexionBD();
        }

        public bool VerificarCredenciales(string username, string password)
        {
            bool loginSuccessful = false;

            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    loginSuccessful = count > 0;
                }
            }

            return loginSuccessful;
        }
    }
}

