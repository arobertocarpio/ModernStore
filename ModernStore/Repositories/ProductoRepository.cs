using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de administrar las operaciones
    /// relacionadas con los productos e inventario.
    ///
    /// Permite consultar, registrar, actualizar y eliminar
    /// productos, además de obtener productos con bajo stock
    /// y próximos a caducar.
    /// </summary>
    public class ProductoRepository
    {
        /// <summary>
        /// Obtiene todos los productos registrados
        /// en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de productos registrados.
        /// </returns>
        public List<Producto> Listar()
        {
            var productos = new List<Producto>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_Listar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(
                    MapearProducto(reader)
                );
            }

            return productos;
        }

        /// <summary>
        /// Obtiene un producto mediante su identificador.
        /// </summary>
        /// <param name="idProducto">
        /// Identificador del producto que se desea consultar.
        /// </param>
        /// <returns>
        /// El producto encontrado o null si no existe.
        /// </returns>
        public Producto? ObtenerPorId(int idProducto)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_ObtenerPorId",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_producto",
                SqlDbType.Int
            ).Value = idProducto;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return MapearProducto(reader);
        }

        /// <summary>
        /// Registra un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="producto">
        /// Producto que contiene la información a registrar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza la operación.
        /// Se utiliza para registrar la acción en la bitácora.
        /// </param>
        public void Crear(
            Producto producto,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_Insertar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            AgregarParametrosProducto(
                command,
                producto
            );

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Actualiza la información de un producto existente.
        /// </summary>
        /// <param name="producto">
        /// Producto con la información actualizada.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza la modificación.
        /// </param>
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
                string.IsNullOrWhiteSpace(
                    producto.Descripcion
                )
                    ? DBNull.Value
                    : producto.Descripcion;

            SqlParameter precioParameter =
                command.Parameters.Add(
                    "@precio",
                    SqlDbType.Decimal
                );

            precioParameter.Precision = 12;
            precioParameter.Scale = 2;
            precioParameter.Value = producto.Precio;

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

        /// <summary>
        /// Elimina un producto de la base de datos.
        /// </summary>
        /// <param name="idProducto">
        /// Identificador del producto que se desea eliminar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que ejecuta la operación.
        /// </param>
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

        /// <summary>
        /// Convierte el registro obtenido desde SQL Server
        /// en una instancia de Producto.
        ///
        /// Centraliza el mapeo para evitar repetir la misma
        /// conversión en diferentes consultas.
        /// </summary>
        /// <param name="reader">
        /// Lector que contiene los datos obtenidos
        /// desde la base de datos.
        /// </param>
        /// <returns>
        /// Objeto Producto construido a partir del registro.
        /// </returns>
        private static Producto MapearProducto(
            SqlDataReader reader)
        {
            return new Producto
            {
                IdProducto =
                    Convert.ToInt32(
                        reader["id_producto"]
                    ),

                IdCategoria =
                    Convert.ToInt32(
                        reader["id_categoria"]
                    ),

                IdProveedor =
                    reader["id_proveedor"] == DBNull.Value
                        ? null
                        : Convert.ToInt32(
                            reader["id_proveedor"]
                        ),

                Nombre =
                    reader["nombre"].ToString()
                    ?? string.Empty,

                Descripcion =
                    reader["descripcion"] == DBNull.Value
                        ? null
                        : reader["descripcion"].ToString(),

                Precio =
                    Convert.ToDecimal(
                        reader["precio"]
                    ),

                Stock =
                    Convert.ToInt32(
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

        /// <summary>
        /// Agrega al comando SQL los parámetros utilizados
        /// para registrar un producto.
        ///
        /// Los valores opcionales, como proveedor,
        /// descripción y fecha de caducidad, se envían
        /// como DBNull cuando no contienen información.
        /// </summary>
        /// <param name="command">
        /// Comando SQL que recibirá los parámetros.
        /// </param>
        /// <param name="producto">
        /// Producto del cual se obtienen los valores.
        /// </param>
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
                string.IsNullOrWhiteSpace(
                    producto.Descripcion
                )
                    ? DBNull.Value
                    : producto.Descripcion;

            SqlParameter precioParameter =
                command.Parameters.Add(
                    "@precio",
                    SqlDbType.Decimal
                );

            precioParameter.Precision = 12;
            precioParameter.Scale = 2;
            precioParameter.Value = producto.Precio;

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
        }

        /// <summary>
        /// Obtiene los productos cuyo stock se encuentra
        /// por debajo del límite definido en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de productos con bajo nivel de existencias.
        /// </returns>
        public List<Producto> ListarBajoStock()
        {
            var productos =
                new List<Producto>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_ListarBajoStock",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    IdProducto =
                        Convert.ToInt32(
                            reader["id_producto"]
                        ),

                    Nombre =
                        reader["nombre"].ToString()
                        ?? string.Empty,

                    Stock =
                        Convert.ToInt32(
                            reader["stock"]
                        ),

                    Precio =
                        Convert.ToDecimal(
                            reader["precio"]
                        )
                });
            }

            return productos;
        }

        /// <summary>
        /// Obtiene los productos cuya fecha de caducidad
        /// se encuentra próxima.
        /// </summary>
        /// <returns>
        /// Lista de tuplas que contiene el producto y
        /// la cantidad de días restantes para su caducidad.
        /// </returns>
        public List<(Producto Producto, int DiasParaCaducar)>
            ListarProximosCaducar()
        {
            var productos =
                new List<(
                    Producto Producto,
                    int DiasParaCaducar
                )>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Producto_ListarProximosCaducar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                Producto producto =
                    new Producto
                    {
                        IdProducto =
                            Convert.ToInt32(
                                reader["id_producto"]
                            ),

                        Nombre =
                            reader["nombre"].ToString()
                            ?? string.Empty,

                        Stock =
                            Convert.ToInt32(
                                reader["stock"]
                            ),

                        FechaCaducidad =
                            Convert.ToDateTime(
                                reader["fecha_caducidad"]
                            )
                    };

                int diasParaCaducar =
                    Convert.ToInt32(
                        reader["dias_para_caducar"]
                    );

                productos.Add(
                    (producto, diasParaCaducar)
                );
            }

            return productos;
        }
    }
}