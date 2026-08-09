using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioRepository usuarioRepository;

        public LoginForm()
        {
            InitializeComponent();

            usuarioRepository = new UsuarioRepository();

            txtPassword.UseSystemPasswordChar = true;

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show(
                    "Ingresa usuario y contraseña.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                var usuario = usuarioRepository.Autenticar(
                    nombreUsuario,
                    contrasena
                );

                if (usuario == null)
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "Inicio de sesión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }

                MessageBox.Show(
                    $"Bienvenido, {usuario.NombreCompleto}",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                MainForm mainForm = new MainForm(usuario);

                Hide();

                mainForm.ShowDialog();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo iniciar sesión.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}