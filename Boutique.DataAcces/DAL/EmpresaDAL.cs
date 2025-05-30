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
    public class EmpresaDAL: Conection
    {
        private static EmpresaDAL _instance;

        public static EmpresaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpresaDAL();
                }

                return _instance;
            }
        }


        public bool Insert(Empresa entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpresaInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpresaId", entity.  EmpresaId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@NIT", entity.NIT);
                    cmd.Parameters.AddWithValue("@NRC", entity.NRC);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }
        public bool Update(Empresa entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpresaUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpresaId", entity.EmpresaId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@NIT", entity.NIT);
                    cmd.Parameters.AddWithValue("@NRC", entity.NRC);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Empresa> SelecAll()
        {
            List<Empresa> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpresaSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Empresa>();
                            while (dr.Read())
                            {
                                Empresa entity = new Empresa();
                                entity.EmpresaId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                entity.Telefono = dr.GetString(2);
                                entity.Direccion = dr.GetString(3);
                                entity.Correo = dr.GetString(4);
                                entity.NIT = dr.GetString(5);
                                entity.NRC  = dr.GetString(6);

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
