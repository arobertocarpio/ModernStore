using Microsoft.Data.SqlClient;

namespace ModernStore.Data
{
    /// <summary>
    /// Proporciona el acceso centralizado a la conexión
    /// con la base de datos TiendaLaModerna.
    ///
    /// Esta clase permite que los repositorios obtengan
    /// conexiones a SQL Server sin duplicar la lógica
    /// de creación de conexiones.
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// Cadena de conexión utilizada para establecer
        /// comunicación con la base de datos.
        /// </summary>
        private static readonly string connectionString =
            "Server=localhost;Database=TiendaLaModerna;User Id=sa;Password=Mauri56h6$;TrustServerCertificate=True;";

        /// <summary>
        /// Crea una nueva instancia de SqlConnection
        /// utilizando la cadena de conexión configurada.
        /// </summary>
        /// <returns>
        /// Una nueva conexión hacia la base de datos
        /// TiendaLaModerna.
        /// </returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}