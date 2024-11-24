using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FPermiso;

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermisosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPermiso(CrearPermisoCommand command)
        {
            var permisoId = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerPermisoPorID), new { id = permisoId }, permisoId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPermiso(int id, ActualizarPermisoCommand command)
        {
            if (id != command.Id) return BadRequest();
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPermiso(int id)
        {
            var result = await _mediator.Send(new EliminarPermisoCommand(id));
            return result ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPermisoPorID(int id)
        {
            var permiso = await _mediator.Send(new ObtenerPermisoPorIDQuery(id));
            return permiso != null ? Ok(permiso) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> ListarPermisos()
        {
            var permisos = await _mediator.Send(new ListarPermisosQuery());
            return Ok(permisos);
        }
    }
}
