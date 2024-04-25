using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            cbDepartamento.Items.Add("Almacen carnicos");
            cbDepartamento.Items.Add("Control de Produccion");
            cbDepartamento.Items.Add("Limpieza y Formulacion");
            cbDepartamento.Items.Add("Recepcion(mocha)");
            cbDepartamento.Items.Add("Mezclado");

            btnActualizar.Visible = true;
            btnActualizar.Enabled = false;
            btnEliminar.Visible = true;
            btnEliminar.Enabled = false;
            txtUsuario.Focus();
            CargarUsuarios();
            MostrarInformacionUsuario();
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
                dgGestionUsuarios.Rows.Add(usuario.IdUsuario, usuario.usuario, usuario.Password, usuario.Nombre, usuario.Departamento, ObtenerNombrePerfil(usuario.IdPerfil));
            }
            // Ajustar automáticamente el ancho de las columnas después de cargar los datos
            foreach (DataGridViewColumn columna in dgGestionUsuarios.Columns)
            {
                //columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void MostrarInformacionUsuario()
        {
            // Verificar si hay información del usuario actual disponible
            if (frmLogin.UsuarioActual != null)
            {
                // Obtener el nombre y perfil del usuario actual
                string nombrePerfil = ObtenerNombrePerfil(frmLogin.UsuarioActual.IdPerfil);

                // Mostrar el nombre y el perfil del usuario en el panel superior
                lbNombreGu.Text = $"Usuario: {frmLogin.UsuarioActual.Nombre}";
                lbPerfilGu.Text = $"Perfil: {nombrePerfil}";

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
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgGestionUsuarios.Rows[e.RowIndex];
                    // Mostrar la información del usuario seleccionado en los campos correspondientes
                    lblId.Text = fila.Cells["IdUsuario"].Value.ToString();
                    txtUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
                    txtPassword.Text = fila.Cells["Password"].Value.ToString();
                    txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                    cbDepartamento.Text = fila.Cells["Departamento"].Value.ToString();
                    cbPerfil.Text = fila.Cells["Perfil"].Value.ToString();
                    
                }
                btnAgregar.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, seleccione una fila valida");
                return;
            }  

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string nombre = txtNombre.Text;
            string departamento = cbDepartamento.Text;
            string perfil = cbPerfil.Text;
           

            // Verificar que todos los campos estén completos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(departamento) || string.IsNullOrEmpty(perfil))
            {
                MessageBox.Show("Por favor, capture todos los campos.");
                return;
            }

            UsuariosDAO usuariosDAO = new UsuariosDAO();
            bool usuarioAgregado = usuariosDAO.CrearUsuario(usuario, password, nombre, departamento, perfil);

            if (usuarioAgregado)
            {
                MessageBox.Show("Usuario agregado correctamente.");
                CargarUsuarios(); // Recargar la lista de usuarios en el DataGridView
                LimpiarCampos();
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
            string departamento = cbDepartamento.Text;
            string perfil = cbPerfil.Text;
            

            UsuariosDAO usuariosDAO = new UsuariosDAO();
            bool usuarioActualizado = usuariosDAO.ActualizarUsuario(idUsuario, usuario, password, nombre, departamento, perfil);

            if (usuarioActualizado)
            {
                MessageBox.Show("Usuario actualizado correctamente.");
                CargarUsuarios(); // Recargar la lista de usuarios en el DataGridView
                                  // Después de actualizar un usuario
                LimpiarCampos(); // Llama a un método para limpiar los campos
                btnAgregar.Enabled = true;
                btnActualizar.Enabled = false;
                btnEliminar.Enabled = false;
                txtUsuario.Focus();
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
                    LimpiarCampos();
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
            cbDepartamento.SelectedIndex = -1;
            cbPerfil.SelectedIndex = -1; // O establece el valor por defecto
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            /*  string textoBusqueda = txtBuscar.Text.Trim().ToLowerInvariant(); // Convertir texto de búsqueda a minúsculas

              // Recorremos todas las filas del DataGridView
              foreach (DataGridViewRow row in dgGestionUsuarios.Rows)
              {
                  // Verificamos si la fila no es una fila nueva sin confirmar
                  if (!row.IsNewRow)
                  {
                      bool encontrada = false;

                      // Recorremos todas las celdas de la fila actual
                      foreach (DataGridViewCell cell in row.Cells)
                      {
                          // Verificamos si el valor de la celda contiene el texto de búsqueda
                          if (cell.Value != null && cell.Value.ToString().ToLowerInvariant().Contains(textoBusqueda))
                          {
                              encontrada = true;
                              break; // Si encontramos una coincidencia, salimos del bucle interno
                          }
                      }

                      // Mostramos u ocultamos la fila dependiendo de si se encontró alguna coincidencia
                      row.Visible = encontrada;
                  }
              }*/
            //  --------------------------------------------------------------------------------------------
            /*string textoBusqueda = txtBuscar.Text.Trim().ToLowerInvariant(); // Convertir texto de búsqueda a minúsculas

            // Recorremos todas las filas del DataGridView
            foreach (DataGridViewRow row in dgGestionUsuarios.Rows)
            {
                // Verificamos si la fila no es una fila nueva sin confirmar
                if (!row.IsNewRow)
                {
                    bool encontrada = false;

                    // Recorremos todas las celdas de la fila actual
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Verificamos si el CheckBox correspondiente a la columna está seleccionado
                        if (ShouldSearchColumn(cell.ColumnIndex))
                        {
                            // Verificamos si el valor de la celda contiene el texto de búsqueda
                            if (cell.Value != null && cell.Value.ToString().ToLowerInvariant().Contains(textoBusqueda))
                            {
                                encontrada = true;
                                break; // Si encontramos una coincidencia, salimos del bucle interno
                            }
                        }
                    }

                    // Mostramos u ocultamos la fila dependiendo de si se encontró alguna coincidencia
                    row.Visible = encontrada;
                }
            }
            ---------------------hasta aqui es solo busqueda--------------------------------------------------------------------*/
            //aqui empieza busqueda solo con check
            /*
            string textoBusqueda = txtBuscar.Text.Trim().ToLowerInvariant(); // Convertir texto de búsqueda a minúsculas

            // Recorremos todas las filas del DataGridView
            foreach (DataGridViewRow row in dgGestionUsuarios.Rows)
            {
                // Verificamos si la fila no es una fila nueva sin confirmar
                if (!row.IsNewRow)
                {
                    bool encontrada = false;

                    // Recorremos las columnas del DataGridView
                    foreach (DataGridViewColumn column in dgGestionUsuarios.Columns)
                    {
                        // Verificamos si la columna actual debe ser considerada para la búsqueda
                        if (ShouldSearchColumn(column.Index))
                        {
                            // Obtenemos el valor de la celda en la fila actual y la columna correspondiente
                            DataGridViewCell cell = row.Cells[column.Index];

                            // Verificamos si el valor de la celda contiene el texto de búsqueda
                            if (cell.Value != null && cell.Value.ToString().ToLowerInvariant().Contains(textoBusqueda))
                            {
                                encontrada = true;
                                break; // Si encontramos una coincidencia, salimos del bucle interno
                            }
                        }
                    }

                    // Mostramos u ocultamos la fila dependiendo de si se encontró alguna coincidencia
                    row.Visible = encontrada;
                }
            }
            //-------------------------aqui termina la busqueda con check
            */
            string textoBusqueda = txtBuscar.Text.Trim().ToLowerInvariant(); // Convertir texto de búsqueda a minúsculas

            // Verificar si algún CheckBox está seleccionado
            bool alMenosUnCheckboxSeleccionado = chbId.Checked || chbUsuario.Checked || chbNombre.Checked || chbPerfil.Checked;

            // Determinar qué enfoque utilizar para la búsqueda
            if (!alMenosUnCheckboxSeleccionado)
            {
                // Si ningún CheckBox está seleccionado, utilizar el primer enfoque de búsqueda
                foreach (DataGridViewRow row in dgGestionUsuarios.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        bool encontrada = false;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null && cell.Value.ToString().ToLowerInvariant().Contains(textoBusqueda))
                            {
                                encontrada = true;
                                break;
                            }
                        }
                        row.Visible = encontrada;
                    }
                }
            }
            else
            {
                // Si algún CheckBox está seleccionado, utilizar el segundo enfoque de búsqueda
                foreach (DataGridViewRow row in dgGestionUsuarios.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        bool encontrada = false;
                        foreach (DataGridViewColumn column in dgGestionUsuarios.Columns)
                        {
                            if (ShouldSearchColumn(column.Index))
                            {
                                DataGridViewCell cell = row.Cells[column.Index];
                                if (cell.Value != null && cell.Value.ToString().ToLowerInvariant().Contains(textoBusqueda))
                                {
                                    encontrada = true;
                                    break;
                                }
                            }
                        }
                        row.Visible = encontrada;
                    }
                }
            }
        }
        // Método para verificar si la columna debe ser considerada para la búsqueda
        private bool ShouldSearchColumn(int columnIndex)
        {
            // Verificamos si la columna corresponde a uno de los CheckBox seleccionados
            switch (columnIndex)
            {
                case 0: // Columna de ID
                    return chbId.Checked;
                case 1: // Columna de Usuario
                    return chbUsuario.Checked;
                case 2: // Columna de Password
                    return false; // No buscamos en la columna de contraseña
                case 3: // Columna de Nombre
                    return chbNombre.Checked;
                case 4: // Columna de Perfil
                    return chbPerfil.Checked;
                default:
                    return false; // No se considera ninguna otra columna
            }
        }

        private void frmGestionUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal frmPr = new frmPrincipal();
            frmPr.Show();
        }
    }
}
