using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Boutique.DataAcces.DAL
{
    public class EmpleadoDAL : Conection
    {


        private static EmpleadoDAL _instance;

        public static EmpleadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpleadoDAL();
                }

                return _instance;
            }
        }


        public bool Insert(Empleado entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpleadoInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", entity.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion); 
                    cmd.Parameters.AddWithValue("@FechaContratacion", entity.FechaContratacion);
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }


        public bool Update(Empleado entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpleadoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@Nombres", entity.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", entity.Apellidos);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", entity.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Correo", entity.Correo);
                    cmd.Parameters.AddWithValue("@Codigo", entity.Codigo);
                    cmd.Parameters.AddWithValue("@Direccion", entity.Direccion);
                    cmd.Parameters.AddWithValue("@FechaContratacion", entity.FechaContratacion);
                    cmd.Parameters.AddWithValue("@CargoId", entity.CargoId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }
        public List<Empleado> SelecAll()
        {
            List<Empleado> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpleadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Empleado>();
                            while (dr.Read())
                            {
                                Empleado entity = new Empleado();
                                entity.EmpleadoId = dr.GetInt32(0);
                                entity.Nombres = dr.GetString(1);
                                entity.Apellidos = dr.GetString(2);
                                entity.FechaNacimiento = dr.GetDateTime(3);
                                entity.DUI = dr.GetString(4);
                                entity.Telefono = dr.GetString(5);
                                entity.Correo = dr.GetString(6);
                                entity.Codigo = dr.GetString(7);
                                entity.Direccion = dr.GetString(8); 
                                entity.FechaContratacion = dr.GetDateTime(9);
                                entity.CargoId = dr.GetString(10);
                                entity.EstadoId = dr.GetString(11);

                                result.Add(entity);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpleadoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", id);

                    conn.Open();

                    result = cmd.ExecuteNonQuery() > 0;


                }
            }

            return result;
        }

     
        public bool SelectName(string Nombre)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpEmpleadoSelectName", conn))
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
