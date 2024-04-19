using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class frmRecepcionCarne : Form
    {
        public frmRecepcionCarne()
        {
            InitializeComponent();
        }

        private void frmRecepcionCarne_Load(object sender, EventArgs e)
        {
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = false;
            //pbImpresionCb.Visible = true;
            pbImpresionCb.Enabled = false;
            //pbGuardarCb.Visible = true;
            pbGuardarCb.Enabled = false;
        }              

        private void btnGenerarCodigoBarras_Click(object sender, EventArgs e)
        {
            /*
            // Generar el código de barras y mostrarlo en el PictureBox
            BarcodeGenerator barcodeGenerator = new BarcodeGenerator();
            Bitmap barcodeImage = barcodeGenerator.GenerateBarcode(txtFactura.Text);
            pbCodigoBarras.Image = barcodeImage;            

            // Deshabilitar todos los campos de entrada
            txtLinea.Enabled = false;
            txtProcedencia.Enabled = false;
            txtFleje.Enabled = false;
            cbTurno.Enabled = false;
            txtFleje.Enabled = false;
            txtCantidad.Enabled = false;
            cbContenedor.Enabled = false;
            txtFactura.Enabled = false;
            txtOrdenCompra.Enabled = false;
            txtMarca.Enabled = false;
            txtLote.Enabled = false;
            txtProducto.Enabled = false;
            btnAgregarCarne.Enabled = false;
            pbImpresionCb.Enabled = Enabled;
            pbGuardarCb.Enabled = Enabled;
            

            // Otros campos aquí...

            // Habilitar el botón para agregar carne
            btnAgregarCarne.Enabled = true;

            // Mostrar el botón para modificar y deshabilitarlo
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = true;

            btnGenerarCodigoBarras.Visible = true;
            btnGenerarCodigoBarras.Enabled = false;
            */
            //---------------------------------- aqui todo funcionando

            /*----------- con leyecda-----
            // Generar la leyenda que deseas agregar al código de barras
            string leyenda = "Leyenda: " + DateTime.Now.ToString("dd/MM/yyyy");

            // Generar el código de barras y mostrarlo en el PictureBox
            BarcodeGenerator barcodeGenerator = new BarcodeGenerator();
            Bitmap barcodeImage = barcodeGenerator.GenerateBarcode(txtFactura.Text);

            // Añadir la leyenda al código de barras
            using (Graphics graphics = Graphics.FromImage(barcodeImage))
            {
                using (Font font = new Font("Arial", 10))
                {
                    // Se Define la posición y el color de la leyenda
                    PointF point = new PointF(10, barcodeImage.Height - 20);
                    SolidBrush brush = new SolidBrush(Color.Black);

                    // Se dibuja la leyenda en el código de barras
                    graphics.DrawString(leyenda, font, brush, point);
                }
            }

            // Se mostra el código de barras modificado en el PictureBox
            pbCodigoBarras.Image = barcodeImage;

            // Deshabilitar el botón Generar Código de Barras
            btnGenerarCodigoBarras.Enabled = false;

            // Habilitar el botón Agregar Carne
            btnAgregarCarne.Enabled = true;
            */
            //-----hasta aqui con leyenda----------------------

            // Obtener la información del producto, lote y cantidad
            string producto = txtProducto.Text;
            string lote = txtLote.Text;
            string cantidad = txtCantidad.Text;

            // Generar el código de barras
            BarcodeGenerator barcodeGenerator = new BarcodeGenerator();
            Bitmap barcodeImage = barcodeGenerator.GenerateBarcode(txtFactura.Text);

            // Agregar la leyenda al código de barras
            using (Graphics graphics = Graphics.FromImage(barcodeImage))
            {
                // Definir el texto de la leyenda
                string leyenda = $"P: {producto} | L: {lote} | Cant: {cantidad}";

                // Definir la fuente y el color del texto
                Font font = new Font("Arial", 15);
                SolidBrush brush = new SolidBrush(Color.Red);

                // Calcular la posición para centrar el texto horizontalmente y colocarlo en la parte superior del código de barras
                float x = (barcodeImage.Width - graphics.MeasureString(leyenda, font).Width) / 2;
                float y = 145; // Distancia desde la parte superior del código de barras

                // Dibujar la leyenda en el código de barras
                graphics.DrawString(leyenda, font, brush, x, y);
            }

            // Mostrar el código de barras con la leyenda en el PictureBox
            pbCodigoBarras.Image = barcodeImage;

            // Deshabilitar todos los campos de entrada
            txtLinea.Enabled = false;
            txtProcedencia.Enabled = false;
            txtFleje.Enabled = false;
            cbTurno.Enabled = false;
            txtFleje.Enabled = false;
            txtCantidad.Enabled = false;
            cbContenedor.Enabled = false;
            txtFactura.Enabled = false;
            txtOrdenCompra.Enabled = false;
            txtMarca.Enabled = false;
            txtLote.Enabled = false;
            txtProducto.Enabled = false;
            btnAgregarCarne.Enabled = false;
            pbImpresionCb.Enabled = Enabled;
            pbGuardarCb.Enabled = Enabled;
            
            // Habilitar el botón para agregar carne
            btnAgregarCarne.Enabled = true;

            // Mostrar el botón para modificar y deshabilitarlo
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = true;

            btnGenerarCodigoBarras.Visible = true;
            btnGenerarCodigoBarras.Enabled = false;


        }

        private void btnModificarDatosCarne_Click(object sender, EventArgs e)
        {
           // Habilitar todos los campos de entrada
            txtLinea.Enabled = true;
            txtProcedencia.Enabled = true;
            txtFleje.Enabled = true;
            cbTurno.Enabled = true;
            txtFleje.Enabled = true;
            txtCantidad.Enabled = true;
            cbContenedor.Enabled = true;
            txtFactura.Enabled = true;
            txtOrdenCompra.Enabled = true;
            txtMarca.Enabled = true;
            txtLote.Enabled = true;
            txtProducto.Enabled = true;
            btnAgregarCarne.Enabled = true;
            pbImpresionCb.Enabled = true;
            pbGuardarCb.Enabled = true;
            // Otros campos aquí...

            // Desabilitar el botón para agregar carne
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = false;

            btnGenerarCodigoBarras.Visible = true;
            btnGenerarCodigoBarras.Enabled = true;
            pbImpresionCb.Enabled = false;
            pbGuardarCb.Enabled = false;

        }

        private void pbImpresionCb_Click(object sender, EventArgs e)
        {
            // Verificar si hay una imagen en el PictureBox
            if (pbCodigoBarras.Image != null)
            {
                // Configurar el diálogo de impresión
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                // Mostrar el diálogo de impresión
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            else
            {
                // Si no hay una imagen en el PictureBox, mostrar un mensaje de error
                MessageBox.Show("No hay ningún código de barras para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metodo para imprimir
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Obtener la imagen del PictureBox
            Image image = pbCodigoBarras.Image;

            // Calcular las dimensiones de la página y de la imagen
            Rectangle marginBounds = e.MarginBounds;
            float aspectRatio = (float)image.Width / (float)image.Height;
            int width = marginBounds.Width;
            int height = (int)(width / aspectRatio);

            // Dibujar la imagen en la página
            e.Graphics.DrawImage(image, marginBounds.Left, marginBounds.Top, width, height);
        }

        private void pbGuardarCb_Click(object sender, EventArgs e)
        {
            string leyenda = txtProducto.Text+"-" + txtLote.Text +"-" + txtCantidad.Text+" kg";
            // Verificar si hay una imagen en el PictureBox
            if (pbCodigoBarras.Image != null)
            {
                // Mostrar un cuadro de diálogo para guardar la imagen
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = leyenda;
                saveDialog.Filter = "Archivos de imagen (*.png)|*.png|Todos los archivos (*.*)|*.*";
                saveDialog.Title = "Guardar código de barras";

                // Mostrar el cuadro de diálogo y verificar si el usuario ha seleccionado un archivo
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del archivo seleccionado por el usuario
                    string filePath = saveDialog.FileName;

                    // Guardar la imagen en el archivo seleccionado
                    pbCodigoBarras.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("El código de barras se ha guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Si no hay una imagen en el PictureBox, mostrar un mensaje de error
                MessageBox.Show("No hay ningún código de barras para guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCarne_Click(object sender, EventArgs e)
        {

        }
    }
}
