using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private int ObtenerIdPerfil(string perfil)
        {
            // Supongamos que "Administrador" tiene id 1 y "Usuario" tiene id 2 en la tabla de perfiles
            switch (perfil)
            {
                case "Administrador":
                    return 1;
                case "Usuario":
                    return 2;
                default:
                    return -1; // Perfil no válido
            }
        }

        public bool CrearUsuario(string usuario, string password, string nombre, string perfil)
        {
            try
            {
                int idPerfil = ObtenerIdPerfil(perfil);
                if (idPerfil == -1)
                {
                    return false; // El perfil no existe
                }

                string query = "INSERT INTO usuarios (usuario, password, nombre, id_perfil) VALUES (@usuario, @password, @nombre, @idPerfil)";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@idPerfil", idPerfil);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ActualizarUsuario(int idUsuario, string usuario, string password, string nombre, string perfil)
        {
            try
            {
                int idPerfil = ObtenerIdPerfil(perfil);
                if (idPerfil == -1)
                {
                    return false; // El perfil no existe
                }

                string query = "UPDATE usuarios SET usuario = @usuario, password = @password, nombre = @nombre, id_perfil = @idPerfil WHERE id_usuario = @idUsuario";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@idPerfil", idPerfil);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                string query = "DELETE FROM usuarios WHERE id_usuario = @idUsuario";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM usuarios";

            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                usuario = reader["usuario"].ToString(),
                                Password = reader["password"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                IdPerfil = Convert.ToInt32(reader["id_perfil"])
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }
    }
}


