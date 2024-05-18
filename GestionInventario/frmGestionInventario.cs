using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            CargarDatosInventario();
        }        

        private void frmGestionInventario_Load(object sender, EventArgs e)
        {
            // Mostrar la información del usuario de sesion en el panel superior
            MostrarInformacionUsuario();           
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
                case 3:
                    return "Supervisor";
                default:
                    return "Desconocido";
            }
        }

        private void frmGestionInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }

        private void CargarDatosInventario()
        {
            DataTable dt = BusquedaBD.ObtenerInventario();
            dgvInventario.DataSource = dt;

            foreach (DataGridViewColumn columna in dgvInventario.Columns)
            {
                //columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }


        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            Devoluciones frmDev = new Devoluciones();
            frmDev.Show();
            Hide();
        }

        //aqui vamos.. hay q corregir
        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInventario.Rows[e.RowIndex];

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
        }
    }
}

