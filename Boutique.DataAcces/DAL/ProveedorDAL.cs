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
    public class ProveedorDAL : Conection
    {
        private static ProveedorDAL _instance;

        public static ProveedorDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProveedorDAL();
                }

                return _instance;
            }
        }


        public bool Insert(Proveedor entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpProveedorInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Encargo", entity.Encargo);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@ContactoPrincipal", entity.ContactoPrincipal);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(Proveedor entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpProveedorUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProveedorId", entity.ProveedorId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Encargo", entity.Encargo);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@ContactoPrincipal", entity.ContactoPrincipal);
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
                using (SqlCommand cmd = new SqlCommand("Ventas.SpProveedorDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProveedorId", id);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Proveedor> SelecAll()
        {
            List<Proveedor> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpProveedorSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Proveedor>();
                            while (dr.Read())
                            {
                                Proveedor entity = new Proveedor();
                                entity.ProveedorId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                entity.Encargo = dr.GetString(2);
                                entity.Telefono = dr.GetString(3);
                                entity.Correo = dr.GetString(4);
                                entity.Direccion = dr.GetString(5);
                                entity.ContactoPrincipal = dr.GetString(6);
                                entity.EstadoId = dr.GetInt32(7);
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
                using (SqlCommand cmd = new SqlCommand("Ventas.SpProveedorSelectName", conn))
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
