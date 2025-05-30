using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }

    }
}
