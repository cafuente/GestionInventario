﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventario
{
    public partial class FrmRecepcionCarne : Form
    {
        private AlertaInventarioService alertaInventarioService;
        private AlertaVencimientoService alertaVencimientoService;
        private ConexionBD conexion;        

        public FrmRecepcionCarne()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            InicializarServicios();
            ConfigurarControles();

            // Define los supervisores disponibles
            string[] supervisores = { "Pablo B.", "Hugo B.", "José R." };

            // Agrega los supervisores al ComboBox
            cbTurno.Items.AddRange(supervisores);
        }

        private void frmRecepcionCarne_Load(object sender, EventArgs e)
        {
            // Deshabilitar el CheckBox al iniciar el formulario
            chbFijarDatos.Checked = false;
            chbFijarDatos.Enabled = true;
            // Habilitar todos los campos
            HabilitarCampos(true);
            pbCodigoBarras.Visible = true;
            pbCodigoBarras.Enabled = false;
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnActualizarCodigoBarras.Visible = true;
            btnActualizarCodigoBarras.Enabled = false;
            //pbImpresionCb.Visible = true;
            pbImpresionCb.Enabled = false;
            //pbGuardarCb.Visible = true;
            pbGuardarCb.Enabled = false;
            // Se inician los datetimepicker en al fecha actual
            dpSacrificio.Value = DateTime.Now;
            dpEmpaque.Value = DateTime.Now;
            dpFecha.Value = DateTime.Now;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;

            // Crear una instancia de la clase InsercionDatosDAO
            InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();

            // Obtener el último ID de la tabla recepcion_carne
            string ultimoId = insercionDatosDAO.ObtenerUltimoId();

            // Mostrar el último ID en el idLabel
            idLabel.Text = ultimoId;

            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            //mostrar informacion en el datagrid
            dgRecepcionCarne.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CargarDatosRecepcionCarne();
            //alertas
            chkAlertasRc.Checked = true;
            chkAlertasRc.Visible = false;
            //InicializarServicios();
            ConfigurarControles();

        }
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (FrmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(FrmLogin.UsuarioActual.IdPerfil);
                
                lbNombreRc.Text = $"{FrmLogin.UsuarioActual.Nombre}";
                lbDepartamentoRc.Text = $"{FrmLogin.UsuarioActual.Departamento}";
                //lbPerfilRc.Text = $"{nombrePerfil}";
                lbPerfilRc.Text = $"{FrmLogin.UsuarioActual.PerfilNombre}";

                // Crear instancia de UsuariosDAO
                UsuariosDAO usuariosDAO = new UsuariosDAO();

                // Cargar la imagen del usuario desde la base de datos
                byte[] imagenUsuario = usuariosDAO.ObtenerImagenUsuario(FrmLogin.UsuarioActual.IdUsuario);
                if (imagenUsuario != null && imagenUsuario.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imagenUsuario))
                    {
                        pbLogoRc.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbLogoRc.Image = Properties.Resources.user_account; // Imagen predeterminada
                }
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

        private void InicializarServicios()
        {
            alertaInventarioService = new AlertaInventarioService(txtUmbralRc, chkAlertasRc, "Almacen carnicos");
            alertaVencimientoService = new AlertaVencimientoService(chkAlertasRc, "Almacen carnicos");
        }

        private void btnGenerarCodigoBarras_Click(object sender, EventArgs e)
        {
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
                string.IsNullOrEmpty(txtProducto.Text) ||
                string.IsNullOrEmpty(txtTara.Text)||
                string.IsNullOrEmpty(txtPeso.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de generar el código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generar el código de barras y mostrarlo en el PictureBox
            GenerarCodigoBarras();
            btnAgregarCarne.Enabled = true;
            btnGenerarCodigoBarras.Enabled = false;
            pbCodigoBarras.Enabled = true;
            pbImpresionCb.Enabled = true;
            pbGuardarCb.Enabled = true;
            btnCancelar.Enabled = true;
        }       

        private void GenerarCodigoBarras()
        {
            // Obtener la información del producto, lote y cantidad
            string producto = txtProducto.Text;
            string lote = txtLote.Text;
            string cantidad = txtPeso.Text;

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

            HabilitarCampos(false);
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
            string leyenda = txtProducto.Text+"-" + txtLote.Text +"-" + txtPeso.Text+" kg";
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
            float cantidad = float.Parse(txtCantidad.Text);
            int cajas = Convert.ToInt32(txtCajas.Text);
            string factura = txtFactura.Text;
            string ordenCompra = txtOrdenCompra.Text;
            string marca = txtMarca.Text;
            string lote = txtLote.Text;
            string producto = txtProducto.Text;
            DateTime fecha = dpFecha.Value;
            int tara = Convert.ToInt32(txtTara.Text);
            float peso = float.Parse(txtPeso.Text);
            string departamento = lbDepartamentoRc.Text;
            float disponible = float.Parse(txtPeso.Text);
            string nombreUsuario = lbNombreRc.Text;

            // Crear una instancia de la clase InsercionDatosDAO
            InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();

            // Llamar al método InsertarDatosRecepcionCarne para insertar los datos en la base de datos
            bool insercionExitosa = insercionDatosDAO.InsertarDatosRecepcionCarne(id,linea, procedencia, fechaSacrificio, fechaEmpaque, fleje, turno, cantidad, cajas, factura, ordenCompra, marca, lote, producto, fecha, tara, peso,departamento, disponible, nombreUsuario);

            // Verificar si la inserción fue exitosa
            if (insercionExitosa)
            {
                MessageBox.Show("Los datos se han agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chbFijarDatos.Checked)
                {
                    // Si el CheckBox está marcado, deshabilitar todos los campos excepto el de cantidad
                    HabilitarCampos(false);
                    txtPeso.Enabled = true;
                    txtTara.Enabled = true;
                    txtPeso.Text = "";
                    txtTara.Text = "";
                    btnGenerarCodigoBarras.Enabled = true;
                    pbImpresionCb.Enabled = false;
                    pbGuardarCb.Enabled = false;                                        
                    Image imagenPredeterminada = Properties.Resources.barcode_scan;                    
                    pbCodigoBarras.Image = imagenPredeterminada;
                    btnAgregarCarne.Enabled = false;
                    btnActualizarCodigoBarras.Enabled = false;
                    string nuevoId = insercionDatosDAO.ObtenerUltimoId();
                    idLabel.Text = nuevoId;
                    CargarDatosRecepcionCarne();
                }
                else
                {                                        
                    HabilitarCampos(true);
                    LimpiarCampos();
                    string nuevoId = insercionDatosDAO.ObtenerUltimoId();
                    idLabel.Text = nuevoId;
                    Image imagenPredeterminada = Properties.Resources.barcode_scan;
                    pbCodigoBarras.Image = imagenPredeterminada;
                    pbCodigoBarras.Enabled = false;
                    btnGenerarCodigoBarras.Enabled= true;
                    pbGuardarCb.Enabled = false;
                    pbImpresionCb.Enabled= false;
                    btnAgregarCarne.Enabled = false;
                    CargarDatosRecepcionCarne();
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
            //chbFijarDatos.Enabled = habilitar;
            txtTara.Enabled = habilitar;
            txtPeso.Enabled = habilitar;
        }
                
        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            pbImpresionCb.Enabled = false;
            pbGuardarCb.Enabled = false;

            // Desabilitar el botón para agregar carne            
            btnActualizarCodigoBarras.Visible = true;
            btnActualizarCodigoBarras.Enabled = false;
            
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
            txtTara.Text = "";
            txtPeso.Text = "";
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

        private void CargarDatosRecepcionCarne()
        {
            try
            {
                string consulta = "SELECT * FROM recepcion_carne ORDER BY id DESC";

                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Asignar el DataTable como origen de datos del DataGridView
                            dgRecepcionCarne.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de recepcion_carne: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRecepcionCarne_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal frmP = new FrmPrincipal(FrmLogin.UsuarioActual);
            frmP.Show();
        }

        private void dgRecepcionCarne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar si se hizo clic en una fila válida
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgRecepcionCarne.Rows[e.RowIndex];

                    // Obtener los valores de la fila seleccionada
                    string id = fila.Cells["Id"].Value.ToString();
                    string linea = fila.Cells["Linea"].Value.ToString();
                    string procedencia = fila.Cells["Procedencia"].Value.ToString();
                    DateTime fechaSacrificio = Convert.ToDateTime(fila.Cells["Fecha_Sacrificio"].Value);
                    DateTime fechaEmpaque = Convert.ToDateTime(fila.Cells["Fecha_Empaque"].Value);
                    string fleje = fila.Cells["Fleje"].Value.ToString();
                    string turno = fila.Cells["Turno"].Value.ToString();
                    float cantidad = Convert.ToSingle(fila.Cells["Cantidad"].Value);
                    int cajas = Convert.ToInt32(fila.Cells["Cajas"].Value);
                    string factura = fila.Cells["Factura"].Value.ToString();
                    string ordenCompra = fila.Cells["Orden_Compra"].Value.ToString();
                    string marca = fila.Cells["Marca"].Value.ToString();
                    string lote = fila.Cells["Lote"].Value.ToString();
                    string producto = fila.Cells["Producto"].Value.ToString();
                    DateTime fecha = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                    int tara = Convert.ToInt32(fila.Cells["Tara"].Value);
                    float peso = Convert.ToSingle(fila.Cells["Peso"].Value);

                    // Asignar los valores a los controles correspondientes
                    idLabel.Text = id;
                    txtLinea.Text = linea;
                    txtProcedencia.Text = procedencia;
                    dpSacrificio.Value = fechaSacrificio;
                    dpEmpaque.Value = fechaEmpaque;
                    txtFleje.Text = fleje;
                    cbTurno.Text = turno;
                    txtCantidad.Text = cantidad.ToString();
                    txtCajas.Text = cajas.ToString();
                    txtFactura.Text = factura;
                    txtOrdenCompra.Text = ordenCompra;
                    txtMarca.Text = marca;
                    txtLote.Text = lote;
                    txtProducto.Text = producto;
                    dpFecha.Value = fecha;
                    txtTara.Text = tara.ToString();
                    txtPeso.Text = peso.ToString();
                }
                //btnAgregarCarne.Enabled = false;
                btnActualizarCodigoBarras.Enabled = true;
                btnGenerarCodigoBarras.Enabled = false;
                btnEliminar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();
                string nuevoId = insercionDatosDAO.ObtenerUltimoId();
                idLabel.Text = nuevoId;
                HabilitarCampos(true);

                // Desabilitar el botón para agregar carne
                btnAgregarCarne.Visible = true;
                btnAgregarCarne.Enabled = false;
                btnActualizarCodigoBarras.Visible = true;
                btnActualizarCodigoBarras.Enabled = false;
                // codigo de barras
                btnGenerarCodigoBarras.Visible = true;
                btnGenerarCodigoBarras.Enabled = true;
                chbFijarDatos.Enabled = true;
                chbFijarDatos.Checked = false;
                pbImpresionCb.Enabled = false;
                pbGuardarCb.Enabled = false;
                pbCodigoBarras.Image = null;
                dgRecepcionCarne.Enabled = true;
                // Cargar la imagen predeterminada desde los recursos
                Image imagenPredeterminada = Properties.Resources.barcode_scan;
                // Asignar la imagen predeterminada al PictureBox
                pbCodigoBarras.Image = imagenPredeterminada;
                pbCodigoBarras.Enabled = false;

                LimpiarCampos();
                btnEliminar.Enabled = false;
                btnCancelar.Enabled = false;
                btnActualizar.Enabled = false;
            }           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();
            string nuevoId = insercionDatosDAO.ObtenerUltimoId();
            idLabel.Text = nuevoId;
            HabilitarCampos(true);

            // Desabilitar el botón para agregar carne
            btnAgregarCarne.Visible = true;
            btnAgregarCarne.Enabled = false;
            btnActualizarCodigoBarras.Visible = true;
            btnActualizarCodigoBarras.Enabled = false;
            // codigo de barras
            btnGenerarCodigoBarras.Visible = true;
            btnGenerarCodigoBarras.Enabled = true;
            chbFijarDatos.Enabled = true;
            chbFijarDatos.Checked = false;
            pbImpresionCb.Enabled = false;
            pbGuardarCb.Enabled = false;
            pbCodigoBarras.Image = null;
            dgRecepcionCarne.Enabled = true;
            // Cargar la imagen predeterminada desde los recursos
            Image imagenPredeterminada = Properties.Resources.barcode_scan;
            // Asignar la imagen predeterminada al PictureBox
            pbCodigoBarras.Image = imagenPredeterminada;
            pbCodigoBarras.Enabled = false;

            LimpiarCampos();
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnActualizar.Enabled = false;            
        }

        private void btnActualizarCodigoBarras_Click(object sender, EventArgs e)
        {
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
                string.IsNullOrEmpty(txtProducto.Text) ||
                string.IsNullOrEmpty(txtTara.Text) ||
                string.IsNullOrEmpty(txtPeso.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de generar el código de barras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generar el código de barras y mostrarlo en el PictureBox
            GenerarCodigoBarras();
            btnEliminar.Enabled=false;
            chbFijarDatos.Enabled=false;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = true;
            pbCodigoBarras.Enabled = true;
            pbGuardarCb.Enabled = true;
            pbImpresionCb.Enabled = true;
            btnActualizarCodigoBarras.Enabled=false;
            dgRecepcionCarne.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles en el formulario
            string id = idLabel.Text;
            string linea = txtLinea.Text;
            string procedencia = txtProcedencia.Text;
            DateTime fechaSacrificio = dpSacrificio.Value;
            DateTime fechaEmpaque = dpEmpaque.Value;
            string fleje = txtFleje.Text;
            string turno = cbTurno.SelectedItem.ToString();
            float cantidad = float.Parse(txtCantidad.Text);
            int cajas = Convert.ToInt32(txtCajas.Text);
            string factura = txtFactura.Text;
            string ordenCompra = txtOrdenCompra.Text;
            string marca = txtMarca.Text;
            string lote = txtLote.Text;
            string producto = txtProducto.Text;
            DateTime fecha = dpFecha.Value;
            int tara = Convert.ToInt32(txtTara.Text);
            float peso = float.Parse(txtPeso.Text);
            string departamento = lbDepartamentoRc.Text;
            float disponible = float.Parse(txtPeso.Text);
            string nombreUsuario = lbNombreRc.Text;

            // Crear una instancia de la clase InsercionDatosDAO
            InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();

            // Llamar al método ActualizarDatosRecepcionCarne para actualizar los datos en la base de datos
            bool operacionExitosa = insercionDatosDAO.ActualizarDatosRecepcionCarne(id, linea, procedencia, fechaSacrificio, fechaEmpaque, fleje, turno, cantidad, cajas, factura, ordenCompra, marca, lote, producto, fecha, tara, peso, departamento, disponible, nombreUsuario);

            if (operacionExitosa)
            {
                MessageBox.Show("Los datos se han actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chbFijarDatos.Checked)
                {
                    // Si el CheckBox está marcado, deshabilitar todos los campos excepto el de cantidad
                    HabilitarCampos(false);
                    txtPeso.Enabled = true;
                    txtTara.Enabled = true;
                    txtPeso.Text = "";
                    txtTara.Text = "";
                    btnGenerarCodigoBarras.Enabled = true;
                    pbImpresionCb.Enabled = false;
                    pbGuardarCb.Enabled = false;
                    Image imagenPredeterminada = Properties.Resources.barcode_scan;
                    pbCodigoBarras.Image = imagenPredeterminada;
                    btnAgregarCarne.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnActualizarCodigoBarras.Enabled = false;
                    btnCancelar.Enabled = true;
                    dgRecepcionCarne.Enabled = Enabled;
                    //chbFijarDatos.Enabled = true;                    
                    CargarDatosRecepcionCarne();
                    txtTara.Focus();
                }
                else
                {
                    HabilitarCampos(true);
                    LimpiarCampos();
                    string newId = insercionDatosDAO.ObtenerUltimoId();
                    idLabel.Text = newId;
                    Image imagenPredeterminada = Properties.Resources.barcode_scan;
                    pbCodigoBarras.Image = imagenPredeterminada;
                    pbCodigoBarras.Enabled = false;
                    btnGenerarCodigoBarras.Enabled = true;
                    pbGuardarCb.Enabled = false;
                    pbImpresionCb.Enabled = false;
                    btnAgregarCarne.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnCancelar .Enabled = false;
                    chbFijarDatos.Enabled = true;
                    dgRecepcionCarne.Enabled = true;
                    CargarDatosRecepcionCarne();
                }
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string nuevoId = insercionDatosDAO.ObtenerUltimoId();
            idLabel.Text = nuevoId;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgRecepcionCarne.SelectedRows.Count > 0)
            {
                // Obtener el ID del registro seleccionado
                string id = dgRecepcionCarne.SelectedRows[0].Cells["id"].Value.ToString();

                // Mostrar un mensaje de confirmación antes de eliminar el registro
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Crear una instancia de la clase InsercionDatosDAO
                    InsercionDatosDAO insercionDatosDAO = new InsercionDatosDAO();

                    // Llamar al método EliminarDatosRecepcionCarne para eliminar el registro
                    bool eliminacionExitosa = insercionDatosDAO.EliminarDatosRecepcionCarne(id);

                    // Verificar si la eliminación fue exitosa
                    if (eliminacionExitosa)
                    {
                        MessageBox.Show("El registro se ha eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar el DataGridView para reflejar los cambios
                        CargarDatosRecepcionCarne();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBusquedaRc_TextChanged(object sender, EventArgs e)
       {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBusquedaRc.Text.Trim();

            if (chkId.Checked || chkFechaSacrificio.Checked || chkFechaEmpaque.Checked || chkMarca.Checked || chkProducto.Checked)
            {
                // Si hay algún CheckBox activado, ejecutar la búsqueda condicionada
                EjecutarBusquedaCondicionada(terminoBusqueda);
            }
            else
            {
                // Si no hay ningún CheckBox activado, ejecutar la búsqueda sin condiciones
                EjecutarBusquedaNoCondicionada(terminoBusqueda);
            }
        }

        private void EjecutarBusquedaCondicionada(string terminoBusqueda)
        {
            // Construir la consulta SQL dinámica según los CheckBox activados
            List<string> condiciones = new List<string>();

            if (chkId.Checked)
                condiciones.Add("id LIKE @termino");
            if (chkFechaSacrificio.Checked)
                condiciones.Add("fecha_sacrificio LIKE @termino");
            if (chkFechaEmpaque.Checked)
                condiciones.Add("fecha_empaque LIKE @termino");
            if (chkMarca.Checked)
                condiciones.Add("marca LIKE @termino");
            if (chkProducto.Checked)
                condiciones.Add("producto LIKE @termino");

            string consulta = "SELECT * FROM recepcion_carne WHERE " + string.Join(" OR ", condiciones);

            try
            {
                // Crear la conexión a la base de datos
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    // Abrir la conexión
                    con.Open();

                    // Crear el comando SQL
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        // Asignar el término de búsqueda como parámetro
                        cmd.Parameters.AddWithValue("@termino", $"%{terminoBusqueda}%");

                        // Crear un adaptador de datos y un DataTable para almacenar los resultados
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            // Llenar el DataTable con los resultados de la consulta
                            adapter.Fill(dt);

                            // Asignar el DataTable como origen de datos del DataGridView
                            dgRecepcionCarne.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda condicionada: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EjecutarBusquedaNoCondicionada(string terminoBusqueda)
        {
            // Consulta SQL para buscar en todas las columnas
            string consulta = "SELECT * FROM recepcion_carne WHERE " +
                              "id LIKE @termino OR " +
                              "linea LIKE @termino OR " +
                              "procedencia LIKE @termino OR " +
                              "fecha_sacrificio LIKE @termino OR " +
                              "fecha_empaque LIKE @termino OR " +
                              "fleje LIKE @termino OR " +
                              "turno LIKE @termino OR " +
                              "cantidad LIKE @termino OR " +
                              "cajas LIKE @termino OR " +
                              "factura LIKE @termino OR " +
                              "orden_compra LIKE @termino OR " +
                              "marca LIKE @termino OR " +
                              "lote LIKE @termino OR " +
                              "producto LIKE @termino OR " +
                              "fecha LIKE @termino OR " +
                              "tara LIKE @termino OR " +
                              "peso LIKE @termino OR " +
                              "departamento LIKE @termino OR " +
                              "cantidad_disponible LIKE @termino OR " +
                              "nombreUsuario LIKE @termino";
            try
            {
                // Crear la conexión a la base de datos
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    // Abrir la conexión
                    con.Open();

                    // Crear el comando SQL
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        // Asignar el término de búsqueda como parámetro
                        cmd.Parameters.AddWithValue("@termino", $"%{terminoBusqueda}%");

                        // Crear un adaptador de datos y un DataTable para almacenar los resultados
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            // Llenar el DataTable con los resultados de la consulta
                            adapter.Fill(dt);

                            // Asignar el DataTable como origen de datos del DataGridView
                            dgRecepcionCarne.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda sin condición: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        } 

        private void txtCodigoBarrasRc_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* // opcion con clase busqueda
            BusquedaCb objetoBusqueda = new BusquedaCb();
            objetoBusqueda.ProcesarCodigoBarras(txtCodigoBarrasRc, idLabel, txtLinea, txtProcedencia, dpSacrificio);
            */

            // otra opcion
            try
            {
                // Verificar si se presionó la tecla Enter
                if (e.KeyChar == (char)Keys.Enter)
                {
                    // Realizar la búsqueda y mostrar la información en los campos del formulario
                    BuscarYMostrarInformacion();
                    txtCodigoBarrasRc.Clear();
                    btnActualizarCodigoBarras.Enabled = true;
                    btnGenerarCodigoBarras.Enabled = false;
                    btnCancelar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }                
        }

        private void BuscarYMostrarInformacion()
        {
            // Obtener el código de barras ingresado por el usuario
            string codigoBarras = txtCodigoBarrasRc.Text.Trim();

            // Realizar la búsqueda en el DataGridView y obtener el índice de la fila correspondiente
            int indiceFila = BuscarFilaPorCodigoBarras(codigoBarras);

            // Mostrar la información en los campos del formulario
            MostrarInformacionEnCampos(indiceFila);
        }

        private int BuscarFilaPorCodigoBarras(string codigoBarras)
        {
            // Iterar sobre todas las filas del DataGridView
            for (int i = 0; i < dgRecepcionCarne.Rows.Count; i++)
            {
                // Obtener el valor de la celda correspondiente a la columna de código de barras
                string valorCelda = dgRecepcionCarne.Rows[i].Cells["id"].Value.ToString();

                // Comparar el valor de la celda con el código de barras buscado
                if (valorCelda == codigoBarras)
                {
                    // Si se encuentra el código de barras, devolver el índice de la fila
                    return i;
                }
            }

            // Si no se encuentra el código de barras, devolver -1 para indicar que no se encontró
            return -1;
        }

        private void MostrarInformacionEnCampos(int indiceFila)
        {
            if (indiceFila >= 0)
            {
                // Obtener la fila correspondiente al índice
                DataGridViewRow fila = dgRecepcionCarne.Rows[indiceFila];

                // Mostrar la información en los campos del formulario
                idLabel.Text = fila.Cells["id"].Value.ToString();
                txtLinea.Text = fila.Cells["linea"].Value.ToString();
                txtProcedencia.Text = fila.Cells["procedencia"].Value.ToString();
                dpSacrificio.Text = fila.Cells["fecha_sacrificio"].Value.ToString();
                dpEmpaque.Text = fila.Cells["fecha_empaque"].Value.ToString();
                txtFleje.Text= fila.Cells["fleje"].Value.ToString();
                cbTurno.Text = fila.Cells["turno"].Value.ToString();
                txtCantidad.Text = fila.Cells["cantidad"].Value.ToString();
                txtCajas.Text = fila.Cells["cajas"].Value.ToString();
                txtFactura.Text = fila.Cells["factura"].Value.ToString();
                txtOrdenCompra.Text = fila.Cells["orden_compra"].Value.ToString();
                txtMarca.Text = fila.Cells["marca"].Value.ToString();
                txtLote.Text = fila.Cells["lote"].Value.ToString();
                txtProducto.Text = fila.Cells["producto"].Value.ToString();
                dpFecha.Text = fila.Cells["fecha"].Value.ToString();
                txtTara.Text = fila.Cells["tara"].Value.ToString();
                txtPeso.Text = fila.Cells["peso"].Value.ToString();                                
            }
            else
            {
                // Mensaje en caso de no encontrar ninguna fila con el código de barras
                MessageBox.Show("No se encontró ninguna tarima o combo con el código de barras proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*  //metodo de busqueda y llenado en datagrid por lector codigo de barras y clase
        private void ProcesarCodigoBarras(string idLabel)
        {
            // Construir la consulta SQL para buscar el ID en la base de datos
            string consulta = "SELECT * FROM recepcion_carne WHERE id = @id";
            try
            {
                // Crear la conexión a la base de datos
                using (MySqlConnection con = conexion.ObtenerConexion())
                {
                    // Abrir la conexión
                    con.Open();

                    // Crear el comando SQL
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        // Asignar el ID como parámetro
                        cmd.Parameters.AddWithValue("@id", idLabel);

                        // Crear un adaptador de datos y un DataTable para almacenar los resultados
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            // Llenar el DataTable con los resultados de la consulta
                            adapter.Fill(dt);
                            // Asignar el DataTable como origen de datos del DataGridView
                            dgRecepcionCarne.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        // Servicio de Alertas
        public class AlertaInventarioService
        {
            private TextBox txtUmbral;
            private CheckBox chkAlertas;
            private string departamento;

            public AlertaInventarioService(TextBox umbral, CheckBox alertas, string depto)
            {
                txtUmbral = umbral;
                chkAlertas = alertas;
                departamento = depto;
            }

            public void VerificarInventario()
            {
                if (!chkAlertas.Checked) return;

                int umbral = int.Parse(txtUmbral.Text);
                DataTable inventario = BusquedaBD.ObtenerInventarioAgrupadoPorDepartamento(departamento);
                foreach (DataRow row in inventario.Rows)
                {
                    int cantidad = Convert.ToInt32(row["cantidad_total"]);
                    if (cantidad < umbral)
                    {
                        MostrarNotificacion($"El producto {row["producto"]} (Lote: {row["lote"]}) tiene un inventario bajo de {cantidad} unidades.");
                    }
                }
            }

            private void MostrarNotificacion(string mensaje)
            {
                MessageBox.Show(mensaje, "Alerta de Bajo Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public class AlertaVencimientoService
        {
            private CheckBox chkAlertas;
            private string departamento;

            public AlertaVencimientoService(CheckBox alertas, string depto)
            {
                chkAlertas = alertas;
                departamento = depto;
            }

            public void VerificarVencimientos()
            {
                if (!chkAlertas.Checked) return;

                DataTable inventario = BusquedaBD.ObtenerInventarioConFechasAgrupadoPorDepartamento(departamento);
                foreach (DataRow row in inventario.Rows)
                {
                    DateTime fechaSacrificio = Convert.ToDateTime(row["fecha_sacrificio"]);
                    DateTime fechaVencimiento;
                    string producto = row["producto"].ToString();
                    string lote = row["lote"].ToString();
                    int cantidadTotal = Convert.ToInt32(row["cantidad_total"]);

                    if (producto.EndsWith("FCA"))
                    {
                        fechaVencimiento = fechaSacrificio.AddDays(10);
                    }
                    else if (producto.EndsWith("CONG"))
                    {
                        fechaVencimiento = fechaSacrificio.AddYears(1);
                    }
                    else
                    {
                        continue;
                    }

                    if (fechaVencimiento <= DateTime.Now)
                    {
                        MostrarNotificacion($"El producto {producto} (Lote: {lote}) con cantidad total de {cantidadTotal} está próximo a vencer el {fechaVencimiento.ToShortDateString()}.");
                    }
                }
            }

            private void MostrarNotificacion(string mensaje)
            {
                MessageBox.Show(mensaje, "Alerta de Vencimiento de Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarControles()
        {
            txtUmbralRc.Text = "20000"; // Umbral por defecto

            // Solo el administrador puede editar el umbral
            if (lbPerfilRc.Text == "Administrador")
            {
                txtUmbralRc.Visible = true;
                lbAlerta.Visible = true;
                chkAlertasRc.Visible = true;
            }
            else
            {
                txtUmbralRc.Visible = false;
                lbAlerta.Visible = false;
            }

            // Verificar inventario y vencimientos automáticamente al abrir el formulario
            this.Load += (s, e) =>
            {
                alertaInventarioService.VerificarInventario();
                alertaVencimientoService.VerificarVencimientos();
            };
        }

        private void txtUmbralRc_TextChanged(object sender, EventArgs e)
        {
            alertaInventarioService.VerificarInventario();
        }

        private void chkAlertasRc_CheckedChanged(object sender, EventArgs e)
        {
            alertaInventarioService.VerificarInventario();
            alertaVencimientoService.VerificarVencimientos();
        }

       private void pbCargarImagenRc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    byte[] imageBytes = File.ReadAllBytes(filePath);

                    // Crear instancia de UsuariosDAO
                    UsuariosDAO usuariosDAO = new UsuariosDAO();

                    // Guardar la imagen en la base de datos
                    usuariosDAO.GuardarImagenUsuario(FrmLogin.UsuarioActual.IdUsuario, imageBytes);

                    // Mostrar la imagen en el PictureBox
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbLogoRc.Image = Image.FromStream(ms);
                    }
                }
            }
        }
    }
}
