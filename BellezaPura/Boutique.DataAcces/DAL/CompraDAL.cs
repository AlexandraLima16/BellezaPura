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
    public class CompraDAL: Conection
    {
        private static CompraDAL _instance;

        public static CompraDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompraDAL();
                }

                return _instance;
            }
        }

        public int Insert(Compra entity)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpCompraInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@TotalCompra", entity.TotalCompra);

                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }

            return result;

        }

        

        public List<Compra> SelecAll()
        {
            List<Compra> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpCompraSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Compra>();
                            while (dr.Read())
                            {
                                Compra entity = new Compra();
                                entity.CompraId = dr.GetInt32(0);
                                entity.Fecha = dr.GetDateTime(1);
                                entity.DUI = dr.GetString(2);
                                entity.TotalCompra = dr.GetDecimal(3);

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
