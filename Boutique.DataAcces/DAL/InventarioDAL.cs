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
    public class InventarioDAL : Conection
    {
        private static InventarioDAL _instance;

        public static InventarioDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventarioDAL();
                }

                return _instance;
            }
        }
        //Cuando se agrega un nuevo producto
        public bool Insert(int Id)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpInventarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", Id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }

        //Cuando hay una venta

        public bool InsertVenta(int Id, int Cantidad)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpInventarioVenta", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", Id);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }
        //Cuando hay una Compra

        public bool InsertCompra(int Id, int Cantidad)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpInventarioCompra", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", Id);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }




        public bool Update(Inventario entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpInventarioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductoId", entity.ProductoId);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

       

        public List<Inventario> SelecAll()
        {
            List<Inventario> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpInventarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Inventario>();
                            while (dr.Read())
                            {
                                Inventario entity = new Inventario();
                                entity.ProductoId = dr.GetInt32(0);
                                entity.Cantidad = dr.GetInt32(1);

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
