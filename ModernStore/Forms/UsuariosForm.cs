using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class UsuariosForm : Form
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly UsuarioSesion usuarioSesion;

        private List<Usuario> usuarios = new();

        public UsuariosForm(UsuarioSesion usuarioSesion)
        {
            InitializeComponent();

            this.usuarioSesion = usuarioSesion;

            usuarioRepository =
                new UsuarioRepository();

            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                usuarios =
                    usuarioRepository.Listar();

                MostrarUsuarios(usuarios);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los usuarios.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void MostrarUsuarios(
            List<Usuario> lista)
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = lista;

            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvUsuarios.Columns.Count == 0)
            {
                return;
            }

            // Ocultamos IDs internos
            if (dgvUsuarios.Columns["IdUsuario"] != null)
            {
                dgvUsuarios.Columns["IdUsuario"].Visible = false;
            }

            if (dgvUsuarios.Columns["IdRol"] != null)
            {
                dgvUsuarios.Columns["IdRol"].Visible = false;
            }

            // NombreCompleto es útil para mostrarlo,
            // pero ocultamos campos redundantes.
            if (dgvUsuarios.Columns["Nombre"] != null)
            {
                dgvUsuarios.Columns["Nombre"].Visible = false;
            }

            if (dgvUsuarios.Columns["ApellidoPaterno"] != null)
            {
                dgvUsuarios.Columns["ApellidoPaterno"].Visible = false;
            }

            if (dgvUsuarios.Columns["ApellidoMaterno"] != null)
            {
                dgvUsuarios.Columns["ApellidoMaterno"].Visible = false;
            }

            if (dgvUsuarios.Columns["Activo"] != null)
            {
                dgvUsuarios.Columns["Activo"].Visible = false;
            }

            // Encabezados más bonitos
            if (dgvUsuarios.Columns["NombreCompleto"] != null)
            {
                dgvUsuarios.Columns["NombreCompleto"].HeaderText =
                    "Nombre";
            }

            if (dgvUsuarios.Columns["NombreUsuario"] != null)
            {
                dgvUsuarios.Columns["NombreUsuario"].HeaderText =
                    "Usuario";
            }

            if (dgvUsuarios.Columns["Rol"] != null)
            {
                dgvUsuarios.Columns["Rol"].HeaderText =
                    "Rol";
            }

            if (dgvUsuarios.Columns["Estado"] != null)
            {
                dgvUsuarios.Columns["Estado"].HeaderText =
                    "Estado";
            }

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.ReadOnly = true;

            dgvUsuarios.AllowUserToAddRows = false;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text
                    .Trim()
                    .ToLower();

            var filtrados = usuarios
                .Where(u =>
                    u.NombreCompleto
                        .ToLower()
                        .Contains(texto)
                    ||
                    u.NombreUsuario
                        .ToLower()
                        .Contains(texto)
                    ||
                    u.Rol
                        .ToLower()
                        .Contains(texto)
                )
                .ToList();

            MostrarUsuarios(filtrados);
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            using UsuarioForm usuarioForm =
                new UsuarioForm(usuarioSesion);

            if (usuarioForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            Usuario? usuarioSeleccionado =
                ObtenerUsuarioSeleccionado();

            if (usuarioSeleccionado == null)
            {
                return;
            }

            using UsuarioForm usuarioForm =
                new UsuarioForm(
                    usuarioSesion,
                    usuarioSeleccionado
                );

            if (usuarioForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void btnActivarDesactivar_Click(
            object sender,
            EventArgs e)
        {
            Usuario? usuarioSeleccionado =
                ObtenerUsuarioSeleccionado();

            if (usuarioSeleccionado == null)
            {
                return;
            }

            // Evitamos que el usuario actual
            // se desactive a sí mismo.
            if (usuarioSeleccionado.IdUsuario ==
                usuarioSesion.IdUsuario)
            {
                MessageBox.Show(
                    "No puedes desactivar tu propio usuario mientras tienes una sesión activa.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string accion =
                usuarioSeleccionado.Activo
                    ? "desactivar"
                    : "reactivar";

            DialogResult confirmacion =
                MessageBox.Show(
                    $"¿Deseas {accion} al usuario " +
                    $"'{usuarioSeleccionado.NombreUsuario}'?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (usuarioSeleccionado.Activo)
                {
                    usuarioRepository.Desactivar(
                        usuarioSeleccionado.IdUsuario,
                        usuarioSesion.IdUsuario
                    );

                    MessageBox.Show(
                        "Usuario desactivado correctamente.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    usuarioRepository.Reactivar(
                        usuarioSeleccionado.IdUsuario,
                        usuarioSesion.IdUsuario
                    );

                    MessageBox.Show(
                        "Usuario reactivado correctamente.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo cambiar el estado del usuario.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Usuario? ObtenerUsuarioSeleccionado()
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un usuario.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            if (dgvUsuarios.CurrentRow.DataBoundItem
                is not Usuario usuario)
            {
                MessageBox.Show(
                    "No se pudo obtener el usuario seleccionado.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return null;
            }

            return usuario;
        }

        private void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            Usuario? usuarioSeleccionado =
            ObtenerUsuarioSeleccionado();

            if (usuarioSeleccionado == null)
            {
                return;
            }

            using CambiarContrasenaForm form =
                new CambiarContrasenaForm(
                    usuarioSesion,
                    usuarioSeleccionado
                );

            form.ShowDialog();
        }
    }
}