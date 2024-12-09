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
    public class ObtenerRecursosPorTareaQuery : IRequest <ActualizarRecursoCommand>
    {
        public int TareaID { get; set; }
    }
    public class ObtenerRecursosPorTareaQueryHandler : IRequest<ObtenerRecursosPorTareaQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerRecursosPorTareaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Recurso>> Handle(ObtenerRecursosPorTareaQuery request, CancellationToken cancellationToken)
        {
            var ListRecurso =  _unitOfWork.RepositoryRecurso.GetAll();
            return ListRecurso.Select(r => new Recurso
            {
                Id = r.Id,
                nombreRecurso = r.nombreRecurso,
                url = r.url,
                tipoRecurso = r.tipoRecurso
            })
                .Where(r => r.tareasID == request.TareaID)
                .OrderBy(r => r.nombreRecurso)
                .ToList();
        }
    }
}
