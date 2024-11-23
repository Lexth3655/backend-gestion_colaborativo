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
    public class ObtenerTableroPorIDQuery : IRequest<Tablero>
    {
        public int tableroID { get; set; }
    }

    public class ObtenerTableroPorIDQueryHandler : IRequestHandler<ObtenerTableroPorIDQuery, Tablero>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ObtenerTableroPorIDQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tablero> Handle(ObtenerTableroPorIDQuery request, CancellationToken cancellationToken)
        {

            var tableroId = await _unitOfWork.RepositoryTablero.GetByIdAsync(request.tableroID);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Tablero>(tableroId); // Retorna el ID del nuevo proyecto
        }
    }
}
