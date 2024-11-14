using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FUsuario;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] IniciarSesionCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
            {
                return Unauthorized();
            }

            return Ok("Inicion de Session Exitoso");
        }
       
    }
}
