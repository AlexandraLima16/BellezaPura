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

        public int Insert(Compra entity, List<DetCompra> detalles)
        {
            int result = -1;

            try
            {
                result = CompraDAL.Instance.Insert(entity); // llama a la clase 
                foreach (DetCompra item in detalles)
                {
                    item.CompraId = result;
                    DetCompraBL.Instance.Insert(item);
                    InventarioBL.Instance.InsertCompra(item.ProductoId, item.Cantidad);

                }
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
