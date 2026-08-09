using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class CategoriaForm : Form
    {
        private readonly CategoriaRepository categoriaRepository;
        private readonly UsuarioSesion usuario;

        private readonly Categoria? categoriaEditar;

        // CREAR
        public CategoriaForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            categoriaRepository =
                new CategoriaRepository();

            Text = "Nueva categoría";
        }

        // EDITAR
        public CategoriaForm(
            UsuarioSesion usuario,
            Categoria categoria
        ) : this(usuario)
        {
            categoriaEditar = categoria;

            Text = "Editar categoría";

            CargarDatos();
        }

        private void CargarDatos()
        {
            if (categoriaEditar == null)
            {
                return;
            }

            txtNombre.Text =
                categoriaEditar.Nombre;
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
                Categoria categoria = new Categoria
                {
                    IdCategoria =
                        categoriaEditar?.IdCategoria ?? 0,

                    Nombre =
                        txtNombre.Text.Trim()
                };

                if (categoriaEditar == null)
                {
                    categoriaRepository.Crear(
                        categoria,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Categoría creada correctamente.",
                        "Categorías",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    categoriaRepository.Actualizar(
                        categoria,
                        usuario.IdUsuario
                    );

                    MessageBox.Show(
                        "Categoría actualizada correctamente.",
                        "Categorías",
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
                    $"No se pudo guardar la categoría.\n\n{ex.Message}",
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
                    "Ingresa el nombre de la categoría.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();

                return false;
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