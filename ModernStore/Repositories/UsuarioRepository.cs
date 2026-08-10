using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de administrar las operaciones
    /// relacionadas con los usuarios y la autenticación.
    ///
    /// Permite autenticar usuarios, consultar cuentas,
    /// registrar y actualizar usuarios, cambiar contraseñas
    /// y controlar el estado activo o inactivo de las cuentas.
    ///
    /// Las contraseñas son protegidas mediante BCrypt antes
    /// de almacenarse en la base de datos.
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Valida las credenciales de un usuario e inicia
        /// la construcción de su información de sesión.
        /// </summary>
        /// <param name="nombreUsuario">
        /// Nombre de usuario utilizado para iniciar sesión.
        /// </param>
        /// <param name="contrasena">
        /// Contraseña ingresada por el usuario.
        /// </param>
        /// <returns>
        /// Un objeto UsuarioSesion cuando las credenciales
        /// son correctas y la cuenta se encuentra activa;
        /// de lo contrario, null.
        /// </returns>
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

            // Si el nombre de usuario no existe,
            // la autenticación es rechazada.
            if (!reader.Read())
            {
                return null;
            }

            string hash =
                reader["contrasena_hash"].ToString()
                ?? string.Empty;

            // BCrypt compara la contraseña ingresada
            // con el hash almacenado en la base de datos.
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

            // Las cuentas inactivas no pueden
            // iniciar sesión en el sistema.
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
                    $"{nombre} {apellidoPaterno} {apellidoMaterno}"
                    .Trim(),

                Rol =
                    reader["rol"].ToString()
                    ?? string.Empty
            };
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados
        /// en el sistema.
        /// </summary>
        /// <returns>
        /// Lista de usuarios con su información,
        /// rol y estado actual.
        /// </returns>
        public List<Usuario> Listar()
        {
            var usuarios =
                new List<Usuario>();

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

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        ///
        /// La contraseña recibida es convertida en un hash
        /// mediante BCrypt antes de enviarse a la base de datos.
        /// </summary>
        /// <param name="usuario">
        /// Usuario que contiene la información
        /// que será registrada.
        /// </param>
        /// <param name="contrasena">
        /// Contraseña definida para la nueva cuenta.
        /// </param>
        /// <param name="idUsuarioEjecutor">
        /// Identificador del usuario que realiza
        /// la creación de la cuenta.
        /// </param>
        public void Crear(
            Usuario usuario,
            string contrasena,
            int idUsuarioEjecutor)
        {
            // Nunca se almacena directamente la contraseña.
            string hash =
                BCrypt.Net.BCrypt.HashPassword(
                    contrasena
                );

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
                string.IsNullOrWhiteSpace(
                    usuario.ApellidoMaterno
                )
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

        /// <summary>
        /// Actualiza la información general y el rol
        /// de un usuario existente.
        ///
        /// La contraseña no se modifica mediante este método.
        /// </summary>
        /// <param name="usuario">
        /// Usuario con la información actualizada.
        /// </param>
        /// <param name="idUsuarioEjecutor">
        /// Identificador del usuario que realiza
        /// la modificación.
        /// </param>
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
                string.IsNullOrWhiteSpace(
                    usuario.ApellidoMaterno
                )
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

        /// <summary>
        /// Cambia la contraseña de un usuario.
        ///
        /// La nueva contraseña es protegida mediante BCrypt
        /// antes de ser enviada a la base de datos.
        /// </summary>
        /// <param name="idUsuario">
        /// Identificador del usuario cuya contraseña
        /// será modificada.
        /// </param>
        /// <param name="nuevaContrasena">
        /// Nueva contraseña definida para la cuenta.
        /// </param>
        /// <param name="idUsuarioEjecutor">
        /// Identificador del usuario que ejecuta el cambio.
        /// </param>
        public void CambiarContrasena(
            int idUsuario,
            string nuevaContrasena,
            int idUsuarioEjecutor)
        {
            string hash =
                BCrypt.Net.BCrypt.HashPassword(
                    nuevaContrasena
                );

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

        /// <summary>
        /// Desactiva una cuenta de usuario.
        ///
        /// Una cuenta inactiva no puede autenticarse
        /// en el sistema.
        /// </summary>
        /// <param name="idUsuario">
        /// Identificador del usuario que será desactivado.
        /// </param>
        /// <param name="idUsuarioEjecutor">
        /// Identificador del usuario que ejecuta la operación.
        /// </param>
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

        /// <summary>
        /// Reactiva una cuenta de usuario previamente
        /// desactivada.
        /// </summary>
        /// <param name="idUsuario">
        /// Identificador del usuario que será reactivado.
        /// </param>
        /// <param name="idUsuarioEjecutor">
        /// Identificador del usuario que ejecuta la operación.
        /// </param>
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