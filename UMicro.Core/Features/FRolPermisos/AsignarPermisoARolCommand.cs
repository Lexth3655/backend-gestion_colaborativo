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
    public record AsignarPermisoARolCommand(int RolId, int PermisoId) : IRequest<Unit>;

    public class AsignarPermisoARolHandler : IRequestHandler<AsignarPermisoARolCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AsignarPermisoARolHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AsignarPermisoARolCommand request, CancellationToken cancellationToken)
        {
            var entity = new Rol_Permiso
            {
                rolID = request.RolId,
                permisoID = request.PermisoId
            };

            // Agregar la relación entre Rol y Permiso
            await _unitOfWork.RepositoryRol_Permiso.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            // Retornar Unit.Value como resultado
            return Unit.Value;
        }
    }



}
