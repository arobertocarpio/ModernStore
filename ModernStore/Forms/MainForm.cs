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
                Close();
            }
        }
    }
}
