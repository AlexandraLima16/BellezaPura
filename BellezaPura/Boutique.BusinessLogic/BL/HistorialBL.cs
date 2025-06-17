using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class HistorialBL
    {

        private static HistorialBL _instance;

        public static HistorialBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HistorialBL();
                }

                return _instance;
            }
        }

        public bool Insert(Historial entity)
        {
            bool result = false;

            try
            {
                result = HistorialDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

     

        public List<Historial> SelecAll()
        {
            List<Historial> result = null;

            try
            {
                result = HistorialDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }



        public List<Historial> ObtenerPorFecha(DateTime fecha)
        {
            List<Historial> result = null;

            try
            {
                result = HistorialDAL.Instance.ObtenerPorFecha(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
