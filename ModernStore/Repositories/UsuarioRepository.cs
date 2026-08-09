using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class UsuarioRepository
    {
        public UsuarioSesion? Autenticar(
            string nombreUsuario,
            string contrasena)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_ObtenerParaAutenticacion",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@nombre_usuario",
                SqlDbType.VarChar,
                50
            ).Value = nombreUsuario;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            string hash =
                reader["contrasena_hash"].ToString()
                ?? string.Empty;

            if (!BCrypt.Net.BCrypt.Verify(
                contrasena,
                hash))
            {
                return null;
            }

            bool activo =
                Convert.ToBoolean(
                    reader["activo"]
                );

            if (!activo)
            {
                return null;
            }

            string nombre =
                reader["nombre"].ToString()
                ?? string.Empty;

            string apellidoPaterno =
                reader["apellido_paterno"].ToString()
                ?? string.Empty;

            string apellidoMaterno =
                reader["apellido_materno"] == DBNull.Value
                    ? string.Empty
                    : reader["apellido_materno"].ToString()
                      ?? string.Empty;

            return new UsuarioSesion
            {
                IdUsuario =
                    Convert.ToInt32(
                        reader["id_usuario"]
                    ),

                NombreUsuario =
                    reader["nombre_usuario"].ToString()
                    ?? string.Empty,

                NombreCompleto =
                    $"{nombre} {apellidoPaterno} {apellidoMaterno}".Trim(),

                Rol =
                    reader["rol"].ToString()
                    ?? string.Empty
            };
        }

        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_Listar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new Usuario
                {
                    IdUsuario =
                        Convert.ToInt32(
                            reader["id_usuario"]
                        ),

                    IdRol =
                        Convert.ToInt32(
                            reader["id_rol"]
                        ),

                    Rol =
                        reader["rol"].ToString()
                        ?? string.Empty,

                    Nombre =
                        reader["nombre"].ToString()
                        ?? string.Empty,

                    ApellidoPaterno =
                        reader["apellido_paterno"].ToString()
                        ?? string.Empty,

                    ApellidoMaterno =
                        reader["apellido_materno"] == DBNull.Value
                            ? null
                            : reader["apellido_materno"].ToString(),

                    NombreUsuario =
                        reader["nombre_usuario"].ToString()
                        ?? string.Empty,

                    Activo =
                        Convert.ToBoolean(
                            reader["activo"]
                        )
                });
            }

            return usuarios;
        }

        public void Crear(
            Usuario usuario,
            string contrasena,
            int idUsuarioEjecutor)
        {
            string hash =
                BCrypt.Net.BCrypt.HashPassword(contrasena);

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_Insertar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_rol",
                SqlDbType.Int
            ).Value = usuario.IdRol;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                50
            ).Value = usuario.Nombre;

            command.Parameters.Add(
                "@apellido_paterno",
                SqlDbType.VarChar,
                50
            ).Value = usuario.ApellidoPaterno;

            command.Parameters.Add(
                "@apellido_materno",
                SqlDbType.VarChar,
                50
            ).Value =
                string.IsNullOrWhiteSpace(usuario.ApellidoMaterno)
                    ? DBNull.Value
                    : usuario.ApellidoMaterno;

            command.Parameters.Add(
                "@nombre_usuario",
                SqlDbType.VarChar,
                50
            ).Value = usuario.NombreUsuario;

            command.Parameters.Add(
                "@contrasena_hash",
                SqlDbType.VarChar,
                255
            ).Value = hash;

            command.Parameters.Add(
                "@id_usuario_ejecutor",
                SqlDbType.Int
            ).Value = idUsuarioEjecutor;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Actualizar(
            Usuario usuario,
            int idUsuarioEjecutor)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_Actualizar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = usuario.IdUsuario;

            command.Parameters.Add(
                "@id_rol",
                SqlDbType.Int
            ).Value = usuario.IdRol;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                50
            ).Value = usuario.Nombre;

            command.Parameters.Add(
                "@apellido_paterno",
                SqlDbType.VarChar,
                50
            ).Value = usuario.ApellidoPaterno;

            command.Parameters.Add(
                "@apellido_materno",
                SqlDbType.VarChar,
                50
            ).Value =
                string.IsNullOrWhiteSpace(usuario.ApellidoMaterno)
                    ? DBNull.Value
                    : usuario.ApellidoMaterno;

            command.Parameters.Add(
                "@nombre_usuario",
                SqlDbType.VarChar,
                50
            ).Value = usuario.NombreUsuario;

            command.Parameters.Add(
                "@id_usuario_ejecutor",
                SqlDbType.Int
            ).Value = idUsuarioEjecutor;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void CambiarContrasena(
            int idUsuario,
            string nuevaContrasena,
            int idUsuarioEjecutor)
        {
            string hash =
                BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_CambiarContrasena",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            command.Parameters.Add(
                "@nueva_contrasena_hash",
                SqlDbType.VarChar,
                255
            ).Value = hash;

            command.Parameters.Add(
                "@id_usuario_ejecutor",
                SqlDbType.Int
            ).Value = idUsuarioEjecutor;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Desactivar(
            int idUsuario,
            int idUsuarioEjecutor)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_Desactivar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            command.Parameters.Add(
                "@id_usuario_ejecutor",
                SqlDbType.Int
            ).Value = idUsuarioEjecutor;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Reactivar(
            int idUsuario,
            int idUsuarioEjecutor)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Usuario_Reactivar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            command.Parameters.Add(
                "@id_usuario_ejecutor",
                SqlDbType.Int
            ).Value = idUsuarioEjecutor;

            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}