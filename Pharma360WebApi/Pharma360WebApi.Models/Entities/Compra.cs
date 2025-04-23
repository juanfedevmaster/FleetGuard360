using System;
using System.Collections.Generic;
using System.Text;

namespace Pharma360WebApi.Models.Entities
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; } = null!;

        public ICollection<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();
    }

}
