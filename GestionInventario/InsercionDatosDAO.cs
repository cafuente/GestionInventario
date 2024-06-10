using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
                         
                        // Formatear el nuevo ID con el formato "D0000001"
                        ultimoId = $"D{nuevoIdInt:D7}";
                    }
                    else
                    {
                        // Si no hay registros en la tabla, establecer el ID inicial como "D000001"
                        ultimoId = "D0000001";
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

        public bool InsertarDatosRecepcionCarne(string id, string linea, string procedencia, DateTime fechaSacrificio, DateTime fechaEmpaque, string fleje, string turno, float cantidad, int cajas, string factura, string ordenCompra, string marca, string lote, string producto, DateTime fecha, int tara, float peso, string departamento, float disponible, string nombreUsuario)
        {
            /*try
            {
                string consulta = "INSERT INTO recepcion_carne (id, linea, procedencia, fecha_sacrificio, fecha_empaque, fleje, turno, cantidad, cajas, factura, orden_compra, marca, lote, producto, fecha, tara, peso, departamento, cantidad_disponible, nombreUsuario) " +
                                  "VALUES (@id, @Linea, @Procedencia, @FechaSacrificio, @FechaEmpaque, @Fleje, @Turno, @Cantidad, @Cajas, @Factura, @OrdenCompra, @Marca, @Lote, @Producto, @Fecha, @tara, @peso, @departamento, @disponible, @nombreUsuario)";

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
                        cmd.Parameters.AddWithValue("@tara", tara);
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@departamento", departamento);
                        cmd.Parameters.AddWithValue("@disponible", disponible);
                        cmd.Parameters.AddWithValue("@nombreUsuario",nombreUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar datos: " + ex.Message);
                return false;
            }*/
            try
            {
                string consulta = @"INSERT INTO recepcion_carne 
                            (id, linea, procedencia, fecha_sacrificio, fecha_empaque, fleje, turno, cantidad, cajas, factura, orden_compra, marca, lote, producto, fecha, tara, peso, departamento, cantidad_disponible, nombreUsuario) 
                            VALUES 
                            (@id, @Linea, @Procedencia, @FechaSacrificio, @FechaEmpaque, @Fleje, @Turno, @Cantidad, @Cajas, @Factura, @OrdenCompra, @Marca, @Lote, @Producto, @Fecha, @tara, @peso, @departamento, @disponible, @nombreUsuario)";

                string consultaMovimientos = @"INSERT INTO salidas_devoluciones 
                                       (idTarima, producto, lote, cantidad, tipoOperacion, fechaOperacion, destino, usuario, departamento) 
                                       VALUES 
                                       (@idTarima, @producto, @lote, @disponible, 'Recepcion', NOW(), 'Almacen', @usuario, @departamento)";

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
                        cmd.Parameters.AddWithValue("@tara", tara);
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@departamento", departamento);
                        cmd.Parameters.AddWithValue("@disponible", disponible);
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                        cmd.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmdMovimientos = new MySqlCommand(consultaMovimientos, con))
                    {
                        cmdMovimientos.Parameters.AddWithValue("@idTarima", id);
                        cmdMovimientos.Parameters.AddWithValue("@producto", producto);
                        cmdMovimientos.Parameters.AddWithValue("@lote", lote);
                        cmdMovimientos.Parameters.AddWithValue("@disponible", disponible);
                        cmdMovimientos.Parameters.AddWithValue("@usuario", nombreUsuario);
                        cmdMovimientos.Parameters.AddWithValue("@departamento", departamento);

                        cmdMovimientos.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar datos: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarDatosRecepcionCarne(string id, string linea, string procedencia, DateTime fechaSacrificio, DateTime fechaEmpaque, string fleje, string turno, float cantidad, int cajas, string factura, string ordenCompra, string marca, string lote, string producto, DateTime fecha, int tara, float peso, string departamento, float disponible, string nombreUsuario)
        {
            try
            {
                string consulta = "UPDATE recepcion_carne SET linea = @Linea, procedencia = @Procedencia, fecha_sacrificio = @FechaSacrificio, fecha_empaque = @FechaEmpaque, fleje = @Fleje, turno = @Turno, cantidad = @Cantidad, cajas = @Cajas, factura = @Factura, orden_compra = @OrdenCompra, marca = @Marca, lote = @Lote, producto = @Producto, fecha = @Fecha, tara = @Tara, peso = @Peso, departamento = @Departamento, cantidad_disponible = @Disponible, nombreUsuario = @NombreUsuario WHERE id = @Id";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
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
                        cmd.Parameters.AddWithValue("@Tara", tara);
                        cmd.Parameters.AddWithValue("@Peso", peso);
                        cmd.Parameters.AddWithValue("@Departamento", departamento);
                        cmd.Parameters.AddWithValue("@Disponible", disponible);
                        cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar datos: " + ex.Message);
                return false;
            }
        }
        public bool EliminarDatosRecepcionCarne(string id)
        {
            try
            {
                string consulta = "DELETE FROM recepcion_carne WHERE id = @id";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar datos: " + ex.Message);
                return false;
            }
        }
    }
}
