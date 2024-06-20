using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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
        private int currentRowIndex = 0;             

        public FrmReportes(Usuario usuario)
        {
            InitializeComponent();
            conexion = new ConexionBD();
            usuarioAutenticado = usuario;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;            
        }
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            MostrarInformacionUsuario();
            cbDepartamentos.Items.AddRange(new string[] { "Almacen Carnicos", "Limpieza y Formulacion", "Recepcion(mocha)", "Mezclado" });
            // Seleccionar el primer elemento por defecto (opcional)            
            cbDepartamentos.SelectedItem = $"{FrmLogin.UsuarioActual.Departamento}";
            cbDepartamentosRep.Items.AddRange(new string[] { "Almacen Carnicos", "Limpieza y Formulacion", "Recepcion(mocha)", "Mezclado" });
            // Seleccionar el primer elemento por defecto (opcional)
            cbDepartamentos.SelectedItem = $"{FrmLogin.UsuarioActual.Departamento}";

            // Llenar el ComboBox con las opciones de reportes disponibles
            cbReportes.Items.Add("Inventario Actual");
            cbReportes.Items.Add("Movimientos por Producto");
            cbReportes.Items.Add("Productos con Bajo Inventario");
            cbReportes.Items.Add("Tarimas Detenidas");
            cbReportes.Items.Add("Consumo por Departamento");

            // Seleccionar el primer elemento por defecto (opcional)
            if (cbReportes.Items.Count > 0)
            {
                cbReportes.SelectedIndex = 0;
            }
            txtUmbral.Visible = false;
            lbUmbral.Visible = false;
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
            if (string.IsNullOrEmpty(dtpFechaInicio.Text) ||
                string.IsNullOrEmpty(dtpFechaFin.Text) ||
                cbDepartamentos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;
            string departamento = cbDepartamentos.SelectedItem.ToString();

            DataTable tendenciaData = ObtenerTendenciaMensual(fechaInicio, fechaFin, departamento);
            CrearGraficoTendencia(tendenciaData);

            DataTable consumoData = ObtenerConsumoPorTipo(fechaInicio, fechaFin, departamento);
            CrearGraficoConsumo(consumoData);
        }
        
        // Evento Click para imprimir ambos gráficos
        private void btnImprimirTendencia_Click(object sender, EventArgs e)
        {
            List<Chart> charts = new List<Chart> { chartTendencia, chartConsumo };
            ImprimirGraficos(charts);
        }
        // Método para imprimir múltiples gráficos
        private void ImprimirGraficos(List<Chart> charts)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                float yPos = 0;
                foreach (Chart chart in charts)
                {
                    Bitmap bmp = new Bitmap(chart.Width, chart.Height);
                    chart.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    e.Graphics.DrawImage(bmp, 0, yPos);
                    yPos += chart.Height + 20; // Añadir un margen entre los gráficos
                }
            };

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDocument;
            printPreview.ShowDialog();
        }

        // Evento Click para exportar ambos gráficos a Excel
        private void btnExportarTendencia_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                DataTable tendenciaData = ObtenerTendenciaMensual(fechaInicio, fechaFin, cbDepartamentos.SelectedItem.ToString());
                DataTable consumoData = ObtenerConsumoPorTipo(fechaInicio, fechaFin, cbDepartamentos.SelectedItem.ToString());

                List<DataTable> dataTables = new List<DataTable> { tendenciaData, consumoData };
                List<string> nombresHojas = new List<string> { "Tendencia Mensual", "Consumo Cárnico" };

                ExportarDataTablesAExcel(dataTables, nombresHojas, saveFileDialog.FileName=$"Tendencia");
            }
        }

        // Método para exportar múltiples DataTables a Excel
        private void ExportarDataTablesAExcel(List<DataTable> dataTables, List<string> nombresHojas, string rutaArchivo)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                for (int i = 0; i < dataTables.Count; i++)
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(nombresHojas[i]);
                    worksheet.Cells["A1"].LoadFromDataTable(dataTables[i], true);
                }
                package.SaveAs(new FileInfo(rutaArchivo));
            }
        }
               
        private void btnGenerarReporteRep_Click(object sender, EventArgs e)
        {
            if (cbDepartamentosRep.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime fechaInicio = dtpFechaInicioRep.Value;
            DateTime fechaFin = dtpFechaFinRep.Value;
            string departamento = cbDepartamentosRep.SelectedItem.ToString();
            DataTable dataTable = new DataTable();

            switch (cbReportes.SelectedItem.ToString())
            {
                case "Inventario Actual":
                    dataTable = BusquedaBD.ObtenerInventarioActual(departamento);
                    break;
                case "Movimientos por Producto":
                    dataTable = BusquedaBD.ObtenerMovimientosPorProducto(fechaInicio, fechaFin, departamento);
                    break;
                case "Productos con Bajo Inventario":
                    //int umbral = 800; // ajustar este valor o hacerlo configurable
                    int umbral;
                    if (!int.TryParse(txtUmbral.Text, out umbral))
                    {
                        MessageBox.Show("Por favor, ingrese un umbral válido.");
                        return;
                    }
                    dataTable = BusquedaBD.ObtenerProductosConBajoInventario(umbral, departamento);
                    break;
                case "Tarimas Detenidas":
                    dataTable = BusquedaBD.ObtenerTarimasDetenidas(departamento);
                    break;
                case "Consumo por Departamento":
                    dataTable = BusquedaBD.ObtenerConsumoPorDepartamento(fechaInicio, fechaFin, departamento);
                    break;
            }

            dgvReporte.DataSource = dataTable;
        }

        private void cbReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reporte = cbReportes.Text;
            if (reporte == "Productos con Bajo Inventario")
            {
                txtUmbral.Visible = true;
                lbUmbral.Visible = true;
            }
            else
            {
                txtUmbral.Visible = false;
                lbUmbral.Visible = false;
            }
        }

        private void pbGuardarReporte_Click(object sender, EventArgs e)
        {
            if (dgvReporte.DataSource is DataTable dataTable)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Guardar Reporte"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;
                    ExportarDataTableAExcel(dataTable, cbReportes.SelectedItem.ToString(), rutaArchivo);
                    MessageBox.Show("Reporte guardado exitosamente.", "Guardar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay datos para guardar.", "Guardar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExportarDataTableAExcel(DataTable dataTable, string nombreHoja, string rutaArchivo)
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(nombreHoja);

                // Añadir encabezados de columna
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                }

                // Añadir filas de datos
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                    }
                }

                // Guardar el archivo en la ruta especificada
                FileInfo fileInfo = new FileInfo(rutaArchivo);
                excelPackage.SaveAs(fileInfo);
            }
        }

        private void pbImprimirReporte_Click(object sender, EventArgs e)
        {
            if (dgvReporte.DataSource is DataTable dataTable)
            {
                ImprimirReporte(dgvReporte, cbReportes.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("No hay datos para imprimir.", "Imprimir Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Dictionary<string, int[]> anchosColumnasReportes = new Dictionary<string, int[]>
        {
            { "Inventario Actual", new int[] { 100, 170, 100, 100, 100 } },
            { "Movimientos por Producto", new int[] { 70, 150, 90, 70, 90, 170, 100, 100 } },
            { "Productos con Bajo Inventario", new int[] { 100, 100 } },
            { "Tarimas Detenidas", new int[] { 100, 170, 100, 90, 100, 100 } },
            { "Consumo por Departamento", new int[] { 170, 100 } }
        };
        //private PrintDocument printDocument;        

        private void ImprimirReporte(DataGridView dgv, string tituloReporte)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Imprimir Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!anchosColumnasReportes.ContainsKey(cbReportes.SelectedItem.ToString()))
            {
                MessageBox.Show("No se encontraron configuraciones de ancho para el reporte seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] anchosColumnas = anchosColumnasReportes[cbReportes.SelectedItem.ToString()]; // Asegúrate de que esto no sea nulo
            if (anchosColumnas.Length != dgv.Columns.Count)
            {
                MessageBox.Show("El número de anchos de columna no coincide con el número de columnas en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                float yPosition = e.MarginBounds.Top;
                float xPosition = e.MarginBounds.Left;
                //int[] anchosColumnas = anchosColumnasReportes[cbReportes.SelectedItem.ToString()];
                using (Font printFont = new Font("Arial", 9))
                {
                    // Imprimir título del reporte
                    e.Graphics.DrawString(tituloReporte, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, xPosition, yPosition);
                    yPosition += 30;

                    // Imprimir encabezados de columna
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        e.Graphics.DrawString(dgv.Columns[i].HeaderText, printFont, Brushes.Black, xPosition, yPosition);
                        xPosition += anchosColumnas[i];
                    }
                    yPosition += 30;
                    xPosition = e.MarginBounds.Left;

                    // Imprimir filas del DataGridView
                    while (currentRowIndex < dgv.Rows.Count)
                    {
                        DataGridViewRow row = dgv.Rows[currentRowIndex];
                        xPosition = e.MarginBounds.Left; // Resetear la posición a la izquierda del margen
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            e.Graphics.DrawString(row.Cells[i].Value?.ToString(), printFont, Brushes.Black, xPosition, yPosition);
                            xPosition += anchosColumnas[i];
                        }
                        yPosition += 20;

                        // Verificar si hay suficiente espacio para la siguiente fila
                        if (yPosition + 20 > e.MarginBounds.Bottom)
                        {
                            currentRowIndex++;
                            e.HasMorePages = true;
                            return; // Salir del manejador de eventos para que se imprima en la siguiente página
                        }
                        currentRowIndex++;
                    }

                    // Reiniciar la variable currentRowIndex para la próxima vez que se imprima
                    currentRowIndex = 0;
                    e.HasMorePages = false; // Indicar que no hay más páginas que imprimir
                }
            };

            // Mostrar PageSetupDialog para configurar la página
            PageSetupDialog pageSetupDialog = new PageSetupDialog
            {
                Document = printDocument,
                PageSettings = printDocument.DefaultPageSettings               
            };
            pageSetupDialog.ShowDialog();

            // Mostrar PrintPreviewDialog para vista previa antes de imprimir
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument,
                Width = 800,
                Height = 600
            };
            DialogResult result = printPreviewDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                // Mostrar PrintDialog para seleccionar impresora y guardar como PDF
                PrintDialog printDialog = new PrintDialog
                {
                    Document = printDocument,
                    AllowCurrentPage = true,
                    AllowSomePages = true,
                    AllowSelection = true,
                    UseEXDialog = true,
                };

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    try
                    {
                        printDocument.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al imprimir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
