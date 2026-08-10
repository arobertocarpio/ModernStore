using ModernStore.Models;
using ModernStore.Repositories;
using System.Data;

namespace ModernStore.Forms
{
    public partial class POSForm : Form
    {
        private readonly ProductoRepository productoRepository;
        private readonly VentaRepository ventaRepository;
        private readonly ClienteRepository clienteRepository;

        private readonly UsuarioSesion usuario;

        private List<Producto> productos = new();
        private List<CarritoItem> carrito = new();

        public POSForm(UsuarioSesion usuario)
        {
            InitializeComponent();

            this.usuario = usuario;

            productoRepository = new ProductoRepository();
            ventaRepository = new VentaRepository();
            clienteRepository = new ClienteRepository();

            CargarProductos();
            CargarClientes();
        }

        /// <summary>
        /// Carga todos los productos disponibles
        /// en la tabla del punto de venta.
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                productos =
                    productoRepository.Listar();

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

        /// <summary>
        /// Carga los clientes registrados en el sistema
        /// dentro del ComboBox del punto de venta.
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                var clientes =
                    clienteRepository.Listar();

                cmbCliente.DataSource = null;
                cmbCliente.DataSource = clientes;

                cmbCliente.DisplayMember =
                    "NombreCompleto";

                cmbCliente.ValueMember =
                    "IdCliente";

                cmbCliente.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                // Evita seleccionar automáticamente
                // al primer cliente.
                cmbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los clientes.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Actualiza la información mostrada
        /// en el carrito y calcula el total de la venta.
        /// </summary>
        private void ActualizarCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;

            decimal total =
                carrito.Sum(
                    x => x.Subtotal
                );

            lblTotal.Text =
                $"${total:N2}";
        }

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text
                    .Trim()
                    .ToLower();

            var filtrados =
                productos
                    .Where(
                        p => p.Nombre
                            .ToLower()
                            .Contains(texto)
                    )
                    .ToList();

            dgvProductos.DataSource = null;
            dgvProductos.DataSource = filtrados;
        }

        /// <summary>
        /// Agrega al carrito el producto seleccionado.
        /// Si el producto ya se encuentra en el carrito,
        /// incrementa su cantidad mientras exista stock.
        /// </summary>
        private void btnAgregar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un producto.",
                    "Producto requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Producto producto =
                (Producto)
                dgvProductos
                    .CurrentRow
                    .DataBoundItem;

            var item =
                carrito.FirstOrDefault(
                    c =>
                        c.IdProducto ==
                        producto.IdProducto
                );

            int cantidadActual =
                item?.Cantidad ?? 0;

            if (cantidadActual >= producto.Stock)
            {
                MessageBox.Show(
                    $"No hay suficiente stock.\n\n" +
                    $"Stock disponible: {producto.Stock}",
                    "Stock insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (item == null)
            {
                carrito.Add(
                    new CarritoItem
                    {
                        IdProducto =
                            producto.IdProducto,

                        Nombre =
                            producto.Nombre,

                        Precio =
                            producto.Precio,

                        Cantidad = 1
                    }
                );
            }
            else
            {
                item.Cantidad++;
            }

            ActualizarCarrito();
        }

        /// <summary>
        /// Registra la venta utilizando el usuario
        /// autenticado, el cliente seleccionado
        /// y los productos agregados al carrito.
        /// </summary>
        private void btnCobrar_Click(
            object sender,
            EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show(
                    "El carrito está vacío.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show(
                    "Selecciona un cliente para registrar la venta.",
                    "Cliente requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbCliente.Focus();

                return;
            }

            int idCliente =
                Convert.ToInt32(
                    cmbCliente.SelectedValue
                );

            decimal total =
                carrito.Sum(
                    x => x.Subtotal
                );

            DialogResult confirmacion =
                MessageBox.Show(
                    $"¿Registrar la venta por ${total:N2}?",
                    "Confirmar venta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DataTable detalle =
                    new DataTable();

                detalle.Columns.Add(
                    "id_producto",
                    typeof(int)
                );

                detalle.Columns.Add(
                    "cantidad",
                    typeof(int)
                );

                foreach (CarritoItem item in carrito)
                {
                    detalle.Rows.Add(
                        item.IdProducto,
                        item.Cantidad
                    );
                }

                var resultado =
                    ventaRepository.Registrar(
                        usuario.IdUsuario,
                        idCliente,
                        detalle
                    );

                MessageBox.Show(
                    $"{resultado.Mensaje}\n\n" +
                    $"Venta: {resultado.IdVenta}\n" +
                    $"Total: ${resultado.Total:N2}",
                    "Venta registrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                carrito.Clear();

                ActualizarCarrito();

                CargarProductos();

                // Limpia la selección del cliente
                // para la siguiente venta.
                cmbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo registrar la venta.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Elimina del carrito el producto seleccionado.
        /// </summary>
        private void btnQuitar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona un producto del carrito.",
                    "Carrito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            CarritoItem item =
                (CarritoItem)
                dgvCarrito
                    .CurrentRow
                    .DataBoundItem;

            carrito.Remove(item);

            ActualizarCarrito();
        }
    }
}