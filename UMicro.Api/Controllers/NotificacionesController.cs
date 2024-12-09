using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FNotificaciones;
using UMicro.Core.Features.FProyecto;
using UMicro.Domain.Modelo;
using UMicro.Persistence.Data;

namespace UMicro.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificacionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Enviar una notificación inmediata
        [HttpPost("EnviarNotificacion")]
        public async Task<IActionResult> EnviarNotificacion([FromQuery] int userId, [FromBody] EnviarNotificacionCommand command)
        {
            command.UserId = userId; // Asigna el UserId desde la URL
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : BadRequest("Error al enviar la notificación.");
        }

        //Programar una notificación
        [HttpPost("ProgramarNotificacion")]
        public async Task<IActionResult> ProgramarNotificacion([FromQuery] int userId, [FromBody] ProgramarNotificacionCommand command)
        {
            command.UserId = userId; // Asigna el UserId desde la URL
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : BadRequest("Error al programar la notificación.");
        }

       // Obtener notificaciones por usuario
        [HttpGet("ObtenerNotificacionesPorUsuario/{userId}")]
        public async Task<IActionResult> ObtenerNotificacionesPorUsuario(int userId)
        {
            var result = await _mediator.Send(new ObtenerNotificacionesPorUsuarioQuery { UserId = userId });
            return result != null ? Ok(result) : NotFound(new { mensaje = "No hay notificaciones para este usuario." });
        }
    }

}
