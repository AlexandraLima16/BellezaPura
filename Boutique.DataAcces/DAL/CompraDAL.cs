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

        public bool Insert(Compra entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpCompraInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@PagoId", entity.PagoId);
                    cmd.Parameters.AddWithValue("@ProveedoresId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.DUI);
                    cmd.Parameters.AddWithValue("@TotalCompra", entity.TotalCompra);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }

        public bool Update(Compra entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpCompraUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CompraId", entity.CompraId);
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    cmd.Parameters.AddWithValue("@PagoId", entity.PagoId);
                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@PagoId", entity.PagoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }
            return result;
        }

        public bool Delete(int CompraId)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpCompraDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompraId", CompraId);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


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
                                entity.EstadoId = dr.GetInt32(2);
                                entity.PagoId = dr.GetInt32(3);
                                entity.ProveedorId = dr.GetInt32(4);
                                entity.DUI = dr.GetString(5);
                                entity.TotalCompra = dr.GetDecimal(6);

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
