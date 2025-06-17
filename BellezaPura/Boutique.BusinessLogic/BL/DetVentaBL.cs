using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class DetVentaBL
    {
        private static DetVentaDAL _instance;

        public static DetVentaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DetVentaDAL();
                }

                return _instance;
            }
        }

        public bool Insert(DetVenta entity)
        {
            bool result = false;

            try
            {
                result = DetVentaDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(DetVenta entity)
        {
            bool result = false;

            try
            {
                result = DetVentaDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        

        public List<DetVenta> SelecAll()
        {
            List<DetVenta> result = null;

            try
            {
                result = DetVentaDAL.Instance.SelecAll(); // llama a la clase 
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
