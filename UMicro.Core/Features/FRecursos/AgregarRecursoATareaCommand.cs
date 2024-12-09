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
    public class AgregarRecursoATareaCommand : IRequest<Recurso>
    {
        public int tareasID { get; set; }
        public string nombreRecurso { get; set; }
        public string url { get; set; }
        public string tipoRecurso { get; set; }
        public int TareaId { get; set; }
    }
    public class AgregarRecursoCommandHandler : IRequest<AgregarRecursoATareaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgregarRecursoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(AgregarRecursoATareaCommand request, CancellationToken cancellationToken)
        {
            var recurso = new Recurso
            {
                tareasID = request.tareasID,
                nombreRecurso = request.nombreRecurso,
                url = request.url,
                tipoRecurso = request.tipoRecurso
            };

            await _unitOfWork.RepositoryRecurso.AddAsync(recurso);
            await _unitOfWork.SaveChangesAsync();

            return recurso.Id; 
        }



    }
}
