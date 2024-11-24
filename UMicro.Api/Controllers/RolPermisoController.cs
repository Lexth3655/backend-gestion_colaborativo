using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FRolPermisos;

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolPermisoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolPermisoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AsignarPermisoARol")]
        public async Task<IActionResult> AsignarPermisoARol([FromBody] AsignarPermisoARolCommand command)
        {
            await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerPermisosPorRol), new { RolId = command.RolId }, null);
        }

        [HttpDelete("EliminarPermisoDeRol")]
        public async Task<IActionResult> EliminarPermisoDeRol([FromBody] EliminarPermisoDeRolCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("ObtenerPermisosPorRol/{rolId}")]
        public async Task<IActionResult> ObtenerPermisosPorRol(int rolId)
        {
            var result = await _mediator.Send(new ObtenerPermisosPorRolQuery(rolId));
            return Ok(result);
        }

        [HttpGet("ObtenerRolesPorPermiso/{permisoId}")]
        public async Task<IActionResult> ObtenerRolesPorPermiso(int permisoId)
        {
            var result = await _mediator.Send(new ObtenerRolesPorPermisoQuery(permisoId));
            return Ok(result);
        }
    }
}
