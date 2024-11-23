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
    public class AsignarRolAUsuarioCommand : IRequest<bool>
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public int ProyectoId { get; set; } // Si aplica, según la relación UsuarioProyecto
    }

    public class AsignarRolAUsuarioCommandHandler : IRequestHandler<AsignarRolAUsuarioCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AsignarRolAUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AsignarRolAUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Verificar si el usuario existe
            var usuario = await _unitOfWork.RepositoryUsuario.GetByIdAsync(request.UsuarioId);
            if (usuario == null)
                return false;

            // Verificar si el rol existe
            var rol = await _unitOfWork.RepositoryRol.GetByIdAsync(request.RolId);
            if (rol == null)
                return false;

            // Crear la relación UsuarioProyecto (si aplica)
            var usuarioProyecto = new UsuarioProyecto
            {
                usuarioID = request.UsuarioId,
                proyectoID = request.ProyectoId, // Asocia al proyecto
                rolID = request.RolId
            };

            // Agregar la relación a la base de datos
            await _unitOfWork.RepositoryUsuarioProyecto.AddAsync(usuarioProyecto);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }

}
