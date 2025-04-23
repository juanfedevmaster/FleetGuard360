using System;
using System.Collections.Generic;
using System.Text;

namespace Pharma360WebApi.Models.DOTs
{
    public class CompraConDetallesDto
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdProveedor { get; set; }

        public List<DetalleCompraDto> Detalles { get; set; } = new List<DetalleCompraDto>();
    }
}
