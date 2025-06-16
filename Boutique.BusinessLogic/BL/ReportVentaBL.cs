using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boutique.Entity.Entidades;
using Boutique.DataAcces.DAL;
using System.Threading.Tasks;

namespace Boutique.BusinessLogic.BL
{
    public class ReportVentaBL
    {
        private static ReportVentaBL _instance;
        public static ReportVentaBL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportVentaBL();
                }

                return _instance;
            }
        }
        public List<ReportVentas> SelecAll()
        {
            List<ReportVentas> result = null;

            try
            {
                result = ReporteVentasDAL.Instance.SelecAll(); // llama a la clase 
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<ReportVentas> ObtenerPorFecha(DateTime fecha)
        {
            List<ReportVentas> result = null;

            try
            {
                result = ReporteVentasDAL.Instance.ObtenerPorFecha(fecha);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}

