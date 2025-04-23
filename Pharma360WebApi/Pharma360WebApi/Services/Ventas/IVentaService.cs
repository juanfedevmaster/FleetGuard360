using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Ventas
{
    public interface IVentaService
    {
        Task<IEnumerable<VentaConDetallesDto>> GetAllAsync();
        Task<VentaConDetallesDto?> GetByIdAsync(int id);
    }
}
