using Microsoft.Data.SqlClient;

namespace ModernStore.Data
{
    public static class Database
    {
        private static readonly string connectionString =
            "Server=localhost;Database=TiendaLaModerna;User Id=sa;Password=Mauri56h6$;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}