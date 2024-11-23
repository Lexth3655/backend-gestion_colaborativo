using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FUsuariosProyectos
{
    public class ObtenerProyectosPorUsuarioCommand : IRequest<List<UsuarioProyecto>>
    {
        public int UsuarioID { get; set; }
    }


    public class ObtenerProyectosPorUsuarioHandler : IRequestHandler<ObtenerProyectosPorUsuarioCommand, List<UsuarioProyecto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerProyectosPorUsuarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UsuarioProyecto>> Handle(ObtenerProyectosPorUsuarioCommand request, CancellationToken cancellationToken)
        {
            var proyectosUsuario = await _unitOfWork.RepositoryUsuarioProyecto.ObtenerPorUsuarioYProyectoAsync(request.UsuarioID);
            return _mapper.Map<List<UsuarioProyecto>>(proyectosUsuario);
        }
    }

}
