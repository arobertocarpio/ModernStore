using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de administrar las operaciones
    /// relacionadas con las categorías de productos.
    /// 
    /// Todas las operaciones se realizan mediante
    /// procedimientos almacenados definidos en SQL Server.
    /// </summary>
    public class CategoriaRepository
    {
        /// <summary>
        /// Obtiene todas las categorías registradas
        /// en la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos Categoria.
        /// </returns>
        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Listar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    IdCategoria = Convert.ToInt32(
                        reader["id_categoria"]
                    ),

                    Nombre =
                        reader["nombre"].ToString()
                        ?? string.Empty
                });
            }

            return categorias;
        }

        /// <summary>
        /// Obtiene una categoría específica mediante
        /// su identificador.
        /// </summary>
        /// <param name="idCategoria">
        /// Identificador de la categoría que se desea consultar.
        /// </param>
        /// <returns>
        /// Objeto Categoria si el registro existe;
        /// de lo contrario, null.
        /// </returns>
        public Categoria? ObtenerPorId(int idCategoria)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_ObtenerPorId",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = idCategoria;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return new Categoria
            {
                IdCategoria = Convert.ToInt32(
                    reader["id_categoria"]
                ),

                Nombre =
                    reader["nombre"].ToString()
                    ?? string.Empty
            };
        }

        /// <summary>
        /// Registra una nueva categoría en la base de datos.
        /// </summary>
        /// <param name="categoria">
        /// Categoría que se desea registrar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza la operación.
        /// Se utiliza para registrar la acción en la bitácora.
        /// </param>
        public void Crear(
            Categoria categoria,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Insertar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                50
            ).Value = categoria.Nombre;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Actualiza la información de una categoría existente.
        /// </summary>
        /// <param name="categoria">
        /// Categoría con los datos modificados.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que realiza la operación.
        /// </param>
        public void Actualizar(
            Categoria categoria,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Actualizar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = categoria.IdCategoria;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                50
            ).Value = categoria.Nombre;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Elimina una categoría de la base de datos.
        /// </summary>
        /// <param name="idCategoria">
        /// Identificador de la categoría que se desea eliminar.
        /// </param>
        /// <param name="idUsuario">
        /// Identificador del usuario que ejecuta la operación.
        /// </param>
        public void Eliminar(
            int idCategoria,
            int idUsuario)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Eliminar",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = idCategoria;

            command.Parameters.Add(
                "@id_usuario",
                SqlDbType.Int
            ).Value = idUsuario;

            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}