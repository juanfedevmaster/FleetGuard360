using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Compras
{
    public interface ICompraService
    {
        Task<IEnumerable<CompraDto>> GetAllAsync();
        Task<CompraDto?> GetByIdAsync(int id);
        Task<CompraDto> CreateAsync(CompraDto dto);
        Task<bool> UpdateAsync(int id, CompraDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
