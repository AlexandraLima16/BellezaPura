using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class ReportCompra
    {
        
        public int CompraId { get; set; }
        public string ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalCompra { get; set; }
    }
}
