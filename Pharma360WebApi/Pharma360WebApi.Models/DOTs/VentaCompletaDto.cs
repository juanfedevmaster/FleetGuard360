using System;
using System.Collections.Generic;
using System.Text;

namespace Pharma360WebApi.Models.DOTs
{
    public class VentaCompletaDto
    {
        public VentaDto Venta { get; set; } = null!;
        public List<DetalleVentaDto> Detalles { get; set; }

        public VentaCompletaDto()
        {
            Detalles = new List<DetalleVentaDto>();
        }
    }
}
