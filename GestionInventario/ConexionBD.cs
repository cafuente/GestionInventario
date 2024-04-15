using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    internal class ConexionBD
    {

        private MySqlConnection conexion;
        private string servidor;
        private string database;
        private string usuario;
        private string password;

        public ConexionBD()
        {
            servidor = "localhost";
            database = "trazabilidad";
            usuario = "root"; // Cambiar por tu nombre de usuario de MySQL
            password = "123456"; // Cambiar por tu contraseña de MySQL

            string connectionString = $"Server={servidor};Database={database};Uid={usuario};Pwd={password};";

            conexion = new MySqlConnection(connectionString);
        }

        public bool AbrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
                return false;
            }
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }

        public MySqlConnection ObtenerConexion()
        {
            return conexion;
        }
    }  
}
