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
    public  class EstadoDevDAL : Conection
    {

        private static EstadoDevDAL _instance;

        public static EstadoDevDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EstadoDevDAL();
                }

                return _instance;
            }
        }
        public bool Insert(EstadoDev estado)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpEstadoDevInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreEstadoDev", estado.NombreEstadoDev);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(EstadoDev estado)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpEstadoDevUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EstadoDevId", estado.EstadoDevId);
                    cmd.Parameters.AddWithValue("@NombreEstadoDev", estado.NombreEstadoDev);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }


        public List<EstadoDev> SelecAll()
        {
            List<EstadoDev> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpEstadoDevSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<EstadoDev>();
                            while (dr.Read())
                            {
                                EstadoDev entity = new EstadoDev();
                                entity.EstadoDevId = dr.GetInt32(0);
                                entity.NombreEstadoDev = dr.GetString(1);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }


        public bool SelectName(string NombreEstadoDev)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpEstadoDevSelectName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreEstadoDev", NombreEstadoDev);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
