using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class EstadoBL
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

        public bool Insert(Estado entity)
        {
            bool result = false;

            try
            {
                result = EstadoDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Estado entity)
        {
            bool result = false;

            try
            {
                result = EstadoDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        //public bool Delete(int id)
        //{
        //    bool result = false;

        //    try
        //    {
        //        result = EstadoDAL.Instance.Delete(id); // llama a la clase 
        //    }
        //    catch (Exception ex)
        //    {
        //        //Errores con store 
        //        throw new Exception(ex.Message);
        //    }
        //    return result;
        //}

        public List<Estado> SelecAll()
        {
            List<Estado> result = null;

            try
            {
                result = EstadoDAL.Instance.SelecAll(); // llama a la clase 
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
