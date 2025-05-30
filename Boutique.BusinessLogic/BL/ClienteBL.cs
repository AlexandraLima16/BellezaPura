using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class ClienteBL
    {
        private static ClienteBL _instance;

        public static ClienteBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ClienteBL();
                }

                return _instance;
            }
        }

        public bool Insert(Cliente entity)
        {
            bool result = false;

            try
            {
                result = ClienteDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Cliente entity)
        {
            bool result = false;

            try
            {
                result = ClienteDAL.Instance.Update(entity); // llama a la clase 
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
                result = ClienteDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Cliente> SelecAll()
        {
            List<Cliente> result = null;

            try
            {
                result = ClienteDAL.Instance.SelecAll(); // llama a la clase 
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
