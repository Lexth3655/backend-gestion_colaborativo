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
    public class ActualizarComentarioCommand : IRequest<Comentarios>
    {
        public int Id { get; set; }
        public string NuevoContenido { get; set; }
    }
    public class ActualizarComentarioHandler : IRequestHandler<ActualizarComentarioCommand, Comentarios>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ActualizarComentarioHandler( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Comentarios> Handle(ActualizarComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _unitOfWork.UpdateAsync(request.Id);
            if (comentario == null) return null;

            comentario.contenido = request.NuevoContenido;
            await _unitOfWork.SaveChangesAsync();
            return comentario;
        }
    }



}
