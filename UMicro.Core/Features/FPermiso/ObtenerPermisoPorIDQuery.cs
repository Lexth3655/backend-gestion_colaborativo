using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FPermiso
{
    // Query para ObtenerPermisoPorID
    public record ObtenerPermisoPorIDQuery(int Id) : IRequest<Permiso>;

    // Handler para ObtenerPermisoPorID
    public class ObtenerPermisoPorIDQueryHandler : IRequestHandler<ObtenerPermisoPorIDQuery, Permiso>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerPermisoPorIDQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Permiso> Handle(ObtenerPermisoPorIDQuery request, CancellationToken cancellationToken)
        {
            var permiso = await _unitOfWork.RepositoryPermiso.FindAsync(request.Id);
            return _mapper.Map<Permiso>(permiso);
        }
    }

}
