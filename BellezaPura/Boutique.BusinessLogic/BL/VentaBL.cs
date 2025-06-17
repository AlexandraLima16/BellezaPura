using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class VentaBL
    {
        private static VentaBL _instance;

        public static VentaBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VentaBL();
                }

                return _instance;
            }
        }

        public int Insert(Venta entity, List< DetVenta> detalle)
        {
            int result = -1;

            try
            {

                //La venta se inserta aca
                result = VentaDAL.Instance.Insert(entity); // llama a la clase 
                foreach (DetVenta item in detalle)
                { 
                    item.VentaId = result;
                    //Se procesa
                    DetVentaBL.Instance.Insert(item);
                    InventarioBL.Instance.InsertVenta(item.ProductoId, item.Cantidad);
                }
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Venta entity)
        {
            bool result = false;

            try
            {
                result = VentaDAL.Instance.Update(entity); // llama a la clase 
            }
            catch (Exception ex)
            {
                //Errores con store 
                throw new Exception(ex.Message);
            }
            return result;
        }

        //public bool Delete(int id)
        //{
        //    bool result = false;

        //    try
        //    {
        //        result = VentaDAL.Instance.Delete(id); // llama a la clase 
        //    }
        //    catch (Exception ex)
        //    {
        //        //Errores con store 
        //        throw new Exception(ex.Message);
        //    }
        //    return result;
        //}

        public List<Venta> SelecAll()
        {
            List<Venta> result = null;

            try
            {
                result = VentaDAL.Instance.SelecAll(); // llama a la clase 
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
