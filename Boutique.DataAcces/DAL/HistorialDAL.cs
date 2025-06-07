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
    public class HistorialDAL :Conection
    {
        private static HistorialDAL _instance;

        public static HistorialDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HistorialDAL();
                }

                return _instance;
            }
        }

        public bool Insert(Historial entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpHistorialInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", entity.Fecha);
                    cmd.Parameters.AddWithValue("@Evento", entity.Evento);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.DUI);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;

                }
            }

            return result;

        }

     

        public List<Historial> SelecAll()
        {
            List<Historial> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("Controlsistema.SpHistorialSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Historial>();
                            while (dr.Read())
                            {
                                Historial entity = new Historial();
                                entity.EventoId = dr.GetInt32(0);
                                entity.Fecha = dr.GetDateTime(1);
                                entity.Evento = dr.GetString(2);
                                entity.DUI = dr.GetString(3);

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
