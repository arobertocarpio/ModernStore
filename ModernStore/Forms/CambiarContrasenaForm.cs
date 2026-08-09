using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class CambiarContrasenaForm : Form
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly UsuarioSesion usuarioSesion;
        private readonly Usuario usuario;

        public CambiarContrasenaForm(
            UsuarioSesion usuarioSesion,
            Usuario usuario)
        {
            InitializeComponent();

            this.usuarioSesion = usuarioSesion;
            this.usuario = usuario;

            usuarioRepository = new UsuarioRepository();

            Text = $"Cambiar contraseña - {usuario.NombreUsuario}";
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtNuevaContrasena.Text))
            {
                MessageBox.Show(
                    "Ingresa una nueva contraseña.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNuevaContrasena.Focus();
                return;
            }

            if (txtNuevaContrasena.Text.Length < 8)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 8 caracteres.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNuevaContrasena.Focus();
                return;
            }

            if (txtNuevaContrasena.Text !=
                txtConfirmarContrasena.Text)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Contraseña inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtConfirmarContrasena.Focus();
                return;
            }

            try
            {
                usuarioRepository.CambiarContrasena(
                    usuario.IdUsuario,
                    txtNuevaContrasena.Text,
                    usuarioSesion.IdUsuario
                );

                MessageBox.Show(
                    "Contraseña actualizada correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo cambiar la contraseña.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
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