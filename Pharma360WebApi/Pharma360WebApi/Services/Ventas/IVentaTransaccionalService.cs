using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Ventas
{
    public interface IVentaTransaccionalService
    {
        Task<bool> CrearVentaConDetallesAsync(VentaCompletaDto ventaCompleta);
    }
}
