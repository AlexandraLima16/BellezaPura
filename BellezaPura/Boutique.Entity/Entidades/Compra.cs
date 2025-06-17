using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Compra
    {
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public string DUI { get; set; }
        public decimal TotalCompra { get; set; }
    }
}
