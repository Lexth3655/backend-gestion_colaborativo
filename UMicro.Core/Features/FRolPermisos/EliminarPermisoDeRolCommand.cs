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
    public record EliminarPermisoDeRolCommand(int RolId, int PermisoId) : IRequest<Unit>;

    public class EliminarPermisoDeRolHandler : IRequestHandler<EliminarPermisoDeRolCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPermisoDeRolHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EliminarPermisoDeRolCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.RepositoryRol_Permiso.FindAsync(new object[] { request.RolId, request.PermisoId });
            if (entity == null)
                throw new KeyNotFoundException("No se encontró la relación Rol-Permiso.");

            _unitOfWork.RepositoryRol_Permiso.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }


}
