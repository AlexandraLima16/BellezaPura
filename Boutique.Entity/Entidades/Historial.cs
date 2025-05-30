using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Historial
    {

        public int HistorialId { get; set; }
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
        public int UsuarioId { get; set; }
    }
}
