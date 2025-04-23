using System.Collections.Generic;

namespace Pharma360WebApi.Models.DOTs
{
    public class CompraCompletaDto
    {
        public CompraDto Compra { get; set; } = null!;
        public List<DetalleCompraDto> Detalles { get; set; }

        public CompraCompletaDto()
        {
            Detalles = new List<DetalleCompraDto>();
        }
    }
}
