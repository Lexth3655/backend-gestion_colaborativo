using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMicro.Core.Features.FProyecto;
using UMicro.Core.Features.FTableroKanban;
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

        [HttpPost]
        public async Task<Proyecto> Post([FromBody] CreateProyectoCommand command)
        {
            return await _mediator.Send(command);
        }
        
    }
}
