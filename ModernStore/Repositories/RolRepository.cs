using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class RolRepository
    {
        public List<Rol> Listar()
        {
            var roles = new List<Rol>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "SELECT id_rol, nombre FROM Roles ORDER BY nombre",
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
                        Convert.ToInt32(reader["id_rol"]),

                    Nombre =
                        reader["nombre"].ToString()
                        ?? string.Empty
                });
            }

            return roles;
        }
    }
}