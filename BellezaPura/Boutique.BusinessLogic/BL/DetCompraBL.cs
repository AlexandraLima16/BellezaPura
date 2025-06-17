using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class DetCompraBL
    {
        private static DetCompraDAL _instance;

        public static DetCompraDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetCompraDAL();
                }

                return _instance;
            }
        }

        public bool Insert(DetCompra entity)
        {
            bool result = false;

            try
            {
                result = DetCompraDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(DetCompra entity)
        {
            bool result = false;

            try
            {
                result = DetCompraDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }


        public List<DetCompra> SelecAll()
        {
            List<DetCompra> result = null;

            try
            {
                result = DetCompraDAL.Instance.SelecAll(); // llama a la clase 
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
