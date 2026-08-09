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
                    IdProveedor = Convert.ToInt32(
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
    }
}