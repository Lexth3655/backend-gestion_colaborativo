using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FUsuario
{
    public class ListarUsuariosQuery : IRequest<List<Usuario>> { }

    public class ListarUsuariosQueryHandler : IRequestHandler<ListarUsuariosQuery, List<Usuario>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListarUsuariosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Usuario>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RepositoryUsuario.GetAllAsync();
        }
    }

}
