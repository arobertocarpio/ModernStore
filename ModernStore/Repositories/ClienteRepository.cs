using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de gestionar las operaciones
    /// relacionadas con los clientes del sistema.
    ///
    /// Utiliza procedimientos almacenados para consultar,
    /// registrar, actualizar y eliminar clientes.
    /// </summary>
    public class ClienteRepository
    {
        /// <summary>
        /// Obtiene todos los clientes registrados
        /// en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos Cliente.
        /// </returns>
        public List<Cliente> Listar()
        {
            var clientes = new List<Cliente>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Cliente_Listar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                clientes.Add(new Cliente
                {
                    IdCliente =
                        Convert.ToInt32(
                            reader["id_cliente"]
                        ),

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

                    Telefono =
                        reader["telefono"] == DBNull.Value
                            ? null
                            : reader["telefono"].ToString()
                });
            }

            return clientes;
        }

        /// <summary>
        /// Registra un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="cliente">
        /// Cliente que se desea registrar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza la operación.
        /// Este valor se utiliza para registrar la acción
        /// correspondiente en la bitácora.
        /// </param>
        public void Crear(
            Cliente cliente,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Cliente_Insertar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            AgregarParametros(command, cliente);

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Actualiza la información de un cliente existente.
        /// </summary>
        /// <param name="cliente">
        /// Cliente que contiene los datos actualizados.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que ejecuta la modificación.
        /// </param>
        public void Actualizar(
            Cliente cliente,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Cliente_Actualizar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_cliente",
                SqlDbType.Int
            ).Value = cliente.IdCliente;

            AgregarParametros(command, cliente);

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Elimina un cliente de la base de datos.
        /// </summary>
        /// <param name="idCliente">
        /// Identificador del cliente que se desea eliminar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que ejecuta la operación.
        /// </param>
        public void Eliminar(
            int idCliente,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Cliente_Eliminar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_cliente",
                SqlDbType.Int
            ).Value = idCliente;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Agrega al comando SQL los parámetros comunes
        /// utilizados para crear o actualizar un cliente.
        ///
        /// Los campos opcionales se envían como DBNull
        /// cuando no contienen información.
        /// </summary>
        /// <param name="command">
        /// Comando SQL al que se agregarán los parámetros.
        /// </param>
        /// <param name="cliente">
        /// Cliente del cual se obtienen los valores.
        /// </param>
        private static void AgregarParametros(
            SqlCommand command,
            Cliente cliente)
        {
            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                50
            ).Value = cliente.Nombre;

            command.Parameters.Add(
                "@apellido_paterno",
                SqlDbType.VarChar,
                50
            ).Value = cliente.ApellidoPaterno;

            command.Parameters.Add(
                "@apellido_materno",
                SqlDbType.VarChar,
                50
            ).Value =
                string.IsNullOrWhiteSpace(cliente.ApellidoMaterno)
                    ? DBNull.Value
                    : cliente.ApellidoMaterno;

            command.Parameters.Add(
                "@telefono",
                SqlDbType.VarChar,
                15
            ).Value =
                string.IsNullOrWhiteSpace(cliente.Telefono)
                    ? DBNull.Value
                    : cliente.Telefono;
        }
    }
}