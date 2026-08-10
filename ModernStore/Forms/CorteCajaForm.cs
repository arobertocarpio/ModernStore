using ModernStore.Models;
using ModernStore.Repositories;

namespace ModernStore.Forms
{
    public partial class CorteCajaForm : Form
    {
        private readonly CorteCajaRepository corteCajaRepository;

        public CorteCajaForm()
        {
            InitializeComponent();

            corteCajaRepository =
                new CorteCajaRepository();

            dtpFecha.Format =
                DateTimePickerFormat.Short;

            ConfigurarGrid();

            LimpiarResumen();
        }

        private void ConfigurarGrid()
        {
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;

            dgvVentas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvVentas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LimpiarResumen()
        {
            lblCantidadVentas.Text =
                "Cantidad de ventas: 0";

            lblTotalEfectivo.Text =
                "Total efectivo: $0.00";
        }

        private void btnGenerar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                DateTime fecha =
                    dtpFecha.Value.Date;

                CorteCaja? corte =
                    corteCajaRepository.ObtenerCorte(
                        fecha
                    );

                List<DetalleCorteCaja> detalles =
                    corteCajaRepository.ObtenerDetalle(
                        fecha
                    );

                dgvVentas.DataSource = null;
                dgvVentas.DataSource = detalles;

                ConfigurarColumnas();

                if (corte == null)
                {
                    LimpiarResumen();

                    MessageBox.Show(
                        "No se encontraron ventas para la fecha seleccionada.",
                        "Corte de caja",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                lblCantidadVentas.Text =
                    $"Cantidad de ventas: {corte.CantidadVentas}";

                lblTotalEfectivo.Text =
                    $"Total efectivo: ${corte.TotalEfectivo:N2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo generar el corte de caja.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvVentas.Columns["IdVenta"] != null)
            {
                dgvVentas.Columns["IdVenta"].HeaderText =
                    "Venta";
            }

            if (dgvVentas.Columns["FechaVenta"] != null)
            {
                dgvVentas.Columns["FechaVenta"].HeaderText =
                    "Fecha";

                dgvVentas.Columns["FechaVenta"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }

            if (dgvVentas.Columns["Cliente"] != null)
            {
                dgvVentas.Columns["Cliente"].HeaderText =
                    "Cliente";
            }

            if (dgvVentas.Columns["Usuario"] != null)
            {
                dgvVentas.Columns["Usuario"].HeaderText =
                    "Usuario";
            }

            if (dgvVentas.Columns["Total"] != null)
            {
                dgvVentas.Columns["Total"].HeaderText =
                    "Total";

                dgvVentas.Columns["Total"]
                    .DefaultCellStyle.Format =
                    "C2";
            }
        }
    }
}