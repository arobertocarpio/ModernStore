namespace ModernStore.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public int IdCategoria { get; set; }

        public int? IdProveedor { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public DateTime? FechaCaducidad { get; set; }
    }
}
