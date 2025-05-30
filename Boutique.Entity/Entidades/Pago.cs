using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public   class Pago
    {
        public int PagoId { get; set; }
        public string TipoPago { get; set; }
        public int EstadoId { get; set; }
    }
}
