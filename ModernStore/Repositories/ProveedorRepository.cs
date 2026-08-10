using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de administrar las operaciones
    /// relacionadas con los proveedores del sistema.
    ///
    /// Permite consultar, registrar, actualizar y eliminar
    /// proveedores mediante procedimientos almacenados.
    /// </summary>
    public class ProveedorRepository
    {
        /// <summary>
        /// Obtiene todos los proveedores registrados
        /// en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos Proveedor.
        /// </returns>
        public List<Proveedor> Listar()
        {
            var proveedores = new List<Proveedor>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Proveedor_Listar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                proveedores.Add(new Proveedor
                {
                    IdProveedor =
                        Convert.ToInt32(
                            reader["id_proveedor"]
                        ),

                    Nombre =
                        reader["nombre"].ToString()
                        ?? string.Empty,

                    Telefono =
                        reader["telefono"] == DBNull.Value
                            ? null
                            : reader["telefono"].ToString(),

                    Correo =
                        reader["correo"] == DBNull.Value
                            ? null
                            : reader["correo"].ToString()
                });
            }

            return proveedores;
        }

        /// <summary>
        /// Registra un nuevo proveedor en la base de datos.
        /// </summary>
        /// <param name="proveedor">
        /// Proveedor que contiene la información
        /// que será registrada.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza la operación.
        /// Este valor permite registrar la acción en la bitácora.
        /// </param>
        public void Crear(
            Proveedor proveedor,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Proveedor_Insertar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                100
            ).Value = proveedor.Nombre;

            command.Parameters.Add(
                "@telefono",
                SqlDbType.VarChar,
                15
            ).Value =
                string.IsNullOrWhiteSpace(
                    proveedor.Telefono
                )
                    ? DBNull.Value
                    : proveedor.Telefono;

            command.Parameters.Add(
                "@correo",
                SqlDbType.VarChar,
                100
            ).Value =
                string.IsNullOrWhiteSpace(
                    proveedor.Correo
                )
                    ? DBNull.Value
                    : proveedor.Correo;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Actualiza la información de un proveedor existente.
        /// </summary>
        /// <param name="proveedor">
        /// Proveedor que contiene la información actualizada.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza
        /// la modificación.
        /// </param>
        public void Actualizar(
            Proveedor proveedor,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Proveedor_Actualizar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_proveedor",
                SqlDbType.Int
            ).Value = proveedor.IdProveedor;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                100
            ).Value = proveedor.Nombre;

            command.Parameters.Add(
                "@telefono",
                SqlDbType.VarChar,
                15
            ).Value =
                string.IsNullOrWhiteSpace(
                    proveedor.Telefono
                )
                    ? DBNull.Value
                    : proveedor.Telefono;

            command.Parameters.Add(
                "@correo",
                SqlDbType.VarChar,
                100
            ).Value =
                string.IsNullOrWhiteSpace(
                    proveedor.Correo
                )
                    ? DBNull.Value
                    : proveedor.Correo;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Elimina un proveedor de la base de datos.
        /// </summary>
        /// <param name="idProveedor">
        /// Identificador del proveedor que se desea eliminar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que ejecuta la operación.
        /// </param>
        public void Eliminar(
            int idProveedor,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Proveedor_Eliminar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_proveedor",
                SqlDbType.Int
            ).Value = idProveedor;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}