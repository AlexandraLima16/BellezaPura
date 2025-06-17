using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Devolucion
    {
        public int DevolucionId { get; set; }
        public int DetCompraId { get; set; }
        public string  Descripcion  { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int DetVentaId { get; set; }
    }
}
