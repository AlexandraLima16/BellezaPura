using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class CompraBL
    {
        private static CompraBL _instance;

        public static CompraBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompraBL();
                }

                return _instance;
            }
        }

        public bool Insert(Compra entity)
        {
            bool result = false;

            try
            {
                result = CompraDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Compra entity)
        {
            bool result = false;

            try
            {
                result = CompraDAL.Instance.Update(entity); // llama a la clase 
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
                result = CompraDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Compra> SelecAll()
        {
            List<Compra> result = null;

            try
            {
                result = CompraDAL.Instance.SelecAll(); // llama a la clase 
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
