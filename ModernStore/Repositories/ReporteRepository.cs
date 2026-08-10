using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    public class ReporteRepository
    {
        public List<ReporteVentaSemanal> ObtenerVentasSemanales(
            DateTime fechaInicio)
        {
            var reporte =
                new List<ReporteVentaSemanal>();

            using SqlConnection connection =
                Database.GetConnection();

            using SqlCommand command = new SqlCommand(
                "sp_Reporte_VentasSemanales",
                connection
            );

            command.CommandType =
                CommandType.StoredProcedure;

            command.Parameters.Add(
                "@fecha_inicio",
                SqlDbType.Date
            ).Value = fechaInicio.Date;

            connection.Open();

            using SqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                reporte.Add(
                    new ReporteVentaSemanal
                    {
                        Fecha =
                            Convert.ToDateTime(
                                reader["fecha"]
                            ),

                        CantidadVentas =
                            Convert.ToInt32(
                                reader["cantidad_ventas"]
                            ),

                        TotalVendido =
                            Convert.ToDecimal(
                                reader["total_vendido"]
                            )
                    }
                );
            }

            return reporte;
        }
    }
}