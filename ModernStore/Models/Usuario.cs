namespace ModernStore.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public int IdRol { get; set; }

        public string Rol { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string ApellidoPaterno { get; set; } = string.Empty;

        public string? ApellidoMaterno { get; set; }

        public string NombreUsuario { get; set; } = string.Empty;

        public bool Activo { get; set; }

        public string NombreCompleto =>
            $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();

        public string Estado =>
            Activo ? "Activo" : "Inactivo";
    }
}