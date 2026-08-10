namespace ModernStore.Models
{
    /// <summary>
    /// Representa el resumen de un corte
    /// de caja correspondiente a una fecha.
    /// </summary>
    public class CorteCaja
    {
        public DateTime FechaCorte { get; set; }

        public int CantidadVentas { get; set; }

        public decimal TotalEfectivo { get; set; }
    }
}