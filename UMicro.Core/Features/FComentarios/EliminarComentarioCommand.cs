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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EliminarComentarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _unitOfWork.RepositoryComentarios.GetByIdAsync(request.Id);
            if (comentario == null) return false;

            await _unitOfWork.RepositoryComentarios.DeleteAsync(comentario);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }



}
