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
    public class RegistrarUsuarioCommand : IRequest<Usuario>
    {
        public string nombre { get; set; }
        public string correo { get; set; }
        public string Password { get; set; }
    }

    public class RegistrarUsuarioCommandHandler : IRequestHandler<RegistrarUsuarioCommand, Usuario>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RegistrarUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Usuario> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario
            {
                nombre = request.nombre,
                correo = request.correo,
                // En un escenario real, asegúrate de hashear la contraseña antes de guardarla.
            };

            var result = await _unitOfWork.RepositoryUsuario.AddAsync(usuario);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }

}
