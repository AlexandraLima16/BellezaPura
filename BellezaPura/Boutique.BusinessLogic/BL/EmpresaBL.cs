using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class EmpresaBL
    {
        private static EmpresaDAL _instance;

        public static EmpresaDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpresaDAL();
                }

                return _instance;
            }
        }

      

        public bool Update(Empresa entity)
        {
            bool result = false;

            try
            {
                result = EmpresaDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

    

        public List<Empresa> SelecAll()
        {
            List<Empresa> result = null;

            try
            {
                result = EmpresaDAL.Instance.SelecAll(); // llama a la clase 
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
