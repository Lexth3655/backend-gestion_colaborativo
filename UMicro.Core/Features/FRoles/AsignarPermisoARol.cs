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
    public class AsignarPermisoARol : IRequest<bool>
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }

    public class AsignarPermisoARolCommandHandler : IRequestHandler<AsignarPermisoARol, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AsignarPermisoARolCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AsignarPermisoARol request, CancellationToken cancellationToken)
        {
            var rolPermiso = new Rol_Permiso { rolID = request.RolId, permisoID = request.PermisoId };
            await _unitOfWork.RepositoryRol_Permiso.AddAsync(rolPermiso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }


}
