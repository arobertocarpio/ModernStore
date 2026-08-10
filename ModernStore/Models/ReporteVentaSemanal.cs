namespace ModernStore.Models
{
    public class ReporteVentaSemanal
    {
        public DateTime Fecha { get; set; }

        public int CantidadVentas { get; set; }

        public decimal TotalVendido { get; set; }
    }
}