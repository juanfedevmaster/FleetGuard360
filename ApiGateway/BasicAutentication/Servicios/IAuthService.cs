using ApiGateway.Models.DTOs;

namespace BasicAutentication.Servicios
{
    public interface IAuthService
    {
        Task<LoginBasicAuthResponse> LoginAsync(LoginRequest request);
        Task<string> RegisterAsync(RegisterRequest request);
    }
}
