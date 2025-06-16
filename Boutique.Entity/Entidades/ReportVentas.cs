using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class ReportVentas
        {
            public int VentaId { get; set; }
            public string Producto { get; set; }
            public DateTime Fecha { get; set; }
            public int Cantidad { get; set; }
            public decimal Total { get; set; }
        }
    }

