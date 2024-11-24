using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FTablero;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TableroController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpPost("AddTablero")]
        public async Task<IActionResult> CrearTablero([FromBody] AgregarTableroCommand command)
        {
            try
            {
                var tableroId = await _mediator.Send(command);
                return CreatedAtAction(
                    nameof(ObtenerTableroPorID),
                    new { id = tableroId.id }, 
                    tableroId);
            } catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTableroPorID(int id)
        {
            var tablero = await _mediator.Send(new ObtenerTableroPorIDQuery { tableroID = id });
            if (tablero == null)
                return NotFound();
            return Ok(tablero);
        }

        // PUT: ActualizarTablero
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarTablero(int tableroId, [FromBody] ModifcarTableroCommand command)
        {
            if (tableroId != command.tableroID)
                return BadRequest("El ID del tablero no coincide.");

            var resultado = await _mediator.Send(command);
            if (!resultado)
                return NotFound();

            return NoContent();
        }

        // DELETE: EliminarTablero
        [HttpDelete("eliminar/{tableroId}")]
        public async Task<bool> EliminarTablero([FromBody] EliminarTableroCommand command)
        {
            return await _mediator.Send(command);
        }

        // GET: ListarTablerosPorProyecto
        [HttpGet("proyecto/{proyectoId}")]
        public async Task<IActionResult> ListarTablerosPorProyecto(int proyectoId)
        {
            var tableros = await _mediator.Send(new GetTablerosByProyectoQuery{ proyectoId = proyectoId});
            if(tableros == null || tableros.Count == 0)
            return NotFound("No se encontraron tableros para el proyecto especificado.");
            return Ok(tableros);
        }
    }
}
