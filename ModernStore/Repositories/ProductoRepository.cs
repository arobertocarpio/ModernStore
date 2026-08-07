using Microsoft.Data.SqlClient;
using System.Data;
using ModernStore.Data;
using ModernStore.Models;

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
                var producto = new Producto
                {
                    IdProducto = Convert.ToInt32(reader["id_producto"]),
                    IdCategoria = Convert.ToInt32(reader["id_categoria"]),

                    IdProveedor = reader["id_proveedor"] == DBNull.Value
                        ? null
                        : Convert.ToInt32(reader["id_proveedor"]),

                    Nombre = reader["nombre"].ToString() ?? string.Empty,

                    Descripcion = reader["descripcion"] == DBNull.Value
                        ? null
                        : reader["descripcion"].ToString(),

                    Precio = Convert.ToDecimal(reader["precio"]),

                    Stock = Convert.ToInt32(reader["stock"]),

                    FechaCaducidad = reader["fecha_caducidad"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(reader["fecha_caducidad"])
                };

                productos.Add(producto);
            }

            return productos;
        }
    }
}