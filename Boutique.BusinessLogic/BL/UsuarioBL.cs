using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class UsuarioBL
    {

        private static UsuarioBL _instance;

        public static UsuarioBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UsuarioBL();
                }

                return _instance;
            }
        }

        public bool Insert(Usuario entity)
        {
            bool result = false;

            try
            {
                result = UsuarioDAL.Instance.Insert(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }
        public bool Existe(string dui)
        {
            return UsuarioDAL.Instance.ObtenerPorDUI(dui) != null;
        }
        public bool Update(Usuario entity)
        {
            bool result = false;

            try
            {
                result = UsuarioDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool Delete(string DUI)
        {
            bool result = false;

            try
            {
                result = UsuarioDAL.Instance.Delete(DUI); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Usuario> SelecAll()
        {
            List<Usuario> result = null;

            try
            {
                result = UsuarioDAL.Instance.SelecAll(); // llama a la clase 
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
