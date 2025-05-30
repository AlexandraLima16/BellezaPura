using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class CategoriaBL
    {
        private static CategoriaBL _instance;

        public static CategoriaBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoriaBL();
                }

                return _instance;
            }
        }

        public bool Insert(Categoria entity)
        {
            bool result = false;

            try
            {
                result = CategoriaDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Categoria entity)
        {
            bool result = false;

            try
            {
                result = CategoriaDAL.Instance.Update(entity); // llama a la clase 
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
                result = CategoriaDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Categoria> SelecAll()
        {
            List<Categoria> result = null;

            try
            {
                result = CategoriaDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
