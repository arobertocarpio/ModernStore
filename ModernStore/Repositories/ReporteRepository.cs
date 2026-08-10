using Microsoft.Data.SqlClient;
using ModernStore.Data;
using ModernStore.Models;
using System.Data;

namespace ModernStore.Repositories
{
    /// <summary>
    /// Repositorio encargado de obtener la información
    /// utilizada para generar los reportes de ventas.
    ///
    /// Las consultas se realizan mediante procedimientos
    /// almacenados definidos en SQL Server.
    /// </summary>
    public class ReporteRepository
    {
        /// <summary>
        /// Obtiene el resumen de ventas correspondiente
        /// a una semana a partir de una fecha inicial.
        /// </summary>
        /// <param name="fechaInicio">
        /// Fecha desde la cual se realizará la consulta
        /// del reporte semanal.
        /// </param>
        /// <returns>
        /// Lista de registros que contiene la fecha,
        /// cantidad de ventas y total vendido por día.
        /// </returns>
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