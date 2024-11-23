using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FUsuariosProyectos
{
    public class ObtenerUsuariosDeProyectoCommand : IRequest<List<Usuario>>
    {
        public int ProyectoID { get; set; }
    }


    public class ObtenerUsuariosDeProyectoHandler : IRequestHandler<ObtenerUsuariosDeProyectoCommand, List<Usuario>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerUsuariosDeProyectoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Usuario>> Handle(ObtenerUsuariosDeProyectoCommand request, CancellationToken cancellationToken)
        {
            var usuariosProyectos = await _unitOfWork.RepositoryUsuarioProyecto.GetUsuariosByProyectoIdAsync(request.ProyectoID);
            return usuariosProyectos.Select(up => up.Usuario).ToList();
        }
    }

}
