namespace ModernStore.Models
{
    /// <summary>
    /// Representa el resumen de ventas correspondiente
    /// a un día dentro de un reporte semanal.
    ///
    /// Contiene la cantidad de ventas realizadas y
    /// el importe total vendido durante la fecha indicada.
    /// </summary>
    public class ReporteVentaSemanal
    {
        /// <summary>
        /// Fecha correspondiente al resumen de ventas.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Cantidad de ventas realizadas durante la fecha.
        /// </summary>
        public int CantidadVentas { get; set; }

        /// <summary>
        /// Importe total vendido durante la fecha.
        /// </summary>
        public decimal TotalVendido { get; set; }
    }
}