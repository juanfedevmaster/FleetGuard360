using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Pharma360BasicToken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            // Validamos usuario (mockeado) 
            // username=admin
            // password=password123
            if (username == "admin" && password == "password123")
            {
                var plainTextBytes = Encoding.UTF8.GetBytes($"{username}:{password}");
                var token = Convert.ToBase64String(plainTextBytes);

                return Ok(new { token = token });
            }

            return Unauthorized(new { mensaje = "Credenciales incorrectas" });
        }
    }
}
