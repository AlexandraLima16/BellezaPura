using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace Boutique.DataAcces.DAL
{
    public  class EstadoDAL: Conection
    {

        private static EstadoDAL _instance;

        public static EstadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EstadoDAL();
                }

                return _instance;
            }
        }



        public bool Insert(Estado estado)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using(SqlCommand cmd = new SqlCommand("Controlsistema.SpEstadoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreEstado", estado.NombreEstado);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(Estado estado) 
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using(SqlCommand cmd = new SqlCommand("Controlsistema.SpEstadoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EstadoId", estado.EstadoId);
                    cmd.Parameters.AddWithValue("@NombreEstado", estado.NombreEstado);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Estado> SelecAll()
        {
            List<Estado> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEstadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Estado>();
                            while (dr.Read())
                            {
                                Estado entity = new Estado();
                                entity.EstadoId = dr.GetInt32(0);
                                entity.NombreEstado = dr.GetString(1);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }


        public bool SelectName(string NombreEstado)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEstadoSelectName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreEstado", NombreEstado);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }


}

