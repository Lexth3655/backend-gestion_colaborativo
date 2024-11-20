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
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ActionResult<Comentarios>> AgregarComentarioATarea([FromQuery] int tareaId, [FromQuery] int usuarioId, [FromBody] string contenido)
        {
            return AgregarComentarioATarea(tareaId, usuarioId, contenido, _context);
        }

        //Agregar un comentario a una tarea
        [HttpPost("AgregarComentarioATarea")]
        public async Task<ActionResult<Comentarios>> AgregarComentarioATarea(
            [FromQuery] int tareaId,
            [FromQuery] int usuarioId,
            [FromBody] string contenido, ApplicationDbContext _context)
        {
            var tarea = await _context.Tareas.FindAsync(tareaId);
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (tarea == null)
            {
                return NotFound(new { mensaje = "La tarea no existe." });
            }

            if (usuario == null)
            {
                return NotFound(new { mensaje = "El usuario no existe." });
            }

            var comentario = new Comentarios
            {
                tareaID = tareaId,
                usuarioID = usuarioId,
                contenido = contenido,
            };

            object value = _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerComentariosPorTarea), new { tareaId = tareaId }, comentario);
        }

        //Actualizar un comentario
        [HttpPut("ActualizarComentario")]
        public async Task<IActionResult> ActualizarComentario(
            [FromQuery] int id,
            [FromBody] string nuevoContenido)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound(new { mensaje = "El comentario no existe." });
            }

            comentario.contenido = nuevoContenido;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Eliminar un comentario
        [HttpDelete("EliminarComentario")]
        public async Task<IActionResult> EliminarComentario([FromQuery] int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound(new { mensaje = "El comentario no existe." });
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Obtener comentarios por tarea
        [HttpGet("ObtenerComentariosPorTarea")]
        public async Task<ActionResult<IEnumerable<Comentarios>>> ObtenerComentariosPorTarea([FromQuery] int tareaId)
        {
            var comentarios = await _context.Comentarios
                .Where(c =>
                {
                    return c.tareaID == tareaId;
                })
                .Include(c => c.Usuario) // Incluye información del usuario
                .OrderByDescending(c => c.Id) // Orden por el último comentario
                .ToListAsync();

            if (!comentarios.Any())
            {
                return NotFound(new { mensaje = "No hay comentarios asociados a esta tarea." });
            }

            return Ok(comentarios);
        }
    }



}
