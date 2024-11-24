using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FPermiso
{
    // Comando para EliminarPermiso
    public record EliminarPermisoCommand(int Id) : IRequest<bool>;

    // Handler para EliminarPermiso
    public class EliminarPermisoCommandHandler : IRequestHandler<EliminarPermisoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPermisoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarPermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = await _unitOfWork.RepositoryPermiso.FindAsync(request.Id);
            if (permiso == null) return false;

            await _unitOfWork.RepositoryPermiso.DeleteAsync(permiso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
