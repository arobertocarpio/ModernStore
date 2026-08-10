using ModernStore.Models;
using ModernStore.Repositories;

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

            AplicarPermisos();
            RevisarStockBajo();
            RevisarProductosPorCaducar();
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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            using UsuariosForm usuariosForm =
                new UsuariosForm(usuario);

            usuariosForm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            using VentasForm ventasForm =
                new VentasForm();

            ventasForm.ShowDialog();
        }

        private void AplicarPermisos()
        {
            bool esAdministrador =
                usuario.Rol.Equals(
                    "Administrador",
                    StringComparison.OrdinalIgnoreCase
                );

            // Todos pueden usar estas opciones
            btnPOS.Enabled = true;
            btnClientes.Enabled = true;
            btnVentas.Enabled = true;

            // Solo administrador
            btnProductos.Enabled = esAdministrador;
            btnCategorias.Enabled = esAdministrador;
            btnProveedores.Enabled = esAdministrador;
            btnUsuarios.Enabled = esAdministrador;
            btnReportes.Enabled = esAdministrador;
        }

        private void RevisarStockBajo()
        {
            try
            {
                ProductoRepository productoRepository =
                    new ProductoRepository();

                var productosBajoStock =
                    productoRepository.ListarBajoStock();

                if (productosBajoStock.Count == 0)
                {
                    return;
                }

                string mensaje =
                    "Los siguientes productos tienen stock bajo:\n\n";

                foreach (var producto in productosBajoStock)
                {
                    mensaje +=
                        $"• {producto.Nombre}: {producto.Stock} unidades\n";
                }

                MessageBox.Show(
                    mensaje,
                    "Alerta de stock bajo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo revisar el stock.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void RevisarProductosPorCaducar()
        {
            try
            {
                ProductoRepository productoRepository =
                    new ProductoRepository();

                var productos =
                    productoRepository.ListarProximosCaducar();

                if (productos.Count == 0)
                {
                    return;
                }

                string mensaje =
                    "Los siguientes productos están próximos a caducar:\n\n";

                foreach (var item in productos)
                {
                    mensaje +=
                        $"• {item.Producto.Nombre} - " +
                        $"{item.DiasParaCaducar} días restantes\n";
                }

                MessageBox.Show(
                    mensaje,
                    "Alerta de caducidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo revisar la caducidad de los productos.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using ReportesForm reportesForm =
                new ReportesForm();

            reportesForm.ShowDialog();
        }

        private void btnCorteCaja_Click(object sender, EventArgs e)
        {
            using CorteCajaForm corteCajaForm =
                new CorteCajaForm();

            corteCajaForm.ShowDialog();
        }
    }
}