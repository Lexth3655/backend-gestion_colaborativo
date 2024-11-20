using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

namespace UMicro.Api.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComentariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Agregar un comentario a una tarea
        [HttpPost("AgregarComentarioATarea")]
        public async Task<IActionResult> AgregarComentarioATarea([FromQuery] int tareaId, [FromBody] AgregarComentarioCommand command)
        {
            command.TareaId = tareaId; // Asigna la tareaId desde la URL
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : BadRequest("Error al agregar el comentario.");
        }

        //Actualizar un comentario
        [HttpPut("ActualizarComentario/{id}")]
        public async Task<IActionResult> ActualizarComentario(int id, [FromBody] ActualizarComentarioCommand command)
        {
            command.Id = id; // Asigna el ID del comentario
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : BadRequest("Error al actualizar el comentario.");
        }

        //Eliminar un comentario
        [HttpDelete("EliminarComentario/{id}")]
        public async Task<IActionResult> EliminarComentario(int id)
        {
            var result = await _mediator.Send(new EliminarComentarioCommand { Id = id });
            return result ? Ok("Comentario eliminado exitosamente.") : NotFound("Comentario no encontrado.");
        }

        //Obtener comentarios por tarea
        [HttpGet("ObtenerComentariosPorTarea/{tareaId}")]
        public async Task<IActionResult> ObtenerComentariosPorTarea(int tareaId)
        {
            var result = await _mediator.Send(new ObtenerComentariosPorTareaQuery { TareaId = tareaId });
            return result != null ? Ok(result) : NotFound("No hay comentarios para esta tarea.");
        }
    }



}
