namespace ModernStore.Models
{
    /// <summary>
    /// Representa la información del usuario que mantiene
    /// una sesión activa dentro del sistema.
    ///
    /// Contiene únicamente los datos necesarios para
    /// identificar al usuario durante la ejecución
    /// de la aplicación y aplicar las restricciones
    /// correspondientes según su rol.
    /// </summary>
    public class UsuarioSesion
    {
        /// <summary>
        /// Identificador único del usuario autenticado.
        ///
        /// Se utiliza para relacionar las operaciones
        /// realizadas durante la sesión con el usuario
        /// que las ejecutó.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre utilizado por el usuario
        /// para iniciar sesión en el sistema.
        /// </summary>
        public string NombreUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Nombre completo del usuario autenticado.
        ///
        /// Se utiliza principalmente para mostrar
        /// información del usuario dentro de la interfaz.
        /// </summary>
        public string NombreCompleto { get; set; } = string.Empty;

        /// <summary>
        /// Rol asignado al usuario autenticado.
        ///
        /// Permite determinar las funciones del sistema
        /// disponibles durante la sesión.
        /// </summary>
        public string Rol { get; set; } = string.Empty;
    }
}