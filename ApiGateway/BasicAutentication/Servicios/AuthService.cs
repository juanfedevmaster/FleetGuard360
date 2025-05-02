using ApiGateway.Data;
using ApiGateway.Models.DTOs;
using ApiGateway.Models.Entities;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BasicAutentication.Servicios
{
    /// <summary>
    /// Servicio para manejar la autenticación de usuarios.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor de la clase AuthService.
        /// </summary>
        /// <param name="context">Contexto de base de datos para la autenticación.</param>
        /// <param name="config">Configuración de la aplicación.</param>
        public AuthService(AuthDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        /// <summary>
        /// Inicia sesión en el sistema con las credenciales proporcionadas.
        /// </summary>
        /// <param name="request">Objeto que contiene el nombre de usuario y la contraseña.</param>
        /// <returns>Un objeto <see cref="LoginResponse"/> con el token JWT si las credenciales son válidas, o null si no lo son.</returns>
        public async Task<LoginBasicAuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;

            var basicToken = await GenerateToken(user);

            return new LoginBasicAuthResponse
            {
                Username = user.Username,
                Token = basicToken
            };
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema y le asigna un rol.
        /// </summary>
        /// <param name="request">Objeto que contiene los datos necesarios para registrar al usuario.</param>
        /// <returns>Un mensaje indicando que el usuario fue registrado con éxito y el rol fue asignado.</returns>
        /// <exception cref="Exception">Se lanza si no se encuentra el rol correspondiente al tipo de usuario.</exception>
        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                UserType = request.UserType
            };

            _context.Users.Add(user);

            // 1. Buscamos el rol correspondiente
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == request.UserType);
            if (role == null)
                throw new Exception($"Rol no encontrado para tipo de usuario: {request.UserType}");

            // 2. Relaciona con la tabla UserRoles
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            };

            _context.UserRoles.Add(userRole);

            await _context.SaveChangesAsync();

            return "Usuario registrado con éxito y rol asignado.";
        }

        /// <summary>
        /// Genera un token JWT para un usuario autenticado.
        /// </summary>
        /// <param name="user">Usuario para el cual se generará el token.</param>
        /// <returns>Un token JWT como cadena.</returns>
        private async Task<string> GenerateToken(User user)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{user.Username}:{user.PasswordHash}");
            var token = Convert.ToBase64String(plainTextBytes);
            
            return token;
        }
    }
}
