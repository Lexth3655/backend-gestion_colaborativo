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
    public class AgregarComentarioATarea : IRequest<Comentarios>
    {
        public int TareaId { get; set; }
        public int UsuarioId { get; set; }
        public string Contenido { get; set; }
    }
    public class AgregarComentarioHandler : IRequestHandler<AgregarComentarioATarea, Comentarios>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgregarComentarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork; 
        }

        public async Task<Comentarios> Handle(AgregarComentarioATarea request, CancellationToken cancellationToken)
        {
            var tarea = await _unitOfWork.RepositoryTarea.GetByIdAsync(request.TareaId);
            if (tarea == null) return null;

            var comentario = new Comentarios
            {
                tareaID = request.TareaId,
                usuarioID = request.UsuarioId,
                contenido = request.Contenido,
                FechaCreacion = DateTime.UtcNow
            };

            await _unitOfWork.RepositoryComentarios.AddAsync(comentario);
            await _unitOfWork.SaveChangesAsync();
            return comentario;
        }
    }



}
