using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class CategoriasForm : Form
    {
        private readonly CategoriaRepository categoriaRepository;
        private readonly UsuarioSesion usuario;

        private List<Categoria> categorias = new();

        public CategoriasForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            categoriaRepository =
                new CategoriaRepository();

            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                categorias =
                    categoriaRepository.Listar();

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar las categorías.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text.Trim().ToLower();

            var filtradas = categorias
                .Where(c =>
                    c.Nombre
                        .ToLower()
                        .Contains(texto)
                )
                .ToList();

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = filtradas;
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            using CategoriaForm categoriaForm =
                new CategoriaForm(usuario);

            if (categoriaForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarCategorias();
            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona una categoría para editar.",
                    "Categorías",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Categoria categoria =
                (Categoria)dgvCategorias
                    .CurrentRow
                    .DataBoundItem;

            using CategoriaForm categoriaForm =
                new CategoriaForm(
                    usuario,
                    categoria
                );

            if (categoriaForm.ShowDialog()
                == DialogResult.OK)
            {
                CargarCategorias();
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona una categoría para eliminar.",
                    "Categorías",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Categoria categoria =
                (Categoria)dgvCategorias
                    .CurrentRow
                    .DataBoundItem;

            DialogResult confirmacion =
                MessageBox.Show(
                    $"¿Estás seguro de eliminar la categoría '{categoria.Nombre}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                categoriaRepository.Eliminar(
                    categoria.IdCategoria,
                    usuario.IdUsuario
                );

                MessageBox.Show(
                    "Categoría eliminada correctamente.",
                    "Categorías",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar la categoría.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}