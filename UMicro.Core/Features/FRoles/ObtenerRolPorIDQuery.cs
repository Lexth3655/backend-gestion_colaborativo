using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FRoles
{
    public class ObtenerRolPorIDQuery : IRequest<Roles>
    {
        public int RolId { get; set; }
    }

    public class ObtenerRolPorIDQueryHandler : IRequestHandler<ObtenerRolPorIDQuery, Roles>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerRolPorIDQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Roles> Handle(ObtenerRolPorIDQuery request, CancellationToken cancellationToken)
        {
            var rol = await _unitOfWork.RepositoryRol.GetByIdAsync(request.RolId);
            return _mapper.Map<Roles>(rol);
        }
    }


}
