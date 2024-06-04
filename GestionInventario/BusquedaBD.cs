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
            string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso' AND destino = 'LyFC(traslado)' AND estado = 'activo'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerTarimasDetenidas()
        {                
            string consulta = "SELECT id, producto, lote, cantidad_disponible FROM recepcion_carne WHERE estado = 'detenido'";
            return EjecutarConsulta(consulta);
        }

        //pendientes por confirmar recepcion
        // frmLyfc datagrid obtener pendientes de pestaña conciliacion
        public static DataTable ObtenerPendientesConfirmacionLyfc()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad, estado_confirmacion FROM inventario_lyfc WHERE estado_confirmacion = 'Pendiente'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerPendientesConfirmacionMocha()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad, estado_confirmacion FROM inventario_mocha WHERE estado_confirmacion = 'Pendiente'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerPendientesConfirmacionMezclado()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad, estado_confirmacion FROM inventario_mezclado WHERE estado_confirmacion = 'Pendiente'";
            return EjecutarConsulta(consulta);
        }

        // FrmLyfc datagrid traspasos-----------------------------------------------------------------
        public static DataTable ObtenerInventarioLyfc()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad, estado, estado_confirmacion FROM inventario_lyfc WHERE cantidad > 0 AND estado_confirmacion = 'Recibido'";
            return EjecutarConsulta(consulta);
        }

        //FrmLyfc datagrid inventario total
        public static DataTable ObtenerInventarioAgrupadoLyfc()
        {
            string consulta = @"
                SELECT producto, lote, SUM(cantidad) AS cantidad
                FROM inventario_lyfc
                WHERE cantidad > 0 AND estado_confirmacion = 'Recibido'
                GROUP BY producto, lote";

            return EjecutarConsulta(consulta);
        }

        //FrmLyfc datagrid devoluciones
        public static DataTable ObtenerTraspasosLyfc()
        {
            string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso' AND destino = 'Recibo(Mocha)' AND estado = 'activo'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerDevolucionesLyfc()
        {
            string consulta = "SELECT idDevolucion, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Devolucion' AND destino = 'LyFC'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerDetenidosLyfc()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad FROM inventario_lyfc WHERE estado = 'Detenido'";
            return EjecutarConsulta(consulta);
        }
        //----------------------------------------------------------------------------------

        public static DataTable ObtenerInventarioMocha()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad, estado, estado_confirmacion FROM inventario_Mocha WHERE cantidad > 0 AND estado_confirmacion = 'Recibido'";
            return EjecutarConsulta(consulta);
        }

        //FrmMocha pestaña datagrid inventario total
        public static DataTable ObtenerInventarioAgrupadoMocha()
        {
            string consulta = @"
                SELECT producto, lote, SUM(cantidad) AS cantidad
                FROM inventario_Mocha
                WHERE cantidad > 0 AND estado_confirmacion = 'Recibido'
                GROUP BY producto, lote";
            return EjecutarConsulta(consulta);
        }

        //FrmMocha pestaña datagrid devoluciones
        public static DataTable ObtenerTraspasosMocha()
        {
            string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso' AND destino = 'Mezclado' AND estado = 'activo'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerDevolucionesMocha()
        {
            string consulta = "SELECT idDevolucion, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Devolucion' AND destino = 'LyFC(traslado)'";
            return EjecutarConsulta(consulta);
        }

        //frmMocha pestaña data grid detenidos
        public static DataTable ObtenerDetenidosMocha()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad FROM inventario_mocha WHERE estado = 'Detenido'";
            return EjecutarConsulta(consulta);
        }
        //----------------------------------------------------------------------------------

        public static DataTable ObtenerInventarioMezclado()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad, estado FROM inventario_mezclado WHERE cantidad > 0";
            return EjecutarConsulta(consulta);
        }

        //FrmMocha pestaña datagrid inventario total
        public static DataTable ObtenerInventarioAgrupadoMezclado()
        {
            string consulta = @"
                SELECT producto, lote, SUM(cantidad) AS cantidad
                FROM inventario_Mezclado
                WHERE cantidad > 0
                GROUP BY producto, lote";
            return EjecutarConsulta(consulta);
        }

        //FrmMocha pestaña datagrid devoluciones
        public static DataTable ObtenerTraspasosMezclado()
        {
            string consulta = "SELECT idTraspaso, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Traspaso' AND destino = 'Logística' AND estado = 'activo'";
            return EjecutarConsulta(consulta);
        }

        public static DataTable ObtenerDevolucionesMezclado()
        {
            string consulta = "SELECT idDevolucion, idTarima, producto, lote, cantidad, destino, fechaOperacion FROM salidas_devoluciones WHERE tipoOperacion = 'Devolucion' AND destino = 'LyFC(traslado)'";
            return EjecutarConsulta(consulta);
        }

        //frmMocha pestaña data grid detenidos
        public static DataTable ObtenerDetenidosMezclado()
        {
            string consulta = "SELECT idTarima, producto, lote, cantidad FROM inventario_mezclado WHERE estado = 'Detenido'";
            return EjecutarConsulta(consulta);
        }

        //----------------------------------------------------------------------------------
        public static DataTable ObtenerInventarioAgrupadoLogistica()
        {
            string consulta = @"
                SELECT producto, lote, SUM(cantidad) AS cantidad
                FROM inventario_logistica
                WHERE cantidad > 0
                GROUP BY producto, lote";
            return EjecutarConsulta(consulta);
        }

    }// aqui arriba va todo

}
