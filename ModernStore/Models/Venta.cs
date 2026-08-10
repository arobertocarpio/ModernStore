namespace ModernStore.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }

        public DateTime FechaVenta { get; set; }

        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public string Usuario { get; set; } = string.Empty;

        public int IdCliente { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }
    }
}