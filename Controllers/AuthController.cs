using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RunGym.Run;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly RunGymContext _context;

        public AuthController(IConfiguration configuration, RunGymContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Invalid client request");
            }

            // Obtener las credenciales desde la configuración
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == login.Username);

            if (usuario == null || usuario.Contrasena != login.Password)
            {
                return Unauthorized("Invalid email or password");
            }
            
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: new List<Claim>
            {
            new Claim(ClaimTypes.Name, usuario.Email), // Usamos el email como nombre de usuario
            new Claim(ClaimTypes.Role, usuario.TipoUsuario) // Puedes ajustar el rol según sea necesario
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
    }
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
