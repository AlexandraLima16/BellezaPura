﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Boutique.Entity.Entidades
{
    public class DetCompra
    {
        public int DetCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int PagoId { get; set; }
        public int ProveedorId { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

    }
}
