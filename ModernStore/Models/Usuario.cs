namespace ModernStore.Models
{
    /// <summary>
    /// Representa a un usuario registrado en el sistema.
    ///
    /// Contiene la información personal, las credenciales
    /// de identificación, el rol asignado y el estado
    /// actual de la cuenta.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Identificador del rol asignado al usuario.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre del rol asociado al usuario.
        /// Se utiliza principalmente para mostrar
        /// información en la interfaz.
        /// </summary>
        public string Rol { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Apellido paterno del usuario.
        /// </summary>
        public string ApellidoPaterno { get; set; } = string.Empty;

        /// <summary>
        /// Apellido materno del usuario.
        /// Puede ser nulo cuando no se proporciona.
        /// </summary>
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Nombre utilizado por el usuario
        /// para identificarse al iniciar sesión.
        /// </summary>
        public string NombreUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la cuenta del usuario se encuentra activa.
        ///
        /// Una cuenta inactiva no puede iniciar sesión
        /// en el sistema.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Obtiene el nombre completo del usuario
        /// combinando su nombre y apellidos.
        ///
        /// El valor se calcula automáticamente y
        /// no necesita almacenarse por separado.
        /// </summary>
        public string NombreCompleto =>
            $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();

        /// <summary>
        /// Obtiene una representación textual del estado
        /// actual de la cuenta.
        ///
        /// Devuelve "Activo" cuando la cuenta está habilitada
        /// e "Inactivo" cuando se encuentra deshabilitada.
        /// </summary>
        public string Estado =>
            Activo ? "Activo" : "Inactivo";
    }
}