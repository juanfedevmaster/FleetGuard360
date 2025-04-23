using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Proveedores
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedorDto>> GetAllAsync();
        Task<ProveedorDto?> GetByIdAsync(int id);
        Task<ProveedorDto> CreateAsync(ProveedorDto dto);
        Task<bool> UpdateAsync(int id, ProveedorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
