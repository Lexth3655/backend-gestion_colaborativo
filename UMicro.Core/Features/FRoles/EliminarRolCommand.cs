using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;

namespace UMicro.Core.Features.FRoles
{
    public class EliminarRolCommand : IRequest<bool>
    {
        public int RolId { get; set; }
    }

    public class EliminarRolCommandHandler : IRequestHandler<EliminarRolCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarRolCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _unitOfWork.RepositoryRol.GetByIdAsync(request.RolId);
            if (rol == null) return false;

            _unitOfWork.RepositoryRol.DeleteAsync(rol);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }


}
