using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace GestionInventario
{
    public partial class frmTrazalibildad : Form
    {
        private PrintDocument printDocument;
        private DataTable printTable;
        private int rowIndex;
        public frmTrazalibildad()
        {
            InitializeComponent();
        }
        private void frmTrazalibildad_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            //marca de agua busqueda traspasos
            txtIdTarimaBusqueda.ForeColor = Color.LightGray;
            txtIdTarimaBusqueda.Text = "DXXXXXXX";
            txtIdTarimaBusqueda.GotFocus += new EventHandler(txtIdTarimaBusqueda_GotFocus);
            txtIdTarimaBusqueda.LostFocus += new EventHandler(txtIdTarimaBusqueda_LostFocus);
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            printDocument.DefaultPageSettings.Landscape = true; // Default modo landscape
            lbFiltro.Enabled = false;
            txtBuscar.Enabled = false;
            pbGuardar.Enabled = false;
        }
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreTr.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoTr.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilTr.Text = $"{nombrePerfil}";

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

        private void frmTrazalibildad_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }

        private void txtIdTarimaBusqueda_Click(object sender, EventArgs e)
        {
            txtIdTarimaBusqueda.Text = "";
            txtIdTarimaBusqueda.ForeColor = Color.Black;
        }
        private void txtIdTarimaBusqueda_GotFocus(object sender, EventArgs e)
        {
            if (txtIdTarimaBusqueda.Text.Trim().Length == 0)
            {
                txtIdTarimaBusqueda.Text = "";
            }
        }
        private void txtIdTarimaBusqueda_LostFocus(object sender, EventArgs e)
        {
            if (txtIdTarimaBusqueda.Text.Trim().Length == 0)
            {
                txtIdTarimaBusqueda.Text = "DXXXXXXX";
                txtIdTarimaBusqueda.ForeColor = Color.LightGray;
            }
        }
        private void txtIdTarimaBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Regex regex = new Regex(@"^D\d{7}$");
                // Realizar la búsqueda y mostrar la información en los campos del formulario
                txtIdTarimaBusqueda.Text = txtIdTarimaBusqueda.Text.ToUpper();
                Match match = regex.Match(txtIdTarimaBusqueda.Text);
                if (!match.Success)
                {
                    // Mostrar mensaje de error
                    MessageBox.Show("El formato del texto ingresado no es válido. Debe ser DXXXXXXX.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIdTarimaBusqueda.Text = "";
                }
                else
                {
                    string idTarima = txtIdTarimaBusqueda.Text.Trim();
                    if (!string.IsNullOrEmpty(idTarima))
                    {
                        dgvTrazabilidad.DataSource = BusquedaBD.ObtenerTrazabilidad(idTarima);
                        lbFiltro.Enabled = true;
                        txtBuscar.Enabled = true;
                        pbGuardar.Enabled = true;
                        ConfigurarColumnasTrazabilidad();
                        ResaltarFilas();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un ID de Tarima.");
                    }
                    // Prevent the 'ding' sound
                    e.Handled = true;                    
                }                
            }            
        }
        private void ConfigurarColumnasTrazabilidad()
        {
            dgvTrazabilidad.Columns["idTraspaso"].HeaderText = "ID Traspaso";
            dgvTrazabilidad.Columns["idTarima"].HeaderText = "ID Tarima";
            dgvTrazabilidad.Columns["producto"].HeaderText = "Producto";
            dgvTrazabilidad.Columns["lote"].HeaderText = "Lote";
            dgvTrazabilidad.Columns["cantidad"].HeaderText = "Cantidad";
            dgvTrazabilidad.Columns["tipoOperacion"].HeaderText = "Tipo de Operación";
            dgvTrazabilidad.Columns["fechaOperacion"].HeaderText = "Fecha de Operación";
            dgvTrazabilidad.Columns["destino"].HeaderText = "Destino";
            dgvTrazabilidad.Columns["usuario"].HeaderText = "Usuario";
            dgvTrazabilidad.Columns["departamento"].HeaderText = "Departamento";
        }

        private void ResaltarFilas()
        {
            foreach (DataGridViewRow row in dgvTrazabilidad.Rows)
            {
                try
                {
                    string tipoOperacion = row.Cells["tipoOperacion"].Value.ToString();
                    if (tipoOperacion == "Traspaso")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                    else if (tipoOperacion == "Confirmacion Recepcion")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (tipoOperacion == "Devolucion")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else if (tipoOperacion == "Detenido")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else if (tipoOperacion == "Desbloqueado")
                    {
                        row.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                    }
                }
                catch (Exception)
                {
                    return;
                }
                
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            (dgvTrazabilidad.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("tipoOperacion LIKE '%{0}%' OR destino LIKE '%{0}%'", txtBuscar.Text);
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            string idTarima = txtIdTarimaBusqueda.Text;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            //sfd.Filter = "XLS files (*.XLS)|*.XLS";
            sfd.FileName = $"Trazabilidad. {idTarima}";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = (DataTable)dgvTrazabilidad.DataSource;
                ExportarDataTableAExcel(dt, sfd.FileName);
            }
        }
        private void ExportarDataTableAExcel(DataTable dt, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        private void dgvTrazabilidad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string idTarima = txtIdTarimaBusqueda.Text;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgvTrazabilidad[e.ColumnIndex, e.RowIndex];
                cell.ToolTipText = $"Trazabilidad  de combo o tarima {idTarima}";
            }
        }

        private void pbImpresion_Click(object sender, EventArgs e)
        {
            printTable = (DataTable)dgvTrazabilidad.DataSource;
            rowIndex = 0;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            /*int startX = 10;
            int startY = 10;
            int offsetY = 40;
            int rowHeight = 20;

            Font font = new Font("Arial", 8);
            Brush brush = Brushes.Black;

            int pageWidth = e.MarginBounds.Width;
            int columnWidth = pageWidth / printTable.Columns.Count;

            // Print column headers
            for (int i = 0; i < printTable.Columns.Count; i++)
            {
                e.Graphics.DrawString(printTable.Columns[i].ColumnName, font, brush, startX + (i * columnWidth), startY);
            }

            // Print rows
            while (rowIndex < printTable.Rows.Count)
            {
                if (offsetY + rowHeight > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
                for (int i = 0; i < printTable.Columns.Count; i++)
                {
                    e.Graphics.DrawString(printTable.Rows[rowIndex][i].ToString(), font, brush, startX + (i * columnWidth), startY + offsetY);
                }
                offsetY += rowHeight;
                rowIndex++;
            }
            e.HasMorePages = false;*/
            int startX = 10;
            int startY = 10;
            int offsetY = 40;
            int rowHeight = 20;

            Font font = new Font("Arial", 7);
            Brush brush = Brushes.Black;

            int pageWidth = e.MarginBounds.Width;
            int columnCount = printTable.Columns.Count;

            // Custom column widths (e.g., 15% for 'producto', 20% for 'lote', etc.)
            var columnWidths = new Dictionary<string, float>
            {
                { "idTraspaso", 0.15f },
                { "idTarima", 0.15f },
                { "producto", 0.15f },
                { "lote", 0.10f },
                { "cantidad", 0.10f },
                { "tipoOperacion", 0.17f },
                { "fechaOperacion", 0.17f },
                { "destino", 0.12f },
                { "usuario", 0.15f },
                { "departamento", 0.15f }
            };

            // Calculate remaining width for unspecified columns
            float specifiedWidth = columnWidths.Values.Sum();
            int unspecifiedColumns = columnCount - columnWidths.Count;
            float unspecifiedColumnWidth = unspecifiedColumns > 0 ? (1 - specifiedWidth) / unspecifiedColumns : 0;

            // Adjust column width dictionary to include unspecified columns
            foreach (DataColumn column in printTable.Columns)
            {
                if (!columnWidths.ContainsKey(column.ColumnName))
                {
                    columnWidths[column.ColumnName] = unspecifiedColumnWidth;
                }
            }

            // Convert widths to actual pixel values
            var pixelWidths = columnWidths.ToDictionary(kv => kv.Key, kv => (int)(kv.Value * pageWidth));

            // Print column headers
            int currentX = startX;
            foreach (DataColumn column in printTable.Columns)
            {
                e.Graphics.DrawString(column.ColumnName, font, brush, currentX, startY);
                currentX += pixelWidths[column.ColumnName];
            }

            // Print rows
            while (rowIndex < printTable.Rows.Count)
            {
                if (offsetY + rowHeight > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }

                currentX = startX;
                foreach (DataColumn column in printTable.Columns)
                {
                    e.Graphics.DrawString(printTable.Rows[rowIndex][column.ColumnName].ToString(), font, brush, currentX, startY + offsetY);
                    currentX += pixelWidths[column.ColumnName];
                }
                offsetY += rowHeight;
                rowIndex++;
            }
            e.HasMorePages = false;
        }
    }
}
