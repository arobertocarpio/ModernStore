namespace ModernStore.Models
{
    /// <summary>
    /// Representa una venta incluida dentro
    /// de un corte de caja diario.
    /// </summary>
    public class DetalleCorteCaja
    {
        public int IdVenta { get; set; }

        public DateTime FechaVenta { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public string Usuario { get; set; } = string.Empty;

        public decimal Total { get; set; }
    }
}