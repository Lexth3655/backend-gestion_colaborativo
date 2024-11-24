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
    public record ObtenerRolesPorPermisoQuery(int PermisoId) : IRequest<IEnumerable<Roles>>;

    public class ObtenerRolesPorPermisoHandler : IRequestHandler<ObtenerRolesPorPermisoQuery, IEnumerable<Roles>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerRolesPorPermisoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Roles>> Handle(ObtenerRolesPorPermisoQuery request, CancellationToken cancellationToken)
        {
            var roles = await _unitOfWork.RepositoryRol_Permiso.GetRolesPorPermisoAsync(request.PermisoId);
            return _mapper.Map<IEnumerable<Roles>>(roles);
        }
    }


}
