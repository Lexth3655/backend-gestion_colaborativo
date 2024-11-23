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
    public class AsignarUsuarioAProyectoCommand : IRequest<UsuarioProyecto>
    {
        public int UsuarioID { get; set; }
        public int ProyectoID { get; set; }
        public int RolID { get; set; }
    }

    public class AsignarUsuarioAProyectoHandler : IRequestHandler<AsignarUsuarioAProyectoCommand, UsuarioProyecto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AsignarUsuarioAProyectoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UsuarioProyecto> Handle(AsignarUsuarioAProyectoCommand request, CancellationToken cancellationToken)
        {
            var usuarioProyecto = new UsuarioProyecto
            {
                usuarioID = request.UsuarioID,
                proyectoID = request.ProyectoID,
                rolID = request.RolID,
                FechaAsignacion = DateTime.UtcNow
            };

            await _unitOfWork.RepositoryUsuarioProyecto.AddAsync(usuarioProyecto);
            await _unitOfWork.SaveChangesAsync();
            return usuarioProyecto;
        }
    }

}
