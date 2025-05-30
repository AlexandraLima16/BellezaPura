using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public  class EmpleadoBL
    {
        private static EmpleadoDAL _instance;

        public static EmpleadoDAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmpleadoDAL();
                }

                return _instance;
            }
        }

        public bool Insert(Empleado entity)
        {
            bool result = false;

            try
            {
                result = EmpleadoDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Empleado entity)
        {
            bool result = false;

            try
            {
                result = EmpleadoDAL.Instance.Update(entity); // llama a la clase 
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
                result = EmpleadoDAL.Instance.Delete(id); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Empleado> SelecAll()
        {
            List<Empleado> result = null;

            try
            {
                result = EmpleadoDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}

        

