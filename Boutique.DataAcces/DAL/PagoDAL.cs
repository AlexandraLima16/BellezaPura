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
    public class PagoDAL: Conection
    {

        private static PagoDAL _instance;

        public static PagoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PagoDAL();
                }

                return _instance;
            }
        }


        public bool Insert(Pago entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpPagoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoPago", entity.TipoPago);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }
        public bool Update(Pago entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpPagoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PagoId", entity.PagoId);
                    cmd.Parameters.AddWithValue("@TipoPago", entity.TipoPago);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpPagoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PagoId", id);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Pago> SelecAll()
        {
            List<Pago> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpPagoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Pago>();
                            while (dr.Read())
                            {
                                Pago entity = new Pago();
                                entity.PagoId = dr.GetInt32(0);
                                entity.TipoPago = dr.GetString(1);
                                entity.EstadoId = dr.GetInt32(2);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }
        public bool SelectName(string Nombre)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpPagoSelectName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
