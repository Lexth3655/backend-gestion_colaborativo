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
    public class EliminarComentarioCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
    public class EliminarComentarioHandler : IRequestHandler<EliminarComentarioCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public EliminarComentarioHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(EliminarComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _context.Comentarios.FindAsync(request.Id);
            if (comentario == null) return false;

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }



}
