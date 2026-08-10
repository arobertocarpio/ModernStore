using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de consultar
    /// la información del corte de caja diario.
    /// </summary>
    public class CorteCajaRepository
    {
        public CorteCaja? ObtenerCorte(
            DateTime fecha)
        {
            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Reporte_CorteCajaDiario",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@fecha",
                SqlDbType.Date
            ).Value = fecha.Date;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            return new CorteCaja
            {
                FechaCorte =
                    Convert.ToDateTime(
                        reader["fecha_corte"]
                    ),

                CantidadVentas =
                    Convert.ToInt32(
                        reader["cantidad_ventas"]
                    ),

                TotalEfectivo =
                    Convert.ToDecimal(
                        reader["total_efectivo"]
                    )
            };
        }

        public List<DetalleCorteCaja> ObtenerDetalle(
            DateTime fecha)
        {
            var detalles =
                new List<DetalleCorteCaja>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Reporte_DetalleCorteDiario",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@fecha",
                SqlDbType.Date
            ).Value = fecha.Date;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                detalles.Add(
                    new DetalleCorteCaja
                    {
                        IdVenta =
                            Convert.ToInt32(
                                reader["id_venta"]
                            ),

                        FechaVenta =
                            Convert.ToDateTime(
                                reader["fecha_venta"]
                            ),

                        Cliente =
                            reader["cliente"].ToString()
                            ?? string.Empty,

                        Usuario =
                            reader["usuario"].ToString()
                            ?? string.Empty,

                        Total =
                            Convert.ToDecimal(
                                reader["total"]
                            )
                    }
                );
            }

            return detalles;
        }
    }
}