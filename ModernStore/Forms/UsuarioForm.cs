using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class UsuarioForm : Form
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly RolRepository rolRepository;
        private readonly UsuarioSesion usuarioSesion;

        private readonly Usuario? usuarioEditar;

        // CREAR
        public UsuarioForm(UsuarioSesion usuarioSesion)
        {
            InitializeComponent();

            this.usuarioSesion = usuarioSesion;

            usuarioRepository = new UsuarioRepository();
            rolRepository = new RolRepository();

            CargarRoles();

            Text = "Nuevo usuario";
        }

        // EDITAR
        public UsuarioForm(
            UsuarioSesion usuarioSesion,
            Usuario usuario
        ) : this(usuarioSesion)
        {
            usuarioEditar = usuario;

            Text = "Editar usuario";

            CargarDatosUsuario();

            // La contraseña se cambia desde otro formulario.
            txtContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
        }

        private void CargarRoles()
        {
            try
            {
                var roles = rolRepository.Listar();

                cmbRol.DataSource = null;
                cmbRol.DataSource = roles;

                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "IdRol";

                cmbRol.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los roles.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarDatosUsuario()
        {
            if (usuarioEditar == null)
            {
                return;
            }

            txtNombre.Text =
                usuarioEditar.Nombre;

            txtApellidoPaterno.Text =
                usuarioEditar.ApellidoPaterno;

            txtApellidoMaterno.Text =
                usuarioEditar.ApellidoMaterno
                ?? string.Empty;

            txtNombreUsuario.Text =
                usuarioEditar.NombreUsuario;

            cmbRol.SelectedValue =
                usuarioEditar.IdRol;
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario =
                        usuarioEditar?.IdUsuario ?? 0,

                    IdRol =
                        Convert.ToInt32(
                            cmbRol.SelectedValue
                        ),

                    Nombre =
                        txtNombre.Text.Trim(),

                    ApellidoPaterno =
                        txtApellidoPaterno.Text.Trim(),

                    ApellidoMaterno =
                        string.IsNullOrWhiteSpace(
                            txtApellidoMaterno.Text
                        )
                            ? null
                            : txtApellidoMaterno.Text.Trim(),

                    NombreUsuario =
                        txtNombreUsuario.Text.Trim(),

                    Activo =
                        usuarioEditar?.Activo ?? true
                };

                if (usuarioEditar == null)
                {
                    usuarioRepository.Crear(
                        usuario,
                        txtContrasena.Text,
                        usuarioSesion.IdUsuario
                    );

                    MessageBox.Show(
                        "Usuario creado correctamente.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    usuarioRepository.Actualizar(
                        usuario,
                        usuarioSesion.IdUsuario
                    );

                    MessageBox.Show(
                        "Usuario actualizado correctamente.",
                        "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo guardar el usuario.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingresa el nombre.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtApellidoPaterno.Text))
            {
                MessageBox.Show(
                    "Ingresa el apellido paterno.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtApellidoPaterno.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtNombreUsuario.Text))
            {
                MessageBox.Show(
                    "Ingresa un nombre de usuario.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombreUsuario.Focus();
                return false;
            }

            if (cmbRol.SelectedValue == null)
            {
                MessageBox.Show(
                    "Selecciona un rol.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbRol.Focus();
                return false;
            }

            // Contraseña solamente al crear.
            if (usuarioEditar == null)
            {
                if (string.IsNullOrWhiteSpace(
                    txtContrasena.Text))
                {
                    MessageBox.Show(
                        "Ingresa una contraseña.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtContrasena.Focus();
                    return false;
                }

                if (txtContrasena.Text.Length < 8)
                {
                    MessageBox.Show(
                        "La contraseña debe tener al menos 8 caracteres.",
                        "Contraseña inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtContrasena.Focus();
                    return false;
                }

                if (txtContrasena.Text !=
                    txtConfirmarContrasena.Text)
                {
                    MessageBox.Show(
                        "Las contraseñas no coinciden.",
                        "Contraseña inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtConfirmarContrasena.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}