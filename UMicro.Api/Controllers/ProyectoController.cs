using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FProyecto;
using UMicro.Domain.Modelo;

namespace UMicro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProyectoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("AddProyecto")]
        public async Task<Proyecto> Post([FromBody] AgregarComentarioCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("id")]
        //public async Task<IActionResult> Update(int id, [FromBody] ActualizarProyectoCommand command)
        //{
        //    if(id != command.proyectoID)
        //    {
        //        return BadRequest("El ID del proyecto no coincice");
       //     }
       //     await _mediator.Send(command);
       // }

        [HttpGet("GetListProyect")]
        public async Task<Proyecto> Get()
        {
            return await _mediator.Send(new ObtenerProyectoPorIdQuery());
        }

        [HttpPost("UpdateProyecto")]
        public async Task<Proyecto> Update([FromBody] EnviarNotificacionCommand command)
        {
            return await _mediator.Send(command);
        }

        

    }
}
