using ModernStore.Models;

namespace ModernStore.Forms
{
    public partial class MainForm : Form
    {
        private readonly UsuarioSesion usuario;

        public MainForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            lblUsuario.Text =
                $"{usuario.NombreCompleto} | {usuario.Rol}";
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            POSForm posForm = new POSForm(usuario);

            posForm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();

                Hide();

                loginForm.ShowDialog();

                Close();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            using ProductosForm productosForm =
                new ProductosForm(usuario);

            productosForm.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            using CategoriasForm categoriasForm =
            new CategoriasForm(usuario);

            categoriasForm.ShowDialog();
        }
    }
}
