using ModernStore.Models;
using ModernStore.Repositories;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ModernStore.Forms
{
    public partial class ReportesForm : Form
    {
        private readonly ReporteRepository reporteRepository;

        private List<ReporteVentaSemanal> reporte = new();

        public ReportesForm()
        {
            InitializeComponent();

            QuestPDF.Settings.License =
                LicenseType.Community;

            reporteRepository =
                new ReporteRepository();

            dtpFechaInicio.Format =
                DateTimePickerFormat.Short;

            btnExportarPDF.Enabled = false;
        }

        private void btnGenerar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                reporte =
                    reporteRepository.ObtenerVentasSemanales(
                        dtpFechaInicio.Value
                    );

                dgvReporte.DataSource = null;
                dgvReporte.DataSource = reporte;

                ConfigurarGrid();
                ActualizarTotales();

                btnExportarPDF.Enabled =
                    reporte.Count > 0;

                if (reporte.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron ventas para la semana seleccionada.",
                        "Reporte semanal",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo generar el reporte.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ConfigurarGrid()
        {
            dgvReporte.ReadOnly = true;
            dgvReporte.AllowUserToAddRows = false;

            dgvReporte.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvReporte.Columns["Fecha"] != null)
            {
                dgvReporte.Columns["Fecha"].HeaderText =
                    "Fecha";

                dgvReporte.Columns["Fecha"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy";
            }

            if (dgvReporte.Columns["CantidadVentas"] != null)
            {
                dgvReporte.Columns["CantidadVentas"].HeaderText =
                    "Cantidad de ventas";
            }

            if (dgvReporte.Columns["TotalVendido"] != null)
            {
                dgvReporte.Columns["TotalVendido"].HeaderText =
                    "Total vendido";

                dgvReporte.Columns["TotalVendido"]
                    .DefaultCellStyle.Format =
                    "C2";
            }
        }

        private void ActualizarTotales()
        {
            int totalVentas =
                reporte.Sum(
                    r => r.CantidadVentas
                );

            decimal totalVendido =
                reporte.Sum(
                    r => r.TotalVendido
                );

            lblTotalVentas.Text =
                $"Total de ventas: {totalVentas}";

            lblTotalVendido.Text =
                $"Total vendido: ${totalVendido:N2}";
        }

        private void btnExportarPDF_Click(
            object sender,
            EventArgs e)
        {
            if (reporte.Count == 0)
            {
                MessageBox.Show(
                    "Primero genera un reporte.",
                    "Reporte semanal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            using SaveFileDialog saveFileDialog =
                new SaveFileDialog();

            saveFileDialog.Filter =
                "Archivo PDF (*.pdf)|*.pdf";

            saveFileDialog.FileName =
                $"Reporte_Ventas_{dtpFechaInicio.Value:yyyy-MM-dd}.pdf";

            if (saveFileDialog.ShowDialog()
                != DialogResult.OK)
            {
                return;
            }

            try
            {
                int totalVentas =
                    reporte.Sum(r => r.CantidadVentas);

                decimal totalVendido =
                    reporte.Sum(r => r.TotalVendido);

                DateTime fechaInicio =
                    dtpFechaInicio.Value.Date;

                DateTime fechaFin =
                    fechaInicio.AddDays(6);

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(40);

                        page.Header()
                            .Column(column =>
                            {
                                column.Item()
                                    .Text("TIENDA LA MODERNA")
                                    .FontSize(20)
                                    .Bold();

                                column.Item()
                                    .Text("Reporte semanal de ventas")
                                    .FontSize(16)
                                    .Bold();

                                column.Item()
                                    .Text(
                                        $"Periodo: " +
                                        $"{fechaInicio:dd/MM/yyyy} - " +
                                        $"{fechaFin:dd/MM/yyyy}"
                                    );
                            });

                        page.Content()
                            .PaddingVertical(20)
                            .Column(column =>
                            {
                                column.Spacing(10);

                                column.Item()
                                    .Table(table =>
                                    {
                                        table.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn();
                                            columns.RelativeColumn();
                                            columns.RelativeColumn();
                                        });

                                        table.Header(header =>
                                        {
                                            header.Cell()
                                                .Text("Fecha")
                                                .Bold();

                                            header.Cell()
                                                .Text("Cantidad de ventas")
                                                .Bold();

                                            header.Cell()
                                                .Text("Total vendido")
                                                .Bold();
                                        });

                                        foreach (var item in reporte)
                                        {
                                            table.Cell()
                                                .Text(
                                                    item.Fecha
                                                        .ToString("dd/MM/yyyy")
                                                );

                                            table.Cell()
                                                .Text(
                                                    item.CantidadVentas
                                                        .ToString()
                                                );

                                            table.Cell()
                                                .Text(
                                                    $"${item.TotalVendido:N2}"
                                                );
                                        }
                                    });

                                column.Item()
                                    .PaddingTop(20)
                                    .Text(
                                        $"Total de ventas: {totalVentas}"
                                    )
                                    .Bold();

                                column.Item()
                                    .Text(
                                        $"Total vendido: ${totalVendido:N2}"
                                    )
                                    .FontSize(14)
                                    .Bold();
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(text =>
                            {
                                text.Span(
                                    "Generado por ModernStore | Página "
                                );

                                text.CurrentPageNumber();
                            });
                    });
                })
                .GeneratePdf(saveFileDialog.FileName);

                MessageBox.Show(
                    "El reporte PDF se generó correctamente.",
                    "Reporte generado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo generar el PDF.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}