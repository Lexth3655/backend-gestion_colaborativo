using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;

namespace UMicro.Core.Features.FRoles
{
    public class ActualizarRolCommand : IRequest<bool>
    {
        public int RolId { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
    }

    public class ActualizarRolCommandHandler : IRequestHandler<ActualizarRolCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActualizarRolCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(ActualizarRolCommand request, CancellationToken cancellationToken)
        {
            var rol = await _unitOfWork.RepositoryRol.GetByIdAsync(request.RolId);
            if (rol == null) return false;
            rol.nombreRol = request.NombreRol;
            rol.descripcion = request.Descripcion;
            rol.fecha_modificado = DateTime.Now;
            _mapper.Map(request, rol);
            _unitOfWork.RepositoryRol.UpdateAsync(rol);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
