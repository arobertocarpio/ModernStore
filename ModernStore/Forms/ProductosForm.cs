using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class ProductosForm : Form
    {
        private readonly ProductoRepository productoRepository;
        private readonly UsuarioSesion usuario;

        private List<Producto> productos = new();

        public ProductosForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            productoRepository = new ProductoRepository();

            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                productos = productoRepository.Listar();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los productos.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text
                .Trim()
                .ToLower();

            var filtrados = productos
                .Where(p =>
                    p.Nombre.ToLower().Contains(texto)
                )
                .ToList();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtrados;
        }

        private void dgvProductos_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using ProductoForm productoForm =
                new ProductoForm(usuario);

            if (productoForm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un producto para editar.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Producto producto =
                (Producto)dgvProductos.CurrentRow.DataBoundItem;

            using ProductoForm productoForm =
                new ProductoForm(
                    usuario,
                    producto
                );

            if (productoForm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un producto para eliminar.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Producto producto =
                (Producto)dgvProductos.CurrentRow.DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Estás seguro de eliminar el producto '{producto.Nombre}'?",
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
                productoRepository.Eliminar(
                    producto.IdProducto,
                    usuario.IdUsuario
                );

                MessageBox.Show(
                    "Producto eliminado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar el producto.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}