using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de consultar los roles
    /// disponibles dentro del sistema.
    ///
    /// Los roles permiten determinar el nivel de acceso
    /// y las funciones disponibles para cada usuario.
    /// </summary>
    public class RolRepository
    {
        /// <summary>
        /// Obtiene todos los roles registrados
        /// en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos Rol ordenados alfabéticamente
        /// por nombre.
        /// </returns>
        public List<Rol> Listar()
        {
            var roles = new List<Rol>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "SELECT id_rol, nombre " +
                "FROM Roles " +
                "ORDER BY nombre",
                connection
            );

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(new Rol
                {
                    IdRol =
                        Convert.ToInt32(
                            reader["id_rol"]
                        ),

                    Nombre =
                        reader["nombre"].ToString()
                        ?? string.Empty
                });
            }

            return roles;
        }
    }
}