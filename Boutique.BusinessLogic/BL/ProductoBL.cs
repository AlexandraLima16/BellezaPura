using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class ProductoBL
    { 

        private static ProductoBL _instance;

        public static ProductoBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductoBL();
                }

                return _instance;
            }
        }

        public bool Insert(Producto entity)
        {
            bool result = false;

            try
            {
                result = ProductoDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Producto entity)
        {
            bool result = false;

            try
            {
                result = ProductoDAL.Instance.Update(entity); // llama a la clase 
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
                result = ProductoDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Producto> SelecAll()
        {
            List<Producto> result = null;

            try
            {
                result = ProductoDAL.Instance.SelecAll(); // llama a la clase 
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
