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
    public class RolDAL : Conection
    {
        private static RolDAL _instance;

        public static RolDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RolDAL();
                }

                return _instance;
            }
        }
        public bool Insert(Rol entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpRolInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreRol", entity.NombreRol);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(Rol entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpRolUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@NombreRol", entity.NombreRol);
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
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpRolDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", id);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Rol> SelecAll()
        {
            List<Rol> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpRolSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Rol>();
                            while (dr.Read())
                            {
                                Rol entity = new Rol();
                                entity.RolId = dr.GetInt32(0);
                                entity.NombreRol = dr.GetString(1);
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
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpRolSelectName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreRol", Nombre);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }


    }
}
