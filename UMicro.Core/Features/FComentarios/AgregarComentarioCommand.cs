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
    public class AgregarComentarioCommand : IRequest<Comentarios>
    {
        public int TareaId { get; set; }
        public int UsuarioId { get; set; }
        public string Contenido { get; set; }
    }
    public class AgregarComentarioHandler : IRequestHandler<AgregarComentarioCommand, Comentarios>
    {
        private readonly ApplicationDbContext _context;

        public AgregarComentarioHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comentarios> Handle(AgregarComentarioCommand request, CancellationToken cancellationToken)
        {
            var tarea = await _context.Tareas.FindAsync(request.TareaId);
            if (tarea == null) return null;

            var comentario = new Comentarios
            {
                tareaID = request.TareaId,
                usuarioID = request.UsuarioId,
                contenido = request.Contenido,
                FechaCreacion = DateTime.UtcNow
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync(cancellationToken);
            return comentario;
        }
    }



}
