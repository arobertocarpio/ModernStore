namespace ModernStore.Models
{
    /// <summary>
    /// Representa un producto registrado en el inventario
    /// de Tienda La Moderna.
    ///
    /// Contiene la información necesaria para identificar,
    /// clasificar y controlar las existencias del producto.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Identificador de la categoría a la que
        /// pertenece el producto.
        /// </summary>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Identificador del proveedor asociado al producto.
        /// Puede ser nulo cuando no existe un proveedor asignado.
        /// </summary>
        public int? IdProveedor { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción adicional del producto.
        /// Puede ser nula cuando no se proporciona.
        /// </summary>
        public string? Descripcion { get; set; }

        /// <summary>
        /// Precio de venta actual del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Cantidad de unidades disponibles actualmente
        /// en el inventario.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Fecha de caducidad del producto.
        /// Puede ser nula para productos que no requieren
        /// control de caducidad.
        /// </summary>
        public DateTime? FechaCaducidad { get; set; }
    }
}