using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Features.FNotificaciones;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FNotificaciones
{
    public class ProgramarNotificacionCommand : IRequest<List<Notificacion>>
    {
        public int UserId { get; set; }
        public string TipoNotificacion { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
    public class ProgramarNotificacionHandler : IRequest<ProgramarNotificacionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ProgramarNotificacionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Notificacion> Handle(ProgramarNotificacionCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _unitOfWork.RepositoryNotificacion.GetByIdAsync(request.UserId);
            if (usuario == null) return null;

            if (request.FechaEnvio <= DateTime.UtcNow)
                throw new ArgumentException("La fecha de envío debe ser futura.");

            var notificacion = new Notificacion
            {
                userID = request.UserId,
                tipoNotificacion = request.TipoNotificacion,
                mensaje = request.Mensaje,
                fechaEnvio = request.FechaEnvio
            };

            await _unitOfWork.RepositoryNotificacion.AddAsync(notificacion);
            await _unitOfWork.SaveChangesAsync();
            return notificacion;
        }
    }

}


