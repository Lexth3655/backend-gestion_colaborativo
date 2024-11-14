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
    public class EliminarProyectoCommand : IRequest<Proyecto>
    {
        public int proyectoId { get; set; }

    }

    public class EliminarProyectoCommandHandler : IRequestHandler<EliminarProyectoCommand, Proyecto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EliminarProyectoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Proyecto> Handle(EliminarProyectoCommand request, CancellationToken cancellationToken)
        {
            var proyecto = await _unitOfWork.RepositoryProyecto.GetByIdAsync(request.proyectoId);
            if (proyecto == null)
            {
                throw new NotImplementedException("Proyecto no encontrado");
            }

            var p = _mapper.Map<Proyecto>(proyecto);
            await _unitOfWork.RepositoryProyecto.DeleteAsync(proyecto);
            await _unitOfWork.SaveChangesAsync();

            return p;
        }

    }
}
