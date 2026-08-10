namespace ModernStore.Models
{
    /// <summary>
    /// Representa a un proveedor registrado en el sistema.
    ///
    /// Contiene la información básica necesaria para
    /// identificar y contactar a los proveedores asociados
    /// con los productos del inventario.
    /// </summary>
    public class Proveedor
    {
        /// <summary>
        /// Identificador único del proveedor.
        /// </summary>
        public int IdProveedor { get; set; }

        /// <summary>
        /// Nombre del proveedor.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Número telefónico de contacto del proveedor.
        /// Puede ser nulo cuando no se proporciona.
        /// </summary>
        public string? Telefono { get; set; }

        /// <summary>
        /// Dirección de correo electrónico del proveedor.
        /// Puede ser nula cuando no se proporciona.
        /// </summary>
        public string? Correo { get; set; }
    }
}