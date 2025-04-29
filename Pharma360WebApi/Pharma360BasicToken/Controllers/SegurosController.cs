using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pharma360BasicToken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize] // Protegido por Basic Authentication
    public class SegurosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { mensaje = "Acceso autorizado al módulo de seguros." });
        }
    }
}
