using Microsoft.Data.SqlClient;
using ModernStore.Data;
using System.Data;

namespace ModernStore.Repositories
{
    public class VentaRepository
    {
        public (int IdVenta, decimal Total, string Mensaje) Registrar(
            int idUsuario,
            int? idCliente,
            DataTable detalle)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Venta_Registrar",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_usuario", idUsuario);

            command.Parameters.AddWithValue(
                "@id_cliente",
                idCliente.HasValue ? idCliente.Value : DBNull.Value
            );

            SqlParameter detalleParameter =
                command.Parameters.AddWithValue("@detalle", detalle);

            detalleParameter.SqlDbType = SqlDbType.Structured;
            detalleParameter.TypeName = "dbo.DetalleVentaType";

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return (
                    Convert.ToInt32(reader["id_venta"]),
                    Convert.ToDecimal(reader["total"]),
                    reader["mensaje"].ToString() ?? string.Empty
                );
            }

            throw new Exception("No se recibió respuesta al registrar la venta.");
        }
    }
}