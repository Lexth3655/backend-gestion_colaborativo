using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UMicro.Core.Features.FProyecto;

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProyectosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Obtener proyectos en los que un usuario participa
        [HttpGet("usuario/{usuarioId}/proyectos")]
        public async Task<IActionResult> ListarProyectosDeUsuario(int usuarioId)
        {
            try
            {
                var query = new ListarProyectosDeUsuarioQuery { UsuarioId = usuarioId };
                var proyectos = await _mediator.Send(query);

                if (proyectos == null || !proyectos.Any())
                {
                    return NotFound($"No se encontraron proyectos para el usuario con ID {usuarioId}.");
                }

                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        

        // Crear Proyecto
        [HttpPost("crear")]
        public async Task<IActionResult> CrearProyecto([FromBody] CrearProyectoCommand command)
        {
            try
            {
                var proyecto = await _mediator.Send(command);
                return CreatedAtAction(nameof(ObtenerProyectoPorId), new { id = proyecto.id }, proyecto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // Actualizar Proyecto
        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarProyecto(int id, [FromBody] ActualizarProyectoCommand command)
        {
            if (id != command.proyectoID)
            {
                return BadRequest("El ID del proyecto no coincide.");
            }

            try
            {
                var proyecto = await _mediator.Send(command);
                if (proyecto == null)
                {
                    return NotFound($"El proyecto con ID {id} no existe.");
                }

                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // Eliminar Proyecto
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarProyecto(int id)
        {
            try
            {
                var command = new EliminarProyectoCommand { proyectoId = id };
                var proyecto = await _mediator.Send(command);

                if (proyecto == null)
                {
                    return NotFound($"El proyecto con ID {id} no existe.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // Obtener Proyecto Por ID
        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> ObtenerProyectoPorId(int id)
        {
            try
            {
                var query = new ObtenerProyectoPorIdQuery { proyectoId = id };
                var proyecto = await _mediator.Send(query);

                if (proyecto == null)
                {
                    return NotFound($"El proyecto con ID {id} no existe.");
                }

                return Ok(proyecto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        // Listar Todos los Proyectos
        [HttpGet("listar")]
        public async Task<IActionResult> ListarProyectos()
        {
            try
            {
                var query = new ListarProyectosDeUsuarioQuery();
                var proyectos = await _mediator.Send(query);

                return Ok(proyectos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
