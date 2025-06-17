using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class DevolucionBL
    {
        private static DevolucionDAL _instance;

        public static DevolucionDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DevolucionDAL();
                }

                return _instance;
            }
        }

        public bool Insert(Devolucion entity)
        {
            bool result = false;

            try
            {
                result = DevolucionDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Devolucion entity)
        {
            bool result = false;

            try
            {
                result = DevolucionDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                result = DevolucionDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Devolucion> SelecAll()
        {
            List<Devolucion> result = null;

            try
            {
                result = DevolucionDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

    }
}
