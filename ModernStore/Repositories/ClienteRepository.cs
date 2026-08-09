using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class ClienteRepository
    {
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