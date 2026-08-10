using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class VentasForm : Form
    {
        private readonly VentaRepository ventaRepository;

        private List<Venta> ventas = new();

        public VentasForm()
        {
            InitializeComponent();

            ventaRepository = new VentaRepository();

            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                ventas = ventaRepository.Listar();

                dgvVentas.DataSource = null;
                dgvVentas.DataSource = ventas;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar las ventas.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvVentas.Columns.Count == 0)
            {
                return;
            }

            if (dgvVentas.Columns["IdUsuario"] != null)
                dgvVentas.Columns["IdUsuario"].Visible = false;

            if (dgvVentas.Columns["IdCliente"] != null)
                dgvVentas.Columns["IdCliente"].Visible = false;

            if (dgvVentas.Columns["Usuario"] != null)
                dgvVentas.Columns["Usuario"].HeaderText = "Cajero";

            if (dgvVentas.Columns["Cliente"] != null)
                dgvVentas.Columns["Cliente"].HeaderText = "Cliente";

            if (dgvVentas.Columns["FechaVenta"] != null)
                dgvVentas.Columns["FechaVenta"].HeaderText = "Fecha";

            if (dgvVentas.Columns["Total"] != null)
                dgvVentas.Columns["Total"].HeaderText = "Total";

            dgvVentas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvVentas.MultiSelect = false;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;

            dgvVentas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            string texto =
                txtBuscar.Text.Trim().ToLower();

            var filtradas = ventas
                .Where(v =>
                    v.Cliente.ToLower().Contains(texto)
                    ||
                    v.Usuario.ToLower().Contains(texto)
                    ||
                    v.NombreUsuario.ToLower().Contains(texto)
                    ||
                    v.IdVenta.ToString().Contains(texto)
                )
                .ToList();

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = filtradas;

            ConfigurarGrid();
        }

        private void btnVerDetalle_Click(
            object sender,
            EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecciona una venta.",
                    "Ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (dgvVentas.CurrentRow.DataBoundItem
                is not Venta venta)
            {
                return;
            }

            using VentaDetalleForm detalleForm =
                new VentaDetalleForm(venta);

            detalleForm.ShowDialog();
        }
    }
}