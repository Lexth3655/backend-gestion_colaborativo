using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;

namespace UMicro.Core.Features.FRoles
{
    public class EliminarPermisoDeRolCommand : IRequest<bool>
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }

    public class EliminarPermisoDeRolCommandHandler : IRequestHandler<EliminarPermisoDeRolCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPermisoDeRolCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarPermisoDeRolCommand request, CancellationToken cancellationToken)
        {
            var rolPermiso = await _unitOfWork.RepositoryRol_Permiso
                .FindAsync(request.RolId , request.PermisoId);

            if (rolPermiso == null) return false;

            _unitOfWork.RepositoryRol_Permiso.DeleteAsync(rolPermiso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }


}
