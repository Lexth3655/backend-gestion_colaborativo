using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Core.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Features.FRecursos
{
    public class ActualizarRecursoCommand : IRequest<Recurso>
    {
        public int tareasID { get; set; }
        public string nombreRecurso { get; set; }
        public string url { get; set; }
        public string tipoRecurso { get; set; }
        public int Id { get; internal set; }
    }
    public class ActualizarRecursoCommandHandler : IRequest<ActualizarRecursoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ActualizarRecursoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork; 
        }

        public async Task<Unit> Handle(ActualizarRecursoCommand request, CancellationToken cancellationToken)
        {
            var recurso = await _unitOfWork.RepositoryRecurso.GetByIdAsync(request.Id);
            if (recurso == null)
                throw new FileNotFoundException("Recurso no encontrado.");

            recurso.nombreRecurso = request.nombreRecurso;
            recurso.url = request.url;
            recurso.tipoRecurso = request.tipoRecurso;

            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }

}
