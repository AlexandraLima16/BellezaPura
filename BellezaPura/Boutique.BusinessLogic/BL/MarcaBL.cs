using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class MarcaBL
    {
        private static MarcaBL _instance;

        public static MarcaBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MarcaBL();
                }

                return _instance;
            }
        }

        public bool Insert(Marca entity)
        {
            bool result = false;

            try
            {
                result = MarcaDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Marca entity)
        {
            bool result = false;

            try
            {
                result = MarcaDAL.Instance.Update(entity); // llama a la clase 
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
                result = MarcaDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Marca> SelecAll()
        {
            List<Marca> result = null;

            try
            {
                result = MarcaDAL.Instance.SelecAll(); // llama a la clase 
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
