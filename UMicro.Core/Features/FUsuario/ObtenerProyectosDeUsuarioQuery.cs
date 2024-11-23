using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FUsuario
{
    public class ObtenerProyectosDeUsuarioQuery : IRequest<IEnumerable<Proyecto>>
    {
        public int UsuarioId { get; set; }
    }

    public class ObtenerProyectosDeUsuarioQueryHandler : IRequestHandler<ObtenerProyectosDeUsuarioQuery, IEnumerable<Proyecto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ObtenerProyectosDeUsuarioQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Proyecto>> Handle(ObtenerProyectosDeUsuarioQuery request, CancellationToken cancellationToken)
        {
            // Verifica si el usuario existe
            var usuario = await _unitOfWork.RepositoryUsuario.GetByIdAsync(request.UsuarioId);
            if (usuario == null)
                throw new KeyNotFoundException("Usuario no encontrado.");

            // Obtiene los proyectos asociados al usuario
            var proyectos = await _unitOfWork.RepositoryUsuarioProyecto
                .GetProyectosDeUsuarioAsync(request.UsuarioId);

            return proyectos;
        }
    }

}
