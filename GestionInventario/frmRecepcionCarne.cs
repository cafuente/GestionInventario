using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;
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

            // Define los supervisores disponibles
            string[] supervisores = { "Pablo B.", "Hugo B.", "José R." };

            // Agrega los supervisores al ComboBox
            cbTurno.Items.AddRange(supervisores);

        }

        private void frmRecepcionCarne_Load(object sender, EventArgs e)
        {
            // Deshabilitar el CheckBox al iniciar el formulario
            chbFijarDatos.Checked = false;
            chbFijarDatos.Enabled = false;
            // Habilitar todos los campos
            HabilitarCampos(true);
            pbCodigoBarras.Visible = true;
            pbCodigoBarras.Enabled = false;
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = false;
            //pbImpresionCb.Visible = true;
            pbImpresionCb.Enabled = false;
            //pbGuardarCb.Visible = true;
            pbGuardarCb.Enabled = false;
            // Se inician los datetimepicker en al fecha actual
            dpSacrificio.Value = DateTime.Now;
            dpEmpaque.Value = DateTime.Now;
            dpFecha.Value = DateTime.Now;

            // Crear una instancia de la clase InsercionDatosDAO
            InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();

            // Obtener el último ID de la tabla recepcion_carne
            string ultimoId = insercionDatosDAO.ObtenerUltimoId();

            // Mostrar el último ID en el idLabel
            idLabel.Text = ultimoId;
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

            // desde aqui funciona todo bien
            /*
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
            */
            //-----hasta aqui funciona todo bien

            // Verificar si todos los campos están llenos
            if (string.IsNullOrEmpty(txtLinea.Text) ||
                string.IsNullOrEmpty(txtProcedencia.Text) ||
                string.IsNullOrEmpty(txtFleje.Text) ||
                cbTurno.SelectedItem == null ||
                string.IsNullOrEmpty(txtCantidad.Text) ||
                string.IsNullOrEmpty(txtCajas.Text) ||
                string.IsNullOrEmpty(txtFactura.Text) ||
                string.IsNullOrEmpty(txtOrdenCompra.Text) ||
                string.IsNullOrEmpty(txtMarca.Text) ||
                string.IsNullOrEmpty(txtLote.Text) ||
                string.IsNullOrEmpty(txtProducto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de generar el código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generar el código de barras y mostrarlo en el PictureBox
            GenerarCodigoBarras();

        }

        private void btnModificarDatosCarne_Click(object sender, EventArgs e)
        {
            // Habilitar todos los campos de entrada
            //txtLinea.Enabled = true;
            //txtProcedencia.Enabled = true;
            //txtFleje.Enabled = true;
            //cbTurno.Enabled = true;
            //txtFleje.Enabled = true;
            //txtCantidad.Enabled = true;
            //txtCajas.Enabled = true;
            //txtFactura.Enabled = true;
            //txtOrdenCompra.Enabled = true;
            //txtMarca.Enabled = true;
            //txtLote.Enabled = true;
            //txtProducto.Enabled = true;
            //btnAgregarCarne.Enabled = true;
            //pbImpresionCb.Enabled = true;
            //pbGuardarCb.Enabled = true;

            HabilitarCampos(true);            
            

            // Desabilitar el botón para agregar carne
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = false;

            btnGenerarCodigoBarras.Visible = true;
            btnGenerarCodigoBarras.Enabled = true;
            pbImpresionCb.Enabled = false;
            pbGuardarCb.Enabled = false;
            pbCodigoBarras.Image = null;
            // Cargar la imagen predeterminada desde los recursos
            Image imagenPredeterminada = Properties.Resources.barcode_scan;
            // Asignar la imagen predeterminada al PictureBox
            pbCodigoBarras.Image = imagenPredeterminada;
            pbCodigoBarras.Enabled = false;

        }

        private void GenerarCodigoBarras()
        {

            // desde aqui funciona todo bien
            /*
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
            */
            // hasta aqui todo funcina bien

            // Obtener la información del producto, lote y cantidad
            string producto = txtProducto.Text;
            string lote = txtLote.Text;
            string cantidad = txtCantidad.Text;

            // Generar el código de barras
            BarcodeGenerator barcodeGenerator = new BarcodeGenerator();
            Bitmap barcodeImage = barcodeGenerator.GenerateBarcode(idLabel.Text);

            // Generar la imagen para la leyenda
            Font font = new Font("Arial", 16);
            Color colorTexto = Color.Black;
            Color colorFondo = Color.White;
            Bitmap leyendaImage = AyudanteImagen.TextoAImagen($"Producto: {producto} | Lote: {lote} | Cantidad: {cantidad}kg", font, colorTexto, colorFondo);

            // Combinar la imagen de la leyenda con el código de barras
            Bitmap combinedImage = AyudanteImagen.CombinarImagenes(leyendaImage, barcodeImage);

            // Mostrar el código de barras con la leyenda en el PictureBox
            pbCodigoBarras.Image = combinedImage;

            // Deshabilitar todos los campos de entrada
            //txtLinea.Enabled = false;
            //txtProcedencia.Enabled = false;
            //dpSacrificio.Enabled = false;
            //dpEmpaque.Enabled = false;
            //txtFleje.Enabled = false;
            //cbTurno.Enabled = false;
            //txtCantidad.Enabled = false;
            //txtCajas.Enabled = false;
            //txtFactura.Enabled = false;
            //txtOrdenCompra.Enabled = false;
            //txtMarca.Enabled = false;
            //txtLote.Enabled = false;
            //txtProducto.Enabled = false;
            //dpFecha.Enabled = false;
            HabilitarCampos(false);

            btnAgregarCarne.Enabled = false;
            pbImpresionCb.Enabled = Enabled;
            pbGuardarCb.Enabled = Enabled;
            pbCodigoBarras.Enabled = Enabled;
            
            // Habilitar el botón para agregar carne
            btnAgregarCarne.Enabled = true;

            // Mostrar el botón para modificar y deshabilitarlo
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = true;

            btnGenerarCodigoBarras.Visible = true;
            btnGenerarCodigoBarras.Enabled = false;

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
            // Obtener los valores ingresados por el usuario
            string id = idLabel.Text;
            string linea = txtLinea.Text;
            string procedencia = txtProcedencia.Text;
            DateTime fechaSacrificio = dpSacrificio.Value;
            DateTime fechaEmpaque = dpEmpaque.Value;
            string fleje = txtFleje.Text;
            string turno = cbTurno.SelectedItem.ToString();
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            int cajas = Convert.ToInt32(txtCajas.Text);
            string factura = txtFactura.Text;
            string ordenCompra = txtOrdenCompra.Text;
            string marca = txtMarca.Text;
            string lote = txtLote.Text;
            string producto = txtProducto.Text;
            DateTime fecha = dpFecha.Value;

            // Crear una instancia de la clase InsercionDatosDAO
            InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();

            // Llamar al método InsertarDatosRecepcionCarne para insertar los datos en la base de datos
            bool insercionExitosa = insercionDatosDAO.InsertarDatosRecepcionCarne(id,linea, procedencia, fechaSacrificio, fechaEmpaque, fleje, turno, cantidad, cajas, factura, ordenCompra, marca, lote, producto, fecha);

            // Verificar si la inserción fue exitosa
            if (insercionExitosa)
            {
                MessageBox.Show("Los datos se han agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chbFijarDatos.Checked)
                {
                    // Si el CheckBox está marcado, deshabilitar todos los campos excepto el de cantidad
                    HabilitarCampos(false);
                    txtCantidad.Enabled = true; // Habilitar el campo de cantidad
                }
                else
                {

                    //Habilitar los campos
                    HabilitarCampos(true);
                    // Limpiar los campos después de la inserción
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Error al agregar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void HabilitarCampos(bool habilitar) 
        {
            txtLinea.Enabled = habilitar;
            txtProcedencia.Enabled = habilitar;
            dpSacrificio.Enabled = habilitar;
            dpEmpaque.Enabled = habilitar;
            txtFleje.Enabled = habilitar;
            cbTurno.Enabled = habilitar;
            txtCantidad.Enabled = habilitar;
            txtCajas.Enabled = habilitar;
            txtFactura.Enabled = habilitar;
            txtOrdenCompra.Enabled = habilitar;
            txtMarca.Enabled = habilitar;
            txtLote.Enabled = habilitar;
            txtProducto.Enabled = habilitar;
            dpFecha.Enabled = habilitar;
            chbFijarDatos.Enabled = habilitar;
             
        }
                
        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            // Habilitar todos los campos de entrada
            //txtLinea.Enabled = true;
            //txtProcedencia.Enabled = true;
            //dpSacrificio.Enabled = true;
            //dpEmpaque.Enabled = true;
            //txtFleje.Enabled = true;
            //cbTurno.Enabled = true;
            //txtFleje.Enabled = true;
            //txtCantidad.Enabled = true;
            //txtCajas.Enabled = true;
            //txtFactura.Enabled = true;
            //txtOrdenCompra.Enabled = true;
            //txtMarca.Enabled = true;
            //txtLote.Enabled = true;
            //txtProducto.Enabled = true;
            //dpFecha.Enabled = true;
            //btnAgregarCarne.Enabled = true;
            pbImpresionCb.Enabled = false;
            pbGuardarCb.Enabled = false;


            // Desabilitar el botón para agregar carne
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnModificarDatosCarne.Visible = true;
            btnModificarDatosCarne.Enabled = false;
            // habilitar todos los campos
            //btnGenerarCodigoBarras.Visible = true;
            //btnGenerarCodigoBarras.Enabled = true;
            pbImpresionCb.Enabled = false;
            pbGuardarCb.Enabled = false;

            //limpiar campos
            txtLinea.Text = "";
            txtProcedencia.Text = "";
            dpSacrificio.Value = DateTime.Now;
            dpEmpaque.Value = DateTime.Now;
            txtFleje.Text = "";
            cbTurno.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtCajas.Text = "";
            txtFactura.Text = "";
            txtOrdenCompra.Text = "";
            txtMarca.Text = "";
            txtLote.Text = "";
            txtProducto.Text = "";
            dpFecha.Value = DateTime.Now;// Asignar la fecha actual
            txtLinea.Text = "";
            txtProcedencia.Text = "";
            dpSacrificio.Value = DateTime.Now;
            dpEmpaque.Value = DateTime.Now;
            txtFleje.Text = "";
            cbTurno.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtCajas.Text = "";
            txtFactura.Text = "";
            txtOrdenCompra.Text = "";
            txtMarca.Text = "";
            txtLote.Text = "";
            txtProducto.Text = "";
            dpFecha.Value = DateTime.Now;// Asignar la fecha actual
            pbCodigoBarras.Image = null;
            // Cargar la imagen predeterminada desde los recursos
            Image imagenPredeterminada = Properties.Resources.barcode_scan;
            // Asignar la imagen predeterminada al PictureBox
            pbCodigoBarras.Image = imagenPredeterminada;


        }

        //Metodo para hacer zoom al codigo de barras
        private void pbCodigoBarras_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                // Obtener la imagen actual
                Image image = pictureBox.Image;
                if (image != null)
                {
                    // Crear un formulario para mostrar la imagen en un PictureBox con capacidad de zoom
                    Form form = new Form();
                    form.Text = "Zoom del Código de Barras";
                    form.Size = new Size(800, 600);

                    PictureBox pbZoom = new PictureBox();
                    pbZoom.Dock = DockStyle.Fill;
                    pbZoom.Image = image;

                    // Habilitar la propiedad de zoom en el PictureBox
                    pbZoom.SizeMode = PictureBoxSizeMode.Zoom;

                    form.Controls.Add(pbZoom);
                    form.ShowDialog();
                }
            }
        }
    }
}
