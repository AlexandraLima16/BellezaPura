using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class RolBL
    {

        private static RolBL _instance;

        public static RolBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RolBL();
                }

                return _instance;
            }
        }

        public bool Insert(Rol entity)
        {
            bool result = false;

            try
            {
                result = RolDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Rol entity)
        {
            bool result = false;

            try
            {
                result = RolDAL.Instance.Update(entity); // llama a la clase 
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
                result = RolDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Rol> SelecAll()
        {
            List<Rol> result = null;

            try
            {
                result = RolDAL.Instance.SelecAll(); // llama a la clase 
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
