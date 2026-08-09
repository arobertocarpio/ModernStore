using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class ProveedorRepository
    {
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
                string.IsNullOrWhiteSpace(proveedor.Telefono)
                    ? DBNull.Value
                    : proveedor.Telefono;

            command.Parameters.Add(
                "@correo",
                SqlDbType.VarChar,
                100
            ).Value =
                string.IsNullOrWhiteSpace(proveedor.Correo)
                    ? DBNull.Value
                    : proveedor.Correo;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

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
                string.IsNullOrWhiteSpace(proveedor.Telefono)
                    ? DBNull.Value
                    : proveedor.Telefono;

            command.Parameters.Add(
                "@correo",
                SqlDbType.VarChar,
                100
            ).Value =
                string.IsNullOrWhiteSpace(proveedor.Correo)
                    ? DBNull.Value
                    : proveedor.Correo;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

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