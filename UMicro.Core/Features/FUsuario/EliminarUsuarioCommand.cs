using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UMicro.Core.Interfaces;

namespace UMicro.Core.Features.FUsuario
{
    public class EliminarUsuarioCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
    }

    public class EliminarUsuarioCommandHandler : IRequestHandler<EliminarUsuarioCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarUsuarioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.RepositoryUsuario.GetByIdAsync(request.UsuarioId);
            if (usuario == null) return false;

            await _unitOfWork.RepositoryUsuario.DeleteAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }

}
