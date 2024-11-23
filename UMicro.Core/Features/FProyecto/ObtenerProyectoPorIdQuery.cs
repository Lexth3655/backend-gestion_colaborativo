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
    public class ObtenerProyectoPorIdQuery : IRequest<Proyecto>
    {
        public int proyectoId { get; set; }

    }

    public class ObtenerProyectoPorIdHandler : IRequestHandler<ObtenerProyectoPorIdQuery, Proyecto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerProyectoPorIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Proyecto> Handle(ObtenerProyectoPorIdQuery request, CancellationToken cancellationToken)
        {
            var proyecto = await _unitOfWork.RepositoryProyecto.GetByIdAsync(request.proyectoId);


            if (proyecto == null)
            {
                throw new NotImplementedException("Proyecto no encontrado"); ;
            }
            var p = _mapper.Map<Proyecto>(proyecto);
            await _unitOfWork.SaveChangesAsync();

            return p;
        }
    }

}
