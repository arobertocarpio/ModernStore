using ModernStore.Models;
using ModernStore.Repositories;
using System.Data;

namespace ModernStore.Forms
{
    public partial class POSForm : Form
    {
        private readonly ProductoRepository productoRepository;
        private readonly VentaRepository ventaRepository;

        private List<Producto> productos = new();
        private List<CarritoItem> carrito = new();

        public POSForm()
        {
            InitializeComponent();

            productoRepository = new ProductoRepository();
            ventaRepository = new VentaRepository();

            CargarProductos();
        }

        private void CargarProductos()
        {
            productos = productoRepository.Listar();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
        }

        private void ActualizarCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;

            decimal total = carrito.Sum(x => x.Subtotal);

            lblTotal.Text = $"${total:N2}";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            var filtrados = productos
                .Where(p => p.Nombre.ToLower().Contains(texto))
                .ToList();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtrados;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            Producto producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;

            var item = carrito.FirstOrDefault(c => c.IdProducto == producto.IdProducto);

            if (item == null)
            {
                carrito.Add(new CarritoItem
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = 1
                });
            }
            else
            {
                item.Cantidad++;
            }

            ActualizarCarrito();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            try
            {
                DataTable detalle = new DataTable();

                detalle.Columns.Add("id_producto", typeof(int));
                detalle.Columns.Add("cantidad", typeof(int));

                foreach (CarritoItem item in carrito)
                {
                    detalle.Rows.Add(
                        item.IdProducto,
                        item.Cantidad
                    );
                }

                int idUsuario = 1;

                var resultado = ventaRepository.Registrar(
                    idUsuario,
                    null,
                    detalle
                );

                MessageBox.Show(
                    $"{resultado.Mensaje}\n\n" +
                    $"Venta: {resultado.IdVenta}\n" +
                    $"Total: ${resultado.Total:N2}"
                );

                carrito.Clear();

                ActualizarCarrito();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo registrar la venta.\n\n{ex.Message}"
                );
            }
        }
    }
}