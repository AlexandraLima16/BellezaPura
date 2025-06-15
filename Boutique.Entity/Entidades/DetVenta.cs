using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class DetVenta
    {

        public int DetVentaId { get; set; }
        public int Cantidad  { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }

    }
}
