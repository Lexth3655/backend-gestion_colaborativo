using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FRolPermisos
{
    public record ObtenerPermisosPorRolQuery(int RolId) : IRequest<IEnumerable<Permiso>>;

    public class ObtenerPermisosPorRolHandler : IRequestHandler<ObtenerPermisosPorRolQuery, IEnumerable<Permiso>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerPermisosPorRolHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Permiso>> Handle(ObtenerPermisosPorRolQuery request, CancellationToken cancellationToken)
        {
            var permisos = await _unitOfWork.RepositoryRol_Permiso.GetPermisosPorRolAsync(request.RolId);
            return _mapper.Map<IEnumerable<Permiso>>(permisos);
        }
    }


}
