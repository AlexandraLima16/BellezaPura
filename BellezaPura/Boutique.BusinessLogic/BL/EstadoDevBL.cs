using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class EstadoDevBL
    {
        private static EstadoDevBL _instance;

        public static EstadoDevBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EstadoDevBL();
                }

                return _instance;
            }
        }

        public bool Insert(EstadoDev entity)
        {
            bool result = false;

            try
            {
                result = EstadoDevDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(EstadoDev entity)
        {
            bool result = false;

            try
            {
                result = EstadoDevDAL.Instance.Update(entity); // llama a la clase 
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
        //        result = EstadoDevDAL.Instance.Delete(id); // llama a la clase 
        //    }
        //    catch (Exception ex)
        //    {
        //        //Errores con store 
        //        throw new Exception(ex.Message);
        //    }
        //    return result;
        //}

        public List<EstadoDev> SelecAll()
        {
            List<EstadoDev> result = null;

            try
            {
                result = EstadoDevDAL.Instance.SelecAll(); // llama a la clase 
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
