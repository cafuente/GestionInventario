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
    public partial class frmGestionUsuarios : Form
    {
        public frmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbPerfil.Items.Add("Administrador");
            cbPerfil.Items.Add("Usuario");
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            UsuariosDAO usuariosDAO = new UsuariosDAO();
            List<Usuario> usuarios = usuariosDAO.ObtenerUsuarios();

            // Limpiar las filas existentes en el DataGridView
            dgGestionUsuarios.Rows.Clear();

            // Agregar los usuarios al DataGridView
            foreach (Usuario usuario in usuarios)
            {
                dgGestionUsuarios.Rows.Add(usuario.IdUsuario, usuario.usuario, usuario.Password, usuario.Nombre, ObtenerNombrePerfil(usuario.IdPerfil));
            }
            // Ajustar automáticamente el ancho de las columnas después de cargar los datos
            foreach (DataGridViewColumn columna in dgGestionUsuarios.Columns)
            {
                //columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void dgGestionUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgGestionUsuarios.Rows[e.RowIndex];
                // Mostrar la información del usuario seleccionado en los campos correspondientes
                lblId.Text = fila.Cells["IdUsuario"].Value.ToString();
                txtUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
                txtPassword.Text = fila.Cells["Password"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                cbPerfil.Text = fila.Cells["Perfil"].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string nombre = txtNombre.Text;
            string perfil = cbPerfil.Text;

            // Verificar que todos los campos estén completos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(perfil))
            {
                MessageBox.Show("Por favor, capture todos los campos.");
                return;
            }

            UsuariosDAO usuariosDAO = new UsuariosDAO();
            bool usuarioAgregado = usuariosDAO.CrearUsuario(usuario, password, nombre, perfil);

            if (usuarioAgregado)
            {
                MessageBox.Show("Usuario agregado correctamente.");
                CargarUsuarios(); // Recargar la lista de usuarios en el DataGridView
            }
            else
            {
                MessageBox.Show("Error al agregar usuario. Por favor, verifique los datos e intente nuevamente.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Mostrar el número de filas seleccionadas en el DataGridView (solo para verificar)
            //MessageBox.Show("Filas seleccionadas: " + dgGestionUsuarios.SelectedRows.Count);

            if (dgGestionUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para actualizar.");
                return;
            }

            // Obtener el id del usuario seleccionado
            int idUsuario = Convert.ToInt32(dgGestionUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string nombre = txtNombre.Text;
            string perfil = cbPerfil.Text;

            UsuariosDAO usuariosDAO = new UsuariosDAO();
            bool usuarioActualizado = usuariosDAO.ActualizarUsuario(idUsuario, usuario, password, nombre, perfil);

            if (usuarioActualizado)
            {
                MessageBox.Show("Usuario actualizado correctamente.");
                CargarUsuarios(); // Recargar la lista de usuarios en el DataGridView
                                  // Después de actualizar un usuario
                LimpiarCampos(); // Llama a un método para limpiar los campos                
            }
            else
            {
                MessageBox.Show("Error al actualizar usuario. Por favor, verifique los datos e intente nuevamente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgGestionUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                return;
            }

            // Obtener el id del usuario seleccionado
            int idUsuario = Convert.ToInt32(dgGestionUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

            DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                UsuariosDAO usuariosDAO = new UsuariosDAO();
                bool usuarioEliminado = usuariosDAO.EliminarUsuario(idUsuario);

                if (usuarioEliminado)
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios(); // Recargar la lista de usuarios en el DataGridView
                }
                else
                {
                    MessageBox.Show("Error al eliminar usuario. Por favor, inténtelo nuevamente.");
                }
            }
        }
        private void LimpiarCampos()
        {
            lblId.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            cbPerfil.SelectedIndex = -1; // O establece el valor por defecto
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el DataSource no es nulo
            if (dgGestionUsuarios.DataSource != null)
            {
                // Verificar si hay texto de búsqueda y al menos un CheckBox seleccionado
                if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && (chbId.Checked || chbUsuario.Checked || chbNombre.Checked || chbPerfil.Checked))
                {
                    string textoBusqueda = txtBuscar.Text.Trim().ToLower(); // Obtener el texto de búsqueda en minúsculas

                    // Obtener las columnas seleccionadas para la búsqueda
                    List<string> columnasSeleccionadas = new List<string>();
                    if (chbId.Checked) columnasSeleccionadas.Add("Id");
                    if (chbUsuario.Checked) columnasSeleccionadas.Add("Usuario");
                    if (chbNombre.Checked) columnasSeleccionadas.Add("Nombre");
                    if (chbPerfil.Checked) columnasSeleccionadas.Add("Perfil");

                    // Realizar la búsqueda en las columnas seleccionadas
                    string filtro = string.Empty;
                    if (columnasSeleccionadas.Count > 0) // Si se ha seleccionado al menos una columna
                    {
                        // Construir la expresión de búsqueda dinámica
                        filtro = string.Join(" OR ", columnasSeleccionadas.Select(columna => $"{columna} LIKE '%{textoBusqueda}%'"));
                    }
                    else // Si no se ha seleccionado ninguna columna, buscar en todas las columnas
                    {
                        // Construir la expresión de búsqueda para todas las columnas
                        filtro = string.Join(" OR ", dgGestionUsuarios.Columns.Cast<DataGridViewColumn>().Select(columna => $"{columna.DataPropertyName} LIKE '%{textoBusqueda}%'"));
                    }

                    // Aplicar el filtro al DataGridView
                    ((DataTable)dgGestionUsuarios.DataSource).DefaultView.RowFilter = filtro;
                }
                else // Si no hay texto de búsqueda o ningún CheckBox seleccionado, mostrar todos los registros
                {
                    ((DataTable)dgGestionUsuarios.DataSource).DefaultView.RowFilter = string.Empty;
                }
            }
        }
    }
}
