using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;

namespace UMicro.Core.Features.FRoles
{
    public class EliminarPermisoDeRol : IRequest<bool>
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }

    public class EliminarPermisoDeRolHandler : IRequestHandler<EliminarPermisoDeRol, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPermisoDeRolHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarPermisoDeRol request, CancellationToken cancellationToken)
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
