using AutoMapper;
using MediatR;
using UMicro.Core.Features.FNotificaciones;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FNotificaciones
{
    public class EnviarNotificacionCommand : IRequest<Notificacion>
    {
        public int UserId { get; set; }
        public string TipoNotificacion { get; set; }
        public string Mensaje { get; set; }
    }
}

public class EnviarNotificacionHandler: IRequestHandler<EnviarNotificacionCommand, Notificacion>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public EnviarNotificacionHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    //public Task<Notificacion> Handle(EnviarNotificacionCommand request, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<Notificacion> Handle(EnviarNotificacionCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _unitOfWork.RepositoryNotificacion.GetByIdAsync(request.UserId);
        if (usuario == null) return null;

        var notificacion = new Notificacion
        {
            userID = request.UserId,
            tipoNotificacion = request.TipoNotificacion,
            mensaje = request.Mensaje,
            fechaEnvio = DateTime.UtcNow
        };

        await _unitOfWork.RepositoryNotificacion.AddAsync(notificacion);
        await _unitOfWork.SaveChangesAsync();

        return notificacion;
    }
}


