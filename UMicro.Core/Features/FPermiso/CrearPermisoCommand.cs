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
    // Comando para CrearPermiso
    public record CrearPermisoCommand(string NombrePermiso) : IRequest<int>;

    // Handler para CrearPermiso
    public class CrearPermisoCommandHandler : IRequestHandler<CrearPermisoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrearPermisoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CrearPermisoCommand request, CancellationToken cancellationToken)
        {
            var permiso = new Permiso { 
                nombrePermiso = request.NombrePermiso,
                descripcion = " ",
                fecha_creado = DateTime.Now,
                activo = true
               
            };
            var result = _mapper.Map<Permiso>(permiso);
            await _unitOfWork.RepositoryPermiso.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();
            return result.id;
        }
    }

}
