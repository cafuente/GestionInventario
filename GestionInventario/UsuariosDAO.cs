using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        /*ok-public bool VerificarCredenciales(string username, string password)
        {
            bool loginSuccessful = false;

            string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @usuario AND password = @password";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@usuario", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        loginSuccessful = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return loginSuccessful;
        }*/
        public bool VerificarCredenciales(string username, string password, out Usuario usuario)
        {
            usuario = null;
            string query = @"
                SELECT u.*, p.nombre AS perfil
                FROM usuarios u
                JOIN perfil p ON u.id_perfil = p.id_perfil
                WHERE u.usuario = @usuario AND u.password = @password";

            try
            {
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@usuario", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario
                                {
                                    IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                    usuario = reader["usuario"].ToString(),
                                    Password = reader["password"].ToString(),
                                    Nombre = reader["nombre"].ToString(),
                                    Departamento = reader["departamento"].ToString(),
                                    IdPerfil = Convert.ToInt32(reader["id_perfil"]),
                                    PerfilNombre = reader["perfil"].ToString()
                                };
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar credenciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
                case "Supervisor":
                    return 3;
                default:
                    return -1; // Perfil no válido
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

        public bool CrearUsuario(string usuario, string password, string nombre, string departamento, string perfil)
        {
            try
            {
                int idPerfil = ObtenerIdPerfil(perfil);
                if (idPerfil == -1)
                {
                    return false; // El perfil no existe
                }

                string query = "INSERT INTO usuarios (usuario, password, nombre, departamento, id_perfil) VALUES (@usuario, @password, @nombre,@departamento, @idPerfil)";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@departamento", departamento);
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

        public bool ActualizarUsuario(int idUsuario, string usuario, string password, string nombre, string departamento, string perfil)
        {
            try
            {
                int idPerfil = ObtenerIdPerfil(perfil);
                if (idPerfil == -1)
                {
                    return false; // El perfil no existe
                }

                string query = "UPDATE usuarios SET usuario = @usuario, password = @password, nombre = @nombre,departamento = @departamento, id_perfil = @idPerfil WHERE id_usuario = @idUsuario";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@departamento", departamento);
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

        /*public List<Usuario> ObtenerUsuarios()
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
                                Departamento = reader["departamento"].ToString(),
                                IdPerfil = Convert.ToInt32(reader["id_perfil"])
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }*/

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
                                Departamento = reader["departamento"].ToString(),
                                IdPerfil = Convert.ToInt32(reader["id_perfil"]),
                                Imagen = reader["imagen"] != DBNull.Value ? (byte[])reader["imagen"] : null
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public void ActualizarImagenUsuario(int idUsuario, byte[] imagen)
        {
            string query = "UPDATE usuarios SET imagen = @imagen WHERE id_usuario = @idUsuario";

            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@imagen", imagen);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void GuardarImagenUsuario(int idUsuario, byte[] imagen)
        {
            string query = "UPDATE usuarios SET imagen = @imagen WHERE id_usuario = @idUsuario";
            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@imagen", imagen);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public byte[] ObtenerImagenUsuario(int idUsuario)
        {
            string query = "SELECT imagen FROM usuarios WHERE id_usuario = @idUsuario";
            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    object resultado = cmd.ExecuteScalar();
                    if (resultado != DBNull.Value)
                    {
                        return (byte[])resultado;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }


        public Usuario ObtenerInformacionUsuario(string nombreUsuario)
        {
            /*
            Usuario usuario = null;
            string query = "SELECT * FROM usuarios WHERE usuario = @usuario";

            try
            {
                // Abrir la conexión
                conexion.AbrirConexion();

                // Crear el comando SQL
                using (MySqlCommand comando = new MySqlCommand(query, conexion.ObtenerConexion()))
                {
                    // Agregar parámetro
                    comando.Parameters.AddWithValue("@usuario", nombreUsuario);

                    // Ejecutar la consulta y obtener el resultado
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        // Verificar si se encontró el usuario
                        if (reader.Read())
                        {
                            // Crear objeto Usuario con la información recuperada de la base de datos
                            usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                usuario = reader["usuario"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Departamento= reader["departamento"].ToString(),
                                IdPerfil = Convert.ToInt32(reader["id_perfil"])
                                // aqui se agregan más propiedades si es necesario
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la ejecución de la consulta
                Console.WriteLine("Error al obtener la información del usuario: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión al finalizar la operación
                conexion.CerrarConexion();
            }

            return usuario;*/
            Usuario usuario = null;
            string query = @"SELECT u.id_usuario, u.usuario, u.password, u.nombre, u.departamento, u.id_perfil, p.nombre AS perfil_nombre 
                     FROM usuarios u
                     JOIN perfil p ON u.id_perfil = p.id_perfil
                     WHERE u.usuario = @usuario";

            try
            {
                conexion.AbrirConexion();
                using (MySqlCommand comando = new MySqlCommand(query, conexion.ObtenerConexion()))
                {
                    comando.Parameters.AddWithValue("@usuario", nombreUsuario);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(reader["id_usuario"]),
                                usuario = reader["usuario"].ToString(),
                                Password = reader["password"].ToString(),
                                Nombre = reader["nombre"].ToString(),
                                Departamento = reader["departamento"].ToString(),
                                IdPerfil = Convert.ToInt32(reader["id_perfil"]),
                                PerfilNombre = reader["nombre"].ToString()  // Actualización aquí
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la información del usuario: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return usuario;
        }


        // Método para cargar los usuarios en el DataGridView
        public void CargarUsuarios(DataGridView dataGridView)
        {
            try
            {
                conexion.AbrirConexion(); // Abrimos la conexión utilizando la instancia de ConexionBD
                string query = "SELECT id_usuario, usuario, password, nombre, departamento, id_perfil FROM usuarios";

                MySqlCommand command = new MySqlCommand(query, conexion.ObtenerConexion());
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Agregar una columna adicional para mostrar el nombre del perfil en lugar del ID
                DataColumn nombrePerfilColumna = new DataColumn("Perfil", typeof(string));
                dataTable.Columns.Add(nombrePerfilColumna);

                // Recorrer cada fila y obtener el nombre del perfil
                foreach (DataRow row in dataTable.Rows)
                {
                    int idPerfil = Convert.ToInt32(row["id_perfil"]);
                    string nombrePerfil = ObtenerNombrePerfil(idPerfil);
                    row["Perfil"] = nombrePerfil;
                }

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.CerrarConexion(); // Cerramos la conexión al finalizar la operación
            }
        }
        
    }
}


