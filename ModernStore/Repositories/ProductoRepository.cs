using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class ProductoRepository
    {
        public List<Producto> Listar()
        {
            var productos = new List<Producto>();

            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_Listar",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(MapearProducto(reader));
            }

            return productos;
        }

        public Producto? ObtenerPorId(int idProducto)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_ObtenerPorId",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_producto",
                SqlDbType.Int
            ).Value = idProducto;

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return MapearProducto(reader);
        }

        public void Crear(Producto producto, int idUsuario)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_Insertar",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            AgregarParametrosProducto(command, producto);

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Actualizar(
            Producto producto,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_Actualizar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_producto",
                SqlDbType.Int
            ).Value = producto.IdProducto;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = producto.IdCategoria;

            command.Parameters.Add(
                "@id_proveedor",
                SqlDbType.Int
            ).Value =
                producto.IdProveedor.HasValue
                    ? producto.IdProveedor.Value
                    : DBNull.Value;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                100
            ).Value = producto.Nombre;

            command.Parameters.Add(
                "@descripcion",
                SqlDbType.VarChar,
                255
            ).Value =
                string.IsNullOrWhiteSpace(producto.Descripcion)
                    ? DBNull.Value
                    : producto.Descripcion;

            command.Parameters.Add(
                "@precio",
                SqlDbType.Decimal
            ).Value = producto.Precio;

            command.Parameters["@precio"].Precision = 12;
            command.Parameters["@precio"].Scale = 2;

            command.Parameters.Add(
                "@stock",
                SqlDbType.Int
            ).Value = producto.Stock;

            command.Parameters.Add(
                "@fecha_caducidad",
                SqlDbType.Date
            ).Value =
                producto.FechaCaducidad.HasValue
                    ? producto.FechaCaducidad.Value
                    : DBNull.Value;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Eliminar(
            int idProducto,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_Eliminar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_producto",
                SqlDbType.Int
            ).Value = idProducto;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        private static Producto MapearProducto(SqlDataReader reader)
        {
            return new Producto
            {
                IdProducto = Convert.ToInt32(
                    reader["id_producto"]
                ),

                IdCategoria = Convert.ToInt32(
                    reader["id_categoria"]
                ),

                IdProveedor = reader["id_proveedor"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(reader["id_proveedor"]),

                Nombre =
                    reader["nombre"].ToString() ?? string.Empty,

                Descripcion = reader["descripcion"] == DBNull.Value
                    ? null
                    : reader["descripcion"].ToString(),

                Precio = Convert.ToDecimal(
                    reader["precio"]
                ),

                Stock = Convert.ToInt32(
                    reader["stock"]
                ),

                FechaCaducidad =
                    reader["fecha_caducidad"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["fecha_caducidad"]
                        )
            };
        }

        private static void AgregarParametrosProducto(
            SqlCommand command,
            Producto producto)
        {
            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = producto.IdCategoria;

            command.Parameters.Add(
                "@id_proveedor",
                SqlDbType.Int
            ).Value = producto.IdProveedor.HasValue
                ? producto.IdProveedor.Value
                : DBNull.Value;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                100
            ).Value = producto.Nombre;

            command.Parameters.Add(
                "@descripcion",
                SqlDbType.VarChar,
                255
            ).Value = string.IsNullOrWhiteSpace(producto.Descripcion)
                ? DBNull.Value
                : producto.Descripcion;

            SqlParameter precioParameter = command.Parameters.Add(
                "@precio",
                SqlDbType.Decimal
            );

            precioParameter.Precision = 10;
            precioParameter.Scale = 2;
            precioParameter.Value = producto.Precio;

            command.Parameters.Add(
                "@stock",
                SqlDbType.Int
            ).Value = producto.Stock;

            command.Parameters.Add(
                "@fecha_caducidad",
                SqlDbType.Date
            ).Value = producto.FechaCaducidad.HasValue
                ? producto.FechaCaducidad.Value
                : DBNull.Value;
        }
    }
}