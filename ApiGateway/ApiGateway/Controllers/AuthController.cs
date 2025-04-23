using ApiGateway.Models.DTOs;
using ApiGateway.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    /// <summary>
    /// Controlador para gestionar la autenticación de usuarios.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Constructor de la clase AuthController.
        /// </summary>
        /// <param name="authService">Servicio de autenticación utilizado para manejar las operaciones de autenticación.</param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="request">Objeto que contiene los datos necesarios para registrar al usuario.</param>
        /// <returns>Un resultado de acción que indica el éxito o el fallo del registro.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Inicia sesión en el sistema con las credenciales proporcionadas.
        /// </summary>
        /// <param name="request">Objeto que contiene el nombre de usuario y la contraseña.</param>
        /// <returns>Un resultado de acción que contiene el token de autenticación si las credenciales son válidas, o un error si no lo son.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            // Los usuarios pasajero1, operador1, conductor1, admin1 son de prueba y su password es:
            // "MiContraseñaSegura123!"

            var result = await _authService.LoginAsync(request);
            if (result == null)
                return Unauthorized("Credenciales inválidas.");
            return Ok(result);
        }

        /*  Con este código puedes validar el Claim para verificar si tiene o no permisos para
         *  la funcionalidad que requiera un permiso personalizado.
            if (User.HasClaim("perm:create", "true"))
            {
                // Permitir crear
            }
            else
            {
                return Forbid(); // O Unauthorized()
            }
         */
    }
}
