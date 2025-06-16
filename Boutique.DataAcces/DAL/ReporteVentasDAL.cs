using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.DataAcces.DAL
{
    public class ReporteVentasDAL : Conection
    {
        private static ReporteVentasDAL _instance;
        public static ReporteVentasDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReporteVentasDAL();
                return _instance;
            }
        }

        public List<ReportVentas> SelecAll()
        {
            List<ReportVentas> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpReporteVentasSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<ReportVentas>();
                            while (dr.Read())
                            {
                                ReportVentas entity = new ReportVentas();

                                entity.VentaId = dr.GetInt32(0);
                                entity.Producto = dr.GetString(1);
                                entity.Fecha = dr.GetDateTime(2);
                                entity.Cantidad = dr.GetInt32(3);
                                entity.Total = dr.GetDecimal(4);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<ReportVentas> ObtenerPorFecha(DateTime fecha)
        {
            List<ReportVentas> lista = new List<ReportVentas>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("Ventas.SpReportVentasSelectByFecha", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ReportVentas h = new ReportVentas()
                    {
                        VentaId = Convert.ToInt32(reader["VentaId"]),
                        Producto =reader["Producto"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        Total = Convert.ToInt32(reader["Total"]),

                    };

                    lista.Add(h);
                }

                reader.Close();
            }

            return lista;
        }
    }
    }


