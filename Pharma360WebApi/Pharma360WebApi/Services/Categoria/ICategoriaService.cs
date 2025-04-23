using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetAllAsync();
        Task<CategoriaDto?> GetByIdAsync(int id);
        Task<CategoriaDto> CreateAsync(CategoriaDto dto);
        Task<bool> UpdateAsync(int id, CategoriaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
