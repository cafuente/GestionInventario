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

namespace GestionInventario
{
    public partial class frmGestionInventario : Form
    {
        private ConexionBD conexion;
        private InsercionDatosDAO insercionDatosDAO;
        public frmGestionInventario()
        {
            InitializeComponent();
            conexion = new ConexionBD();
            insercionDatosDAO = new InsercionDatosDAO();
        }        

        private void frmGestionInventario_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();
            CargarDatosRecepcionCarne();

            dpSacrificio.Value = DateTime.Now;
            dpEmpaque.Value = DateTime.Now;
            dpFecha.Value = DateTime.Now;
        }
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreGi.Text = $"{frmLogin.UsuarioActual.Nombre}";
                lbDepartamentoGi.Text = $"{frmLogin.UsuarioActual.Departamento}";
                lbPerfilGi.Text = $"{nombrePerfil}";
                
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
                default:
                    return "Desconocido";
            }
        }

        private void frmGestionInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }
        private void CargarDatosRecepcionCarne()
        {
            try
            {
                string consulta = "SELECT * FROM recepcion_carne";

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

        private void dgRecepcionCarne_CellClick(object sender, DataGridViewCellEventArgs e)
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
                txtId.Text = id;
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
        }
    }
}

