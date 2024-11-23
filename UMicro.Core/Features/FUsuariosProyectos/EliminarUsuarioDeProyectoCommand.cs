using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UMicro.Core.Interfaces;

namespace UMicro.Core.Features.FUsuariosProyectos
{

    public class EliminarUsuarioDeProyectoCommand : IRequest<Unit>
    {
        public int UsuarioID { get; set; }
        public int ProyectoID { get; set; }
    }

    public class EliminarUsuarioDeProyectoHandler : IRequestHandler<EliminarUsuarioDeProyectoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarUsuarioDeProyectoHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EliminarUsuarioDeProyectoCommand request, CancellationToken cancellationToken)
        {
            var usuarioProyecto = await _unitOfWork.RepositoryUsuarioProyecto.ObtenerPorUsuarioYProyectoAsync(request.UsuarioID, request.ProyectoID);

            if (usuarioProyecto != null)
            {
                await _unitOfWork.RepositoryUsuarioProyecto.DeleteAsync(usuarioProyecto);
                await _unitOfWork.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }

}
