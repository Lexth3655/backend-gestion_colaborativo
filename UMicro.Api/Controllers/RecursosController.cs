using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UMicro.Core.Features.FComentario;
using UMicro.Core.Features.FRecursos;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class recursosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public recursosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("agregar-recurso")]
        //public async Task<IActionResult> AgregarRecursoATarea([FromBody] AgregarRecursoATareaCommand command)
        ////{
        ////    var recursoId = await _mediator.Send(command);
        ////    return Ok(new { RecursoId = recursoId });
        //}
        // Agregar un recurso a una tarea
        [HttpPost("AgregarRecursoATarea")]
        public async Task<ActionResult<Recurso>> AgregarRecursoATareaCommand([FromQuery] int tareaId,
            [FromBody] Recurso nuevoRecurso)
        {
            var recursoId = await _mediator.Send(nuevoRecurso);
            return Ok(new { RecursoId = recursoId });

            return CreatedAtAction(nameof(ObtenerRecursosPorTareaQuery), new { tareaId = tareaId }, nuevoRecurso);
            }
            [HttpPut("actualizar-recurso")]
        public async Task<IActionResult> ActualizarRecurso([FromBody] ActualizarRecursoCommand command)
        {
            await _mediator.Send(command);
            return NoContent(); // 204 No Content, ya que no se devuelve un recurso
        }
        [HttpDelete("eliminar-recurso/{id}")]
        public async Task<IActionResult> EliminarRecurso(int id)
        {
            var command = new EliminarRecursoCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }



    }

    //[ApiController]
    //[Route("api/[controller]")]
    //public class RecursosController : ControllerBase
    //{
    //    private readonly ApplicationDbContext _context;

    //    public RecursosController(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // Agregar un recurso a una tarea
    //    [HttpPost("AgregarRecursoATarea")]
    //    public async Task<ActionResult<Recurso>> AgregarRecursoATarea(
    //        [FromQuery] int tareaId,
    //        [FromBody] Recurso nuevoRecurso)
    //    {
    //        var tarea = await _context.Tareas.FindAsync(tareaId);
    //        if (tarea == null)
    //        {
    //            return NotFound(new { mensaje = "La tarea no existe." });
    //        }

    //        nuevoRecurso.tareasID = tareaId;
    //        object value = _context.Recursos.Add(nuevoRecurso);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction(nameof(ObtenerRecursosPorTarea), new { tareaId = tareaId }, nuevoRecurso);
    //    }

    //    //Actualizar un recurso
    //    [HttpPut("ActualizarRecurso/{id}")]
    //    public async Task<IActionResult> ActualizarRecurso(
    //        [FromRoute] int id,
    //        [FromBody] Recurso recursoActualizado)
    //    {
    //        var recurso = await _context.Recursos.FindAsync(id);
    //        if (recurso == null)
    //        {
    //            return NotFound(new { mensaje = "El recurso no existe." });
    //        }

    //        recurso.nombreRecurso = recursoActualizado.nombreRecurso;
    //        recurso.url = recursoActualizado.url;
    //        recurso.tipoRecurso = recursoActualizado.tipoRecurso;

    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    //Eliminar un recurso
    //    [HttpDelete("EliminarRecurso/{id}")]
    //    public async Task<IActionResult> EliminarRecurso([FromRoute] int id)
    //    {
    //        var recurso = await _context.Recursos.FindAsync(id);
    //        if (recurso == null)
    //        {
    //            return NotFound(new { mensaje = "El recurso no existe." });
    //        }

    //        _context.Recursos.Remove(recurso);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    //Obtener recursos por tarea
    //    [HttpGet("ObtenerRecursosPorTarea/{tareaId}")]
    //    public async Task<ActionResult<IEnumerable<Recurso>>> ObtenerRecursosPorTarea([FromRoute] int tareaId)
    //    {
    //        var recursos = await _context.Recursos
    //            .Where(r => r.tareasID == tareaId).ToListAsync();

    //        if (!recursos.Any())
    //        {
    //            return NotFound(new { mensaje = "No hay recursos asociados a esta tarea." });
    //        }

    //        return Ok(recursos);
    //    }
    //}
}
