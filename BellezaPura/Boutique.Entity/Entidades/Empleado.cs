using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Codigo { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaContratacion { get; set; }
        public string CargoId { get; set; }
        public string EstadoId { get; set; }
    }
}
