using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class VentaRepository
    { 
        public List<Venta> Listar()
        {
            var ventas = new List<Venta>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Venta_Listar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                ventas.Add(new Venta
                {
                    IdVenta =
                        Convert.ToInt32(
                            reader["id_venta"]
                        ),

                    FechaVenta =
                        Convert.ToDateTime(
                            reader["fecha_venta"]
                        ),

                    IdUsuario =
                        Convert.ToInt32(
                            reader["id_usuario"]
                        ),

                    NombreUsuario =
                        reader["nombre_usuario"].ToString()
                        ?? string.Empty,

                    Usuario =
                        reader["usuario"].ToString()
                        ?? string.Empty,

                    IdCliente =
                        Convert.ToInt32(
                            reader["id_cliente"]
                        ),

                    Cliente =
                        reader["cliente"].ToString()
                        ?? string.Empty,

                    Subtotal =
                        Convert.ToDecimal(
                            reader["subtotal"]
                        ),

                    Total =
                        Convert.ToDecimal(
                            reader["total"]
                        )
                });
            }

            return ventas;
        }

        public List<DetalleVenta> ObtenerDetalle(
            int idVenta)
        {
            var detalles =
                new List<DetalleVenta>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Venta_ObtenerDetalle",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_venta",
                SqlDbType.Int
            ).Value = idVenta;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                detalles.Add(new DetalleVenta
                {
                    IdDetalleVenta =
                        Convert.ToInt32(
                            reader["id_detalle_venta"]
                        ),

                    IdVenta =
                        Convert.ToInt32(
                            reader["id_venta"]
                        ),

                    IdProducto =
                        Convert.ToInt32(
                            reader["id_producto"]
                        ),

                    Producto =
                        reader["producto"].ToString()
                        ?? string.Empty,

                    Cantidad =
                        Convert.ToInt32(
                            reader["cantidad"]
                        ),

                    PrecioUnitario =
                        Convert.ToDecimal(
                            reader["precio_unitario"]
                        ),

                    Subtotal =
                        Convert.ToDecimal(
                            reader["subtotal"]
                        )
                });
            }

            return detalles;
        }

        public (
            int IdVenta,
            decimal Total,
            string Mensaje
        ) Registrar(
            int idUsuario,
            int? idCliente,
            DataTable detalle)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Venta_Registrar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.AddWithValue(
                "@id_usuario",
                idUsuario
            );

            command.Parameters.AddWithValue(
                "@id_cliente",
                idCliente.HasValue
                    ? idCliente.Value
                    : DBNull.Value
            );

            SqlParameter detalleParameter =
                command.Parameters.AddWithValue(
                    "@detalle",
                    detalle
                );

            detalleParameter.SqlDbType =
                SqlDbType.Structured;

            detalleParameter.TypeName =
                "dbo.DetalleVentaType";

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (reader.Read())
            {
                return (
                    Convert.ToInt32(
                        reader["id_venta"]
                    ),

                    Convert.ToDecimal(
                        reader["total"]
                    ),

                    reader["mensaje"].ToString()
                        ?? string.Empty
                );
            }

            throw new Exception(
                "No se recibió respuesta al registrar la venta."
            );
        }
    }
}