namespace ModernStore.Models
{
    /// <summary>
    /// Representa el detalle de un producto incluido
    /// dentro de una venta.
    ///
    /// Contiene la cantidad vendida, el precio unitario
    /// y el subtotal correspondiente al producto.
    /// </summary>
    public class DetalleVenta
    {
        /// <summary>
        /// Identificador único del detalle de venta.
        /// </summary>
        public int IdDetalleVenta { get; set; }

        /// <summary>
        /// Identificador de la venta a la que
        /// pertenece este detalle.
        /// </summary>
        public int IdVenta { get; set; }

        /// <summary>
        /// Identificador del producto vendido.
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Nombre del producto asociado al detalle.
        /// Se utiliza principalmente para mostrar
        /// información en la interfaz.
        /// </summary>
        public string Producto { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad de unidades vendidas
        /// del producto.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario registrado para el producto
        /// al momento de realizar la venta.
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Subtotal correspondiente a este detalle
        /// de venta.
        /// </summary>
        public decimal Subtotal { get; set; }
    }
}