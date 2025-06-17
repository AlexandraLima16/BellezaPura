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
    public class VentaDAL: Conection
    {

        private static VentaDAL _instance;

        public static VentaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VentaDAL();
                }

                return _instance;
            }
        }

        public int Insert(Venta entity)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpVentaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Total", entity.Total);
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }

            return result;

        }


        public bool Update(Venta entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpVentaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@Total", entity.Total);
                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }


        public List<Venta> SelecAll()
        {
            List<Venta> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpVentaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Venta>();
                            while (dr.Read())
                            {
                                Venta entity = new Venta();
                                entity.VentaId = dr.GetInt32(0);
                                entity.Fecha = dr.GetDateTime(1);
                                entity.ClienteId = dr.GetInt32(2);
                                entity.DUI = dr.GetString(3);
                                entity.Total = dr.GetDecimal(4);
                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }
     
    }
}
