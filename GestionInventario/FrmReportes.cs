using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionInventario
{
    public partial class FrmReportes : Form
    {
        private Usuario usuarioAutenticado;
        private ConexionBD conexion;
        
        public FrmReportes(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD();
            usuarioAutenticado = usuario;           
            
        }
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            MostrarInformacionUsuario();
            cbDepartamentos.Items.AddRange(new string[] { "Almacen Carnicos", "Limpieza y Formulacion", "Recepcion(mocha)", "Mezclado"});
        }

        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreRep.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoRep.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                lbPerfilRep.Text = $"{nombrePerfil}";

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

        private void FrmReportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmPrincipal = new FrmPrincipal(FrmLogin.UsuarioActual);
            frmPrincipal.Show();
        }

        // Método para obtener la tendencia mensual
        public DataTable ObtenerTendenciaMensual(DateTime fechaInicio, DateTime fechaFin, string departamento)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                string consulta = @"
            SELECT 
                DATE(fechaOperacion) AS Fecha, 
                SUM(cantidad) AS CantidadTotal 
            FROM 
                salidas_devoluciones 
            WHERE 
                fechaOperacion BETWEEN @fechaInicio AND @fechaFin
                AND departamento = @departamento AND tipoOperacion = 'Traspaso' AND estado = 'activo'
            GROUP BY 
                DATE(fechaOperacion)
            ORDER BY 
                Fecha";

                using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@departamento", departamento);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Método para crear gráfico de tendencia
        private void CrearGraficoTendencia(DataTable dataTable)
        {
            chartTendencia.Series.Clear();
            chartTendencia.ChartAreas.Clear();
            chartTendencia.Titles.Clear();

            ChartArea chartArea = new ChartArea("TendenciaMensual");
            chartArea.AxisX.Title = "Fecha";
            chartArea.AxisX.LabelStyle.Format = "dd-MM";
            chartArea.AxisY.Title = "Cantidad Total";
            chartTendencia.ChartAreas.Add(chartArea);

            Title title = new Title("Tendencia de Traspasos", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
            chartTendencia.Titles.Add(title);

            Series series = new Series("Tendencia traspasos");
            series.IsVisibleInLegend = false;
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Date;
            series.BorderWidth = 3;
            series.Color = Color.Blue;
            chartTendencia.Series.Add(series);

            foreach (DataRow row in dataTable.Rows)
            {
                series.Points.AddXY(Convert.ToDateTime(row["Fecha"]), Convert.ToDouble(row["CantidadTotal"]));
            }

            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0"; // Formato sin decimales

            foreach (DataPoint point in series.Points)
            {
                point.LabelForeColor = Color.Black;
                point.LabelBackColor = Color.White;
            }

            chartTendencia.Invalidate();
        }

        // Método para obtener el consumo por tipo
        public DataTable ObtenerConsumoPorTipo(DateTime fechaInicio, DateTime fechaFin, string departamento)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection con = conexion.ObtenerConexion())
            {
                con.Open();
                string consulta = @"
            SELECT 
                producto, 
                SUM(cantidad) AS CantidadTotal 
            FROM 
                salidas_devoluciones 
            WHERE 
                tipoOperacion =""Traspaso"" AND departamento = @departamento AND estado = ""Activo"" AND
                fechaOperacion BETWEEN @fechaInicio AND @fechaFin
                AND departamento = @departamento
            GROUP BY 
                producto
            ORDER BY 
                CantidadTotal DESC";

                using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@departamento", departamento);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Método para crear gráfico de consumo
        private void CrearGraficoConsumo(DataTable dataTable)
        {
            chartConsumo.Series.Clear();
            chartConsumo.ChartAreas.Clear();
            chartConsumo.Titles.Clear();
            chartConsumo.Legends.Clear();

            ChartArea chartArea = new ChartArea("ConsumoCarnico");
            chartConsumo.ChartAreas.Add(chartArea);

            Title title = new Title("Consumo Cárnico por Tipo", Docking.Top, new Font("Verdana", 12, FontStyle.Bold), Color.Black);
            chartConsumo.Titles.Add(title);

            Series series = new Series("Consumo Cárnico");
            series.ChartType = SeriesChartType.Pie;
            chartConsumo.Series.Add(series);

            foreach (DataRow row in dataTable.Rows)
            {
                series.Points.AddXY(row["producto"].ToString(), Convert.ToDouble(row["CantidadTotal"]));
            }

            series.IsValueShownAsLabel = true;
            series.LabelFormat = "N0"; // Formato sin decimales

            foreach (DataPoint point in series.Points)
            {
                point.LabelForeColor = Color.Black;
                point.LabelBackColor = Color.White;
                point.Label = $"#VALY Kg\n#PERCENT"; // Agregar porcentaje y cantidad dentro del pastel
                point.LegendText = "#VALX";
            }

            Legend legend = new Legend("Leyenda");
            legend.Docking = Docking.Bottom; // Posicionar la leyenda en la parte inferior
            chartConsumo.Legends.Add(legend);

            chartConsumo.Invalidate();
        }

        // Evento click del botón para generar el reporte
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;
            string departamento = cbDepartamentos.SelectedItem.ToString();

            DataTable tendenciaData = ObtenerTendenciaMensual(fechaInicio, fechaFin, departamento);
            CrearGraficoTendencia(tendenciaData);

            DataTable consumoData = ObtenerConsumoPorTipo(fechaInicio, fechaFin, departamento);
            CrearGraficoConsumo(consumoData);
        }

    }
}
