using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Productos
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetAllAsync();
        Task<ProductoDto?> GetByIdAsync(int id);
        Task<ProductoDto> CreateAsync(ProductoDto dto);
        Task<bool> UpdateAsync(int id, ProductoDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
