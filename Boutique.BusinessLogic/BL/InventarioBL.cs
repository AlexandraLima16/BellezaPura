using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class InventarioBL
    {

        private static InventarioBL _instance;

        public static InventarioBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventarioBL();
                }

                return _instance;
            }
        }

        public bool Insert(Inventario entity)
        {
            bool result = false;

            try
            {
                result = InventarioDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Inventario entity)
        {
            bool result = false;

            try
            {
                result = InventarioDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Inventario> SelecAll()
        {
            List<Inventario> result = null;

            try
            {
                result = InventarioDAL.Instance.SelecAll(); // llama a la clase 
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
