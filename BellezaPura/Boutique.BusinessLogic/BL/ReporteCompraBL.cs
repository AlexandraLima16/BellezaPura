using Boutique.DataAcces.DAL;
using Boutique.Entity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class ReporteCompraBL
    {
        public static ReporteCompraBL _instance;
        public static ReporteCompraBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReporteCompraBL();
                }

                return _instance;
            }

        }
        public List<ReportCompra> SelecAll()
        {
            List<ReportCompra> result = null;

            try
            {
                result = ReporteCompraDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        public List<ReportCompra> ObtenerPorFecha(DateTime fecha)
        {
            List<ReportCompra> result = null;

            try
            {
                result = ReporteCompraDAL.Instance.ObtenerPorFecha(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
