using ApiGateway.Models.DTOs;
using BasicAutentication.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BasicAutentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            LoginRequest request = new LoginRequest
            {
                Username = username,
                Password = password
            };

            var token = await _authService.LoginAsync(request);

            if(token == null)
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });

            return Ok(new { token = token.Token });

            
        }
    }
}
