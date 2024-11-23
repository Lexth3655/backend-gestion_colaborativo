using AutoMapper;
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
    public class CrearRolCommand: IRequest<int>
    {
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
    }

    public class CrearRolCommandHandler : IRequestHandler<CrearRolCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CrearRolCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CrearRolCommand request, CancellationToken cancellationToken)
        {
            var rol = new Roles
            {
                nombreRol = request.NombreRol,
                descripcion = request.Descripcion,
                fecha_creado = DateTime.Now,
                activo = true
            };
            var result = _mapper.Map<Roles>(rol);
            await _unitOfWork.RepositoryRol.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();
            return rol.id;
        }
    }

}
