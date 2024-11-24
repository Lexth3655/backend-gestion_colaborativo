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
    public class ObtenerNotificacionesPorUsuarioQuery : IRequest<List<Notificacion>>
    {
        public int UserId { get; set; }
    }
}
public class ObtenerNotificacionesPorUsuarioHandler : IRequestHandler<ObtenerNotificacionesPorUsuarioQuery, List<Notificacion>>
{
    private readonly ApplicationDbContext _context;

    public async Task<List<Notificacion>> Handle(ObtenerNotificacionesPorUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await _context.Notificaciones
            .Where(n => n.userID == request.UserId)
            .OrderByDescending(n => n.fechaEnvio)
            .ToListAsync(cancellationToken);
    }
}

