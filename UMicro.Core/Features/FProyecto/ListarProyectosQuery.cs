using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FProyecto
{
    public class ListarProyectosDeUsuarioQuery : IRequest<IEnumerable<Proyecto>>
    {
        public int UsuarioId { get; set; }
    }

    public class ListarProyectosDeUsuarioQueryHandler : IRequestHandler<ListarProyectosDeUsuarioQuery, IEnumerable<Proyecto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListarProyectosDeUsuarioQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Proyecto>> Handle(ListarProyectosDeUsuarioQuery request, CancellationToken cancellationToken)
        {
            // Obtener los proyectos del usuario mediante el repositorio
            var proyectos = await _unitOfWork.RepositoryUsuarioProyecto.GetProyectosDeUsuarioAsync(request.UsuarioId);

            if (proyectos == null || !proyectos.Any())
                throw new KeyNotFoundException("El usuario no participa en ningún proyecto.");

            // Retornar los proyectos mapeados (si es necesario)
            return _mapper.Map<IEnumerable<Proyecto>>(proyectos);
        }
    }
}
