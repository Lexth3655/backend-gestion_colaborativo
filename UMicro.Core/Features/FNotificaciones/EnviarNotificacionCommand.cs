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
    public class EnviarNotificacionCommand : IRequest<Notificacion>
    {
        public int UserId { get; set; }
        public string TipoNotificacion { get; set; }
        public string Mensaje { get; set; }
    }
}

public class EnviarNotificacionHandler: IRequestHandler<EnviarNotificacionCommand, Notificacion>
{
    private readonly ApplicationDbContext _context;

    public async Task<Notificacion> Handle(EnviarNotificacionCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _context.Usuarios.FindAsync(request.UserId);
        if (usuario == null) return null;

        var notificacion = new Notificacion
        {
            userID = request.UserId,
            tipoNotificacion = request.TipoNotificacion,
            mensaje = request.Mensaje,
            fechaEnvio = DateTime.UtcNow
        };

        _context.Notificaciones.Add(notificacion);
        await _context.SaveChangesAsync(cancellationToken);

        return notificacion;
    }
}


