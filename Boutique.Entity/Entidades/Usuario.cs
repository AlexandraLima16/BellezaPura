using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string EstadoId { get; set; }
        public string EmpleadoId { get; set; }
        public string RolId { get; set; }
    }
}
