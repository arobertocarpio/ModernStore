namespace ModernStore.Models
{
    /// <summary>
    /// Representa una venta registrada en el sistema.
    ///
    /// Contiene la información general de la operación,
    /// incluyendo la fecha, el usuario que realizó la venta,
    /// el cliente asociado y los importes correspondientes.
    /// </summary>
    public class Venta
    {
        /// <summary>
        /// Identificador único de la venta.
        /// </summary>
        public int IdVenta { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó la venta.
        /// </summary>
        public DateTime FechaVenta { get; set; }

        /// <summary>
        /// Identificador del usuario que registró
        /// la venta en el sistema.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre de usuario de la cuenta que
        /// realizó la venta.
        /// </summary>
        public string NombreUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Nombre completo del usuario responsable
        /// de registrar la venta.
        /// </summary>
        public string Usuario { get; set; } = string.Empty;

        /// <summary>
        /// Identificador del cliente asociado
        /// a la venta.
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Nombre del cliente asociado a la venta.
        /// Se utiliza principalmente para mostrar
        /// información en la interfaz.
        /// </summary>
        public string Cliente { get; set; } = string.Empty;

        /// <summary>
        /// Importe correspondiente al subtotal
        /// registrado en la venta.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Importe total registrado para la venta.
        /// </summary>
        public decimal Total { get; set; }
    }
}