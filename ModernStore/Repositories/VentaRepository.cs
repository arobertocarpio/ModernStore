using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de administrar las operaciones
    /// relacionadas con las ventas del sistema.
    ///
    /// Permite consultar el historial de ventas, obtener
    /// el detalle de una venta y registrar nuevas ventas
    /// mediante procedimientos almacenados en SQL Server.
    /// </summary>
    public class VentaRepository
    {
        /// <summary>
        /// Obtiene todas las ventas registradas
        /// en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos Venta con la información
        /// general de cada operación.
        /// </returns>
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

        /// <summary>
        /// Obtiene los productos y cantidades asociados
        /// a una venta específica.
        /// </summary>
        /// <param name="idVenta">
        /// Identificador de la venta cuyo detalle
        /// se desea consultar.
        /// </param>
        /// <returns>
        /// Lista de objetos DetalleVenta correspondientes
        /// a la venta seleccionada.
        /// </returns>
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

        /// <summary>
        /// Registra una nueva venta en la base de datos.
        ///
        /// La operación envía el detalle de productos mediante
        /// un parámetro estructurado de tipo DetalleVentaType.
        /// El procedimiento almacenado se encarga de validar
        /// la venta, registrar su detalle y actualizar el stock.
        /// </summary>
        /// <param name="idUsuario">
        /// Identificador del usuario que registra la venta.
        /// </param>
        /// <param name="idCliente">
        /// Identificador del cliente asociado a la venta.
        /// Puede ser null cuando se utiliza el cliente
        /// predeterminado del sistema.
        /// </param>
        /// <param name="detalle">
        /// Tabla en memoria que contiene los productos
        /// y cantidades que forman parte de la venta.
        /// </param>
        /// <returns>
        /// Tupla que contiene el identificador de la venta,
        /// el total registrado y el mensaje devuelto
        /// por el procedimiento almacenado.
        /// </returns>
        /// <exception cref="Exception">
        /// Se lanza cuando el procedimiento almacenado
        /// no devuelve información sobre la venta registrada.
        /// </exception>
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

            // El detalle de la venta se envía como un
            // Table-Valued Parameter definido en SQL Server.
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