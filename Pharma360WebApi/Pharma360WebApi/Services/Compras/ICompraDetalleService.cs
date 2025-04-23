using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Compras
{
    public interface ICompraDetalleService
    {
        Task<IEnumerable<CompraConDetallesDto>> GetAllAsync();
        Task<CompraConDetallesDto?> GetByIdAsync(int id);
    }
}
