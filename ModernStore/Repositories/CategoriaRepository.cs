using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class CategoriaRepository
    {
        public List<Categoria> Listar()
        {
            var categorias = new List<Categoria>();

            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Listar",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    IdCategoria = Convert.ToInt32(
                        reader["id_categoria"]
                    ),

                    Nombre =
                        reader["nombre"].ToString() ?? string.Empty
                });
            }

            return categorias;
        }

        public Categoria? ObtenerPorId(int idCategoria)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_ObtenerPorId",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = idCategoria;

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

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
                    reader["nombre"].ToString() ?? string.Empty
            };
        }

        public void Crear(Categoria categoria)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Crear",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                100
            ).Value = categoria.Nombre;

            command.Parameters.Add(
                "@descripcion",
                SqlDbType.VarChar,
                255
            ).Value = string.IsNullOrWhiteSpace(categoria.Descripcion)
                ? DBNull.Value
                : categoria.Descripcion;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Actualizar(Categoria categoria)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Actualizar",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = categoria.IdCategoria;

            command.Parameters.Add(
                "@nombre",
                SqlDbType.VarChar,
                100
            ).Value = categoria.Nombre;

            command.Parameters.Add(
                "@descripcion",
                SqlDbType.VarChar,
                255
            ).Value = string.IsNullOrWhiteSpace(categoria.Descripcion)
                ? DBNull.Value
                : categoria.Descripcion;

            connection.Open();

            command.ExecuteNonQuery();
        }

        public void Eliminar(int idCategoria)
        {
            using SqlConnection connection = Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Categoria_Eliminar",
                connection
            );

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(
                "@id_categoria",
                SqlDbType.Int
            ).Value = idCategoria;

            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}