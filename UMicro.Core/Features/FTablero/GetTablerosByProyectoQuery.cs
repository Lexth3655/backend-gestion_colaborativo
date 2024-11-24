using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;


namespace UMicro.Core.Features.FTablero
{
    public class GetTablerosByProyectoQuery : IRequest<List<Tablero>>
    {
        public int proyectoId { get; set; }
    }

    public class GetTablerosByProyectoQueryHandler : IRequestHandler<GetTablerosByProyectoQuery, List<Tablero>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetTablerosByProyectoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Tablero>> Handle(GetTablerosByProyectoQuery request, CancellationToken cancellationToken)
        {
            var tablero = await Task.Run(() =>
            _unitOfWork.RepositoryUsuario.GetAllE().SingleOrDefault(t => t.id == request.proyectoId && t.activo));

            return _mapper.Map<List<Tablero>>(tablero);
        }
    }
}
