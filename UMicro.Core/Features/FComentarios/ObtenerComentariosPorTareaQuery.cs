using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FComentario
{
    public class ObtenerComentariosPorTareaQuery : IRequest<List<Comentarios>>
    {
        public int TareaId { get; set; }
    }

    public class ObtenerComentariosPorTareaHandler : IRequestHandler<ObtenerComentariosPorTareaQuery, List<Comentarios>>
    {
        private readonly ApplicationDbContext _context;

        public ObtenerComentariosPorTareaHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comentarios>> Handle(ObtenerComentariosPorTareaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comentarios
                .Where(c => c.tareaID == request.TareaId)
                .OrderByDescending(c => c.FechaCreacion)
                .ToListAsync(cancellationToken);
        }
    }

}



}
