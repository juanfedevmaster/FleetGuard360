using System;
using System.Collections.Generic;

namespace Pharma360WebApi.Models.DOTs
{
    public class VentaConDetallesDto
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }

        // Fix: Replace target-typed new() initialization with explicit instantiation to support C# 8.0  
        public List<DetalleVentaDto> Detalles { get; set; } = new List<DetalleVentaDto>();
    }
}
