namespace ModernStore.Models
{
    /// <summary>
    /// Representa un rol disponible dentro del sistema.
    ///
    /// Los roles permiten clasificar a los usuarios
    /// según las funciones y permisos que les corresponden.
    /// </summary>
    public class Rol
    {
        /// <summary>
        /// Identificador único del rol.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre asignado al rol.
        /// Por ejemplo: Administrador o Cajero.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
    }
}