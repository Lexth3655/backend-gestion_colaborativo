using AutoMapper;
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
    // Comando para ActualizarPermiso
    public record ActualizarPermisoCommand(int Id, string NombrePermiso) : IRequest<bool>;

    // Handler para ActualizarPermiso
    public class ActualizarPermisoCommandHandler : IRequestHandler<ActualizarPermisoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActualizarPermisoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ActualizarPermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = await _unitOfWork.RepositoryPermiso.FindAsync(request.Id);
            if (permiso == null) return false;

            permiso.nombrePermiso = request.NombrePermiso;
            permiso.fecha_modificado = DateTime.Now;

            _unitOfWork.RepositoryPermiso.UpdateAsync(permiso);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
