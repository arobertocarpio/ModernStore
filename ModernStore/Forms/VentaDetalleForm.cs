using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class VentaDetalleForm : Form
    {
        private readonly VentaRepository ventaRepository;
        private readonly Venta venta;

        public VentaDetalleForm(Venta venta)
        {
            InitializeComponent();

            this.venta = venta;

            ventaRepository = new VentaRepository();

            CargarInformacion();
            CargarDetalle();
        }

        private void CargarInformacion()
        {
            lblVenta.Text =
                $"Venta #{venta.IdVenta}";

            lblFecha.Text =
                $"Fecha: {venta.FechaVenta:dd/MM/yyyy HH:mm}";

            lblUsuario.Text =
                $"Cajero: {venta.Usuario}";

            lblCliente.Text =
                $"Cliente: {venta.Cliente}";

            lblTotal.Text =
                $"Total: ${venta.Total:N2}";
        }

        private void CargarDetalle()
        {
            try
            {
                var detalles =
                    ventaRepository.ObtenerDetalle(
                        venta.IdVenta
                    );

                dgvDetalle.DataSource = null;
                dgvDetalle.DataSource = detalles;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo cargar el detalle.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvDetalle.Columns.Count == 0)
            {
                return;
            }

            if (dgvDetalle.Columns["IdDetalleVenta"] != null)
                dgvDetalle.Columns["IdDetalleVenta"].Visible = false;

            if (dgvDetalle.Columns["IdVenta"] != null)
                dgvDetalle.Columns["IdVenta"].Visible = false;

            if (dgvDetalle.Columns["IdProducto"] != null)
                dgvDetalle.Columns["IdProducto"].Visible = false;

            if (dgvDetalle.Columns["Producto"] != null)
                dgvDetalle.Columns["Producto"].HeaderText = "Producto";

            if (dgvDetalle.Columns["Cantidad"] != null)
                dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";

            if (dgvDetalle.Columns["PrecioUnitario"] != null)
                dgvDetalle.Columns["PrecioUnitario"].HeaderText = "Precio";

            if (dgvDetalle.Columns["Subtotal"] != null)
                dgvDetalle.Columns["Subtotal"].HeaderText = "Subtotal";

            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;

            dgvDetalle.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}