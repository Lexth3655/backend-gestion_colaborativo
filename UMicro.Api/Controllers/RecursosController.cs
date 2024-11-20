using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UMicro.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecursosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Agregar un recurso a una tarea
        [HttpPost("AgregarRecursoATarea")]
        public async Task<ActionResult<Recurso>> AgregarRecursoATarea(
            [FromQuery] int tareaId,
            [FromBody] Recurso nuevoRecurso)
        {
            var tarea = await _context.Tareas.FindAsync(tareaId);
            if (tarea == null)
            {
                return NotFound(new { mensaje = "La tarea no existe." });
            }

            nuevoRecurso.tareasID = tareaId;
            object value = _context.Recursos.Add(nuevoRecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerRecursosPorTarea), new { tareaId = tareaId }, nuevoRecurso);
        }

        //Actualizar un recurso
        [HttpPut("ActualizarRecurso/{id}")]
        public async Task<IActionResult> ActualizarRecurso(
            [FromRoute] int id,
            [FromBody] Recurso recursoActualizado)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound(new { mensaje = "El recurso no existe." });
            }

            recurso.nombreRecurso = recursoActualizado.nombreRecurso;
            recurso.url = recursoActualizado.url;
            recurso.tipoRecurso = recursoActualizado.tipoRecurso;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Eliminar un recurso
        [HttpDelete("EliminarRecurso/{id}")]
        public async Task<IActionResult> EliminarRecurso([FromRoute] int id)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound(new { mensaje = "El recurso no existe." });
            }

            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Obtener recursos por tarea
        [HttpGet("ObtenerRecursosPorTarea/{tareaId}")]
        public async Task<ActionResult<IEnumerable<Recurso>>> ObtenerRecursosPorTarea([FromRoute] int tareaId)
        {
            var recursos = await _context.Recursos
                .Where(r => r.tareasID == tareaId).ToListAsync();

            if (!recursos.Any())
            {
                return NotFound(new { mensaje = "No hay recursos asociados a esta tarea." });
            }

            return Ok(recursos);
        }
    }
}
