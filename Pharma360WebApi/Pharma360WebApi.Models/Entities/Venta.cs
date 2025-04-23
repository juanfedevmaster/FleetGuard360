using System;
using System.Collections.Generic;

namespace Pharma360WebApi.Models.Entities
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();
    }

}
