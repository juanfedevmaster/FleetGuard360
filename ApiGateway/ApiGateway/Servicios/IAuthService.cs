using ApiGateway.Models.DTOs;

namespace ApiGateway.Servicios
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<string> RegisterAsync(RegisterRequest request);
    }
}
