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
    public class ListarRolesQuery : IRequest<List<Roles>> { }

    public class ListarRolesQueryHandler : IRequestHandler<ListarRolesQuery, List<Roles>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListarRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<Roles>> Handle(ListarRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _unitOfWork.RepositoryRol.GetAllAsync();
            return _mapper.Map<List<Roles>>(roles);
        }
    }


}
