using Pharma360WebApi.Models.DOTs;

namespace Pharma360WebApi.Services.Clientes
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(int id);
        Task<ClienteDto> CreateAsync(ClienteDto dto);
        Task<bool> UpdateAsync(int id, ClienteDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
