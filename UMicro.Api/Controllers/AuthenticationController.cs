using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UMicro.Core.Features.FUsuario;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] IniciarSesionCommand command)
        {
            //Validar credenciales(reemplaza esto con la lógica de tu base de datos)
            if (command.email == "perez@hotmail.com" && command.password == "123456")
            {
                await _mediator.Send(command);
                var token = GenerateJwtToken(command.email);
                return Ok(new { token });
            }
            //var result = await _mediator.Send(command);

            //if (!result)
            //{
            //    return Unauthorized();
            //}

            return Unauthorized("Credenciales incorrectas.");
        }

        private string GenerateJwtToken(string email)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];

            // Validar si las configuraciones son nulas o vacías
            if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
            {
                throw new InvalidOperationException("Faltan configuraciones de JWT en appsettings.json.");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            Console.WriteLine($"Key: {_configuration["Jwt:Key"]}");
            Console.WriteLine($"Issuer: {_configuration["Jwt:Issuer"]}");
            Console.WriteLine($"Audience: {_configuration["Jwt:Audience"]}");

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
