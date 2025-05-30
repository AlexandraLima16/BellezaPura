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
    public class UsuarioDAL:Conection
    {
        private static UsuarioDAL _instance;

        public static UsuarioDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioDAL();
                }

                return _instance;
            }
        }

        public bool Insert(Usuario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpUsuarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@FechaRegistro", entity.FechaRegistro);
                    cmd.Parameters.AddWithValue("@Contrasena", entity.Contrasena);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }
        public Usuario ObtenerPorDUI(string dui)
        {
            Usuario user = null;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_Usuario_ObtenerPorDUI", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DUI", dui);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new Usuario
                    {
                        DUI = reader["DUI"].ToString(),
                        Nombre = reader["Nombre"].ToString(),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        Contrasena = reader["Contrasena"].ToString(),
                        EstadoId = Convert.ToInt32(reader["EstadoId"]),
                        EmpleadoId = Convert.ToInt32(reader["EmpleadoId"]),
                        RolId = Convert.ToInt32(reader["RolId"])
                    };
                }
            }
            return user;
        }


        public bool Update(Usuario entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpUsuarioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@FechaRegistro", entity.FechaRegistro);
                    cmd.Parameters.AddWithValue("@Contrasena", entity.Contrasena);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public bool Delete(string DUI)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpUsuarioDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DUI", DUI);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Usuario> SelecAll()
        {
            List<Usuario> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpUsuarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Usuario>();
                            while (dr.Read())
                            {
                                Usuario entity = new Usuario();
                                entity.DUI = dr.GetString(0);
                                entity.Nombre = dr.GetString(1);
                                entity.FechaRegistro =  dr.GetDateTime(2);
                                entity.Contrasena = dr.GetString(3);
                                entity.EstadoId = dr.GetInt32(4);
                                entity.EmpleadoId = dr.GetInt32(5);
                                entity.RolId = dr.GetInt32(6);                     

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
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpUsuarioSelectName", conn))
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
