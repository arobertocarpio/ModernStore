using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;

namespace ModernStore.Repositories
{
    public class UsuarioRepository
    {
        public UsuarioSesion? Autenticar(
            string nombreUsuario,
            string contrasena)
        {
            using SqlConnection connection = Database.GetConnection();

            connection.Open();

            string query = @"
                SELECT
                    u.id_usuario,
                    u.nombre,
                    u.apellido_paterno,
                    u.apellido_materno,
                    u.nombre_usuario,
                    u.contrasena_hash,
                    r.nombre AS rol
                FROM Usuarios u
                INNER JOIN Roles r
                    ON r.id_rol = u.id_rol
                WHERE u.nombre_usuario = @nombre_usuario
                  AND u.activo = 1;";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(
                "@nombre_usuario",
                nombreUsuario
            );

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            string hash = reader["contrasena_hash"].ToString()!;

            bool contrasenaCorrecta =
                BCrypt.Net.BCrypt.Verify(contrasena, hash);

            if (!contrasenaCorrecta)
            {
                return null;
            }

            string nombre = reader["nombre"].ToString()!;
            string apellidoPaterno =
                reader["apellido_paterno"].ToString()!;

            string apellidoMaterno =
                reader["apellido_materno"] == DBNull.Value
                    ? string.Empty
                    : reader["apellido_materno"].ToString()!;

            return new UsuarioSesion
            {
                IdUsuario = Convert.ToInt32(
                    reader["id_usuario"]
                ),

                NombreUsuario =
                    reader["nombre_usuario"].ToString()!,

                NombreCompleto =
                    $"{nombre} {apellidoPaterno} {apellidoMaterno}".Trim(),

                Rol =
                    reader["rol"].ToString()!
            };
        }
    }
}