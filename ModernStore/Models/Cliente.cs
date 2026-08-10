namespace ModernStore.Models
{
    /// <summary>
    /// Representa a un cliente registrado en el sistema.
    ///
    /// Contiene la información personal básica utilizada
    /// para identificarlo y asociarlo con las ventas.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único del cliente.
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Nombre del cliente.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Apellido paterno del cliente.
        /// </summary>
        public string ApellidoPaterno { get; set; } = string.Empty;

        /// <summary>
        /// Apellido materno del cliente.
        /// Puede ser nulo cuando no se proporciona.
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Número telefónico de contacto del cliente.
        /// Puede ser nulo cuando no se proporciona.
        /// </summary>
        public string? Telefono { get; set; }

        /// <summary>
        /// Obtiene el nombre completo del cliente
        /// combinando su nombre y apellidos.
        ///
        /// Esta propiedad se calcula automáticamente
        /// y no requiere almacenarse por separado.
        /// </summary>
        public string NombreCompleto =>
            $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();
    }
}