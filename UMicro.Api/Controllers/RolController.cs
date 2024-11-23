using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FRoles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Crear un nuevo rol
        [HttpPost("Crear")]
        public async Task<IActionResult> CrearRol([FromBody] CrearRolCommand command)
        {
            var rolId = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerRolPorID), new { id = rolId }, rolId);
        }

        // Actualizar un rol existente
        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] ActualizarRolCommand command)
        {
            if (id != command.RolId)
                return BadRequest("El ID del rol en la URL y el cuerpo no coinciden.");

            var result = await _mediator.Send(command);
            if (!result) return NotFound("El rol especificado no fue encontrado.");
            return NoContent();
        }

        // Eliminar un rol
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            var result = await _mediator.Send(new EliminarRolCommand { RolId = id });
            if (!result) return NotFound("El rol especificado no fue encontrado.");
            return NoContent();
        }

        // Obtener un rol por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerRolPorID(int id)
        {
            var rol = await _mediator.Send(new ObtenerRolPorIDQuery { RolId = id });
            if (rol == null) return NotFound("El rol especificado no fue encontrado.");
            return Ok(rol);
        }

        // Listar todos los roles
        [HttpGet("Listar")]
        public async Task<IActionResult> ListarRoles()
        {
            var roles = await _mediator.Send(new ListarRolesQuery());
            return Ok(roles);
        }

        // Asignar un permiso a un rol
        [HttpPost("AsignarPermiso")]
        public async Task<IActionResult> AsignarPermisoARol([FromBody] AsignarPermisoARolCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return BadRequest("La asignación del permiso falló.");
            return Ok("Permiso asignado correctamente.");
        }

        // Eliminar un permiso de un rol
        [HttpDelete("EliminarPermiso")]
        public async Task<IActionResult> EliminarPermisoDeRol([FromBody] EliminarPermisoDeRolCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result) return NotFound("La relación entre el rol y el permiso no fue encontrada.");
            return Ok("Permiso eliminado correctamente.");
        }
    }
}
