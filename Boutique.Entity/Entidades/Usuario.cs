using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Usuario
    {
        public string DUI { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Contrasena { get; set; }
        public int EstadoId { get; set; }
        public int EmpleadoId { get; set; }
        public int RolId { get; set; }
    }
}
