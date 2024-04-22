using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventario
{
    public class InsercionDatosDAO
    {
        private ConexionBD conexion;

        public InsercionDatosDAO()
        {
            conexion = new ConexionBD();
        }

        public string ObtenerUltimoId()
        {
            string ultimoId = "";
            string consulta = "SELECT MAX(CAST(SUBSTRING(id, 2) AS UNSIGNED)) FROM recepcion_carne";

            try
            {
                // Abrir la conexión
                conexion.AbrirConexion();

                // Crear el comando SQL
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion.ObtenerConexion()))
                {
                    // Ejecutar la consulta y obtener el resultado
                    object resultado = comando.ExecuteScalar();

                    // Verificar si se obtuvo un resultado
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        // Obtener el último ID y sumarle 1 para el nuevo ID
                        int ultimoIdInt = Convert.ToInt32(resultado);
                        int nuevoIdInt = ultimoIdInt + 1;

                        // Formatear el nuevo ID con el formato "D000001"
                        ultimoId = $"D{nuevoIdInt:D6}";
                    }
                    else
                    {
                        // Si no hay registros en la tabla, establecer el ID inicial como "D000001"
                        ultimoId = "D000001";
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la ejecución de la consulta
                Console.WriteLine("Error al obtener el último ID: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión al finalizar la operación
                conexion.CerrarConexion();
            }

            return ultimoId;
        }

        public bool InsertarDatosRecepcionCarne(string id, string linea, string procedencia, DateTime fechaSacrificio, DateTime fechaEmpaque, string fleje, string turno, int cantidad, int cajas, string factura, string ordenCompra, string marca, string lote, string producto, DateTime fecha)
        {
            try
            {
                string consulta = "INSERT INTO recepcion_carne (id, linea, procedencia, fecha_sacrificio, fecha_empaque, fleje, turno, cantidad, cajas, factura, orden_compra, marca, lote, producto, fecha) " +
                                  "VALUES (@id, @Linea, @Procedencia, @FechaSacrificio, @FechaEmpaque, @Fleje, @Turno, @Cantidad, @Cajas, @Factura, @OrdenCompra, @Marca, @Lote, @Producto, @Fecha)";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@Linea", linea);
                        cmd.Parameters.AddWithValue("@Procedencia", procedencia);
                        cmd.Parameters.AddWithValue("@FechaSacrificio", fechaSacrificio);
                        cmd.Parameters.AddWithValue("@FechaEmpaque", fechaEmpaque);
                        cmd.Parameters.AddWithValue("@Fleje", fleje);
                        cmd.Parameters.AddWithValue("@Turno", turno);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@Cajas", cajas);
                        cmd.Parameters.AddWithValue("@Factura", factura);
                        cmd.Parameters.AddWithValue("@OrdenCompra", ordenCompra);
                        cmd.Parameters.AddWithValue("@Marca", marca);
                        cmd.Parameters.AddWithValue("@Lote", lote);
                        cmd.Parameters.AddWithValue("@Producto", producto);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar datos: " + ex.Message);
                return false;
            }
        }
    }
}
