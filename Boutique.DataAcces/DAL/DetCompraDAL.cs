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
    public class DetCompraDAL : Conection
    {
        private static DetCompraDAL _instance;

        public static DetCompraDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetCompraDAL();
                }

                return _instance;
            }
        }


        public bool Insert(DetCompra entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpDetCompraInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubTotal", entity.Subtotal);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                    cmd.Parameters.AddWithValue("@CompraId", entity.CompraId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }
        public bool Update(DetCompra entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpDetCompraUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DetCompraId", entity.DetCompraId);
                    cmd.Parameters.AddWithValue("@CompraId", entity.CompraId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Subtotal", entity.Subtotal);
                    cmd.Parameters.AddWithValue("@Subtotal", entity.Subtotal);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }


        public List<DetCompra> SelecAll()
        {
            List<DetCompra> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Compra.SpDetCompraSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<DetCompra>();
                            while (dr.Read())
                            {
                                DetCompra entity = new DetCompra();
                                entity.DetCompraId = dr.GetInt32(0);
                                entity.Subtotal = dr.GetInt32(1);
                                entity.Cantidad = dr.GetInt32(2);
                                entity.Precio = dr.GetInt32(3);
                                entity.CompraId = dr.GetInt32(4);
                                entity.ProductoId = dr.GetInt32(5);

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
