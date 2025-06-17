using System;
using System.Collections.Generic;
using Boutique.Entity.Entidades;
using Boutique.DataAcces.DAL;
namespace Boutique.BusinessLogic.BL
{
    public  class CargoBL
    { 
        private static CargoBL _instance;

        public static CargoBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CargoBL();
                }

                return _instance;
            }
        }

        public bool Insert(Cargo entity)
        {
            bool result = false;

            try
            {
                result = CargoDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Cargo entity)
        {
            bool result = false;

            try
            {
                result = CargoDAL.Instance.Update(entity); // llama a la clase 
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
                result = CargoDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Cargo> SelecAll()
        {
            List<Cargo> result = null;

            try
            {
                result = CargoDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
            return result;
        }



    }
}
