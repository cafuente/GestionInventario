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
    /*
    public class BusquedaBD
    {
        public static DataTable ObtenerInventario()
        {
            DataTable dt = new DataTable();
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            try
            {
                conexion.Open();
                string consulta = "SELECT id, producto, lote, cantidad_disponible FROM recepcion_carne WHERE cantidad_disponible > 0";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el inventario: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            return dt;
        }

        public static DataTable ObtenerInventarioAgrupado()
        {
            DataTable dt = new DataTable();
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            try
            {
                conexion.Open();
                string consulta = @"
                    SELECT producto, lote, SUM(cantidad_disponible) AS cantidad_total
                    FROM recepcion_carne
                    WHERE cantidad_disponible > 0
                    GROUP BY producto, lote";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el inventario agrupado: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            return dt;
        }

        public static DataTable ObtenerTraspasos()
        {
            DataTable dt = new DataTable();
            ConexionBD conexionBD = new ConexionBD();
            MySqlConnection conexion = conexionBD.ObtenerConexion();
            try
            {
                conexion.Open();
                string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso'";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los traspasos: " + ex.Message);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
            return dt;
        }

    }*/
    public class BusquedaBD
    {
        private static DataTable EjecutarConsulta(string consulta)
        {
            DataTable dt = new DataTable();
            using (ConexionBD conexionBD = new ConexionBD())
            {
                MySqlConnection conexion = conexionBD.ObtenerConexion();
                try
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                    adaptador.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }
            }
            return dt;
        }

        public static DataTable ObtenerInventario()
        {
            string consulta = "SELECT id, producto, lote, cantidad_disponible, estado FROM recepcion_carne WHERE cantidad_disponible > 0";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerInventarioAgrupado()
        {
            string consulta = @"
                SELECT producto, lote, SUM(cantidad_disponible) AS cantidad_total
                FROM recepcion_carne
                WHERE cantidad_disponible > 0
                GROUP BY producto, lote";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerTraspasos()
        {
            string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso'AND estado = 'activo'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerTarimasDetenidas()
        {                
            string consulta = "SELECT id, producto, lote, cantidad_disponible FROM recepcion_carne WHERE estado = 'detenido'";
            return EjecutarConsulta(consulta);
        }


        // FrmLyfc
        public static DataTable ObtenerInventarioLyfc()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad FROM inventario_lyfc WHERE cantidad > 0";
            return EjecutarConsulta(consulta);
        }

        
        public static DataTable ObtenerInventarioAgrupadoLyfc()
        {
            string consulta = @"
                SELECT producto, lote, SUM(cantidad) AS cantidad
                FROM inventario_lyfc
                WHERE cantidad > 0
                GROUP BY producto, lote";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerTraspasosLyfc()
        {
            string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso' AND destino = 'LyFC'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerDevolucionesLyfc()
        {
            string consulta = "SELECT idDevolucion, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Devolucion' AND destino = 'LyFC'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerDetenidosLyfc()
        {
            string consulta = "SELECT id, producto, lote, cantidad_disponible FROM inventario_lyfc WHERE estado = 'Detenido'";
            return EjecutarConsulta(consulta);
        }


    }// aqui arriba va todo

}
