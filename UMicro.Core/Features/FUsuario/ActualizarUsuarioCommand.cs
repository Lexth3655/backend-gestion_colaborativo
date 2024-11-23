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
    public class ActualizarUsuarioCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
    }

    public class ActualizarUsuarioCommandHandler : IRequestHandler<ActualizarUsuarioCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActualizarUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.RepositoryUsuario.GetByIdAsync(request.UsuarioId);
            if (usuario == null) return false;

            usuario.nombre = request.nombre;
            usuario.correo = request.correo;

            await _unitOfWork.RepositoryUsuario.UpdateAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }

}
