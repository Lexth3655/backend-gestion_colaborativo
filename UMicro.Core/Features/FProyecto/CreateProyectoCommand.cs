using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FProyecto
{
    //Command
    public class CreateProyectoCommand : IRequest<Proyecto>
    {
        public string NombreProyecto { get; set; }
        public string Description { get; set; }
    }
    //Handler
    public class CreateProyectoCommandHandler : IRequestHandler<CreateProyectoCommand, Proyecto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProyectoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Proyecto> Handle(CreateProyectoCommand request, CancellationToken cancellationToken)
        {
            var p = _mapper.Map<Proyecto>(request);
            await _unitOfWork.RepositoryProyecto.AddAsync(p);
            await _unitOfWork.SaveChangesAsync();
            return p;
        }
    }

    //Response
    public record Response(Proyecto proyecto);
}
