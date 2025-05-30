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
    public class DetVentaDAL: Conection
    {

        private static DetVentaDAL _instance;

        public static DetVentaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetVentaDAL();
                }

                return _instance;
            }
        }

        public bool Insert(DetVenta entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand(" Ventas.SpDetventaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", entity.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(DetVenta entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpDetventaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DetVentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@SubTotal", entity.SubTotal);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", entity.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@VentaId", entity.VentaId);
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

       

        public List<DetVenta> SelecAll()
        {
            List<DetVenta> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpDetventaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<DetVenta>();
                            while (dr.Read())
                            {
                                DetVenta entity = new DetVenta();
                                entity.DetVentaId = dr.GetInt32(0);
                                entity.Cantidad = dr.GetInt32(1);
                                entity.SubTotal = dr.GetInt32(2);
                                entity.Descripcion = dr.GetString(3);
                                entity.PrecioUnitario = dr.GetDecimal(4);
                                entity.VentaId = dr.GetInt32(5);
                                entity.ProductoId = dr.GetInt32(6);
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
