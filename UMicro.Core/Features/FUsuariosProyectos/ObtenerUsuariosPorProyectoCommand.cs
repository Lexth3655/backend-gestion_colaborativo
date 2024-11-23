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
    public class ObtenerUsuariosPorProyectoCommand : IRequest<List<UsuarioProyecto>>
    {
        public int ProyectoID { get; set; }
    }

    public class ObtenerUsuariosPorProyectoHandler : IRequestHandler<ObtenerUsuariosPorProyectoCommand, List<UsuarioProyecto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerUsuariosPorProyectoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UsuarioProyecto>> Handle(ObtenerUsuariosPorProyectoCommand request, CancellationToken cancellationToken)
        {
            var usuariosProyecto = await _unitOfWork.RepositoryUsuarioProyecto.ObtenerPorUsuarioYProyectoAsync(request.ProyectoID);
            return _mapper.Map<List<UsuarioProyecto>>(usuariosProyecto);
        }
    }

}
