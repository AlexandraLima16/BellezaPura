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
    public class DevolucionDAL : Conection
    {



        private static DevolucionDAL _instance;
        public static DevolucionDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DevolucionDAL();
                }
                return _instance;
            }
        }



        public bool Insert(Devolucion entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpDevolucionInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaDevolucion", entity.FechaDevolucion);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                    cmd.Parameters.AddWithValue("@DetVentaId", entity.DetVentaId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(Devolucion entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpDevolucionUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DevolcionId", entity.DevolucionId);
                    cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                    cmd.Parameters.AddWithValue("@FechaDevolucion", entity.FechaDevolucion);
                    cmd.Parameters.AddWithValue("@Cantidad", entity.Cantidad);
                    cmd.Parameters.AddWithValue("@Precio", entity.Precio);
                    cmd.Parameters.AddWithValue("@DetVentaId", entity.DetVentaId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        //no tiene delete
        public bool Delete(int DevolucionId)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DevolucionId", DevolucionId);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Devolucion> SelecAll()
        {
            List<Devolucion> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpDevolucionSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Devolucion>();
                            while (dr.Read())
                            {
                                Devolucion entity = new Devolucion();
                                entity.DevolucionId = dr.GetInt32(0);
                                entity.Descripcion = dr.GetString(1);
                                entity.FechaDevolucion = dr.GetDateTime(2);
                                entity.Cantidad = dr.GetInt32(3);
                                entity.Precio = dr.GetDecimal(4);
                                entity.DetVentaId = dr.GetInt32(5);

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
