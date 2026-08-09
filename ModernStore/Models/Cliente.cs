namespace ModernStore.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string ApellidoPaterno { get; set; } = string.Empty;

        public string? ApellidoMaterno { get; set; }

        public string? Telefono { get; set; }

        public string NombreCompleto =>
            $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();
    }
}