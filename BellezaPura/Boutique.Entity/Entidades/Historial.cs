using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Historial
    {

        public int EventoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
        public string DUI { get; set; }
    }
}
