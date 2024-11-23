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
    // Query para ListarPermisos
    public record ListarPermisosQuery() : IRequest<List<Permiso>>;

    // Handler para ListarPermisos
    public class ListarPermisosQueryHandler : IRequestHandler<ListarPermisosQuery, List<Permiso>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListarPermisosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Permiso>> Handle(ListarPermisosQuery request, CancellationToken cancellationToken)
        {
            var permisos = await _unitOfWork.RepositoryPermiso.GetAllAsync();
            return _mapper.Map<List<Permiso>>(permisos);
        }
    }

}
