namespace ModernStore.Models
{
    /// <summary>
    /// Representa un producto agregado al carrito
    /// durante el proceso de una venta.
    ///
    /// Contiene la información necesaria para calcular
    /// el importe correspondiente a cada producto.
    /// </summary>
    public class CarritoItem
    {
        /// <summary>
        /// Identificador del producto asociado
        /// al elemento del carrito.
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Nombre del producto mostrado
        /// dentro del carrito.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Precio unitario del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Cantidad de unidades agregadas al carrito.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Obtiene el subtotal correspondiente
        /// al producto.
        ///
        /// El valor se calcula multiplicando
        /// el precio unitario por la cantidad.
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                return Precio * Cantidad;
            }
        }
    }
}