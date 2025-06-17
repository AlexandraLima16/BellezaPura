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
    public class ClienteDAL: Conection
    {
        private static ClienteDAL _instance;

        public static ClienteDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClienteDAL();
                }

                return _instance;
            }
        }
        public bool Insert(Cliente entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpClienteInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Genero", entity.Genero);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(Cliente entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpClienteUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClienteId", entity.ClienteId);
                    cmd.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    cmd.Parameters.AddWithValue("@Genero", entity.Genero);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }
        //Cliente no tiene delete 
        public bool Delete(int ClienteId)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("SpDeleteCargo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteId", ClienteId);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

        public List<Cliente> SelecAll()
        {
            List<Cliente> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Ventas.SpClienteSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Cliente>();
                            while (dr.Read())
                            {
                                Cliente entity = new Cliente();
                                entity.ClienteId = dr.GetInt32(0);
                                entity.Nombres = dr.GetString(1);
                                entity.Apellidos = dr.GetString(2);
                                entity.Direccion = dr.GetString(3);
                                entity.Correo = dr.GetString(4);
                                entity.DUI = dr.GetString(5);
                                entity.Genero = dr.GetString(6);    
                                entity.Telefono = dr.GetString(7);

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
            using (SqlConnection conn = new SqlConnection(""))
            {
                using (SqlCommand cmd = new SqlCommand("SpProductoSelectName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Producto", NombreEstado);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

    }
}
