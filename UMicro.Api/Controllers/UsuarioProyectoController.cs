using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioProyectoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioProyectoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/UsuarioProyecto
        [HttpGet]
        public async Task<IActionResult> GetAllUsuarioProyectos()
        {
            var usuarioProyectos = await _unitOfWork.RepositoryUsuarioProyecto.GetAllAsync();
            var usuarioProyectoDtos = usuarioProyectos.Select(up => new UsuarioProyectoDto
            {
                usuarioID = up.usuarioID,
                proyectoID = up.proyectoID,
                FechaAsignacion = up.FechaAsignacion,
                rolID = up.rolID,
                RolDescripcion = up.Roles.Descripcion // Asegúrate de que Roles esté incluido en el query
            });

            return Ok(usuarioProyectoDtos);
        }

        // GET: api/UsuarioProyecto/Usuario/5/Proyecto/10
        [HttpGet("Usuario/{usuarioId}/Proyecto/{proyectoId}")]
        public async Task<IActionResult> ObtenerPorUsuarioYProyecto(int usuarioId, int proyectoId)
        {
            var usuarioProyecto = await _unitOfWork.RepositoryUsuarioProyecto.ObtenerPorUsuarioYProyectoAsync(usuarioId, proyectoId);

            if (usuarioProyecto == null)
                return NotFound($"No se encontró un registro para el usuario con ID {usuarioId} y el proyecto con ID {proyectoId}.");

            var usuarioProyectoDto = new UsuarioProyecto
            {
                usuarioID = usuarioProyecto.usuarioID,
                proyectoID = usuarioProyecto.proyectoID,
                FechaAsignacion = usuarioProyecto.FechaAsignacion,
                rolID = usuarioProyecto.rolID,
                RolDescripcion = usuarioProyecto.Roles?.Descripcion
            };

            return Ok(usuarioProyectoDto);
        }

        // POST: api/UsuarioProyecto
        [HttpPost]
        public async Task<IActionResult> CreateUsuarioProyecto([FromBody] UsuarioProyecto usuarioProyectoDto)
        {
            if (usuarioProyectoDto == null)
                return BadRequest("El cuerpo de la solicitud no puede ser nulo.");

            // Comprueba si ya existe la relación entre el usuario y el proyecto
            var existente = await _unitOfWork.RepositoryUsuarioProyecto
                .ObtenerPorUsuarioYProyectoAsync(usuarioProyectoDto.usuarioID, usuarioProyectoDto.proyectoID);

            if (existente != null)
                return Conflict("La relación entre el usuario y el proyecto ya existe.");

            var usuarioProyecto = new UsuarioProyecto
            {
                usuarioID = usuarioProyectoDto.usuarioID,
                proyectoID = usuarioProyectoDto.proyectoID,
                FechaAsignacion = usuarioProyectoDto.FechaAsignacion,
                rolID = usuarioProyectoDto.rolID
            };

            await _unitOfWork.RepositoryUsuarioProyecto.AddAsync(usuarioProyecto);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new
            {
                Message = "UsuarioProyecto creado correctamente",
                usuarioID = usuarioProyecto.usuarioID,
                proyectoID = usuarioProyecto.proyectoID
            });
        }

        // PUT: api/UsuarioProyecto/Usuario/5/Proyecto/10
        [HttpPut("Usuario/{usuarioId}/Proyecto/{proyectoId}")]
        public async Task<IActionResult> UpdateUsuarioProyecto(int usuarioId, int proyectoId, [FromBody] UsuarioProyecto usuarioProyectoDto)
        {
            if (usuarioId != usuarioProyectoDto.usuarioID || proyectoId != usuarioProyectoDto.proyectoID)
                return BadRequest("Los IDs proporcionados no coinciden con el cuerpo de la solicitud.");

            var usuarioProyecto = await _unitOfWork.RepositoryUsuarioProyecto.ObtenerPorUsuarioYProyectoAsync(usuarioId, proyectoId);
            if (usuarioProyecto == null)
                return NotFound($"No se encontró un registro para el usuario con ID {usuarioId} y el proyecto con ID {proyectoId}.");

            // Actualiza los campos
            usuarioProyecto.FechaAsignacion = usuarioProyectoDto.FechaAsignacion;
            usuarioProyecto.rolID = usuarioProyectoDto.rolID;

            await _unitOfWork.RepositoryUsuarioProyecto.UpdateAsync(usuarioProyecto);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/UsuarioProyecto/Usuario/5/Proyecto/10
        [HttpDelete("Usuario/{usuarioId}/Proyecto/{proyectoId}")]
        public async Task<IActionResult> DeleteUsuarioProyecto(int usuarioId, int proyectoId)
        {
            var usuarioProyecto = await _unitOfWork.RepositoryUsuarioProyecto.ObtenerPorUsuarioYProyectoAsync(usuarioId, proyectoId);
            if (usuarioProyecto == null)
                return NotFound($"No se encontró un registro para el usuario con ID {usuarioId} y el proyecto con ID {proyectoId}.");

            await _unitOfWork.RepositoryUsuarioProyecto.DeleteAsync(usuarioProyecto);
            await _unitOfWork.SaveChangesAsync();

            return Ok("UsuarioProyecto eliminado correctamente.");
        }
    }
}
