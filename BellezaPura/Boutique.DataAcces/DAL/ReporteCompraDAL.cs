using System;
using Boutique.Entity.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Boutique.DataAcces.DAL
{
    public class ReporteCompraDAL : Conection
    {
        private static ReporteCompraDAL _instance;

        public static ReporteCompraDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReporteCompraDAL();
                return _instance;


            }
        }
        public List<ReportCompra> SelecAll()
        {
            List<ReportCompra> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpReporteCompraSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<ReportCompra>();
                            while (dr.Read())
                            {
                                ReportCompra entity = new ReportCompra();

                                entity.CompraId = dr.GetInt32(0);
                                entity.ProductoId = dr.GetString(1);
                                entity.Fecha = dr.GetDateTime(2);
                                entity.Cantidad = dr.GetInt32(3);
                                entity.TotalCompra = dr.GetDecimal(4);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public List<ReportCompra> ObtenerPorFecha(DateTime fecha)
        {
            List<ReportCompra> lista = new List<ReportCompra>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("Compra.SpReporteCompraPorFecha", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ReportCompra h = new ReportCompra()
                    {
                        CompraId = Convert.ToInt32(reader["CompraId"]),
                        ProductoId = reader["Producto"].ToString(),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        TotalCompra = Convert.ToInt32(reader["TotalCompra"]),

                    };

                    lista.Add(h);
                }

                reader.Close();
            }

            return lista;
        }
    }

}