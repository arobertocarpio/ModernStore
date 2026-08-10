namespace ModernStore.Models
{
    /// <summary>
    /// Representa una categoría utilizada para clasificar
    /// los productos registrados en el sistema.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
    }
}