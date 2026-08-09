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
            using POSForm posForm =
                new POSForm(usuario);

            posForm.ShowDialog();
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

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            using ProveedoresForm proveedoresForm =
                new ProveedoresForm(usuario);

            proveedoresForm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Deseas cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            Hide();

            using LoginForm loginForm =
                new LoginForm();

            loginForm.ShowDialog();

            Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using ClientesForm clientesForm =
                new ClientesForm(usuario);

            clientesForm.ShowDialog();
        }
    }
}