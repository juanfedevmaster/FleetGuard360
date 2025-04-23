using System;
using System.Collections.Generic;
using System.Text;

namespace Pharma360WebApi.Models.DOTs
{
    public class DetalleCompraDto
    {
        public int IdDetalle { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
